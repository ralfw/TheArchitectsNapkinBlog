using System;
using convertroman.providers;
using convertroman.contracts;
using convertroman.body;

namespace convertroman.head
{
	public class Program
	{
		public static void Main() {
			IInputProvider input = new Providers ();
			IOutputProvider output = input as IOutputProvider;

			var body = new Body ();
			var head = new Head (input, body, output);

			head.Run ();
		}
	}
}