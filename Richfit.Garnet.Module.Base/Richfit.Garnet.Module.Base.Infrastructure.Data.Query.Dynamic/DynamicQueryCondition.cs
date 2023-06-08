namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query.Dynamic;

/// <summary>
/// 动态查询条件结构
/// </summary>
public class DynamicQueryCondition
{
	/// <summary>
	/// 查询条件块
	/// </summary>
	public IQueryBlock QueryBlock { get; set; }

	/// <summary>
	/// 分页设置
	/// </summary>
	public PagingInfo PagingSetting { get; set; }
}
