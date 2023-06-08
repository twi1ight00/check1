using System;
using System.Collections.Generic;

namespace ns67;

internal abstract class Class3280 : Class3089, ICloneable
{
	internal class Class3376
	{
		private Class3071[] class3071_0;

		private Enum468 enum468_0;

		private Class3377 class3377_0;

		private Struct160 struct160_0;

		private double double_0;

		private double double_1;

		private double double_2;

		public Class3377 ActualBounds => class3377_0;

		public Struct160 Bounds => struct160_0;

		public Enum468 Alignment => enum468_0;

		public double HorizontalLength => double_0;

		public double MaxHeight => double_1;

		public double MaxFontSize => double_2;

		public Class3071[] Contours => class3071_0;

		public Class3376(Enum468 alignment, Class3071[] contours, double maxFontSize)
		{
			class3071_0 = contours;
			enum468_0 = alignment;
			double_2 = maxFontSize;
			method_2();
		}

		public static Class3376 smethod_0(IList<Class3376> items)
		{
			List<Class3071> list = new List<Class3071>();
			Enum468 @enum = Enum468.const_0;
			Enum468 enum2 = ((items.Count > 0) ? items[0].enum468_0 : @enum);
			double num = 0.0;
			foreach (Class3376 item in items)
			{
				list.AddRange(item.class3071_0);
				if (item.enum468_0 != enum2)
				{
					enum2 = @enum;
				}
				if (num < item.double_2)
				{
					num = item.double_2;
				}
			}
			return new Class3376(enum2, list.ToArray(), num);
		}

		public static List<Class3376> smethod_1(IEnumerable<Class3376> items)
		{
			List<Class3376> list = new List<Class3376>();
			foreach (Class3376 item in items)
			{
				list.AddRange(item.method_0());
			}
			return list;
		}

		public List<Class3376> method_0()
		{
			List<Class3376> list = new List<Class3376>();
			if (class3071_0.Length > 0)
			{
				List<Class3071> list2 = new List<Class3071>();
				Class3071 @class = class3071_0[0];
				list2.Add(@class);
				for (int i = 1; i < class3071_0.Length; i++)
				{
					Class3071 class2 = class3071_0[i];
					if (class2.Bounds.Bottom > @class.Bounds.Bottom + class2.Height / 2.0)
					{
						if (list2[list2.Count - 1].TextContourList.ContourList.Count == 0)
						{
							list2.RemoveAt(list2.Count - 1);
						}
						list.Add(new Class3376(enum468_0, list2.ToArray(), double_2));
						list2 = new List<Class3071>();
					}
					list2.Add(class2);
					@class = class2;
				}
				if (list2.Count > 0)
				{
					list.Add(new Class3376(enum468_0, list2.ToArray(), double_2));
				}
			}
			return list;
		}

		public void method_1(Struct159 center, double ratio)
		{
			Class3071[] array = class3071_0;
			foreach (Class3071 @class in array)
			{
				@class.method_0(center, ratio);
			}
			double_2 *= ratio;
			method_2();
		}

		private void method_2()
		{
			class3377_0 = new Class3377(class3071_0);
			double_0 = 0.0;
			double_1 = 0.0;
			if (class3071_0.Length > 0)
			{
				double num = double.MaxValue;
				double num2 = double.MinValue;
				double num3 = double.MaxValue;
				double num4 = double.MinValue;
				Class3071[] array = class3071_0;
				foreach (Class3071 @class in array)
				{
					Struct160 bounds = @class.Bounds;
					num = Math.Min(num, bounds.Left);
					num2 = Math.Max(num2, bounds.Right);
					num3 = Math.Min(num3, bounds.Top);
					num4 = Math.Max(num4, bounds.Bottom);
					double_0 += bounds.Width;
					if (bounds.Height > double_1)
					{
						double_1 = bounds.Height;
					}
				}
				struct160_0 = new Struct160(num, num3, num2, num4);
			}
			else
			{
				struct160_0 = default(Struct160);
			}
		}
	}

	private Class3448 class3448_0;

	internal Class3448 Transform2D
	{
		get
		{
			return class3448_0;
		}
		set
		{
			if (class3448_0 != value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3448_0 = value.method_0();
			}
		}
	}

	public abstract Enum496 ShapeType { get; }

