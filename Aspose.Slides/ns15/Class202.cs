using System.Collections.Generic;
using System.Drawing;
using ns60;
using ns62;

namespace ns15;

internal class Class202
{
	private Class854 class854_0;

	private List<Class2623> list_0;

	private Struct14[] struct14_0;

	private Struct14[] struct14_1;

	private Struct14[] struct14_2;

	private Struct14[] struct14_3;

	private bool bool_0 = true;

	private Rectangle rectangle_0;

	private SortedList<int, object> sortedList_0 = new SortedList<int, object>();

	private SortedList<int, object> sortedList_1 = new SortedList<int, object>();

	private int int_0;

	private int int_1;

	internal Struct14[] TableCells => struct14_0;

	internal Struct14[] VerticalLines => struct14_1;

	internal Struct14[] HorisontalLines => struct14_2;

	internal Struct14[] DiagonalLines => struct14_3;

	internal int ColumnsCount => int_0;

	internal int RowsCount => int_1;

	internal Rectangle TableRectangle => rectangle_0;

	internal Class854 DeserializationContext => class854_0;

	internal int method_0(int index)
	{
		if (index >= 0 && index <= int_0 - 1)
		{
			return sortedList_0.Keys[index + 1] - sortedList_0.Keys[index];
		}
		return -1;
	}

	internal int method_1(int index)
	{
		if (index >= 0 && index <= int_1 - 1)
		{
			return sortedList_1.Keys[index + 1] - sortedList_1.Keys[index];
		}
		return -1;
	}

	internal Class202(Class2671 shapesGroup, Class854 slideDeserializationContext)
	{
		class854_0 = slideDeserializationContext;
		list_0 = shapesGroup.Records;
		if (list_0[0] is Class2670 @class)
		{
			if (@class.ShapeGroup == null)
			{
				bool_0 = false;
			}
			if (@class.ClientAnchor == null)
			{
				bool_0 = false;
			}
			else
			{
				rectangle_0 = @class.ClientAnchor.Rectangle;
			}
		}
		else
		{
			bool_0 = false;
		}
		if (bool_0)
		{
			method_3();
		}
	}

	internal Rectangle method_2(Rectangle shapeRect)
	{
		int num = sortedList_0.IndexOfKey(shapeRect.X);
		int num2 = sortedList_1.IndexOfKey(shapeRect.Y);
		int i = 0;
		int j = 0;
		int num3 = shapeRect.X + shapeRect.Width;
		int num4 = shapeRect.Y + shapeRect.Height;
		for (; sortedList_0.Keys[num + i] < num3; i++)
		{
		}
		for (; sortedList_1.Keys[num2 + j] < num4; j++)
		{
		}
		return new Rectangle(num, num2, i, j);
	}

	private void method_3()
	{
		List<Struct14> list = new List<Struct14>();
		List<Struct14> list2 = new List<Struct14>();
		List<Struct14> list3 = new List<Struct14>();
		List<Struct14> list4 = new List<Struct14>();
		int num = 0;
		int num2 = 0;
		int count = list_0.Count;
		for (int i = 1; i < count; i++)
		{
			if (!(list_0[i] is Class2670 @class))
			{
				continue;
			}
			Enum425 shapeType = @class.ShapeProp.ShapeType;
			Rectangle rectangle = ((@class.ChildAnchor == null) ? @class.ClientAnchor.Rectangle : @class.ChildAnchor.Rectangle);
			Struct14 item = default(Struct14);
			item.class2670_0 = @class;
			item.rectangle_0 = rectangle;
			switch (shapeType)
			{
			case Enum425.const_20:
				if (rectangle.Width != 0)
				{
					if (rectangle.Height != 0)
					{
						list4.Add(item);
					}
					else
					{
						list2.Add(item);
					}
				}
				else
				{
					list3.Add(item);
				}
				break;
			case Enum425.const_1:
			case Enum425.const_202:
				sortedList_0[rectangle.X] = null;
				sortedList_1[rectangle.Y] = null;
				if (rectangle.X + rectangle.Width > num)
				{
					num = rectangle.X + rectangle.Width;
				}
				if (rectangle.Y + rectangle.Height > num2)
				{
					num2 = rectangle.Y + rectangle.Height;
				}
				list.Add(item);
				break;
			}
		}
		rectangle_0 = new Rectangle(sortedList_0.Keys[0], sortedList_1.Keys[0], num - sortedList_0.Keys[0], num2 - sortedList_1.Keys[0]);
		int_0 = sortedList_0.Count;
		int_1 = sortedList_1.Count;
		sortedList_0[num] = null;
		sortedList_1[num2] = null;
		struct14_0 = list.ToArray();
		struct14_1 = list3.ToArray();
		struct14_2 = list2.ToArray();
		struct14_3 = list4.ToArray();
	}
}
