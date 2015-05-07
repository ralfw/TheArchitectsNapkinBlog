using System;
using System.Linq;

namespace spike.nconversions
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var disp = new Dispatcher (new Reverse (), new ToUpper (), new ToLower ());

			var data = Read_data_from_commandline (args);
			disp.Choose (data,
				conv => {
					var convertedData = conv.Convert(data);
					Output_result(convertedData);
				});

		}


		private static string Read_data_from_commandline(string[] args) {
			return args [0];
		}

		private static void Output_result(string result) {
			Console.WriteLine (result);
		}
	}


	class Dispatcher {
		private IConversion[] conversions;

		public Dispatcher(params IConversion[] conversions) {
			this.conversions = conversions;
		}


		public void Choose(string data, Action<IConversion> onConversion) {
			Stream_conversions (
				conv => conv.Check_applicability(data,
								() => onConversion(conv)));
		}

		private void Stream_conversions(Func<IConversion, bool> onConversion) {
			foreach (var conv in this.conversions)
				if (onConversion (conv)) return;
		}
	}


	interface IConversion {
		bool Check_applicability (string data, Action onApplicable);
		string Convert (string data);
	}

	class Reverse : IConversion {
		#region IConversion implementation
		public bool Check_applicability (string data, Action onApplicable)
		{
			if (data.StartsWith ("[")) {
				onApplicable ();
				return true;
			} else
				return false;
		}

		public string Convert (string data)
		{
			return string.Join ("", data.ToCharArray ().Reverse ());
		}
		#endregion
	}

	class ToUpper : IConversion {
		#region IConversion implementation
		public bool Check_applicability (string data, Action onApplicable)
		{
			if (char.IsLower (data [0])) {
				onApplicable ();
				return true;
			} else
				return false;
		}
		public string Convert (string data)
		{
			return data.ToUpper ();
		}
		#endregion
	}

	class ToLower : IConversion {
		#region IConversion implementation
		public bool Check_applicability (string data, Action onApplicable)
		{
			if (char.IsUpper (data [0])) {
				onApplicable ();
				return true;
			} else
				return false;
		}
		public string Convert (string data)
		{
			return data.ToLower ();
		}
		#endregion
	}
}