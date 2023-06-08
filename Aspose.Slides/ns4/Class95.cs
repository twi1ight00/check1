using System.Collections.Generic;

namespace ns4;

internal class Class95
{
	public static void smethod_0(Dictionary<string, Class72> formatters)
	{
		formatters.Add("wo-SN", new Class72("wo-SN", new Class71[1]
		{
			new Class71("gr", new string[7] { "dimanche", "lundi", "mardi", "mercredi", "jeudi", "vendredi", "samedi" }, null, new string[13]
			{
				"janvier", "février", "mars", "avril", "mai", "juin", "juillet", "août", "septembre", "octobre",
				"novembre", "décembre", ""
			}, new string[13]
			{
				"janv.", "févr.", "mars", "avr.", "mai", "juin", "juil.", "août", "sept.", "oct.",
				"nov.", "déc.", ""
			}, null, null, null)
		}, null, new string[13]
		{
			"cgr;dd/MM/yyyy", "cgr;dddd d MMMM yyyy", "cgr;dd.MM.yy", "cgr;d MMMM yyyy", "cgr;d-MMM-yy", "cgr;MMMM yy", "cgr;MMM-yy", "cgr;dd/MM/yyyy HH:mm", "cgr;dd/MM/yyyy HH:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
	}

	private Class95()
	{
	}
}
