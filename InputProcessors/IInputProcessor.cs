using System;
using System.Collections.Generic;

namespace ExtPlaneNet.InputProcessors
{
	public interface IInputProcessor
	{
		string Evaluator { get; }
		void Process(string data);
	}
}