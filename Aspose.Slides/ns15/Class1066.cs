using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Aspose.Slides;
using ns18;
using ns22;
using ns24;
using ns276;
using ns4;
using ns60;
using ns62;
using ns63;

namespace ns15;

internal class Class1066
{
	private class Class1067
	{
		internal Hyperlink hyperlink_0;

		internal int int_0;

		internal int int_1;
	}

	private class Class1068
	{
		private struct Struct55
		{
			internal int int_0;

			internal Class2882 class2882_0;
		}

		private List<Class1069> list_0 = new List<Class1069>();

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		internal bool NoText => list_0.Count == 0;

		internal bool DataNotDepleted => int_1 > 0;

		internal Class1068(string sourceText)
		{
			int length = sourceText.Length;
			if (length < 1)
			{
				Class1069 item = new Class1069
				{
					string_0 = string.Concat('\r')
				};
				list_0 = new List<Class1069> { item };
				return;
			}
			list_0 = new List<Class1069>();
			char[] anyOf = new char[1] { '\r' };
			int num = 0;
			int num2 = 0;
			while (num2 < length)
			{
				int num3 = sourceText.IndexOfAny(anyOf, num2);
				Class1069 @class;
				if (num3 < 0)
				{
					if (num2 < length)
					{
						@class = new Class1069();
						list_0.Add(@class);
						@class.string_0 = sourceText.Substring(num2, length - num2);
						@class.int_0 = num;
						num2 = length;
					}
					continue;
				}
				if (num3 > num2)
				{
					@class = new Class1069();
					list_0.Add(@class);
					@class.string_0 = sourceText.Substring(num2, num3 - num2);
					@class.int_0 = num;
				}
				@class = new Class1069();
				list_0.Add(@class);
				@class.string_0 = string.Concat('\r');
				@class.int_0 = num++;
				num2 = num3 + 1;
			}
			if (!NoText)
			{
				Class1069 @class = new Class1069();
				list_0.Add(@class);
				@class.string_0 = string.Concat('\r');
				@class.int_0 = num++;
			}
		}

		internal void method_0()
		{
			method_1(0);
			int_1 = 0;
			int_4 = 0;
		}

		private void method_1(int portionIndex)
		{
			if (portionIndex >= 0 && portionIndex < list_0.Count)
			{
				int_0 = portionIndex;
				int_3 = list_0[int_0].string_0.Length;
				int_2 = 0;
			}
		}

		internal void method_2(int runLength)
		{
			if (DataNotDepleted)
			{
				throw new PptException("The previous run isn't depleted!");
			}
			int_1 = runLength;
		}

		internal Class1069 method_3()
		{
			Class1069 @class;
			do
			{
				if (int_1 > 0)
				{
					@class = null;
					int num = int_3 - int_2;
					if (int_1 >= num)
					{
						int_4 += num;
						int_1 -= num;
						@class = list_0[int_0];
						method_1(int_0 + 1);
					}
					else
					{
						int_4 += int_1;
						int_2 += int_1;
						int_1 = 0;
						Class1069 item = new Class1069(list_0[int_0], int_2);
						@class = list_0[int_0];
						list_0.Insert(++int_0, item);
						method_1(int_0);
					}
					continue;
				}
				return null;
			}
			while (@class == null);
			return @class;
		}

		internal void method_4(Class2856 styleTextPropAtom)
		{
			method_0();
			Class2984[] rgTextPFRun = styleTextPropAtom.RgTextPFRun;
			foreach (Class2984 @class in rgTextPFRun)
			{
				method_2((int)@class.Count);
				while (DataNotDepleted)
				{
					Class1069 class2 = method_3();
					if (class2 != null)
					{
						class2.short_0 = (short)@class.IndentLevel;
						class2.class2974_0 = @class.ParagraphFormat;
					}
				}
			}
			method_0();
			Class2983[] rgTextCFRun = styleTextPropAtom.RgTextCFRun;
			foreach (Class2983 class3 in rgTextCFRun)
			{
				method_2((int)class3.Count);
				while (DataNotDepleted)
				{
					Class1069 class4 = method_3();
					if (class4 != null)
					{
						class4.class2971_0 = class3.CharFormat;
					}
				}
			}
		}

		internal void method_5(Class2853 masterTextPropAtom)
		{
			method_0();
			foreach (Class2961 item in masterTextPropAtom.RgMasterTextPropRun)
			{
				method_2((int)item.Count);
				while (DataNotDepleted)
				{
					Class1069 @class = method_3();
					if (@class != null)
					{
						@class.short_0 = (short)item.IndentLevel;
					}
				}
			}
		}

		internal void method_6(Class2861 textSpecialInfoAtom)
		{
			method_0();
			Class2986[] rgTextSIRun = textSpecialInfoAtom.RgTextSIRun;
			foreach (Class2986 @class in rgTextSIRun)
			{
				method_2((int)@class.Count);
				while (DataNotDepleted)
				{
					Class1069 class2 = method_3();
					if (class2 != null)
					{
						class2.class2977_0 = @class.SpecialInfo;
					}
				}
			}
		}

		public void method_7(List<Class2846> textMCAtoms)
		{
			foreach (Class2846 textMCAtom in textMCAtoms)
			{
				if (textMCAtom is Class2852)
				{
					method_0();
					Class2852 @class = (Class2852)textMCAtom;
					if (@class.Position > 0)
					{
						method_2(@class.Position);
						while (DataNotDepleted)
						{
							method_3();
						}
					}
					method_2(1);
					Class1069 class2 = method_3();
					if (class2 != null)
					{
						class2.int_1 = 20;
					}
					continue;
				}
				if (textMCAtom is Class2847)
				{
					method_0();
					Class2847 class3 = (Class2847)textMCAtom;
					if (class3.Position > 0)
					{
						method_2(class3.Position);
						while (DataNotDepleted)
						{
							method_3();
						}
					}
					method_2(1);
					Class1069 class4 = method_3();
					if (class4 != null)
					{
						class4.int_1 = class3.Index;
					}
				}
				if (!(textMCAtom is Class2848))
				{
					continue;
				}
				method_0();
				Class2848 class5 = (Class2848)textMCAtom;
				if (class5.Position > 0)
				{
					method_2(class5.Position);
					while (DataNotDepleted)
					{
						method_3();
					}
				}
				method_2(1);
				Class1069 class6 = method_3();
				if (class6 != null)
				{
					class6.int_1 = 21;
				}
			}
		}

