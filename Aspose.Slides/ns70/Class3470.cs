using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using ns67;

namespace ns70;

internal sealed class Class3470 : IDisposable, Interface53
{
	private const int int_0 = 9144000;

	private const int int_1 = 6858000;

	private const int int_2 = 3;

	private static Class3470 class3470_0;

	private bool bool_0;

	private readonly Class3469 class3469_0;

	private Struct161 struct161_0;

	private Class3455 class3455_0;

	private readonly int int_3;

	public Struct161 Size => struct161_0;

	public Class3455 ModelSize => class3455_0;

	public Class3470(int width, int height, double clientWidth, double clientHeight, int smooth)
	{
		int_3 = smooth;
		struct161_0 = new Struct161(width, height);
		class3455_0 = new Class3455(clientWidth, clientHeight);
		class3469_0 = new Class3469(width * int_3, height * int_3);
		method_4();
	}

	public Class3470(int width, int height, double clientWidth, double clientHeight)
		: this(width, height, clientWidth, clientHeight, 3)
	{
	}

	public Class3470(int width, int height, int smooth)
		: this(width, height, 9144000.0, 6858000.0, smooth)
	{
	}

	public Class3470(int width, int height)
		: this(width, height, 9144000.0, 6858000.0, 3)
	{
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~Class3470()
	{
		Dispose(disposing: false);
	}

	public uint imethod_0(Bitmap bitmap)
	{
		smethod_0(this);
		uint[] array = new uint[1];
		class3469_0.method_41(1, array);
		class3469_0.method_5(3553u, array[0]);
		class3469_0.method_146(3553u, 10240u, 9729f);
		class3469_0.method_146(3553u, 10241u, 9729f);
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
		class3469_0.method_145(3553u, 0, 6408, bitmap.Width, bitmap.Height, 0, 32993u, 5121u, bitmapData.Scan0);
		bitmap.UnlockBits(bitmapData);
		return array[0];
	}

	public void imethod_1(uint id)
	{
		smethod_0(this);
		uint[] array = new uint[1] { id };
		class3469_0.method_5(3553u, array[0]);
	}

	public void imethod_2(double x, double y)
	{
		smethod_0(this);
		class3469_0.method_139((float)x, (float)y);
	}

	public Interface53 imethod_3(int width, int height, double modelWidth, double modelHeight)
	{
		return new Class3470(width, height, modelWidth, modelHeight, int_3);
	}

	public Bitmap imethod_4()
	{
		smethod_0(this);
		class3469_0.method_2();
		Bitmap bitmap = class3469_0.method_0();
		if (1 == int_3)
		{
			return bitmap;
		}
		try
		{
			return method_9(bitmap);
		}
		finally
		{
			bitmap.Dispose();
		}
	}

	public void imethod_5()
	{
		smethod_0(this);
		class3469_0.method_4(9u);
	}

	public void imethod_6()
	{
		smethod_0(this);
		class3469_0.method_4(4u);
	}

	public void imethod_9()
	{
		smethod_0(this);
		class3469_0.method_24();
	}

	public void imethod_7(Class3453 color)
	{
		smethod_0(this);
		class3469_0.method_10(color.Red, color.Green, color.Blue, color.Alpha);
	}

	public void imethod_8(double x, double y, double z)
	{
		smethod_0(this);
		class3469_0.method_155(x, 0.0 - y, z);
	}

	public void imethod_10()
	{
		smethod_0(this);
		class3469_0.method_78(5889u);
		class3469_0.method_101();
		class3469_0.method_78(5888u);
		class3469_0.method_101();
	}

	public void imethod_11()
	{
		smethod_0(this);
		class3469_0.method_78(5889u);
		class3469_0.method_97();
		class3469_0.method_78(5888u);
		class3469_0.method_97();
	}

	public void method_0(double x, double y, double z)
	{
		smethod_0(this);
	}

	public void imethod_12(double longitude, double latitude, double revolution)
	{
		smethod_0(this);
		class3469_0.method_117(latitude, 1.0, 0.0, 0.0);
		class3469_0.method_117(longitude, 0.0, -1.0, 0.0);
		double[] array = method_2();
		double x = 0.0 - (array[0] * array[12] + array[1] * array[13] + array[2] * array[14]);
		double y = 0.0 - (array[4] * array[12] + array[5] * array[13] + array[6] * array[14]);
		double z = 0.0 - (array[8] * array[12] + array[9] * array[13] + array[10] * array[14]);
		class3469_0.method_117(revolution, x, y, z);
	}

	public void imethod_13(double ratio)
	{
		smethod_0(this);
		class3469_0.method_120(ratio, ratio, ratio);
	}

	public void imethod_14(double x, double y, double z)
	{
		smethod_0(this);
		class3469_0.method_150(x, y, z);
	}

	public void imethod_15(double q, double f)
	{
		smethod_0(this);
		method_5(q, f);
	}

	public void imethod_16()
	{
		smethod_0(this);
		method_6();
	}

	public void imethod_17(double fov)
	{
		smethod_0(this);
		double fov2 = fov / 2.0 * (ModelSize.Cx / ModelSize.Cy);
		method_7(fov2);
	}

	internal double[] method_1()
	{
		smethod_0(this);
		double[] array = new double[16];
		class3469_0.method_44(2983u, array);
		return array;
	}

	internal double[] method_2()
	{
		smethod_0(this);
		double[] array = new double[16];
		class3469_0.method_44(2982u, array);
		return array;
	}

	internal void method_3(double[] matrix)
	{
		for (int i = 0; i < 4; i++)
		{
		}
	}

	private void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			if (disposing)
			{
				class3469_0.Dispose();
			}
			bool_0 = true;
		}
	}

	private void method_4()
	{
		smethod_0(this);
		class3469_0.method_21(3008u);
		class3469_0.method_21(3042u);
		class3469_0.method_21(3553u);
		class3469_0.method_21(2929u);
		class3469_0.method_16(519u);
		class3469_0.method_49(3152u, 4354u);
		class3469_0.method_159(0, 0, class3469_0.Width, class3469_0.Height);
		class3469_0.method_78(5890u);
		class3469_0.method_63();
		class3469_0.method_78(5889u);
		class3469_0.method_63();
		class3469_0.method_78(5888u);
		class3469_0.method_63();
		method_6();
		class3469_0.method_8(1f, 1f, 1f, 0f);
		class3469_0.method_9(1.0);
		class3469_0.Clear(16640u);
	}

	private void method_5(double q, double f)
	{
		double[] array = new double[16]
		{
			1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0,
			1.0, 0.0, 0.0, 0.0, 0.0, 0.0
		};
		array[8] = 0.0 - Math.Cos(q);
		array[9] = 0.0 - Math.Cos(f);
		double[] m = array;
		method_6();
		class3469_0.method_78(5889u);
		class3469_0.method_79(m);
	}

	private void method_6()
	{
		smethod_0(this);
		class3469_0.method_78(5889u);
		class3469_0.method_63();
		class3469_0.method_88((0.0 - ModelSize.Cx) / 2.0, ModelSize.Cx / 2.0, (0.0 - ModelSize.Cy) / 2.0, ModelSize.Cy / 2.0, double.MinValue, double.MaxValue);
		method_8(90.0);
	}

	private void method_7(double fov)
	{
		smethod_0(this);
		class3469_0.method_78(5889u);
		class3469_0.method_63();
		class3469_0.method_92(fov, (double)class3469_0.Width / (double)class3469_0.Height, 0.1, ModelSize.Cy + 0.1);
		method_8(fov);
	}

	private void method_8(double fov)
	{
		smethod_0(this);
		class3469_0.method_78(5888u);
		class3469_0.method_63();
		double num = fov * Math.PI / 180.0;
		if (num < 0.1)
		{
			num = 0.1;
		}
		double eyez = ModelSize.Cy * Math.Cos(num / 2.0) / (2.0 * Math.Sin(num / 2.0));
		class3469_0.method_65(ModelSize.Cx / 2.0, 0.0 - ModelSize.Cy / 2.0, eyez, ModelSize.Cx / 2.0, 0.0 - ModelSize.Cy / 2.0, 0.0, 0.0, 1.0, 0.0);
	}

	private Bitmap method_9(Bitmap src)
	{
		Bitmap bitmap = new Bitmap(src.Width / int_3, src.Height / int_3, src.PixelFormat);
		try
		{
			using Graphics graphics = Graphics.FromImage(bitmap);
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			Rectangle srcRect = new Rectangle(0, 0, src.Width, src.Height);
			Rectangle destRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
			graphics.DrawImage(src, destRect, srcRect, GraphicsUnit.Pixel);
			return bitmap;
		}
		catch
		{
			bitmap.Dispose();
			throw;
		}
	}

	private static void smethod_0(Class3470 device)
	{
		if (device != class3470_0)
		{
			device.class3469_0.method_1();
			class3470_0 = device;
		}
	}
}
