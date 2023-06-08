using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using x38a89dee67fc7a16;

namespace xfbd1009a0cbb9842;

internal class x7a0719c07625a2cb : Field, x6ed66b5cf8da2955
{
	internal string x9f8e4dc805c6986e => base.xb452e2ee706d7a67.x642e37025c67edab(0);

	internal bool x9bc71e96fb52c0cf => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\c");

	internal bool x5571dc81e21bd535 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\d");

	internal bool x14fb814acade678b => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\x");

	internal bool x02e3026dc7b4e693 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\y");

	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		x52b190e626f65140(x7d5e2f34b6651bf4.xf8d31d196ccd74c4);
		Shape shape = new Shape(base.x2c8c6741422a1298, ShapeType.Image);
		base.End.ParentNode.InsertBefore(shape, base.End);
		shape.Width = 216.0;
		shape.Height = 216.0;
		shape.WrapType = WrapType.Inline;
		shape.ImageData.SourceFullName = x9f8e4dc805c6986e;
		byte[] array = shape.ImageData.x096dc407252fbea0();
		if (array != null)
		{
			xa2745adfabe0c674 xa2745adfabe0c = xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(array);
			shape.Width = xa2745adfabe0c.xd0c3f0768d960161;
			shape.Height = xa2745adfabe0c.xeb129b9a992183c5;
			if (!x5571dc81e21bd535)
			{
				shape.ImageData.ImageBytes = array;
			}
		}
		else if (!x5571dc81e21bd535)
		{
			return new xd5801a931e010963(this, "Error! Filename not specified.");
		}
		return null;
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\c":
			return x9f6b815e19fa8f62.x47e3e032f7bd5d28;
		case "\\d":
		case "\\x":
		case "\\y":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		default:
			return x9f6b815e19fa8f62.xf6c17f648b65c793;
		}
	}

	x9f6b815e19fa8f62 x6ed66b5cf8da2955.x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6b9dc5b8ca4335e3
		return this.x6b9dc5b8ca4335e3(x724fbd227bfb6eda);
	}
}
