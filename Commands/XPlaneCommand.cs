using System;
using System.Globalization;

namespace ExtPlaneNet.Commands
{
	public class XPlaneCommand : Command
	{
		public string DataRef { get; set; }
		public CommandType SubCommand { get; set; }

		public XPlaneCommand(string dataRef, CommandType type = CommandType.Once) : base("cmd")
		{
			if (string.IsNullOrWhiteSpace(dataRef))
				throw new ArgumentNullException("dataRef");

			DataRef = dataRef;
			SubCommand = type;
		}

		protected override string FormatParameters()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0} {1}", SubCommand.ToString().ToLower(), DataRef);
		}
	}
}