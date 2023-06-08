namespace ns36;

internal interface Interface12
{
	bool NotPlotted { get; set; }

	bool XNotPlotted { get; set; }

	bool Interpolated { get; set; }

	bool IsXValueError { get; set; }

	bool IsYValueError { get; set; }

	Interface6 Area { get; }

	Interface18 Border { get; }

	Interface19 Marker { get; }

	Interface13 DataLabels { get; }

	double XValue { get; set; }

	object XValueOriginal { get; set; }

	string XFormat { get; set; }

	bool XValueIsCulture { get; set; }

	double YValue { get; set; }

	object YValueOriginal { get; set; }

	string YFormat { get; set; }

	bool YValueIsCulture { get; set; }

	double BubbleSizeValue { get; set; }

	string BubbleSizeFormat { get; set; }

	bool BubbleSizeIsCulture { get; set; }

	int Explosion { get; set; }

	bool IsExplosionAuto { get; set; }

	bool IsShadow { get; set; }
}
