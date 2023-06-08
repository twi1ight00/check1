using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns224;
using ns235;

namespace ns201;

internal class Class6182 : Class6176
{
	public class Class6183 : Class6176
	{
		private Dictionary<Class6204, bool> dictionary_0;

		private Class6216 class6216_0;

		private Stack<Class6212> stack_0 = new Stack<Class6212>();

		public Class6216 Page => class6216_0;

		public Class6183(Dictionary<Class6204, bool> ignoreFromSplitting)
		{
			dictionary_0 = ignoreFromSplitting;
		}

		private void method_0(Class6204 node)
		{
			if (!dictionary_0.ContainsKey(node))
			{
				stack_0.Peek().Add(node);
			}
		}

		public override void vmethod_0(Class6216 page)
		{
			class6216_0 = new Class6216(page.Width, page.Height);
			stack_0.Push(class6216_0);
		}

		public override void vmethod_2(Class6213 canvas)
		{
			Class6213 @class = new Class6213();
			if (!dictionary_0.ContainsKey(canvas))
			{
				@class.RenderTransform = canvas.RenderTransform;
				@class.Clip = canvas.Clip;
				stack_0.Peek().Add(@class);
			}
			stack_0.Push(@class);
		}

		public override void vmethod_3(Class6213 canvas)
		{
			stack_0.Pop();
		}

		public override void vmethod_4(Class6219 glyphs)
		{
			method_0(glyphs);
		}

		public override void vmethod_5(Class6217 path)
		{
			Class6217 @class = new Class6217();
			if (!dictionary_0.ContainsKey(path))
			{
				@class.RenderTransform = @class.RenderTransform;
				@class.Clip = @class.Clip;
				@class.Brush = path.Brush;
				@class.FillMode = path.FillMode;
				stack_0.Peek().Add(@class);
			}
			stack_0.Push(@class);
		}

		public override void vmethod_6(Class6217 path)
		{
			stack_0.Pop();
		}

		public override void vmethod_7(Class6218 pathFigure)
		{
			Class6218 @class = new Class6218();
			if (!dictionary_0.ContainsKey(pathFigure))
			{
				@class.IsClosed = pathFigure.IsClosed;
				stack_0.Peek().Add(@class);
			}
			stack_0.Push(@class);
		}

		public override void vmethod_8(Class6218 pathFigure)
		{
			stack_0.Pop();
		}

		public override void vmethod_9(Class6223 segment)
		{
			method_0(segment);
		}

		public override void vmethod_10(Class6222 segment)
		{
			method_0(segment);
		}

		public override void vmethod_11(Class6220 image)
		{
			method_0(image);
		}

		public override void vmethod_12(Class6211 bookmark)
		{
			method_0(bookmark);
		}

		public override void vmethod_13(Class6221 bookmark)
		{
			method_0(bookmark);
		}

		public override void vmethod_14(Class6210 field)
		{
			method_0(field);
		}

		public override void vmethod_15(Class6207 field)
		{
			method_0(field);
		}

		public override void vmethod_16(Class6209 field)
		{
			method_0(field);
		}

		public override void vmethod_17(Class6208 field)
		{
			method_0(field);
		}

		public override void vmethod_18(Class6206 field)
		{
			method_0(field);
		}

		public override bool vmethod_19(Class6215 group)
		{
			method_0(group);
			return true;
		}
	}

	internal class Class5348
	{
		private Class6213 class6213_0;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		public Class6213 Canvas
		{
			get
			{
				return class6213_0;
			}
			set
			{
				class6213_0 = value;
			}
		}

		public bool Ignore => bool_0;

