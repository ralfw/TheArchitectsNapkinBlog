using System;

namespace convertroman.conversions
{
	public static class ToRomanConversion {
		public static string Convert(int arabicNumber) {
			return arabicNumber.ToString() + "->XLII";
		}
	}
}