using System;
using Aspose.Words;
using x13f1efc79617a47b;
using x59d6a4fc5007b7a4;

namespace xb3b3ff3836e35ac5;

internal class x442fa4fe5ac3b905
{
	private const float xa3ba5b7db026df15 = 0.0125f;

	private const float x31732ac4247ac68e = 0.05f;

	private const float xae7cd73c4f2ff8f5 = 0.075f;

	private const float xbcdebc28f7f9eda8 = 0.025f;

	private const float xb7406e7df3e97511 = 0.1f;

	private const float xacdb8f52696e21b1 = 0.0375f;

	private const float xe395e73d2bb2bbf5 = 0.1375f;

	private const float xc557b1e3c865056d = 0.1f;

	private const float xec917a978f12869c = 0.112500004f;

	private const float x0e1a3946fb23efe1 = 0.1f;

	private const float x875a983bb5bd09e6 = 0.1f;

	private const float x58289e1eb8e21b82 = 0.05f;

	private const float xa45e467a3a097b9e = 0.15f;

	private const float xcc1f6d7c2363545e = 0.0625f;

	private const float xe60387bb06f21847 = 0.16250001f;

	private const float xc61362af1fbb72f5 = 0.112500004f;

	private const float x039434219dab8466 = 0.1375f;

	private Underline xb1ea9576066f2aaa;

	private float xf609db124803ff96;

	private float x7b733fe8325058a5;

	private float[] x3b67bfefd773456e = new float[2];

	private int x19aa52c865f3160d;

	private static readonly float[] x36ef32bc43ce6597 = new float[2] { 0.075f, 0.15f };

	private static readonly float[] xecdec4435136677e = new float[2] { 0.0875f, 0.1375f };

	private static readonly float[] x7252729bf855504d = new float[2] { 0.0875f, 0.1875f };

	private static readonly float[] x18ab20366af21117 = new float[2] { 0.1f, 0.175f };

	internal float x3e678b4c8e5924ae => xf609db124803ff96 / (float)x19aa52c865f3160d;

	internal float x475dd4456657c57c => x7b733fe8325058a5 / (float)x19aa52c865f3160d;

	internal float[] x3684f71bb8ea1d65
	{
		get
		{
			float[] array = (float[])x3b67bfefd773456e.Clone();
			array[0] /= x19aa52c865f3160d;
			array[1] /= x19aa52c865f3160d;
			return array;
		}
	}

	internal x442fa4fe5ac3b905(x038d2057eb729fcf span)
	{
		xb1ea9576066f2aaa = span.xc2d4efc42998d87b.Underline;
	}

