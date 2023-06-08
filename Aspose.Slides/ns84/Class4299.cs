using System.Drawing;
using ns87;

namespace ns84;

internal class Class4299 : Class4269
{
	public Color Color => method_2(Enum600.const_19);

	public Enum515 Clip => method_1<Enum515>(Enum600.const_18);

	public Class4218 Image => new Class4218(method_0(Enum600.const_20));

	public Enum515 Origin => method_1<Enum515>(Enum600.const_21);

	public Class4219 Position => new Class4219(method_0(Enum600.const_22));

	public Enum636 Repeat => method_1<Enum636>(Enum600.const_23);

	public Enum604 Attachment => method_1<Enum604>(Enum600.const_17);

	public Class4161 Size => new Class4161(method_0(Enum600.const_24));

	internal Class4299(Class4345 model)
		: base(model)
	{
	}
}
