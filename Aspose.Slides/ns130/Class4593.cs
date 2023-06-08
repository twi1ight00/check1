using System;
using System.Diagnostics;
using System.Text;

namespace ns130;

internal class Class4593
{
	public static readonly string string_0 = "ttcf";

	public static readonly string string_1 = "cmap";

	public static readonly string string_2 = "head";

	public static readonly string string_3 = "hhea";

	public static readonly string string_4 = "hmtx";

	public static readonly string string_5 = "maxp";

	public static readonly string string_6 = "name";

	public static readonly string string_7 = "OS/2";

	public static readonly string string_8 = "post";

	public static readonly string string_9 = "cvt ";

	public static readonly string string_10 = "fpgm";

	public static readonly string string_11 = "glyf";

	public static readonly string string_12 = "loca";

	public static readonly string string_13 = "prep";

	public static readonly string string_14 = "CFF ";

	public static readonly string string_15 = "VORG";

	public static readonly string string_16 = "EBDT";

	public static readonly string string_17 = "EBLC";

	public static readonly string string_18 = "EBSC";

	public static readonly string string_19 = "BASE";

	public static readonly string string_20 = "GDEF";

	public static readonly string string_21 = "GPOS";

	public static readonly string string_22 = "GSUB";

	public static readonly string string_23 = "JSTF";

	public static readonly string string_24 = "DSIG";

	public static readonly string string_25 = "gasp";

	public static readonly string string_26 = "hdmx";

	public static readonly string string_27 = "kern";

	public static readonly string string_28 = "LTSH";

	public static readonly string string_29 = "PCLT";

	public static readonly string string_30 = "VDMX";

	public static readonly string string_31 = "vhea";

	public static readonly string string_32 = "vmtx";

	public static readonly string string_33 = "bsln";

	public static readonly string string_34 = "feat";

	public static readonly string string_35 = "lcar";

	public static readonly string string_36 = "morx";

	public static readonly string string_37 = "opbd";

	public static readonly string string_38 = "prop";

	public static readonly string string_39 = "Feat";

	public static readonly string string_40 = "Glat";

	public static readonly string string_41 = "Gloc";

	public static readonly string string_42 = "Sile";

	public static readonly string string_43 = "Silf";

	public static readonly string string_44 = "bhed";

	public static readonly string string_45 = "bdat";

	public static readonly string string_46 = "bloc";

	private static readonly string[] string_47 = new string[47]
	{
		string_0, string_1, string_2, string_3, string_4, string_5, string_6, string_7, string_8, string_9,
		string_10, string_11, string_12, string_13, string_14, string_15, string_16, string_17, string_18, string_19,
		string_20, string_21, string_22, string_23, string_24, string_25, string_26, string_27, string_28, string_29,
		string_30, string_31, string_32, string_33, string_34, string_35, string_36, string_37, string_38, string_39,
		string_40, string_41, string_42, string_43, string_44, string_45, string_46
	};

	public static uint smethod_0(string tag)
	{
		if (tag.Length != 4)
		{
			throw new ArgumentException("Length of tag must be 4", "tag");
		}
		byte[] bytes = Encoding.ASCII.GetBytes(tag);
		return (uint)((bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3]);
	}

	public static string smethod_1(uint tag)
	{
		byte[] bytes = new byte[4]
		{
			(byte)(0xFFu & (tag >> 24)),
			(byte)(0xFFu & (tag >> 16)),
			(byte)(0xFFu & (tag >> 8)),
			(byte)(0xFFu & tag)
		};
		return Encoding.ASCII.GetString(bytes);
	}

	[Conditional("DEBUG")]
	private static void smethod_2(string tag)
	{
		string[] array = string_47;
		foreach (string text in array)
		{
			if (tag == text)
			{
				break;
			}
		}
	}
}
