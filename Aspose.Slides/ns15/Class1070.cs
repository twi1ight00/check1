using Aspose.Slides;
using ns63;

namespace ns15;

internal class Class1070
{
	internal static void smethod_0(TextStyle textStyle, Class2981 textRuler)
	{
		if (textRuler == null)
		{
			return;
		}
		if (textRuler.TabStops != null)
		{
			_ = textRuler.TabStops;
			for (int i = 0; i < textRuler.TabStops.Count; i++)
			{
				double position = (double)textRuler.TabStops[i].Position / 8.0;
				TabAlignment align = Class862.smethod_13(textRuler.TabStops[i].TabType);
				textStyle.paragraphFormat_0[0].Tabs.Add(position, align);
			}
		}
		if (((int?)textRuler.DefaultTabSize).HasValue)
		{
			textStyle.paragraphFormat_0[0].DefaultTabSize = Class862.smethod_17(textRuler.DefaultTabSize.Value);
		}
		textStyle.paragraphFormat_0[0].DefaultTabSize = float.NaN;
		for (int j = 0; j < 5; j++)
		{
			Class2975 @class = textRuler.method_1(j);
			if (textStyle.paragraphFormat_0[j + 1] == null)
			{
				textStyle.method_0(j + 1);
			}
			if (@class.LeftMargin.HasValue)
			{
				textStyle.paragraphFormat_0[j + 1].double_0 = Class862.smethod_17(@class.LeftMargin.Value);
			}
			if (@class.Indent.HasValue)
			{
				textStyle.paragraphFormat_0[j + 1].double_2 = Class862.smethod_17(@class.Indent.Value);
			}
			if (@class.LeftMargin.HasValue || @class.Indent.HasValue)
			{
				textStyle.paragraphFormat_0[j + 1].tabCollection_0.method_2((TabCollection)textStyle.paragraphFormat_0[0].Tabs);
				textStyle.paragraphFormat_0[j + 1].DefaultTabSize = textStyle.paragraphFormat_0[0].DefaultTabSize;
			}
		}
	}

	internal static void smethod_1(TextStyle textStyle, int levelInternalIndex, Class2974 textPFException, Class2971 textCFException, Class857 deserializationContext)
	{
		textStyle.paragraphFormat_0[levelInternalIndex] = Class862.smethod_10(textStyle, textPFException, textCFException, deserializationContext);
		textStyle.paragraphFormat_0[levelInternalIndex].m_changedEvent_OldMode += textStyle.method_9;
	}

	internal static void smethod_2(TextStyle textStyle, Class2894 textMasterStyleAtom, Class857 deserializationContext)
	{
		textStyle.nullable_0 = (Enum449)textMasterStyleAtom.Instance;
		Class2987 textMasterStyleLevel = null;
		Class2987 @class = null;
		for (int i = 0; i < textMasterStyleAtom.Levels.Count; i++)
		{
			@class = new Class2987();
			@class.method_0(textMasterStyleAtom.Levels[i]);
			if (i > 0)
			{
				@class.method_0(textMasterStyleLevel);
			}
			smethod_1(textStyle, i + 1, @class.ParagraphFormat, @class.CharFormat, deserializationContext);
			textMasterStyleLevel = @class;
		}
	}

	internal static void smethod_3(ITextStyle[] styles, ITextStyle textStyle)
	{
	}
}
