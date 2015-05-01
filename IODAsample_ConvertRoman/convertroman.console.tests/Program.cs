using System;
using convertroman.contracts;
using convertroman.providers;

namespace convertroman.console.tests
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var providers = new Providers (new[]{"42"});

			var input = providers as IInputProvider;
			Console.WriteLine ("The ultimate answer: {0}", input.Read_number_to_convert ());

			var output = providers as IOutputProvider;
			output.Display_result ("XLII");
			output.Display_error ("An error message!");
		}
	}
}