		internal void method_8(List<Interface45> interactiveInfoList, Class857 pptDeserializationContext)
		{
			if (interactiveInfoList == null || interactiveInfoList.Count < 1)
			{
				return;
			}
			SortedList<int, Struct55> sortedList = new SortedList<int, Struct55>();
			Class2882 @class = null;
			bool flag = false;
			for (int i = 0; i < interactiveInfoList.Count; i++)
			{
				if (interactiveInfoList[i] is Class2711)
				{
					@class = ((Class2711)interactiveInfoList[i]).InteractiveInfoAtom;
					if (@class != null && @class.ExHyperlinkIdRef != 0)
					{
						flag = true;
					}
				}
				else if (interactiveInfoList[i] is Class2862 && flag)
				{
					flag = false;
					Class2862 class2 = (Class2862)interactiveInfoList[i];
					int num = class2.End - class2.Begin;
					if (num > 0)
					{
						Struct55 value = default(Struct55);
						value.int_0 = num;
						value.class2882_0 = @class;
						sortedList.Add(class2.Begin, value);
					}
				}
			}
			if (sortedList.Count <= 0)
			{
				return;
			}
			method_0();
			foreach (KeyValuePair<int, Struct55> item in sortedList)
			{
				if (int_4 < item.Key)
				{
					method_2(item.Key - int_4);
				}
				while (DataNotDepleted)
				{
					method_3();
				}
				method_2(item.Value.int_0);
				Hyperlink hyperlink_ = Class1054.smethod_0(item.Value.class2882_0, pptDeserializationContext);
				while (DataNotDepleted)
				{
					Class1069 class3 = method_3();
					if (class3 != null)
					{
						class3.hyperlink_0 = hyperlink_;
					}
				}
			}
		}

		internal void method_9(TextFrame targetFrame, Class2898 styleTextProp9Atom, ParagraphFormat defaultPF, Class854 slidePptDeserializationContext)
		{
			Dictionary<int, PPImage> pictureBulletIdToPPImage = slidePptDeserializationContext.DeserializationContext.PictureBulletIdToPPImage;
			IParagraphCollection paragraphs = targetFrame.Paragraphs;
			paragraphs.Clear();
			if (NoText)
			{
				return;
			}
			int count = list_0.Count;
			list_0[count - 1].string_0 = list_0[count - 1].string_0.Remove(list_0[count - 1].string_0.Length - 1);
			int num = -1;
			Paragraph paragraph = null;
			Class2974 @class = null;
			Class2971 class2 = null;
			Class2977 class3 = null;
			ParagraphFormat paragraphFormat = null;
			PortionFormat portionFormat = null;
			bool flag = false;
			for (int i = 0; i < count; i++)
			{
				Class1069 class4 = list_0[i];
				ParagraphFormat paragraphFormat2 = null;
				if (targetFrame.textFrameFormat_0.textStyle_0 != null)
				{
					paragraphFormat2 = (ParagraphFormat)targetFrame.textFrameFormat_0.textStyle_0.GetLevel(class4.short_0);
				}
				if (class4.string_0.Length == 1 && class4.string_0[0] == '\r')
				{
					class4.string_0 = "";
				}
				if (@class != class4.class2974_0)
				{
					@class = class4.class2974_0;
					if (@class != null)
					{
						paragraphFormat = new ParagraphFormat(defaultPF, targetFrame);
						Class862.smethod_0(@class, paragraphFormat, Class53.smethod_3(slidePptDeserializationContext));
						((IParagraphFormat)paragraphFormat).Depth = class4.short_0;
					}
					else
					{
						paragraphFormat = null;
					}
				}
				if (class2 != class4.class2971_0)
				{
					class2 = class4.class2971_0;
					if (class2 != null)
					{
						portionFormat = new PortionFormat(paragraphFormat);
						Class862.smethod_2(class2, portionFormat, Class53.smethod_3(slidePptDeserializationContext));
						bool flag2 = false;
						byte pp9rt = 0;
						if (styleTextProp9Atom != null)
						{
							flag2 = true;
						}
						if (flag2 && paragraphFormat2 != null && paragraphFormat2.bulletFormat_0.PPTUnsupportedProps.BulletSchemeIndex.HasValue)
						{
							pp9rt = paragraphFormat2.bulletFormat_0.PPTUnsupportedProps.BulletSchemeIndex.Value;
						}
						if (class2.PP9RT.HasValue)
						{
							flag2 = true;
							pp9rt = class2.PP9RT.Value;
						}
						if (flag2)
						{
							smethod_5(paragraphFormat, pp9rt, styleTextProp9Atom, pictureBulletIdToPPImage);
						}
					}
					else
					{
						portionFormat = null;
					}
				}
				if (class3 != class4.class2977_0)
				{
					class3 = class4.class2977_0;
				}
				if (num != class4.int_0)
				{
					flag = false;
					num = class4.int_0;
					paragraph = new Paragraph();
					paragraphs.Add(paragraph);
					paragraph.Portions.Clear();
				}
				if (!flag)
				{
					if (paragraphFormat != null)
					{
						((ParagraphFormat)paragraph.ParagraphFormat).method_0(paragraphFormat);
						flag = true;
					}
					paragraph.ParagraphFormat.Depth = class4.short_0;
				}
				Portion portion = new Portion(class4.string_0);
				paragraph.Portions.Add(portion);
				if (portionFormat != null)
				{
					((PortionFormat)portion.PortionFormat).vmethod_1(portionFormat);
				}
				if (class4.int_1 != -1)
				{
					switch (class4.int_1)
					{
					case 20:
						portion.AddField(FieldType.SlideNumber);
						break;
					case 21:
						portion.AddField(FieldType.Footer);
						break;
					case -16:
						portion.AddField(Class232.smethod_28(class4.int_1));
						break;
					}
				}
				if (class4.hyperlink_0 != null)
				{
					portion.PortionFormat.HyperlinkClick = class4.hyperlink_0;
				}
			}
		}
	}

	private class Class1069
	{
		internal string string_0 = "";

		internal int int_0;

		internal short short_0;

		internal Class2974 class2974_0;

		internal Class2971 class2971_0;

		internal Class2977 class2977_0;

		internal Hyperlink hyperlink_0;

		internal int int_1 = -1;

		internal Class1069()
		{
		}

