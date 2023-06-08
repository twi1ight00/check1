using System;
using System.Collections;
using System.Drawing;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x5794c252ba25e723;

namespace Aspose.Words;

[JavaGenericArguments("Iterable<Border>")]
public class BorderCollection : IEnumerable
{
	private class xd7d316c007c4503e : IEnumerator
	{
		private readonly BorderCollection xac8df3ffedaa82be;

		private int x92607c329f3ecad3;

		public object Current => xac8df3ffedaa82be[x92607c329f3ecad3];

		internal xd7d316c007c4503e(BorderCollection borders)
		{
			xac8df3ffedaa82be = borders;
			x92607c329f3ecad3 = -1;
		}

		public bool MoveNext()
		{
			if (x92607c329f3ecad3 >= xac8df3ffedaa82be.Count - 1)
			{
				return false;
			}
			x92607c329f3ecad3++;
			return true;
		}

		public void Reset()
		{
			x92607c329f3ecad3 = -1;
		}
	}

	private readonly x0e9935be205598e7 xc454c03c23d4b4d9;

	public Border this[BorderType borderType]
	{
		get
		{
			object obj = xc454c03c23d4b4d9.x01e813efe52383e6[borderType];
			if (obj == null)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bkaiclhimkoiegfjdlmjdkdkmkkknkblkjilfkpldkgmbjnmniengelnficopijopiapohhpmhopgifabdmahhdbohkbicbcdhicbhpcdhgdmbndkfeemgleefcfjfjfjfaglehgjeogaffhgemhopcibekihebjheijcpojdegkednkcdeljdlldobmpcjmpbanechnmbonhbfofcmomncp", 153124941)));
			}
			int num = (int)obj;
			Border border = (Border)xc454c03c23d4b4d9.x6e9ebce5ff38cae9(num);
			if (border == null)
			{
				border = new Border(xc454c03c23d4b4d9, num);
				xc454c03c23d4b4d9.x039f0f0de50f5575(num, border);
			}
			return border;
		}
	}

	public Border this[int index]
	{
		get
		{
			BorderType borderType = (BorderType)xc454c03c23d4b4d9.x01e813efe52383e6.GetKey(index);
			return this[borderType];
		}
	}

	public Border Left => this[BorderType.Left];

	public Border Right => this[BorderType.Right];

	public Border Top => this[BorderType.Top];

	public Border Bottom => this[BorderType.Bottom];

	public Border Horizontal => this[BorderType.Horizontal];

	public Border Vertical => this[BorderType.Vertical];

	public int Count => xc454c03c23d4b4d9.x01e813efe52383e6.Count;

	public double LineWidth
	{
		get
		{
			return this[0].LineWidth;
		}
		set
		{
			foreach (BorderType key in xc454c03c23d4b4d9.x01e813efe52383e6.GetKeyList())
			{
				if (x11fffe3ee4a02aec(key))
				{
					this[key].LineWidth = value;
				}
			}
		}
	}

	public LineStyle LineStyle
	{
		get
		{
			return this[0].LineStyle;
		}
		set
		{
			foreach (BorderType key in xc454c03c23d4b4d9.x01e813efe52383e6.GetKeyList())
			{
				if (x11fffe3ee4a02aec(key))
				{
					this[key].LineStyle = value;
				}
			}
		}
	}

	public Color Color
	{
		get
		{
			return x63b1a7c31a962459.xc7656a130b2889c7();
		}
		set
		{
			x63b1a7c31a962459 = x26d9ecb4bdf0456d.xcd907c08c553c15c(value);
		}
	}

	internal x26d9ecb4bdf0456d x63b1a7c31a962459
	{
		get
		{
			return this[0].x63b1a7c31a962459;
		}
		set
		{
			foreach (BorderType key in xc454c03c23d4b4d9.x01e813efe52383e6.GetKeyList())
			{
				if (x11fffe3ee4a02aec(key))
				{
					this[key].x63b1a7c31a962459 = value;
				}
			}
		}
	}

	internal bool x227665e444fb500a
	{
		get
		{
			return this[0].x227665e444fb500a;
		}
		set
		{
			foreach (BorderType key in xc454c03c23d4b4d9.x01e813efe52383e6.GetKeyList())
			{
				if (x11fffe3ee4a02aec(key))
				{
					this[key].x227665e444fb500a = value;
				}
			}
		}
	}

	public double DistanceFromText
	{
		get
		{
			return this[0].DistanceFromText;
		}
		set
		{
			foreach (BorderType key in xc454c03c23d4b4d9.x01e813efe52383e6.GetKeyList())
			{
				if (x11fffe3ee4a02aec(key))
				{
					this[key].DistanceFromText = value;
				}
			}
		}
	}

	public bool Shadow
	{
		get
		{
			return this[0].Shadow;
		}
		set
		{
			foreach (BorderType key in xc454c03c23d4b4d9.x01e813efe52383e6.GetKeyList())
			{
				if (x11fffe3ee4a02aec(key))
				{
					this[key].Shadow = value;
				}
			}
		}
	}

	internal bool xa853df7acdb217c8
	{
		get
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Border border = (Border)enumerator.Current;
					if (border.IsVisible)
					{
						return true;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return false;
		}
	}

	internal BorderCollection(x0e9935be205598e7 parent)
	{
		xc454c03c23d4b4d9 = parent;
	}

	internal bool xba03fa6c82ac9b73(BorderType xe6e655492739f7d2)
	{
		return xc454c03c23d4b4d9.x01e813efe52383e6.Contains(xe6e655492739f7d2);
	}

	public void ClearFormatting()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Border border = (Border)enumerator.Current;
				border.ClearFormatting();
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	public IEnumerator GetEnumerator()
	{
		return new xd7d316c007c4503e(this);
	}

	private static bool x11fffe3ee4a02aec(BorderType xe6e655492739f7d2)
	{
		if (xe6e655492739f7d2 != BorderType.DiagonalDown)
		{
			return xe6e655492739f7d2 != BorderType.DiagonalUp;
		}
		return false;
	}
}
