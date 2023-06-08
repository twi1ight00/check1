using System.Collections.Generic;

namespace ns4;

internal class Class82
{
	public static void smethod_0(Dictionary<string, Class72> formatters)
	{
		formatters.Add("ja-JP", new Class72("ja-JP", new Class71[2]
		{
			new Class71("gr", null, null, null, null, null, null, null),
			new Class71("ja", null, null, null, null, null, null, null)
		}, Class68.class68_0, new string[13]
		{
			"cgr;M/d/yyyy", "len-US;cgr;dddd, MMMM dd, yyyy", "cja;平成yy年M月d日", "cgr;yyyy'年'M'月'd'日'", "len-US;cgr;d-MMM-yy", "cja;平成yy年M月", "cja;平成yy{}年MM{}月d{}日", "cgr;yy/M/d H時m分", "cgr;yy/M/d H時m分s秒", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;H時m分", "cgr;H時m分s秒"
		}));
	}

	private Class82()
	{
	}
}
