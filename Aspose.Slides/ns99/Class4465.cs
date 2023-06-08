using System.Collections;
using ns121;
using ns151;

namespace ns99;

internal abstract class Class4465 : Interface118
{
	private bool bool_0;

	private Class4518 class4518_0;

	private uint uint_0;

	private double double_0;

	private double double_1;

	private Class4509 class4509_0;

	internal Hashtable hashtable_0;

	internal Class4699 class4699_0;

	public virtual double Ascender
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public virtual double Descender
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public virtual double TypoDescender
	{
		get
		{
			return Descender;
		}
		set
		{
			Descender = value;
		}
	}

	public virtual double TypoAscender
	{
		get
		{
			return Ascender;
		}
		set
		{
			Ascender = value;
		}
	}

	public virtual double LineGap => 0.0;

	public virtual double TypoLineGap => LineGap;

	public bool IsFixedPitch
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public virtual Class4518 FontBBox
	{
		get
		{
			return class4518_0;
		}
		set
		{
			class4518_0 = value;
		}
	}

	public virtual Class4509 FontMatrix
	{
		get
		{
			return class4509_0;
		}
		set
		{
			class4509_0 = value;
		}
	}

	public virtual uint UnitsPerEM
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	internal Class4465()
	{
		hashtable_0 = new Hashtable();
		class4699_0 = new Class4699();
	}

	internal abstract int vmethod_0(Class4506 glyphId);

	public virtual double imethod_0(Class4506 prevGlyphId, Class4506 nextGlyphId)
	{
		Hashtable hashtable = class4699_0[vmethod_0(prevGlyphId)];
		if (hashtable != null)
		{
			int num = vmethod_0(nextGlyphId);
			if (hashtable.ContainsKey(num))
			{
				return ((Class4698)hashtable[num]).double_0;
			}
		}
		return 0.0;
	}

	public virtual double imethod_3(double fontSize)
	{
		return Ascender / (double)UnitsPerEM * fontSize;
	}

	public virtual double imethod_4(double fontSize)
	{
		return Descender / (double)UnitsPerEM * fontSize;
	}

	public virtual double imethod_5(double fontSize)
	{
		return TypoDescender / (double)UnitsPerEM * fontSize;
	}

	public virtual double imethod_6(double fontSize)
	{
		return TypoAscender / (double)UnitsPerEM * fontSize;
	}

	public virtual double imethod_7(double fontSize)
	{
		return TypoLineGap / (double)UnitsPerEM * fontSize;
	}

	internal virtual void vmethod_1(Class4506 glyphID, double width, Class4518 bbox)
	{
		Class4697 @class = new Class4697();
		@class.double_0 = width;
		@class.class4518_0 = bbox;
		hashtable_0[glyphID] = @class;
	}

	public virtual double imethod_1(Class4506 glyphID)
	{
		if (hashtable_0.ContainsKey(glyphID))
		{
			return ((Class4697)hashtable_0[glyphID]).double_0;
		}
		return 0.0;
	}

	public virtual Class4518 imethod_2(Class4506 glyphID)
	{
		Class4518 @class = null;
		if (hashtable_0.ContainsKey(glyphID))
		{
			@class = ((Class4697)hashtable_0[glyphID]).class4518_0;
		}
		if (@class == null)
		{
			@class = FontBBox;
		}
		return @class;
	}

	internal virtual void vmethod_2()
	{
	}

	internal virtual void vmethod_3(Class4506 previousGlyphID, Class4506 nextGlyphID, double kerningValue)
	{
		Class4698 @class = new Class4698();
		@class.int_0 = vmethod_0(nextGlyphID);
		@class.double_0 = kerningValue;
		class4699_0.Add(vmethod_0(previousGlyphID), @class);
	}
}
