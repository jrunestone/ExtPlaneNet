using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace ExtPlaneNet
{
	public class DataRefRepository : IDataRefRepository
	{
		protected readonly ConcurrentDictionary<string, object> DataRefs = new ConcurrentDictionary<string, object>();

		public void Add<T>(DataRef<T> dataRef)
		{
			DataRefs.TryAdd(dataRef.Name, dataRef);
		}

		public DataRef<T> Get<T>(string dataRef)
		{
			object value;
			DataRefs.TryGetValue(dataRef, out value);

			return value as DataRef<T>;
		}

		public DataRef Get(string dataRef, Type type)
		{
			object value;
			DataRefs.TryGetValue(dataRef, out value);

			return value as DataRef;
		}

		public void Remove(string dataRef)
		{
			object value;
			DataRefs.TryRemove(dataRef, out value);
		}

		public bool Contains(string dataRef)
		{
			return DataRefs.ContainsKey(dataRef);
		}
	}
}