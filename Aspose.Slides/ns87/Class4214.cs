using System.Collections.Generic;
using ns73;

namespace ns87;

internal class Class4214 : Class4154
{
	public class Class4352
	{
		private readonly string string_0;

		private readonly string string_1;

		public string Open => string_0;

		public string Close => string_1;

		internal Class4352(string open, string close)
		{
			string_0 = open;
			string_1 = close;
		}
	}

	private IList<Class4352> ilist_0;

	private bool bool_0;

	public IList<Class4352> Quotes => ilist_0;

	public bool IsNone => bool_0;

	internal Class4214(Class3679 value)
		: base(value)
	{
		ilist_0 = new List<Class4352>();
		bool_0 = !base.IsListValue;
		if (!bool_0)
		{
			Class3691 @class = (Class3691)value;
			for (int i = 0; i < @class.Length; i += 2)
			{
				string open = ((Class3680)@class[i]).vmethod_3();
				string close = ((Class3680)@class[i + 1]).vmethod_3();
				ilist_0.Add(new Class4352(open, close));
			}
		}
	}
}
