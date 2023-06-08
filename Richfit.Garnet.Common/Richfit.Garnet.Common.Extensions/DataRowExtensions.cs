using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Data.DataRow" /> 类型扩展方法类
///
/// 包括：
/// 1. DataRow类型的扩展方法
/// 2. 以DataRow类型为约束的泛型的扩展方法
/// 3. DataRow类型数组或者泛型数组的扩展方法
/// 4. 以DataRow类型为约束的泛型或者泛型数组的扩展方法
/// </summary>
public static class DataRowExtensions
{
	/// <summary>
	/// 复制当前数据行，制作数据行中存储的列值的浅表副本
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <returns>当前数据行的副本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	public static DataRow Copy(this DataRow row)
	{
		row.GuardNotNull("row");
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
	public static R Copy<R>(this R row) where R : DataRow
	{
		row.GuardNotNull("row");
		return (R)((DataRow)row).Copy();
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Boolean" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static bool GetBoolean(this DataRow row, DataColumn column, bool defaultValue = false)
	{
		return row.GetValue(column, defaultValue);
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
	public static bool GetBoolean(this DataRow row, DataColumn column, DataRowVersion version, bool defaultValue = false)
	{
		return row.GetValue(column, version, defaultValue);
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
	public static bool GetBoolean(this DataRow row, int columnIndex, bool defaultValue = false)
	{
		return row.GetValue(columnIndex, defaultValue);
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
	public static bool GetBoolean(this DataRow row, int columnIndex, DataRowVersion version, bool defaultValue = false)
	{
		return row.GetValue(columnIndex, version, defaultValue);
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
	public static bool GetBoolean(this DataRow row, string columnName, bool defaultValue = false)
	{
		return row.GetValue(columnName, defaultValue);
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
	public static bool GetBoolean(this DataRow row, string columnName, DataRowVersion version, bool defaultValue = false)
	{
		return row.GetValue(columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Byte" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列名称</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static int GetByte(this DataRow row, DataColumn column, byte defaultValue = 0)
	{
		return row.GetValue(column, defaultValue);
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
	public static int GetByte(this DataRow row, DataColumn column, DataRowVersion version, byte defaultValue = 0)
	{
		return row.GetValue(column, version, defaultValue);
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
	public static int GetByte(this DataRow row, int columnIndex, byte defaultValue = 0)
	{
		return row.GetValue(columnIndex, defaultValue);
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
	public static int GetByte(this DataRow row, int columnIndex, DataRowVersion version, byte defaultValue = 0)
	{
		return row.GetValue(columnIndex, version, defaultValue);
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
	public static int GetByte(this DataRow row, string columnName, byte defaultValue = 0)
	{
		return row.GetValue(columnName, defaultValue);
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
	public static int GetByte(this DataRow row, string columnName, DataRowVersion version, byte defaultValue = 0)
	{
		return row.GetValue(columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Byte" /> 类型的数组
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static byte[] GetBytes(this DataRow row, DataColumn column, byte[] defaultValue = null)
	{
		return row.GetValue(column, defaultValue);
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
	public static byte[] GetBytes(this DataRow row, DataColumn column, DataRowVersion version, byte[] defaultValue = null)
	{
		return row.GetValue(column, version, defaultValue);
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
	public static byte[] GetBytes(this DataRow row, int columnIndex, byte[] defaultValue = null)
	{
		return row.GetValue(columnIndex, defaultValue);
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
	public static byte[] GetBytes(this DataRow row, int columnIndex, DataRowVersion version, byte[] defaultValue = null)
	{
		return row.GetValue(columnIndex, version, defaultValue);
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
	public static byte[] GetBytes(this DataRow row, string columnName, byte[] defaultValue = null)
	{
		return row.GetValue(columnName, defaultValue);
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
	public static byte[] GetBytes(this DataRow row, string columnName, DataRowVersion version, byte[] defaultValue = null)
	{
		return row.GetValue(columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.DateTime" /> 类型数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值，默认为 <see cref="F:System.DateTime.MinValue" />。</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static DateTime GetDateTime(this DataRow row, DataColumn column, DateTime? defaultValue = null)
	{
		return row.GetValue(column, defaultValue.IfNull(DateTime.MinValue).Value);
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
	public static DateTime GetDateTime(this DataRow row, DataColumn column, DataRowVersion version, DateTime? defaultValue = null)
	{
		return row.GetValue(column, version, defaultValue.IfNull(DateTime.MinValue).Value);
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
	public static DateTime GetDateTime(this DataRow row, int columnIndex, DateTime? defaultValue = null)
	{
		return row.GetValue(columnIndex, defaultValue.IfNull(DateTime.MinValue).Value);
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
	public static DateTime GetDateTime(this DataRow row, int columnIndex, DataRowVersion version, DateTime? defaultValue = null)
	{
		return row.GetValue(columnIndex, version, defaultValue.IfNull(DateTime.MinValue).Value);
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
	public static DateTime GetDateTime(this DataRow row, string columnName, DateTime? defaultValue = null)
	{
		return row.GetValue(columnName, defaultValue.IsNull() ? DateTime.MinValue : defaultValue.Value);
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
	public static DateTime GetDateTime(this DataRow row, string columnName, DataRowVersion version, DateTime? defaultValue = null)
	{
		return row.GetValue(columnName, version, defaultValue.IfNull(DateTime.MinValue).Value);
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
	public static DateTimeOffset GetDateTimeOffset(this DataRow row, DataColumn column, DateTime? defaultValue = null, TimeSpan? defaultTimeZone = null)
	{
		return new DateTimeOffset(row.GetDateTime(column, defaultValue), defaultTimeZone.IsNull() ? TimeSpan.Zero : defaultTimeZone.Value);
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
	public static DateTimeOffset GetDateTimeOffset(this DataRow row, DataColumn column, DataRowVersion version, DateTime? defaultValue = null, TimeSpan? defaultTimeZone = null)
	{
		return new DateTimeOffset(row.GetDateTime(column, version, defaultValue), defaultTimeZone.IsNull() ? TimeSpan.Zero : defaultTimeZone.Value);
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
	public static DateTimeOffset GetDateTimeOffset(this DataRow row, int columnIndex, DateTime? defaultValue = null, TimeSpan? defaultTimeZone = null)
	{
		return new DateTimeOffset(row.GetDateTime(columnIndex, defaultValue), defaultTimeZone.IsNull() ? TimeSpan.Zero : defaultTimeZone.Value);
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
	public static DateTimeOffset GetDateTimeOffset(this DataRow row, int columnIndex, DataRowVersion version, DateTime? defaultValue = null, TimeSpan? defaultTimeZone = null)
	{
		return new DateTimeOffset(row.GetDateTime(columnIndex, version, defaultValue), defaultTimeZone.IsNull() ? TimeSpan.Zero : defaultTimeZone.Value);
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
	public static DateTimeOffset GetDateTimeOffset(this DataRow row, string columnName, DateTime? defaultValue = null, TimeSpan? defaultTimeZone = null)
	{
		return new DateTimeOffset(row.GetDateTime(columnName, defaultValue), defaultTimeZone.IsNull() ? TimeSpan.Zero : defaultTimeZone.Value);
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
	public static DateTimeOffset GetDateTimeOffset(this DataRow row, string columnName, DataRowVersion version, DateTime? defaultValue = null, TimeSpan? defaultTimeZone = null)
	{
		return new DateTimeOffset(row.GetDateTime(columnName, version, defaultValue), defaultTimeZone.IsNull() ? TimeSpan.Zero : defaultTimeZone.Value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Decimal" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static decimal GetDecimal(this DataRow row, DataColumn column, decimal defaultValue = 0m)
	{
		return row.GetValue(column, defaultValue);
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
	public static decimal GetDecimal(this DataRow row, DataColumn column, DataRowVersion version, decimal defaultValue = 0m)
	{
		return row.GetValue(column, version, defaultValue);
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
	public static decimal GetDecimal(this DataRow row, int columnIndex, decimal defaultValue = 0m)
	{
		return row.GetValue(columnIndex, defaultValue);
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
	public static decimal GetDecimal(this DataRow row, int columnIndex, DataRowVersion version, decimal defaultValue = 0m)
	{
		return row.GetValue(columnIndex, version, defaultValue);
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
	public static decimal GetDecimal(this DataRow row, string columnName, decimal defaultValue = 0m)
	{
		return row.GetValue(columnName, defaultValue);
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
	public static decimal GetDecimal(this DataRow row, string columnName, DataRowVersion version, decimal defaultValue = 0m)
	{
		return row.GetValue(columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Double" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static double GetDouble(this DataRow row, DataColumn column, double defaultValue = 0.0)
	{
		return row.GetValue(column, defaultValue);
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
	public static double GetDouble(this DataRow row, DataColumn column, DataRowVersion version, double defaultValue = 0.0)
	{
		return row.GetValue(column, version, defaultValue);
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
	public static double GetDouble(this DataRow row, int columnIndex, double defaultValue = 0.0)
	{
		return row.GetValue(columnIndex, defaultValue);
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
	public static double GetDouble(this DataRow row, int columnIndex, DataRowVersion version, double defaultValue = 0.0)
	{
		return row.GetValue(columnIndex, version, defaultValue);
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
	public static double GetDouble(this DataRow row, string columnName, double defaultValue = 0.0)
	{
		return row.GetValue(columnName, defaultValue);
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
	public static double GetDouble(this DataRow row, string columnName, DataRowVersion version, double defaultValue = 0.0)
	{
		return row.GetValue(columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Guid" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static Guid GetGuid(this DataRow row, DataColumn column, Guid? defaultValue = null)
	{
		return row.GetGuid(column, DataRowVersion.Default, defaultValue);
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
	public static Guid GetGuid(this DataRow row, DataColumn column, DataRowVersion version, Guid? defaultValue = null)
	{
		Guid? value = row.GetValue(column, version, ConvertToGuid);
		defaultValue = defaultValue.IfNull(Guid.Empty);
		return value.IsNull() ? defaultValue.Value : value.Value;
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
	public static Guid GetGuid(this DataRow row, int columnIndex, Guid? defaultValue = null)
	{
		return row.GetGuid(columnIndex, DataRowVersion.Default, defaultValue);
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
	public static Guid GetGuid(this DataRow row, int columnIndex, DataRowVersion version, Guid? defaultValue = null)
	{
		Guid? value = row.GetValue(columnIndex, version, ConvertToGuid);
		defaultValue = defaultValue.IfNull(Guid.Empty);
		return value.IsNull() ? defaultValue.Value : value.Value;
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
	public static Guid GetGuid(this DataRow row, string columnName, Guid? defaultValue = null)
	{
		return row.GetGuid(columnName, DataRowVersion.Default, defaultValue);
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
	public static Guid GetGuid(this DataRow row, string columnName, DataRowVersion version, Guid? defaultValue = null)
	{
		Guid? value = row.GetValue(columnName, ConvertToGuid);
		defaultValue = defaultValue.IfNull(Guid.Empty);
		return value.IsNull() ? defaultValue.Value : value.Value;
	}

	private static Guid? ConvertToGuid(object value)
	{
		if (value.IsNullOrDBNull())
		{
			return null;
		}
		if (value is byte[])
		{
			byte[] bs = value.As<byte[]>();
			if (bs.Length == 16)
			{
				return new Guid(bs);
			}
		}
		else if (value is string)
		{
			string s = value.As<string>();
			if (Guid.TryParse(s, out var guid))
			{
				return guid;
			}
		}
		else if (value is Guid)
		{
			return (Guid)value;
		}
		throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(Guid).FullName));
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int16" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static short GetInt16(this DataRow row, DataColumn column, short defaultValue = 0)
	{
		return row.GetValue(column, defaultValue);
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
	public static short GetInt16(this DataRow row, DataColumn column, DataRowVersion version, short defaultValue = 0)
	{
		return row.GetValue(column, version, defaultValue);
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
	public static short GetInt16(this DataRow row, int columnIndex, short defaultValue = 0)
	{
		return row.GetValue(columnIndex, defaultValue);
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
	public static short GetInt16(this DataRow row, int columnIndex, DataRowVersion version, short defaultValue = 0)
	{
		return row.GetValue(columnIndex, version, defaultValue);
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
	public static short GetInt16(this DataRow row, string columnName, short defaultValue = 0)
	{
		return row.GetValue(columnName, defaultValue);
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
	public static short GetInt16(this DataRow row, string columnName, DataRowVersion version, short defaultValue = 0)
	{
		return row.GetValue(columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int32" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static int GetInt32(this DataRow row, DataColumn column, int defaultValue = 0)
	{
		return row.GetValue(column, defaultValue);
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
	public static int GetInt32(this DataRow row, DataColumn column, DataRowVersion version, int defaultValue = 0)
	{
		return row.GetValue(column, version, defaultValue);
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
	public static int GetInt32(this DataRow row, int columnIndex, int defaultValue = 0)
	{
		return row.GetValue(columnIndex, defaultValue);
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
	public static int GetInt32(this DataRow row, int columnIndex, DataRowVersion version, int defaultValue = 0)
	{
		return row.GetValue(columnIndex, version, defaultValue);
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
	public static int GetInt32(this DataRow row, string columnName, int defaultValue = 0)
	{
		return row.GetValue(columnName, defaultValue);
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
	public static int GetInt32(this DataRow row, string columnName, DataRowVersion version, int defaultValue = 0)
	{
		return row.GetValue(columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Int64" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static long GetInt64(this DataRow row, DataColumn column, long defaultValue = 0L)
	{
		return row.GetValue(column, defaultValue);
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
	public static long GetInt64(this DataRow row, DataColumn column, DataRowVersion version, long defaultValue = 0L)
	{
		return row.GetValue(column, version, defaultValue);
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
	public static long GetInt64(this DataRow row, int columnIndex, long defaultValue = 0L)
	{
		return row.GetValue(columnIndex, defaultValue);
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
	public static long GetInt64(this DataRow row, int columnIndex, DataRowVersion version, long defaultValue = 0L)
	{
		return row.GetValue(columnIndex, version, defaultValue);
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
	public static long GetInt64(this DataRow row, string columnName, long defaultValue = 0L)
	{
		return row.GetValue(columnName, defaultValue);
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
	public static long GetInt64(this DataRow row, string columnName, DataRowVersion version, long defaultValue = 0L)
	{
		return row.GetValue(columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.SByte" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static sbyte GetSByte(this DataRow row, DataColumn column, sbyte defaultValue = 0)
	{
		return row.GetValue(column, defaultValue);
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
	public static sbyte GetSByte(this DataRow row, DataColumn column, DataRowVersion version, sbyte defaultValue = 0)
	{
		return row.GetValue(column, version, defaultValue);
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
	public static sbyte GetSByte(this DataRow row, int columnIndex, sbyte defaultValue = 0)
	{
		return row.GetValue(columnIndex, defaultValue);
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
	public static sbyte GetSByte(this DataRow row, int columnIndex, DataRowVersion version, sbyte defaultValue = 0)
	{
		return row.GetValue(columnIndex, version, defaultValue);
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
	public static sbyte GetSByte(this DataRow row, string columnName, sbyte defaultValue = 0)
	{
		return row.GetValue(columnName, defaultValue);
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
	public static sbyte GetSByte(this DataRow row, string columnName, DataRowVersion version, sbyte defaultValue = 0)
	{
		return row.GetValue(columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Single" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static float GetSingle(this DataRow row, DataColumn column, float defaultValue = 0f)
	{
		return row.GetValue(column, defaultValue);
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
	public static float GetSingle(this DataRow row, DataColumn column, DataRowVersion version, float defaultValue = 0f)
	{
		return row.GetValue(column, version, defaultValue);
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
	public static float GetSingle(this DataRow row, int columnIndex, float defaultValue = 0f)
	{
		return row.GetValue(columnIndex, defaultValue);
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
	public static float GetSingle(this DataRow row, int columnIndex, DataRowVersion version, float defaultValue = 0f)
	{
		return row.GetValue(columnIndex, version, defaultValue);
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
	public static float GetSingle(this DataRow row, string columnName, float defaultValue = 0f)
	{
		return row.GetValue(columnName, defaultValue);
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
	public static float GetSingle(this DataRow row, string columnName, DataRowVersion version, float defaultValue = 0f)
	{
		return row.GetValue(columnName, version, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.String" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的列</param>
	/// <param name="defaultValue">数据列的默认值</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static string GetString(this DataRow row, DataColumn column, string defaultValue = "")
	{
		return row.GetString(column, DataRowVersion.Default, defaultValue);
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
	public static string GetString(this DataRow row, DataColumn column, DataRowVersion version, string defaultValue = "")
	{
		object value = row.GetValue(column, version);
		return value.IsNullOrDBNull() ? defaultValue : value.ToString();
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
	public static string GetString(this DataRow row, DataColumn column, string format, string defaultValue = "")
	{
		return row.GetString(column, DataRowVersion.Default, format, defaultValue);
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
	public static string GetString(this DataRow row, DataColumn column, DataRowVersion version, string format, string defaultValue = "")
	{
		object value = row.GetValue(column, version);
		return value.IsNullOrDBNull() ? defaultValue : format.IfNull("{0}").FormatValue(value);
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
	public static string GetString(this DataRow row, int columnIndex, string defaultValue = "")
	{
		return row.GetString(columnIndex, DataRowVersion.Default, defaultValue);
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
	public static string GetString(this DataRow row, int columnIndex, DataRowVersion version, string defaultValue = "")
	{
		object value = row.GetValue(columnIndex, version);
		return value.IsNullOrDBNull() ? defaultValue : value.ToString();
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
	public static string GetString(this DataRow row, int columnIndex, string format, string defaultValue = "")
	{
		return row.GetString(columnIndex, DataRowVersion.Default, format, defaultValue);
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
	public static string GetString(this DataRow row, int columnIndex, DataRowVersion version, string format, string defaultValue = "")
	{
		object value = row.GetValue(columnIndex, version);
		return value.IsNullOrDBNull() ? defaultValue : format.IfNull("{0}").FormatValue(value);
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
	public static string GetString(this DataRow row, string columnName, string defaultValue = "")
	{
		return row.GetString(columnName, DataRowVersion.Default, defaultValue);
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
	public static string GetString(this DataRow row, string columnName, DataRowVersion version, string defaultValue = "")
	{
		object value = row.GetValue(columnName, version);
		return value.IsNullOrDBNull() ? defaultValue : value.ToString();
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
	public static string GetString(this DataRow row, string columnName, string format, string defaultValue = "")
	{
		return row.GetString(columnName, DataRowVersion.Default, format, defaultValue);
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
	public static string GetString(this DataRow row, string columnName, DataRowVersion version, string format, string defaultValue = "")
	{
		object value = row.GetValue(columnName, version);
		return value.IsNullOrDBNull() ? defaultValue : format.IfNull("{0}").FormatValue(value);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值，并转换为 <see cref="T:System.Type" /> 类型的数值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="defaultValue">列值的默认值</param>
	/// <returns>当前数据行指定的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static Type GetType(this DataRow row, DataColumn column, Type defaultValue = null)
	{
		return row.GetType(column, DataRowVersion.Default, defaultValue);
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
	public static Type GetType(this DataRow row, DataColumn column, DataRowVersion version, Type defaultValue = null)
	{
		Type type = row.GetValue(column, version, ConvertToType);
		return type.IsNull() ? defaultValue : type;
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
	public static Type GetType(this DataRow row, int columnIndex, Type defaultValue = null)
	{
		return row.GetType(columnIndex, DataRowVersion.Default, defaultValue);
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
	public static Type GetType(this DataRow row, int columnIndex, DataRowVersion version, Type defaultValue = null)
	{
		Type type = row.GetValue(columnIndex, version, ConvertToType);
		return type.IsNull() ? defaultValue : type;
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
	public static Type GetType(this DataRow row, string columnName, Type defaultValue = null)
	{
		return row.GetType(columnName, DataRowVersion.Default, defaultValue);
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
	public static Type GetType(this DataRow row, string columnName, DataRowVersion version, Type defaultValue = null)
	{
		Type type = row.GetValue(columnName, version, ConvertToType);
		return type.IsNull() ? defaultValue : type;
	}

	private static Type ConvertToType(object value)
	{
		if (value.IsNullOrDBNull())
		{
			return null;
		}
		if (value is string)
		{
			return value.As<string>().ResolveType();
		}
		if (value is Type)
		{
			return (Type)value;
		}
		throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(Guid).FullName));
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <returns>当前数据行中指定数据列的值。如果指定的列的值为空，则返回 <see cref="T:System.DBNull" />。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static object GetValue(this DataRow row, DataColumn column)
	{
		return row.GetValue(column, DataRowVersion.Default);
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
	public static T GetValue<T>(this DataRow row, DataColumn column, T defaultValue = default(T))
	{
		return row.GetValue(column, DataRowVersion.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">数据列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="evaluator">获取的列值的处理方法</param>
	/// <returns>当前数据行指定列的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	public static T GetValue<T>(this DataRow row, DataColumn column, Func<object, T> evaluator)
	{
		return row.GetValue(column, DataRowVersion.Default, evaluator);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="version">要获取的数据值的版本</param>
	/// <returns>当前数据行中指定数据列的值。如果指定的列的值为空，则返回 <see cref="T:System.DBNull" />。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空。</exception>
	public static object GetValue(this DataRow row, DataColumn column, DataRowVersion version)
	{
		row.GuardNotNull("row");
		column.GuardNotNull("column");
		return row[column, version].EnsureDBNull();
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
	public static T GetValue<T>(this DataRow row, DataColumn column, DataRowVersion version, T defaultValue = default(T))
	{
		return row.GetValue(column, version).IfNullOrDBNull(defaultValue).As<T>();
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">数据列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="version">要获取的数据值的版本</param>
	/// <param name="evaluator">获取的列值的处理方法</param>
	/// <returns>当前数据行指定列的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="column" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	public static T GetValue<T>(this DataRow row, DataColumn column, DataRowVersion version, Func<object, T> evaluator)
	{
		evaluator.GuardNotNull("evaluator");
		return evaluator(row.GetValue(column, version));
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <returns>当前数据行指定列的值；如果指定的列的值为空，则返回 <see cref="T:System.DBNull" />。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static object GetValue(this DataRow row, int columnIndex)
	{
		return row.GetValue(columnIndex, DataRowVersion.Default);
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
	public static T GetValue<T>(this DataRow row, int columnIndex, T defaultValue = default(T))
	{
		return row.GetValue(columnIndex, DataRowVersion.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">获取的列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="evaluator">获取的列值的处理方法。</param>
	/// <returns>当前数据行指定列的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static T GetValue<T>(this DataRow row, int columnIndex, Func<object, T> evaluator)
	{
		return row.GetValue(columnIndex, DataRowVersion.Default, evaluator);
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
	public static object GetValue(this DataRow row, int columnIndex, DataRowVersion version)
	{
		row.GuardNotNull("row");
		columnIndex.GuardIndexRange(0, row.Table.Columns.Count - 1, "column index");
		return row[columnIndex, version].EnsureDBNull();
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
	public static T GetValue<T>(this DataRow row, int columnIndex, DataRowVersion version, T defaultValue = default(T))
	{
		return row.GetValue(columnIndex, version).IfNullOrDBNull(defaultValue).As<T>();
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">获取的列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="columnIndex">获取值的列的索引</param>
	/// <param name="version">要获取的数据值的版本</param>
	/// <param name="evaluator">获取的列值的处理方法。</param>
	/// <returns>当前数据行指定列的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据行列索引范围。</exception>
	public static T GetValue<T>(this DataRow row, int columnIndex, DataRowVersion version, Func<object, T> evaluator)
	{
		evaluator.GuardNotNull("evaluator");
		return evaluator(row.GetValue(columnIndex, version));
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">指定数据列的名称</param>
	/// <returns>当前数据行指定列的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static object GetValue(this DataRow row, string columnName)
	{
		return row.GetValue(columnName, DataRowVersion.Default);
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
	public static T GetValue<T>(this DataRow row, string columnName, T defaultValue = default(T))
	{
		return row.GetValue(columnName, DataRowVersion.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">获取的列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">指定数据列的名称</param>
	/// <param name="evaluator">获取的列值的处理方法</param>
	/// <returns>当前数据行指定列的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static T GetValue<T>(this DataRow row, string columnName, Func<object, T> evaluator)
	{
		return row.GetValue(columnName, DataRowVersion.Default, evaluator);
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
	public static object GetValue(this DataRow row, string columnName, DataRowVersion version)
	{
		row.GuardNotNull("row");
		columnName.GuardNotNull("Column Name");
		DataColumn column = row.Table.Columns[columnName];
		column.Guard(column.IsNotNull(), () => new ArgumentException(Literals.MSG_DataColumnNotFound_1.FormatValue(columnName), "Column Name"));
		return row[column, version].EnsureDBNull();
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
	public static T GetValue<T>(this DataRow row, string columnName, DataRowVersion version, T defaultValue = default(T))
	{
		return row.GetValue(columnName, version).IfNullOrDBNull(defaultValue).As<T>();
	}

	/// <summary>
	/// 获取当前数据行中指定列的值
	/// </summary>
	/// <typeparam name="T">获取的列值的类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="columnName">指定数据列的名称</param>
	/// <param name="version">要获取的数据值的版本</param>
	/// <param name="evaluator">获取的列值的处理方法</param>
	/// <returns>当前数据行指定列的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者 <paramref name="columnName" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="columnName" /> 指定的数据列在数据表中不存在。</exception>
	public static T GetValue<T>(this DataRow row, string columnName, DataRowVersion version, Func<object, T> evaluator)
	{
		evaluator.GuardNotNull("evaluator");
		return evaluator(row.GetValue(columnName, version));
	}

	/// <summary>
	/// 检测当前数据行的指定的数据列的值是否是 <see cref="T:System.DBNull" />。
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="column">获取值的数据列</param>
	/// <param name="version">要获取的值的行版本</param>
	/// <returns>如果指定的数据列的值为空或者 <see cref="T:System.DBNull" /> 则返回true，否则返回false。</returns>
	public static bool IsDBNull(this DataRow row, DataColumn column, DataRowVersion version = DataRowVersion.Default)
	{
		return row.GetValue(column, version).IsDBNull();
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
	public static bool IsDBNull(this DataRow row, int columnIndex, DataRowVersion version = DataRowVersion.Default)
	{
		return row.GetValue(columnIndex, version).IsDBNull();
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
	public static bool IsDBNull(this DataRow row, string columnName, DataRowVersion version = DataRowVersion.Default)
	{
		return row.GetValue(columnName, version).IsDBNull();
	}

	/// <summary>
	/// 向当前数据行中加载指定对象的属性值，如果对象的属性没有对应的数据列则忽略；将数据对象的公共实例属相加载到当前数据行
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="data">加载的数据对象</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者加载的数据对象 <paramref name="data" /> 为空。</exception>
	public static void LoadObject(this DataRow row, object data)
	{
		row.LoadObject(data, BindingFlags.Instance | BindingFlags.Public);
	}

	/// <summary>
	/// 向当前数据行中加载指定对象的属性值，如果对象的属性没有对应的数据列则忽略
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="data">加载的数据对象</param>
	/// <param name="flags">属性绑定标志</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者加载的数据对象 <paramref name="data" /> 为空。</exception>
	public static void LoadObject(this DataRow row, object data, BindingFlags flags)
	{
		row.LoadObject(data, new DataMapping[0], flags);
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
	public static void LoadObject(this DataRow row, object data, string[] propertyNames, bool onlyMapping = false, bool ignoreCase = false)
	{
		row.LoadObject(data, propertyNames, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase);
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
	public static void LoadObject(this DataRow row, object data, string[] propertyNames, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		propertyNames.GuardNotNull("property names");
		DataMapping[] mappings = (from n in propertyNames.Where((string n) => n.IsNotNull()).Distinct()
			select new DataMapping(null, n)).ToArray();
		row.LoadObject(data, mappings, flags, onlyMapping, ignoreCase);
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
	public static void LoadObject(this DataRow row, object data, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false)
	{
		row.LoadObject(data, mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase);
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
	public static void LoadObject(this DataRow row, object data, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		row.GuardNotNull("row");
		data.GuardNotNull("data");
		mappings.GuardNotNull("mappings");
		Dictionary<string, DataColumn> columns = new Dictionary<string, DataColumn>(ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
		columns.TryAddRange(row.Table.Columns(), (DataColumn c) => c.ColumnName);
		object owner;
		if (onlyMapping)
		{
			foreach (DataMapping mapping in mappings.Where((DataMapping m) => m.IsNotNull() && m.PropertyName.IsNotNullAndEmpty()))
			{
				PropertyInfo pinfo = data.GetProperty(mapping.PropertyName, flags, out owner, ignoreCase);
				if (pinfo.IsNull())
				{
					throw new ArgumentException(Literals.MSG_MissingProperty_1.FormatValue(mapping.PropertyName), "mappings");
				}
				string columnName = mapping.ColumnName.IfNullOrEmpty(pinfo.Name);
				if (!columns.ContainsKey(columnName))
				{
					throw new ArgumentException(Literals.MSG_DataColumnNotFound_1.FormatValue(columnName), "mappings");
				}
				DataColumn column = columns[columnName];
				row[column] = pinfo.GetValue(owner, null).ConvertTo(column.DataType);
			}
			return;
		}
		Dictionary<string, DataMapping> properties = new Dictionary<string, DataMapping>(ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
		properties.TryAddRange(mappings.Where((DataMapping m) => m.IsNotNull() && m.PropertyName.IsNotNullAndEmpty()), (DataMapping m) => m.PropertyName);
		PropertyInfo[] properties2 = data.GetType().GetProperties(flags);
		foreach (PropertyInfo pinfo in properties2)
		{
			if (properties.ContainsKey(pinfo.Name))
			{
				string columnName = properties[pinfo.Name].ColumnName.IfNullOrEmpty(pinfo.Name);
				if (!columns.ContainsKey(columnName))
				{
					throw new ArgumentException(Literals.MSG_DataColumnNotFound_1.FormatValue(columnName), "mappings");
				}
				DataColumn column = columns[columnName];
				row[column] = pinfo.GetValue(data, null).ConvertTo(column.DataType);
				properties.Remove(pinfo.Name);
			}
			else
			{
				string columnName = pinfo.Name;
				if (columns.ContainsKey(columnName))
				{
					DataColumn column = columns[columnName];
					row[column] = pinfo.GetValue(data, null).ConvertTo(column.DataType);
				}
			}
		}
		foreach (DataMapping mapping in properties.Values)
		{
			PropertyInfo extraPinfo = data.GetProperty(mapping.PropertyName, out owner, ignoreCase);
			if (extraPinfo.IsNull())
			{
				throw new ArgumentException(Literals.MSG_MissingProperty_1.FormatValue(mapping.PropertyName), "mappings");
			}
			string columnName = mapping.ColumnName.IfNullOrEmpty(extraPinfo.Name);
			if (!columns.ContainsKey(columnName))
			{
				throw new ArgumentException(Literals.MSG_DataColumnNotFound_1.FormatValue(columnName), "mappings");
			}
			DataColumn column = columns[columnName];
			row[column] = extraPinfo.GetValue(owner, null).ConvertTo(column.DataType);
		}
	}

	/// <summary>
	/// 将当前数据行转换为目标类型的对象；将数据行的列映射到目标类型的公共属性
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="type">转换的目标类型</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空。</exception>
	public static object ToObject(this DataRow row, Type type)
	{
		type.GuardNotNull("type");
		return row.ToObject(type.CreateInstance());
	}

	/// <summary>
	/// 将当前数据行转换为目标类型的对象；将数据行的列映射到目标类型的公共属性
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="row">当前数据行</param>
	/// <param name="obj">转换的目标对象，如果为空则创建该类型的对象的新实例</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	public static T ToObject<T>(this DataRow row, T obj = default(T))
	{
		return row.ToObject(BindingFlags.Instance | BindingFlags.Public, obj);
	}

	/// <summary>
	/// 将当前数据行转换为目标类型的对象
	/// </summary>
	/// <param name="row">当前数据行</param>
	/// <param name="type">转换的目标类型</param>
	/// <param name="flags">属性绑定标志</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空。</exception>
	public static object ToObject(this DataRow row, Type type, BindingFlags flags)
	{
		type.GuardNotNull("type");
		return row.ToObject(flags, type.CreateInstance());
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
	public static T ToObject<T>(this DataRow row, BindingFlags flags, T obj = default(T))
	{
		return row.ToObject(new DataMapping[0], flags, onlyMapping: false, ignoreCase: false, obj);
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
	public static object ToObject(this DataRow row, Type type, string[] columnNames, bool onlyMapping = false, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		return row.ToObject(columnNames, onlyMapping, ignoreCase, type.CreateInstance());
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
	public static T ToObject<T>(this DataRow row, string[] columnNames, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		return row.ToObject(columnNames, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase, obj);
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
	public static object ToObject(this DataRow row, Type type, string[] columnNames, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		return row.ToObject(columnNames, flags, onlyMapping, ignoreCase, type.CreateInstance());
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
	public static T ToObject<T>(this DataRow row, string[] columnNames, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		columnNames.GuardNotNull("column names");
		DataMapping[] mappings = (from n in columnNames.Where((string n) => n.IsNotNull()).Distinct()
			select new DataMapping(n, null)).ToArray();
		return row.ToObject(mappings, flags, onlyMapping, ignoreCase, obj);
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
	public static object ToObject(this DataRow row, Type type, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false)
	{
		return row.ToObject(type, mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase);
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
	public static T ToObject<T>(this DataRow row, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		return row.ToObject(mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase, obj);
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
	public static object ToObject(this DataRow row, Type type, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		return row.ToObject(mappings, flags, onlyMapping, ignoreCase, type.CreateInstance());
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
	public static T ToObject<T>(this DataRow row, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		row.GuardNotNull("row");
		mappings.GuardNotNull("mappings");
		obj = obj.IfNull(typeof(T).CreateInstance<T>());
		object owner;
		if (onlyMapping)
		{
			Dictionary<string, DataColumn> columns2 = new Dictionary<string, DataColumn>(ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
			columns2.TryAddRange(row.Table.Columns(), (DataColumn c) => c.ColumnName);
			foreach (DataMapping mapping in mappings.Where((DataMapping m) => m.IsNotNull() && m.ColumnName.IsNotNullAndEmpty()))
			{
				if (!columns2.ContainsKey(mapping.ColumnName))
				{
					throw new ArgumentException(Literals.MSG_DataColumnNotFound_1.FormatValue(mapping.ColumnName), "mappings");
				}
				string propertyName = mapping.PropertyName.IfNullOrEmpty(mapping.ColumnName);
				PropertyInfo pinfo = obj.GetProperty(propertyName, flags, out owner, ignoreCase);
				if (pinfo.IsNull())
				{
					throw new ArgumentException(Literals.MSG_MissingProperty_1.FormatValue(propertyName), "mappings");
				}
				pinfo.SetValue(owner, row[columns2[mapping.ColumnName]].ConvertTo(pinfo.PropertyType), null);
			}
		}
		else
		{
			Dictionary<string, DataMapping> columns = new Dictionary<string, DataMapping>(ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
			columns.TryAddRange(mappings.Where((DataMapping m) => m.IsNotNull() && m.ColumnName.IsNotNullAndEmpty()), (DataMapping m) => m.ColumnName);
			foreach (DataColumn column in row.Table.Columns)
			{
				if (columns.ContainsKey(column.ColumnName))
				{
					string propertyName = columns[column.ColumnName].PropertyName.IfNullOrEmpty(column.ColumnName);
					PropertyInfo pinfo = obj.GetProperty(propertyName, flags, out owner, ignoreCase);
					if (pinfo.IsNull())
					{
						throw new ArgumentException(Literals.MSG_MissingProperty_1.FormatValue(propertyName), "mappings");
					}
					pinfo.SetValue(owner, row[column].ConvertTo(pinfo.PropertyType), null);
					columns.Remove(column.ColumnName);
				}
				else
				{
					string propertyName = column.ColumnName;
					PropertyInfo pinfo = obj.GetProperty(propertyName, flags, out owner, ignoreCase);
					if (pinfo.IsNotNull())
					{
						pinfo.SetValue(owner, row[column].ConvertTo(pinfo.PropertyType), null);
					}
				}
			}
			if (columns.Count > 0)
			{
				using Dictionary<string, DataMapping>.Enumerator enumerator3 = columns.GetEnumerator();
				if (enumerator3.MoveNext())
				{
					KeyValuePair<string, DataMapping> kvp = enumerator3.Current;
					throw new ArgumentException(Literals.MSG_DataColumnNotFound_1.FormatValue(kvp.Key), "mappings");
				}
			}
		}
		return obj;
	}
}
