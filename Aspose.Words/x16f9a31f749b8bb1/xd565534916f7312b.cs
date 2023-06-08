using System;
using System.IO;
using System.Text;
using Aspose.Words;
using x13f1efc79617a47b;
using x1ba3a5ce73d4b39d;
using x26869753cb97bfe9;
using x681ccae5509c120d;
using x884584cc69c5c378;
using xa604c4d210ae0581;
using xaa035fc640f94856;
using xb92b7270f78a4e8d;
using xc8ef30c5dc53a453;

namespace x16f9a31f749b8bb1;

internal class xd565534916f7312b
{
	private xd8c3135513b9115b x435daba16a6b8f42;

	private BinaryReader xe1d718cca131846e;

	private BinaryReader x3903735d25c008ad;

	private BinaryReader xb2bb2c8e72f15b15;

	private BinaryReader x3e80e5ec36f43a17;

	private x8aeace2bf92692ab xa6172040dc8d693f;

	private x8f4cc590b89c730d x64adac4fe37b09ae;

	private x4d66abcb6ba362b4 xb62384534c3b4daa;

	private xf8b5e62cf3165594 x33b93318db8db4ed;

	private xdb6ea7a460485a97 x43a58bc2c9b1fd20;

	private x5c2107ebcbb7681b x598a9748951d56b2;

	private x846eeecacc00f82b x2a8c54cec2ed34c4;

	private x1238479da7c66191 xa71a1ee23c38552d;

	private x1238479da7c66191 xc335834826922c5b;

	private x2b702525301ee74a x6c3a262e2d07f509;

	private xd452a5f78fa06e8b x3613df8e6a658a81;

	private xd452a5f78fa06e8b xc5c7ba24502dc004;

	private xe91a1cdf262fe886 x96f19c22613114cd;

	private x31a5ab258b5c21f3 xc1b38625cc10d621;

	private x39a0e849afa5b554 x20429b97275cb2fb;

	private xd078c45cd488fe12 xd2a1236e4f89a0e2;

	internal static bool x492f529cee830a40;

	internal xd8c3135513b9115b xd5113ab23c2feda8 => x435daba16a6b8f42;

	internal BinaryReader x0f8a9a895bdf560e => xe1d718cca131846e;

	internal BinaryReader x5a4620c6b9a3bb66 => x3903735d25c008ad;

	internal BinaryReader x4f6bee9d11d5b851 => xb2bb2c8e72f15b15;

	internal BinaryReader x6215066365db5120 => x3e80e5ec36f43a17;

	internal x8aeace2bf92692ab x8aeace2bf92692ab => xa6172040dc8d693f;

	internal x8f4cc590b89c730d x8f4cc590b89c730d => x64adac4fe37b09ae;

	internal x5c2107ebcbb7681b x5c2107ebcbb7681b => x598a9748951d56b2;

	internal x846eeecacc00f82b x846eeecacc00f82b => x2a8c54cec2ed34c4;

	internal x2b702525301ee74a x2b702525301ee74a => x6c3a262e2d07f509;

	internal xd452a5f78fa06e8b x766da124ec0eb8b2 => x3613df8e6a658a81;

	internal xd452a5f78fa06e8b xf926db502adbb667 => xc5c7ba24502dc004;

	internal xe91a1cdf262fe886 xe91a1cdf262fe886 => x96f19c22613114cd;

	internal x4d66abcb6ba362b4 x4d66abcb6ba362b4 => xb62384534c3b4daa;

	internal xf8b5e62cf3165594 xf8b5e62cf3165594 => x33b93318db8db4ed;

	internal xdb6ea7a460485a97 xdb6ea7a460485a97 => x43a58bc2c9b1fd20;

	internal x31a5ab258b5c21f3 x31a5ab258b5c21f3 => xc1b38625cc10d621;

	internal x39a0e849afa5b554 x39a0e849afa5b554 => x20429b97275cb2fb;

