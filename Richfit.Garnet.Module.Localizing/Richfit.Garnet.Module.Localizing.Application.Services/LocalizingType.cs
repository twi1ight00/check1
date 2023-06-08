namespace Richfit.Garnet.Module.Localizing.Application.Services;

/// <summary>
/// 针对数据的本地化多语类型
/// </summary>
public enum LocalizingType
{
	/// <summary>
	/// 菜单
	/// </summary>
	Menu,
	/// <summary>
	/// 码表
	/// </summary>
	CodeTable,
	/// <summary>
	/// 消息
	/// </summary>
	Message,
	/// <summary>
	/// 表格
	/// </summary>
	GridView,
	/// <summary>
	/// Label或Button等控件
	/// </summary>
	Control,
	/// <summary>
	/// 系统数据（用于数据库枚举类型多语翻译）
	/// </summary>
	SystemData,
	/// <summary>
	/// 对象验证信息，用于DTO或者POCO验证
	/// </summary>
	ObjectValidate
}