		public bool IsPath
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
			}
		}

		public bool IsLink
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		public Class5348(Class6213 canvas, bool ignore, bool isLink, bool isPath)
		{
			class6213_0 = canvas;
			bool_0 = ignore;
			bool_1 = isLink;
			bool_2 = isPath;
		}
	}

	private const byte byte_0 = 5;

	private Class6216 class6216_0;

	private ArrayList arrayList_0 = new ArrayList();

	private RectangleF rectangleF_0 = RectangleF.Empty;

	private Stack stack_0 = new Stack();

	private Dictionary<Class6204, bool> dictionary_0;

	public Class6182(Dictionary<Class6204, bool> ignoreFromSplitting)
	{
		dictionary_0 = ignoreFromSplitting;
	}

	public void method_0(ArrayList pages, RectangleF marginRect)
	{
		rectangleF_0 = marginRect;
		if (pages.Count == 0)
		{
			return;
		}
		float num = 0f;
		Class6216 @class = (Class6216)pages[0];
		Class6216 class2 = new Class6216(@class.Width, @class.Height);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < pages.Count; i++)
		{
			Class6216 class3 = (Class6216)pages[i];
			RectangleF rectangleF;
			if (dictionary_0.Count > 0)
			{
				Class6183 class4 = new Class6183(dictionary_0);
				class3.vmethod_0(class4);
				rectangleF = smethod_2(class4.Page);
			}
			else
			{
				rectangleF = smethod_2(class3);
			}
			if (rectangleF.Bottom <= class3.Height && class2.Count == 0)
			{
				arrayList.Add(class3);
				continue;
			}
			for (int j = 0; j < class3.Count; j++)
			{
				Class6213 class5 = new Class6213();
				class5.Add(class3[j]);
				class2.Add(class5);
				class5.RenderTransform = new Class6002(1f, 0f, 0f, 1f, 0f, num);
			}
			num += rectangleF.Height;
		}
		if (class2.Count > 0)
		{
			class2.vmethod_0(this);
			method_2(arrayList, new SizeF(class6216_0.Width, class6216_0.Height));
		}
		pages.Clear();
		pages.AddRange(arrayList);
	}

	internal static Class6270 smethod_0(Class6270 link, RectangleF activeRect)
	{
		if (link.JumpType != 0)
		{
			if (link.JumpType == Enum803.const_7)
			{
				return new Class6270(activeRect, link.Page);
			}
			return new Class6270(activeRect, link.JumpType);
		}
		return new Class6270(activeRect, link.Target);
	}

	private Class6213 method_1(Class6213 canvas)
	{
		Class6213 @class = method_4(canvas);
		Class6213 class2 = @class;
		for (int i = 0; i < canvas.Count; i++)
		{
			if (canvas[i] is Class6213)
			{
				class2.Add(method_1(canvas[i] as Class6213));
			}
			else
			{
				class2.Add(canvas[i]);
			}
		}
		return @class;
	}

	private static Class6213 smethod_1(Class6213 canvas)
	{
		Class6213 @class = new Class6213();
		if (canvas.RenderTransform != null)
		{
			@class.RenderTransform = canvas.RenderTransform.Clone();
		}
		@class.Clip = canvas.Clip;
		for (int i = 0; i < canvas.Count; i++)
		{
			@class.Add(canvas[i]);
		}
		return @class;
	}

	public override void vmethod_0(Class6216 page)
	{
		class6216_0 = new Class6216(page.Width, page.Height);
		stack_0.Push(class6216_0);
	}

	private void method_2(ArrayList apsPages, SizeF pageSize)
	{
		bool flag = true;
		while (arrayList_0.Count > 0)
		{
			class6216_0 = new Class6216(pageSize.Width, pageSize.Height);
			ArrayList arrayList = new ArrayList();
			float num = 0f;
			ArrayList arrayList2 = new ArrayList();
			foreach (Class5348 item in arrayList_0)
			{
				Class6213 class2 = method_1(item.Canvas);
				arrayList2.Add(new Class5348(class2, item.Ignore, item.IsLink, item.IsPath));
				if (class2.RenderTransform == null)
				{
					class2.RenderTransform = new Class6002();
				}
				if (!flag)
				{
					class2.RenderTransform.method_8(0f, 0f - rectangleF_0.Height + rectangleF_0.Top);
				}
				RectangleF rectangleF = smethod_2(class2);
				arrayList.Add(rectangleF);
				if (!item.Ignore && !item.IsLink && rectangleF.Top <= rectangleF_0.Bottom && rectangleF.Bottom > rectangleF_0.Bottom && rectangleF.Height <= rectangleF_0.Height)
				{
					float num2 = rectangleF_0.Bottom - rectangleF.Top;
					if (!item.IsPath || (double)(num2 / rectangleF_0.Height) < 0.3)
					{
						num = Math.Max(num, num2);
					}
				}
			}
			float num3 = rectangleF_0.Bottom - num - 1f;
			int i;
			for (i = 0; i < arrayList.Count; i++)
			{
				RectangleF rectangleF2 = (RectangleF)arrayList[i];
				Class5348 class3 = (Class5348)arrayList_0[i];
				if (!class3.Ignore && !class3.IsLink && rectangleF2.Top <= num3 && rectangleF2.Bottom > num3 && rectangleF2.Height <= rectangleF_0.Height && num3 - rectangleF2.Top < 5f)
				{
					num = Math.Max(num, num3 - rectangleF2.Top);
				}
			}
			i = 0;
			arrayList_0.Clear();
			float num4 = rectangleF_0.Bottom - num;
			foreach (Class5348 item2 in arrayList2)
			{
				RectangleF rectangleF3 = (RectangleF)arrayList[i++];
				if (rectangleF3.Top >= num4 && rectangleF3.Height <= rectangleF_0.Height)
				{
					arrayList_0.Add(new Class5348(item2.Canvas, item2.Ignore, item2.IsLink, item2.IsPath));
					item2.Canvas.RenderTransform.method_8(0f, num);
				}
				else if ((!item2.Ignore && rectangleF3.Height > rectangleF_0.Height) || item2.IsLink)
				{
					Class6213 topParentCanvas = smethod_1(item2.Canvas);
					if (rectangleF3.Bottom > num4)
					{
						arrayList_0.Add(new Class5348(item2.Canvas, ignore: false, item2.IsLink, item2.IsPath));
						item2.Canvas.RenderTransform.method_8(0f, num);
					}
					method_3(topParentCanvas);
				}
				else
				{
					class6216_0.Add(item2.Canvas);
				}
			}
			apsPages.Add(class6216_0);
			flag = false;
		}
	}

	private void method_3(Class6213 topParentCanvas)
	{
		Class6218 @class = new Class6218();
		@class.method_3(new RectangleF(0f, rectangleF_0.Y, class6216_0.Width, rectangleF_0.Height));
		Class6213 class2 = new Class6213();
		Class6217 class3 = new Class6217();
		class3.Add(@class);
		class2.Clip = class3;
		class2.Add(topParentCanvas);
		class6216_0.Add(class2);
	}

	public override void vmethod_1(Class6216 page)
	{
		stack_0.Pop();
	}

	private Class6213 method_4(Class6213 src)
	{
		Class6213 @class = new Class6213();
		if (src.RenderTransform != null)
		{
			@class.RenderTransform = src.RenderTransform.Clone();
		}
		if (src.Clip != null)
		{
			@class.Clip = src.Clip;
			if (src.Clip.RenderTransform != null)
			{
				@class.Clip.RenderTransform = src.Clip.RenderTransform.Clone();
			}
		}
		return @class;
	}

	public override void vmethod_2(Class6213 canvas)
	{
		Class6213 @class = method_4(canvas);
		((Class6212)stack_0.Peek()).Add(@class);
		stack_0.Push(@class);
	}

	public override void vmethod_3(Class6213 canvas)
	{
		stack_0.Pop();
	}

	internal static RectangleF smethod_2(Class6204 node)
	{
		Class6185 @class = new Class6185();
		return @class.method_2(node);
	}

	private Class6213 method_5()
	{
		Class6213 @class = new Class6213();
		if (stack_0.Count > 1)
		{
			object[] array = stack_0.ToArray();
			for (int num = array.Length - 2; num >= 0; num--)
			{
				Class6213 class2 = method_4((Class6213)array[num]);
				@class.Add(class2);
				@class = class2;
			}
		}
		return @class;
	}

	private Class6213 method_6(Class6204 parent)
	{
		if (parent.Parent == null)
		{
			return (Class6213)parent;
		}
		return method_6(parent.Parent);
	}

	private Class6213 method_7(Class6213 canvas)
	{
		if (canvas.Count == 0)
		{
			return null;
		}
		if (!(canvas[0] is Class6213 @class))
		{
			return canvas;
		}
		Class6213 class2 = method_7(@class);
		if (class2 == null)
		{
			return null;
		}
		canvas.Remove(@class);
		if (class2.Clip == null)
		{
			if (class2.RenderTransform != null)
			{
				if (canvas.RenderTransform == null)
				{
					canvas.RenderTransform = new Class6002();
				}
				canvas.RenderTransform.method_9(class2.RenderTransform, MatrixOrder.Prepend);
				for (int i = 0; i < class2.Count; i++)
				{
					canvas.Add(class2[i]);
				}
			}
		}
		else
		{
			canvas.Add(class2);
		}
		return canvas;
	}

	private void method_8(Class6204 node)
	{
		Class6213 @class = method_5();
		@class.Add(node);
		Class6213 canvas = method_6(@class);
		Class6213 class2 = method_7(canvas);
		if (class2 != null)
		{
			Class6213 class3 = new Class6213();
			class3.Add(class2);
			canvas = class3;
			arrayList_0.Add(new Class5348(canvas, dictionary_0.ContainsKey(node), node is Class6217 && ((Class6217)node).Hyperlink != null, node is Class6217));
		}
	}

	public override void vmethod_4(Class6219 glyphs)
	{
		method_8(glyphs);
	}

	public override void vmethod_6(Class6217 path)
	{
		method_8(path);
	}

	public override void vmethod_11(Class6220 image)
	{
		method_8(image);
	}

	public override void vmethod_12(Class6211 bookmark)
	{
		method_8(bookmark);
	}

	public override void vmethod_13(Class6221 outlineItem)
	{
		method_8(outlineItem);
	}

	public override void vmethod_14(Class6210 field)
	{
		method_8(field);
	}

	public override void vmethod_15(Class6207 field)
	{
		method_8(field);
	}

	public override void vmethod_16(Class6209 field)
	{
		method_8(field);
	}

	public override void vmethod_17(Class6208 field)
	{
		method_8(field);
	}

	public override void vmethod_18(Class6206 field)
	{
		method_8(field);
	}

	public override bool vmethod_19(Class6215 group)
	{
		method_8(group);
		return true;
	}
}
