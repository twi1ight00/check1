using System;
using System.IO;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal class xc9072e4c3fa520ad : x6fa6e31d93cf837a, xa38071b52e850907
{
	private const int x40c82871e51036d5 = 4;

	private readonly int x39e46a286f75f41c;

	internal int x437e3b626c0fdd43 => base.x82b0eb36012eef83 * 4 + base.x23719734cf1f138c * x39e46a286f75f41c;

	internal int x917ff080881b369a => x39e46a286f75f41c;

	internal int x6ba3a6a074ca1119 => x39e46a286f75f41c + ((base.x23719734cf1f138c == 0) ? 8 : 4);

	internal xc9072e4c3fa520ad(int itemSize)
	{
		x39e46a286f75f41c = itemSize;
	}

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, x3fdb33c580a0bef3 xe83fbae1e983d207)
	{
		xe134235b3526fa75.BaseStream.Position = xe83fbae1e983d207.xe53f0e68147463d1;
		x759e32a03439237a.x06b0e25aa6ad68a9(xe134235b3526fa75, xe83fbae1e983d207.x04c290dc4d04369c, x39e46a286f75f41c, this, GetType().Name);
	}

	protected virtual object DoReadItem(BinaryReader reader)
	{
		return x39e46a286f75f41c switch
		{
			4 => reader.ReadInt32(), 
			0 => null, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("loboopiobaapjkgpepnpioeafolabocbkjjbloacdohcbjocnnfdbomdnmdehnkeenbfimifampfolggghnghmehillhglcinljihgajblhjgkojclfkdkmkhkdljjklcfbmdkimljpmjegnijnniieobilobicpkdjphgaaaghaefoaeffblcmbmgdcggkcghbdagidkcpd", 1953096082))), 
		};
	}

	private void xb10f2c5426ecd7f6(BinaryReader xe134235b3526fa75, int x10aaa7cdfa38f254, int xca09b6c2b5b18485)
	{
		if (base.x82b0eb36012eef83 == 0)
		{
			xd6b6ed77479ef68c(x10aaa7cdfa38f254);
		}
		xd6b6ed77479ef68c(xca09b6c2b5b18485, DoReadItem(xe134235b3526fa75));
	}

	void xa38071b52e850907.xa6a789f0e88511c3(BinaryReader xe134235b3526fa75, int x10aaa7cdfa38f254, int xca09b6c2b5b18485)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xb10f2c5426ecd7f6
		this.xb10f2c5426ecd7f6(xe134235b3526fa75, x10aaa7cdfa38f254, xca09b6c2b5b18485);
	}

	internal virtual int x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		if (base.x23719734cf1f138c == 0)
		{
			return 0;
		}
		for (int i = 0; i < base.x82b0eb36012eef83; i++)
		{
			xbdfb620b7167944b.Write(xed8a0d4499d6f292(i));
		}
		for (int j = 0; j < base.x23719734cf1f138c; j++)
		{
			if (xe84e6ff66aac2a0e(j) == null)
			{
				continue;
			}
			if (xe84e6ff66aac2a0e(j) is int)
			{
				xbdfb620b7167944b.Write((int)xe84e6ff66aac2a0e(j));
				continue;
			}
			if (xe84e6ff66aac2a0e(j) is xf67718a36ff889c3)
			{
				xf67718a36ff889c3 xf67718a36ff889c4 = (xf67718a36ff889c3)xe84e6ff66aac2a0e(j);
				xf67718a36ff889c4.x6210059f049f0d48(xbdfb620b7167944b);
				continue;
			}
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bdjfmeaggfhgdfogbffhdfmhmpciafkiiebjmdijeepjcdgkkomkhbelablleacmeajmlnpmbchnjconhbfombmommcplakplabagaiabapacbgbnanbmpdcelkckpbdcajdlkpdmogeepnehoefcplfmjcghojgfoahhohhajohcnficomihndjdnkjenbkdmiklhpkbkglmknlememillmamcnkkjnikaopkhofkoonffpdkmpfkdaikkagjbbakibbjpbjigciinchiedneld", 1225677038)));
		}
		return x437e3b626c0fdd43;
	}

	internal void x09663d2eb09f3fd9(int x374ea4fe62468d0f)
	{
		for (int i = 0; i < base.x82b0eb36012eef83; i++)
		{
			x6d93cc54d095824a(i, x374ea4fe62468d0f + xed8a0d4499d6f292(i) * 2);
		}
	}
}
