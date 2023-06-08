using System.Collections.Generic;
using ns73;

namespace ns87;

internal class Class4190 : Class4154
{
	public enum Enum513
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9,
		const_10
	}

	public class Class4334
	{
		private string string_0;

		internal string Identifier => string_0;

		internal Class4334(string value)
		{
			string_0 = value;
		}
	}

	private List<Class4334> list_0;

	public bool None => list_0.Count == 0;

	public int Count => list_0.Count;

	public Class4334 this[int index] => list_0[index];

	internal Class4190(Class3679 cssValue)
		: base(cssValue)
	{
		list_0 = new List<Class4334>();
		if (base.IsListValue)
		{
			list_0.Add(new Class4334(method_0()));
		}
	}
}
