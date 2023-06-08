using System;
using System.Collections;
using Aspose.Words.Tables;

namespace x2a6f63b6650e76c4;

internal abstract class x4e68fc46f3a05e16 : IEnumerator
{
	protected readonly xd554b53e829d5f97 x4517c2b411ea1d52;

	protected xe02d79c539b6382d xc83d0e6d4611cafd;

	private Cell x8739fb53143d56e8;

	public object Current => x8739fb53143d56e8;

	protected x4e68fc46f3a05e16(xd554b53e829d5f97 range)
	{
		x4517c2b411ea1d52 = range;
		xc83d0e6d4611cafd = x4517c2b411ea1d52.x89f700c5ff3d93e4.x8b61531c8ea35b85();
	}

	public static x4e68fc46f3a05e16 x8506c44a27b96f94(xd554b53e829d5f97 x9b10ace6509508c0)
	{
		x4e68fc46f3a05e16 result = null;
		switch (x9b10ace6509508c0.xdbfa333b4cd503e0)
		{
		case xb8f8d187f6793877.x2e8310e038e73798:
		case xb8f8d187f6793877.x7af9190cf6099399:
			result = new x886615a98e7e709b(x9b10ace6509508c0);
			break;
		case xb8f8d187f6793877.x72d92bd1aff02e37:
		case xb8f8d187f6793877.x419ba17a5322627b:
			result = new x096ed875f2aef681(x9b10ace6509508c0);
			break;
		default:
			x360ab359eefb8af4();
			break;
		}
		return result;
	}

	protected static void x360ab359eefb8af4()
	{
		throw new InvalidOperationException("Unknown cell enumeration direction.");
	}

	public bool MoveNext()
	{
		bool flag;
		do
		{
			flag = MoveToNextCell();
			x8739fb53143d56e8 = (flag ? xc83d0e6d4611cafd.x11db8fc7f469a2fc : null);
		}
		while (flag && x4e9d836334ed9885(x8739fb53143d56e8));
		return flag;
	}

	private static bool x4e9d836334ed9885(Cell xe6de5e5fa2d44af5)
	{
		if (xe6de5e5fa2d44af5.xf8cef531dae89ea3.x1a1dda35b3ae703d != CellMerge.Previous)
		{
			return xe6de5e5fa2d44af5.xf8cef531dae89ea3.x338a5e6ab7c5595e == CellMerge.Previous;
		}
		return true;
	}

	protected abstract bool MoveToNextCell();

	public void Reset()
	{
		xc83d0e6d4611cafd = x4517c2b411ea1d52.x89f700c5ff3d93e4.x8b61531c8ea35b85();
		x8739fb53143d56e8 = null;
	}
}
