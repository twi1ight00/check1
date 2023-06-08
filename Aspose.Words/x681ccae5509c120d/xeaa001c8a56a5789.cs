using System.IO;
using System.Reflection;
using xa604c4d210ae0581;

namespace x681ccae5509c120d;

[DefaultMember("Item")]
internal class xeaa001c8a56a5789 : xc9072e4c3fa520ad
{
	internal xca838b0f1d157cd8 xe6d4b1b411ed94b5 => (xca838b0f1d157cd8)xe84e6ff66aac2a0e(xc0c4c459c6ccbd00);

	internal xeaa001c8a56a5789()
		: base(30)
	{
	}

	protected override object DoReadItem(BinaryReader reader)
	{
		return new xca838b0f1d157cd8(reader);
	}

	internal void x5f571ea8c74d391b(BinaryReader xe134235b3526fa75, int x10aaa7cdfa38f254, int x961016a387451f05)
	{
		xe134235b3526fa75.BaseStream.Position = x10aaa7cdfa38f254;
		int num = x961016a387451f05 / 18;
		for (int i = 0; i < num; i++)
		{
			this.get_xe6d4b1b411ed94b5(i).x5f571ea8c74d391b(xe134235b3526fa75);
		}
	}

	internal int xbab4a8354252fa3b(BinaryWriter xbdfb620b7167944b)
	{
		int num = (int)xbdfb620b7167944b.BaseStream.Position;
		for (int i = 0; i < base.x23719734cf1f138c; i++)
		{
			this.get_xe6d4b1b411ed94b5(i).xbab4a8354252fa3b(xbdfb620b7167944b);
		}
		return (int)xbdfb620b7167944b.BaseStream.Position - num;
	}
}
