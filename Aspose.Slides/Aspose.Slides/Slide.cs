using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Theme;
using ns11;
using ns12;
using ns22;
using ns224;
using ns235;
using ns24;
using ns28;
using ns4;

namespace Aspose.Slides;

public sealed class Slide : BaseSlide, IPresentationComponent, ISlideComponent, IThemeable, IOverrideThemeable, IBaseSlide, ISlide
{
	private const string string_1 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/comments";

	private Class302 class302_0 = new Class302();

	private Class266 class266_0 = new Class266();

	private LayoutSlide layoutSlide_0;

	private NotesSlide notesSlide_0;

	private readonly SlideThemeManager slideThemeManager_0;

	private bool bool_0;

	internal List<IComment> list_0 = new List<IComment>();

	internal override Class296 BaseSlidePPTXUnsupportedProps => class302_0;

	internal override Class262 BaseSlidePPTUnsupportedProps => class266_0;

	internal Class302 PPTXUnsupportedProps => class302_0;

	internal Class266 PPTUnsupportedProps => class266_0;

	public IOverrideThemeManager ThemeManager => slideThemeManager_0;

	[Obsolete("Use ThemeManager.OverrideTheme property instead. Property will be removed after 01.09.2013.")]
	public OverrideTheme OverrideTheme => (OverrideTheme)ThemeManager.OverrideTheme;

	public int SlideNumber
	{
		get
		{
			return base.Presentation.Slides.IndexOf(this) + 1;
		}
		set
		{
			base.Presentation.Slides.Reorder(value - 1, this);
		}
	}

	public bool Hidden
	{
		get
		{
			return !bool_0;
		}
		set
		{
			bool_0 = !value;
		}
	}

	public ILayoutSlide LayoutSlide
	{
		get
		{
			return layoutSlide_0;
		}
		set
		{
			method_26(value);
			method_25();
			method_21();
			layoutSlide_0 = (LayoutSlide)value;
			method_22();
			method_24();
		}
	}

	internal LayoutSlide LayoutSlideInternal
	{
		get
		{
			return layoutSlide_0;
		}
		set
		{
			method_26(value);
			method_25();
			HeaderFooterManager.smethod_5(this, value);
			layoutSlide_0 = value;
			method_24();
		}
	}

	internal IMasterSlide MasterSlide
	{
		get
		{
			if (layoutSlide_0 != null)
			{
				return layoutSlide_0.MasterSlide;
			}
			return null;
		}
	}

	internal override IBaseSlide[] BaseSlides
	{
		get
		{
			if (layoutSlide_0 == null)
			{
				return BaseSlide.baseSlide_0;
			}
			if (layoutSlide_0.MasterSlide == null)
			{
				return new BaseSlide[1] { layoutSlide_0 };
			}
			return new IBaseSlide[2] { layoutSlide_0, layoutSlide_0.MasterSlide };
		}
	}

	public INotesSlide NotesSlide => notesSlide_0;

	internal int CommentsCount => list_0.Count;

	IBaseSlide ISlide.AsIBaseSlide => this;

	IOverrideThemeable ISlide.AsIOverrideThemeable => this;

	IThemeable IOverrideThemeable.AsIThemeable => this;

	internal Slide(Presentation parentPresentation)
		: base(parentPresentation)
	{
		slideThemeManager_0 = new SlideThemeManager(this);
		InitSlideShowTransition();
	}

