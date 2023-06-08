using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Aspose.Cells;
using ns22;

namespace ns18;

internal class Class472 : Class468
{
	internal bool bool_1;

	private Graphics graphics_0;

	private readonly Stack stack_0 = new Stack();

	private GraphicsPath graphicsPath_0;

	public void method_2(Class452 class452_0, Graphics graphics_1)
	{
		if (class452_0 == null)
		{
			throw new ArgumentNullException("node");
		}
		if (graphics_1 == null)
		{
			throw new ArgumentNullException("graphics");
		}
		if (graphics_1.PageUnit != GraphicsUnit.Point)
		{
			throw new ArgumentException("PageUnit of the Graphics object must be points.", "graphics");
		}
		if (graphics_1.PageScale != 1f)
		{
			throw new ArgumentException("PageScale of the Graphics object must be 1.", "graphics");
		}
		graphics_0 = graphics_1;
		if (class452_0 is Class461)
		{
			Class461 @class = (Class461)class452_0;
			Class461 class2 = class461_0;
			if (class2 == null || @class.rectangleF_0.IntersectsWith(class2.rectangleF_0))
			{
				class452_0.vmethod_0(this);
			}
		}
		else
		{
			class452_0.vmethod_0(this);
		}
	}

	public override void vmethod_5(Class463 class463_0)
	{
		method_3(class463_0);
		PointF origin = new PointF(class463_0.method_4().X + 0.5f, class463_0.method_4().Y - class463_0.method_1().method_1() - (class463_0.method_1().method_0() - class463_0.method_1().Size) / 2f);
		GraphicsState gstate = graphics_0.Save();
		graphics_0.TranslateTransform(origin.X, origin.Y);
		if (class463_0.method_6() != 0f)
		{
			graphics_0.ScaleTransform(class463_0.method_6(), 1f);
		}
		if (class463_0.bool_1)
		{
			origin.Y += class463_0.Size.Height / 1.5f;
		}
		if (class463_0.bool_0)
		{
			origin.Y -= class463_0.Size.Height / 1.5f;
		}
		System.Drawing.Font font = class463_0.method_1().method_4();
		if (class463_0.fontUnderlineType_0 == FontUnderlineType.Single || class463_0.fontUnderlineType_0 == FontUnderlineType.Accounting)
		{
			font = new System.Drawing.Font(font.Name, font.Size, font.Style | FontStyle.Underline);
		}
		if (!Class1178.smethod_0(class463_0.Color))
		{
			Brush brush = new SolidBrush(class463_0.Color);
			graphics_0.DrawString(class463_0.Text, font, brush, default(PointF), StringFormat.GenericTypographic);
		}
		if (!Class1178.smethod_0(class463_0.method_3()))
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			System.Drawing.Font font2 = class463_0.method_1().method_4();
			graphicsPath.AddString(class463_0.Text, font2.FontFamily, (int)font2.Style, class463_0.method_1().Size, origin, Class1396.smethod_3());
			Pen pen = new Pen(class463_0.method_3());
			graphics_0.DrawPath(pen, graphicsPath);
		}
		graphics_0.Restore(gstate);
		method_4(class463_0);
	}

	public override void vmethod_3(Class454 class454_0)
	{
		method_3(class454_0);
	}

	public override void vmethod_4(Class454 class454_0)
	{
		method_4(class454_0);
	}

	public override void vmethod_6(Class458 class458_0)
	{
		method_3(class458_0);
		graphicsPath_0 = new GraphicsPath(class458_0.method_4());
	}

	public override void vmethod_7(Class458 class458_0)
	{
		if (class458_0.method_2() != null)
		{
			Brush brush = class458_0.method_2();
			if (class458_0.method_2() is Class1199)
			{
				Class1199 @class = (Class1199)class458_0.method_2();
				brush = new LinearGradientBrush(@class.method_3(), @class.method_2(), @class.method_1(), @class.method_0());
			}
			graphics_0.FillPath(brush, graphicsPath_0);
		}
		if (class458_0.class770_0 != null)
		{
			using Pen pen = Class770.smethod_0(class458_0.class770_0);
			graphics_0.DrawPath(pen, graphicsPath_0);
		}
		method_4(class458_0);
		graphicsPath_0 = null;
	}

	public override void vmethod_8(Class459 class459_0)
	{
		graphicsPath_0.StartFigure();
		graphicsPath_0.AddLines(new PointF[1] { class459_0.method_2() });
	}

	public override void vmethod_9(Class459 class459_0)
	{
		if (class459_0.method_4())
		{
			graphicsPath_0.CloseFigure();
		}
	}

	public override void vmethod_10(Class467 class467_0)
	{
		graphicsPath_0.AddLines(smethod_0(class467_0.Points));
	}

	public override void vmethod_11(Class466 class466_0)
	{
		foreach (Struct89 item in class466_0.method_2())
		{
			graphicsPath_0.AddBezier(item.method_0(), item.method_2(), item.method_4(), item.method_6());
		}
	}

	public override void vmethod_12(Class462 class462_0)
	{
		graphicsPath_0.AddArc(class462_0.method_7().X, class462_0.method_7().Y, class462_0.Size.Width, class462_0.Size.Height, class462_0.method_9(), class462_0.method_11());
	}

	public override void vmethod_13(Class465 class465_0)
	{
		MemoryStream stream = new MemoryStream(class465_0.method_3());
		Image image = Image.FromStream(stream);
		graphics_0.DrawImage(image, class465_0.method_2().X, class465_0.method_2().Y, class465_0.Size.Width, class465_0.Size.Height);
	}

	public override void vmethod_15(Class460 class460_0)
	{
		if (class460_0 != null && class460_0.class770_0 != null)
		{
			using (Pen pen = Class770.smethod_0(class460_0.class770_0))
			{
				graphics_0.DrawLine(pen, class460_0.pointF_0, class460_0.pointF_1);
			}
		}
	}

	private void method_3(Interface5 interface5_0)
	{
		if (Class1405.smethod_0(interface5_0))
		{
			stack_0.Push(graphics_0.Save());
			if (Class1405.smethod_2(interface5_0))
			{
				graphics_0.MultiplyTransform(interface5_0.imethod_0());
			}
			if (Class1405.smethod_3(interface5_0))
			{
				method_5(interface5_0.imethod_1());
			}
		}
	}

	private void method_4(Interface5 interface5_0)
	{
		if (Class1405.smethod_0(interface5_0))
		{
			graphics_0.Restore((GraphicsState)stack_0.Pop());
		}
	}

	private void method_5(Class458 class458_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		foreach (Class459 item in class458_0.method_1())
		{
			foreach (Class452 item2 in item.method_1())
			{
				if (item2 is Class467)
				{
					Class467 class3 = (Class467)item2;
					ArrayList points = class3.Points;
					PointF[] array = new PointF[points.Count + 1];
					ref PointF reference = ref array[0];
					reference = item.method_2();
					for (int i = 0; i < points.Count; i++)
					{
						ref PointF reference2 = ref array[i + 1];
						reference2 = (PointF)points[i];
					}
					graphicsPath.AddLines(array);
				}
				else if (item2 is Class462)
				{
					Class462 class4 = (Class462)item2;
					Struct89[] array2 = class4.method_3();
					PointF[] array3 = new PointF[array2.Length * 3 + 1];
					ref PointF reference3 = ref array3[0];
					reference3 = item.method_2();
					for (int j = 0; j < array2.Length; j++)
					{
						Struct89 @struct = array2[j];
						ref PointF reference4 = ref array3[j * 3 + 1];
						reference4 = @struct.method_2();
						ref PointF reference5 = ref array3[j * 3 + 2];
						reference5 = @struct.method_4();
						ref PointF reference6 = ref array3[j * 3 + 3];
						reference6 = @struct.method_6();
					}
					graphicsPath.AddBeziers(array3);
				}
				else
				{
					if (!(item2 is Class466))
					{
						continue;
					}
					Class466 class5 = (Class466)item2;
					PointF[] array4 = new PointF[3];
					foreach (Struct89 item3 in class5.method_2())
					{
						ref PointF reference7 = ref array4[0];
						reference7 = item3.method_2();
						ref PointF reference8 = ref array4[1];
						reference8 = item3.method_4();
						ref PointF reference9 = ref array4[2];
						reference9 = item3.method_6();
					}
					PointF[] array5 = new PointF[class5.method_2().Count * 3 + 1];
					ref PointF reference10 = ref array5[0];
					reference10 = item.method_2();
					for (int k = 0; k < class5.method_2().Count; k++)
					{
						Struct89 struct3 = (Struct89)class5.method_2()[k];
						ref PointF reference11 = ref array5[k * 3 + 1];
						reference11 = struct3.method_2();
						ref PointF reference12 = ref array5[k * 3 + 2];
						reference12 = struct3.method_4();
						ref PointF reference13 = ref array5[k * 3 + 3];
						reference13 = struct3.method_6();
					}
					graphicsPath.AddBeziers(array5);
				}
			}
			if (item.method_4())
			{
				graphicsPath.CloseFigure();
			}
		}
		graphics_0.SetClip(graphicsPath, CombineMode.Intersect);
	}

	private static PointF[] smethod_0(ArrayList arrayList_3)
	{
		return arrayList_3.ToArray(typeof(PointF)) as PointF[];
	}
}
