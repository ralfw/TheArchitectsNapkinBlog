using System;
using System.Collections.Generic;
using System.Linq;

namespace convertroman.conversions
{
	public static class ToRomanConversion {
		private static readonly Dictionary<int,string> MAP = new Dictionary<int,string>{ 
			{1000, "M"}, {900, "CM"}, {500, "D"}, {400, "CD"},
			{100, "C"}, {90, "XC"}, {50, "L"}, {40, "XL"},
			{10, "X"}, {9, "IX"}, {5, "V"}, {4, "IV"},
			{1, "I"}
		};


		public static string Convert(int arabicNumber) {
			var factors = Factorize (arabicNumber);
			var digits = Map_factors_to_digits (factors);
			return Build_from_digits (digits);
		}


		private static IEnumerable<int> Factorize(int arabicNumber) {
			while (arabicNumber > 0) {
				foreach (var f in MAP.Keys)
					while (arabicNumber >= f) {
						yield return f;
						arabicNumber -= f;
					}
			}
		}


		private static IEnumerable<string> Map_factors_to_digits(IEnumerable<int> factors) {
			return factors.Select (f => MAP [f]);
		}


		private static string Build_from_digits(IEnumerable<string> digits) {
			return string.Join ("", digits);
		}
	}
}