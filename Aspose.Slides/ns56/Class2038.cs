using System.Xml;

namespace ns56;

internal abstract class Class2038 : Class1351
{
	internal delegate Class2038 Delegate1856();

	internal delegate void Delegate1857(Class2038 elementData);

	public Class1921.Delegate1630 delegate1630_0;

	internal Class1921.Delegate1632 delegate1632_0;

	internal Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2114.Delegate2069 delegate2069_0;

	internal Class2114.Delegate2071 delegate2071_0;

	public Class2341.Delegate2765 delegate2765_0;

	internal Class2341.Delegate2766 delegate2766_0;

	public Class2342.Delegate2767 delegate2767_0;

	internal Class2342.Delegate2768 delegate2768_0;

	public Class2341.Delegate2765 delegate2765_1;

	internal Class2341.Delegate2766 delegate2766_1;

	public Class2342.Delegate2767 delegate2767_1;

	internal Class2342.Delegate2768 delegate2768_1;

	public Class2342.Delegate2767 delegate2767_2;

	internal Class2342.Delegate2768 delegate2768_2;

	public Class2091.Delegate1991 delegate1991_0;

	internal Class2091.Delegate1993 delegate1993_0;

	public Class2339.Delegate2763 delegate2763_0;

	internal Class2339.Delegate2764 delegate2764_0;

	public Class2069.Delegate1920 delegate1920_0;

	internal Class2069.Delegate1922 delegate1922_0;

	public Class2071.Delegate1927 delegate1927_0;

	public Class2129.Delegate2118 delegate2118_0;

	internal Class1449.Delegate383 delegate383_0;

	public Class1449.Delegate384 delegate384_0;

	public Class2073.Delegate1933 delegate1933_0;

	public Class2073.Delegate1935 delegate1935_0;

	public Class2339.Delegate2763 delegate2763_1;

	internal Class2339.Delegate2764 delegate2764_1;

	public Class2135.Delegate2136 delegate2136_0;

	internal Class2135.Delegate2138 delegate2138_0;

	public Class2115.Delegate2072 delegate2072_0;

	internal Class2115.Delegate2074 delegate2074_0;

	public Class2339.Delegate2763 delegate2763_2;

	internal Class2339.Delegate2764 delegate2764_2;

	public abstract Class2135 Idx { get; }

	public abstract Class2135 Order { get; }

	public abstract Class1921 SpPr { get; }

	public abstract Class1885 ExtLst { get; }

	public abstract Class2114 Tx { get; }

	public virtual Class2341 Cat => null;

	public virtual Class2342 Val => null;

	public virtual Class2341 XVal => null;

	public virtual Class2342 YVal => null;

	public virtual Class2342 BubbleSize => null;

	public virtual Class2091 Marker => null;

	public virtual Class2339 Smooth => null;

	public virtual Class2069 DLbls => null;

	public virtual Class2071[] DPtList => null;

	public virtual Class2129[] TrendlineList => null;

	public virtual Class1453 PictureOptions => null;

	public virtual Class2073[] ErrBarsList => null;

	public virtual Class2073 ErrBars => null;

	public virtual Class2339 InvertIfNegative => null;

	public virtual Class2135 Explosion => null;

	public virtual Class2115 Shape => null;

	public virtual Class2339 Bubble3D => null;

	internal Class2038(XmlReader reader)
		: base(reader)
	{
	}

	internal Class2038()
	{
	}
}
