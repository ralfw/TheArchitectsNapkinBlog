using System;
using System.Diagnostics;

namespace alarmclock.head
{
	public interface IAlarmbell : IDisposable {
		void Ring();
	}
}