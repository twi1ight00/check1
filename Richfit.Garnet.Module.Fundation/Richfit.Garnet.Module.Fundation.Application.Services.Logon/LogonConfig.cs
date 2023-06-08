using System.Collections.Generic;
using System.Globalization;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.Localizing.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Logon;

/// <summary>
/// 登陆配置信息
/// </summary>
public class LogonConfig
{
	/// <summary>
	/// 是否启用多语
	/// </summary>
	public bool EnableMultiLanguage { get; set; }

	/// <summary>
	/// 默认的语言区域设置
	/// </summary>
	public CultureInfo DefaultCulture { get; set; }

	/// <summary>
	/// 系统语言列表
	/// </summary>
	public IList<SYS_LANGUAGEDTO> AllCulture { get; set; }

	/// <summary>
	/// 获得DefaultCulture对应的登陆页多语信息
	/// </summary>
	public IList<SYS_LOCALIZINGDTO> AllLoginLocalizing { get; set; }

	/// <summary>
	/// 是否启用域验证
	/// </summary>
	public bool EnableDomain { get; set; }

	/// <summary>
	/// 系统域列表
	/// </summary>
	public IList<DomainDTO> AllDomain { get; set; }

	/// <summary>
	/// 是否启用时区偏移
	/// </summary>
	public bool EnableTimeOffset { get; set; }
}
