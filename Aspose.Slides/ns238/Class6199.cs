using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using ns218;
using ns221;
using ns224;
using ns233;
using ns234;
using ns235;
using ns264;

namespace ns238;

internal class Class6199 : Class6176
{
	private const long long_0 = 4L;

	private const long long_1 = 19L;

	private Stream stream_0;

	private Class6567 class6567_0;

	private Stack stack_0 = new Stack();

	private Class6002 class6002_0 = new Class6002();

	private Class6482 class6482_0 = new Class6482();

	private Class5956 class5956_0 = new Class5956();

	public Class6199(Stream stream, Class5956 documentInfo, Class6588 options)
	{
		stream_0 = stream;
		class6567_0 = new Class6567(new MemoryStream(), options);
		class5956_0 = documentInfo;
		method_1();
		class6002_0.method_5(20f, 20f, MatrixOrder.Prepend);
	}

	public void method_0(Class6204 node)
	{
		node.vmethod_0(this);
	}

	private void method_1()
	{
		Class6575 @class = new Class6575(class6567_0);
		@class.Write(class6567_0.Options.Compressed);
		Class6570 class2 = new Class6570(class6567_0);
		class2.method_0();
		Class6578 class3 = new Class6578(class6567_0);
		class3.method_0(class5956_0);
		if (class6567_0.Options.ViewerIncluded)
		{
			class6567_0.Writer.method_0(Class6592.ViewerUi);
			class6567_0.method_9();
		}
	}

	public void method_2()
	{
		class6567_0.method_11(class6567_0.Options.ViewerIncluded);
		class6567_0.Writer.method_16(Enum878.const_0, 0);
		Stream baseStream = class6567_0.Writer.BaseWriter.BaseStream;
		baseStream.Position = 4L;
		class6567_0.Writer.method_2((int)baseStream.Length);
		baseStream.Position = 19L;
		class6567_0.Writer.method_1((short)(class6567_0.Pages.Count + (class6567_0.Options.ViewerIncluded ? 2 : 0)));
		baseStream.Position = 0L;
		if (class6567_0.Options.Compressed)
		{
			method_3(baseStream);
		}
		else
		{
			Class5964.smethod_9(baseStream, stream_0);
		}
	}

	public override void vmethod_0(Class6216 page)
	{
		short num = class6567_0.method_10();
		class6567_0.method_0(num, page.Size);
		Class6583 @class = new Class6583(class6567_0, num);
		method_6(@class);
		Class6583 class2 = new Class6583(class6567_0, class6567_0.method_10());
		method_6(class2);
		Class6217 class3 = new Class6217();
		Class6218 class4 = new Class6218();
		class4.method_3(new RectangleF(0f, 0f, page.Width, page.Height));
		class4.IsClosed = true;
		class3.Add(class4);
		Class6217 path = class3.Clone();
		short childId = class6567_0.CurrentPage.method_0(path);
		@class.method_1(childId, class6002_0, string.Empty, isClip: false);
		method_5(class3, class6002_0, @class);
		@class.method_0(class2.CharacterId, class6002_0, null);
	}

	public override void vmethod_1(Class6216 page)
	{
		class6567_0.CurrentPage.method_2(method_7());
		Class6583 @class = method_7();
		if (class6567_0.Options.ShowPageBorder)
		{
			Class6217 class2 = new Class6217();
			Class6218 class3 = new Class6218();
			class3.method_3(new RectangleF(0f, 0f, page.Width, page.Height));
			class3.IsClosed = true;
			class2.Add(class3);
			class2.Brush = new Class5997(Class5998.class5998_141);
			class2.Pen = new Class6003(new Class5997(Class5998.class5998_7), 1f);
			short childId = class6567_0.CurrentPage.method_0(class2);
			@class.method_1(childId, class6002_0, string.Empty, isClip: false);
		}
		class6567_0.method_1(@class);
	}

	public override void vmethod_2(Class6213 canvas)
	{
		Class6583 @class = method_8();
		Class6583 class2 = new Class6583(class6567_0, class6567_0.method_10());
		if (canvas.Clip != null)
		{
			method_5(canvas.Clip, canvas.RenderTransform, @class);
		}
		string name = string.Empty;
		if (canvas.Hyperlink != null)
		{
			name = $"hyperlink{class2.CharacterId}";
			class6567_0.CurrentPage.method_3(class2.CharacterId, canvas.Hyperlink);
		}
		@class.method_0(class2.CharacterId, canvas.RenderTransform, name);
		method_6(class2);
	}

	public override void vmethod_3(Class6213 canvas)
	{
		class6567_0.CurrentPage.method_2(method_7());
	}

