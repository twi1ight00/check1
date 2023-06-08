using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using ns163;
using ns165;
using ns224;
using ns234;
using ns235;
using ns236;
using ns269;
using ns271;

namespace ns161;

internal class Class4753
{
	internal class Class6177 : Class6176
	{
		private const float float_0 = 2f / 3f;

		private Stack stack_0 = new Stack();

		private Stack stack_1 = new Stack();

		private float float_1;

		internal bool bool_0 = true;

		internal Class4859 class4859_0;

		internal Class6216 class6216_0;

		private Class6215 class6215_0;

		private Stack stack_2 = new Stack();

		private bool bool_1;

		private int int_0;

		public bool TransformImages
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

		public Class6216 method_0(Class6216 page)
		{
			class6215_0 = new Class6215();
			page.vmethod_0(this);
			if (!(stack_0.Pop() is Class6216 result))
			{
				throw new ArgumentException("Structure of ApsPage object is not valid");
			}
			return result;
		}

		public override void vmethod_0(Class6216 page)
		{
			int_0 = 0;
			class6216_0 = new Class6216(page.Width, page.Height);
			stack_0.Push(class6216_0);
			float_1 = page.Height;
		}

		public override void vmethod_1(Class6216 page)
		{
		}

		private RectangleF method_1()
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
				RectangleF bounds = @class.GraphicsPath.GetBounds(Class6161.smethod_0(method_2()));
				stack_2.Push(bounds);
			}
			if (canvas.RenderTransform != null && !bool_1 && canvas.Count == 1 && canvas[0] is Class6220)
			{
				Class6220 class2 = canvas[0] as Class6220;
				canvas.RenderTransform.method_9(new Class6002(1f / class2.Size.Width, 0f, 0f, -1f / class2.Size.Height, 0f, 1f), MatrixOrder.Prepend);
				canvas.RenderTransform.method_9(new Class6002(1f, 0f, 0f, -1f, 0f, float_1), MatrixOrder.Append);
			}
			stack_1.Push((canvas.RenderTransform != null) ? canvas.RenderTransform : new Class6002(1f, 0f, 0f, 1f, 0f, 0f));
			Class6213 class3 = new Class6213();
			class3.RenderTransform = canvas.RenderTransform;
			class3.Clip = canvas.Clip;
			((Class6212)stack_0.Peek()).Add(class3);
			stack_0.Push(class3);
		}

		public override void vmethod_3(Class6213 canvas)
		{
			if (canvas.Clip != null && stack_2.Count > 0)
			{
				stack_2.Pop();
			}
			if (stack_1.Count > 0)
			{
				stack_1.Pop();
			}
			stack_0.Pop();
		}

		private Class6002 method_2()
		{
			Class6002 @class = new Class6002(1f, 0f, 0f, 1f, 0f, 0f);
			foreach (Class6002 item in stack_1)
			{
				@class.method_9(item, MatrixOrder.Append);
			}
			return @class;
		}

		public override void vmethod_4(Class6219 glyphs)
		{
			glyphs.Id = (++int_0).ToString();
			if (glyphs.RenderTransform == null)
			{
				glyphs.RenderTransform = new Class6002(1f, 0f, 0f, -1f, 0f, float_1);
			}
			else
			{
				glyphs.RenderTransform.method_9(new Class6002(1f, 0f, 0f, -1f, 0f, 0f), MatrixOrder.Prepend);
				glyphs.RenderTransform.method_9(new Class6002(1f, 0f, 0f, -1f, 0f, float_1), MatrixOrder.Append);
			}
			Class6002 renderTransform = glyphs.RenderTransform;
			PointF pointF = glyphs.RenderTransform.method_2(glyphs.Origin);
			float sizePoints = (Math.Abs(renderTransform.M11) + Math.Abs(renderTransform.M22)) / 2f * glyphs.Font.SizePoints;
			Class5999 @class = ((!class4859_0.UseEmbeddedTrueTypeFonts || glyphs.Font.TrueTypeFont == null) ? Class6652.Instance.method_1(glyphs.Font.FamilyName, sizePoints, glyphs.Font.Style) : new Class5999(sizePoints, glyphs.Font.Style, glyphs.Font.TrueTypeFont));
			if (@class.SizePoints == 0f)
			{
				return;
			}
			float sizePoints2 = @class.SizePoints;
			if (Class4860.Instance.Options.UserAgent != Enum678.const_1 || Class4860.Instance.Options.Mode != 0)
			{
				float num = (float)Math.Floor(@class.SizePoints);
				float num2 = @class.SizePoints - num;
				if ((double)num2 <= 0.25)
				{
					if (num != 0f)
					{
						@class.SizePoints = num;
					}
					else
					{
						@class.SizePoints = 0.5f;
					}
				}
				else if ((double)num2 <= 0.75)
				{
					@class.SizePoints = num + 0.5f;
				}
				else
				{
					@class.SizePoints = num + 1f;
				}
			}
			bool flag = glyphs.Tag != null && glyphs.Tag.Equals("convertedFont");
			RectangleF a = method_1();
			if (flag)
			{
				if (glyphs.Indices != null)
				{
					Class6265.Class6267 class2 = new Class6265.Class6267(glyphs.Indices);
					float num3 = 0f;
					for (int i = 0; i < class2.method_0(); i++)
					{
						PointF pointF2 = pointF;
						float num4 = 0f;
						float num5 = class2.method_1(i);
						num4 = glyphs.Font.method_4(glyphs.Text[i].ToString()).Width;
						float num6 = class2.method_2(i);
						pointF2 = new PointF(pointF2.X + Math.Abs(renderTransform.M11 * num6) + Math.Abs(renderTransform.M11 * num3), pointF2.Y);
						SizeF sizeF = @class.method_4(glyphs.Text[i].ToString());
						sizeF = new SizeF(Math.Abs(renderTransform.M11 * num4), sizeF.Height);
						if (sizeF.Width == 0f)
						{
							sizeF.Width = renderTransform.M11 * num5;
						}
						if ((a.IsEmpty || !RectangleF.Intersect(a, new RectangleF(pointF2, sizeF)).IsEmpty) && (glyphs.Text[i] != ' ' || sizeF.Width < @class.method_1(' ') || Class4860.Instance.Options.UseNewTextBoxRecognitionAlgorithm))
						{
							string text = glyphs.Text[i].ToString();
							Class6219 class3 = new Class6219(@class, glyphs.Color, glyphs.OutlineColor, pointF2, text, sizeF, glyphs.CharSpace);
							class3.Id = (++int_0).ToString();
							class3.Hyperlink = glyphs.Hyperlink;
							class6216_0.Add(class3);
						}
						num3 += num5;
					}
					return;
				}
				SizeF size = @class.method_4(glyphs.Text);
				if (glyphs.Size.Width != 0f && glyphs.Size.Height != 0f)
				{
					if (size.Width / glyphs.Size.Width > 2f)
					{
						glyphs.Size = size;
					}
					else if (size.Height / glyphs.Size.Height > 2f)
					{
						glyphs.Size = new SizeF(glyphs.Size.Width, size.Height);
					}
				}
				else
				{
					glyphs.Size = size;
				}
				if (a.IsEmpty || !RectangleF.Intersect(a, new RectangleF(pointF, glyphs.Size)).IsEmpty)
				{
					Class6219 class4 = new Class6219(@class, glyphs.Color, glyphs.OutlineColor, pointF, glyphs.Text, glyphs.Size, glyphs.CharSpace);
					class4.Id = (++int_0).ToString();
					class4.Hyperlink = glyphs.Hyperlink;
					class6216_0.Add(class4);
				}
				return;
			}
			if (glyphs.Indices != null)
			{
				Class6265.Class6267 class5 = new Class6265.Class6267(glyphs.Indices);
				float num7 = 0f;
				for (int j = 0; j < class5.method_0(); j++)
				{
					float num8 = 0f;
					float num9 = class5.method_1(j);
					num8 = ((!(num9 > 0f)) ? glyphs.Font.method_4(glyphs.Text[j].ToString()).Width : num9);
					float num10 = class5.method_2(j);
					if (num10 != 0f)
					{
						if (j == 0)
						{
							pointF = new PointF(pointF.X + Math.Abs(renderTransform.M11 * num10), pointF.Y);
						}
						if (j == class5.method_0() - 1)
						{
							num8 += num10;
						}
					}
					num7 += num8;
				}
				float num11 = 1f - (sizePoints2 - @class.SizePoints) / @class.SizePoints;
				SizeF sizeF2 = @class.method_4(glyphs.Text);
				glyphs.Size = new SizeF(Math.Abs(renderTransform.M11 * num7 * num11), sizeF2.Height);
			}
			else
			{
				SizeF size2 = @class.method_4(glyphs.Text);
				if (glyphs.Size.Width != 0f && glyphs.Size.Height != 0f)
				{
					if (size2.Width / glyphs.Size.Width > 2f)
					{
						glyphs.Size = size2;
					}
					else if (size2.Height / glyphs.Size.Height > 2f)
					{
						glyphs.Size = new SizeF(glyphs.Size.Width, size2.Height);
					}
				}
				else
				{
					glyphs.Size = size2;
				}
			}
			if (a.IsEmpty || !RectangleF.Intersect(a, new RectangleF(pointF, glyphs.Size)).IsEmpty)
			{
				Class6219 class6 = new Class6219(@class, glyphs.Color, glyphs.OutlineColor, pointF, glyphs.Text, glyphs.Size, glyphs.CharSpace);
				class6.Id = (++int_0).ToString();
				class6.Hyperlink = glyphs.Hyperlink;
				class6216_0.Add(class6);
			}
		}

		public override void vmethod_5(Class6217 path)
		{
			Class6217 @class = new Class6217(path.Pen);
			@class.FillMode = path.FillMode;
			@class.Brush = path.Brush;
			@class.Clip = path.Clip;
			@class.RenderTransform = path.RenderTransform;
			if (@class.RenderTransform == null)
			{
				@class.RenderTransform = new Class6002(1f, 0f, 0f, 1f, 0f, 0f);
			}
			@class.RenderTransform.method_9(new Class6002(1f, 0f, 0f, -1f, 0f, float_1), MatrixOrder.Append);
			((Class6212)stack_0.Peek()).Add(@class);
			stack_0.Push(@class);
		}

		public override void vmethod_6(Class6217 path)
		{
			stack_0.Pop();
		}

		public override void vmethod_7(Class6218 pathFigure)
		{
			Class6218 @class = new Class6218();
			@class.IsClosed = pathFigure.IsClosed;
			((Class6212)stack_0.Peek()).Add(@class);
			stack_0.Push(@class);
		}

		public override void vmethod_8(Class6218 pathFigure)
		{
			stack_0.Pop();
		}

		public override void vmethod_9(Class6223 segment)
		{
			((Class6212)stack_0.Peek()).Add(segment);
		}

		public override void vmethod_10(Class6222 segment)
		{
			((Class6212)stack_0.Peek()).Add(segment);
		}

		private Bitmap method_3(int width, int height, PixelFormat format, Class6002 matrix, int attempNumber)
		{
			int width2 = width;
			int height2 = height;
			Bitmap result = method_4(ref width2, ref height2, format, attempNumber);
			if (width2 != width || height2 != height)
			{
				matrix.method_10(new Class6002((float)width2 / (float)width, 0f, 0f, (float)height2 / (float)height, 0f, 0f));
			}
			return result;
		}

		private Bitmap method_4(ref int width, ref int height, PixelFormat format, int attempNumber)
		{
			try
			{
				return new Bitmap(width, height, format);
			}
			catch (Exception ex)
			{
				if (!bool_0 || attempNumber <= 0 || (!(ex is OutOfMemoryException) && !(ex is ArgumentException)))
				{
					throw;
				}
				width = (int)((float)width * (2f / 3f));
				height = (int)((float)height * (2f / 3f));
				return method_4(ref width, ref height, format, --attempNumber);
			}
		}

		public void method_5(Class6220 image)
		{
			try
			{
				Class6002 @class = method_2();
				Class6002 class2 = new Class6002(1f, 0f, 0f, -1f, 0f, float_1);
				Matrix matrix = new Matrix(@class.M11, 0f - @class.M12, 0f - @class.M21, @class.M22, 0f, 0f);
				matrix.Multiply(new Matrix(class2.M11, class2.M12, class2.M21, class2.M22, 0f, 0f));
				matrix.Multiply(new Matrix(1f / image.Size.Width, 0f, 0f, -1f / image.Size.Height, 0f, 0f));
				RectangleF rectangleF = new RectangleF(0f, 0f, image.Size.Width, image.Size.Height);
				PointF[] array = new PointF[4]
				{
					new PointF(rectangleF.Left, rectangleF.Top),
					new PointF(rectangleF.Right, rectangleF.Top),
					new PointF(rectangleF.Left, rectangleF.Bottom),
					new PointF(rectangleF.Right, rectangleF.Bottom)
				};
				matrix.TransformPoints(array);
				float num = 0f;
				float num2 = 0f;
				float num3 = 0f;
				float num4 = 0f;
				PointF[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					PointF pointF = array2[i];
					num = Math.Min(num, pointF.X);
					num2 = Math.Min(num2, pointF.Y);
					num3 = Math.Max(num3, pointF.X);
					num4 = Math.Max(num4, pointF.Y);
				}
				float num5 = Math.Abs(num3 - num);
				float num6 = Math.Abs(num4 - num2);
				float num7 = Math.Max(image.Size.Width, image.Size.Height) / Math.Max(num5, num6);
				float num8 = num5 * num7;
				float num9 = num6 * num7;
				int num10 = (int)Math.Ceiling(num8);
				int num11 = (int)Math.Ceiling(num9);
				float num12 = (float)num10 / num8;
				float num13 = (float)num11 / num9;
				bool flag = matrix.Elements[1] != 0f && matrix.Elements[2] != 0f;
				Image image2 = smethod_0(image.ImageBytes, flag);
				Class6002 class3 = new Class6002(1f, 0f, 0f, 1f, 0f, 0f);
				Bitmap image3 = method_3(num10, num11, (flag || image2.PixelFormat != PixelFormat.Format24bppRgb) ? PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb, class3, 5);
				Graphics graphics = Graphics.FromImage(image3);
				matrix.Multiply(new Matrix(num7 * class3.M11 * num12, 0f, 0f, num7 * class3.M22 * num13, 0f, 0f));
				float[] elements = matrix.Elements;
				graphics.Transform = new Matrix(elements[0], elements[1], elements[2], elements[3], (0f - num) * num7 * class3.M11 * num12, (0f - num2) * num7 * class3.M22 * num13);
				graphics.DrawImage(image2, 0, 0);
				Class6220 node = new Class6220(new PointF(@class.M31 - @class.M12 + num, float_1 - @class.M32 - @class.M22 + num2), new SizeF(num5, num6), method_6(image3));
				class6216_0.Add(node);
			}
			catch (Exception ex)
			{
				if (ex is OutOfMemoryException || ex is ArgumentException)
				{
					image.ImageBytes = null;
				}
				throw;
			}
		}

		private static Image smethod_0(byte[] image, bool rotated)
		{
			Image image2 = Image.FromStream(new MemoryStream(image));
			Image image3 = new Bitmap(image2.Width, image2.Height, (rotated || image2.PixelFormat != PixelFormat.Format24bppRgb) ? PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb);
			Graphics graphics = Graphics.FromImage(image3);
			graphics.DrawImage(image2, 0, 0, image2.Width, image2.Height);
			return image3;
		}

		private byte[] method_6(Bitmap image)
		{
			MemoryStream memoryStream = new MemoryStream();
			if (image.PixelFormat == PixelFormat.Format24bppRgb)
			{
				image.Save(memoryStream, ImageFormat.Jpeg);
			}
			else
			{
				image.Save(memoryStream, ImageFormat.Png);
			}
			return memoryStream.ToArray();
		}

		public override void vmethod_11(Class6220 image)
		{
			image.Id = (++int_0).ToString();
			if (bool_1)
			{
				method_5(image);
				return;
			}
			Class6002 @class = method_2();
			RectangleF rectangleF = @class.method_4(new RectangleF(image.Origin, image.Size));
			Class6213 class2 = new Class6213();
			class2.RenderTransform = new Class6002();
			if (rectangleF.Height < 0f)
			{
				Class6002 class3 = new Class6002(1f, 0f, 0f, -1f, 0f, image.Size.Height);
				@class.method_10(class3);
				rectangleF = @class.method_4(new RectangleF(image.Origin, image.Size));
				class2.RenderTransform = class3;
			}
			if (rectangleF.Width < 0f)
			{
				Class6002 tx = new Class6002(-1f, 0f, 0f, 1f, image.Size.Width, 0f);
				@class.method_10(tx);
				rectangleF = @class.method_4(new RectangleF(image.Origin, image.Size));
				class2.RenderTransform.method_10(tx);
			}
			class2.Add(image);
			((Class6212)stack_0.Peek()).Add(class2);
		}

		public override void vmethod_12(Class6211 bookmark)
		{
			((Class6212)stack_0.Peek()).Add(bookmark);
		}

		public override void vmethod_13(Class6221 outlineItem)
		{
			((Class6212)stack_0.Peek()).Add(outlineItem);
		}

		public override void vmethod_14(Class6210 field)
		{
			((Class6212)stack_0.Peek()).Add(field);
		}

		public override void vmethod_16(Class6209 field)
		{
			((Class6212)stack_0.Peek()).Add(field);
		}

		public override void vmethod_15(Class6207 field)
		{
			((Class6212)stack_0.Peek()).Add(field);
		}
	}

	private Delegate2780 delegate2780_0;

	public event Delegate2780 Progress
	{
		add
		{
			Delegate2780 @delegate = delegate2780_0;
			Delegate2780 delegate2;
			do
			{
				delegate2 = @delegate;
				Delegate2780 value2 = (Delegate2780)Delegate.Combine(delegate2, value);
				@delegate = Interlocked.CompareExchange(ref delegate2780_0, value2, delegate2);
			}
			while ((object)@delegate != delegate2);
		}
		remove
		{
			Delegate2780 @delegate = delegate2780_0;
			Delegate2780 delegate2;
			do
			{
				delegate2 = @delegate;
				Delegate2780 value2 = (Delegate2780)Delegate.Remove(delegate2, value);
				@delegate = Interlocked.CompareExchange(ref delegate2780_0, value2, delegate2);
			}
			while ((object)@delegate != delegate2);
		}
	}

	internal static Class6216 smethod_0(Class6216 page, int pageNumber, Class4859 options, int attempsNumber, bool transformImages)
	{
		try
		{
			Class6177 @class = new Class6177();
			@class.TransformImages = transformImages;
			@class.class4859_0 = options;
			@class.bool_0 = options.MemoryHandler == null;
			return @class.method_0(page);
		}
		catch (Exception ex)
		{
			if (attempsNumber < 0 || options.MemoryHandler == null || (!(ex is OutOfMemoryException) && !(ex is ArgumentException)))
			{
				throw;
			}
			return smethod_0((Class6216)((Interface149)options.MemoryHandler).imethod_0(pageNumber, ex), pageNumber, options, --attempsNumber, transformImages);
		}
	}

	public void method_0(ArrayList apsPages, Interface145 builder, Class4859 options)
	{
		try
		{
			Class4860.Instance.Options = options;
			Class4742 @class = new Class4742(options);
			int num = 0;
			foreach (Class6216 apsPage in apsPages)
			{
				num++;
				Class6216 curFixedPage = apsPage;
				if (options.Normalize)
				{
					curFixedPage = smethod_0(apsPage, num, options, 5, transformImages: false);
				}
				@class.method_2(curFixedPage);
				method_3(num, apsPages.Count);
			}
			if (@class.Document == null)
			{
				throw new InvalidOperationException("Please call the Open method prior to saving the document.");
			}
			if (builder != null)
			{
				@class.Document.vmethod_0(builder);
			}
		}
		finally
		{
			Class4860.Instance.Clear();
		}
	}

	public void method_1(ArrayList apsPages, Interface148 builder)
	{
		try
		{
			Class4860.Instance.Options = new Class4859();
			Class4858 @class = new Class4858(new Class4770(builder));
			@class.method_0(apsPages);
		}
		finally
		{
			Class4860.Instance.Clear();
		}
	}

	public void method_2(string apsFile, Interface145 builder, Class4859 options)
	{
		ArrayList arrayList = new ArrayList();
		Class6629 @class = new Class6629();
		using (FileStream stream = new FileStream(apsFile, FileMode.Open))
		{
			if (!(@class.method_2(stream) is Class6215 class2))
			{
				throw new ArgumentException($"Incorrect format of file: {apsFile}");
			}
			for (int i = 0; i < class2.Count; i++)
			{
				arrayList.Add(class2[i]);
			}
		}
		@class = null;
		GC.Collect();
		method_0(arrayList, builder, options);
	}

	private void method_3(int progress, int total)
	{
		if (delegate2780_0 != null)
		{
			delegate2780_0(this, new EventArgs5(progress, total));
		}
	}
}
