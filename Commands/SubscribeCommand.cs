using System;
using System.Globalization;

namespace ExtPlaneNet.Commands
{
	public class SubscribeCommand : Command
	{
		public string DataRef { get; set; }
		public float Accuracy { get; set; }

		public SubscribeCommand(string dataRef, float accuracy = 0.0f) : base("sub")
		{
			if (string.IsNullOrWhiteSpace(dataRef))
				throw new ArgumentNullException("dataRef");
			
			DataRef = dataRef;
			Accuracy = accuracy;
		}

		protected override string FormatParameters()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0} {1}", DataRef, Accuracy);
		}
	}
}