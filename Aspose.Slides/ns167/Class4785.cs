using System;
using System.Collections;
using ns161;
using ns164;
using ns166;
using ns235;

namespace ns167;

internal class Class4785 : Class4780
{
	private static readonly float float_3 = 0.75f;

	private static readonly float float_4 = 1.5f;

	internal float MeanLineSpacing
	{
		get
		{
			double num;
			if (base.LineCount > 2)
			{
				num = Class4816.smethod_0(method_34());
				num /= (double)FontSize;
			}
			else
			{
				num = 0.0;
			}
			return (float)num;
		}
	}

	internal float LineInterval
	{
		get
		{
			double num = 0.0;
			if (base.LineCount > 1)
			{
				ArrayList observations = method_34();
				num = Class4816.smethod_0(observations);
			}
			else if (base.Parent != null && base.Parent is Class4785 @class)
			{
				ArrayList arrayList = @class.method_34();
				int num2 = @class.method_35(this);
				num = ((num2 <= -1) ? ((double)@class.LineInterval) : ((double)arrayList[num2]));
				if (num < 6.0 && (double)BoundingBox.Height - num > 1.0)
				{
					num = BoundingBox.Height;
				}
			}
			if (num == 0.0)
			{
				if (base.LineCount == 1)
				{
					for (int i = 0; i < base[0].PageElementCount; i++)
					{
						num = ((!(base[0][i] is Class4790)) ? Math.Max(num, (double)base[0][i].BoundingBox.Height + 0.5) : Math.Max(num, 1.0));
					}
				}
				if (num == 0.0)
				{
					num = 12.0;
				}
			}
			if (num < 0.0)
			{
				return 0f;
			}
			if (Class4860.Instance.Options.UserAgent == Enum678.const_0 && Class4860.Instance.Options.Mode == Enum676.const_0)
			{
				return (float)num;
			}
			return (int)num;
		}
	}

	internal Enum671 Alignment => method_37();

	internal override void vmethod_1(Class6216 targetPage)
	{
		base.vmethod_1(targetPage);
		Class4842.smethod_0(targetPage, BoundingBox, Class4842.color_3);
	}

	internal override bool Add(Class4779 element)
	{
		bool result = true;
		if (!(element is Class4784) && !(element is Class4790))
		{
			if (element is Class4785 @class)
			{
				foreach (Class4845 item in @class)
				{
					Add(item.Value);
				}
			}
			else if (element is Class4791 element2)
			{
				Class4784 element3 = new Class4784(element2);
				Add(element3);
			}
			else if (element is Class4780 class3)
			{
				foreach (Class4845 item2 in class3)
				{
					Add(item2.Value);
				}
			}
			else
			{
				result = false;
			}
		}
		else if (!(Class4778.smethod_11(element, this) >= float_3) && Class4778.smethod_11(this, element) < float_3)
		{
			base.Add(element);
		}
		else
		{
			bool flag = false;
			{
				IEnumerator enumerator3 = GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						Class4845 class5 = (Class4845)enumerator3.Current;
						if (Class4778.smethod_0(class5.Value.Origin.Y, element.Origin.Y) && Class4778.smethod_1(class5.Value.BoundingBox.Y, element.BoundingBox.Y, 1.5) && class5.Value is Class4784)
						{
							((Class4784)class5.Value).Add(element);
							flag = true;
							break;
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator3 as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			if (!flag)
			{
				base.Add(element);
			}
		}
		return result;
	}

	internal override void vmethod_2(ArrayList elements)
	{
		foreach (Class4779 element in elements)
		{
			Add(element);
		}
	}

	internal ArrayList method_33(int lineStartIndex, int lineEndIndex)
	{
		if (lineStartIndex >= 0 && lineEndIndex <= base.LineCount)
		{
			ArrayList arrayList = new ArrayList();
			int num = lineEndIndex - lineStartIndex - 1;
			for (int i = 0; i < num; i++)
			{
				double num2 = base[i + lineStartIndex + 1].Origin.Y - base[i + lineStartIndex].Origin.Y;
				arrayList.Add(num2);
			}
			return arrayList;
		}
		throw new ArgumentException("Please report exception. Invalid indexes in " + ToString());
	}

	internal ArrayList method_34()
	{
		ArrayList arrayList = new ArrayList();
		if (base.LineCount > 1)
		{
			double num = base[0].Origin.Y;
			for (int i = 1; i < base.LineCount; i++)
			{
				double num2 = base[i].Origin.Y;
				double num3 = num2 - num;
				arrayList.Add(num3);
				num = num2;
			}
		}
		return arrayList;
	}

	internal int method_35(Class4779 element)
	{
		int num = 1;
		while (true)
		{
			if (num < base.LineCount)
			{
				if ((double)base[num].Origin.Y == (double)element.Origin.Y)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num - 1;
	}

	internal float method_36()
	{
		if (base.LineCount == 0)
		{
			return 0f;
		}
		Class4783 @class = base[0];
		return @class.MaxHeight;
	}

	private Enum671 method_37()
	{
		if (method_38(out var left, out var center, out var right))
		{
			double num = Class4816.smethod_0(left);
			double num2 = Class4816.smethod_0(center);
			double num3 = Class4816.smethod_0(right);
			if (base.LineCount > 1 && num / (double)FontSize < (double)float_4 && num2 / (double)FontSize < (double)float_4 && num3 / (double)FontSize < (double)float_4)
			{
				return Enum671.const_3;
			}
			ArrayList arrayList = new ArrayList();
			arrayList.Add(num);
			arrayList.Add(num2);
			arrayList.Add(num3);
			Class4812.smethod_4(arrayList, out var index);
			return index switch
			{
				0 => Enum671.const_0, 
				1 => Enum671.const_1, 
				2 => Enum671.const_2, 
				_ => throw new InvalidOperationException("Please report exception. Invalid alignment option."), 
			};
		}
		return Enum671.const_3;
	}

	private bool method_38(out ArrayList left, out ArrayList center, out ArrayList right)
	{
		bool flag = true;
		left = new ArrayList();
		center = new ArrayList();
		right = new ArrayList();
		for (int i = 0; i < base.LineCount; i++)
		{
			for (int j = 0; j < base[i].PageElementCount; j++)
			{
				if (base[i][j] is Class4790)
				{
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			flag = false;
			for (int k = 0; k < base.LineCount; k++)
			{
				left.Add(Math.Abs((double)base[k].BoundingBox.Left - (double)BoundingBox.Left));
				if (k != base.LineCount - 1 || base.LineCount == 1)
				{
					right.Add(Math.Abs((double)base[k].BoundingBox.Right - (double)BoundingBox.Right));
					center.Add(Math.Abs((double)base[k].GeometricCenter.X - (double)base.GeometricCenter.X));
					flag = true;
				}
			}
		}
		return flag;
	}
}
