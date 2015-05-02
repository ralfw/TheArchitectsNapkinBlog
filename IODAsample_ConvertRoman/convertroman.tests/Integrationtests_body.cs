using NUnit.Framework;
using System;
using convertroman.contracts;
using convertroman.body;
using convertroman.head;

namespace convertroman.tests
{
	[TestFixture ()]
	public class Integrationtests_body
	{
		[Test ()]
		public void Convert_arabic () {
			var output = new OutputProviderMock ();
			var sut = new Body ();

			sut.Convert ("42", output.Display_result, null);

			Assert.AreEqual ("XLII", output.Text);
		}


		[Test ()]
		public void Convert_roman () {
			var output = new OutputProviderMock ();
			var sut = new Body ();

			sut.Convert ("XLII", output.Display_result, null);

			Assert.AreEqual ("42", output.Text);
		}


		[Test ()]
		public void Failed_to_convert_arabic () {
			var output = new OutputProviderMock ();
			var sut = new Body ();

			sut.Convert ("-99", null, output.Display_error);

			Assert.IsTrue (output.Text.StartsWith ("Invalid"));
		}


		[Test ()]
		public void Failed_to_convert_roman () {
			var output = new OutputProviderMock ();
			var sut = new Body ();

			sut.Convert ("XLaI", null, output.Display_error);

			Assert.IsTrue (output.Text.StartsWith ("Invalid"));
		}
	}
}