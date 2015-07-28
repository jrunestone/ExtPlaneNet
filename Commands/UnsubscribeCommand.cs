using System;
using System.Globalization;

namespace ExtPlaneNet.Commands
{
	public class UnsubscribeCommand : Command
	{
		public string DataRef { get; set; }
	
		public UnsubscribeCommand(string dataRef) : base("unsub")
		{
			if (string.IsNullOrWhiteSpace(dataRef))
				throw new ArgumentNullException("dataRef");

			DataRef = dataRef;
		}

		protected override string FormatParameters()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}", DataRef);
		}
	}
}