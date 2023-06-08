using System;
using Aspose;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x4f4df92b75ba3b67;

internal class x9c3b5a148fe3d694 : x265d1165173b3fb3
{
	private byte[] xd08494dce3b2b550;

	private x02df97c06afacbf3 x8dab1a0b6655c671;

	private xc402f9a087112e63 x4a66f2abeb17a818;

	private xa2745adfabe0c674 xbfcb11d1f4e5d8ba;

	private x28d5285d743f03f5 xbe95c1c9fb11a4ba;

	private int xe97e96740bd5f717;

	private x469ef7a51cfbda24 x50bb415121e9c72b;

	private x4d8917c8186e8cb2 xe225379ce9525abe;

	private int x4d06d5f056cb5cf9;

	private xf276f6a75b584d31 x491c1af7ed6ea845;

	internal x9c3b5a148fe3d694(x4882ae789be6e2ef context, byte[] imageBytes, x02df97c06afacbf3 crop, xf276f6a75b584d31 chromaKey)
		: base(context)
	{
		xd08494dce3b2b550 = imageBytes;
		x8dab1a0b6655c671 = crop;
		x4a66f2abeb17a818 = x8cedcaa9a62c6e39.x73979cef1002ed01.x50760500f119773d;
		x491c1af7ed6ea845 = chromaKey;
		if (x4a66f2abeb17a818 == xc402f9a087112e63.x2bca50d746ec73b2)
		{
			x4a66f2abeb17a818 = ((xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(xd08494dce3b2b550) == xfe2ff3c162b47c70.x796ab23ce57ee1e0) ? xc402f9a087112e63.x796ab23ce57ee1e0 : xc402f9a087112e63.x021301649c58465b);
		}
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		try
		{
			xd242e8bfe0aa2699(writer);
		}
		catch (Exception)
		{
			x8cedcaa9a62c6e39.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, "Unsupported image format.");
			xd08494dce3b2b550 = x0d299f323d241756.xcd6c2a9742c9220a();
			x8dab1a0b6655c671 = null;
			xd242e8bfe0aa2699(writer);
		}
	}

	private void xd242e8bfe0aa2699(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		using (x3cd5d648729cd9b6 x3cd5d648729cd9b = x19b7dd7902754d4e())
		{
			xbfcb11d1f4e5d8ba = xa2745adfabe0c674.xe6a756f8b9f6fe18(x3cd5d648729cd9b.xdc1bf80853046136, x3cd5d648729cd9b.xb0f146032f47c24e, x3cd5d648729cd9b.xf2b3620f7bfc9ed5, x3cd5d648729cd9b.x5c6fc5693c6898cd);
			if (x3cd5d648729cd9b.x30a1d7c1aef14f56() == x342b86618ed63a10.x7bc2cd43944d90a3)
			{
				x26d9ecb4bdf0456d[] xc9808022f4ecf = x3cd5d648729cd9b.x063edd567c9c22da();
				x6c2b89e5b468986b(xc9808022f4ecf);
				if (x4a66f2abeb17a818 == xc402f9a087112e63.x796ab23ce57ee1e0)
				{
					x4a66f2abeb17a818 = xc402f9a087112e63.x021301649c58465b;
				}
			}
			xe2e0a8f42145981d(x3cd5d648729cd9b);
		}
		base.WriteToPdf(xbdfb620b7167944b);
		if (xe225379ce9525abe != null)
		{
			xe225379ce9525abe.WriteToPdf(xbdfb620b7167944b);
			xe225379ce9525abe = null;
		}
		if (x50bb415121e9c72b != null)
		{
			x50bb415121e9c72b.WriteToPdf(xbdfb620b7167944b);
			x50bb415121e9c72b = null;
		}
	}

	private x3cd5d648729cd9b6 x19b7dd7902754d4e()
	{
		if (x8dab1a0b6655c671 != null && x8dab1a0b6655c671.x523ab7004b988e96)
		{
			return x8dab1a0b6655c671.xa4e45e1d9e114000(xd08494dce3b2b550);
		}
		return new x3cd5d648729cd9b6(xd08494dce3b2b550);
	}

	[JavaThrows(true)]
	private void xe2e0a8f42145981d(x3cd5d648729cd9b6 xe205f0cd81228282)
	{
		switch (x4a66f2abeb17a818)
		{
		case xc402f9a087112e63.x796ab23ce57ee1e0:
			xb8ca917708786e8b(xe205f0cd81228282);
			break;
		case xc402f9a087112e63.xf6875da725c82a98:
		case xc402f9a087112e63.xd9c34d7c9f00a2f9:
			xf6ef73442a3a0d80(xe205f0cd81228282, xfc9f6120a37a69d7: true);
			break;
		default:
			xf6ef73442a3a0d80(xe205f0cd81228282, xfc9f6120a37a69d7: false);
			break;
		}
	}

	private void xb8ca917708786e8b(x3cd5d648729cd9b6 xe205f0cd81228282)
	{
		x0a7d7e73b38df462(xe205f0cd81228282);
		switch (xe205f0cd81228282.x30a1d7c1aef14f56())
		{
		case x342b86618ed63a10.x2c689d7a8a2c3c93:
			xbe95c1c9fb11a4ba = x28d5285d743f03f5.x529d0bc70de5de1f;
			xe97e96740bd5f717 = 8;
			break;
		case x342b86618ed63a10.x4ad4518443afe7c9:
			xbe95c1c9fb11a4ba = x28d5285d743f03f5.x3e8193d537ae8eac;
			xe97e96740bd5f717 = 8;
			break;
		default:
			throw new InvalidOperationException("Unexpected color model.");
		}
	}

	private void x0a7d7e73b38df462(x3cd5d648729cd9b6 xe205f0cd81228282)
	{
		if (xe205f0cd81228282.x688d6f6524ba3c8b == xfe2ff3c162b47c70.x796ab23ce57ee1e0 && xf5722612b0322e3d())
		{
			if (xe205f0cd81228282.x12de99d3fe309d8f())
			{
				xe205f0cd81228282.x2746a43e49feca2f(base.x9e418ad9a56d1cf5, x8cedcaa9a62c6e39.x73979cef1002ed01.xf7575b7b1ee35d49);
			}
			else
			{
				x6210059f049f0d48(xd08494dce3b2b550, 0, xd08494dce3b2b550.Length);
			}
		}
		else
		{
			xe205f0cd81228282.x2746a43e49feca2f(base.x9e418ad9a56d1cf5, x8cedcaa9a62c6e39.x73979cef1002ed01.xf7575b7b1ee35d49);
		}
	}

	private void xf6ef73442a3a0d80(x3cd5d648729cd9b6 xe205f0cd81228282, bool xfc9f6120a37a69d7)
	{
		bool flag = !x8cedcaa9a62c6e39.x5ba9693d4c3c102e;
		bool xc2e8f3eda = !flag;
		xedbd1996b60ba29c xedbd1996b60ba29c = xe205f0cd81228282.x5e245124259e7268(xfc9f6120a37a69d7, xc2e8f3eda, x491c1af7ed6ea845);
		x491c1af7ed6ea845 = null;
		xa17ff22aa604012f(xedbd1996b60ba29c);
		x6210059f049f0d48(xedbd1996b60ba29c.xe2001cce235baad2, 0, xedbd1996b60ba29c.xe2001cce235baad2.Length);
		xbe95c1c9fb11a4ba = x28d5285d743f03f5.xd62557bb0eb80475(xedbd1996b60ba29c.x342b86618ed63a10);
		xe97e96740bd5f717 = xedbd1996b60ba29c.x1fda32d41ebcf020;
		if (xedbd1996b60ba29c.x24585bc9b0b1d9e9 || xedbd1996b60ba29c.xd7e5cd7ab6525f63)
		{
			if (flag)
			{
				x50bb415121e9c72b = new x469ef7a51cfbda24(x8cedcaa9a62c6e39, xedbd1996b60ba29c.x3c5747a5ee1946d5, xbfcb11d1f4e5d8ba.xdc1bf80853046136, xbfcb11d1f4e5d8ba.xb0f146032f47c24e);
			}
			else
			{
				x8cedcaa9a62c6e39.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, "Transparency does not conform to PDF/A standard. Transparent image has been made opaque.");
			}
		}
	}

	private void xa17ff22aa604012f(xedbd1996b60ba29c x1037b05dde2943fa)
	{
		if ((!x1037b05dde2943fa.xd7e5cd7ab6525f63 && !x1037b05dde2943fa.x24585bc9b0b1d9e9) || x1037b05dde2943fa.x342b86618ed63a10 == x342b86618ed63a10.x7bc2cd43944d90a3 || x1037b05dde2943fa.x342b86618ed63a10 == x342b86618ed63a10.x4ad4518443afe7c9)
		{
			return;
		}
		for (int i = 0; i < x1037b05dde2943fa.x3c5747a5ee1946d5.Length; i++)
		{
			if (x1037b05dde2943fa.x3c5747a5ee1946d5[i] == 0)
			{
				x1037b05dde2943fa.xe2001cce235baad2[3 * i] = (byte)x26d9ecb4bdf0456d.x66d844daa6e9f181.xc613adc4330033f3;
				x1037b05dde2943fa.xe2001cce235baad2[3 * i + 1] = (byte)x26d9ecb4bdf0456d.x66d844daa6e9f181.x26463655896fd90a;
				x1037b05dde2943fa.xe2001cce235baad2[3 * i + 2] = (byte)x26d9ecb4bdf0456d.x66d844daa6e9f181.x8e8f6cc6a0756b05;
			}
		}
	}

	private void xa17ff22aa604012f(x26d9ecb4bdf0456d[] xc9808022f4ecf319)
	{
		for (int i = 0; i < xc9808022f4ecf319.Length; i++)
		{
			if (xc9808022f4ecf319[i].xda71bf6f7c07c3bc == 0)
			{
				xc9808022f4ecf319[i] = x26d9ecb4bdf0456d.x66d844daa6e9f181;
			}
		}
	}

	private void x6c2b89e5b468986b(x26d9ecb4bdf0456d[] xc9808022f4ecf319)
	{
		xa17ff22aa604012f(xc9808022f4ecf319);
		xe225379ce9525abe = new x4d8917c8186e8cb2(x8cedcaa9a62c6e39);
		x4d06d5f056cb5cf9 = xc9808022f4ecf319.Length;
		for (int i = 0; i < x4d06d5f056cb5cf9; i++)
		{
			xe225379ce9525abe.xc351d479ff7ee789((byte)xc9808022f4ecf319[i].xc613adc4330033f3);
			xe225379ce9525abe.xc351d479ff7ee789((byte)xc9808022f4ecf319[i].x26463655896fd90a);
			xe225379ce9525abe.xc351d479ff7ee789((byte)xc9808022f4ecf319[i].x8e8f6cc6a0756b05);
		}
	}

	internal override x4c746eafc29e5079 xf57599e513eb82be()
	{
		switch (x4a66f2abeb17a818)
		{
		case xc402f9a087112e63.xf6875da725c82a98:
		case xc402f9a087112e63.xd9c34d7c9f00a2f9:
			return new x16dc68e1ea82ce9e(x4a66f2abeb17a818, xbfcb11d1f4e5d8ba);
		case xc402f9a087112e63.x021301649c58465b:
			return new x9e0a988568b64551();
		case xc402f9a087112e63.x796ab23ce57ee1e0:
			return new x7fce87ad7977a39a();
		case xc402f9a087112e63.x675c289b5339a759:
		case xc402f9a087112e63.x3261cbcb3719c1c4:
		{
			xa73d31814e085e6d xa73d31814e085e6d2 = new xa73d31814e085e6d();
			xa73d31814e085e6d2.x1fda32d41ebcf020 = xe97e96740bd5f717;
			xa73d31814e085e6d2.xbd7bb54d8760ed0a = xbfcb11d1f4e5d8ba.xdc1bf80853046136;
			xa73d31814e085e6d2.x2c0320b7c80c1e61 = xbe95c1c9fb11a4ba.xdb1ba24fae9ef815;
			xa73d31814e085e6d2.x988e9397bc83aaf3 = x4a66f2abeb17a818 == xc402f9a087112e63.x675c289b5339a759;
			return xa73d31814e085e6d2;
		}
		case xc402f9a087112e63.x4d0b9d4447ba7566:
			return null;
		case xc402f9a087112e63.x67749da60288d66c:
			return new x558f25bc598c7617();
		default:
			throw new InvalidOperationException("Unknown image compression filter type.");
		}
	}

	internal override void x0a2e1f2c2da67e52(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Type", "/XObject");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Subtype", "/Image");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Width", xbfcb11d1f4e5d8ba.xdc1bf80853046136);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Height", xbfcb11d1f4e5d8ba.xb0f146032f47c24e);
		if (x491c1af7ed6ea845 != null)
		{
			int[] xbcea506a33cf = new int[6]
			{
				x491c1af7ed6ea845.xdf863a776b239667.xc613adc4330033f3,
				x491c1af7ed6ea845.xb07c4db017102b70.xc613adc4330033f3,
				x491c1af7ed6ea845.xdf863a776b239667.x26463655896fd90a,
				x491c1af7ed6ea845.xb07c4db017102b70.x26463655896fd90a,
				x491c1af7ed6ea845.xdf863a776b239667.x8e8f6cc6a0756b05,
				x491c1af7ed6ea845.xb07c4db017102b70.x8e8f6cc6a0756b05
			};
			xbdfb620b7167944b.xa4dc0ad8886e23a2("/Mask", xbcea506a33cf);
		}
		if (xbe95c1c9fb11a4ba == x28d5285d743f03f5.x7bc2cd43944d90a3)
		{
			xbdfb620b7167944b.xa4dc0ad8886e23a2("/ColorSpace", $"[{xbe95c1c9fb11a4ba.x0155217fb8bbda6a}/DeviceRGB {x4d06d5f056cb5cf9 - 1} {xe225379ce9525abe.x899a2110a8a35fda}]");
		}
		else
		{
			xbdfb620b7167944b.xa4dc0ad8886e23a2("/ColorSpace", xbe95c1c9fb11a4ba.x0155217fb8bbda6a);
		}
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/BitsPerComponent", xe97e96740bd5f717);
		if (x50bb415121e9c72b != null)
		{
			xbdfb620b7167944b.xa4dc0ad8886e23a2("/SMask", x50bb415121e9c72b.x899a2110a8a35fda);
		}
	}

	private bool xf5722612b0322e3d()
	{
		return x8cedcaa9a62c6e39.x73979cef1002ed01.xf7575b7b1ee35d49 == 100;
	}
}
