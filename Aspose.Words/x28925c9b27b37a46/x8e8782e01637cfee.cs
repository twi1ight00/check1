using System;
using System.Collections;
using System.IO;
using Aspose;
using Aspose.Words;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x28925c9b27b37a46;

internal class x8e8782e01637cfee
{
	private static readonly object xc000264e5c758a56 = new object();

	private static volatile Hashtable x55da87ce5950987d;

	private static Hashtable x5aa0653817ffcbc1
	{
		get
		{
			if (x55da87ce5950987d == null)
			{
				lock (xc000264e5c758a56)
				{
					if (x55da87ce5950987d == null)
					{
						x55da87ce5950987d = x521235458966bd74();
					}
				}
			}
			return x55da87ce5950987d;
		}
	}

	[JavaConvertCheckedExceptions]
	internal static xf247fba5a716fd2b x986b193abe1e68e5(xd28385f788b65737 x61682528bdc59981)
	{
		if (x5aa0653817ffcbc1.Contains((int)x61682528bdc59981))
		{
			return (xf247fba5a716fd2b)x5aa0653817ffcbc1[(int)x61682528bdc59981];
		}
		throw new InvalidOperationException("Unknown border art.");
	}

	private static Hashtable x521235458966bd74()
	{
		Hashtable hashtable = new Hashtable();
		using Stream stream = xed747ca236d86aa0.xe1cd764b6fb0d6f6("Aspose.Words.Resources.PageBorderArt.Definitions.xml");
		xc1dcd6189d01216e xc1dcd6189d01216e = new xc1dcd6189d01216e(stream);
		while (xc1dcd6189d01216e.x152cbadbfa8061b1("BorderArtDefinitions"))
		{
			xf247fba5a716fd2b xf247fba5a716fd2b2 = new xf247fba5a716fd2b(Convert.ToInt32(xc1dcd6189d01216e.xd68abcd61e368af9("id", "-1")), Convert.ToInt32(xc1dcd6189d01216e.xd68abcd61e368af9("contraction", "0")), Convert.ToInt32(xc1dcd6189d01216e.xd68abcd61e368af9("hexpansion", "0")), Convert.ToInt32(xc1dcd6189d01216e.xd68abcd61e368af9("vexpansion", "0")));
			xf247fba5a716fd2b2.xf95986cc69ab2564(BorderType.Top, x32836ca8baa844bb.x38ced5a01a389303, xc0ef399bd2af9822(xc1dcd6189d01216e.xd68abcd61e368af9("tl", "")));
			xf247fba5a716fd2b2.xf95986cc69ab2564(BorderType.Top, x32836ca8baa844bb.x83e8265cdba541b5, xc0ef399bd2af9822(xc1dcd6189d01216e.xd68abcd61e368af9("t", "")));
			xf247fba5a716fd2b2.xf95986cc69ab2564(BorderType.Top, x32836ca8baa844bb.xed3e432f7c9bf846, xc0ef399bd2af9822(xc1dcd6189d01216e.xd68abcd61e368af9("tr", "")));
			xf247fba5a716fd2b2.xf95986cc69ab2564(BorderType.Left, x32836ca8baa844bb.x83e8265cdba541b5, xc0ef399bd2af9822(xc1dcd6189d01216e.xd68abcd61e368af9("l", "")));
			xf247fba5a716fd2b2.xf95986cc69ab2564(BorderType.Right, x32836ca8baa844bb.x83e8265cdba541b5, xc0ef399bd2af9822(xc1dcd6189d01216e.xd68abcd61e368af9("r", "")));
			xf247fba5a716fd2b2.xf95986cc69ab2564(BorderType.Bottom, x32836ca8baa844bb.x38ced5a01a389303, xc0ef399bd2af9822(xc1dcd6189d01216e.xd68abcd61e368af9("bl", "")));
			xf247fba5a716fd2b2.xf95986cc69ab2564(BorderType.Bottom, x32836ca8baa844bb.x83e8265cdba541b5, xc0ef399bd2af9822(xc1dcd6189d01216e.xd68abcd61e368af9("b", "")));
			xf247fba5a716fd2b2.xf95986cc69ab2564(BorderType.Bottom, x32836ca8baa844bb.xed3e432f7c9bf846, xc0ef399bd2af9822(xc1dcd6189d01216e.xd68abcd61e368af9("br", "")));
			hashtable.Add(xf247fba5a716fd2b2.xea1e81378298fa81, xf247fba5a716fd2b2);
		}
		return hashtable;
	}

	internal static byte[] xc0ef399bd2af9822(string x121383aa64985888)
	{
		try
		{
			using Stream x23cda4cfdf81f2cf = xed747ca236d86aa0.xe1cd764b6fb0d6f6($"Aspose.Words.Resources.PageBorderArt.{x121383aa64985888}");
			xa2745adfabe0c674 x95dac044246123ac = xa2745adfabe0c674.xe6a756f8b9f6fe18(1, 1, 96.0, 96.0);
			return xdd1b8f14cc8ba86d.x300bc69d382eb52c(x0d299f323d241756.xa0aed4cd3b3d5d92(x23cda4cfdf81f2cf), x95dac044246123ac);
		}
		catch
		{
			return new byte[0];
		}
	}
}
