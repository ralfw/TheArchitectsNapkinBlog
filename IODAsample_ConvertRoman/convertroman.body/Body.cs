using System;
using convertroman.contracts;
using convertroman.conversions;

namespace convertroman.body
{
	public class Body
	{
		IOutputProvider output;

		public Body (IOutputProvider output) {
			this.output = output;
		}


		public string Convert(string number) {
			string result = null;

			RomanConversions.Determine_number_type (number,
				romanNumber => 
					RomanConversions.Validate_roman_number(romanNumber,
						romanNumber_ => {
							result = FromRomanConversion.Convert(romanNumber_);
						},
						output.Display_error),
				arabicNumber =>
				RomanConversions.Validate_arabic_number(arabicNumber,
					arabicNumber_ => {
						result = ToRomanConversion.Convert(arabicNumber_);
					},
					output.Display_error));

			return result;
		}
	}
}