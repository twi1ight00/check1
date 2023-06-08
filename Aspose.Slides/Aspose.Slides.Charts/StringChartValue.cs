using System;
using System.ComponentModel;
using ns2;

namespace Aspose.Slides.Charts;

public class StringChartValue : BaseChartValue, IBaseChartValue, IMultipleCellChartValue, IStringChartValue
{
	private Chart chart_0;

	private string string_0;

	private ChartCellCollection chartCellCollection_0;

	public IChartCellCollection AsCells
	{
		get
		{
			if (base.DataSourceType != 0)
			{
				throw new InvalidOperationException("DataSourceType property value is not DataSourceType.Worksheet. And so this property is not actual. See BaseChartValue.DataSourceType property summary.");
			}
			return chartCellCollection_0;
		}
		set
		{
			if (base.DataSourceType != 0)
			{
				throw new InvalidOperationException("DataSourceType property value is not DataSourceType.Worksheet. And so this property is not actual. See BaseChartValue.DataSourceType property summary.");
			}
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			chartCellCollection_0 = (ChartCellCollection)value;
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

	public override object Data
	{
		get
		{
			return base.DataSourceType switch
			{
				DataSourceType.Worksheet => chartCellCollection_0, 
				DataSourceType.StringLiterals => string_0, 
				_ => throw new Exception(), 
			};
		}
		set
		{
			switch (base.DataSourceType)
			{
			default:
				throw new InvalidOperationException();
			case DataSourceType.Worksheet:
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				if (value is IChartDataCell)
				{
					SetFromOneCell((IChartDataCell)value);
					break;
				}
				if (value is IChartCellCollection)
				{
					chartCellCollection_0 = (ChartCellCollection)value;
					break;
				}
				throw new ArgumentException("Assigned value is not appropriate to DataSourceType.");
			case DataSourceType.StringLiterals:
				if (!(value is string))
				{
					throw new ArgumentException("Assigned value is not appropriate to DataSourceType.");
				}
				string_0 = (string)value;
				break;
			}
		}
	}

	IBaseChartValue IMultipleCellChartValue.AsIBaseChartValue => this;

	IMultipleCellChartValue IStringChartValue.AsIMultipleCellChartValue => this;

	public override string ToString()
	{
		return base.DataSourceType switch
		{
			DataSourceType.Worksheet => chartCellCollection_0.GetConcatenatedValuesFromCells(), 
			DataSourceType.StringLiterals => string_0, 
			_ => throw new InvalidEnumArgumentException(), 
		};
	}

	public void SetFromOneCell(IChartDataCell cell)
	{
		if (base.DataSourceType != 0)
		{
			throw new InvalidOperationException("DataSourceType property value is not DataSourceType.Worksheet. And so this property is not actual. See BaseChartValue.DataSourceType property summary.");
		}
		chartCellCollection_0 = new ChartCellCollection(chart_0);
		chartCellCollection_0.Add(cell);
	}

	public string GetCellsAddressInWorkbook()
	{
		if (base.DataSourceType != 0)
		{
			return "";
		}
		return chartCellCollection_0.GetCellsAddress();
	}

	internal StringChartValue(Chart parent, Class1035 dataSourceTypeHolder, bool centralizedTypeChangingRestriction)
		: base(dataSourceTypeHolder, centralizedTypeChangingRestriction)
	{
		chart_0 = parent;
		chartCellCollection_0 = new ChartCellCollection(chart_0);
	}
}