		internal Class1069(Class1069 sourcePortion, int textSplitIndex)
		{
			if (textSplitIndex < 1)
			{
				throw new ArgumentOutOfRangeException("textSplitIndex", "Start index for split the text too small!");
			}
			if (textSplitIndex + 1 > sourcePortion.string_0.Length)
			{
				throw new ArgumentOutOfRangeException("textSplitIndex", "Invalid start index for split the text (" + sourcePortion.string_0.Length + " by " + textSplitIndex + ")!");
			}
			string_0 = sourcePortion.string_0.Substring(textSplitIndex);
			sourcePortion.string_0 = sourcePortion.string_0.Substring(0, textSplitIndex);
			int_0 = sourcePortion.int_0;
			short_0 = sourcePortion.short_0;
			class2974_0 = sourcePortion.class2974_0;
			class2971_0 = sourcePortion.class2971_0;
			class2977_0 = sourcePortion.class2977_0;
			hyperlink_0 = sourcePortion.hyperlink_0;
		}
	}

	internal static TextFrame smethod_0(AutoShape parent, Class2670 shapeContainer, Class854 slideDeserializationContext)
	{
		Class2642 clientTextBox = shapeContainer.ClientTextBox;
		if (clientTextBox != null && clientTextBox.Header.IsContainer)
		{
			return smethod_1(parent, shapeContainer, slideDeserializationContext);
		}
		if (shapeContainer.ShapePrimaryOptions != null && shapeContainer.ShapePrimaryOptions.Properties.Contains(Enum426.const_426))
		{
			Class2914 @class = shapeContainer.ShapePrimaryOptions.Properties[Enum426.const_426] as Class2914;
			if (@class.RfGtext)
			{
				return smethod_3(parent, shapeContainer, slideDeserializationContext);
			}
		}
		return null;
	}

	internal static TextFrame smethod_1(ISlideComponent parent, Class2670 shapeContainer, Class854 slideDeserializationContext)
	{
		TextFrame textFrame = new TextFrame(parent);
		if (shapeContainer != null && shapeContainer.ClientTextBox != null && shapeContainer.ClientTextBox.ContentRecords != null)
		{
			bool isPlaceholder = false;
			Class2642 clientTextBox = shapeContainer.ClientTextBox;
			Class2951 contentRecords = clientTextBox.ContentRecords;
			Class2641 clientData = shapeContainer.ClientData;
			List<Class2623> list = new List<Class2623>();
			if (clientData != null)
			{
				Class2729 progTags = clientData.ProgTags;
				if (progTags != null && progTags.PP9ShapeBinaryTagExtension != null)
				{
					list.Add(progTags.PP9ShapeBinaryTagExtension.StyleTextProp9Atom);
				}
				isPlaceholder = clientData.PlaceholderAtom != null;
			}
			smethod_7(textFrame, clientTextBox.ContentRecords, list, slideDeserializationContext, isPlaceholder);
			smethod_8(textFrame, shapeContainer, slideDeserializationContext);
			Class272 pPTUnsupportedProps = textFrame.textFrameFormat_0.PPTUnsupportedProps;
			if (contentRecords.HaveTextBookmarks)
			{
				pPTUnsupportedProps.OfficeArtClientTextbox_TextBookmarkAtoms = contentRecords.TextBookmarks.ToArray();
			}
			return textFrame;
		}
		return textFrame;
	}

	internal static TextFrame smethod_2(AutoShape parent, Class2670 shapeContainer, Class852 phDeserializationContext, Class854 slideDeserializationContext)
	{
		TextFrame textFrame = new TextFrame(parent);
		Class2951 @class = null;
		if (shapeContainer.ClientTextBox != null)
		{
			@class = shapeContainer.ClientTextBox.ContentRecords;
		}
		List<Class2623> list = new List<Class2623>();
		if (@class != null && @class.HaveTextRuler)
		{
			list.Add(@class.TextRuler);
		}
		Class2730 progTags = slideDeserializationContext.DeserializationContext.DocumentContainer.DocInfoList.ProgTags;
		if (progTags != null)
		{
			Class2702 class2 = null;
			Class2683 pP9DocBinaryTagExtension = progTags.PP9DocBinaryTagExtension;
			if (pP9DocBinaryTagExtension != null)
			{
				class2 = pP9DocBinaryTagExtension.OutlineTextPropsContainer;
			}
			if (class2 != null)
			{
				Class2898 class3 = class2.method_5(((BaseSlide)parent.Slide).BaseSlidePPTUnsupportedProps.SlideId, (short)(phDeserializationContext.uint_0 << 4));
				if (class3 != null)
				{
					list.Add(class3);
				}
			}
		}
		smethod_7(textFrame, phDeserializationContext.class2951_0, list, slideDeserializationContext, isPlaceholder: true);
		smethod_8(textFrame, shapeContainer, slideDeserializationContext);
		Class272 pPTUnsupportedProps = textFrame.textFrameFormat_0.PPTUnsupportedProps;
		if (@class != null && @class.HaveTextBookmarks)
		{
			pPTUnsupportedProps.OfficeArtClientTextbox_TextBookmarkAtoms = @class.TextBookmarks.ToArray();
		}
		return textFrame;
	}

	private static TextFrame smethod_3(AutoShape parent, Class2670 shapeContainer, Class854 slideDeserializationContext)
	{
		TextFrame textFrame = new TextFrame(parent, isGeometryText: true);
		smethod_8(textFrame, shapeContainer, slideDeserializationContext);
		Class356 pPTXUnsupportedProps = textFrame.textFrameFormat_0.PPTXUnsupportedProps;
		textFrame.Paragraphs.Clear();
		Class2944 properties = shapeContainer.ShapePrimaryOptions.Properties;
		if (!(properties[Enum426.const_420] is Class2931 @class))
		{
			throw new InvalidOperationException();
		}
		if (shapeContainer.ShapeProp.ShapeType == Enum425.const_136)
		{
			pPTXUnsupportedProps.TextShape.TextShapeType = TextShapeType.Plain;
		}
		string text = Class1036.smethod_8(@class.Value);
		ParagraphCollection paragraphCollection = (ParagraphCollection)textFrame.Paragraphs;
		if (text.IndexOfAny(Class970.char_0) < 0)
		{
			IParagraph paragraph = paragraphCollection.Add();
			CreatePortion((PortionCollection)paragraph.Portions, (ParagraphFormat)paragraph.ParagraphFormat, shapeContainer, slideDeserializationContext, text);
		}
		else
		{
			int startIndex = 0;
			string text2 = null;
			while ((text2 = Class970.smethod_2(text, ref startIndex)) != null)
			{
				IParagraph paragraph2 = paragraphCollection.Add();
				paragraph2.ParagraphFormat.Alignment = TextAlignment.Center;
				CreatePortion((PortionCollection)paragraph2.Portions, (ParagraphFormat)paragraph2.ParagraphFormat, shapeContainer, slideDeserializationContext, text2);
			}
		}
		smethod_4(textFrame, shapeContainer, slideDeserializationContext);
		return textFrame;
	}

