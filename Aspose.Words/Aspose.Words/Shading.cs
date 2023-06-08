using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x5794c252ba25e723;

namespace Aspose.Words;

public class Shading : x11e014059489ae95
{
	private x39462b2e4fc652e7 xc454c03c23d4b4d9;

	private int x824f14e92de69876;

	private TextureIndex xc89939629b6375a5;

	private x26d9ecb4bdf0456d xafea0e9718247608;

	private x26d9ecb4bdf0456d xfd1e04a5633131c0;

	private string x43cc04205601f9c7;

	private string x74fb49f5adf29cac;

	private string xecdbc80736a31aa5;

	private string x00b10e26d1e36c6c;

	private string x116930e494eb7e1d;

	private string xab87737af1866431;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool xc8ea2954a6825f32 => xa157de8185757b11;

	internal bool xa157de8185757b11 => xc454c03c23d4b4d9 != null;

	public Color BackgroundPatternColor
	{
		get
		{
			return x0e18178ac4b2272f.xc7656a130b2889c7();
		}
		set
		{
			x0e18178ac4b2272f = x26d9ecb4bdf0456d.xcd907c08c553c15c(value);
		}
	}

	internal x26d9ecb4bdf0456d x0e18178ac4b2272f
	{
		get
		{
			if (!xa157de8185757b11)
			{
				return xfd1e04a5633131c0;
			}
			return x144aa4462fe3ef7c.x0e18178ac4b2272f;
		}
		set
		{
			xea38c993925dfec4();
			xfd1e04a5633131c0 = value;
		}
	}

	public Color ForegroundPatternColor
	{
		get
		{
			return xc290f60df004e384.xc7656a130b2889c7();
		}
		set
		{
			xc290f60df004e384 = x26d9ecb4bdf0456d.xcd907c08c553c15c(value);
		}
	}

	internal x26d9ecb4bdf0456d xc290f60df004e384
	{
		get
		{
			if (!xa157de8185757b11)
			{
				return xafea0e9718247608;
			}
			return x144aa4462fe3ef7c.xc290f60df004e384;
		}
		set
		{
			xea38c993925dfec4();
			xafea0e9718247608 = value;
		}
	}

	public TextureIndex Texture
	{
		get
		{
			if (!xa157de8185757b11)
			{
				return xc89939629b6375a5;
			}
			return x144aa4462fe3ef7c.Texture;
		}
		set
		{
			xea38c993925dfec4();
			xc89939629b6375a5 = value;
		}
	}

	internal string x19119439284aead2
	{
		get
		{
			return x43cc04205601f9c7;
		}
		set
		{
			x43cc04205601f9c7 = value;
		}
	}

	internal string x545df332a972f97f
	{
		get
		{
			return x74fb49f5adf29cac;
		}
		set
		{
			x74fb49f5adf29cac = value;
		}
	}

	internal string xc7a5a1bef7198132
	{
		get
		{
			return xecdbc80736a31aa5;
		}
		set
		{
			xecdbc80736a31aa5 = value;
		}
	}

	internal string xdb84466ee4f5c751
	{
		get
		{
			return x00b10e26d1e36c6c;
		}
		set
		{
			x00b10e26d1e36c6c = value;
		}
	}

	internal string x3799d35904b4df9e
	{
		get
		{
			return x116930e494eb7e1d;
		}
		set
		{
			x116930e494eb7e1d = value;
		}
	}

	internal string x32bc86f72d097c5d
	{
		get
		{
			return xab87737af1866431;
		}
		set
		{
			xab87737af1866431 = value;
		}
	}

	internal bool xa853df7acdb217c8
	{
		get
		{
			if (Texture == TextureIndex.TextureNone || Texture == TextureIndex.TextureNil)
			{
				return !x0e18178ac4b2272f.x7149c962c02931b3;
			}
			return true;
		}
	}

	private Shading x144aa4462fe3ef7c => (Shading)xc454c03c23d4b4d9.xccf76df3dc24953f(x824f14e92de69876);

	internal Shading()
	{
		ClearFormatting();
	}

	internal Shading(x39462b2e4fc652e7 parent, int key)
	{
		xc454c03c23d4b4d9 = parent;
		x824f14e92de69876 = key;
	}

	public void ClearFormatting()
	{
		xc454c03c23d4b4d9 = null;
		xc89939629b6375a5 = TextureIndex.TextureNone;
		xafea0e9718247608 = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		xfd1e04a5633131c0 = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		x43cc04205601f9c7 = null;
		x74fb49f5adf29cac = null;
		xecdbc80736a31aa5 = null;
		x00b10e26d1e36c6c = null;
		x116930e494eb7e1d = null;
		xab87737af1866431 = null;
	}

