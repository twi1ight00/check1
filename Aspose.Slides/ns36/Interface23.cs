using Aspose.Slides.Charts;

namespace ns36;

internal interface Interface23
{
	Interface18 Border { get; }

	Interface22 Trendlines { get; }

	double Backward { get; set; }

	bool DisplayEquation { get; set; }

	bool DisplayRSquared { get; set; }

	double Forward { get; set; }

	double Intercept { get; set; }

	bool IsNameAuto { get; set; }

	string Name { get; set; }

	int Order { get; set; }

	int Period { get; set; }

	TrendlineType Type { get; set; }

	Interface13 DataLabels { get; }

	int ID { get; set; }
}
