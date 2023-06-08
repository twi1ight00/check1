using System;
using System.Collections;
using System.Drawing;
using Aspose.XfaConverter.Elements;
using ns216;
using ns224;
using ns235;

namespace ns215;

internal abstract class Class5916 : Class5914
{
	private readonly XfaEnums.Enum706 enum706_0;

	protected bool bool_0;

	protected bool bool_1;

	protected Class5829 class5829_0;

	protected float float_0;

	protected float float_1;

	protected Interface250 interface250_0;

	internal ArrayList arrayList_0 = new ArrayList();

	private bool bool_2;

	private Class5791 class5791_0;

	private XfaEnums.Enum712 enum712_0;

	private XfaEnums.Enum712 enum712_1;

	private static Stack stack_0 = new Stack();

	internal XfaEnums.Enum706 Type => enum706_0;

	internal Class5791 Break
	{
		get
		{
			return class5791_0;
		}
		set
		{
			class5791_0 = value;
		}
	}

	protected void method_0()
	{
		if (class5829_0 != null)
		{
			float_0 += class5829_0.LeftInset + class5829_0.RightInset;
			float_1 += class5829_0.TopInset + class5829_0.BottomInset;
		}
	}

	internal Class5916(Interface249 nativeObj)
		: base((Interface252)nativeObj)
	{
		interface250_0 = nativeObj as Interface250;
		if (interface250_0 == null)
		{
			throw new ArgumentException();
		}
		bool_0 = interface250_0.H == 0f;
		bool_1 = interface250_0.W == 0f;
		class5829_0 = interface250_0.Margin;
		if (nativeObj == null)
		{
			throw new ArgumentException();
		}
		enum706_0 = nativeObj.LayoutType;
		if (nativeObj is Class5848 @class)
		{
			class5791_0 = @class.method_6(Class5791.Tag) as Class5791;
			if (@class.Nodes.method_3("breakBefore") is Class5793 class2)
			{
				class5791_0 = new Class5791();
				class5791_0.Before = (XfaEnums.Enum688)class2.method_5("targetType").Value;
				class5791_0.BeforeTarget = (string)class2.method_5("target").Value;
			}
			if (@class.method_6(Class5825.Tag) is Class5825 class3)
			{
				enum712_0 = class3.Intact;
				enum712_1 = class3.Next;
			}
		}
	}

	protected float method_1()
	{
		float num = class5829_0.LeftInset + class5829_0.RightInset;
		return ((!bool_1) ? interface250_0.W : ((interface250_0.MaxW == 0f) ? 4.2949673E+09f : interface250_0.MaxW)) - num;
	}

	protected float method_2()
	{
		float num = class5829_0.TopInset + class5829_0.BottomInset;
		return ((!bool_0) ? interface250_0.H : ((interface250_0.MaxH == 0f) ? 4.2949673E+09f : interface250_0.MaxH)) - num;
	}

	protected override SizeF vmethod_0()
	{
		if (bool_2)
		{
			return base.vmethod_0();
		}
		float height = ((!bool_0) ? interface250_0.H : ((float_1 > 0f) ? float_1 : interface250_0.MinH));
		float width = ((!bool_1) ? interface250_0.W : Math.Max(interface250_0.MinW, float_0));
		return new SizeF(width, height);
	}

	internal abstract void vmethod_3();

	internal void method_3(Class5914 element)
	{
		arrayList_0.Add(element);
	}

