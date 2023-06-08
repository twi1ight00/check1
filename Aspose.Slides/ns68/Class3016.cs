using System;

namespace ns68;

internal sealed class Class3016
{
	private Class2998 class2998_0;

	private Class3019 class3019_0;

	private Struct153 struct153_0;

	private Struct154 struct154_0;

	private Struct154 struct154_1;

	private Struct154 struct154_2;

	public Class2998 CurrentContour
	{
		get
		{
			return class2998_0;
		}
		set
		{
			class2998_0 = value;
		}
	}

	public Struct153 CurrentEdgeCachedData => struct153_0;

	public Struct154 NextEdgeCachedData => struct154_1;

	public Struct154 NeigbourEdgeCachedData
	{
		get
		{
			return struct154_2;
		}
		set
		{
			struct154_2 = value;
		}
	}

	public Struct154 PrevEdgeCachedData => struct154_0;

	public Class3016(Class3019 normalizedBackBuffer)
	{
		class3019_0 = normalizedBackBuffer;
	}

	public void method_0(short edgeIndex, bool fillAsFirst, bool reFilling)
	{
		Class2989 normalizedBackBufferCoordinateSystem = class3019_0.NormalizedBackBufferCoordinateSystem;
		int count = CurrentContour.Count;
		struct153_0.int_1 = edgeIndex;
		struct153_0.short_0 = CurrentContour[edgeIndex].EdgeID;
		struct153_0.double_0 = normalizedBackBufferCoordinateSystem.method_3(CurrentContour[edgeIndex].A.X);
		struct153_0.double_1 = normalizedBackBufferCoordinateSystem.method_4(CurrentContour[edgeIndex].A.Y);
		struct153_0.double_2 = normalizedBackBufferCoordinateSystem.method_3(CurrentContour[edgeIndex].B.X);
		struct153_0.double_3 = normalizedBackBufferCoordinateSystem.method_4(CurrentContour[edgeIndex].B.Y);
		struct153_0.double_10 = CurrentEdgeCachedData.double_2 - CurrentEdgeCachedData.double_0;
		struct153_0.double_11 = CurrentEdgeCachedData.double_3 - CurrentEdgeCachedData.double_1;
		struct153_0.double_4 = CurrentContour[edgeIndex].InnerNormal.X;
		struct153_0.double_5 = CurrentContour[edgeIndex].InnerNormal.Y;
		struct153_0.bool_0 = fillAsFirst;
		struct153_0.bool_1 = reFilling;
		int i = (edgeIndex + 1) % count;
		struct154_1.double_0 = normalizedBackBufferCoordinateSystem.method_3(CurrentContour[i].A.X);
		struct154_1.double_1 = normalizedBackBufferCoordinateSystem.method_4(CurrentContour[i].A.Y);
		struct154_1.double_2 = normalizedBackBufferCoordinateSystem.method_3(CurrentContour[i].B.X);
		struct154_1.double_3 = normalizedBackBufferCoordinateSystem.method_4(CurrentContour[i].B.Y);
		struct154_1.double_4 = CurrentContour[i].InnerNormal.X;
		struct154_1.double_5 = CurrentContour[i].InnerNormal.Y;
		struct154_1.int_0 = CurrentContour[edgeIndex].Step1BuilderCache.BDegreesType;
		int i2 = (edgeIndex + count - 1) % count;
		struct154_0.double_0 = normalizedBackBufferCoordinateSystem.method_3(CurrentContour[i2].A.X);
		struct154_0.double_1 = normalizedBackBufferCoordinateSystem.method_4(CurrentContour[i2].A.Y);
		struct154_0.double_2 = normalizedBackBufferCoordinateSystem.method_3(CurrentContour[i2].B.X);
		struct154_0.double_3 = normalizedBackBufferCoordinateSystem.method_4(CurrentContour[i2].B.Y);
		struct154_0.double_4 = CurrentContour[i2].InnerNormal.X;
		struct154_0.double_5 = CurrentContour[i2].InnerNormal.Y;
		struct154_0.int_0 = CurrentContour[i2].Step1BuilderCache.BDegreesType;
	}

