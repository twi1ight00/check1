using System;
using System.IO;
using x6c95d9cf46ff5f25;

namespace x09d959ca29199776;

internal class xfb5add3858def3a0
{
	public static byte[] x239fffc1037a80f3(byte[] x4a3f0a05c02f235f)
	{
		return x239fffc1037a80f3(x4a3f0a05c02f235f, x86852e28e292b333.x02d77aa3fd584291);
	}

	private static byte[] x239fffc1037a80f3(byte[] x4a3f0a05c02f235f, x86852e28e292b333 x272bc993a9d89cb6)
	{
		if (x4a3f0a05c02f235f == null || x4a3f0a05c02f235f.Length == 0)
		{
			throw new ArgumentNullException("data");
		}
		using MemoryStream stream = new MemoryStream(x4a3f0a05c02f235f);
		x05cddb129b0360cd x05cddb129b0360cd = new x05cddb129b0360cd(stream, useMsbFirstBitOrdering: true);
		bool flag = false;
		if (x272bc993a9d89cb6 == x86852e28e292b333.x02d77aa3fd584291)
		{
			flag = x05cddb129b0360cd.xa1e7dc86736d5ffd();
		}
		int x64f5c06260fe128f = (int)x05cddb129b0360cd.x59692b33f32fe96f(24);
		byte[] array = x5b4a12948bad8876(x05cddb129b0360cd, x64f5c06260fe128f);
		if (flag)
		{
			return xa423fea9cfb435eb.xf76803be5e9ee2aa(array);
		}
		return array;
	}

	private static byte[] x5b4a12948bad8876(x05cddb129b0360cd xe134235b3526fa75, int x64f5c06260fe128f)
	{
		if (x64f5c06260fe128f == 0)
		{
			return xcd4bd3abd72ff2da.x2b0797e1bb4e840a;
		}
		using MemoryStream memoryStream = new MemoryStream(x64f5c06260fe128f);
		xa07b20c560e88b89 xa07b20c560e88b90 = new xa07b20c560e88b89(x64f5c06260fe128f);
		while (memoryStream.Position < x64f5c06260fe128f)
		{
			int num = xa07b20c560e88b90.xebcf3366938d31ee.xe692a3d77ab7e374(xe134235b3526fa75);
			if (num < 256)
			{
				memoryStream.WriteByte((byte)num);
				continue;
			}
			if (num == xa07b20c560e88b90.x3202b46cb7745349)
			{
				byte value = x0ba9a4cb3535460b(xa07b20c560e88b90, memoryStream, 2);
				memoryStream.WriteByte(value);
				continue;
			}
			if (num == xa07b20c560e88b90.x79e977c66a0ee274)
			{
				byte value2 = x0ba9a4cb3535460b(xa07b20c560e88b90, memoryStream, 4);
				memoryStream.WriteByte(value2);
				continue;
			}
			if (num == xa07b20c560e88b90.x2b2d19e5041097b5)
			{
				byte value3 = x0ba9a4cb3535460b(xa07b20c560e88b90, memoryStream, 6);
				memoryStream.WriteByte(value3);
				continue;
			}
			int num2 = x866bd376701ef7ba(xa07b20c560e88b90, xe134235b3526fa75, num);
			int num3 = xf8153f2372812ac3(xa07b20c560e88b90, xe134235b3526fa75, num);
			if (num3 >= 512)
			{
				num2++;
			}
			byte[] array = x9e201968fa67ccf9(xa07b20c560e88b90, memoryStream, num3 + num2 - 1, num2);
			memoryStream.Write(array, 0, array.Length);
		}
		return memoryStream.ToArray();
	}

	private static byte x0ba9a4cb3535460b(xa07b20c560e88b89 x0f7b23d1c393aed9, Stream xcf18e5243f8d5fd3, int x374ea4fe62468d0f)
	{
		byte[] array = x9e201968fa67ccf9(x0f7b23d1c393aed9, xcf18e5243f8d5fd3, x374ea4fe62468d0f, 1);
		return array[0];
	}

	private static byte[] x9e201968fa67ccf9(xa07b20c560e88b89 x0f7b23d1c393aed9, Stream xcf18e5243f8d5fd3, int x374ea4fe62468d0f, int x961016a387451f05)
	{
		int num = x0f7b23d1c393aed9.x2f23ffd1bb98f036.Length;
		if (xcf18e5243f8d5fd3.Position - x374ea4fe62468d0f < -num)
		{
			throw new InvalidOperationException("Invalid copy item offset.");
		}
		if (x961016a387451f05 > x374ea4fe62468d0f)
		{
			throw new InvalidOperationException("Invalid copy item length.");
		}
		byte[] array = new byte[x961016a387451f05];
		long num2 = xcf18e5243f8d5fd3.Position - x374ea4fe62468d0f;
		if (num2 < 0)
		{
			long num3 = num + num2;
			long length = Math.Min(num - num3, x961016a387451f05);
			Array.Copy(x0f7b23d1c393aed9.x2f23ffd1bb98f036, num3, array, 0L, length);
		}
		if (num2 + x961016a387451f05 > 0)
		{
			long num4 = Math.Max(0L, num2);
			int num5 = (int)(num2 + x961016a387451f05 - num4);
			byte[] sourceArray = x3d0024323e3ea163(xcf18e5243f8d5fd3, num4, num5);
			Array.Copy(sourceArray, 0, array, x961016a387451f05 - num5, num5);
		}
		return array;
	}

	private static byte[] x3d0024323e3ea163(Stream xcf18e5243f8d5fd3, long x572f24abeb0300ea, int x961016a387451f05)
	{
		long position = xcf18e5243f8d5fd3.Position;
		byte[] array = new byte[x961016a387451f05];
		xcf18e5243f8d5fd3.Position = x572f24abeb0300ea;
		xcf18e5243f8d5fd3.Read(array, 0, x961016a387451f05);
		xcf18e5243f8d5fd3.Position = position;
		return array;
	}

	private static int x866bd376701ef7ba(xa07b20c560e88b89 x0f7b23d1c393aed9, x05cddb129b0360cd xe134235b3526fa75, int xc1db5dbaf009ebd2)
	{
		int num = (xc1db5dbaf009ebd2 - 256) % 8;
		int num2 = 0;
		while (true)
		{
			num2 <<= 2;
			num2 += num & 3;
			if ((num & 4) == 0)
			{
				break;
			}
			num = x0f7b23d1c393aed9.xbd794880cc56fc6a.xe692a3d77ab7e374(xe134235b3526fa75);
		}
		return num2 + 2;
	}

	private static int xf8153f2372812ac3(xa07b20c560e88b89 x0f7b23d1c393aed9, x05cddb129b0360cd xe134235b3526fa75, int xc1db5dbaf009ebd2)
	{
		int num = (xc1db5dbaf009ebd2 - 256) / 8 + 1;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			int num3 = x0f7b23d1c393aed9.x22fb50187bc072a8.xe692a3d77ab7e374(xe134235b3526fa75);
			num2 <<= 3;
			num2 += num3;
		}
		return num2 + 1;
	}
}
