using System.Globalization;

namespace ExtPlaneNet.Commands
{
	public class ButtonCommand : Command
	{
		public int KeyId { get; set; }
	
		public ButtonCommand(string command, int keyId) : base(command)
		{
			KeyId = keyId;
		}

		protected override string FormatParameters()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}", KeyId);
		}
	}
}