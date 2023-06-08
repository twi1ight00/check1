using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ns161;
using ns166;
using ns224;
using ns235;

namespace ns167;

internal class Class4844
{
	private const bool bool_0 = false;

	private const string string_0 = " ";

	private const string string_1 = "\n";

	private const float float_0 = 0.15f;

	private readonly List<List<Class4779>> list_0 = new List<List<Class4779>>();

	private int int_0;

	private int int_1;

	private RectangleF rectangleF_0;

	private readonly Stack stack_0 = new Stack();

	internal List<Class4779> this[int index]
	{
		get
		{
			return list_0[index];
		}
		set
		{
			list_0[index] = value;
		}
	}

	internal Class4845 Current => new Class4845(int_0, int_1, this);

	internal int LineCount => list_0.Count;

	internal RectangleF BoundingBox
	{
		get
		{
			if (rectangleF_0.IsEmpty)
			{
				method_1();
				Reset();
				while (method_5())
				{
					while (method_6())
					{
						method_7(Current.Value);
					}
				}
				method_2();
			}
			return rectangleF_0;
		}
	}

	internal double NeighborStatistics
	{
		get
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < LineCount; i++)
			{
				List<Class4779> list = list_0[i];
				if (list.Count <= 1)
				{
					continue;
				}
				for (int j = 1; j < list.Count; j++)
				{
					Class4779 text = list[j - 1];
					Class4779 text2 = list[j];
					double num = Class4778.smethod_7(text, text2);
					if (num < 1.0)
					{
						arrayList.Add(num);
					}
				}
			}
			double std = 0.0;
			double mean = 0.0;
			if (arrayList.Count != 0)
			{
				Class4816.smethod_1(arrayList, out mean, out std);
			}
			return mean + 1.7999999523162842 * std;
		}
	}

	internal Class4844()
	{
		Reset();
	}

	internal bool method_0()
	{
		bool result = false;
		for (int i = 0; i < LineCount; i++)
		{
			List<Class4779> list = list_0[i];
			for (int j = 0; j < list.Count; j++)
			{
				Class4779 @class = list[j];
				if (@class is Class4789)
				{
					list.RemoveAt(j);
					j--;
				}
			}
			if (list.Count == 0)
			{
				list_0.RemoveAt(i);
				i--;
				result = true;
			}
		}
		return result;
	}

	internal void method_1()
	{
		stack_0.Push(int_0);
		stack_0.Push(int_1);
	}

	internal void method_2()
	{
		int_1 = (int)stack_0.Pop();
		int_0 = (int)stack_0.Pop();
	}

	internal void method_3(List<Class4779> elements)
	{
		list_0.Add(elements);
	}

	internal void Add(Class4779 element)
	{
		Add(element, optimizeTextPieceInsertion: false);
	}

	internal void Add(Class4779 element, bool optimizeTextPieceInsertion)
	{
		method_1();
		bool flag = false;
		Reset();
		while (method_5() && !flag)
		{
			if (!method_6())
			{
				if (flag = method_11(element))
				{
					break;
				}
				continue;
			}
			Class4779 @class = list_0[int_0][int_1];
			if (!Class4778.smethod_1(element.Origin.Y, @class.Origin.Y, 0.15000000596046448) && !Class4778.smethod_1(element.BoundingBox.Y, @class.BoundingBox.Y, 1.5))
			{
				if (!(element.BoundingBox.Y >= @class.BoundingBox.Y))
				{
					List<Class4779> list = new List<Class4779>();
					list.Add(element);
					list_0.Insert(int_0, list);
					flag = true;
					break;
				}
				continue;
			}
			bool isImage = element is Class4790 || @class is Class4790;
			method_12(element, optimizeTextPieceInsertion, isImage);
			flag = true;
			break;
		}
		if (!flag)
		{
			method_10(element);
		}
		method_7(element);
		method_2();
	}

	internal void method_4(ArrayList elements)
	{
		IEnumerator enumerator = elements.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class4779 element = enumerator.Current as Class4779;
			Add(element);
		}
	}

	internal bool method_5()
	{
		bool result;
		if (int_0 < list_0.Count - 1)
		{
			result = true;
			int_0++;
			int_1 = -1;
		}
		else
		{
			result = false;
		}
		return result;
	}

	internal bool method_6()
	{
		bool result = false;
		if (int_0 != -1)
		{
			List<Class4779> list = list_0[int_0];
			int_1++;
			while (int_1 < list.Count)
			{
				Class4779 @class = list[int_1];
				if (@class is Class4780)
				{
					Class4780 class2 = (Class4780)@class;
					if (class2.ChildrenCount == 0)
					{
						@class = new Class4789();
						list[int_1] = @class;
						@class.vmethod_0();
					}
				}
				if (Current.Value is Class4789)
				{
					int_1++;
					continue;
				}
				result = true;
				break;
			}
		}
		return result;
	}

	internal void Remove(Class4779 element)
	{
		List<Class4779> list = null;
		for (int i = 0; i < list_0.Count; i++)
		{
			list = list_0[i];
			if (element.Origin.Y == list[0].Origin.Y)
			{
				break;
			}
		}
		list?.Remove(element);
	}

	internal void Reset()
	{
		int_0 = -1;
		int_1 = -1;
	}

	internal void Clear()
	{
		list_0.Clear();
	}

	internal void method_7(Class4779 element)
	{
		if (rectangleF_0.IsEmpty)
		{
			rectangleF_0 = element.BoundingBox;
			return;
		}
		if (element.BoundingBox.Left < rectangleF_0.Left)
		{
			rectangleF_0.Width += rectangleF_0.Left - element.BoundingBox.Left;
			rectangleF_0.X = element.BoundingBox.X;
		}
		if (element.BoundingBox.Right > rectangleF_0.Right)
		{
			rectangleF_0.Width += element.BoundingBox.Right - rectangleF_0.Right;
		}
		if (element.BoundingBox.Top < rectangleF_0.Top)
		{
			rectangleF_0.Height += rectangleF_0.Top - element.BoundingBox.Top;
			rectangleF_0.Y = element.BoundingBox.Y;
		}
		if (element.BoundingBox.Bottom > rectangleF_0.Bottom)
		{
			rectangleF_0.Height += element.BoundingBox.Bottom - rectangleF_0.Bottom;
		}
	}

	internal void method_8()
	{
		RectangleF b = default(RectangleF);
		foreach (List<Class4779> item in list_0)
		{
			foreach (Class4779 item2 in item)
			{
				if (!(item2 is Class4789))
				{
					if (b.IsEmpty)
					{
						b = item2.BoundingBox;
					}
					else if (!item2.BoundingBox.IsEmpty)
					{
						b = RectangleF.Union(item2.BoundingBox, b);
					}
				}
			}
		}
		rectangleF_0 = b;
	}

	internal bool method_9()
	{
		if (Class4860.Instance.Options.UseNewTextBoxRecognitionAlgorithm)
		{
			return false;
		}
		bool result = false;
		for (int num = LineCount - 1; num >= 0; num--)
		{
			List<Class4779> list = this[num];
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				if (list[num2].Text == " " || list[num2].Text == "\n")
				{
					list.RemoveAt(num2);
				}
			}
			if (list.Count == 0)
			{
				list_0.RemoveAt(num);
			}
			else
			{
				this[num] = list;
			}
		}
		return result;
	}

	internal void method_10(Class4779 element)
	{
		List<Class4779> list = new List<Class4779>();
		list.Add(element);
		list_0.Add(list);
	}

	internal bool method_11(Class4779 element)
	{
		bool result;
		if (result = list_0.Count == 1)
		{
			List<Class4779> list = list_0[int_0];
			list.Add(element);
		}
		else
		{
			list_0.RemoveAt(int_0);
			int_0--;
		}
		return result;
	}

	private void method_12(Class4779 element, bool optimizeTextPieceInsertion, bool isImage)
	{
		bool flag = false;
		List<Class4779> list = list_0[int_0];
		do
		{
			Class4779 @class = list[int_1];
			if (!(@class is Class4784 class2))
			{
				if (element.Origin.X >= @class.Origin.X)
				{
					if (Class4778.smethod_0(element.Origin.X, @class.Origin.X))
					{
						if (isImage)
						{
							PointF origin = element.Origin;
							origin.X += 0.075f;
							element.Origin = origin;
						}
						else
						{
							method_14(element);
							flag = true;
						}
						break;
					}
					continue;
				}
				list.Insert(int_1, element);
				flag = true;
				break;
			}
			foreach (Class4845 item in class2)
			{
				if (!(element.Origin.X >= item.Value.Origin.X))
				{
					list.Insert(int_1, element);
					return;
				}
			}
		}
		while (method_6());
		if (flag)
		{
			return;
		}
		bool flag2 = false;
		if (optimizeTextPieceInsertion)
		{
			Class4791 class4 = list[list.Count - 1] as Class4791;
			Class4791 class5 = element as Class4791;
			if (class4 != null && class5 != null)
			{
				flag2 = method_13(class4, class5);
			}
			if (flag2)
			{
				class5.method_5();
			}
		}
		if (!flag2)
		{
			list.Add(element);
		}
	}

	internal static bool smethod_0(Class5999 a, Class5999 b)
	{
		if (a != null && b != null)
		{
			if (a.TrueTypeFont.FamilyName == b.TrueTypeFont.FamilyName && a.Style == b.Style && a.SizePoints == b.SizePoints)
			{
				return a.StyleEx == b.StyleEx;
			}
			return false;
		}
		return a == b;
	}

	internal static bool smethod_1(RectangleF a, RectangleF b, Class5999 font)
	{
		RectangleF rectangleF = a;
		float num = 0.5f;
		if (font != null)
		{
			num = font.SizePoints * 0.05f;
		}
		rectangleF.Inflate(num, num);
		return rectangleF.Contains(b);
	}

	internal bool method_13(Class4791 lastEl, Class4791 curEl)
	{
		if (((Class4860.Instance.Options.UserAgent != Enum678.const_1 && !Class4860.Instance.Options.UseNewTextBoxRecognitionAlgorithm) || Class4860.Instance.Options.Mode != 0) && (Class4860.Instance.Options.UserAgent != 0 || Class4860.Instance.Options.Mode != Enum676.const_1))
		{
			bool result = false;
			if (smethod_0(lastEl.ApsGlyphFont, curEl.ApsGlyphFont) && lastEl.IsInvisible == curEl.IsInvisible && curEl.BoundingBox.Left - lastEl.BoundingBox.Right < Class4778.smethod_41(lastEl.ApsGlyphFont) && (!smethod_1(lastEl.BoundingBox, curEl.BoundingBox, lastEl.ApsGlyphFont) || smethod_1(curEl.BoundingBox, lastEl.BoundingBox, lastEl.ApsGlyphFont)))
			{
				if (Class4860.Instance.Options.UserAgent == Enum678.const_1 && Class4860.Instance.Options.Mode == Enum676.const_0 && !Class6270.Equals(lastEl.method_2().Hyperlink, curEl.method_2().Hyperlink))
				{
					return false;
				}
				lastEl.AddText(curEl);
				result = true;
			}
			return result;
		}
		return false;
	}

	internal void method_14(Class4779 element)
	{
		method_15(element);
	}

	internal void method_15(Class4779 element)
	{
		if (!method_16(element))
		{
			return;
		}
		while (Class4778.smethod_0(element.Origin.X, Current.Value.Origin.X))
		{
			PointF origin = new PointF(element.Origin.X + 0.025f, element.Origin.Y);
			element.Origin = origin;
			if (!method_6())
			{
				break;
			}
		}
		List<Class4779> list = list_0[int_0];
		list.Insert(int_1, element);
	}

	internal bool method_16(Class4779 element)
	{
		if (!(element is Class4788) && !(element is Class4780))
		{
			return Current.Value.Text != element.Text;
		}
		return false;
	}
}
