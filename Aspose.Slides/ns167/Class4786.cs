using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using ns161;
using ns166;
using ns224;
using ns233;
using ns234;
using ns235;
using ns236;

namespace ns167;

internal class Class4786 : Class4780
{
	internal class Class6179 : Class6176
	{
		private Class4786 class4786_0 = new Class4786();

		private Class4787 class4787_0 = new Class4787();

		private Stack stack_0 = new Stack();

		private float float_0;

		private int int_0;

		private Stack stack_1 = new Stack();

		private Stack stack_2 = new Stack();

		private Class6185 class6185_0 = new Class6185();

		public Class4786 TextSpace => class4786_0;

		public Class4787 GraphicArea => class4787_0;

		public override void vmethod_0(Class6216 page)
		{
			Class6213 @class = new Class6213();
			float_0 = page.Height;
			@class.RenderTransform = new Class6002(1f, 0f, 0f, 1f, 0f, 0f);
			stack_0.Push(@class);
		}

		public override void vmethod_1(Class6216 page)
		{
			class4787_0.Canvas = stack_0.Pop() as Class6213;
		}

		private RectangleF method_0()
		{
			if (stack_2.Count > 0)
			{
				return (RectangleF)stack_2.Peek();
			}
			return RectangleF.Empty;
		}

		public override void vmethod_2(Class6213 canvas)
		{
			if (canvas.Clip != null)
			{
				Class6188 @class = new Class6188();
				canvas.Clip.vmethod_0(@class);
				RectangleF bounds = @class.GraphicsPath.GetBounds(Class6161.smethod_0(method_1()));
				stack_2.Push(bounds);
			}
			if (stack_0.Count == 1)
			{
				((Class6213)stack_0.Peek()).Add(canvas);
			}
			stack_0.Push(canvas);
			stack_1.Push((canvas.RenderTransform != null) ? canvas.RenderTransform : new Class6002(1f, 0f, 0f, 1f, 0f, 0f));
		}

		public override void vmethod_11(Class6220 image)
		{
			if (Class4860.Instance.Options.UserAgent == Enum678.const_1 && Class4860.Instance.Options.Mode == Enum676.const_0)
			{
				Class6213 @class = new Class6213();
				@class.Add(image);
				@class.RenderTransform = method_1();
				class4786_0.list_0.Add(new Class4850(int.Parse(image.Id), class6185_0.method_2(@class)));
			}
		}

		public override void vmethod_3(Class6213 canvas)
		{
			if (canvas.Clip != null && stack_2.Count > 0)
			{
				stack_2.Pop();
			}
			stack_0.Pop();
			if (stack_1.Count > 0)
			{
				stack_1.Pop();
			}
		}

		public override bool vmethod_19(Class6215 group)
		{
			for (int i = 0; i < group.Count; i++)
			{
				if (group[i] is Class6220 source)
				{
					TextSpace.Add(new Class4790(source, ++int_0));
				}
			}
			return true;
		}

		private Class6002 method_1()
		{
			Class6002 @class = new Class6002(1f, 0f, 0f, 1f, 0f, 0f);
			foreach (Class6002 item in stack_1)
			{
				@class.method_9(item, MatrixOrder.Append);
			}
			return @class;
		}

		public override void vmethod_5(Class6217 path)
		{
			Class6188 @class = new Class6188();
			path.vmethod_0(@class);
			Class6002 class2 = method_1();
			class2.method_9(new Class6002(1f, 0f, 0f, -1f, 0f, float_0), MatrixOrder.Append);
			RectangleF bounds = @class.GraphicsPath.GetBounds(Class6161.smethod_0(class2));
			Class5998 color = Class5998.class5998_7;
			if (path.Pen != null && path.Pen.Brush is Class5997)
			{
				color = ((Class5997)path.Pen.Brush).Color;
			}
			else if (path.Brush != null && path.Brush is Class5997)
			{
				color = ((Class5997)path.Brush).Color;
			}
			if (bounds.Height <= 5f)
			{
				if (bounds.Height == 0f)
				{
					bounds.Height = 1f;
				}
				RectangleF a = method_0();
				if (a.IsEmpty)
				{
					class4786_0.Lines.Add(new Class4849(path, bounds, color));
				}
				else
				{
					RectangleF rect = RectangleF.Intersect(a, bounds);
					if (!rect.IsEmpty)
					{
						class4786_0.Lines.Add(new Class4849(path, rect, color));
					}
				}
			}
			if (stack_0.Count == 1)
			{
				((Class6213)stack_0.Peek()).Add(path);
			}
			GraphicArea.method_1(path, ++int_0);
		}
	}

