using System.Drawing;
using System.IO;
using ns224;

namespace ns237;

internal class Class6520 : Class6519
{
	private MemoryStream memoryStream_1;

	private RectangleF rectangleF_0 = RectangleF.Empty;

	private Class6002 class6002_0;

	internal RectangleF BoundingBox
	{
		get
		{
			return rectangleF_0;
		}
		set
		{
			rectangleF_0 = value;
		}
	}

	internal Class6002 Transform
	{
		get
		{
			return class6002_0;
		}
		set
		{
			class6002_0 = value;
		}
	}

	internal MemoryStream Content
	{
		get
		{
			return memoryStream_1;
		}
		set
		{
			memoryStream_1 = value;
		}
	}

	public Class6520(Class6672 context)
		: base(context)
	{
	}

	internal override void vmethod_2(Class6679 writer)
	{
		base.vmethod_2(writer);
		writer.method_8("/Type", "/XObject");
		writer.method_8("/Subtype", "/Form");
		writer.method_18("/FormType", 1);
		writer.method_16("/BBox", rectangleF_0);
		if (class6002_0 != null)
		{
			writer.method_20("/Matrix", class6002_0);
		}
		class6672_0.AcroForm.method_1(writer, "/Resources");
	}

	public override void vmethod_0(Class6679 writer)
	{
		Write(memoryStream_1.GetBuffer(), 0, (int)memoryStream_1.Length);
		base.vmethod_0(writer);
	}
}
