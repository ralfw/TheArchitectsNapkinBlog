using System;
using convertroman.contracts;

namespace convertroman.providers
{
	public class Providers : IInputProvider, IOutputProvider
	{
		#region IInputProvider implementation

		public string Read_number_to_convert ()
		{
			return Environment.GetCommandLineArgs () [1];
		}

		#endregion


		#region IOutputProvider implementation

		public void Display_result (string result)
		{
			Console.WriteLine (result);
		}

		public void Display_error (string errorMessage)
		{
			var t = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;

			Console.WriteLine (errorMessage);

			Console.ForegroundColor = t;
		}

		#endregion
	}
}