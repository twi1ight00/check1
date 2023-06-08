using Aspose.Words;
using x5794c252ba25e723;

namespace x4adf554d20d941a6;

internal sealed class x5709acc7200773ff : xcf9d359063aa93f2
{
	internal static readonly x5709acc7200773ff x45260ad4b94166f2;

	private TextureIndex xc89939629b6375a5;

	private x26d9ecb4bdf0456d x5c3b7d4a019de9e1 = x26d9ecb4bdf0456d.x45260ad4b94166f2;

	private x26d9ecb4bdf0456d xe5cc466041b3bc40 = x26d9ecb4bdf0456d.x45260ad4b94166f2;

	internal bool x7149c962c02931b3
	{
		get
		{
			if (x7b6a6d281546db99 == TextureIndex.TextureNone || x7b6a6d281546db99 == TextureIndex.TextureNil)
			{
				return x83729c7ebf48ae24.x7149c962c02931b3;
			}
			return false;
		}
	}

	internal TextureIndex x7b6a6d281546db99
	{
		get
		{
			return xc89939629b6375a5;
		}
		set
		{
			x71c6d753219cc1b7();
			xc89939629b6375a5 = value;
		}
	}

	internal x26d9ecb4bdf0456d x8fdbd80e8da6b0e6
	{
		get
		{
			return x5c3b7d4a019de9e1;
		}
		set
		{
			x71c6d753219cc1b7();
			x5c3b7d4a019de9e1 = value;
		}
	}

	internal x26d9ecb4bdf0456d x83729c7ebf48ae24
	{
		get
		{
			return xe5cc466041b3bc40;
		}
		set
		{
			x71c6d753219cc1b7();
			xe5cc466041b3bc40 = value;
		}
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (!x39f156868f37b760(obj))
		{
			return false;
		}
		x5709acc7200773ff x5709acc7200773ff2 = (x5709acc7200773ff)obj;
		return object.Equals(x8fdbd80e8da6b0e6, x5709acc7200773ff2.x8fdbd80e8da6b0e6) && object.Equals(x83729c7ebf48ae24, x5709acc7200773ff2.x83729c7ebf48ae24) && object.Equals(x7b6a6d281546db99, x5709acc7200773ff2.x7b6a6d281546db99);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	protected override void AddKeysToHashCode()
	{
		xd94964d84c426258(x8fdbd80e8da6b0e6);
		xd94964d84c426258(x83729c7ebf48ae24);
		xd94964d84c426258(x7b6a6d281546db99);
	}

	internal static x5709acc7200773ff x38758cbbee49e4cb(x5709acc7200773ff x50a18ad2656e7181)
	{
		if (x50a18ad2656e7181 == null)
		{
			x50a18ad2656e7181 = new x5709acc7200773ff(null, initKey: true);
		}
		if (x50a18ad2656e7181.x17dcbf5fe3c0d2d2 == null)
		{
			return x50a18ad2656e7181;
		}
		if (x50a18ad2656e7181.xe76bdd563aa52beb)
		{
			return x50a18ad2656e7181;
		}
		x5709acc7200773ff x5709acc7200773ff2 = (x5709acc7200773ff)x50a18ad2656e7181.x17dcbf5fe3c0d2d2.x18f61487b906e15c[x50a18ad2656e7181];
		if (x5709acc7200773ff2 == null)
		{
			x50a18ad2656e7181.x17dcbf5fe3c0d2d2.x18f61487b906e15c.Add(x50a18ad2656e7181, x5709acc7200773ff2 = x50a18ad2656e7181);
		}
		return x5709acc7200773ff2;
	}

	internal static x5709acc7200773ff xdb83cd4968ca9d31(x5709acc7200773ff x50a18ad2656e7181)
	{
		if (x50a18ad2656e7181 == null)
		{
			return new x5709acc7200773ff(null, initKey: true);
		}
		x5709acc7200773ff x5709acc7200773ff2 = new x5709acc7200773ff(x50a18ad2656e7181.x17dcbf5fe3c0d2d2, initKey: false);
		x5709acc7200773ff2.x8fdbd80e8da6b0e6 = x50a18ad2656e7181.x8fdbd80e8da6b0e6;
		x5709acc7200773ff2.x83729c7ebf48ae24 = x50a18ad2656e7181.x83729c7ebf48ae24;
		x5709acc7200773ff2.x7b6a6d281546db99 = x50a18ad2656e7181.x7b6a6d281546db99;
		return x5709acc7200773ff2;
	}

	internal x5709acc7200773ff(x17dcbf5fe3c0d2d2 context, bool initKey)
		: base(context)
	{
		if (initKey)
		{
			GetHashCode();
		}
	}

	private static x5709acc7200773ff x38758cbbee49e4cb(x17dcbf5fe3c0d2d2 x0f7b23d1c393aed9, x26d9ecb4bdf0456d x93532ca0ace0c1ae, x26d9ecb4bdf0456d x154083d58301ef75, TextureIndex x29d5ed4aec3de9b7)
	{
		x5709acc7200773ff x5709acc7200773ff2 = new x5709acc7200773ff(x0f7b23d1c393aed9, initKey: false);
		x5709acc7200773ff2.x8fdbd80e8da6b0e6 = x93532ca0ace0c1ae;
		x5709acc7200773ff2.x83729c7ebf48ae24 = x154083d58301ef75;
		x5709acc7200773ff2.x7b6a6d281546db99 = x29d5ed4aec3de9b7;
		return x38758cbbee49e4cb(x5709acc7200773ff2);
	}

	static x5709acc7200773ff()
	{
		x45260ad4b94166f2 = x38758cbbee49e4cb(null, x26d9ecb4bdf0456d.x45260ad4b94166f2, x26d9ecb4bdf0456d.x45260ad4b94166f2, TextureIndex.TextureNone);
		x45260ad4b94166f2.GetHashCode();
	}
}