	internal class Class4850
	{
		private int int_0;

		private RectangleF rectangleF_0;

		internal int Id => int_0;

		internal RectangleF Rect => rectangleF_0;

		public Class4850(int id, RectangleF rect)
		{
			int_0 = id;
			rectangleF_0 = rect;
		}
	}

	internal class Class4849
	{
		private Class6217 class6217_0;

		private RectangleF rectangleF_0;

		private Class5998 class5998_0;

		internal Class5998 Color => class5998_0;

		internal Class6217 Path => class6217_0;

		internal RectangleF Rect => rectangleF_0;

		internal Class4849(Class6217 path, RectangleF rect, Class5998 color)
		{
			class6217_0 = path;
			rectangleF_0 = rect;
			class5998_0 = color;
		}
	}

	private ArrayList arrayList_0 = new ArrayList();

	private List<Class4850> list_0 = new List<Class4850>();

	public ArrayList Lines
	{
		get
		{
			return arrayList_0;
		}
		set
		{
			arrayList_0 = value;
		}
	}

	public List<Class4850> ImgesRects => list_0;

	internal override float InsideTextDistance
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	internal Class4786()
	{
	}

	internal bool method_33(Class4791 prev, Class4791 current)
	{
		return Class4844.smethod_0(prev.Font, current.Font) && Class4844.smethod_1(prev.BoundingBox, current.BoundingBox, current.Font);
	}

	internal Class4786(Class6216 parentPage, Enum676 mode)
		: this(parentPage, mode, new ArrayList(), new List<Class4850>(), recognizeUnderlineAndStrikeout: false)
	{
	}

	private RectangleF method_34(Class4791 text)
	{
		float ascentPoints = text.Font.AscentPoints;
		return new RectangleF(text.BoundingBox.X, text.BoundingBox.Y - ascentPoints, text.BoundingBox.Width, text.BoundingBox.Height);
	}

