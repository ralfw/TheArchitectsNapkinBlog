using System;

namespace convertroman.contracts
{
	public interface IOutputProvider {
		void Display_result (string result);
		void Display_error(string errorMessage);
	}
}