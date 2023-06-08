using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Data.DataRowView" /> 类型扩展方法类
///
/// 包括：
/// 1. DataRowView类型的扩展方法
/// 2. 以DataRowView类型为约束的泛型的扩展方法
/// 3. DataRowView类型数组或者泛型数组的扩展方法
/// 4. 以DataRowView类型为约束的泛型或者泛型数组的扩展方法
/// </summary>
public static class DataRowViewExtensions
{
	/// <summary>
	/// 将数据行视图序列转换为数据行数组
	/// </summary>
	/// <param name="drvs">数据行视图数组</param>
	/// <returns>数据行数组</returns>
	/// <exception cref="T:System.ArgumentNullException">数据行视图序列为空。</exception>
	public static DataRow[] ToDataRows(this IEnumerable<DataRowView> drvs)
	{
		return drvs.ToDataRows<DataRow>();
	}

	/// <summary>
	/// 将数据行视图序列转换为数据行数组
	/// </summary>
	/// <typeparam name="R">强类型数据行类型</typeparam>
	/// <param name="drvs">数据行视图数组</param>
	/// <returns>数据行数组</returns>
	/// <exception cref="T:System.ArgumentNullException">数据行视图序列为空。</exception>
	public static R[] ToDataRows<R>(this IEnumerable<DataRowView> drvs) where R : DataRow
	{
		drvs.GuardNotNull("drvs");
		return drvs.Select((DataRowView drv) => drv.Row.As<R>()).ToArray();
	}

	/// <summary>
	/// 将数据行视图序列转换为新的数据表
	/// </summary>
	/// <param name="drvs">数据行视图数组</param>
	/// <returns>视图新的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">数据行视图序列为空。</exception>
	public static DataTable ToDataTable(this IEnumerable<DataRowView> drvs)
	{
		drvs.GuardNotNull("drvs");
		DataTable table = null;
		foreach (DataRowView drv in drvs)
		{
			if (table.IsNull())
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
	public static T ToDataTable<T>(this IEnumerable<DataRowView> drvs) where T : DataTable, new()
	{
		drvs.GuardNotNull("drvs");
		T table = new T();
		foreach (DataRowView drv in drvs)
		{
			table.Rows.Add(drv.Row.ItemArray);
		}
		return table;
	}
}
