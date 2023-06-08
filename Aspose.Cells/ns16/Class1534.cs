using System.Collections;
using System.Drawing;
using System.IO;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns8;

namespace ns16;

internal class Class1534
{
	internal string string_0;

	internal string string_1;

	internal ArrayList arrayList_0 = new ArrayList();

	internal Hashtable hashtable_0 = new Hashtable();

	internal Hashtable hashtable_1 = new Hashtable();

	internal Class1541 class1541_0;

	internal ArrayList arrayList_1 = new ArrayList();

	internal ArrayList arrayList_2 = new ArrayList();

	internal Class1534()
	{
	}

	internal Class1534(Class1541 class1541_1)
	{
		class1541_0 = class1541_1;
		arrayList_1 = method_7();
		if (!class1541_0.method_17() && !class1541_0.method_19() && !class1541_0.method_11() && arrayList_1.Count == 0 && !class1541_0.method_12())
		{
			return;
		}
		if (class1541_0.worksheet_0.class1557_0 != null && class1541_0.worksheet_0.class1557_0.arrayList_10.Count > 0)
		{
			IEnumerator enumerator = class1541_0.worksheet_0.class1557_0.arrayList_10.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Class1564 value = (Class1564)enumerator.Current;
				arrayList_0.Add(value);
			}
		}
		for (int i = 0; i < class1541_0.worksheet_0.Shapes.Count; i++)
		{
			Shape shape = class1541_0.worksheet_0.Shapes[i];
			if (shape.class1556_0 != null && shape.class1556_0.string_1 != null && shape.MsoDrawingType == MsoDrawingType.Picture)
			{
				Picture picture = (Picture)shape;
				if (!hashtable_0.ContainsKey(picture.method_70()))
				{
					string string_ = "../media/" + (string)class1541_0.class1540_0.hashtable_0[picture.method_70()];
					string value2 = method_4("http://schemas.openxmlformats.org/officeDocument/2006/relationships/image", string_);
					hashtable_0.Add(picture.method_70(), value2);
				}
			}
		}
		int count = class1541_0.arrayList_3.Count;
		for (int j = 0; j < count; j++)
		{
			Class1538 @class = (Class1538)class1541_0.arrayList_3[j];
			if (@class.string_4 != null)
			{
				@class.string_3 = method_4("http://schemas.openxmlformats.org/officeDocument/2006/relationships/image", "../media/" + @class.string_4);
			}
			if (@class.oleObject_0.class1556_0 != null && @class.oleObject_0.class1556_0.string_1 != null)
			{
				@class.string_0 = Class1618.smethod_80(Class1618.smethod_145(@class.oleObject_0.class1556_0.string_1));
			}
			else if (@class.oleObject_0.class1556_0 != null && @class.oleObject_0.class1556_0.string_0 != null)
			{
				@class.string_0 = Class1618.smethod_80(Class1618.smethod_145(@class.oleObject_0.class1556_0.string_0));
			}
			else
			{
				@class.string_0 = method_2(j);
			}
		}
		if (class1541_0.arrayList_4 != null)
		{
			int num = count;
			count = class1541_0.arrayList_4.Count;
			for (int k = 0; k < count; k++)
			{
				Class527 class2 = (Class527)class1541_0.arrayList_4[k];
				if (class2.string_2 != null)
				{
					class2.string_1 = method_4("http://schemas.openxmlformats.org/officeDocument/2006/relationships/image", "../media/" + class2.string_2);
				}
				if (class2.picture_0.class1556_0 != null && class2.picture_0.class1556_0.string_1 != null)
				{
					class2.string_0 = Class1618.smethod_80(Class1618.smethod_145(class2.picture_0.class1556_0.string_1));
				}
				else if (class2.picture_0.class1556_0 != null && class2.picture_0.class1556_0.string_0 != null)
				{
					class2.string_0 = Class1618.smethod_80(Class1618.smethod_145(class2.picture_0.class1556_0.string_0));
				}
				else
				{
					class2.string_0 = method_2(k + num);
				}
			}
		}
		if (class1541_0.method_17())
		{
			foreach (Comment comment in class1541_0.worksheet_0.Comments)
			{
				Shape commentShape = comment.CommentShape;
				method_0(commentShape);
			}
		}
		foreach (object item in arrayList_1)
		{
			Shape shape_ = (Shape)item;
			method_0(shape_);
		}
		string_1 = "vmlDrawing" + Class1618.smethod_80(class1541_0.class1540_0.method_2()) + ".vml";
		string string_2 = "../drawings/" + string_1;
		string_0 = class1541_0.method_22("http://schemas.openxmlformats.org/officeDocument/2006/relationships/vmlDrawing", string_2);
	}

	private void method_0(Shape shape_0)
	{
		byte[] imageData = shape_0.FillFormat.ImageData;
		if (imageData != null)
		{
			Class1357 @class = new Class1357();
			@class.byte_0 = imageData;
			Image image = Image.FromStream(new MemoryStream(imageData));
			@class.string_0 = Class1618.smethod_45("image", class1541_0.class1540_0.method_5(), image.RawFormat);
			@class.object_0 = shape_0;
			arrayList_2.Add(@class);
			@class.string_1 = method_5("http://schemas.openxmlformats.org/officeDocument/2006/relationships/image", "../media/" + @class.string_0, null);
		}
	}

	internal string method_1(Shape shape_0)
	{
		foreach (object item in arrayList_2)
		{
			Class1357 @class = (Class1357)item;
			if (@class.object_0 == shape_0)
			{
				return @class.string_1;
			}
		}
		return null;
	}

	private string method_2(int int_0)
	{
		string text = Class1618.smethod_80(class1541_0.worksheet_0.Index + 1);
		string text2 = text + Class1486.smethod_1(int_0, 4);
		if (class1541_0.method_19())
		{
			int num = 3;
			while (method_3(text2))
			{
				num++;
				text2 = text + Class1486.smethod_1(int_0, num);
			}
		}
		return text2;
	}

	private bool method_3(string string_2)
	{
		ArrayList arrayList_ = class1541_0.worksheet_0.class1557_0.arrayList_6;
		int count = arrayList_.Count;
		int num = 0;
		while (true)
		{
			if (num < count)
			{
				string text = (string)arrayList_[num];
				if (text.IndexOf(string_2) != -1)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal string method_4(string string_2, string string_3)
	{
		string text = "rId" + method_6();
		Class1564 value = new Class1564(text, string_2, string_3, null);
		arrayList_0.Add(value);
		return text;
	}

	internal string method_5(string string_2, string string_3, string string_4)
	{
		string text = "rId" + method_6();
		Class1564 value = new Class1564(text, string_2, string_3, string_4);
		arrayList_0.Add(value);
		return text;
	}

	private int method_6()
	{
		int num = arrayList_0.Count;
		int count = arrayList_0.Count;
		for (int i = 0; i < count; i++)
		{
			Class1564 @class = (Class1564)arrayList_0[i];
			try
			{
				int num2 = Class1618.smethod_87(@class.string_1.Substring(3));
				if (num2 > num)
				{
					num = num2;
				}
			}
			catch
			{
			}
		}
		return num + 1;
	}

	private ArrayList method_7()
	{
		ArrayList arrayList = new ArrayList();
		if (class1541_0 == null)
		{
			return arrayList;
		}
		foreach (Shape item in class1541_0.worksheet_0.method_36())
		{
			if (Class1618.smethod_198(item))
			{
				arrayList.Add(item);
			}
			else
			{
				if (item.MsoDrawingType != MsoDrawingType.Chart)
				{
					continue;
				}
				Chart chart = ((ChartShape)item).Chart;
				if (chart.method_16() == null || chart.method_16().Count <= 0)
				{
					continue;
				}
				foreach (Shape item2 in chart.method_16())
				{
					if (Class1618.smethod_198(item2))
					{
						arrayList.Add(item2);
					}
				}
			}
		}
		return arrayList;
	}
}
