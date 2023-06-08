using System.Collections;
using System.Data;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Data.DataColumn" /> 类型扩展方法
/// </summary>
public static class DataColumnExtensions
{
	/// <summary>
	/// 复制当前数据列，生成一个具有相同属性的，不属于任何数据表的新数据列。
	/// </summary>
	/// <param name="column">当前数据列</param>
	/// <returns>复制的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据列为空。</exception>
	public static DataColumn Copy(this DataColumn column)
	{
		column.GuardNotNull("column");
		DataColumn newColumn = new DataColumn();
		newColumn.AllowDBNull = column.AllowDBNull;
		newColumn.AutoIncrement = column.AutoIncrement;
		newColumn.AutoIncrementSeed = column.AutoIncrementSeed;
		newColumn.AutoIncrementStep = column.AutoIncrementStep;
		newColumn.Caption = column.Caption;
		newColumn.ColumnMapping = column.ColumnMapping;
		newColumn.ColumnName = column.ColumnName;
		newColumn.DataType = column.DataType;
		newColumn.DateTimeMode = column.DateTimeMode;
		newColumn.DefaultValue = column.DefaultValue;
		newColumn.Expression = column.Expression;
		newColumn.MaxLength = column.MaxLength;
		newColumn.Namespace = column.Namespace;
		newColumn.Prefix = column.Prefix;
		newColumn.ReadOnly = column.ReadOnly;
		newColumn.Unique = column.Unique;
		foreach (DictionaryEntry kvp in column.ExtendedProperties)
		{
			newColumn.ExtendedProperties.Add(kvp.Key, kvp.Value);
		}
		return newColumn;
	}
}
