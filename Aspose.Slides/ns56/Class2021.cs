using System;
using System.Collections.Generic;
using System.Xml;
using Aspose.Slides.Charts;

namespace ns56;

internal abstract class Class2021 : Class1351
{
	internal delegate Class2021 Delegate1852();

	internal delegate void Delegate1853(Class2021 elementData);

	internal Class2038.Delegate1856 delegate1856_0;

	public Class1774.Delegate1201 delegate1201_0;

	internal Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2069.Delegate1920 delegate1920_0;

	internal Class2069.Delegate1922 delegate1922_0;

	public Class2137.Delegate2142 delegate2142_0;

	internal Class2137.Delegate2144 delegate2144_0;

	public Class2339.Delegate2763 delegate2763_0;

	internal Class2339.Delegate2764 delegate2764_0;

	public Class2076.Delegate1943 delegate1943_0;

	internal Class2076.Delegate1945 delegate1945_0;

	public Class2076.Delegate1943 delegate1943_1;

	internal Class2076.Delegate1945 delegate1945_1;

	public Class2103.Delegate2028 delegate2028_0;

	internal Class2103.Delegate2030 delegate2030_0;

	public Class2059.Delegate1889 delegate1889_0;

	internal Class2059.Delegate1891 delegate1891_0;

	public Class2059.Delegate1889 delegate1889_1;

	internal Class2059.Delegate1891 delegate1891_1;

	public Class2075.Delegate1940 delegate1940_0;

	internal Class2075.Delegate1942 delegate1942_0;

	public Class2078.Delegate1949 delegate1949_0;

	internal Class2078.Delegate1951 delegate1951_0;

	public Class2113.Delegate2065 delegate2065_0;

	internal Class2113.Delegate2067 delegate2067_0;

	public Class2059.Delegate1889 delegate1889_2;

	public Class2339.Delegate2763 delegate2763_1;

	internal Class2339.Delegate2764 delegate2764_1;

	public Class2116.Delegate2075 delegate2075_0;

	internal Class2116.Delegate2077 delegate2077_0;

	public Class2070.Delegate1923 delegate1923_0;

	internal Class2070.Delegate1925 delegate1925_0;

	public Class2118.Delegate2081 delegate2081_0;

	internal Class2118.Delegate2083 delegate2083_0;

	public Class2339.Delegate2763 delegate2763_2;

	internal Class2339.Delegate2764 delegate2764_2;

	public Class2051.Delegate1875 delegate1875_0;

	internal Class2051.Delegate1877 delegate1877_0;

	internal Class2339.Delegate2763 delegate2763_3;

	internal Class2339.Delegate2764 delegate2764_3;

	public Class2062.Delegate1898 delegate1898_0;

	internal Class2062.Delegate1900 delegate1900_0;

	internal Class1447.Delegate303 delegate303_0;

	public Class1447.Delegate304 delegate304_0;

	public Class2115.Delegate2072 delegate2072_0;

	public Class2115.Delegate2074 delegate2074_0;

	internal Class2339.Delegate2763 delegate2763_4;

	public Class2339.Delegate2764 delegate2764_4;

	internal Class2339.Delegate2763 delegate2763_5;

	public Class2339.Delegate2764 delegate2764_5;

	public virtual Class2049 BarDir => null;

	public abstract Class2038[] SerList { get; }

	public virtual Class1774[] AxIdList
	{
		get
		{
			List<Class1774> list = new List<Class1774>();
			if (AxId1 != null)
			{
				list.Add(AxId1);
				if (AxId2 != null)
				{
					list.Add(AxId2);
					if (AxId3 != null)
					{
						list.Add(AxId3);
					}
				}
			}
			return list.ToArray();
		}
	}

	public virtual Class1774 AxId1 => null;

	public virtual Class1774 AxId2 => null;

	public virtual Class1774 AxId3 => null;

	public abstract Class1885 ExtLst { get; }

	public virtual Class2069 DLbls => null;

	public virtual Class2137 UpDownBars => null;

	public virtual Class2100 OfPieType => null;

	public virtual Class2107 RadarStyle => null;

	public virtual Class2339 VaryColors => null;

	public virtual Class2076 GapDepth => null;

	public virtual Class2076 GapWidth => null;

	public virtual Class2103 Overlap => null;

	public virtual Class2059 DropLines => null;

	public virtual Class2059 HiLowLines => null;

	public virtual Class2075 FirstSliceAng => null;

	public virtual Class2078 HoleSize => null;

	public virtual Class2113 SecondPieSize => null;

	public virtual Class2059[] SerLinesList => null;

	public virtual Class2339 ShowNegBubbles => null;

	public virtual Class2116 SizeRepresents => null;

	public virtual Class2070 SplitPos => null;

	public virtual Class2118 SplitType => null;

	public virtual Class2339 Wireframe => null;

	public virtual Class2051 BubbleScale => null;

	public virtual Class2339 Smooth => null;

	public virtual Class2062 CustSplit => null;

	public virtual Class1458 BandFmts => null;

	public virtual Class2112 ScatterStyle => null;

	public virtual Class2115 Shape => null;

	public virtual Class2339 Bubble3D => null;

	public virtual Class2339 Marker => null;

	internal Class2021(XmlReader reader)
		: base(reader)
	{
	}

	internal Class2021()
	{
	}

