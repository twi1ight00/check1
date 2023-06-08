using System.Collections.Generic;

namespace ns4;

internal class Class84
{
	public static void smethod_0(Dictionary<string, Class72> formatters)
	{
		formatters.Add("lb-LU", new Class72("lb-LU", new Class71[1]
		{
			new Class71("gr", new string[7] { "Sonndeg", "Méindeg", "Dënschdeg", "Mëttwoch", "Donneschdeg", "Freideg", "Samschdeg" }, null, new string[13]
			{
				"Januar", "Februar", "Mäerz", "Abrëll", "Mee", "Juni", "Juli", "August", "September", "Oktober",
				"November", "Dezember", ""
			}, new string[13]
			{
				"Jan", "Feb", "Mäe", "Abr", "Mee", "Jun", "Jul", "Aug", "Sep", "Okt",
				"Nov", "Dez", ""
			}, null, null, null)
		}, null, new string[13]
		{
			"cgr;dd/MM/yyyy", "cgr;dddd d MMMM yyyy", "cgr;dd.MM.yy", "cgr;d MMMM yyyy", "cgr;d-MMM-yy", "cgr;MMMM yy", "cgr;MMM-yy", "cgr;dd/MM/yyyy HH:mm", "cgr;dd/MM/yyyy HH:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("lo-LA", new Class72("lo-LA", new Class71[1]
		{
			new Class71("gr", null, null, new string[13]
			{
				"ມ\u0eb1ງກອນ", "ກ\u0eb8ມພາ", "ມ\u0eb5ນາ", "ເມສາ", "ພ\u0eb6ດສະພາ", "ມ\u0eb4ຖ\u0eb8ນາ", "ກ\u0ecdລະກ\u0ebbດ", "ສ\u0eb4ງຫາ", "ກ\u0eb1ນຍາ", "ຕ\u0eb8ລາ",
				"ພະຈ\u0eb4ກ", "ທ\u0eb1ນວາ", ""
			}, null, null, null, new string[2] { "ເຊ\u0ebb\u0ec9າ", "ແລງ" })
		}, null, new string[13]
		{
			"cgr;dd/MM/yyyy", "", "cgr;dd.MM.yy", "cgr;d MMMM yyyy", "cgr;d-MMM-yy", "cgr;MMMM yy", "cgr;MMM-yy", "cgr;dd/MM/yyyy HH:mm", "cgr;dd/MM/yyyy HH:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("lt-LT", new Class72("lt-LT", new Class71[1]
		{
			new Class71("gr", new string[7] { "sekmadienis", "pirmadienis", "antradienis", "trečiadienis", "ketvirtadienis", "penktadienis", "šeštadienis" }, null, new string[13]
			{
				"sausis", "vasaris", "kovas", "balandis", "gegužė", "birželis", "liepa", "rugpjūtis", "rugsėjis", "spalis",
				"lapkritis", "gruodis", ""
			}, new string[13]
			{
				"Sau", "Vas", "Kov", "Bal", "Geg", "Bir", "Lie", "Rgp", "Rgs", "Spl",
				"Lap", "Grd", ""
			}, new string[13]
			{
				"sausio", "vasario", "kovo", "balandžio", "gegužės", "birželio", "liepos", "rugpjūčio", "rugsėjo", "spalio",
				"lapkričio", "gruodžio", ""
			}, null, null)
		}, null, new string[13]
		{
			"cgr;yyyy.MM.dd", "cgr;dddd, yyyy 'm.' GGGG d 'd.'", "cgr;yy/MM/dd", "cgr;yyyy 'm.' GGGG d 'd.'", "cgr;yy-MMM-d", "cgr;yy 'm.' MMMM", "cgr;MMM-yy", "cgr;yyyy.MM.dd HH:mm", "cgr;yyyy.MM.dd HH:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("lv-LV", new Class72("lv-LV", new Class71[1]
		{
			new Class71("gr", new string[7] { "svētdiena", "pirmdiena", "otrdiena", "trešdiena", "ceturtdiena", "piektdiena", "sestdiena" }, null, new string[13]
			{
				"janvāris", "februāris", "marts", "aprīlis", "maijs", "jūnijs", "jūlijs", "augusts", "septembris", "oktobris",
				"novembris", "decembris", ""
			}, new string[13]
			{
				"jan", "feb", "mar", "apr", "mai", "jūn", "jūl", "aug", "sep", "okt",
				"nov", "dec", ""
			}, null, null, null)
		}, null, new string[13]
		{
			"cgr;yyyy.MM.dd.", "cgr;dddd, yyyy'. gada 'd. MMMM", "cgr;yy/MM/dd", "cgr;yyyy. 'gada' d. MMMM", "cgr;yy-MMM-d", "cgr;yy MMMM", "cgr;MMM-yy", "cgr;yyyy.MM.dd. H:mm", "cgr;yyyy.MM.dd. H:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
	}

	private Class84()
	{
	}
}
