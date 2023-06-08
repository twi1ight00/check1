using System.Collections;
using System.IO;
using System.Text;
using x13f1efc79617a47b;

namespace x1a62aaf14e3c5909;

internal class xef64b8221aa2a96c : xddf6304144fd3863
{
	private int x4016138d7353cc02;

	private int x8e41272c5e3d35ea;

	private int x83b1f032d0833ad8;

	private ArrayList x03e33bab05c4e7ef = new ArrayList();

	internal int xe712fb8c17028f72
	{
		get
		{
			return x4016138d7353cc02;
		}
		set
		{
			x4016138d7353cc02 = value;
		}
	}

	internal int x45856a8054f10613
	{
		get
		{
			return x8e41272c5e3d35ea;
		}
		set
		{
			x8e41272c5e3d35ea = value;
		}
	}

	internal int xf1233101d2dcf572
	{
		get
		{
			return x83b1f032d0833ad8;
		}
		set
		{
			x83b1f032d0833ad8 = value;
		}
	}

	internal ArrayList x55cb50b5c23ddd7c => x03e33bab05c4e7ef;

	internal xef64b8221aa2a96c()
		: base(x773fe540042dad03.x6da9472bbc4fce2c, 0)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0}\n", base.ToString());
		stringBuilder.AppendFormat(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("eoclopjlepammohmcnomdofnhpmngldoepkogkbpnkipimppkogagjnahiebkklbkmcccmjcolademhdijodbmfeemmekldfnlkfaibgoligbhpgklghggnhhfeihilijjcjpijjljaknihkigokbjflejmlkidmnikmafbnoiincepnkigogdnohcepielpdhcapfjachabbghbdgobjffccdmclfddofkdefbehfiekbpeifgfnanfefegonkg", 1357623953)), x4016138d7353cc02, x03e33bab05c4e7ef.Count, x8e41272c5e3d35ea, x83b1f032d0833ad8);
		for (int i = 0; i < x03e33bab05c4e7ef.Count; i++)
		{
			stringBuilder.AppendFormat("{0}\n", x03e33bab05c4e7ef[i].ToString());
		}
		return stringBuilder.ToString();
	}

	protected override void DoRead(BinaryReader reader)
	{
		x4016138d7353cc02 = reader.ReadInt32();
		int num = reader.ReadInt32() - 1;
		x8e41272c5e3d35ea = reader.ReadInt32();
		x83b1f032d0833ad8 = reader.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			x03e33bab05c4e7ef.Add(new xa1d25b751a6c45ec(reader));
		}
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		writer.Write(x4016138d7353cc02);
		writer.Write(x03e33bab05c4e7ef.Count + 1);
		writer.Write(x8e41272c5e3d35ea);
		writer.Write(x83b1f032d0833ad8);
		for (int i = 0; i < x03e33bab05c4e7ef.Count; i++)
		{
			xa1d25b751a6c45ec xa1d25b751a6c45ec2 = (xa1d25b751a6c45ec)x03e33bab05c4e7ef[i];
			xa1d25b751a6c45ec2.x6210059f049f0d48(writer);
		}
	}
}
