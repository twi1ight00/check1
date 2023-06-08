using System.IO;
using ns221;
using ns235;
using ns264;

namespace ns241;

internal class Class6200 : Class6176
{
	private readonly Class6691 class6691_0;

	private string string_0;

	private readonly Class6482 class6482_0 = new Class6482();

	public Class5956 Info => class6691_0.Info;

	public string OriginalFileName
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class6200(Stream outputStream, string resourcesFolderPath, string resourcesFolderAlias)
	{
		class6691_0 = new Class6691(outputStream, resourcesFolderPath, resourcesFolderAlias);
	}

	public void method_0(Class6204 node)
	{
		node.vmethod_0(this);
	}

	public void method_1()
	{
		class6691_0.method_0();
	}

	public override void vmethod_0(Class6216 page)
	{
		class6691_0.method_1(page.Width, page.Height);
	}

	public override void vmethod_1(Class6216 page)
	{
		class6691_0.method_2();
	}

	public override void vmethod_2(Class6213 canvas)
	{
		class6691_0.PageWriter.method_2(canvas);
	}

	public override void vmethod_3(Class6213 canvas)
	{
		class6691_0.PageWriter.method_3();
	}

	public override void vmethod_4(Class6219 glyphs)
	{
		class6691_0.PageWriter.method_7(glyphs);
	}

	public override void vmethod_5(Class6217 path)
	{
		class6691_0.PageWriter.method_4(path);
	}

	public override void vmethod_6(Class6217 path)
	{
		class6691_0.PageWriter.method_5();
	}

	public override void vmethod_11(Class6220 image)
	{
		image = image.method_0(this, class6482_0, scaleForPdf: false, isRenderMetafileToBitmap: false);
		if (image != null)
		{
			class6691_0.PageWriter.method_6(image);
		}
	}

	public override void vmethod_12(Class6211 bookmark)
	{
		class6691_0.method_3(bookmark);
	}
}
