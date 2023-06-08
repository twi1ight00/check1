using System.Collections;
using System.Text;
using x6c95d9cf46ff5f25;

namespace xb1090543d168d647;

internal class x6a788953f4735438
{
	internal static string x395be84bc5b00b61(string x467620606087e51a)
	{
		ArrayList arrayList = xc43925ba6f2dd66c.xcd89c6dd6a1b87e6(x467620606087e51a);
		StringBuilder stringBuilder = new StringBuilder();
		foreach (xc43925ba6f2dd66c item in arrayList)
		{
			stringBuilder.Append(item.x2a41239165b955b7);
		}
		return stringBuilder.ToString();
	}

	internal static string x395be84bc5b00b61(string x467620606087e51a, out int[] x095c3b66aa7fe4df, out int[] x3bdefe1c94341615)
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = xc43925ba6f2dd66c.xcd89c6dd6a1b87e6(x467620606087e51a);
		StringBuilder stringBuilder = new StringBuilder();
		foreach (xc43925ba6f2dd66c item in arrayList3)
		{
			stringBuilder.Append(item.x2a41239165b955b7);
			arrayList.AddRange(item.xb624969a856e30be);
			arrayList2.AddRange(item.x923c40a843439696);
		}
		x095c3b66aa7fe4df = xcd4bd3abd72ff2da.x25c5f23efe5b47e4(arrayList);
		x3bdefe1c94341615 = xcd4bd3abd72ff2da.x25c5f23efe5b47e4(arrayList2);
		return stringBuilder.ToString();
	}
}