	internal xd078c45cd488fe12 xd078c45cd488fe12 => xd2a1236e4f89a0e2;

	internal xd565534916f7312b(xd8c3135513b9115b fs, string password, IWarningCallback warningCallback)
	{
		xd586e0c16bdae7fc(fs, password, warningCallback);
	}

	internal xd565534916f7312b(string fileName)
	{
		using Stream stream = File.OpenRead(fileName);
		xd586e0c16bdae7fc(new xd8c3135513b9115b(stream), null, null);
	}

	internal x1238479da7c66191 x56e5a2c6f7ef0a50(x9e131021ba70185c x77b06614416ee4d3)
	{
		return x77b06614416ee4d3 switch
		{
			x9e131021ba70185c.xc447809891322395 => xa71a1ee23c38552d, 
			x9e131021ba70185c.x1ea60bde2b5d0d28 => xc335834826922c5b, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lhbabjiafipafjgbkinbmhechhlcficddhjdpgaeicheihoehhffbgmfagdgigkgjfbhigihnfphcfgiifnilfejealjffckhfjklealndhldaol", 851968294))), 
		};
	}

	private void xd586e0c16bdae7fc(xd8c3135513b9115b x84378c276c4cd7e2, string xe8e4b5871d71a79a, IWarningCallback x57fef5933b41d0c2)
	{
		if (x84378c276c4cd7e2 == null)
		{
			throw new ArgumentNullException("fs");
		}
		x435daba16a6b8f42 = x84378c276c4cd7e2;
		BinaryReader reader = new BinaryReader(x435daba16a6b8f42.x29e7ace4c90f74cd.xb3b34047219bdc2a("WordDocument"), x93b05c1ad709a695.x9cfd780d6fc703c5(x5be1cad1d00af914: true));
		xa6172040dc8d693f = new x8aeace2bf92692ab(reader, x57fef5933b41d0c2);
		if (xa6172040dc8d693f.x3bf62ca21be92f49)
		{
			throw new UnsupportedFileFormatException("This document is in the pre-Word97 format and it is not currently supported.");
		}
		if (xa6172040dc8d693f.xa07212033002e423)
		{
			if (xa6172040dc8d693f.x9729e21f6f99ff8e)
			{
				throw new UnsupportedFileFormatException("The document is protected using the XOR obfuscation and this is not currently supported.");
			}
			x414106297e729800 x414106297e = new x414106297e729800();
			x414106297e.xcc381ffa3ede662f(x435daba16a6b8f42, xa6172040dc8d693f.xa20346a1e3c44f1b, xe8e4b5871d71a79a);
		}
		Stream input = x435daba16a6b8f42.x29e7ace4c90f74cd.xb3b34047219bdc2a("WordDocument");
		xe1d718cca131846e = new BinaryReader(input, x93b05c1ad709a695.x9cfd780d6fc703c5(x5be1cad1d00af914: true));
		x3903735d25c008ad = new BinaryReader(input, x93b05c1ad709a695.x9cfd780d6fc703c5(x5be1cad1d00af914: false));
		xa6172040dc8d693f.x3a5e2abdc5dbcfd0(xe1d718cca131846e);
		_ = x492f529cee830a40;
		Stream input2 = x435daba16a6b8f42.x29e7ace4c90f74cd.xb3b34047219bdc2a(xa6172040dc8d693f.xa20346a1e3c44f1b);
		xb2bb2c8e72f15b15 = new BinaryReader(input2, Encoding.Unicode);
		Stream stream = x435daba16a6b8f42.x29e7ace4c90f74cd.x3e19bf48aeaa5779("Data");
		x3e80e5ec36f43a17 = ((stream != null) ? new BinaryReader(stream, Encoding.Unicode) : null);
		x64adac4fe37b09ae = new x8f4cc590b89c730d(x8aeace2bf92692ab, x4f6bee9d11d5b851);
		xb62384534c3b4daa = new x4d66abcb6ba362b4(x8aeace2bf92692ab, x0f8a9a895bdf560e, x4f6bee9d11d5b851);
		xf5962200e5f71991();
		xab57cfc5416222bd();
		x598a9748951d56b2 = new x5c2107ebcbb7681b(x8aeace2bf92692ab, x4f6bee9d11d5b851);
		x2a8c54cec2ed34c4 = new x846eeecacc00f82b(x8aeace2bf92692ab, x4f6bee9d11d5b851, xb62384534c3b4daa.x23719734cf1f138c);
		xa71a1ee23c38552d = new x1238479da7c66191(x9e131021ba70185c.xc447809891322395, x8aeace2bf92692ab, x4f6bee9d11d5b851);
		xc335834826922c5b = new x1238479da7c66191(x9e131021ba70185c.x1ea60bde2b5d0d28, x8aeace2bf92692ab, x4f6bee9d11d5b851);
		x6c3a262e2d07f509 = new x2b702525301ee74a(x8aeace2bf92692ab, x4f6bee9d11d5b851);
		x3613df8e6a658a81 = new xd452a5f78fa06e8b(FootnoteType.Footnote, x8aeace2bf92692ab, x4f6bee9d11d5b851);
		xc5c7ba24502dc004 = new xd452a5f78fa06e8b(FootnoteType.Endnote, x8aeace2bf92692ab, x4f6bee9d11d5b851);
		x96f19c22613114cd = new xe91a1cdf262fe886(x8aeace2bf92692ab, x4f6bee9d11d5b851);
		xc1b38625cc10d621 = new x31a5ab258b5c21f3(x8aeace2bf92692ab, x4f6bee9d11d5b851);
		x20429b97275cb2fb = new x39a0e849afa5b554(x8aeace2bf92692ab, x4f6bee9d11d5b851);
		xd2a1236e4f89a0e2 = new xd078c45cd488fe12(x8aeace2bf92692ab, x4f6bee9d11d5b851);
	}

