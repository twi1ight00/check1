using System.Drawing.Drawing2D;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x4f4df92b75ba3b67;

internal abstract class x02cd5c9c8d54330e : x4d8917c8186e8cb2
{
	protected xe21bbe9dfab6c4dd x2107de3fc2a21893;

	protected xa3d3e9bf30ebb072 xdb55316cd005e09a;

	private readonly x54366fa5f75a02f7 x2421cb0c8da5f8ef;

	protected abstract int PatternType { get; }

	protected abstract x54366fa5f75a02f7 BrushTransform { get; }

	internal override x3499f937de5622bc x41c71fb0a8629935 => x3499f937de5622bc.xd265a220a45d3124;

	internal x02cd5c9c8d54330e(x4882ae789be6e2ef context)
		: base(context)
	{
		x2107de3fc2a21893 = new xe21bbe9dfab6c4dd(context);
		xdb55316cd005e09a = new xa3d3e9bf30ebb072(x8cedcaa9a62c6e39, x2107de3fc2a21893, this);
		x2421cb0c8da5f8ef = x8cedcaa9a62c6e39.x147e079aca56accb.xb6d990994f0cea33.x33bbb6b1ad2a7b2e.x8b61531c8ea35b85();
	}

	internal override void x0a2e1f2c2da67e52(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Type", "/Pattern");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/PatternType", PatternType);
	}

	internal static x02cd5c9c8d54330e xa934c26af07952ed(x845d6a068e0b03c5 xd8f1949f8950238a, x4882ae789be6e2ef x0f7b23d1c393aed9)
	{
		return xd8f1949f8950238a.x4bc21f84846f912d switch
		{
			x0b257a9fb413b6c3.x7b6a6d281546db99 => new x20a936294adb09c3(x0f7b23d1c393aed9, (x5e9754e56a4f759f)xd8f1949f8950238a), 
			x0b257a9fb413b6c3.x1b1f1b9a5f55b7ee => new x1fce14d9a9493f27(x0f7b23d1c393aed9, (x5bdb4ba66c23277c)xd8f1949f8950238a), 
			x0b257a9fb413b6c3.x37b6ad6b01d0c641 => new x12723596215025ca(x0f7b23d1c393aed9, (x5f55370cc09dd787)xd8f1949f8950238a), 
			x0b257a9fb413b6c3.x73039d25e580af15 => new x20a936294adb09c3(x0f7b23d1c393aed9, x6fb77f4cc018ceba.xa903f8f328b4c169((xa587dcb499c221cc)xd8f1949f8950238a)), 
			_ => null, 
		};
	}

	protected void xcf7a6694b0b373cb(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		x54366fa5f75a02f7 x54366fa5f75a02f;
		if (BrushTransform == null)
		{
			float num = (float)x4574ea26106f0edb.xad2dd08366e0faf5(1.0);
			x54366fa5f75a02f = new x54366fa5f75a02f7(num, 0f, 0f, num, 0f, 0f);
		}
		else
		{
			x54366fa5f75a02f = BrushTransform.x8b61531c8ea35b85();
			x54366fa5f75a02f.x490e30087768649f(x2421cb0c8da5f8ef, MatrixOrder.Append);
		}
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Matrix", x54366fa5f75a02f);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
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
		if (!typeof(x02cd5c9c8d54330e).IsAssignableFrom(obj.GetType()))
		{
			return false;
		}
		return Equals((x02cd5c9c8d54330e)obj);
	}

	internal bool Equals(x02cd5c9c8d54330e other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		bool flag = PatternType == other.PatternType;
		if (!(flag & (x54366fa5f75a02f7.Equals(BrushTransform, other.BrushTransform) & other.x069d79629db23d6d(x2421cb0c8da5f8ef))))
		{
			return false;
		}
		return EqualsInternal(other);
	}

	protected virtual bool EqualsInternal(x02cd5c9c8d54330e other)
	{
		return false;
	}

	private bool x069d79629db23d6d(x54366fa5f75a02f7 xffbd571d7454e624)
	{
		return x54366fa5f75a02f7.Equals(xffbd571d7454e624, x2421cb0c8da5f8ef);
	}
}
