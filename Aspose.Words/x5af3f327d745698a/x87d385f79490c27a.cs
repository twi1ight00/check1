using System.IO;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;

namespace x5af3f327d745698a;

internal class x87d385f79490c27a
{
	private readonly xb72adff071c98600 x16505b09716bb0ac = xb72adff071c98600.x4d0b9d4447ba7566;

	private readonly string x0119c96d931abcfa;

	internal xb72adff071c98600 xca389730108ebf4a => x16505b09716bb0ac;

	internal string x001f97f04fb2e977 => x0119c96d931abcfa;

	internal x87d385f79490c27a(xb72adff071c98600 cf)
	{
		x16505b09716bb0ac = cf;
	}

	internal x87d385f79490c27a(string cf)
	{
		x0119c96d931abcfa = cf;
	}

	internal x87d385f79490c27a(BinaryReader reader, bool isUnicode)
	{
		int num = reader.ReadInt32();
		if (num > 0)
		{
			x0119c96d931abcfa = (isUnicode ? x93b05c1ad709a695.x79739b9c4ddc2495(reader, num) : x9ac0da7388ceac43.x58db9aaa4a730e59(reader, num));
		}
		else if (num < 0)
		{
			x16505b09716bb0ac = (xb72adff071c98600)reader.ReadInt32();
		}
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b, bool x5be1cad1d00af914)
	{
		if (x16505b09716bb0ac != xb72adff071c98600.x4d0b9d4447ba7566)
		{
			xbdfb620b7167944b.Write(-1);
			xbdfb620b7167944b.Write((int)x16505b09716bb0ac);
		}
		else if (x0d299f323d241756.x5959bccb67bbf051(x0119c96d931abcfa))
		{
			if (x5be1cad1d00af914)
			{
				x93b05c1ad709a695.x81fe2fd2de403f38(x0119c96d931abcfa, xbdfb620b7167944b);
			}
			else
			{
				x9ac0da7388ceac43.x41d7feb042ee43f7(xbdfb620b7167944b, x0119c96d931abcfa);
			}
		}
		else
		{
			xbdfb620b7167944b.Write(0);
		}
	}
}
