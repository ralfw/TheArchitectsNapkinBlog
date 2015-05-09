using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using alarmclock.body;
using Akka.Actor;

namespace alarmclock.head
{
	class DlgActor : ReceiveActor {
		public DlgActor(DlgAlarmclock dlg, IActorRef onStart, IActorRef onStop) {
			Receive<CurrentTimeEvent> (e => dlg.Update_current_time (e.CurrentTime));
			Receive<RemainingTimeEvent> (e => dlg.Update_remaining_time (e.RemainingTime));
			Receive<WakeupTimeDiscoveredEvent> (_ => dlg.Wakeup_time_reached ());


			var self = Self;

			dlg.OnStartRequested += wakeupTime => {
				var cmd = new StartCommand{WakeupTime = wakeupTime};
				onStart.Tell(cmd, self);
			};

			dlg.OnStopRequested += () => {
				var cmd = new StopCommand();
				onStop.Tell(cmd, self);
			};
		}
	}
}