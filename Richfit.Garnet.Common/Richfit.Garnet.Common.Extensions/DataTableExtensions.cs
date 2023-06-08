using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Data.DataTable" /> 类型扩展方法类
///
/// 包括：
/// 1. DataTable类型的扩展方法
/// 2. 以DataTable类型为约束的泛型的扩展方法
/// 3. DataTable类型数组或者泛型数组的扩展方法
/// 4. 以DataTable类型为约束的泛型或者泛型数组的扩展方法
/// </summary>
public static class DataTableExtensions
{
	/// <summary>
	/// 向当前数据表中添加数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="column">添加的数据列</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="column" /> 为空。</exception>
	public static void AddColumn(this DataTable table, DataColumn column)
	{
		table.GuardNotNull("table");
		column.GuardNotNull("column");
		table.Columns.Add(column);
	}

	/// <summary>
	/// 向当前数据表中添加数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <returns>添加后的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static DataColumn AddColumn(this DataTable table, string columnName)
	{
		table.GuardNotNull("table");
		columnName.GuardNotNull("column name");
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
	public static DataColumn AddColumn(this DataTable table, string columnName, Type columnType)
	{
		table.GuardNotNull("table");
		columnName.GuardNotNull("column name");
		columnType.GuardNotNull("column type");
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
	public static DataColumn AddColumn(this DataTable table, string columnName, Type columnType, string columnExpress)
	{
		table.GuardNotNull("table");
		columnName.GuardNotNull("column name");
		columnType.GuardNotNull("column type");
		return table.Columns.Add(columnName, columnType, columnExpress);
	}

	/// <summary>
	/// 向当前数据表中添加多个数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columns">添加的数据列列表</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columns" /> 为空。</exception>
	public static void AddColumns(this DataTable table, params DataColumn[] columns)
	{
		table.GuardNotNull("table");
		columns.GuardNotNull("columns");
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
	public static void AddColumns(this DataTable table, IEnumerable<DataColumn> columns)
	{
		table.GuardNotNull("table");
		columns.GuardNotNull("columns");
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
	public static DataColumn[] AddColumns(this DataTable table, params string[] columnNames)
	{
		table.GuardNotNull("table");
		columnNames.GuardNotNull("column names");
		return columnNames.Select((string x) => table.Columns.Add(x)).ToArray();
	}

	/// <summary>
	/// 向当前数据表中添加多个数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnNames">添加的数据列列名称序列</param>
	/// <return>添加的数据列数组</return>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnNames" /> 为空。</exception>
	public static DataColumn[] AddColumns(this DataTable table, IEnumerable<string> columnNames)
	{
		table.GuardNotNull("table");
		columnNames.GuardNotNull("column names");
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
	public static DataColumn[] AddColumns(this DataTable table, string[] columnNames, Type[] columnTypes)
	{
		table.GuardNotNull("table");
		columnNames.GuardNotNull("column names");
		columnTypes.GuardNotNull("column types");
		columnNames.GuardArrayLength(columnTypes.Length, "columnNames & columnTypes", Literals.MSG_ArrayLengthNotSame_2.FormatValue("column names", "column types"));
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
	public static DataColumn[] AddColumns(this DataTable table, string[] columnNames, Type[] columnTypes, string[] columnExpresses)
	{
		table.GuardNotNull("table");
		columnNames.GuardNotNull("column names");
		columnTypes.GuardNotNull("column types");
		columnExpresses.GuardNotNull("column expresses");
		columnNames.Guard(columnNames.Length == columnTypes.Length && columnTypes.Length == columnExpresses.Length, () => new ArgumentException(Literals.MSG_ArrayLengthNotSame_3.FormatValue("column names", "column types", "column expresses")));
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
	public static IEnumerable<DataRow> AddedRows(this DataTable table)
	{
		table.GuardNotNull("table");
		return from r in table.Rows()
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
	public static IEnumerable<R> AddedRows<R>(this DataTable table) where R : DataRow
	{
		table.GuardNotNull("table");
		return from r in table.Rows<R>()
			where r.RowState.HasFlag(DataRowState.Added)
			select r;
	}

	/// <summary>
	/// 向当前数据表中添加数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="row">添加的数据行</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="row" /> 为空。</exception>
	public static void AddRow(this DataTable table, DataRow row)
	{
		table.GuardNotNull("table");
		row.GuardNotNull("row");
		table.Rows.Add(row);
	}

	/// <summary>
	/// 向当前数据表中添加数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="items">用于创建新行的列值的数组</param>
	/// <returns>添加后的新数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="items" /> 为空。</exception>
	public static DataRow AddRow(this DataTable table, params object[] items)
	{
		table.GuardNotNull("table");
		items.GuardNotNull("items");
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
	public static R AddRow<R>(this DataTable table, params object[] items) where R : DataRow
	{
		return (R)table.AddRow(items);
	}

	/// <summary>
	/// 向当前数据表中添加多个数据行
	/// </summary>
	/// <typeparam name="R">添加的数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="rows">待添加的数据行数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="rows" /> 为空。</exception>
	public static void AddRows<R>(this DataTable table, params R[] rows) where R : DataRow
	{
		table.GuardNotNull("table");
		rows.GuardNotNull("rows");
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
	public static void AddRows<R>(this DataTable table, IEnumerable<R> rows) where R : DataRow
	{
		table.GuardNotNull("table");
		rows.GuardNotNull("rows");
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
	public static DataRow[] AddRows(this DataTable table, params object[][] rowItems)
	{
		table.GuardNotNull("table");
		rowItems.GuardNotNull("items");
		return rowItems.Select((object[] x) => table.AddRow(x)).ToArray();
	}

	/// <summary>
	/// 向当前数据表中添加多个数据行
	/// </summary>
	/// <typeparam name="R">添加的数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="rowItems">待添加的数据行列值数组</param>
	/// <returns>添加的数据行的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="rowItems" /> 为空。</exception>
	public static R[] AddRows<R>(this DataTable table, params object[][] rowItems) where R : DataRow
	{
		table.GuardNotNull("table");
		rowItems.GuardNotNull("items");
		return rowItems.Select((object[] x) => table.AddRow<R>(x)).ToArray();
	}

	/// <summary>
	/// 检查是否可以从当前数据表中移除指定的列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="column">待移除的数据列</param>
	/// <returns>如果可以移除该数据列返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="column" /> 为空。</exception>
	public static bool CanRemoveColumn(this DataTable table, DataColumn column)
	{
		table.GuardNotNull("table");
		column.GuardNotNull("column");
		return table.Columns.CanRemove(column);
	}

	/// <summary>
	/// 检查是否可以从当前数据表中移除指定的列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">待移除的数据列的名称</param>
	/// <returns>如果可以移除该数据列返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static bool CanRemoveColumn(this DataTable table, string columnName)
	{
		table.GuardNotNull("table");
		columnName.GuardNotNull("column name");
		DataColumn column = table.Columns[columnName];
		return !column.IsNull() && table.Columns.CanRemove(column);
	}

	/// <summary>
	/// 从当前数据表中清除所有的列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static void ClearColumns(this DataTable table)
	{
		table.GuardNotNull("table");
		table.Columns.Clear();
	}

	/// <summary>
	/// 从当前数据表中清除所有数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static void ClearRows(this DataTable table)
	{
		table.GuardNotNull("table");
		table.Rows.Clear();
	}

	/// <summary>
	/// 获取当前数据表的数据列数量
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>当前数据表的数据列计数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static int ColumnCount(this DataTable table)
	{
		table.GuardNotNull("table");
		return table.Columns.Count;
	}

	/// <summary>
	/// 获取当前数据表的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<DataColumn> Columns(this DataTable table)
	{
		table.GuardNotNull("table");
		return table.Columns.OfType<DataColumn>();
	}

	/// <summary>
	/// 获取当前数据表的数据列
	/// </summary>
	/// <typeparam name="C">数据列类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<C> Columns<C>(this DataTable table) where C : DataColumn
	{
		table.GuardNotNull("table");
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
	public static IEnumerable<DataColumn> Columns(this DataTable table, string pattern, RegexOptions options = RegexOptions.None)
	{
		return table.Columns<DataColumn>(pattern, options);
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
	public static IEnumerable<C> Columns<C>(this DataTable table, string pattern, RegexOptions options = RegexOptions.None) where C : DataColumn
	{
		table.GuardNotNull("table");
		pattern.GuardNotNull("pattern");
		return from c in table.Columns<C>()
			where pattern.ToRegex(options).IsMatch(c.ColumnName)
			select c;
	}

	/// <summary>
	/// 获取当前数据表中满足指定模式的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="pattern">数据列名称匹配模式</param>
	/// <returns>符合条件的数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="pattern" /> 为空。</exception>
	public static IEnumerable<DataColumn> Columns(this DataTable table, Regex pattern)
	{
		return table.Columns<DataColumn>(pattern);
	}

	/// <summary>
	/// 获取当前数据表中满足指定模式的数据列
	/// </summary>
	/// <typeparam name="C">数据列类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="pattern">数据列名称匹配模式</param>
	/// <returns>符合条件的数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="pattern" /> 为空。</exception>
	public static IEnumerable<C> Columns<C>(this DataTable table, Regex pattern) where C : DataColumn
	{
		table.GuardNotNull("table");
		pattern.GuardNotNull("pattern");
		return from c in table.Columns<C>()
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
	public static IEnumerable<DataColumn> Columns(this DataTable table, Func<DataColumn, bool> predicate)
	{
		return table.Columns<DataColumn>(predicate);
	}

	/// <summary>
	/// 获取当前数据表中满足指定指定条件的数据列
	/// </summary>
	/// <typeparam name="C">数据列类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>符合条件的数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<C> Columns<C>(this DataTable table, Func<C, bool> predicate) where C : DataColumn
	{
		table.GuardNotNull("table");
		predicate.GuardNotNull("predicate");
		return table.Columns<C>().Where(predicate);
	}

	/// <summary>
	/// 获取当前数据表中满足指定指定条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>符合条件的数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<DataColumn> Columns(this DataTable table, Func<DataColumn, int, bool> predicate)
	{
		return table.Columns<DataColumn>(predicate);
	}

	/// <summary>
	/// 获取当前数据表中满足指定指定条件的数据列
	/// </summary>
	/// <typeparam name="C">数据列类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>符合条件的数据列序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<C> Columns<C>(this DataTable table, Func<C, int, bool> predicate) where C : DataColumn
	{
		table.GuardNotNull("table");
		predicate.GuardNotNull("predicate");
		return table.Columns<C>().Where(predicate);
	}

	/// <summary>
	/// 检测当前数据表中是否含有指定名称的列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">查找的列名称</param>
	/// <returns>如果数据表中包含与指定名称匹配的数据列返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static bool ContainsColumn(this DataTable table, string columnName)
	{
		table.GuardNotNull("table");
		columnName.GuardNotNull("column name");
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
	public static bool ContainsColumn(this DataTable table, string columnName, bool ignoreCase)
	{
		table.GuardNotNull("table");
		columnName.GuardNotNull("column name");
		return table.Columns().Any((DataColumn x) => x.ColumnName.EqualCultural(columnName, table.Locale, ignoreCase));
	}

	/// <summary>
	/// 检测当前数据表中是否存在符合条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>如果当前数据表中存在符合条件的数据列返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static bool ContainsColumn(this DataTable table, Func<DataColumn, bool> predicate)
	{
		table.GuardNotNull("table");
		predicate.GuardNotNull("predicate");
		return table.Columns().Any(predicate);
	}

	/// <summary>
	/// 检测当前数据表中是否存在符合条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>如果当前数据表中存在符合条件的数据列返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static bool ContainsColumn(this DataTable table, Func<DataColumn, int, bool> predicate)
	{
		table.GuardNotNull("table");
		predicate.GuardNotNull("predicate");
		return table.Columns().Any(predicate);
	}

	/// <summary>
	/// 检测当前数据表中是否存在主键值与给定值匹配的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="keyValue">主键值</param>
	/// <returns>存在匹配的数据行返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static bool ContainsRow(this DataTable table, object keyValue)
	{
		table.GuardNotNull("table");
		return table.Rows.Contains(keyValue);
	}

	/// <summary>
	/// 检测当前数据表中是否存在主键值与给定值匹配的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="keyValues">主键值列表</param>
	/// <returns>存在匹配的数据行返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keyValues" /> 为空；</exception>
	public static bool ContainsRow(this DataTable table, object[] keyValues)
	{
		table.GuardNotNull("table");
		keyValues.GuardNotNull("keyValues");
		return table.Rows.Contains(keyValues);
	}

	/// <summary>
	/// 检测当前数据表中是否存在符合条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据表检测条件</param>
	/// <returns>存在匹配的数据行返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static bool ContainsRow(this DataTable table, Func<DataRow, bool> predicate)
	{
		return table.ContainsRow<DataRow>(predicate);
	}

	/// <summary>
	/// 检测当前数据表中是否存在符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据表检测条件</param>
	/// <returns>存在匹配的数据行返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static bool ContainsRow<R>(this DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		table.GuardNotNull("table");
		predicate.GuardNotNull("predicate");
		return table.Rows<R>().Any(predicate);
	}

	/// <summary>
	/// 检测当前数据表中是否存在符合条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据表检测条件</param>
	/// <returns>存在匹配的数据行返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static bool ContainsRow(this DataTable table, Func<DataRow, int, bool> predicate)
	{
		return table.ContainsRow<DataRow>(predicate);
	}

	/// <summary>
	/// 检测当前数据表中是否存在符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据表检测条件</param>
	/// <returns>存在匹配的数据行返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static bool ContainsRow<R>(this DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		table.GuardNotNull("table");
		predicate.GuardNotNull("predicate");
		return table.Rows<R>().Any(predicate);
	}

	/// <summary>
	/// 复制当前数据表
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="copying">数据表的值的复制方法；接受当前待复制的值，返回复制后的值。</param>
	/// <returns>复制生成的新的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="copying" /> 为空。</exception>
	public static DataTable Copy(this DataTable table, Func<object, object> copying)
	{
		table.GuardNotNull("table");
		copying.GuardNotNull("copying");
		DataTable newTable = table.Clone();
		foreach (DataRow row in table.Rows())
		{
			DataRow newRow = newTable.NewRow();
			foreach (DataColumn column in table.Columns())
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
	public static DataTable Copy(this DataTable table, Func<DataRow, DataColumn, object> copying)
	{
		return table.Copy<DataTable, DataRow>(copying);
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
	public static T Copy<T, R>(this T table, Func<R, DataColumn, object> copying) where T : DataTable where R : DataRow
	{
		table.GuardNotNull("table");
		copying.GuardNotNull("copying");
		T newTable = (T)table.Clone();
		foreach (R row in table.Rows<R>())
		{
			DataRow newRow = newTable.NewRow();
			foreach (DataColumn column in table.Columns())
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
	public static DataView<T> CreateView<T>(this T table, DataViewRowState state = DataViewRowState.None) where T : DataTable
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
	public static DataView<T> CreateView<T>(this T table, params string[] sortColumns) where T : DataTable
	{
		return table.CreateView(sortColumns, DataViewRowState.None);
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
	public static DataView<T> CreateView<T>(this T table, string[] sortColumns, DataViewRowState state = DataViewRowState.None) where T : DataTable
	{
		table.GuardNotNull("table");
		return new DataView<T>(table, null, sortColumns.WhereNotNull().JoinString("{0} ASC", ","), state);
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
	public static DataView<T> CreateView<T>(this T table, string sortColumn, SortOrder sortOrder, DataViewRowState state = DataViewRowState.None) where T : DataTable
	{
		table.GuardNotNull("table");
		sortColumn.GuardNotNull("sort column");
		return new DataView<T>(table, null, "{0}, {1}".FormatValue(sortColumn, sortOrder switch
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
	public static DataView<T> CreateView<T>(this T table, SortItem[] sortItems, DataViewRowState state = DataViewRowState.None) where T : DataTable
	{
		table.GuardNotNull("table");
		return new DataView<T>(table, null, sortItems.Where((SortItem x) => x.IsNotNull()).JoinString((SortItem x) => "{0} {1}".FormatValue(x.Name.IsNullOrEmpty() ? table.Columns[x.Index.GuardBetween(0, table.Columns.Count - 1)].ColumnName : x.Name, (x.Order == SortOrder.Ascending) ? "ASC" : ((x.Order == SortOrder.Descending) ? "DESC" : string.Empty)), ","), state);
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
	public static DataView<T> CreateView<T>(this T table, string[] sortColumns, SortOrder[] sortOrders, DataViewRowState state = DataViewRowState.None) where T : DataTable
	{
		table.GuardNotNull("table");
		sortColumns.GuardNotNull("sort columns");
		sortOrders.GuardNotNull("sort orders");
		sortColumns.GuardArrayLength(sortOrders.Length, "sort columns & sort orders", Literals.MSG_ArrayLengthNotSame_2.FormatValue("sort columns", "sort orders"));
		List<string> columns = new List<string>();
		for (int i = 0; i < sortColumns.Length; i++)
		{
			if (sortColumns[i].IsNotNull())
			{
				columns.Add($"{sortColumns[i]} {sortOrders[i]}");
			}
		}
		return new DataView<T>(table, null, columns.JoinString(","), state);
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
	public static DataView<T> CreateView<T>(this T table, params int[] sortIndices) where T : DataTable
	{
		return table.CreateView(sortIndices, DataViewRowState.None);
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
	public static DataView<T> CreateView<T>(this T table, int[] sortIndices, DataViewRowState state = DataViewRowState.None) where T : DataTable
	{
		table.GuardNotNull("table");
		sortIndices.GuardNotNull("sort indices");
		sortIndices.ForEach(delegate(int x)
		{
			x.GuardIndexRange(0, table.Columns.Count - 1, "index");
		});
		return table.CreateView(sortIndices.Select((int x) => table.Columns[x].ColumnName).ToArray(), state);
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
	public static DataView<T> CreateView<T>(this T table, int[] sortIndices, SortOrder[] sortOrders, DataViewRowState state = DataViewRowState.None) where T : DataTable
	{
		table.GuardNotNull("table");
		sortIndices.GuardNotNull("sort indices");
		sortIndices.ForEach(delegate(int x)
		{
			x.GuardIndexRange(0, table.Columns.Count - 1, "index");
		});
		sortOrders.GuardNotNull("sort orders");
		sortIndices.GuardArrayLength(sortOrders.Length - 1, "sort indices & sort orders", Literals.MSG_ArrayLengthNotSame_2.FormatValue("sort indices", "sort orders"));
		return table.CreateView(sortIndices.Select((int x) => table.Columns[x].ColumnName).ToArray(), sortOrders, state);
	}

	/// <summary>
	/// 获取当前数据表中已删除的数据行的序列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>已删除的数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<DataRow> DeletedRows(this DataTable table)
	{
		table.GuardNotNull("table");
		return from r in table.Rows()
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
	public static IEnumerable<R> DeletedRows<R>(this DataTable table) where R : DataRow
	{
		table.GuardNotNull("table");
		return from r in table.Rows<R>()
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
	public static DataRow DeleteRow(this DataTable table, int index)
	{
		return table.DeleteRow<DataRow>(index);
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
	public static R DeleteRow<R>(this DataTable table, int index) where R : DataRow
	{
		R row = table.GetRow<R>(index);
		row.Delete();
		return row;
	}

	/// <summary>
	/// 从当前数据表中删除指定的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="row">待删除的数据行</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="row" /> 为空。</exception>
	public static void DeleteRow(this DataTable table, DataRow row)
	{
		table.GuardNotNull("table");
		row.GuardNotNull("row");
		table.Rows.Remove(row);
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="key">数据行主键值</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow DeleteRow(this DataTable table, object key)
	{
		return table.DeleteRow<DataRow>(key);
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="key">数据行主键值</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R DeleteRow<R>(this DataTable table, object key) where R : DataRow
	{
		R row = table.GetRow<R>(key);
		if (row.IsNotNull())
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
	public static DataRow DeleteRow(this DataTable table, object[] key)
	{
		return table.DeleteRow<DataRow>(key);
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="key">数据行主键值</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="key" /> 为空。</exception>
	public static R DeleteRow<R>(this DataTable table, object[] key) where R : DataRow
	{
		R row = table.GetRow<R>(key);
		if (row.IsNotNull())
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
	public static DataRow DeleteRow(this DataTable table, Func<DataRow, bool> predicate)
	{
		return table.DeleteRow<DataRow>(predicate);
	}

	/// <summary>
	/// 从当前数据表中删除符合指定条件的第一个数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">待移除的数据表筛选条件</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R DeleteRow<R>(this DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		R row = table.GetRow(predicate);
		if (row.IsNotNull())
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
	public static DataRow DeleteRow(this DataTable table, Func<DataRow, int, bool> predicate)
	{
		return table.DeleteRow<DataRow>(predicate);
	}

	/// <summary>
	/// 从当前数据表中删除符合指定条件的第一个数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">待移除的数据表筛选条件</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R DeleteRow<R>(this DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		R row = table.GetRow(predicate);
		if (row.IsNotNull())
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
	public static DataRow[] DeleteRows(this DataTable table, params int[] indices)
	{
		return table.DeleteRows<DataRow>(indices);
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
	public static R[] DeleteRows<R>(this DataTable table, params int[] indices) where R : DataRow
	{
		R[] rows = table.GetRows<R>(indices);
		rows.ForEach(delegate(R r)
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
	public static void DeleteRows<R>(this DataTable table, params R[] rows) where R : DataRow
	{
		table.GuardNotNull("table");
		rows.GuardNotNull("rows");
		foreach (R row in rows)
		{
			row.GuardNotNull("row");
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
	public static DataRow[] DeleteRows(this DataTable table, params object[] keys)
	{
		return table.DeleteRows<DataRow>(keys);
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">数据行主键数组</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static R[] DeleteRows<R>(this DataTable table, params object[] keys) where R : DataRow
	{
		R[] rows = table.GetRows<R>(keys);
		rows.ForEach(delegate(R r)
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
	public static DataRow[] DeleteRows(this DataTable table, params object[][] keys)
	{
		return table.DeleteRows<DataRow>(keys);
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">数据行主键数组，每个主键由一个对象数组表示</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static R[] DeleteRows<R>(this DataTable table, params object[][] keys) where R : DataRow
	{
		R[] rows = table.GetRows<R>(keys);
		rows.ForEach(delegate(R r)
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
	public static DataRow[] DeleteRows(this DataTable table, Func<DataRow, bool> predicate)
	{
		return table.DeleteRows<DataRow>(predicate);
	}

	/// <summary>
	/// 从当前数据表中删除所有符合条件的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行删除过滤条件</param>
	/// <returns>成功删除的数据行的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R[] DeleteRows<R>(this DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		R[] rows = table.GetRows(predicate);
		rows.ForEach(delegate(R r)
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
	public static DataRow[] DeleteRows(this DataTable table, Func<DataRow, int, bool> predicate)
	{
		return table.DeleteRows<DataRow>(predicate);
	}

	/// <summary>
	/// 从当前数据表中删除所有符合条件的数据行（仅标记为删除，不实际移除）
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行删除过滤条件</param>
	/// <returns>成功删除的数据行的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R[] DeleteRows<R>(this DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		R[] rows = table.GetRows(predicate);
		rows.ForEach(delegate(R r)
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
	public static DataRow[] GetAddedRows(this DataTable table)
	{
		table.GuardNotNull("table");
		return table.GetRows(DataRowState.Added);
	}

	/// <summary>
	/// 获取当前数据表中新添加的数据行
	/// </summary>
	/// <typeparam name="R">数据行的类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>新添加的数据行数组，没有新添加的行则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R[] GetAddedRows<R>(this DataTable table) where R : DataRow
	{
		table.GuardNotNull("table");
		return table.GetRows<R>(DataRowState.Added);
	}

	/// <summary>
	/// 获取当前数据表中指定索引的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="index">数据列的索引位置</param>
	/// <returns>指定索引的位置的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 超出数据表列的索引范围。</exception>
	public static DataColumn GetColumn(this DataTable table, int index)
	{
		table.GuardNotNull("table");
		index.GuardIndexRange(0, table.Columns.Count - 1, "index");
		return table.Columns[index];
	}

	/// <summary>
	/// 获取当前数据表中指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <returns>与指定名称匹配的数据列，如果没有匹配的数据列返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static DataColumn GetColumn(this DataTable table, string columnName)
	{
		table.GuardNotNull("table");
		columnName.GuardNotNull("column name");
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
	public static DataColumn GetColumn(this DataTable table, string columnName, bool ignoreCase)
	{
		table.GuardNotNull("table");
		columnName.GuardNotNull("column name");
		return table.Columns().FirstOrDefault((DataColumn x) => x.ColumnName.EqualCultural(columnName, table.Locale, ignoreCase));
	}

	/// <summary>
	/// 获取当前数据表中指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <param name="comparison">数据列名称比较方式</param>
	/// <returns>与指定名称匹配的数据列，如果没有匹配的数据列返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static DataColumn GetColumn(this DataTable table, string columnName, StringComparison comparison)
	{
		table.GuardNotNull("table");
		columnName.GuardNotNull("column name");
		return table.Columns().FirstOrDefault((DataColumn x) => string.Equals(x.ColumnName, columnName, comparison));
	}

	/// <summary>
	/// 获取当前数据表中指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <param name="comparer">数据列名称比较器</param>
	/// <returns>与指定名称匹配的数据列，如果没有匹配的数据列返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static DataColumn GetColumn(this DataTable table, string columnName, IEqualityComparer<string> comparer)
	{
		table.GuardNotNull("table");
		columnName.GuardNotNull("column name");
		comparer = comparer.IfNull(StringComparer.Ordinal);
		return table.Columns().FirstOrDefault((DataColumn x) => comparer.Equals(x.ColumnName, columnName));
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>符合条件的数据列，如果没有匹配的数据列返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataColumn GetColumn(this DataTable table, Func<DataColumn, bool> predicate)
	{
		table.GuardNotNull("table");
		predicate.GuardNotNull("predicate");
		return table.Columns().FirstOrDefault(predicate);
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>符合条件的数据列，如果没有匹配的数据列返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataColumn GetColumn(this DataTable table, Func<DataColumn, int, bool> predicate)
	{
		table.GuardNotNull("table");
		predicate.GuardNotNull("predicate");
		return table.Columns().FirstOrDefault(predicate);
	}

	/// <summary>
	/// 获取当前数据表中指定索引的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="indices">数据列索引数组</param>
	/// <returns>获取的数据列数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数据表为空；或者 <paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="indices" /> 中任一索引超出数据列索引有效范围。</exception>
	public static DataColumn[] GetColumns(this DataTable table, params int[] indices)
	{
		table.GuardNotNull("table");
		indices.GuardNotNull("indices");
		indices.ForEach(delegate(int x)
		{
			x.GuardIndexRange(0, table.Columns.Count - 1, "index");
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
	public static DataColumn[] GetColumns(this DataTable table, params string[] columnNames)
	{
		table.GuardNotNull("table");
		columnNames.GuardNotNull("column names");
		return (from x in columnNames
			select table.Columns[x] into x
			where x.IsNotNull()
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
	public static DataColumn[] GetColumns(this DataTable table, string[] columnNames, bool ignoreCase)
	{
		table.GuardNotNull("table");
		columnNames.GuardNotNull("column names");
		return columnNames.SelectMany((string n) => from c in table.Columns()
			where c.ColumnName.EqualCultural(n, table.Locale, ignoreCase)
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
	public static DataColumn[] GetColumns(this DataTable table, string[] columnNames, StringComparison comparison)
	{
		table.GuardNotNull("table");
		columnNames.GuardNotNull("column names");
		return columnNames.SelectMany((string n) => from c in table.Columns()
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
	public static DataColumn[] GetColumns(this DataTable table, string[] columnNames, IEqualityComparer<string> comparer)
	{
		table.GuardNotNull("table");
		columnNames.GuardNotNull("column names");
		comparer = comparer.IfNull(StringComparer.Ordinal);
		return columnNames.SelectMany((string n) => from c in table.Columns()
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
	public static DataColumn[] GetColumns(this DataTable table, string pattern, RegexOptions options)
	{
		table.GuardNotNull("table");
		pattern.GuardNotNull("pattern");
		return (from x in table.Columns()
			where pattern.ToRegex(options).IsMatch(x.ColumnName)
			select x).ToArray();
	}

	/// <summary>
	/// 在当前数据表中查找与指定名称模式匹配的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="pattern">数据列名称模式</param>
	/// <returns>符合条件的数据列数组，如果没有匹配的数据列返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数据表为空；或者 <paramref name="pattern" /> 为空。</exception>
	public static DataColumn[] GetColumns(this DataTable table, Regex pattern)
	{
		table.GuardNotNull("table");
		pattern.GuardNotNull("pattern");
		return (from x in table.Columns()
			where pattern.IsMatch(x.ColumnName)
			select x).ToArray();
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>符合条件的数据列数组，如果没有匹配的数据列返回空数组</returns>
	public static DataColumn[] GetColumns(this DataTable table, Func<DataColumn, bool> predicate)
	{
		table.GuardNotNull();
		predicate.GuardNotNull();
		return table.Columns().Where(predicate).ToArray();
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据列筛选条件</param>
	/// <returns>符合条件的数据列数组，如果没有匹配的数据列返回空数组</returns>
	public static DataColumn[] GetColumns(this DataTable table, Func<DataColumn, int, bool> predicate)
	{
		table.GuardNotNull();
		predicate.GuardNotNull();
		return table.Columns().Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中指定数据列的值数组
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnIndex">数据列索引</param>
	/// <returns>数据列的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="columnIndex" /> 超出数据列索引范围。</exception>
	public static object[] GetColumnValues(this DataTable table, int columnIndex)
	{
		table.GuardNotNull("table");
		columnIndex.GuardIndexRange(0, table.Columns.Count - 1, "column index");
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
	public static T[] GetColumnValues<T>(this DataTable table, int columnIndex)
	{
		table.GuardNotNull("table");
		columnIndex.GuardIndexRange(0, table.Columns.Count - 1, "column index");
		T[] values = new T[table.Rows.Count];
		for (int i = 0; i < table.Rows.Count; i++)
		{
			values[i] = table.Rows[i][columnIndex].EnsureDefault(typeof(T)).As<T>();
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
	public static object[] GetColumnValues(this DataTable table, string columnName)
	{
		table.GuardNotNull("table");
		columnName.GuardNotNull("column name");
		DataColumn column = table.GetColumn(columnName);
		return column.IsNull() ? null : table.GetColumnValues(column.Ordinal);
	}

	/// <summary>
	/// 获取当前数据表中指定数据列的值数组
	/// </summary>
	/// <typeparam name="T">数据列的数据类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">数据列名称</param>
	/// <returns>数据列值数组；如果指定的数据列不存在，则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static T[] GetColumnValues<T>(this DataTable table, string columnName)
	{
		table.GuardNotNull("table");
		columnName.GuardNotNull("column name");
		DataColumn column = table.GetColumn(columnName);
		return column.IsNull() ? null : table.GetColumnValues<T>(column.Ordinal);
	}

	/// <summary>
	/// 获取当前数据表中指定数据列的值数组
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="column">数据列对象</param>
	/// <returns>数据列值数组；如果指定的数据列不存在，则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="column" /> 为空。</exception>
	public static object[] GetColumnValues(this DataTable table, DataColumn column)
	{
		table.GuardNotNull("table");
		column.GuardNotNull("column");
		return table.GetColumnValues(column.Ordinal);
	}

	/// <summary>
	/// 获取当前数据表中指定数据列的值数组
	/// </summary>
	/// <typeparam name="T">数据列的数据类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="column">数据列对象</param>
	/// <returns>数据列值数组；如果指定的数据列不存在，则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="column" /> 为空。</exception>
	public static T[] GetColumnValues<T>(this DataTable table, DataColumn column)
	{
		table.GuardNotNull("table");
		column.GuardNotNull("column");
		return table.GetColumnValues<T>(column.Ordinal);
	}

	/// <summary>
	/// 获取当前数据表中标记为删除的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>标记为删除的数据行数组，没有该状态的数据行则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow[] GetDeletedRows(this DataTable table)
	{
		table.GuardNotNull("table");
		return table.GetRows(DataRowState.Deleted);
	}

	/// <summary>
	/// 获取当前数据表中标记为删除的数据行
	/// </summary>
	/// <typeparam name="R">数据行的类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>标记为删除的数据行数组，没有该状态的数据行则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R[] GetDeletedRows<R>(this DataTable table) where R : DataRow
	{
		table.GuardNotNull("table");
		return table.GetRows<R>(DataRowState.Deleted);
	}

	/// <summary>
	/// 获取当前数据表中修改的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>已修改的数据行的数组，没有该状态的数据行则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow[] GetModifiedRows(this DataTable table)
	{
		table.GuardNotNull("table");
		return table.GetRows(DataRowState.Modified);
	}

	/// <summary>
	/// 获取当前数据表中修改的数据行
	/// </summary>
	/// <typeparam name="R">数据行的类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>已修改的数据行的数组，没有该状态的数据行则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R[] GetModifiedRows<R>(this DataTable table) where R : DataRow
	{
		table.GuardNotNull("table");
		return table.GetRows<R>(DataRowState.Modified);
	}

	/// <summary>
	/// 从当前数据表中获取指定索引的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="index">获取的数据行索引</param>
	/// <returns>指定索引位置的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 指定的索引超出当前数据表的行索引范围。</exception>
	public static DataRow GetRow(this DataTable table, int index)
	{
		return table.GetRow<DataRow>(index);
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
	public static R GetRow<R>(this DataTable table, int index) where R : DataRow
	{
		table.GuardNotNull("table");
		index.GuardIndexRange(0, table.Rows.Count - 1, "index");
		return table.Rows[index].As<R>();
	}

	/// <summary>
	/// 从当前数据表中获取与主键值匹配的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="key">主键值</param>
	/// <returns>与主键匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow GetRow(this DataTable table, object key)
	{
		return table.GetRow<DataRow>(key);
	}

	/// <summary>
	/// 从当前数据表中获取与主键值匹配的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="key">主键值</param>
	/// <returns>与主键匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R GetRow<R>(this DataTable table, object key) where R : DataRow
	{
		table.GuardNotNull("table");
		return table.Rows.Find(key).As<R>();
	}

	/// <summary>
	/// 从当前数据表中获取与主键值匹配的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="key">主键值</param>
	/// <returns>与主键匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="key" /> 为空。</exception>
	public static DataRow GetRow(this DataTable table, object[] key)
	{
		return table.GetRow<DataRow>(key);
	}

	/// <summary>
	/// 从当前数据表中获取与主键值匹配的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="key">主键值</param>
	/// <returns>与主键匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="key" /> 为空。</exception>
	public static R GetRow<R>(this DataTable table, object[] key) where R : DataRow
	{
		table.GuardNotNull("table");
		key.GuardNotNull("key");
		return table.Rows.Find(key).As<R>();
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>符合条件的数据行，如果没有匹配的数据行返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow GetRow(this DataTable table, Func<DataRow, bool> predicate)
	{
		return table.GetRow<DataRow>(predicate);
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>符合条件的数据行，如果没有匹配的数据行返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R GetRow<R>(this DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		table.GuardNotNull("table");
		predicate.GuardNotNull("predicate");
		return table.Rows<R>().FirstOrDefault(predicate);
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>符合条件的数据行，如果没有匹配的数据行返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow GetRow(this DataTable table, Func<DataRow, int, bool> predicate)
	{
		return table.GetRow<DataRow>(predicate);
	}

	/// <summary>
	/// 在当前数据表中查找符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>符合条件的数据行，如果没有匹配的数据行返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R GetRow<R>(this DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		table.GuardNotNull("table");
		predicate.GuardNotNull("predicate");
		return table.Rows<R>().FirstOrDefault(predicate);
	}

	/// <summary>
	/// 获取当前数据表中指定索引位置的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="indices">数据行索引数组</param>
	/// <returns>指定索引位置的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="indices" /> 中任一索引超出数据行索引范围。</exception>
	public static DataRow[] GetRows(this DataTable table, params int[] indices)
	{
		return table.GetRows<DataRow>(indices);
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
	public static R[] GetRows<R>(this DataTable table, params int[] indices) where R : DataRow
	{
		table.GuardNotNull("table");
		indices.GuardNotNull("indices");
		indices.ForEach(delegate(int i)
		{
			i.GuardIndexRange(0, table.Rows.Count - 1, "indices");
		});
		return indices.Select((int i) => table.Rows[i].As<R>()).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中与指定主键值匹配的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">主键值数组</param>
	/// <returns>与指定主键值匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static DataRow[] GetRows(this DataTable table, params object[] keys)
	{
		return table.GetRows<DataRow>(keys);
	}

	/// <summary>
	/// 获取当前数据表中与指定主键值匹配的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">主键值数组</param>
	/// <returns>与指定主键值匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static R[] GetRows<R>(this DataTable table, params object[] keys) where R : DataRow
	{
		table.GuardNotNull("table");
		keys.GuardNotNull("keys");
		return (from k in keys
			select table.Rows.Find(k).As<R>() into x
			where x.IsNotNull()
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中与指定主键值匹配的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">主键值数组</param>
	/// <returns>与指定主键值匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static DataRow[] GetRows(this DataTable table, params object[][] keys)
	{
		return table.GetRows<DataRow>(keys);
	}

	/// <summary>
	/// 获取当前数据表中与指定主键值匹配的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">主键值数组</param>
	/// <returns>与指定主键值匹配的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static R[] GetRows<R>(this DataTable table, params object[][] keys) where R : DataRow
	{
		table.GuardNotNull("table");
		keys.GuardNotNull("keys");
		return (from k in keys
			select table.Rows.Find(k).As<R>() into x
			where x.IsNotNull()
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中符合条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>符合条件的数据行数组，如果没有匹配的数据行返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow[] GetRows(this DataTable table, Func<DataRow, bool> predicate)
	{
		return table.GetRows<DataRow>(predicate);
	}

	/// <summary>
	/// 获取当前数据表中符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>符合条件的数据行数组，如果没有匹配的数据行返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R[] GetRows<R>(this DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		table.GuardNotNull("table");
		predicate.GuardNotNull("predicate");
		return table.Rows<R>().Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中符合条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>符合条件的数据行数组，如果没有匹配的数据行返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static DataRow[] GetRows(this DataTable table, Func<DataRow, int, bool> predicate)
	{
		return table.GetRows<DataRow>(predicate);
	}

	/// <summary>
	/// 获取当前数据表中符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R[] GetRows<R>(this DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		table.GuardNotNull("table");
		predicate.GuardNotNull("predicate");
		return table.Rows<R>().Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中具有指定行状态的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="state">数据行状态</param>
	/// <returns>具有指定行状态的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow[] GetRows(this DataTable table, DataRowState state)
	{
		return table.GetRows<DataRow>(state);
	}

	/// <summary>
	/// 获取当前数据表中具有指定行状态的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="state">数据行状态</param>
	/// <returns>具有指定行状态的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R[] GetRows<R>(this DataTable table, DataRowState state) where R : DataRow
	{
		table.GuardNotNull("table");
		return (from r in table.Rows<R>()
			where r.RowState.HasFlag(state)
			select r).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中未更改的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>未更改的数据行的数组，没有该状态的数据行则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow[] GetUnchangedRows(this DataTable table)
	{
		table.GuardNotNull("table");
		return table.GetRows(DataRowState.Unchanged);
	}

	/// <summary>
	/// 获取当前数据表中未更改的数据行
	/// </summary>
	/// <typeparam name="R">数据行的类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>未更改的数据行的数组，没有该状态的数据行则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R[] GetUnchangedRows<R>(this DataTable table) where R : DataRow
	{
		table.GuardNotNull("table");
		return table.GetRows<R>(DataRowState.Unchanged);
	}

	/// <summary>
	/// 检测当前数据表中的数据行是否发生了更改
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>如果数据表发生了变更则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	/// <remarks>逐行检测每个数据行的状态，如果数据行的状态不是 <see cref="F:System.Data.DataRowState.Unchanged" />，则认为数据表发生了更改。</remarks>
	public static bool HasChanged(this DataTable table)
	{
		table.GuardNotNull("table");
		return table.Rows.OfType<DataRow>().Any((DataRow dr) => dr.RowState != DataRowState.Unchanged);
	}

	/// <summary>
	/// 向当前数据表的数据行集合开头的插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="row">待插入的数据行</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="row" /> 为空。</exception>
	public static void InsertFirstRow(this DataTable table, DataRow row)
	{
		table.InsertRow(row, 0);
	}

	/// <summary>
	/// 向当前数据表的数据行集合开头的插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="items">创建新行用的值的数组</param>
	/// <returns>创建的新的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="items" /> 为空。</exception>
	public static DataRow InsertFirstRow(this DataTable table, object[] items)
	{
		return table.InsertRow(items, 0);
	}

	/// <summary>
	/// 向当前数据表的头部的插入数据行
	/// </summary>
	/// <typeparam name="R">插入的数据行的类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="items">创建新行用的值的数组</param>
	/// <returns>创建的新的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="items" /> 为空。</exception>
	public static R InsertFirstRow<R>(this DataTable table, object[] items) where R : DataRow
	{
		return table.InsertRow<R>(items, 0);
	}

	/// <summary>
	/// 向当前数据表的头部插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="rows">待插入的数据行</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="rows" /> 为空。</exception>
	/// <remarks>插入后数据行的顺序与给定的 <paramref name="rows" /> 顺序相同。</remarks>
	public static void InsertFirstRows(this DataTable table, params DataRow[] rows)
	{
		table.InsertRows(rows, 0);
	}

	/// <summary>
	/// 向当前数据表的头部插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="itemsArray">创建新行用的值的数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="itemsArray" /> 为空。</exception>
	/// <remarks>插入后数据行的顺序与给定的 <paramref name="itemsArray" /> 顺序相同。</remarks>
	public static DataRow[] InsertFirstRows(this DataTable table, params object[][] itemsArray)
	{
		return table.InsertRows(itemsArray, 0);
	}

	/// <summary>
	/// 向当前数据表的头部插入数据行
	/// </summary>
	/// <typeparam name="R">插入的数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="itemsArray">创建新行用的值的数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="itemsArray" /> 为空。</exception>
	/// <remarks>插入后数据行的顺序与给定的 <paramref name="itemsArray" /> 顺序相同。</remarks>
	public static R[] InsertFirstRows<R>(this DataTable table, params object[][] itemsArray) where R : DataRow
	{
		return table.InsertRows<R>(itemsArray, 0);
	}

	/// <summary>
	/// 向当前数据表的末尾的插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="row">待插入的数据行</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="row" /> 为空。</exception>
	public static void InsertLastRow(this DataTable table, DataRow row)
	{
		table.GuardNotNull("table");
		table.InsertRow(row, table.Rows.Count);
	}

	/// <summary>
	/// 向当前数据表的末尾的插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="items">创建新行用的值的数组</param>
	/// <returns>创建的新的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="items" /> 为空。</exception>
	public static DataRow InsertLastRow(this DataTable table, object[] items)
	{
		table.GuardNotNull("table");
		return table.InsertRow(items, table.Rows.Count);
	}

	/// <summary>
	/// 向当前数据表的末尾的插入数据行
	/// </summary>
	/// <typeparam name="R">插入的数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="items">创建新行用的值的数组</param>
	/// <returns>创建的新的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="items" /> 为空。</exception>
	public static R InsertLastRow<R>(this DataTable table, object[] items) where R : DataRow
	{
		table.GuardNotNull("table");
		return table.InsertRow<R>(items, table.Rows.Count);
	}

	/// <summary>
	/// 向当前数据表的末尾的插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="rows">待插入的数据行</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="rows" /> 为空。</exception>
	/// <remarks>插入后数据行的顺序与给定的 <paramref name="rows" /> 顺序相同。</remarks>
	public static void InsertLastRows(this DataTable table, params DataRow[] rows)
	{
		table.GuardNotNull("table");
		table.InsertRows(rows, table.Rows.Count);
	}

	/// <summary>
	/// 向当前数据表的末尾插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="itemsArray">创建新行用的值的数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="itemsArray" /> 为空。</exception>
	/// <remarks>插入后数据行的顺序与给定的 <paramref name="itemsArray" /> 顺序相同。</remarks>
	public static DataRow[] InsertLastRows(this DataTable table, params object[][] itemsArray)
	{
		table.GuardNotNull("table");
		return table.InsertRows(itemsArray, table.Rows.Count);
	}

	/// <summary>
	/// 向当前数据表的末尾插入数据行
	/// </summary>
	/// <typeparam name="R">插入的数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="itemsArray">创建新行用的值的数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="itemsArray" /> 为空。</exception>
	/// <remarks>插入后数据行的顺序与给定的 <paramref name="itemsArray" /> 顺序相同。</remarks>
	public static R[] InsertLastRows<R>(this DataTable table, params object[][] itemsArray) where R : DataRow
	{
		table.GuardNotNull("table");
		return table.InsertRows<R>(itemsArray, table.Rows.Count);
	}

	/// <summary>
	/// 向当前数据表的指定位置中插入数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="row">待插入的数据行</param>
	/// <param name="position">数据行插入的位置</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="row" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="position" /> 小于0。</exception>
	public static void InsertRow(this DataTable table, DataRow row, int position)
	{
		table.GuardNotNull("table");
		row.GuardNotNull("row");
		position.GuardGreaterThanOrEqualTo(0, "position");
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
	public static DataRow InsertRow(this DataTable table, object[] items, int position)
	{
		return table.InsertRow<DataRow>(items, position);
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
	public static R InsertRow<R>(this DataTable table, object[] items, int position) where R : DataRow
	{
		table.GuardNotNull("table");
		items.GuardNotNull("items");
		position.GuardGreaterThanOrEqualTo(0, "position");
		R row = table.NewRow().As<R>();
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
	public static void InsertRows(this DataTable table, DataRow[] rows, int position)
	{
		table.GuardNotNull("table");
		rows.GuardNotNull("rows");
		position.GuardGreaterThanOrEqualTo(0, "position");
		foreach (DataRow row in rows)
		{
			if (row.IsNotNull())
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
	public static DataRow[] InsertRows(this DataTable table, object[][] itemsArray, int position)
	{
		return table.InsertRows<DataRow>(itemsArray, position);
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
	public static R[] InsertRows<R>(this DataTable table, object[][] itemsArray, int position) where R : DataRow
	{
		table.GuardNotNull("table");
		itemsArray.GuardNotNull("items array");
		position.GuardGreaterThanOrEqualTo(0, "position");
		List<R> rows = new List<R>(itemsArray.Length);
		foreach (object[] items in itemsArray)
		{
			if (items.IsNotNull())
			{
				R row = table.NewRow().As<R>();
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
	public static IEnumerable<DataRow> ModifiedRows(this DataTable table)
	{
		table.GuardNotNull("table");
		return from r in table.Rows()
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
	public static IEnumerable<R> ModifiedRows<R>(this DataTable table) where R : DataRow
	{
		table.GuardNotNull("table");
		return from r in table.Rows<R>()
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
	public static DataColumn RemoveColumn(this DataTable table, int index)
	{
		table.GuardNotNull("table");
		DataColumn column = table.GetColumn(index);
		table.Columns.RemoveAt(column.Ordinal);
		return column;
	}

	/// <summary>
	/// 从当前数据表中移除指定的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="column">待移除的数据列</param>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="column" /> 为空。</exception>
	public static void RemoveColumn(this DataTable table, DataColumn column)
	{
		table.GuardNotNull("table");
		column.GuardNotNull("column");
		table.Columns.Remove(column);
	}

	/// <summary>
	/// 从当前数据表中移除指定名称的数据列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="columnName">待移除的数据列名称</param>
	/// <returns>删除的数据列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="columnName" /> 为空。</exception>
	public static DataColumn RemoveColumn(this DataTable table, string columnName)
	{
		table.GuardNotNull("table");
		DataColumn column = table.GetColumn(columnName);
		if (column.IsNotNull())
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
	public static DataColumn RemoveColumn(this DataTable table, string columnName, bool ignoreCase)
	{
		table.GuardNotNull("table");
		DataColumn column = table.GetColumn(columnName, ignoreCase);
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
	public static DataColumn RemoveColumn(this DataTable table, string columnName, StringComparison comparison)
	{
		table.GuardNotNull("table");
		DataColumn column = table.GetColumn(columnName, comparison);
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
	public static DataColumn RemoveColumn(this DataTable table, string columnName, IEqualityComparer<string> comparer)
	{
		table.GuardNotNull("table");
		DataColumn column = table.GetColumn(columnName, comparer);
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
	public static DataColumn RemoveColumn(this DataTable table, Func<DataColumn, bool> predicate)
	{
		table.GuardNotNull("table");
		DataColumn column = table.GetColumn(predicate);
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
	public static DataColumn RemoveColumn(this DataTable table, Func<DataColumn, int, bool> predicate)
	{
		table.GuardNotNull("table");
		DataColumn column = table.GetColumn(predicate);
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
	public static DataColumn[] RemoveColumns(this DataTable table, params int[] indices)
	{
		table.GuardNotNull("table");
		DataColumn[] columns = table.GetColumns(indices);
		columns.ForEach(delegate(DataColumn c)
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
	public static void RemoveColumns(this DataTable table, params DataColumn[] columns)
	{
		table.GuardNotNull("table");
		columns.GuardNotNull("columns");
		foreach (DataColumn column in columns)
		{
			column.GuardNotNull("column");
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
	public static DataColumn[] RemoveColumns(this DataTable table, params string[] columnNames)
	{
		table.GuardNotNull("table");
		DataColumn[] columns = table.GetColumns(columnNames);
		columns.ForEach(delegate(DataColumn c)
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
	public static DataColumn[] RemoveColumns(this DataTable table, string[] columnNames, bool ignoreCase)
	{
		table.GuardNotNull("table");
		DataColumn[] columns = table.GetColumns(columnNames, ignoreCase);
		columns.ForEach(delegate(DataColumn c)
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
	public static DataColumn[] RemoveColumns(this DataTable table, string[] columnNames, StringComparison comparison)
	{
		table.GuardNotNull("table");
		DataColumn[] columns = table.GetColumns(columnNames, comparison);
		columns.ForEach(delegate(DataColumn c)
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
	public static DataColumn[] RemoveColumns(this DataTable table, string[] columnNames, IEqualityComparer<string> comparer)
	{
		table.GuardNotNull("table");
		DataColumn[] columns = table.GetColumns(columnNames, comparer);
		columns.ForEach(delegate(DataColumn c)
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
	public static DataColumn[] RemoveColumns(this DataTable table, Func<DataColumn, bool> predicate)
	{
		table.GuardNotNull("table");
		DataColumn[] columns = table.GetColumns(predicate);
		columns.ForEach(delegate(DataColumn c)
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
	public static DataColumn[] RemoveColumns(this DataTable table, Func<DataColumn, int, bool> predicate)
	{
		table.GuardNotNull("table");
		DataColumn[] columns = table.GetColumns(predicate);
		columns.ForEach(delegate(DataColumn c)
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
	public static DataRow RemoveRow(this DataTable table, int index)
	{
		return table.RemoveRow<DataRow>(index);
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
	public static R RemoveRow<R>(this DataTable table, int index) where R : DataRow
	{
		table.GuardNotNull("table");
		R row = table.GetRow<R>(index);
		if (row.IsNotNull())
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
	public static void RemoveRow(this DataTable table, DataRow row)
	{
		table.GuardNotNull("table");
		row.GuardNotNull("row");
		table.Rows.Remove(row);
	}

	/// <summary>
	/// 从当前数据表中移除与主键值匹配的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="key">待移除数据行的主键值</param>
	/// <returns>被删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow RemoveRow(this DataTable table, object key)
	{
		return table.RemoveRow<DataRow>(key);
	}

	/// <summary>
	/// 从当前数据表中移除与主键值匹配的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="key">待移除数据行的主键值</param>
	/// <returns>被删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R RemoveRow<R>(this DataTable table, object key) where R : DataRow
	{
		table.GuardNotNull("table");
		R row = table.GetRow<R>(key);
		if (row.IsNotNull())
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
	public static DataRow RemoveRow(this DataTable table, object[] key)
	{
		return table.RemoveRow<DataRow>(key);
	}

	/// <summary>
	/// 从当前数据表中移除与主键值匹配的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="key">待移除数据行的主键值数组</param>
	/// <returns>删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="key" /> 为空。</exception>
	public static R RemoveRow<R>(this DataTable table, object[] key) where R : DataRow
	{
		table.GuardNotNull("table");
		R row = table.GetRow<R>(key);
		if (row.IsNotNull())
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
	public static DataRow RemoveRow(this DataTable table, Func<DataRow, bool> predicate)
	{
		return table.RemoveRow<DataRow>(predicate);
	}

	/// <summary>
	/// 从当前数据表中移除符合条件的第一个数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">待移除的数据表筛选条件</param>
	/// <returns>删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R RemoveRow<R>(this DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		table.GuardNotNull("table");
		R row = table.GetRow(predicate);
		if (row.IsNotNull())
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
	public static DataRow RemoveRow(this DataTable table, Func<DataRow, int, bool> predicate)
	{
		return table.RemoveRow<DataRow>(predicate);
	}

	/// <summary>
	/// 从当前数据表中移除符合条件的第一个数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">待移除的数据表筛选条件</param>
	/// <returns>删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R RemoveRow<R>(this DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		table.GuardNotNull("table");
		R row = table.GetRow(predicate);
		if (row.IsNotNull())
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
	public static DataRow[] RemoveRows(this DataTable table, params int[] indices)
	{
		return table.RemoveRows<DataRow>(indices);
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
	public static R[] RemoveRows<R>(this DataTable table, params int[] indices) where R : DataRow
	{
		table.GuardNotNull("table");
		R[] rows = table.GetRows<R>(indices);
		rows.ForEach(delegate(R r)
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
	public static void RemoveRows<R>(this DataTable table, params R[] rows) where R : DataRow
	{
		table.GuardNotNull("table");
		rows.GuardNotNull("rows");
		foreach (R row in rows)
		{
			row.GuardNotNull("row");
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
	public static DataRow[] RemoveRows(this DataTable table, params object[] keys)
	{
		return table.RemoveRows<DataRow>(keys);
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">数据行主键数组</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static R[] RemoveRows<R>(this DataTable table, params object[] keys) where R : DataRow
	{
		table.GuardNotNull("table");
		R[] rows = table.GetRows<R>(keys);
		rows.ForEach(delegate(R r)
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
	public static DataRow[] RemoveRows(this DataTable table, params object[][] keys)
	{
		return table.RemoveRows<DataRow>(keys);
	}

	/// <summary>
	/// 从当前数据表中删除具有指定主键值的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="keys">数据行主键数组，每个主键由一个对象数组表示</param>
	/// <returns>返回被删除的数据行，如果找到需要删除的数据行返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="keys" /> 为空。</exception>
	public static R[] RemoveRows<R>(this DataTable table, params object[][] keys) where R : DataRow
	{
		table.GuardNotNull("table");
		R[] rows = table.GetRows<R>(keys);
		rows.ForEach(delegate(R r)
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
	public static DataRow[] RemoveRows(this DataTable table, Func<DataRow, bool> predicate)
	{
		return table.RemoveRows<DataRow>(predicate);
	}

	/// <summary>
	/// 从当前数据表中删除所有符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行删除过滤条件</param>
	/// <returns>返回被删除的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static R[] RemoveRows<R>(this DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		table.GuardNotNull("table");
		R[] rows = table.GetRows(predicate);
		rows.ForEach(delegate(R r)
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
	public static DataRow[] RemoveRows(this DataTable table, Func<DataRow, int, bool> predicate)
	{
		return table.RemoveRows<DataRow>(predicate);
	}

	/// <summary>
	/// 从当前数据表中删除所有符合条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行删除过滤条件</param>
	/// <returns>成功删除的数据行的数量</returns>
	public static R[] RemoveRows<R>(this DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		table.GuardNotNull("table");
		R[] rows = table.GetRows(predicate);
		rows.ForEach(delegate(R r)
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
	public static int RowCount(this DataTable table)
	{
		table.GuardNotNull("table");
		return table.Rows.Count;
	}

	/// <summary>
	/// 获取当前数据表中具有指定行状态的数据行的数量
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="state">需要计数的数据行状态</param>
	/// <returns>指定行状态的数据行的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static int RowCount(this DataTable table, DataRowState state)
	{
		table.GuardNotNull("table");
		return (from r in table.Rows()
			where r.RowState.HasFlag(state)
			select r).Count();
	}

	/// <summary>
	/// 获取当前数据表中数据行的序列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<DataRow> Rows(this DataTable table)
	{
		return table.Rows<DataRow>();
	}

	/// <summary>
	/// 获取当前数据表中数据行的序列
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<R> Rows<R>(this DataTable table) where R : DataRow
	{
		table.GuardNotNull("table");
		return table.Rows.OfType<R>();
	}

	/// <summary>
	/// 获取当前数据表中指定行状态的序列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="state">数据行状态</param>
	/// <returns>数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<DataRow> Rows(this DataTable table, DataRowState state)
	{
		return table.Rows<DataRow>(state);
	}

	/// <summary>
	/// 获取当前数据表中指定行状态的序列
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="state">数据行状态</param>
	/// <returns>数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<R> Rows<R>(this DataTable table, DataRowState state) where R : DataRow
	{
		table.GuardNotNull("table");
		return from r in table.Rows<R>()
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
	public static IEnumerable<DataRow> Rows(this DataTable table, Func<DataRow, bool> predicate)
	{
		return table.Rows<DataRow>(predicate);
	}

	/// <summary>
	/// 获取当前数据表中满足指定条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<R> Rows<R>(this DataTable table, Func<R, bool> predicate) where R : DataRow
	{
		table.GuardNotNull("table");
		predicate.GuardNotNull("predicate");
		return table.Rows<R>().Where(predicate);
	}

	/// <summary>
	/// 获取当前数据表中满足指定条件的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<DataRow> Rows(this DataTable table, Func<DataRow, int, bool> predicate)
	{
		return table.Rows<DataRow>(predicate);
	}

	/// <summary>
	/// 获取当前数据表中满足指定条件的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="predicate">数据行筛选条件</param>
	/// <returns>数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<R> Rows<R>(this DataTable table, Func<R, int, bool> predicate) where R : DataRow
	{
		table.GuardNotNull("table");
		predicate.GuardNotNull("predicate");
		return table.Rows<R>().Where(predicate);
	}

	/// <summary>
	/// 设置当前数据表中数据行为 <see cref="F:System.Data.DataRowState.Added" /> 状态，仅处理状态为 <see cref="F:System.Data.DataRowState.Unchanged" /> 的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>处理后状态为 <see cref="F:System.Data.DataRowState.Added" /> 的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow[] SetRowsAdded(this DataTable table)
	{
		table.GuardNotNull("table");
		table.UnchangedRows().ForEach(delegate(DataRow r)
		{
			r.SetAdded();
		});
		return table.AddedRows().ToArray();
	}

	/// <summary>
	/// 设置当前数据表中数据行为 <see cref="F:System.Data.DataRowState.Added" /> 状态，仅处理状态为 <see cref="F:System.Data.DataRowState.Unchanged" /> 的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>处理后状态为 <see cref="F:System.Data.DataRowState.Added" /> 的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R[] SetRowsAdded<R>(this DataTable table) where R : DataRow
	{
		table.GuardNotNull("table");
		table.UnchangedRows<R>().ForEach(delegate(R r)
		{
			r.SetAdded();
		});
		return table.AddedRows<R>().ToArray();
	}

	/// <summary>
	/// 设置当前数据表中数据行为 <see cref="F:System.Data.DataRowState.Modified" /> 状态，仅处理状态为 <see cref="F:System.Data.DataRowState.Unchanged" /> 的数据行
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>处理后状态为 <see cref="F:System.Data.DataRowState.Modified" /> 的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static DataRow[] SetRowsModified(this DataTable table)
	{
		table.GuardNotNull("table");
		table.UnchangedRows().ForEach(delegate(DataRow r)
		{
			r.SetModified();
		});
		return table.ModifiedRows().ToArray();
	}

	/// <summary>
	/// 设置当前数据表中数据行为 <see cref="F:System.Data.DataRowState.Modified" /> 状态，仅处理状态为 <see cref="F:System.Data.DataRowState.Unchanged" /> 的数据行
	/// </summary>
	/// <typeparam name="R">数据行类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <returns>处理后状态为 <see cref="F:System.Data.DataRowState.Modified" /> 的数据行</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static R[] SetRowsModified<R>(this DataTable table) where R : DataRow
	{
		table.GuardNotNull("table");
		table.UnchangedRows<R>().ForEach(delegate(R r)
		{
			r.SetModified();
		});
		return table.ModifiedRows<R>().ToArray();
	}

	/// <summary>
	/// 将当前数据表转换为对象数组，每个数据行转换为一个对象；每个数据列映射到对象上相应的公共实例属性
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="type">转换的目标类型</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空。</exception>
	public static object[] ToObjectArray(this DataTable table, Type type)
	{
		table.GuardNotNull("table");
		return (from r in table.Rows()
			select r.ToObject(type)).ToArray();
	}

	/// <summary>
	/// 将当前数据表转换为对象数组，每个数据行转换为一个对象；每个数据列映射到对象上相应的公共实例属性
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="table">当前数据表</param>
	/// <param name="obj">转换的目标对象，如果为空则创建该类型的对象的新实例</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空。</exception>
	public static T[] ToObjectArray<T>(this DataTable table, T obj = default(T))
	{
		table.GuardNotNull("table");
		return (from r in table.Rows()
			select r.ToObject(obj)).ToArray();
	}

	/// <summary>
	/// 将当前数据表转换为对象数组，每个数据行转换为一个对象
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <param name="type">转换的目标类型</param>
	/// <param name="flags">属性绑定标志</param>
	/// <returns>转换生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据行为空；或者转换的目标类型 <paramref name="type" /> 为空。</exception>
	public static object[] ToObjectArray(this DataTable table, Type type, BindingFlags flags)
	{
		table.GuardNotNull("table");
		return (from r in table.Rows()
			select r.ToObject(type, flags)).ToArray();
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
	public static T[] ToObjectArray<T>(this DataTable table, BindingFlags flags, T obj = default(T))
	{
		table.GuardNotNull("table");
		return (from r in table.Rows()
			select r.ToObject(flags, obj)).ToArray();
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
	public static object[] ToObjectArray(this DataTable table, Type type, string[] columns, bool onlyMapping = false, bool ignoreCase = false)
	{
		table.GuardNotNull("table");
		type.GuardNotNull("type");
		columns.GuardNotNull("columns");
		return (from r in table.Rows()
			select r.ToObject(type, columns, onlyMapping, ignoreCase)).ToArray();
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
	public static T[] ToObjectArray<T>(this DataTable table, string[] columns, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		table.GuardNotNull("table");
		columns.GuardNotNull("columns");
		return (from r in table.Rows()
			select r.ToObject(columns, onlyMapping, ignoreCase, obj)).ToArray();
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
	public static object[] ToObjectArray(this DataTable table, Type type, string[] columns, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		table.GuardNotNull("table");
		type.GuardNotNull("type");
		columns.GuardNotNull("columns");
		return (from r in table.Rows()
			select r.ToObject(type, columns, flags, onlyMapping, ignoreCase)).ToArray();
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
	public static T[] ToObjectArray<T>(this DataTable table, string[] columns, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		table.GuardNotNull("table");
		columns.GuardNotNull("columns");
		return (from r in table.Rows()
			select r.ToObject(columns, flags, onlyMapping, ignoreCase, obj)).ToArray();
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
	public static object[] ToObjectArray(this DataTable table, Type type, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false)
	{
		return table.ToObjectArray(type, mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase);
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
	public static T[] ToObjectArray<T>(this DataTable table, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		return table.ToObjectArray(mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase, obj);
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
	public static object[] ToObjectArray(this DataTable table, Type type, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		table.GuardNotNull("table");
		type.GuardNotNull("type");
		mappings.GuardNotNull("mappings");
		return (from r in table.Rows()
			select r.ToObject(type, mappings, flags, onlyMapping, ignoreCase)).ToArray();
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
	public static T[] ToObjectArray<T>(this DataTable table, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false, T obj = default(T))
	{
		table.GuardNotNull("table");
		mappings.GuardNotNull("mappings");
		return (from r in table.Rows()
			select r.ToObject(mappings, flags, onlyMapping, ignoreCase, obj)).ToArray();
	}

	/// <summary>
	/// 获取当前数据表中未修改的数据行的序列
	/// </summary>
	/// <param name="table">当前数据表</param>
	/// <returns>未修改的数据行的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数据表为空。</exception>
	public static IEnumerable<DataRow> UnchangedRows(this DataTable table)
	{
		table.GuardNotNull("table");
		return from r in table.Rows()
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
	public static IEnumerable<R> UnchangedRows<R>(this DataTable table) where R : DataRow
	{
		table.GuardNotNull("table");
		return from r in table.Rows<R>()
			where r.RowState.HasFlag(DataRowState.Unchanged)
			select r;
	}
}
