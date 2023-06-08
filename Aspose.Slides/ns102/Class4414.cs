using ns106;
using ns119;
using ns154;
using ns99;

namespace ns102;

internal class Class4414 : Class4413
{
	internal override Class4718 Type1FontDictionary
	{
		get
		{
			throw new Exception47("Metric font doesn't support glyphs retrieval");
		}
		set
		{
		}
	}

	public override Interface114 Encoding => base.Encoding;

	public override string FontFamily => ((Class4468)Metrics).FamilyName;

	public override string FontName => ((Class4468)Metrics).FontName;

	public override string Style => ((Class4468)Metrics).Weight;

	public override Enum640 FontStyle => method_2();

	public override int NumGlyphs
	{
		get
		{
			if (Encoding != null)
			{
				return ((Class4738)Encoding).imethod_5().Count;
			}
			return 0;
		}
	}

	internal Class4414(Class4490 fontDefinition)
		: base(fontDefinition)
	{
	}

	public override Class4480 vmethod_0(string id)
	{
		throw new Exception47("Metric font doesn't support glyphs retrieval");
	}

	public override Class4480 imethod_0(Class4506 id)
	{
		throw new Exception47("Metric font doesn't support glyphs retrieval");
	}

	public override Class4506[] imethod_1()
	{
		throw new Exception47("Metric font doesn't support glyphs retrieval");
	}

	private Enum640 method_2()
	{
		Enum640 @enum = (Enum640)0;
		string weight = ((Class4468)Metrics).Weight;
		double italicAngle = ((Class4468)Metrics).ItalicAngle;
		if (weight != null)
		{
			string text = weight.ToLower();
			if (text.IndexOf("bold") != -1)
			{
				@enum |= Enum640.flag_1;
			}
			if (italicAngle != 0.0 || text.IndexOf("italic") != -1 || text.IndexOf("oblique") != -1)
			{
				@enum |= Enum640.flag_2;
			}
		}
		if (@enum == (Enum640)0)
		{
			@enum = Enum640.flag_0;
		}
		return @enum;
	}
}
