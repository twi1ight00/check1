using System.Collections;
using System.Drawing;
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using xbe73d5820f7f4ae3;
using xf9a9481c3f63a419;

namespace xfce5b6a304778b89;

internal class xa6dfe060743f7e59
{
	private xf7125312c7ee115c xc0d860684e1ba27c;

	private readonly StringBuilder x800085dd555f7711;

	private readonly ArrayList x89e0b4ecdad90a5c;

	internal xa6dfe060743f7e59()
	{
		x800085dd555f7711 = new StringBuilder();
		x89e0b4ecdad90a5c = new ArrayList();
	}

	internal void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, xeedad81aaed42a76 x789564759d365819)
	{
		xbb857c9fc36f5054.xcbe65b21f4ea2cf5 = 1.0;
		string xa66385d80d4d296f = xe134235b3526fa75.xca994afbcb9073a2.xa66385d80d4d296f;
		Shape shape = new Shape(xe134235b3526fa75.x2c8c6741422a1298);
		x789564759d365819?.xab3af626b1405ee8(shape.xeedad81aaed42a76);
		xc0d860684e1ba27c = new xf7125312c7ee115c();
		xc0d860684e1ba27c.xae20093bed1e48a8(4155, ShapeType.NonPrimitive);
		x3341113d684b115b(xe134235b3526fa75);
		x253dc1c25dfd49a2.x0c1288d16c9571df(xe134235b3526fa75, shape.xf7125312c7ee115c);
		xf0c283250b00d895(xe134235b3526fa75, xa66385d80d4d296f, shape);
		xc0d860684e1ba27c.xab3af626b1405ee8(shape.xf7125312c7ee115c);
		x253dc1c25dfd49a2.xc6b4c0fd353e4c10(shape, (x1ba13e535f55aa54)xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, "graphic", xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true));
		x8b2c3c076d5a7daf.AppendChild(shape);
	}

	private void xf0c283250b00d895(xf871da68decec406 xe134235b3526fa75, string x121383aa64985888, Shape x5770cdefd8931aa9)
	{
		while (xe134235b3526fa75.xca994afbcb9073a2.x152cbadbfa8061b1(x121383aa64985888))
		{
			if (!xe134235b3526fa75.xb18e918c8e329f66(xc0d860684e1ba27c))
			{
				xf871da68decec406.x52b97b00d3a73947(xe134235b3526fa75, x5770cdefd8931aa9);
			}
		}
	}

	private void x3341113d684b115b(xf871da68decec406 xe134235b3526fa75)
	{
		xe134235b3526fa75.xe5ffcf1e3f9bd387 = null;
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		string x8b0a6a8c69ab5cff = "";
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (!xe134235b3526fa75.x42e780a8d918ac91(xe134235b3526fa75.xca994afbcb9073a2, xc0d860684e1ba27c) && !xf871da68decec406.x46e6752379e6650e(xe134235b3526fa75, xc0d860684e1ba27c) && !xf871da68decec406.xec2649804854d946(xe134235b3526fa75, xc0d860684e1ba27c))
			{
				switch (xca994afbcb9073a.xa66385d80d4d296f)
				{
				case "d":
					x6d9c8da6450a47e5(xca994afbcb9073a.xd2f68ee6f47e9dfb);
					x9f5c33e0f81d3687();
					break;
				case "viewBox":
					xf871da68decec406.x08b1f2bf85ce1fc8(xe134235b3526fa75, xca994afbcb9073a.xd2f68ee6f47e9dfb, xbee336e5a17b0d53: false, x74a48429afea3d90: false, xc0d860684e1ba27c);
					break;
				case "transform":
					x8b0a6a8c69ab5cff = xca994afbcb9073a.xd2f68ee6f47e9dfb;
					break;
				}
			}
		}
		xf871da68decec406.xc8cbf0c64adea241(xc0d860684e1ba27c, x8b0a6a8c69ab5cff);
	}

	private static x06e4f09a90ca939a xdb091da38506fa5b(string xcf77fbef31c2d07b)
	{
		int num = xbb857c9fc36f5054.x01c5989f49b62737(xca004f56614e2431.x912616ee70b2d94d(xcf77fbef31c2d07b));
		if (num != int.MinValue)
		{
			return new x06e4f09a90ca939a(num, isFormula: false);
		}
		return new x06e4f09a90ca939a();
	}

	private void x6d9c8da6450a47e5(string xe125219852864557)
	{
		foreach (char c in xe125219852864557)
		{
			x4dd8a59ec8974a5f x4dd8a59ec8974a5f = x0eb9a864413f34de.xa3861736e9040b76(c);
			if (x4dd8a59ec8974a5f != x4dd8a59ec8974a5f.xf6c17f648b65c793)
			{
				x96f40c97d4eb5d47();
				x89e0b4ecdad90a5c.Add(c);
			}
			else if (char.IsDigit(c) || c == '-' || char.IsLetter(c))
			{
				if (c == '-')
				{
					x96f40c97d4eb5d47();
				}
				x800085dd555f7711.Append(c);
			}
			else
			{
				x96f40c97d4eb5d47();
			}
		}
		x96f40c97d4eb5d47();
	}

	private void x96f40c97d4eb5d47()
	{
		string text = x800085dd555f7711.ToString();
		if (text.Length > 0)
		{
			x89e0b4ecdad90a5c.Add(x800085dd555f7711.ToString());
		}
		x800085dd555f7711.Length = 0;
	}

	private void x9f5c33e0f81d3687()
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		x4dd8a59ec8974a5f x4dd8a59ec8974a5f = x4dd8a59ec8974a5f.xf6c17f648b65c793;
		int num = 0;
		x44f2b8bf33b16275 x44f2b8bf33b = new x44f2b8bf33b16275();
		x08d932077485c285 x08d932077485c = new x08d932077485c285();
		char c = 'M';
		x08d932077485c285 xcf79e093dc9efc4b = new x08d932077485c285();
		x08d932077485c285 xcf79e093dc9efc4b2 = new x08d932077485c285();
		while (num < x89e0b4ecdad90a5c.Count)
		{
			if (x89562df66c77cbe7(x89e0b4ecdad90a5c[num]))
			{
				c = (char)x89e0b4ecdad90a5c[num];
				x4dd8a59ec8974a5f = x0eb9a864413f34de.xa3861736e9040b76(c);
				if (x4dd8a59ec8974a5f != x4dd8a59ec8974a5f.x5fd023604497c8ef)
				{
					x44f2b8bf33b = new x44f2b8bf33b16275(x4dd8a59ec8974a5f, 1);
					if (x44f2b8bf33b.x9b6c7f268832a67f() == 0)
					{
						arrayList2.Add(x44f2b8bf33b);
					}
				}
				num++;
			}
			else if (x4dd8a59ec8974a5f != x4dd8a59ec8974a5f.xf6c17f648b65c793 && x4dd8a59ec8974a5f != x4dd8a59ec8974a5f.x5fd023604497c8ef)
			{
				arrayList2.Add(x44f2b8bf33b);
				int num2 = x44f2b8bf33b.x9b6c7f268832a67f();
				for (int i = 0; i < num2; i++)
				{
					x08d932077485c285 x08d932077485c2 = new x08d932077485c285();
					char c2 = char.ToUpper(c);
					if (c2 == 'S' && i == 0)
					{
						x08d932077485c2 = x670340867eb79a8b(x08d932077485c, xcf79e093dc9efc4b);
					}
					else if (c2 == 'T' && i == 0)
					{
						x08d932077485c2 = x670340867eb79a8b(x08d932077485c, xcf79e093dc9efc4b2);
					}
					else
					{
						if (c2 == 'V')
						{
							x08d932077485c2 = new x08d932077485c285(x08d932077485c.x8df91a2f90079e88, x08d932077485c2.xc821290d7ecc08bf);
						}
						else
						{
							x08d932077485c2 = new x08d932077485c285(xdb091da38506fa5b((string)x89e0b4ecdad90a5c[num++]), x08d932077485c2.xc821290d7ecc08bf);
							if (char.IsLower(c))
							{
								x08d932077485c2 = new x08d932077485c285(x08d932077485c2.x8df91a2f90079e88.xd2f68ee6f47e9dfb + x08d932077485c.x8df91a2f90079e88.xd2f68ee6f47e9dfb, x08d932077485c2.xc821290d7ecc08bf.xd2f68ee6f47e9dfb);
							}
						}
						if (c2 == 'H')
						{
							x08d932077485c2 = new x08d932077485c285(x08d932077485c2.x8df91a2f90079e88, x08d932077485c.xc821290d7ecc08bf);
						}
						else
						{
							x08d932077485c2 = new x08d932077485c285(x08d932077485c2.x8df91a2f90079e88, xdb091da38506fa5b((string)x89e0b4ecdad90a5c[num++]));
							if (char.IsLower(c))
							{
								x08d932077485c2 = new x08d932077485c285(x08d932077485c2.x8df91a2f90079e88.xd2f68ee6f47e9dfb, x08d932077485c2.xc821290d7ecc08bf.xd2f68ee6f47e9dfb + x08d932077485c.xc821290d7ecc08bf.xd2f68ee6f47e9dfb);
							}
						}
					}
					if (i == num2 - 1)
					{
						x08d932077485c = x08d932077485c2;
					}
					if (x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.x102c43569e36d6d1)
					{
						if (i == 1)
						{
							xcf79e093dc9efc4b = x08d932077485c2;
						}
					}
					else
					{
						xcf79e093dc9efc4b = x08d932077485c;
					}
					if (x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.xcacbfbb8ebda9581)
					{
						if (i == 0)
						{
							xcf79e093dc9efc4b2 = x08d932077485c2;
						}
					}
					else
					{
						xcf79e093dc9efc4b2 = x08d932077485c;
					}
					arrayList.Add(x08d932077485c2);
				}
			}
			else
			{
				num++;
			}
		}
		if (x44f2b8bf33b.x4dd8a59ec8974a5f != x4dd8a59ec8974a5f.x8ffe90e7fbccfccd)
		{
			arrayList2.Insert(0, new x44f2b8bf33b16275(x4dd8a59ec8974a5f.xaba04beace9e3ba6, 1));
		}
		x08d932077485c285[] array = new x08d932077485c285[arrayList.Count];
		for (int j = 0; j < arrayList.Count; j++)
		{
			array[j] = (x08d932077485c285)arrayList[j];
		}
		x44f2b8bf33b16275[] array2 = new x44f2b8bf33b16275[arrayList2.Count];
		for (int k = 0; k < arrayList2.Count; k++)
		{
			array2[k] = (x44f2b8bf33b16275)arrayList2[k];
		}
		xc0d860684e1ba27c.xae20093bed1e48a8(325, array);
		xc0d860684e1ba27c.xae20093bed1e48a8(326, array2);
	}

	private static x08d932077485c285 x670340867eb79a8b(x08d932077485c285 x8b0308cbfe0a7ecb, x08d932077485c285 xcf79e093dc9efc4b)
	{
		return new x08d932077485c285(new Point(xd4a31b8e0acd0c68(x8b0308cbfe0a7ecb.x8df91a2f90079e88.xd2f68ee6f47e9dfb, xcf79e093dc9efc4b.x8df91a2f90079e88.xd2f68ee6f47e9dfb), xd4a31b8e0acd0c68(x8b0308cbfe0a7ecb.xc821290d7ecc08bf.xd2f68ee6f47e9dfb, xcf79e093dc9efc4b.xc821290d7ecc08bf.xd2f68ee6f47e9dfb)));
	}

	private static int xd4a31b8e0acd0c68(int x2bb5e8d0e89edd5b, int xd0c68d6331c74a24)
	{
		return 2 * x2bb5e8d0e89edd5b - xd0c68d6331c74a24;
	}

	private static bool x89562df66c77cbe7(object xcb61482d958392ca)
	{
		if (xcb61482d958392ca is char)
		{
			return "MmZzLlHhVvCcSsQqTtAa".IndexOf((char)xcb61482d958392ca) != -1;
		}
		return false;
	}
}