	internal void method_14(Class159 canvas, SaveOptions options, Dictionary<string, Class64> imageCache, Class170 renderingOptions)
	{
		ShapeFrame shapeFrame = new ShapeFrame(0f, 0f, base.ParentPresentation.SlideSize.Size.Width, base.ParentPresentation.SlideSize.Size.Height, NullableBool.False, NullableBool.False, 0f);
		Background background = (Background)base.Background;
		if (background.Type == BackgroundType.NotDefined && layoutSlide_0 != null)
		{
			background = (Background)layoutSlide_0.Background;
			if (background.Type == BackgroundType.NotDefined && layoutSlide_0.MasterSlide != null)
			{
				background = (Background)layoutSlide_0.MasterSlide.Background;
			}
		}
		Class169 class2 = (canvas.Context = new Class169(this, imageCache, renderingOptions));
		Class63 class3 = null;
		switch (background.Type)
		{
		case BackgroundType.Themed:
		{
			FillFormat fillFormat = background.method_0(this);
			class3 = ((fillFormat != null) ? new Class63(new Class67(shapeFrame, canvas.Transform, null, this, class2), new Class493(fillFormat, ((ColorFormat)background.StyleColor).method_4(this, FloatColor.floatColor_1))) : new Class63(((ColorFormat)background.StyleColor).method_5(this, FloatColor.floatColor_1)));
			break;
		}
		case BackgroundType.OwnBackground:
			class3 = new Class63(new Class67(shapeFrame, canvas.Transform, null, this, class2), new FloatColor(Color.White), background.method_0(this));
			if (background.PPTXUnsupportedProps.ShadeToShape != null)
			{
				class3.ShadeToShape = background.PPTXUnsupportedProps.ShadeToShape;
			}
			break;
		}
		class2.BackgroundFill = class3;
		if (class3 != null)
		{
			canvas.vmethod_7(shapeFrame.Rectangle, null, class3);
		}
		else
		{
			class3 = new Class63(Color.White);
			canvas.vmethod_7(shapeFrame.Rectangle, null, class3);
		}
		if (PPTXUnsupportedProps.ShowMasterShapes && layoutSlide_0 != null)
		{
			if (layoutSlide_0.ShowMasterShapes && layoutSlide_0.MasterSlide != null)
			{
				((MasterSlide)layoutSlide_0.MasterSlide).groupShape_0.vmethod_4(canvas, class2);
			}
			layoutSlide_0.groupShape_0.vmethod_4(canvas, class2);
		}
		groupShape_0.vmethod_4(canvas, class2);
		if (PPTXUnsupportedProps.ShowMasterShapes && layoutSlide_0 != null)
		{
			if (layoutSlide_0.ShowMasterShapes && layoutSlide_0.MasterSlide != null)
			{
				foreach (Control control4 in layoutSlide_0.MasterSlide.Controls)
				{
					control4.method_1(canvas, class2);
				}
			}
			foreach (Control control5 in layoutSlide_0.Controls)
			{
				control5.method_1(canvas, class2);
			}
		}
		foreach (Control control6 in base.Controls)
		{
			control6.method_1(canvas, class2);
		}
		canvas.Transform = new Class6002();
		if (Class1179.smethod_1() == Enum179.const_0)
		{
			Class151 class4 = new Class151((Presentation)base.ParentPresentation, 72f);
			class4.FontBold = true;
			class4.FontColor = Color.FromArgb(192, 255, 216, 207);
			class4.FontShadow = true;
			class4.FontName = "Arial";
			class4.FontHeight = 24;
			string[] array = new string[3]
			{
				"Evaluation only.",
				"Created with Aspose.Slides for .NET 4.0 15.1.0.0.",
				"Copyright 2004-" + "2015.01.30".Substring(0, 4) + " Aspose Pty Ltd."
			};
			SizeF[] array2 = new SizeF[array.Length];
			PointF pointF = new PointF(0f, 0f);
			float num = 0f;
			for (int i = 0; i < array.Length; i++)
			{
				ref SizeF reference = ref array2[i];
				reference = canvas.method_6(array[i], pointF, class4);
				num += array2[i].Height;
			}
			pointF.Y = ((float)canvas.Height - num) / 2f;
			for (int j = 0; j < array.Length; j++)
			{
				pointF.X = ((float)canvas.Width - array2[j].Width) / 2f;
				canvas.vmethod_13(array[j], new RectangleF(pointF, array2[j]), class4);
				pointF.Y += array2[j].Height;
			}
		}
	}

	internal Class6213 method_15(SaveOptions options, Dictionary<string, Class64> imageCache, Class170 renderingOptions)
	{
		return method_16(saveMetafileAsPng: true, options, imageCache, renderingOptions);
	}

	internal Class6213 method_16(bool saveMetafileAsPng, SaveOptions options, Dictionary<string, Class64> imageCache, Class170 renderingOptions)
	{
		Class164 @class = new Class164((int)base.Presentation.SlideSize.Size.Width, (int)base.Presentation.SlideSize.Size.Height, 72f, 72f, saveMetafileAsPng, renderingOptions.bool_3, ((Presentation)base.Presentation).FontsManagerInternal);
		method_14(@class, options, imageCache, renderingOptions);
		return @class.Canvas;
	}

	public Bitmap GetThumbnail(float scaleX, float scaleY)
	{
		SizeF size = base.Presentation.SlideSize.Size;
		Size imageSize = new Size((int)Math.Round(size.Width * scaleX), (int)Math.Round((float)(int)size.Height * scaleY));
		return GetThumbnail(imageSize);
	}

	public Bitmap GetThumbnail()
	{
		return GetThumbnail(0.2f, 0.2f);
	}

