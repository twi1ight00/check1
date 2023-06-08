using System.Collections.Generic;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query.Dynamic;

/// <summary>
/// 查询块的定义
/// </summary>
public interface IQueryBlock
{
	/// <summary>
	/// 查询块列表
	/// </summary>
	IList<IQueryBlock> BlockItems { get; set; }

	/// <summary>
	/// 查询条件列表
	/// </summary>
	IList<QueryItem> QueryItems { get; set; }

	/// <summary>
	/// sql关系连接标识
	/// </summary>
	string RelationMark { get; }
}
