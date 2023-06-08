using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Theme;
using ns18;
using ns19;
using ns24;
using ns276;
using ns44;
using ns53;
using ns55;
using ns56;

namespace ns16;

internal class Class1028
{
	private Class1346 class1346_0;

	private bool bool_0;

	public void method_0(IPresentation presentation, Class6752 zipFile, Enum165 outputType, IPptxOptions options)
	{
		if (bool_0)
		{
			throw new Exception("PptxSerializator instance can call WritePresentationToZipFile() method only once.");
		}
		bool_0 = true;
		Class1184 @class = new Class1184();
		class1346_0 = new Class1346(@class, presentation, options);
		Class1250 contentType = method_1(outputType);
		Class1342 class2 = @class.method_4("/ppt/presentation.xml", null, contentType);
		@class.RootRelationships.method_4(class2);
		method_2(presentation, class2);
		method_3(@class, presentation);
		method_4(@class, presentation);
		method_8(@class, presentation);
		method_9(@class, presentation);
		foreach (ISlide slide in presentation.Slides)
		{
			class1346_0.SlideToSlidePartPath.Add(slide, "/ppt/slides/slide" + class1346_0.method_28() + ".xml");
		}
		foreach (IMasterSlide master in presentation.Masters)
		{
			smethod_0(@class, master, writeLinkedLayouts: true, class1346_0);
		}
		smethod_2(@class, presentation, class1346_0);
		smethod_6(@class, presentation, class1346_0);
		foreach (ISlide slide2 in presentation.Slides)
		{
			smethod_3(@class, slide2, class1346_0);
		}
		Class1200 class3 = new Class1200(class2, class1346_0);
		class3.method_6(presentation);
		method_5(@class, presentation);
		method_7(@class, presentation);
		method_6(@class, presentation);
		method_10(@class, presentation, outputType);
		smethod_7(@class, presentation.MasterTheme, class1346_0);
		@class.Presentation.Relationships.method_4(class1346_0.ThemeToThemePart[presentation.MasterTheme]);
		method_11(@class, presentation);
		@class.method_9(zipFile);
	}

	private Class1250 method_1(Enum165 outputType)
	{
		return outputType switch
		{
			Enum165.const_0 => new Class1251(), 
			Enum165.const_1 => new Class1252(), 
			Enum165.const_2 => new Class1255(), 
			Enum165.const_3 => new Class1256(), 
			Enum165.const_4 => new Class1254(), 
			Enum165.const_5 => new Class1253(), 
			_ => throw new Exception(), 
		};
	}

	private void method_2(IPresentation presentation, Class1342 presentationEntry)
	{
		Class350 pPTXUnsupportedProps = ((Presentation)presentation).PPTXUnsupportedProps;
		Class247.Write(presentationEntry, pPTXUnsupportedProps.UnknownParts, pPTXUnsupportedProps.RelsToUnknownParts);
		foreach (Class248 unknownPart in pPTXUnsupportedProps.UnknownParts)
		{
			Class247.smethod_0(class1346_0.Package, unknownPart);
		}
	}

	private void method_3(Class1184 package, IPresentation presentation)
	{
		Class1342 @class = package.method_4("/docProps/core.xml", null, new Class1263());
		Class1213 class2 = new Class1213(@class, class1346_0);
		class2.method_6(presentation.DocumentProperties);
		package.RootRelationships.method_4(@class);
	}

	private void method_4(Class1184 package, IPresentation presentation)
	{
		Class1342 @class = package.method_4("/docProps/app.xml", null, new Class1265());
		Class1215 class2 = new Class1215(@class, class1346_0);
		class2.method_6(presentation.DocumentProperties);
		package.RootRelationships.method_4(@class);
	}

	private void method_5(Class1184 package, IPresentation presentation)
	{
		Class1342 targetPart = ((((Presentation)presentation).PPTXUnsupportedProps.PresPropsPart != null) ? package.method_5("/ppt/presProps.xml", null, new Class1257(), ((Presentation)presentation).PPTXUnsupportedProps.PresPropsPart) : package.method_5("/ppt/presProps.xml", null, new Class1257(), Encoding.UTF8.GetBytes("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\r\n<p:presentationPr xmlns:a=\"http://schemas.openxmlformats.org/drawingml/2006/main\" xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\" xmlns:p=\"http://schemas.openxmlformats.org/presentationml/2006/main\"><p:extLst/></p:presentationPr>")));
		package.Presentation.Relationships.method_4(targetPart);
	}

