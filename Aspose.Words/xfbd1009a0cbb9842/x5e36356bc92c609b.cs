using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x2a6f63b6650e76c4;

namespace xfbd1009a0cbb9842;

internal class x5e36356bc92c609b
{
	private Field x54c413cc80cb99d5;

	private xfedf115fd9c03862 x9a4ce700a778f1a8;

	private x5e36356bc92c609b xa172d54c8223c3a0;

	private string x69a08072740439ca;

	private bool x21f190785b3e3036;

	private x57af31d8c74e631c xf7c2bb1665513b83;

	private readonly Hashtable xd3e0ab315d8d658b = new Hashtable();

	private bool x9bcb7dddf2b11b6c;

	private xdac068096ca09318 xfcf287336ac0f736;

	private x5699f8523a546a42 x07da8940d78e1072;

	internal Field xd1b40af56a8385d4 => x54c413cc80cb99d5;

	internal xfedf115fd9c03862 x34a4695711b84f85 => x9a4ce700a778f1a8;

	internal bool x752cfab9af626fd5 => xa172d54c8223c3a0 != null;

	internal x5e36356bc92c609b x506887e8e64fb56f => xa172d54c8223c3a0;

	internal bool x933af3effe3af4af => xfcf287336ac0f736 != null;

	internal string x43f4d74ca20da89e
	{
		get
		{
			return x69a08072740439ca;
		}
		set
		{
			x69a08072740439ca = value;
		}
	}

	internal bool x06768d79f7751c4d
	{
		get
		{
			return x21f190785b3e3036;
		}
		set
		{
			x21f190785b3e3036 = value;
		}
	}

	internal x57af31d8c74e631c x004daeac26db37fe => xf7c2bb1665513b83;

	internal bool x2f525bda126aa442
	{
		get
		{
			return x9bcb7dddf2b11b6c;
		}
		set
		{
			x9bcb7dddf2b11b6c = value;
		}
	}

	internal xdac068096ca09318 xefabd160dd587f64
	{
		get
		{
			return xfcf287336ac0f736;
		}
		set
		{
			xfcf287336ac0f736 = value;
		}
	}

	private x5e36356bc92c609b()
	{
	}

	internal x5e36356bc92c609b(Field field)
		: this(field, new xfedf115fd9c03862(field))
	{
	}

	internal x5e36356bc92c609b(Field field, xfedf115fd9c03862 updater)
	{
		x54c413cc80cb99d5 = field;
		x9a4ce700a778f1a8 = updater;
	}

	internal static x5e36356bc92c609b x48539ee51dba0fcf(Field xe01ae93d9fe5a880, x5e36356bc92c609b xb45f9c07301e0b67, x7d5e2f34b6651bf4 xa5d8121a093a4f5c)
	{
		x5e36356bc92c609b x5e36356bc92c609b2 = new x5e36356bc92c609b();
		x5e36356bc92c609b2.x54c413cc80cb99d5 = xe01ae93d9fe5a880;
		x5e36356bc92c609b2.x9a4ce700a778f1a8 = xb45f9c07301e0b67.x9a4ce700a778f1a8;
		if (xa5d8121a093a4f5c == x7d5e2f34b6651bf4.xb0b4ff1622a01d12)
		{
			x5e36356bc92c609b2.xa172d54c8223c3a0 = xb45f9c07301e0b67;
			x5e36356bc92c609b2.xfcf287336ac0f736 = xb45f9c07301e0b67.xfcf287336ac0f736;
		}
		return x5e36356bc92c609b2;
	}

	internal x82e26649b09596bd x803fdc6662fa3f31()
	{
		if (x933af3effe3af4af)
		{
			x82e26649b09596bd x82e26649b09596bd = xfcf287336ac0f736.x3f88a25febd23896(x54c413cc80cb99d5);
			if (x82e26649b09596bd != null)
			{
				return x82e26649b09596bd;
			}
		}
		return x9a4ce700a778f1a8.x803fdc6662fa3f31(x54c413cc80cb99d5);
	}

	internal object xc1acbb49fa87a8a3()
	{
		return x9a4ce700a778f1a8.xc1acbb49fa87a8a3(x54c413cc80cb99d5);
	}