	public static Class3280 smethod_12(Enum496 type)
	{
		return type switch
		{
			Enum496.const_0 => new Class3324(), 
			Enum496.const_1 => new Class3314(), 
			Enum496.const_2 => new Class3318(), 
			Enum496.const_3 => new Class3320(), 
			Enum496.const_4 => new Class3319(), 
			Enum496.const_5 => new Class3310(), 
			Enum496.const_6 => new Class3309(), 
			Enum496.const_7 => new Class3315(), 
			Enum496.const_8 => new Class3306(), 
			Enum496.const_9 => new Class3287(), 
			Enum496.const_10 => new Class3286(), 
			Enum496.const_11 => new Class3289(), 
			Enum496.const_12 => new Class3288(), 
			Enum496.const_13 => new Class3308(), 
			Enum496.const_14 => new Class3307(), 
			Enum496.const_15 => new Class3311(), 
			Enum496.const_16 => new Class3282(), 
			Enum496.const_17 => new Class3313(), 
			Enum496.const_18 => new Class3312(), 
			Enum496.const_19 => new Class3292(), 
			Enum496.const_20 => new Class3291(), 
			Enum496.const_21 => new Class3321(), 
			Enum496.const_22 => new Class3322(), 
			Enum496.const_23 => new Class3298(), 
			Enum496.const_24 => new Class3323(), 
			Enum496.const_25 => new Class3304(), 
			Enum496.const_26 => new Class3296(), 
			Enum496.const_27 => new Class3303(), 
			Enum496.const_28 => new Class3295(), 
			Enum496.const_29 => new Class3305(), 
			Enum496.const_30 => new Class3297(), 
			Enum496.const_31 => new Class3284(), 
			Enum496.const_32 => new Class3283(), 
			Enum496.const_33 => new Class3301(), 
			Enum496.const_34 => new Class3300(), 
			Enum496.const_35 => new Class3302(), 
			Enum496.const_36 => new Class3299(), 
			Enum496.const_37 => new Class3317(), 
			Enum496.const_38 => new Class3316(), 
			Enum496.const_39 => new Class3294(), 
			Enum496.const_40 => new Class3293(), 
			_ => new Class3324(), 
		};
	}

	public static Enum496 smethod_13(string prst)
	{
		return prst switch
		{
			"textArchDown" => Enum496.const_10, 
			"textArchDownPour" => Enum496.const_14, 
			"textArchUp" => Enum496.const_9, 
			"textArchUpPour" => Enum496.const_13, 
			"textButton" => Enum496.const_12, 
			"textButtonPour" => Enum496.const_16, 
			"textCanDown" => Enum496.const_20, 
			"textCanUp" => Enum496.const_19, 
			"textCascadeDown" => Enum496.const_40, 
			"textCascadeUp" => Enum496.const_39, 
			"textChevron" => Enum496.const_5, 
			"textChevronInverted" => Enum496.const_6, 
			"textCircle" => Enum496.const_11, 
			"textCirclePour" => Enum496.const_15, 
			"textCurveDown" => Enum496.const_18, 
			"textCurveUp" => Enum496.const_17, 
			"textDeflate" => Enum496.const_26, 
			"textDeflateBottom" => Enum496.const_28, 
			"textDeflateInflate" => Enum496.const_31, 
			"textDeflateInflateDeflate" => Enum496.const_32, 
			"textDeflateTop" => Enum496.const_30, 
			"textDoubleWave1" => Enum496.const_23, 
			"textFadeDown" => Enum496.const_36, 
			"textFadeLeft" => Enum496.const_34, 
			"textFadeRight" => Enum496.const_33, 
			"textFadeUp" => Enum496.const_35, 
			"textInflate" => Enum496.const_25, 
			"textInflateBottom" => Enum496.const_27, 
			"textInflateTop" => Enum496.const_29, 
			"textNoShape" => Enum496.const_0, 
			"textPlain" => Enum496.const_1, 
			"textRingInside" => Enum496.const_7, 
			"textRingOutside" => Enum496.const_8, 
			"textSlantDown" => Enum496.const_38, 
			"textSlantUp" => Enum496.const_37, 
			"textStop" => Enum496.const_2, 
			"textTriangle" => Enum496.const_3, 
			"textTriangleInverted" => Enum496.const_4, 
			"textWave1" => Enum496.const_21, 
			"textWave2" => Enum496.const_22, 
			"textWave4" => Enum496.const_24, 
			_ => throw new ArgumentOutOfRangeException("prst"), 
		};
	}

	public object Clone()
	{
		return vmethod_1();
	}

	public abstract Class3280 vmethod_1();

