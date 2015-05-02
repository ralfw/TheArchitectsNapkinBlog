using NUnit.Framework;
using System;
using convertroman.contracts;

namespace convertroman.tests
{

	class OutputProviderMock : IOutputProvider {
		public string Text;

		#region IOutputProvider implementation
		public void Display_result (string result)
		{
			this.Text = result;
		}
		public void Display_error (string errorMessage)
		{
			this.Text = errorMessage;
		}
		#endregion
	}
}