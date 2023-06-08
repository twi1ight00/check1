using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4172 : Class4154
{
	private Enum529 enum529_0;

	private Class4338 class4338_0;

	private bool bool_0;

	public Class4338 Length
	{
		get
		{
			return class4338_0;
		}
		private set
		{
			bool_0 = true;
			class4338_0 = value;
		}
	}

	public Enum529 Value
	{
		get
		{
			return enum529_0;
		}
		private set
		{
			bool_0 = false;
			enum529_0 = value;
		}
	}

	public bool IsLengthValue => bool_0;

	internal Class4172(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsIdentValue)
		{
			Value = Class4342.smethod_0<Enum529>().imethod_3(method_0());
		}
		else
		{
			Length = Class4338.smethod_3((Class3681)cssValue);
		}
	}
}
