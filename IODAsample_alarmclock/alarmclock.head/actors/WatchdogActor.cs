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
		public WatchdogActor(Watchdog dog, string onRemainingTimeActornames, string[] onWakeupTimeDiscoveredActornames) {
			Receive<StartCommand> (cmd => dog.Start_watching_for (cmd.WakeupTime));
			Receive<StopCommand> (_ => dog.Stop_watching());
			Receive<CurrentTimeEvent> (e => dog.Check (e.CurrentTime));

			var self = Self;
			var onRemainingTime = new ActorMultiRef (Context, onRemainingTimeActornames);
			var onWakeupTimeDiscovered = new ActorMultiRef (Context, onWakeupTimeDiscoveredActornames);

			dog.OnRemainingTime += remainingTime => {
				var e = new RemainingTimeEvent{RemainingTime = remainingTime};
				onRemainingTime.Tell(e, self);
			};

			dog.OnWakeuptimeDiscovered += () => {
				var e = new WakeupTimeDiscoveredEvent();
				onWakeupTimeDiscovered.Tell(e, self);
			};
		}
	}
}