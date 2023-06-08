using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class459 : Class453
{
	private PointF pointF_0;

	private bool bool_0;

	public Class459()
	{
	}

	public Class459(PointF pointF_1)
	{
		pointF_0 = pointF_1;
	}

	[SpecialName]
	public PointF method_2()
	{
		return pointF_0;
	}

	[SpecialName]
	public void method_3(PointF pointF_1)
	{
		pointF_0 = pointF_1;
	}

	[SpecialName]
	public bool method_4()
	{
		return bool_0;
	}

	[SpecialName]
	public void method_5(bool bool_1)
	{
		bool_0 = bool_1;
	}

	public override void vmethod_0(Class468 class468_0)
	{
		class468_0.vmethod_8(this);
		base.vmethod_0(class468_0);
		class468_0.vmethod_9(this);
	}

	public static Class459 smethod_0(PointF[] pointF_1, bool bool_1)
	{
		Class459 class459_ = new Class459();
		class459_.method_5(bool_1);
		if (pointF_1.Length < 2)
		{
			return class459_;
		}
		class459_.method_3(pointF_1[0]);
		AddLine(ref class459_, pointF_1);
		return class459_;
	}

	public static Class459 smethod_1(PointF[] pointF_1)
	{
		Class459 @class = new Class459();
		@class.method_5(bool_1: false);
		if (pointF_1.Length < 4)
		{
			return @class;
		}
		@class.method_3(pointF_1[0]);
		int num = pointF_1.Length;
		for (int i = 0; i < num - 3; i += 3)
		{
			Struct89 struct89_ = default(Struct89);
			struct89_.method_1(pointF_1[i]);
			struct89_.method_3(pointF_1[i + 1]);
			struct89_.method_5(pointF_1[i + 2]);
			struct89_.method_7(pointF_1[i + 3]);
			Class466 class2 = new Class466();
			class2.method_1(struct89_);
			@class.Add(class2);
		}
		return @class;
	}

	public static void smethod_2(ref Class459 class459_0, PointF[] pointF_1)
	{
		if (pointF_1.Length >= 4)
		{
			int num = pointF_1.Length;
			for (int i = 0; i < num - 3; i += 3)
			{
				Struct89 struct89_ = default(Struct89);
				struct89_.method_1(pointF_1[i]);
				struct89_.method_3(pointF_1[i + 1]);
				struct89_.method_5(pointF_1[i + 2]);
				struct89_.method_7(pointF_1[i + 3]);
				Class466 @class = new Class466();
				@class.method_1(struct89_);
				class459_0.Add(@class);
			}
		}
	}

	public static void AddLine(ref Class459 class459_0, PointF[] pointF_1)
	{
		if (pointF_1.Length >= 2)
		{
			float[] array = new float[(pointF_1.Length - 1) * 2];
			for (int i = 0; i < pointF_1.Length - 1; i++)
			{
				array[i * 2] = pointF_1[i + 1].X;
				array[i * 2 + 1] = pointF_1[i + 1].Y;
			}
			Class467 class452_ = new Class467(array);
			class459_0.Add(class452_);
		}
	}
}
