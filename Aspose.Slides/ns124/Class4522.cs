using System.Text;
using ns122;
using ns123;
using ns156;

namespace ns124;

internal class Class4522 : Class4521
{
	private byte[] byte_3;

	private Class4727 class4727_0;

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

	public Class4522(Class4700 context)
		: base(context, null)
	{
		base.ChildScanners = new Class4520[4]
		{
			new Class4524(context, this),
			new Class4531(context, this),
			new Class4532(context, this),
			new Class4523(context, this)
		};
		byte_1 = new byte[1][] { Encoding.ASCII.GetBytes("StartFontMetrics") };
		byte_0 = new byte[1][] { Encoding.ASCII.GetBytes("EndFontMetrics") };
	}

	public void method_2()
	{
		if (vmethod_2(0, out var _, out var bodyStartPosition))
		{
			vmethod_0(bodyStartPosition, out var _);
		}
	}

	public override void vmethod_1()
	{
		Dictionary = new Class4727();
		EexecRawData = null;
		base.vmethod_1();
	}

	protected override void vmethod_6(int currentPosition)
	{
		base.vmethod_6(currentPosition);
	}

	public override void imethod_0(object sender)
	{
		if (sender is Class4523 @class)
		{
			Dictionary.Definitions.Add(@class.Definition);
		}
		else if (sender is Class4524 class2)
		{
			Class4725 class3 = new Class4725();
			class3.Name = "StartCharMetrics";
			class3.ObjectInside = class2.Dictionary;
			class3.ObjectTypeInside = Enum666.const_3;
			Dictionary.Definitions.Add(class3);
		}
		else if (sender is Class4532 class4)
		{
			Class4725 class5 = new Class4725();
			class5.Name = "StartComposites";
			class5.ObjectInside = class4.Dictionary;
			class5.ObjectTypeInside = Enum666.const_3;
			Dictionary.Definitions.Add(class5);
		}
		else if (sender is Class4531 class6)
		{
			Class4725 class7 = new Class4725();
			class7.Name = "StartKernPairs";
			class7.ObjectInside = class6.KerningPairDictionary;
			class7.ObjectTypeInside = Enum666.const_3;
			Dictionary.Definitions.Add(class7);
			class7 = new Class4725();
			class7.Name = "StartTrackKern";
			class7.ObjectInside = class6.TrackKernDictionary;
			class7.ObjectTypeInside = Enum666.const_3;
			Dictionary.Definitions.Add(class7);
		}
		base.imethod_0(sender);
	}
}
