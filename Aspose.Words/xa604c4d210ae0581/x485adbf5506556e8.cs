using System;
using System.IO;
using Aspose;
using Aspose.Words;
using Aspose.Words.Drawing;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6f978ba1e7522832;
using xf989f31a236ff98c;

namespace xa604c4d210ae0581;

internal abstract class x485adbf5506556e8
{
	protected x7f77ea92be0d9042 x66c02128fdc6436a;

	protected BinaryReader x7450cc1e48712286;

	protected x354e9ebad65eecc8 x9b287b671d592594;

	protected xd47c6c7442eb8033 xaca3428582882d9d;

	protected TableStyle xe5ef82d048062925;

	private bool x95b7a3036d9d4cab;

	private bool xf6a9c32be7864635;

	private readonly IWarningCallback xa056586c1f99e199;

	internal static bool x492f529cee830a40 = true;

	protected bool x4de4e1e9aeaada1f => x95b7a3036d9d4cab;

	protected bool x48388be4dc888d53 => xf6a9c32be7864635;

	protected IWarningCallback xf69ca7a9bb4a4a51 => xa056586c1f99e199;

	internal x485adbf5506556e8(xd47c6c7442eb8033 revisionAuthors, IWarningCallback warningCallback)
	{
		xa056586c1f99e199 = warningCallback;
		xaca3428582882d9d = revisionAuthors;
		x9b287b671d592594 = new x354e9ebad65eecc8(new MemoryStream());
	}

	private static x58d6a3ec2a2998ff x69adfc837998abf7(x1b1ec609e70eb086 x43163d22e8cd5a71)
	{
		return x43163d22e8cd5a71 switch
		{
			x1b1ec609e70eb086.x1c2c1355ae6bd833 => x58d6a3ec2a2998ff.xea0467ee019c084e, 
			x1b1ec609e70eb086.xa4e228fcd9490f45 => x58d6a3ec2a2998ff.x694b0bdd5dedf0c7, 
			x1b1ec609e70eb086.x37435c29a5649292 => x58d6a3ec2a2998ff.x2437bc812a196a65, 
			x1b1ec609e70eb086.xbea9812efdcba147 => x58d6a3ec2a2998ff.xdd39c88b6867465d, 
			x1b1ec609e70eb086.xb8e3e9a641be95c5 => x58d6a3ec2a2998ff.xb78c16d5f2d4f2f7, 
			x1b1ec609e70eb086.x5d6d04c35215bc51 => x58d6a3ec2a2998ff.x071877003e2ef8a1, 
			x1b1ec609e70eb086.xf59d22dcfa267bc1 => x58d6a3ec2a2998ff.x279da4adfba57f2d, 
			x1b1ec609e70eb086.xbc3a1ad7f75a88f9 => x58d6a3ec2a2998ff.x82da544c8c736f7d, 
			x1b1ec609e70eb086.xb43f8d5efcee0261 => x58d6a3ec2a2998ff.xd642b87569e5f657, 
			x1b1ec609e70eb086.x95249c3688e883c5 => x58d6a3ec2a2998ff.x2deb8144928d8ae8, 
			x1b1ec609e70eb086.x6cecca56ca9d6ef2 => x58d6a3ec2a2998ff.xd94b863f79d825bc, 
			x1b1ec609e70eb086.x34f4bcb41a1eddcb => x58d6a3ec2a2998ff.x8e0a2080e3118166, 
			_ => x58d6a3ec2a2998ff.x4d0b9d4447ba7566, 
		};
	}

