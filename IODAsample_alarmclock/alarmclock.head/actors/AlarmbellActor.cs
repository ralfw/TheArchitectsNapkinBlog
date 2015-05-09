using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using alarmclock.body;
using Akka.Actor;

namespace alarmclock.head
{
	class AlarmbellActor : ReceiveActor {
		public AlarmbellActor(IAlarmbell bell) {
			Receive<WakeupTimeDiscoveredEvent> (_ => bell.Ring ());
		}
	}
}