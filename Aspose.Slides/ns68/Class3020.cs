using System;
using System.Drawing;

namespace ns68;

internal sealed class Class3020
{
	private Class3019 class3019_0;

	public Class3020(Class3019 normalizedBackBuffer)
	{
		class3019_0 = normalizedBackBuffer;
	}

	public bool method_0(ref int x, ref int y, ref short edgeIndex, Enum457 neighbourBorderType)
	{
		Class3016 floodFillerCache = class3019_0.FloodFillerCache;
		Class2998 currentContour = class3019_0.FloodFillerCache.CurrentContour;
		int count = currentContour.Count;
		if (class3019_0.Pixels[x, y].bool_2)
		{
			return false;
		}
		if (floodFillerCache.CurrentEdgeCachedData.bool_0 && !method_5())
		{
			return false;
		}
		short edgeID = currentContour[(count + edgeIndex - 1) % count].EdgeID;
		if (class3019_0.Pixels[x, y].short_0 == edgeID)
		{
			return false;
		}
		short edgeID2 = currentContour[(edgeIndex + 1) % count].EdgeID;
		if (class3019_0.Pixels[x, y].short_0 == edgeID2)
		{
			return false;
		}
		if (!method_3(x, y))
		{
			return false;
		}
		if (!method_1(x, y, edgeIndex, edgeID, edgeID2, neighbourBorderType))
		{
			return false;
		}
		return true;
	}

	private bool method_1(int x, int y, short edgeIndex, short prevAllEdgeIndex, short nextAllEdgeIndex, Enum457 neighbourBorderType)
	{
		Class3016 floodFillerCache = class3019_0.FloodFillerCache;
		int num = -10;
		bool subResultNotBorder4And = true;
		int num2 = 0;
		while (true)
		{
			if (num2 < 2)
			{
				if (num2 == 0)
				{
					if (neighbourBorderType != Enum457.const_2 && neighbourBorderType != Enum457.const_1)
					{
						goto IL_0052;
					}
					floodFillerCache.NeigbourEdgeCachedData = floodFillerCache.NextEdgeCachedData;
				}
				if (num2 == 1)
				{
					if (neighbourBorderType != Enum457.const_2 && neighbourBorderType != 0)
					{
						goto IL_0052;
					}
					floodFillerCache.NeigbourEdgeCachedData = floodFillerCache.PrevEdgeCachedData;
				}
				method_2(ref subResultNotBorder4And);
				if (!subResultNotBorder4And)
				{
					break;
				}
				goto IL_0052;
			}
			return subResultNotBorder4And;
			IL_0052:
			num2++;
		}
		if (num2 == 1 && class3019_0.Pixels[x, y].short_0 != num && class3019_0.Pixels[x, y].short_0 != prevAllEdgeIndex)
		{
			method_6(x, y);
		}
		if (num2 == 1 && class3019_0.Pixels[x, y].short_0 != num && floodFillerCache.PrevEdgeCachedData.int_0 == 1)
		{
			floodFillerCache.CurrentContour[edgeIndex].Step1BuilderCache.FlagToRefillBecauseOfBlameBorderChained = true;
		}
		return false;
	}

