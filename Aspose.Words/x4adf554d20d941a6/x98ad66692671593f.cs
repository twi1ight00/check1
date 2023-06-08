using System;
using Aspose.Words;
using x13f1efc79617a47b;

namespace x4adf554d20d941a6;

internal class x98ad66692671593f : x56410a8dd70087c5
{
	private readonly int x8cf825d90be23d37;

	internal override int x5566e2d2acbd1fbe => x8cf825d90be23d37;

	internal override int x1be93eed8950d961 => 1;

	internal override string xf9ad6fb78355fe13 => xd1fe14c0474a355a();

	internal override int x887b872a95caaab5
	{
		get
		{
			if (int.MinValue == x7f664a1135192acf)
			{
				switch (x5566e2d2acbd1fbe)
				{
				case 10768:
					x7f664a1135192acf = base.x705ed5f9769744e5.xc2d4efc42998d87b.x8e6657c75f309f30("—");
					break;
				case 10769:
					x7f664a1135192acf = base.x705ed5f9769744e5.xc2d4efc42998d87b.x8e6657c75f309f30("–");
					break;
				case 10770:
					x7f664a1135192acf = base.x705ed5f9769744e5.xc2d4efc42998d87b.x8e6657c75f309f30("—") / 4;
					break;
				case 9747:
					x7f664a1135192acf = base.x705ed5f9769744e5.xc2d4efc42998d87b.x8e6657c75f309f30(ControlChar.x3e1feffd8ca6feb2);
					break;
				default:
					return base.x887b872a95caaab5;
				}
				x7f664a1135192acf = base.x705ed5f9769744e5.x7537b54a407680bd(x7f664a1135192acf, 1);
			}
			return x7f664a1135192acf;
		}
	}

	internal bool xd27838d20b491bbe
	{
		get
		{
			if (11284 != x5566e2d2acbd1fbe && 11285 != x5566e2d2acbd1fbe)
			{
				return 9238 == x5566e2d2acbd1fbe;
			}
			return true;
		}
	}

	internal x98ad66692671593f(int spanType)
	{
		x8cf825d90be23d37 = spanType;
		if (spanType == 11799)
		{
			x887b872a95caaab5 = 0;
		}
	}

	internal override x56410a8dd70087c5 xa9d7e8f6fbdcbcfc(x56410a8dd70087c5 x7d95d971d8923f4c)
	{
		if (x7d95d971d8923f4c == null)
		{
			x7d95d971d8923f4c = new x98ad66692671593f(x5566e2d2acbd1fbe);
		}
		return base.xa9d7e8f6fbdcbcfc(x7d95d971d8923f4c);
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x0f76d7593841d24e(this);
	}

	private string xd1fe14c0474a355a()
	{
		return x5566e2d2acbd1fbe switch
		{
			9238 => "-", 
			11799 => "-", 
			11284 => "—", 
			11285 => "–", 
			10768 => "\u2003", 
			10769 => "\u2002", 
			10770 => "\u2005", 
			10782 => "\u3000", 
			9747 => ControlChar.x3e1feffd8ca6feb2, 
			9752 => "\u200c", 
			9753 => "\u200d", 
			9754 => "\u200e", 
			9755 => "\u200f", 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ojhmamomfmfnnkmnfldopkkohkbpagipalppdlgaeknagjebaklbkjcclejcmjadojhdcjodeifekeme", 952747861))), 
		};
	}
}
