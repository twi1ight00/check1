using System;
using System.Drawing;

namespace ns70;

internal sealed class Class3461 : IDisposable
{
	private bool bool_0;

	private Graphics graphics_0;

	private IntPtr intptr_0 = IntPtr.Zero;

	private IntPtr intptr_1 = IntPtr.Zero;

	private readonly int int_0;

	private readonly int int_1;

	public IntPtr HDC => intptr_0;

	public IntPtr HBitmap => intptr_1;

	public int Width => int_0;

	public int Height => int_1;

	public Class3461(int width, int height)
	{
		if (width <= 0)
		{
			throw new ArgumentOutOfRangeException("width", "Width must be positive int");
		}
		if (height <= 0)
		{
			throw new ArgumentOutOfRangeException("height", "Height must be positive int");
		}
		int_0 = width;
		int_1 = height;
		graphics_0 = Graphics.FromHwnd(IntPtr.Zero);
		IntPtr hdc = graphics_0.GetHdc();
		intptr_0 = Class3463.smethod_8(hdc);
		try
		{
			Class3463.Class3467 @class = new Class3463.Class3467
			{
				int_0 = 40,
				short_1 = 24,
				short_0 = 1,
				int_1 = int_0,
				int_2 = int_1
			};
			intptr_1 = Class3463.smethod_7(intptr_0, @class, Class3463.uint_20, out var _, IntPtr.Zero, 0u);
			try
			{
				Class3463.smethod_5(intptr_0, intptr_1);
				method_1((uint)@class.short_1);
			}
			catch
			{
				Class3463.smethod_6(intptr_1);
				throw;
			}
		}
		catch
		{
			Class3463.smethod_9(intptr_0);
			throw;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~Class3461()
	{
		Dispose(disposing: false);
	}

	public void method_0()
	{
		method_1(24u);
	}

	private void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			if (disposing)
			{
				graphics_0.Dispose();
			}
			if (intptr_1 != IntPtr.Zero)
			{
				Class3463.smethod_6(intptr_1);
				intptr_1 = IntPtr.Zero;
			}
			if (intptr_0 != IntPtr.Zero)
			{
				Class3463.smethod_9(intptr_0);
				intptr_0 = IntPtr.Zero;
			}
			bool_0 = true;
		}
	}

	private void method_1(uint bitCount)
	{
		Class3463.Class3466 @class = new Class3463.Class3466();
		@class.ushort_0 = 40;
		@class.ushort_1 = 1;
		@class.uint_0 = 56u;
		@class.byte_0 = 0;
		@class.byte_1 = (byte)bitCount;
		@class.byte_2 = 0;
		@class.byte_3 = 0;
		@class.byte_4 = 0;
		@class.byte_5 = 0;
		@class.byte_6 = 0;
		@class.byte_7 = 0;
		@class.byte_8 = 0;
		@class.byte_9 = 0;
		@class.byte_10 = 0;
		@class.byte_11 = 0;
		@class.byte_12 = 0;
		@class.byte_13 = 0;
		@class.byte_14 = 0;
		@class.byte_15 = 32;
		@class.byte_16 = 0;
		@class.byte_17 = 0;
		@class.sbyte_0 = 0;
		@class.byte_18 = 0;
		@class.uint_1 = 0u;
		@class.uint_2 = 0u;
		@class.uint_3 = 0u;
		int iPixelFormat = Class3463.smethod_1(intptr_0, @class);
		Class3463.smethod_2(intptr_0, iPixelFormat, @class);
	}
}
