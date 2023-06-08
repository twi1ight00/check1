using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.DTO;

[Serializable]
public class MenuDTO : DTOBase
{
	public Guid MENU_ID { get; set; }

	/// <summary>
	/// 菜单显示文本
	/// </summary>
	public string MENUTEXT { get; set; }

	public string MENU_URL { get; set; }

	public string TITLE_IMAGE_URL { get; set; }

	public decimal? IS_SHORT_CUT { get; set; }

	public string SHORT_CUT_IMAGE_URL { get; set; }

	public string SILVERLIGHT_ASSEMBLY { get; set; }

	public string SILVERLIGHT_IMAGE_URL { get; set; }

	/// <summary>
	/// 排序
	/// </summary>
	public decimal? SORT { get; set; }

	public decimal? OPEN_MODE { get; set; }

	public Guid? PARENTMENUID { get; set; }
}
