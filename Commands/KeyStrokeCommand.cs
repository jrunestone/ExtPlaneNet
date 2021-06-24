namespace ExtPlaneNet.Commands
{
	public class KeyStrokeCommand : ButtonCommand
	{
		public KeyStrokeCommand(int keyId) : base("key", keyId)
		{
		}
	}
}