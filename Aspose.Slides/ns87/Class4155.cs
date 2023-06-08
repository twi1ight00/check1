using System.Collections.Generic;
using ns73;

namespace ns87;

internal class Class4155 : Class4154
{
	internal class Class4232
	{
		private bool bool_0;

		private string string_0;

		private string string_1;

		public bool IsLocal
		{
			get
			{
				return bool_0;
			}
			internal set
			{
				bool_0 = value;
			}
		}

		public string URI
		{
			get
			{
				return string_0;
			}
			internal set
			{
				string_0 = value;
			}
		}

		public string Format
		{
			get
			{
				return string_1;
			}
			internal set
			{
				string_1 = value;
			}
		}

		internal Class4232()
		{
		}
	}

	private List<Class4232> list_0;

	private string string_0;

	internal List<Class4232> Urls => list_0;

	public string Format => string_0;

	internal Class4155(Class3679 value)
		: base(value)
	{
		list_0 = new List<Class4232>();
		Class3691 @class = value as Class3691;
		foreach (Class3680 item2 in @class)
		{
			if (item2.PrimitiveType == 19 || item2.PrimitiveType == 20)
			{
				Class4232 item = new Class4232
				{
					URI = item2.vmethod_3()
				};
				list_0.Add(item);
			}
		}
	}
}
