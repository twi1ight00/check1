using System.Collections;
using x28925c9b27b37a46;
using x556d8f9846e43329;
using xf989f31a236ff98c;

namespace x639ad3f66698fe1b;

internal class x9cb1edcd9725c81e
{
	private const int xef81b5be38207697 = 29;

	private const int x3b8497e6bbab85bd = 6;

	private const int x0c7a7f13adbb0d1b = 5;

	private readonly string x90437c98ce7f3d09;

	private readonly string xce90a021418df459;

	private readonly string xe25839ff13f606af;

	private readonly string x4c0df57115051c95;

	private readonly x000f21cbda739311 xb3550b2db5863ccb;

	private readonly bool xa73fdd7910f7028c;

	private readonly x1eec46d494a92718 xcbb460c1f6be6309;

	private readonly x1eec46d494a92718 x8513e5a9751664f3;

	private readonly ArrayList xbc208eee162131c0 = new ArrayList(29);

	private readonly ArrayList xaf59ae68ca2e1e6c = new ArrayList(6);

	private readonly ArrayList xe0e723c4291a4ab2 = new ArrayList(5);

	internal string x51cf23ce6e71b84c => x90437c98ce7f3d09;

	internal string x31ece097bda75a20 => xe25839ff13f606af;

	internal string xd08cbc518cf39317 => x4c0df57115051c95;

	internal x000f21cbda739311 x405f93d712e7bd65 => xb3550b2db5863ccb;

	internal bool x4709d73d132a99cb => xa73fdd7910f7028c;

	internal x1eec46d494a92718 xcedf9c82728ad579 => xcbb460c1f6be6309;

	internal x1eec46d494a92718 xd4e922ceeed89b74 => x8513e5a9751664f3;

	internal ArrayList xdd2c7b955dcd3f70 => xbc208eee162131c0;

	internal ArrayList x10da5e0a6e84ba64 => xaf59ae68ca2e1e6c;

	internal ArrayList x009293a054486e8d => xe0e723c4291a4ab2;

	internal bool xaf983f33c1f4f82f
	{
		get
		{
			if (xcbb460c1f6be6309 != x1eec46d494a92718.xbbad6bbe73c6b1dc)
			{
				return x8513e5a9751664f3 == x1eec46d494a92718.xbbad6bbe73c6b1dc;
			}
			return true;
		}
	}

	internal x9cb1edcd9725c81e(xeedad81aaed42a76 runPr)
	{
		for (int i = 0; i < runPr.xd44988f225497f3a; i++)
		{
			int num = runPr.xf15263674eb297bb(i);
			object obj = runPr.x6d3720b962bd3112(i);
			switch (num)
			{
			case 12:
			case 14:
			case 20:
			case 30:
			case 40:
			case 45:
			case 50:
			case 80:
			case 90:
			case 100:
			case 110:
			case 120:
			case 130:
			case 132:
			case 140:
			case 150:
			case 160:
			case 170:
			case 180:
			case 200:
			case 210:
			case 220:
			case 290:
			case 300:
			case 310:
			case 360:
			case 370:
			case 450:
			case 770:
			case 780:
				xbc208eee162131c0.Add(new xfd5f3842a71dd76e(num, obj));
				break;
			case 265:
				xcbb460c1f6be6309 = ((!((x9b28b1f7f0cc963f)obj).x4e98cd0cf854343f()) ? x1eec46d494a92718.x12642456c7bf0815 : x1eec46d494a92718.xbbad6bbe73c6b1dc);
				break;
			case 268:
				x8513e5a9751664f3 = ((!((x9b28b1f7f0cc963f)obj).x4e98cd0cf854343f()) ? x1eec46d494a92718.x12642456c7bf0815 : x1eec46d494a92718.xbbad6bbe73c6b1dc);
				break;
			case 440:
				xbc208eee162131c0.Add(new xfd5f3842a71dd76e(num, obj));
				xa73fdd7910f7028c = true;
				break;
			case 240:
				x4c0df57115051c95 = (string)obj;
				break;
			case 235:
				xe25839ff13f606af = (string)obj;
				break;
			case 400:
				xb3550b2db5863ccb = (x000f21cbda739311)obj;
				break;
			case 230:
				xaf59ae68ca2e1e6c.Add(new xfd5f3842a71dd76e(num, obj));
				x90437c98ce7f3d09 = (string)obj;
				break;
			case 60:
			case 70:
			case 190:
			case 380:
			case 390:
				xaf59ae68ca2e1e6c.Add(new xfd5f3842a71dd76e(num, obj));
				break;
			case 270:
				xe0e723c4291a4ab2.Add(new xfd5f3842a71dd76e(num, obj));
				xce90a021418df459 = (string)obj;
				break;
			case 250:
			case 260:
			case 340:
			case 350:
				xe0e723c4291a4ab2.Add(new xfd5f3842a71dd76e(num, obj));
				break;
			}
		}
	}

	internal string xaf95fb496eb25433(x000f21cbda739311 x6f02b6a80bf6b36f)
	{
		return xb7dbd7bb3ed97d5b.x4a59367ba6527b94(x6f02b6a80bf6b36f, x90437c98ce7f3d09, xce90a021418df459, xe25839ff13f606af, x4c0df57115051c95);
	}
}
