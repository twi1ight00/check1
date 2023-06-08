using System;

namespace Richfit.Garnet.Module.Base.Application.DTO;

/// <summary>
/// 树节点基本结构
/// </summary>
public class TREE_NODE : DTOBase
{
	/// <summary>
	/// 树节点ID
	/// </summary>
	public Guid ID { get; set; }

	/// <summary>
	/// 树节点名称
	/// </summary>     
	public string NAME { get; set; }

	/// <summary>
	/// 树节点的父ID
	/// </summary>
	public Guid? PARENT_ID { get; set; }

	/// <summary>
	/// 树节点上级名称
	/// </summary>
	public string PARENT_NAME { get; set; }

	/// <summary>
	/// 子节点是否为空
	/// </summary>
	public decimal CHILD_COUNT { get; set; }

	/// <summary>
	/// checkbox选择状态
	/// </summary>
	public decimal IS_CHECK { get; set; }

	/// <summary>
	/// 数据业务类型
	/// </summary>
	public string TYPE { get; set; }

	/// <summary>
	/// 排序
	/// </summary>
	public decimal SORT { get; set; }
}
/// <summary>
/// 树节点基本结构
/// </summary>
public class TREE_NODE<T> : DTOBase where T : struct
{
	/// <summary>
	/// 树节点ID
	/// </summary>
	public T ID { get; set; }

	/// <summary>
	/// 树节点名称
	/// </summary>     
	public string NAME { get; set; }

	/// <summary>
	/// 树节点的父ID
	/// </summary>
	public T? PARENT_ID { get; set; }

	/// <summary>
	/// 树节点上级名称
	/// </summary>
	public string PARENT_NAME { get; set; }

	/// <summary>
	/// 子节点是否为空
	/// </summary>
	public decimal CHILD_COUNT { get; set; }

	/// <summary>
	/// checkbox选择状态
	/// </summary>
	public decimal IS_CHECK { get; set; }

	/// <summary>
	/// 数据业务类型
	/// </summary>
	public string TYPE { get; set; }

	/// <summary>
	/// 排序
	/// </summary>
	public decimal SORT { get; set; }
}
