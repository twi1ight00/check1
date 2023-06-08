using System.Text;
using ns122;
using ns123;
using ns156;

namespace ns124;

internal class Class4531 : Class4521
{
	private Class4727 class4727_0;

	private Class4727 class4727_1;

	public Class4727 KerningPairDictionary
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

	public Class4727 TrackKernDictionary
	{
		get
		{
			return class4727_1;
		}
		set
		{
			class4727_1 = value;
		}
	}

	public Class4531(Class4700 context, Class4521 parent)
		: base(context, parent)
	{
		byte_1 = new byte[1][] { Encoding.ASCII.GetBytes("StartKernData") };
		byte_0 = new byte[3][]
		{
			Encoding.ASCII.GetBytes("EndKernData\r\n"),
			Encoding.ASCII.GetBytes("EndKernData\r"),
			Encoding.ASCII.GetBytes("EndKernData\n")
		};
		base.ChildScanners = new Class4520[2]
		{
			new Class4530(context, this),
			new Class4529(context, this)
		};
	}

	public override void vmethod_1()
	{
		class4727_0 = new Class4727();
		class4727_1 = new Class4727();
		base.vmethod_1();
	}

	protected override void vmethod_6(int currentPosition)
	{
		base.vmethod_6(currentPosition);
	}

	public override void imethod_0(object sender)
	{
		if (sender is Class4530 @class)
		{
			class4727_0 = @class.Dictionary;
		}
		else if (sender is Class4529 class2)
		{
			class4727_1 = class2.Dictionary;
		}
		base.imethod_0(sender);
	}
}
