using System;
using System.Linq;
using System.Collections.Generic;

namespace convertroman.conversions
{
	public static class FromRomanConversion
	{
		public static int Convert(string romanNumber) {
			var values = Map_to_values (romanNumber);
			var negatedValues = Apply_subtraction_rule (values);
			return negatedValues.Sum ();
		}


		private static int[] Map_to_values(string romanNumber) {
			var map = new Dictionary<char,int>{ 
				{'I', 1},{'V', 5},{'X', 10},
				{'L', 50},{'C', 100},{'D', 500},
				{'M', 1000},
			};

			return romanNumber.ToUpper ().ToCharArray ()
							  .Select (d => map [d])
				   			  .ToArray ();
		}


		private static int[] Apply_subtraction_rule(int[] values) {
			var negatedValues = new int[values.Length];
			values.CopyTo (negatedValues, 0);

			for (var i = 0; i < negatedValues.Length - 1; i++)
				if (negatedValues [i + 1] > negatedValues [i])
					negatedValues[i] *= -1;

			return negatedValues;
		}
	}

}
