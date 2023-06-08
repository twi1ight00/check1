using System;
using System.Diagnostics;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

public class TextColumn
{
	private int xd74c65b8d28b1740;

	private int xa0a9a799418687e8;

	public double Width
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2(xd74c65b8d28b1740);
		}
		set
		{
			if (0.0 > value)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			int num = x4574ea26106f0edb.x88bf16f2386d633e(value);
			xd74c65b8d28b1740 = num;
		}
	}

	public double SpaceAfter
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2(xa0a9a799418687e8);
		}
		set
		{
			if (0.0 > value)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			int num = x4574ea26106f0edb.x88bf16f2386d633e(value);
			xa0a9a799418687e8 = num;
		}
	}

	internal int x7219de950d4b708a
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

	internal int xbe8b68828bd16a4b
	{
		get
		{
			return xa0a9a799418687e8;
		}
		set
		{
			xa0a9a799418687e8 = value;
		}
	}

	internal TextColumn()
	{
	}

	internal TextColumn x8b61531c8ea35b85()
	{
		return (TextColumn)MemberwiseClone();
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void x466dd296f7338c95(params object[] xcd31b50c43a96e21)
	{
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void xcbdf0bfb4ca95676(params object[] xcd31b50c43a96e21)
	{
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void x7d47e950edb3a736(params object[] xcd31b50c43a96e21)
	{
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void x7869748cc09722f7(params object[] xcd31b50c43a96e21)
	{
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void x0ea5334e913cd72c(params object[] xcd31b50c43a96e21)
	{
	}
}