	private void method_6(Class1184 package, IPresentation presentation)
	{
		if (presentation.DocumentProperties.Count > 0)
		{
			Class1342 @class = package.method_4("/docProps/custom.xml", null, new Class1264());
			package.RootRelationships.method_4(@class);
			Class1214 class2 = new Class1214(@class, class1346_0);
			class2.method_6(presentation.DocumentProperties);
		}
	}

	private void method_7(Class1184 package, IPresentation presentation)
	{
		Class350 pPTXUnsupportedProps = ((Presentation)presentation).PPTXUnsupportedProps;
		if (presentation.ViewProperties.LastView != 0 || presentation.ViewProperties.ShowComments != NullableBool.NotDefined)
		{
			if (pPTXUnsupportedProps.ViewProps == null)
			{
				pPTXUnsupportedProps.ViewProps = new Class367();
				pPTXUnsupportedProps.ViewProps.ViewPropertiesElementData = new Class2321();
			}
			Enum361 lastView = presentation.ViewProperties.LastView switch
			{
				ViewType.NotDefined => Enum361.const_0, 
				ViewType.SlideView => Enum361.const_1, 
				ViewType.SlideMasterView => Enum361.const_2, 
				ViewType.NotesView => Enum361.const_3, 
				ViewType.HandoutView => Enum361.const_4, 
				ViewType.NotesMasterView => Enum361.const_5, 
				ViewType.OutlineView => Enum361.const_6, 
				ViewType.SlideSorterView => Enum361.const_7, 
				ViewType.SlideThumbnailView => Enum361.const_8, 
				_ => Enum361.const_1, 
			};
			pPTXUnsupportedProps.ViewProps.ViewPropertiesElementData.LastView = lastView;
			if (presentation.ViewProperties.ShowComments == NullableBool.True)
			{
				pPTXUnsupportedProps.ViewProps.ViewPropertiesElementData.ShowComments = true;
			}
			else if (presentation.ViewProperties.ShowComments == NullableBool.False)
			{
				pPTXUnsupportedProps.ViewProps.ViewPropertiesElementData.ShowComments = false;
			}
		}
		Class1342 @class;
		if (pPTXUnsupportedProps.ViewProps == null)
		{
			@class = package.method_5("/ppt/viewProps.xml", null, new Class1259(), Encoding.UTF8.GetBytes("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\r\n<p:viewPr xmlns:a=\"http://schemas.openxmlformats.org/drawingml/2006/main\" xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\" xmlns:p=\"http://schemas.openxmlformats.org/presentationml/2006/main\"><p:normalViewPr><p:restoredLeft sz=\"15620\"/><p:restoredTop sz=\"94660\"/></p:normalViewPr><p:slideViewPr><p:cSldViewPr><p:cViewPr varScale=\"1\"><p:scale><a:sx n=\"101\" d=\"100\"/><a:sy n=\"101\" d=\"100\"/></p:scale><p:origin x=\"-558\" y=\"-90\"/></p:cViewPr><p:guideLst><p:guide orient=\"horz\" pos=\"2160\"/><p:guide pos=\"2880\"/></p:guideLst></p:cSldViewPr></p:slideViewPr><p:notesTextViewPr><p:cViewPr><p:scale><a:sx n=\"1\" d=\"1\"/><a:sy n=\"1\" d=\"1\"/></p:scale><p:origin x=\"0\" y=\"0\"/></p:cViewPr></p:notesTextViewPr><p:gridSpacing cx=\"73736200\" cy=\"73736200\"/></p:viewPr>"));
		}
		else
		{
			@class = package.method_4("/ppt/viewProps.xml", null, new Class1259());
			Class1211 class2 = new Class1211(@class, class1346_0);
			class2.method_6(presentation);
		}
		package.Presentation.Relationships.method_4(@class);
	}

