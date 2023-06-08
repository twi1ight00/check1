using System;
using System.Globalization;
using ns2;
using ns56;

namespace Aspose.Slides.Charts;

public class StringOrDoubleChartValue : BaseChartValue, IBaseChartValue, ISingleCellChartValue, IStringOrDoubleChartValue
{
	private ChartDataCell chartDataCell_0;

	private string string_0;

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

	public string AsLiteralString
	{
		get
		{
			if (base.DataSourceType != DataSourceType.StringLiterals)
			{
				throw new InvalidOperationException("DataSourceType property value is not DataSourceType.StringLiterals. And so this property is not actual. See BaseChartValue.DataSourceType property summary.");
			}
			return string_0;
		}
		set
		{
			if (base.DataSourceType != DataSourceType.StringLiterals)
			{
				throw new InvalidOperationException("DataSourceType property value is not DataSourceType.StringLiterals. And so this property is not actual. See BaseChartValue.DataSourceType property summary.");
			}
			string_0 = value;
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
			default:
				throw new Exception();
			case DataSourceType.Worksheet:
				if (chartDataCell_0 != null)
				{
					return chartDataCell_0.Value;
				}
				return null;
			case DataSourceType.StringLiterals:
				return string_0;
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
			default:
				throw new InvalidOperationException();
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
			case DataSourceType.StringLiterals:
				if (!(value is string))
				{
					throw new ArgumentException("Assigned value is not appropriate to DataSourceType.");
				}
				string_0 = (string)value;
				break;
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

	ISingleCellChartValue IStringOrDoubleChartValue.AsISingleCellChartValue => this;

	public double ToDouble()
	{
		switch (base.DataSourceType)
		{
		default:
			throw new Exception();
		case DataSourceType.Worksheet:
			if (chartDataCell_0 != null && chartDataCell_0.Value != null && chartDataCell_0.Type != Enum262.const_3)
			{
				return Convert.ToDouble(chartDataCell_0.Value, CultureInfo.InvariantCulture);
			}
			return double.NaN;
		case DataSourceType.StringLiterals:
			return Convert.ToDouble(string_0, CultureInfo.InvariantCulture);
		case DataSourceType.DoubleLiterals:
			return double_0;
		}
	}

	internal StringOrDoubleChartValue(Class1035 dataSourceTypeHolder, bool centralizedTypeChangingRestriction)
		: base(dataSourceTypeHolder, centralizedTypeChangingRestriction)
	{
	}
}
