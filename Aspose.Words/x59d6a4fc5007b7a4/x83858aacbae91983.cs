using System.Collections;
using xb1090543d168d647;

namespace x59d6a4fc5007b7a4;

internal class x83858aacbae91983 : xc2469d942acfbc3d
{
	private static readonly Hashtable x201f7b5a9df3dd53;

	internal x83858aacbae91983(x91866f79774c2b6a shapingWorkspace)
		: base(shapingWorkspace)
	{
	}

	internal override void x550781f8db1cf5f2()
	{
		char xb867a42da3ae686d = '\uffff';
		int x30cc7819189f11b = 0;
		for (int i = 0; i < xb14db7591535b378.x1be93eed8950d961; i++)
		{
			char c = xb14db7591535b378.get_xe6d4b1b411ed94b5(i);
			if (xd9a6b2b6ada137e6.xdcb014d94aea6e74(c) == x610f9b736060774c.x48ce0d46d6b8c1d4)
			{
				xb867a42da3ae686d = c;
				x30cc7819189f11b = xf18f3b887970dbc4.x1be93eed8950d961;
			}
			string key = xb867a42da3ae686d.ToString() + c;
			if (x201f7b5a9df3dd53.ContainsKey(key))
			{
				xb867a42da3ae686d = (char)x201f7b5a9df3dd53[key];
				xb6b8f962814600b2(x30cc7819189f11b, xb867a42da3ae686d);
			}
			else
			{
				xf18f3b887970dbc4.x917b69030691beda(c, i);
			}
		}
		xf18f3b887970dbc4.xcd5f7940e9d851bd();
	}

	static x83858aacbae91983()
	{
		x201f7b5a9df3dd53 = new Hashtable();
		x201f7b5a9df3dd53["ש\u05c1"] = 'שׁ';
		x201f7b5a9df3dd53["ש\u05c2"] = 'שׂ';
		x201f7b5a9df3dd53["שּ\u05c1"] = 'שּׁ';
		x201f7b5a9df3dd53["שּ\u05c2"] = 'שּׂ';
		x201f7b5a9df3dd53["א\u05b7"] = 'אַ';
		x201f7b5a9df3dd53["א\u05b8"] = 'אָ';
		x201f7b5a9df3dd53["א\u05bc"] = 'אּ';
		x201f7b5a9df3dd53["ב\u05bc"] = 'בּ';
		x201f7b5a9df3dd53["ג\u05bc"] = 'גּ';
		x201f7b5a9df3dd53["ד\u05bc"] = 'דּ';
		x201f7b5a9df3dd53["ה\u05bc"] = 'הּ';
		x201f7b5a9df3dd53["ו\u05bc"] = 'וּ';
		x201f7b5a9df3dd53["ז\u05bc"] = 'זּ';
		x201f7b5a9df3dd53["ט\u05bc"] = 'טּ';
		x201f7b5a9df3dd53["י\u05bc"] = 'יּ';
		x201f7b5a9df3dd53["ך\u05bc"] = 'ךּ';
		x201f7b5a9df3dd53["כ\u05bc"] = 'כּ';
		x201f7b5a9df3dd53["ל\u05bc"] = 'לּ';
		x201f7b5a9df3dd53["מ\u05bc"] = 'מּ';
		x201f7b5a9df3dd53["נ\u05bc"] = 'נּ';
		x201f7b5a9df3dd53["ס\u05bc"] = 'סּ';
		x201f7b5a9df3dd53["ף\u05bc"] = 'ףּ';
		x201f7b5a9df3dd53["פ\u05bc"] = 'פּ';
		x201f7b5a9df3dd53["צ\u05bc"] = 'צּ';
		x201f7b5a9df3dd53["ק\u05bc"] = 'קּ';
		x201f7b5a9df3dd53["ר\u05bc"] = 'רּ';
		x201f7b5a9df3dd53["ש\u05bc"] = 'שּ';
		x201f7b5a9df3dd53["ת\u05bc"] = 'תּ';
		x201f7b5a9df3dd53["ו\u05b9"] = 'וֹ';
		x201f7b5a9df3dd53["ב\u05bf"] = 'בֿ';
		x201f7b5a9df3dd53["כ\u05bf"] = 'כֿ';
		x201f7b5a9df3dd53["פ\u05bf"] = 'פֿ';
	}
}
