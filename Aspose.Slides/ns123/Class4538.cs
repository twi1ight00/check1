using ns156;

namespace ns123;

internal class Class4538 : Class4521
{
	private Class4726 class4726_0;

	public Class4726 Definitions
	{
		get
		{
			return class4726_0;
		}
		set
		{
			class4726_0 = value;
		}
	}

	public Class4538(Class4700 context)
		: base(context, null)
	{
		base.ChildScanners = new Class4521[1]
		{
			new Class4542(context, this, canContainDictionary: true, nestedDictionaries: true)
		};
		byte_1 = new byte[0][];
		byte_0 = new byte[0][];
	}

	public override void vmethod_1()
	{
		Definitions = new Class4726();
		base.vmethod_1();
	}

	public override void imethod_0(object sender)
	{
		if (sender is Class4542 @class)
		{
			Definitions.Add(@class.Definition);
		}
		base.imethod_0(sender);
	}

	protected override void vmethod_6(int currentPosition)
	{
		base.vmethod_6(currentPosition);
	}
}
