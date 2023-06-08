namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query.Dynamic;

/// <summary>
/// 表示Or条件的查询块
/// </summary>
public class OrQueryBlock : QueryBlockBase
{
	/// <inheritdoc />
	public override string RelationMark => " or ";
}
