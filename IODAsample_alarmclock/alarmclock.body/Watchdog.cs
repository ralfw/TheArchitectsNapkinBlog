using System;

namespace alarmclock.body
{
	public class Watchdog {
		private bool watching;
		private DateTime wakeuptime;

		public void Start_watching_for(DateTime wakeuptime) {
			this.wakeuptime = wakeuptime;
			this.watching = true;
		}

		public void Stop_watching() {
			this.watching = false;
		}

		public void Check(DateTime currentTime) {
			if (this.watching) {
				var remainingTime = this.wakeuptime.Subtract (currentTime);
				if (remainingTime.TotalSeconds <= 0) {
					this.watching = false;
					this.OnRemainingTime (new TimeSpan(0,0,0));
					this.OnWakeuptimeDiscovered ();
				}
				else
					this.OnRemainingTime (remainingTime);
			}
		}

		public event Action<TimeSpan> OnRemainingTime;
		public event Action OnWakeuptimeDiscovered;
	}
}