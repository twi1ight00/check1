using System.Collections;
using System.Text;
using ns122;
using ns123;
using ns125;
using ns156;

namespace ns124;

internal class Class4523 : Class4521, Interface135
{
	private Class4725 class4725_0;

	private Stack stack_0;

	public Class4725 Definition
	{
		get
		{
			return class4725_0;
		}
		set
		{
			class4725_0 = value;
		}
	}

	public Stack ValueStack
	{
		get
		{
			return stack_0;
		}
		set
		{
			stack_0 = value;
		}
	}

	public Class4523(Class4700 context, Class4521 parent)
		: base(context, parent)
	{
		byte_1 = new byte[0][];
		byte_0 = new byte[3][]
		{
			Encoding.ASCII.GetBytes("\r\n"),
			Encoding.ASCII.GetBytes("\r"),
			Encoding.ASCII.GetBytes("\n")
		};
		base.ChildScanners = (Class4520[])new ArrayList
		{
			new Class4550(this, context.File),
			new Class4533(context, this),
			new Class4533(context, this)
		}.ToArray(typeof(Class4520));
	}

	public override void vmethod_1()
	{
		class4725_0 = new Class4725();
		stack_0 = new Stack();
		((Class4550)base.ChildScanners[0]).IsAllowed = true;
		base.vmethod_1();
	}

	protected override bool vmethod_2(int startPosition, out byte[] matchedMarker, out int bodyStartPosition)
	{
		bodyStartPosition = startPosition;
		matchedMarker = new byte[0];
		return true;
	}

	protected override void vmethod_6(int currentPosition)
	{
		base.vmethod_6(currentPosition);
	}

	public override void imethod_0(object sender)
	{
		if (sender is Class4550 @class)
		{
			class4725_0.Name = @class.Name;
		}
		else if (sender is Class4533 class2)
		{
			class4725_0.ObjectInside = class2.String;
			class4725_0.ObjectTypeInside = Enum666.const_0;
		}
		base.imethod_0(sender);
	}
}
