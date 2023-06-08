using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using ns22;

namespace ns18;

internal class Class470 : Class468
{
	private PointF pointF_0;

	private StringBuilder stringBuilder_0;

	private bool bool_1;

	private Matrix matrix_0;

	private bool bool_2;

	[Attribute0(true)]
	internal string method_2(Class458 class458_0, bool bool_3)
	{
		stringBuilder_0 = new StringBuilder();
		bool_2 = bool_3;
		matrix_0 = class458_0.imethod_0();
		class458_0.vmethod_0(this);
		return stringBuilder_0.ToString();
	}

	public override void vmethod_8(Class459 class459_0)
	{
		MoveTo(class459_0.method_2());
		pointF_0 = class459_0.method_2();
		bool_1 = true;
	}

	public override void vmethod_9(Class459 class459_0)
	{
		if (class459_0.method_4())
		{
			stringBuilder_0.Append("Z ");
		}
	}

	public override void vmethod_12(Class462 class462_0)
	{
		Struct89[] array = class462_0.method_3();
		Struct89 @struct = array[0];
		if (array.Length > 0)
		{
			if (bool_1)
			{
				MoveTo(@struct.method_0());
				bool_1 = false;
			}
			else
			{
				method_3(@struct.method_0());
			}
			PointF[] array2 = new PointF[3];
			for (int i = 0; i < array.Length; i++)
			{
				@struct = array[i];
				ref PointF reference = ref array2[0];
				reference = @struct.method_2();
				ref PointF reference2 = ref array2[1];
				reference2 = @struct.method_4();
				ref PointF reference3 = ref array2[2];
				reference3 = @struct.method_6();
				method_4(array2);
				pointF_0 = @struct.method_6();
			}
		}
	}

	public override void vmethod_10(Class467 class467_0)
	{
		if (class467_0.Points.Count <= 0)
		{
			return;
		}
		if (bool_1)
		{
			bool_1 = false;
		}
		for (int i = 0; i < class467_0.Points.Count; i++)
		{
			PointF pointF_ = (PointF)class467_0.Points[i];
			if (pointF_.X != pointF_0.X || pointF_.Y != pointF_0.Y)
			{
				method_3(pointF_);
				pointF_0 = pointF_;
			}
		}
	}

	public override void vmethod_11(Class466 class466_0)
	{
		Struct89 @struct = (Struct89)class466_0.method_2()[0];
		if (bool_1)
		{
			bool_1 = false;
		}
		else
		{
			method_3(@struct.method_0());
		}
		foreach (Struct89 item in class466_0.method_2())
		{
			method_4(new PointF[3]
			{
				item.method_2(),
				item.method_4(),
				item.method_6()
			});
			pointF_0 = item.method_6();
		}
	}

	private void MoveTo(PointF pointF_1)
	{
		if (matrix_0 != null && bool_2)
		{
			PointF[] array = new PointF[1]
			{
				new PointF(pointF_1.X, pointF_1.Y)
			};
			matrix_0.TransformPoints(array);
			stringBuilder_0.AppendFormat("M{0} ", Class1059.smethod_4(array[0]));
		}
		else
		{
			stringBuilder_0.AppendFormat("M{0} ", Class1059.smethod_4(pointF_1));
		}
	}

	private void method_3(PointF pointF_1)
	{
		if (matrix_0 != null && bool_2)
		{
			PointF[] array = new PointF[1]
			{
				new PointF(pointF_1.X, pointF_1.Y)
			};
			matrix_0.TransformPoints(array);
			stringBuilder_0.AppendFormat("L{0} ", Class1059.smethod_4(array[0]));
		}
		else
		{
			stringBuilder_0.AppendFormat("L{0} ", Class1059.smethod_4(pointF_1));
		}
	}

	private void method_4(PointF[] pointF_1)
	{
		stringBuilder_0.Append("C");
		if (matrix_0 != null && bool_2)
		{
			PointF[] array = new PointF[pointF_1.Length];
			for (int i = 0; i < array.Length; i++)
			{
				ref PointF reference = ref array[i];
				reference = new PointF(pointF_1[i].X, pointF_1[i].Y);
			}
			matrix_0.TransformPoints(array);
			for (int j = 0; j < pointF_1.Length; j++)
			{
				stringBuilder_0.Append(Class1059.smethod_4(array[j]));
				stringBuilder_0.Append(" ");
			}
		}
		else
		{
			for (int k = 0; k < pointF_1.Length; k++)
			{
				stringBuilder_0.Append(Class1059.smethod_4(pointF_1[k]));
				stringBuilder_0.Append(" ");
			}
		}
	}
}
