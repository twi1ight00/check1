using System;
using System.Collections;
using System.Drawing;
using ns161;

namespace ns168;

internal class Class4798 : Class4792
{
	private bool bool_0;

	private Class4796 class4796_0;

	private int int_1 = -32768;

	private int int_2 = 32767;

	private readonly ArrayList arrayList_0;

	internal Class4797 this[int index]
	{
		get
		{
			return (Class4797)arrayList_0[index];
		}
		set
		{
			if (index >= Count)
			{
				throw new ArgumentException("Please report exception. Index out of range.");
			}
			arrayList_0[index] = value;
		}
	}

	internal int Count => arrayList_0.Count;

	internal Class4798()
	{
		arrayList_0 = new ArrayList();
	}

	internal Class4798(Class4796 parent)
	{
		arrayList_0 = new ArrayList();
		class4796_0 = parent;
		bool_0 = true;
	}

	internal void method_0(bool isHorizontal, Class4798 opposites)
	{
		method_2(isHorizontal, opposites);
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		for (int i = 1; i < Count; i++)
		{
			arrayList.Clear();
			bool flag;
			do
			{
				Class4797 @class = this[i - 1];
				Class4797 class2 = this[i];
				if (flag = ((!isHorizontal) ? (Math.Abs(@class.Start.X - class2.Start.X) < 3f) : (Math.Abs(@class.Start.Y - class2.Start.Y) < 3f)))
				{
					if (!arrayList.Contains(i - 1))
					{
						arrayList.Add(i - 1);
					}
					if (!arrayList.Contains(i))
					{
						arrayList.Add(i);
					}
					i++;
					if (i == Count)
					{
						break;
					}
				}
			}
			while (flag);
			method_1(isHorizontal, this, opposites, arrayList, arrayList2);
		}
		arrayList2.Sort(Class4817.smethod_6());
		for (int j = 0; j < arrayList2.Count; j++)
		{
			arrayList_0.RemoveAt((int)arrayList2[j]);
		}
	}

	internal void method_1(bool isHorizontal, Class4798 main, Class4798 opposites, ArrayList toCheck, ArrayList toRemove)
	{
		float[] array = new float[toCheck.Count];
		if (isHorizontal)
		{
			for (int i = 0; i < toCheck.Count; i++)
			{
				array[i] = main[(int)toCheck[i]].LeftVertex.X;
			}
		}
		else
		{
			for (int j = 0; j < toCheck.Count; j++)
			{
				array[j] = main[(int)toCheck[j]].TopVertex.Y;
			}
		}
		int[] array2 = Class4817.smethod_3(array);
		for (int k = 1; k < toCheck.Count; k++)
		{
			bool flag;
			do
			{
				Class4797 @class = main[(int)toCheck[array2[k - 1]]];
				Class4797 class2 = main[(int)toCheck[array2[k]]];
				float num = ((!isHorizontal) ? Math.Min(Math.Abs(@class.Start.Y - class2.Start.Y), Math.Abs(@class.End.Y - class2.Start.Y)) : Math.Min(Math.Abs(@class.Start.X - class2.Start.X), Math.Abs(@class.End.X - class2.Start.X)));
				if (flag = Class4817.smethod_5(@class.Color, class2.Color) && num < 2f * method_3(isHorizontal, @class, class2, opposites))
				{
					main[(int)toCheck[array2[k]]] = Class4797.smethod_0(class2, @class);
					toRemove.Add((int)toCheck[array2[k - 1]]);
					k++;
					if (k == toCheck.Count)
					{
						break;
					}
				}
			}
			while (flag);
		}
	}

	internal void method_2(bool isHorizontal, Class4798 opposites)
	{
		if (opposites != null)
		{
			if (isHorizontal)
			{
				method_6();
				opposites.method_5();
			}
			else
			{
				method_5();
				opposites.method_6();
			}
		}
	}

	internal float method_3(bool isHorizontal, Class4797 curSegm, Class4797 nextSegm, Class4798 opposites)
	{
		float num = 0f;
		if (isHorizontal)
		{
			for (int i = 0; i < opposites.Count; i++)
			{
				Class4797 @class = opposites[i];
				if (@class.Start.X <= nextSegm.LeftVertex.X + @class.Thickness && !(@class.Start.X < curSegm.RightVertex.X - @class.Thickness))
				{
					num = @class.Thickness;
					break;
				}
			}
		}
		else
		{
			for (int j = 0; j < opposites.Count; j++)
			{
				Class4797 class2 = opposites[j];
				if (class2.Start.Y <= curSegm.BottomVertex.Y + class2.Thickness && !(class2.Start.Y < nextSegm.TopVertex.Y - class2.Thickness))
				{
					num = class2.Thickness;
					break;
				}
			}
		}
		return num + curSegm.Thickness + nextSegm.Thickness;
	}