	private x1b1ec609e70eb086 xd4e129043d0cce57(x58d6a3ec2a2998ff x8619bdb710f6bf6c)
	{
		switch (x8619bdb710f6bf6c)
		{
		case x58d6a3ec2a2998ff.xea0467ee019c084e:
			return x1b1ec609e70eb086.x1c2c1355ae6bd833;
		case x58d6a3ec2a2998ff.x694b0bdd5dedf0c7:
			return x1b1ec609e70eb086.xa4e228fcd9490f45;
		case x58d6a3ec2a2998ff.x2437bc812a196a65:
			return x1b1ec609e70eb086.x37435c29a5649292;
		case x58d6a3ec2a2998ff.xdd39c88b6867465d:
			return x1b1ec609e70eb086.xbea9812efdcba147;
		case x58d6a3ec2a2998ff.xb78c16d5f2d4f2f7:
			return x1b1ec609e70eb086.xb8e3e9a641be95c5;
		case x58d6a3ec2a2998ff.x071877003e2ef8a1:
			return x1b1ec609e70eb086.x5d6d04c35215bc51;
		case x58d6a3ec2a2998ff.x279da4adfba57f2d:
			return x1b1ec609e70eb086.xf59d22dcfa267bc1;
		case x58d6a3ec2a2998ff.x82da544c8c736f7d:
			return x1b1ec609e70eb086.xbc3a1ad7f75a88f9;
		case x58d6a3ec2a2998ff.xd642b87569e5f657:
			return x1b1ec609e70eb086.xb43f8d5efcee0261;
		case x58d6a3ec2a2998ff.x2deb8144928d8ae8:
			return x1b1ec609e70eb086.x95249c3688e883c5;
		case x58d6a3ec2a2998ff.xd94b863f79d825bc:
			return x1b1ec609e70eb086.x6cecca56ca9d6ef2;
		case x58d6a3ec2a2998ff.x8e0a2080e3118166:
			return x1b1ec609e70eb086.x34f4bcb41a1eddcb;
		default:
			x3dc950453374051a("Unknown conditional formatting read 0x{0:x4}.", (int)x8619bdb710f6bf6c);
			return x1b1ec609e70eb086.x4d0b9d4447ba7566;
		}
	}

	protected byte[] x6210059f049f0d48(x7f77ea92be0d9042 x94aec03cf2ae750b)
	{
		x66c02128fdc6436a = x94aec03cf2ae750b;
		x9b287b671d592594.BaseStream.Position = 0L;
		WriteCore();
		return x6ca2fe3c7f213f3e();
	}

	protected byte[] x6ca2fe3c7f213f3e()
	{
		byte[] array = new byte[(int)x9b287b671d592594.BaseStream.Position];
		x9b287b671d592594.BaseStream.Position = 0L;
		x9b287b671d592594.BaseStream.Read(array, 0, array.Length);
		return array;
	}

	[JavaThrows(true)]
	protected abstract void WriteCore();

	protected void x8af4cf76757a2ae7(x875aca5784596b73 x9035cf16181332fc, int xba08ce632055a1d9)
	{
		x992a87e8a159fe04(x9035cf16181332fc, x66c02128fdc6436a.xf7866f89640a29a3(xba08ce632055a1d9));
	}