	public void method_1(ref int currX, ref int currY)
	{
		struct153_0.int_0 = currY;
		struct153_0.double_6 = (double)currX - CurrentEdgeCachedData.double_0;
		struct153_0.double_7 = (double)currY - CurrentEdgeCachedData.double_1;
		struct153_0.double_8 = (double)currX - CurrentEdgeCachedData.double_2;
		struct153_0.double_9 = (double)currY - CurrentEdgeCachedData.double_3;
		struct153_0.double_14 = CurrentEdgeCachedData.double_5 * CurrentEdgeCachedData.double_7;
		struct153_0.double_15 = CurrentEdgeCachedData.double_4 * CurrentEdgeCachedData.double_7;
		struct153_0.double_16 = CurrentEdgeCachedData.double_4 * CurrentEdgeCachedData.double_9;
		struct153_0.double_12 = CurrentEdgeCachedData.double_15 - CurrentEdgeCachedData.double_5 * CurrentEdgeCachedData.double_6;
		struct153_0.double_13 = CurrentEdgeCachedData.double_16 - CurrentEdgeCachedData.double_5 * CurrentEdgeCachedData.double_8;
		struct153_0.sbyte_0 = (sbyte)Math.Sign(CurrentEdgeCachedData.double_12 * CurrentEdgeCachedData.double_13);
		struct153_0.double_17 = CurrentEdgeCachedData.double_6 * CurrentEdgeCachedData.double_4 + CurrentEdgeCachedData.double_14;
		struct154_1.double_6 = (double)currX - NextEdgeCachedData.double_0;
		struct154_1.double_7 = (double)currY - NextEdgeCachedData.double_1;
		struct154_1.double_8 = (double)currX - NextEdgeCachedData.double_2;
		struct154_1.double_9 = (double)currY - NextEdgeCachedData.double_3;
		struct154_1.double_10 = NextEdgeCachedData.double_4 * NextEdgeCachedData.double_7 - NextEdgeCachedData.double_5 * NextEdgeCachedData.double_6;
		struct154_1.double_11 = NextEdgeCachedData.double_4 * NextEdgeCachedData.double_9 - NextEdgeCachedData.double_5 * NextEdgeCachedData.double_8;
		struct154_1.sbyte_0 = (sbyte)Math.Sign(NextEdgeCachedData.double_10 * NextEdgeCachedData.double_11);
		struct154_0.double_6 = (double)currX - PrevEdgeCachedData.double_0;
		struct154_0.double_7 = (double)currY - PrevEdgeCachedData.double_1;
		struct154_0.double_8 = (double)currX - PrevEdgeCachedData.double_2;
		struct154_0.double_9 = (double)currY - PrevEdgeCachedData.double_3;
		struct154_0.double_10 = PrevEdgeCachedData.double_4 * PrevEdgeCachedData.double_7 - PrevEdgeCachedData.double_5 * PrevEdgeCachedData.double_6;
		struct154_0.double_11 = PrevEdgeCachedData.double_4 * PrevEdgeCachedData.double_9 - PrevEdgeCachedData.double_5 * PrevEdgeCachedData.double_8;
		struct154_0.sbyte_0 = (sbyte)Math.Sign(PrevEdgeCachedData.double_10 * PrevEdgeCachedData.double_11);
		if (class3019_0.Pixels[currX, currY].bool_0 && class3019_0.Pixels[currX, currY].short_0 == CurrentEdgeCachedData.short_0 && !CurrentEdgeCachedData.bool_0)
		{
			class3019_0.Pixels[currX, currY].short_0 = -10;
			class3019_0.Pixels[currX, currY].short_1 = -10;
			class3019_0.Pixels[currX, currY].bool_0 = false;
		}
		if (!class3019_0.Pixels[currX, currY].bool_1 && class3019_0.Pixels[currX, currY].short_0 == CurrentEdgeCachedData.short_0 && CurrentEdgeCachedData.bool_1)
		{
			class3019_0.Pixels[currX, currY].short_0 = -10;
			class3019_0.Pixels[currX, currY].short_1 = -10;
			class3019_0.Pixels[currX, currY].bool_1 = true;
		}
	}