	internal Class4786(Class6216 parentPage, Enum676 mode, ArrayList lines, List<Class4850> images, bool recognizeUnderlineAndStrikeout)
	{
		arrayList_0 = lines;
		list_0 = images;
		ArrayList arrayList = new ArrayList();
		Class4851 @class = new Class4851();
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < parentPage.Count; i++)
		{
			Class6204 class2 = parentPage[i];
			if (class2 is Class6219 class3 && smethod_11(class3))
			{
				Class4791 class4 = new Class4791(class3);
				RectangleF rect = ((Class4860.Instance.Options.UserAgent == Enum678.const_1) ? method_34(class4) : class4.BoundingBox);
				arrayList2.Add(new Class4851.Class4856(rect, class4));
				arrayList.Add(class4);
			}
		}
		@class.method_0(arrayList2);
		foreach (Class4850 item in list_0)
		{
			ArrayList arrayList3 = new ArrayList();
			@class.method_1(item.Rect, arrayList3);
			foreach (Class4791 item2 in arrayList3)
			{
				if (item.Id > item2.Id && item2.BoundingBox.Left >= item.Rect.Left && item2.BoundingBox.Width <= item.Rect.Width && item2.BoundingBox.Top >= item.Rect.Top && item2.BoundingBox.Height <= item.Rect.Height)
				{
					item2.IsInvisible = true;
				}
			}
		}
		if (recognizeUnderlineAndStrikeout)
		{
			foreach (Class4849 line in Lines)
			{
				ArrayList arrayList4 = new ArrayList();
				@class.method_1(line.Rect, arrayList4);
				float num = 0f;
				float num2 = 0f;
				ArrayList arrayList5 = new ArrayList();
				int num3 = 0;
				foreach (Class4791 item3 in arrayList4)
				{
					RectangleF a = ((Class4860.Instance.Options.UserAgent == Enum678.const_1) ? method_34(item3) : item3.BoundingBox);
					if ((double)(RectangleF.Intersect(a, line.Rect).Width / item3.BoundingBox.Width) >= 0.9 && item3.Color == line.Color)
					{
						arrayList5.Add(item3);
						num2 = ((num3++ == 0) ? item3.BoundingBox.Left : Math.Min(num2, item3.BoundingBox.Left));
						num = Math.Max(num, item3.BoundingBox.Right);
					}
				}
				float num4 = num - num2;
				float num5 = Math.Max(num4, line.Rect.Width) / Math.Min(num4, line.Rect.Width);
				if ((Class4860.Instance.Options.UserAgent != Enum678.const_1 || !(Math.Abs(num4 - line.Rect.Width) <= 3f)) && (Class4860.Instance.Options.UserAgent == Enum678.const_1 || !(num5 <= 1.2f)))
				{
					continue;
				}
				bool flag = true;
				foreach (Class4791 item4 in arrayList5)
				{
					RectangleF boundingBox = item4.BoundingBox;
					RectangleF a2 = ((Class4860.Instance.Options.UserAgent == Enum678.const_1) ? new RectangleF(boundingBox.X, boundingBox.Y, boundingBox.Width, 2f) : RectangleF.FromLTRB(boundingBox.Left, boundingBox.Bottom - 2f, boundingBox.Right, boundingBox.Bottom));
					bool flag2 = !RectangleF.Intersect(a2, line.Rect).IsEmpty;
					RectangleF a3 = ((Class4860.Instance.Options.UserAgent == Enum678.const_1) ? new RectangleF(boundingBox.X, boundingBox.Y - boundingBox.Height - 2f, boundingBox.Width, 1f) : RectangleF.FromLTRB(boundingBox.Left, boundingBox.Top, boundingBox.Right, boundingBox.Top + 2f));
					bool flag3 = !RectangleF.Intersect(a3, line.Rect).IsEmpty;
					short num6 = (short)item4.Font.Style;
					if (item4.Font != null)
					{
						if (flag2)
						{
							num6 = (short)(num6 | 4);
							flag = true;
						}
						else if (!flag3)
						{
							num6 = (short)(num6 | 8);
							flag = true;
						}
						else
						{
							flag = false;
						}
						if (((uint)item4.Font.StyleEx & 8u) != 0)
						{
							num6 = (short)(num6 & -9);
							num6 = (short)(num6 | 0x10);
						}
						Class5999 font = new Class5999(item4.Font.SizePoints, item4.Font.Style, item4.Font.TrueTypeFont)
						{
							StyleEx = num6
						};
						Class6219 class9 = item4.method_2();
						item4.method_3(new Class6219(font, class9.Color, class9.OutlineColor, class9.Origin, class9.Text, class9.Size, class9.CharSpace)
						{
							Id = class9.Id
						});
						item4.LineRef = line;
					}
				}
				if (flag)
				{
					line.Path.Clear();
				}
			}
		}
		Class4784 class10 = null;
		foreach (Class4791 item5 in arrayList)
		{
			if (item5.Text.Length == 0)
			{
				continue;
			}
			if (item5.Text.Trim(' ').Length > 0)
			{
				ArrayList arrayList6 = new ArrayList();
				@class.method_1(RectangleF.FromLTRB(item5.BoundingBox.Left, item5.BoundingBox.Top, item5.BoundingBox.Right, item5.BoundingBox.Bottom), arrayList6);
				if (arrayList6.Count > 1)
				{
					foreach (Class4791 item6 in arrayList6)
					{
						string text = item5.Text.Trim(' ');
						string text2 = item6.Text.Trim(' ');
						if (text.Length > 0 && text2.Length > 0 && item5 != item6 && method_33(item5, item6) && text.IndexOf(text2) != -1)
						{
							item6.method_5();
						}
					}
				}
			}
			if (mode == Enum676.const_0)
			{
				class4844_0.Add(item5, optimizeTextPieceInsertion: true);
			}
			if (mode == Enum676.const_1)
			{
				if (class10 == null)
				{
					class10 = new Class4784(item5);
				}
				else if (Class4778.smethod_12(class10.BoundingBox, item5.BoundingBox) > 0.5f && (class10.BoundingBox.Left < item5.BoundingBox.Left || Class4860.Instance.Options.UserAgent == Enum678.const_0))
				{
					class10.Add(item5);
				}
				else
				{
					if (class10.ChildrenCount > 1)
					{
						class4844_0.Add(class10, optimizeTextPieceInsertion: true);
					}
					else
					{
						class4844_0.Add(class10[0], optimizeTextPieceInsertion: true);
					}
					class10 = new Class4784(item5);
				}
			}
			if (string.IsNullOrEmpty(item5.Text))
			{
				class4844_0.Remove(item5);
			}
		}
		if (mode == Enum676.const_1 && class10 != null)
		{
			if (class10.ChildrenCount > 1)
			{
				class4844_0.Add(class10, optimizeTextPieceInsertion: true);
			}
			else
			{
				class4844_0.Add(class10[0], optimizeTextPieceInsertion: true);
			}
		}
	}

	internal static Class6179 smethod_7(Class6216 parentPage)
	{
		Class6179 @class = new Class6179();
		parentPage.vmethod_0(@class);
		return @class;
	}

	internal static Class4786 smethod_8(Class6216 parentPage)
	{
		Class4786 @class = new Class4786();
		Class6212 class2 = parentPage;
		if (class2.Count > 0 && class2[0] is Class6213)
		{
			class2 = class2[0] as Class6212;
		}
		for (int i = 0; i < class2.Count; i++)
		{
			Class6204 class3 = class2[i];
			Class6220 class4 = class3 as Class6220;
			if (class4 != null)
			{
				if (class4.Bounds.IsEmpty)
				{
					class4 = smethod_10(class4);
				}
				@class.Add(new Class4790(class4));
			}
		}
		return @class;
	}

	private static ImageFormat smethod_9(Enum788 imageType)
	{
		return imageType switch
		{
			Enum788.const_1 => ImageFormat.Emf, 
			Enum788.const_2 => ImageFormat.Wmf, 
			Enum788.const_4 => ImageFormat.Jpeg, 
			Enum788.const_5 => ImageFormat.Png, 
			Enum788.const_6 => ImageFormat.Bmp, 
			Enum788.const_7 => ImageFormat.Gif, 
			Enum788.const_8 => ImageFormat.Tiff, 
			_ => ImageFormat.Png, 
		};
	}

	private static Class6220 smethod_10(Class6220 image)
	{
		bool flag = image.Size.Width < 0f;
		bool flag2 = image.Size.Height < 0f;
		RotateFlipType rotateFlipType = RotateFlipType.RotateNoneFlipNone;
		if (flag && flag2)
		{
			rotateFlipType = RotateFlipType.Rotate180FlipNone;
		}
		else if (flag2)
		{
			rotateFlipType = RotateFlipType.Rotate180FlipX;
		}
		else if (flag)
		{
			rotateFlipType = RotateFlipType.RotateNoneFlipX;
		}
		if (rotateFlipType == RotateFlipType.RotateNoneFlipNone)
		{
			return image;
		}
		using Image image2 = Image.FromStream(new MemoryStream(image.ImageBytes));
		image2.RotateFlip(rotateFlipType);
		using MemoryStream memoryStream = new MemoryStream();
		image2.Save(memoryStream, smethod_9(image.ImageType));
		return new Class6220(image.Origin, new SizeF(Math.Abs(image.Size.Width), Math.Abs(image.Size.Height)), memoryStream.ToArray());
	}

	internal void Add(Class4786 textSpace)
	{
		for (int i = 0; i < textSpace.LineCount; i++)
		{
			for (int j = 0; j < textSpace[i].PageElementCount; j++)
			{
				Add(textSpace[i][j]);
			}
		}
	}

	private static bool smethod_11(Class6219 curPageObj)
	{
		if (curPageObj.Size.Width != 0f)
		{
			return curPageObj.Text != "\u00a0";
		}
		return false;
	}
}
