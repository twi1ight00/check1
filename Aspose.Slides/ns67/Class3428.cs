using System;
using System.Collections.Generic;
using System.Drawing;
using ns69;

namespace ns67;

internal sealed class Class3428 : IDisposable
{
	public const double double_0 = 3116.0;

	private double double_1;

	private Interface53 interface53_0;

	private Class3068 class3068_0;

	private readonly List<Class3063> list_0;

	public double Flatness
	{
		get
		{
			return double_1;
		}
		set
		{
			if (double_1 < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_1 = value;
		}
	}

	public Class3428(Interface53 device)
	{
		if (device == null)
		{
			throw new ArgumentNullException("device");
		}
		interface53_0 = device;
		double_1 = 3116.0;
		list_0 = new List<Class3063>();
	}

	public void Dispose()
	{
		interface53_0 = null;
	}

	public void method_0(Class3279 geometry, Class3434 attributes)
	{
		Class3030[] array = geometry.method_9(double_1);
		uint textureId = method_7(attributes, geometry.Transform2D);
		Class3068 attributes2 = new Class3068(attributes, geometry.Transform2D, textureId);
		for (int i = 0; i < array.Length; i++)
		{
			method_5(array[i], attributes2);
		}
	}

	public void method_1(Class3433 shape, Class3434 attributes)
	{
		Class3448 @class = shape.method_2();
		Class3069[] array = shape.TextBody.method_4(@class, double_1);
		Class3069[] array2 = array;
		foreach (Class3069 class2 in array2)
		{
			Class3434 class3 = class2.method_0(attributes);
			uint textureId = method_7(class3, @class);
			method_5(class2.ContourList, new Class3068(class3, @class, textureId));
		}
	}

	public void method_2()
	{
		foreach (Class3063 item in list_0)
		{
			interface53_0.imethod_10();
			try
			{
				Class3372 scene3D = item.RenderingAttributes.Attributes.Scene3D;
				scene3D?.Camera.method_2(interface53_0);
				interface53_0.imethod_14(item.RenderingAttributes.Transform.Offset.X + item.RenderingAttributes.Transform.Extents.Cx / 2.0, 0.0 - item.RenderingAttributes.Transform.Offset.Y - item.RenderingAttributes.Transform.Extents.Cy / 2.0, 0.0);
				scene3D?.Camera.method_1(interface53_0);
				item.vmethod_0(interface53_0);
			}
			finally
			{
				interface53_0.imethod_11();
			}
		}
	}

	private void method_3(Class3068 attributes)
	{
		class3068_0 = attributes;
	}

	private void method_4()
	{
		class3068_0 = null;
	}

	private void method_5(Class3030 flat, Class3068 attributes)
	{
		method_3(attributes);
		try
		{
			method_6(flat.method_0());
		}
		finally
		{
			method_4();
		}
	}

	private void method_6(Class3031[] contours)
	{
		if (contours.Length > 0 && contours[0].FillMode != Enum492.const_5)
		{
			Class3056 triangulation = new Class3056(contours);
			Class3045 @class = new Class3045(triangulation);
			Class3046 class2 = @class.method_0();
			int count = class2.Count;
			for (int i = 0; i < count; i++)
			{
				Class3068 class3 = class3068_0.method_0();
				class3.Attributes.method_2(contours[0].FillMode);
				Class3065 class4 = new Class3065(class3);
				class4.method_1(class2[i]);
				list_0.Add(class4);
			}
		}
		for (int j = 0; j < contours.Length; j++)
		{
			if (contours[j].Stroke)
			{
				Class3064 class5 = new Class3064(class3068_0);
				class5.method_1(contours[j]);
				list_0.Add(class5);
			}
		}
	}

	private uint method_7(Class3434 attr, Class3448 transform)
	{
		uint result = 0u;
		Class3336 @class = attr.ShapeFillMode as Class3336;
		Class3339 class2 = attr.ShapeFillMode as Class3339;
		if (@class == null && class2 == null)
		{
			if (attr.ShapeFillMode is Class3333 fillMode)
			{
				Bitmap bitmap = method_8(fillMode, transform);
				result = interface53_0.imethod_0(bitmap);
			}
			else
			{
				if (!(attr.ShapeFillMode is Class3334 class3))
				{
					throw new NotImplementedException();
				}
				if (class3.Path == Enum460.const_0)
				{
					Bitmap bitmap2 = method_9(class3, transform);
					result = interface53_0.imethod_0(bitmap2);
				}
			}
		}
		else
		{
			result = 0u;
		}
		return result;
	}

	private Bitmap method_8(Class3333 fillMode, Class3448 transform)
	{
		int width = method_10((int)Math.Round((double)interface53_0.Size.Width * transform.Extents.Cx / interface53_0.ModelSize.Cx));
		int height = method_10((int)Math.Round((double)interface53_0.Size.Height * transform.Extents.Cy / interface53_0.ModelSize.Cy));
		Struct161 @struct = new Struct161(width, height);
		using Interface53 @interface = interface53_0.imethod_3(@struct.Width, @struct.Height, 1.0, 1.0);
		@interface.imethod_14(0.5, -0.5, 0.0);
		double num = fillMode.Angle / 60000.0;
		double num2 = 1.0;
		double num3 = fillMode.Angle / 60000.0 * Math.PI / 180.0;
		num2 *= Math.Abs(Math.Cos(num3)) + Math.Abs(Math.Sin(num3));
		if (fillMode.RotateWithShape)
		{
			num += transform.Rotation / 60000.0;
			double num4 = transform.Rotation / 60000.0 * Math.PI / 180.0;
			num2 /= Math.Abs(Math.Cos(num4)) + Math.Abs(Math.Sin(num4));
		}
		@interface.imethod_13(num2);
		@interface.imethod_12(0.0, 0.0, 0.0 - num);
		for (int i = 0; i < fillMode.GradientStopList.Count - 1; i++)
		{
			@interface.imethod_5();
			@interface.imethod_7(fillMode.GradientStopList[i].Color);
			@interface.imethod_8(fillMode.GradientStopList[i].Position / 100.0 - 0.5, -0.5, 0.0);
			@interface.imethod_8(fillMode.GradientStopList[i].Position / 100.0 - 0.5, 0.5, 0.0);
			@interface.imethod_7(fillMode.GradientStopList[i + 1].Color);
			@interface.imethod_8(fillMode.GradientStopList[i + 1].Position / 100.0 - 0.5, 0.5, 0.0);
			@interface.imethod_8(fillMode.GradientStopList[i + 1].Position / 100.0 - 0.5, -0.5, 0.0);
			@interface.imethod_9();
		}
		return @interface.imethod_4();
	}

	private Bitmap method_9(Class3334 fillMode, Class3448 transform)
	{
		int width = method_10((int)Math.Round((double)interface53_0.Size.Width * transform.Extents.Cx / interface53_0.ModelSize.Cx));
		int height = method_10((int)Math.Round((double)interface53_0.Size.Height * transform.Extents.Cy / interface53_0.ModelSize.Cy));
		Struct161 @struct = new Struct161(width, height);
		using Interface53 @interface = interface53_0.imethod_3(@struct.Width, @struct.Height, 1.0, 1.0);
		@interface.imethod_14(0.5, -0.5, 0.0);
		double num = 0.0;
		double num2 = 1.0;
		if (fillMode.RotateWithShape)
		{
			num += transform.Rotation / 60000.0;
			double num3 = transform.Rotation / 60000.0 * Math.PI / 180.0;
			num2 /= Math.Abs(Math.Cos(num3)) + Math.Abs(Math.Sin(num3));
		}
		@interface.imethod_13(num2);
		@interface.imethod_12(0.0, 0.0, 0.0 - num);
		for (int i = 0; i < fillMode.GradientStopList.Count - 1; i++)
		{
			@interface.imethod_5();
			@interface.imethod_7(fillMode.GradientStopList[i].Color);
			@interface.imethod_8(0.5 - fillMode.GradientStopList[i].Position / 100.0, 0.5, 0.0);
			@interface.imethod_8(0.5 - fillMode.GradientStopList[i].Position / 100.0, 0.5 - fillMode.GradientStopList[i].Position / 100.0, 0.0);
			@interface.imethod_7(fillMode.GradientStopList[i + 1].Color);
			@interface.imethod_8(0.5 - fillMode.GradientStopList[i + 1].Position / 100.0, 0.5 - fillMode.GradientStopList[i + 1].Position / 100.0, 0.0);
			@interface.imethod_8(0.5 - fillMode.GradientStopList[i + 1].Position / 100.0, 0.5, 0.0);
			@interface.imethod_9();
			@interface.imethod_5();
			@interface.imethod_7(fillMode.GradientStopList[i].Color);
			@interface.imethod_8(0.5, 0.5 - fillMode.GradientStopList[i].Position / 100.0, 0.0);
			@interface.imethod_8(0.5 - fillMode.GradientStopList[i].Position / 100.0, 0.5 - fillMode.GradientStopList[i].Position / 100.0, 0.0);
			@interface.imethod_7(fillMode.GradientStopList[i + 1].Color);
			@interface.imethod_8(0.5 - fillMode.GradientStopList[i + 1].Position / 100.0, 0.5 - fillMode.GradientStopList[i + 1].Position / 100.0, 0.0);
			@interface.imethod_8(0.5, 0.5 - fillMode.GradientStopList[i + 1].Position / 100.0, 0.0);
			@interface.imethod_9();
		}
		return @interface.imethod_4();
	}

	private int method_10(int extent)
	{
		int num = 2;
		for (int i = 1; i <= 11; i++)
		{
			num = 1 << i;
			if (num > extent)
			{
				break;
			}
		}
		if (num > 2048)
		{
			num = 2048;
		}
		return num;
	}
}
