using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ExtPlaneNet.InputProcessors;

namespace ExtPlaneNet
{
	public class InputHandler
	{
		protected readonly List<IInputProcessor> Processors = new List<IInputProcessor>();

		public void AddInputProcessor(IInputProcessor processor)
		{
			if (processor == null)
				throw new ArgumentNullException("processor");

			Processors.Add(processor);
		}

		public void Handle(string data)
		{
			if (string.IsNullOrWhiteSpace(data))
				return;
			
			var processor = Processors.FirstOrDefault(p => Regex.IsMatch(data, p.Evaluator));

			if (processor != null)
				processor.Process(data);
		}
	}
}