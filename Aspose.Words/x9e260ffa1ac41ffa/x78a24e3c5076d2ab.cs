using System.IO;
using xa604c4d210ae0581;

namespace x9e260ffa1ac41ffa;

internal class x78a24e3c5076d2ab : x25732282434cea28
{
	private class x8e8f6cc6a0756b05 : xf67718a36ff889c3
	{
		private readonly int x0d9772cf77aec2f1;

		internal x8e8f6cc6a0756b05(int wordOffset)
		{
			x0d9772cf77aec2f1 = wordOffset;
		}

		private void x85313d56ab6f266e(BinaryWriter xbdfb620b7167944b)
		{
			xbdfb620b7167944b.Write((byte)x0d9772cf77aec2f1);
		}

		void xf67718a36ff889c3.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
		{
			//ILSpy generated this explicit interface implementation from .override directive in x85313d56ab6f266e
			this.x85313d56ab6f266e(xbdfb620b7167944b);
		}
	}

	internal x78a24e3c5076d2ab()
		: base(1)
	{
	}

	protected override object NewStructure(int lastPXWordOffset)
	{
		return new x8e8f6cc6a0756b05(lastPXWordOffset);
	}
}
