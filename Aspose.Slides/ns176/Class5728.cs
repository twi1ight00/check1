using System.Text;

namespace ns176;

internal class Class5728
{
	public int int_0;

	public int int_1;

	public Class5728(int ipd, int bpd)
	{
		int_0 = ipd;
		int_1 = bpd;
	}

	public int method_0()
	{
		return int_0;
	}

	public int method_1()
	{
		return int_1;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(" {ipd=").Append(int_0);
		stringBuilder.Append(", bpd=").Append(int_1);
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}
}