	internal bool Equals(Shading rhs)
	{
		if (object.ReferenceEquals(null, rhs))
		{
			return false;
		}
		if (object.ReferenceEquals(this, rhs))
		{
			return true;
		}
		if (Texture == rhs.Texture && xc290f60df004e384 == rhs.xc290f60df004e384 && x0e18178ac4b2272f == rhs.x0e18178ac4b2272f && x19119439284aead2 == rhs.x19119439284aead2 && x545df332a972f97f == rhs.x545df332a972f97f && xc7a5a1bef7198132 == rhs.xc7a5a1bef7198132 && xdb84466ee4f5c751 == rhs.xdb84466ee4f5c751 && x3799d35904b4df9e == rhs.x3799d35904b4df9e)
		{
			return x32bc86f72d097c5d == rhs.x32bc86f72d097c5d;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != typeof(Shading))
		{
			return false;
		}
		return Equals((Shading)obj);
	}

	public override int GetHashCode()
	{
		int num = (int)xc89939629b6375a5;
		num = (num * 397) ^ ((xafea0e9718247608 != null) ? xafea0e9718247608.GetHashCode() : 0);
		num = (num * 397) ^ ((xfd1e04a5633131c0 != null) ? xfd1e04a5633131c0.GetHashCode() : 0);
		num = (num * 397) ^ ((x43cc04205601f9c7 != null) ? x43cc04205601f9c7.GetHashCode() : 0);
		num = (num * 397) ^ ((x74fb49f5adf29cac != null) ? x74fb49f5adf29cac.GetHashCode() : 0);
		num = (num * 397) ^ ((xecdbc80736a31aa5 != null) ? xecdbc80736a31aa5.GetHashCode() : 0);
		num = (num * 397) ^ ((x00b10e26d1e36c6c != null) ? x00b10e26d1e36c6c.GetHashCode() : 0);
		num = (num * 397) ^ ((x116930e494eb7e1d != null) ? x116930e494eb7e1d.GetHashCode() : 0);
		return (num * 397) ^ ((xab87737af1866431 != null) ? xab87737af1866431.GetHashCode() : 0);
	}

	private void xea38c993925dfec4()
	{
		if (xa157de8185757b11)
		{
			xd9641c81aa48bd0d(x144aa4462fe3ef7c);
			xc454c03c23d4b4d9 = null;
		}
	}

	private void xd9641c81aa48bd0d(Shading x50a18ad2656e7181)
	{
		if (x50a18ad2656e7181 == null)
		{
			throw new ArgumentNullException("src");
		}
		xc454c03c23d4b4d9 = x50a18ad2656e7181.xc454c03c23d4b4d9;
		x824f14e92de69876 = x50a18ad2656e7181.x824f14e92de69876;
		xc89939629b6375a5 = x50a18ad2656e7181.Texture;
		xafea0e9718247608 = x50a18ad2656e7181.xc290f60df004e384;
		xfd1e04a5633131c0 = x50a18ad2656e7181.x0e18178ac4b2272f;
		x43cc04205601f9c7 = x50a18ad2656e7181.x19119439284aead2;
		x74fb49f5adf29cac = x50a18ad2656e7181.x545df332a972f97f;
		xecdbc80736a31aa5 = x50a18ad2656e7181.xc7a5a1bef7198132;
		x00b10e26d1e36c6c = x50a18ad2656e7181.xdb84466ee4f5c751;
		x116930e494eb7e1d = x50a18ad2656e7181.x3799d35904b4df9e;
		xab87737af1866431 = x50a18ad2656e7181.x32bc86f72d097c5d;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	private x11e014059489ae95 xa9c9dc40c97ccfd0()
	{
		if (xa157de8185757b11)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("npjcibbdccidpbpdnbgepbneimdfialfoacgoajgkaahopghglnhepeioplinkcjdpjjfpakmohkgookapfleomlmodmknkmgnbnpiinnmpnnngoknnofnepjmlpplcapmjalmabjlhbphob", 117713338)));
		}
		return (Shading)MemberwiseClone();
	}

	x11e014059489ae95 x11e014059489ae95.xcc4933610939ad04()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa9c9dc40c97ccfd0
		return this.xa9c9dc40c97ccfd0();
	}

	internal Shading x8b61531c8ea35b85()
	{
		if (xa157de8185757b11)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("piolkkfmelmmbldnpkknblbokfiokjpoakgpaknpmjeaajlaiecbgijbajacpdhcfiochifdohmdihdecikeghbfohifmgpfigggbcngpfehpglhmgcihgjilfajbfhjbgojnffklemkbbdl", 2127674956)));
		}
		return (Shading)MemberwiseClone();
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void xa38d8176588e85f3(params object[] xcd31b50c43a96e21)
	{
	}
}
