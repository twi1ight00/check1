using System.IO;
using x13f1efc79617a47b;

namespace x1a62aaf14e3c5909;

internal class xa1d25b751a6c45ec
{
	internal int x6b7f819c93711560;

	internal int xbc89105f15c17a8e;

	internal xa1d25b751a6c45ec(int dgid, int cspidCur)
	{
		x6b7f819c93711560 = dgid;
		xbc89105f15c17a8e = cspidCur;
	}

	public override string ToString()
	{
		return string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mhjomjapejhpajopgjfadfmaeedbfikbfibceiicmhpcpegdnindpdeejilefdcfgcjfggagdhhgngogdgfhlfmhhddiggkiagbjfcijdgpjgbgkpfnk", 1365961014)), x6b7f819c93711560, xbc89105f15c17a8e);
	}

	internal xa1d25b751a6c45ec(BinaryReader reader)
	{
		x6b7f819c93711560 = reader.ReadInt32();
		xbc89105f15c17a8e = reader.ReadInt32();
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(x6b7f819c93711560);
		xbdfb620b7167944b.Write(xbc89105f15c17a8e);
	}
}
