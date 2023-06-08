using System;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

/// <summary>
/// 模板查询
/// </summary>
public class TemplateParameter : QueryObjectBase
{
	/// <summary>
	/// 模板ID
	/// </summary>
	[ParameterConfig("TEMPLATE_ID", "guid", " = ")]
	public Guid? TEMPLATE_ID { get; set; }

	/// <summary>
	/// 包ID
	/// </summary>
	[ParameterConfig("PACKAGE_ID", "guid", " = ")]
	public Guid? PACKAGE_ID { get; set; }

	/// <summary>
	/// 模板名称
	/// </summary>
	[ParameterConfig("TEMPLATE_NAME", "string", " Like ")]
	public string TEMPLATE_NAME { get; set; }

	/// <summary>
	/// 版本ID
	/// </summary>
	[ParameterConfig("VERSION_ID", "guid", " = ")]
	public Guid? VERSION_ID { get; set; }
}
