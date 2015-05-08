using System;
using System.Diagnostics;

namespace alarmclock.head
{
	public class AlarmbellWin : IAlarmbell
	{
		public void Ring() {
			var player = new System.Media.SoundPlayer("Alarm.wav");
			player.Load ();
			player.PlaySync();
		}

		public void Dispose() {}
	}
}