	internal override Class5914[] vmethod_2(float height, Class5834 page)
	{
		if (base.Size.Height - height <= 1.5f)
		{
			return null;
		}
		bool flag = false;
		Class5791 @break = null;
		Interface250 nativeObj = base.NativeObj;
		Hashtable hashtable = new Hashtable();
		while (height > 0f && !flag)
		{
			if (!(nativeObj.Margin.BottomInset > 0f) || base.Size.Height - nativeObj.Margin.BottomInset <= height)
			{
				flag = true;
				foreach (Class5914 item in arrayList_0)
				{
					if (item.IsHidden)
					{
						continue;
					}
					RectangleF rectangleF = new RectangleF(item.Pos, item.Size);
					Class5916 class2 = item as Class5916;
					if (!(rectangleF.Top < height) || class2 == null || class2.Break == null || class2.Break.Processed || class2.Break.Before != XfaEnums.Enum688.const_2 || (!(class2.Break.BeforeTarget != "#" + page.Id) && !(class2.Break.BeforeTarget != page.Id)))
					{
						if (class2 != null && class2.enum712_1 == XfaEnums.Enum712.const_1)
						{
							Class5914[] value = new Class5914[2] { null, item };
							hashtable[arrayList_0.IndexOf(item)] = value;
							height = 0f;
							class2.enum712_1 = XfaEnums.Enum712.const_0;
						}
						else
						{
							if (!(rectangleF.Top < height) || !(rectangleF.Bottom > height + 1.5f))
							{
								continue;
							}
							if (item.vmethod_1())
							{
								Class5914[] array = item.vmethod_2(height - item.Pos.Y, page);
								if (array != null)
								{
									hashtable[arrayList_0.IndexOf(item)] = array;
									height = item.Pos.Y + array[0].Size.Height;
									continue;
								}
							}
							else if (class2 != null && class2.enum712_0 == XfaEnums.Enum712.const_1)
							{
								Class5914[] array2 = new Class5914[1] { item };
								hashtable[arrayList_0.IndexOf(item)] = array2;
								height = item.Pos.Y + array2[0].Size.Height;
								continue;
							}
							height = rectangleF.Top;
							flag = false;
							break;
						}
						continue;
					}
					height = rectangleF.Top;
					@break = class2.Break;
					break;
				}
				continue;
			}
			height = base.Size.Height - nativeObj.Margin.BottomInset;
			break;
		}
		if (!flag)
		{
			return null;
		}
		Class5916 class3 = Class5929.Instance.method_0((Interface249)base.NativeObj);
		class3.enum712_0 = enum712_0;
		Class5916 class4 = Class5929.Instance.method_0((Interface249)base.NativeObj);
		class4.enum712_0 = enum712_0;
		class4.enum712_1 = enum712_1;
		foreach (Class5914 item2 in arrayList_0)
		{
			if (item2.IsHidden)
			{
				continue;
			}
			RectangleF rectangleF2 = new RectangleF(item2.Pos, item2.Size);
			if (rectangleF2.Top < height && rectangleF2.Bottom > height + 1.5f)
			{
				Class5914[] array3 = (Class5914[])hashtable[arrayList_0.IndexOf(item2)];
				if (array3 != null && array3.Length > 0)
				{
					class3.method_3(array3[0]);
					if (array3.Length > 1)
					{
						class4.method_3(array3[1]);
					}
				}
			}
			else if (rectangleF2.Top < height)
			{
				if (hashtable.Contains(arrayList_0.IndexOf(item2)))
				{
					Class5914[] array4 = (Class5914[])hashtable[arrayList_0.IndexOf(item2)];
					if (array4 != null && array4.Length > 0)
					{
						if (array4[0] != null)
						{
							class3.method_3(array4[0]);
						}
						if (array4.Length > 1)
						{
							class4.method_3(array4[1]);
						}
					}
				}
				else
				{
					class3.method_3(item2);
				}
			}
			else
			{
				item2.Pos = new PointF(item2.Pos.X, item2.Pos.Y - height);
				class4.method_3(item2);
			}
		}
		class3.Pos = base.Pos;
		class3.Size = new SizeF(base.Size.Width, height);
		class3.bool_2 = true;
		class4.Pos = new PointF(base.Pos.X, 0f);
		class4.Size = new SizeF(base.Size.Width, base.Size.Height - height);
		class4.bool_2 = true;
		class4.Break = @break;
		return new Class5914[2] { class3, class4 };
	}

	internal void method_4(Class5925 pageContentProvider)
	{
		pageContentProvider.method_2(this);
	}

	internal void method_5()
	{
	}

	internal override bool vmethod_1()
	{
		return true;
	}

	private static string smethod_0()
	{
		string text = string.Empty;
		foreach (string item in stack_0)
		{
			text = text + item + ".";
		}
		return text;
	}

	internal void method_6(Class5912 builder)
	{
		Class6213 @class = new Class6213();
		@class.RenderTransform = new Class6002(1f, 0f, 0f, 1f, base.Pos.X, base.Pos.Y);
		builder.method_6(@class);
		foreach (Class5914 item in arrayList_0)
		{
			if (!item.IsHidden)
			{
				if (item is Class5915 class3)
				{
					class3.NativeObj.imethod_4(builder, new PointF(0f, 0f), new SizeF(0f, 0f));
				}
				if (item is Class5916 class4)
				{
					class4.method_6(builder);
				}
				if (item is Class5915)
				{
					Class6213 class5 = new Class6213();
					class5.RenderTransform = new Class6002(1f, 0f, 0f, 1f, item.Pos.X, item.Pos.Y);
					builder.method_6(class5);
					((Class5915)item).Layout.method_6(builder);
					builder.method_7();
				}
				else
				{
					item.NativeObj.imethod_4(builder, item.Pos, item.Size);
				}
			}
		}
		builder.method_7();
	}
}
