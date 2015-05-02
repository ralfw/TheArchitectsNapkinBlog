using NUnit.Framework;
using System;
using convertroman.contracts;
using convertroman.body;
using convertroman.head;

namespace convertroman.tests
{

	class MockBody : IBody {
		bool fail;

		public MockBody(bool fail) {
			this.fail = fail;
		}

		#region IBody implementation
		public void Convert (string number, Action<string> onSuccess, Action<string> onError)
		{
			if (this.fail)
				onError ("Failed for " + number);
			else
				onSuccess (number);
		}
		#endregion	
	}
}