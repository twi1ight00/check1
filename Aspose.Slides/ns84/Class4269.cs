using System.Drawing;
using ns73;
using ns87;

namespace ns84;

internal class Class4269
{
	private readonly Class4345 class4345_0;

	protected Class4345 Model => class4345_0;

	internal Class4269(Class4345 model)
	{
		class4345_0 = model;
	}

	internal Class3679 method_0(Enum600 type)
	{
		return class4345_0.vmethod_0(type);
	}

	internal T method_1<T>(Enum600 type) where T : struct
	{
		return class4345_0.method_0<T>(type);
	}

	internal Color method_2(Enum600 type)
	{
		return class4345_0.method_1(type);
	}

	internal Class4338 method_3(Enum600 type)
	{
		return class4345_0.method_2(type);
	}
}
