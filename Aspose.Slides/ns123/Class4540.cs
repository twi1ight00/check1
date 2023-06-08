using System.Text;
using ns122;
using ns156;

namespace ns123;

internal class Class4540 : Class4521
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

	public Class4540(Class4700 context, Class4521 parent)
		: this(context, parent, nestedDictionaries: false)
	{
	}

	public Class4540(Class4700 context, Class4521 parent, bool nestedDictionaries)
		: base(context, parent)
	{
		base.UseParentEndMarker = true;
		byte_1 = new byte[2][]
		{
			Encoding.ASCII.GetBytes("dict begin"),
			Encoding.ASCII.GetBytes("dict dup begin")
		};
		byte_0 = new byte[1][] { Encoding.ASCII.GetBytes("end") };
		base.ChildScanners = new Class4520[1]
		{
			new Class4542(context, this, nestedDictionaries, nestedDictionaries: false)
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
		if (sender is Class4542 @class)
		{
			class4727_0.Definitions.Add(@class.Definition);
		}
		base.imethod_0(sender);
	}
}
