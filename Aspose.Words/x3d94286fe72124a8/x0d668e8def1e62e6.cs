using System.Collections;
using x1c8faa688b1f0b0c;

namespace x3d94286fe72124a8;

internal class x0d668e8def1e62e6
{
	private readonly xb8e7e788f6d59708 x9b1777152cf410e1;

	private readonly int xe701c28126a5083b;

	private readonly ArrayList x8981fd81e0974d02;

	internal x0d668e8def1e62e6(xb8e7e788f6d59708 canvas)
		: this(canvas, 2)
	{
	}

	internal x0d668e8def1e62e6(xb8e7e788f6d59708 canvas, int newPathsMinCount)
	{
		x9b1777152cf410e1 = canvas;
		xe701c28126a5083b = newPathsMinCount;
		x8981fd81e0974d02 = new ArrayList();
	}

	internal void x74ed4bb22f1a8f34(xab391c46ff9a0a38 x2f5729efd2d1a8f4, xab391c46ff9a0a38[] xee75ad616e9ea85f)
	{
		if (xee75ad616e9ea85f.Length >= xe701c28126a5083b)
		{
			x33a82d228a2abd54 x33a82d228a2abd55 = new x33a82d228a2abd54();
			x33a82d228a2abd55.x479977869948f26a = x9b1777152cf410e1.x2ee5ad3d826ed0fe(x2f5729efd2d1a8f4);
			if (x33a82d228a2abd55.x479977869948f26a != -1)
			{
				x33a82d228a2abd55.xaaa120d80a7ca164 = xee75ad616e9ea85f;
				x8981fd81e0974d02.Add(x33a82d228a2abd55);
			}
		}
	}

	internal void x63f57747c3aa8228()
	{
		int num = 0;
		x33a82d228a2abd54[] array = xe68b03450a1a8b0b();
		foreach (x33a82d228a2abd54 x33a82d228a2abd55 in array)
		{
			int num2 = x33a82d228a2abd55.xaaa120d80a7ca164.Length;
			x9b1777152cf410e1.x7121e9e177952651(x33a82d228a2abd55.x479977869948f26a);
			for (int j = 0; j < num2; j++)
			{
				x9b1777152cf410e1.xef23aa45e7612fdd(x33a82d228a2abd55.x479977869948f26a + num, x33a82d228a2abd55.xaaa120d80a7ca164[j]);
			}
			num += num2 - 1;
		}
	}

	private x33a82d228a2abd54[] xe68b03450a1a8b0b()
	{
		x8981fd81e0974d02.Sort();
		return (x33a82d228a2abd54[])x8981fd81e0974d02.ToArray(typeof(x33a82d228a2abd54));
	}
}
