using System;
using System.Drawing;
using System.Text;
using Aspose.Words;
using x4adf554d20d941a6;
using x6c95d9cf46ff5f25;

namespace x59d6a4fc5007b7a4;

internal class xbf5b03855bcdbdae : xb850ecb8335a2e09
{
	private const int x01c260fe7a041c97 = 100;

	private xf6937c72cebe4ad1 xf1975e36ef845def;

	protected float x943a73cc1864eec6 = float.MinValue;

	private RectangleF x0e533d951c6fb669 = RectangleF.Empty;

	private RectangleF x28586e25126c7295 = RectangleF.Empty;

	private Border xd21518bde886d5f7;

	private Border x14b90998e3c89383;

	private Border x8ffe12e4b9029415;

	private Border xe6e868c3daa28785;

	private x7bc8e2bdb755f2f0 xcdf827290562fb36;

	internal Shading x554aca059bdf6d48 => x3557aa8566455ba9.x6c51e7de39313dea(x705ed5f9769744e5.x554aca059bdf6d48);

	internal x7bc8e2bdb755f2f0 xa9e41271000a315a
	{
		get
		{
			if (xcdf827290562fb36 == null && x2f51638df5545eb6)
			{
				string description = x0cac9e9885174327(x927910b7aed705e2.x406d8cd2af514771);
				xcdf827290562fb36 = new x7bc8e2bdb755f2f0((int)x705ed5f9769744e5.xdd05b9fa0fd72684, description);
			}
			return xcdf827290562fb36;
		}
	}

	internal bool xd356018c23fff3be
	{
		get
		{
			if (x927910b7aed705e2.xd17e5f6278553255.x92e7e5f35452590d.xa853df7acdb217c8)
			{
				return true;
			}
			if (x927910b7aed705e2.xd17e5f6278553255.x0924cade9dc2d296.xa853df7acdb217c8)
			{
				return true;
			}
			if (x927910b7aed705e2.xd17e5f6278553255.x9d329a00f2c534a8.xa853df7acdb217c8)
			{
				return true;
			}
			if (x0ec18313f761be96.xd17e5f6278553255.x3903fbc9023c861c.xa853df7acdb217c8)
			{
				return true;
			}
			return false;
		}
	}

	internal bool x11e2cd24a3b67965 => x0ec18313f761be96.xd17e5f6278553255.xedd20abd47db3ccc(xcc36986f44d69e8f: true);

	internal TabStopCollection x8df6f6ca274123b0
	{
		get
		{
			TabStopCollection tabStopCollection = new TabStopCollection();
			x41ccdd7753312e4f x41ccdd7753312e4f = x705ed5f9769744e5;
			if (0 < x41ccdd7753312e4f.xf395c3c043d1a6cf)
			{
				int[] xcda2d9a027b80cd = x41ccdd7753312e4f.xcda2d9a027b80cd0;
				float[] array = new float[xcda2d9a027b80cd.Length];
				for (int i = 0; i < xcda2d9a027b80cd.Length; i++)
				{
					array[i] = x4574ea26106f0edb.xc96d70553223ee04(xcda2d9a027b80cd[i]);
				}
				TabLeader[] x3f2d62428d975f = x41ccdd7753312e4f.x3f2d62428d975f86;
				TabAlignment[] xb367d01ee0a9434c = x41ccdd7753312e4f.xb367d01ee0a9434c;
				for (int j = 0; j < x41ccdd7753312e4f.xf395c3c043d1a6cf; j++)
				{
					tabStopCollection.Add(array[j], xb367d01ee0a9434c[j], x3f2d62428d975f[j]);
				}
			}
			return tabStopCollection;
		}
	}

	internal Border x92e7e5f35452590d
	{
		get
		{
			if (xd21518bde886d5f7 == null)
			{
				xd21518bde886d5f7 = x3557aa8566455ba9.x9f6bbfd6a9013899(x927910b7aed705e2.xd17e5f6278553255.x92e7e5f35452590d);
			}
			return xd21518bde886d5f7;
		}
	}

	internal Border x0924cade9dc2d296
	{
		get
		{
			if (x14b90998e3c89383 == null)
			{
				x14b90998e3c89383 = x3557aa8566455ba9.x9f6bbfd6a9013899(x927910b7aed705e2.xd17e5f6278553255.x0924cade9dc2d296);
			}
			return x14b90998e3c89383;
		}
	}

	internal Border x9d329a00f2c534a8
	{
		get
		{
			if (x8ffe12e4b9029415 == null)
			{
				x8ffe12e4b9029415 = x3557aa8566455ba9.x9f6bbfd6a9013899(x927910b7aed705e2.xd17e5f6278553255.x9d329a00f2c534a8);
			}
			return x8ffe12e4b9029415;
		}
	}

