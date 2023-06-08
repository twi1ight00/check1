using ns108;
using ns121;
using ns99;

namespace ns100;

internal class Class4466 : Class4465
{
	private Class4409 class4409_0;

	private uint uint_1;

	private object object_0 = new object();

	public override double Ascender => FontBBox.double_3;

	public override double Descender => FontBBox.double_1;

	public override Class4518 FontBBox => class4409_0.TopmostFont.FontDictionary.class4518_0;

	public override Class4509 FontMatrix
	{
		get
		{
			if (class4409_0.TopmostFont.FontDictionary.class4509_0 != null)
			{
				return class4409_0.TopmostFont.FontDictionary.class4509_0;
			}
			return Class4438.class4509_1;
		}
	}

	public override uint UnitsPerEM
	{
		get
		{
			if (uint_1 == 0)
			{
				lock (object_0)
				{
					if (uint_1 == 0)
					{
						uint_1 = (uint)(1.0 / FontMatrix.A);
					}
				}
			}
			return uint_1;
		}
	}

	internal Class4466(Class4409 font)
	{
		class4409_0 = font;
	}

	public Class4509 method_1(Class4506 glyphId)
	{
		int glyphIndex = ((!(glyphId is Class4508)) ? class4409_0.method_1(((Class4507)glyphId).Value) : ((Class4508)glyphId).Value);
		Class4444 @class = class4409_0.TopmostFont;
		if (class4409_0.SubFonts != null && class4409_0.SubFonts.Length != 0)
		{
			byte b = class4409_0.Internals.FdSelect.method_0(glyphIndex);
			if (b < class4409_0.SubFonts.Length)
			{
				@class = class4409_0.SubFonts[b];
			}
		}
		if (@class != class4409_0.TopmostFont && @class.FontDictionary.class4509_0 != null)
		{
			if (class4409_0.TopmostFont.FontDictionary.class4509_0 != null)
			{
				return @class.FontDictionary.class4509_0.method_4(class4409_0.TopmostFont.FontDictionary.class4509_0);
			}
			return @class.FontDictionary.class4509_0;
		}
		if (class4409_0.TopmostFont.FontDictionary.class4509_0 != null)
		{
			return class4409_0.TopmostFont.FontDictionary.class4509_0;
		}
		return Class4438.class4509_1;
	}

	public override double imethod_1(Class4506 glyphID)
	{
		double num = base.imethod_1(glyphID);
		if (num == 0.0)
		{
			Class4480 @class = class4409_0.imethod_0(glyphID);
			if (@class != null)
			{
				return @class.WidthVectorX;
			}
		}
		return num;
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
