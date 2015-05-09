using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using alarmclock.body;
using Akka.Actor;

namespace alarmclock.head
{

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
			Receive<CurrentTimeEvent> (e => dog.Check (e.CurrentTime));
		}
	}

}