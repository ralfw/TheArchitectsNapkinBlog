using System;
using System.Diagnostics;


namespace alarmclock.head
{
	public class AlarmbellOSX : IAlarmbell
	{
		public void Ring() {
			
			var pi = new ProcessStartInfo ("afplay", "alarm.mp3");
			Process.Start (pi);
		}

		public void Dispose() {}
	}
}