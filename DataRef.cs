using System;
using System.Linq;

namespace ExtPlaneNet
{
	public abstract class DataRef
	{
		public readonly string Name;
		public readonly float Accuracy;

		protected DataRef(string name, float accuracy = 0.0f)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException("name");

			Name = name;
			Accuracy = accuracy;
		}

		public abstract void SetValue(object value);

		public static Type ParseType(string rawType)
		{
			if (string.IsNullOrWhiteSpace(rawType))
				throw new ArgumentNullException("rawType");
			
			switch (rawType)
			{
				case "i":
					return typeof(int);

				case "f":
					return typeof(float);

				case "d":
					return typeof(double);

				case "ia":
					return typeof(int[]);

				case "fa":
					return typeof(float[]);

				default:
					return typeof(string);
			}
		}

		public static object ParseValue(string rawValue, Type type)
		{
			if (string.IsNullOrWhiteSpace(rawValue))
				throw new ArgumentNullException("rawValue");

			if (type == null)
				throw new ArgumentNullException("type");

			object value;

			if (type.IsArray)
			{
				string[] elements = rawValue.Replace("[", string.Empty).Replace("]", string.Empty).Split(',');
				Array array = Array.CreateInstance(type.GetElementType(), elements.Length);

				for (int i = 0; i < array.Length; i++)
					array.SetValue(Convert.ChangeType(elements[i], type.GetElementType()), i);

				value = array;
			}
			else
				value = Convert.ChangeType(rawValue, type);

			return value;
		}
	}
}