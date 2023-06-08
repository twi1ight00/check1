using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ns166;
using ns224;
using ns235;

namespace ns167;

internal class Class4780 : Class4779, IEnumerable, IEnumerator, Interface147
{
	private bool bool_0 = true;

	private Enum672 enum672_0;

	private PointF pointF_0;

	private float float_0;

	private PointF pointF_1;

	private float float_1;

	protected Class4846 class4846_0;

	protected readonly Class4844 class4844_0 = new Class4844();

	protected static readonly int int_0 = -1;

	private static readonly float float_2 = float.PositiveInfinity;

	internal int LineCount => class4844_0.LineCount;

	internal Class4783 this[int index]
	{
		get
		{
			return new Class4783(class4844_0[index]);
		}
		set
		{
			class4844_0[index] = value.method_1();
		}
	}

	internal override RectangleF BoundingBox
	{
		get
		{
			if (bool_0)
			{
				method_27();
			}
			return class4844_0.BoundingBox;
		}
	}

	internal override string Text
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < class4844_0.LineCount; i++)
			{
				List<Class4779> list = class4844_0[i];
				foreach (Class4779 item in list)
				{
					stringBuilder.Append(item.Text);
				}
				stringBuilder.Append("\n");
			}
			return stringBuilder.ToString();
		}
	}

	internal override PointF MassCenter
	{
		get
		{
			if (bool_0)
			{
				method_27();
			}
			return pointF_0;
		}
	}

	internal override float FontSize
	{
		get
		{
			if (bool_0)
			{
				method_27();
			}
			return float_0;
		}
	}

	internal override PointF Origin
	{
		get
		{
			if (bool_0)
			{
				method_27();
			}
			return pointF_1;
		}
		set
		{
			pointF_1 = value;
		}
	}

	internal override float Compactness
	{
		get
		{
			if (bool_0)
			{
				method_27();
			}
			return float_1;
		}
	}

	internal override Enum672 Style
	{
		get
		{
			if (bool_0)
			{
				method_27();
			}
			return enum672_0;
		}
	}

	internal double OptimalGroupingDistance => class4844_0.NeighborStatistics;

	Class4845 Interface147.Current => class4844_0.Current;

	public override object Current => class4844_0.Current;

	internal int ChildrenCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < class4844_0.LineCount; i++)
			{
				num += class4844_0[i].Count;
			}
			return num;
		}
	}

	internal override bool CanHaveChildren => true;

	internal override float GetRealWidth
	{
		get
		{
			float num = float.NegativeInfinity;
			for (int i = 0; i < LineCount; i++)
			{
				if (num < Math.Abs(this[i].GetRealWidth))
				{
					num = this[i].GetRealWidth;
				}
			}
			if (num != float.NegativeInfinity)
			{
				return num;
			}
			return 0f;
		}
	}

	internal override string FontFace
	{
		get
		{
			string text = string.Empty;
			if (!method_21())
			{
				text = this[0][0].FontFace;
				{
					IEnumerator enumerator = GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							Class4845 @class = (Class4845)enumerator.Current;
							string fontFace = @class.Value.FontFace;
							if (text != fontFace)
							{
								text = "Mixed";
								break;
							}
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
			return text;
		}
	}

	internal override float InsideTextDistance
	{
		get
		{
			float num = 0f;
			for (int i = 0; i < LineCount; i++)
			{
				num += this[i].InsideTextDistance;
			}
			if (!method_21())
			{
				return num / (float)LineCount;
			}
			return 0f;
		}
	}

	internal override bool CanBeOptimized => true;

	internal Class4780()
	{
	}

	internal Class4780(ArrayList els)
	{
		foreach (Class4779 el in els)
		{
			Add(el);
		}
	}

	internal virtual bool Add(Class4779 element)
	{
		class4844_0.Add(element);
		element.Parent = this;
		vmethod_0();
		return true;
	}

	internal void CopyFrom(Class4780 source)
	{
		foreach (Class4845 item in source)
		{
			Add(item.Value);
		}
	}

	internal List<Class4779> method_1()
	{
		List<Class4779> list = new List<Class4779>();
		for (int i = 0; i < class4844_0.LineCount; i++)
		{
			for (int j = 0; j < class4844_0[i].Count; j++)
			{
				list.Add(class4844_0[i][j]);
			}
		}
		return list;
	}

	internal override void vmethod_0()
	{
		enum672_0 = Enum672.flag_0;
		bool_0 = true;
		base.vmethod_0();
	}

	internal override void vmethod_1(Class6216 targetPage)
	{
		PointF end = new PointF(Origin.X + 2f, Origin.Y);
		Class6217 @class = Class6217.smethod_3(Origin, end);
		@class.Pen = new Class6003(Class5998.class5998_29);
		targetPage.Add(@class);
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class4845 class2 = (Class4845)enumerator.Current;
				class2.Value.vmethod_1(targetPage);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	internal Class4846 method_2(Enum673 dimension, bool isReverse)
	{
		if (class4846_0 == null)
		{
			class4846_0 = new Class4846(dimension, isReverse);
		}
		else
		{
			class4846_0.Clear();
			class4846_0.method_11(dimension, isReverse);
		}
		for (int i = 0; i < LineCount; i++)
		{
			for (int j = 0; j < class4844_0[i].Count; j++)
			{
				Class4845 @class = new Class4845(i, j, class4844_0);
				if (!(@class.Value is Class4789))
				{
					class4846_0.Add(@class);
				}
			}
		}
		class4846_0.method_11(dimension, isReverse);
		return class4846_0;
	}

	internal virtual void vmethod_2(ArrayList elements)
	{
		class4844_0.method_4(elements);
		foreach (Class4779 element in elements)
		{
			element.Parent = this;
		}
		vmethod_0();
	}

	internal bool method_3()
	{
		bool result = false;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class4845 @class = (Class4845)enumerator.Current;
				if (@class.Value is Class4790)
				{
					result = true;
					break;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return result;
	}

	internal void Remove(Class4779 element)
	{
		class4844_0.Remove(element);
		vmethod_0();
	}

	void Interface147.Reset()
	{
		class4844_0.Reset();
	}

	public override void Reset()
	{
		class4844_0.Reset();
	}

	bool Interface147.imethod_0()
	{
		return class4844_0.method_5();
	}

	bool Interface147.imethod_1()
	{
		return class4844_0.method_6();
	}

	public override bool MoveNext()
	{
		bool flag = class4844_0.method_6();
		while (!flag && class4844_0.method_5())
		{
			flag = class4844_0.method_6();
		}
		return flag;
	}

	internal Interface147 method_4()
	{
		((Interface147)this).Reset();
		return this;
	}

	public override IEnumerator GetEnumerator()
	{
		((IEnumerator)this).Reset();
		return this;
	}

	internal bool method_5()
	{
		return class4844_0.method_9();
	}

	internal Class4846 method_6(RectangleF region)
	{
		return method_8(region, checkForLooseOverlap: true);
	}

	internal Class4786 method_7(RectangleF region)
	{
		Class4846 @class = method_11(region, 2f, isPercentage: false);
		Class4786 class2 = new Class4786();
		foreach (Class4845 item in @class)
		{
			class2.Add(item.Value);
			item.Remove();
		}
		Flush();
		return class2;
	}

	internal Class4846 method_8(RectangleF region, bool checkForLooseOverlap)
	{
		if (region.IsEmpty)
		{
			return null;
		}
		Class4846 @class = new Class4846();
		class4844_0.method_1();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class4845 class2 = (Class4845)enumerator.Current;
				if (!RectangleF.Intersect(class2.Value.BoundingBox, region).IsEmpty && (!checkForLooseOverlap || Class4778.smethod_16(class2.Value.BoundingBox, region)))
				{
					@class.Add(class2);
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		class4844_0.method_2();
		return @class;
	}

	internal Class4846 method_9(RectangleF region, float minCoverageAreaForOverlap)
	{
		return method_11(region, minCoverageAreaForOverlap, isPercentage: true);
	}

	internal Class4846 method_10(RectangleF region, float minCoverageAreaForOverlap)
	{
		Class4846 @class = new Class4846();
		Class4846 class2 = method_9(region, minCoverageAreaForOverlap);
		foreach (Class4845 item in class2)
		{
			if (item.Value is Class4780)
			{
				@class.method_9(((Class4780)item.Value).method_10(region, minCoverageAreaForOverlap));
			}
			else
			{
				@class.Add(item);
			}
		}
		return @class;
	}

	internal Class4846 method_11(RectangleF region, float minCoverageAreaForOverlap, bool isPercentage)
	{
		if (region.IsEmpty)
		{
			return null;
		}
		Class4846 @class = new Class4846();
		class4844_0.method_1();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class4845 class2 = (Class4845)enumerator.Current;
				RectangleF overlap = RectangleF.Intersect(class2.Value.BoundingBox, region);
				if (!overlap.IsEmpty && ((isPercentage && smethod_0(class2, minCoverageAreaForOverlap, overlap, region)) || (!isPercentage && smethod_1(minCoverageAreaForOverlap, overlap))))
				{
					@class.Add(class2);
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		class4844_0.method_2();
		return @class;
	}

	private static bool smethod_0(Class4845 elPtr, float minCoverageAreaForOverlap, RectangleF overlap, RectangleF region)
	{
		if (!(Class4778.smethod_4(overlap) / Class4778.smethod_4(region) > minCoverageAreaForOverlap))
		{
			if (Class4778.smethod_14(elPtr.Value.BoundingBox, region) == 1f && !(Class4778.smethod_12(elPtr.Value.BoundingBox, region) <= minCoverageAreaForOverlap))
			{
				return true;
			}
			if (Class4778.smethod_14(region, elPtr.Value.BoundingBox) == 1f)
			{
				return Class4778.smethod_12(region, elPtr.Value.BoundingBox) > minCoverageAreaForOverlap;
			}
			return false;
		}
		return true;
	}

	private static bool smethod_1(float minCoverageAreaForOverlap, RectangleF overlap)
	{
		if (overlap.Width > minCoverageAreaForOverlap)
		{
			return overlap.Height > minCoverageAreaForOverlap;
		}
		return false;
	}

	internal Class4846 method_12(Class4845 elementPointer, float epsY, float epsX)
	{
		return method_25(elementPointer.Row, elementPointer.Column, epsY, epsX, lookDown: false, nonExhaustiveSearch: true);
	}

	internal Class4846 method_13(Class4845 elementPointer, float epsY, float epsX)
	{
		return method_26(elementPointer.Row, elementPointer.Column, epsY, epsX, lookDown: false, nonExhaustiveSearch: true, searhNearby: true);
	}

	internal Class4846 method_14(Class4845 elementPointer, float epsY, float epsX)
	{
		return method_26(elementPointer.Row, elementPointer.Column, epsY, epsX, lookDown: true, nonExhaustiveSearch: true, searhNearby: true);
	}

	internal Class4846 method_15(Class4845 elementPointer, float epsY, float epsX)
	{
		return method_25(elementPointer.Row, elementPointer.Column, epsY, epsX, lookDown: true, nonExhaustiveSearch: true);
	}

	internal Class4846 method_16(Class4845 elementPointer, float epsY, float epsX)
	{
		Class4846 @class = method_25(elementPointer.Row, elementPointer.Column, epsY, epsX, lookDown: true, nonExhaustiveSearch: false);
		ArrayList arrayList = smethod_6(elementPointer.Value, this[elementPointer.Row], epsX, epsY);
		foreach (int item in arrayList)
		{
			if (item != elementPointer.Column)
			{
				@class.method_6(new Class4845(elementPointer.Row, item, class4844_0));
			}
		}
		return @class;
	}

	internal Class4846 method_17(Class4845 elementPointer, float epsY, float epsX)
	{
		Class4846 @class = method_25(elementPointer.Row, elementPointer.Column, epsY, epsX, lookDown: false, nonExhaustiveSearch: false);
		ArrayList arrayList = smethod_6(elementPointer.Value, this[elementPointer.Row], epsX, epsY);
		foreach (int item in arrayList)
		{
			if (item != elementPointer.Column)
			{
				@class.method_6(new Class4845(elementPointer.Row, item, class4844_0));
			}
		}
		return @class;
	}

	internal Class4846 method_18(Class4845 elementPointer, float epsY, float epsX)
	{
		if (elementPointer == null)
		{
			return null;
		}
		return method_24(elementPointer.Row, elementPointer.Column, epsY, epsX, lookLeft: true, nonExhaustiveSearch: false);
	}

	internal Class4846 method_19(Class4845 elementPointer, float epsY, float epsX)
	{
		if (elementPointer == null)
		{
			return null;
		}
		return method_24(elementPointer.Row, elementPointer.Column, epsY, epsX, lookLeft: false, nonExhaustiveSearch: false);
	}

	internal virtual bool Flush()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class4845 @class = (Class4845)enumerator.Current;
				if (@class.Value is Class4780)
				{
					Class4780 class2 = (Class4780)@class.Value;
					class2.Flush();
					if (class2.ChildrenCount == 0)
					{
						@class.Remove();
					}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		base.vmethod_0();
		return class4844_0.method_0();
	}

	internal Class4845 method_20(int row, int column)
	{
		return new Class4845(row, column, class4844_0);
	}

	internal void Clear()
	{
		class4844_0.Clear();
	}

	internal bool method_21()
	{
		bool result = true;
		for (int i = 0; i < class4844_0.LineCount; i++)
		{
			if (this[i].PageElementCount != 0)
			{
				result = false;
				break;
			}
		}
		return result;
	}

	internal void method_22(Class4779 element)
	{
		class4844_0.method_7(element);
	}

	internal void method_23()
	{
		class4844_0.method_8();
		if (base.Parent != null)
		{
			((Class4780)base.Parent).method_22(this);
		}
	}

	internal static Enum672 smethod_2(IEnumerable allElements)
	{
		Enum672 @enum = Enum672.flag_0;
		bool flag = true;
		foreach (Class4845 allElement in allElements)
		{
			if (flag)
			{
				@enum = allElement.Value.Style;
				flag = false;
			}
			if (@enum != allElement.Value.Style)
			{
				@enum = Enum672.flag_4;
				break;
			}
		}
		return @enum;
	}

	internal static PointF smethod_3(IEnumerable allElements)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		foreach (Class4845 allElement in allElements)
		{
			Class4779 value = allElement.Value;
			num += value.MassCenter.X;
			num2 += value.MassCenter.Y;
			num3 += 1f;
		}
		return new PointF(num / num3, num2 / num3);
	}

	internal static float smethod_4(IEnumerable allElements)
	{
		float num = 0f;
		int num2 = 0;
		foreach (Class4845 allElement in allElements)
		{
			Class4779 value = allElement.Value;
			num += value.FontSize;
			num2++;
		}
		return num / (float)num2;
	}

	internal static float smethod_5(IEnumerable allElements, float width, float height)
	{
		float num = 0f;
		foreach (Class4845 allElement in allElements)
		{
			Class4779 value = allElement.Value;
			num = ((!(value is Class4791)) ? (num + value.Compactness * value.BoundingBox.Width * value.BoundingBox.Height) : (num + value.BoundingBox.Width * value.BoundingBox.Height));
		}
		if (width * height == 0f)
		{
			return 0f;
		}
		return num / (width * height);
	}

	private Class4846 method_24(int placementLineIndex, int textPartIndex, float epsY, float epsX, bool lookLeft, bool nonExhaustiveSearch)
	{
		Class4846 @class = new Class4846();
		Class4779 class2 = this[placementLineIndex][textPartIndex];
		bool flag = false;
		for (int i = 0; i < LineCount; i++)
		{
			bool flag2 = class4844_0[i].Count != 0;
			int num = 0;
			while (flag2)
			{
				if (placementLineIndex == i && textPartIndex == num)
				{
					flag2 = flag2 && num + 1 < class4844_0[i].Count;
				}
				else
				{
					Class4779 class3 = this[i][num];
					if (!(class3 is Class4789) && (flag2 = !lookLeft || class3.BoundingBox.Right <= class2.BoundingBox.Right))
					{
						bool flag3 = Class4778.smethod_33(class2, class3) || Class4778.smethod_7(class2, class3) < (double)epsX;
						bool flag4 = Class4778.smethod_34(class2, class3) || Class4778.smethod_9(class2, class3) <= (double)epsY;
						bool flag5 = lookLeft || class3.BoundingBox.Left >= class2.BoundingBox.Left;
						if (flag3 && flag4 && flag5)
						{
							@class.Add(new Class4845(i, num, class4844_0));
							flag = true;
							if (nonExhaustiveSearch)
							{
								break;
							}
						}
					}
					flag2 = flag2 && num + 1 < class4844_0[i].Count;
				}
				num++;
			}
			if (flag && nonExhaustiveSearch)
			{
				break;
			}
		}
		return @class;
	}

	private Class4846 method_25(int placementLineIndex, int textPartIndex, float epsY, float epsX, bool lookDown, bool nonExhaustiveSearch)
	{
		return method_26(placementLineIndex, textPartIndex, epsY, epsX, lookDown, nonExhaustiveSearch, searhNearby: false);
	}

	private Class4846 method_26(int placementLineIndex, int textPartIndex, float epsY, float epsX, bool lookDown, bool nonExhaustiveSearch, bool searhNearby)
	{
		Class4846 @class = new Class4846();
		Class4779 curEl = this[placementLineIndex][textPartIndex];
		int num = placementLineIndex;
		Class4783 class2 = this[placementLineIndex];
		bool flag;
		do
		{
			flag = true;
			num = (lookDown ? (num + 1) : (num - 1));
			if ((lookDown && num < LineCount) || (!lookDown && num >= 0))
			{
				Class4783 class3 = this[num];
				if (class3.PageElementCount == 0 || class3.BoundingBox.IsEmpty)
				{
					continue;
				}
				if (Class4778.smethod_9(class2, class3) <= (double)epsY || Class4778.smethod_34(class2, class3))
				{
					ArrayList arrayList = smethod_6(curEl, class3, epsX, epsY);
					if (arrayList.Count == 0)
					{
						continue;
					}
					foreach (int item in arrayList)
					{
						@class.Add(new Class4845(num, item, class4844_0));
					}
					if (nonExhaustiveSearch)
					{
						flag = false;
					}
				}
				else if (lookDown || searhNearby)
				{
					flag = false;
				}
			}
			else
			{
				flag = false;
			}
		}
		while (flag);
		return @class;
	}

	private static ArrayList smethod_6(Class4779 curEl, Class4783 lineToCheck, float epsX, float epsY)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < lineToCheck.PageElementCount; i++)
		{
			Class4779 @class = lineToCheck[i];
			if (!(@class is Class4789) && Class4778.smethod_9(curEl, @class) < (double)epsY)
			{
				if (Class4778.smethod_33(curEl, @class))
				{
					arrayList.Add(i);
				}
				else if (Class4778.smethod_7(curEl, @class) < (double)epsX)
				{
					arrayList.Add(i);
				}
			}
		}
		return arrayList;
	}

	private void method_27()
	{
		bool_0 = false;
		if (!method_21())
		{
			class4844_0.method_1();
			method_23();
			method_28();
			method_29();
			method_30();
			method_31();
			method_32();
			class4844_0.method_2();
		}
		else
		{
			pointF_0 = default(PointF);
			float_0 = 0f;
			pointF_1 = default(PointF);
			float_1 = 0f;
			enum672_0 = Enum672.flag_0;
		}
	}

	private void method_28()
	{
		pointF_0 = smethod_3(this);
	}

	private void method_29()
	{
		float_0 = smethod_4(this);
	}

	private void method_30()
	{
		if (class4844_0.LineCount == 0 || class4844_0[0].Count == 0)
		{
			throw new InvalidOperationException("Please report exception. Null reference while calculating Origin.");
		}
		pointF_1 = class4844_0[0][0].Origin;
	}

	private void method_31()
	{
		float_1 = smethod_5(this, BoundingBox.Width, BoundingBox.Height);
	}

	private void method_32()
	{
		enum672_0 = smethod_2(this);
	}
}