	private void method_2(ref bool subResultNotBorder4And5)
	{
		Class3016 floodFillerCache = class3019_0.FloodFillerCache;
		switch (floodFillerCache.NeigbourEdgeCachedData.int_0)
		{
		case 1:
		{
			double num4 = floodFillerCache.NeigbourEdgeCachedData.double_6 * floodFillerCache.NeigbourEdgeCachedData.double_4 + floodFillerCache.NeigbourEdgeCachedData.double_7 * floodFillerCache.NeigbourEdgeCachedData.double_5;
			subResultNotBorder4And5 = subResultNotBorder4And5 && floodFillerCache.CurrentEdgeCachedData.double_17 <= num4;
			break;
		}
		case 2:
			if (floodFillerCache.CurrentEdgeCachedData.sbyte_0 <= 0 && floodFillerCache.NeigbourEdgeCachedData.sbyte_0 > 0)
			{
				subResultNotBorder4And5 = subResultNotBorder4And5;
			}
			else if (floodFillerCache.CurrentEdgeCachedData.sbyte_0 > 0 && floodFillerCache.NeigbourEdgeCachedData.sbyte_0 > 0)
			{
				double num3 = floodFillerCache.NeigbourEdgeCachedData.double_6 * floodFillerCache.NeigbourEdgeCachedData.double_4 + floodFillerCache.NeigbourEdgeCachedData.double_7 * floodFillerCache.NeigbourEdgeCachedData.double_5;
				subResultNotBorder4And5 = subResultNotBorder4And5 && floodFillerCache.CurrentEdgeCachedData.double_17 > num3;
			}
			else if (floodFillerCache.CurrentEdgeCachedData.sbyte_0 > 0 && floodFillerCache.NeigbourEdgeCachedData.sbyte_0 <= 0)
			{
				subResultNotBorder4And5 = false;
			}
			else if (floodFillerCache.CurrentEdgeCachedData.sbyte_0 <= 0 && floodFillerCache.NeigbourEdgeCachedData.sbyte_0 <= 0)
			{
				subResultNotBorder4And5 = false;
			}
			break;
		case 3:
			if (floodFillerCache.CurrentEdgeCachedData.sbyte_0 <= 0)
			{
				subResultNotBorder4And5 = subResultNotBorder4And5;
			}
			if (floodFillerCache.CurrentEdgeCachedData.sbyte_0 >= 0 && floodFillerCache.NeigbourEdgeCachedData.sbyte_0 >= 0)
			{
				double num = floodFillerCache.NeigbourEdgeCachedData.double_6 * floodFillerCache.NeigbourEdgeCachedData.double_4 + floodFillerCache.NeigbourEdgeCachedData.double_7 * floodFillerCache.NeigbourEdgeCachedData.double_5;
				subResultNotBorder4And5 = subResultNotBorder4And5 && floodFillerCache.CurrentEdgeCachedData.double_17 >= num;
			}
			if (floodFillerCache.CurrentEdgeCachedData.sbyte_0 >= 0 && floodFillerCache.NeigbourEdgeCachedData.sbyte_0 <= 0)
			{
				double num2 = floodFillerCache.NeigbourEdgeCachedData.double_6 * floodFillerCache.NeigbourEdgeCachedData.double_4 + floodFillerCache.NeigbourEdgeCachedData.double_7 * floodFillerCache.NeigbourEdgeCachedData.double_5;
				subResultNotBorder4And5 = subResultNotBorder4And5 && floodFillerCache.CurrentEdgeCachedData.double_17 > num2;
			}
			break;
		}
	}

	private bool method_3(int x, int y)
	{
		Class3016 floodFillerCache = class3019_0.FloodFillerCache;
		bool flag;
		if (class3019_0.Pixels[x, y].short_0 != -10)
		{
			if (class3019_0.Pixels[x, y].short_0 == floodFillerCache.CurrentEdgeCachedData.short_0)
			{
				flag = true;
			}
			else
			{
				Class2994 @class = class3019_0.StructuralEdges[floodFillerCache.CurrentEdgeCachedData.short_0];
				Class2994 class2 = class3019_0.StructuralEdges[class3019_0.Pixels[x, y].short_0];
				double num = @class.AB.X * class2.BA.Y - @class.AB.Y * class2.BA.X;
				flag = ((!method_4(@class, class2) || !(num > 0.0)) ? (floodFillerCache.CurrentEdgeCachedData.double_17 <= class3019_0.Pixels[x, y].double_0) : ((@class.Contour != class2.Contour) ? true : false));
				if (!flag)
				{
					if (class3019_0.Pixels[x, y].bool_3)
					{
						class3019_0.Pixels[x, y].bool_3 = false;
						class3019_0.FloodFiller.StopOnBlameBorderCounter[class3019_0.Pixels[x, y].short_0]++;
					}
					method_6(x, y);
				}
			}
		}
		else
		{
			flag = true;
		}
		return flag;
	}

	private bool method_4(Class2994 rayCurrBA, Class2994 rayFarPrevAB)
	{
		double num = rayCurrBA.AB.X * rayFarPrevAB.AB.Y - rayCurrBA.AB.Y * rayFarPrevAB.AB.X;
		double num2 = (rayCurrBA.B.X - rayFarPrevAB.A.X) * rayFarPrevAB.AB.Y - (rayCurrBA.B.Y - rayFarPrevAB.A.Y) * rayFarPrevAB.AB.X;
		double num3 = rayCurrBA.AB.X * (rayCurrBA.B.Y - rayFarPrevAB.A.Y) - rayCurrBA.AB.Y * (rayCurrBA.B.X - rayFarPrevAB.A.X);
		if (Math.Abs(num) < 1E-07)
		{
			return false;
		}
		double num4 = num2 / num;
		double num5 = num3 / num;
		if (0.0 <= num5 && 0.0 <= num4)
		{
			return true;
		}
		return false;
	}

	private bool method_5()
	{
		Class3016 floodFillerCache = class3019_0.FloodFillerCache;
		return floodFillerCache.CurrentEdgeCachedData.double_10 * floodFillerCache.CurrentEdgeCachedData.double_6 + floodFillerCache.CurrentEdgeCachedData.double_11 * floodFillerCache.CurrentEdgeCachedData.double_7 > 0.0;
	}

	private void method_6(int x, int y)
	{
		class3019_0.CrossesList.Add(new Point(x - 1, y - 1));
		class3019_0.CrossesList.Add(new Point(x, y - 1));
		class3019_0.CrossesList.Add(new Point(x - 1, y));
		class3019_0.CrossesList.Add(new Point(x, y));
	}
}
