using System.Collections;
using ns119;
using ns99;

namespace ns101;

internal class Class4491 : Class4490
{
	public class Class4640 : Class4638
	{
		private short short_0;

		private short short_1;

		private short short_2;

		private short short_3;

		private short short_4;

		private short short_5;

		private short short_6;

		public short CharacterClass
		{
			get
			{
				return short_0;
			}
			set
			{
				short_0 = value;
			}
		}

		public short DeltaX
		{
			get
			{
				return short_1;
			}
			set
			{
				short_1 = value;
			}
		}

		public short Width
		{
			get
			{
				return short_2;
			}
			set
			{
				short_2 = value;
			}
		}

		public short Height
		{
			get
			{
				return short_3;
			}
			set
			{
				short_3 = value;
			}
		}

		public short LeftOffset
		{
			get
			{
				return short_4;
			}
			set
			{
				short_4 = value;
			}
		}

		public short TopOffset
		{
			get
			{
				return short_5;
			}
			set
			{
				short_5 = value;
			}
		}

		public short Orientation
		{
			get
			{
				return short_6;
			}
			set
			{
				short_6 = value;
			}
		}

		public Class4640(int charCode, short characterClass, short deltaX, short width, short height, short leftOffset, short topOffset, short orientation, byte[] data)
			: base(charCode, data)
		{
			short_0 = characterClass;
			short_1 = deltaX;
			short_2 = width;
			short_3 = height;
			short_4 = leftOffset;
			short_5 = topOffset;
			short_6 = orientation;
		}
	}

	public abstract class Class4638
	{
		private byte[] byte_0;

		private int int_0;

		public byte[] Data
		{
			get
			{
				return byte_0;
			}
			set
			{
				byte_0 = value;
			}
		}

		public int CharCode
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		public Class4638(int charCode, byte[] data)
		{
			byte_0 = data;
			int_0 = charCode;
		}
	}

	public abstract class Class4635
	{
		private string string_0;

		private float float_0;

		private float float_1;

		private float float_2;

		private float float_3;

		public string FontName
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		public float FontSize
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		public float XHeight
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}

		public float Ascent
		{
			get
			{
				return float_2;
			}
			set
			{
				float_2 = value;
			}
		}

		public float Descent
		{
			get
			{
				return float_3;
			}
			set
			{
				float_3 = value;
			}
		}

		public Class4635(string fontName, float fontSize, float xHeight, float ascent, float descent)
		{
			string_0 = fontName;
			float_0 = fontSize;
			float_2 = ascent;
			float_3 = descent;
			float_1 = xHeight;
		}
	}

	public class Class4636 : Class4635
	{
		private byte[] byte_0;

		private bool bool_0;

		internal byte[] GlobalData
		{
			get
			{
				return byte_0;
			}
			set
			{
				byte_0 = value;
			}
		}

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

		public Class4636(bool isFixedPitch, string fontName, float fontSize, float xHeight, float ascent, float descent, byte[] globalData)
			: base(fontName, fontSize, xHeight, ascent, descent)
		{
			bool_0 = isFixedPitch;
			byte_0 = globalData;
		}
	}

	public class Class4637 : Class4635
	{
		private int int_0;

		private int int_1;

		public int XResolution
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		public int YResolution
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		public Class4637(string fontName, float fontSize, float xHeight, float ascent, float descent, short xResolution, short yResolution)
			: base(fontName, fontSize, xHeight, ascent, descent)
		{
			int_0 = xResolution;
			int_1 = yResolution;
		}
	}

	public class Class4639 : Class4638
	{
		private int int_1;

		private short short_0;

		public int GlyphId
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		public short AdvanceWidth
		{
			get
			{
				return short_0;
			}
			set
			{
				short_0 = value;
			}
		}

		public Class4639(int charCode, int glyphId, byte[] data, short advanceWidth)
			: base(charCode, data)
		{
			int_1 = glyphId;
			short_0 = advanceWidth;
		}
	}

	private Hashtable hashtable_0 = new Hashtable();

	private Hashtable hashtable_1 = new Hashtable();

	private Class4635 class4635_0;

	public override string FontName => GlobalFontDefinition.FontName;

	public override Class4519 FontNames => new Class4519(FontName);

	internal Hashtable GlyphIdToGlyphData => hashtable_0;

	internal Hashtable CharCodeToGlyphData => hashtable_1;

	internal Class4635 GlobalFontDefinition => class4635_0;

	public Class4491()
		: base(Enum639.const_0, (Class4487)null)
	{
	}

	public void method_0(Class4635 fontDef)
	{
		class4635_0 = fontDef;
	}

	public void method_1(Class4638 charDef)
	{
		hashtable_1[charDef.CharCode] = charDef;
		if (charDef is Class4639 @class)
		{
			hashtable_0[@class.GlyphId] = charDef;
		}
	}
}
