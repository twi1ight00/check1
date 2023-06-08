using System.Collections;
using x38a89dee67fc7a16;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;

namespace x7dc87ca8f7f7b273;

internal class xd878af0d0717b77a
{
	private Hashtable x9ee620a4e6847a49 = new Hashtable();

	private xd345c73dd1b16b74 xc0d087858ac2d6fc = new xd345c73dd1b16b74();

	private Hashtable x7056611584e138d9 = new Hashtable();

	private int xc15fbe08856788d6;

	private x54b98d0096d7251a xa056586c1f99e199;

	private x3c74b3c4f21844f9 x9b287b671d592594;

	private xbc9dfa2bfc69713d x83d0f75f3858e3a4;

	private xf336a7bbc8d9b33f xe3fe1c34d837bdbf;

	public x3c74b3c4f21844f9 x5aa326f374b3d0ef => x9b287b671d592594;

	public xbc9dfa2bfc69713d x73979cef1002ed01 => x83d0f75f3858e3a4;

	public x54b98d0096d7251a xf69ca7a9bb4a4a51 => xa056586c1f99e199;

	public xd878af0d0717b77a(x3c74b3c4f21844f9 writer, xbc9dfa2bfc69713d options)
	{
		x9b287b671d592594 = writer;
		x83d0f75f3858e3a4 = options;
		xa056586c1f99e199 = options.x4d2cf6c77ee521cd();
		xe3fe1c34d837bdbf = new xf336a7bbc8d9b33f(options.xf7575b7b1ee35d49, xa056586c1f99e199, x3959df40367ac8a3.x6b60f7630a7ba83e);
	}

	public void x304b6d4b7f054ae1()
	{
		x5aa326f374b3d0ef.x2307058321cdb62f("defs");
		if (x73979cef1002ed01.xd6830e3399cd5355 == xa1f9fc75a377297a.xdbd20e87a6636992 || x73979cef1002ed01.xd6830e3399cd5355 == xa1f9fc75a377297a.x516adb49f27e286e)
		{
			x3363b5fd92e52a33 x733dd6b64d2ac9f = new x3363b5fd92e52a33(this, null);
			foreach (xcd986872cf3bcf68 value in xc0d087858ac2d6fc.GetValueList())
			{
				xc4d46ec64ab4b74a(x733dd6b64d2ac9f, value);
			}
		}
		if (x7056611584e138d9.Count > 0)
		{
			foreach (DictionaryEntry item in x7056611584e138d9)
			{
				x7d1f003f35efd2d0 x7d1f003f35efd2d = (x7d1f003f35efd2d0)item.Value;
				x7d1f003f35efd2d.x5664f05a403c3b73();
			}
		}
		x5aa326f374b3d0ef.x2dfde153f4ef96d0();
	}

	private void xc4d46ec64ab4b74a(x3363b5fd92e52a33 x733dd6b64d2ac9f9, xcd986872cf3bcf68 xdf4e8adcb2e5e03b)
	{
		switch (x73979cef1002ed01.xd6830e3399cd5355)
		{
		case xa1f9fc75a377297a.xdbd20e87a6636992:
			x733dd6b64d2ac9f9.xc4d46ec64ab4b74a(xdf4e8adcb2e5e03b);
			break;
		case xa1f9fc75a377297a.x516adb49f27e286e:
			x733dd6b64d2ac9f9.xb395c8e795fac79c(xdf4e8adcb2e5e03b);
			break;
		case xa1f9fc75a377297a.x40590fcd18085b57:
			break;
		}
	}

	public string x4a59854a1bae262a(x6b1a899052c71a60 x26094932cf7a9139)
	{
		string text = (string)x9ee620a4e6847a49[x26094932cf7a9139];
		if (text != null)
		{
			return text;
		}
		text = $"Font{x8e81c5a80377d905()}";
		x9ee620a4e6847a49[x26094932cf7a9139] = text;
		return text;
	}

	public xcd986872cf3bcf68 x5fa376febd884803(x6b1a899052c71a60 x26094932cf7a9139)
	{
		string key = x4a59854a1bae262a(x26094932cf7a9139);
		object obj = xc0d087858ac2d6fc[key];
		if (obj != null)
		{
			return (xcd986872cf3bcf68)obj;
		}
		obj = x26094932cf7a9139.x78789688b9fe78d2(x4867e759695b4319: false);
		xc0d087858ac2d6fc[key] = obj;
		return (xcd986872cf3bcf68)obj;
	}

	public string x9728de41bb77ce76(byte[] x43e181e083db6cdf, x02df97c06afacbf3 x5edc4e0499c937b4)
	{
		x43e181e083db6cdf = xe3fe1c34d837bdbf.x601e9a2243ca6720(x43e181e083db6cdf);
		int num = x02df97c06afacbf3.x1c3a4a07dc224a14(x43e181e083db6cdf, x5edc4e0499c937b4);
		x7d1f003f35efd2d0 x7d1f003f35efd2d = (x7d1f003f35efd2d0)x7056611584e138d9[num];
		if (x7d1f003f35efd2d == null)
		{
			x43e181e083db6cdf = xe3fe1c34d837bdbf.xe323925c2800577d(x43e181e083db6cdf, x5edc4e0499c937b4);
			x7d1f003f35efd2d = new x7d1f003f35efd2d0($"image{x8e81c5a80377d905()}", x43e181e083db6cdf, this);
			x7056611584e138d9[num] = x7d1f003f35efd2d;
		}
		return x7d1f003f35efd2d.xaa2bf8c845776543;
	}

	public int x8e81c5a80377d905()
	{
		return ++xc15fbe08856788d6;
	}
}
