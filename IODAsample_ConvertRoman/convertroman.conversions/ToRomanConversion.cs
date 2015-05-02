using System;

namespace convertroman.head
{
	public static class ToRomanConversion {
		public static string Convert(int arabicNumber) {
			return arabicNumber.ToString() + "->XLII";
		}
	}
}