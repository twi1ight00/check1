using System.Data;

namespace Richfit.Garnet.Common.Data;

/// <summary>
/// 数据表类型化的数据视图
/// </summary>
/// <typeparam name="T">数据视图的基础数据表类型</typeparam>
public class DataView<T> : DataView where T : DataTable
{
	/// <summary>
	/// 获取或设置基础数据表。 
	/// </summary>
	public new T Table
	{
		get
		{
			return (T)base.Table;
		}
		set
		{
			base.Table = value;
		}
	}

	/// <summary>
	/// 初始化数据视图的新实例。 
	/// </summary>
	public DataView()
	{
	}

	/// <summary>
	/// 初始化数据视图的新实例
	/// </summary>
	/// <param name="table">基础数据表</param>
	public DataView(T table)
		: base(table)
	{
	}

	/// <summary>
	/// 初始化数据视图的新实例
	/// </summary>
	/// <param name="table">基础数据表</param>
	/// <param name="sort">数据行排序条件</param>
	/// <param name="state">数据行版本筛选</param>
	public DataView(T table, string sort, DataViewRowState state)
		: base(table, null, sort, state)
	{
	}

	/// <summary>
	/// 初始化数据视图的新实例
	/// </summary>
	/// <param name="table">基础数据表</param>
	/// <param name="rowFilter">数据行筛选条件</param>
	/// <param name="sort">数据行排序条件</param>
	/// <param name="state">数据行版本筛选条件</param>
	public DataView(T table, string rowFilter, string sort, DataViewRowState state)
		: base(table, rowFilter, sort, state)
	{
	}
}
