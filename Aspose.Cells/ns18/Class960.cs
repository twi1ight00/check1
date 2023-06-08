using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ns18;

internal class Class960 : Class938
{
	private float float_0;

	private float float_1;

	private Class939 class939_0;

	private Class458 class458_0;

	private Class459 class459_0;

	private Class1452 class1452_0;

	private Class1445 class1445_0;

	private Class1450 class1450_0;

	public Class960(Class1440 class1440_1, float float_2, float float_3)
		: base(class1440_1)
	{
		float_0 = float_2;
		float_1 = float_3;
		class939_0 = new Class939(class1440_0, bool_1: false);
		class1452_0 = new Class1452(class1440_0, class939_0);
		class1445_0 = new Class1445(class1440_0, class1440_0.method_2(), class939_0);
		class1440_0.method_6().ResetGraphicState();
		class1440_0.method_6().method_2(new Matrix(1f, 0f, 0f, -1f, 0f, float_1), class939_0);
	}

	public void method_4()
	{
	}

	public void method_5(Class454 class454_0)
	{
		method_17(class454_0);
	}

	public void method_6(Class454 class454_0)
	{
		method_18(class454_0);
		if (class454_0.Hyperlink != null)
		{
			AddHyperlink(class454_0.Hyperlink);
		}
	}

	public void method_7(Class463 class463_0)
	{
		method_17(class463_0);
		class1452_0.method_0(class463_0);
		if (class463_0.Hyperlink != null)
		{
			AddHyperlink(class463_0.Hyperlink);
		}
		method_18(class463_0);
	}

	public void method_8(Class458 class458_1)
	{
		method_17(class458_1);
		if (class458_1.method_2() != null)
		{
			class1445_0.method_1(class458_1.method_2(), bool_0: false);
		}
		if (class458_1.class770_0 != null)
		{
			class1445_0.method_0(class458_1.class770_0);
		}
		class458_0 = class458_1;
	}

	public void method_9(Class458 class458_1)
	{
		class939_0.method_8(method_19());
		class459_0 = null;
		method_18(class458_1);
	}

	public void method_10(Class459 class459_1)
	{
		if (method_20())
		{
			class939_0.method_8("h");
		}
		class939_0.method_9("{0} m", Class1446.smethod_2(class459_1.method_2()));
		class459_0 = class459_1;
	}

	public void method_11(Class459 class459_1)
	{
	}

	public void method_12(Class467 class467_0)
	{
		for (int i = 0; i < class467_0.Points.Count; i++)
		{
			PointF pointF_ = (PointF)class467_0.Points[i];
			class939_0.method_9("{0} l", Class1446.smethod_2(pointF_));
		}
	}

	public void method_13(Class466 class466_0)
	{
		PointF[] array = new PointF[3];
		if (class466_0.method_2().Count <= 0)
		{
			return;
		}
		foreach (Struct89 item in class466_0.method_2())
		{
			ref PointF reference = ref array[0];
			reference = item.method_2();
			ref PointF reference2 = ref array[1];
			reference2 = item.method_4();
			ref PointF reference3 = ref array[2];
			reference3 = item.method_6();
			class939_0.method_9("{0} c", Class1446.smethod_3(array));
		}
	}

	public void method_14(Class462 class462_0)
	{
		Struct89[] array = class462_0.method_3();
		for (int i = 0; i < array.Length; i++)
		{
			PointF[] pointF_ = new PointF[3]
			{
				array[i].method_2(),
				array[i].method_4(),
				array[i].method_6()
			};
			class939_0.method_9("{0} c", Class1446.smethod_3(pointF_));
		}
	}

	public void method_15(Class465 class465_0)
	{
		if (class465_0.ImageType == Enum200.const_4)
		{
			class1445_0.method_2(class465_0.method_3(), class465_0.method_2(), class465_0.Size, class465_0.method_1());
		}
		else if (class465_0.ImageType != 0)
		{
			MemoryStream memoryStream = new MemoryStream(class465_0.method_3());
			Bitmap bitmap = (Bitmap)Image.FromStream(memoryStream);
			if (bitmap.PixelFormat != PixelFormat.Format32bppArgb && bitmap.PixelFormat != PixelFormat.Format32bppRgb)
			{
				bitmap = Class1404.smethod_36(bitmap);
				memoryStream.Position = 0L;
				class1445_0.method_3(bitmap, class465_0.method_2(), class465_0.Size, class465_0.method_1());
			}
			else
			{
				class1445_0.method_3(bitmap, class465_0.method_2(), class465_0.Size, class465_0.method_1());
			}
			if (class465_0.Hyperlink != null)
			{
				AddHyperlink(class465_0.Hyperlink);
			}
		}
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		method_16(class1447_0);
		class939_0.vmethod_1(class1447_0);
	}

