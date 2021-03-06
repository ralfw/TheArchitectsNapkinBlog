using NUnit.Framework;
using System;
using convertroman.contracts;
using convertroman.body;
using convertroman.head;

namespace convertroman.tests
{

	[TestFixture]
	public class Integrationtests_head {
		[Test]
		public void Successful_conversion() {
			var body = new MockBody (false);

			var input = new InputProviderMock ("42");
			var output = new OutputProviderMock ();

			var head = new Head (input, body, output);

			head.Run ();

			Assert.AreEqual ("42", output.Text);
		}


		[Test]
		public void Failing_conversion() {
			var body = new MockBody (true);

			var input = new InputProviderMock ("42");
			var output = new OutputProviderMock ();

			var head = new Head (input, body, output);

			head.Run ();

			Assert.AreEqual ("Failed for 42", output.Text);
		}
	}
}