using System;
using System.Drawing;
using Aspose.Slides;

namespace ns4;

internal class Class1077
{
	internal static void smethod_0(NotesSlide notes)
	{
		notes.groupShape_0.RawFrameImpl.vmethod_0(0.0, 0.0, 0.0, 0.0);
		notes.groupShape_0.RawFrameImpl.ChildRect = new RectangleF(0f, 0f, 0f, 0f);
		notes.groupShape_0.effectFormat_0 = new EffectFormat(notes.groupShape_0);
		notes.groupShape_0.AlternativeText = "";
		notes.groupShape_0.Name = "";
		AutoShape autoShape = new AutoShape(notes);
		autoShape.AlternativeText = "";
		autoShape.Name = "Slide Image Placeholder 1";
		autoShape.method_0(Orientation.Horizontal, PlaceholderSize.Full, PlaceholderType.SlideImage, 0u, hasCustomPrompt: false);
		autoShape.ShapeLock.GroupingLocked = true;
		autoShape.ShapeLock.RotateLocked = true;
		autoShape.ShapeLock.AspectRatioLocked = true;
		((ShapeCollection)notes.groupShape_0.Shapes).Add(autoShape);
		autoShape.method_26();
		AutoShape autoShape2 = new AutoShape(notes);
		autoShape2.AlternativeText = "";
		autoShape2.Name = "Notes Placeholder 2";
		autoShape2.method_0(Orientation.Horizontal, PlaceholderSize.Full, PlaceholderType.Body, 1u, hasCustomPrompt: false);
		autoShape2.ShapeLock.GroupingLocked = true;
		autoShape2.AddTextFrame("");
		autoShape2.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Normal;
		((ShapeCollection)notes.groupShape_0.Shapes).Add(autoShape2);
		autoShape2.method_26();
		AutoShape autoShape3 = new AutoShape(notes);
		autoShape3.AlternativeText = "";
		autoShape3.Name = "Slide Number Placeholder 3";
		autoShape3.method_0(Orientation.Horizontal, PlaceholderSize.Quarter, PlaceholderType.SlideNumber, 10u, hasCustomPrompt: false);
		autoShape3.ShapeLock.GroupingLocked = true;
		autoShape3.AddTextFrame("");
		autoShape3.TextFrame.Paragraphs.Clear();
		Paragraph paragraph = new Paragraph();
		Portion portion = new Portion();
		portion.AddField("slidenum");
		((Field)portion.Field).Guid = new Guid("6101C5E1-D8E9-464D-A93E-CE21651935A7");
		portion.PortionFormat.LanguageId = "en-US";
		portion.PortionFormat.SmartTagClean = false;
		portion.TextInternal = "1";
		paragraph.Portions.Add(portion);
		Portion portion2 = new Portion();
		portion2.PortionFormat.LanguageId = "en-US";
		paragraph.Portions.Add(portion2);
		autoShape3.TextFrame.Paragraphs.Add(paragraph);
		((ShapeCollection)notes.groupShape_0.Shapes).Add(autoShape3);
		autoShape3.method_26();
	}
}
