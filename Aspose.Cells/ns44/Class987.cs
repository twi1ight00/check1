using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Cells;
using ns16;
using ns18;
using ns2;
using ns22;

namespace ns44;

internal class Class987 : Class984
{
	internal IconSet iconSet_0;

	internal Class1658 class1658_0;

	internal Cell cell_0;

	internal CellArea cellArea_0;

	internal static Class746 class746_0;

	private static Hashtable hashtable_0;

	public Class987(IconSet iconSet_1, Class1658 class1658_1, Cell cell_1, CellArea cellArea_1)
	{
		if (class746_0 == null)
		{
			class746_0 = Class746.Read(Class1028.smethod_0("Aspose.Cells.StyleObject.ConditionStyle.IconImages.zip"));
			hashtable_0 = new Hashtable();
		}
		iconSet_0 = iconSet_1;
		class1658_0 = class1658_1;
		cell_0 = cell_1;
		cellArea_0 = cellArea_1;
	}

	private Image method_0(IconSetType iconSetType_0)
	{
		Image image = (Image)hashtable_0[iconSetType_0];
		lock (hashtable_0)
		{
			if (image == null)
			{
				Class744 @class = class746_0.method_38(Class1130.ToString(iconSetType_0) + ".png");
				BinaryReader binaryReader = new BinaryReader(class746_0.method_39(@class));
				byte[] array = new byte[(int)@class.Size];
				binaryReader.Read(array, 0, array.Length);
				MemoryStream stream = new MemoryStream(array);
				image = Image.FromStream(stream);
				hashtable_0[iconSetType_0] = image;
			}
		}
		return image;
	}

	private Class465 method_1(IconSetType iconSetType_0, int int_0)
	{
		Image image = method_0(iconSetType_0);
		Bitmap bitmap = new Bitmap(16, 16);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(image, new Rectangle(0, 0, 16, 16), new Rectangle(0, int_0 * 24, 16, 16), GraphicsUnit.Pixel);
		graphics.Dispose();
		MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, ImageFormat.Png);
		return Class465.smethod_0(new PointF(0f, 0f), new SizeF(12f, 12f), memoryStream);
	}

	private int method_2()
	{
		ArrayList arrayList = new ArrayList();
		try
		{
			foreach (ConditionalFormattingValue cfvo in iconSet_0.Cfvos)
			{
				if (cfvo.method_6() != null)
				{
					object value = Class984.Calculate(cell_0, cfvo, cellArea_0, class1658_0);
					arrayList.Add(value);
				}
			}
			int num = iconSet_0.Cfvos.Count - 1;
			foreach (ConditionalFormattingValue cfvo2 in iconSet_0.Cfvos)
			{
				double num2 = (double)arrayList[num];
				if (cell_0.method_20() != Enum199.const_7 && cell_0.method_20() != Enum199.const_6)
				{
					if (cfvo2.IsGTE)
					{
						if (cell_0.DoubleValue >= num2)
						{
							return num;
						}
					}
					else if (!(cell_0.DoubleValue <= num2))
					{
						return num;
					}
					num--;
					continue;
				}
				return -1;
			}
		}
		catch
		{
			return -1;
		}
		return 0;
	}

	public override Class454 vmethod_0(RectangleF rectangleF_0, double[] double_0, TextAlignmentType textAlignmentType_0)
	{
		int count = iconSet_0.Cfvos.Count;
		int num = method_2();
		if (num == -1)
		{
			return null;
		}
		if (!iconSet_0.Reverse)
		{
			num = count - 1 - num;
		}
		Class465 @class = null;
		if (iconSet_0.Type == IconSetType.CustomSet)
		{
			if (iconSet_0.CfIcons[num].Type == IconSetType.None)
			{
				@class = null;
			}
			else
			{
				iconSet_0.Type = iconSet_0.CfIcons[num].Type;
				@class = method_1(iconSet_0.Type, num);
			}
		}
		else
		{
			@class = method_1(iconSet_0.Type, num);
		}
		Class454 class2 = new Class454();
		Class454 class3 = new Class454();
		if (@class != null)
		{
			class3.Add(@class);
			float num2 = (float)Math.Min(double_0[0], double_0[1]);
			float num3 = 0f;
			float dx = rectangleF_0.Left;
			num3 = textAlignmentType_0 switch
			{
				TextAlignmentType.Top => rectangleF_0.Top, 
				TextAlignmentType.Center => (rectangleF_0.Top + rectangleF_0.Bottom) / 2f - 6f * num2, 
				_ => rectangleF_0.Bottom - 12f * num2 - 1f, 
			};
			if (!iconSet_0.ShowValue)
			{
				dx = rectangleF_0.Left + rectangleF_0.Width / 2f - 6f * num2;
			}
			class3.vmethod_1(new Matrix(num2, 0f, 0f, num2, dx, num3));
			class2.vmethod_2(new Class458(rectangleF_0));
			class2.Add(class3);
		}
		return class2;
	}

	public override bool vmethod_1()
	{
		return iconSet_0.ShowValue;
	}
}
