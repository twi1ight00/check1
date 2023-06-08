namespace Richfit.Garnet.Module.Base.Infrastructure.ExternalAccess;

/// <summary>
/// 访问配置
/// </summary>
public class AccessConfig
{
	/// <summary>
	/// 配置主键信息
	/// </summary>
	public string ConfigKey { get; set; }

	/// <summary>
	/// 访问信息
	/// </summary>
	public AccessInfo AccessInfo { get; set; }

	/// <summary>
	/// 访问成功返回的Token
	/// </summary>
	public string Token { get; set; }

	/// <summary>
	/// 是否握手标识，1代表握手，0代表不握手
	/// </summary>
	public string IsShake { get; set; }
}
