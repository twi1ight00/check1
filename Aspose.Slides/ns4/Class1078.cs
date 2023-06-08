using System;
using System.Drawing;
using Aspose.Slides;

namespace ns4;

internal class Class1078
{
	internal static void smethod_0(Presentation pres)
	{
		pres.DocumentProperties.NameOfApplication = "Microsoft Office PowerPoint";
		pres.DocumentProperties.PresentationFormat = "Ýêðàí (4:3)";
		pres.DocumentProperties.SharedDoc = false;
		pres.DocumentProperties.TotalEditingTime = TimeSpan.FromMinutes(1.0);
		pres.DocumentProperties.Title = "";
		pres.DocumentProperties.Author = "";
		pres.DocumentProperties.CreatedTime = DateTime.Now;
		pres.DocumentProperties.LastSavedBy = "";
		pres.DocumentProperties.LastSavedTime = DateTime.Now;
		pres.DocumentProperties.NameOfApplication = "Aspose.Slides for .NET 15.1.0.0";
		pres.DocumentProperties.RevisionNumber = 1;
		Class1075.smethod_0(pres.MasterTheme);
		MasterSlide masterSlide = Class1079.smethod_0(pres);
		Class1081.smethod_0(masterSlide, SlideLayoutType.Title);
		Class1081.smethod_0(masterSlide, SlideLayoutType.TitleAndObject);
		Class1081.smethod_0(masterSlide, SlideLayoutType.SectionHeader);
		Class1081.smethod_0(masterSlide, SlideLayoutType.TwoObjects);
		Class1081.smethod_0(masterSlide, SlideLayoutType.TwoTextAndTwoObjects);
		Class1081.smethod_0(masterSlide, SlideLayoutType.TitleOnly);
		LayoutSlide layoutSlide = Class1081.smethod_0(masterSlide, SlideLayoutType.Blank);
		Class1081.smethod_0(masterSlide, SlideLayoutType.TitleObjectAndCaption);
		Class1081.smethod_0(masterSlide, SlideLayoutType.PictureAndCaption);
		Class1081.smethod_0(masterSlide, SlideLayoutType.VerticalText);
		Class1081.smethod_0(masterSlide, SlideLayoutType.VerticalTitleAndText);
		((MasterSlideCollection)pres.Masters).Add(masterSlide);
		masterSlide.method_9();
		Slide slide = Class1080.smethod_0(pres);
		((SlideCollection)pres.Slides).Add(slide);
		pres.SlideSize.Type = SlideSizeType.OnScreen;
		pres.PPTXUnsupportedProps.NotesSize = new SizeF(540f, 720f);
		pres.DefaultTextStyle.DefaultParagraphFormat.DefaultPortionFormat.LanguageId = "en-US";
		((TextStyle)pres.DefaultTextStyle).method_0(1);
		IParagraphFormat level = pres.DefaultTextStyle.GetLevel(0);
		level.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
		level.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
		level.DefaultPortionFormat.FontHeight = 18f;
		level.DefaultPortionFormat.KerningMinimalSize = 12f;
		level.DefaultPortionFormat.LatinFont = new FontData("+mn-lt");
		level.DefaultPortionFormat.EastAsianFont = new FontData("+mn-ea");
		level.DefaultPortionFormat.ComplexScriptFont = new FontData("+mn-cs");
		level.Alignment = TextAlignment.Left;
		level.MarginLeft = 0f;
		level.DefaultTabSize = 72f;
		level.RightToLeft = NullableBool.False;
		level.EastAsianLineBreak = NullableBool.True;
		level.LatinLineBreak = NullableBool.False;
		level.HangingPunctuation = NullableBool.True;
		((TextStyle)pres.DefaultTextStyle).method_0(2);
		IParagraphFormat level2 = pres.DefaultTextStyle.GetLevel(1);
		level2.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
		level2.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
		level2.DefaultPortionFormat.FontHeight = 18f;
		level2.DefaultPortionFormat.KerningMinimalSize = 12f;
		level2.DefaultPortionFormat.LatinFont = new FontData("+mn-lt");
		level2.DefaultPortionFormat.EastAsianFont = new FontData("+mn-ea");
		level2.DefaultPortionFormat.ComplexScriptFont = new FontData("+mn-cs");
		level2.Alignment = TextAlignment.Left;
		level2.MarginLeft = 36f;
		level2.DefaultTabSize = 72f;
		level2.RightToLeft = NullableBool.False;
		level2.EastAsianLineBreak = NullableBool.True;
		level2.LatinLineBreak = NullableBool.False;
		level2.HangingPunctuation = NullableBool.True;
		((TextStyle)pres.DefaultTextStyle).method_0(3);
		IParagraphFormat level3 = pres.DefaultTextStyle.GetLevel(2);
		level3.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
		level3.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
		level3.DefaultPortionFormat.FontHeight = 18f;
		level3.DefaultPortionFormat.KerningMinimalSize = 12f;
		level3.DefaultPortionFormat.LatinFont = new FontData("+mn-lt");
		level3.DefaultPortionFormat.EastAsianFont = new FontData("+mn-ea");
		level3.DefaultPortionFormat.ComplexScriptFont = new FontData("+mn-cs");
		level3.Alignment = TextAlignment.Left;
		level3.MarginLeft = 72f;
		level3.DefaultTabSize = 72f;
		level3.RightToLeft = NullableBool.False;
		level3.EastAsianLineBreak = NullableBool.True;
		level3.LatinLineBreak = NullableBool.False;
		level3.HangingPunctuation = NullableBool.True;
		((TextStyle)pres.DefaultTextStyle).method_0(4);
		IParagraphFormat level4 = pres.DefaultTextStyle.GetLevel(3);
		level4.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
		level4.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
		level4.DefaultPortionFormat.FontHeight = 18f;
		level4.DefaultPortionFormat.KerningMinimalSize = 12f;
		level4.DefaultPortionFormat.LatinFont = new FontData("+mn-lt");
		level4.DefaultPortionFormat.EastAsianFont = new FontData("+mn-ea");
		level4.DefaultPortionFormat.ComplexScriptFont = new FontData("+mn-cs");
		level4.Alignment = TextAlignment.Left;
		level4.MarginLeft = 108f;
		level4.DefaultTabSize = 72f;
		level4.RightToLeft = NullableBool.False;
		level4.EastAsianLineBreak = NullableBool.True;
		level4.LatinLineBreak = NullableBool.False;
		level4.HangingPunctuation = NullableBool.True;
		((TextStyle)pres.DefaultTextStyle).method_0(5);
		IParagraphFormat level5 = pres.DefaultTextStyle.GetLevel(4);
		level5.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
		level5.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
		level5.DefaultPortionFormat.FontHeight = 18f;
		level5.DefaultPortionFormat.KerningMinimalSize = 12f;
		level5.DefaultPortionFormat.LatinFont = new FontData("+mn-lt");
		level5.DefaultPortionFormat.EastAsianFont = new FontData("+mn-ea");
		level5.DefaultPortionFormat.ComplexScriptFont = new FontData("+mn-cs");
		level5.Alignment = TextAlignment.Left;
		level5.MarginLeft = 144f;
		level5.DefaultTabSize = 72f;
		level5.RightToLeft = NullableBool.False;
		level5.EastAsianLineBreak = NullableBool.True;
		level5.LatinLineBreak = NullableBool.False;
		level5.HangingPunctuation = NullableBool.True;
		((TextStyle)pres.DefaultTextStyle).method_0(6);
		IParagraphFormat level6 = pres.DefaultTextStyle.GetLevel(5);
		level6.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
		level6.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
		level6.DefaultPortionFormat.FontHeight = 18f;
		level6.DefaultPortionFormat.KerningMinimalSize = 12f;
		level6.DefaultPortionFormat.LatinFont = new FontData("+mn-lt");
		level6.DefaultPortionFormat.EastAsianFont = new FontData("+mn-ea");
		level6.DefaultPortionFormat.ComplexScriptFont = new FontData("+mn-cs");
		level6.Alignment = TextAlignment.Left;
		level6.MarginLeft = 180f;
		level6.DefaultTabSize = 72f;
		level6.RightToLeft = NullableBool.False;
		level6.EastAsianLineBreak = NullableBool.True;
		level6.LatinLineBreak = NullableBool.False;
		level6.HangingPunctuation = NullableBool.True;
		((TextStyle)pres.DefaultTextStyle).method_0(7);
		IParagraphFormat level7 = pres.DefaultTextStyle.GetLevel(6);
		level7.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
		level7.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
		level7.DefaultPortionFormat.FontHeight = 18f;
		level7.DefaultPortionFormat.KerningMinimalSize = 12f;
		level7.DefaultPortionFormat.LatinFont = new FontData("+mn-lt");
		level7.DefaultPortionFormat.EastAsianFont = new FontData("+mn-ea");
		level7.DefaultPortionFormat.ComplexScriptFont = new FontData("+mn-cs");
		level7.Alignment = TextAlignment.Left;
		level7.MarginLeft = 216f;
		level7.DefaultTabSize = 72f;
		level7.RightToLeft = NullableBool.False;
		level7.EastAsianLineBreak = NullableBool.True;
		level7.LatinLineBreak = NullableBool.False;
		level7.HangingPunctuation = NullableBool.True;
		((TextStyle)pres.DefaultTextStyle).method_0(8);
		IParagraphFormat level8 = pres.DefaultTextStyle.GetLevel(7);
		level8.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
		level8.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
		level8.DefaultPortionFormat.FontHeight = 18f;
		level8.DefaultPortionFormat.KerningMinimalSize = 12f;
		level8.DefaultPortionFormat.LatinFont = new FontData("+mn-lt");
		level8.DefaultPortionFormat.EastAsianFont = new FontData("+mn-ea");
		level8.DefaultPortionFormat.ComplexScriptFont = new FontData("+mn-cs");
		level8.Alignment = TextAlignment.Left;
		level8.MarginLeft = 252f;
		level8.DefaultTabSize = 72f;
		level8.RightToLeft = NullableBool.False;
		level8.EastAsianLineBreak = NullableBool.True;
		level8.LatinLineBreak = NullableBool.False;
		level8.HangingPunctuation = NullableBool.True;
		((TextStyle)pres.DefaultTextStyle).method_0(9);
		IParagraphFormat level9 = pres.DefaultTextStyle.GetLevel(8);
		level9.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
		level9.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
		level9.DefaultPortionFormat.FontHeight = 18f;
		level9.DefaultPortionFormat.KerningMinimalSize = 12f;
		level9.DefaultPortionFormat.LatinFont = new FontData("+mn-lt");
		level9.DefaultPortionFormat.EastAsianFont = new FontData("+mn-ea");
		level9.DefaultPortionFormat.ComplexScriptFont = new FontData("+mn-cs");
		level9.Alignment = TextAlignment.Left;
		level9.MarginLeft = 288f;
		level9.DefaultTabSize = 72f;
		level9.RightToLeft = NullableBool.False;
		level9.EastAsianLineBreak = NullableBool.True;
		level9.LatinLineBreak = NullableBool.False;
		level9.HangingPunctuation = NullableBool.True;
		pres.PPTXUnsupportedProps.SaveSubsetFonts = true;
		foreach (LayoutSlide layoutSlide2 in pres.LayoutSlides)
		{
			layoutSlide2.method_9();
		}
		slide.method_9();
		slide.LayoutSlide = layoutSlide;
	}
}
