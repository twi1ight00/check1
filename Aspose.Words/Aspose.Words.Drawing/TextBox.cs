using System;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Drawing;

public class TextBox
{
	private readonly x7b71245a33212e76 xc454c03c23d4b4d9;

	public double InternalMarginLeft
	{
		get
		{
			return x4574ea26106f0edb.xa23e6b6c3169521d((int)xfe91eeeafcb3026a(129));
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xae20093bed1e48a8(129, x4574ea26106f0edb.x3aa08882c9feaf96(value));
		}
	}

	public double InternalMarginRight
	{
		get
		{
			return x4574ea26106f0edb.xa23e6b6c3169521d((int)xfe91eeeafcb3026a(131));
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xae20093bed1e48a8(131, x4574ea26106f0edb.x3aa08882c9feaf96(value));
		}
	}

	public double InternalMarginTop
	{
		get
		{
			return x4574ea26106f0edb.xa23e6b6c3169521d((int)xfe91eeeafcb3026a(130));
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xae20093bed1e48a8(130, x4574ea26106f0edb.x3aa08882c9feaf96(value));
		}
	}

	public double InternalMarginBottom
	{
		get
		{
			return x4574ea26106f0edb.xa23e6b6c3169521d((int)xfe91eeeafcb3026a(132));
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xae20093bed1e48a8(132, x4574ea26106f0edb.x3aa08882c9feaf96(value));
		}
	}

	public bool FitShapeToText
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(190);
		}
		set
		{
			xae20093bed1e48a8(190, value);
		}
	}

	public LayoutFlow LayoutFlow
	{
		get
		{
			return (LayoutFlow)xfe91eeeafcb3026a(136);
		}
		set
		{
			xae20093bed1e48a8(136, value);
		}
	}

	public TextBoxWrapMode TextBoxWrapMode
	{
		get
		{
			return (TextBoxWrapMode)xfe91eeeafcb3026a(133);
		}
		set
		{
			xae20093bed1e48a8(133, value);
		}
	}

	internal x69aaa2975337eae6 x69aaa2975337eae6
	{
		get
		{
			return (x69aaa2975337eae6)xfe91eeeafcb3026a(135);
		}
		set
		{
			xae20093bed1e48a8(135, value);
		}
	}

	internal TextBox(x7b71245a33212e76 parent)
	{
		xc454c03c23d4b4d9 = parent;
	}

	private object xfe91eeeafcb3026a(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.xfc928672852cc4c4(xba08ce632055a1d9);
	}

	private void xae20093bed1e48a8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xc454c03c23d4b4d9.x0817d5cde9e19bf6(xba08ce632055a1d9, xbcea506a33cf9111);
	}
}
