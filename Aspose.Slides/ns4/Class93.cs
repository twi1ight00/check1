using System.Collections.Generic;

namespace ns4;

internal class Class93
{
	public static void smethod_0(Dictionary<string, Class72> formatters)
	{
		formatters.Add("uk-UA", new Class72("uk-UA", new Class71[1]
		{
			new Class71("gr", new string[7] { "неділя", "понеділок", "вівторок", "середа", "четвер", "п'ятниця", "субота" }, null, new string[13]
			{
				"січень", "лютий", "березень", "квітень", "травень", "червень", "липень", "серпень", "вересень", "жовтень",
				"листопад", "грудень", ""
			}, new string[13]
			{
				"січ", "лют", "бер", "кві", "тра", "чер", "лип", "сер", "вер", "жов",
				"лис", "гру", ""
			}, new string[13]
			{
				"січня", "лютого", "березня", "квітня", "травня", "червня", "липня", "серпня", "вересня", "жовтня",
				"листопада", "грудня", ""
			}, null, null)
		}, null, new string[13]
		{
			"cgr;dd.MM.yyyy", "cgr;dddd, d GGGG yyyy р.", "cgr;dd/MM/yy", "cgr;d GGGG yyyy р.", "cgr;d-MMM-yy", "cgr;MMMM yy р", "cgr;MMM-yy", "cgr;dd.MM.yyyy H:mm", "cgr;dd.MM.yyyy H:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("ur-PK", new Class72("ur-PK", new Class71[2]
		{
			new Class71("gr", new string[7] { "اتوار", "پير", "منگل", "بدھ", "جمعرات", "جمعه", "هفته" }, null, new string[13]
			{
				"جنوری", "فروری", "مارچ", "اپریل", "مئی", "جون", "جولائی", "اگست", "ستمبر", "اکتوبر",
				"نومبر", "دسمبر", ""
			}, null, null, null, new string[2] { "صبح", "شام" }),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "الثانی،", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "الحج", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd/MM/yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd/MM/yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;dd،MM،yy", "cgr;dd MMMM، yy", "cgr;dd،MM،yy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd/MM/yyyy h:mm tt", "cgr;d-MMM-yy"
		}));
		formatters.Add("uz-Cyrl-UZ", new Class72("uz-Cyrl-UZ", new Class71[1]
		{
			new Class71("gr", new string[7] { "Якшанба", "Душанба", "Сешанба", "Чоршанба", "Пайшанба", "Жума", "Шанба" }, null, new string[13]
			{
				"январ", "феврал", "март", "апрел", "май", "июн", "июл", "август", "сентябр", "октябр",
				"ноябр", "декабр", ""
			}, new string[13]
			{
				"янв", "фев", "мар", "апр", "май", "июн", "июл", "авг", "сен", "окт",
				"ноя", "дек", ""
			}, null, null, null)
		}, null, new string[13]
		{
			"cgr;dd.MM.yyyy", "cgr;dddd, yyyy йил d-MMMM", "cgr;dd/MM/yy", "cgr;yyyy 'йил' d-MMMM", "cgr;d-MMM-yy", "cgr;yy-MMMM", "cgr;MMM-yy", "cgr;dd.MM.yyyy HH:mm", "cgr;dd.MM.yyyy HH:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("uz-Latn-UZ", new Class72("uz-Latn-UZ", new Class71[1]
		{
			new Class71("gr", new string[7] { "yakshanba", "dushanba", "seshanba", "chorshanba", "payshanba", "juma", "shanba" }, null, new string[13]
			{
				"yanvar", "fevral", "mart", "aprel", "may", "iyun", "iyul", "avgust", "sentyabr", "oktyabr",
				"noyabr", "dekabr", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"cgr;dd/MM yyyy", "cgr;dddd, yyyy 'yil' d-MMMM", "cgr;dd.MM.yy", "cgr;yyyy 'yil' d-MMMM", "cgr;d-MMM-yy", "cgr;yy-MMMM", "cgr;MMM-yy", "cgr;dd/MM yyyy HH:mm", "cgr;dd/MM yyyy HH:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
	}

	private Class93()
	{
	}
}