	private static void smethod_4(TextFrame textFrame, Class2670 shapeContainer, Class854 slideDeserializationContext)
	{
		Class356 pPTXUnsupportedProps = textFrame.textFrameFormat_0.PPTXUnsupportedProps;
		if (textFrame.IsGeometryText)
		{
			pPTXUnsupportedProps.FromWordArt = NullableBool.True;
		}
		Class520 textShape = pPTXUnsupportedProps.TextShape;
		Class208.smethod_0(textShape, shapeContainer);
		if (textFrame.IsGeometryText)
		{
			textShape.class341_0 = Class205.smethod_0(textShape, shapeContainer, out textShape.dictionary_0);
		}
	}

	private static void CreatePortion(PortionCollection portions, ParagraphFormat format, Class2670 shapeContainer, Class854 slideDeserializationContext, string text)
	{
		IPortion portion = portions.Add();
		portion.Text = text;
		format.PPTXUnsupportedProps.SoftParagraph = true;
		Class207.smethod_0(portion.PortionFormat, shapeContainer, slideDeserializationContext);
	}

	private static void smethod_5(IParagraphFormat paragraphFormat, byte pp9rt, Class2898 styleTextProp9Atom, Dictionary<int, PPImage> bulletPicture)
	{
		if (styleTextProp9Atom == null || pp9rt >= styleTextProp9Atom.RgStyleTextProp9.Count)
		{
			return;
		}
		Class2968 @class = styleTextProp9Atom.RgStyleTextProp9[pp9rt];
		if (!@class.ParagraphFormat9.IsEmpty)
		{
			if (@class.ParagraphFormat9.BulletBlipRef.HasValue && (ushort)@class.ParagraphFormat9.BulletBlipRef.Value != ushort.MaxValue && bulletPicture.ContainsKey(@class.ParagraphFormat9.BulletBlipRef.Value))
			{
				((BulletFormat)paragraphFormat.Bullet).Picture.Image = bulletPicture[@class.ParagraphFormat9.BulletBlipRef.Value];
				paragraphFormat.Bullet.Type = BulletType.Picture;
			}
			if (@class.ParagraphFormat9.BulletHasScheme == NullableBool.True)
			{
				paragraphFormat.Bullet.Type = BulletType.Numbered;
				paragraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletArabicPeriod;
				paragraphFormat.Bullet.NumberedBulletStartWith = 1;
			}
			if (@class.ParagraphFormat9.BulletAutoNumberScheme != null)
			{
				paragraphFormat.Bullet.NumberedBulletStyle = (NumberedBulletStyle)@class.ParagraphFormat9.BulletAutoNumberScheme.Scheme;
				paragraphFormat.Bullet.NumberedBulletStartWith = @class.ParagraphFormat9.BulletAutoNumberScheme.StartNum;
				paragraphFormat.Bullet.Type = BulletType.Numbered;
			}
		}
	}

	private static void smethod_6(TextFrame targetFrame, Class2981 textRuler)
	{
		IParagraphCollection paragraphs = targetFrame.Paragraphs;
		IParagraphFormat[] array = new ParagraphFormat[5];
		for (int i = 0; i < 5; i++)
		{
			array[i] = targetFrame.TextFrameFormat.TextStyle.GetLevel(i);
		}
		TabCollection tabCollection = null;
		if (textRuler.TabStops != null)
		{
			tabCollection = new TabCollection();
			for (int j = 0; j < textRuler.TabStops.Count; j++)
			{
				double position = (double)textRuler.TabStops[j].Position / 8.0;
				TabAlignment align = Class862.smethod_13(textRuler.TabStops[j].TabType);
				tabCollection.Add(position, align);
			}
		}
		foreach (Paragraph item in paragraphs)
		{
			ParagraphFormat paragraphFormat = (ParagraphFormat)item.ParagraphFormat;
			short depth = item.ParagraphFormat.Depth;
			if (textRuler.DefaultTabSize.HasValue)
			{
				paragraphFormat.double_3 = Class862.smethod_17(textRuler.DefaultTabSize.Value);
			}
			if (tabCollection != null)
			{
				((TabCollection)paragraphFormat.Tabs).method_2(tabCollection);
			}
			Class2975 @class = textRuler.method_1(depth);
			if (@class == null)
			{
				continue;
			}
			Class862.Class863 class2 = new Class862.Class863();
			class2.nullable_0 = @class.LeftMargin;
			class2.nullable_1 = @class.Indent;
			if ((!class2.nullable_0.HasValue || !class2.nullable_1.HasValue) && array[depth] != null)
			{
				Class862.Class863 class3 = new Class862.Class863();
				class3.float_0 = array[depth].MarginLeft;
				class3.float_1 = array[depth].Indent;
				Class862.smethod_20(class3);
				if (!class2.nullable_0.HasValue)
				{
					class2.nullable_0 = class3.nullable_0;
				}
				if (!class2.nullable_1.HasValue)
				{
					class2.nullable_1 = class3.nullable_1;
				}
			}
			Class862.smethod_19(class2);
			paragraphFormat.double_0 = class2.float_0;
			paragraphFormat.double_2 = class2.float_1;
		}
	}

