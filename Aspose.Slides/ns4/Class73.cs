using System.Collections.Generic;

namespace ns4;

internal class Class73
{
	public static void smethod_0(Dictionary<string, Class72> formatters)
	{
		formatters.Add("af-ZA", new Class72("af-ZA", new Class71[1]
		{
			new Class71("gr", new string[7] { "Sondag", "Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrydag", "Saterdag" }, null, new string[13]
			{
				"Januarie", "Februarie", "Maart", "April", "Mei", "Junie", "Julie", "Augustus", "September", "Oktober",
				"November", "Desember", ""
			}, new string[13]
			{
				"Jan", "Feb", "Mar", "Apr", "Mei", "Jun", "Jul", "Aug", "Sep", "Okt",
				"Nov", "Des", ""
			}, null, null, new string[2] { "AM", "PM" })
		}, null, new string[13]
		{
			"cgr;yyyy/MM/dd", "cgr;dddd, dd MMMM yyyy", "cgr;yy.MM.dd", "cgr;dd MMMM yyyy", "cgr;yy-MMM-d", "cgr;MMMM yy", "cgr;MMM-yy", "cgr;yyyy/MM/dd hh:mm tt", "cgr;yyyy/MM/dd hh:mm:ss tt", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("am-ET", new Class72("am-ET", new Class71[1]
		{
			new Class71("gr", new string[7] { "እሑድ", "ሰኞ", "ማክሰኞ", "ረቡዕ", "ሐሙስ", "ዓርብ", "ቅዳሜ" }, null, new string[13]
			{
				"ጃንዩወሪ", "ፌብሩወሪ", "ማርች", "ኤፕረል", "ሜይ", "ጁን", "ጁላይ", "ኦገስት", "ሴፕቴምበር", "ኦክተውበር",
				"ኖቬምበር", "ዲሴምበር", ""
			}, new string[13]
			{
				"ጃንዩ", "ፌብሩ", "ማርች", "ኤፕረ", "ሜይ", "ጁን", "ጁላይ", "ኦገስ", "ሴፕቴ", "ኦክተ",
				"ኖቬም", "ዲሴም", ""
			}, null, null, new string[2] { "ጡዋት", "ከሰዓት" })
		}, null, new string[13]
		{
			"cgr;d/M/yyyy", "cgr;dddd '፣' MMMM d 'ቀን' yyyy", "cgr;d.M.yy", "cgr;MMMM d ቀን yyyy", "cgr;d-MMM-yy", "cgr;MMMM ቀን yy", "cgr;MMM-yy", "cgr;d/M/yyyy h:mm tt", "cgr;d/M/yyyy h:mm:ss tt", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("ar-AE", new Class72("ar-AE", new Class71[2]
		{
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, new string[2] { "ص", "م" }),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd/MM/yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd/MM/yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd/MM/yyyy hh:mm tt", "cgr;d-MMM-yy"
		}));
		formatters.Add("ar-BH", new Class72("ar-BH", new Class71[2]
		{
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, new string[2] { "ص", "م" }),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd/MM/yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd/MM/yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd/MM/yyyy hh:mm tt", "cgr;d-MMM-yy"
		}));
		formatters.Add("ar-DZ", new Class72("ar-DZ", new Class71[2]
		{
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, null),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd-MM-yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd-MM-yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd-MM-yyyy H:mm", "cgr;d-MMM-yy"
		}));
		formatters.Add("ar-IQ", new Class72("ar-IQ", new Class71[2]
		{
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, new string[2] { "ص", "م" }),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd/MM/yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd/MM/yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd/MM/yyyy hh:mm tt", "cgr;d-MMM-yy"
		}));
		formatters.Add("ar-EG", new Class72("ar-EG", new Class71[2]
		{
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, new string[2] { "ص", "م" }),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd/MM/yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd/MM/yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd/MM/yyyy hh:mm tt", "cgr;d-MMM-yy"
		}));
		formatters.Add("ar-JO", new Class72("ar-JO", new Class71[2]
		{
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, new string[2] { "ص", "م" }),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd/MM/yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd/MM/yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd/MM/yyyy hh:mm tt", "cgr;d-MMM-yy"
		}));
		formatters.Add("ar-KW", new Class72("ar-KW", new Class71[2]
		{
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, new string[2] { "ص", "م" }),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd/MM/yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd/MM/yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd/MM/yyyy hh:mm tt", "cgr;d-MMM-yy"
		}));
		formatters.Add("ar-LB", new Class72("ar-LB", new Class71[2]
		{
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, new string[2] { "ص", "م" }),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd/MM/yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd/MM/yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd/MM/yyyy hh:mm tt", "cgr;d-MMM-yy"
		}));
		formatters.Add("ar-LY", new Class72("ar-LY", new Class71[2]
		{
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, new string[2] { "ص", "م" }),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd/MM/yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd/MM/yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd/MM/yyyy hh:mm tt", "cgr;d-MMM-yy"
		}));
		formatters.Add("ar-MA", new Class72("ar-MA", new Class71[2]
		{
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, null),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd-MM-yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd-MM-yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd-MM-yyyy H:mm", "cgr;d-MMM-yy"
		}));
		formatters.Add("ar-OM", new Class72("ar-OM", new Class71[2]
		{
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, new string[2] { "ص", "م" }),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd/MM/yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd/MM/yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd/MM/yyyy hh:mm tt", "cgr;d-MMM-yy"
		}));
		formatters.Add("ar-QA", new Class72("ar-QA", new Class71[2]
		{
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, new string[2] { "ص", "م" }),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd/MM/yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd/MM/yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd/MM/yyyy hh:mm tt", "cgr;d-MMM-yy"
		}));
		formatters.Add("ar-SA", new Class72("ar-SA", new Class71[2]
		{
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null),
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, new string[2] { "ص", "م" })
		}, null, new string[13]
		{
			"chi;dd/MM/yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd/MM/yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd/MM/yyyy hh:mm tt", "cgr;d-MMM-yy"
		}));
		formatters.Add("ar-SY", new Class72("ar-SY", new Class71[2]
		{
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, new string[2] { "ص", "م" }),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd/MM/yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd/MM/yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd/MM/yyyy hh:mm tt", "cgr;d-MMM-yy"
		}));
		formatters.Add("ar-TN", new Class72("ar-TN", new Class71[2]
		{
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, null),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd-MM-yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd-MM-yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd-MM-yyyy H:mm", "cgr;d-MMM-yy"
		}));
		formatters.Add("ar-YE", new Class72("ar-YE", new Class71[2]
		{
			new Class71("gr", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"كانون\u00a0الثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين\u00a0الأول",
				"تشرين\u00a0الثاني", "كانون\u00a0الأول", ""
			}, null, null, null, new string[2] { "ص", "م" }),
			new Class71("hi", new string[7] { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" }, null, new string[13]
			{
				"محرم", "صفر", "ربيع\u00a0الأول", "ربيع\u00a0الثاني", "جمادى\u00a0الأولى", "جمادى\u00a0الثانية", "رجب", "شعبان", "رمضان", "شوال",
				"ذو\u00a0القعدة", "ذو\u00a0الحجة", ""
			}, null, null, null, null)
		}, null, new string[13]
		{
			"chi;dd/MM/yyyy", "chi;dddd، dd MMMM، yyyy", "chi;dd MMMM، yyyy", "chi;dd/MM/yy", "chi;yyyy-MM-dd", "chi;d-MMM-yy", "chi;d MMMM yyyy", "cgr;dd MMMM، yy", "cgr;d MMMM yyyy", "cgr;dddd، dd MMMM، yyyy",
			"cgr;MMM-yy", "cgr;dd/MM/yyyy hh:mm tt", "cgr;d-MMM-yy"
		}));
		formatters.Add("arn-CL", new Class72("arn-CL", new Class71[1]
		{
			new Class71("gr", new string[7] { "domingo", "lunes", "martes", "miércoles", "jueves", "viernes", "sábado" }, null, new string[13]
			{
				"enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre",
				"noviembre", "diciembre", ""
			}, new string[13]
			{
				"ene", "feb", "mar", "abr", "may", "jun", "jul", "ago", "sep", "oct",
				"nov", "dic", ""
			}, null, null, null)
		}, null, new string[13]
		{
			"cgr;dd-MM-yyyy", "cgr;dddd, dd' de 'MMMM' de 'yyyy", "cgr;dd/MM/yy", "cgr;dd 'de' MMMM 'de' yyyy", "cgr;d-MMM-yy", "cgr;MMMM 'de' yy", "cgr;MMM-yy", "cgr;dd-MM-yyyy H:mm", "cgr;dd-MM-yyyy H:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("az-Cyrl-AZ", new Class72("az-Cyrl-AZ", new Class71[1]
		{
			new Class71("gr", new string[7] { "Базар", "Базар\u00a0ертәси", "Чәршәнбә\u00a0ахшамы", "Чәршәнбә", "Ҹүмә\u00a0ахшамы", "Ҹүмә", "Шәнбә" }, null, new string[13]
			{
				"Јанвар", "Феврал", "Март", "Апрел", "Мај", "Ијун", "Ијул", "Август", "Сентјабр", "Октјабр",
				"Нојабр", "Декабр", ""
			}, new string[13]
			{
				"Јан", "Фев", "Мар", "Апр", "Мај", "Ијун", "Ијул", "Авг", "Сен", "Окт",
				"Ноя", "Дек", ""
			}, null, null, null)
		}, null, new string[13]
		{
			"cgr;dd.MM.yyyy", "cgr;dddd, d MMMM yyyy", "cgr;dd/MM/yy", "cgr;d MMMM yyyy", "cgr;d-MMM-yy", "cgr;MMMM yy", "cgr;MMM-yy", "cgr;dd.MM.yyyy H:mm", "cgr;dd.MM.yyyy H:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("as-IN", new Class72("as-IN", new Class71[1]
		{
			new Class71("gr", new string[7] { "স\u09cbমব\u09beৰ", "মঙ\u09cdগলব\u09beৰ", "ব\u09c1ধব\u09beৰ", "ব\u09c3হস\u09cdপত\u09bfব\u09beৰ", "শ\u09c1ক\u09cdরব\u09beৰ", "শন\u09bfব\u09beৰ", "ৰব\u09bfব\u09beৰ" }, null, new string[13]
			{
				"জ\u09beন\u09c1ৱ\u09beৰ\u09c0", "ফ\u09c7ব\u09cdর\u09c1ৱ\u09beৰ\u09c0", "ম\u09beর\u09cdচ", "এপ\u09cdর\u09bfল", "ম\u09c7", "জ\u09c1ন", "জ\u09c1ল\u09beই", "আগষ\u09cdট", "চ\u09c7প\u09cdট\u09c7ম\u09cdবর", "অক\u09cdট\u09cbবর",
				"নব\u09c7ম\u09cdবর", "ড\u09bfচ\u09c7ম\u09cdবর", ""
			}, new string[13]
			{
				"জ\u09beন\u09c1", "ফ\u09c7ব\u09cdর\u09c1", "ম\u09beর\u09cdচ", "এপ\u09cdর\u09bfল", "ম\u09c7", "জ\u09c1ন", "জ\u09c1ল\u09beই", "আগষ\u09cdট", "চ\u09c7প\u09cdট\u09c7", "অক\u09cdট\u09cb",
				"নব\u09c7", "ড\u09bfচ\u09c7", ""
			}, null, null, new string[2] { "ৰ\u09beত\u09bfপ\u09c1", "আব\u09c7ল\u09bf" })
		}, null, new string[13]
		{
			"cgr;dd-MM-yyyy", "cgr;yyyy,MMMM dd, dddd", "cgr;dd/MM/yy", "cgr;yyyy,MMMM d", "cgr;d-MMM-yy", "", "cgr;MMM-yy", "cgr;dd-MM-yyyy tt h:mm", "cgr;dd-MM-yyyy tt h:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
		formatters.Add("az-Latn-AZ", new Class72("az-Latn-AZ", new Class71[1]
		{
			new Class71("gr", new string[7] { "Bazar", "Bazar\u00a0ertəsi", "Çərşənbə\u00a0axşamı", "Çərşənbə", "Cümə\u00a0axşamı", "Cümə", "Şənbə" }, null, new string[13]
			{
				"Yanvar", "Fevral", "Mart", "Aprel", "May", "İyun", "İyul", "Avgust", "Sentyabr", "Oktyabr",
				"Noyabr", "Dekabr", ""
			}, new string[13]
			{
				"Yan", "Fev", "Mar", "Apr", "May", "İyun", "İyul", "Avg", "Sen", "Okt",
				"Noy", "Dek", ""
			}, null, null, null)
		}, null, new string[13]
		{
			"cgr;dd.MM.yyyy", "cgr;dddd, d MMMM yyyy", "cgr;dd/MM/yy", "cgr;d MMMM yyyy", "cgr;d-MMM-yy", "cgr;MMMM yy", "cgr;MMM-yy", "cgr;dd.MM.yyyy H:mm", "cgr;dd.MM.yyyy H:mm:ss", "cgr;HH:mm",
			"cgr;HH:mm:ss", "cgr;h:mm tt", "cgr;h:mm:ss tt"
		}));
	}

	private Class73()
	{
	}
}
