using System;
using System.Globalization;
using System.Collections.Concurrent;
using ExtPlaneNet.Commands;
using System.Net.Sockets;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace ExtPlaneNet
{
	public class CommandQueue : ICommandQueue
	{
		protected readonly ConcurrentQueue<Command> Commands = new ConcurrentQueue<Command>();

		public void Enqueue(Command command)
		{
			Commands.Enqueue(command);
		}

		public Command TryDequeue()
		{
			Command command;
			Commands.TryDequeue(out command);

			return command;
		}
	}
}