	public Bitmap GetThumbnail(Size imageSize)
	{
		Dictionary<string, Class64> dictionary = new Dictionary<string, Class64>();
		Bitmap bitmap = new Bitmap(imageSize.Width, imageSize.Height, PixelFormat.Format32bppRgb);
		bitmap.SetResolution(96f, 96f);
		try
		{
			SizeF size = base.Presentation.SlideSize.Size;
			((FontsManager)base.Presentation.FontsManager).UseFontsSubstitutionsList = true;
			using (Class160 @class = new Class160(bitmap, size.Width, size.Height))
			{
				@class.vmethod_7(new RectangleF(-1f, -1f, size.Width + 2f, size.Height + 2f), null, new Class63(Color.White));
				Class170 renderingOptions = new Class170();
				method_14(@class, new PptxOptions(), dictionary, renderingOptions);
			}
			return bitmap;
		}
		catch
		{
			bitmap.Dispose();
			throw;
		}
		finally
		{
			foreach (Class64 value in dictionary.Values)
			{
				((IDisposable)value).Dispose();
			}
			((FontsManager)base.Presentation.FontsManager).UseFontsSubstitutionsList = false;
		}
	}

	public Bitmap GetThumbnail(TiffOptions options)
	{
		MemoryStream stream = new MemoryStream();
		Class197.smethod_7(this, stream, options, withNotes: false);
		return (Bitmap)Image.FromStream(stream);
	}

	public void WriteAsSvg(Stream stream)
	{
		WriteAsSvg(stream, null);
	}

	public void WriteAsSvg(Stream stream, SVGOptions svgOptions)
	{
		if (svgOptions == null)
		{
			svgOptions = new SVGOptions();
		}
		Class163 @class = new Class163((int)base.ParentPresentation.SlideSize.Size.Width, (int)base.ParentPresentation.SlideSize.Size.Height, 72f, 72f, 72f, svgOptions, null);
		Dictionary<string, Class64> dictionary = new Dictionary<string, Class64>();
		try
		{
			Class170 class2 = new Class170();
			class2.bool_2 = true;
			class2.interface3_0 = new Class184(@class, svgOptions.ShapeFormattingController);
			method_14(@class, svgOptions, dictionary, class2);
			@class.method_9(stream, writingXml: true);
		}
		finally
		{
			foreach (Class64 value in dictionary.Values)
			{
				((IDisposable)value).Dispose();
			}
			@class.Dispose();
		}
	}

	public void Remove()
	{
		if (base.PresentationInternal == null)
		{
			throw new PptxEditException("Slide is already removed from presentation.");
		}
		lock (((ICollection)((SlideCollection)base.PresentationInternal.Slides).list_0).SyncRoot)
		{
			((SlideCollection)base.PresentationInternal.Slides).list_0.Remove(this);
			((SlideCollection)base.PresentationInternal.Slides).method_2();
			base.PresentationInternal = null;
		}
	}

	internal void method_17(ILayoutSlide layout)
	{
		LayoutSlideInternal = (LayoutSlide)layout;
	}

	public INotesSlide AddNotesSlide()
	{
		if (notesSlide_0 == null)
		{
			method_18(new NotesSlide(this));
		}
		return notesSlide_0;
	}

