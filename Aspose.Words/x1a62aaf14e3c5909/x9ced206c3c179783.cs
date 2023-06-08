using System.IO;
using x011d489fb9df7027;

namespace x1a62aaf14e3c5909;

internal class x9ced206c3c179783 : x21ad3b7fe343bc74, x663fe87979a30296
{
	internal x9ced206c3c179783()
		: base(x773fe540042dad03.x66105e422ac8a42a)
	{
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		base.DoWrite(writer);
		base.x1ea60bde2b5d0d28.x9834ddb0e0bd5996 = base.xf2453c298c5de6f5.Count;
	}

	private x6299a07c6a18ef52 x19cdbfe8a5805dce(int x1f6ee650d037e627)
	{
		for (int i = 0; i < base.xd44988f225497f3a; i++)
		{
			xddf6304144fd3863 xddf6304144fd3864 = base.xf2453c298c5de6f5.get_xe6d4b1b411ed94b5(i);
			if (xddf6304144fd3864 is xccdb3c81ecbef978)
			{
				xccdb3c81ecbef978 xccdb3c81ecbef979 = (xccdb3c81ecbef978)xddf6304144fd3864;
				if (xccdb3c81ecbef979.x3290a7e57100eb12 == x1f6ee650d037e627)
				{
					return xccdb3c81ecbef979.x865b320f557323c1();
				}
			}
		}
		return null;
	}

	x6299a07c6a18ef52 x663fe87979a30296.x53610ed4674cd9ba(int x1f6ee650d037e627)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x19cdbfe8a5805dce
		return this.x19cdbfe8a5805dce(x1f6ee650d037e627);
	}

	private void x33af365c7c769a58(int x1f6ee650d037e627, x6299a07c6a18ef52 x248a09993cacc1b3)
	{
		int ruleId = base.xd44988f225497f3a + 1;
		xccdb3c81ecbef978 value = new xccdb3c81ecbef978(ruleId, x1f6ee650d037e627, x248a09993cacc1b3);
		base.xf2453c298c5de6f5.Add(value);
	}

	void x663fe87979a30296.x6ed23a925c03438a(int x1f6ee650d037e627, x6299a07c6a18ef52 x248a09993cacc1b3)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x33af365c7c769a58
		this.x33af365c7c769a58(x1f6ee650d037e627, x248a09993cacc1b3);
	}
}
