using System.Collections;
using System.Text;
using ns122;
using ns125;
using ns127;
using ns156;

namespace ns123;

internal class Class4536 : Class4521, Interface135
{
	private Class4713 class4713_0;

	private ArrayList arrayList_0;

	private Stack stack_0;

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

	public Class4713 ArrayItem
	{
		get
		{
			return class4713_0;
		}
		set
		{
			class4713_0 = value;
		}
	}

	public Class4536(Class4700 context, Class4521 parent)
		: base(context, parent)
	{
		byte_1 = new byte[1][] { Encoding.ASCII.GetBytes("dup") };
		byte_0 = new byte[7][]
		{
			Encoding.ASCII.GetBytes("|\r"),
			Encoding.ASCII.GetBytes("|\n"),
			Encoding.ASCII.GetBytes("NP\r"),
			Encoding.ASCII.GetBytes("NP\n"),
			Encoding.ASCII.GetBytes("put\r"),
			Encoding.ASCII.GetBytes("put\n"),
			Encoding.ASCII.GetBytes("put")
		};
		base.ChildScanners = new Class4520[3]
		{
			new Class4548(this, context.File),
			new Class4547(this, context.File),
			new Class4537(context, this)
		};
	}

	public override void vmethod_1()
	{
		stack_0 = new Stack();
		class4713_0 = new Class4713();
		arrayList_0 = new ArrayList();
		base.vmethod_1();
	}

	protected override byte[] vmethod_3(int currentPosition, out int endPosition)
	{
		byte[] array = base.vmethod_3(currentPosition, out endPosition);
		if (array != null)
		{
			if (!Class4554.smethod_3(array, Encoding.ASCII.GetBytes("|\r")) && !Class4554.smethod_3(array, Encoding.ASCII.GetBytes("|\n")) && !Class4554.smethod_3(array, Encoding.ASCII.GetBytes("NP\r")) && !Class4554.smethod_3(array, Encoding.ASCII.GetBytes("NP\n")))
			{
				class4713_0.ItemType = Enum665.const_2;
			}
			else
			{
				class4713_0.ItemType = Enum665.const_3;
			}
		}
		return array;
	}

	protected override void vmethod_6(int currentPosition)
	{
		arrayList_0.Add(byte_2[currentPosition]);
		base.vmethod_6(currentPosition);
	}

	public override void imethod_0(object sender)
	{
		if (sender is Class4548 @class)
		{
			if (class4713_0.ItemIndex == int.MinValue)
			{
				class4713_0.ItemIndex = (int)@class.Number;
			}
			ValueStack.Push(@class.Number);
		}
		else if (sender is Class4537 class2)
		{
			class4713_0.ObjectInside = class2.DecryptedBytes;
		}
		else if (sender is Class4547 class3)
		{
			class4713_0.ObjectInside = Encoding.ASCII.GetBytes(class3.String);
		}
		base.imethod_0(sender);
	}
}
