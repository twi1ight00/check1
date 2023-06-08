namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query.Dynamic;

/// <summary>
/// 表示And条件的查询块
/// </summary>
public class AndQueryBlock : QueryBlockBase
{
	/// <inheritdoc />
	public override string RelationMark => " and ";
}