	internal void x9682faecb1d1a8a5(x038d2057eb729fcf x5906905c888d3d98)
	{
		if (!x5906905c888d3d98.xc2d4efc42998d87b.Hidden && x5906905c888d3d98.xc2d4efc42998d87b.Underline != xb1ea9576066f2aaa)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("iejgagahkfhhgfohmeficamiefdjkekjndbkldikfepkmdglgdnlidemmclmeobnfdjnhdaolchonboodoep", 1370384625)), "span");
		}
		int num = ((x5906905c888d3d98.xf9ad6fb78355fe13 == null) ? 1 : x5906905c888d3d98.xf9ad6fb78355fe13.Length);
		xf609db124803ff96 += x510e6cab26eb08dd(x5906905c888d3d98.xc2d4efc42998d87b) * (float)num;
		if (!x54afa1405121518f.x4f0ec65105795df7(x5906905c888d3d98.xc2d4efc42998d87b.Underline))
		{
			x7b733fe8325058a5 += x37cd5bc0046495e1(x5906905c888d3d98.xc2d4efc42998d87b) * (float)num;
		}
		else
		{
			float[] array = xfbcc51b13011ed59(x5906905c888d3d98.xc2d4efc42998d87b);
			x3b67bfefd773456e[0] += array[0] * (float)num;
			x3b67bfefd773456e[1] += array[1] * (float)num;
		}
		x19aa52c865f3160d += num;
	}

	private static float x510e6cab26eb08dd(Font x26094932cf7a9139)
	{
		if (x26094932cf7a9139.Hidden)
		{
			return 1f;
		}
		float num;
		switch (x26094932cf7a9139.Underline)
		{
		case Underline.Single:
		case Underline.Words:
		case Underline.Dotted:
		case Underline.Dash:
		case Underline.DotDash:
		case Underline.DotDotDash:
		case Underline.DashLong:
			num = (x26094932cf7a9139.Bold ? 0.1f : 0.05f);
			break;
		case Underline.Thick:
		case Underline.DottedHeavy:
		case Underline.DashHeavy:
		case Underline.DotDashHeavy:
		case Underline.DotDotDashHeavy:
		case Underline.DashLongHeavy:
			num = (x26094932cf7a9139.Bold ? 0.1f : 0.075f);
			break;
		case Underline.Double:
			num = (x26094932cf7a9139.Bold ? 0.05f : 0.025f);
			break;
		case Underline.Wavy:
		case Underline.WavyHeavy:
			num = (x26094932cf7a9139.Bold ? 0.15f : 0.1f);
			break;
		case Underline.WavyDouble:
			num = (x26094932cf7a9139.Bold ? 0.0625f : 0.0375f);
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("aagggbngkaehkblhpacibajimppikahjipnjepeknklkppclfpjlioamgohmapomhofnbomndodohnkopibpaoipcoppgngaimnaoieb", 2135319979)));
		}
		return x26094932cf7a9139.xe286def5a6a116b8(x282df02f8c72bc6f: true) * num;
	}

	private static float x37cd5bc0046495e1(Font x26094932cf7a9139)
	{
		float num;
		if (x26094932cf7a9139.Hidden)
		{
			num = (x26094932cf7a9139.Bold ? 0.16250001f : 0.1375f);
		}
		else
		{
			switch (x26094932cf7a9139.Underline)
			{
			case Underline.Single:
			case Underline.Words:
			case Underline.Dotted:
			case Underline.Dash:
			case Underline.DotDash:
			case Underline.DotDotDash:
			case Underline.DashLong:
				num = (x26094932cf7a9139.Bold ? 0.16250001f : 0.1375f);
				break;
			case Underline.Thick:
			case Underline.DottedHeavy:
			case Underline.DashHeavy:
			case Underline.DotDashHeavy:
			case Underline.DotDotDashHeavy:
			case Underline.DashLongHeavy:
				num = (x26094932cf7a9139.Bold ? 0.112500004f : 0.1f);
				break;
			case Underline.Wavy:
			case Underline.WavyHeavy:
				num = (x26094932cf7a9139.Bold ? 0.1375f : 0.112500004f);
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lhmabjdbfikbfjbckiicmhpchhgdfinddheepgleiccfkhjfahagdghgbgoglgfhcgmhmfdiofkicfbjkaijlfpjnfgkbfnkdeeljall", 256838694)));
			}
		}
		return x26094932cf7a9139.xe286def5a6a116b8(x282df02f8c72bc6f: true) * num;
	}

	private static float[] xfbcc51b13011ed59(Font x26094932cf7a9139)
	{
		float[] array = x26094932cf7a9139.Underline switch
		{
			Underline.Double => x26094932cf7a9139.Bold ? x7252729bf855504d : x36ef32bc43ce6597, 
			Underline.WavyDouble => x26094932cf7a9139.Bold ? x18ab20366af21117 : xecdec4435136677e, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fdcblejbpdacpehceeocgdfdbdmdpddenckejcbfcohfedpfkcggnbnglbehfclhmbcigbjiibajmahjemnjfbfkhbmkladlnpjldmam", 704582112))), 
		};
		float[] array2 = new float[2];
		for (int i = 0; i < 2; i++)
		{
			array2[i] = x26094932cf7a9139.xe286def5a6a116b8(x282df02f8c72bc6f: true) * array[i];
		}
		return array2;
	}
}
