using System;
using NUnit.Framework;
using alarmclock.head;

namespace alarmclock.automatic.tests
{
	[TestFixture]
	public class test_Clock
	{
		[Test, Explicit]
		public void It_ticks ()
		{
			using (var sut = new Clock ()) {
				sut.OnCurrentTime += _ => Console.WriteLine("The clock is ticking: {0}", _);

				System.Threading.Thread.Sleep (5000);
			}
		}
	}
}