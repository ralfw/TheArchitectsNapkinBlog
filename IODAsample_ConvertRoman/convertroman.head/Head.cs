using System;
using convertroman.providers;
using convertroman.contracts;
using convertroman.body;

namespace convertroman.head
{

	public class Head {
		IInputProvider input;
		IBody body;
		IOutputProvider output;

		public Head(IInputProvider input, IBody body, IOutputProvider output) {
			this.output = output;
			this.body = body;
			this.input = input;
		}

		public void Run() {
			var number = this.input.Read_number_to_convert ();
			this.body.Convert (number,
				this.output.Display_result,
				this.output.Display_error);
		}
	}
}
