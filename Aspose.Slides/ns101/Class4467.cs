using System;
using ns121;
using ns143;
using ns147;
using ns99;

namespace ns101;

internal class Class4467 : Class4465
{
	private Class4681 class4681_0;

	private Class4518 class4518_1;

	private Class4509 class4509_1;

	private object object_0 = new object();

	private object object_1 = new object();

	[Obsolete("please use TTFFont.Encoding.DecodeToGID(char unicode) => GetGlyphWidth(glyphId) instead")]
	private Class4625 class4625_0;

	public override double Ascender
	{
		get
		{
			if (class4681_0.HheaTable != null)
			{
				return class4681_0.HheaTable.Ascent;
			}
			return 0.0;
		}
		set
		{
			if (class4681_0.HheaTable != null)
			{
				class4681_0.HheaTable.Ascent = (short)value;
			}
		}
	}

	public override double Descender
	{
		get
		{
			if (class4681_0.HheaTable != null)
			{
				return class4681_0.HheaTable.Descent;
			}
			return 0.0;
		}
		set
		{
			if (class4681_0.HheaTable != null)
			{
				class4681_0.HheaTable.Descent = (short)value;
			}
		}
	}

	public override double LineGap
	{
		get
		{
			if (class4681_0.HheaTable != null)
			{
				return class4681_0.HheaTable.LineGap;
			}
			return 0.0;
		}
	}

	public override double TypoDescender
	{
		get
		{
			if (class4681_0.OS2Table != null)
			{
				return class4681_0.OS2Table.STypoDescender;
			}
			return Descender;
		}
		set
		{
			if (class4681_0.OS2Table != null)
			{
				class4681_0.OS2Table.STypoDescender = (short)value;
			}
		}
	}

	public override double TypoLineGap
	{
		get
		{
			if (class4681_0.OS2Table != null)
			{
				return class4681_0.OS2Table.STypoLineGap;
			}
			return LineGap;
		}
	}

	public override double TypoAscender
	{
		get
		{
			if (class4681_0.OS2Table != null)
			{
				return class4681_0.OS2Table.STypoAscender;
			}
			return Descender;
		}
		set
		{
			if (class4681_0.OS2Table != null)
			{
				class4681_0.OS2Table.STypoAscender = (short)value;
			}
		}
	}

	public override Class4518 FontBBox
	{
		get
		{
			if (class4518_1 == null)
			{
				lock (object_0)
				{
					if (class4518_1 == null)
					{
						if (class4681_0.HeadTable != null)
						{
							class4518_1 = new Class4518(class4681_0.HeadTable.XMin, class4681_0.HeadTable.YMin, class4681_0.HeadTable.XMax, class4681_0.HeadTable.YMax);
						}
						else
						{
							class4518_1 = new Class4518(0.0, 0.0, 0.0, 0.0);
						}
					}
				}
			}
			return class4518_1;
		}
	}

	public override Class4509 FontMatrix
	{
		get
		{
			if (class4509_1 == null)
			{
				lock (object_1)
				{
					if (class4509_1 == null)
					{
						class4509_1 = new Class4509(new double[6]
						{
							1.0 / (double)UnitsPerEM,
							0.0,
							0.0,
							1.0 / (double)UnitsPerEM,
							0.0,
							0.0
						});
					}
				}
			}
			return class4509_1;
		}
	}

	public override uint UnitsPerEM
	{
		get
		{
			if (class4681_0.HeadTable == null)
			{
				return 1000u;
			}
			return class4681_0.HeadTable.UnitsPerEm;
		}
		set
		{
			if (class4681_0.HeadTable != null)
			{
				class4681_0.HeadTable.UnitsPerEm = value;
			}
		}
	}

	internal Class4467(Class4681 ttfTables)
	{
		class4681_0 = ttfTables;
		if (ttfTables != null && ttfTables.CMapTable != null)
		{
			Class4625[] array = ttfTables.CMapTable.method_3(3, 1);
			if (array != null && array.Length > 0)
			{
				class4625_0 = array[0];
			}
		}
	}

	[Obsolete("please use TTFFont.Encoding.DecodeToGID(char unicode) => GetGlyphWidth(glyphId) instead")]
	internal double method_1(char ch)
	{
		if (class4625_0 != null && ch != 0)
		{
			int glyphIndex = class4625_0.vmethod_2(ch);
			return (double)(int)class4681_0.HmtxTable.Hmetrics[glyphIndex].ushort_0 / (double)class4681_0.HeadTable.UnitsPerEm;
		}
		return 0.0;
	}

	public override double imethod_1(Class4506 glyphId)
	{
		Class4508 @class = glyphId as Class4508;
		if (@class != null)
		{
			double result = 0.0;
			if (class4681_0.HmtxTable != null && class4681_0.HmtxTable.Hmetrics.Count == 1)
			{
				result = (int)class4681_0.HmtxTable.Hmetrics[0].ushort_0;
			}
			else if (class4681_0.HmtxTable != null && @class.Value <= class4681_0.HmtxTable.Hmetrics.Count - 1)
			{
				result = (int)class4681_0.HmtxTable.Hmetrics[@class.Value].ushort_0;
			}
			else if (class4681_0.HheaTable != null)
			{
				result = (int)class4681_0.HheaTable.AdvanceWidthMax;
			}
			return result;
		}
		return base.imethod_1(glyphId);
	}

	public override double imethod_0(Class4506 prevGlyphId, Class4506 nextGlyphId)
	{
		if (class4699_0.Count > 0)
		{
			return base.imethod_0(prevGlyphId, nextGlyphId);
		}
		if (class4681_0.KernTable != null && class4681_0.KernTable.Metrics.class4699_0.Count > 0)
		{
			return class4681_0.KernTable.Metrics.imethod_0(prevGlyphId, nextGlyphId);
		}
		return 0.0;
	}

	internal override int vmethod_0(Class4506 glyphID)
	{
		Class4508 @class = glyphID as Class4508;
		if (@class != null)
		{
			return @class.Value.GetHashCode();
		}
		return glyphID.GetHashCode();
	}
}
