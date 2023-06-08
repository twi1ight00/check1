using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4176 : Class4154
{
	private Enum541 enum541_0;

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
			class4338_0 = value;
			bool_0 = true;
		}
	}

	public Enum541 Value
	{
		get
		{
			return enum541_0;
		}
		private set
		{
			enum541_0 = value;
			bool_0 = false;
		}
	}

	public bool IsLengthValue => bool_0;

	internal Class4176(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsIdentValue)
		{
			Value = Class4342.smethod_0<Enum541>().imethod_3(method_0());
		}
		else
		{
			Length = Class4338.smethod_3((Class3681)cssValue);
		}
	}
}