	private void xf5962200e5f71991()
	{
		x33b93318db8db4ed = new xf8b5e62cf3165594();
		xe4fb040c584e2705 xe4fb040c584e2706 = new xe4fb040c584e2705();
		xe4fb040c584e2706.x06b0e25aa6ad68a9(x4f6bee9d11d5b851, xa6172040dc8d693f.x955a03f821588c52.xdbb3d6f783bebba7);
		for (int i = 0; i < xe4fb040c584e2706.x23719734cf1f138c; i++)
		{
			x0f8a9a895bdf560e.BaseStream.Seek(xe4fb040c584e2706.xfbe217fe06e4abb5(i), SeekOrigin.Begin);
			xe31a274c53017211 xe31a274c53017212 = new xe31a274c53017211(x0f8a9a895bdf560e);
			xe31a274c53017212.x06b0e25aa6ad68a9(x33b93318db8db4ed);
		}
	}

	private void xab57cfc5416222bd()
	{
		x43a58bc2c9b1fd20 = new xdb6ea7a460485a97();
		xe4fb040c584e2705 xe4fb040c584e2706 = new xe4fb040c584e2705();
		xe4fb040c584e2706.x06b0e25aa6ad68a9(x4f6bee9d11d5b851, xa6172040dc8d693f.x955a03f821588c52.x03f990c30d457af3);
		for (int i = 0; i < xe4fb040c584e2706.x23719734cf1f138c; i++)
		{
			x0f8a9a895bdf560e.BaseStream.Seek(xe4fb040c584e2706.xfbe217fe06e4abb5(i), SeekOrigin.Begin);
			xdc4e21950f668b1f xdc4e21950f668b1f2 = new xdc4e21950f668b1f(x0f8a9a895bdf560e);
			xdc4e21950f668b1f2.x06b0e25aa6ad68a9(x43a58bc2c9b1fd20);
		}
	}
}
