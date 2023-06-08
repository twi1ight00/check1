using System.Collections;
using System.Text.RegularExpressions;

namespace x7c4557e104065fc9;

internal class x116c8d451bdca7af
{
	private static readonly Hashtable x53530c8778ac6354;

	private static readonly Regex xe2b04121f4cac8a9;

	internal static string xc4ae649c0fe7bc8a(string xdeb9b8034c9e8cc2)
	{
		xdeb9b8034c9e8cc2 = xdeb9b8034c9e8cc2.ToLower();
		object obj = x53530c8778ac6354[xdeb9b8034c9e8cc2];
		if (obj == null)
		{
			Match match = xe2b04121f4cac8a9.Match(xdeb9b8034c9e8cc2);
			if (match.Success)
			{
				obj = x53530c8778ac6354[match.Value];
			}
		}
		return (string)obj;
	}

	static x116c8d451bdca7af()
	{
		xe2b04121f4cac8a9 = new Regex("arial|book|cambria|century gothic|copperplate gothic|courier|franklin gothic|garamond|gill sans|helv|microsoft sans serif|myriad|nimbus sans|palatino|script|tahoma|times|trebuchet|verdana|wingdings", RegexOptions.Compiled);
		x53530c8778ac6354 = new Hashtable();
		x53530c8778ac6354.Add("adobe caslon pro", "serif");
		x53530c8778ac6354.Add("adobe minion cyrillic", "serif");
		x53530c8778ac6354.Add("adobe poetica", "cursive");
		x53530c8778ac6354.Add("adobecorpid minionpkg", "monospace");
		x53530c8778ac6354.Add("akzidenz grotesk", "sans-serif");
		x53530c8778ac6354.Add("akzidenzgroteskbq-ligcnd", "monospace");
		x53530c8778ac6354.Add("akzidenzgroteskbq-reg", "monospace");
		x53530c8778ac6354.Add("albany", "sans-serif");
		x53530c8778ac6354.Add("albany amt", "sans-serif");
		x53530c8778ac6354.Add("albertus", "sans-serif");
		x53530c8778ac6354.Add("albertus medium", "sans-serif");
		x53530c8778ac6354.Add("algerian", "fantasy");
		x53530c8778ac6354.Add("alpha geometrique", "fantasy");
		x53530c8778ac6354.Add("arial", "sans-serif");
		x53530c8778ac6354.Add("attika", "sans-serif");
		x53530c8778ac6354.Add("avantgarde", "sans-serif");
		x53530c8778ac6354.Add("avenir 45", "sans-serif");
		x53530c8778ac6354.Add("avenir 55", "sans-serif");
		x53530c8778ac6354.Add("bastion", "sans-serif");
		x53530c8778ac6354.Add("batang", "serif");
		x53530c8778ac6354.Add("batangche", "monospace");
		x53530c8778ac6354.Add("bauhaus 93", "fantasy");
		x53530c8778ac6354.Add("bauhaus light", "sans-serif");
		x53530c8778ac6354.Add("berlin sans fb", "sans-serif");
		x53530c8778ac6354.Add("bernhardmod bt", "serif");
		x53530c8778ac6354.Add("bitstream charter", "serif");
		x53530c8778ac6354.Add("bitstream cyberbit", "serif");
		x53530c8778ac6354.Add("bitstream vera sans", "sans-serif");
		x53530c8778ac6354.Add("bitstream vera sans mono", "monospace");
		x53530c8778ac6354.Add("bitstream vera sans oblique", "sans-serif");
		x53530c8778ac6354.Add("bitstream vera serif", "serif");
		x53530c8778ac6354.Add("blackadder itc", "fantasy");
		x53530c8778ac6354.Add("blackoak std", "monospace");
		x53530c8778ac6354.Add("bmo nesbitt burns pi", "sans-serif");
		x53530c8778ac6354.Add("bodoni", "serif");
		x53530c8778ac6354.Add("book", "serif");
		x53530c8778ac6354.Add("broadway", "fantasy");
		x53530c8778ac6354.Add("calibri", "sans-serif");
		x53530c8778ac6354.Add("calisto mt", "serif");
		x53530c8778ac6354.Add("cambria", "serif");
		x53530c8778ac6354.Add("castellar", "serif");
		x53530c8778ac6354.Add("century", "serif");
		x53530c8778ac6354.Add("century gothic", "sans-serif");
		x53530c8778ac6354.Add("cg omega", "sans-serif");
		x53530c8778ac6354.Add("charlesworth", "fantasy");
		x53530c8778ac6354.Add("charter bt", "serif");
		x53530c8778ac6354.Add("chicago", "serif");
		x53530c8778ac6354.Add("comic sans ms", "cursive");
		x53530c8778ac6354.Add("consolas", "monospace");
		x53530c8778ac6354.Add("cooper black", "serif");
		x53530c8778ac6354.Add("copperplate gothic", "sans-serif");
		x53530c8778ac6354.Add("corsiva", "cursive");
		x53530c8778ac6354.Add("cottonwood", "fantasy");
		x53530c8778ac6354.Add("courier", "monospace");
		x53530c8778ac6354.Add("courier new", "monospace");
		x53530c8778ac6354.Add("critter", "fantasy");
		x53530c8778ac6354.Add("cumberland", "monospace");
		x53530c8778ac6354.Add("cumberland amt", "monospace");
		x53530c8778ac6354.Add("dauphin", "serif");
		x53530c8778ac6354.Add("dejavu sans mono", "sans-serif");
		x53530c8778ac6354.Add("din-light", "sans-serif");
		x53530c8778ac6354.Add("din-medium", "sans-serif");
		x53530c8778ac6354.Add("dinmittelschrift", "sans-serif");
		x53530c8778ac6354.Add("din-regular", "sans-serif");
		x53530c8778ac6354.Add("dotumche", "monospace");
		x53530c8778ac6354.Add("er bukinst", "serif");
		x53530c8778ac6354.Add("er kurier", "monospace");
		x53530c8778ac6354.Add("er univers", "sans-serif");
		x53530c8778ac6354.Add("eras demi itc", "sans-serif");
		x53530c8778ac6354.Add("estrangelo edessa", "cursive");
		x53530c8778ac6354.Add("everson mono", "monospace");
		x53530c8778ac6354.Add("ex ponto", "cursive");
		x53530c8778ac6354.Add("excelcior cyrillic upright", "serif");
		x53530c8778ac6354.Add("fb reactor", "fantasy");
		x53530c8778ac6354.Add("felix titling", "fantasy");
		x53530c8778ac6354.Add("footlight mt light", "serif");
		x53530c8778ac6354.Add("franklin gothic", "sans-serif");
		x53530c8778ac6354.Add("freesans", "sans-serif");
		x53530c8778ac6354.Add("friz quadrata", "serif");
		x53530c8778ac6354.Add("frutiger 55 roman", "sans-serif");
		x53530c8778ac6354.Add("futura", "serif");
		x53530c8778ac6354.Add("galliard", "serif");
		x53530c8778ac6354.Add("garamond", "serif");
		x53530c8778ac6354.Add("ge inspira", "sans-serif");
		x53530c8778ac6354.Add("geneva", "sans-serif");
		x53530c8778ac6354.Add("georgia", "serif");
		x53530c8778ac6354.Add("gill sans", "sans-serif");
		x53530c8778ac6354.Add("goudy old style", "serif");
		x53530c8778ac6354.Add("gulim", "sans-serif");
		x53530c8778ac6354.Add("gulimche", "monospace");
		x53530c8778ac6354.Add("haettenschweiler", "sans-serif");
		x53530c8778ac6354.Add("helv", "sans-serif");
		x53530c8778ac6354.Add("helvetica", "sans-serif");
		x53530c8778ac6354.Add("impact", "sans-serif");
		x53530c8778ac6354.Add("imprint mt shadow", "fantasy");
		x53530c8778ac6354.Add("ipa pゴシック1", "monospace");
		x53530c8778ac6354.Add("iso-font", "serif");
		x53530c8778ac6354.Add("itc avant garde gothic", "sans-serif");
		x53530c8778ac6354.Add("itc stone sans", "sans-serif");
		x53530c8778ac6354.Add("itc stone serif", "serif");
		x53530c8778ac6354.Add("kix barcode", "sans-serif");
		x53530c8778ac6354.Add("letter gothic", "monospace");
		x53530c8778ac6354.Add("letter gothic mt", "monospace");
		x53530c8778ac6354.Add("lucida bright", "serif");
		x53530c8778ac6354.Add("lucida calligraphy", "cursive");
		x53530c8778ac6354.Add("lucida console", "monospace");
		x53530c8778ac6354.Add("lucida sans typewriter", "monospace");
		x53530c8778ac6354.Add("lucida sans unicode", "sans-serif");
		x53530c8778ac6354.Add("maiola-bolditalic", "monospace");
		x53530c8778ac6354.Add("map symbols", "serif");
		x53530c8778ac6354.Add("microsoft sans serif", "sans-serif");
		x53530c8778ac6354.Add("microsoftlogo95", "serif");
		x53530c8778ac6354.Add("minion web", "serif");
		x53530c8778ac6354.Add("modern no. 20", "serif");
		x53530c8778ac6354.Add("monaco", "monospace");
		x53530c8778ac6354.Add("monotype albion 70", "serif");
		x53530c8778ac6354.Add("monotype corsiva", "cursive");
		x53530c8778ac6354.Add("ms georgia", "serif");
		x53530c8778ac6354.Add("ms gothic", "monospace");
		x53530c8778ac6354.Add("ms mincho", "serif");
		x53530c8778ac6354.Add("ms pgothic", "sans-serif");
		x53530c8778ac6354.Add("ms shell dlg", "sans-serif");
		x53530c8778ac6354.Add("myriad", "sans-serif");
		x53530c8778ac6354.Add("new york", "serif");
		x53530c8778ac6354.Add("nimbus mono l", "monospace");
		x53530c8778ac6354.Add("nimbus sans", "sans-serif");
		x53530c8778ac6354.Add("old english text mt", "cursive");
		x53530c8778ac6354.Add("optima", "sans-serif");
		x53530c8778ac6354.Add("palatino", "serif");
		x53530c8778ac6354.Add("playbill", "fantasy");
		x53530c8778ac6354.Add("pmingliu", "serif");
		x53530c8778ac6354.Add("prestige", "monospace");
		x53530c8778ac6354.Add("rockwell", "serif");
		x53530c8778ac6354.Add("roman", "serif");
		x53530c8778ac6354.Add("sabon mt", "serif");
		x53530c8778ac6354.Add("sanvito", "cursive");
		x53530c8778ac6354.Add("sapdings", "monospace");
		x53530c8778ac6354.Add("scalasans-regular", "sans-serif");
		x53530c8778ac6354.Add("script", "cursive");
		x53530c8778ac6354.Add("signet roundhand", "cursive");
		x53530c8778ac6354.Add("signs", "sans-serif");
		x53530c8778ac6354.Add("simsun", "serif");
		x53530c8778ac6354.Add("snell roundhand", "cursive");
		x53530c8778ac6354.Add("studz", "fantasy");
		x53530c8778ac6354.Add("swis721 lt bt", "sans-serif");
		x53530c8778ac6354.Add("swiss", "sans-serif");
		x53530c8778ac6354.Add("sylfaen", "serif");
		x53530c8778ac6354.Add("symbol", "serif");
		x53530c8778ac6354.Add("tahoma", "sans-serif");
		x53530c8778ac6354.Add("thorndale", "serif");
		x53530c8778ac6354.Add("thorndale amt", "serif");
		x53530c8778ac6354.Add("times", "serif");
		x53530c8778ac6354.Add("times new roman", "serif");
		x53530c8778ac6354.Add("tktypebold", "sans-serif");
		x53530c8778ac6354.Add("tms rmn", "serif");
		x53530c8778ac6354.Add("tpg kpn pensioen", "sans-serif");
		x53530c8778ac6354.Add("tradegothic", "sans-serif");
		x53530c8778ac6354.Add("trebuchet", "sans-serif");
		x53530c8778ac6354.Add("tw cen mt", "sans-serif");
		x53530c8778ac6354.Add("tw cen mt condensed", "sans-serif");
		x53530c8778ac6354.Add("typiko new era", "sans-serif");
		x53530c8778ac6354.Add("univers", "sans-serif");
		x53530c8778ac6354.Add("univers (w1)", "sans-serif");
		x53530c8778ac6354.Add("univers ce", "sans-serif");
		x53530c8778ac6354.Add("universalmath1 bt", "serif");
		x53530c8778ac6354.Add("utopia", "serif");
		x53530c8778ac6354.Add("verdana", "sans-serif");
		x53530c8778ac6354.Add("wachovia celeste", "serif");
		x53530c8778ac6354.Add("water on the oil", "sans-serif");
		x53530c8778ac6354.Add("webdings", "serif");
		x53530c8778ac6354.Add("wingdings", "serif");
		x53530c8778ac6354.Add("zapf-chancery", "cursive");
		x53530c8778ac6354.Add("zapfdingbats", "fantasy");
		x53530c8778ac6354.Add("zapfhumnst bt", "sans-serif");
		x53530c8778ac6354.Add("ヒラギノ角ゴ pro w3", "serif");
		x53530c8778ac6354.Add("ヒラギノ角ゴ pro w6", "serif");
		x53530c8778ac6354.Add("新細明體", "serif");
	}
}
