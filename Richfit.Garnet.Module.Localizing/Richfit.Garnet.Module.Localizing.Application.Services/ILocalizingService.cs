using System.Collections.Generic;
using Richfit.Garnet.Module.Localizing.Application.DTO;

namespace Richfit.Garnet.Module.Localizing.Application.Services;

/// <summary>
/// 多语服务接口定义
/// </summary>
public interface ILocalizingService
{
	/// <summary>
	/// 获取配置的所有语言类型
	/// </summary>
	/// <returns></returns>
	IList<SYS_LANGUAGEDTO> GetAllLanguage();

	/// <summary>
	/// 获得多语表中的所有记录
	/// </summary>
	/// <returns></returns>
	IList<SYS_LOCALIZINGDTO> GetAllLocalizing();

	/// <summary>
	/// 获取某多语类型某键值的多语信息
	/// </summary>
	/// <param name="localizingType"></param>
	/// <param name="stringKey"></param>
	/// <returns></returns>
	IList<SYS_LOCALIZINGDTO> GetLocalizingByCondition(LocalizingType localizingType, string stringKey);

	/// <summary>
	/// 新增多语信息
	/// </summary>
	/// <param name="localizingDTO">多语信息DTO对象</param>
	/// <returns>返回新增的多语DTO对象</returns>
	SYS_LOCALIZINGDTO AddLocalizing(SYS_LOCALIZINGDTO localizingDTO);

	/// <summary>
	/// 批量新增多语信息
	/// </summary>
	/// <param name="localizingDTOList"></param>
	IList<SYS_LOCALIZINGDTO> AddLocalizing(IList<SYS_LOCALIZINGDTO> localizingDTOList);

	/// <summary>
	/// 删除码表多语信息
	/// </summary>
	/// <param name="stringKey">码表多语对应的StringKey</param>
	void RemoveCodeTableLocalizingByStringKey(string stringKey);
}