	public void method_2(ref int currX)
	{
		if (currX == 150)
		{
			_ = CurrentEdgeCachedData.int_0;
		}
		struct153_0.double_6 = (double)currX - CurrentEdgeCachedData.double_0;
		struct153_0.double_8 = (double)currX - CurrentEdgeCachedData.double_2;
		struct153_0.double_12 = CurrentEdgeCachedData.double_15 - CurrentEdgeCachedData.double_5 * CurrentEdgeCachedData.double_6;
		struct153_0.double_13 = CurrentEdgeCachedData.double_16 - CurrentEdgeCachedData.double_5 * CurrentEdgeCachedData.double_8;
		struct153_0.sbyte_0 = (sbyte)Math.Sign(CurrentEdgeCachedData.double_12 * CurrentEdgeCachedData.double_13);
		struct153_0.double_17 = CurrentEdgeCachedData.double_6 * CurrentEdgeCachedData.double_4 + CurrentEdgeCachedData.double_14;
		struct154_1.double_6 = (double)currX - NextEdgeCachedData.double_0;
		struct154_1.double_8 = (double)currX - NextEdgeCachedData.double_2;
		struct154_1.double_10 = NextEdgeCachedData.double_4 * NextEdgeCachedData.double_7 - NextEdgeCachedData.double_5 * NextEdgeCachedData.double_6;
		struct154_1.double_11 = NextEdgeCachedData.double_4 * NextEdgeCachedData.double_9 - NextEdgeCachedData.double_5 * NextEdgeCachedData.double_8;
		struct154_1.sbyte_0 = (sbyte)Math.Sign(NextEdgeCachedData.double_10 * NextEdgeCachedData.double_11);
		struct154_0.double_6 = (double)currX - PrevEdgeCachedData.double_0;
		struct154_0.double_8 = (double)currX - PrevEdgeCachedData.double_2;
		struct154_0.double_10 = PrevEdgeCachedData.double_4 * PrevEdgeCachedData.double_7 - PrevEdgeCachedData.double_5 * PrevEdgeCachedData.double_6;
		struct154_0.double_11 = PrevEdgeCachedData.double_4 * PrevEdgeCachedData.double_9 - PrevEdgeCachedData.double_5 * PrevEdgeCachedData.double_8;
		struct154_0.sbyte_0 = (sbyte)Math.Sign(PrevEdgeCachedData.double_10 * PrevEdgeCachedData.double_11);
		if (class3019_0.Pixels[currX, CurrentEdgeCachedData.int_0].bool_0 && class3019_0.Pixels[currX, CurrentEdgeCachedData.int_0].short_0 == CurrentEdgeCachedData.short_0 && !CurrentEdgeCachedData.bool_0)
		{
			class3019_0.Pixels[currX, CurrentEdgeCachedData.int_0].short_0 = -10;
			class3019_0.Pixels[currX, CurrentEdgeCachedData.int_0].short_1 = -10;
			class3019_0.Pixels[currX, CurrentEdgeCachedData.int_0].bool_0 = false;
		}
		if (!class3019_0.Pixels[currX, CurrentEdgeCachedData.int_0].bool_1 && class3019_0.Pixels[currX, CurrentEdgeCachedData.int_0].short_0 == CurrentEdgeCachedData.short_0 && CurrentEdgeCachedData.bool_1)
		{
			class3019_0.Pixels[currX, CurrentEdgeCachedData.int_0].short_0 = -10;
			class3019_0.Pixels[currX, CurrentEdgeCachedData.int_0].short_1 = -10;
			class3019_0.Pixels[currX, CurrentEdgeCachedData.int_0].bool_1 = true;
		}
	}
}
