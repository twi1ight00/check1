using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using x13f1efc79617a47b;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x4f4df92b75ba3b67;

internal class x0d8cdce10fda1cfd
{
	private bool x4136fd76c6e231aa;

	private x4f40d990d5bf81a6 x9b287b671d592594;

	private bool x4acaa54e03893217;

	private xfaf91ffd88d78c15 x730a3c5f4afd73ef = new xfaf91ffd88d78c15();

	private byte[] x0bd22eb243c109e7;

	private x92b3f3beff79453c xda204b96e60ccd3f;

	private x9e65c8722a39afe5 x15d383d2ed991a0b;

	private xd6b2a42851fedfba x277a8e7797009ec7;

	private x4882ae789be6e2ef x8cedcaa9a62c6e39;

	private x888a983e10e0c567 x983edd0ae7918309;

	private x658aebf1ca09b792 x2c8ada2c4f96d818;

	private xf70c7bfb09d6c003 x846143a9c01ca74d;

	public Stream xb8a774e0111d0fbe => x9b287b671d592594.x9e418ad9a56d1cf5;

	public xfaf91ffd88d78c15 xb444c09fa044bbca
	{
		get
		{
			return x730a3c5f4afd73ef;
		}
		set
		{
			x730a3c5f4afd73ef = value;
		}
	}

	public x658aebf1ca09b792 xf3b73fb11ed05856 => x2c8ada2c4f96d818;

	internal x4882ae789be6e2ef x28fcdc775a1d069c => x8cedcaa9a62c6e39;

	public x0044309004b99510 xabeecde5328505ea
	{
		get
		{
			return x15d383d2ed991a0b.xabeecde5328505ea;
		}
		set
		{
			x15d383d2ed991a0b.xabeecde5328505ea = value;
		}
	}

	public x8424217194953834 x8c5715ff65c8019b
	{
		get
		{
			return x15d383d2ed991a0b.x8c5715ff65c8019b;
		}
		set
		{
			x15d383d2ed991a0b.x8c5715ff65c8019b = value;
		}
	}

	internal x556ab440136df1a4 x3a60bb04bce53320 => x15d383d2ed991a0b.x3a60bb04bce53320;

	public xd6b2a42851fedfba xa65184d44a47025b => x277a8e7797009ec7;

	internal xe21bbe9dfab6c4dd x2107de3fc2a21893 => x09ed8d79c4ca4609.x2107de3fc2a21893;

	internal x888a983e10e0c567 x7cdd5738448662c5 => x983edd0ae7918309;

	internal xf86e577c4526d9a1 x93e68a44438355fd => x15d383d2ed991a0b.x93e68a44438355fd;

	internal x088a7b5025029c50 x09ed8d79c4ca4609 => x15d383d2ed991a0b.x09ed8d79c4ca4609;

	public x3a8cfc6f629fbbd3 xb0cbdf6b726de026 => x15d383d2ed991a0b.xb0cbdf6b726de026;

	public x0d8cdce10fda1cfd(string fileName, xd0e7b6ac3d6a3950 options)
	{
		x0d299f323d241756.x48501aec8e48c869(fileName, "fileName");
		x962254ea97336724(File.Create(fileName), options, x06088e3eb9b909d9: true);
	}

	public x0d8cdce10fda1cfd(Stream stream, xd0e7b6ac3d6a3950 options)
	{
		x962254ea97336724(stream, options, x06088e3eb9b909d9: false);
	}

	public x0d8cdce10fda1cfd(xd0e7b6ac3d6a3950 options)
		: this(new MemoryStream(), options)
	{
	}

	public void xa0dfc102c691b11f()
	{
		if (!x4136fd76c6e231aa)
		{
			x983edd0ae7918309.x10f3680c04d77f08(x9b287b671d592594);
			xda204b96e60ccd3f.WriteToPdf(x9b287b671d592594);
			x15d383d2ed991a0b.WriteToPdf(x9b287b671d592594);
			int x393f350850cb2bf = x9b287b671d592594.xc5ae6b313da3b21f();
			xef5ce3a0d5fe807a(x393f350850cb2bf);
			x9b287b671d592594.x25d0efbd7848eeb3("%%EOF");
			if (x846143a9c01ca74d != null)
			{
				x93619359a213c4b3.xca99e0aebcf34c85(xb8a774e0111d0fbe, x846143a9c01ca74d.xca559344d394e612.xea1e81378298fa81, x8cedcaa9a62c6e39.x73979cef1002ed01.xf0c8dca398b16b43.x8514ca825407a888, x8cedcaa9a62c6e39.x73979cef1002ed01.xf0c8dca398b16b43.x3b8b3c175efa9d40);
			}
			if (x4acaa54e03893217)
			{
				x9b287b671d592594.x8ffe90e7fbccfccd();
			}
			x4136fd76c6e231aa = true;
		}
	}