	internal void method_4(bool isHorizontal)
	{
		if (isHorizontal)
		{
			method_6();
		}
		else
		{
			method_5();
		}
		bool flag;
		do
		{
			ArrayList arrayList = new ArrayList();
			flag = false;
			for (int num = Count - 1; num >= 1; num--)
			{
				bool flag2 = false;
				Class4797 @class = this[num];
				Class4797 class2 = this[num - 1];
				Class4797 class3 = null;
				float num2 = 0f;
				if (smethod_0(isHorizontal, @class, class2, @class.Thickness + class2.Thickness))
				{
					if (isHorizontal)
					{
						if (Class4817.smethod_5(@class.Color, class2.Color) && @class.Start.Y - class2.Start.Y <= (@class.Thickness + class2.Thickness) / 2f)
						{
							flag2 = true;
							num2 = @class.Start.Y - class2.Start.Y;
							float y = class2.Start.Y + num2 / 2f;
							class3 = new Class4797(new PointF(Math.Min(@class.LeftVertex.X, class2.LeftVertex.X), y), new PointF(Math.Max(@class.RightVertex.X, class2.RightVertex.X), y));
						}
					}
					else if (Class4817.smethod_5(@class.Color, class2.Color) && @class.Start.X - class2.Start.X <= (@class.Thickness + class2.Thickness) / 2f)
					{
						flag2 = true;
						num2 = (@class.Start.X - class2.Start.X) / 2f;
						float x = class2.Start.X + num2;
						class3 = new Class4797(new PointF(x, Math.Min(@class.TopVertex.Y, class2.TopVertex.Y)), new PointF(x, Math.Max(@class.BottomVertex.Y, class2.BottomVertex.Y)));
					}
				}
				if (flag2)
				{
					arrayList.Add(num);
					class3.Thickness = (@class.Thickness + class2.Thickness) / 2f + num2;
					class3.PageOrder = Math.Min(@class.PageOrder, class2.PageOrder);
					class3.Color = @class.Color;
					this[num - 1] = class3;
					flag = true;
				}
			}
			for (int i = 0; i < arrayList.Count; i++)
			{
				arrayList_0.RemoveAt((int)arrayList[i]);
			}
		}
		while (flag);
	}

	private static bool smethod_0(bool checkHorizontal, Class4797 s1, Class4797 s2, float tolerance)
	{
		float num;
		float num2;
		float num3;
		float num4;
		if (checkHorizontal)
		{
			num = s1.LeftVertex.X - tolerance;
			num2 = s1.RightVertex.X + tolerance;
			num3 = s2.LeftVertex.X;
			num4 = s2.RightVertex.X;
		}
		else
		{
			num = s1.TopVertex.Y - tolerance;
			num2 = s1.BottomVertex.Y + tolerance;
			num3 = s2.TopVertex.Y;
			num4 = s2.BottomVertex.Y;
		}
		if (num3 >= num && !(num3 > num2))
		{
			return true;
		}
		if (num4 >= num)
		{
			return num4 <= num2;
		}
		return false;
	}

	public override void vmethod_0(Graphics canvas, PointF topLeft)
	{
		for (int i = 0; i < Count; i++)
		{
			this[i].vmethod_0(canvas, topLeft);
			canvas.DrawString(i.ToString(), new Font("Arial", 3f), new SolidBrush(Color.Black), this[i].LeftVertex.X - topLeft.X, this[i].TopVertex.Y - topLeft.Y);
		}
	}

	internal void method_5()
	{
		for (int i = 0; i < Count; i++)
		{
			if (this[i].Start.X > this[i].End.X)
			{
				this[i].method_4();
			}
			else if (this[i].Start.X == this[i].End.X && this[i].Start.Y > this[i].End.Y)
			{
				this[i].method_4();
			}
		}
		arrayList_0.Sort(Class4797.HorizontalComparer);
	}

	internal void method_6()
	{
		for (int i = 0; i < Count; i++)
		{
			if (this[i].Start.Y > this[i].End.Y)
			{
				this[i].method_4();
			}
			else if (this[i].Start.Y == this[i].End.Y && this[i].Start.X > this[i].End.X)
			{
				this[i].method_4();
			}
		}
		arrayList_0.Sort(Class4797.VerticalComparer);
	}

	internal void Add(Class4797 segment)
	{
		if (!(segment == null) && !Contains(segment))
		{
			arrayList_0.Add(segment);
			int_2 = Math.Min(int_2, segment.PageOrder);
			int_1 = Math.Max(int_1, segment.PageOrder);
			if (bool_0)
			{
				class4796_0.method_3(segment);
			}
		}
	}

	internal bool Contains(Class4797 s)
	{
		bool result = false;
		for (int i = 0; i < Count; i++)
		{
			if (this[i] == s)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	internal bool Remove(Class4797 s)
	{
		bool result = false;
		int num = Count - 1;
		while (num >= 0)
		{
			if (!(this[num] == s))
			{
				num--;
				continue;
			}
			arrayList_0.RemoveAt(num);
			result = true;
			break;
		}
		return result;
	}

	internal bool method_7(Class4798 c)
	{
		bool flag = false;
		for (int i = 0; i < c.Count; i++)
		{
			flag |= Remove(c[i]);
		}
		return flag;
	}
}
