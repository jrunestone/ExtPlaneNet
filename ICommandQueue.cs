using System.Collections.Concurrent;
using ExtPlaneNet.Commands;

namespace ExtPlaneNet
{
	public interface ICommandQueue
	{
		void Enqueue(Command command);
		Command TryDequeue();
	}
}