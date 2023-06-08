using System.Text;
using ns24;

namespace ns18;

internal class Class955
{
	internal static string smethod_0(Class541 guide, Class541[] geomGuides, Class341[] values)
	{
		StringBuilder stringBuilder = new StringBuilder(32);
		stringBuilder.Append(Class541.class1151_0[(int)guide.Operation]);
		int num = Class541.int_0[(uint)guide.Operation];
		stringBuilder.AppendFormat(" {0}", Class954.smethod_11(guide.Data1, geomGuides, values));
		if (num > 1)
		{
			stringBuilder.AppendFormat(" {0}", Class954.smethod_11(guide.Data2, geomGuides, values));
			if (num > 2)
			{
				stringBuilder.AppendFormat(" {0}", Class954.smethod_11(guide.Data3, geomGuides, values));
			}
		}
		return stringBuilder.ToString();
	}
}
