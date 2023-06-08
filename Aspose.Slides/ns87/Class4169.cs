using System.Collections.Generic;
using ns73;

namespace ns87;

internal class Class4169 : Class4154
{
	public enum Enum512
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5
	}

	public class Class4327
	{
		private Class3679 class3679_0;

		private Enum512 enum512_0;

		public Enum512 Type => enum512_0;

		internal Class3679 CSSValue => class3679_0;

		internal Class4327(Enum512 type, Class3679 value)
		{
			class3679_0 = value;
			enum512_0 = type;
		}

		public override string ToString()
		{
			return class3679_0.CSSText;
		}
	}

	public class Class4328 : Class4327
	{
		private string string_0;

		public string Value => string_0 ?? (string_0 = base.CSSValue.CSSText.Trim('\'', '"'));

		internal Class4328(Class3679 value)
			: base(Enum512.const_0, value)
		{
		}
	}

	public class Class4329 : Class4327
	{
		internal Class4329(Class3679 value)
			: base(Enum512.const_2, value)
		{
		}
	}

	public class Class4330 : Class4327
	{
		internal Class4330(Class3679 value)
			: base(Enum512.const_3, value)
		{
		}
	}

	public class Class4331 : Class4327
	{
		internal Class4331(Class3679 value)
			: base(Enum512.const_4, value)
		{
		}
	}

	public class Class4332 : Class4327
	{
		internal Class4332(Class3679 value)
			: base(Enum512.const_5, value)
		{
		}
	}

	private List<Class4327> list_0 = new List<Class4327>();

	public bool None => list_0.Count == 0;

	public int Count => list_0.Count;

	public Class4327 this[int index] => list_0[index];

	internal Class4169(Class3679 cssValue)
		: base(cssValue)
	{
	}
}
