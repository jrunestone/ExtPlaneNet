namespace ExtPlaneNet.Commands
{
	public class ButtonReleaseCommand : ButtonCommand
	{
		public ButtonReleaseCommand(int buttonId) : base("rel", buttonId)
		{
		}
	}
}