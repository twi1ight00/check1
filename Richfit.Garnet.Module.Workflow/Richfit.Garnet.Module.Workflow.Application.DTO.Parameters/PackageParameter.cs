using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

/// <summary>
/// 包参数
/// </summary>
public class PackageParameter : QueryObjectBase
{
	/// <summary>
	/// 包名称
	/// </summary>
	[ParameterConfig("PACKAGE_NAME", "string", " Like ")]
	public string PACKAGE_NAME { get; set; }

	/// <summary>
	/// 包名称
	/// </summary>
	[ParameterConfig("ORG_ID", "string", " = ")]
	public string ORG_ID { get; set; }
}