	private void method_8(Class1184 package, IPresentation presentation)
	{
		SizeF size = presentation.SlideSize.Size;
		Size imageSize = ((size.Width > size.Height) ? new Size(256, (int)Math.Ceiling(256f * size.Height / size.Width)) : new Size((int)Math.Ceiling(256f * size.Width / size.Height), 256));
		Bitmap bitmap;
		if (presentation.Slides.Count > 0)
		{
			bitmap = presentation.Slides[0].GetThumbnail(imageSize);
		}
		else
		{
			bitmap = new Bitmap(imageSize.Width, imageSize.Height);
			bitmap.SetResolution(96f, 96f);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.FillRectangle(Brushes.White, 0, 0, imageSize.Width, imageSize.Height);
		}
		MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, ImageFormat.Jpeg);
		Class1342 targetPart = package.method_5("/docProps/thumbnail.jpeg", null, new Class1316(), memoryStream.ToArray());
		package.RootRelationships.method_4(targetPart);
	}

	internal static Class1342 smethod_0(Class1184 package, IMasterSlide masterSlide, bool writeLinkedLayouts, Class1346 serializationContext)
	{
		Class1342 @class = package.method_4("/ppt/slideMasters/slideMaster{0}.xml", serializationContext.method_26, new Class1248());
		Class1195 class2 = new Class1195(@class, serializationContext, masterSlide);
		switch (serializationContext.Mode)
		{
		default:
			throw new Exception();
		case Enum167.const_0:
			package.Presentation.Relationships.method_4(@class);
			break;
		case Enum167.const_1:
		case Enum167.const_2:
			break;
		}
		serializationContext.SlideToSlidePartPath.Add(masterSlide, @class.PartPath);
		if (writeLinkedLayouts)
		{
			foreach (ILayoutSlide layoutSlide in masterSlide.LayoutSlides)
			{
				smethod_1(package, layoutSlide, @class, serializationContext);
			}
		}
		class2.method_10(masterSlide, writeLinkedLayouts);
		MasterThemeManager masterThemeManager = (MasterThemeManager)masterSlide.ThemeManager;
		IMasterTheme masterThemeEffective = masterThemeManager.MasterThemeEffective;
		smethod_7(package, masterThemeEffective, serializationContext);
		@class.Relationships.method_4(serializationContext.ThemeToThemePart[masterThemeEffective]);
		return @class;
	}

	internal static Class1342 smethod_1(Class1184 package, ILayoutSlide layout, Class1342 masterSlideEntry, Class1346 serializationContext)
	{
		Class1342 @class = package.method_4("/ppt/slideLayouts/slideLayout{0}.xml", serializationContext.method_23, new Class1247());
		Class1194 class2 = new Class1194(@class, serializationContext, layout);
		class2.method_9(layout);
		serializationContext.SlideToSlidePartPath.Add(layout, @class.PartPath);
		if (masterSlideEntry != null)
		{
			@class.Relationships.method_4(masterSlideEntry);
			masterSlideEntry.Relationships.method_4(@class);
		}
		Class900.smethod_1(layout.ThemeManager, @class.Relationships, serializationContext);
		return @class;
	}

	internal static Class1342 smethod_2(Class1184 package, IPresentation presentation, Class1346 serializationContext)
	{
		IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
		if (masterNotesSlide != null)
		{
			Class1342 @class = package.method_4("/ppt/notesMasters/notesMaster1.xml", null, new Class1245());
			Class1192 class2 = new Class1192(@class, serializationContext, masterNotesSlide);
			class2.method_9(masterNotesSlide);
			switch (serializationContext.Mode)
			{
			default:
				throw new Exception();
			case Enum167.const_0:
				package.Presentation.Relationships.method_4(@class);
				break;
			case Enum167.const_1:
			case Enum167.const_2:
				break;
			}
			MasterThemeManager masterThemeManager = (MasterThemeManager)masterNotesSlide.ThemeManager;
			IMasterTheme masterThemeEffective = masterThemeManager.MasterThemeEffective;
			smethod_7(package, masterThemeEffective, serializationContext);
			@class.Relationships.method_4(serializationContext.ThemeToThemePart[masterThemeEffective]);
			return @class;
		}
		return null;
	}

	private void method_9(Class1184 package, IPresentation presentation)
	{
		if (presentation.CommentAuthors.Count > 0)
		{
			Class1342 @class = package.method_4("/ppt/commentAuthors.xml", null, new Class1241());
			Class1198 class2 = new Class1198(@class, class1346_0);
			class2.method_7(presentation);
			package.Presentation.Relationships.method_4(@class);
		}
	}

	internal static Class1342 smethod_3(Class1184 package, ISlide slide, Class1346 serializationContext)
	{
		Class1342 @class = package.method_4(serializationContext.SlideToSlidePartPath[slide], null, new Class1249());
		Class1196 class2 = new Class1196(@class, serializationContext, slide);
		switch (serializationContext.Mode)
		{
		default:
			throw new Exception();
		case Enum167.const_0:
			@class.Relationships.method_4(serializationContext.SlideToSlidePart[slide.LayoutSlide]);
			package.Presentation.Relationships.method_4(@class);
			Class900.smethod_1(slide.ThemeManager, @class.Relationships, serializationContext);
			break;
		case Enum167.const_1:
		case Enum167.const_2:
			break;
		}
		smethod_4(package, slide, @class, serializationContext);
		switch (serializationContext.Mode)
		{
		default:
			throw new Exception();
		case Enum167.const_0:
		case Enum167.const_1:
			smethod_5(package, slide, @class, serializationContext);
			break;
		case Enum167.const_2:
			break;
		}
		class2.method_10(slide);
		return @class;
	}

	private static void smethod_4(Class1184 package, ISlide slide, Class1342 slideEntry, Class1346 serializationContext)
	{
		if (slide.NotesSlide == null)
		{
			return;
		}
		INotesSlide notesSlide = slide.NotesSlide;
		Class1342 @class = package.method_4("/ppt/notesSlides/notesSlide{0}.xml", serializationContext.method_27, new Class1246());
		Class1193 class2 = new Class1193(@class, serializationContext, notesSlide);
		@class.Relationships.method_4(slideEntry);
		slideEntry.Relationships.method_4(@class);
		switch (serializationContext.Mode)
		{
		default:
			throw new Exception();
		case Enum167.const_0:
			if (notesSlide.Presentation.MasterNotesSlideManager.MasterNotesSlide != null)
			{
				Class1342 targetPart = package.NotesMasters[0];
				@class.Relationships.method_4(targetPart);
			}
			Class900.smethod_1(notesSlide.ThemeManager, @class.Relationships, serializationContext);
			break;
		case Enum167.const_1:
		case Enum167.const_2:
			break;
		}
		class2.method_10(notesSlide);
	}

	private static void smethod_5(Class1184 package, ISlide slide, Class1342 slideEntry, Class1346 serializationContext)
	{
		IComment[] slideComments = slide.GetSlideComments(null);
		if (slideComments.Length > 0)
		{
			Class1342 @class = package.method_4("/ppt/comments/comment{0}.xml", serializationContext.method_29, new Class1242());
			Class1199 class2 = new Class1199(@class, serializationContext);
			class2.method_7(slideComments);
			slideEntry.Relationships.method_4(@class);
		}
	}

	private static void smethod_6(Class1184 package, IPresentation presentation, Class1346 serializationContext)
	{
		IMasterHandoutSlide masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
		if (masterHandoutSlide != null)
		{
			Class1342 @class = package.method_4("/ppt/handoutMasters/handoutMaster1.xml", null, new Class1244());
			Class1191 class2 = new Class1191(@class, serializationContext, masterHandoutSlide);
			class2.method_9(masterHandoutSlide);
			package.Presentation.Relationships.method_4(@class);
			MasterThemeManager masterThemeManager = (MasterThemeManager)masterHandoutSlide.ThemeManager;
			IMasterTheme masterThemeEffective = masterThemeManager.MasterThemeEffective;
			smethod_7(package, masterThemeEffective, serializationContext);
			@class.Relationships.method_4(serializationContext.ThemeToThemePart[masterThemeEffective]);
		}
	}

	private static void smethod_7(Class1184 package, IMasterTheme masterTheme, Class1346 serializationContext)
	{
		if (masterTheme != null && !serializationContext.ThemeToThemePart.ContainsKey(masterTheme))
		{
			Class1342 @class = package.method_4("/ppt/theme/theme{0}.xml", serializationContext.method_24, new Class1237());
			Class1209 class2 = new Class1209(@class, serializationContext);
			class2.method_9(masterTheme);
			serializationContext.ThemeToThemePart.Add(masterTheme, @class);
		}
	}

	internal static void smethod_8(IOverrideTheme overrideTheme, Class1346 serializationContext)
	{
		if (overrideTheme != null && !serializationContext.ThemeToThemePart.ContainsKey(overrideTheme))
		{
			Class1342 @class = serializationContext.Package.method_4("/ppt/theme/themeOverride{0}.xml", serializationContext.method_25, new Class1236());
			Class1208 class2 = new Class1208(@class, serializationContext);
			class2.method_6(overrideTheme);
			serializationContext.ThemeToThemePart.Add(overrideTheme, @class);
		}
	}

	private void method_10(Class1184 package, IPresentation presentation, Enum165 outputType)
	{
		bool flag = outputType == Enum165.const_1 || outputType == Enum165.const_3 || outputType == Enum165.const_5;
		if (presentation.VbaProject != null && flag)
		{
			Class1342 @class = package.method_4("/ppt/vbaProject.bin", null, new Class1335());
			Class246 class2 = new Class246();
			class2.method_1(@class, presentation);
			package.Presentation.Relationships.method_4(@class);
		}
	}

	private void method_11(Class1184 package, IPresentation presentation)
	{
		Class1342 @class = package.method_4("/ppt/tableStyles.xml", null, new Class1235());
		Class1206 class2 = new Class1206(@class, class1346_0);
		class2.method_6(((Presentation)presentation).PPTXUnsupportedProps.TableStyles);
		package.Presentation.Relationships.method_4(@class);
	}
}
