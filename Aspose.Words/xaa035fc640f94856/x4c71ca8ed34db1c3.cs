using System.Collections;
using System.IO;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;

namespace xaa035fc640f94856;

internal class x4c71ca8ed34db1c3
{
	private const int x26aabfd419255a4f = 12;

	private readonly xef0eed281c498fe1 x71be0612b696f76f;

	private readonly int x4aac7bcf4ad57ded;

	private readonly int x5a6ae02edd8d8e79;

	private readonly string x18078bbe01c444ae;

	private readonly int x60adf410a9cceab0;

	private readonly ArrayList x4acedb5e9b236f4a = new ArrayList();

	internal xef0eed281c498fe1 xef0eed281c498fe1 => x71be0612b696f76f;

	internal int x56263eb153185fc7 => x4aac7bcf4ad57ded;

	internal int x1fbae63bd8ae49a5 => x5a6ae02edd8d8e79;

	internal string xa3111ce09c95d2d1
	{
		get
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(x18078bbe01c444ae))
			{
				return "";
			}
			return x18078bbe01c444ae;
		}
	}

	internal ArrayList xbb028f757a204eeb => x4acedb5e9b236f4a;

	internal int xea1e81378298fa81 => x60adf410a9cceab0;

	internal x4c71ca8ed34db1c3(xef0eed281c498fe1 sdtt, int ixsdr, int ixst, string placeholder)
	{
		x71be0612b696f76f = sdtt;
		x4aac7bcf4ad57ded = ixsdr;
		x5a6ae02edd8d8e79 = ixst;
		x18078bbe01c444ae = placeholder;
	}

	internal x4c71ca8ed34db1c3(BinaryReader reader)
	{
		reader.ReadInt16();
		x60adf410a9cceab0 = reader.ReadInt32();
		x4aac7bcf4ad57ded = reader.ReadInt32();
		x5a6ae02edd8d8e79 = reader.ReadInt32();
		x71be0612b696f76f = (xef0eed281c498fe1)reader.ReadInt32();
		int num = reader.ReadInt32();
		int num2 = reader.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			x4acedb5e9b236f4a.Add(new x40376939900911c5(reader));
		}
		if (num2 > 0)
		{
			x18078bbe01c444ae = x93b05c1ad709a695.x79739b9c4ddc2495(reader, num2);
		}
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b, int xeaf1b27180c0557b)
	{
		xbdfb620b7167944b.Write((short)12);
		xbdfb620b7167944b.Write(xeaf1b27180c0557b);
		xbdfb620b7167944b.Write(x4aac7bcf4ad57ded);
		xbdfb620b7167944b.Write(x5a6ae02edd8d8e79);
		xbdfb620b7167944b.Write((int)xef0eed281c498fe1);
		xbdfb620b7167944b.Write(x4acedb5e9b236f4a.Count);
		xbdfb620b7167944b.Write(x0d299f323d241756.x5959bccb67bbf051(x18078bbe01c444ae) ? (x18078bbe01c444ae.Length * 2 + 2) : 0);
		foreach (x40376939900911c5 item in x4acedb5e9b236f4a)
		{
			item.x6210059f049f0d48(xbdfb620b7167944b);
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x18078bbe01c444ae))
		{
			x93b05c1ad709a695.x535736a60cc73a33(x18078bbe01c444ae, xbdfb620b7167944b);
		}
	}
}
