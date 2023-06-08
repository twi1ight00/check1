using System;
using Aspose.Words;
using x013bb5b086aff77e;
using x077e797660ceec8d;
using x084786fe6fb0a4e7;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x4b070b01116bb3ff;
using x611adfb9b9d21a97;
using x639ad3f66698fe1b;
using x6a671772ec29137f;
using x722d80085b19d13f;
using x9e260ffa1ac41ffa;
using x9e2fb16d9c62aa97;
using xa2462df43988ffad;
using xa8550ea6ae4a81a5;
using xbe829a00a7a86dc3;
using xce0136f05681c5e9;
using xd6ff03883d34d0de;
using xdbe3cd173bd00464;

namespace xf989f31a236ff98c;

internal class xb64ca40f4a97bbc0
{
	private xb64ca40f4a97bbc0()
	{
	}

	internal static x3d2908992e1d1667 xa0cd748a38fb4102(SaveFormat x4e17f25eeff90cf4)
	{
		switch (x4e17f25eeff90cf4)
		{
		case SaveFormat.Doc:
		case SaveFormat.Dot:
			return new x163859bfa28558c4();
		case SaveFormat.Docx:
		case SaveFormat.Docm:
		case SaveFormat.Dotx:
		case SaveFormat.Dotm:
		case SaveFormat.FlatOpc:
		case SaveFormat.FlatOpcMacroEnabled:
		case SaveFormat.FlatOpcTemplate:
		case SaveFormat.FlatOpcTemplateMacroEnabled:
			return new xe41cdb7a2a4611b4();
		case SaveFormat.Rtf:
			return new x93beff1c2303c6fc();
		case SaveFormat.WordML:
			return new x4f037d20d40d8390();
		case SaveFormat.Pdf:
			return new xcd769e39c0788209();
		case SaveFormat.Xps:
			return new x666961dc91f135b7();
		case SaveFormat.XamlFixed:
			return new xeb3b220b7fe10a9c();
		case SaveFormat.Swf:
			return new xa58f8cc58d37b8dc();
		case SaveFormat.Svg:
			return new xe0864095980957ab();
		case SaveFormat.Html:
			return new x967f6fb76e7d0c72();
		case SaveFormat.Mhtml:
			return new xd42a56f5a5d721b4();
		case SaveFormat.Odt:
		case SaveFormat.Ott:
			return new xdb0bf9f81de4b38c();
		case SaveFormat.Text:
			return new xc045be5d79e471b9();
		case SaveFormat.Epub:
			return new x75eb89ee42a8f635();
		case SaveFormat.XamlFlow:
		case SaveFormat.XamlFlowPack:
			return new x10f42db128083eb4();
		case SaveFormat.Tiff:
		case SaveFormat.Png:
		case SaveFormat.Bmp:
		case SaveFormat.Emf:
		case SaveFormat.Jpeg:
			return new x39513200ff58c2e3();
		default:
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kkpbmmgcbnncjledbmldllcedljemgafpkhfpkofpkfgfkmgnfdhakkhgkbigkiiojpipigjpjnjieekhjlkhiclajjlbjamohhmjiomhifnfhmnbhdoidko", 1061887841)));
		}
	}
}
