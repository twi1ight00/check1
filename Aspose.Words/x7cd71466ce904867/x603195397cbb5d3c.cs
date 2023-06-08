using System.Collections;
using System.Drawing;
using x4dc96876c552a593;

namespace x7cd71466ce904867;

internal class x603195397cbb5d3c : x6aaf9a29d5bba480
{
	private double x3d8d71f408cb357b;

	private double x8918dc7c534575e5;

	private ArrayList x047f3d74dc5f5da7 = new ArrayList();

	private double xd74c65b8d28b1740;

	private double x7cf290e345b9b3cf;

	private double x7b7c4bf07166b4da;

	public RectangleF x6ae4612a8469678e
	{
		get
		{
			return new RectangleF((float)x8df91a2f90079e88, (float)xc821290d7ecc08bf, (float)xdc1bf80853046136, (float)xb0f146032f47c24e);
		}
		set
		{
			x8df91a2f90079e88 = value.X;
			xc821290d7ecc08bf = value.Y;
			xdc1bf80853046136 = value.Width;
			xb0f146032f47c24e = value.Height;
		}
	}

	public double xb0f146032f47c24e
	{
		get
		{
			return x8918dc7c534575e5;
		}
		set
		{
			x8918dc7c534575e5 = value;
		}
	}

	public double xdc1bf80853046136
	{
		get
		{
			return xd74c65b8d28b1740;
		}
		set
		{
			xd74c65b8d28b1740 = value;
		}
	}

	public double x8df91a2f90079e88
	{
		get
		{
			return x7cf290e345b9b3cf;
		}
		set
		{
			x7cf290e345b9b3cf = value;
		}
	}

	public double xc821290d7ecc08bf
	{
		get
		{
			return x7b7c4bf07166b4da;
		}
		set
		{
			x7b7c4bf07166b4da = value;
		}
	}

	public double x449ad19c79665932 => x3d8d71f408cb357b;

	public void x49babf6761229eb5(x4e65d9f1b1fbe157 x311e7a92306d7199, x7e58bc4f68c02a4e xd4449dd234838d4a)
	{
		x5725b63233877cf4 x5725b63233877cf5 = xd4449dd234838d4a.x25ebf13b3a18c04f(x311e7a92306d7199.x6cee542cebddb262);
		x311e7a92306d7199.xc821290d7ecc08bf = x7b7c4bf07166b4da + x3d8d71f408cb357b + x5725b63233877cf5.x3f80ed349f729542;
		x311e7a92306d7199.x8df91a2f90079e88 = x8df91a2f90079e88;
		if (x047f3d74dc5f5da7.Count == 0)
		{
			x311e7a92306d7199.x8bfe79484ce3a1f2 = false;
		}
		else
		{
			x311e7a92306d7199.x8bfe79484ce3a1f2 = x5725b63233877cf5.xb0f146032f47c24e + x3d8d71f408cb357b > x8918dc7c534575e5;
		}
		x3d8d71f408cb357b += x5725b63233877cf5.x84bbacdc1fc0efd2;
		x047f3d74dc5f5da7.Add(x311e7a92306d7199);
	}

	public void xb6c5870a775295da(double x29a242958ae284ac)
	{
		if (x047f3d74dc5f5da7.Count != 0)
		{
			x3d8d71f408cb357b += x29a242958ae284ac;
		}
	}

	public void xd257a163f3436872(double xfb0f7ad9a3c6ddd5)
	{
		x3d8d71f408cb357b += xfb0f7ad9a3c6ddd5;
	}

	public void xcf7a67f089849fcb(x4e65d9f1b1fbe157 x311e7a92306d7199)
	{
		x047f3d74dc5f5da7.Remove(x311e7a92306d7199);
	}
}
