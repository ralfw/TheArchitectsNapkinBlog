using System;

namespace convertroman.contracts
{
	public interface IBody {
		void Convert (string number, Action<string> onSuccess, Action<string> onError);
	}
}