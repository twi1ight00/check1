using System;
using System.Collections;
using System.Drawing;
using ns161;
using ns224;
using ns235;

namespace ns167;

internal class Class4791 : Class4779
{
	private bool bool_0;

	private Class4786.Class4849 class4849_0;

	private RectangleF rectangleF_0;

	private Class6219 class6219_0;

	private Enum672 enum672_0;

	internal static readonly float float_0 = 0.3f;

	private static readonly int int_0 = 1;

	public bool IsInvisible
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	internal int Id => int.Parse(class6219_0.Id);

	internal Class4786.Class4849 LineRef
	{
		get
		{
			return class4849_0;
		}
		set
		{
			class4849_0 = value;
		}
	}

	internal override PointF Origin
	{
		get
		{
			return class6219_0.Origin;
		}
		set
		{
			class6219_0.Origin = value;
		}
	}

	internal override string Text => class6219_0.Text;

	internal override float FontSize => class6219_0.Font.SizePoints;

	internal Class5999 Font => class6219_0.Font;

	internal Class5999 ApsGlyphFont => class6219_0.Font;

	internal override Enum672 Style => enum672_0;

	internal Class5998 Color => class6219_0.Color;

	internal override RectangleF BoundingBox => rectangleF_0;

	internal override PointF MassCenter => new PointF(BoundingBox.Width / 2f + BoundingBox.X, BoundingBox.Height / 2f + BoundingBox.Y);

	internal override float Compactness => int_0;

	internal override float InsideTextDistance => float_0;

	internal override bool CanHaveChildren => false;

	public override object Current
	{
		get
		{
			throw new InvalidOperationException("Please report exception. Can not enumerate" + ToString());
		}
	}

	internal override float GetRealWidth => BoundingBox.Width;

	internal override string FontFace => class6219_0.Font.FamilyName;

	internal override bool CanBeOptimized => true;

	internal Class4791(Class6219 text)
	{
		class6219_0 = text;
		method_1();
		method_4();
	}

	private void method_1()
	{
		if ((Class4860.Instance.Options.UserAgent == Enum678.const_1 || Class4860.Instance.Options.UseNewTextBoxRecognitionAlgorithm) && Class4860.Instance.Options.Mode == Enum676.const_0)
		{
			rectangleF_0 = new RectangleF(class6219_0.Origin.X, class6219_0.Origin.Y, class6219_0.Size.Width, class6219_0.Size.Height);
		}
		else
		{
			rectangleF_0 = class6219_0.Bounds;
		}
	}

	internal Class6219 method_2()
	{
		return class6219_0;
	}

	internal void method_3(Class6219 text)
	{
		class6219_0 = text;
		method_1();
		method_4();
	}

	internal override void vmethod_1(Class6216 targetPage)
	{
	}

	private void method_4()
	{
		if (class6219_0.Font.Style == FontStyle.Regular)
		{
			enum672_0 = Enum672.flag_1;
		}
		if ((class6219_0.Font.Style & FontStyle.Bold) == FontStyle.Bold)
		{
			enum672_0 |= Enum672.flag_2;
		}
		if ((class6219_0.Font.Style & FontStyle.Italic) == FontStyle.Italic)
		{
			enum672_0 |= Enum672.flag_3;
		}
	}

	internal void AddText(Class4791 text)
	{
		class6219_0.AddText(text.Text, text.BoundingBox.Width);
		rectangleF_0 = RectangleF.Union(BoundingBox, text.BoundingBox);
	}

	internal void method_5()
	{
		class6219_0.method_2();
		rectangleF_0 = default(RectangleF);
	}

	public override IEnumerator GetEnumerator()
	{
		throw new InvalidOperationException("Please report exception. Can not enumerate" + ToString());
	}

	public override bool MoveNext()
	{
		throw new InvalidOperationException("Please report exception. Can not enumerate" + ToString());
	}

	public override void Reset()
	{
		throw new InvalidOperationException("Please report exception. Can not enumerate" + ToString());
	}
}
