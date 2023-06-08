using System;
using System.Collections;
using x32a884d842a34446;
using xb3013071794e5415;
using xcc8a79815d76af85;

namespace xad5c68c1ad3b0224;

internal class x6128243c276d529b
{
	private ArrayList x98da5b0e998c9be8 = new ArrayList();

	private Hashtable xfdc8c7089cdfb246 = new Hashtable();

	private xb2e8360ba85c2d52 xbf29a65d7269c9e2;

	private xa4d912a00c540cf0 x2c9b21f64c8361c0;

	private xbc46977eebea4733 xda54f2210ded5b25;

	internal ArrayList x4cb4f5636323b916 => x98da5b0e998c9be8;

	internal xb2e8360ba85c2d52 x1d122b11a35a0e78
	{
		get
		{
			return xbf29a65d7269c9e2;
		}
		set
		{
			xbf29a65d7269c9e2 = value;
		}
	}

	internal xa4d912a00c540cf0 xb7ae55095fddecd9
	{
		get
		{
			return x2c9b21f64c8361c0;
		}
		set
		{
			x2c9b21f64c8361c0 = value;
		}
	}

	internal xbc46977eebea4733 xff13b489d81606b6
	{
		get
		{
			if (xda54f2210ded5b25 == null)
			{
				xda54f2210ded5b25 = new xbc46977eebea4733();
			}
			return xda54f2210ded5b25;
		}
	}

	internal bool xc1e4f3262e31a5bc => xfdc8c7089cdfb246.Count > 0;

	internal void x18e36e2c1b210e57(xf6f80e59810bad00 x5f12ae7e2f404c29)
	{
		x5f12ae7e2f404c29.x40f19e37287f753b(this);
		xfdc8c7089cdfb246[x5f12ae7e2f404c29.xb1cd0e7571a46f8e] = x5f12ae7e2f404c29;
	}

	internal void x7326b83dea8a55f8(x958ddf7e6db1ce94 xe640ebcce83ddadc)
	{
		xe640ebcce83ddadc.x40f19e37287f753b(this);
		x98da5b0e998c9be8.Add(xe640ebcce83ddadc);
	}

	internal xf6f80e59810bad00 xa91684dc1f1e4fe8(int xe093f46dbfbdd01e)
	{
		return (xf6f80e59810bad00)xfdc8c7089cdfb246[xe093f46dbfbdd01e];
	}

	internal void xd22d4131e7740788()
	{
		foreach (x958ddf7e6db1ce94 item in x4cb4f5636323b916)
		{
			if (!(item is x4457da8976f5f7bc))
			{
				continue;
			}
			x4457da8976f5f7bc x4457da8976f5f7bc2 = (x4457da8976f5f7bc)item;
			foreach (x9b87766ad1dbe8d6 item2 in item.xc869533ad93d98d3)
			{
				x4457da8976f5f7bc2.x47443c66c2e1bad9.x2797b8054a5b30a6(item2.x3440cb7904436598, item2.x2205bab75ecf5743);
			}
			x6332e4343519e4e6 x6332e4343519e4e = xfd079739c176c3fc(item);
			x4457da8976f5f7bc2.xd14c2707620ef55a.x2797b8054a5b30a6(x6332e4343519e4e, x6332e4343519e4e.x6b73aa01aa019d3a.x2205bab75ecf5743);
		}
	}

	private static x6332e4343519e4e6 xfd079739c176c3fc(x958ddf7e6db1ce94 xe640ebcce83ddadc)
	{
		x1c0d56aa74903bbc x1c0d56aa74903bbc = (x1c0d56aa74903bbc)xe640ebcce83ddadc.x1c0c32c5e4d010d3.x4ff37084a5d7d57f(x2c127adefb5db3a3.x1c0d56aa74903bbc);
		float[] array = new float[xe640ebcce83ddadc.x28627c25cb262062];
		string x92f10ef6823bd0cb = xe640ebcce83ddadc.x21ad465cfac3f62e.x141ab7d3c1198e04.x6b73aa01aa019d3a.xfc954f23e7c18656;
		switch (x1c0d56aa74903bbc)
		{
		case x1c0d56aa74903bbc.x4f7bed84dc733f96:
			array = x318f74746d616ef0.xfdf7ff990b986a85(xe640ebcce83ddadc);
			break;
		case x1c0d56aa74903bbc.x7b3f79b8ae65a772:
			array[0] = 0f;
			array[^1] = 0.9f;
			x92f10ef6823bd0cb = "0%";
			break;
		default:
		{
			float num = 0f;
			float num2 = 0f;
			foreach (x9b87766ad1dbe8d6 item in xe640ebcce83ddadc.xc869533ad93d98d3)
			{
				for (int i = 0; i < array.Length; i++)
				{
					x86270791cf6a92b9 x86270791cf6a92b = item.x141ab7d3c1198e04.x2206903f9421fd4b(i);
					if (x86270791cf6a92b != null)
					{
						num = Math.Min(x86270791cf6a92b.FloatValue, num);
						num2 = Math.Max(x86270791cf6a92b.FloatValue, num2);
					}
				}
			}
			array[0] = num;
			array[^1] = num2;
			break;
		}
		}
		return x97b336bb370a6f1f(array, x92f10ef6823bd0cb);
	}

	private static x6332e4343519e4e6 x97b336bb370a6f1f(float[] x0788cd5a9865fc16, string x92f10ef6823bd0cb)
	{
		x6332e4343519e4e6 x6332e4343519e4e = new x6332e4343519e4e6();
		x6332e4343519e4e.x6b73aa01aa019d3a = new xecb835beef9d8f87(xd620087af5172910.xdad37f621665da16, isCache: false);
		x6332e4343519e4e.x6b73aa01aa019d3a.x2205bab75ecf5743 = x0788cd5a9865fc16.Length;
		for (int i = 0; i < x0788cd5a9865fc16.Length; i++)
		{
			x6332e4343519e4e.x6b73aa01aa019d3a.x2f72b9643ccd1483(new x8feaf55aff422186(i, x0788cd5a9865fc16[i], x92f10ef6823bd0cb));
		}
		return x6332e4343519e4e;
	}
}
