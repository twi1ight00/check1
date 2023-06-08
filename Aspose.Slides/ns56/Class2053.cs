using System.Xml;

namespace ns56;

internal abstract class Class2053 : Class1351
{
	public delegate Class2053 Delegate1882();

	public delegate void Delegate1883(Class2053 elementData);

	public delegate void Delegate1884(Class2053 elementData);

	public Class2339.Delegate2763 delegate2763_0;

	internal Class2339.Delegate2764 delegate2764_0;

	public Class2059.Delegate1889 delegate1889_0;

	internal Class2059.Delegate1891 delegate1891_0;

	public Class2059.Delegate1889 delegate1889_1;

	internal Class2059.Delegate1891 delegate1891_1;

	public Class2128.Delegate2115 delegate2115_0;

	internal Class2128.Delegate2117 delegate2117_0;

	public Class2097.Delegate2009 delegate2009_0;

	internal Class2097.Delegate2011 delegate2011_0;

	public Class2126.Delegate2109 delegate2109_0;

	internal Class2126.Delegate2111 delegate2111_0;

	public Class2126.Delegate2109 delegate2109_1;

	internal Class2126.Delegate2111 delegate2111_1;

	public Class2125.Delegate2106 delegate2106_0;

	internal Class2125.Delegate2108 delegate2108_0;

	public Class1921.Delegate1630 delegate1630_0;

	internal Class1921.Delegate1632 delegate1632_0;

	public Class1946.Delegate1705 delegate1705_0;

	internal Class1946.Delegate1707 delegate1707_0;

	public Class2605.Delegate2773 delegate2773_0;

	public Class2339.Delegate2763 delegate2763_1;

	public Class2339.Delegate2764 delegate2764_1;

	public Class2083.Delegate1964 delegate1964_0;

	public Class2083.Delegate1966 delegate1966_0;

	public Class2084.Delegate1967 delegate1967_0;

	public Class2084.Delegate1969 delegate1969_0;

	public Class2117.Delegate2078 delegate2078_0;

	internal Class2117.Delegate2080 delegate2080_0;

	public Class2117.Delegate2078 delegate2078_1;

	internal Class2117.Delegate2080 delegate2080_1;

	public Class2339.Delegate2763 delegate2763_2;

	public Class2339.Delegate2764 delegate2764_2;

	internal Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2127.Delegate2112 delegate2112_0;

	public Class2127.Delegate2114 delegate2114_0;

	public Class2047.Delegate1859 delegate1859_0;

	public Class2047.Delegate1861 delegate1861_0;

	public Class2127.Delegate2112 delegate2112_1;

	public Class2127.Delegate2114 delegate2114_1;

	public Class2047.Delegate1859 delegate1859_1;

	public Class2047.Delegate1861 delegate1861_1;

	public Class2127.Delegate2112 delegate2112_2;

	public Class2127.Delegate2114 delegate2114_2;

	public Class2060.Delegate1892 delegate1892_0;

	internal Class2060.Delegate1894 delegate1894_0;

	public Class2065.Delegate1908 delegate1908_0;

	internal Class2065.Delegate1910 delegate1910_0;

	public abstract Class1774 AxId { get; }

	public abstract Class2111 Scaling { get; }

	public abstract Class2339 Delete { get; }

	public abstract Class2048 AxPos { get; }

	public abstract Class2059 MajorGridlines { get; }

	public abstract Class2059 MinorGridlines { get; }

	public abstract Class2128 Title { get; }

	public abstract Class2097 NumFmt { get; }

	public abstract Class2126 MajorTickMark { get; }

	public abstract Class2126 MinorTickMark { get; }

	public abstract Class2125 TickLblPos { get; }

	public abstract Class1921 SpPr { get; }

	public abstract Class1946 TxPr { get; }

	public abstract Class1774 CrossAx { get; }

	public abstract Class2605 Crossing { get; set; }

	public virtual Class2339 Auto => null;

	public virtual Class2083 LblAlgn => null;

	public virtual Class2084 LblOffset => null;

	public virtual Class2117 TickLblSkip => null;

	public virtual Class2117 TickMarkSkip => null;

	public virtual Class2339 NoMultiLvlLbl => null;

	public abstract Class1885 ExtLst { get; }

	public virtual Class2127 BaseTimeUnit => null;

	public virtual Class2047 MajorUnit => null;

	public virtual Class2127 MajorTimeUnit => null;

	public virtual Class2047 MinorUnit => null;

	public virtual Class2127 MinorTimeUnit => null;

	public virtual Class2060 CrossBetween => null;

	public virtual Class2065 DispUnits => null;

	internal Class2053(XmlReader reader)
		: base(reader)
	{
	}

	internal Class2053()
	{
	}
}
