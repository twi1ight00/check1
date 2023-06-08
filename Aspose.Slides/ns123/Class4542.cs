using System.Collections;
using System.Text;
using ns122;
using ns125;
using ns156;

namespace ns123;

internal class Class4542 : Class4521, Interface135
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

	public Class4542(Class4700 context, Class4521 parent, bool canContainDictionary, bool nestedDictionaries)
		: base(context, parent)
	{
		byte_1 = new byte[1][] { Encoding.ASCII.GetBytes("/") };
		byte_0 = new byte[9][]
		{
			Encoding.ASCII.GetBytes("end"),
			Encoding.ASCII.GetBytes("def"),
			Encoding.ASCII.GetBytes("readonly def"),
			Encoding.ASCII.GetBytes("executeonly def"),
			Encoding.ASCII.GetBytes("noaccess def"),
			Encoding.ASCII.GetBytes("ND\r"),
			Encoding.ASCII.GetBytes("ND\n"),
			Encoding.ASCII.GetBytes("|-\r"),
			Encoding.ASCII.GetBytes("|-\n")
		};
		ArrayList arrayList = new ArrayList
		{
			new Class4550(this, context.File),
			new Class4539(context, this),
			new Class4546(this, context.File),
			new Class4545(this, context.File),
			new Class4549(this, context.File),
			new Class4534(context, this),
			new Class4547(this, context.File),
			new Class4548(this, context.File)
		};
		if (canContainDictionary)
		{
			arrayList.Add(new Class4540(context, this, nestedDictionaries));
		}
		arrayList.Add(new Class4544(this, context.File));
		base.ChildScanners = (Class4520[])arrayList.ToArray(typeof(Class4520));
	}

	public override void vmethod_1()
	{
		class4725_0 = new Class4725();
		stack_0 = new Stack();
		((Class4550)base.ChildScanners[0]).IsAllowed = true;
		base.vmethod_1();
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
		else if (sender is Class4547 class2)
		{
			class4725_0.ObjectInside = class2.String;
			class4725_0.ObjectTypeInside = Enum666.const_0;
		}
		else if (sender is Class4549 class3)
		{
			class4725_0.ObjectInside = class3.String;
			class4725_0.ObjectTypeInside = Enum666.const_0;
		}
		else if (sender is Class4544 class4)
		{
			class4725_0.ObjectInside = class4.String;
			class4725_0.ObjectTypeInside = Enum666.const_0;
		}
		else if (sender is Class4546 class5)
		{
			class4725_0.ObjectInside = class5.String;
			class4725_0.ObjectTypeInside = Enum666.const_5;
		}
		else if (sender is Class4545 class6)
		{
			class4725_0.ObjectInside = class6.String;
			class4725_0.ObjectTypeInside = Enum666.const_5;
		}
		else if (sender is Class4548 class7)
		{
			class4725_0.ObjectInside = class7.Number;
			class4725_0.ObjectTypeInside = Enum666.const_2;
			ValueStack.Push(class7.Number);
			if (class4725_0.Name == "lenIV")
			{
				base.Context.LenIV = (int)class7.Number;
			}
		}
		else if (sender is Class4534 class8)
		{
			class4725_0.ObjectInside = class8.Array;
			class4725_0.ObjectTypeInside = Enum666.const_4;
		}
		else if (sender is Class4540 class9)
		{
			class4725_0.ObjectInside = class9.Dictionary;
			class4725_0.ObjectTypeInside = Enum666.const_3;
		}
		else if (sender is Class4539 class10)
		{
			class4725_0.ObjectInside = class10.DecryptedBytes;
			class4725_0.ObjectTypeInside = Enum666.const_8;
		}
		base.imethod_0(sender);
	}
}
