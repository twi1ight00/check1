using System.Collections.Generic;

namespace ns4;

internal class Class78
{
	public static void smethod_0(Dictionary<string, Class72> formatters)
	{
		formatters.Add("fa-IR", new Class72("fa-IR", new Class71[2]
		{
			new Class71("gr", new string[7] { "یکشنبه", "دوشنبه", "سه شنبه", "چهار شنبه", "پنجشنبه", "آدینه", "شنبه" }, null, new string[13]
			{
				"ژانويه", "فوريه", "مارس", "آوريل", "مى", "ژوئن", "ژوئيه", "اوت", "سپتامبر", "ا\u064fكتبر",
				"نوامبر", "دسامبر", ""
			}, null, null, null, new string[2] { "ق،ظ", "ب،ظ" }),
			new Class71("hi", new string[7] { "یکشنبه", "دوشنبه", "سه شنبه", "چهار شنبه", "پنجشنبه", "آدینه", "شنبه" }, null, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null)
		}, null, new string[13]
		{
			"chi;yyyy/MM/dd", "chi;dddd، yyyy/MM/dd", "chi;yyyy/MM/d", "chi;yy/MM/dd", "chi;yyyy-MM-dd", "chi;yy-MMM-d", "chi;yy،MM،dd", "cgr;yy/MMMM/d", "cgr;yy،MM،dd", "cgr;dddd، yyyy/MM/dd",
			"cgr;MMM-yy", "cgr;yyyy/MM/dd hh:mm tt", "cgr;yy-MMM-d"
		}));
		formatters.Add("fi-FI", new Class72("fi-FI", new Class71[1]
		{
			new Class71("gr", new string[7] { "sunnuntai", "maanantai", "tiistai", "keskiviikko", "torstai", "perjantai", "lauantai" }, null, new string[13]
			{
				"tammikuu", "helmikuu", "maaliskuu", "huhtikuu", "toukokuu", "kesäkuu", "heinäkuu", "elokuu", "syyskuu", "lokakuu",
				"marraskuu", "joulukuu", ""
			}, null, new string[13]
			{
				"tammikuuta", "helmikuuta", "maaliskuuta", "huhtikuuta", "toukokuuta", "kesäkuuta", "heinäkuuta", "elokuuta", "syyskuuta", "lokakuuta",
				"marraskuuta", "joulukuuta", ""
			}, new string[13]
			{
				"tammik", "helmik", "maalisk", "huhtik", "toukok", "kesäk", "heinäk", "elok", "syysk", "lokak",
				"marrask", "jouluk", ""
			}, null)
		}, null, new string[13]
		{
			"cgr;d.M.yyyy", "cgr;dddd, d. GGGG yyyy", "cgr;d/M/yy", "cgr;d. MMMM'ta 'yyyy", "cgr;d-GGG-yy", "cgr;GGGG yy", "cgr;GGG-yy", "cgr;d.M.yyyy H:mm", "cgr;d.M.yyyy H:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("fil-PH", new Class72("fil-PH", new Class71[1]
		{
			new Class71("gr", new string[7] { "Linggo", "Lunes", "Martes", "Mierkoles", "Huebes", "Biernes", "Sabado" }, null, new string[13]
			{
				"Enero", "Pebrero", "Marso", "Abril", "Mayo", "Hunyo", "Hulyo", "Agosto", "Septyembre", "Oktubre",
				"Nobyembre", "Disyembre", ""
			}, new string[13]
			{
				"En", "Peb", "Mar", "Abr", "Mayo", "Hun", "Hul", "Agos", "Sept", "Okt",
				"Nob", "Dis", ""
			}, null, null, new string[2] { "AM", "PM" })
		}, null, new string[13]
		{
			"cgr;M/d/yyyy", "cgr;dddd, MMMM dd, yyyy", "cgr;M.d.yy", "cgr;MMMM d, yyyy", "cgr;d-MMM-yy", "cgr;MMMM yy", "cgr;MMM-yy", "cgr;M/d/yyyy h:mm tt", "cgr;M/d/yyyy h:mm:ss tt", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("fo-FO", new Class72("fo-FO", new Class71[1]
		{
			new Class71("gr", new string[7] { "sunnudagur", "mánadagur", "týsdagur", "mikudagur", "hósdagur", "fríggjadagur", "leygardagur" }, null, new string[13]
			{
				"januar", "februar", "mars", "apríl", "mai", "juni", "juli", "august", "september", "oktober",
				"november", "desember", ""
			}, new string[13]
			{
				"jan", "feb", "mar", "apr", "mai", "jun", "jul", "aug", "sep", "okt",
				"nov", "des", ""
			}, null, null, null)
		}, null, new string[13]
		{
			"cgr;dd-MM-yyyy", "cgr;dddd, d. GGGG yyyy", "cgr;dd/MM/yy", "cgr;d. MMMM yyyy", "cgr;d-MMM-yy", "cgr;MMMM yy", "cgr;MMM-yy", "cgr;dd-MM-yyyy HH:mm", "cgr;dd-MM-yyyy HH:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("fr-BE", new Class72("fr-BE", new Class71[1]
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
			"cgr;d/MM/yyyy", "cgr;dddd d MMMM yyyy", "cgr;d.MM.yy", "cgr;d MMMM yyyy", "cgr;d-MMM-yy", "cgr;MMMM yy", "cgr;MMM-yy", "cgr;d/MM/yyyy HH:mm", "cgr;d/MM/yyyy HH:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("fr-CA", new Class72("fr-CA", new Class71[1]
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
			"cgr;yyyy-MM-dd", "cgr;dddd, d MMMM yyyy", "cgr;yy/MM/dd", "cgr;d MMMM yyyy", "cgr;yy-MMM-d", "cgr;MMMM yy", "cgr;MMM-yy", "cgr;yyyy-MM-dd HH:mm", "cgr;yyyy-MM-dd HH:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("fr-CH", new Class72("fr-CH", new Class71[1]
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
			"cgr;dd.MM.yyyy", "cgr;dddd d MMMM yyyy", "cgr;dd/MM/yy", "cgr;d MMMM yyyy", "cgr;d-MMM-yy", "cgr;MMMM yy", "cgr;MMM-yy", "cgr;dd.MM.yyyy HH:mm", "cgr;dd.MM.yyyy HH:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("fr-FR", new Class72("fr-FR", new Class71[1]
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
		formatters.Add("fr-LU", new Class72("fr-LU", new Class71[1]
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
		formatters.Add("fr-MC", new Class72("fr-MC", new Class71[1]
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
		formatters.Add("fy-NL", new Class72("fy-NL", new Class71[1]
		{
			new Class71("gr", new string[7] { "Snein", "Moandei", "Tiisdei", "Woansdei", "Tongersdei", "Freed", "Sneon" }, null, new string[13]
			{
				"jannewaris", "febrewaris", "maart", "april", "maaie", "juny", "july", "augustus", "septimber", "oktober",
				"novimber", "desimber", ""
			}, new string[13]
			{
				"jann", "febr", "mrt", "apr", "maaie", "jun", "jul", "aug", "sept", "okt",
				"nov", "des", ""
			}, null, null, null)
		}, null, new string[13]
		{
			"cgr;d-M-yyyy", "cgr;dddd d MMMM yyyy", "cgr;d/M/yy", "cgr;d MMMM yyyy", "cgr;d-MMM-yy", "cgr;MMMM yy", "cgr;MMM-yy", "cgr;d-M-yyyy H:mm", "cgr;d-M-yyyy H:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
	}

	private Class78()
	{
	}
}
