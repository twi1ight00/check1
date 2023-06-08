using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns67;

internal sealed class Class3070
{
	private readonly List<Class3069> list_0;

	private readonly double double_0;

	private readonly Class3450 class3450_0;

	private readonly Class3448 class3448_0;

	private readonly Class3448 class3448_1;

	public Class3070(Class3450 textBody, Class3448 transform, double flatness)
	{
		class3450_0 = textBody;
		class3448_1 = transform;
		class3448_0 = new Class3448(new Class3456(transform.Offset.X + textBody.Properties.LeftInset, transform.Offset.Y + textBody.Properties.TopInset), new Class3455(transform.Extents.Cx - textBody.Properties.LeftInset - textBody.Properties.RightInset, transform.Extents.Cy - textBody.Properties.TopInset - textBody.Properties.BottomInset));
		double_0 = flatness;
		list_0 = new List<Class3069>();
		method_4();
	}

	public Class3069[] method_0()
	{
		return list_0.ToArray();
	}

	private void method_1(double offsetX, double offsetY, Class3075 builder)
	{
		Class3072[] array = builder.method_0();
		Class3072[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Class3080 @class = (Class3080)array2[i];
			Class3072[] array3 = @class.method_0();
			Class3072[] array4 = array3;
			for (int j = 0; j < array4.Length; j++)
			{
				Class3084 builder2 = (Class3084)array4[j];
				method_3(offsetX + builder.Point.X + @class.Point.X, offsetY + builder.Point.Y + @class.Point.Y, builder2);
			}
		}
	}

	private void method_2(Class3062 drawingPath, Class3406 properties)
	{
		if (drawingPath.PointCount == 0)
		{
			Class3030 contourList = new Class3030();
			list_0.Add(new Class3069(contourList, properties));
			return;
		}
		drawingPath.method_14(class3448_0.Offset.X, class3448_0.Offset.Y, append: false);
		drawingPath.method_12();
		Class3030 contourList2 = smethod_0(drawingPath);
		list_0.Add(new Class3069(contourList2, properties));
	}

	private void method_3(double offsetX, double offsetY, Class3084 builder)
	{
		Class3062 @class = builder.method_0();
		using (new Matrix())
		{
			@class.method_2();
			@class.method_14(offsetX, offsetY, append: false);
			@class.method_12();
			method_2(@class, builder.Properties);
		}
	}

	private void method_4()
	{
		Class3406 defaultProperties = new Class3406();
		bool flag = class3450_0.Properties.TextWarp != null;
		if (class3450_0.PredefinedPaths != null)
		{
			Class3074 @class = new Class3074(class3450_0, class3448_0, defaultProperties);
			list_0.AddRange(@class.method_3());
			if (flag)
			{
				method_5(@class.method_4());
			}
			return;
		}
		Class3083 class2 = new Class3083(class3450_0, class3448_0, defaultProperties);
		Class3072[] array = class2.method_0();
		List<Class3071> list = (flag ? new List<Class3071>() : null);
		Class3072[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Class3082 class3 = (Class3082)array2[i];
			Class3072[] array3 = class3.method_0();
			Class3072[] array4 = array3;
			for (int j = 0; j < array4.Length; j++)
			{
				Class3081 class4 = (Class3081)array4[j];
				double num = class3.Point.X + class4.Point.X;
				double num2 = class3.Point.Y + class4.Point.Y;
				if (class4.BulletBuilder != null)
				{
					method_1(num, num2, class4.BulletBuilder);
				}
				Class3072[] array5 = class4.method_0();
				Class3072[] array6 = array5;
				for (int k = 0; k < array6.Length; k++)
				{
					Class3080 class5 = (Class3080)array6[k];
					Class3072[] array7 = class5.method_0();
					Class3072[] array8 = array7;
					for (int l = 0; l < array8.Length; l++)
					{
						Class3084 class6 = (Class3084)array8[l];
						method_3(num + class5.Point.X, num2 + class5.Point.Y, class6);
						if (flag)
						{
							Struct159 @struct = new Struct159(num + class5.Point.X + class6.Point.X + class3448_0.Offset.X, num2 + class5.Point.Y + class6.Point.Y + class3448_0.Offset.Y);
							list.Add(new Class3071(glyphBoundingBox: new Struct160(@struct.X, @struct.Y, @struct.X + class6.vmethod_0().Cx, @struct.Y - class6.vmethod_0().Cy), list: list_0[list_0.Count - 1]));
						}
					}
				}
			}
		}
		if (flag)
		{
			method_5(list);
		}
	}

	private void method_5(IList<Class3071> contours)
	{
		Class3280 textWarp = class3450_0.Properties.TextWarp;
		if (textWarp != null)
		{
			textWarp.Transform2D = class3448_1;
			Class3069[] collection = textWarp.method_1(contours, class3450_0);
			list_0.Clear();
			list_0.AddRange(collection);
		}
	}

	public static Class3030 smethod_0(Class3062 path)
	{
		Class3030 @class = new Class3030();
		PointF[] pathPoints = path.PathPoints;
		Enum458[] pathTypes = path.PathTypes;
		int num = -1;
		for (int i = 0; i < pathTypes.Length; i++)
		{
			Enum458 @enum = pathTypes[i];
			if ((@enum & Enum458.flag_1) == 0)
			{
				num = i;
			}
			else if ((@enum & Enum458.flag_5) != 0)
			{
				int num2 = i - num + 1;
				Class3031 class2 = new Class3031(Enum492.const_0);
				for (int j = 0; j < num2; j++)
				{
					PointF pointF = pathPoints[num + j];
					class2.method_0(new Struct159(pointF.X, pointF.Y));
				}
				class2.Close();
				@class.Add(class2);
				num = -1;
			}
			else if (Enum458.flag_1 != @enum && (Enum458.flag_1 | Enum458.flag_4 | Enum458.flag_5) != @enum)
			{
				throw new ApplicationException();
			}
		}
		return @class;
	}
}
