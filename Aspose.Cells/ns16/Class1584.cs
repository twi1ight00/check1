using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Cells;
using ns21;

namespace ns16;

internal class Class1584
{
	private Workbook workbook_0;

	private Class1540 class1540_0;

	internal Class1584(Class1540 class1540_1)
	{
		workbook_0 = class1540_1.workbook_0;
		class1540_0 = class1540_1;
	}

	internal void method_0(Stream6 stream6_0)
	{
		if (class1540_0.hashtable_0 != null && class1540_0.hashtable_0.Count > 0)
		{
			Class1716 @class = new Class1716();
			@class.method_1(workbook_0.Worksheets);
			method_2(@class, class1540_0.hashtable_0, stream6_0);
		}
		if (class1540_0.hashtable_1 != null && class1540_0.hashtable_1.Count > 0)
		{
			Class1716 class2 = new Class1716();
			class2.method_2(workbook_0.Worksheets);
			method_2(class2, class1540_0.hashtable_1, stream6_0);
		}
		for (int i = 0; i < class1540_0.arrayList_0.Count; i++)
		{
			Class1541 class3 = (Class1541)class1540_0.arrayList_0[i];
			if (class3.string_2 == null)
			{
				continue;
			}
			byte[] array = class3.worksheet_0.BackgroundImage;
			string string_ = "xl/media/" + class3.string_2;
			Image image = Image.FromStream(new MemoryStream(array));
			if (image.RawFormat.Equals(ImageFormat.Bmp))
			{
				array = method_1(image);
				if (array == null)
				{
					continue;
				}
			}
			Class744 class4 = stream6_0.method_18(string_);
			class4.method_5(DateTime.Now);
			stream6_0.Write(array, 0, array.Length);
			stream6_0.Flush();
			class1540_0.method_22(class3.string_2);
		}
	}

	private byte[] method_1(Image image_0)
	{
		try
		{
			Bitmap bitmap = new Bitmap(image_0);
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Png);
			memoryStream.Position = 0L;
			int num = (int)memoryStream.Length;
			byte[] array = new byte[num];
			memoryStream.Read(array, 0, num);
			return array;
		}
		catch
		{
			return null;
		}
	}

	internal void method_2(Class1716 class1716_0, Hashtable hashtable_0, Stream6 stream6_0)
	{
		int count = class1716_0.Count;
		for (int i = 0; i < count; i++)
		{
			Class1715 @class = class1716_0[i];
			if (@class.Data != null && hashtable_0.ContainsKey(i + 1))
			{
				string text = (string)hashtable_0[i + 1];
				string string_ = "xl/media/" + text;
				Class744 class2 = stream6_0.method_18(string_);
				class2.method_5(DateTime.Now);
				stream6_0.Write(@class.Data, 0, @class.Data.Length);
				stream6_0.Flush();
			}
		}
	}
}
