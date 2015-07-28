using System;
using System.Collections.Generic;

namespace ExtPlaneNet
{
	public interface IDataRefRepository
	{
		void Add<T>(DataRef<T> dataRef);
		void Remove(string dataRef);
		DataRef<T> Get<T>(string dataRef);
		DataRef Get(string dataRef, Type type);
		bool Contains(string dataRef);
	}
}