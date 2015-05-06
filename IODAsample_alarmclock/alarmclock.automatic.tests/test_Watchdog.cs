using NUnit.Framework;
using System;
using alarmclock.body;

namespace alarmclock.automatic.tests
{
	[TestFixture ()]
	public class test_Watchdog
	{
		[Test ()]
		public void Nothing_discovered ()
		{
			var sut = new Watchdog ();

			TimeSpan result = TimeSpan.MinValue;
			sut.OnRemainingTime += _ => result = _;

			sut.Start_watching_for (new DateTime (10, 0, 0));
			sut.Check (new DateTime (9, 55, 35));

			Assert.AreEqual (new TimeSpan(0,4,25), result);
		}
	}
}