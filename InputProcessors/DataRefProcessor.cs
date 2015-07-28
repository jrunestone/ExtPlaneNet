using System;
using System.Text.RegularExpressions;

namespace ExtPlaneNet.InputProcessors
{
	public class DataRefProcessor : IInputProcessor
	{
		protected readonly IDataRefRepository DataRefRepository;

		public string Evaluator
		{
			get { return "^u(i|f|d|ia|fa|b)\\s([^\\s]+)\\s(.+)"; }
		}

		public DataRefProcessor(IDataRefRepository dataRefRepository)
		{
			if (dataRefRepository == null)
				throw new ArgumentNullException("dataRefRepository");

			DataRefRepository = dataRefRepository;
		}

		public void Process(string data)
		{
			if (string.IsNullOrWhiteSpace(data))
				return;

			Match match = Regex.Match(data, Evaluator);

			string rawType = match.Groups[1].Value;
			string name = match.Groups[2].Value;
			string rawValue = match.Groups[3].Value;

			Type type = DataRef.ParseType(rawType);
			object value = DataRef.ParseValue(rawValue, type);
			DataRef dataRef = DataRefRepository.Get(name, type);

			dataRef.SetValue(value);
		}
	}
}