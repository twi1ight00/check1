using System.Collections;
using System.Text;
using ns156;
using ns157;

namespace ns123;

internal class Class4535 : Class4521
{
	private Class4713 class4713_0;

	private ArrayList arrayList_0;

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

	public Class4535(Class4700 context, Class4521 parent)
		: base(context, parent)
	{
		byte_1 = new byte[0][];
		byte_0 = new byte[1][] { Encoding.ASCII.GetBytes("for") };
	}

	public override void vmethod_1()
	{
		class4713_0 = new Class4713();
		arrayList_0 = new ArrayList();
		base.vmethod_1();
	}

	protected override bool vmethod_2(int startPosition, out byte[] matchedMarker, out int bodyStartPosition)
	{
		bodyStartPosition = -1;
		matchedMarker = null;
		if (Class4729.smethod_0(byte_2, startPosition))
		{
			bodyStartPosition = startPosition;
			matchedMarker = new byte[0];
			return true;
		}
		return false;
	}

	protected override void vmethod_6(int currentPosition)
	{
		arrayList_0.Add(byte_2[currentPosition]);
		base.vmethod_6(currentPosition);
	}

	protected override void vmethod_5()
	{
		class4713_0.ObjectInside = (byte[])arrayList_0.ToArray(typeof(byte));
		class4713_0.ItemType = Enum665.const_1;
		base.IsAllowed = false;
		base.vmethod_5();
	}
}