	internal x5e36356bc92c609b xfb9ab092513c65d9()
	{
		x5e36356bc92c609b x5e36356bc92c609b2 = this;
		while (x5e36356bc92c609b2.x752cfab9af626fd5)
		{
			x5e36356bc92c609b2 = x5e36356bc92c609b2.x506887e8e64fb56f;
		}
		return x5e36356bc92c609b2;
	}

	internal xcf417e2db4fe9ed3 xcf4268d5a79e653b()
	{
		xcf417e2db4fe9ed3 xcf417e2db4fe9ed4 = x5c29822913be33c1.x48ccce05802169c7(x54c413cc80cb99d5);
		switch (xcf417e2db4fe9ed4)
		{
		case xcf417e2db4fe9ed3.xa370a6f48a445ff9:
			return xcf417e2db4fe9ed3.x35cfcea4890f4e7d;
		case xcf417e2db4fe9ed3.x290a7f421b080483:
			if (x933af3effe3af4af)
			{
				return xcf417e2db4fe9ed3.x35cfcea4890f4e7d;
			}
			break;
		default:
			throw new InvalidOperationException();
		case xcf417e2db4fe9ed3.xa4eb7166eb7f09b4:
		case xcf417e2db4fe9ed3.x5a360e1cee7f2c61:
			break;
		}
		if (!x9a4ce700a778f1a8.xcf4268d5a79e653b(x54c413cc80cb99d5, xcf417e2db4fe9ed4))
		{
			return xcf417e2db4fe9ed3.x35cfcea4890f4e7d;
		}
		return xcf417e2db4fe9ed4;
	}

	internal void xcd5c6b74a5207c7d()
	{
		for (x5e36356bc92c609b x5e36356bc92c609b2 = x506887e8e64fb56f; x5e36356bc92c609b2 != null; x5e36356bc92c609b2 = x5e36356bc92c609b2.x506887e8e64fb56f)
		{
			x5e36356bc92c609b2.x2f525bda126aa442 = true;
		}
		Document document = x54c413cc80cb99d5.x357c90b33d6bb8e6();
		if (document.xc6ce8b20496b71f5)
		{
			x9a4ce700a778f1a8.x874035a07982e6e7(new xe88721c09229233b(document), xcf417e2db4fe9ed3.x9fd888e65466818c);
		}
	}

	private void xa7d2ef9410b5d78c(Field xe01ae93d9fe5a880)
	{
		xd3e0ab315d8d658b.Add(xe01ae93d9fe5a880.Start, xe01ae93d9fe5a880);
	}

	internal void x9a64fac49f4da132(x57af31d8c74e631c xab8fe3cd8c5556fb)
	{
		xf7c2bb1665513b83 = xab8fe3cd8c5556fb;
		if (x752cfab9af626fd5)
		{
			xa172d54c8223c3a0.xa7d2ef9410b5d78c(x54c413cc80cb99d5);
		}
	}

	internal void xdc608dfe6805120e(FieldStart xa6315bf377f6364c)
	{
		Field field = (Field)xd3e0ab315d8d658b[xa6315bf377f6364c];
		if (field != null)
		{
			field.x6edce55dcd2d335b.x06768d79f7751c4d = x06768d79f7751c4d;
		}
	}

	internal bool x45bd6960cee454bd()
	{
		if (xd3e0ab315d8d658b.Count > 0)
		{
			foreach (DictionaryEntry item in xd3e0ab315d8d658b)
			{
				Field field = (Field)item.Value;
				field.x6edce55dcd2d335b.x004daeac26db37fe.xb333e1e6c01c2be2(field);
			}
			xd3e0ab315d8d658b.Clear();
			return true;
		}
		return false;
	}

	internal void xdd53735657fe1b6b()
	{
		if (x07da8940d78e1072 == null)
		{
			x07da8940d78e1072 = new x5699f8523a546a42(xd1b40af56a8385d4.xabae4fa6681a6afd(x7d5e2f34b6651bf4.xf8d31d196ccd74c4), xe1bd913bc72a8d58.x93e9ea6b6c905cc5);
			x07da8940d78e1072.xd993fd34ab5f063d();
		}
	}

	internal void xac51c2571643df46()
	{
		if (x07da8940d78e1072 != null)
		{
			x07da8940d78e1072.xd777282ef2cf0d3d();
			x07da8940d78e1072 = null;
		}
	}
}
