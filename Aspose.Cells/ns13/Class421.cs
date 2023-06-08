using System.Collections;

namespace ns13;

internal class Class421
{
	private class Class422 : IEnumerator
	{
		private Class421 class421_0;

		private int int_0;

		private bool bool_0;

		public object Current
		{
			get
			{
				if (int_0 >= 0)
				{
					return class421_0.object_0[int_0];
				}
				return class421_0.object_0[class421_0.object_0.Length + int_0];
			}
		}

		public bool MoveNext()
		{
			int_0--;
			if (bool_0)
			{
				return int_0 >= class421_0.int_0;
			}
			if (int_0 < 0)
			{
				return class421_0.object_0.Length + int_0 >= class421_0.int_0;
			}
			return true;
		}

		public void Reset()
		{
			int_0 = class421_0.int_1;
			bool_0 = class421_0.int_0 == class421_0.object_0.Length || class421_0.int_1 > class421_0.int_0;
		}
	}

	private object[] object_0;

	private int int_0;

	private int int_1;

	public object this[int int_2]
	{
		get
		{
			return object_0[(int_0 + int_2) % object_0.Length];
		}
		set
		{
			object_0[(int_0 + int_2) % object_0.Length] = value;
		}
	}
}