	public override void vmethod_4(Class6219 glyphs)
	{
		Class6583 @class = method_8();
		short childId = class6567_0.CurrentPage.AddText(glyphs);
		if (glyphs.Hyperlink != null)
		{
			@class = method_4(glyphs.Hyperlink, @class);
		}
		Class6002 class2 = ((glyphs.RenderTransform != null) ? glyphs.RenderTransform.Clone() : new Class6002());
		class2.method_5(0.05f, 0.05f, MatrixOrder.Prepend);
		Class6217 class3 = new Class6217();
		Class6218 class4 = new Class6218();
		class4.method_3(new RectangleF(glyphs.Origin.X, glyphs.Origin.Y - glyphs.Font.SizePoints, glyphs.Bounds.Width, glyphs.Bounds.Height));
		class4.IsClosed = true;
		class3.Add(class4);
		short childId2 = class6567_0.CurrentPage.method_0(class3);
		@class.method_1(childId2, new Class6002(), string.Empty, isClip: false);
		if (glyphs.Clip != null)
		{
			method_5(glyphs.Clip, glyphs.RenderTransform, @class);
		}
		@class.method_0(childId, class2, string.Empty);
	}

	public override void vmethod_5(Class6217 path)
	{
		Class6583 @class = method_8();
		if (path.Clip != null)
		{
			method_5(path.Clip, path.RenderTransform, @class);
		}
		short childId = class6567_0.CurrentPage.method_0(path);
		@class.method_0(childId, path.RenderTransform, string.Empty);
	}

	public override void vmethod_11(Class6220 image)
	{
		image = image.method_0(this, class6482_0, scaleForPdf: false, isRenderMetafileToBitmap: false);
		if (image != null)
		{
			AddImage(image);
		}
	}

	public override void vmethod_12(Class6211 bookmark)
	{
		class6567_0.method_7(bookmark);
	}

	public override void vmethod_13(Class6221 outlineItem)
	{
		class6567_0.method_8(outlineItem);
	}

	private void method_3(Stream swfStream)
	{
		Class6566 @class = new Class6566(stream_0);
		byte[] array = new byte[8];
		swfStream.Read(array, 0, array.Length);
		@class.method_0(array);
		byte[] array2 = new byte[(int)(swfStream.Length - array.Length)];
		swfStream.Read(array2, 0, array2.Length);
		byte[] buffer = Class6171.smethod_2(array2, Enum794.const_1);
		@class.method_0(buffer);
	}

	private void AddImage(Class6220 image)
	{
		Class6217 @class = new Class6217();
		Class6218 class2 = new Class6218();
		class2.method_3(new RectangleF(0f, 0f, image.Size.Width, image.Size.Height));
		class2.IsClosed = true;
		@class.Add(class2);
		@class.Brush = smethod_0(image);
		Class6002 class3 = new Class6002();
		class3.method_7(image.Origin.X, image.Origin.Y, MatrixOrder.Prepend);
		Class6583 class4 = method_8();
		if (image.Hyperlink != null)
		{
			class4 = method_4(image.Hyperlink, class4);
		}
		short childId = class6567_0.CurrentPage.method_0(@class);
		class4.method_0(childId, class3, string.Empty);
	}

	private static Class5995 smethod_0(Class6220 image)
	{
		Class5995 @class = new Class5995(image.ImageBytes);
		@class.WrapMode = WrapMode.Clamp;
		Class6002 class2 = new Class6002();
		Class6147 class3 = Class6148.smethod_3(image.ImageBytes);
		float scaleX = image.Size.Width / (float)class3.Width;
		float scaleY = image.Size.Height / (float)class3.Height;
		class2.method_5(scaleX, scaleY, MatrixOrder.Prepend);
		@class.Transform = class2;
		return @class;
	}

	private Class6583 method_4(Class6270 hyperlink, Class6583 parentSprite)
	{
		Class6583 @class = new Class6583(class6567_0, class6567_0.method_10());
		parentSprite.method_0(@class.CharacterId, new Class6002(), $"hyperlink{@class.CharacterId}");
		class6567_0.CurrentPage.method_3(@class.CharacterId, hyperlink);
		parentSprite = @class;
		class6567_0.CurrentPage.method_2(@class);
		return parentSprite;
	}

	private void method_5(Class6217 clip, Class6002 parentMatrix, Class6583 parentSprite)
	{
		short childId = class6567_0.CurrentPage.method_0(clip);
		Class6002 @class = ((clip.RenderTransform != null) ? clip.RenderTransform.Clone() : new Class6002());
		if (parentMatrix != null)
		{
			@class.method_9(parentMatrix, MatrixOrder.Prepend);
		}
		parentSprite.method_1(childId, @class, string.Empty, isClip: true);
	}

	private void method_6(Class6583 spriteWriter)
	{
		stack_0.Push(spriteWriter);
	}

	private Class6583 method_7()
	{
		return (Class6583)stack_0.Pop();
	}

	private Class6583 method_8()
	{
		return (Class6583)stack_0.Peek();
	}
}
