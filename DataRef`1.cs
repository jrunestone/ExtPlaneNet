using System;
using System.Collections;
using System.Linq;

namespace ExtPlaneNet
{
	public class DataRef<T> : DataRef
	{
		public event EventHandler<DataRef<T>> Changed;
		public T Value { get; set; }

		public DataRef(string name, float accuracy = 0.0f) : base(name, accuracy)
		{
			
		}

		public override void SetValue(object value)
		{
			Value = (T)value;

			if (Changed != null)
				Changed(this, this);
		}
	}
}