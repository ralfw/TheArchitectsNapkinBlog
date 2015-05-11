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


			using (IAlarmbell bell = new AlarmbellOSX ())
			using (var clock = new Clock ()) {
				var dog = new Watchdog ();
				var dlg = new DlgAlarmclock ();


				var sys = ActorSystem.Create ("MyActorSystem");

				var bellActorProps = Props.Create<AlarmbellActor> (bell);
				sys.ActorOf (bellActorProps, "AlarmbellActor");

				var dogActorProps = Props.Create<WatchdogActor> (dog, "DlgActor", new[]{ "DlgActor", "AlarmbellActor" });
				var dogActor = sys.ActorOf (dogActorProps, "WatchdogActor");

				var dlgActorProps = Props.Create<DlgActor> (dlg, dogActor, dogActor)
									 .WithDispatcher ("akka.actor.synchronized-dispatcher");
				var dlgActor = sys.ActorOf (dlgActorProps, "DlgActor");


				clock.OnCurrentTime += t => {
					var e = new CurrentTimeEvent{ CurrentTime = t };
					dlgActor.Tell (e);
					dogActor.Tell (e);
				};


				Application.Run (dlg);
			}
        }
    }
}