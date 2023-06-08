using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using x13f1efc79617a47b;
using x88e3d716d9aea406;

namespace x28925c9b27b37a46;

internal class x220f433da4115056
{
	private struct xd3e5f557e5a291e1
	{
		internal readonly string x8616b18a72626f98;

		internal readonly string x1628a74a58e3379e;

		internal xd3e5f557e5a291e1(string oldName, string newName)
		{
			x8616b18a72626f98 = oldName;
			x1628a74a58e3379e = newName;
		}
	}

	private const string x51b8a98a6469193d = "Aspose.";

	private string[] xa445414d77956ef3;

	private xf077e0ca29a2a5af xcc0b303e50da8c7f;

	private string xee69e2871841771a;

	private DateTime x0a5ceea3e0b3a2a9;

	private DateTime x2a11af91f2bda1b2;

	private x58c5e4583e3b6711 x65aad33f2ff6ebda;

	private static x220f433da4115056 x34b2bceb03ebdad9;

	private static Hashtable x419a53174216aa26;

	private static readonly xd3e5f557e5a291e1[] xd48097c689a73c7a = new xd3e5f557e5a291e1[5]
	{
		new xd3e5f557e5a291e1(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dedechkemgbfigifjgpfifggobngeeehjflhjfciieji", 601047810)), string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ohdenkkehkbfdkifekpfdjggjfngphehejlhejcidijipiaj", 433734461))),
		new xd3e5f557e5a291e1(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mgnlljemfjlmbjcncjjnbiaoheholfoolifpdhmpchdaghka", 1305656619)), string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lnjikabjeaijaapjbagkapmkgldlimklhobmloimiopmmogn", 153192858))),
		new xd3e5f557e5a291e1(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("encddakdnpaejphekpoejoffpkmfdmdgdpkglnbhknihonphnjgidmniomejimlj", 1200501395)), string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hoejgbmjabdkmakknablmphlcmolinfmaanmepdnmokn", 1150194854))),
		new xd3e5f557e5a291e1(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jfgfiinfciegohlgphchogjhedaidfhipgoiehfjpfmjjgdkeekkagblhfiljfplmfgm", 815552024)), string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mkkplnbafniabnpacngbbmnbhiecjklcplcdjljdblaepkhekloe", 1848113771))),
		new xd3e5f557e5a291e1(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mdeclglcfgcdbgjdcgaebfhehboegdffffmfpedghekgpdbhkdihieph", 2005148667)), string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("oneinamihadjdakjeabkdphkjlokmnflgomlfpdmkokmpobn", 1879213213)))
	};

	internal string[] x676cd75e30358fc4 => xa445414d77956ef3;

	internal xf077e0ca29a2a5af xf077e0ca29a2a5af => xcc0b303e50da8c7f;

	internal string x7ca3035643c9b13d => xee69e2871841771a;

	internal DateTime x4e27ae11bd85e2a8 => x0a5ceea3e0b3a2a9;

	internal DateTime xac71e4a431176032 => x2a11af91f2bda1b2;

	internal void x7d0214bf69711dd9(string x1c1fc72fe1a3b4ea, Assembly x5807f920b6fc67c4)
	{
		string text;
		switch (xf077e0ca29a2a5af.xbd4904fd691196f5)
		{
		case xf077e0ca29a2a5af.xbd4904fd691196f5:
			text = string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("epcbdbkbnabcbaicnpociagdfandipdelpkehpbfhoifpopf", 1955140260));
			break;
		case xf077e0ca29a2a5af.x4a7d849f65d49ff1:
			text = string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dlkfjnbgmnigkmpgenghpmnhomeicmlijmcjiljj", 605248110));
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("diaofkhokkoocjfpkjmpejdamikafebbhiibdipbfigcnincphedcildohcencjeohafaihfehofggfgmcmg", 2072830010)));
		}
		string text2 = xf077e0ca29a2a5af.xbd4904fd691196f5 switch
		{
			xf077e0ca29a2a5af.xbd4904fd691196f5 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jkhkimokcmflglmlcldmnlkmklbnnkinalpnmkgomjnoekep", 878290777)), 
			xf077e0ca29a2a5af.x4a7d849f65d49ff1 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kinlalemdllmbkcnlkjngkaofkhojjooakfppimp", 1184087365)), 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mkfmommmdndnllkndmbonlioflpooggpalnpmkeaoklaglcbikjblkachkhcgfochkfdjkmdnjdepikeffbf", 1272628579))), 
		};
		if (!x1c1fc72fe1a3b4ea.Equals(""))
		{
			using Stream xcf18e5243f8d5fd = xde6236852622c268(x1c1fc72fe1a3b4ea, x5807f920b6fc67c4);
			x7d0214bf69711dd9(xcf18e5243f8d5fd);
		}
		else
		{
			x34b2bceb03ebdad9 = this;
		}
		text = text2;
		text2 = text;
	}

	internal void x7d0214bf69711dd9(Stream xcf18e5243f8d5fd3)
	{
		if (xcf18e5243f8d5fd3 == null)
		{
			throw new ArgumentNullException("stream");
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(xcf18e5243f8d5fd3);
		xdd1e20b9c89f40c7(xmlDocument);
		Hashtable hashtable = x419a53174216aa26;
		if (hashtable == null)
		{
			hashtable = (x419a53174216aa26 = xdc195f1c5804967a());
		}
		if (hashtable.ContainsKey(xee69e2871841771a))
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("agibbhpbpggcghncacedjglddgcekfjejfafpfhfbgofaffgiamgoedhffkhppaiaeiicepijegjednjcdekjdlkpccllcjlapplbogmocomhcfnnbmngbdofckoebbpmmhpmappfbgabbnaebebopkbnpbclajcelpccngdbaodlpeehpleipcfhojfpjagaphgiooggjfhcomhcndibokilmbjanijcnpjbigkplnklhelgmllklcmjmjmpganilhnclonjkfoikmookdpalkppjbafgia", 1530468364)));
		}
		if (x653127678ccafb25.xd3d1e0b7118994e1 > 0)
		{
			throw new InvalidOperationException("Invalid license signature. Please make sure the license file was not modified.");
		}
		bool flag = false;
		string[] array = xa445414d77956ef3;
		foreach (string text in array)
		{
			if (text.Equals(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lpkjkcckecjkacalbchlabolgnemjplmbbdndbknnpaofaiogloojpfpppmpppdakkkaflbbcnibgmpbcngc", 492346042))))
			{
				flag = true;
				break;
			}
			if (text.Equals(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ldmakgdbegkbagbcbgicafpcgbgdjdndbfeedflendcffejf", 1928662010))) && ".NET".Equals(".NET"))
			{
				flag = true;
				break;
			}
			if (text.Equals(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ikkbhnbcbnicnmpcomgdnlnddieegkleolcfamjfkkagclhgdgogajfhpkmhjkdiljkijkbjejijckpjlegkognkgielpilliicmiijmcjan", 1736055399))))
			{
				flag = true;
				break;
			}
			if (text.Equals(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gjlgfmchpljhllaimlhilkoibhfjhjmjmkdkmkkkljblhkilbfplejgmkjnmkjenfelnafcongjobgapnghp", 528575317))))
			{
				flag = true;
				break;
			}
			if (text.Equals(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bphmacpmkbgngbnnhbeogalommbpcpiphaaahahagpnacafb", 2042939312))) && ".NET".Equals(".NET"))
			{
				flag = true;
				break;
			}
			if (text.Equals(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("pcmoofdpifkpefbaffiaeepakagbadnbfeecfelcedcdaejdkopdhbhegdoeadffccmfaddglbkgjcbhcnhhfpohnagigbnipaejpaljjbck", 873262062))))
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("helfifcgcfjgkaahdfhhneoheefidemijedjlekjkdbkcphkidpkpdgljomledemcdlmedcnnninadaoibhoacookbfpcbmplmcaoakaebbbebibplobabgcbancppddgaldalbenpiemppegpgfionfgpegbolgpochgkjh", 1948998387)));
		}
		DateTime dateTime = DateTime.ParseExact("2012.10.31", string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bdigocpglcghicnhkndigpkidpbjbnijeaakbahk", 778266552)), CultureInfo.InvariantCulture);
		if (dateTime > x0a5ceea3e0b3a2a9)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gkinhlpnblgojgnojlepillpckcaaljanjabjkhbnjobbkfcckmcejddhjkddjbeceieiipekigfmhnfciegiilgehchchjhogaihchingoipgfjobmjpgdkagkkofblfgilpaplifgmcfnmjeenielnoecoafjopdaphpgpfdopndfakdmakddbpdkbidbccohcfcpcocgdobndlbeednkefccfnbjfbbagjbhgfaogfafhdamhoadiiljikabjaaijdapjfpfkfpmkgkdlopklalbmkpimgkpmhjgngnnngoeocololicpmnjpnmaalmhacnoamhfbpmmblldcfmkcdmbdglidjlpdflgeegnealefeklflfcgmkjgnjahhjhhpeohmjfiljmifjdjhikjfjbkaiikoipkhdgllinlchembilmlccnkhjnkgaooghoegoonffpmgmplfdahfkaabbbmfibifpbhagcpfnccbedlfldjaceipiefcafodhfedofncfgmdmglcdhdojhcdbicciiicpimbgjlcnjbndkcclkdbclnajlfmplfbhmebomopenmamnjpcofakojpapnphpopopapfadpmapodbojkbkobckoicfjpchogdcondbneejilehmcfdijfanagpmhgplognmfhnlmhamdidmkiolbjigijllpjhkgkblnkpkelckllfkcmbkjmafanmjhnajonhefoijmojidpdikpldbaiiiahipabigbdhnbbiecmglckhcdbdjd", 1910102098)), x0a5ceea3e0b3a2a9.ToString("dd MMM yyyy", CultureInfo.InvariantCulture), dateTime.ToString("dd MMM yyyy", CultureInfo.InvariantCulture)));
		}
		if (DateTime.Now > x2a11af91f2bda1b2)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hiojijfkcjmkkedldjklnibmeiimdipmjignlinnkheocdlohhcpngjpmhaagchaigoaihfbngmbdgdcjgkcjfbdffidmbpd", 79011379)));
		}
		x65aad33f2ff6ebda = x58c5e4583e3b6711.x912a04090aaf5eef;
		x34b2bceb03ebdad9 = this;
	}

	internal static x58c5e4583e3b6711 x62e56b3bc7bfedfc()
	{
		switch (xf077e0ca29a2a5af.xbd4904fd691196f5)
		{
		case xf077e0ca29a2a5af.xbd4904fd691196f5:
		{
			string text = string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("glhifnoipmfjdmmjpldkkmkkhmblklilnlpljlgmjknmblen", 565675878));
			break;
		}
		case xf077e0ca29a2a5af.x4a7d849f65d49ff1:
		{
			string text = string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dblnjdcomdjokcapedhppcopocfaccmajcdbibkb", 1900010190));
			break;
		}
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nmmepodfepkfmnbgeoigonpggnghpinhbneinmlipmcjhnjjjmakmmhkimokhhflimmlkmdmolkmalbnghin", 943934596)));
		}
		string text2 = xf077e0ca29a2a5af.xbd4904fd691196f5 switch
		{
			xf077e0ca29a2a5af.xbd4904fd691196f5 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cjghblnhlkeipjliljcjgkjjdkakgjhkjjokfjflfimlnidm", 1010136642)), 
			xf077e0ca29a2a5af.x4a7d849f65d49ff1 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gfaomhhophoongfphhmpchdabhkafgbbmgiblfpb", 754638865)), 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("abgmcdnmhdenpblnhccobcjojbapcngpebopabfacbmakbdbmakbpabclaickloclagdnandbaeedpkejlbf", 1602536903))), 
		};
		if (x34b2bceb03ebdad9 != null && x34b2bceb03ebdad9.x65aad33f2ff6ebda != 0 && x653127678ccafb25.x9e6ffc8a97f47090() != 4096)
		{
			return x58c5e4583e3b6711.x912a04090aaf5eef;
		}
		return x58c5e4583e3b6711.xd0f6aaead40783cb;
	}

	internal static void x5fd5ae949fe79926(xf077e0ca29a2a5af xa2408d256f138972, string x1f25abf5fb75e795)
	{
		if (x62e56b3bc7bfedfc() != 0)
		{
			string arg = xa2408d256f138972 switch
			{
				xf077e0ca29a2a5af.xbd4904fd691196f5 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("chkibjbjliijphpjlhgkginkdielghlljhcmfhjmfgannghn", 1257277986)), 
				xf077e0ca29a2a5af.x4a7d849f65d49ff1 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cdnkifellflljecmdfjmoeannehnbeoniefohdmo", 1177660653)), 
				_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cjjjelakjlhkbkokjkfldkmlljdmefkmgjbncjinejpnmjgooinobjepnilpmdcanijapiabdihbfhobldfc", 1326422345))), 
			};
			string arg2 = x34b2bceb03ebdad9.xf077e0ca29a2a5af switch
			{
				xf077e0ca29a2a5af.xbd4904fd691196f5 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fbbeedieocpeccgfobnfjceggclgjbchmbjhibaiiahiaboi", 1540899013)), 
				xf077e0ca29a2a5af.x4a7d849f65d49ff1 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gnelmpllppcmnojmhpancphnbponfofomomolndp", 1175237777)), 
				_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dfadfhhdkhodcgfekgmeegdfmfkffbbghfigdfpgffghnfnhpeeicflioecjnpijoeakafhkeeokgdflmpll", 790900746))), 
			};
			if (xa2408d256f138972 > x34b2bceb03ebdad9.xf077e0ca29a2a5af)
			{
				throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ieknkpaoeeioeooogbgpmcnpbceahclahccbgcjbecackbhckaockbfdiamdmadegbkegmafhlhfiapfjpfghpmgopdhikkhlobihoiiaopiapgjoonjioekinlkajclgnjlnnamhihmdnompmfnkmmnendoihkoglbpimipalppflgaflnahkebfklbmkccckjckfadakhdckodbffejkmemfdffkkffebghgigdipgfighninhpheiciliohcjjdjjkcakjghkjhokfhflobmlehdmhgkmkgbneginpapnifgocfnojeepielpoecaafjapdabhpgbndobeefcoolcbdddhdkdhdbecohekdpeooffgdnfgndgipkgebchgbjhobaiabhidboipafjmmljllckiojkbablhphlapolppfmoommgkdngoknpoboloiooopoingphnnpfoeaoilamkcblnjbfnacbnhccnocbmfdjhmdkmdecmkeahbfcmifklpfokggglngckehcklhakciifjiokajbkhjekojojfkjemkcjdlmikldibmciimiipmkignjhnnpdeo", 7199181)), x1f25abf5fb75e795, arg, arg2));
			}
		}
	}

	internal void xdd1e20b9c89f40c7(XmlDocument x6beba47238e0ade6)
	{
		XmlElement documentElement = x6beba47238e0ade6.DocumentElement;
		XmlElement xmlElement = xed4379b11711a5ca(documentElement, "Data");
		XmlElement x7e15b054ab73fa5b = xed4379b11711a5ca(documentElement, "Signature");
		x2057a6404e6c2b4c(xmlElement, x7e15b054ab73fa5b);
		XmlElement xmlElement2 = xed4379b11711a5ca(xmlElement, "Products");
		XmlNodeList elementsByTagName = xmlElement2.GetElementsByTagName("Product");
		xa445414d77956ef3 = new string[elementsByTagName.Count];
		for (int i = 0; i < elementsByTagName.Count; i++)
		{
			xa445414d77956ef3[i] = x6a1d3b4fdbb7b56f(elementsByTagName[i].InnerText);
		}
		string text = xc79ba7b5665427dc(xmlElement, "EditionType");
		if (text.Equals(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("belgagchkfjhoeaikehiffoicffjfemjiedkeekkedblmdil", 2081450737))))
		{
			xcc0b303e50da8c7f = xf077e0ca29a2a5af.xbd4904fd691196f5;
		}
		else
		{
			if (!text.Equals(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mdnccgedfglddfcenfjeifafhfhfleofcffgbemg", 1152396535))))
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cnijeppjjpgkbonkjoeldolllncmejjmgnancnhnenonmnfoommobndpnmkpmhbanmiapmpadmgbflnblhec", 2111019145)));
			}
			xcc0b303e50da8c7f = xf077e0ca29a2a5af.x4a7d849f65d49ff1;
		}
		xee69e2871841771a = xc79ba7b5665427dc(xmlElement, "SerialNumber");
		x0a5ceea3e0b3a2a9 = xca2f4751a3894a1a(xmlElement, "SubscriptionExpiry");
		x2a11af91f2bda1b2 = xca2f4751a3894a1a(xmlElement, string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("aklcklcdbljdalaeglheiloehkffeimfeldgjkkgpjbhfkihjkph", 342371156)));
	}

	private static string x6a1d3b4fdbb7b56f(string xf865335615dc5536)
	{
		for (int i = 0; i < xd48097c689a73c7a.Length; i++)
		{
			if (xf865335615dc5536.Equals(xd48097c689a73c7a[i].x8616b18a72626f98))
			{
				return xd48097c689a73c7a[i].x1628a74a58e3379e;
			}
		}
		return xf865335615dc5536;
	}

	internal void xdd1e20b9c89f40c7(string xafe2f3653ee64ebc)
	{
		string text;
		switch (xf077e0ca29a2a5af.xbd4904fd691196f5)
		{
		case xf077e0ca29a2a5af.xbd4904fd691196f5:
			text = string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("npijmbakgbhkkaokgaflbbmloadmbakmeabnaainaponipfo", 1891932333));
			break;
		case xf077e0ca29a2a5af.x4a7d849f65d49ff1:
			text = string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bbdmhdkmkdbnicincdpnncgomcnoacephclpgbca", 934789836));
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lbdandkacebbkcibcdpbmcgcecncnnddpbldlbcenbjefcafhbhfkbofgbfgfmlggbdhibkhmabiophiemoi", 228983506)));
		}
		string text2 = xf077e0ca29a2a5af.xbd4904fd691196f5 switch
		{
			xf077e0ca29a2a5af.xbd4904fd691196f5 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ebalddhlncolbcfmnbmmicdnfcknibbolbiohbpohagppanp", 116830148)), 
			xf077e0ca29a2a5af.x4a7d849f65d49ff1 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("efmckhddnhkdlgbefhieahpepggfdgnfkgegjflg", 215297039)), 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fdohhffimfmieedjmekjgebkodikhpokjdglfdnlhdempdlmbdcnedjnadaopngoadoocdfpgcmpibdaonja", 910261740))), 
		};
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(xafe2f3653ee64ebc);
		xdd1e20b9c89f40c7(xmlDocument);
		text = text2;
		text2 = text;
	}

	private static void x2057a6404e6c2b4c(XmlNode xd4fdffba4cd2bd00, XmlNode x7e15b054ab73fa5b)
	{
		string text;
		switch (xf077e0ca29a2a5af.xbd4904fd691196f5)
		{
		case xf077e0ca29a2a5af.xbd4904fd691196f5:
			text = string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("eldbdnkbnmbcbmicnlpcimgdfmndileelllehlcfhkjfpkag", 1421742948));
			break;
		case xf077e0ca29a2a5af.x4a7d849f65d49ff1:
			text = string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("glcfmnjfpnagnmhghnogcnfhbnmhfmdimmkillbj", 1277907569));
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bkphdmgiimnialejilljclckkkjkdgalfkhlbkoldkfmlkmmnjdnakknmjboleiomjpoojgpcjnpeieakela", 1452638040)));
		}
		string text2 = xf077e0ca29a2a5af.xbd4904fd691196f5 switch
		{
			xf077e0ca29a2a5af.xbd4904fd691196f5 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kepnjggodgnohfepdflpofcalfjaoeabbfhbneobndfcfemc", 83812090)), 
			xf077e0ca29a2a5af.x4a7d849f65d49ff1 => string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mfjhciaifihidhoinhfjihmjhhdklgkkchblbgil", 1257077015)), 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ilflknmlpndmhmkmpmbnjminbmpnkhgomlnoilepkllpcmcaeljahlabdlhbcgobdlfcflmcjkddljkdbgbe", 116503919))), 
		};
		string s = ((xd4fdffba4cd2bd00 != null) ? xd4fdffba4cd2bd00.OuterXml : "");
		byte[] bytes = Encoding.Unicode.GetBytes(s);
		string s2 = ((x7e15b054ab73fa5b != null) ? x7e15b054ab73fa5b.InnerText : "");
		byte[] x8ebde9a98df = Convert.FromBase64String(s2);
		string s3 = string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("poddkcldlacelcjekcafopgfcpnfoafglamgmpchibkhkoaibaiiapoihnfjjmmjppdkdalkplblmlilkmplhlgmoknmhmenkmlnnkcoekjofnapcmhpakopcnfaalmajndbgkkbajbcmmicimpcilgdaindnjeenkleihcfhjjfphagaihghioghhfhijmhpjdiekkinjbjogijpgpjdggkminkoielajllbicmhijmpdanlfhnhhonkgfohhmokgdpehkpcfbalfiagcpabcgbidnbobeclblcfbcdkcjdefaemeheiaoefcffndmffedgeekgkpahpdihnbphkbgieanioodjgaljfobkmpikbppkbchllnnlepempammdadnopjnmabonmhoiapobagphanppndajmkailbbjpibgnpbdmgceoncemedholdbnceakjeplafjnhfhlofpkfgbkmgendhljkhojbigiiiljpickgjajnjglekoklkbjclphjllhamhghmlhomihfnajmnbhdobjkoajbpkjipchppnegalinalgebjflbihcclhjcphadcfhdhhodadfeeememgdfngkffgbgigigdcpggbghjdnhndeiecliefcjfejjheakfehkfbokjcflnpllnddmmdkmmbbnbphnlpon", 1752642495));
		string s4 = "AQAB";
		byte[] modulus = Convert.FromBase64String(s3);
		byte[] exponent = Convert.FromBase64String(s4);
		xd402608383e80d3c xd402608383e80d3c = new xd402608383e80d3c(modulus, exponent);
		xd402608383e80d3c.x2057a6404e6c2b4c(bytes, x8ebde9a98df);
		text = text2;
		text2 = text;
	}

	private static Stream xde6236852622c268(string x1c1fc72fe1a3b4ea, Assembly x39e0a96279c40baa)
	{
		string path = x1c1fc72fe1a3b4ea;
		if (File.Exists(path))
		{
			return File.OpenRead(path);
		}
		path = xdd464f895516da3e(x1c1fc72fe1a3b4ea, Assembly.GetExecutingAssembly());
		if (File.Exists(path))
		{
			return File.OpenRead(path);
		}
		path = xdd464f895516da3e(x1c1fc72fe1a3b4ea, x39e0a96279c40baa);
		if (File.Exists(path))
		{
			return File.OpenRead(path);
		}
		Assembly entryAssembly = Assembly.GetEntryAssembly();
		if (entryAssembly != null)
		{
			path = xdd464f895516da3e(x1c1fc72fe1a3b4ea, entryAssembly);
			if (File.Exists(path))
			{
				return File.OpenRead(path);
			}
		}
		Stream stream = x0004f58017c756bc(x39e0a96279c40baa, x1c1fc72fe1a3b4ea);
		if (stream != null)
		{
			return stream;
		}
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		Assembly[] array = assemblies;
		foreach (Assembly xd3764619ec304ff in array)
		{
			stream = x0004f58017c756bc(xd3764619ec304ff, x1c1fc72fe1a3b4ea);
			if (stream != null)
			{
				return stream;
			}
		}
		throw new FileNotFoundException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("macnhcjnbdaoochomcooocfphnlpkbdakbkambbbpaibimobbbgclanccaedbaldhacejajeippealgfelnffafghllgbadhikjhmkai", 1584714185)), x1c1fc72fe1a3b4ea));
	}

	internal static string xdd464f895516da3e(string xafe2f3653ee64ebc, Assembly xd3764619ec304ff0)
	{
		return Path.Combine(x9b6c749de2abbbfb(xd3764619ec304ff0), xafe2f3653ee64ebc);
	}

	private static string x9b6c749de2abbbfb(Assembly xd3764619ec304ff0)
	{
		Uri uri = new Uri(xd3764619ec304ff0.CodeBase);
		return Path.GetDirectoryName(uri.LocalPath);
	}

	private static Stream x0004f58017c756bc(Assembly xd3764619ec304ff0, string xf3a1146bd8778bac)
	{
		string[] manifestResourceNames = xd3764619ec304ff0.GetManifestResourceNames();
		string[] array = manifestResourceNames;
		foreach (string text in array)
		{
			if (text.IndexOf(xf3a1146bd8778bac) != -1)
			{
				return xd3764619ec304ff0.GetManifestResourceStream(text);
			}
		}
		return null;
	}

	private static string xc79ba7b5665427dc(XmlElement x0ef2217e41c111e4, string xaeb3f027cd164120)
	{
		XmlElement xmlElement = xed4379b11711a5ca(x0ef2217e41c111e4, xaeb3f027cd164120);
		if (xmlElement == null)
		{
			return "";
		}
		return xmlElement.InnerText;
	}

	private static DateTime xca2f4751a3894a1a(XmlElement x0ef2217e41c111e4, string xaeb3f027cd164120)
	{
		string text = xc79ba7b5665427dc(x0ef2217e41c111e4, xaeb3f027cd164120);
		if (!text.Equals(""))
		{
			return DateTime.ParseExact(text, string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bpkfoobgloigiopgjlghglnhkmeihmli", 114711160)), CultureInfo.InvariantCulture);
		}
		return DateTime.MaxValue;
	}

	private static XmlElement xed4379b11711a5ca(XmlElement x0ef2217e41c111e4, string xaeb3f027cd164120)
	{
		XmlNodeList elementsByTagName = x0ef2217e41c111e4.GetElementsByTagName(xaeb3f027cd164120);
		if (elementsByTagName.Count <= 0)
		{
			return null;
		}
		return (XmlElement)elementsByTagName[0];
	}

	private static Hashtable xdc195f1c5804967a()
	{
		Stream stream = x0004f58017c756bc(Assembly.GetExecutingAssembly(), string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nlhjmoojgofkcomkdodlcnklijbmdlimnmpmemgndmnnjmeolmloklcpaijpbjaailhakkoajkfbokmbmidcgkkcnkbdlkid", 1021482876)));
		if (stream == null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nddhifkhcgbipfiinfpipfgjianjleeklelkneclaejljpplidhmpdombdfnadmnfddohojoadbpkcipbdpppcganbnajbebcnkblbccfbjcmaadlahdbboddbfecamenadfhljfgabggphgbapgkpfhnpmhhpdifokieobjkkijjjpjgmgkpnnkfnelomllnncmmmjmeiandnhndmonlmfohmmohmdpgmkppgbaamiablpapkgbglnbageccklcmkcdjkjddkaedkheoeoepjffhjmffedgdgkgcjbhmiihiiphjigiihniodej", 2068673274)));
		}
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(stream);
			XmlElement documentElement = xmlDocument.DocumentElement;
			XmlElement xmlElement = xed4379b11711a5ca(documentElement, "Data");
			XmlNode x7e15b054ab73fa5b = xed4379b11711a5ca(documentElement, "Signature");
			x2057a6404e6c2b4c(xmlElement, x7e15b054ab73fa5b);
			Hashtable hashtable = new Hashtable();
			XmlNodeList elementsByTagName = xmlElement.GetElementsByTagName("SN");
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				hashtable[elementsByTagName[i].InnerText] = null;
			}
			return hashtable;
		}
		finally
		{
			stream.Close();
		}
	}
}
