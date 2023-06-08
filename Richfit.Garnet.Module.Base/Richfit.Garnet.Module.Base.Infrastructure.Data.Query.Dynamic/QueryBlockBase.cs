using System.Collections.Generic;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query.Dynamic;

/// <summary>
/// 查询块基类
/// </summary>
public abstract class QueryBlockBase : IQueryBlock
{
	private IList<IQueryBlock> blockItems;

	private IList<QueryItem> queryItems;

	/// <inheritdoc />
	public IList<IQueryBlock> BlockItems
	{
		get
		{
			return blockItems;
		}
		set
		{
			blockItems = value;
		}
	}

	/// <inheritdoc />
	public IList<QueryItem> QueryItems
	{
		get
		{
			return queryItems;
		}
		set
		{
			queryItems = value;
		}
	}

	/// <summary>
	/// sql关系连接标识
	/// </summary>
	/// <returns></returns>
	public abstract string RelationMark { get; }

	/// <summary>
	/// 初始化对象
	/// </summary>
	public QueryBlockBase()
	{
		BlockItems = new List<IQueryBlock>();
		QueryItems = new List<QueryItem>();
	}
}
