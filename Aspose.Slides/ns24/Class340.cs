using System;
using System.Collections.Generic;
using ns33;
using ns56;

namespace ns24;

internal class Class340 : Class278
{
	private static readonly Class1151 class1151_0 = new Class1151("Arab", "Armn", "Beng", "Bopo", "Cher", "Qaac", "Cyrl", "Dsrt", "Deva", "Ethi", "Geor", "Goth", "Grek", "Gujr", "Guru", "Hani", "Hang", "Hebr", "Hira", "Knda", "Kana", "Khmr", "Laoo", "Latn", "Mlym", "Mong", "Mymr", "Ogam", "Ital", "Orya", "Runr", "Sinh", "Syrc", "Taml", "Telu", "Thaa", "Thai", "Tibt", "Cans", "Yiii", "Tglg", "Hano", "Buhd", "Tagb", "Brai", "Cprt", "Limb", "Osma", "Shaw", "Linb", "Tale", "Ugar", "Talu", "Bugi", "Glag", "Tfng", "Sylo", "Xpeo", "Khar", "Bali", "Xsux", "Phnx", "Phag", "Nkoo", "Kali", "Lepc", "Rjng", "Sund", "Saur", "Cham", "Olck", "Vaii", "Cari", "Lyci", "Lydi");

	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

	private Class1885 class1885_0;

	public Dictionary<string, string> Fonts => dictionary_0;

	public Class1885 ExtensionList
	{
		get
		{
			return class1885_0;
		}
		set
		{
			class1885_0 = value;
		}
	}

	public void method_0(string script, string typeface)
	{
		dictionary_0.Add(script, typeface);
	}
}
