using System;
using ns2;

namespace Aspose.Slides.Charts;

public abstract class BaseChartValue : IBaseChartValue
{
	private Class1035 class1035_0;

	private DataSourceType dataSourceType_0;

	private bool bool_0;

	public DataSourceType DataSourceType
	{
		get
		{
			if (class1035_0 != null)
			{
				return class1035_0.DataSourceType;
			}
			return dataSourceType_0;
		}
		set
		{
			if (!bool_0)
			{
				if (class1035_0 != null)
				{
					class1035_0.DataSourceType = value;
				}
				else
				{
					dataSourceType_0 = value;
				}
				return;
			}
			throw new InvalidOperationException("This BaseChartValue instance is created with CentralizedTypeChangingRestriction and so DataSourceType is centralized managed with dataSourceTypeHolder whitch is passed as parameter into constructor.");
		}
	}

	public abstract object Data { get; set; }

	internal BaseChartValue(Class1035 dataSourceTypeHolder, bool centralizedTypeChangingRestriction)
	{
		if (bool_0 && dataSourceTypeHolder == null)
		{
			throw new ArgumentException("centralizedTypeChangingRestriction paranenter is true and so dataSourceTypeHolder can't be null");
		}
		bool_0 = centralizedTypeChangingRestriction;
		class1035_0 = dataSourceTypeHolder;
	}
}