	protected void x992a87e8a159fe04(x875aca5784596b73 x9035cf16181332fc, object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != null)
		{
			x9b287b671d592594.x9d91059a64953e89(x9035cf16181332fc, (bool)xbcea506a33cf9111);
		}
	}

	protected void x2ab845eb152478b4(x875aca5784596b73 x9035cf16181332fc, int xba08ce632055a1d9)
	{
		object obj = x66c02128fdc6436a.xf7866f89640a29a3(xba08ce632055a1d9);
		if (obj != null)
		{
			x9b287b671d592594.x9d91059a64953e89(x9035cf16181332fc, !(bool)obj);
		}
	}

	protected void xc351d479ff7ee789(x875aca5784596b73 x9035cf16181332fc, int xba08ce632055a1d9)
	{
		xdd694ce55709aeca(x9035cf16181332fc, x66c02128fdc6436a.xf7866f89640a29a3(xba08ce632055a1d9));
	}

	protected void xdd694ce55709aeca(x875aca5784596b73 x9035cf16181332fc, object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != null)
		{
			int xbcea506a33cf9112 = ((xbcea506a33cf9111 is int) ? ((int)xbcea506a33cf9111) : ((!(xbcea506a33cf9111 is x9b28b1f7f0cc963f)) ? Convert.ToInt32(xbcea506a33cf9111) : ((x9b28b1f7f0cc963f)xbcea506a33cf9111).xd2f68ee6f47e9dfb));
			x9b287b671d592594.x1680160a63ff3e0b(x9035cf16181332fc, xbcea506a33cf9112);
		}
	}

	protected void xab5f6b7526efa5be(x875aca5784596b73 x9035cf16181332fc, int xba08ce632055a1d9)
	{
		x2819fd3ae48985bb(x9035cf16181332fc, x66c02128fdc6436a.xf7866f89640a29a3(xba08ce632055a1d9));
	}

	protected void xb0c682b9901a2443(x875aca5784596b73 x9035cf16181332fc, int xba08ce632055a1d9)
	{
		xcfd55d7b496787e5(x9035cf16181332fc, x66c02128fdc6436a.xf7866f89640a29a3(xba08ce632055a1d9));
	}

	protected void xcfd55d7b496787e5(x875aca5784596b73 x9035cf16181332fc, object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != null)
		{
			x9b287b671d592594.x52cfd1b813a1514a(x9035cf16181332fc, Convert.ToInt32(xbcea506a33cf9111));
		}
	}

	protected void x2819fd3ae48985bb(x875aca5784596b73 x9035cf16181332fc, object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != null)
		{
			x9b287b671d592594.xd776ae6f68bc4d9c(x9035cf16181332fc, Convert.ToInt32(xbcea506a33cf9111));
		}
	}

	protected void x6ff7c65ed4805c27(x875aca5784596b73 x9035cf16181332fc, int xba08ce632055a1d9)
	{
		xdcd54ad49250a806(x9035cf16181332fc, x66c02128fdc6436a.xf7866f89640a29a3(xba08ce632055a1d9));
	}

	protected void xdcd54ad49250a806(x875aca5784596b73 x9035cf16181332fc, object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != null)
		{
			x9b287b671d592594.x138617e45a6d57be(x9035cf16181332fc, Convert.ToInt32(xbcea506a33cf9111));
		}
	}

	protected void xfa0bf2c209de0eaa(x875aca5784596b73 x9035cf16181332fc, int xba08ce632055a1d9)
	{
		x6805c2c452bad830(x9035cf16181332fc, x66c02128fdc6436a.xf7866f89640a29a3(xba08ce632055a1d9));
	}

	protected void x6805c2c452bad830(x875aca5784596b73 x9035cf16181332fc, object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != null)
		{
			x9b287b671d592594.x1680160a63ff3e0b(x9035cf16181332fc, (int)x195cb055715b526e.xc3bcf5a9ad941428((x26d9ecb4bdf0456d)xbcea506a33cf9111));
		}
	}

	protected void x61431dc20e80763f(x875aca5784596b73 x9035cf16181332fc, int xba08ce632055a1d9)
	{
		xa79654a7a96ec0c8(x9035cf16181332fc, x66c02128fdc6436a.xf7866f89640a29a3(xba08ce632055a1d9));
	}

	protected void xa79654a7a96ec0c8(x875aca5784596b73 x9035cf16181332fc, object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != null)
		{
			x9b287b671d592594.x138617e45a6d57be(x9035cf16181332fc, x195cb055715b526e.x103636c839f725d7((x26d9ecb4bdf0456d)xbcea506a33cf9111));
		}
	}

	protected void x06060bc88026b467(x875aca5784596b73 x9035cf16181332fc, int xba08ce632055a1d9)
	{
		xf4829300ee2ded8a(x9035cf16181332fc, x66c02128fdc6436a.xf7866f89640a29a3(xba08ce632055a1d9));
	}

	protected void xf4829300ee2ded8a(x875aca5784596b73 x9035cf16181332fc, object xbcea506a33cf9111)
	{
		Border border = (Border)xbcea506a33cf9111;
		if (border != null && !border.xa157de8185757b11)
		{
			x9b287b671d592594.x3a52c4e37999b16e(x9035cf16181332fc);
			x1df55585ec1be056.x2beefb7099c2c239(border, x9b287b671d592594, x10e248b4013349b1: true);
		}
	}

	protected void x5f45ba3056182cdb(x875aca5784596b73 x9035cf16181332fc, int xba08ce632055a1d9)
	{
		xa46408338e704d99(x9035cf16181332fc, x66c02128fdc6436a.xf7866f89640a29a3(xba08ce632055a1d9));
	}

	protected void xa46408338e704d99(x875aca5784596b73 x9035cf16181332fc, object xbcea506a33cf9111)
	{
		Border border = (Border)xbcea506a33cf9111;
		if (border != null && !border.xa157de8185757b11)
		{
			x9b287b671d592594.x3a52c4e37999b16e(x9035cf16181332fc);
			x9b287b671d592594.Write((byte)8);
			x1df55585ec1be056.x7cf486446cf04117(border, x9b287b671d592594, x10e248b4013349b1: true);
		}
	}

	protected void x1cf70b3230c37a6a(x875aca5784596b73 x9035cf16181332fc, int xba08ce632055a1d9)
	{
		xc8950caaebdd16ee(x9035cf16181332fc, x66c02128fdc6436a.xf7866f89640a29a3(xba08ce632055a1d9));
	}

	protected void xc8950caaebdd16ee(x875aca5784596b73 x9035cf16181332fc, object xbcea506a33cf9111)
	{
		Shading shading = (Shading)xbcea506a33cf9111;
		if (shading != null && !shading.xa157de8185757b11)
		{
			x9b287b671d592594.x3a52c4e37999b16e(x9035cf16181332fc);
			x075263c82f5cad54.x2beefb7099c2c239(shading, x9b287b671d592594);
		}
	}

	protected void x254ca7c3e16cd9eb(x875aca5784596b73 x9035cf16181332fc, int xba08ce632055a1d9)
	{
		x81340dc16c92f474(x9035cf16181332fc, x66c02128fdc6436a.xf7866f89640a29a3(xba08ce632055a1d9));
	}

	protected void x81340dc16c92f474(x875aca5784596b73 x9035cf16181332fc, object xbcea506a33cf9111)
	{
		Shading shading = (Shading)xbcea506a33cf9111;
		if (shading != null && !shading.xa157de8185757b11)
		{
			x9b287b671d592594.x3a52c4e37999b16e(x9035cf16181332fc);
			x9b287b671d592594.Write((byte)10);
			x075263c82f5cad54.x7cf486446cf04117(shading, x9b287b671d592594);
		}
	}

	protected long x6d582d881359c5db(x875aca5784596b73 x28180b3c3774af93, x1b1ec609e70eb086 x43163d22e8cd5a71)
	{
		x95b7a3036d9d4cab = true;
		x9b287b671d592594.x3a52c4e37999b16e(x28180b3c3774af93);
		long result = (int)x9b287b671d592594.BaseStream.Position;
		x9b287b671d592594.Write((byte)0);
		x9b287b671d592594.Write((ushort)x69adfc837998abf7(x43163d22e8cd5a71));
		return result;
	}

	protected void xdff84d5a65b9347a(long x30cc7819189f11b6)
	{
		long position = x9b287b671d592594.BaseStream.Position;
		x9b287b671d592594.BaseStream.Position = x30cc7819189f11b6;
		x9b287b671d592594.Write((byte)(position - x30cc7819189f11b6 - 1));
		x9b287b671d592594.BaseStream.Position = position;
		x95b7a3036d9d4cab = false;
	}

	protected void x2640c2c8da422cb3(int xba08ce632055a1d9)
	{
		Border x14cf9593b86ecbaa = (Border)x66c02128fdc6436a.xf7866f89640a29a3(xba08ce632055a1d9);
		Border border = x1df55585ec1be056.x002fafae3e338912(x7450cc1e48712286, x14cf9593b86ecbaa);
		if (border != null)
		{
			x66c02128fdc6436a.xae20093bed1e48a8(xba08ce632055a1d9, border);
		}
	}

	protected void x263126e767bb1792(int xba08ce632055a1d9)
	{
		Border x14cf9593b86ecbaa = (Border)x66c02128fdc6436a.xf7866f89640a29a3(xba08ce632055a1d9);
		Border border = x1df55585ec1be056.x9b448ca00ed9c929(x7450cc1e48712286, x14cf9593b86ecbaa);
		if (border != null)
		{
			if (!border.x27d7528a28faeec8() && !border.xbca512cb9f5a451a)
			{
				x98b0e09ccece0a5a.x3dc950453374051a(xa056586c1f99e199, WarningSource.Doc, "Invalid line style value is read for border while reading DOC file.");
				border.LineStyle = LineStyle.None;
			}
			x66c02128fdc6436a.xae20093bed1e48a8(xba08ce632055a1d9, border);
		}
	}

	protected void x7d7320edca68565e(int xba08ce632055a1d9)
	{
		x7d7320edca68565e(xba08ce632055a1d9, x66c02128fdc6436a);
	}

	protected void x7d7320edca68565e(int xba08ce632055a1d9, x7f77ea92be0d9042 xe9707cb1ec88db49)
	{
		Shading x12b7f8e5698b30a = (Shading)xe9707cb1ec88db49.xf7866f89640a29a3(xba08ce632055a1d9);
		Shading shading = x075263c82f5cad54.x002fafae3e338912(x7450cc1e48712286, x12b7f8e5698b30a);
		if (shading != null)
		{
			xe9707cb1ec88db49.xae20093bed1e48a8(xba08ce632055a1d9, shading);
		}
	}

	protected void x19ce25c3c13b0c39(int xba08ce632055a1d9)
	{
		x19ce25c3c13b0c39(xba08ce632055a1d9, x66c02128fdc6436a);
	}

	protected void x19ce25c3c13b0c39(int xba08ce632055a1d9, x7f77ea92be0d9042 xe9707cb1ec88db49)
	{
		Shading x12b7f8e5698b30a = (Shading)xe9707cb1ec88db49.xf7866f89640a29a3(xba08ce632055a1d9);
		Shading shading = x075263c82f5cad54.x9b448ca00ed9c929(x7450cc1e48712286, x12b7f8e5698b30a);
		if (shading != null)
		{
			xe9707cb1ec88db49.xae20093bed1e48a8(xba08ce632055a1d9, shading);
		}
	}

	protected void xf9b50472de6f2a55(x7f77ea92be0d9042 x9ebb5a0ce8fc4fc4)
	{
		xf9b50472de6f2a55(x9ebb5a0ce8fc4fc4, x677e602d930f9cfb: true);
	}

	protected void xf9b50472de6f2a55(x7f77ea92be0d9042 x9ebb5a0ce8fc4fc4, bool x677e602d930f9cfb)
	{
		bool flag = x7450cc1e48712286.ReadByte() != 0;
		int x9f442fb6cbea238c = x7450cc1e48712286.ReadInt16();
		DateTime dateTime = xed28c1e5772a17ea.x06b0e25aa6ad68a9(x7450cc1e48712286);
		if (flag)
		{
			x5fb16e270c21db2e x5fb16e270c21db2e = new x5fb16e270c21db2e(x9ebb5a0ce8fc4fc4, xaca3428582882d9d.x8f3a8caf455fbd75(x9f442fb6cbea238c), dateTime);
			x66c02128fdc6436a.xae20093bed1e48a8(10010, x5fb16e270c21db2e);
			if (x677e602d930f9cfb)
			{
				x66c02128fdc6436a = x5fb16e270c21db2e.xdf4bcc85da8f85b2;
			}
		}
	}

	protected void x9566f11596f04e72(x875aca5784596b73 x2e0cd070a8f04e23, x875aca5784596b73 x3c1bbd3494e4867e)
	{
		if (x66c02128fdc6436a.x0f53f53f15b61ef5)
		{
			x5fb16e270c21db2e x5fb16e270c21db2e = x66c02128fdc6436a.x5fb16e270c21db2e;
			x9b287b671d592594.x3a52c4e37999b16e(x2e0cd070a8f04e23);
			x9b287b671d592594.Write((byte)7);
			x9b287b671d592594.Write((byte)1);
			x9b287b671d592594.Write((short)xaca3428582882d9d.x157cb2cfc16453ee(x5fb16e270c21db2e.xb063bbfcfeade526));
			xed28c1e5772a17ea.x6210059f049f0d48(x5fb16e270c21db2e.x242851e6278ed355, x9b287b671d592594);
			x9b287b671d592594.x9d91059a64953e89(x3c1bbd3494e4867e, xbcea506a33cf9111: true);
			xf6a9c32be7864635 = true;
			x7f77ea92be0d9042 x7f77ea92be0d = x66c02128fdc6436a;
			x66c02128fdc6436a = x5fb16e270c21db2e.xdf4bcc85da8f85b2;
			WriteCore();
			x66c02128fdc6436a = x7f77ea92be0d;
			xf6a9c32be7864635 = false;
		}
	}

	protected void x2b63788f541b61ed(int xec51f524f3f839d9, int x15bb86ffc08baf97, bool x063dc23d24025556)
	{
		int num = x7450cc1e48712286.ReadInt16();
		object obj = x2f717babec2a8e7f.xd43d4db190ad0d78(num);
		if (obj != null)
		{
			x66c02128fdc6436a.xae20093bed1e48a8(xec51f524f3f839d9, 0);
			x66c02128fdc6436a.xae20093bed1e48a8(x15bb86ffc08baf97, obj);
		}
		else
		{
			x66c02128fdc6436a.xae20093bed1e48a8(xec51f524f3f839d9, x063dc23d24025556 ? (num - 1) : num);
			x66c02128fdc6436a.xae20093bed1e48a8(x15bb86ffc08baf97, HorizontalAlignment.None);
		}
	}

	protected void x2b63788f541b61ed(int xec51f524f3f839d9, int x15bb86ffc08baf97)
	{
		x2b63788f541b61ed(xec51f524f3f839d9, x15bb86ffc08baf97, x063dc23d24025556: false);
	}

	protected void xe58888a235038afd(int x9e27eb7c86ed6fa1, int x052cb01fbe24bd46, bool x063dc23d24025556)
	{
		int num = x7450cc1e48712286.ReadInt16();
		object obj = x2f717babec2a8e7f.xe6b0c89a4a739248(num);
		if (obj != null)
		{
			x66c02128fdc6436a.xae20093bed1e48a8(x9e27eb7c86ed6fa1, 0);
			x66c02128fdc6436a.xae20093bed1e48a8(x052cb01fbe24bd46, obj);
		}
		else
		{
			x66c02128fdc6436a.xae20093bed1e48a8(x9e27eb7c86ed6fa1, x063dc23d24025556 ? (num - 1) : num);
			x66c02128fdc6436a.xae20093bed1e48a8(x052cb01fbe24bd46, VerticalAlignment.None);
		}
	}

	protected void xe58888a235038afd(int x9e27eb7c86ed6fa1, int x052cb01fbe24bd46)
	{
		xe58888a235038afd(x9e27eb7c86ed6fa1, x052cb01fbe24bd46, x063dc23d24025556: false);
	}

	protected void x1ca1a6c61763ad66(x875aca5784596b73 x9035cf16181332fc, int xec51f524f3f839d9, int x15bb86ffc08baf97, bool x063dc23d24025556)
	{
		if (x66c02128fdc6436a.xbc5dc59d0d9b620d(xec51f524f3f839d9) || x66c02128fdc6436a.xbc5dc59d0d9b620d(x15bb86ffc08baf97))
		{
			HorizontalAlignment horizontalAlignment = (HorizontalAlignment)x66c02128fdc6436a.xfe91eeeafcb3026a(x15bb86ffc08baf97);
			int xbcea506a33cf = ((horizontalAlignment != 0) ? x2f717babec2a8e7f.xaaba364645901dfa(horizontalAlignment) : (x063dc23d24025556 ? ((int)x66c02128fdc6436a.xfe91eeeafcb3026a(xec51f524f3f839d9) + 1) : ((int)x66c02128fdc6436a.xfe91eeeafcb3026a(xec51f524f3f839d9))));
			x9b287b671d592594.xd776ae6f68bc4d9c(x9035cf16181332fc, xbcea506a33cf);
		}
	}

	protected void x1ca1a6c61763ad66(x875aca5784596b73 x9035cf16181332fc, int xec51f524f3f839d9, int x15bb86ffc08baf97)
	{
		x1ca1a6c61763ad66(x9035cf16181332fc, xec51f524f3f839d9, x15bb86ffc08baf97, x063dc23d24025556: false);
	}

	protected void x21d53041f795334c(x875aca5784596b73 x9035cf16181332fc, int x9e27eb7c86ed6fa1, int x052cb01fbe24bd46, bool x063dc23d24025556)
	{
		if (x66c02128fdc6436a.xbc5dc59d0d9b620d(x9e27eb7c86ed6fa1) || x66c02128fdc6436a.xbc5dc59d0d9b620d(x052cb01fbe24bd46))
		{
			VerticalAlignment verticalAlignment = (VerticalAlignment)x66c02128fdc6436a.xfe91eeeafcb3026a(x052cb01fbe24bd46);
			int xbcea506a33cf = ((verticalAlignment != 0) ? x2f717babec2a8e7f.xc61c9cd360ef06b7(verticalAlignment) : (x063dc23d24025556 ? ((int)x66c02128fdc6436a.xfe91eeeafcb3026a(x9e27eb7c86ed6fa1) + 1) : ((int)x66c02128fdc6436a.xfe91eeeafcb3026a(x9e27eb7c86ed6fa1))));
			x9b287b671d592594.xd776ae6f68bc4d9c(x9035cf16181332fc, xbcea506a33cf);
		}
	}

	protected void x21d53041f795334c(x875aca5784596b73 x9035cf16181332fc, int x9e27eb7c86ed6fa1, int x052cb01fbe24bd46)
	{
		x21d53041f795334c(x9035cf16181332fc, x9e27eb7c86ed6fa1, x052cb01fbe24bd46, x063dc23d24025556: false);
	}

	protected void xfcbfa618cffcaf3b(int x75af7b3d562e25ab, int xa20ffe3ba3c9d857)
	{
		int num = x7450cc1e48712286.ReadByte();
		int num2 = (num & 0x30) >> 4;
		if (num2 != 3)
		{
			x66c02128fdc6436a.xae20093bed1e48a8(xa20ffe3ba3c9d857, x2f717babec2a8e7f.x236ab77a519bb64a(num2));
		}
		int num3 = (num & 0xC0) >> 6;
		if (num3 != 3)
		{
			x66c02128fdc6436a.xae20093bed1e48a8(x75af7b3d562e25ab, x2f717babec2a8e7f.x06defeda9eeb2545(num3));
		}
	}

	protected void x8911bca820bfab79(x875aca5784596b73 x9035cf16181332fc, int x75af7b3d562e25ab, int xa20ffe3ba3c9d857)
	{
		if (x66c02128fdc6436a.xbc5dc59d0d9b620d(x75af7b3d562e25ab) || x66c02128fdc6436a.xbc5dc59d0d9b620d(xa20ffe3ba3c9d857))
		{
			int num = x2f717babec2a8e7f.x0e9e6ad8f0b1a8aa((RelativeVerticalPosition)x66c02128fdc6436a.xfe91eeeafcb3026a(xa20ffe3ba3c9d857));
			int num2 = x2f717babec2a8e7f.x2e629e7dee0425f3((RelativeHorizontalPosition)x66c02128fdc6436a.xfe91eeeafcb3026a(x75af7b3d562e25ab));
			int xbcea506a33cf = (num << 4) | (num2 << 6);
			x9b287b671d592594.x1680160a63ff3e0b(x9035cf16181332fc, xbcea506a33cf);
		}
	}

	protected void x7da53fcf55413cb5(x456c8b07916a8790 xb5001325846e2ee9, BinaryReader xe134235b3526fa75, int xb5964a891b6cf7c3, x70d40b77e7fb14d0 xd515847b862b6b66)
	{
		x1b1ec609e70eb086 x43163d22e8cd5a = xd4e129043d0cce57((x58d6a3ec2a2998ff)xe134235b3526fa75.ReadInt16());
		x95b7a3036d9d4cab = true;
		x7f77ea92be0d9042 x7f77ea92be0d = x66c02128fdc6436a;
		x66c02128fdc6436a = xe5ef82d048062925.xbb34992bd03b3875(x43163d22e8cd5a, xd515847b862b6b66);
		xd503583b32a53cea xd503583b32a53cea2 = new xd503583b32a53cea(xb5001325846e2ee9, xe134235b3526fa75);
		xd503583b32a53cea2.x06b0e25aa6ad68a9(xe134235b3526fa75.ReadBytes(xb5964a891b6cf7c3 - 2));
		x66c02128fdc6436a = x7f77ea92be0d;
		x95b7a3036d9d4cab = false;
	}

	protected void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45, params object[] xce8d8c7e3c2c2426)
	{
		x98b0e09ccece0a5a.xbbf9a1ead81dd3a1(xa056586c1f99e199, x9f91de645a9fe01a, WarningSource.Doc, xc2358fbac7da3d45, xce8d8c7e3c2c2426);
	}

	protected void x3dc950453374051a(string xc2358fbac7da3d45, params object[] xce8d8c7e3c2c2426)
	{
		x98b0e09ccece0a5a.x3dc950453374051a(xa056586c1f99e199, WarningSource.Doc, xc2358fbac7da3d45, xce8d8c7e3c2c2426);
	}

	protected void xd28f53fd94b9c0e4(string xc2358fbac7da3d45, params object[] xce8d8c7e3c2c2426)
	{
		x98b0e09ccece0a5a.xd28f53fd94b9c0e4(xa056586c1f99e199, WarningSource.Doc, xc2358fbac7da3d45, xce8d8c7e3c2c2426);
	}
}
