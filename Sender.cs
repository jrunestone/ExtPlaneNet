using System;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace ExtPlaneNet
{
	public class Sender
	{
		protected readonly NetworkStream Stream;
		protected readonly ICommandQueue Commands;
		protected readonly CancellationToken CancelToken;

		public Sender(NetworkStream stream, ICommandQueue commandQueue, CancellationToken cancelToken)
		{
			if (stream == null)
				throw new ArgumentNullException("stream");

			if (commandQueue == null)
				throw new ArgumentNullException("commandQueue");

			Stream = stream;
			Commands = commandQueue;
			CancelToken = cancelToken;
		}

		public void Run()
		{
			while (true)
			{
				if (CancelToken.IsCancellationRequested)
					break;

				var command = Commands.TryDequeue();

				if (command != null)
				{
					string data = command.Build();
					byte[] buffer = Encoding.UTF8.GetBytes(data);

					Stream.Write(buffer, 0, buffer.Length);
				}

				Thread.Sleep(1);
			}
		}
	}
}