	private static void smethod_7(TextFrame targetFrame, Class2951 subTextFrame, List<Class2623> additionalRecords, Class854 slidePptDeserializationContext, bool isPlaceholder)
	{
		Class857 deserializationContext = slidePptDeserializationContext.DeserializationContext;
		if (subTextFrame == null)
		{
			return;
		}
		if (subTextFrame.HaveTextHeader)
		{
			((TextFrameFormat)targetFrame.TextFrameFormat).PPTUnsupportedProps.PptTextType = subTextFrame.TextHeader.TextType;
			bool flag = isPlaceholder || subTextFrame.HaveMetaCharRecords;
			switch (subTextFrame.TextHeader.TextType)
			{
			case Enum449.const_0:
			case Enum449.const_1:
				flag = true;
				break;
			}
			if (flag)
			{
				uint masterIdRef = slidePptDeserializationContext.SlideAtom.MasterIdRef;
				TextStyle textStyle = null;
				if (masterIdRef != 0)
				{
					if (slidePptDeserializationContext.DeserializationContext.SlideIdToMasterOrLayoutSlide.ContainsKey(masterIdRef))
					{
						Class854 @class = slidePptDeserializationContext.DeserializationContext.method_2(masterIdRef);
						if (@class != null && @class.TxMasterStyles != null && @class.TxMasterStyles.ContainsKey((int)subTextFrame.TextHeader.TextType))
						{
							textStyle = @class.TxMasterStyles[(int)subTextFrame.TextHeader.TextType];
						}
					}
				}
				else if (slidePptDeserializationContext.TxMasterStyles.ContainsKey((int)subTextFrame.TextHeader.TextType))
				{
					textStyle = slidePptDeserializationContext.TxMasterStyles[(int)subTextFrame.TextHeader.TextType];
				}
				if (textStyle != null)
				{
					targetFrame.textFrameFormat_0.textStyle_0 = textStyle;
				}
			}
			else
			{
				Class2894 class2 = deserializationContext.PptDefaultTextMasterStyleList[(int)subTextFrame.TextHeader.TextType];
				if (class2 != null)
				{
					TextStyle textStyle2 = targetFrame.textFrameFormat_0.textStyle_0;
					if (textStyle2 == null)
					{
						textStyle2 = new TextStyle(targetFrame);
						targetFrame.textFrameFormat_0.textStyle_0 = textStyle2;
					}
					Class1070.smethod_2(textStyle2, class2, deserializationContext);
				}
			}
		}
		Class1068 class3 = (subTextFrame.HaveTextData ? new Class1068(subTextFrame.ChildText) : new Class1068(string.Empty));
		if (subTextFrame.HaveStyleTextProp)
		{
			class3.method_4(subTextFrame.StyleTextProp);
		}
		if (subTextFrame.HaveMasterTextProp)
		{
			class3.method_5(subTextFrame.MasterTextProp);
		}
		if (subTextFrame.HaveTextSpecialInfo)
		{
			class3.method_6(subTextFrame.TextSpecialInfo);
		}
		if (subTextFrame.HaveMetaCharRecords)
		{
			class3.method_7(subTextFrame.TextMCAtoms);
		}
		if (subTextFrame.HaveInteractiveInfo)
		{
			class3.method_8(subTextFrame.InteractiveInfoList, deserializationContext);
		}
		Class2898 styleTextProp9Atom = null;
		for (int i = 0; i < additionalRecords.Count; i++)
		{
			switch (additionalRecords[i].Header.Type)
			{
			case 4012:
				styleTextProp9Atom = (Class2898)additionalRecords[i];
				break;
			case 4006:
				Class1070.smethod_0(targetFrame.textFrameFormat_0.textStyle_0, ((Class2860)additionalRecords[i]).TextRuler);
				break;
			}
		}
		class3.method_9(targetFrame, styleTextProp9Atom, new ParagraphFormat(null), slidePptDeserializationContext);
		if (subTextFrame.HaveTextRuler)
		{
			smethod_6(targetFrame, subTextFrame.TextRuler.TextRuler);
		}
	}

