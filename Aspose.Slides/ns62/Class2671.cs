using System;
using System.IO;
using System.Runtime.CompilerServices;
using ns60;
using ns63;

namespace ns62;

internal class Class2671 : Class2669
{
	internal const int int_0 = 61443;

	[CompilerGenerated]
	private static Converter<Class2623, Class2669> converter_0;

	public Class2669[] Rgfb
	{
		get
		{
			if (base.Records.Count > 0)
			{
				return Array.ConvertAll(base.Records.ToArray(), (Class2623 obj) => (Class2669)obj);
			}
			return null;
		}
	}

	public override Class2836 ShapeGroup => ((Class2670)base.Records[0]).ShapeGroup;

	public override Class2835 ShapeProp => ((Class2670)base.Records[0]).ShapeProp;

	public override Class2818 DeletedShape => ((Class2670)base.Records[0]).DeletedShape;

	public override Class2834 ShapePrimaryOptions => ((Class2670)base.Records[0]).ShapePrimaryOptions;

	public override Class2817 ShapeSecondaryOptions => null;

	public override Class2837 ShapeTertiaryOptions => ((Class2670)base.Records[0]).ShapeTertiaryOptions;

	public override Class2741 ChildAnchor => ((Class2670)base.Records[0]).ChildAnchor;

	public override Class2742 ClientAnchor => ((Class2670)base.Records[0]).ClientAnchor;

	public override Class2641 ClientData => ((Class2670)base.Records[0]).ClientData;

	public Class2671()
		: base(61443)
	{
	}

	internal void method_5(Enum452 queryType)
	{
		switch (queryType)
		{
		case Enum452.const_1:
		{
			for (int j = 0; j < 6; j++)
			{
				Class2670 @class = new Class2670();
				@class.method_5(queryType, j + 1);
				@class.Header.Version = 15;
				@class.Header.Instance = 0;
				base.Records.Add(@class);
			}
			break;
		}
		case Enum452.const_2:
		{
			for (int i = 0; i < 3; i++)
			{
				Class2670 @class = new Class2670();
				@class.method_5(queryType, i + 1);
				@class.Header.Version = 15;
				@class.Header.Instance = 0;
				base.Records.Add(@class);
			}
			break;
		}
		}
	}

	internal void method_6()
	{
		base.Records.RemoveRange(1, base.Records.Count - 1);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		if (ShapeTertiaryOptions != null)
		{
			method_7(writer, ShapeTertiaryOptions.IsTable);
		}
		else
		{
			base.vmethod_1(writer);
		}
	}

	public override int vmethod_2()
	{
		return method_8(ShapeTertiaryOptions != null && ShapeTertiaryOptions.IsTable);
	}

	internal int method_7(BinaryWriter writer, bool skipInvisibleBorders)
	{
		long position = writer.BaseStream.Position;
		foreach (Class2623 record in base.Records)
		{
			if (record is Class2641 @class)
			{
				if (@class.Records.Count == 0)
				{
					continue;
				}
				if (@class.Records.Count == 1 && @class.Records[0] is Class2727)
				{
					Class2727 class2 = (Class2727)@class.Records[0];
					if (class2.Records.Count == 0)
					{
						continue;
					}
				}
			}
			Class2670 class3 = record as Class2670;
			if (!skipInvisibleBorders || class3 == null || class3.ShapeProp.ShapeType != Enum425.const_20 || (class3.ShapePrimaryOptions != null && class3.ShapePrimaryOptions.Properties != null && class3.ShapePrimaryOptions.Properties[Enum426.const_154] is Class2911 class4 && (class4.Value & 8u) != 0))
			{
				record.Write(writer);
			}
		}
		return (int)(writer.BaseStream.Position - position);
	}

	private int method_8(bool skipInvisibleBorders)
	{
		int num = 0;
		foreach (Class2623 record in base.Records)
		{
			if (record is Class2641)
			{
				Class2641 @class = (Class2641)record;
				if (@class.Records.Count == 0)
				{
					continue;
				}
				if (@class.Records.Count == 1 && @class.Records[0] is Class2727)
				{
					Class2727 class2 = (Class2727)@class.Records[0];
					if (class2.Records.Count == 0)
					{
						continue;
					}
				}
			}
			if (skipInvisibleBorders && record is Class2670)
			{
				Class2670 class3 = (Class2670)record;
				if (class3.ShapeProp.ShapeType == Enum425.const_20 && (class3.ShapePrimaryOptions == null || class3.ShapePrimaryOptions.Properties == null || !(class3.ShapePrimaryOptions.Properties[Enum426.const_154] is Class2911 class4) || (class4.Value & 8) == 0))
				{
					continue;
				}
			}
			num += record.vmethod_2() + 8;
		}
		return num;
	}

	[CompilerGenerated]
	private static Class2669 smethod_2(Class2623 obj)
	{
		return (Class2669)obj;
	}
}
