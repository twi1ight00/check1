using System;
using System.Runtime.InteropServices;
using ns2;

namespace Aspose.Slides.Charts;

[Guid("59b83c74-d1e6-4e59-949e-a849ec79fa9b")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class DataSourceTypeForErrorBarsCustomValues : IDataSourceTypeForErrorBarsCustomValues
{
	private Class1035 class1035_0 = new Class1035();

	private Class1035 class1035_1 = new Class1035();

	private Class1035 class1035_2 = new Class1035();

	private Class1035 class1035_3 = new Class1035();

	public DataSourceType DataSourceTypeForXMinusValues
	{
		get
		{
			return class1035_0.DataSourceType;
		}
		set
		{
			if (value != 0 && value != DataSourceType.DoubleLiterals)
			{
				throw new InvalidOperationException("DataSourceTypeForXMinus can be DataSourceType.Worksheet or DataSourceType.DoubleLiterals");
			}
			class1035_0.DataSourceType = value;
		}
	}

	public DataSourceType DataSourceTypeForXPlusValues
	{
		get
		{
			return class1035_1.DataSourceType;
		}
		set
		{
			if (value != 0 && value != DataSourceType.DoubleLiterals)
			{
				throw new InvalidOperationException("DataSourceTypeForXPlus can be DataSourceType.Worksheet or DataSourceType.DoubleLiterals");
			}
			class1035_1.DataSourceType = value;
		}
	}

	public DataSourceType DataSourceTypeForYMinusValues
	{
		get
		{
			return class1035_2.DataSourceType;
		}
		set
		{
			if (value != 0 && value != DataSourceType.DoubleLiterals)
			{
				throw new InvalidOperationException("DataSourceTypeForYMinus can be DataSourceType.Worksheet or DataSourceType.DoubleLiterals");
			}
			class1035_2.DataSourceType = value;
		}
	}

	public DataSourceType DataSourceTypeForYPlusValues
	{
		get
		{
			return class1035_3.DataSourceType;
		}
		set
		{
			if (value != 0 && value != DataSourceType.DoubleLiterals)
			{
				throw new InvalidOperationException("DataSourceTypeForYPlus can be DataSourceType.Worksheet or DataSourceType.DoubleLiterals");
			}
			class1035_3.DataSourceType = value;
		}
	}

	internal Class1035 method_0()
	{
		return class1035_0;
	}

	internal Class1035 method_1()
	{
		return class1035_1;
	}

	internal Class1035 method_2()
	{
		return class1035_2;
	}

	internal Class1035 method_3()
	{
		return class1035_3;
	}
}
