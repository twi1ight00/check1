using System;

namespace x583d72a986201ed7;

internal class x049d57bc3026d28f
{
	private readonly string xed4a7b1500064e12;

	private readonly int x7f3c86b3fa6e7e46;

	private xc987730810b89250 x6e1b1eda820f4841;

	private x02344c8663635c5d x03a697d966a9baa9;

	internal string xf9ad6fb78355fe13 => xed4a7b1500064e12;

	internal int xc0741c7ff92cf1aa => x7f3c86b3fa6e7e46;

	internal xc987730810b89250 x1658a038b1a3cb0a
	{
		get
		{
			return x6e1b1eda820f4841;
		}
		set
		{
			x6e1b1eda820f4841 = value;
		}
	}

	internal x02344c8663635c5d x17dbe5d89173a7b0
	{
		get
		{
			return x03a697d966a9baa9;
		}
		set
		{
			x03a697d966a9baa9 = value;
		}
	}

	internal x049d57bc3026d28f(xc987730810b89250 lineType)
		: this("", 0, lineType)
	{
	}

	internal x049d57bc3026d28f(string text, int leftIndent, xc987730810b89250 lineType)
	{
		if (text == null)
		{
			throw new ArgumentNullException("text");
		}
		x6e1b1eda820f4841 = lineType;
		xed4a7b1500064e12 = text;
		x7f3c86b3fa6e7e46 = leftIndent;
	}
}
