using System;

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
			try
			{
				Value = (T)value;
				Exception = null;
			}
			catch (Exception ex)
            {
				Exception = ex;
            }

			if (Changed != null)
				Changed(this, this);
		}
	}
}