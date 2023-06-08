using System;
using System.Drawing.Imaging;
using System.IO;
using x5794c252ba25e723;
using x74500b509de15565;
using xa7850104c8d8c135;
using xf9a9481c3f63a419;

namespace x24e0e4e48dc84bd8;

internal class x05ec9e59d7d139e6
{
	private readonly x28a5d52551b64191 x7450cc1e48712286;

	private readonly x4e88096751fad171 xd995695f8e3419d6;

	public x05ec9e59d7d139e6(x28a5d52551b64191 reader, x4e88096751fad171 serviceLocator)
	{
		x7450cc1e48712286 = reader;
		xd995695f8e3419d6 = serviceLocator;
	}

	public x273fb960e2b0a823 x264f3cba2f0b02e2(long x6de0d334b172ed56)
	{
		x7450cc1e48712286.ReadInt32();
		return (x874b9bde02b36555)x7450cc1e48712286.ReadInt32() switch
		{
			x874b9bde02b36555.x0d6939474a8d8900 => null, 
			x874b9bde02b36555.xaae8f5887b316f39 => xbeb18aad14874d11(x6de0d334b172ed56), 
			x874b9bde02b36555.x7b46136fc4b577e4 => xa4699527f1298389(x6de0d334b172ed56), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	private x02fc88fbf71cd2d5 xbeb18aad14874d11(long x6de0d334b172ed56)
	{
		int x9b0739496f8b = x7450cc1e48712286.ReadInt32();
		int x4d5aabc7a55b12ba = x7450cc1e48712286.ReadInt32();
		int x0053b35d1b88b = x7450cc1e48712286.ReadInt32();
		PixelFormat xe794eba09b6f3cf = (PixelFormat)x7450cc1e48712286.ReadInt32();
		return (x1c4d7b462cb03acd)x7450cc1e48712286.ReadInt32() switch
		{
			x1c4d7b462cb03acd.x2a965d88e4d98d31 => new x02fc88fbf71cd2d5(xff23d92e8fcb47ca(x9b0739496f8b, x4d5aabc7a55b12ba, x0053b35d1b88b, xe794eba09b6f3cf)), 
			x1c4d7b462cb03acd.x7021bbb7e5f3cfcf => new x02fc88fbf71cd2d5(x5eaed1a69d3bdfa9(x6de0d334b172ed56)), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	private byte[] x5eaed1a69d3bdfa9(long x6de0d334b172ed56)
	{
		return x7450cc1e48712286.ReadBytes((int)(x6de0d334b172ed56 - x7450cc1e48712286.BaseStream.Position));
	}

	private byte[] xff23d92e8fcb47ca(int x9b0739496f8b5475, int x4d5aabc7a55b12ba, int x0053b35d1b88b761, PixelFormat xe794eba09b6f3cf9)
	{
		x26d9ecb4bdf0456d[] palette = null;
		if ((xe794eba09b6f3cf9 & PixelFormat.Indexed) == PixelFormat.Indexed)
		{
			palette = xb1da0e4f9c7ede73();
		}
		int count = x4d5aabc7a55b12ba * x0053b35d1b88b761;
		byte[] bytes = x7450cc1e48712286.ReadBytes(count);
		using x3cd5d648729cd9b6 x3cd5d648729cd9b = new x3cd5d648729cd9b6(x9b0739496f8b5475, x4d5aabc7a55b12ba, x0053b35d1b88b761, xe794eba09b6f3cf9, bytes, palette);
		using MemoryStream memoryStream = new MemoryStream();
		x3cd5d648729cd9b.xccd8261f31df114c(memoryStream);
		memoryStream.Position = 0L;
		return memoryStream.ToArray();
	}

	private x26d9ecb4bdf0456d[] xb1da0e4f9c7ede73()
	{
		x7450cc1e48712286.ReadInt32();
		int num = x7450cc1e48712286.ReadInt32();
		x26d9ecb4bdf0456d[] array = new x26d9ecb4bdf0456d[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = x7450cc1e48712286.x458cbe2343cf2fba();
		}
		return array;
	}

	private x11d3005e3db787c9 xa4699527f1298389(long x465cc4aa9686e5ef)
	{
		x15e3f5f8a0a3fb3b x15e3f5f8a0a3fb3b = (x15e3f5f8a0a3fb3b)x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.ReadInt32();
		int num = (int)(x465cc4aa9686e5ef - x7450cc1e48712286.BaseStream.Position);
		byte[] array;
		if (x15e3f5f8a0a3fb3b == x15e3f5f8a0a3fb3b.x054b6b6a51ff7486)
		{
			array = x12355ba38b0d4d70(num);
			if (array == null)
			{
				return null;
			}
		}
		else
		{
			array = x7450cc1e48712286.ReadBytes(num);
		}
		return new x11d3005e3db787c9(array, x15e3f5f8a0a3fb3b, xd995695f8e3419d6);
	}

	private byte[] x12355ba38b0d4d70(int xff884decc91dea16)
	{
		if (xff884decc91dea16 < 24)
		{
			return null;
		}
		using MemoryStream memoryStream = new MemoryStream(xff884decc91dea16 - 2);
		byte[] array = x7450cc1e48712286.ReadBytes(22);
		memoryStream.Write(array, 0, array.Length);
		x7450cc1e48712286.ReadBytes(2);
		byte[] array2 = x7450cc1e48712286.ReadBytes(xff884decc91dea16 - 22 - 2);
		memoryStream.Write(array2, 0, array2.Length);
		return memoryStream.ToArray();
	}
}
