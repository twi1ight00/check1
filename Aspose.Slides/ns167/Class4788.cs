using System;
using System.Collections;
using System.Drawing;
using System.Text;
using ns235;

namespace ns167;

internal class Class4788 : Class4779, IEnumerable, IEnumerator, Interface147
{
	private bool bool_0;

	private bool bool_1;

	private Class4846 class4846_0;

	private RectangleF rectangleF_0;

	private PointF pointF_0;

	private float float_0;

	private Enum672 enum672_0;

	private PointF pointF_1;

	private float float_1;

	private IEnumerator ienumerator_0;

	private Interface147 interface147_0;

	internal override PointF Origin
	{
		get
		{
			if (bool_1)
			{
				method_1();
			}
			return pointF_0;
		}
		set
		{
			throw new InvalidOperationException("Please report exception. Can not set origin point for BasicTextGrouping.");
		}
	}

	internal override RectangleF BoundingBox
	{
		get
		{
			if (bool_1)
			{
				method_1();
			}
			return rectangleF_0;
		}
	}

	internal override string Text => method_3();

	internal override PointF MassCenter
	{
		get
		{
			if (bool_1)
			{
				method_1();
			}
			return pointF_1;
		}
	}

	internal override float FontSize
	{
		get
		{
			if (bool_1)
			{
				method_1();
			}
			return float_0;
		}
	}

	internal override Enum672 Style
	{
		get
		{
			if (bool_1)
			{
				method_1();
			}
			return enum672_0;
		}
	}

	internal override float Compactness
	{
		get
		{
			if (bool_1)
			{
				method_1();
			}
			return float_1;
		}
	}

	internal override float GetRealWidth
	{
		get
		{
			float num = 0f;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Class4845 @class = (Class4845)enumerator.Current;
					num += @class.Value.GetRealWidth;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			if (Count != 0)
			{
				return num / (float)Count;
			}
			return 0f;
		}
	}

	public override object Current => ienumerator_0.Current;

	Class4845 Interface147.Current => interface147_0.Current;

	internal int Count => class4846_0.Count;

	internal override bool CanHaveChildren => true;

	internal override string FontFace
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	internal override float InsideTextDistance
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	internal override bool CanBeOptimized
	{
		get
		{
			throw new InvalidOperationException("Please report exception.");
		}
	}

	internal Class4788()
	{
		class4846_0 = new Class4846();
	}

	internal Class4788(Class4845 element)
		: this()
	{
		Add(element);
	}

	internal virtual void Add(Class4788 elements)
	{
		foreach (Class4845 element in elements)
		{
			Add(element);
		}
	}

	internal void Add(Class4845 el)
	{
		if (!class4846_0.Contains(el))
		{
			class4846_0.Add(el);
			vmethod_0();
		}
	}

	internal override void vmethod_1(Class6216 targetPage)
	{
	}

	internal override void vmethod_0()
	{
		bool_1 = true;
		base.vmethod_0();
	}

	public override void Reset()
	{
		ienumerator_0 = class4846_0.GetEnumerator();
	}

	public override bool MoveNext()
	{
		return ienumerator_0.MoveNext();
	}

	public override IEnumerator GetEnumerator()
	{
		((IEnumerator)this).Reset();
		return this;
	}

	void Interface147.Reset()
	{
		interface147_0 = class4846_0.method_2();
		interface147_0.Reset();
	}

	bool Interface147.imethod_0()
	{
		return interface147_0.imethod_0();
	}

	bool Interface147.imethod_1()
	{
		return interface147_0.imethod_1();
	}

	private void method_1()
	{
		bool_1 = false;
		class4846_0.method_11(Enum673.const_0, isReverse: false);
		rectangleF_0 = method_2();
		float_1 = Class4780.smethod_5(this, BoundingBox.Width, BoundingBox.Height);
		float_0 = Class4780.smethod_4(this);
		pointF_1 = Class4780.smethod_3(this);
		enum672_0 = Class4780.smethod_2(this);
		pointF_0 = default(PointF);
		IEnumerator enumerator = GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				Class4845 @class = (Class4845)enumerator.Current;
				pointF_0 = @class.Value.Origin;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	private RectangleF method_2()
	{
		RectangleF rectangleF = default(RectangleF);
		foreach (Class4845 item in class4846_0)
		{
			rectangleF = ((!rectangleF.IsEmpty) ? RectangleF.Union(rectangleF, item.Value.BoundingBox) : item.Value.BoundingBox);
		}
		return rectangleF;
	}

	private string method_3()
	{
		StringBuilder stringBuilder = new StringBuilder();
		class4846_0.method_11(Enum673.const_0, isReverse: false);
		foreach (Class4845 item in class4846_0)
		{
			stringBuilder.Append(item.Value.Text);
		}
		return stringBuilder.ToString();
	}
}
