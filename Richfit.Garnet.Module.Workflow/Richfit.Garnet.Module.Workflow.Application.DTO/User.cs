using System;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

[Serializable]
public class User
{
	/// <summary>
	/// 当前用户ID
	/// </summary>
	public Guid CURRENT_USER_ID { get; set; }

	/// <summary>
	/// 当前用户名称
	/// </summary>
	public string CURRENT_USER_NAME { get; set; }

	/// <summary>
	/// 被代理用户ID
	/// </summary>
	public Guid? PROXY_USER_ID { get; set; }

	/// <summary>
	/// 被代理用户名称
	/// </summary>
	public string PROXY_USER_NAME { get; set; }

	/// <summary>
	/// 当前用户所在机构ID
	/// </summary>
	public Guid? CURRENT_ORG_ID { get; set; }

	/// <summary>
	/// 当前用户所在机构名称
	/// </summary>
	public string CURRENT_ORG_NAME { get; set; }

	/// <summary>
	/// 被代理用户所在机构ID
	/// </summary>
	public Guid? PROXY_ORG_ID { get; set; }

	/// <summary>
	/// 被代理用户所在机构名称
	/// </summary>
	public string PROXY_ORG_NAME { get; set; }

	public decimal? CLIENT_TYPE { get; set; }
}
