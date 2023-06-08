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

namespace ns8;

internal class Class1467
{
	private Class1478 class1478_0;

	internal Class1467(Class1478 class1478_1)
	{
		class1478_0 = class1478_1;
	}

	internal void method_0(Class1487 class1487_0, string string_0, string string_1, string string_2, string string_3, bool bool_0)
	{
		Class1716 @class = new Class1716();
		@class.method_1(class1478_0.workbook_0.Worksheets);
		int count = @class.Count;
		if (count == 0)
		{
			return;
		}
		if (!class1478_0.method_2().ExportImagesAsBase64 && class1487_0 == null)
		{
			Directory.CreateDirectory(class1478_0.string_5);
		}
		class1478_0.method_6(new Hashtable(count));
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			Class1715 class2 = @class[i];
			if (class2.Data == null)
			{
				continue;
			}
			if (class1478_0.arrayList_1.Count == 1)
			{
				bool flag = false;
				Worksheet worksheet = (Worksheet)class1478_0.arrayList_1[0];
				if (worksheet.method_16() != null)
				{
					int count2 = worksheet.method_16().Count;
					for (int j = 0; j < count2; j++)
					{
						Picture picture = worksheet.Pictures[j];
						if (picture.method_70() == i + 1)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					continue;
				}
			}
			if (class2.bool_0)
			{
				string text = "image" + Class1486.smethod_1(num, 3) + ".pict";
				num++;
				class1478_0.method_5().Add(i, class1478_0.method_17(string_0) + text);
				if (!class1478_0.method_2().ExportImagesAsBase64 || class1487_0 != null)
				{
					if (class1487_0 == null)
					{
						string path = class1478_0.string_5 + text;
						FileStream fileStream = new FileStream(path, FileMode.Create);
						fileStream.Write(class2.Data, 0, class2.Data.Length);
						fileStream.Close();
					}
					else if (bool_0)
					{
						method_1(class1487_0, string_0, string_1 + text, string_2, class2.Data, string_3);
					}
					continue;
				}
				break;
			}
			ImageFormat imageFormat = class2.Type;
			byte[] array = class2.Data;
			if (imageFormat == ImageFormat.Png)
			{
				try
				{
					Class768 class3 = new Class768();
					class3.vmethod_0(new MemoryStream(array));
					byte[] array2 = class3.method_3();
					if (array2 != null)
					{
						array = array2;
						imageFormat = ImageFormat.Gif;
					}
				}
				catch
				{
				}
			}
			string text2 = Class1618.smethod_47(imageFormat);
			if (text2 == null)
			{
				text2 = ".jpg";
				imageFormat = ImageFormat.Jpeg;
			}
			string text3 = "image" + Class1486.smethod_1(num, 3) + text2;
			num++;
			class1478_0.method_5().Add(i, class1478_0.method_17(string_0) + text3);
			if (class1478_0.method_2().ExportImagesAsBase64 && class1487_0 == null)
			{
				continue;
			}
			string path2 = class1478_0.string_5 + text3;
			try
			{
				MemoryStream stream = new MemoryStream(array);
				Bitmap bitmap = new Bitmap(stream);
				if (bitmap != null)
				{
					if (imageFormat == ImageFormat.Jpeg)
					{
						bitmap = Class1404.smethod_42(bitmap, 1.0);
					}
					if (class1487_0 == null)
					{
						FileStream fileStream2 = new FileStream(path2, FileMode.Create);
						fileStream2.Write(array, 0, array.Length);
						fileStream2.Close();
					}
					else if (bool_0)
					{
						method_1(class1487_0, string_0, string_1 + text3, string_2, array, string_3);
					}
				}
			}
			catch
			{
				if (class1487_0 == null)
				{
					FileStream fileStream3 = new FileStream(path2, FileMode.Create);
					fileStream3.Write(array, 0, array.Length);
					fileStream3.Close();
				}
				else if (bool_0)
				{
					method_1(class1487_0, string_0, string_1 + text3, string_2, array, string_3);
				}
			}
		}
	}

	private void method_1(Class1487 class1487_0, string string_0, string string_1, string string_2, byte[] byte_0, string string_3)
	{
		Class1478.smethod_0(class1487_0, string_0, string_1, string_2, string_3);
		class1487_0.Write(Convert.ToBase64String(byte_0));
	}
}
