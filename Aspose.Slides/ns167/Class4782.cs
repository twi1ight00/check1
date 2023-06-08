using System;
using System.Collections;
using System.Drawing;
using ns166;
using ns168;
using ns169;
using ns235;

namespace ns167;

internal class Class4782 : Class4780
{
	private const float float_3 = 1.3f;

	private bool bool_1;

	private Class4781 class4781_0;

	private Class4786 class4786_0;

	internal bool IsColumnwise => bool_1;

	internal Class4786 Images
	{
		get
		{
			return class4786_0;
		}
		set
		{
			class4786_0 = value;
		}
	}

	internal Class4782(bool isColumnwise)
	{
		bool_1 = isColumnwise;
	}

	internal Class4781 method_33()
	{
		Flush();
		Class4857 @class = smethod_10(BoundingBox, !IsColumnwise);
		Class4781 class2 = new Class4781(@class);
		method_35();
		RectangleF rectangleF = RectangleF.Empty;
		Class4846 class3 = (IsColumnwise ? method_2(Enum673.const_3, isReverse: false) : method_2(Enum673.const_1, isReverse: false));
		foreach (Class4845 item in class3)
		{
			if (rectangleF != RectangleF.Empty)
			{
				float num = (IsColumnwise ? (item.Value.BoundingBox.Left - rectangleF.Right) : (item.Value.BoundingBox.Top - rectangleF.Bottom));
				if (num > 0f)
				{
					RectangleF bbox = (IsColumnwise ? new RectangleF(rectangleF.Right, BoundingBox.Top, num, BoundingBox.Height) : new RectangleF(BoundingBox.Left, rectangleF.Bottom, BoundingBox.Width, num));
					Class4857 class5 = smethod_10(bbox, IsColumnwise);
					class5.IsDummy = true;
					class5.HasBoundary = false;
					Class4781 element = new Class4781(class5);
					@class.Add(class5);
					class2.Add(element);
				}
			}
			rectangleF = item.Value.BoundingBox;
			if (item.Value is Class4781)
			{
				Class4781 class6 = (Class4781)item.Value;
				if (@class.IsColumn != class6.BoundingGraphics.IsColumn)
				{
					class2.Add(class6);
					@class.Add(class6.BoundingGraphics);
				}
				else
				{
					class2.Add(method_34(class6, @class));
				}
			}
			else
			{
				method_37(item, class2, @class);
			}
		}
		class2.Parent = base.Parent;
		return class2;
	}

	private Class4781 method_34(Class4781 curCell, Class4857 result)
	{
		Class4857 @class = smethod_10(curCell.BoundingBox, IsColumnwise);
		@class.HasBoundary = false;
		Class4781 class2 = new Class4781(@class);
		result.Add(@class);
		class2.Add(curCell);
		@class.Add(curCell.BoundingGraphics);
		return class2;
	}

	private void method_35()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class4845 @class = (Class4845)enumerator.Current;
				if (@class.Value is Class4781)
				{
					continue;
				}
				Class4846 class2 = (IsColumnwise ? method_16(@class, 0.5f, 0f) : method_19(@class, 0f, 0.5f));
				class2.Remove(smethod_7(@class, IsColumnwise, class2));
				if (class2.method_3() || !(@class.Value is Class4780 class3))
				{
					continue;
				}
				foreach (Class4845 item in class2)
				{
					class3.Add(item.Value);
					item.Remove();
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

	private static Class4846 smethod_7(Class4845 elPtr, bool isColumnwise, Class4846 neighbors)
	{
		Class4846 @class = new Class4846();
		foreach (Class4845 neighbor in neighbors)
		{
			if (isColumnwise ? Class4778.smethod_23(neighbor.Value, elPtr.Value) : Class4778.smethod_25(neighbor.Value, elPtr.Value))
			{
				@class.Add(neighbor);
			}
		}
		return @class;
	}

	private RectangleF method_36(RectangleF childBox)
	{
		if (IsColumnwise)
		{
			childBox.Height = BoundingBox.Height;
			childBox.Location = new PointF(childBox.Location.X, BoundingBox.Location.Y);
		}
		else
		{
			childBox.Width = BoundingBox.Width;
			childBox.Location = new PointF(BoundingBox.Location.X, childBox.Location.Y);
		}
		return childBox;
	}

	private static void smethod_8(Class4785 block, Class4780 parent)
	{
		ArrayList arrayList = Class4805.smethod_2(block, splitLargeInterval: false);
		Class4786 @class = new Class4786();
		foreach (Class4785 item in arrayList)
		{
			@class.Add(item);
		}
		Class4807 class2 = new Class4807(@class);
		@class.Add(class2.TargetSpace);
		Class4809.smethod_0(@class);
		foreach (Class4845 item2 in @class)
		{
			parent.Add(item2.Value);
		}
	}

	private static float smethod_9(RectangleF a, RectangleF b)
	{
		return RectangleF.Intersect(a, new RectangleF(b.X, a.Y, b.Width, a.Height)).Width;
	}

	private void method_37(Class4845 elPtr, Class4781 main, Class4857 result)
	{
		if (class4781_0 != null && elPtr.Value is Class4785)
		{
			float num = smethod_9(class4781_0.BoundingBox, elPtr.Value.BoundingBox);
			if (num > 1f)
			{
				foreach (Class4845 item in elPtr.Value)
				{
					class4781_0.Add(item.Value);
				}
				return;
			}
		}
		RectangleF bbox = method_36(elPtr.Value.BoundingBox);
		Class4857 class2 = smethod_10(bbox, IsColumnwise);
		class2.HasBoundary = false;
		Class4781 class3 = new Class4781(class2);
		result.Add(class2);
		if (elPtr.Value is Class4785)
		{
			Class4785 block = (Class4785)elPtr.Value;
			smethod_8(block, class3);
		}
		else if (elPtr.Value is Class4782)
		{
			Class4782 class4 = new Class4782(isColumnwise: true);
			class4.Parent = elPtr.Value.Parent;
			foreach (Class4845 item2 in elPtr.Value)
			{
				if (item2.Value is Class4785 block2)
				{
					smethod_8(block2, class4);
				}
				else
				{
					class4.Add(item2.Value);
				}
				class3.Add(class4);
			}
		}
		else
		{
			class3.Add(elPtr.Value);
		}
		main.Add(class3);
		class4781_0 = class3;
	}

	private static Class4857 smethod_10(RectangleF bbox, bool isColumn)
	{
		Class4797[] sideArray = new Class4793(bbox).SideArray;
		return new Class4857(sideArray[3], sideArray[0], sideArray[1], sideArray[2], isColumn);
	}

	internal override void vmethod_1(Class6216 targetPage)
	{
		base.vmethod_1(targetPage);
		Class4842.smethod_0(targetPage, BoundingBox, Class4842.color_4);
	}

	internal bool method_38()
	{
		bool result = false;
		if (IsColumnwise)
		{
			{
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Class4845 @class = (Class4845)enumerator.Current;
						if (!(Class4778.smethod_31(@class.Value) >= 1.3f))
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
			}
		}
		return result;
	}

	internal bool method_39()
	{
		bool result = true;
		if (IsColumnwise)
		{
			{
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Class4845 @class = (Class4845)enumerator.Current;
						if (!(Class4778.smethod_31(@class.Value) <= 1.3f))
						{
							result = false;
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
		else
		{
			result = false;
		}
		return result;
	}
}
