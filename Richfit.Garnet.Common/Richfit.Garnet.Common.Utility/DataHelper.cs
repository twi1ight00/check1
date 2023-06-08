#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// 数据对象辅助类
/// </summary>
public static class DataHelper
{
	/// <summary>
	/// 复制当前数据列，生成一个具有相同属性的，不属于任何数据表的新数据列。
	/// </summary>
	/// <param name="column">当前数据列</param>
	/// <returns>复制的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据列为空。</exception>
	public static DataColumn Copy(DataColumn column)
	{
		Guard.AssertNotNull(column, "column");
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

	/// <summary>
	/// 复制当前数据行，制作数据行中存储的列值的浅表副本
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <returns>当前数据行的副本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	public static DataRow Copy(DataRow row)
	{
		Guard.AssertNotNull(row, "row");
		DataRow newRow = row.Table.NewRow();
		newRow.ItemArray = row.ItemArray;
		return newRow;
	}

	/// <summary>
	/// 复制当前数据行，制作数据行中存储的列值的浅表副本
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <returns>当前数据行的副本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	public static R Copy<R>(R row) where R : DataRow
	{
		Guard.AssertNotNull(row, "row");
		return (R)Copy((DataRow)row);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Boolean" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static bool GetBoolean(DataRow row, DataColumn column, bool defaultValue = false)
	{
		return GetValue(row, column, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Boolean" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="version">获取值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static bool GetBoolean(DataRow row, DataColumn column, DataRowVersion version, bool defaultValue = false)
	{
		return GetValue(row, column, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Boolean" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static bool GetBoolean(DataRow row, int columnIndex, bool defaultValue = false)
	{
		return GetValue(row, columnIndex, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Boolean" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">获取值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static bool GetBoolean(DataRow row, int columnIndex, DataRowVersion version, bool defaultValue = false)
	{
		return GetValue(row, columnIndex, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Boolean" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列的名称</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static bool GetBoolean(DataRow row, string columnName, bool defaultValue = false)
	{
		return GetValue(row, columnName, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Boolean" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列的名称</param>
	/// <param name="version">获取值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static bool GetBoolean(DataRow row, string columnName, DataRowVersion version, bool defaultValue = false)
	{
		return GetValue(row, columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Byte" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列名称</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static int GetByte(DataRow row, DataColumn column, byte defaultValue = 0)
	{
		return GetValue(row, column, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Byte" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列名称</param>
	/// <param name="version">获取值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static int GetByte(DataRow row, DataColumn column, DataRowVersion version, byte defaultValue = 0)
	{
		return GetValue(row, column, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Byte" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static int GetByte(DataRow row, int columnIndex, byte defaultValue = 0)
	{
		return GetValue(row, columnIndex, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Byte" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">获取值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static int GetByte(DataRow row, int columnIndex, DataRowVersion version, byte defaultValue = 0)
	{
		return GetValue(row, columnIndex, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Byte" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列名称</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static int GetByte(DataRow row, string columnName, byte defaultValue = 0)
	{
		return GetValue(row, columnName, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Byte" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列名称</param>
	/// <param name="version">获取值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static int GetByte(DataRow row, string columnName, DataRowVersion version, byte defaultValue = 0)
	{
		return GetValue(row, columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Byte" /> 类型的数组
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static byte[] GetBytes(DataRow row, DataColumn column, byte[] defaultValue = null)
	{
		return GetValue(row, column, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Byte" /> 类型的数组
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="version">获取值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static byte[] GetBytes(DataRow row, DataColumn column, DataRowVersion version, byte[] defaultValue = null)
	{
		return GetValue(row, column, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Byte" /> 类型的数组
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static byte[] GetBytes(DataRow row, int columnIndex, byte[] defaultValue = null)
	{
		return GetValue(row, columnIndex, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Byte" /> 类型的数组
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">获取值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static byte[] GetBytes(DataRow row, int columnIndex, DataRowVersion version, byte[] defaultValue = null)
	{
		return GetValue(row, columnIndex, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Byte" /> 类型的数组
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列名称</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static byte[] GetBytes(DataRow row, string columnName, byte[] defaultValue = null)
	{
		return GetValue(row, columnName, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Byte" /> 类型的数组
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列名称</param>
	/// <param name="version">获取值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static byte[] GetBytes(DataRow row, string columnName, DataRowVersion version, byte[] defaultValue = null)
	{
		return GetValue(row, columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.DateTime" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值，默认为 <see cref="F:System.DateTime.MinValue" />。</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static DateTime GetDateTime(DataRow row, DataColumn column, DateTime? defaultValue = null)
	{
		return GetValue(row, column, ObjectHelper.IfNull(defaultValue, DateTime.MinValue).Value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.DateTime" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="version">获取值的版本</param>
	/// <param name="defaultValue">数据列的默认值，默认为 <see cref="F:System.DateTime.MinValue" />。</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static DateTime GetDateTime(DataRow row, DataColumn column, DataRowVersion version, DateTime? defaultValue = null)
	{
		return GetValue(row, column, version, ObjectHelper.IfNull(defaultValue, DateTime.MinValue).Value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.DateTime" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="defaultValue">数据列的默认值，默认为 <see cref="F:System.DateTime.MinValue" />。</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static DateTime GetDateTime(DataRow row, int columnIndex, DateTime? defaultValue = null)
	{
		return GetValue(row, columnIndex, ObjectHelper.IfNull(defaultValue, DateTime.MinValue).Value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.DateTime" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">获取的列值的版本</param>
	/// <param name="defaultValue">数据列的默认值，默认为 <see cref="F:System.DateTime.MinValue" />。</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static DateTime GetDateTime(DataRow row, int columnIndex, DataRowVersion version, DateTime? defaultValue = null)
	{
		return GetValue(row, columnIndex, version, ObjectHelper.IfNull(defaultValue, DateTime.MinValue).Value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.DateTime" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列的名称</param>
	/// <param name="defaultValue">数据列的默认值，默认为 <see cref="F:System.DateTime.MinValue" />。</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static DateTime GetDateTime(DataRow row, string columnName, DateTime? defaultValue = null)
	{
		return GetValue(row, columnName, ObjectHelper.IsNull(defaultValue) ? DateTime.MinValue : defaultValue.Value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.DateTime" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列的名称</param>
	/// <param name="version">获取的列值的版本</param>
	/// <param name="defaultValue">数据列的默认值，默认为 <see cref="F:System.DateTime.MinValue" />。</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static DateTime GetDateTime(DataRow row, string columnName, DataRowVersion version, DateTime? defaultValue = null)
	{
		return GetValue(row, columnName, version, ObjectHelper.IfNull(defaultValue, DateTime.MinValue).Value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.DateTimeOffset" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值，默认为 <see cref="F:System.DateTime.MinValue" />。</param>
	/// <param name="defaultTimeZone">默认的时区， 默认为 <see cref="F:System.TimeSpan.Zero" />。</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static DateTimeOffset GetDateTimeOffset(DataRow row, DataColumn column, DateTime? defaultValue = null, TimeSpan? defaultTimeZone = null)
	{
		return new DateTimeOffset(GetDateTime(row, column, defaultValue), ObjectHelper.IsNull(defaultTimeZone) ? TimeSpan.Zero : defaultTimeZone.Value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.DateTimeOffset" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="version">获取值的版本</param>
	/// <param name="defaultValue">数据列的默认值，默认为 <see cref="F:System.DateTime.MinValue" />。</param>
	/// <param name="defaultTimeZone">默认的时区， 默认为 <see cref="F:System.TimeSpan.Zero" />。</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static DateTimeOffset GetDateTimeOffset(DataRow row, DataColumn column, DataRowVersion version, DateTime? defaultValue = null, TimeSpan? defaultTimeZone = null)
	{
		return new DateTimeOffset(GetDateTime(row, column, version, defaultValue), ObjectHelper.IsNull(defaultTimeZone) ? TimeSpan.Zero : defaultTimeZone.Value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.DateTimeOffset" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="defaultValue">数据列的默认值，默认为 <see cref="F:System.DateTime.MinValue" />。</param>
	/// <param name="defaultTimeZone">默认的时区， 默认为 <see cref="F:System.TimeSpan.Zero" />。</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static DateTimeOffset GetDateTimeOffset(DataRow row, int columnIndex, DateTime? defaultValue = null, TimeSpan? defaultTimeZone = null)
	{
		return new DateTimeOffset(GetDateTime(row, columnIndex, defaultValue), ObjectHelper.IsNull(defaultTimeZone) ? TimeSpan.Zero : defaultTimeZone.Value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.DateTimeOffset" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">获取的值的版本</param>
	/// <param name="defaultValue">数据列的默认值，默认为 <see cref="F:System.DateTime.MinValue" />。</param>
	/// <param name="defaultTimeZone">默认的时区， 默认为 <see cref="F:System.TimeSpan.Zero" />。</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static DateTimeOffset GetDateTimeOffset(DataRow row, int columnIndex, DataRowVersion version, DateTime? defaultValue = null, TimeSpan? defaultTimeZone = null)
	{
		return new DateTimeOffset(GetDateTime(row, columnIndex, version, defaultValue), ObjectHelper.IsNull(defaultTimeZone) ? TimeSpan.Zero : defaultTimeZone.Value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.DateTimeOffset" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列的名称</param>
	/// <param name="defaultValue">数据列的默认值，默认为 <see cref="F:System.DateTime.MinValue" />。</param>
	/// <param name="defaultTimeZone">默认的时区， 默认为 <see cref="F:System.TimeSpan.Zero" />。</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static DateTimeOffset GetDateTimeOffset(DataRow row, string columnName, DateTime? defaultValue = null, TimeSpan? defaultTimeZone = null)
	{
		return new DateTimeOffset(GetDateTime(row, columnName, defaultValue), ObjectHelper.IsNull(defaultTimeZone) ? TimeSpan.Zero : defaultTimeZone.Value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.DateTimeOffset" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列的名称</param>
	/// <param name="version">获取值的版本</param>
	/// <param name="defaultValue">数据列的默认值，默认为 <see cref="F:System.DateTime.MinValue" />。</param>
	/// <param name="defaultTimeZone">默认的时区， 默认为 <see cref="F:System.TimeSpan.Zero" />。</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static DateTimeOffset GetDateTimeOffset(DataRow row, string columnName, DataRowVersion version, DateTime? defaultValue = null, TimeSpan? defaultTimeZone = null)
	{
		return new DateTimeOffset(GetDateTime(row, columnName, version, defaultValue), ObjectHelper.IsNull(defaultTimeZone) ? TimeSpan.Zero : defaultTimeZone.Value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Decimal" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static decimal GetDecimal(DataRow row, DataColumn column, decimal defaultValue = 0m)
	{
		return GetValue(row, column, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Decimal" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="version">获取数值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static decimal GetDecimal(DataRow row, DataColumn column, DataRowVersion version, decimal defaultValue = 0m)
	{
		return GetValue(row, column, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Decimal" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的数据列的索引</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static decimal GetDecimal(DataRow row, int columnIndex, decimal defaultValue = 0m)
	{
		return GetValue(row, columnIndex, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Decimal" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的数据列的索引</param>
	/// <param name="version">获取数值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static decimal GetDecimal(DataRow row, int columnIndex, DataRowVersion version, decimal defaultValue = 0m)
	{
		return GetValue(row, columnIndex, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Decimal" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的数据列的名称</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static decimal GetDecimal(DataRow row, string columnName, decimal defaultValue = 0m)
	{
		return GetValue(row, columnName, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Decimal" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的数据列的名称</param>
	/// <param name="version">获取数值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static decimal GetDecimal(DataRow row, string columnName, DataRowVersion version, decimal defaultValue = 0m)
	{
		return GetValue(row, columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Double" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static double GetDouble(DataRow row, DataColumn column, double defaultValue = 0.0)
	{
		return GetValue(row, column, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Double" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="version">获取数值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static double GetDouble(DataRow row, DataColumn column, DataRowVersion version, double defaultValue = 0.0)
	{
		return GetValue(row, column, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Double" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的数据列的索引</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static double GetDouble(DataRow row, int columnIndex, double defaultValue = 0.0)
	{
		return GetValue(row, columnIndex, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Double" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的数据列的索引</param>
	/// <param name="version">获取数值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static double GetDouble(DataRow row, int columnIndex, DataRowVersion version, double defaultValue = 0.0)
	{
		return GetValue(row, columnIndex, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Double" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的数据列的名称</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static double GetDouble(DataRow row, string columnName, double defaultValue = 0.0)
	{
		return GetValue(row, columnName, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Double" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的数据列的名称</param>
	/// <param name="version">获取数值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static double GetDouble(DataRow row, string columnName, DataRowVersion version, double defaultValue = 0.0)
	{
		return GetValue(row, columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Guid" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static Guid GetGuid(DataRow row, DataColumn column, Guid? defaultValue = null)
	{
		return GetGuid(row, column, DataRowVersion.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Guid" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="version">获取数值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static Guid GetGuid(DataRow row, DataColumn column, DataRowVersion version, Guid? defaultValue = null)
	{
		Guid? value = GetValue(row, column, version, ConvertToGuid);
		defaultValue = ObjectHelper.IfNull(defaultValue, Guid.Empty);
		return ObjectHelper.IsNull(value) ? defaultValue.Value : value.Value;
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Guid" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static Guid GetGuid(DataRow row, int columnIndex, Guid? defaultValue = null)
	{
		return GetGuid(row, columnIndex, DataRowVersion.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Guid" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">获取数值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static Guid GetGuid(DataRow row, int columnIndex, DataRowVersion version, Guid? defaultValue = null)
	{
		Guid? value = GetValue(row, columnIndex, version, ConvertToGuid);
		defaultValue = ObjectHelper.IfNull(defaultValue, Guid.Empty);
		return ObjectHelper.IsNull(value) ? defaultValue.Value : value.Value;
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Guid" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列的名称</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static Guid GetGuid(DataRow row, string columnName, Guid? defaultValue = null)
	{
		return GetGuid(row, columnName, DataRowVersion.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Guid" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列的名称</param>
	/// <param name="version">获取数值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static Guid GetGuid(DataRow row, string columnName, DataRowVersion version, Guid? defaultValue = null)
	{
		Guid? value = GetValue(row, columnName, ConvertToGuid);
		defaultValue = ObjectHelper.IfNull(defaultValue, Guid.Empty);
		return ObjectHelper.IsNull(value) ? defaultValue.Value : value.Value;
	}

	private static Guid? ConvertToGuid(object value)
	{
		if (ObjectHelper.IsNullOrDBNull(value))
		{
			return null;
		}
		if (value is byte[])
		{
			byte[] bs = ObjectHelper.As<byte[]>(value);
			if (bs.Length == 16)
			{
				return new Guid(bs);
			}
		}
		else if (value is string)
		{
			string s = ObjectHelper.As<string>(value);
			if (Guid.TryParse(s, out var guid))
			{
				return guid;
			}
		}
		else if (value is Guid)
		{
			return (Guid)value;
		}
		throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(Guid).FullName));
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int16" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static short GetInt16(DataRow row, DataColumn column, short defaultValue = 0)
	{
		return GetValue(row, column, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int16" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="version">获取的数值版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static short GetInt16(DataRow row, DataColumn column, DataRowVersion version, short defaultValue = 0)
	{
		return GetValue(row, column, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int16" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static short GetInt16(DataRow row, int columnIndex, short defaultValue = 0)
	{
		return GetValue(row, columnIndex, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int16" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">获取的数值版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static short GetInt16(DataRow row, int columnIndex, DataRowVersion version, short defaultValue = 0)
	{
		return GetValue(row, columnIndex, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int16" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列名称</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static short GetInt16(DataRow row, string columnName, short defaultValue = 0)
	{
		return GetValue(row, columnName, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int16" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列名称</param>
	/// <param name="version">获取的数值版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static short GetInt16(DataRow row, string columnName, DataRowVersion version, short defaultValue = 0)
	{
		return GetValue(row, columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int32" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static int GetInt32(DataRow row, DataColumn column, int defaultValue = 0)
	{
		return GetValue(row, column, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int32" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="version">获取的数值版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static int GetInt32(DataRow row, DataColumn column, DataRowVersion version, int defaultValue = 0)
	{
		return GetValue(row, column, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int32" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static int GetInt32(DataRow row, int columnIndex, int defaultValue = 0)
	{
		return GetValue(row, columnIndex, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int32" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">获取的数值版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static int GetInt32(DataRow row, int columnIndex, DataRowVersion version, int defaultValue = 0)
	{
		return GetValue(row, columnIndex, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int32" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列名称</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static int GetInt32(DataRow row, string columnName, int defaultValue = 0)
	{
		return GetValue(row, columnName, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int32" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列名称</param>
	/// <param name="version">获取的数值版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static int GetInt32(DataRow row, string columnName, DataRowVersion version, int defaultValue = 0)
	{
		return GetValue(row, columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int64" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static long GetInt64(DataRow row, DataColumn column, long defaultValue = 0L)
	{
		return GetValue(row, column, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int64" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="version">获取的数据版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static long GetInt64(DataRow row, DataColumn column, DataRowVersion version, long defaultValue = 0L)
	{
		return GetValue(row, column, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int64" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static long GetInt64(DataRow row, int columnIndex, long defaultValue = 0L)
	{
		return GetValue(row, columnIndex, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int64" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">获取的数据版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static long GetInt64(DataRow row, int columnIndex, DataRowVersion version, long defaultValue = 0L)
	{
		return GetValue(row, columnIndex, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int64" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列名称</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static long GetInt64(DataRow row, string columnName, long defaultValue = 0L)
	{
		return GetValue(row, columnName, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int64" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列名称</param>
	/// <param name="version">获取的数据版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static long GetInt64(DataRow row, string columnName, DataRowVersion version, long defaultValue = 0L)
	{
		return GetValue(row, columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.SByte" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static sbyte GetSByte(DataRow row, DataColumn column, sbyte defaultValue = 0)
	{
		return GetValue(row, column, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.SByte" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="version">获取的数据版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static sbyte GetSByte(DataRow row, DataColumn column, DataRowVersion version, sbyte defaultValue = 0)
	{
		return GetValue(row, column, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.SByte" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的数据列的索引</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static sbyte GetSByte(DataRow row, int columnIndex, sbyte defaultValue = 0)
	{
		return GetValue(row, columnIndex, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.SByte" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的数据列的索引</param>
	/// <param name="version">获取的数据版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static sbyte GetSByte(DataRow row, int columnIndex, DataRowVersion version, sbyte defaultValue = 0)
	{
		return GetValue(row, columnIndex, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.SByte" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的数据列的名称</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static sbyte GetSByte(DataRow row, string columnName, sbyte defaultValue = 0)
	{
		return GetValue(row, columnName, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.SByte" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的数据列的名称</param>
	/// <param name="version">获取的数据版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static sbyte GetSByte(DataRow row, string columnName, DataRowVersion version, sbyte defaultValue = 0)
	{
		return GetValue(row, columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Single" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static float GetSingle(DataRow row, DataColumn column, float defaultValue = 0f)
	{
		return GetValue(row, column, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Single" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="version">获取的数值版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static float GetSingle(DataRow row, DataColumn column, DataRowVersion version, float defaultValue = 0f)
	{
		return GetValue(row, column, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Single" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的数据列的索引</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static float GetSingle(DataRow row, int columnIndex, float defaultValue = 0f)
	{
		return GetValue(row, columnIndex, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Single" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的数据列的索引</param>
	/// <param name="version">获取的数值版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static float GetSingle(DataRow row, int columnIndex, DataRowVersion version, float defaultValue = 0f)
	{
		return GetValue(row, columnIndex, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Single" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的数据列的名称</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static float GetSingle(DataRow row, string columnName, float defaultValue = 0f)
	{
		return GetValue(row, columnName, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Single" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的数据列的名称</param>
	/// <param name="version">获取的数值版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static float GetSingle(DataRow row, string columnName, DataRowVersion version, float defaultValue = 0f)
	{
		return GetValue(row, columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.String" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static string GetString(DataRow row, DataColumn column, string defaultValue = "")
	{
		return GetString(row, column, DataRowVersion.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.String" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="version">获取的数据版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static string GetString(DataRow row, DataColumn column, DataRowVersion version, string defaultValue = "")
	{
		object value = GetValue(row, column, version);
		return ObjectHelper.IsNullOrDBNull(value) ? defaultValue : value.ToString();
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.String" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="format">数据列的格式化字符串</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static string GetString(DataRow row, DataColumn column, string format, string defaultValue = "")
	{
		return GetString(row, column, DataRowVersion.Default, format, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.String" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="version">获取的数据版本</param>
	/// <param name="format">数据列的格式化字符串</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static string GetString(DataRow row, DataColumn column, DataRowVersion version, string format, string defaultValue = "")
	{
		object value = GetValue(row, column, version);
		return ObjectHelper.IsNullOrDBNull(value) ? defaultValue : string.Format(ObjectHelper.IfNull(format, "{0}"), value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.String" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static string GetString(DataRow row, int columnIndex, string defaultValue = "")
	{
		return GetString(row, columnIndex, DataRowVersion.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.String" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">获取的数据版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static string GetString(DataRow row, int columnIndex, DataRowVersion version, string defaultValue = "")
	{
		object value = GetValue(row, columnIndex, version);
		return ObjectHelper.IsNullOrDBNull(value) ? defaultValue : value.ToString();
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.String" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="format">数据列的格式化字符串</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static string GetString(DataRow row, int columnIndex, string format, string defaultValue = "")
	{
		return GetString(row, columnIndex, DataRowVersion.Default, format, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.String" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">获取的数据版本</param>
	/// <param name="format">数据列的格式化字符串</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static string GetString(DataRow row, int columnIndex, DataRowVersion version, string format, string defaultValue = "")
	{
		object value = GetValue(row, columnIndex, version);
		return ObjectHelper.IsNullOrDBNull(value) ? defaultValue : string.Format(ObjectHelper.IfNull(format, "{0}"), value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.String" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列名称</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static string GetString(DataRow row, string columnName, string defaultValue = "")
	{
		return GetString(row, columnName, DataRowVersion.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.String" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列名称</param>
	/// <param name="version">获取的数据版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static string GetString(DataRow row, string columnName, DataRowVersion version, string defaultValue = "")
	{
		object value = GetValue(row, columnName, version);
		return ObjectHelper.IsNullOrDBNull(value) ? defaultValue : value.ToString();
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.String" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列名称</param>
	/// <param name="format">数据列的格式化字符串</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static string GetString(DataRow row, string columnName, string format, string defaultValue = "")
	{
		return GetString(row, columnName, DataRowVersion.Default, format, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.String" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列名称</param>
	/// <param name="version">获取的数据版本</param>
	/// <param name="format">数据列的格式化字符串</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static string GetString(DataRow row, string columnName, DataRowVersion version, string format, string defaultValue = "")
	{
		object value = GetValue(row, columnName, version);
		return ObjectHelper.IsNullOrDBNull(value) ? defaultValue : string.Format(ObjectHelper.IfNull(format, "{0}"), value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Type" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="defaultValue">列值的默认值</param>
	/// <returns>当前数据行指定的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static Type GetType(DataRow row, DataColumn column, Type defaultValue = null)
	{
		return GetType(row, column, DataRowVersion.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Type" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="version">获取的数据版本</param>
	/// <param name="defaultValue">列值的默认值</param>
	/// <returns>当前数据行指定的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static Type GetType(DataRow row, DataColumn column, DataRowVersion version, Type defaultValue = null)
	{
		Type type = GetValue(row, column, version, ConvertToType);
		return ObjectHelper.IsNull(type) ? defaultValue : type;
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Type" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="defaultValue">列值的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static Type GetType(DataRow row, int columnIndex, Type defaultValue = null)
	{
		return GetType(row, columnIndex, DataRowVersion.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Type" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">获取的数据版本</param>
	/// <param name="defaultValue">列值的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static Type GetType(DataRow row, int columnIndex, DataRowVersion version, Type defaultValue = null)
	{
		Type type = GetValue(row, columnIndex, version, ConvertToType);
		return ObjectHelper.IsNull(type) ? defaultValue : type;
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Type" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列的名称</param>
	/// <param name="defaultValue">列值的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static Type GetType(DataRow row, string columnName, Type defaultValue = null)
	{
		return GetType(row, columnName, DataRowVersion.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Type" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">获取值的列的名称</param>
	/// <param name="version">获取的数据行版本</param>
	/// <param name="defaultValue">列值的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static Type GetType(DataRow row, string columnName, DataRowVersion version, Type defaultValue = null)
	{
		Type type = GetValue(row, columnName, version, ConvertToType);
		return ObjectHelper.IsNull(type) ? defaultValue : type;
	}

	private static Type ConvertToType(object value)
	{
		if (ObjectHelper.IsNullOrDBNull(value))
		{
			return null;
		}
		if (value is string)
		{
			return TypeHelper.ResolveType(ObjectHelper.As<string>(value));
		}
		if (value is Type)
		{
			return (Type)value;
		}
		throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(Guid).FullName));
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <returns>当前数据行中指定数据列的值。如果指定的列的值为空，则返回 <see cref="T:System.DBNull" />。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static object GetValue(DataRow row, DataColumn column)
	{
		return GetValue(row, column, DataRowVersion.Default);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">数据列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值；如果指定的列的值为 <see cref="T:System.DBNull" />，则返回 <paramref name="defaultValue" />。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static T GetValue<T>(DataRow row, DataColumn column, T defaultValue = default(T))
	{
		return GetValue(row, column, DataRowVersion.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">数据列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="evaluation">获取的列值的处理方法</param>
	/// <returns>当前数据行指定列的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T GetValue<T>(DataRow row, DataColumn column, Func<object, T> evaluation)
	{
		return GetValue(row, column, DataRowVersion.Default, evaluation);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="version">要获取的数据值的版本</param>
	/// <returns>当前数据行中指定数据列的值。如果指定的列的值为空，则返回 <see cref="T:System.DBNull" />。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static object GetValue(DataRow row, DataColumn column, DataRowVersion version)
	{
		Guard.AssertNotNull(row, "row");
		Guard.AssertNotNull(column, "column");
		return ConvertHelper.EnsureDBNull(row[column, version]);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">数据列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="version">要获取的数据值的版本</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值；如果指定的列的值为 <see cref="T:System.DBNull" />，则返回 <paramref name="defaultValue" />。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static T GetValue<T>(DataRow row, DataColumn column, DataRowVersion version, T defaultValue = default(T))
	{
		return ObjectHelper.As<T>(ObjectHelper.IfNullOrDBNull(GetValue(row, column, version), defaultValue));
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">数据列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="version">要获取的数据值的版本</param>
	/// <param name="evaluation">获取的列值的处理方法</param>
	/// <returns>当前数据行指定列的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T GetValue<T>(DataRow row, DataColumn column, DataRowVersion version, Func<object, T> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return evaluation(GetValue(row, column, version));
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <returns>当前数据行指定列的值；如果指定的列的值为空，则返回 <see cref="T:System.DBNull" />。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static object GetValue(DataRow row, int columnIndex)
	{
		return GetValue(row, columnIndex, DataRowVersion.Default);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">获取的列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="defaultValue">列值的默认值。获取的列值为 <see cref="T:System.DBNull" /> 时，返回该值。</param>
	/// <returns>当前数据行指定列的值；如果指定的列的值为 <see cref="T:System.DBNull" />，则返回 <paramref name="defaultValue" />。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static T GetValue<T>(DataRow row, int columnIndex, T defaultValue = default(T))
	{
		return GetValue(row, columnIndex, DataRowVersion.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">获取的列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="evaluation">获取的列值的处理方法。</param>
	/// <returns>当前数据行指定列的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static T GetValue<T>(DataRow row, int columnIndex, Func<object, T> evaluation)
	{
		return GetValue(row, columnIndex, DataRowVersion.Default, evaluation);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">要获取的数据值的版本</param>
	/// <returns>当前数据行指定列的值；如果指定的列的值为空，则返回 <see cref="T:System.DBNull" />。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static object GetValue(DataRow row, int columnIndex, DataRowVersion version)
	{
		Guard.AssertNotNull(row, "row");
		Guard.AssertIndexRange(columnIndex, 0, row.Table.Columns.Count - 1, "column index");
		return ConvertHelper.EnsureDBNull(row[columnIndex, version]);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">获取的列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">要获取的数据值的版本</param>
	/// <param name="defaultValue">列值的默认值。获取的列值为 <see cref="T:System.DBNull" /> 时，返回该值。</param>
	/// <returns>当前数据行指定列的值；如果指定的列的值为 <see cref="T:System.DBNull" />，则返回 <paramref name="defaultValue" />。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static T GetValue<T>(DataRow row, int columnIndex, DataRowVersion version, T defaultValue = default(T))
	{
		return ObjectHelper.As<T>(ObjectHelper.IfNullOrDBNull(GetValue(row, columnIndex, version), defaultValue));
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">获取的列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">要获取的数据值的版本</param>
	/// <param name="evaluation">获取的列值的处理方法。</param>
	/// <returns>当前数据行指定列的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static T GetValue<T>(DataRow row, int columnIndex, DataRowVersion version, Func<object, T> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return evaluation(GetValue(row, columnIndex, version));
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">指定数据列的名称</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static object GetValue(DataRow row, string columnName)
	{
		return GetValue(row, columnName, DataRowVersion.Default);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">获取的列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">指定数据列的名称</param>
	/// <param name="defaultValue">列值的默认值。获取的列值为 <see cref="T:System.DBNull" /> 时，返回该值。</param>
	/// <returns>当前数据行指定列的值；如果指定的列的值为 <see cref="T:System.DBNull" />，则返回 <paramref name="defaultValue" />。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static T GetValue<T>(DataRow row, string columnName, T defaultValue = default(T))
	{
		return GetValue(row, columnName, DataRowVersion.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">获取的列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">指定数据列的名称</param>
	/// <param name="evaluation">获取的列值的处理方法</param>
	/// <returns>当前数据行指定列的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static T GetValue<T>(DataRow row, string columnName, Func<object, T> evaluation)
	{
		return GetValue(row, columnName, DataRowVersion.Default, evaluation);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">指定数据列的名称</param>
	/// <param name="version">要获取的数据值的版本</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static object GetValue(DataRow row, string columnName, DataRowVersion version)
	{
		Guard.AssertNotNull(row, "row");
		Guard.AssertNotNull(columnName, "Column Name");
		DataColumn column = row.Table.Columns[columnName];
		Guard.Assert(ObjectHelper.IsNotNull(column), () => new ArgumentException(string.Format(Literals.MSG_DataColumnNotFound_1, columnName), "Column Name"));
		return ConvertHelper.EnsureDBNull(row[column, version]);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">获取的列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">指定数据列的名称</param>
	/// <param name="version">要获取的数据值的版本</param>
	/// <param name="defaultValue">列值的默认值。获取的列值为 <see cref="T:System.DBNull" /> 时，返回该值。</param>
	/// <returns>当前数据行指定列的值；如果指定的列的值为 <see cref="T:System.DBNull" />，则返回 <paramref name="defaultValue" />。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static T GetValue<T>(DataRow row, string columnName, DataRowVersion version, T defaultValue = default(T))
	{
		return ObjectHelper.As<T>(ObjectHelper.IfNullOrDBNull(GetValue(row, columnName, version), defaultValue));
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">获取的列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">指定数据列的名称</param>
	/// <param name="version">要获取的数据值的版本</param>
	/// <param name="evaluation">获取的列值的处理方法</param>
	/// <returns>当前数据行指定列的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static T GetValue<T>(DataRow row, string columnName, DataRowVersion version, Func<object, T> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return evaluation(GetValue(row, columnName, version));
	}

	/// <summary>
	/// 检测当前数据行的指定的数据列的值是否是 <see cref="T:System.DBNull" />。
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="version">要获取的值的行版本</param>
	/// <returns>如果指定的数据列的值为空或者 <see cref="T:System.DBNull" /> 则返回true，否则返回false。</returns>
	public static bool IsDBNull(DataRow row, DataColumn column, DataRowVersion version = DataRowVersion.Default)
	{
		return ObjectHelper.IsDBNull(GetValue(row, column, version));
	}

	/// <summary>
	/// 检测当前数据行的指定索引位置的数据列的值是否是 <see cref="T:System.DBNull" />。
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">要获取的值的行版本</param>
	/// <returns>如果指定的数据列的值为空或者 <see cref="T:System.DBNull" /> 则返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static bool IsDBNull(DataRow row, int columnIndex, DataRowVersion version = DataRowVersion.Default)
	{
		return ObjectHelper.IsDBNull(GetValue(row, columnIndex, version));
	}

	/// <summary>
	/// 检测当前数据行的指定名称的数据列的值是否是 <see cref="T:System.DBNull" />。
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">指定数据列的名称</param>
	/// <param name="version">要获取的值的行版本</param>
	/// <returns>如果指定的数据列的值为空或者 <see cref="T:System.DBNull" /> 则返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static bool IsDBNull(DataRow row, string columnName, DataRowVersion version = DataRowVersion.Default)
	{
		return ObjectHelper.IsDBNull(GetValue(row, columnName, version));
	}

	/// <summary>
	/// 向当前数据行中加载指定对象的属性值，如果对象的属性没有对应的数据列则忽略；将数据对象的公共实例属相加载到当前数据行
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="data">加载的数据对象</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者加载的数据对象 <paramref name="data" /> 为空。</exception>
	public static void LoadObject(DataRow row, object data)
	{
		LoadObject(row, data, BindingFlags.Instance | BindingFlags.Public);
	}

	/// <summary>
	/// 向当前数据行中加载指定对象的属性值，如果对象的属性没有对应的数据列则忽略
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="data">加载的数据对象</param>
	/// <param name="flags">属性绑定标志</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者加载的数据对象 <paramref name="data" /> 为空。</exception>
	public static void LoadObject(DataRow row, object data, BindingFlags flags)
	{
		LoadObject(row, data, new DataMapping[0], flags);
	}

	/// <summary>
	/// 向当前数据行中加载指定对象的属性值，如果对象的属性没有对应的数据列则忽略；将数据对象的公共实例属相加载到当前数据行
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="data">加载的数据对象</param>
	/// <param name="propertyNames">加载的对象属性的名称数组</param>
	/// <param name="onlyMapping">是否只处理已列出的对象属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者加载的数据对象 <paramref name="data" /> 为空；或者加载的属性名称数组 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中指定的对象属性不存在；或者指定的数据列名不存在。</exception>
	public static void LoadObject(DataRow row, object data, string[] propertyNames, bool onlyMapping = false, bool ignoreCase = false)
	{
		LoadObject(row, data, propertyNames, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase);
	}

	/// <summary>
	/// 向当前数据行中加载指定对象的属性值，如果对象的属性没有对应的数据列则忽略
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="data">加载的数据对象</param>
	/// <param name="propertyNames">加载的对象属性的名称数组</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理已列出的对象属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者加载的数据对象 <paramref name="data" /> 为空；或者加载的属性名称数组 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中指定的对象属性不存在；或者指定的数据列名不存在。</exception>
	public static void LoadObject(DataRow row, object data, string[] propertyNames, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		Guard.AssertNotNull(propertyNames, "property names");
		DataMapping[] mappings = (from n in propertyNames.Where((string n) => ObjectHelper.IsNotNull(n)).Distinct()
			select new DataMapping(null, n)).ToArray();
		LoadObject(row, data, mappings, flags, onlyMapping, ignoreCase);
	}

	/// <summary>
	/// 向当前数据行中加载指定对象的属性值，如果对象的属性没有对应的数据列则忽略；将数据对象的公共实例属相加载到当前数据行
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="data">加载的数据对象</param>
	/// <param name="mappings">数据对象属性到数据列的映射数组</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者加载的数据对象 <paramref name="data" /> 为空；或者映射数组 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中指定的对象属性不存在；或者指定的数据列名不存在。</exception>
	/// <remarks>
	/// 如果映射规则 <paramref name="mappings" /> 指定的对象属性或者数据列不存在，则抛出异常。
	/// 如果 <paramref name="onlyMapping" /> 为false时，未指定映射的规则的对象属性，在没有匹配的数据列时（名称相同则匹配）则忽略。
	/// </remarks>
	public static void LoadObject(DataRow row, object data, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false)
	{
		LoadObject(row, data, mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase);
	}

	/// <summary>
	/// 向当前数据行中加载指定对象的属性值，如果对象的属性没有对应的数据列则忽略
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="data">加载的数据对象</param>
	/// <param name="mappings">数据对象属性到数据列的映射数组</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者加载的数据对象 <paramref name="data" /> 为空；或者映射数组 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中指定的对象属性不存在；或者指定的数据列名不存在。</exception>
	/// <remarks>
	/// 如果映射规则 <paramref name="mappings" /> 指定的对象属性或者数据列不存在，则抛出异常。
	/// 如果 <paramref name="onlyMapping" /> 为false时，未指定映射的规则的对象属性，在没有匹配的数据列时（名称相同则匹配）则忽略。
	/// </remarks>
	public static void LoadObject(DataRow row, object data, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		Guard.AssertNotNull(row, "row");
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(mappings, "mappings");
		Dictionary<string, DataColumn> columns = new Dictionary<string, DataColumn>(ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
		CollectionHelper.TryAddRange(columns, Columns(row.Table), (DataColumn c) => c.ColumnName);
		object owner;
		if (onlyMapping)
		{
			foreach (DataMapping mapping in mappings.Where((DataMapping m) => ObjectHelper.IsNotNull(m) && TextHelper.IsNotNullAndEmpty(m.PropertyName)))
			{
				PropertyInfo pinfo = ObjectHelper.GetProperty(data, mapping.PropertyName, flags, out owner, ignoreCase);
				if (ObjectHelper.IsNull(pinfo))
				{
					throw new ArgumentException(string.Format(Literals.MSG_MissingProperty_1, mapping.PropertyName), "mappings");
				}
				string columnName = TextHelper.IfNullOrEmpty(mapping.ColumnName, pinfo.Name);
				if (!columns.ContainsKey(columnName))
				{
					throw new ArgumentException(string.Format(Literals.MSG_DataColumnNotFound_1, columnName), "mappings");
				}
				DataColumn column = columns[columnName];
				row[column] = ConvertHelper.Cast(pinfo.GetValue(owner, null), column.DataType);
			}
			return;
		}
		Dictionary<string, DataMapping> properties = new Dictionary<string, DataMapping>(ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
		CollectionHelper.TryAddRange(properties, mappings.Where((DataMapping m) => ObjectHelper.IsNotNull(m) && TextHelper.IsNotNullAndEmpty(m.PropertyName)), (DataMapping m) => m.PropertyName);
		PropertyInfo[] properties2 = data.GetType().GetProperties(flags);
		foreach (PropertyInfo pinfo in properties2)
		{
			if (properties.ContainsKey(pinfo.Name))
			{
				string columnName = TextHelper.IfNullOrEmpty(properties[pinfo.Name].ColumnName, pinfo.Name);
				if (!columns.ContainsKey(columnName))
				{
					throw new ArgumentException(string.Format(Literals.MSG_DataColumnNotFound_1, columnName), "mappings");
				}
				DataColumn column = columns[columnName];
				row[column] = ConvertHelper.Cast(pinfo.GetValue(data, null), column.DataType);
				properties.Remove(pinfo.Name);
			}
			else
			{
				string columnName = pinfo.Name;
				if (columns.ContainsKey(columnName))
				{
					DataColumn column = columns[columnName];
					row[column] = ConvertHelper.Cast(pinfo.GetValue(data, null), column.DataType);
				}
			}
		}
		foreach (DataMapping mapping in properties.Values)
		{
			PropertyInfo extraPinfo = ObjectHelper.GetProperty(data, mapping.PropertyName, out owner, ignoreCase);
			if (ObjectHelper.IsNull(extraPinfo))
			{
				throw new ArgumentException(string.Format(Literals.MSG_MissingProperty_1, mapping.PropertyName), "mappings");
			}
			string columnName = TextHelper.IfNullOrEmpty(mapping.ColumnName, extraPinfo.Name);
			if (!columns.ContainsKey(columnName))
			{
				throw new ArgumentException(string.Format(Literals.MSG_DataColumnNotFound_1, columnName), "mappings");
			}
			DataColumn column = columns[columnName];
			row[column] = ConvertHelper.Cast(extraPinfo.GetValue(owner, null), column.DataType);
		}
	}

	/// <summary>
	/// 将当前数据行转换为目标类型的对象；将数据行的列映射到目标类型的公共属性
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="type">转换的目标类型</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空。</exception>
	public static object ToObject(DataRow row, Type type)
	{
		Guard.AssertNotNull(type, "type");
		return ToObject(row, TypeHelper.CreateInstance(type));
	}

	/// <summary>
	/// 将当前数据行转换为目标类型的对象；将数据行的列映射到目标类型的公共属性
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="obj">转换的目标对象，如果为空则创建该类型的对象的新实例</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	public static T ToObject<T>(DataRow row, T obj = default(T))
	{
		return ToObject(row, BindingFlags.Instance | BindingFlags.Public, obj);
	}

	/// <summary>
	/// 将当前数据行转换为目标类型的对象
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="type">转换的目标类型</param>
	/// <param name="flags">属性绑定标志</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空。</exception>
	public static object ToObject(DataRow row, Type type, BindingFlags flags)
	{
		Guard.AssertNotNull(type, "type");
		return ToObject(row, flags, TypeHelper.CreateInstance(type));
	}

	/// <summary>
	/// 将当前数据行转换为目标类型的对象
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="obj">转换的目标对象，如果为空则创建该类型的对象的新实例</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	public static T ToObject<T>(DataRow row, BindingFlags flags, T obj = default(T))
	{
		return ToObject(row, new DataMapping[0], flags, onlyMapping: false, ignoreCase: false, obj);
	}

	/// <summary>
	/// 将当前数据行转换为目标类型的对象；将数据行的列映射到目标类型的公共属性
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="type">转换的目标类型</param>
	/// <param name="columnNames">映射的数据列名称</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空；映射的数据列名称数组 <paramref name="columnNames" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static object ToObject(DataRow row, Type type, string[] columnNames, bool onlyMapping = false, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		return ToObject(row, columnNames, onlyMapping, ignoreCase, TypeHelper.CreateInstance(type));
	}

	/// <summary>
	/// 将当前数据行转换为目标类型的对象；将数据行的列映射到目标类型的公共属性
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="columnNames">映射的数据列名称</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <param name="obj">转换的目标对象，如果为空则创建该类型的对象的新实例</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；映射的数据列名称数组 <paramref name="columnNames" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static T ToObject<T>(DataRow row, string[] columnNames, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		return ToObject(row, columnNames, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase, obj);
	}

	/// <summary>
	/// 将当前数据行转换为目标类型的对象
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="type">转换的目标类型</param>
	/// <param name="columnNames">映射的数据列名称</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空；映射的数据列名称数组 <paramref name="columnNames" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static object ToObject(DataRow row, Type type, string[] columnNames, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		return ToObject(row, columnNames, flags, onlyMapping, ignoreCase, TypeHelper.CreateInstance(type));
	}

	/// <summary>
	/// 将当前数据行转换为目标类型的对象
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="columnNames">映射的数据列名称</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <param name="obj">转换的目标对象，如果为空则创建该类型的对象的新实例</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；映射的数据列名称数组 <paramref name="columnNames" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static T ToObject<T>(DataRow row, string[] columnNames, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		Guard.AssertNotNull(columnNames, "column names");
		DataMapping[] mappings = (from n in columnNames.Where((string n) => ObjectHelper.IsNotNull(n)).Distinct()
			select new DataMapping(n, null)).ToArray();
		return ToObject(row, mappings, flags, onlyMapping, ignoreCase, obj);
	}

	/// <summary>
	/// 将当前数据行转换为目标类型的对象；将数据行的列映射到目标类型的公共属性
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="type">转换的目标类型</param>
	/// <param name="mappings">数据列到对象属性的映射，未设置数据列名称则忽略</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空；映射规则数组 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static object ToObject(DataRow row, Type type, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false)
	{
		return ToObject(row, type, mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase);
	}

	/// <summary>
	/// 将当前数据行转换为目标类型的对象；将数据行的列映射到目标类型的公共属性
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="mappings">数据列到对象属性的映射，未设置数据列名称则忽略</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <param name="obj">转换的目标对象，如果为空则创建该类型的对象的新实例</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；映射规则数组 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static T ToObject<T>(DataRow row, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		return ToObject(row, mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase, obj);
	}

	/// <summary>
	/// 将当前数据行转换为目标类型的对象
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="type">转换的目标类型</param>
	/// <param name="mappings">数据列到对象属性的映射，未设置数据列名称则忽略</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空；映射规则数组 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static object ToObject(DataRow row, Type type, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		return ToObject(row, mappings, flags, onlyMapping, ignoreCase, TypeHelper.CreateInstance(type));
	}

	/// <summary>
	/// 将当前数据行转换为目标类型的对象
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="mappings">数据列到对象属性的映射，未设置数据列名称则忽略</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <param name="obj">转换的目标对象，如果为空则创建该类型的对象的新实例</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；映射规则数组 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static T ToObject<T>(DataRow row, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		Guard.AssertNotNull(row, "row");
		Guard.AssertNotNull(mappings, "mappings");
		obj = ObjectHelper.IfNull(obj, TypeHelper.CreateInstance<T>());
		object owner;
		if (onlyMapping)
		{
			Dictionary<string, DataColumn> columns = new Dictionary<string, DataColumn>(ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
			CollectionHelper.TryAddRange(columns, Columns(row.Table), (DataColumn c) => c.ColumnName);
			foreach (DataMapping mapping in mappings.Where((DataMapping m) => ObjectHelper.IsNotNull(m) && TextHelper.IsNotNullAndEmpty(m.ColumnName)))
			{
				if (!columns.ContainsKey(mapping.ColumnName))
				{
					throw new ArgumentException(string.Format(Literals.MSG_DataColumnNotFound_1, mapping.ColumnName), "mappings");
				}
				string propertyName = TextHelper.IfNullOrEmpty(mapping.PropertyName, mapping.ColumnName);
				PropertyInfo pinfo = ObjectHelper.GetProperty(obj, propertyName, flags, out owner, ignoreCase);
				if (ObjectHelper.IsNull(pinfo))
				{
					throw new ArgumentException(string.Format(Literals.MSG_MissingProperty_1, propertyName), "mappings");
				}
				pinfo.SetValue(owner, ConvertHelper.Cast(row[columns[mapping.ColumnName]], pinfo.PropertyType), null);
			}
		}
		else
		{
			Dictionary<string, DataMapping> columns2 = new Dictionary<string, DataMapping>(ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
			CollectionHelper.TryAddRange(columns2, mappings.Where((DataMapping m) => ObjectHelper.IsNotNull(m) && TextHelper.IsNotNullAndEmpty(m.ColumnName)), (DataMapping m) => m.ColumnName);
			foreach (DataColumn column in row.Table.Columns)
			{
				if (columns2.ContainsKey(column.ColumnName))
				{
					string propertyName = TextHelper.IfNullOrEmpty(columns2[column.ColumnName].PropertyName, column.ColumnName);
					PropertyInfo pinfo = ObjectHelper.GetProperty(obj, propertyName, flags, out owner, ignoreCase);
					if (ObjectHelper.IsNull(pinfo))
					{
						throw new ArgumentException(string.Format(Literals.MSG_MissingProperty_1, propertyName), "mappings");
					}
					pinfo.SetValue(owner, ConvertHelper.Cast(row[column], pinfo.PropertyType), null);
					columns2.Remove(column.ColumnName);
				}
				else
				{
					string propertyName = column.ColumnName;
					PropertyInfo pinfo = ObjectHelper.GetProperty(obj, propertyName, flags, out owner, ignoreCase);
					if (ObjectHelper.IsNotNull(pinfo))
					{
						pinfo.SetValue(owner, ConvertHelper.Cast(row[column], pinfo.PropertyType), null);
					}
				}
			}
			if (columns2.Count > 0)
			{
				using Dictionary<string, DataMapping>.Enumerator enumerator3 = columns2.GetEnumerator();
				if (enumerator3.MoveNext())
				{
					KeyValuePair<string, DataMapping> kvp = enumerator3.Current;
					throw new ArgumentException(string.Format(Literals.MSG_DataColumnNotFound_1, kvp.Key), "mappings");
				}
			}
		}
		return obj;
	}

	/// <summary>
	/// 向当前数据表中添加数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="column">添加的数据列</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="column" /> 为空。</exception>
	public static void AddColumn(DataTable table, DataColumn column)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(column, "column");
		table.Columns.Add(column);
	}

	/// <summary>
	/// 向当前数据表中添加数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <returns>添加后的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static DataColumn AddColumn(DataTable table, string columnName)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnName, "column name");
		return table.Columns.Add(columnName);
	}

	/// <summary>
	/// 向当前数据表中添加数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <param name="columnType">数据列类型</param>
	/// <returns>添加后的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空；或者 <paramref name="columnType" /> 为空。</exception>
	public static DataColumn AddColumn(DataTable table, string columnName, Type columnType)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnName, "column name");
		Guard.AssertNotNull(columnType, "column type");
		return table.Columns.Add(columnName, columnType);
	}

	/// <summary>
	/// 向当前数据表中添加数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <param name="columnType">数据列类型</param>
	/// <param name="columnExpress">数据列的计算表达式</param>
	/// <returns>添加后的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空；或者 <paramref name="columnType" /> 为空。</exception>
	public static DataColumn AddColumn(DataTable table, string columnName, Type columnType, string columnExpress)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnName, "column name");
		Guard.AssertNotNull(columnType, "column type");
		return table.Columns.Add(columnName, columnType, columnExpress);
	}

	/// <summary>
	/// 向当前数据表中添加多个数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columns">添加的数据列列表</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columns" /> 为空。</exception>
	public static void AddColumns(DataTable table, params DataColumn[] columns)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columns, "columns");
		foreach (DataColumn column in columns)
		{
			table.Columns.Add(column);
		}
	}

	/// <summary>
	/// 向当前数据表中添加多个数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columns">添加的数据列序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columns" /> 为空。</exception>
	public static void AddColumns(DataTable table, IEnumerable<DataColumn> columns)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columns, "columns");
		foreach (DataColumn column in columns)
		{
			table.Columns.Add(column);
		}
	}

	/// <summary>
	/// 向当前数据表中添加多个数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnNames">添加的数据列列名称数组</param>
	/// <return>添加的数据列数组</return>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnNames" /> 为空。</exception>
	public static DataColumn[] AddColumns(DataTable table, params string[] columnNames)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnNames, "column names");
		return columnNames.Select((string x) => table.Columns.Add(x)).ToArray();
	}

	/// <summary>
	/// 向当前数据表中添加多个数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnNames">添加的数据列列名称序列</param>
	/// <return>添加的数据列数组</return>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnNames" /> 为空。</exception>
	public static DataColumn[] AddColumns(DataTable table, IEnumerable<string> columnNames)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnNames, "column names");
		return columnNames.Select((string x) => table.Columns.Add(x)).ToArray();
	}

	/// <summary>
	/// 向当前数据表总添加多个数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnNames">添加的数据列名称数组</param>
	/// <param name="columnTypes">添加的数据列类型数组</param>
	/// <return>添加的数据列数组</return>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnNames" /> 为空；或者 <paramref name="columnTypes" /> 为空。</exception>
	public static DataColumn[] AddColumns(DataTable table, string[] columnNames, Type[] columnTypes)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnNames, "column names");
		Guard.AssertNotNull(columnTypes, "column types");
		Guard.AssertArrayLength(columnNames, columnTypes.Length, "columnNames & columnTypes", string.Format(Literals.MSG_ArrayLengthNotSame_2, "column names", "column types"));
		List<DataColumn> columns = new List<DataColumn>(columnNames.Length);
		for (int i = 0; i < columnNames.Length; i++)
		{
			columns.Add(table.Columns.Add(columnNames[i], columnTypes[i]));
		}
		return columns.ToArray();
	}

	/// <summary>
	/// 向当前数据表总添加多个数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnNames">添加的数据列名称数组</param>
	/// <param name="columnTypes">添加的数据列类型数组</param>
	/// <param name="columnExpresses">数据列的计算表达式数组</param>
	/// <return>添加的数据列数组</return>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnNames" /> 为空；或者 <paramref name="columnTypes" /> 为空；或者 <paramref name="columnExpresses" /> 为空。</exception>
	public static DataColumn[] AddColumns(DataTable table, string[] columnNames, Type[] columnTypes, string[] columnExpresses)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnNames, "column names");
		Guard.AssertNotNull(columnTypes, "column types");
		Guard.AssertNotNull(columnExpresses, "column expresses");
		Guard.Assert(columnNames.Length == columnTypes.Length && columnTypes.Length == columnExpresses.Length, () => new ArgumentException(string.Format(Literals.MSG_ArrayLengthNotSame_3, "column names", "column types", "column expresses")));
		List<DataColumn> columns = new List<DataColumn>(columnNames.Length);
		for (int i = 0; i < columnNames.Length; i++)
		{
			columns.Add(table.Columns.Add(columnNames[i], columnTypes[i], columnExpresses[i]));
		}
		return columns.ToArray();
	}

	/// <summary>
	/// 获取当前数据表中新加的数据行的序列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>新加数据行序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<DataRow> AddedRows(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		return from r in Rows(table)
			where r.RowState.HasFlag(DataRowState.Added)
			select r;
	}

	/// <summary>
	/// 获取当前数据表中新加的数据行的序列
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>新加数据行序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<R> AddedRows<R>(DataTable table) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		return from r in Rows<R>(table)
			where r.RowState.HasFlag(DataRowState.Added)
			select r;
	}

	/// <summary>
	/// 向当前数据表中添加数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="row">添加的数据行</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="row" /> 为空。</exception>
	public static void AddRow(DataTable table, DataRow row)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(row, "row");
		table.Rows.Add(row);
	}

	/// <summary>
	/// 向当前数据表中添加数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="items">用于创建新行的列值的数组</param>
	/// <returns>添加后的新数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="items" /> 为空。</exception>
	public static DataRow AddRow(DataTable table, params object[] items)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(items, "items");
		return table.Rows.Add(items);
	}

	/// <summary>
	/// 向当前数据表中添加数据行
	/// </summary>
	/// <typeparam name="R">新数据行的类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="items">用于创建新行的列值的数组</param>
	/// <returns>添加后的新数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="items" /> 为空。</exception>
	public static R AddRow<R>(DataTable table, params object[] items) where R : DataRow
	{
		return AddRow<R>(table, items);
	}

	/// <summary>
	/// 向当前数据表中添加多个数据行
	/// </summary>
	/// <typeparam name="R">添加的数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="rows">待添加的数据行数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="rows" /> 为空。</exception>
	public static void AddRows<R>(DataTable table, params R[] rows) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(rows, "rows");
		foreach (R row in rows)
		{
			table.Rows.Add(row);
		}
	}

	/// <summary>
	/// 向当前数据表中添加多个数据行
	/// </summary>
	/// <typeparam name="R">添加的数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="rows">待添加的数据行序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="rows" /> 为空。</exception>
	public static void AddRows<R>(DataTable table, IEnumerable<R> rows) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(rows, "rows");
		foreach (R row in rows)
		{
			table.Rows.Add(row);
		}
	}

	/// <summary>
	/// 向当前数据表中添加多个数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="rowItems">待添加的数据行列值数组</param>
	/// <returns>添加的数据行的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="rowItems" /> 为空。</exception>
	public static DataRow[] AddRows(DataTable table, params object[][] rowItems)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(rowItems, "items");
		return rowItems.Select((object[] x) => AddRow(table, x)).ToArray();
	}

	/// <summary>
	/// 向当前数据表中添加多个数据行
	/// </summary>
	/// <typeparam name="R">添加的数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="rowItems">待添加的数据行列值数组</param>
	/// <returns>添加的数据行的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="rowItems" /> 为空。</exception>
	public static R[] AddRows<R>(DataTable table, params object[][] rowItems) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(rowItems, "items");
		return rowItems.Select((object[] x) => AddRow<R>(table, x)).ToArray();
	}

	/// <summary>
	/// 检查是否可以从当前数据表中移除指定的列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="column">待移除的数据列</param>
	/// <returns>如果可以移除该数据列返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="column" /> 为空。</exception>
	public static bool CanRemoveColumn(DataTable table, DataColumn column)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(column, "column");
		return table.Columns.CanRemove(column);
	}

	/// <summary>
	/// 检查是否可以从当前数据表中移除指定的列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">待移除的数据列的名称</param>
	/// <returns>如果可以移除该数据列返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static bool CanRemoveColumn(DataTable table, string columnName)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnName, "column name");
		DataColumn column = table.Columns[columnName];
		return !ObjectHelper.IsNull(column) && table.Columns.CanRemove(column);
	}

	/// <summary>
	/// 从当前数据表中清除所有的列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static void ClearColumns(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		table.Columns.Clear();
	}

	/// <summary>
	/// 从当前数据表中清除所有数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static void ClearRows(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		table.Rows.Clear();
	}

	/// <summary>
	/// 获取当前数据表的数据列数量
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>当前数据表的数据列计数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static int ColumnCount(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		return table.Columns.Count;
	}

	/// <summary>
	/// 获取当前数据表的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<DataColumn> Columns(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		return table.Columns.OfType<DataColumn>();
	}

	/// <summary>
	/// 获取当前数据表的数据列
	/// </summary>
	/// <typeparam name="C">数据列类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<C> Columns<C>(DataTable table) where C : DataColumn
	{
		Guard.AssertNotNull(table, "table");
		return table.Columns.OfType<C>();
	}

	/// <summary>
	/// 获取当前数据表中满足指定模式的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="pattern">数据列名称匹配模式</param>
	/// <param name="options">匹配模式参数</param>
	/// <returns>符合条件的数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="pattern" /> 为空。</exception>
	public static IEnumerable<DataColumn> Columns(DataTable table, string pattern, RegexOptions options = RegexOptions.None)
	{
		return Columns<DataColumn>(table, pattern, options);
	}

	/// <summary>
	/// 获取当前数据表中满足指定模式的数据列
	/// </summary>
	/// <typeparam name="C">数据列类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="pattern">数据列名称匹配模式</param>
	/// <param name="options">匹配模式参数</param>
	/// <returns>符合条件的数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="pattern" /> 为空。</exception>
	public static IEnumerable<C> Columns<C>(DataTable table, string pattern, RegexOptions options = RegexOptions.None) where C : DataColumn
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(pattern, "pattern");
		return from c in Columns<C>(table)
			where ConvertHelper.ToRegex(pattern, options).IsMatch(c.ColumnName)
			select c;
	}

	/// <summary>
	/// 获取当前数据表中满足指定模式的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="pattern">数据列名称匹配模式</param>
	/// <returns>符合条件的数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="pattern" /> 为空。</exception>
	public static IEnumerable<DataColumn> Columns(DataTable table, Regex pattern)
	{
		return Columns<DataColumn>(table, pattern);
	}

	/// <summary>
	/// 获取当前数据表中满足指定模式的数据列
	/// </summary>
	/// <typeparam name="C">数据列类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="pattern">数据列名称匹配模式</param>
	/// <returns>符合条件的数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="pattern" /> 为空。</exception>
	public static IEnumerable<C> Columns<C>(DataTable table, Regex pattern) where C : DataColumn
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(pattern, "pattern");
		return from c in Columns<C>(table)
			where pattern.IsMatch(c.ColumnName)
			select c;
	}

	/// <summary>
	/// 获取当前数据表中满足指定指定条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>符合条件的数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<DataColumn> Columns(DataTable table, Func<DataColumn, bool> predicate)
	{
		return DataHelper.Columns<DataColumn>(table, predicate);
	}

	/// <summary>
	/// 获取当前数据表中满足指定指定条件的数据列
	/// </summary>
	/// <typeparam name="C">数据列类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>符合条件的数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<C> Columns<C>(DataTable table, Func<C, bool> predicate) where C : DataColumn
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return Columns<C>(table).Where(predicate);
	}

	/// <summary>
	/// 获取当前数据表中满足指定指定条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>符合条件的数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<DataColumn> Columns(DataTable table, Func<DataColumn, int, bool> predicate)
	{
		return DataHelper.Columns<DataColumn>(table, predicate);
	}

	/// <summary>
	/// 获取当前数据表中满足指定指定条件的数据列
	/// </summary>
	/// <typeparam name="C">数据列类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>符合条件的数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<C> Columns<C>(DataTable table, Func<C, int, bool> predicate) where C : DataColumn
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return Columns<C>(table).Where(predicate);
	}

	/// <summary>
	/// 检测当前数据表中是否含有指定名称的列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">查找的列名称</param>
	/// <returns>如果数据表中包含与指定名称匹配的数据列返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static bool ContainsColumn(DataTable table, string columnName)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnName, "column name");
		return table.Columns.Contains(columnName);
	}

	/// <summary>
	/// 检测当前数据表中是否含有指定名称的列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">查找的列名称</param>
	/// <param name="ignoreCase">数据列名称是否区分大小写</param>
	/// <returns>如果数据表中包含与指定名称匹配的数据列返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static bool ContainsColumn(DataTable table, string columnName, bool ignoreCase)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnName, "column name");
		return Columns(table).Any((DataColumn x) => TextHelper.EqualCultural(x.ColumnName, columnName, table.Locale, ignoreCase));
	}

	/// <summary>
	/// 检测当前数据表中是否存在符合条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>如果当前数据表中存在符合条件的数据列返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static bool ContainsColumn(DataTable table, Func<DataColumn, bool> predicate)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return Columns(table).Any(predicate);
	}

	/// <summary>
	/// 检测当前数据表中是否存在符合条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>如果当前数据表中存在符合条件的数据列返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static bool ContainsColumn(DataTable table, Func<DataColumn, int, bool> predicate)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return CollectionHelper.Any(Columns(table), predicate);
	}

	/// <summary>
	/// 检测当前数据表中是否存在主键值与给定值匹配的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="keyValue">主键值</param>
	/// <returns>存在匹配的数据行返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static bool ContainsRow(DataTable table, object keyValue)
	{
		Guard.AssertNotNull(table, "table");
		return table.Rows.Contains(keyValue);
	}

	/// <summary>
	/// 检测当前数据表中是否存在主键值与给定值匹配的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="keyValues">主键值列表</param>
	/// <returns>存在匹配的数据行返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keyValues" /> 为空；</exception>
	public static bool ContainsRow(DataTable table, object[] keyValues)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(keyValues, "keyValues");
		return table.Rows.Contains(keyValues);
	}

	/// <summary>
	/// 检测当前数据表中是否存在符合条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据表检测条件</param>
	/// <returns>存在匹配的数据行返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static bool ContainsRow(DataTable table, Func<DataRow, bool> predicate)
	{
		return DataHelper.ContainsRow<DataRow>(table, predicate);
	}

	/// <summary>
	/// 检测当前数据表中是否存在符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据表检测条件</param>
	/// <returns>存在匹配的数据行返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static bool ContainsRow<R>(DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return Rows<R>(table).Any(predicate);
	}

	/// <summary>
	/// 检测当前数据表中是否存在符合条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据表检测条件</param>
	/// <returns>存在匹配的数据行返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static bool ContainsRow(DataTable table, Func<DataRow, int, bool> predicate)
	{
		return DataHelper.ContainsRow<DataRow>(table, predicate);
	}

	/// <summary>
	/// 检测当前数据表中是否存在符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据表检测条件</param>
	/// <returns>存在匹配的数据行返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static bool ContainsRow<R>(DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return CollectionHelper.Any(Rows<R>(table), predicate);
	}

	/// <summary>
	/// 复制当前数据表
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="copying">数据表的值的复制方法；接受当前待复制的值，返回复制后的值。</param>
	/// <returns>复制生成的新的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="copying" /> 为空。</exception>
	public static DataTable Copy(DataTable table, Func<object, object> copying)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(copying, "copying");
		DataTable newTable = table.Clone();
		foreach (DataRow row in Rows(table))
		{
			DataRow newRow = newTable.NewRow();
			foreach (DataColumn column in Columns(table))
			{
				newRow[column.Ordinal] = copying(row[column]);
			}
			newTable.Rows.Add(newRow);
		}
		return newTable;
	}

	/// <summary>
	/// 复制当前数据表
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="copying">数据表的值的复制方法；接受当前的数据行和数据列，返回复制后的值。</param>
	/// <returns>复制生成的新的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="copying" /> 为空。</exception>
	public static DataTable Copy(DataTable table, Func<DataRow, DataColumn, object> copying)
	{
		return DataHelper.Copy<DataTable, DataRow>(table, copying);
	}

	/// <summary>
	/// 复制当前数据表
	/// </summary>
	/// <typeparam name="T">当前数据表类型</typeparam>
	/// <typeparam name="R">当前数据表数据行的类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="copying">数据表的值的复制方法；接受当前的数据行和数据列，返回复制后的值。</param>
	/// <returns>复制生成的新的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="copying" /> 为空。</exception>
	public static T Copy<T, R>(T table, Func<R, DataColumn, object> copying) where T : DataTable where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(copying, "copying");
		T newTable = (T)table.Clone();
		foreach (R row in Rows<R>(table))
		{
			DataRow newRow = newTable.NewRow();
			foreach (DataColumn column in Columns(table))
			{
				newRow[column.Ordinal] = copying(row, column);
			}
			newTable.Rows.Add(newRow);
		}
		return newTable;
	}

	/// <summary>
	/// 为当前数据表创建数据视图
	/// </summary>
	/// <typeparam name="T">当前数据表类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="state">筛选的数据视图数据行状态</param>
	/// <returns>当前表的数据视图</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataView<T> CreateView<T>(T table, DataViewRowState state = DataViewRowState.None) where T : DataTable
	{
		return new DataView<T>(table, null, null, state);
	}

	/// <summary>
	/// 为当前数据表创建数据视图，并按指定的数据列进行排序
	/// </summary>
	/// <typeparam name="T">当前数据表类型</typeparam>
	/// <param name="table">当前的数据表</param>
	/// <param name="sortColumns">排序列名称数组</param>
	/// <returns>当前数据表的排序视图</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataView<T> CreateView<T>(T table, params string[] sortColumns) where T : DataTable
	{
		return CreateView(table, sortColumns, DataViewRowState.None);
	}

	/// <summary>
	/// 为当前数据表创建数据视图，并按指定的数据列进行排序
	/// </summary>
	/// <typeparam name="T">当前数据表类型</typeparam>
	/// <param name="table">当前的数据表</param>
	/// <param name="sortColumns">排序列名称数组</param>
	/// <param name="state">筛选的数据视图数据行状态</param>
	/// <returns>当前数据表的排序视图</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataView<T> CreateView<T>(T table, string[] sortColumns, DataViewRowState state = DataViewRowState.None) where T : DataTable
	{
		Guard.AssertNotNull(table, "table");
		return new DataView<T>(table, null, CollectionHelper.JoinString(sortColumns.Where((string s) => ObjectHelper.IsNotNull(s)), "{0} ASC", ","), state);
	}

	/// <summary>
	/// 为当前数据表创建数据视图，并按指定的数据列进行排序
	/// </summary>
	/// <typeparam name="T">当前数据表类型</typeparam>
	/// <param name="table">当前的数据表</param>
	/// <param name="sortColumn">排序列名称</param>
	/// <param name="sortOrder">排序方向</param>
	/// <param name="state">筛选的数据视图数据行状态</param>
	/// <returns>当前数据表的排序视图</returns>
	public static DataView<T> CreateView<T>(T table, string sortColumn, SortOrder sortOrder, DataViewRowState state = DataViewRowState.None) where T : DataTable
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(sortColumn, "sort column");
		return new DataView<T>(table, null, string.Format("{0}, {1}", sortColumn, sortOrder switch
		{
			SortOrder.Descending => "DESC", 
			SortOrder.Ascending => "ASC", 
			_ => string.Empty, 
		}, ","), state);
	}

	/// <summary>
	/// 为当前数据表创建数据视图，并按指定的数据列进行排序
	/// </summary>
	/// <typeparam name="T">当前数据表类型</typeparam>
	/// <param name="table">当前的数据表</param>
	/// <param name="sortItems">排序项目</param>
	/// <param name="state">筛选的数据视图数据行状态</param>
	/// <returns>当前数据表的排序视图</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="sortItems" /> 为空。</exception>
	public static DataView<T> CreateView<T>(T table, SortItem[] sortItems, DataViewRowState state = DataViewRowState.None) where T : DataTable
	{
		Guard.AssertNotNull(table, "table");
		return new DataView<T>(table, null, CollectionHelper.JoinString(sortItems.Where((SortItem x) => ObjectHelper.IsNotNull(x)), (SortItem x) => string.Format("{0} {1}", TextHelper.IsNullOrEmpty(x.Name) ? table.Columns[Guard.EnsureBetween(x.Index, 0, table.Columns.Count - 1)].ColumnName : x.Name, (x.Order == SortOrder.Ascending) ? "ASC" : ((x.Order == SortOrder.Descending) ? "DESC" : string.Empty)), ","), state);
	}

	/// <summary>
	/// 为当前数据表创建数据视图，并按指定的数据列进行排序
	/// </summary>
	/// <typeparam name="T">当前数据表类型</typeparam>
	/// <param name="table">当前的数据表</param>
	/// <param name="sortColumns">排序列名称</param>
	/// <param name="sortOrders">排序列排序方向</param>
	/// <param name="state">筛选的数据视图数据行状态</param>
	/// <returns>当前数据表的排序视图</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="sortColumns" /> 为空；或者 <paramref name="sortOrders" /> 为空。</exception>、
	/// <exception cref="T:System.ArgumentException"><paramref name="sortColumns" /> 和 <paramref name="sortOrders" /> 的长度不相同。</exception>
	public static DataView<T> CreateView<T>(T table, string[] sortColumns, SortOrder[] sortOrders, DataViewRowState state = DataViewRowState.None) where T : DataTable
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(sortColumns, "sort columns");
		Guard.AssertNotNull(sortOrders, "sort orders");
		Guard.AssertArrayLength(sortColumns, sortOrders.Length, "sort columns & sort orders", string.Format(Literals.MSG_ArrayLengthNotSame_2, "sort columns", "sort orders"));
		List<string> columns = new List<string>();
		for (int i = 0; i < sortColumns.Length; i++)
		{
			if (ObjectHelper.IsNotNull(sortColumns[i]))
			{
				columns.Add($"{sortColumns[i]} {sortOrders[i]}");
			}
		}
		return new DataView<T>(table, null, CollectionHelper.JoinString(columns, ","), state);
	}

	/// <summary>
	/// 为当前数据表创建数据视图，并按指定的数据列进行排序
	/// </summary>
	/// <typeparam name="T">当前数据表类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="sortIndices">排序列索引数组</param>
	/// <returns>当前数据表的排序视图</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="sortIndices" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="sortIndices" /> 中任意一个列索引超出数据表列的索引范围。</exception>
	public static DataView<T> CreateView<T>(T table, params int[] sortIndices) where T : DataTable
	{
		return CreateView(table, sortIndices, DataViewRowState.None);
	}

	/// <summary>
	/// 为当前数据表创建数据视图，并按指定的数据列进行排序
	/// </summary>
	/// <typeparam name="T">当前数据表类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="sortIndices">排序列索引数组</param>
	/// <param name="state">筛选的数据视图数据行状态</param>
	/// <returns>当前数据表的排序视图</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="sortIndices" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="sortIndices" /> 中任意一个列索引超出数据表列的索引范围。</exception>
	public static DataView<T> CreateView<T>(T table, int[] sortIndices, DataViewRowState state = DataViewRowState.None) where T : DataTable
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(sortIndices, "sort indices");
		Array.ForEach(sortIndices, delegate(int x)
		{
			Guard.AssertIndexRange(x, 0, table.Columns.Count - 1, "index");
		});
		return CreateView(table, sortIndices.Select((int x) => table.Columns[x].ColumnName).ToArray(), state);
	}

	/// <summary>
	/// 为当前数据表创建数据视图，并按指定的数据列进行排序
	/// </summary>
	/// <typeparam name="T">当前数据表类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="sortIndices">排序列索引</param>
	/// <param name="sortOrders">排序列排序标记</param>
	/// <param name="state">筛选的数据视图数据行状态</param>
	/// <returns>当前数据表的排序视图</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="sortIndices" /> 为空；或者 <paramref name="sortOrders" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="sortIndices" /> 中任意一个列索引超出数据表列的索引范围。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="sortIndices" /> 和 <paramref name="sortOrders" /> 的长度不相同。</exception>
	public static DataView<T> CreateView<T>(T table, int[] sortIndices, SortOrder[] sortOrders, DataViewRowState state = DataViewRowState.None) where T : DataTable
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(sortIndices, "sort indices");
		Array.ForEach(sortIndices, delegate(int x)
		{
			Guard.AssertIndexRange(x, 0, table.Columns.Count - 1, "index");
		});
		Guard.AssertNotNull(sortOrders, "sort orders");
		Guard.AssertArrayLength(sortIndices, sortOrders.Length - 1, "sort indices & sort orders", string.Format(Literals.MSG_ArrayLengthNotSame_2, "sort indices", "sort orders"));
		return CreateView(table, sortIndices.Select((int x) => table.Columns[x].ColumnName).ToArray(), sortOrders, state);
	}

	/// <summary>
	/// 获取当前数据表中已删除的数据行的序列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>已删除的数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<DataRow> DeletedRows(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		return from r in Rows(table)
			where r.RowState.HasFlag(DataRowState.Deleted)
			select r;
	}

	/// <summary>
	/// 获取当前数据表中已删除的数据行的序列
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>已删除的数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<R> DeletedRows<R>(DataTable table) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		return from r in Rows<R>(table)
			where r.RowState.HasFlag(DataRowState.Deleted)
			select r;
	}

	/// <summary>
	/// 从当前数据表中删除指定索引的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="index">待删除的数据行索引</param>
	/// <returns>返回被删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 超出当前数据表的数据行索引范围。</exception>
	public static DataRow DeleteRow(DataTable table, int index)
	{
		return DeleteRow<DataRow>(table, index);
	}

	/// <summary>
	/// 从当前数据表中删除指定索引的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="index">待删除的数据行索引</param>
	/// <returns>返回被删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 超出当前数据表的数据行索引范围。</exception>
	public static R DeleteRow<R>(DataTable table, int index) where R : DataRow
	{
		R row = GetRow<R>(table, index);
		row.Delete();
		return row;
	}

	/// <summary>
	/// 从当前数据表中删除指定的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="row">待删除的数据行</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="row" /> 为空。</exception>
	public static void DeleteRow(DataTable table, DataRow row)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(row, "row");
		table.Rows.Remove(row);
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="key">数据行主键值</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow DeleteRow(DataTable table, object key)
	{
		return DeleteRow<DataRow>(table, key);
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="key">数据行主键值</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R DeleteRow<R>(DataTable table, object key) where R : DataRow
	{
		R row = GetRow<R>(table, key);
		if (ObjectHelper.IsNotNull(row))
		{
			row.Delete();
		}
		return row;
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="key">数据行主键值</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="key" /> 为空。</exception>
	public static DataRow DeleteRow(DataTable table, object[] key)
	{
		return DeleteRow<DataRow>(table, key);
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="key">数据行主键值</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="key" /> 为空。</exception>
	public static R DeleteRow<R>(DataTable table, object[] key) where R : DataRow
	{
		R row = GetRow<R>(table, key);
		if (ObjectHelper.IsNotNull(row))
		{
			row.Delete();
		}
		return row;
	}

	/// <summary>
	/// 从当前数据表中删除符合指定条件的第一个数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">待移除的数据表筛选条件</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow DeleteRow(DataTable table, Func<DataRow, bool> predicate)
	{
		return DataHelper.DeleteRow<DataRow>(table, predicate);
	}

	/// <summary>
	/// 从当前数据表中删除符合指定条件的第一个数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">待移除的数据表筛选条件</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R DeleteRow<R>(DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		R row = GetRow(table, predicate);
		if (ObjectHelper.IsNotNull(row))
		{
			row.Delete();
		}
		return row;
	}

	/// <summary>
	/// 从当前数据表中删除符合指定条件的第一个数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">待移除的数据表筛选条件</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow DeleteRow(DataTable table, Func<DataRow, int, bool> predicate)
	{
		return DataHelper.DeleteRow<DataRow>(table, predicate);
	}

	/// <summary>
	/// 从当前数据表中删除符合指定条件的第一个数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">待移除的数据表筛选条件</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R DeleteRow<R>(DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		R row = GetRow(table, predicate);
		if (ObjectHelper.IsNotNull(row))
		{
			row.Delete();
		}
		return row;
	}

	/// <summary>
	/// 从当前数据表中删除指定索引的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="indices">待删除的数据行索引</param>
	/// <returns>成功删除数据行的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="indices" /> 中的任意一个索引超出当前数据表的数据行索引范围。</exception>
	public static DataRow[] DeleteRows(DataTable table, params int[] indices)
	{
		return DeleteRows<DataRow>(table, indices);
	}

	/// <summary>
	/// 从当前数据表中删除指定索引的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="indices">待删除的数据行索引</param>
	/// <returns>成功删除数据行的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="indices" /> 中的任意一个索引超出当前数据表的数据行索引范围。</exception>
	public static R[] DeleteRows<R>(DataTable table, params int[] indices) where R : DataRow
	{
		R[] rows = GetRows<R>(table, indices);
		Array.ForEach(rows, delegate(R r)
		{
			r.Delete();
		});
		return rows;
	}

	/// <summary>
	/// 从当前数据表中删除指定的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="rows">待删除的数据行</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="rows" /> 为空。</exception>
	public static void DeleteRows<R>(DataTable table, params R[] rows) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(rows, "rows");
		foreach (R row in rows)
		{
			Guard.AssertNotNull(row, "row");
			table.Rows.Remove(row);
		}
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">数据行主键数组</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static DataRow[] DeleteRows(DataTable table, params object[] keys)
	{
		return DeleteRows<DataRow>(table, keys);
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">数据行主键数组</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static R[] DeleteRows<R>(DataTable table, params object[] keys) where R : DataRow
	{
		R[] rows = GetRows<R>(table, keys);
		Array.ForEach(rows, delegate(R r)
		{
			r.Delete();
		});
		return rows;
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">数据行主键数组，每个主键由一个对象数组表示</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static DataRow[] DeleteRows(DataTable table, params object[][] keys)
	{
		return DeleteRows<DataRow>(table, keys);
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">数据行主键数组，每个主键由一个对象数组表示</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static R[] DeleteRows<R>(DataTable table, params object[][] keys) where R : DataRow
	{
		R[] rows = GetRows<R>(table, keys);
		Array.ForEach(rows, delegate(R r)
		{
			r.Delete();
		});
		return rows;
	}

	/// <summary>
	/// 从当前数据表中删除所有符合条件的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行删除过滤条件</param>
	/// <returns>成功删除的数据行的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow[] DeleteRows(DataTable table, Func<DataRow, bool> predicate)
	{
		return DataHelper.DeleteRows<DataRow>(table, predicate);
	}

	/// <summary>
	/// 从当前数据表中删除所有符合条件的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行删除过滤条件</param>
	/// <returns>成功删除的数据行的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R[] DeleteRows<R>(DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		R[] rows = GetRows(table, predicate);
		Array.ForEach(rows, delegate(R r)
		{
			r.Delete();
		});
		return rows;
	}

	/// <summary>
	/// 从当前数据表中删除所有符合条件的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行删除过滤条件</param>
	/// <returns>成功删除的数据行的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow[] DeleteRows(DataTable table, Func<DataRow, int, bool> predicate)
	{
		return DataHelper.DeleteRows<DataRow>(table, predicate);
	}

	/// <summary>
	/// 从当前数据表中删除所有符合条件的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行删除过滤条件</param>
	/// <returns>成功删除的数据行的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R[] DeleteRows<R>(DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		R[] rows = GetRows(table, predicate);
		Array.ForEach(rows, delegate(R r)
		{
			r.Delete();
		});
		return rows;
	}

	/// <summary>
	/// 获取当前数据表中新添加的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>新添加的数据行数组，没有新添加的行则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow[] GetAddedRows(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		return GetRows(table, DataRowState.Added);
	}

	/// <summary>
	/// 获取当前数据表中新添加的数据行
	/// </summary>
	/// <typeparam name="R">数据行的类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>新添加的数据行数组，没有新添加的行则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R[] GetAddedRows<R>(DataTable table) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		return GetRows<R>(table, DataRowState.Added);
	}

	/// <summary>
	/// 获取当前数据表中指定索引的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="index">数据列的索引位置</param>
	/// <returns>指定索引的位置的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 超出数据表列的索引范围。</exception>
	public static DataColumn GetColumn(DataTable table, int index)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertIndexRange(index, 0, table.Columns.Count - 1, "index");
		return table.Columns[index];
	}

	/// <summary>
	/// 获取当前数据表中指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <returns>与指定名称匹配的数据列，如果没有匹配的数据列返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static DataColumn GetColumn(DataTable table, string columnName)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnName, "column name");
		return table.Columns[columnName];
	}

	/// <summary>
	/// 获取当前数据表中指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <param name="ignoreCase">数据列名称是否区分大小写</param>
	/// <returns>与指定名称匹配的数据列，如果没有匹配的数据列返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static DataColumn GetColumn(DataTable table, string columnName, bool ignoreCase)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnName, "column name");
		return Columns(table).FirstOrDefault((DataColumn x) => TextHelper.EqualCultural(x.ColumnName, columnName, table.Locale, ignoreCase));
	}

	/// <summary>
	/// 获取当前数据表中指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <param name="comparison">数据列名称比较方式</param>
	/// <returns>与指定名称匹配的数据列，如果没有匹配的数据列返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static DataColumn GetColumn(DataTable table, string columnName, StringComparison comparison)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnName, "column name");
		return Columns(table).FirstOrDefault((DataColumn x) => string.Equals(x.ColumnName, columnName, comparison));
	}

	/// <summary>
	/// 获取当前数据表中指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <param name="comparer">数据列名称比较器</param>
	/// <returns>与指定名称匹配的数据列，如果没有匹配的数据列返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static DataColumn GetColumn(DataTable table, string columnName, IEqualityComparer<string> comparer)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnName, "column name");
		comparer = ObjectHelper.IfNull(comparer, StringComparer.Ordinal);
		return Columns(table).FirstOrDefault((DataColumn x) => comparer.Equals(x.ColumnName, columnName));
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>符合条件的数据列，如果没有匹配的数据列返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataColumn GetColumn(DataTable table, Func<DataColumn, bool> predicate)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return Columns(table).FirstOrDefault(predicate);
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>符合条件的数据列，如果没有匹配的数据列返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataColumn GetColumn(DataTable table, Func<DataColumn, int, bool> predicate)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return CollectionHelper.FirstOrDefault(Columns(table), predicate);
	}

	/// <summary>
	/// 获取当前数据表中指定索引的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="indices">数据列索引数组</param>
	/// <returns>获取的数据列数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数据表为空；或者 <paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="indices" /> 中任一索引超出数据列索引有效范围。</exception>
	public static DataColumn[] GetColumns(DataTable table, params int[] indices)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(indices, "indices");
		Array.ForEach(indices, delegate(int x)
		{
			Guard.AssertIndexRange(x, 0, table.Columns.Count - 1, "index");
		});
		return indices.Select((int x) => table.Columns[x]).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnNames">数据列名称数组</param>
	/// <returns>获取的数据列的数组，如果没有匹配的数据列则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数据表为空；或者 <paramref name="columnNames" /> 为空。</exception>
	public static DataColumn[] GetColumns(DataTable table, params string[] columnNames)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnNames, "column names");
		return (from x in columnNames
			select table.Columns[x] into x
			where ObjectHelper.IsNotNull(x)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnNames">数据列名称数组</param>
	/// <param name="ignoreCase">数据列名称是否区分大小写</param>
	/// <returns>获取的数据列的数组，如果没有匹配的数据列则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数据表为空；或者 <paramref name="columnNames" /> 为空。</exception>
	public static DataColumn[] GetColumns(DataTable table, string[] columnNames, bool ignoreCase)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnNames, "column names");
		return columnNames.SelectMany((string n) => from c in Columns(table)
			where TextHelper.EqualCultural(c.ColumnName, n, table.Locale, ignoreCase)
			select c).Distinct().ToArray();
	}

	/// <summary>
	/// 获取当前数据表中指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnNames">数据列名称数组</param>
	/// <param name="comparison">数据列名称比较方式</param>
	/// <returns>获取的数据列的数组，如果没有匹配的数据列则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数据表为空；或者 <paramref name="columnNames" /> 为空。</exception>
	public static DataColumn[] GetColumns(DataTable table, string[] columnNames, StringComparison comparison)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnNames, "column names");
		return columnNames.SelectMany((string n) => from c in Columns(table)
			where string.Equals(c.ColumnName, n, comparison)
			select c).Distinct().ToArray();
	}

	/// <summary>
	/// 获取当前数据表中指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnNames">数据列名称数组</param>
	/// <param name="comparer">数据列名称比较器</param>
	/// <returns>获取的数据列的数组，如果没有匹配的数据列则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数据表为空；或者 <paramref name="columnNames" /> 为空。</exception>
	public static DataColumn[] GetColumns(DataTable table, string[] columnNames, IEqualityComparer<string> comparer)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnNames, "column names");
		comparer = ObjectHelper.IfNull(comparer, StringComparer.Ordinal);
		return columnNames.SelectMany((string n) => from c in Columns(table)
			where comparer.Equals(c.ColumnName, n)
			select c).Distinct().ToArray();
	}

	/// <summary>
	/// 在当前数据表中查找与指定名称模式匹配的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="pattern">数据列名称模式</param>
	/// <param name="options">模式参数</param>
	/// <returns>符合条件的数据列数组，如果没有匹配的数据列返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数据表为空；或者 <paramref name="pattern" /> 为空。</exception>
	public static DataColumn[] GetColumns(DataTable table, string pattern, RegexOptions options)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(pattern, "pattern");
		return (from x in Columns(table)
			where ConvertHelper.ToRegex(pattern, options).IsMatch(x.ColumnName)
			select x).ToArray();
	}

	/// <summary>
	/// 在当前数据表中查找与指定名称模式匹配的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="pattern">数据列名称模式</param>
	/// <returns>符合条件的数据列数组，如果没有匹配的数据列返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数据表为空；或者 <paramref name="pattern" /> 为空。</exception>
	public static DataColumn[] GetColumns(DataTable table, Regex pattern)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(pattern, "pattern");
		return (from x in Columns(table)
			where pattern.IsMatch(x.ColumnName)
			select x).ToArray();
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>符合条件的数据列数组，如果没有匹配的数据列返回空数组</returns>
	public static DataColumn[] GetColumns(DataTable table, Func<DataColumn, bool> predicate)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return Columns(table).Where(predicate).ToArray();
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>符合条件的数据列数组，如果没有匹配的数据列返回空数组</returns>
	public static DataColumn[] GetColumns(DataTable table, Func<DataColumn, int, bool> predicate)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return Columns(table).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中指定数据列的值数组
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnIndex">数据列索引</param>
	/// <returns>数据列的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据列索引范围。</exception>
	public static object[] GetColumnValues(DataTable table, int columnIndex)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertIndexRange(columnIndex, 0, table.Columns.Count - 1, "column index");
		object[] values = new object[table.Rows.Count];
		for (int i = 0; i < table.Rows.Count; i++)
		{
			values[i] = table.Rows[i][columnIndex];
		}
		return values;
	}

	/// <summary>
	/// 获取当前数据表中指定数据列的值数组
	/// </summary>
	/// <typeparam name="T">数据列的数据类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="columnIndex">数据列索引</param>
	/// <returns>数据列的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据列索引范围。</exception>
	public static T[] GetColumnValues<T>(DataTable table, int columnIndex)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertIndexRange(columnIndex, 0, table.Columns.Count - 1, "column index");
		T[] values = new T[table.Rows.Count];
		for (int i = 0; i < table.Rows.Count; i++)
		{
			values[i] = ObjectHelper.As<T>(ConvertHelper.EnsureDefault(table.Rows[i][columnIndex], typeof(T)));
		}
		return values;
	}

	/// <summary>
	/// 获取当前数据表中指定数据列的值数组
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <returns>数据列值数组；如果指定的数据列不存在，则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static object[] GetColumnValues(DataTable table, string columnName)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnName, "column name");
		DataColumn column = GetColumn(table, columnName);
		return ObjectHelper.IsNull(column) ? null : GetColumnValues(table, column.Ordinal);
	}

	/// <summary>
	/// 获取当前数据表中指定数据列的值数组
	/// </summary>
	/// <typeparam name="T">数据列的数据类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <returns>数据列值数组；如果指定的数据列不存在，则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static T[] GetColumnValues<T>(DataTable table, string columnName)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columnName, "column name");
		DataColumn column = GetColumn(table, columnName);
		return ObjectHelper.IsNull(column) ? null : GetColumnValues<T>(table, column.Ordinal);
	}

	/// <summary>
	/// 获取当前数据表中指定数据列的值数组
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="column">数据列对象</param>
	/// <returns>数据列值数组；如果指定的数据列不存在，则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="column" /> 为空。</exception>
	public static object[] GetColumnValues(DataTable table, DataColumn column)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(column, "column");
		return GetColumnValues(table, column.Ordinal);
	}

	/// <summary>
	/// 获取当前数据表中指定数据列的值数组
	/// </summary>
	/// <typeparam name="T">数据列的数据类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="column">数据列对象</param>
	/// <returns>数据列值数组；如果指定的数据列不存在，则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="column" /> 为空。</exception>
	public static T[] GetColumnValues<T>(DataTable table, DataColumn column)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(column, "column");
		return GetColumnValues<T>(table, column.Ordinal);
	}

	/// <summary>
	/// 获取当前数据表中标记为删除的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>标记为删除的数据行数组，没有该状态的数据行则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow[] GetDeletedRows(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		return GetRows(table, DataRowState.Deleted);
	}

	/// <summary>
	/// 获取当前数据表中标记为删除的数据行
	/// </summary>
	/// <typeparam name="R">数据行的类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>标记为删除的数据行数组，没有该状态的数据行则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R[] GetDeletedRows<R>(DataTable table) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		return GetRows<R>(table, DataRowState.Deleted);
	}

	/// <summary>
	/// 获取当前数据表中修改的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>已修改的数据行的数组，没有该状态的数据行则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow[] GetModifiedRows(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		return GetRows(table, DataRowState.Modified);
	}

	/// <summary>
	/// 获取当前数据表中修改的数据行
	/// </summary>
	/// <typeparam name="R">数据行的类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>已修改的数据行的数组，没有该状态的数据行则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R[] GetModifiedRows<R>(DataTable table) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		return GetRows<R>(table, DataRowState.Modified);
	}

	/// <summary>
	/// 从当前数据表中获取指定索引的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="index">获取的数据行索引</param>
	/// <returns>指定索引位置的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 指定的索引超出当前数据表的行索引范围。</exception>
	public static DataRow GetRow(DataTable table, int index)
	{
		return GetRow<DataRow>(table, index);
	}

	/// <summary>
	/// 从当前数据表中获取指定索引的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="index">获取的数据行索引</param>
	/// <returns>指定索引位置的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 指定的索引超出当前数据表的行索引范围。</exception>
	public static R GetRow<R>(DataTable table, int index) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertIndexRange(index, 0, table.Rows.Count - 1, "index");
		return ObjectHelper.As<R>(table.Rows[index]);
	}

	/// <summary>
	/// 从当前数据表中获取与主键值匹配的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="key">主键值</param>
	/// <returns>与主键匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow GetRow(DataTable table, object key)
	{
		return GetRow<DataRow>(table, key);
	}

	/// <summary>
	/// 从当前数据表中获取与主键值匹配的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="key">主键值</param>
	/// <returns>与主键匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R GetRow<R>(DataTable table, object key) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		return ObjectHelper.As<R>(table.Rows.Find(key));
	}

	/// <summary>
	/// 从当前数据表中获取与主键值匹配的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="key">主键值</param>
	/// <returns>与主键匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="key" /> 为空。</exception>
	public static DataRow GetRow(DataTable table, object[] key)
	{
		return GetRow<DataRow>(table, key);
	}

	/// <summary>
	/// 从当前数据表中获取与主键值匹配的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="key">主键值</param>
	/// <returns>与主键匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="key" /> 为空。</exception>
	public static R GetRow<R>(DataTable table, object[] key) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(key, "key");
		return ObjectHelper.As<R>(table.Rows.Find(key));
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>符合条件的数据行，如果没有匹配的数据行返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow GetRow(DataTable table, Func<DataRow, bool> predicate)
	{
		return DataHelper.GetRow<DataRow>(table, predicate);
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>符合条件的数据行，如果没有匹配的数据行返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R GetRow<R>(DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return Rows<R>(table).FirstOrDefault(predicate);
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>符合条件的数据行，如果没有匹配的数据行返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow GetRow(DataTable table, Func<DataRow, int, bool> predicate)
	{
		return DataHelper.GetRow<DataRow>(table, predicate);
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>符合条件的数据行，如果没有匹配的数据行返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R GetRow<R>(DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return CollectionHelper.FirstOrDefault(Rows<R>(table), predicate);
	}

	/// <summary>
	/// 获取当前数据表中指定索引位置的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="indices">数据行索引数组</param>
	/// <returns>指定索引位置的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="indices" /> 中任一索引超出数据行索引范围。</exception>
	public static DataRow[] GetRows(DataTable table, params int[] indices)
	{
		return GetRows<DataRow>(table, indices);
	}

	/// <summary>
	/// 获取当前数据表中指定索引位置的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="indices">数据行索引数组</param>
	/// <returns>指定索引位置的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="indices" /> 中任一索引超出数据行索引范围。</exception>
	public static R[] GetRows<R>(DataTable table, params int[] indices) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(indices, "indices");
		Array.ForEach(indices, delegate(int i)
		{
			Guard.AssertIndexRange(i, 0, table.Rows.Count - 1, "indices");
		});
		return indices.Select((int i) => ObjectHelper.As<R>(table.Rows[i])).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中与指定主键值匹配的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">主键值数组</param>
	/// <returns>与指定主键值匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static DataRow[] GetRows(DataTable table, params object[] keys)
	{
		return GetRows<DataRow>(table, keys);
	}

	/// <summary>
	/// 获取当前数据表中与指定主键值匹配的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">主键值数组</param>
	/// <returns>与指定主键值匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static R[] GetRows<R>(DataTable table, params object[] keys) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(keys, "keys");
		return (from k in keys
			select ObjectHelper.As<R>(table.Rows.Find(k)) into x
			where ObjectHelper.IsNotNull(x)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中与指定主键值匹配的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">主键值数组</param>
	/// <returns>与指定主键值匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static DataRow[] GetRows(DataTable table, params object[][] keys)
	{
		return GetRows<DataRow>(table, keys);
	}

	/// <summary>
	/// 获取当前数据表中与指定主键值匹配的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">主键值数组</param>
	/// <returns>与指定主键值匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static R[] GetRows<R>(DataTable table, params object[][] keys) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(keys, "keys");
		return (from k in keys
			select ObjectHelper.As<R>(table.Rows.Find(k)) into x
			where ObjectHelper.IsNotNull(x)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中符合条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>符合条件的数据行数组，如果没有匹配的数据行返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow[] GetRows(DataTable table, Func<DataRow, bool> predicate)
	{
		return DataHelper.GetRows<DataRow>(table, predicate);
	}

	/// <summary>
	/// 获取当前数据表中符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>符合条件的数据行数组，如果没有匹配的数据行返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R[] GetRows<R>(DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return Rows<R>(table).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中符合条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>符合条件的数据行数组，如果没有匹配的数据行返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow[] GetRows(DataTable table, Func<DataRow, int, bool> predicate)
	{
		return DataHelper.GetRows<DataRow>(table, predicate);
	}

	/// <summary>
	/// 获取当前数据表中符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R[] GetRows<R>(DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return Rows<R>(table).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中具有指定行状态的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="state">数据行状态</param>
	/// <returns>具有指定行状态的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow[] GetRows(DataTable table, DataRowState state)
	{
		return GetRows<DataRow>(table, state);
	}

	/// <summary>
	/// 获取当前数据表中具有指定行状态的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="state">数据行状态</param>
	/// <returns>具有指定行状态的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R[] GetRows<R>(DataTable table, DataRowState state) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		return (from r in Rows<R>(table)
			where r.RowState.HasFlag(state)
			select r).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中未更改的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>未更改的数据行的数组，没有该状态的数据行则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow[] GetUnchangedRows(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		return GetRows(table, DataRowState.Unchanged);
	}

	/// <summary>
	/// 获取当前数据表中未更改的数据行
	/// </summary>
	/// <typeparam name="R">数据行的类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>未更改的数据行的数组，没有该状态的数据行则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R[] GetUnchangedRows<R>(DataTable table) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		return GetRows<R>(table, DataRowState.Unchanged);
	}

	/// <summary>
	/// 检测当前数据表中的数据行是否发生了更改
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>如果数据表发生了变更则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	/// <remarks>逐行检测每个数据行的状态，如果数据行的状态不是 <see cref="F:System.Data.DataRowState.Unchanged" />，则认为数据表发生了更改。</remarks>
	public static bool HasChanged(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		return table.Rows.OfType<DataRow>().Any((DataRow dr) => dr.RowState != DataRowState.Unchanged);
	}

	/// <summary>
	/// 向当前数据表的数据行集合开头的插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="row">待插入的数据行</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="row" /> 为空。</exception>
	public static void InsertFirstRow(DataTable table, DataRow row)
	{
		InsertRow(table, row, 0);
	}

	/// <summary>
	/// 向当前数据表的数据行集合开头的插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="items">创建新行用的值的数组</param>
	/// <returns>创建的新的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="items" /> 为空。</exception>
	public static DataRow InsertFirstRow(DataTable table, object[] items)
	{
		return InsertRow(table, items, 0);
	}

	/// <summary>
	/// 向当前数据表的头部的插入数据行
	/// </summary>
	/// <typeparam name="R">插入的数据行的类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="items">创建新行用的值的数组</param>
	/// <returns>创建的新的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="items" /> 为空。</exception>
	public static R InsertFirstRow<R>(DataTable table, object[] items) where R : DataRow
	{
		return InsertRow<R>(table, items, 0);
	}

	/// <summary>
	/// 向当前数据表的头部插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="rows">待插入的数据行</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="rows" /> 为空。</exception>
	/// <remarks>插入后数据行的顺序与给定的 <paramref name="rows" /> 顺序相同。</remarks>
	public static void InsertFirstRows(DataTable table, params DataRow[] rows)
	{
		InsertRows(table, rows, 0);
	}

	/// <summary>
	/// 向当前数据表的头部插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="itemsArray">创建新行用的值的数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="itemsArray" /> 为空。</exception>
	/// <remarks>插入后数据行的顺序与给定的 <paramref name="itemsArray" /> 顺序相同。</remarks>
	public static DataRow[] InsertFirstRows(DataTable table, params object[][] itemsArray)
	{
		return InsertRows(table, itemsArray, 0);
	}

	/// <summary>
	/// 向当前数据表的头部插入数据行
	/// </summary>
	/// <typeparam name="R">插入的数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="itemsArray">创建新行用的值的数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="itemsArray" /> 为空。</exception>
	/// <remarks>插入后数据行的顺序与给定的 <paramref name="itemsArray" /> 顺序相同。</remarks>
	public static R[] InsertFirstRows<R>(DataTable table, params object[][] itemsArray) where R : DataRow
	{
		return InsertRows<R>(table, itemsArray, 0);
	}

	/// <summary>
	/// 向当前数据表的末尾的插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="row">待插入的数据行</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="row" /> 为空。</exception>
	public static void InsertLastRow(DataTable table, DataRow row)
	{
		Guard.AssertNotNull(table, "table");
		InsertRow(table, row, table.Rows.Count);
	}

	/// <summary>
	/// 向当前数据表的末尾的插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="items">创建新行用的值的数组</param>
	/// <returns>创建的新的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="items" /> 为空。</exception>
	public static DataRow InsertLastRow(DataTable table, object[] items)
	{
		Guard.AssertNotNull(table, "table");
		return InsertRow(table, items, table.Rows.Count);
	}

	/// <summary>
	/// 向当前数据表的末尾的插入数据行
	/// </summary>
	/// <typeparam name="R">插入的数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="items">创建新行用的值的数组</param>
	/// <returns>创建的新的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="items" /> 为空。</exception>
	public static R InsertLastRow<R>(DataTable table, object[] items) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		return InsertRow<R>(table, items, table.Rows.Count);
	}

	/// <summary>
	/// 向当前数据表的末尾的插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="rows">待插入的数据行</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="rows" /> 为空。</exception>
	/// <remarks>插入后数据行的顺序与给定的 <paramref name="rows" /> 顺序相同。</remarks>
	public static void InsertLastRows(DataTable table, params DataRow[] rows)
	{
		Guard.AssertNotNull(table, "table");
		InsertRows(table, rows, table.Rows.Count);
	}

	/// <summary>
	/// 向当前数据表的末尾插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="itemsArray">创建新行用的值的数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="itemsArray" /> 为空。</exception>
	/// <remarks>插入后数据行的顺序与给定的 <paramref name="itemsArray" /> 顺序相同。</remarks>
	public static DataRow[] InsertLastRows(DataTable table, params object[][] itemsArray)
	{
		Guard.AssertNotNull(table, "table");
		return InsertRows(table, itemsArray, table.Rows.Count);
	}

	/// <summary>
	/// 向当前数据表的末尾插入数据行
	/// </summary>
	/// <typeparam name="R">插入的数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="itemsArray">创建新行用的值的数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="itemsArray" /> 为空。</exception>
	/// <remarks>插入后数据行的顺序与给定的 <paramref name="itemsArray" /> 顺序相同。</remarks>
	public static R[] InsertLastRows<R>(DataTable table, params object[][] itemsArray) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		return InsertRows<R>(table, itemsArray, table.Rows.Count);
	}

	/// <summary>
	/// 向当前数据表的指定位置中插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="row">待插入的数据行</param>
	/// <param name="position">数据行插入的位置</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="row" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="position" /> 小于0。</exception>
	public static void InsertRow(DataTable table, DataRow row, int position)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(row, "row");
		Guard.AssertGreaterThanOrEqualTo(position, 0, "position");
		table.Rows.InsertAt(row, position);
	}

	/// <summary>
	/// 向当前数据表的指定位置中插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="items">创建新行用的值的数组</param>
	/// <param name="position">数据行的插入的位置</param>
	/// <returns>返回插入的新数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="position" /> 小于0。</exception>
	public static DataRow InsertRow(DataTable table, object[] items, int position)
	{
		return InsertRow<DataRow>(table, items, position);
	}

	/// <summary>
	/// 向当前数据表的指定位置中插入数据行
	/// </summary>
	/// <typeparam name="R">插入的数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="items">创建新行用的值的数组</param>
	/// <param name="position">数据行的插入的位置</param>
	/// <returns>返回插入的新数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="position" /> 小于0。</exception>
	public static R InsertRow<R>(DataTable table, object[] items, int position) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(items, "items");
		Guard.AssertGreaterThanOrEqualTo(position, 0, "position");
		R row = ObjectHelper.As<R>(table.NewRow());
		row.ItemArray = items;
		table.Rows.InsertAt(row, position);
		return row;
	}

	/// <summary>
	/// 向当前数据表的指定位置中插入多个数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="rows">待插入的数据行</param>
	/// <param name="position">数据行插入的位置</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="rows" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="position" /> 小于0。</exception>
	/// <remarks>插入后数据行的顺序与给定的 <paramref name="rows" /> 顺序相同。</remarks>
	public static void InsertRows(DataTable table, DataRow[] rows, int position)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(rows, "rows");
		Guard.AssertGreaterThanOrEqualTo(position, 0, "position");
		foreach (DataRow row in rows)
		{
			if (ObjectHelper.IsNotNull(row))
			{
				table.Rows.InsertAt(row, position++);
			}
		}
	}

	/// <summary>
	/// 向当前数据表的指定位置中插入多个数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="itemsArray">创建新行用的值的数组</param>
	/// <param name="position">数据行插入位置</param>
	/// <returns>插入的新创建的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="itemsArray" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="position" /> 小于0。</exception>
	/// <remarks>插入后数据行的顺序与给定的 <paramref name="itemsArray" /> 顺序相同。</remarks>
	public static DataRow[] InsertRows(DataTable table, object[][] itemsArray, int position)
	{
		return InsertRows<DataRow>(table, itemsArray, position);
	}

	/// <summary>
	/// 向当前数据表的指定位置中插入多个数据行
	/// </summary>
	/// <typeparam name="R">插入的数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="itemsArray">创建新行用的值的数组</param>
	/// <param name="position">数据行插入位置</param>
	/// <returns>插入的新创建的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="itemsArray" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="position" /> 小于0。</exception>
	/// <remarks>插入后数据行的顺序与给定的 <paramref name="itemsArray" /> 顺序相同。</remarks>
	public static R[] InsertRows<R>(DataTable table, object[][] itemsArray, int position) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(itemsArray, "items array");
		Guard.AssertGreaterThanOrEqualTo(position, 0, "position");
		List<R> rows = new List<R>(itemsArray.Length);
		foreach (object[] items in itemsArray)
		{
			if (ObjectHelper.IsNotNull(items))
			{
				R row = ObjectHelper.As<R>(table.NewRow());
				row.ItemArray = items;
				table.Rows.InsertAt(row, position++);
				rows.Add(row);
			}
		}
		return rows.ToArray();
	}

	/// <summary>
	/// 获取当前数据表中已修改的数据行的序列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>已修改的数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<DataRow> ModifiedRows(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		return from r in Rows(table)
			where r.RowState.HasFlag(DataRowState.Modified)
			select r;
	}

	/// <summary>
	/// 获取当前数据表中已修改的数据行的序列
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>已修改的数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<R> ModifiedRows<R>(DataTable table) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		return from r in Rows<R>(table)
			where r.RowState.HasFlag(DataRowState.Modified)
			select r;
	}

	/// <summary>
	/// 从当前数据表中移除指定位置的索引
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="index">待删除的数据列的索引</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 超出了数据列索引范围。</exception>
	public static DataColumn RemoveColumn(DataTable table, int index)
	{
		Guard.AssertNotNull(table, "table");
		DataColumn column = GetColumn(table, index);
		table.Columns.RemoveAt(column.Ordinal);
		return column;
	}

	/// <summary>
	/// 从当前数据表中移除指定的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="column">待移除的数据列</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="column" /> 为空。</exception>
	public static void RemoveColumn(DataTable table, DataColumn column)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(column, "column");
		table.Columns.Remove(column);
	}

	/// <summary>
	/// 从当前数据表中移除指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">待移除的数据列名称</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static DataColumn RemoveColumn(DataTable table, string columnName)
	{
		Guard.AssertNotNull(table, "table");
		DataColumn column = GetColumn(table, columnName);
		if (ObjectHelper.IsNotNull(column))
		{
			table.Columns.RemoveAt(column.Ordinal);
		}
		return column;
	}

	/// <summary>
	/// 从当前数据表中移除指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <param name="ignoreCase">数据列名称是否区分大小写</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static DataColumn RemoveColumn(DataTable table, string columnName, bool ignoreCase)
	{
		Guard.AssertNotNull(table, "table");
		DataColumn column = GetColumn(table, columnName, ignoreCase);
		table.Columns.RemoveAt(column.Ordinal);
		return column;
	}

	/// <summary>
	/// 从当前数据表中移除指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <param name="comparison">数据列名称比较方式</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static DataColumn RemoveColumn(DataTable table, string columnName, StringComparison comparison)
	{
		Guard.AssertNotNull(table, "table");
		DataColumn column = GetColumn(table, columnName, comparison);
		table.Columns.RemoveAt(column.Ordinal);
		return column;
	}

	/// <summary>
	/// 从当前数据表中移除指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <param name="comparer">数据列名称比较对象</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static DataColumn RemoveColumn(DataTable table, string columnName, IEqualityComparer<string> comparer)
	{
		Guard.AssertNotNull(table, "table");
		DataColumn column = GetColumn(table, columnName, comparer);
		table.Columns.RemoveAt(column.Ordinal);
		return column;
	}

	/// <summary>
	/// 从当前数据表中移除满足条件的第一个数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataColumn RemoveColumn(DataTable table, Func<DataColumn, bool> predicate)
	{
		Guard.AssertNotNull(table, "table");
		DataColumn column = GetColumn(table, predicate);
		table.Columns.RemoveAt(column.Ordinal);
		return column;
	}

	/// <summary>
	/// 从当前数据表中移除满足条件的第一个数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataColumn RemoveColumn(DataTable table, Func<DataColumn, int, bool> predicate)
	{
		Guard.AssertNotNull(table, "table");
		DataColumn column = GetColumn(table, predicate);
		table.Columns.RemoveAt(column.Ordinal);
		return column;
	}

	/// <summary>
	/// 从当前数据表中删除指定索引的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="indices">待删除的数据列的索引列表</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表null；<paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="indices" /> 中的任意一个索引超出当前数据表的数据行索引范围。</exception>
	public static DataColumn[] RemoveColumns(DataTable table, params int[] indices)
	{
		Guard.AssertNotNull(table, "table");
		DataColumn[] columns = GetColumns(table, indices);
		Array.ForEach(columns, delegate(DataColumn c)
		{
			table.Columns.RemoveAt(c.Ordinal);
		});
		return columns;
	}

	/// <summary>
	/// 从当前数据表中删除指定的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columns">待删除的数据列的列表</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；<paramref name="columns" /> 为空。</exception>
	public static void RemoveColumns(DataTable table, params DataColumn[] columns)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columns, "columns");
		foreach (DataColumn column in columns)
		{
			Guard.AssertNotNull(column, "column");
			table.Columns.Remove(column);
		}
	}

	/// <summary>
	/// 从当前数据表中删除指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnNames">待删除的数据列的名称列表</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；<paramref name="columnNames" /> 为空。</exception>
	public static DataColumn[] RemoveColumns(DataTable table, params string[] columnNames)
	{
		Guard.AssertNotNull(table, "table");
		DataColumn[] columns = GetColumns(table, columnNames);
		Array.ForEach(columns, delegate(DataColumn c)
		{
			table.Columns.RemoveAt(c.Ordinal);
		});
		return columns;
	}

	/// <summary>
	/// 从当前数据表中删除指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnNames">待删除的数据列的名称列表</param>
	/// <param name="ignoreCase">数据列名称是否区分大小写</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；<paramref name="columnNames" /> 为空。</exception>
	public static DataColumn[] RemoveColumns(DataTable table, string[] columnNames, bool ignoreCase)
	{
		Guard.AssertNotNull(table, "table");
		DataColumn[] columns = GetColumns(table, columnNames, ignoreCase);
		Array.ForEach(columns, delegate(DataColumn c)
		{
			table.Columns.RemoveAt(c.Ordinal);
		});
		return columns;
	}

	/// <summary>
	/// 从当前数据表中删除指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnNames">待删除的数据列的名称列表</param>
	/// <param name="comparison">数据列名称比较方式</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；<paramref name="columnNames" /> 为空。</exception>
	public static DataColumn[] RemoveColumns(DataTable table, string[] columnNames, StringComparison comparison)
	{
		Guard.AssertNotNull(table, "table");
		DataColumn[] columns = GetColumns(table, columnNames, comparison);
		Array.ForEach(columns, delegate(DataColumn c)
		{
			table.Columns.RemoveAt(c.Ordinal);
		});
		return columns;
	}

	/// <summary>
	/// 从当前数据表中删除指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnNames">待删除的数据列的名称列表</param>
	/// <param name="comparer">数据列名称比较对象</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；<paramref name="columnNames" /> 为空。</exception>
	public static DataColumn[] RemoveColumns(DataTable table, string[] columnNames, IEqualityComparer<string> comparer)
	{
		Guard.AssertNotNull(table, "table");
		DataColumn[] columns = GetColumns(table, columnNames, comparer);
		Array.ForEach(columns, delegate(DataColumn c)
		{
			table.Columns.RemoveAt(c.Ordinal);
		});
		return columns;
	}

	/// <summary>
	/// 从当前数据表中移除所有符合条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；<paramref name="predicate" /> 为空。</exception>
	public static DataColumn[] RemoveColumns(DataTable table, Func<DataColumn, bool> predicate)
	{
		Guard.AssertNotNull(table, "table");
		DataColumn[] columns = GetColumns(table, predicate);
		Array.ForEach(columns, delegate(DataColumn c)
		{
			table.Columns.RemoveAt(c.Ordinal);
		});
		return columns;
	}

	/// <summary>
	/// 从当前数据表中移除所有符合条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；<paramref name="predicate" /> 为空。</exception>
	public static DataColumn[] RemoveColumns(DataTable table, Func<DataColumn, int, bool> predicate)
	{
		Guard.AssertNotNull(table, "table");
		DataColumn[] columns = GetColumns(table, predicate);
		Array.ForEach(columns, delegate(DataColumn c)
		{
			table.Columns.RemoveAt(c.Ordinal);
		});
		return columns;
	}

	/// <summary>
	/// 从当前数据表中移除指定索引位置的数据行
	/// </summary>
	/// <param name="table">当前的数据表</param>
	/// <param name="index">待移除的数据行的索引</param>
	/// <returns>被删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 超出数据行索引范围。</exception>
	public static DataRow RemoveRow(DataTable table, int index)
	{
		return RemoveRow<DataRow>(table, index);
	}

	/// <summary>
	/// 从当前数据表中移除指定索引位置的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前的数据表</param>
	/// <param name="index">待移除的数据行的索引</param>
	/// <returns>被删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 超出数据行索引范围。</exception>
	public static R RemoveRow<R>(DataTable table, int index) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		R row = GetRow<R>(table, index);
		if (ObjectHelper.IsNotNull(row))
		{
			table.Rows.Remove(row);
		}
		return row;
	}

	/// <summary>
	/// 从当前数据表中移除指定的数据行
	/// </summary>
	/// <param name="table">当前的数据表</param>
	/// <param name="row">待移除的数据行</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="row" /> 为空。</exception>
	public static void RemoveRow(DataTable table, DataRow row)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(row, "row");
		table.Rows.Remove(row);
	}

	/// <summary>
	/// 从当前数据表中移除与主键值匹配的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="key">待移除数据行的主键值</param>
	/// <returns>被删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow RemoveRow(DataTable table, object key)
	{
		return RemoveRow<DataRow>(table, key);
	}

	/// <summary>
	/// 从当前数据表中移除与主键值匹配的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="key">待移除数据行的主键值</param>
	/// <returns>被删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R RemoveRow<R>(DataTable table, object key) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		R row = GetRow<R>(table, key);
		if (ObjectHelper.IsNotNull(row))
		{
			table.Rows.Remove(row);
		}
		return row;
	}

	/// <summary>
	/// 从当前数据表中移除与主键值匹配的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="key">待移除数据行的主键值数组</param>
	/// <returns>删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="key" /> 为空。</exception>
	public static DataRow RemoveRow(DataTable table, object[] key)
	{
		return RemoveRow<DataRow>(table, key);
	}

	/// <summary>
	/// 从当前数据表中移除与主键值匹配的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="key">待移除数据行的主键值数组</param>
	/// <returns>删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="key" /> 为空。</exception>
	public static R RemoveRow<R>(DataTable table, object[] key) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		R row = GetRow<R>(table, key);
		if (ObjectHelper.IsNotNull(row))
		{
			table.Rows.Remove(row);
		}
		return row;
	}

	/// <summary>
	/// 从当前数据表中移除符合条件的第一个数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">待移除的数据表筛选条件</param>
	/// <returns>删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow RemoveRow(DataTable table, Func<DataRow, bool> predicate)
	{
		return DataHelper.RemoveRow<DataRow>(table, predicate);
	}

	/// <summary>
	/// 从当前数据表中移除符合条件的第一个数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">待移除的数据表筛选条件</param>
	/// <returns>删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R RemoveRow<R>(DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		R row = GetRow(table, predicate);
		if (ObjectHelper.IsNotNull(row))
		{
			table.Rows.Remove(row);
		}
		return row;
	}

	/// <summary>
	/// 从当前数据表中移除符合条件的第一个数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">待移除的数据表筛选条件</param>
	/// <returns>删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow RemoveRow(DataTable table, Func<DataRow, int, bool> predicate)
	{
		return DataHelper.RemoveRow<DataRow>(table, predicate);
	}

	/// <summary>
	/// 从当前数据表中移除符合条件的第一个数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">待移除的数据表筛选条件</param>
	/// <returns>删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R RemoveRow<R>(DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		R row = GetRow(table, predicate);
		if (ObjectHelper.IsNotNull(row))
		{
			table.Rows.Remove(row);
		}
		return row;
	}

	/// <summary>
	/// 从当前数据表中删除指定索引的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="indices">待删除的数据表的行索引</param>
	/// <returns>删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="indices" /> 中任一索引超出数据行索引范围。</exception>
	public static DataRow[] RemoveRows(DataTable table, params int[] indices)
	{
		return RemoveRows<DataRow>(table, indices);
	}

	/// <summary>
	/// 从当前数据表中删除指定索引的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="indices">待删除的数据表的行索引</param>
	/// <returns>删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="indices" /> 中任一索引超出数据行索引范围。</exception>
	public static R[] RemoveRows<R>(DataTable table, params int[] indices) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		R[] rows = GetRows<R>(table, indices);
		Array.ForEach(rows, delegate(R r)
		{
			table.Rows.Remove(r);
		});
		return rows;
	}

	/// <summary>
	/// 从当前数据表中删除指定的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="rows">待删除的数据行</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="rows" /> 为空。</exception>
	public static void RemoveRows<R>(DataTable table, params R[] rows) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(rows, "rows");
		foreach (R row in rows)
		{
			Guard.AssertNotNull(row, "row");
			table.Rows.Remove(row);
		}
	}

	/// <summary>
	/// 从当前数据表中删除指定的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">数据行主键数组</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static DataRow[] RemoveRows(DataTable table, params object[] keys)
	{
		return RemoveRows<DataRow>(table, keys);
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">数据行主键数组</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static R[] RemoveRows<R>(DataTable table, params object[] keys) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		R[] rows = GetRows<R>(table, keys);
		Array.ForEach(rows, delegate(R r)
		{
			table.Rows.Remove(r);
		});
		return rows;
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">数据行主键数组，每个主键由一个对象数组表示</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static DataRow[] RemoveRows(DataTable table, params object[][] keys)
	{
		return RemoveRows<DataRow>(table, keys);
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">数据行主键数组，每个主键由一个对象数组表示</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static R[] RemoveRows<R>(DataTable table, params object[][] keys) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		R[] rows = GetRows<R>(table, keys);
		Array.ForEach(rows, delegate(R r)
		{
			table.Rows.Remove(r);
		});
		return rows;
	}

	/// <summary>
	/// 从当前数据表中删除所有符合条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行删除过滤条件</param>
	/// <returns>返回被删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow[] RemoveRows(DataTable table, Func<DataRow, bool> predicate)
	{
		return DataHelper.RemoveRows<DataRow>(table, predicate);
	}

	/// <summary>
	/// 从当前数据表中删除所有符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行删除过滤条件</param>
	/// <returns>返回被删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R[] RemoveRows<R>(DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		R[] rows = GetRows(table, predicate);
		Array.ForEach(rows, delegate(R r)
		{
			table.Rows.Remove(r);
		});
		return rows;
	}

	/// <summary>
	/// 从当前数据表中删除所有符合条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行删除过滤条件</param>
	/// <returns>返回被删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow[] RemoveRows(DataTable table, Func<DataRow, int, bool> predicate)
	{
		return DataHelper.RemoveRows<DataRow>(table, predicate);
	}

	/// <summary>
	/// 从当前数据表中删除所有符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行删除过滤条件</param>
	/// <returns>成功删除的数据行的数量</returns>
	public static R[] RemoveRows<R>(DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		R[] rows = GetRows(table, predicate);
		Array.ForEach(rows, delegate(R r)
		{
			table.Rows.Remove(r);
		});
		return rows;
	}

	/// <summary>
	/// 获取当前数据表的数据行数量
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>当前数据表包含的数据行数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static int RowCount(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		return table.Rows.Count;
	}

	/// <summary>
	/// 获取当前数据表中具有指定行状态的数据行的数量
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="state">需要计数的数据行状态</param>
	/// <returns>指定行状态的数据行的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static int RowCount(DataTable table, DataRowState state)
	{
		Guard.AssertNotNull(table, "table");
		return (from r in Rows(table)
			where r.RowState.HasFlag(state)
			select r).Count();
	}

	/// <summary>
	/// 获取当前数据表中数据行的序列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<DataRow> Rows(DataTable table)
	{
		return Rows<DataRow>(table);
	}

	/// <summary>
	/// 获取当前数据表中数据行的序列
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<R> Rows<R>(DataTable table) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		return table.Rows.OfType<R>();
	}

	/// <summary>
	/// 获取当前数据表中指定行状态的序列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="state">数据行状态</param>
	/// <returns>数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<DataRow> Rows(DataTable table, DataRowState state)
	{
		return Rows<DataRow>(table, state);
	}

	/// <summary>
	/// 获取当前数据表中指定行状态的序列
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="state">数据行状态</param>
	/// <returns>数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<R> Rows<R>(DataTable table, DataRowState state) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		return from r in Rows<R>(table)
			where r.RowState.HasFlag(state)
			select r;
	}

	/// <summary>
	/// 获取当前数据表中满足指定条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<DataRow> Rows(DataTable table, Func<DataRow, bool> predicate)
	{
		return DataHelper.Rows<DataRow>(table, predicate);
	}

	/// <summary>
	/// 获取当前数据表中满足指定条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<R> Rows<R>(DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return Rows<R>(table).Where(predicate);
	}

	/// <summary>
	/// 获取当前数据表中满足指定条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<DataRow> Rows(DataTable table, Func<DataRow, int, bool> predicate)
	{
		return DataHelper.Rows<DataRow>(table, predicate);
	}

	/// <summary>
	/// 获取当前数据表中满足指定条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<R> Rows<R>(DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(predicate, "predicate");
		return Rows<R>(table).Where(predicate);
	}

	/// <summary>
	/// 设置当前数据表中数据行为 <see cref="F:System.Data.DataRowState.Added" /> 状态，仅处理状态为 <see cref="F:System.Data.DataRowState.Unchanged" /> 的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>处理后状态为 <see cref="F:System.Data.DataRowState.Added" /> 的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow[] SetRowsAdded(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		CollectionHelper.ForEach(UnchangedRows(table), delegate(DataRow r)
		{
			r.SetAdded();
		});
		return AddedRows(table).ToArray();
	}

	/// <summary>
	/// 设置当前数据表中数据行为 <see cref="F:System.Data.DataRowState.Added" /> 状态，仅处理状态为 <see cref="F:System.Data.DataRowState.Unchanged" /> 的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>处理后状态为 <see cref="F:System.Data.DataRowState.Added" /> 的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R[] SetRowsAdded<R>(DataTable table) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		CollectionHelper.ForEach(UnchangedRows<R>(table), delegate(R r)
		{
			r.SetAdded();
		});
		return AddedRows<R>(table).ToArray();
	}

	/// <summary>
	/// 设置当前数据表中数据行为 <see cref="F:System.Data.DataRowState.Modified" /> 状态，仅处理状态为 <see cref="F:System.Data.DataRowState.Unchanged" /> 的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>处理后状态为 <see cref="F:System.Data.DataRowState.Modified" /> 的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow[] SetRowsModified(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		CollectionHelper.ForEach(UnchangedRows(table), delegate(DataRow r)
		{
			r.SetModified();
		});
		return ModifiedRows(table).ToArray();
	}

	/// <summary>
	/// 设置当前数据表中数据行为 <see cref="F:System.Data.DataRowState.Modified" /> 状态，仅处理状态为 <see cref="F:System.Data.DataRowState.Unchanged" /> 的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>处理后状态为 <see cref="F:System.Data.DataRowState.Modified" /> 的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R[] SetRowsModified<R>(DataTable table) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		CollectionHelper.ForEach(UnchangedRows<R>(table), delegate(R r)
		{
			r.SetModified();
		});
		return ModifiedRows<R>(table).ToArray();
	}

	/// <summary>
	/// 将当前数据表转换为对象数组，每个数据行转换为一个对象；每个数据列映射到对象上相应的公共实例属性
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="type">转换的目标类型</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空。</exception>
	public static object[] ToObjectArray(DataTable table, Type type)
	{
		Guard.AssertNotNull(table, "table");
		return (from r in Rows(table)
			select ToObject(r, type)).ToArray();
	}

	/// <summary>
	/// 将当前数据表转换为对象数组，每个数据行转换为一个对象；每个数据列映射到对象上相应的公共实例属性
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="obj">转换的目标对象，如果为空则创建该类型的对象的新实例</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	public static T[] ToObjectArray<T>(DataTable table, T obj = default(T))
	{
		Guard.AssertNotNull(table, "table");
		return (from r in Rows(table)
			select ToObject(r, obj)).ToArray();
	}

	/// <summary>
	/// 将当前数据表转换为对象数组，每个数据行转换为一个对象
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="type">转换的目标类型</param>
	/// <param name="flags">属性绑定标志</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空。</exception>
	public static object[] ToObjectArray(DataTable table, Type type, BindingFlags flags)
	{
		Guard.AssertNotNull(table, "table");
		return (from r in Rows(table)
			select ToObject(r, type, flags)).ToArray();
	}

	/// <summary>
	/// 将当前数据表转换为对象数组，每个数据行转换为一个对象
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="obj">转换的目标对象，如果为空则创建该类型的对象的新实例</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	public static T[] ToObjectArray<T>(DataTable table, BindingFlags flags, T obj = default(T))
	{
		Guard.AssertNotNull(table, "table");
		return (from r in Rows(table)
			select ToObject(r, flags, obj)).ToArray();
	}

	/// <summary>
	/// 将当前数据表转换为对象数组，每个数据行转换为一个对象；每个数据列映射到对象上相应的公共实例属性
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="type">转换的目标类型</param>
	/// <param name="columns">转换映射的数据列名称</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空；转换映射的数据列名称 <paramref name="columns" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static object[] ToObjectArray(DataTable table, Type type, string[] columns, bool onlyMapping = false, bool ignoreCase = false)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(columns, "columns");
		return (from r in Rows(table)
			select ToObject(r, type, columns, onlyMapping, ignoreCase)).ToArray();
	}

	/// <summary>
	/// 将当前数据表转换为对象数组，每个数据行转换为一个对象；每个数据列映射到对象上相应的公共实例属性
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="columns">转换映射的数据列名称</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <param name="obj">转换的目标对象，如果为空则创建该类型的对象的新实例</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；转换映射的数据列名称 <paramref name="columns" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static T[] ToObjectArray<T>(DataTable table, string[] columns, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columns, "columns");
		return (from r in Rows(table)
			select ToObject(r, columns, onlyMapping, ignoreCase, obj)).ToArray();
	}

	/// <summary>
	/// 将当前数据表转换为对象数组，每个数据行转换为一个对象
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="type">转换的目标类型</param>
	/// <param name="columns">转换映射的数据列名称</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空；转换映射的数据列名称 <paramref name="columns" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static object[] ToObjectArray(DataTable table, Type type, string[] columns, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(columns, "columns");
		return (from r in Rows(table)
			select ToObject(r, type, columns, flags, onlyMapping, ignoreCase)).ToArray();
	}

	/// <summary>
	/// 将当前数据表转换为对象数组，每个数据行转换为一个对象
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="columns">转换映射的数据列名称</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <param name="obj">转换的目标对象，如果为空则创建该类型的对象的新实例</param> 
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；转换映射的数据列名称 <paramref name="columns" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static T[] ToObjectArray<T>(DataTable table, string[] columns, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(columns, "columns");
		return (from r in Rows(table)
			select ToObject(r, columns, flags, onlyMapping, ignoreCase, obj)).ToArray();
	}

	/// <summary>
	/// 将当前数据表转换为对象数组，每个数据行转换为一个对象；每个数据列映射到对象上相应的公共实例属性
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="type">转换的目标类型</param>
	/// <param name="mappings">数据列到对象属性的映射，未设置数据列名称则忽略</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空；映射规则数组 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static object[] ToObjectArray(DataTable table, Type type, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false)
	{
		return ToObjectArray(table, type, mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase);
	}

	/// <summary>
	/// 将当前数据表转换为对象数组，每个数据行转换为一个对象；每个数据列映射到对象上相应的公共实例属性
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="mappings">数据列到对象属性的映射，未设置数据列名称则忽略</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <param name="obj">转换的目标对象，如果为空则创建该类型的对象的新实例</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；映射规则数组 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static T[] ToObjectArray<T>(DataTable table, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		return ToObjectArray(table, mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase, obj);
	}

	/// <summary>
	/// 将当前数据表转换为对象数组，每个数据行转换为一个对象
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="type">转换的目标类型</param>
	/// <param name="mappings">数据列到对象属性的映射，未设置数据列名称则忽略</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空；映射规则数组 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static object[] ToObjectArray(DataTable table, Type type, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(mappings, "mappings");
		return (from r in Rows(table)
			select ToObject(r, type, mappings, flags, onlyMapping, ignoreCase)).ToArray();
	}

	/// <summary>
	/// 将当前数据表转换为对象数组，每个数据行转换为一个对象
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="mappings">数据列到对象属性的映射，未设置数据列名称则忽略</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <param name="obj">转换的目标对象，如果为空则创建该类型的对象的新实例</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；映射规则数组 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中定义的数据列名称或者属性名称不存在。</exception>
	public static T[] ToObjectArray<T>(DataTable table, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		Guard.AssertNotNull(table, "table");
		Guard.AssertNotNull(mappings, "mappings");
		return (from r in Rows(table)
			select ToObject(r, mappings, flags, onlyMapping, ignoreCase, obj)).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中未修改的数据行的序列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>未修改的数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<DataRow> UnchangedRows(DataTable table)
	{
		Guard.AssertNotNull(table, "table");
		return from r in Rows(table)
			where r.RowState.HasFlag(DataRowState.Unchanged)
			select r;
	}

	/// <summary>
	/// 获取当前数据表中未修改的数据行的序列
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>未修改的数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<R> UnchangedRows<R>(DataTable table) where R : DataRow
	{
		Guard.AssertNotNull(table, "table");
		return from r in Rows<R>(table)
			where r.RowState.HasFlag(DataRowState.Unchanged)
			select r;
	}

	/// <summary>
	/// 将数据行视图序列转换为数据行数组
	/// </summary>
	/// <param name="drvs">数据行视图数组</param>
	/// <returns>数据行数组</returns>
	/// <exception cref="T:System.ArgumentNullException">数据行视图序列为空。</exception>
	public static DataRow[] ToDataRows(IEnumerable<DataRowView> drvs)
	{
		return ToDataRows<DataRow>(drvs);
	}

	/// <summary>
	/// 将数据行视图序列转换为数据行数组
	/// </summary>
	/// <typeparam name="R">强类型数据行类型</typeparam>
	/// <param name="drvs">数据行视图数组</param>
	/// <returns>数据行数组</returns>
	/// <exception cref="T:System.ArgumentNullException">数据行视图序列为空。</exception>
	public static R[] ToDataRows<R>(IEnumerable<DataRowView> drvs) where R : DataRow
	{
		Guard.AssertNotNull(drvs, "drvs");
		return drvs.Select((DataRowView drv) => ObjectHelper.As<R>(drv.Row)).ToArray();
	}

	/// <summary>
	/// 将数据行视图序列转换为新的数据表
	/// </summary>
	/// <param name="drvs">数据行视图数组</param>
	/// <returns>视图新的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">数据行视图序列为空。</exception>
	public static DataTable ToDataTable(IEnumerable<DataRowView> drvs)
	{
		Guard.AssertNotNull(drvs, "drvs");
		DataTable table = null;
		foreach (DataRowView drv in drvs)
		{
			if (ObjectHelper.IsNull(table))
			{
				table = drv.Row.Table.Clone();
			}
			table.Rows.Add(drv.Row.ItemArray);
		}
		return table;
	}

	/// <summary>
	/// 将数据行视图序列转换为指定类型的强类型数据表
	/// </summary>
	/// <typeparam name="T">强类型数据表类型</typeparam>
	/// <param name="drvs">数据行视图数组</param>
	/// <returns>强类型数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">数据行视图序列为空。</exception>
	public static T ToDataTable<T>(IEnumerable<DataRowView> drvs) where T : DataTable, new()
	{
		Guard.AssertNotNull(drvs, "drvs");
		T table = new T();
		foreach (DataRowView drv in drvs)
		{
			table.Rows.Add(drv.Row.ItemArray);
		}
		return table;
	}
}
