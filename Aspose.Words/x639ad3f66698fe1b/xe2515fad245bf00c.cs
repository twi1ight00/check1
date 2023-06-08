using System;
using Aspose.Words.Fields;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using xf989f31a236ff98c;
using xfbd1009a0cbb9842;

namespace x639ad3f66698fe1b;

internal class xe2515fad245bf00c
{
	private readonly x21f0d20d41203be1 x8cedcaa9a62c6e39;

	internal xe2515fad245bf00c(x21f0d20d41203be1 context)
	{
		x8cedcaa9a62c6e39 = context;
	}

	internal void x8605874f1b4c6798(bool x0c07ecaa89906059, bool x549b1a1bab8624ee)
	{
		x8cedcaa9a62c6e39.xe1410f585439c7d4.xee60bff2900a72f2("\\field");
		x8cedcaa9a62c6e39.xe1410f585439c7d4.xb8aea59edd4060ce("\\fldlock", x0c07ecaa89906059);
		x8cedcaa9a62c6e39.xe1410f585439c7d4.xb8aea59edd4060ce("\\flddirty", x549b1a1bab8624ee);
		x8cedcaa9a62c6e39.xe1410f585439c7d4.xee60bff2900a72f2("\\*\\fldinst");
	}

	internal void x8605874f1b4c6798(string x0e59413709b18038, xeedad81aaed42a76 x789564759d365819, bool x0c07ecaa89906059)
	{
		x8605874f1b4c6798(x0c07ecaa89906059, x549b1a1bab8624ee: false);
		x8cedcaa9a62c6e39.xe1410f585439c7d4.xa07aa514e9082b3a();
		x8cedcaa9a62c6e39.x6fca94e50472ae68.x6210059f049f0d48(x789564759d365819, x00ce61b8358bb4cc: true);
		x8cedcaa9a62c6e39.xe1410f585439c7d4.x50f5dc167b3269a7(x0e59413709b18038);
		x8cedcaa9a62c6e39.xe1410f585439c7d4.x4ecc66ceff7a75c0();
	}

	internal void x8d6cd60f05fc1fe9()
	{
		x8cedcaa9a62c6e39.xe1410f585439c7d4.xc8a13a52db0580ae();
		x8cedcaa9a62c6e39.xe1410f585439c7d4.xee60bff2900a72f2("\\fldrslt");
	}

	internal void x98ab27c28fa098eb(bool x4797cf69c5ec19ff)
	{
		x8cedcaa9a62c6e39.xe1410f585439c7d4.xc8a13a52db0580ae();
		if (!x4797cf69c5ec19ff)
		{
			x8cedcaa9a62c6e39.xe1410f585439c7d4.xee60bff2900a72f2("\\fldrslt");
			x8cedcaa9a62c6e39.xe1410f585439c7d4.xc8a13a52db0580ae();
		}
		x8cedcaa9a62c6e39.xe1410f585439c7d4.xc8a13a52db0580ae();
	}

	internal void x85599597a4d57020(FormField x0ab8fc6e4b8e829c)
	{
		xbfd162a6d47f59a4 xe1410f585439c7d = x8cedcaa9a62c6e39.xe1410f585439c7d4;
		xe1410f585439c7d.xee60bff2900a72f2("\\*\\formfield");
		x58bf2a36f9adf9a9 x58bf2a36f9adf9a = x0ab8fc6e4b8e829c.x58bf2a36f9adf9a9;
		xe1410f585439c7d.x4d14ee33f46b5913("\\fftype", Convert.ToInt32(x0ab8fc6e4b8e829c.xdda013621290d582));
		xe1410f585439c7d.xb8aea59edd4060ce("\\ffownhelp", x58bf2a36f9adf9a.x0c2c83899c41d345);
		xe1410f585439c7d.xb8aea59edd4060ce("\\ffownstat", x58bf2a36f9adf9a.x5a70ee0d6c0cb151);
		xe1410f585439c7d.xb8aea59edd4060ce("\\ffprot", !x58bf2a36f9adf9a.x9f2c0dc847992f03);
		xe1410f585439c7d.xb8aea59edd4060ce("\\ffrecalc", x58bf2a36f9adf9a.x8cc2703314d01b16);
		xe1410f585439c7d.xf55384516c165731("\\*\\ffname", x58bf2a36f9adf9a.x759aa16c2016a289);
		xe1410f585439c7d.xf55384516c165731("\\*\\ffhelptext", x58bf2a36f9adf9a.x22f04e1437bdf856);
		xe1410f585439c7d.xf55384516c165731("\\*\\ffstattext", x58bf2a36f9adf9a.x50bd293cbfa8c01a);
		xe1410f585439c7d.xf55384516c165731("\\*\\ffentrymcr", x58bf2a36f9adf9a.x6ebae521c5565993);
		xe1410f585439c7d.xf55384516c165731("\\*\\ffexitmcr", x58bf2a36f9adf9a.xedb00d3630ef56d1);
		xe1410f585439c7d.x4d14ee33f46b5913("\\ffres", xf2b9ab75a7571713.x3f88a25febd23896(x58bf2a36f9adf9a, x0ab8fc6e4b8e829c.xdda013621290d582));
		switch (x0ab8fc6e4b8e829c.Type)
		{
		case FieldType.FieldFormTextInput:
			xe1410f585439c7d.x4d14ee33f46b5913("\\fftypetxt", Convert.ToInt32(x58bf2a36f9adf9a.x98ed2e2b5602a6f1));
			xe1410f585439c7d.x4d14ee33f46b5913("\\ffmaxlen", x58bf2a36f9adf9a.xc5c2fb4db5b8c3bd);
			xe1410f585439c7d.xf55384516c165731("\\*\\ffdeftext", x58bf2a36f9adf9a.x5e1adcb28cb5f299);
			xe1410f585439c7d.xf55384516c165731("\\*\\ffformat", x58bf2a36f9adf9a.xe8f8d8a7db32427b);
			break;
		case FieldType.FieldFormCheckBox:
			xe1410f585439c7d.xb8aea59edd4060ce("\\ffsize1", !x58bf2a36f9adf9a.xbd91bc7364251d6d);
			xe1410f585439c7d.x4d14ee33f46b5913("\\ffhps", x58bf2a36f9adf9a.x4bdafa5e724a058a);
			xe1410f585439c7d.x4d14ee33f46b5913("\\ffdefres", x58bf2a36f9adf9a.x5e6597fb50c93e39 ? 1 : 0);
			break;
		case FieldType.FieldFormDropDown:
			if (x58bf2a36f9adf9a.xc055d178db9e8d17.Count > 0)
			{
				xe1410f585439c7d.x4d14ee33f46b5913("\\ffhaslistbox");
				xe1410f585439c7d.x4d14ee33f46b5913("\\ffdefres", x58bf2a36f9adf9a.x290a782f6c7cab2f);
				for (int i = 0; i < x58bf2a36f9adf9a.xc055d178db9e8d17.Count; i++)
				{
					xe1410f585439c7d.xf55384516c165731("\\*\\ffl", x58bf2a36f9adf9a.xc055d178db9e8d17[i]);
				}
			}
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kmgcaoncknedknldincennjebnafaihfdmofjmfgjmmgbmdhbhkhelbieliinkpiblgjgknjpfekallkclclgkjlijamofhm", 2020812405)));
		}
		xe1410f585439c7d.xc8a13a52db0580ae();
	}
}
