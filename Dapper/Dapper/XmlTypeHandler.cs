using System.Data;

namespace Dapper;

internal abstract class XmlTypeHandler<T> : SqlMapper.StringTypeHandler<T>
{
	public override void SetValue(IDbDataParameter parameter, T value)
	{
		base.SetValue(parameter, value);
		parameter.DbType = DbType.Xml;
	}
}
