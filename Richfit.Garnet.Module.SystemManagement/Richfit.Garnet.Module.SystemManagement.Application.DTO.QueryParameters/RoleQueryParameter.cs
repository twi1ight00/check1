using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.SystemManagement.Application.DTO.QueryParameters;

public class RoleQueryParameter : QueryObjectBase
{
	/// <summary>
	///  角色名称
	/// </summary>
	[ParameterConfig("ROLE_NAME", "string", " Like ")]
	public string ROLE_NAME { get; set; }

	/// <summary>
	///  所属机构ID
	/// </summary>
	[ParameterConfig("ORG_ID", "guid", " = ")]
	public string ORG_ID { get; set; }
}
