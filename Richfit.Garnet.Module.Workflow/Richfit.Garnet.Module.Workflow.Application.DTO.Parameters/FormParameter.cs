using System;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

/// <summary>
///
/// </summary>
public class FormParameter : QueryObjectBase
{
	/// <summary>
	/// 表单名称
	/// </summary>
	[ParameterConfig("FORM_NAME", "string", " Like ")]
	public string FORM_NAME { get; set; }

	/// <summary>
	/// 所属组织机构
	/// </summary>
	[ParameterConfig("ORG_ID", "guid", " = ")]
	public string ORG_ID { get; set; }

	/// <summary>
	/// URL
	/// </summary>
	[ParameterConfig("URL", "string", " Like ")]
	public string URL { get; set; }

	/// <summary>
	/// 版本ID
	/// </summary>
	[ParameterConfig("VERSION_ID", "guid", " = ")]
	public Guid? VERSION_ID { get; set; }

	/// <summary>
	/// 版本ID
	/// </summary>
	[ParameterConfig("FORM_ID", "guid", " = ")]
	public Guid? FORM_ID { get; set; }
}
