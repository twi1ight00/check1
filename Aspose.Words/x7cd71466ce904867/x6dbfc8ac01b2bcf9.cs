using System.Drawing;
using x4dc96876c552a593;

namespace x7cd71466ce904867;

internal class x6dbfc8ac01b2bcf9 : x4f93a140c903e3c5
{
	private readonly xe9a355a58980e0a4 xd995695f8e3419d6;

	private RectangleF x930e7264e89b1eb5 = default(RectangleF);

	private x603195397cbb5d3c[] x660741034f534cfd;

	private int x88152c2fb71b147e;

	public double x7757bd7d74f2b5d9
	{
		get
		{
			double num = 0.0;
			x603195397cbb5d3c[] array = x660741034f534cfd;
			foreach (x603195397cbb5d3c x603195397cbb5d3c2 in array)
			{
				if (num < x603195397cbb5d3c2.x449ad19c79665932)
				{
					num = x603195397cbb5d3c2.x449ad19c79665932;
				}
			}
			return num;
		}
	}

	public double x884d3da464d53ce7 => x660741034f534cfd[0].xdc1bf80853046136;

	public double x842782b6ef7e2bba => x660741034f534cfd[0].xb0f146032f47c24e;

	public x603195397cbb5d3c[] xbd7bb54d8760ed0a => x660741034f534cfd;

	private x603195397cbb5d3c x6830765b14732e35
	{
		get
		{
			if (x88152c2fb71b147e >= x660741034f534cfd.Length)
			{
				return null;
			}
			return x660741034f534cfd[x88152c2fb71b147e];
		}
	}

	public x6dbfc8ac01b2bcf9(xe9a355a58980e0a4 serviceLocator)
	{
		xd995695f8e3419d6 = serviceLocator;
	}

	public void x20aee281977480cf(x53a4366d160ef67f xe28166f06d2bf011, RectangleF xda73fcb97c77d998)
	{
		x930e7264e89b1eb5 = xe28166f06d2bf011.xa182bedf6256377d.xbe2cb8264b39a622(xda73fcb97c77d998);
		int num = xe28166f06d2bf011.xe7a008202327d76d;
		if (num == 0)
		{
			num = 1;
		}
		double num2 = xe28166f06d2bf011.x1a5b505e78ae10c9;
		double num3 = ((double)x930e7264e89b1eb5.Width - num2 * (double)(num - 1)) / (double)num;
		x660741034f534cfd = new x603195397cbb5d3c[num];
		for (int i = 0; i < num; i++)
		{
			x603195397cbb5d3c x603195397cbb5d3c2 = new x603195397cbb5d3c();
			x603195397cbb5d3c2.xb0f146032f47c24e = x930e7264e89b1eb5.Height;
			x603195397cbb5d3c2.xdc1bf80853046136 = num3;
			x603195397cbb5d3c2.x8df91a2f90079e88 = (double)x930e7264e89b1eb5.X + (num3 + num2) * (double)i;
			x603195397cbb5d3c2.xc821290d7ecc08bf = x930e7264e89b1eb5.Y;
			x660741034f534cfd[i] = x603195397cbb5d3c2;
		}
	}

	public void x49babf6761229eb5(x4e65d9f1b1fbe157 x311e7a92306d7199, x7e58bc4f68c02a4e xd4449dd234838d4a)
	{
		if (x6830765b14732e35 != null)
		{
			x6830765b14732e35.x49babf6761229eb5(x311e7a92306d7199, xd4449dd234838d4a);
			if (x311e7a92306d7199.x8bfe79484ce3a1f2 && x88152c2fb71b147e < x660741034f534cfd.Length - 1)
			{
				x6830765b14732e35.xcf7a67f089849fcb(x311e7a92306d7199);
				x88152c2fb71b147e++;
				x49babf6761229eb5(x311e7a92306d7199, xd4449dd234838d4a);
			}
		}
	}

	public void xb6c5870a775295da(double x29a242958ae284ac)
	{
		if (x6830765b14732e35 != null)
		{
			x6830765b14732e35.xb6c5870a775295da(x29a242958ae284ac);
		}
	}

	public void xd257a163f3436872(double xfb0f7ad9a3c6ddd5)
	{
		if (x6830765b14732e35 != null)
		{
			x6830765b14732e35.xd257a163f3436872(xfb0f7ad9a3c6ddd5);
		}
	}
}