	public Class2038 method_2(ChartType seriesType)
	{
		if (this is Class2022)
		{
			switch (seriesType)
			{
			default:
				throw new Exception();
			case ChartType.Area3D:
			case ChartType.StackedArea3D:
			case ChartType.PercentsStackedArea3D:
				break;
			}
		}
		else if (this is Class2023)
		{
			switch (seriesType)
			{
			default:
				throw new Exception();
			case ChartType.Area:
			case ChartType.StackedArea:
			case ChartType.PercentsStackedArea:
				break;
			}
		}
		else if (this is Class2024)
		{
			switch (seriesType)
			{
			default:
				throw new Exception();
			case ChartType.ClusteredColumn3D:
			case ChartType.StackedColumn3D:
			case ChartType.PercentsStackedColumn3D:
			case ChartType.Column3D:
			case ChartType.ClusteredCylinder:
			case ChartType.StackedCylinder:
			case ChartType.PercentsStackedCylinder:
			case ChartType.Cylinder3D:
			case ChartType.ClusteredCone:
			case ChartType.StackedCone:
			case ChartType.PercentsStackedCone:
			case ChartType.Cone3D:
			case ChartType.ClusteredPyramid:
			case ChartType.StackedPyramid:
			case ChartType.PercentsStackedPyramid:
			case ChartType.Pyramid3D:
			case ChartType.ClusteredBar3D:
			case ChartType.StackedBar3D:
			case ChartType.PercentsStackedBar3D:
			case ChartType.ClusteredHorizontalCylinder:
			case ChartType.StackedHorizontalCylinder:
			case ChartType.PercentsStackedHorizontalCylinder:
			case ChartType.ClusteredHorizontalCone:
			case ChartType.StackedHorizontalCone:
			case ChartType.PercentsStackedHorizontalCone:
			case ChartType.ClusteredHorizontalPyramid:
			case ChartType.StackedHorizontalPyramid:
			case ChartType.PercentsStackedHorizontalPyramid:
				break;
			}
		}
		else if (this is Class2025)
		{
			switch (seriesType)
			{
			default:
				throw new Exception();
			case ChartType.ClusteredColumn:
			case ChartType.StackedColumn:
			case ChartType.PercentsStackedColumn:
			case ChartType.PercentsStackedBar:
			case ChartType.ClusteredBar:
			case ChartType.StackedBar:
				break;
			}
		}
		else if (this is Class2026)
		{
			switch (seriesType)
			{
			default:
				throw new Exception();
			case ChartType.Bubble:
			case ChartType.BubbleWith3D:
				break;
			}
		}
		else if (this is Class2027)
		{
			switch (seriesType)
			{
			default:
				throw new Exception();
			case ChartType.Doughnut:
			case ChartType.ExplodedDoughnut:
				break;
			}
		}
		else if (this is Class2028)
		{
			if (seriesType != ChartType.Line3D)
			{
				throw new Exception();
			}
		}
		else if (this is Class2029)
		{
			switch (seriesType)
			{
			default:
				throw new Exception();
			case ChartType.Line:
			case ChartType.StackedLine:
			case ChartType.PercentsStackedLine:
			case ChartType.LineWithMarkers:
			case ChartType.StackedLineWithMarkers:
			case ChartType.PercentsStackedLineWithMarkers:
				break;
			}
		}
		else if (this is Class2030)
		{
			if (seriesType != ChartType.PieOfPie && seriesType != ChartType.BarOfPie)
			{
				throw new Exception();
			}
		}
		else if (this is Class2031)
		{
			if (seriesType != ChartType.Pie3D && seriesType != ChartType.ExplodedPie3D)
			{
				throw new Exception();
			}
		}
		else if (this is Class2032)
		{
			if (seriesType != ChartType.Pie && seriesType != ChartType.ExplodedPie)
			{
				throw new Exception();
			}
		}
		else if (this is Class2033)
		{
			switch (seriesType)
			{
			default:
				throw new Exception();
			case ChartType.Radar:
			case ChartType.RadarWithMarkers:
			case ChartType.FilledRadar:
				break;
			}
		}
		else if (this is Class2034)
		{
			switch (seriesType)
			{
			default:
				throw new Exception();
			case ChartType.ScatterWithMarkers:
			case ChartType.ScatterWithSmoothLinesAndMarkers:
			case ChartType.ScatterWithSmoothLines:
			case ChartType.ScatterWithStraightLinesAndMarkers:
			case ChartType.ScatterWithStraightLines:
				break;
			}
		}
		else if (this is Class2035)
		{
			switch (seriesType)
			{
			default:
				throw new Exception();
			case ChartType.HighLowClose:
			case ChartType.OpenHighLowClose:
			case ChartType.VolumeHighLowClose:
			case ChartType.VolumeOpenHighLowClose:
				break;
			}
		}
		else if (this is Class2036)
		{
			switch (seriesType)
			{
			default:
				throw new Exception();
			case ChartType.Surface3D:
			case ChartType.WireframeSurface3D:
				break;
			}
		}
		else
		{
			if (!(this is Class2037))
			{
				throw new Exception();
			}
			switch (seriesType)
			{
			default:
				throw new Exception();
			case ChartType.Contour:
			case ChartType.WireframeContour:
				break;
			}
		}
		return delegate1856_0();
	}
}