	private void method_16(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		class1447_0.method_11("/Type", "/Page");
		class1447_0.method_11("/Parent", class1440_0.Pages.method_1());
		class1447_0.method_11("/Contents", class939_0.method_1());
		class1447_0.method_14("/MediaBox", new RectangleF(0f, 0f, float_0, float_1));
		if (class1450_0 != null)
		{
			class1447_0.Write("/Annots");
			class1450_0.method_0(class1447_0);
		}
		class1447_0.method_10();
		class1447_0.method_25();
	}

	private void method_17(Interface5 interface5_0)
	{
		if (!Class1405.smethod_0(interface5_0))
		{
			return;
		}
		class1440_0.method_6().method_0(class939_0);
		if (Class1405.smethod_2(interface5_0))
		{
			class1440_0.method_6().method_2(interface5_0.imethod_0(), class939_0);
		}
		if (Class1405.smethod_3(interface5_0))
		{
			if (Class1405.smethod_2(interface5_0.imethod_1()))
			{
				class1440_0.method_6().method_2(interface5_0.imethod_1().imethod_0(), class939_0);
			}
			class1440_0.method_6().method_3(interface5_0.imethod_1(), class939_0);
			if (Class1405.smethod_2(interface5_0.imethod_1()))
			{
				Matrix matrix = interface5_0.imethod_1().imethod_0().Clone();
				matrix.Invert();
				class1440_0.method_6().method_2(matrix, class939_0);
				matrix = null;
			}
		}
	}

	private void method_18(Interface5 interface5_0)
	{
		if (Class1405.smethod_0(interface5_0))
		{
			class1440_0.method_6().method_1(class939_0);
		}
	}

	private string method_19()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (class458_0.method_2() != null && class458_0.class770_0 != null)
		{
			stringBuilder.Append(method_20() ? "b" : "B");
			if (class458_0.method_4() == FillMode.Alternate)
			{
				stringBuilder.Append("*");
			}
		}
		else if (class458_0.method_2() != null)
		{
			if (class458_0.method_2() is Class1199)
			{
				stringBuilder.Append(" W  n ");
				Class948 @class = class1440_0.method_2().method_2(class458_0.method_2());
				stringBuilder.Append("/" + @class.method_3() + " sh ");
			}
			else
			{
				stringBuilder.Append("f");
				if (class458_0.method_4() == FillMode.Alternate)
				{
					stringBuilder.Append("*");
				}
			}
		}
		else if (class458_0.class770_0 != null)
		{
			stringBuilder.Append(method_20() ? "s" : "S");
		}
		return stringBuilder.ToString();
	}

	public void AddHyperlink(Class464 class464_0)
	{
		if (class1450_0 == null)
		{
			class1450_0 = new Class1450();
		}
		Class950 @class = new Class950(class1440_0, class1440_0.method_6().method_16(class464_0.method_1()), class464_0.method_3(), class464_0.method_2());
		class1450_0.Add(@class.method_1());
		class1440_0.method_3().method_0(@class);
		class1440_0.method_3().method_1(class464_0.method_3(), @class.Destination);
	}

	[SpecialName]
	private bool method_20()
	{
		if (class459_0 != null)
		{
			return class459_0.method_4();
		}
		return false;
	}

	internal void AddLine(Class460 class460_0)
	{
		class1440_0.method_6().method_0(class939_0);
		class1445_0.method_0(class460_0.class770_0);
		class939_0.method_9("{0} m", Class1446.smethod_2(class460_0.pointF_0));
		class939_0.method_9("{0} l", Class1446.smethod_2(class460_0.pointF_1));
		class939_0.method_8("S");
		class1440_0.method_6().method_1(class939_0);
	}
}
