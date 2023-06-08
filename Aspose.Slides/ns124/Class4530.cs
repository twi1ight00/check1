using System.Text;
using ns122;
using ns123;
using ns156;

namespace ns124;

internal class Class4530 : Class4521
{
	private Class4727 class4727_0;

	public Class4727 Dictionary
	{
		get
		{
			return class4727_0;
		}
		set
		{
			class4727_0 = value;
		}
	}

	public Class4530(Class4700 context, Class4521 parent)
		: base(context, parent)
	{
		byte_1 = new byte[1][] { Encoding.ASCII.GetBytes("StartKernPairs") };
		byte_0 = new byte[3][]
		{
			Encoding.ASCII.GetBytes("EndKernPairs\r\n"),
			Encoding.ASCII.GetBytes("EndKernPairs\r"),
			Encoding.ASCII.GetBytes("EndKernPairs\n")
		};
		base.ChildScanners = new Class4520[1]
		{
			new Class4528(context, this)
		};
	}

	public override void vmethod_1()
	{
		class4727_0 = new Class4727();
		base.vmethod_1();
	}

	protected override void vmethod_6(int currentPosition)
	{
		base.vmethod_6(currentPosition);
	}

	public override void imethod_0(object sender)
	{
		if (sender is Class4528 @class)
		{
			Class4725 class2 = new Class4725();
			class2.ObjectInside = @class.String;
			class2.ObjectTypeInside = Enum666.const_0;
			Dictionary.Definitions.Add(class2);
		}
		base.imethod_0(sender);
	}
}
