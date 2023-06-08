using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ns70;

internal sealed class Class3463 : Class3462
{
	[StructLayout(LayoutKind.Explicit)]
	public class Class3467
	{
		[FieldOffset(0)]
		public int int_0;

		[FieldOffset(4)]
		public int int_1;

		[FieldOffset(8)]
		public int int_2;

		[FieldOffset(12)]
		public short short_0;

		[FieldOffset(14)]
		public short short_1;

		[FieldOffset(16)]
		public int int_3;

		[FieldOffset(20)]
		public int int_4;

		[FieldOffset(24)]
		public int int_5;

		[FieldOffset(28)]
		public int int_6;

		[FieldOffset(32)]
		public int int_7;

		[FieldOffset(36)]
		public int int_8;

		[FieldOffset(40)]
		public int int_9;
	}

	[StructLayout(LayoutKind.Explicit)]
	public class Class3466
	{
		[FieldOffset(0)]
		public ushort ushort_0;

		[FieldOffset(2)]
		public ushort ushort_1;

		[FieldOffset(4)]
		public uint uint_0;

		[FieldOffset(8)]
		public byte byte_0;

		[FieldOffset(9)]
		public byte byte_1;

		[FieldOffset(10)]
		public byte byte_2;

		[FieldOffset(11)]
		public byte byte_3;

		[FieldOffset(12)]
		public byte byte_4;

		[FieldOffset(13)]
		public byte byte_5;

		[FieldOffset(14)]
		public byte byte_6;

		[FieldOffset(15)]
		public byte byte_7;

		[FieldOffset(16)]
		public byte byte_8;

		[FieldOffset(17)]
		public byte byte_9;

		[FieldOffset(18)]
		public byte byte_10;

		[FieldOffset(19)]
		public byte byte_11;

		[FieldOffset(20)]
		public byte byte_12;

		[FieldOffset(21)]
		public byte byte_13;

		[FieldOffset(22)]
		public byte byte_14;

		[FieldOffset(23)]
		public byte byte_15;

		[FieldOffset(24)]
		public byte byte_16;

		[FieldOffset(25)]
		public byte byte_17;

		[FieldOffset(26)]
		public sbyte sbyte_0;

		[FieldOffset(27)]
		public byte byte_18;

		[FieldOffset(28)]
		public uint uint_1;

		[FieldOffset(32)]
		public uint uint_2;

		[FieldOffset(36)]
		public uint uint_3;
	}

	private const string string_0 = "gdi32.dll";

	internal const byte byte_0 = 0;

	internal const byte byte_1 = 1;

	internal const uint uint_0 = 1u;

	internal const uint uint_1 = 2u;

	internal const uint uint_2 = 4u;

	internal const uint uint_3 = 8u;

	internal const uint uint_4 = 16u;

	internal const uint uint_5 = 32u;

	internal const uint uint_6 = 64u;

	internal const uint uint_7 = 128u;

	internal const uint uint_8 = 256u;

	internal const uint uint_9 = 512u;

	internal const uint uint_10 = 1024u;

	internal const uint uint_11 = 2048u;

	internal const uint uint_12 = 4096u;

	internal const uint uint_13 = 8192u;

	internal const sbyte sbyte_0 = 0;

	internal const sbyte sbyte_1 = 1;

	internal const sbyte sbyte_2 = -1;

	public static uint uint_14 = 0u;

	public static uint uint_15 = 1u;

	public static uint uint_16 = 2u;

	public static uint uint_17 = 3u;

	public static uint uint_18 = 4u;

	public static uint uint_19 = 5u;

	public static uint uint_20 = 0u;

	public static uint uint_21 = 1u;

	private Class3463()
	{
	}

	[DllImport("gdi32.dll", SetLastError = true)]
	private static extern int ChoosePixelFormat(IntPtr hDc, [In][MarshalAs(UnmanagedType.LPStruct)] Class3466 ppfd);

	[DllImport("gdi32.dll", SetLastError = true)]
	private static extern int SetPixelFormat(IntPtr hDc, int iPixelFormat, [In][MarshalAs(UnmanagedType.LPStruct)] Class3466 ppfd);

	[DllImport("gdi32.dll", SetLastError = true)]
	private static extern int SwapBuffers(IntPtr hDC);

	[DllImport("gdi32.dll", SetLastError = true)]
	private static extern int BitBlt(IntPtr hDC, int x, int y, int width, int height, IntPtr hDCSource, int sourceX, int sourceY, uint type);

	[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
	private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

	[DllImport("gdi32.dll")]
	private static extern int DeleteObject(IntPtr objectHandle);

	[DllImport("gdi32.dll")]
	private static extern IntPtr CreateDIBSection(IntPtr hdc, [In][MarshalAs(UnmanagedType.LPStruct)] Class3467 pbmi, uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);

	[DllImport("gdi32.dll", SetLastError = true)]
	private static extern IntPtr CreateCompatibleDC(IntPtr hDC);

	[DllImport("gdi32.dll")]
	private static extern bool DeleteDC(IntPtr hDC);

	public static int smethod_1(IntPtr hDC, Class3466 ppfd)
	{
		int num = ChoosePixelFormat(hDC, ppfd);
		Class3462.smethod_0(num != 0);
		return num;
	}

	public static void smethod_2(IntPtr hDC, int iPixelFormat, Class3466 ppfd)
	{
		Class3462.smethod_0(SetPixelFormat(hDC, iPixelFormat, ppfd) != 0);
	}

	public static void smethod_3(IntPtr hDC)
	{
		Class3462.smethod_0(SwapBuffers(hDC) != 0);
	}

	public static void smethod_4(IntPtr hDC, int x, int y, int width, int height, IntPtr hDCSource, int sourceX, int sourceY, uint type)
	{
		Class3462.smethod_0(BitBlt(hDC, x, y, width, height, hDCSource, sourceX, sourceY, type) != 0);
	}

	public static IntPtr smethod_5(IntPtr hdc, IntPtr hgdiobj)
	{
		IntPtr intPtr = SelectObject(hdc, hgdiobj);
		Class3462.smethod_0(intPtr != IntPtr.Zero);
		return intPtr;
	}

	public static void smethod_6(IntPtr objectHandle)
	{
		if (DeleteObject(objectHandle) == 0)
		{
			throw new Win32Exception(1, "The specified handle is not valid or is currently selected into a DC");
		}
	}

	public static IntPtr smethod_7(IntPtr hdc, Class3467 pbmi, uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset)
	{
		IntPtr intPtr = CreateDIBSection(hdc, pbmi, iUsage, out ppvBits, hSection, dwOffset);
		if (intPtr == IntPtr.Zero && ppvBits == IntPtr.Zero)
		{
			throw new Win32Exception(1, "DIB creation failed");
		}
		return intPtr;
	}

	public static IntPtr smethod_8(IntPtr hDC)
	{
		IntPtr intPtr = CreateCompatibleDC(hDC);
		if (intPtr == IntPtr.Zero)
		{
			throw new Win32Exception(1, "CreateCompatibleDC fails");
		}
		return intPtr;
	}

	public static void smethod_9(IntPtr hDC)
	{
		if (!DeleteDC(hDC))
		{
			throw new Win32Exception(1, "DeleteDC fails");
		}
	}
}
