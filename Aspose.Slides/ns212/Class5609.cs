using System.Text;
using ns195;

namespace ns212;

internal class Class5609
{
	private int[] int_0;

	private string string_0;

	private int int_1;

	private Class5609(string word, int[] points)
	{
		string_0 = word;
		int_0 = points;
		int_1 = points.Length;
	}

	public int method_0()
	{
		return int_1;
	}

	public string method_1(int index)
	{
		return Class5479.smethod_0(string_0, 0, int_0[index]);
	}

	public string method_2(int index)
	{
		return string_0.Substring(int_0[index]);
	}

	public int[] method_3()
	{
		return int_0;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		for (int i = 0; i < int_1; i++)
		{
			stringBuilder.Append(Class5479.smethod_0(string_0, num, int_0[i]) + "-");
			num = int_0[i];
		}
		stringBuilder.Append(string_0.Substring(num));
		return stringBuilder.ToString();
	}
}
