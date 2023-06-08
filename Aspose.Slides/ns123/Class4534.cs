using System.Text;
using ns122;
using ns156;

namespace ns123;

internal class Class4534 : Class4521
{
	private Class4722 class4722_0;

	public Class4722 Array
	{
		get
		{
			return class4722_0;
		}
		set
		{
			class4722_0 = value;
		}
	}

	public Class4534(Class4700 context, Class4521 parent)
		: base(context, parent)
	{
		base.UseParentEndMarker = true;
		byte_1 = new byte[1][] { Encoding.ASCII.GetBytes("array") };
		byte_0 = new byte[6][]
		{
			Encoding.ASCII.GetBytes("def"),
			Encoding.ASCII.GetBytes("readonly def"),
			Encoding.ASCII.GetBytes("ND\r"),
			Encoding.ASCII.GetBytes("ND\n"),
			Encoding.ASCII.GetBytes("|-\r"),
			Encoding.ASCII.GetBytes("|-\n")
		};
		base.ChildScanners = new Class4520[2]
		{
			new Class4535(context, this),
			new Class4536(context, this)
		};
	}

	public override void vmethod_1()
	{
		class4722_0 = new Class4722();
		base.vmethod_1();
	}

	protected override void vmethod_6(int currentPosition)
	{
		base.vmethod_6(currentPosition);
	}

	public override void imethod_0(object sender)
	{
		if (sender is Class4536 @class)
		{
			((Class4535)base.ChildScanners[0]).IsAllowed = false;
			class4722_0.Definitions.Add(@class.ArrayItem);
		}
		else if (sender is Class4535 class2)
		{
			class4722_0.Definitions.Add(class2.ArrayItem);
		}
		base.imethod_0(sender);
	}
}
