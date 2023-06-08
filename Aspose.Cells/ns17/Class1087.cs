using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns16;
using ns18;
using ns21;
using ns47;

namespace ns17;

internal class Class1087
{
	public Class1080 class1080_0;

	public Class1080 class1080_1;

	public Class1080 class1080_2;

	public Class1080 class1080_3;

	public Class1080 class1080_4;

	public Class1080 class1080_5;

	public Class1080 class1080_6;

	public string string_0;

	public Aspose.Cells.Font font_0;

	public Worksheet worksheet_0;

	public int int_0;

	public int int_1;

	public float float_0;

	public float float_1;

	public float float_2;

	public Class1092 class1092_0;

	private Hashtable hashtable_0;

	private PageSetup pageSetup_0;

	public double[] double_0;

	public void method_0(string string_1)
	{
		int num = string_1.IndexOf(',');
		if (num == -1)
		{
			font_0.Name = string_1;
			return;
		}
		font_0.Name = string_1.Substring(0, num);
		if (font_0.Name.StartsWith("+"))
		{
			font_0.Name = worksheet_0.Workbook.DefaultStyle.method_40().Name;
		}
		string_1 = string_1.Substring(num + 1);
		string[] array = string_1.Split(' ');
		for (int i = 0; i < array.Length; i++)
		{
			switch (array[i])
			{
			case "Regular":
			case "常规":
				font_0.IsItalic = false;
				font_0.IsBold = false;
				break;
			case "Italic":
			case "倾斜":
				font_0.IsItalic = true;
				break;
			case "Bold":
			case "加粗":
				font_0.IsBold = true;
				break;
			}
		}
	}

	public Enum170 method_1(ref string string_1)
	{
		Enum170 @enum = Enum170.const_0;
		try
		{
			while (string_1.Length > 0 && @enum == Enum170.const_0)
			{
				@enum = class1080_6.vmethod_0(ref string_1);
			}
		}
		catch
		{
			return @enum;
		}
		if (string_0.Length > 0)
		{
			method_5();
		}
		return @enum;
	}

	public void method_2()
	{
	}

	public void method_3()
	{
		class1092_0.method_0();
	}

	public void method_4()
	{
		Picture picture = GetPicture();
		class1092_0.method_3(method_6(picture.method_70() - 1), new SizeF((float)(picture.WidthPt * double_0[0]), (float)(picture.HeightPt * double_0[1])));
	}

	public void method_5()
	{
		Class1544 @class = new Class1544();
		@class.font_0 = new Aspose.Cells.Font(worksheet_0.method_2(), null);
		@class.font_0.Copy(font_0);
		@class.font_0.Size = Math.Max(1, (int)((double)@class.font_0.Size * double_0[1]));
		@class.string_0 = string_0;
		if (!Class1462.smethod_6(@class.font_0.Name, @class.font_0.method_30(), @class.string_0))
		{
			Aspose.Cells.Font font = worksheet_0.Workbook.DefaultStyle.method_40();
			if (Class1462.smethod_6(font.Name, @class.font_0.method_30(), @class.string_0))
			{
				@class.font_0.Name = font.Name;
			}
			else if (worksheet_0.Workbook.SaveOptions.string_1 != null && worksheet_0.Workbook.SaveOptions.string_1.Length > 0)
			{
				@class.font_0.Name = worksheet_0.Workbook.SaveOptions.string_1;
			}
			else
			{
				@class.font_0.Name = Struct78.string_0;
			}
		}
		class1092_0.method_2(@class);
		string_0 = "";
	}

	public Class1087(Class1092 class1092_1, Worksheet worksheet_1, Hashtable hashtable_1, int int_2, int int_3)
	{
		class1080_0 = new Class1085(this);
		class1080_1 = new Class1086(this);
		class1080_2 = new Class1084(this);
		class1080_3 = new Class1083(this);
		class1080_5 = new Class1081(this);
		class1080_4 = new Class1082(this);
		worksheet_0 = worksheet_1;
		font_0 = new Aspose.Cells.Font(worksheet_1.method_2(), null);
		font_0.Copy(worksheet_0.Workbook.DefaultStyle.method_40());
		class1080_6 = class1080_0;
		hashtable_0 = hashtable_1;
		class1092_0 = class1092_1;
		int_0 = int_2;
		int_1 = int_3;
		double_0 = class1092_0.double_0;
		pageSetup_0 = worksheet_0.PageSetup;
		string_0 = "";
		Class1625.smethod_10(worksheet_1.PageSetup, out var pageWidthBase, out var pageHeightBase);
		float_0 = (float)pageWidthBase * 72f;
		float_1 = (float)pageHeightBase * 72f;
		switch (class1092_0.textAlignmentType_0)
		{
		case TextAlignmentType.Left:
		case TextAlignmentType.Right:
			float_2 = float_0 * 0.8f;
			break;
		case TextAlignmentType.Center:
			float_2 = float_0 * 0.8f;
			break;
		}
		if (worksheet_0.Type == SheetType.Chart)
		{
			pageSetup_0 = worksheet_0.Charts[0].PageSetup;
		}
		method_2();
	}

	private MemoryStream method_6(int int_2)
	{
		if (hashtable_0[int_2] != null)
		{
			MemoryStream memoryStream = (MemoryStream)hashtable_0[int_2];
			memoryStream.Seek(0L, SeekOrigin.Begin);
			return memoryStream;
		}
		if (int_2 >= worksheet_0.Workbook.Worksheets.method_87().method_0().Count)
		{
			return new MemoryStream();
		}
		Class1715 picture = Class1716.GetPicture(worksheet_0.Workbook.Worksheets.method_87().method_0()[int_2]);
		_ = worksheet_0.Workbook.Worksheets.method_87().method_0()[int_2];
		MemoryStream memoryStream2 = new MemoryStream();
		if (picture.Data != null)
		{
			memoryStream2.Write(picture.Data, 0, picture.Data.Length);
			memoryStream2.Seek(0L, SeekOrigin.Begin);
			Image image = Image.FromStream(memoryStream2);
			if (image is Metafile)
			{
				return memoryStream2;
			}
			memoryStream2 = new MemoryStream();
			if (image.Width >= 8 && image.Height >= 8)
			{
				image = Class1404.smethod_41(image);
				Class1404.smethod_40(image, memoryStream2, 90L);
				memoryStream2.Seek(0L, SeekOrigin.Begin);
			}
			else
			{
				Class1404.smethod_37(image, memoryStream2);
			}
			hashtable_0[int_2] = memoryStream2;
			memoryStream2.Seek(0L, SeekOrigin.Begin);
			return memoryStream2;
		}
		return new MemoryStream();
	}

	private Picture GetPicture()
	{
		Picture result = null;
		pageSetup_0 = worksheet_0.PageSetup;
		ShapeCollection shapeCollection = pageSetup_0.method_32();
		int int_ = 0;
		switch (class1092_0.textAlignmentType_0)
		{
		case TextAlignmentType.Left:
			int_ = 0;
			break;
		case TextAlignmentType.Right:
			int_ = 2;
			break;
		case TextAlignmentType.Center:
			int_ = 1;
			break;
		}
		bool bool_ = true;
		if (class1092_0.textAlignmentType_1 == TextAlignmentType.Bottom)
		{
			bool_ = false;
		}
		if (shapeCollection != null)
		{
			int num = pageSetup_0.method_33(bool_, int_);
			if (num < 0)
			{
				return null;
			}
			Shape shape = shapeCollection[num];
			if (shape != null)
			{
				return (Picture)shape;
			}
		}
		return result;
	}
}
