using System.IO;
using xa604c4d210ae0581;

namespace xaa035fc640f94856;

internal class x40376939900911c5
{
	private readonly int x4aac7bcf4ad57ded;

	private readonly int x5a6ae02edd8d8e79;

	private readonly string x4574aea041dd835f;

	internal int x56263eb153185fc7 => x4aac7bcf4ad57ded;

	internal int x1fbae63bd8ae49a5 => x5a6ae02edd8d8e79;

	internal string xd2f68ee6f47e9dfb => x4574aea041dd835f;

	internal x40376939900911c5(int ixdr, int ixst, string value)
	{
		x4aac7bcf4ad57ded = ixdr;
		x5a6ae02edd8d8e79 = ixst;
		x4574aea041dd835f = value;
	}

	internal x40376939900911c5(BinaryReader reader)
	{
		x4aac7bcf4ad57ded = reader.ReadInt32();
		x5a6ae02edd8d8e79 = reader.ReadInt32();
		x4574aea041dd835f = x93b05c1ad709a695.x602d3c3fbfa56f51(reader, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(x4aac7bcf4ad57ded);
		xbdfb620b7167944b.Write(x5a6ae02edd8d8e79);
		x93b05c1ad709a695.x4a3c44ae9b1cf5ab(x4574aea041dd835f, x4574aea041dd835f.Length, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
	}
}
