using System;
using System.Drawing;
using Aspose.Cells.Rendering;

namespace ns18;

internal class Class1452
{
	private static string[] string_0 = new string[0];

	private Class1440 class1440_0;

	private Class939 class939_0;

	private bool bool_0;

	private bool bool_1;

	private PointF pointF_0;

	private PointF pointF_1;

	private string string_1;

	private float float_0;

	private Class1452()
	{
	}

	internal Class1452(Class1440 class1440_1, Class939 class939_1)
	{
		class1440_0 = class1440_1;
		class939_0 = class939_1;
	}

	internal void method_0(Class463 class463_0)
	{
		if (class463_0.method_1().IsStrikeout)
		{
			class1440_0.method_6().method_0(class939_0);
			class1440_0.method_6().method_10(class463_0.method_1().method_4().Size / 25.4f, class939_0);
			class939_0.method_10("{0} {1}", Class1446.smethod_9(class463_0.Color), "RG");
			class939_0.method_10("{0} {1} m", Class1446.smethod_5(class463_0.Left), Class1446.smethod_5(class463_0.Bottom - class463_0.Size.Height / 3f));
			class939_0.method_10("{0} {1} l", Class1446.smethod_5(class463_0.Left + class463_0.Size.Width), Class1446.smethod_5(class463_0.Bottom - class463_0.Size.Height / 3f));
			class939_0.method_8("S");
			class1440_0.method_6().method_1(class939_0);
		}
		method_1();
		bool bool_ = true;
		if (class1440_0.method_1().Compliance == PdfCompliance.PdfA1b)
		{
			bool_ = true;
		}
		Class1396 @class = class463_0.method_1();
		Class954 class2 = class1440_0.method_2().method_1(@class.Name, @class.Style, bool_);
		float_0 = class463_0.method_6();
		if (!class463_0.bool_1 && !class463_0.bool_0)
		{
			class939_0.method_10(" {0} {1}", 0, "Ts");
		}
		method_5(class2, @class.Size);
		method_3(class2, class463_0);
		if (class463_0.method_3().IsEmpty && !class2.method_6())
		{
			if (bool_0 || class1440_0.method_6().method_17().method_7() != class463_0.Color || class1440_0.method_6().method_17().method_14() != 0)
			{
				method_9();
			}
			method_4(0);
			class1440_0.method_6().method_5(class463_0.Color, bool_0: false, class939_0);
		}
		else
		{
			method_9();
			if (!class463_0.Color.IsEmpty)
			{
				method_4(2);
				class1440_0.method_6().method_5(class463_0.Color, bool_0: false, class939_0);
			}
			else
			{
				method_4(1);
			}
			if (class2.method_6())
			{
				float num = class463_0.method_1().Size / 30f;
				class939_0.method_9("{0} w", Class1446.smethod_5(num));
				Color color_ = ((!class463_0.Color.IsEmpty) ? class463_0.Color : class463_0.method_3());
				class1440_0.method_6().method_5(color_, bool_0: true, class939_0);
			}
			else
			{
				class939_0.method_9("{0} w", Class1446.smethod_5(0.5f));
				class1440_0.method_6().method_5(class463_0.method_3(), bool_0: true, class939_0);
			}
		}
		if (class463_0.bool_1)
		{
			float num2 = class463_0.method_1().method_4().Size * 0.1f;
			class939_0.method_10("-{0} {1}", Class1446.smethod_5(num2), "Ts");
		}
		if (class463_0.bool_0)
		{
			float num3 = class463_0.method_1().method_4().Size * 0.6f;
			class939_0.method_10("{0} {1}", Class1446.smethod_5(num3), "Ts");
		}
		method_7(class463_0, class2, bool_);
		pointF_1.X += class463_0.Size.Width;
		bool_0 = false;
		method_2();
	}

	internal void method_1()
	{
		class939_0.method_8("BT");
		bool_0 = true;
		string_1 = "Tj";
	}

	internal void method_2()
	{
		method_9();
		class939_0.method_8("ET");
	}

	private void method_3(Class954 class954_0, Class463 class463_0)
	{
		if (!bool_0 && !class954_0.method_5() && !class1440_0.method_6().method_17().TextFont.method_5())
		{
			if (class463_0.method_4() == pointF_1)
			{
				return;
			}
			method_9();
			float num = class463_0.method_4().X - pointF_0.X;
			float num2 = class463_0.method_4().Y - pointF_0.Y;
			if (num2 == class1440_0.method_6().method_17().method_9())
			{
				if (class463_0.method_4().X == pointF_0.X)
				{
					string_1 = "'";
				}
				else
				{
					class939_0.method_10("{0} {1} Td", Class1446.smethod_5(num), Class1446.smethod_5(0f - num2));
				}
			}
			else if (class463_0.method_4().X == pointF_0.X)
			{
				class1440_0.method_6().method_6(num2, class939_0);
				string_1 = "'";
			}
			else
			{
				class939_0.method_10("{0} {1} TD", Class1446.smethod_5(num), Class1446.smethod_5(0f - num2));
				class1440_0.method_6().method_17().method_10(num2);
			}
			pointF_0 = class463_0.method_4();
			pointF_1 = class463_0.method_4();
		}
		else
		{
			method_9();
			method_6(class954_0, class463_0);
		}
	}

	private void method_4(int int_0)
	{
		method_9();
		class1440_0.method_6().method_8(int_0, class939_0);
		class1440_0.method_6().method_9(float_0, class939_0);
	}

	private void method_5(Class954 class954_0, float float_1)
	{
		method_9();
		class1440_0.method_6().method_7(class954_0, float_1, class939_0);
	}

	private void method_6(Class954 class954_0, Class463 class463_0)
	{
		float num = 1f;
		float float_ = 0f;
		float float_2 = (class954_0.method_5() ? ((float)Math.PI / 9f) : 0f);
		float float_3 = -1f;
		float x = class463_0.method_4().X;
		float y = class463_0.method_4().Y;
		class939_0.method_11(num, float_, float_2, float_3, x, y, "Tm");
		pointF_0 = class463_0.method_4();
		pointF_1 = class463_0.method_4();
	}

	private void method_7(Class463 class463_0, Class954 class954_0, bool bool_2)
	{
		method_8();
		if (bool_2)
		{
			method_11(class463_0, (Class956)class954_0);
		}
		else
		{
			method_10(class463_0, (Class955)class954_0);
		}
	}

	private void method_8()
	{
		if (!bool_1)
		{
			class939_0.Write("(");
			bool_1 = true;
		}
	}

	private void method_9()
	{
		if (bool_1)
		{
			class939_0.method_9(") {0}", string_1);
			string_1 = "Tj";
			bool_1 = false;
		}
	}

	private void method_10(Class463 class463_0, Class955 class955_0)
	{
		class955_0.method_14(class463_0.Text);
		class939_0.method_14(class463_0.Text);
	}

	private void method_11(Class463 class463_0, Class956 class956_0)
	{
		byte[] byte_ = class956_0.method_14(class463_0.Text);
		class939_0.method_15(byte_);
	}
}