	public void x804b2039ae4e9b33(float x9b0739496f8b5475, float x4d5aabc7a55b12ba)
	{
		if (x277a8e7797009ec7 != null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("napoicgpcdnppceanclapccbinibicacgchcabocobfdnbmdgmceeakeamaflaifppofoaggelmgbaehpokhcpbinoiifkpijpgjhonjfoekfolklncldjjlbnamlnhmjnomlnfnmmmngmdoankolhbpimipglppjlgaelnamgebcllbjlccdgjcokadmkhdokodhffekjmekjdfmjkfejbgljignipghighdinhkeei", 555871946)));
		}
		x277a8e7797009ec7 = new xd6b2a42851fedfba(x8cedcaa9a62c6e39, x9b0739496f8b5475, x4d5aabc7a55b12ba);
		x15d383d2ed991a0b.x09ed8d79c4ca4609.x915eab2b9175eade(x277a8e7797009ec7.x899a2110a8a35fda);
		x73760b7b80ba7d23();
		x1bd5fb8b489b237d();
	}

	public void x804b2039ae4e9b33(SizeF x0ceec69a97f73617)
	{
		x804b2039ae4e9b33(x0ceec69a97f73617.Width, x0ceec69a97f73617.Height);
	}

	public void xa0cf4a18229be519()
	{
		if (x277a8e7797009ec7 == null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kejligamgbhmdgombffnefmnpedohakoifbpafipopopaegagenajdebaalb", 806074620)));
		}
		x277a8e7797009ec7.xa0cf4a18229be519();
		x277a8e7797009ec7.WriteToPdf(x9b287b671d592594);
		x277a8e7797009ec7 = null;
	}

	private void x73760b7b80ba7d23()
	{
		if (x8cedcaa9a62c6e39.x73979cef1002ed01.xa4167addc9c6947c && x15d383d2ed991a0b.x09ed8d79c4ca4609.xd44988f225497f3a == 1)
		{
			x2c8ada2c4f96d818 = new x658aebf1ca09b792(x8cedcaa9a62c6e39, xb3df580699166542());
			x2c8ada2c4f96d818.WriteToPdf(x9b287b671d592594);
		}
	}

	private void x1bd5fb8b489b237d()
	{
		x8b94de1cf9818907 xf0c8dca398b16b = x8cedcaa9a62c6e39.x73979cef1002ed01.xf0c8dca398b16b43;
		if (xf0c8dca398b16b != null && xf0c8dca398b16b.x8514ca825407a888 != null && x15d383d2ed991a0b.x09ed8d79c4ca4609.xd44988f225497f3a == 1)
		{
			x846143a9c01ca74d = new xf70c7bfb09d6c003(x28fcdc775a1d069c, RectangleF.Empty, x277a8e7797009ec7);
			x277a8e7797009ec7.x7062f8071787723c(x846143a9c01ca74d);
			x846143a9c01ca74d.xca559344d394e612.x84b5eecbdcca03b0 = new string('0', 32000);
			x846143a9c01ca74d.xca559344d394e612.xcd5d15a1f9661947 = "Adobe.PPKMS";
			x846143a9c01ca74d.xca559344d394e612.xfb99a81ca7845421 = "adbe.pkcs7.sha1";
			x846143a9c01ca74d.xca559344d394e612.xfe2547b8d747df6a = "[0 0 0 0]";
			x846143a9c01ca74d.xca559344d394e612.x32e1da0b7ddf4b75 = xf0c8dca398b16b.x8514ca825407a888.GetNameInfo(X509NameType.SimpleName, forIssuer: false);
			x846143a9c01ca74d.xca559344d394e612.xbb6d310c2b0ab6cc = xf0c8dca398b16b.x8514ca825407a888.GetNameInfo(X509NameType.EmailName, forIssuer: false);
			x846143a9c01ca74d.xca559344d394e612.x0124e2b3982c7c2b = xf0c8dca398b16b.x0124e2b3982c7c2b;
			x846143a9c01ca74d.xca559344d394e612.xab07b26048f600ba = xf0c8dca398b16b.xab07b26048f600ba;
			x846143a9c01ca74d.xca559344d394e612.x3a4da692532b620c = xf0c8dca398b16b.x31e4f7a372c34e86;
			x7cdd5738448662c5.xfff43e6a4e67b816(x846143a9c01ca74d);
			x3a60bb04bce53320.x7062f8071787723c(x846143a9c01ca74d);
		}
	}

	private void x962254ea97336724(Stream xcf18e5243f8d5fd3, xd0e7b6ac3d6a3950 xdfde339da46db651, bool x06088e3eb9b909d9)
	{
		if (xcf18e5243f8d5fd3 == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (xdfde339da46db651 == null)
		{
			throw new ArgumentNullException("options");
		}
		xdfde339da46db651.x461c3bf969128260();
		x4acaa54e03893217 = x06088e3eb9b909d9;
		x8cedcaa9a62c6e39 = new x4882ae789be6e2ef(this, xdfde339da46db651);
		x9b287b671d592594 = new x4f40d990d5bf81a6(xcf18e5243f8d5fd3);
		x983edd0ae7918309 = new x888a983e10e0c567();
		xda204b96e60ccd3f = new x92b3f3beff79453c(x8cedcaa9a62c6e39);
		x15d383d2ed991a0b = new x9e65c8722a39afe5(x8cedcaa9a62c6e39);
		if (x8cedcaa9a62c6e39.x5ba9693d4c3c102e)
		{
			x9b287b671d592594.x25d0efbd7848eeb3("%PDF-1.4");
			x9b287b671d592594.xc351d479ff7ee789(37);
			x9b287b671d592594.xc351d479ff7ee789(200);
			x9b287b671d592594.xc351d479ff7ee789(201);
			x9b287b671d592594.xc351d479ff7ee789(202);
			x9b287b671d592594.xc351d479ff7ee789(203);
			x9b287b671d592594.x25d0efbd7848eeb3("");
		}
		else
		{
			x9b287b671d592594.x25d0efbd7848eeb3("%PDF-1.5");
		}
	}

	private void xef5ce3a0d5fe807a(int x393f350850cb2bf8)
	{
		x9b287b671d592594.x25d0efbd7848eeb3("trailer");
		x9b287b671d592594.xafb7e6f79ed43681();
		x9b287b671d592594.xa4dc0ad8886e23a2("/Size", x9b287b671d592594.x0ac04543e6572f02);
		x9b287b671d592594.xa4dc0ad8886e23a2("/Info", xda204b96e60ccd3f.x899a2110a8a35fda);
		x9b287b671d592594.xa4dc0ad8886e23a2("/Root", x15d383d2ed991a0b.x899a2110a8a35fda);
		if (x8cedcaa9a62c6e39.x73979cef1002ed01.xa4167addc9c6947c)
		{
			x9b287b671d592594.xa4dc0ad8886e23a2("/Encrypt", x2c8ada2c4f96d818.x899a2110a8a35fda);
		}
		if (x8cedcaa9a62c6e39.x5ba9693d4c3c102e || x8cedcaa9a62c6e39.x73979cef1002ed01.xa4167addc9c6947c)
		{
			x9b287b671d592594.xa4dc0ad8886e23a2("/ID", string.Format("[<{0}><{0}>]", x0d299f323d241756.x482624a13e9e9d98(xb3df580699166542())));
		}
		x9b287b671d592594.x693a8d6d020474f2();
		x9b287b671d592594.x25d0efbd7848eeb3();
		x9b287b671d592594.x25d0efbd7848eeb3("startxref");
		x9b287b671d592594.x25d0efbd7848eeb3(xca004f56614e2431.xc8ba948e0d631490(x393f350850cb2bf8));
	}

	private byte[] xb3df580699166542()
	{
		if (x0bd22eb243c109e7 != null)
		{
			return x0bd22eb243c109e7;
		}
		string s = $"{x730a3c5f4afd73ef.xb063bbfcfeade526}/{x730a3c5f4afd73ef.x1d3fdaa19c46dec0}/{x730a3c5f4afd73ef.x514c0ea24ce40ef0}/{x730a3c5f4afd73ef.xc605b5c8a6696acf}/{x730a3c5f4afd73ef.x191dcb88c409b8dd}/{x730a3c5f4afd73ef.x238bf167ccfdd282}/{xca004f56614e2431.x6efbf9d15154c80d(x730a3c5f4afd73ef.x01fda47aa971692d)}/{xca004f56614e2431.x6efbf9d15154c80d(x730a3c5f4afd73ef.xdd48db0e1a80d624)}";
		x0bd22eb243c109e7 = x1e72f71e14224f7d.xc6df3c48d7ea1182(Encoding.UTF8.GetBytes(s));
		return x0bd22eb243c109e7;
	}
}
