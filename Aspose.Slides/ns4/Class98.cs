using System.Collections.Generic;

namespace ns4;

internal class Class98
{
	public static void smethod_0(Dictionary<string, Class72> formatters)
	{
		formatters.Add("zh-SG", new Class72("zh-SG", new Class71[1]
		{
			new Class71("gr", new string[7] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" }, null, null, null, null, null, new string[2] { "上午", "下午" })
		}, null, new string[13]
		{
			"cgr;M/d/yyyy", "cgr;yyyy'年'M'月'd'日'", "cgr;yyyy'年'M'月'd'日'", "cgr;yyyy年M月d日dddd", "len-US;cgr;d-MMM-yy", "cgr;yyyy'年'M'月'", "len-US;cgr;MMM-yy", "cgr;yyyy年M月d日h时m分", "cgr;yyyy年M月d{}日ddddh时m分s秒", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;tth时m分", "cgr;tth时m分s秒"
		}));
		formatters.Add("zh-HK", new Class72("zh-HK", new Class71[1]
		{
			new Class71("gr", new string[7] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" }, null, null, null, null, null, null)
		}, null, new string[13]
		{
			"cgr;M/d/yyyy", "cgr;yyyy'年'M'月'd'日'", "cgr;yyyy'年'M'月'd'日'", "cgr;yyyy年M月d日dddd", "len-US;cgr;d-MMM-yy", "cgr;yyyy'年'M'月'", "len-US;cgr;MMM-yy", "len-US;cgr;M/d/yyyy h:mm tt", "len-US;cgr;M/d/yyyy h:mm:ss tt", "cgr;HH:mm",
			"cgr;HH:mm:ss", "len-US;cgr;h:mm tt", "len-US;cgr;h:mm:ss tt"
		}));
		formatters.Add("zh-MO", new Class72("zh-MO", new Class71[1]
		{
			new Class71("gr", new string[7] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" }, null, null, null, null, null, null)
		}, null, new string[13]
		{
			"cgr;M/d/yyyy", "cgr;yyyy'年'M'月'd'日'", "cgr;yyyy'年'M'月'd'日'", "cgr;yyyy年M月d日dddd", "len-US;cgr;d-MMM-yy", "cgr;yyyy'年'M'月'", "len-US;cgr;MMM-yy", "len-US;cgr;M/d/yyyy h:mm tt", "len-US;cgr;M/d/yyyy h:mm:ss tt", "cgr;HH:mm",
			"cgr;HH:mm:ss", "len-US;cgr;h:mm tt", "len-US;cgr;h:mm:ss tt"
		}));
		formatters.Add("zh-TW", new Class72("zh-TW", new Class71[1]
		{
			new Class71("gr", new string[7] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" }, null, null, null, null, null, new string[2] { "上午", "下午" })
		}, Class68.class68_0, new string[13]
		{
			"cgr;M/d/yyyy", "cgr;yyyy'年'M'月'd'日'", "cgr;yyyy'年'M'月'd'日'", "cgr;yyyy年M月d日dddd", "cgr;yyyy年M月d日dddd", "cgr;yyyy{e}年MM{}月d{}日dddd", "cgr;yyyy{e}年MM{}月d{}日dddd", "cgr;yyyy{e}年MM{}月d{}日", "cgr;yyyy{e}年MM{}月d{}日dddd", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("zh-CN", new Class72("zh-CN", new Class71[1]
		{
			new Class71("gr", new string[7] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" }, null, null, null, null, null, new string[2] { "上午", "下午" })
		}, null, new string[13]
		{
			"cgr;M/d/yyyy", "cgr;yyyy'年'M'月'd'日'", "cgr;yyyy年M月d日dddd", "cgr;yyyy年M月d日dddd", "len-US;cgr;d-MMM-yy", "cgr;yyyy'年'M'月'", "len-US;cgr;MMM-yy", "cgr;yyyy年M月d日h时m分", "cgr;yyyy年M月d{}日ddddh时m分s秒", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;tth时m分", "cgr;tth时m分s秒"
		}));
		formatters.Add("zu-ZA", new Class72("zu-ZA", new Class71[1]
		{
			new Class71("gr", new string[7] { "iSonto", "uMsombuluko", "uLwesibili", "uLwesithathu", "uLwesine", "uLwesihlanu", "uMgqibelo" }, null, new string[13]
			{
				"uMasingana", "uNhlolanja", "uNdasa", "uMbaso", "uNhlaba", "uNhlangulana", "uNtulikazi", "uNcwaba", "uMandulo", "uMfumfu",
				"uLwezi", "uZibandlela", ""
			}, new string[13]
			{
				"Mas.", "Nhlo.", "Nda.", "Mba.", "Nhla.", "Nhlang.", "Ntu.", "Ncwa.", "Man.", "Mfu.",
				"Lwe.", "Zib.", ""
			}, null, null, new string[2] { "AM", "PM" })
		}, null, new string[13]
		{
			"cgr;yyyy/MM/dd", "cgr;dddd, dd MMMM yyyy", "cgr;yy.MM.dd", "cgr;dd MMMM yyyy", "cgr;yy-MMM-d", "cgr;MMMM yy", "cgr;MMM-yy", "cgr;yyyy/MM/dd hh:mm tt", "cgr;yyyy/MM/dd hh:mm:ss tt", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
	}

	private Class98()
	{
	}
}
