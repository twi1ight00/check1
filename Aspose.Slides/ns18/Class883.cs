using System.Drawing;
using ns119;
using ns16;
using ns24;
using ns4;
using ns53;
using ns56;
using ns99;

namespace ns18;

internal class Class883
{
	public static void smethod_0(Class54 fontsManager, Class2234 embeddedFontListElementData, Class1341 deserializationContext)
	{
		if (embeddedFontListElementData == null)
		{
			return;
		}
		Class1348 relationshipsOfCurrentPartEntry = deserializationContext.RelationshipsOfCurrentPartEntry;
		Class61 @class = new Class61();
		@class.PPTXUnsupportedProps.EmbeddedFonts.Clear();
		Class2132[] embeddedFontList = embeddedFontListElementData.EmbeddedFontList;
		if (embeddedFontList == null || embeddedFontList.Length <= 0)
		{
			return;
		}
		bool flag = false;
		Class2132[] array = embeddedFontList;
		foreach (Class2132 class2 in array)
		{
			Class334 class3 = new Class334();
			class3.Font = class2.Font;
			string typeface = class2.Font.Typeface;
			if (class2.Regular != null)
			{
				Class1347 class4 = relationshipsOfCurrentPartEntry[class2.Regular.R_Id];
				class3.Regular = class4.TargetPart.Clone();
				smethod_1(@class, class4.TargetPart, typeface, class2.Font.Charset, class2.Font.PitchFamily, FontStyle.Regular, deserializationContext);
				flag = true;
			}
			if (class2.Bold != null)
			{
				Class1347 class5 = relationshipsOfCurrentPartEntry[class2.Bold.R_Id];
				class3.Bold = class5.TargetPart.Clone();
				smethod_1(@class, class5.TargetPart, typeface, class2.Font.Charset, class2.Font.PitchFamily, FontStyle.Bold, deserializationContext);
				flag = true;
			}
			if (class2.Italic != null)
			{
				Class1347 class6 = relationshipsOfCurrentPartEntry[class2.Italic.R_Id];
				class3.Italic = class6.TargetPart.Clone();
				smethod_1(@class, class6.TargetPart, typeface, class2.Font.Charset, class2.Font.PitchFamily, FontStyle.Italic, deserializationContext);
				flag = true;
			}
			if (class2.BoldItalic != null)
			{
				Class1347 class7 = relationshipsOfCurrentPartEntry[class2.BoldItalic.R_Id];
				class3.BoldItalic = class7.TargetPart.Clone();
				smethod_1(@class, class7.TargetPart, typeface, class2.Font.Charset, class2.Font.PitchFamily, FontStyle.Bold | FontStyle.Italic, deserializationContext);
				flag = true;
			}
			@class.PPTXUnsupportedProps.EmbeddedFonts.Add(class3);
		}
		if (flag)
		{
			@class.method_6();
		}
		fontsManager.method_0(@class);
	}

	private static void smethod_1(Class61 fontsCollection, Class1342 partEntry, string typeface, int charset, int pitchFamily, FontStyle style, Class1341 deserializationContext)
	{
		Class4488 streamSource = new Class4488(partEntry.Data);
		partEntry.Processed = true;
		Class4490 fontDefinition = new Class4490(Enum639.const_0, "fntdata", streamSource);
		fontsCollection.method_5(typeface, charset, pitchFamily, style, Class4408.smethod_0(fontDefinition), deserializationContext.Presentation.LoadOptions);
	}

	public static void smethod_2(Class54 fontsCollection, Class2234.Delegate2440 embeddedFontLst, Class1346 serializationContext)
	{
		if (fontsCollection.EmbeddedFonts == null || fontsCollection.EmbeddedFonts.PPTXUnsupportedProps.EmbeddedFonts.Count == 0)
		{
			return;
		}
		Class1348 relationshipsOfCurrentPartEntry = serializationContext.RelationshipsOfCurrentPartEntry;
		Class2234 @class = embeddedFontLst();
		foreach (Class334 embeddedFont in fontsCollection.EmbeddedFonts.PPTXUnsupportedProps.EmbeddedFonts)
		{
			Class2132 class2 = @class.delegate2127_0();
			class2.Font.Charset = embeddedFont.Font.Charset;
			class2.Font.Panose = embeddedFont.Font.Panose;
			class2.Font.PitchFamily = embeddedFont.Font.PitchFamily;
			class2.Font.Typeface = embeddedFont.Font.Typeface;
			if (embeddedFont.Regular != null)
			{
				serializationContext.Package.method_6(embeddedFont.Regular);
				class2.delegate2124_0().R_Id = relationshipsOfCurrentPartEntry.method_4(embeddedFont.Regular).Id;
			}
			if (embeddedFont.Bold != null)
			{
				serializationContext.Package.method_6(embeddedFont.Bold);
				class2.delegate2124_1().R_Id = relationshipsOfCurrentPartEntry.method_4(embeddedFont.Bold).Id;
			}
			if (embeddedFont.Italic != null)
			{
				serializationContext.Package.method_6(embeddedFont.Italic);
				class2.delegate2124_2().R_Id = relationshipsOfCurrentPartEntry.method_4(embeddedFont.Italic).Id;
			}
			if (embeddedFont.BoldItalic != null)
			{
				serializationContext.Package.method_6(embeddedFont.BoldItalic);
				class2.delegate2124_3().R_Id = relationshipsOfCurrentPartEntry.method_4(embeddedFont.BoldItalic).Id;
			}
		}
	}
}