	internal Class3069[] method_1(IList<Class3071> contours, Class3450 textBody)
	{
		List<Class3376> list = new List<Class3376>();
		int num = 0;
		Class3451[] paragraphs = textBody.Paragraphs;
		foreach (Class3451 @class in paragraphs)
		{
			List<Class3071> list2 = new List<Class3071>();
			double num2 = 0.0;
			Class3423[] textRuns = @class.TextRuns;
			foreach (Class3423 class2 in textRuns)
			{
				if (class2 is Class3424 class3)
				{
					for (int k = 0; k < class3.TextString.Length; k++)
					{
						list2.Add(contours[num]);
						num++;
					}
					if (class3.RunProperties.FontSize > num2)
					{
						num2 = class3.RunProperties.FontSize;
					}
				}
			}
			if (list2.Count > 0)
			{
				list.Add(new Class3376(@class.Properties.Alignment, list2.ToArray(), num2));
			}
		}
		return vmethod_2(list);
	}

	internal Class3381[] method_2()
	{
		List<Class3062> list = vmethod_3().method_1();
		Class3381[] array = new Class3381[list.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new Class3381(list[i]);
		}
		return array;
	}

	internal abstract Class3069[] vmethod_2(List<Class3376> paragraphs);

	internal abstract Class3340 vmethod_3();

	internal static int[] smethod_14(int paragraphsCount, int guidelinesCount)
	{
		int[] array = new int[guidelinesCount];
		int num = 0;
		for (int i = 0; i < paragraphsCount; i++)
		{
			array[num]++;
			num = ((num + 1 < guidelinesCount) ? (num + 1) : 0);
		}
		return array;
	}

	internal Class3069[] method_3(Class3071[] lists, Class3377 bounds, Class3381 top, Class3381 bottom)
	{
		Class3069[] array = new Class3069[lists.Length];
		for (int i = 0; i < lists.Length; i++)
		{
			Class3030 contourList = lists[i].TextContourList.ContourList;
			Class3030 @class = new Class3030();
			foreach (Class3031 item in contourList)
			{
				Class3031 class2 = new Class3031(item.FillMode, item.Stroke);
				if (item.PointsCount > 0)
				{
					Struct159 firstPoint = item[0];
					int num = (item.IsClosed ? (item.PointsCount + 1) : item.PointsCount);
					for (int j = 1; j < num; j++)
					{
						Struct159 @struct = ((j < item.PointsCount) ? item[j] : item[0]);
						method_4(firstPoint, @struct, top, bottom, bounds, class2);
						firstPoint = @struct;
					}
					if (item.IsClosed)
					{
						class2.Close();
					}
				}
				@class.Add(class2);
			}
			array[i] = new Class3069(@class, lists[i].TextContourList.Properties.method_0());
		}
		return array;
	}

	private void method_4(Struct159 firstPoint, Struct159 secondPoint, Class3381 top, Class3381 bottom, Class3377 bounds, Class3031 output)
	{
		Struct158 @struct = Struct159.smethod_0(secondPoint, firstPoint);
		Struct159 struct2 = new Struct159(firstPoint.X + @struct.Dx / 2.0, firstPoint.Y + @struct.Dy / 2.0);
		Struct159 right = method_5(bounds, firstPoint, top, bottom);
		Struct159 right2 = method_5(bounds, struct2, top, bottom);
		Struct159 struct3 = method_5(bounds, secondPoint, top, bottom);
		Struct158 struct4 = Struct159.smethod_0(struct3, right);
		Struct158 vector = Struct159.smethod_0(struct3, right2);
		if (vector.Norm > 1E-06 && struct4.Norm > 1E-06)
		{
			double num = struct4.method_0(vector);
			if (num < Math.PI / 90.0)
			{
				output.method_0(struct3);
				return;
			}
			method_4(firstPoint, struct2, top, bottom, bounds, output);
			method_4(struct2, secondPoint, top, bottom, bounds, output);
		}
		else
		{
			output.method_0(struct3);
		}
	}

	private Struct159 method_5(Class3377 bounds, Struct159 point, Class3381 topGuideline, Class3381 bottomGuideline)
	{
		Struct159 @struct = new Struct159(Transform2D.Offset.X, Transform2D.Offset.Y);
		double percent = bounds.method_1(point.X);
		double num = bounds.method_2(point.Y);
		Struct159 right = topGuideline.method_2(percent);
		Struct159 left = bottomGuideline.method_2(percent);
		Struct158 struct2 = Struct159.smethod_0(left, right);
		return new Struct159(@struct.X + right.X + struct2.Dx * num, @struct.Y + right.Y + struct2.Dy * num);
	}
}
