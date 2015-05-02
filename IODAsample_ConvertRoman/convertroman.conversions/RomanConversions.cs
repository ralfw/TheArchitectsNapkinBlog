using System;

namespace convertroman.conversions
{
	public static class RomanConversions {
		public static void Determine_number_type(string number, Action<string> isRoman, Action<int> isArabic) {
			var arabic = 0;
			if (int.TryParse (number, out arabic))
				isArabic (arabic);
			else
				isRoman (number);
		}


		public static void Validate_roman_number(string romanNumber, Action<string> isValid, Action<string> isInvalid) {
			if (System.Text.RegularExpressions.Regex.Match (romanNumber.ToUpper (), "^[IVXLCDM]+$").Success)
				isValid (romanNumber);
			else
				isValid ("Invalid roman digit found in " + romanNumber);
		}


		public static void Validate_arabic_number(int arabicNumber, Action<int> isValid, Action<string> isInvalid) {
			if (arabicNumber >= 0 && arabicNumber <= 3000)
				isValid (arabicNumber);
			else
				isInvalid ("Arabic number must be in range 0..3000");
		}
	}
}