	internal static void smethod_8(TextFrame targetFrame, Class2670 shapeContainer, Class854 slideDeserializationContext)
	{
		if (targetFrame == null)
		{
			throw new NullReferenceException("Target TextFrame not found!");
		}
		Class2834 shapePrimaryOptions = shapeContainer.ShapePrimaryOptions;
		if (shapePrimaryOptions == null)
		{
			return;
		}
		TextFrameFormat textFrameFormat_ = targetFrame.textFrameFormat_0;
		Class2911 @class = (Class2911)shapePrimaryOptions.Properties[Enum426.const_406];
		if (@class != null)
		{
			textFrameFormat_.double_0 = (double)@class.Value / 12700.0;
		}
		else
		{
			textFrameFormat_.double_0 = double.NaN;
		}
		@class = (Class2911)shapePrimaryOptions.Properties[Enum426.const_407];
		if (@class != null)
		{
			textFrameFormat_.double_2 = (double)@class.Value / 12700.0;
		}
		else
		{
			textFrameFormat_.double_2 = double.NaN;
		}
		@class = (Class2911)shapePrimaryOptions.Properties[Enum426.const_408];
		if (@class != null)
		{
			textFrameFormat_.double_1 = (double)@class.Value / 12700.0;
		}
		else
		{
			textFrameFormat_.double_1 = double.NaN;
		}
		@class = (Class2911)shapePrimaryOptions.Properties[Enum426.const_409];
		if (@class != null)
		{
			textFrameFormat_.double_3 = (double)@class.Value / 12700.0;
		}
		else
		{
			textFrameFormat_.double_3 = double.NaN;
		}
		@class = (Class2911)shapePrimaryOptions.Properties[Enum426.const_410];
		if (@class != null)
		{
			textFrameFormat_.PPTXUnsupportedProps.Wrap = ((@class.Value != 2) ? NullableBool.True : NullableBool.False);
		}
		else
		{
			textFrameFormat_.PPTXUnsupportedProps.Wrap = NullableBool.NotDefined;
		}
		@class = (Class2911)shapePrimaryOptions.Properties[Enum426.const_412];
		if (@class != null)
		{
			textFrameFormat_.AnchoringType = Class232.smethod_21((Enum391)@class.Value);
			textFrameFormat_.CenterText = Class232.smethod_22((Enum391)@class.Value);
		}
		else
		{
			Class2911 class2 = (Class2911)shapePrimaryOptions.Properties[Enum426.const_0];
			if (class2 != null && slideDeserializationContext.DeserializationContext.ShapeIdToFrame.ContainsKey(class2.Value))
			{
				Class2670 class3 = slideDeserializationContext.DeserializationContext.ShapeIdToFrame[class2.Value] as Class2670;
				@class = (Class2911)class3.ShapePrimaryOptions.Properties[Enum426.const_412];
				if (@class != null)
				{
					textFrameFormat_.AnchoringType = Class232.smethod_21((Enum391)@class.Value);
					textFrameFormat_.CenterText = Class232.smethod_22((Enum391)@class.Value);
				}
				else
				{
					textFrameFormat_.AnchoringType = TextAnchorType.NotDefined;
					textFrameFormat_.CenterText = NullableBool.NotDefined;
				}
			}
			else
			{
				textFrameFormat_.AnchoringType = TextAnchorType.NotDefined;
				textFrameFormat_.CenterText = NullableBool.NotDefined;
			}
		}
		@class = (Class2911)shapePrimaryOptions.Properties[Enum426.const_413];
		if (@class != null)
		{
			textFrameFormat_.textVerticalType_0 = Class232.smethod_26(@class.Value);
		}
		else
		{
			textFrameFormat_.textVerticalType_0 = TextVerticalType.NotDefined;
		}
		@class = (Class2911)shapePrimaryOptions.Properties[Enum426.const_414];
		if (@class != null)
		{
			textFrameFormat_.RotationAngle = @class.Value % 4u * 90;
		}
		else
		{
			textFrameFormat_.RotationAngle = float.NaN;
		}
		@class = (Class2911)shapePrimaryOptions.Properties[Enum426.const_419];
		if (@class != null && (@class.Value & 0x20000u) != 0)
		{
			textFrameFormat_.AutofitTypeInternal = (((@class.Value & 2) == 2) ? TextAutofitType.Shape : TextAutofitType.None);
		}
		else
		{
			textFrameFormat_.AutofitTypeInternal = TextAutofitType.NotDefined;
		}
		if (!(targetFrame.islideComponent_0.Slide is ISlide))
		{
			return;
		}
		Class2837 shapeTertiaryOptions = shapeContainer.ShapeTertiaryOptions;
		if (shapeTertiaryOptions == null || shapeTertiaryOptions.Properties[Enum426.const_48] == null)
		{
			return;
		}
		Class2935 class4 = (Class2935)shapeTertiaryOptions.Properties[Enum426.const_48];
		Class6752 class5 = Class6752.Read(new MemoryStream(class4.Value));
		Class6751 class6 = class5["drs/shapexml.xml"];
		if (class6 == null)
		{
			return;
		}
		using MemoryStream memoryStream = new MemoryStream();
		class6.method_8(memoryStream);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(memoryStream);
		XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
		xmlNamespaceManager.AddNamespace("p", "http://schemas.openxmlformats.org/presentationml/2006/main");
		xmlNamespaceManager.AddNamespace("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
		XmlNodeList xmlNodeList = xmlDocument.SelectNodes("p:sp/p:txBody/a:p/a:pPr", xmlNamespaceManager);
		if (targetFrame.Paragraphs.Count != xmlNodeList.Count)
		{
			return;
		}
		for (int i = 0; i < xmlNodeList.Count; i++)
		{
			XmlNode xmlNode = xmlNodeList[i];
			IParagraphFormat paragraphFormat = targetFrame.Paragraphs[i].ParagraphFormat;
			float num = (float)((double)long.Parse(xmlNode.Attributes["marL"].Value) / 12700.0);
			float num2 = (float)((double)long.Parse(xmlNode.Attributes["marR"].Value) / 12700.0);
			float num3 = (float)((double)long.Parse(xmlNode.Attributes["indent"].Value) / 12700.0);
			if (num != 0f && (paragraphFormat.MarginLeft == 0f || float.IsNaN(paragraphFormat.MarginLeft)))
			{
				paragraphFormat.MarginLeft = num;
			}
			if (num2 != 0f && (paragraphFormat.MarginRight == 0f || float.IsNaN(paragraphFormat.MarginRight)))
			{
				paragraphFormat.MarginRight = num2;
			}
			if (num3 != 0f && (paragraphFormat.Indent == 0f || float.IsNaN(paragraphFormat.Indent)))
			{
				paragraphFormat.Indent = num3;
			}
		}
	}

	private static void smethod_9(Class1067 hyperLinkInstance, Class2982 textSubRecordsList, Class856 pptSerializationContext)
	{
		Class1054.smethod_2(hyperLinkInstance.hyperlink_0, textSubRecordsList, pptSerializationContext);
		Class2862 @class = new Class2862(null);
		@class.Begin = hyperLinkInstance.int_0;
		@class.End = hyperLinkInstance.int_1;
		textSubRecordsList.method_2(@class);
	}

	public static void smethod_10(TextFrame domTextFrame, Class2982 textSubRecordsList, Class856 pptSerializationContext)
	{
		int num = 0;
		Class1067 @class = null;
		foreach (Paragraph paragraph in domTextFrame.Paragraphs)
		{
			foreach (Portion portion in paragraph.Portions)
			{
				PortionFormat portionFormat = (PortionFormat)portion.PortionFormat;
				if (portionFormat.HyperlinkClick != null)
				{
					if (@class != null)
					{
						if (@class.hyperlink_0 != portionFormat.HyperlinkClick)
						{
							@class.int_1 = num;
							smethod_9(@class, textSubRecordsList, pptSerializationContext);
							@class = new Class1067();
							@class.hyperlink_0 = (Hyperlink)portionFormat.HyperlinkClick;
							@class.int_0 = num;
						}
					}
					else
					{
						@class = new Class1067();
						@class.hyperlink_0 = (Hyperlink)portionFormat.HyperlinkClick;
						@class.int_0 = num;
					}
				}
				else if (@class != null)
				{
					@class.int_1 = num;
					smethod_9(@class, textSubRecordsList, pptSerializationContext);
					@class = null;
				}
				num += portion.TextInternal.Length;
			}
			num++;
		}
		if (@class != null)
		{
			@class.int_1 = num;
			smethod_9(@class, textSubRecordsList, pptSerializationContext);
		}
	}

	public static void smethod_11(TextFrame domTextFrame, Class2982 textSubRecordsList, Class201 shapeSerializationContext)
	{
		Class2894 relatedTextMasterStyleAtom = null;
		if (domTextFrame.textFrameFormat_0.textStyle_0 != null && domTextFrame.textFrameFormat_0.textStyle_0.GetLevel(0) != null)
		{
			relatedTextMasterStyleAtom = Class862.smethod_7(domTextFrame.textFrameFormat_0.textStyle_0, shapeSerializationContext.ParentContext);
		}
		shapeSerializationContext.FrameHasBulletSchemes = false;
		int num = 0;
		if (!string.IsNullOrEmpty(domTextFrame.TextInternal))
		{
			foreach (Paragraph paragraph3 in domTextFrame.Paragraphs)
			{
				foreach (Portion portion3 in paragraph3.Portions)
				{
					if (portion3.IsField)
					{
						FieldType fieldType = (FieldType)portion3.Field.Type;
						Class2846 @class = null;
						if (fieldType.InternalString.Equals(FieldType.SlideNumber.InternalString))
						{
							@class = new Class2852(null);
							portion3.TextInternal = "*";
						}
						else if (fieldType.InternalString.Contains(FieldType.DateTime.InternalString))
						{
							@class = new Class2847(null);
							((Class2847)@class).Index = Class232.smethod_29(fieldType.InternalString);
							portion3.TextInternal = "*";
						}
						if (@class != null)
						{
							@class.Position = num;
							textSubRecordsList.method_2(@class);
						}
					}
					num += portion3.TextInternal.Length;
				}
				num++;
			}
			Class2858 class2 = new Class2858(null);
			textSubRecordsList.method_2(class2);
			class2.Text = domTextFrame.TextInternal;
		}
		List<Class2984> list = new List<Class2984>();
		List<Class2983> list2 = new List<Class2983>();
		List<Class2961> list3 = new List<Class2961>();
		num = 0;
		foreach (Paragraph paragraph4 in domTextFrame.Paragraphs)
		{
			Class2984 class3 = new Class2984();
			class3.Count = (uint)(paragraph4.TextInternal.Length + 1);
			class3.IndentLevel = (ushort)paragraph4.ParagraphFormat.Depth;
			Class2961 item = new Class2961(class3.Count, class3.IndentLevel);
			list3.Add(item);
			Class862.smethod_1(paragraph4.ParagraphFormat, class3.ParagraphFormat, shapeSerializationContext.ParentContext);
			Class862.smethod_4(relatedTextMasterStyleAtom, class3.IndentLevel, shapeSerializationContext);
			Class862.smethod_5(class3.ParagraphFormat, shapeSerializationContext);
			list.Add(class3);
			Class2983 class4 = null;
			foreach (Portion portion4 in paragraph4.Portions)
			{
				class4 = new Class2983();
				class4.Count = (uint)portion4.TextInternal.Length;
				Class862.smethod_3(portion4.PortionFormat, class4.CharFormat, shapeSerializationContext.ParentContext);
				smethod_12(paragraph4.ParagraphFormat, class4.CharFormat, shapeSerializationContext);
				Class862.smethod_6(class4.CharFormat, relatedTextMasterStyleAtom, shapeSerializationContext, class3.IndentLevel);
				list2.Add(class4);
				num += portion4.TextInternal.Length;
			}
			if (class4 != null)
			{
				class4.Count++;
			}
			num++;
		}
		if (shapeSerializationContext.ParentContext.PptCurrentMasterOrSlideContainer is Class2718 && shapeSerializationContext.CurrentTextType != Enum449.const_3)
		{
			if (list3.Count > 0)
			{
				Class2853 class5 = new Class2853(null);
				class5.RgMasterTextPropRun = list3;
				if (!class5.IsEmpty)
				{
					textSubRecordsList.method_2(class5);
				}
			}
		}
		else if (list.Count > 0 && list2.Count > 0)
		{
			smethod_14(list, textSubRecordsList);
			Class2856 class6 = new Class2856(null);
			class6.RgTextPFRun = list.ToArray();
			class6.RgTextCFRun = list2.ToArray();
			class6.method_1();
			if (!class6.IsEmpty)
			{
				textSubRecordsList.method_2(class6);
			}
		}
		smethod_13(domTextFrame, textSubRecordsList, shapeSerializationContext.ParentContext);
		smethod_10(domTextFrame, textSubRecordsList, shapeSerializationContext.ParentContext);
	}

	private static void smethod_12(IParagraphFormat domParagraphFormat, Class2971 charFormat, Class201 shapeSerializationContext)
	{
		Class2968 @class = null;
		if (domParagraphFormat.Bullet == null)
		{
			return;
		}
		IBulletFormat bullet = domParagraphFormat.Bullet;
		if (bullet.NumberedBulletStyle == NumberedBulletStyle.NotDefined && !shapeSerializationContext.FrameHasBulletSchemes && (bullet.Type == BulletType.NotDefined || bullet.Type == BulletType.None))
		{
			return;
		}
		switch (bullet.Type)
		{
		case BulletType.Numbered:
			@class = new Class2968();
			@class.ParagraphFormat9.BulletHasScheme = NullableBool.True;
			if (bullet.NumberedBulletStartWith != 1 || bullet.NumberedBulletStyle != NumberedBulletStyle.BulletArabicPeriod)
			{
				@class.ParagraphFormat9.BulletAutoNumberScheme = new Class2979((Enum444)bullet.NumberedBulletStyle, bullet.NumberedBulletStartWith);
			}
			break;
		}
		if (shapeSerializationContext.FrameHasBulletSchemes && @class == null)
		{
			@class = new Class2968();
		}
		if (@class != null)
		{
			shapeSerializationContext.FrameHasBulletSchemes = true;
			Class2641 class2 = shapeSerializationContext.method_4();
			Class2679 class3 = class2.ProgTags.method_8();
			class3.AutoInit = true;
			Class2898 styleTextProp9Atom = class3.StyleTextProp9Atom;
			int num = styleTextProp9Atom.method_1(@class);
			charFormat.PP9RT = (byte)num;
		}
	}

	private static void smethod_13(TextFrame domTextFrame, Class2982 textSubRecordsList, Class856 pptSerializationContext)
	{
		if (domTextFrame.TextInternal != null)
		{
			Class2861 @class = new Class2861(null);
			textSubRecordsList.method_2(@class);
			Class2986 class2 = new Class2986();
			@class.RgTextSIRun = new Class2986[1] { class2 };
			class2.Count = (uint)(domTextFrame.TextInternal.Length + 1);
			Class2977 specialInfo = class2.SpecialInfo;
			specialInfo.Lid = 1036;
			specialInfo.AltLid = 0;
		}
	}

	private static void smethod_14(List<Class2984> textPfRunList, Class2982 textSubRecordsList)
	{
		Class2860 @class = new Class2860(null);
		Class2981 class2 = null;
		bool[] array = new bool[7] { true, true, true, true, true, true, true };
		foreach (Class2984 textPfRun in textPfRunList)
		{
			Class2974 paragraphFormat = textPfRun.ParagraphFormat;
			int indentLevel = textPfRun.IndentLevel;
			if (paragraphFormat.HaveTabAndMargin)
			{
				if (class2 == null)
				{
					class2 = @class.TextRuler;
				}
				if (array[5] && paragraphFormat.DefaultTabSize.HasValue)
				{
					array[5] = false;
					class2.DefaultTabSize = paragraphFormat.DefaultTabSize.Value;
				}
				if (array[6] && paragraphFormat.TabStops != null)
				{
					array[6] = false;
					class2.TabStops = paragraphFormat.TabStops;
				}
				if (array[indentLevel])
				{
					Class2975 class3 = new Class2975();
					class3.LeftMargin = paragraphFormat.LeftMargin;
					class3.Indent = paragraphFormat.Indent;
					if (paragraphFormat.LeftMargin.HasValue || paragraphFormat.Indent.HasValue)
					{
						array[indentLevel] = false;
						class2.method_0(indentLevel, class3);
					}
				}
			}
			paragraphFormat.HaveTabAndMargin = false;
		}
		if (class2 != null)
		{
			textSubRecordsList.method_2(@class);
		}
	}

	internal static void smethod_15(ITextFrameFormat textFrameFormat, Class2834 odrawFopt, Class856 pptSerializationContext)
	{
		Class2911 property = new Class2911(Enum426.const_405, (uint)pptSerializationContext.TextlTxId);
		odrawFopt.Properties.method_0(property);
		if (!double.IsNaN(textFrameFormat.MarginLeft))
		{
			Class2911 property2 = new Class2911(Enum426.const_406, (uint)(textFrameFormat.MarginLeft * 12700.0));
			odrawFopt.Properties.method_0(property2);
		}
		if (!double.IsNaN(textFrameFormat.MarginTop))
		{
			Class2911 property3 = new Class2911(Enum426.const_407, (uint)(textFrameFormat.MarginTop * 12700.0));
			odrawFopt.Properties.method_0(property3);
		}
		if (!double.IsNaN(textFrameFormat.MarginRight))
		{
			Class2911 property4 = new Class2911(Enum426.const_408, (uint)(textFrameFormat.MarginRight * 12700.0));
			odrawFopt.Properties.method_0(property4);
		}
		if (!double.IsNaN(textFrameFormat.MarginBottom))
		{
			Class2911 property5 = new Class2911(Enum426.const_409, (uint)(textFrameFormat.MarginBottom * 12700.0));
			odrawFopt.Properties.method_0(property5);
		}
		if (((TextFrameFormat)textFrameFormat).PPTXUnsupportedProps.Wrap != NullableBool.NotDefined)
		{
			uint value = ((((TextFrameFormat)textFrameFormat).PPTXUnsupportedProps.Wrap != NullableBool.True) ? 2u : 0u);
			Class2911 property6 = new Class2911(Enum426.const_410, value);
			odrawFopt.Properties.method_0(property6);
		}
		if (textFrameFormat.AnchoringType != TextAnchorType.NotDefined || textFrameFormat.CenterText == NullableBool.True)
		{
			Class2911 property7 = new Class2911(Enum426.const_412, (uint)Class232.smethod_23(textFrameFormat.AnchoringType, textFrameFormat.CenterText));
			odrawFopt.Properties.method_0(property7);
		}
		if (textFrameFormat.TextVerticalType != TextVerticalType.NotDefined)
		{
			Class2911 property8 = new Class2911(Enum426.const_413, Class232.smethod_27(textFrameFormat.TextVerticalType));
			odrawFopt.Properties.method_0(property8);
		}
		if (!float.IsNaN(((TextFrameFormat)textFrameFormat).RotationAngle))
		{
			float num = ((TextFrameFormat)textFrameFormat).RotationAngle % 360f;
			if (num < 0f)
			{
				num = 360f - num;
			}
			Class2911 property9 = new Class2911(Enum426.const_414, (uint)(Math.Round(num / 90f) % 4.0));
			odrawFopt.Properties.method_0(property9);
		}
		Class2918 @class = new Class2918();
		if (textFrameFormat.AutofitType == TextAutofitType.Shape)
		{
			@class.DfUsefFitShapeToText = true;
			@class.IfFitShapeToText = true;
		}
		odrawFopt.Properties.method_0(@class);
	}

	public static void smethod_16(TextFrame domTextFrame, Class2859 pptTextHeaderAtom, Class201 shapeSerializationContext)
	{
		Class856 parentContext = shapeSerializationContext.ParentContext;
		Enum449? @enum = null;
		TextStyle textStyle_ = domTextFrame.textFrameFormat_0.textStyle_0;
		if (textStyle_ != null)
		{
			@enum = domTextFrame.textFrameFormat_0.textStyle_0.nullable_0;
		}
		if (!@enum.HasValue)
		{
			@enum = domTextFrame.textFrameFormat_0.PPTUnsupportedProps.PptTextType;
		}
		if (@enum.HasValue)
		{
			pptTextHeaderAtom.TextType = @enum.Value;
		}
		else if (pptTextHeaderAtom.TextType != Enum449.const_3 && !shapeSerializationContext.IsPlaceholder)
		{
			pptTextHeaderAtom.TextType = Enum449.const_3;
		}
		shapeSerializationContext.CurrentTextType = pptTextHeaderAtom.TextType;
		shapeSerializationContext.CurrentTextMasterStyle = null;
		shapeSerializationContext.CurrentTextDefaultStyle = shapeSerializationContext.ParentContext.PptDefaultTextMasterStyleList[(int)pptTextHeaderAtom.TextType];
		shapeSerializationContext.CurrentTextMasterStyle = parentContext.PptCurrentTextMasterStyleList[(int)pptTextHeaderAtom.TextType];
		bool flag = shapeSerializationContext.IsPlaceholder;
		switch (pptTextHeaderAtom.TextType)
		{
		case Enum449.const_0:
		case Enum449.const_1:
			flag = true;
			break;
		}
		if (textStyle_ != null && parentContext.PptCurrentTextMasterStyleList != null && flag)
		{
			Class862.smethod_9(shapeSerializationContext.CurrentTextMasterStyle, domTextFrame.textFrameFormat_0.textStyle_0, parentContext);
		}
	}
}
