using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Data;

/// <summary>
/// 数据排序项
/// </summary>
public class SortItem
{
	/// <summary>
	/// 排序项目名称
	/// </summary>
	private string name;

	/// <summary>
	/// 排序项目索引
	/// </summary>
	private int index;

	/// <summary>
	/// 排序方向
	/// </summary>
	private SortOrder order;

	/// <summary>
	/// 获取或者设置排序项目名称
	/// </summary>
	public string Name
	{
		get
		{
			return name.IfNull(string.Empty);
		}
		set
		{
			name = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 获取或者设置排序项目索引
	/// </summary>
	public int Index
	{
		get
		{
			return index;
		}
		set
		{
			index = value.GuardGreaterThanOrEqualTo(0, "sort item index");
		}
	}

	/// <summary>
	/// 获取或者设置排序方向
	/// </summary>
	public SortOrder Order
	{
		get
		{
			return order;
		}
		set
		{
			order = value;
		}
	}

	/// <summary>
	/// 初始化数据排序项
	/// </summary>
	/// <param name="name">排序项目名称</param>
	/// <param name="order">排序方向</param>
	public SortItem(string name, SortOrder order)
	{
		Name = name;
		Index = index;
		Order = order;
	}
}
