using System;
using System.Collections;
using x13f1efc79617a47b;
using x38a89dee67fc7a16;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;
using xfc5388ad7dff404f;

namespace xaf73fad8cede26de;

internal class x07f294506d1c9a72 : x22a2c6bbecd8ed7a
{
	private readonly xe965bada78e2d6b1 xb88ed8cce554eb93;

	private xa2f1c3dcbd86f20a xfe5afb01ba820091;

	private x26efbcdc713eaa49 x83d0f75f3858e3a4;

	internal xe965bada78e2d6b1 x23ada1d4cc8753b4 => xb88ed8cce554eb93;

	internal xa2f1c3dcbd86f20a x189ff6a60062fbf5 => xfe5afb01ba820091;

	internal x26efbcdc713eaa49 x73979cef1002ed01
	{
		get
		{
			return x83d0f75f3858e3a4;
		}
		set
		{
			x83d0f75f3858e3a4 = value;
		}
	}

	internal x07f294506d1c9a72(xe965bada78e2d6b1 xpsPackage, x54b98d0096d7251a warningCallback)
		: base("/Resources", warningCallback)
	{
		xb88ed8cce554eb93 = xpsPackage;
	}

	internal override string x68949e659a0029db(x6b1a899052c71a60 x26094932cf7a9139)
	{
		string text = base.x68949e659a0029db(x26094932cf7a9139);
		xfe5afb01ba820091.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.microsoft.com/xps/2005/06/required-resource", text, x1bc1cc5e4fd586bf: false);
		return text;
	}

	internal override xfc4b33756f599219 xa9557f69810d0afe(byte[] x43e181e083db6cdf, x02df97c06afacbf3 x5edc4e0499c937b4)
	{
		xfc4b33756f599219 xfc4b33756f599220 = base.xa9557f69810d0afe(x43e181e083db6cdf, x5edc4e0499c937b4);
		xfe5afb01ba820091.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.microsoft.com/xps/2005/06/required-resource", xfc4b33756f599220.xb405a444ca77e2d4, x1bc1cc5e4fd586bf: false);
		return xfc4b33756f599220;
	}

	internal override void xa04e23b676ea0cc9()
	{
		foreach (DictionaryEntry item in base.x39ca55b691f96321)
		{
			xb88ed8cce554eb93.xd6abb2ab950b4d22.xd6b6ed77479ef68c(x2bba4028a0d3928b.x8572e146dc2654a2((xcd986872cf3bcf68)item.Value, (string)item.Key));
		}
		foreach (xfc4b33756f599219 value in base.xb3bbeebb44588c3a.Values)
		{
			xa2f1c3dcbd86f20a xd7e5673853e47af = x36cb70a24a75c02d(value);
			xb88ed8cce554eb93.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xd7e5673853e47af);
		}
	}

	internal void xed34dd38c3f5b36e(int x39b5532b4ddc40a3)
	{
		xa2f1c3dcbd86f20a xd7e5673853e47af = new xa2f1c3dcbd86f20a($"/Documents/1/Pages/{x39b5532b4ddc40a3}.fpage", "application/vnd.ms-package.xps-fixedpage+xml");
		xb88ed8cce554eb93.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xd7e5673853e47af);
		xfe5afb01ba820091 = xd7e5673853e47af;
	}

	private static xa2f1c3dcbd86f20a x36cb70a24a75c02d(xfc4b33756f599219 x0b7745bf6c373f1b)
	{
		xfe2ff3c162b47c70 x0182a6dae298f8a = xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(x0b7745bf6c373f1b.xcc18177a965e0313);
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = new xa2f1c3dcbd86f20a(x0b7745bf6c373f1b.xb405a444ca77e2d4, xb1f2499baf0687ef(x0182a6dae298f8a));
		xa2f1c3dcbd86f20a.xb8a774e0111d0fbe.Write(x0b7745bf6c373f1b.xcc18177a965e0313, 0, x0b7745bf6c373f1b.xcc18177a965e0313.Length);
		return xa2f1c3dcbd86f20a;
	}

	private static string xb1f2499baf0687ef(xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		return x0182a6dae298f8a4 switch
		{
			xfe2ff3c162b47c70.x796ab23ce57ee1e0 => "image/jpeg", 
			xfe2ff3c162b47c70.x6339cdb9e2b512c7 => "image/png", 
			xfe2ff3c162b47c70.x15c106572f1e1fbf => "image/tiff", 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kfdgahkgegbhehihjgphlfgigfniegejcfljoeckhajknealoehlpdolcefmndmmfpcngekniebomdioocpoepfp", 1768710917))), 
		};
	}
}
