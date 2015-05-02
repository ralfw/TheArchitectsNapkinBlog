using NUnit.Framework;
using System;
using convertroman.contracts;

namespace convertroman.tests
{

	class InputProviderMock : IInputProvider {
		string number;

		public InputProviderMock(string number) {
			this.number = number;
		}

		#region IInputProvider implementation
		public string Read_number_to_convert ()
		{
			return this.number;
		}
		#endregion
	}

}