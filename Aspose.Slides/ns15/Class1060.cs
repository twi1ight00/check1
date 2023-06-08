using System;
using System.Reflection;
using System.Resources;
using Aspose.Slides;
using ns4;
using ns62;

namespace ns15;

internal class Class1060
{
	internal static readonly string string_0 = "Aspose.Slides.DOM.resources.patterns";

	private static readonly string[] string_1 = new string[48]
	{
		"05%", "10%", "20%", "25%", "30%", "40%", "50%", "60%", "70%", "75%",
		"80%", "90%", "Dark Horizontal", "Dark Vertical", "Dark Downward Diagonal", "Dark Upward Diagonal", "Small Checker Board", "Trellis", "Light Horizontal", "Light Vertical",
		"Light Downward Diagonal", "Light Upward Diagonal", "Small Grid", "Dotted Diamond", "Wide Downward Diagonal", "Wide Upward Diagonal", "Dashed Upward Diagonal", "Dashed Downward Diagonal", "Narrow Vertical", "Narrow Horizontal",
		"Dashed Vertical", "Dashed Horizontal", "Large Confetti", "Large Grid", "Horizontal Brick", "Large Checker Board", "Small Confetti", "Zigzag", "Solid Diamond", "Diagonal Brick",
		"Outlined Diamond", "Plaid", "Sphere", "Weave", "Dotted Grid", "Divot", "Shingle", "Wave"
	};

	internal static void smethod_0(PatternFormat patternFormat, Class2670 frame, Class854 slideDeserializationContext)
	{
		Class1049.smethod_2((ColorFormat)patternFormat.ForeColor, frame, Enum426.const_82, Enum426.const_83, 16777215u);
		Class1049.smethod_2((ColorFormat)patternFormat.BackColor, frame, Enum426.const_84, Enum426.const_85, 16777215u);
		Class2911 @class = Class2945.smethod_2(frame, Enum426.const_87) as Class2911;
		patternFormat.PatternStyle = PatternStyle.Unknown;
		if (@class == null)
		{
			return;
		}
		Guid guid = slideDeserializationContext.DeserializationContext.ImagesGuids[@class.Value - 1];
		ResourceManager resourceManager = new ResourceManager(string_0, Assembly.GetExecutingAssembly());
		for (int i = 1; i < 49; i++)
		{
			Guid guid2 = (Guid)resourceManager.GetObject(smethod_2((Enum21)i) + " Guid");
			if (object.Equals(guid, guid2))
			{
				patternFormat.PatternStyle = Class232.smethod_18((Enum21)i);
			}
		}
	}

	internal static void smethod_1(PatternFormat patternFormat, Class2834 fopt, Class856 serializationContext)
	{
		Class2944 properties = fopt.Properties;
		properties.method_0(new Class2911(Enum426.const_81, 1u));
		Class1049.smethod_8(patternFormat.ForeColor, properties, Enum426.const_82, Enum426.const_83, serializationContext);
		Class1049.smethod_8(patternFormat.BackColor, properties, Enum426.const_84, Enum426.const_85, serializationContext);
		properties.Remove(Enum426.const_87);
		if (patternFormat.PatternStyle != 0 && patternFormat.PatternStyle != PatternStyle.NotDefined)
		{
			Class878 @class = serializationContext.method_7(patternFormat.PatternStyle);
			Class2911 class2 = new Class2911(Enum426.const_87, isBid: true, 0u);
			properties.Add(class2);
			@class.method_0(class2);
		}
	}

	internal static string smethod_2(Enum21 pstyle)
	{
		int num = (int)(pstyle - 1);
		if (num >= 0 && num < string_1.Length)
		{
			return string_1[num];
		}
		return string_1[3];
	}

	private static string smethod_3(Enum21 pstyle)
	{
		return pstyle switch
		{
			Enum21.const_1 => "05%", 
			Enum21.const_2 => "10%", 
			Enum21.const_3 => "20%", 
			Enum21.const_4 => "25%", 
			Enum21.const_5 => "30%", 
			Enum21.const_6 => "40%", 
			Enum21.const_7 => "50%", 
			Enum21.const_8 => "60%", 
			Enum21.const_9 => "70%", 
			Enum21.const_10 => "75%", 
			Enum21.const_11 => "80%", 
			Enum21.const_12 => "90%", 
			Enum21.const_13 => "Dark Horizontal", 
			Enum21.const_14 => "Dark Vertical", 
			Enum21.const_15 => "Dark Downward Diagonal", 
			Enum21.const_16 => "Dark Upward Diagonal", 
			Enum21.const_17 => "Small Checker Board", 
			Enum21.const_18 => "Trellis", 
			Enum21.const_19 => "Light Horizontal", 
			Enum21.const_20 => "Light Vertical", 
			Enum21.const_21 => "Light Downward Diagonal", 
			Enum21.const_22 => "Light Upward Diagonal", 
			Enum21.const_23 => "Small Grid", 
			Enum21.const_24 => "Dotted Diamond", 
			Enum21.const_25 => "Wide Downward Diagonal", 
			Enum21.const_26 => "Wide Upward Diagonal", 
			Enum21.const_27 => "Dashed Downward Diagonal", 
			Enum21.const_28 => "Dashed Upward Diagonal", 
			Enum21.const_29 => "Narrow Vertical", 
			Enum21.const_30 => "Narrow Horizontal", 
			Enum21.const_31 => "Dashed Vertical", 
			Enum21.const_32 => "Dashed Horizontal", 
			Enum21.const_33 => "Large Confetti", 
			Enum21.const_34 => "Large Grid", 
			Enum21.const_35 => "Horizontal Brick", 
			Enum21.const_36 => "Large Checker Board", 
			Enum21.const_37 => "Small Confetti", 
			Enum21.const_38 => "Zigzag", 
			Enum21.const_39 => "Solid Diamond", 
			Enum21.const_40 => "Diagonal Brick", 
			Enum21.const_41 => "Outlined Diamond", 
			Enum21.const_42 => "Plaid", 
			Enum21.const_43 => "Sphere", 
			Enum21.const_44 => "Weave", 
			Enum21.const_45 => "Dotted Grid", 
			Enum21.const_46 => "Divot", 
			Enum21.const_47 => "Shingle", 
			Enum21.const_48 => "Wave", 
			_ => "25%", 
		};
	}
}
