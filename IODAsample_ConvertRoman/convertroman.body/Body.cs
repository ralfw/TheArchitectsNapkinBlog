using System;
using convertroman.contracts;
using convertroman.conversions;

namespace convertroman.body
{
	public class Body : IBody
	{
		public void Convert(string number, Action<string> onSuccess, Action<string> onError) {
			RomanConversions.Determine_number_type (number,
				romanNumber => 
					RomanConversions.Validate_roman_number(romanNumber,
						() => {
							var result = FromRomanConversion.Convert(romanNumber);
							onSuccess(result.ToString());
						},
						onError),
				arabicNumber =>
					RomanConversions.Validate_arabic_number(arabicNumber,
						() => {
							var result = ToRomanConversion.Convert(arabicNumber);
							onSuccess(result);
						},
						onError));
		}
	}
}