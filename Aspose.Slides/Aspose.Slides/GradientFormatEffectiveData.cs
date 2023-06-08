using ns24;

namespace Aspose.Slides;

public sealed class GradientFormatEffectiveData : IGradientFormatEffectiveData, IEffectiveData
{
	private TileFlip tileFlip_0;

	private GradientDirection gradientDirection_0;

	private float float_0;

	private bool bool_0;

	private GradientShape gradientShape_0;

	private Class1148 class1148_0 = new Class1148();

	private Class1148 class1148_1 = new Class1148();

	private GradientStopCollectionEffectiveData gradientStopCollectionEffectiveData_0;

	public TileFlip TileFlip => tileFlip_0;

	public GradientDirection GradientDirection => gradientDirection_0;

	public float LinearGradientAngle => float_0;

	public bool LinearGradientScaled => bool_0;

	public GradientShape GradientShape => gradientShape_0;

	public IGradientStopCollectionEffectiveData GradientStops => gradientStopCollectionEffectiveData_0;

	internal GradientFormatEffectiveData()
	{
		gradientStopCollectionEffectiveData_0 = new GradientStopCollectionEffectiveData();
		tileFlip_0 = TileFlip.NotDefined;
		gradientDirection_0 = GradientDirection.NotDefined;
		float_0 = float.NaN;
		bool_0 = false;
		gradientShape_0 = GradientShape.NotDefined;
		gradientStopCollectionEffectiveData_0.Clear();
	}

	internal GradientFormatEffectiveData(GradientFormat format, IBaseSlide slide, FloatColor styleColor)
		: this()
	{
		method_1(format, slide, styleColor);
	}

	internal void method_0(GradientFormat source, BaseSlide slide, FloatColor styleColor)
	{
		if (source == null)
		{
			return;
		}
		tileFlip_0 = source.tileFlip_0;
		gradientDirection_0 = source.GradientDirection;
		float_0 = source.float_2;
		bool_0 = source.nullableBool_0 == NullableBool.True;
		gradientShape_0 = source.gradientShape_0;
		class1148_0.method_0(source.TileRectangle);
		class1148_1.method_0(new Class1148(source.FillToRectangleX, source.FillToRectangleY, source.FillToRectangleWidth, source.FillToRectangleHeight));
		gradientStopCollectionEffectiveData_0.Clear();
		foreach (GradientStop item in source.gradientStopCollection_0)
		{
			gradientStopCollectionEffectiveData_0.Add(item.Position, ((ColorFormat)item.Color).method_5(slide, styleColor));
		}
	}

	internal void method_1(GradientFormat source, IBaseSlide slide, FloatColor styleColor)
	{
		if (source == null)
		{
			return;
		}
		if (source.tileFlip_0 != TileFlip.NotDefined)
		{
			tileFlip_0 = source.tileFlip_0;
		}
		if (source.GradientDirection != GradientDirection.NotDefined)
		{
			gradientDirection_0 = source.GradientDirection;
		}
		if (!float.IsNaN(source.float_2))
		{
			float_0 = source.float_2;
		}
		if (source.nullableBool_0 != NullableBool.NotDefined)
		{
			bool_0 = source.nullableBool_0 == NullableBool.True;
		}
		if (source.gradientShape_0 != GradientShape.NotDefined)
		{
			gradientShape_0 = source.gradientShape_0;
		}
		if (source.TileRectangle != null)
		{
			class1148_0.method_0(source.TileRectangle);
		}
		class1148_1.method_0(new Class1148(source.FillToRectangleX, source.FillToRectangleY, source.FillToRectangleWidth, source.FillToRectangleHeight));
		if (source.gradientStopCollection_0 == null || source.gradientStopCollection_0.Count <= 0)
		{
			return;
		}
		gradientStopCollectionEffectiveData_0.Clear();
		foreach (GradientStop item in source.gradientStopCollection_0)
		{
			gradientStopCollectionEffectiveData_0.Add(item.Position, ((ColorFormat)item.Color).method_5(slide, styleColor));
		}
	}

	public override bool Equals(object obj)
	{
		if (!(obj is GradientFormatEffectiveData gradientFormatEffectiveData))
		{
			return base.Equals(obj);
		}
		if (gradientDirection_0 != gradientFormatEffectiveData.gradientDirection_0)
		{
			return false;
		}
		if (gradientShape_0 != gradientFormatEffectiveData.gradientShape_0)
		{
			return false;
		}
		switch (gradientShape_0)
		{
		default:
			return true;
		case GradientShape.Linear:
			if (float_0 == gradientFormatEffectiveData.float_0 && bool_0 == gradientFormatEffectiveData.bool_0)
			{
				if (tileFlip_0 == gradientFormatEffectiveData.tileFlip_0 && gradientStopCollectionEffectiveData_0.Count == gradientFormatEffectiveData.gradientStopCollectionEffectiveData_0.Count)
				{
					int num = 0;
					while (true)
					{
						if (num < gradientStopCollectionEffectiveData_0.Count)
						{
							if (gradientStopCollectionEffectiveData_0[num].Position != gradientFormatEffectiveData.gradientStopCollectionEffectiveData_0[num].Position || gradientStopCollectionEffectiveData_0[num].Color != gradientFormatEffectiveData.gradientStopCollectionEffectiveData_0[num].Color)
							{
								break;
							}
							num++;
							continue;
						}
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		case GradientShape.Rectangle:
		case GradientShape.Radial:
			return gradientDirection_0 == gradientFormatEffectiveData.gradientDirection_0;
		}
	}

	public override int GetHashCode()
	{
		return 23456;
	}
}
