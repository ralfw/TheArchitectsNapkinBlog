using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using alarmclock.body;
using Akka.Actor;

namespace alarmclock.head
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			IAlarmbell bell = new AlarmbellOSX ();
			var clock = new Clock ();
			var dog = new Watchdog ();
			var dlg = new DlgAlarmclock ();


			var sys = ActorSystem.Create("MyActorSystem");

			var bellActorProps = Props.Create<AlarmbellActor> (bell);
			sys.ActorOf (bellActorProps, "AlarmbellActor");

			var dogActorProps = Props.Create<WatchdogActor> (dog, "DlgActor", new[]{"DlgActor", "AlarmbellActor"});
			var dogActor = sys.ActorOf (dogActorProps, "WatchdogActor");

			var dlgActorProps = Props.Create<DlgActor>(dlg, dogActor, dogActor)
									 .WithDispatcher("akka.actor.synchronized-dispatcher");
			var dlgActor = sys.ActorOf(dlgActorProps, "DlgActor");


			clock.OnCurrentTime += t => {
				var e = new CurrentTimeEvent{CurrentTime=t};
				dlgActor.Tell(e);
				dogActor.Tell(e);
			};


            Application.Run(dlg);
        }
    }


	class CurrentTimeEvent {
		public DateTime CurrentTime;
	}

	class RemainingTimeEvent {
		public TimeSpan RemainingTime;
	}

	class WakeupTimeDiscoveredEvent {}

	class StartCommand {
		public DateTime WakeupTime;
	}

	class StopCommand {}



	class DlgActor : ReceiveActor {
		public DlgActor(DlgAlarmclock dlg, IActorRef onStart, IActorRef onStop) {
			var self = Self;

			dlg.OnStartRequested += wakeupTime => {
				var cmd = new StartCommand{WakeupTime = wakeupTime};
				onStart.Tell(cmd, self);
			};

			dlg.OnStopRequested += () => {
				var cmd = new StopCommand();
				onStop.Tell(cmd, self);
			};

			Receive<CurrentTimeEvent> (e => dlg.Update_current_time (e.CurrentTime));
			Receive<RemainingTimeEvent> (e => dlg.Update_remaining_time (e.RemainingTime));
			Receive<WakeupTimeDiscoveredEvent> (_ => dlg.Wakeup_time_reached ());
		}
	}


	class WatchdogActor : ReceiveActor {
		public WatchdogActor(Watchdog dog, string onRemainingTime, string[] onWakeupTimeDiscovered) {
			var self = Self;
			var bc = new ActorBroadcast (Context);

			dog.OnRemainingTime += remainingTime => {
				var e = new RemainingTimeEvent{RemainingTime = remainingTime};
				bc.Tell(new[]{onRemainingTime}, e, self);
			};

			dog.OnWakeuptimeDiscovered += () => {
				var e = new WakeupTimeDiscoveredEvent();
				bc.Tell(onWakeupTimeDiscovered, e, self);
			};

			Receive<StartCommand> (cmd => dog.Start_watching_for (cmd.WakeupTime));
			Receive<StopCommand> (_ => dog.Stop_watching());
		}
	}


	class AlarmbellActor : ReceiveActor {
		public AlarmbellActor(IAlarmbell bell) {
			Receive<WakeupTimeDiscoveredEvent> (_ => bell.Ring ());
		}
	}


	class ActorBroadcast {
		IActorContext ctx;

		public ActorBroadcast(IActorContext ctx) {
			this.ctx = ctx;
		}

		public void Tell(string[] receiverNames, object msg) { Tell (receiverNames, msg, null); }

		public void Tell(string[] receiverNames, object msg, IActorRef sender) {
			receiverNames.ToList ().ForEach (n => {
				var path = n.IndexOf("/") >= 0 ? n : "/user/" + n;
				var receiver = this.ctx.ActorSelection(path);
				receiver.Tell(msg, sender);
			});	
		}
	}
}