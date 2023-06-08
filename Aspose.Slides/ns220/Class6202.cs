using System.Collections.Generic;
using ns221;
using ns235;
using ns247;
using ns264;

namespace ns220;

internal class Class6202 : Class6176
{
	private readonly Class6482 class6482_0 = new Class6482();

	private readonly Class6256 class6256_0;

	private readonly Class6704 class6704_0;

	private string string_0;

	private Class6594 class6594_0;

	public Class6256 Package => class6256_0;

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

	public IList<Class5974> Warnings => class6704_0.Warnings;

	public Class6202(Class5956 info, Class6596 options)
	{
		class6256_0 = new Class6256();
		class6704_0 = new Class6704(class6256_0);
		class6704_0.Info = info;
		class6704_0.Options = options;
		class6594_0 = new Class6594(options);
	}

	public void method_0(Class6204 node)
	{
		node.vmethod_0(this);
	}

	public void method_1()
	{
		class6704_0.method_0();
	}

	public override void vmethod_0(Class6216 page)
	{
		class6704_0.method_1(page.Width, page.Height);
		class6704_0.method_7(page.Size);
	}

	public override void vmethod_1(Class6216 page)
	{
		class6704_0.method_2();
	}

	public override void vmethod_2(Class6213 canvas)
	{
		class6704_0.PageWriter.method_2(canvas);
	}

	public override void vmethod_3(Class6213 canvas)
	{
		class6704_0.PageWriter.method_3();
	}

	public override void vmethod_4(Class6219 glyphs)
	{
		class6704_0.PageWriter.method_7(glyphs);
	}

	public override void vmethod_5(Class6217 path)
	{
		class6704_0.PageWriter.method_4(path);
	}

	public override void vmethod_6(Class6217 path)
	{
		class6704_0.PageWriter.method_5();
	}

	public override void vmethod_11(Class6220 image)
	{
		image = image.method_0(this, class6482_0, scaleForPdf: false, class6704_0.Options.RenderMetafileAsBitmap);
		if (image != null)
		{
			class6704_0.PageWriter.method_6(image);
		}
	}

	public override void vmethod_12(Class6211 bookmark)
	{
		class6704_0.method_3(bookmark);
	}

	public override void vmethod_13(Class6221 outlineItem)
	{
		class6704_0.method_4(outlineItem);
	}

	public override void vmethod_14(Class6210 field)
	{
		if (class6704_0.Options.EmulateFormFieldRendering.EnableEmulation)
		{
			class6594_0.method_6(field).vmethod_0(this);
		}
	}

	public override void vmethod_15(Class6207 field)
	{
		if (class6704_0.Options.EmulateFormFieldRendering.EnableEmulation)
		{
			class6594_0.method_7(field).vmethod_0(this);
		}
	}

	public override void vmethod_16(Class6209 field)
	{
		if (class6704_0.Options.EmulateFormFieldRendering.EnableEmulation)
		{
			class6594_0.method_8(field).vmethod_0(this);
		}
	}

	public override void vmethod_17(Class6208 field)
	{
		if (class6704_0.Options.EmulateFormFieldRendering.EnableEmulation)
		{
			class6594_0.method_9(field).vmethod_0(this);
		}
	}

	public override void vmethod_18(Class6206 field)
	{
		if (class6704_0.Options.EmulateFormFieldRendering.EnableEmulation)
		{
			class6594_0.method_10(field).vmethod_0(this);
		}
	}
}
