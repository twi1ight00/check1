using System.Collections.Generic;

namespace ns4;

internal class Class87
{
	public static void smethod_0(Dictionary<string, Class72> formatters)
	{
		formatters.Add("oc-FR", new Class72("oc-FR", new Class71[1]
		{
			new Class71("gr", new string[7] { "dimenge", "diluns", "dimars", "dimècres", "dijòus", "divendres", "dissabte" }, null, new string[13]
			{
				"genier", "febrier", "març", "abril", "mai", "junh", "julh", "agost", "setembre", "octobre",
				"novembre", "desembre", ""
			}, new string[13]
			{
				"gen.", "feb.", "mar.", "abr.", "mai.", "jun.", "jul.", "ag.", "set.", "oct.",
				"nov.", "des.", ""
			}, null, null, null)
		}, null, new string[13]
		{
			"cgr;dd/MM/yyyy", "cgr;dddd,' lo 'd MMMM' de 'yyyy", "cgr;dd.MM.yy", "cgr;d MMMM 'de' yyyy", "cgr;d-MMM-yy", "cgr;MMMM 'de' yy", "cgr;MMM-yy", "cgr;dd/MM/yyyy HH:mm", "cgr;dd/MM/yyyy HH:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("or-IN", new Class72("or-IN", new Class71[1]
		{
			new Class71("gr", new string[7] { "ରବ\u0b3fବ\u0b3eର", "ସ\u0b47\u0b3eମବ\u0b3eର", "ମଙ\u0b4dଗଳବ\u0b3eର", "ବ\u0b41ଧବ\u0b3eର", "ଗ\u0b41ର\u0b41ବ\u0b3eର", "ଶ\u0b41କ\u0b4dରବ\u0b3eର", "ଶନ\u0b3fବ\u0b3eର" }, null, new string[13]
			{
				"ଜ\u0b3eନ\u0b41ୟ\u0b3eର\u0b40", "ଫ\u0b4dର\u0b47ବ\u0b43ୟ\u0b3eର\u0b40", "ମ\u0b3eର\u0b4dଚ\u0b4dଚ", "ଏପ\u0b4dର\u0b3fଲ\u0b4d\u200c", "ମ\u0b47", "ଜ\u0b41ନ\u0b4d\u200c", "ଜ\u0b41ଲ\u0b3eଇ", "ଅଗଷ\u0b4dଟ", "ସ\u0b47ପ\u0b4dଟ\u0b47ମ\u0b4dବର", "ଅକ\u0b4dଟ\u0b4bବର",
				"ନଭ\u0b47ମ\u0b4dବର", "(ଡ\u0b3fସ\u0b47ମ\u0b4dବର", ""
			}, null, null, null, new string[2] { "AM", "PM" })
		}, null, new string[13]
		{
			"cgr;dd-MM-yy", "cgr;dddd, dd MMMM yyyy", "cgr;dd/MM/yyyy", "cgr;dd MMMM yyyy", "cgr;d-MMM-yy", "cgr;MMMM yy", "cgr;MMM-yy", "cgr;dd-MM-yy HH:mm", "cgr;dd-MM-yy HH:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
	}

	private Class87()
	{
	}
}
