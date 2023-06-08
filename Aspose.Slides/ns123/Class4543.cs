using ns156;

namespace ns123;

internal class Class4543 : Class4521
{
	private byte[] byte_3;

	private Class4726 class4726_0;

	public byte[] EexecRawData
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
		}
	}

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

	public Class4543(Class4700 context)
		: base(context, null)
	{
		base.ChildScanners = new Class4521[2]
		{
			new Class4542(context, this, canContainDictionary: true, nestedDictionaries: true),
			new Class4541(context, this)
		};
		byte_1 = new byte[0][];
		byte_0 = new byte[0][];
	}

	public void method_2()
	{
		if (vmethod_2(0, out var _, out var bodyStartPosition))
		{
			vmethod_0(bodyStartPosition, out var _);
		}
	}

	protected override bool vmethod_2(int startPosition, out byte[] matchedMarker, out int bodyStartPosition)
	{
		bodyStartPosition = startPosition;
		matchedMarker = new byte[0];
		return true;
	}

	protected override byte[] vmethod_3(int currentPosition, out int endPosition)
	{
		endPosition = -1;
		if (currentPosition == byte_2.Length - 1)
		{
			endPosition = currentPosition;
			return new byte[0];
		}
		return null;
	}

	public override void vmethod_1()
	{
		Definitions = new Class4726();
		EexecRawData = null;
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
			Definitions.Add(@class.Definition);
		}
		if (sender is Class4541 class2)
		{
			EexecRawData = class2.DecryptedBytes;
		}
		base.imethod_0(sender);
	}
}