	public IComment[] GetSlideComments(ICommentAuthor author)
	{
		if (author == null)
		{
			return list_0.ToArray();
		}
		List<IComment> list = new List<IComment>();
		foreach (Comment item in list_0)
		{
			if (item.Author == author)
			{
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	internal IComment AddComment(ICommentAuthor author, string text, PointF position)
	{
		Comment comment = new Comment((CommentAuthor)author, text, this, position, DateTime.Now);
		list_0.Add(comment);
		((CommentCollection)author.Comments).Add(comment);
		return comment;
	}

	internal void method_18(NotesSlide notes)
	{
		notesSlide_0 = notes;
		if (notes != null)
		{
			notes.slide_0 = this;
		}
	}

	internal override Shape[] vmethod_0(IPlaceholder placeholder)
	{
		if (layoutSlide_0 == null)
		{
			return BaseSlide.shape_0;
		}
		Shape shape = null;
		if (placeholder.Index == uint.MaxValue)
		{
			if (layoutSlide_0.MasterSlide != null)
			{
				shape = ((BaseSlide)layoutSlide_0.MasterSlide).class518_0.method_1(placeholder, null);
			}
			if (shape != null)
			{
				return new Shape[1] { shape };
			}
			return BaseSlide.shape_0;
		}
		Shape shape2 = layoutSlide_0.class518_0.method_0((Placeholder)placeholder);
		if (shape2 != null && layoutSlide_0.MasterSlide != null)
		{
			shape = ((BaseSlide)layoutSlide_0.MasterSlide).class518_0.method_1(shape2.Placeholder, (Placeholder)placeholder);
		}
		if (shape2 == null)
		{
			return BaseSlide.shape_0;
		}
		if (shape == null)
		{
			return new Shape[1] { shape2 };
		}
		return new Shape[2] { shape2, shape };
	}

	internal void method_19(Class416 page, Class476 package)
	{
		foreach (MasterSlide master in base.ParentPresentation.Masters)
		{
			MasterThemeManager masterThemeManager = (MasterThemeManager)master.ThemeManager;
			IMasterTheme masterThemeEffective = masterThemeManager.MasterThemeEffective;
			if (!(masterThemeEffective.Name == page.MasterPageNameStr))
			{
				continue;
			}
			foreach (LayoutSlide layoutSlide in master.LayoutSlides)
			{
				if (layoutSlide.LayoutType == SlideLayoutType.Blank)
				{
					layoutSlide_0 = layoutSlide;
					break;
				}
			}
			break;
		}
		PPTXUnsupportedProps.ShowMasterShapes = page.StyleName.DrawingPageProperties.BackgroundObjectsVisible;
		method_12(page, package);
		class518_0.method_2(this);
	}

	internal void method_20(Class476 odpPackage)
	{
		if (Name == "" || Name == null)
		{
			Name = "Slide_" + PPTXUnsupportedProps.SlideId;
		}
		Class416 @class = odpPackage.class462_0.method_2(Name);
		@class.MasterPageNameStr = MasterSlide.Name + "_" + LayoutSlideInternal.Name;
		Class437 class2 = (odpPackage.class462_0.AutomaticStyles as Class438).method_36(string.Format("{0}{1}", "gp", odpPackage.int_0++));
		class2.method_36();
		@class.StyleName = class2;
		class2.Family = Enum84.const_10;
		class2.DrawingPageProperties.DisplayPageNumber = false;
		class2.DrawingPageProperties.DisplayDateTime = false;
		class2.DrawingPageProperties.DisplayFooter = false;
		class2.DrawingPageProperties.DisplayHeader = false;
		class2.DrawingPageProperties.BackgroundObjectsVisible = PPTXUnsupportedProps.ShowMasterShapes;
		Background background = (Background)base.Background;
		if (background.Type == BackgroundType.NotDefined && layoutSlide_0 != null)
		{
			background = (Background)layoutSlide_0.Background;
			if (background.Type == BackgroundType.NotDefined && layoutSlide_0.MasterSlide != null)
			{
				background = (Background)layoutSlide_0.MasterSlide.Background;
			}
		}
		Class469 class3 = null;
		switch (background.Type)
		{
		case BackgroundType.Themed:
		{
			FillFormat fillFormat = background.method_0(this);
			class3 = ((fillFormat != null) ? new Class469(new Class493(fillFormat, ((ColorFormat)background.StyleColor).method_4(this, FloatColor.floatColor_1))) : new Class469());
			break;
		}
		case BackgroundType.OwnBackground:
			class3 = new Class469(background.method_0(this));
			break;
		}
		class3.method_1(class2.DrawingPageProperties.FillProperties, this, odpPackage, FloatColor.floatColor_0);
		((ShapeCollection)base.Shapes).method_20(@class, odpPackage, (Class438)odpPackage.class462_0.AutomaticStyles);
	}

	[Obsolete("Use ThemeManager.ApplyColorScheme(..) method instead. Will be removed after 01.09.2013.")]
	public override void ApplyColorScheme(ExtraColorScheme scheme)
	{
		ThemeManager.ApplyColorScheme(scheme);
	}

	public override void JoinPortionsWithSameFormatting()
	{
		if (NotesSlide != null)
		{
			NotesSlide.JoinPortionsWithSameFormatting();
		}
		base.JoinPortionsWithSameFormatting();
	}

	private void method_21()
	{
		if (layoutSlide_0 != null)
		{
			HeaderFooterManager.smethod_2(this);
		}
	}

	private void method_22()
	{
		if (layoutSlide_0 != null)
		{
			((HeaderFooterManager)base.ParentPresentation.HeaderFooterManager).method_3(this, LayoutSlideInternal);
		}
	}

	internal void method_23()
	{
		if (layoutSlide_0 != null)
		{
			((HeaderFooterManager)base.ParentPresentation.HeaderFooterManager).method_4(this, LayoutSlideInternal);
		}
	}

	private void method_24()
	{
		if (layoutSlide_0 != null)
		{
			layoutSlide_0.class518_0.m_textPropsChanged += class518_0.method_4;
		}
	}

	private void method_25()
	{
		if (layoutSlide_0 != null)
		{
			layoutSlide_0.class518_0.m_textPropsChanged -= class518_0.method_4;
		}
	}

	private void method_26(ILayoutSlide layout)
	{
		if (layout != null && layout.Presentation != base.ParentPresentation)
		{
			throw new PptxEditException("Layout slide must be from the same presentation.");
		}
	}
}
