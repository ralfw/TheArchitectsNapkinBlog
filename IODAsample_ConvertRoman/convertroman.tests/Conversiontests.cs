using System;
using NUnit.Framework;
using convertroman.conversions;

namespace convertroman.tests
{
	[TestFixture]
	public class Conversiontests
	{
		[TestCase("I", 1)]
		[TestCase("IV", 4)]
		[TestCase("MCMLXXXIV", 1984)]
		[TestCase("MMXV", 2015)]
		public void From_roman(string romanNumber, int expected) {
			Assert.AreEqual (expected, FromRomanConversion.Convert (romanNumber));
		}


		[TestCase(1, "I")]
		[TestCase(4, "IV")]
		[TestCase(1984, "MCMLXXXIV")]
		[TestCase(2015, "MMXV")]
		public void From_roman(int arabicNumber, string expected) {
			Assert.AreEqual (expected, ToRomanConversion.Convert (arabicNumber));
		}
	}
}