	internal Border x3903fbc9023c861c
	{
		get
		{
			if (xe6e868c3daa28785 == null)
			{
				xe6e868c3daa28785 = x3557aa8566455ba9.x9f6bbfd6a9013899(x0ec18313f761be96.xd17e5f6278553255.x3903fbc9023c861c);
			}
			return xe6e868c3daa28785;
		}
	}

	internal RectangleF x007986b943c7e3cf => new RectangleF(x74aeffd7850a8166, xce1f19b805aa290d, x309c670c8878568f, xa2a9e5b20ef4d76a);

	internal virtual float xa2a9e5b20ef4d76a
	{
		get
		{
			if (x0917437609b3cc68())
			{
				x943a73cc1864eec6 = x4574ea26106f0edb.xc96d70553223ee04(x0ec18313f761be96.xc821290d7ecc08bf + x0ec18313f761be96.x4e0afe70adcb4c39.xeebd2917de4cec33 - x927910b7aed705e2.xc821290d7ecc08bf);
			}
			return x943a73cc1864eec6;
		}
	}

	internal float x74aeffd7850a8166
	{
		get
		{
			int x23f780eed403f = x927910b7aed705e2.x8df91a2f90079e88;
			if (!x927910b7aed705e2.x149175c6cbc422b6())
			{
				x23f780eed403f = x927910b7aed705e2.x406d8cd2af514771.xa79651e2f1a1416e.xc0741c7ff92cf1aa + x927910b7aed705e2.xc255c495fd9232ca.x5c392d6ad6fe7e28;
			}
			return x4574ea26106f0edb.xc96d70553223ee04(x23f780eed403f) - x92e7e5f35452590d.x9f8e9e93501d1d42;
		}
	}

	internal virtual float xce1f19b805aa290d => x4574ea26106f0edb.xc96d70553223ee04(x927910b7aed705e2.xc821290d7ecc08bf + x927910b7aed705e2.x4e0afe70adcb4c39.x858cf35bef435420);

	internal float x309c670c8878568f
	{
		get
		{
			int x23f780eed403f = Math.Max(x927910b7aed705e2.x419ba17a5322627b, xfdc1a17f479acc42.x0ec18313f761be96.x419ba17a5322627b);
			return x4574ea26106f0edb.xc96d70553223ee04(x23f780eed403f) - x74aeffd7850a8166 + x0924cade9dc2d296.x9f8e9e93501d1d42;
		}
	}

	internal RectangleF x8d3e220b8546945e
	{
		get
		{
			if (x28586e25126c7295.IsEmpty)
			{
				x28586e25126c7295 = x4afa89fe0635c02e(x14cf9593b86ecbaa: false);
			}
			return x28586e25126c7295;
		}
	}

	internal RectangleF xc95b376fd068d3cb
	{
		get
		{
			if (x0e533d951c6fb669.IsEmpty)
			{
				x0e533d951c6fb669 = x4afa89fe0635c02e(x14cf9593b86ecbaa: true);
			}
			return x0e533d951c6fb669;
		}
	}

	internal bool xe7d4230f1aba8704 => x927910b7aed705e2.xc0e56f2fca892328;

	internal bool x53cdf62e9b7ca051 => x0ec18313f761be96.x55b6066f30988caf;

	internal xf6937c72cebe4ad1 x0ec18313f761be96
	{
		get
		{
			if (xf1975e36ef845def == null)
			{
				xf1975e36ef845def = x927910b7aed705e2.x7467a47ca44f1964();
			}
			return xf1975e36ef845def;
		}
	}

	internal bool x795a7cd03a8ffcb2
	{
		get
		{
			if (xe7d4230f1aba8704)
			{
				if (!xfdc1a17f479acc42.xa79651e2f1a1416e.x00a3b7ca8cc4ec27 && !xfdc1a17f479acc42.xa79651e2f1a1416e.x1534142faaf03859)
				{
					return xfdc1a17f479acc42.xa79651e2f1a1416e.xbed6d6330712f0f2;
				}
				return true;
			}
			return false;
		}
	}

	private bool x2f51638df5545eb6
	{
		get
		{
			bool xc0e56f2fca = x927910b7aed705e2.xc0e56f2fca892328;
			bool result = x705ed5f9769744e5.xdd05b9fa0fd72684 != OutlineLevel.BodyText;
			if (xc0e56f2fca)
			{
				return result;
			}
			return false;
		}
	}

	private x41ccdd7753312e4f x705ed5f9769744e5 => xfdc1a17f479acc42.xa79651e2f1a1416e;

	protected xf6937c72cebe4ad1 x927910b7aed705e2 => (xf6937c72cebe4ad1)x9fb0e9c0b1bdc4b3;

	private x8d9303345f12a846 xfdc1a17f479acc42 => x927910b7aed705e2.x406d8cd2af514771;

