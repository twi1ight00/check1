using System;
using System.Drawing;
using Aspose;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;
using x74500b509de15565;
using xa7850104c8d8c135;

namespace x0097836593a6a96a;

internal abstract class x776d392443cca64d
{
	protected readonly xb0d8039f74776744 x28fcdc775a1d069c;

	private readonly x3fa09e8d7b952fbc x730a3c5f4afd73ef;

	public x3fa09e8d7b952fbc xb444c09fa044bbca => x730a3c5f4afd73ef;

	protected x776d392443cca64d(x3fa09e8d7b952fbc info, xb0d8039f74776744 context)
	{
		x28fcdc775a1d069c = context;
		x730a3c5f4afd73ef = info;
	}

	public static x776d392443cca64d xebcf83b00134300b(byte[] x43e181e083db6cdf, xb0d8039f74776744 x0f7b23d1c393aed9)
	{
		return xebcf83b00134300b(new x3fa09e8d7b952fbc(x43e181e083db6cdf), x0f7b23d1c393aed9);
	}

	public static x776d392443cca64d xebcf83b00134300b(x3fa09e8d7b952fbc x7314c991efe1c392, xb0d8039f74776744 x0f7b23d1c393aed9)
	{
		switch (x7314c991efe1c392.x33bca70acf5ccba8)
		{
		case x3ad1f4cb1f0990ad.xb5fe04c34562f438:
		case x3ad1f4cb1f0990ad.x054b6b6a51ff7486:
			return new x224c7769d37efa9c(x7314c991efe1c392, x0f7b23d1c393aed9);
		case x3ad1f4cb1f0990ad.xd82e588b84205868:
			return new x78da9c3caac1b315(x7314c991efe1c392, x0f7b23d1c393aed9);
		case x3ad1f4cb1f0990ad.x93a6fe984442be6b:
			return new x00baf17d46a2678d(x7314c991efe1c392, x0f7b23d1c393aed9);
		case x3ad1f4cb1f0990ad.x6b99da0700ba955b:
			return new x8d66a93a21740a70(x7314c991efe1c392, x0f7b23d1c393aed9);
		default:
			throw new InvalidOperationException("Unknown metafile type.");
		}
	}

	[JavaThrows(true)]
	public virtual xb8e7e788f6d59708 Play(SizeF size, x6edb191c4eaef585 options)
	{
		if (options.x7f6f31ee939e56c7)
		{
			xb8e7e788f6d59708 result = PlayToVector(size, options);
			if (!x28fcdc775a1d069c.xec8728ceac69f279 || !options.x77e4ea8d21a6ccca)
			{
				return result;
			}
			x95539ce79f3e5432();
		}
		return xe78f78d2a0cdc373(size);
	}

	[JavaThrows(true)]
	protected abstract xb8e7e788f6d59708 PlayToVector(SizeF size, x6edb191c4eaef585 options);

	private xb8e7e788f6d59708 xe78f78d2a0cdc373(SizeF x0ceec69a97f73617)
	{
		xb510a2547ea5f578 xb510a2547ea5f = new xb510a2547ea5f578(x730a3c5f4afd73ef, x28fcdc775a1d069c);
		return xb510a2547ea5f.x0613827d1b6c81c9(x0ceec69a97f73617, x48c97d04abed82b6: false);
	}

	private void x95539ce79f3e5432()
	{
		x28fcdc775a1d069c.x4d2cf6c77ee521cd().xbbf9a1ead81dd3a1(x6d058fdf61831c39.x3d55d2f5d9d21184, x3959df40367ac8a3.x5459fadea977d08d, "Metafile cannot be correctly rendered as vector graphics. Fallback to bitmap rendering will be performed.");
	}
}
