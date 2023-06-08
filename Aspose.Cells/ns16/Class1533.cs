using System.Collections;
using System.Drawing;
using System.IO;
using Aspose.Cells.Charts;

namespace ns16;

internal class Class1533
{
	internal Chart chart_0;

	internal int int_0 = -1;

	internal ArrayList arrayList_0 = new ArrayList();

	internal ArrayList arrayList_1 = new ArrayList();

	internal string string_0;

	internal Class1358 class1358_0;

	internal Class1540 class1540_0;

	internal Class1533(Class1540 class1540_1, Chart chart_1)
	{
		class1540_0 = class1540_1;
		chart_0 = chart_1;
		class1358_0 = new Class1358(this);
		if (class1358_0.string_1 == null)
		{
			class1358_0 = null;
		}
		else
		{
			class1358_0.string_0 = method_1("http://schemas.openxmlformats.org/officeDocument/2006/relationships/chartUserShapes", "../drawings/" + class1358_0.string_1, null);
		}
	}

	internal string method_0(byte[] byte_0)
	{
		if (byte_0 != null && byte_0.Length != 0)
		{
			Class1357 @class = new Class1357();
			@class.byte_0 = byte_0;
			Image image = Image.FromStream(new MemoryStream(byte_0));
			@class.string_0 = Class1618.smethod_45("image", class1540_0.method_5(), image.RawFormat);
			arrayList_0.Add(@class);
			@class.string_1 = method_1("http://schemas.openxmlformats.org/officeDocument/2006/relationships/image", "../media/" + @class.string_0, null);
			return @class.string_1;
		}
		return null;
	}

	private string method_1(string string_1, string string_2, string string_3)
	{
		string text = "rId" + (arrayList_1.Count + 1);
		Class1564 value = new Class1564(text, string_1, string_2, string_3);
		arrayList_1.Add(value);
		return text;
	}
}