	internal xbf5b03855bcdbdae(x398b3bd0acd94b61 part)
		: base(part)
	{
	}

	internal override void x7012609bcdb39574(x3adba2572f6b9747 x672ff13faf031f3d)
	{
		x672ff13faf031f3d.x6967be9680f35960(this);
		bool flag = false;
		xf54a8003057d59ef = x927910b7aed705e2;
		while (!flag && xf54a8003057d59ef != null)
		{
			new x6a53cec2ada67e5c(xf54a8003057d59ef, x9fb0e9c0b1bdc4b3.x2206903f9421fd4b()).x7012609bcdb39574(x672ff13faf031f3d);
			flag = xf54a8003057d59ef.x55b6066f30988caf;
			xf54a8003057d59ef = xf54a8003057d59ef.xf432ece93e450408();
		}
		x672ff13faf031f3d.x93c88bcdc9f7f32e(this);
	}

	protected bool x0917437609b3cc68()
	{
		return x943a73cc1864eec6 < 0f;
	}

	private RectangleF x4afa89fe0635c02e(bool x14cf9593b86ecbaa)
	{
		Rectangle rectangle = (x14cf9593b86ecbaa ? x927910b7aed705e2.xd17e5f6278553255.x1049a67c4c918fe0() : x927910b7aed705e2.xd17e5f6278553255.xe6cffb3d72baa311());
		rectangle = new Rectangle(rectangle.X + x927910b7aed705e2.x8df91a2f90079e88, rectangle.Y + x927910b7aed705e2.xc821290d7ecc08bf, rectangle.Width, rectangle.Height);
		Rectangle rectangle2 = (x14cf9593b86ecbaa ? x0ec18313f761be96.xd17e5f6278553255.x1049a67c4c918fe0() : x0ec18313f761be96.xd17e5f6278553255.xe6cffb3d72baa311());
		rectangle2 = new Rectangle(rectangle2.X + x0ec18313f761be96.x8df91a2f90079e88, rectangle2.Y + x0ec18313f761be96.xc821290d7ecc08bf, rectangle2.Width, rectangle2.Height);
		if (x0ec18313f761be96.xd40b2068334ae37c && x0ec18313f761be96.xc255c495fd9232ca.x954503abc583f675 == x954503abc583f675.x77f91d2130d08599 && (x0ec18313f761be96.xc255c495fd9232ca.x3f424ec11646003b == null || x0ec18313f761be96.xc255c495fd9232ca.x3f424ec11646003b.x7149c962c02931b3))
		{
			int xfe73c0e9e2aad0f = ((x00b4e2c077f699df)x0ec18313f761be96.xc255c495fd9232ca).xfe73c0e9e2aad0f2;
			if (rectangle2.Y + rectangle2.Height + x0ec18313f761be96.x4e0afe70adcb4c39.x853fb708c04424c4 <= xfe73c0e9e2aad0f)
			{
				rectangle2 = new Rectangle(rectangle2.X, rectangle2.Y, rectangle2.Width, xfe73c0e9e2aad0f - rectangle2.Y);
			}
		}
		int left = Math.Min(rectangle.Left, rectangle2.Left);
		int top = rectangle.Top;
		int right = Math.Min(rectangle.Right, rectangle2.Right);
		int bottom = rectangle2.Bottom;
		int xd72444cc04207b = x927910b7aed705e2.x147605d3f215e4c9.xd72444cc04207b76;
		return x4574ea26106f0edb.xc96d70553223ee04(Rectangle.FromLTRB(left, top + xd72444cc04207b, right, bottom + xd72444cc04207b));
	}

	private static string x0cac9e9885174327(x8d9303345f12a846 x2612f62f94df47de)
	{
		x56410a8dd70087c5 x56410a8dd70087c = x2612f62f94df47de.x0eafd527bd1e778e;
		StringBuilder stringBuilder = new StringBuilder();
		while (x56410a8dd70087c != null && x56410a8dd70087c.x406d8cd2af514771 == x2612f62f94df47de.x0eafd527bd1e778e.x406d8cd2af514771)
		{
			switch (x56410a8dd70087c.x5566e2d2acbd1fbe)
			{
			case 9217:
			case 10754:
				stringBuilder.Append(x56410a8dd70087c.xf9ad6fb78355fe13);
				break;
			case 12803:
				stringBuilder.Append(' ');
				break;
			default:
				if (x5566e2d2acbd1fbe.x6634ed9c1dfbdfce(x56410a8dd70087c.x5566e2d2acbd1fbe))
				{
					stringBuilder.Append(' ');
				}
				break;
			}
			x56410a8dd70087c = x56410a8dd70087c.x61712f0b4f5455af;
		}
		return stringBuilder.ToString(0, Math.Min(stringBuilder.Length, 100));
	}
}
