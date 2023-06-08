using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.CodeTableManagement.Application.DTO;

/// <summary>
/// 码表ListDTO对象，用于前端List展现的对应类
/// </summary>
public class CodeTableListDTO : DTOBase
{
	public Guid CODE_TABLE_ID { get; set; }

	public Guid? PARENT_CODE_TABLE_ID { get; set; }

	/// <summary>
	/// ParentCodeID
	/// </summary>
	public string PARENTCODEID { get; set; }

	/// <summary>
	/// 编码
	/// </summary>
	public string CODE_ID { get; set; }

	/// <summary>
	/// 业务编码（1,2,3...）
	/// </summary>
	public string CODE_BUSINESS_NO { get; set; }

	/// <summary>
	/// Parent名称
	/// </summary>
	public string PARENTNAME { get; set; }

	/// <summary>
	/// 排序
	/// </summary>
	public decimal? SORT { get; set; }

	/// <summary>
	/// 1启用2禁用
	/// </summary>
	public decimal? STATUS { get; set; }

	/// <summary>
	/// 中文名称
	/// </summary>
	public string ZH_CN { get; set; }

	/// <summary>
	/// 英文名称
	/// </summary>
	public string EN_US { get; set; }

	/// <summary>
	/// 俄文名称
	/// </summary>
	public string RU_RU { get; set; }
}
