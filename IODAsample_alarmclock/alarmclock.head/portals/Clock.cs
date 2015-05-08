using System;
using System.Threading;

namespace alarmclock.head
{
	public class Clock : IDisposable
	{
		Timer timer;

		public Clock ()
		{
			this.timer = new Timer (_ => {
				this.OnCurrentTime(DateTime.Now);
			}, null, 0, 1000);
		}

		#region IDisposable implementation

		public void Dispose () {
			this.timer.Change (Timeout.Infinite, Timeout.Infinite);
		}

		#endregion

		public event Action<DateTime> OnCurrentTime = _ => {};
	}
}

