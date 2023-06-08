using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("985df8c2-9eb6-4748-840c-48469f61917f")]
public interface IChartDataPointCollection : ICollection, IEnumerable, IEnumerable<IChartDataPoint>
{
	IChartDataPoint this[int index] { get; }

	int this[IChartDataPoint pt] { get; }

	DataSourceType DataSourceTypeForXValues { get; set; }

	DataSourceType DataSourceTypeForYValues { get; set; }

	DataSourceType DataSourceTypeForBubbleSizes { get; set; }

	DataSourceType DataSourceTypeForValues { get; set; }

	IDataSourceTypeForErrorBarsCustomValues DataSourceTypeForErrorBarsCustomValues { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	IChartDataPoint GetOrCreateDataPointByIdx(uint idx);

	IChartDataPoint AddDataPointForLineSeries(IChartDataCell value);

	IChartDataPoint AddDataPointForLineSeries(double value);

	IChartDataPoint AddDataPointForScatterSeries(IChartDataCell xValue, IChartDataCell yValue);

	IChartDataPoint AddDataPointForScatterSeries(double xValue, IChartDataCell yValue);

	IChartDataPoint AddDataPointForScatterSeries(string xValue, IChartDataCell yValue);

	IChartDataPoint AddDataPointForScatterSeries(IChartDataCell xValue, double yValue);

	IChartDataPoint AddDataPointForScatterSeries(double xValue, double yValue);

	IChartDataPoint AddDataPointForScatterSeries(string xValue, double yValue);

	IChartDataPoint AddDataPointForRadarSeries(IChartDataCell value);

	IChartDataPoint AddDataPointForRadarSeries(double value);

	IChartDataPoint AddDataPointForBarSeries(IChartDataCell value);

	IChartDataPoint AddDataPointForBarSeries(double value);

	IChartDataPoint AddDataPointForAreaSeries(IChartDataCell value);

	IChartDataPoint AddDataPointForAreaSeries(double value);

	IChartDataPoint AddDataPointForPieSeries(IChartDataCell value);

	IChartDataPoint AddDataPointForPieSeries(double value);

	IChartDataPoint AddDataPointForBubbleSeries(IChartDataCell xValue, IChartDataCell yValue, IChartDataCell bubbleSize);

	IChartDataPoint AddDataPointForBubbleSeries(double xValue, IChartDataCell yValue, IChartDataCell bubbleSize);

	IChartDataPoint AddDataPointForBubbleSeries(string xValue, IChartDataCell yValue, IChartDataCell bubbleSize);

	IChartDataPoint AddDataPointForBubbleSeries(IChartDataCell xValue, double yValue, IChartDataCell bubbleSize);

	IChartDataPoint AddDataPointForBubbleSeries(double xValue, double yValue, IChartDataCell bubbleSize);

	IChartDataPoint AddDataPointForBubbleSeries(string xValue, double yValue, IChartDataCell bubbleSize);

	IChartDataPoint AddDataPointForBubbleSeries(IChartDataCell xValue, IChartDataCell yValue, double bubbleSize);

	IChartDataPoint AddDataPointForBubbleSeries(double xValue, IChartDataCell yValue, double bubbleSize);

	IChartDataPoint AddDataPointForBubbleSeries(string xValue, IChartDataCell yValue, double bubbleSize);

	IChartDataPoint AddDataPointForBubbleSeries(IChartDataCell xValue, double yValue, double bubbleSize);

	IChartDataPoint AddDataPointForBubbleSeries(double xValue, double yValue, double bubbleSize);

	IChartDataPoint AddDataPointForBubbleSeries(string xValue, double yValue, double bubbleSize);

	IChartDataPoint AddDataPointForSurfaceSeries(IChartDataCell value);

	IChartDataPoint AddDataPointForSurfaceSeries(double value);

	void Clear();

	void Remove(IChartDataPoint value);
}
