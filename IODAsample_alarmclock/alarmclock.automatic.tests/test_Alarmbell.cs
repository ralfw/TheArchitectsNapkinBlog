using System;
using NUnit.Framework;
using alarmclock.head;
using System.IO;

namespace alarmclock.automatic.tests
{
	[TestFixture]
	public class test_Alarmbell
	{
		[Test, Explicit]
		public void Ring_OSX_bell()
		{
			IAlarmbell sut = new AlarmbellOSX ();
			sut.Ring ();
		}
	}
}

