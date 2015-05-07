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

			sut.Start_watching_for (new DateTime (2015, 1, 1, 10, 0, 0));
			sut.Check (new DateTime (2015, 1, 1, 9, 55, 35));

			Assert.AreEqual (new TimeSpan(0,4,25), result);
		}


		[Test ()]
		public void Wakeuptime_discovered ()
		{
			var sut = new Watchdog ();

			var result = TimeSpan.MinValue;
			sut.OnRemainingTime += _ => result = _;

			var resultDiscovery = false;
			sut.OnWakeuptimeDiscovered += () => resultDiscovery = true;

			sut.Start_watching_for (new DateTime (2015, 1, 1, 10, 0, 0));
			sut.Check (new DateTime (2015, 1, 1, 10, 0, 0));

			Assert.AreEqual (new TimeSpan(0,0,0), result);
			Assert.IsTrue (resultDiscovery);
		}


		[Test ()]
		public void Wakeuptime_discovered_even_if_already_past ()
		{
			var sut = new Watchdog ();

			var result = TimeSpan.MinValue;
			sut.OnRemainingTime += _ => result = _;

			var resultDiscovery = false;
			sut.OnWakeuptimeDiscovered += () => resultDiscovery = true;

			sut.Start_watching_for (new DateTime (2015, 1, 1, 10, 0, 0));
			sut.Check (new DateTime (2015, 1, 1, 10, 1, 10));

			Assert.AreEqual (new TimeSpan(0,0,0), result);
			Assert.IsTrue (resultDiscovery);
		}
	}
}