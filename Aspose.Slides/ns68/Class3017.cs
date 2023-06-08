using System.Drawing;

namespace ns68;

internal sealed class Class3017
{
	private Class3018 class3018_0;

	private Class3019 class3019_0;

	private int[] int_0;

	public int[] StopOnBlameBorderCounter => int_0;

	public Class3017(Class3019 normalizedBackBuffer)
	{
		class3019_0 = normalizedBackBuffer;
	}

	internal void method_0(Point startFillPoint, short edgeIndex, bool fillAsFirst, bool reFilling, Enum457 neighbourBorderType)
	{
		Struct156[,] pixels = class3019_0.Pixels;
		Class3016 floodFillerCache = class3019_0.FloodFillerCache;
		Class3020 pixelChecker = class3019_0.PixelChecker;
		int currX = startFillPoint.X;
		int currY = startFillPoint.Y;
		int_0 = new int[class3019_0.StructuralEdges.Count];
		int_0.Initialize();
		floodFillerCache.method_0(edgeIndex, fillAsFirst, reFilling);
		floodFillerCache.method_1(ref currX, ref currY);
		class3018_0 = new Class3018((class3019_0.Width + class3019_0.Height) / 2 * 5);
		method_1(ref currX, ref currY, ref edgeIndex, neighbourBorderType);
		while (class3018_0.Count > 0)
		{
			Struct155 @struct = class3018_0.method_1();
			int currY2 = @struct.int_2 - 1;
			int currY3 = @struct.int_2 + 1;
			for (int i = @struct.int_0; i <= @struct.int_1; i++)
			{
				if (@struct.int_2 > 0)
				{
					floodFillerCache.method_1(ref i, ref currY2);
					if (pixels[i, currY2].short_1 != floodFillerCache.CurrentEdgeCachedData.short_0)
					{
						if (pixelChecker.method_0(ref i, ref currY2, ref edgeIndex, neighbourBorderType))
						{
							method_1(ref i, ref currY2, ref edgeIndex, neighbourBorderType);
						}
						else
						{
							pixels[i, currY2 + 1].bool_3 = false;
						}
					}
				}
				if (@struct.int_2 >= class3019_0.Height - 1)
				{
					continue;
				}
				floodFillerCache.method_1(ref i, ref currY3);
				if (pixels[i, currY3].short_1 != floodFillerCache.CurrentEdgeCachedData.short_0)
				{
					if (pixelChecker.method_0(ref i, ref currY3, ref edgeIndex, neighbourBorderType))
					{
						method_1(ref i, ref currY3, ref edgeIndex, neighbourBorderType);
					}
					else
					{
						pixels[i, currY3 - 1].bool_3 = false;
					}
				}
			}
		}
		for (int j = 0; j < StopOnBlameBorderCounter.Length; j++)
		{
			if (StopOnBlameBorderCounter[j] > 2)
			{
				class3019_0.StructuralEdges[j].Step1BuilderCache.FlagToRefillBecauseOfBlameBorderChained = true;
			}
		}
	}

	private void method_1(ref int x, ref int y, ref short edgeIndex, Enum457 neighbourBorderType)
	{
		Struct156[,] pixels = class3019_0.Pixels;
		Class3016 floodFillerCache = class3019_0.FloodFillerCache;
		Class3020 pixelChecker = class3019_0.PixelChecker;
		int num = x;
		int currX = x;
		while (true)
		{
			pixels[currX, y].short_0 = floodFillerCache.CurrentEdgeCachedData.short_0;
			pixels[currX, y].double_0 = floodFillerCache.CurrentEdgeCachedData.double_17;
			pixels[currX, y].sbyte_0 = floodFillerCache.CurrentEdgeCachedData.sbyte_0;
			pixels[currX, y].bool_3 = false;
			pixels[currX, y].short_1 = floodFillerCache.CurrentEdgeCachedData.short_0;
			pixels[currX, y].bool_0 = floodFillerCache.CurrentEdgeCachedData.bool_0 || pixels[currX, y].bool_0;
			num--;
			if (num < 0)
			{
				break;
			}
			currX--;
			floodFillerCache.method_2(ref currX);
			if (pixels[currX, y].short_1 == floodFillerCache.CurrentEdgeCachedData.short_0)
			{
				break;
			}
			if (!pixelChecker.method_0(ref currX, ref y, ref edgeIndex, neighbourBorderType))
			{
				pixels[currX + 1, y].bool_3 = false;
				break;
			}
		}
		num++;
		int num2 = x;
		currX = x;
		while (true)
		{
			num2++;
			if (num2 >= class3019_0.Width)
			{
				break;
			}
			currX++;
			floodFillerCache.method_2(ref currX);
			if (pixels[currX, y].short_1 == floodFillerCache.CurrentEdgeCachedData.short_0)
			{
				break;
			}
			if (pixelChecker.method_0(ref currX, ref y, ref edgeIndex, neighbourBorderType))
			{
				pixels[currX, y].short_0 = floodFillerCache.CurrentEdgeCachedData.short_0;
				pixels[currX, y].double_0 = floodFillerCache.CurrentEdgeCachedData.double_17;
				pixels[currX, y].sbyte_0 = floodFillerCache.CurrentEdgeCachedData.sbyte_0;
				pixels[currX, y].bool_3 = false;
				pixels[currX, y].short_1 = floodFillerCache.CurrentEdgeCachedData.short_0;
				pixels[currX, y].bool_0 = floodFillerCache.CurrentEdgeCachedData.bool_0 || pixels[currX, y].bool_0;
				continue;
			}
			pixels[currX - 1, y].bool_3 = false;
			break;
		}
		num2--;
		Struct155 r = new Struct155(num, num2, y);
		class3018_0.method_0(ref r);
	}
}
