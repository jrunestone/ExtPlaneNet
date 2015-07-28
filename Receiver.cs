using System;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace ExtPlaneNet
{
	public class Receiver
	{
		protected NetworkStream Stream { get; set; }

		protected readonly InputHandler InputHandler;
		protected readonly CancellationToken CancelToken;

		public Receiver(NetworkStream stream, InputHandler inputHandler, CancellationToken cancelToken)
		{
			if (stream == null)
				throw new ArgumentNullException("stream");

			if (inputHandler == null)
				throw new ArgumentNullException("inputHandler");
			
			Stream = stream;
			InputHandler = inputHandler;
			CancelToken = cancelToken;
		}

		public void Run()
		{
			while (true)
			{
				if (CancelToken.IsCancellationRequested)
					break;

				if (Stream.DataAvailable)
				{
					StringBuilder rawData = new StringBuilder();
					byte[] buffer = new byte[1024];
					int read = 0;

					while (Stream.DataAvailable)
					{
						read = Stream.Read(buffer, 0, buffer.Length);
						rawData.Append(Encoding.UTF8.GetString(buffer, 0, read));
					}

					var lines = rawData.ToString().Split('\n');

					foreach (string line in lines)
						InputHandler.Handle(line);
				}

				Thread.Sleep(1);
			}
		}
	}
}