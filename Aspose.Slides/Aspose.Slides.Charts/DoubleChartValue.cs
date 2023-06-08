using System;
using System.Globalization;
using ns2;
using ns56;

namespace Aspose.Slides.Charts;

public class DoubleChartValue : BaseChartValue, IBaseChartValue, ISingleCellChartValue, IDoubleChartValue
{
	private ChartDataCell chartDataCell_0;

	private double double_0 = double.NaN;

	public IChartDataCell AsCell
	{
		get
		{
			if (base.DataSourceType != 0)
			{
				throw new InvalidOperationException("DataSourceType property value is not DataSourceType.Worksheet. And so this property is not actual. See BaseChartValue.DataSourceType property summary.");
			}
			return chartDataCell_0;
		}
		set
		{
			if (base.DataSourceType != 0)
			{
				throw new InvalidOperationException("DataSourceType property value is not DataSourceType.Worksheet. And so this property is not actual. See BaseChartValue.DataSourceType property summary.");
			}
			chartDataCell_0 = (ChartDataCell)value;
		}
	}

	public double AsLiteralDouble
	{
		get
		{
			if (base.DataSourceType != DataSourceType.DoubleLiterals)
			{
				throw new InvalidOperationException("DataSourceType property value is not DataSourceType.DoubleLiterals. And so this property is not actual. See BaseChartValue.DataSourceType property summary.");
			}
			return double_0;
		}
		set
		{
			if (base.DataSourceType != DataSourceType.DoubleLiterals)
			{
				throw new InvalidOperationException("DataSourceType property value is not DataSourceType.DoubleLiterals. And so this property is not actual. See BaseChartValue.DataSourceType property summary.");
			}
			double_0 = value;
		}
	}

	public override object Data
	{
		get
		{
			switch (base.DataSourceType)
			{
			case DataSourceType.Worksheet:
				if (chartDataCell_0 != null)
				{
					return chartDataCell_0.Value;
				}
				return null;
			default:
				throw new Exception();
			case DataSourceType.DoubleLiterals:
				if (double_0 == double.NaN)
				{
					return null;
				}
				return double_0;
			}
		}
		set
		{
			switch (base.DataSourceType)
			{
			case DataSourceType.Worksheet:
				if (value is ChartDataCell)
				{
					chartDataCell_0 = (ChartDataCell)value;
				}
				else
				{
					chartDataCell_0.method_3(value);
				}
				break;
			default:
				throw new Exception();
			case DataSourceType.DoubleLiterals:
				if (value == null)
				{
					double_0 = double.NaN;
					break;
				}
				if (!(value is double))
				{
					throw new ArgumentException("Assigned value is not appropriate to DataSourceType.");
				}
				double_0 = (double)value;
				break;
			}
		}
	}

	IBaseChartValue ISingleCellChartValue.AsIBaseChartValue => this;

	ISingleCellChartValue IDoubleChartValue.AsISingleCellChartValue => this;

	public double ToDouble()
	{
		switch (base.DataSourceType)
		{
		case DataSourceType.Worksheet:
			if (chartDataCell_0 != null && chartDataCell_0.Value != null && chartDataCell_0.Type != Enum262.const_3)
			{
				return Convert.ToDouble((!string.IsNullOrEmpty(chartDataCell_0.Value.ToString())) ? chartDataCell_0.Value : "0", CultureInfo.InvariantCulture);
			}
			return double.NaN;
		default:
			throw new Exception();
		case DataSourceType.DoubleLiterals:
			return double_0;
		}
	}

	internal DoubleChartValue(Class1035 dataSourceTypeHolder, bool centralizedTypeChangingRestriction)
		: base(dataSourceTypeHolder, centralizedTypeChangingRestriction)
	{
	}
}
