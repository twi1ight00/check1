using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Aspose.Slides.Export;
using Aspose.Slides.Theme;
using ns11;
using ns22;
using ns24;
using ns4;

namespace Aspose.Slides;

public class NotesSlide : BaseSlide, IPresentationComponent, ISlideComponent, IThemeable, IOverrideThemeable, IBaseSlide, INotesSlide
{
	private Class301 class301_0 = new Class301();

	private Class265 class265_0 = new Class265();

	internal Slide slide_0;

	private readonly NotesSlideThemeManager notesSlideThemeManager_0;

	internal override Class296 BaseSlidePPTXUnsupportedProps => class301_0;

	internal override Class262 BaseSlidePPTUnsupportedProps => class265_0;

	internal Class301 PPTXUnsupportedProps => class301_0;

	internal Class265 PPTUnsupportedProps => class265_0;

	public ITextFrame NotesTextFrame
	{
		get
		{
			foreach (Shape shape in base.Shapes)
			{
				if (shape.Placeholder != null && shape.Placeholder.Type == PlaceholderType.Body && shape is AutoShape)
				{
					return ((AutoShape)shape).TextFrame;
				}
			}
			return null;
		}
	}

	public IOverrideThemeManager ThemeManager => notesSlideThemeManager_0;

	public ISlide ParentSlide => slide_0;

	[Obsolete("Use ThemeManager.OverrideTheme property instead. Property will be removed after 01.09.2013.")]
	public OverrideTheme OverrideTheme => (OverrideTheme)ThemeManager.OverrideTheme;

	IBaseSlide INotesSlide.AsIBaseSlide => this;

	IOverrideThemeable INotesSlide.AsIOverrideThemeable => this;

	IThemeable IOverrideThemeable.AsIThemeable => this;

	internal NotesSlide(Slide slide)
		: base(slide.PresentationInternal)
	{
		notesSlideThemeManager_0 = new NotesSlideThemeManager(this);
		slide_0 = slide;
		Class1077.smethod_0(this);
	}

	[Obsolete("Use ThemeManager.ApplyColorScheme(..) method instead. Will be removed after 01.09.2013.")]
	public override void ApplyColorScheme(ExtraColorScheme scheme)
	{
		ThemeManager.ApplyColorScheme(scheme);
	}

	public Bitmap GetThumbnail(float scaleX, float scaleY)
	{
		SizeF notesSize = base.PresentationInternal.NotesSize;
		Size imageSize = new Size((int)Math.Round(notesSize.Width * scaleX), (int)Math.Round(notesSize.Height * scaleY));
		return GetThumbnail(imageSize);
	}

	public Bitmap GetThumbnail(Size imageSize)
	{
		Dictionary<string, Class64> dictionary = new Dictionary<string, Class64>();
		Bitmap bitmap = new Bitmap(imageSize.Width, imageSize.Height, PixelFormat.Format32bppRgb);
		bitmap.SetResolution(96f, 96f);
		try
		{
			SizeF notesSize = base.PresentationInternal.NotesSize;
			using (Class160 @class = new Class160(bitmap, notesSize.Width, notesSize.Height))
			{
				@class.vmethod_7(new RectangleF(-1f, -1f, notesSize.Width + 2f, notesSize.Height + 2f), null, new Class63(Color.White));
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
		}
	}

	internal void method_14(Class159 canvas, SaveOptions options, Dictionary<string, Class64> imageCache, Class170 renderingOptions)
	{
		ShapeFrame shapeFrame = new ShapeFrame(0f, 0f, base.PresentationInternal.NotesSize.Width, base.PresentationInternal.NotesSize.Height, NullableBool.False, NullableBool.False, 0f);
		Class169 rc = new Class169(this, imageCache, renderingOptions);
		Class63 fillParam = new Class63(Color.White);
		canvas.vmethod_7(shapeFrame.Rectangle, null, fillParam);
		if (slide_0 != null)
		{
			foreach (Shape shape in base.Shapes)
			{
				if (shape is AutoShape autoShape && autoShape.Placeholder != null && autoShape.Placeholder.Type == PlaceholderType.SlideImage)
				{
					IShapeFrame frame = autoShape.Frame;
					using Bitmap img = slide_0.GetThumbnail(new Size((int)frame.Width, (int)frame.Height));
					canvas.vmethod_6(img, (int)frame.X, (int)frame.Y);
				}
			}
		}
		if (base.Presentation != null && base.Presentation.MasterNotesSlideManager.MasterNotesSlide != null)
		{
			((BaseSlide)base.Presentation.MasterNotesSlideManager.MasterNotesSlide).groupShape_0.vmethod_4(canvas, rc);
		}
		groupShape_0.vmethod_4(canvas, rc);
		if (Class1179.smethod_1() == Enum179.const_0)
		{
			Class151 @class = new Class151(base.PresentationInternal, 72f);
			@class.FontBold = true;
			@class.FontColor = Color.FromArgb(192, 255, 216, 207);
			@class.FontShadow = true;
			@class.FontName = "Arial";
			@class.FontHeight = 24;
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
				reference = canvas.method_6(array[i], pointF, @class);
				num += array2[i].Height;
			}
			pointF.Y = ((float)canvas.Height - num) / 2f;
			for (int j = 0; j < array.Length; j++)
			{
				pointF.X = ((float)canvas.Width - array2[j].Width) / 2f;
				canvas.vmethod_13(array[j], new RectangleF(pointF, array2[j]), @class);
				pointF.Y += array2[j].Height;
			}
		}
	}

	internal override Shape[] vmethod_0(IPlaceholder placeholder)
	{
		if (base.Presentation != null && base.Presentation.MasterNotesSlideManager.MasterNotesSlide != null)
		{
			Shape shape = ((BaseSlide)base.Presentation.MasterNotesSlideManager.MasterNotesSlide).class518_0.method_1(placeholder, null);
			if (shape != null)
			{
				return new Shape[1] { shape };
			}
			return BaseSlide.shape_0;
		}
		return BaseSlide.shape_0;
	}
}
