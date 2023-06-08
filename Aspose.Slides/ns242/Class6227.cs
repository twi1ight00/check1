using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ns235;
using ns243;
using ns246;

namespace ns242;

internal abstract class Class6227 : Class6226
{
	protected Class6239 class6239_0;

	protected Enum797 enum797_0;

	protected float float_0;

	protected Class6249 class6249_0;

	public override SizeF Size => new SizeF(float_0, vmethod_8());

	public override PointF Location
	{
		get
		{
			return base.Location;
		}
		set
		{
			vmethod_1(value);
		}
	}

	public Class6249 Style => class6249_0;

	protected Class6227(float width, Struct220 margin, Class6239 documentCreator)
	{
		float_0 = width;
		Margin = margin;
		class6239_0 = documentCreator;
		enum797_0 = Enum797.const_0;
	}

	public virtual float vmethod_8()
	{
		return vmethod_9() + Margin.float_0 + Margin.float_3;
	}

	public virtual float vmethod_9()
	{
		float num = 0f;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class6225 @class = (Class6225)enumerator.Current;
				num += @class.Size.Height;
			}
			return num;
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

	public virtual float vmethod_10()
	{
		float num = 0f;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class6225 @class = (Class6225)enumerator.Current;
				num += @class.Size.Width;
			}
			return num;
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

	public virtual void vmethod_11(Enum797 alignment)
	{
		enum797_0 = alignment;
		for (int i = 0; i < Count; i++)
		{
			vmethod_12(i, enum797_0);
		}
	}

	public virtual void vmethod_12(int indexRow, Enum797 alignment)
	{
		Class6225 child = vmethod_4(indexRow);
		vmethod_13(child, alignment);
	}

	public virtual void vmethod_13(Class6225 child, Enum797 alignment)
	{
		RectangleF rectangleF = vmethod_0();
		switch (alignment)
		{
		case Enum797.const_0:
			child.Location = new PointF(rectangleF.X, child.Location.Y);
			break;
		case Enum797.const_1:
			child.Location = new PointF(rectangleF.X + (rectangleF.Width - child.Size.Width) / 2f, child.Location.Y);
			break;
		case Enum797.const_2:
			child.Location = new PointF(rectangleF.X + (rectangleF.Width - child.Size.Width), child.Location.Y);
			break;
		case Enum797.const_3:
			child.Location = new PointF(rectangleF.X, child.Location.Y);
			if (child is Class6235 @class)
			{
				@class.method_4(rectangleF.Width);
			}
			break;
		}
	}

	public override Class6225 vmethod_5(Class6225 node)
	{
		RectangleF rectangleF = vmethod_0();
		PointF location = new PointF(rectangleF.X, rectangleF.Y + vmethod_9());
		Class6225 @class = base.vmethod_5(node);
		@class.Location = location;
		vmethod_13(@class, enum797_0);
		return @class;
	}

	public override void vmethod_1(PointF toPoint)
	{
		float num = toPoint.X - Location.X;
		float num2 = toPoint.Y - Location.Y;
		base.vmethod_1(toPoint);
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class6225 @class = (Class6225)enumerator.Current;
				PointF location = @class.Location;
				@class.vmethod_1(new PointF(location.X + num, location.Y + num2));
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

	public virtual Class6227 vmethod_14()
	{
		throw new NotImplementedException();
	}

	public override void RemoveAt(int pos)
	{
		Class6225 node = vmethod_4(pos);
		if (pos < Count - 1)
		{
			float dy = 0f - vmethod_15(node);
			for (int i = pos + 1; i < Count; i++)
			{
				Class6225 @class = vmethod_4(i);
				@class.method_1(dy);
			}
		}
		base.RemoveAt(pos);
	}

	protected virtual float vmethod_15(Class6225 node)
	{
		return node.Size.Height;
	}

	public override Class6225 vmethod_7(int pos, Class6225 node)
	{
		List<Class6225> list = new List<Class6225>();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class6225 item = (Class6225)enumerator.Current;
				list.Add(item);
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
		Clear();
		vmethod_5(node);
		foreach (Class6225 item2 in list)
		{
			vmethod_5(item2);
		}
		return node;
	}

	public override Class6204[] vmethod_2()
	{
		List<Class6204> list = new List<Class6204>();
		list.AddRange(class6239_0.StyleProcessor.vmethod_1(this));
		list.AddRange(class6239_0.StyleProcessor.vmethod_0(this));
		list.AddRange(base.vmethod_2());
		return list.ToArray();
	}

	public virtual void vmethod_16(Class6249 style, bool applyToChildren)
	{
		class6249_0 = style;
		if (!applyToChildren)
		{
			return;
		}
		for (int i = 0; i < Count; i++)
		{
			if (vmethod_4(i) is Class6227 @class && @class.Style == null)
			{
				@class.vmethod_16(style, applyToChildren);
			}
		}
	}

	public void method_4(Class6249 style)
	{
		vmethod_16(style, applyToChildren: false);
	}
}
