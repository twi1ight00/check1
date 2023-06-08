using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.CodeTableManagement.Application.DTO;

/// <summary>
/// 码表DTO对象，与后端实体表对应类
/// </summary>
[Serializable]
public class CodeTableDTO : DTOBase
{
	public Guid CODE_TABLE_ID { get; set; }

	/// <summary>
	/// 编码
	/// </summary>
	public string CODE_ID { get; set; }

	/// <summary>
	/// 业务编码（1,2,3...）
	/// </summary>
	public string CODE_BUSINESS_NO { get; set; }

	/// <summary>
	/// 描述
	/// </summary>
	public string CODEDESC { get; set; }

	/// <summary>
	/// 排序
	/// </summary>
	public decimal? SORT { get; set; }

	public Guid? PARENT_CODE_TABLE_ID { get; set; }

	/// <summary>
	/// 是否删除
	/// </summary>
	public decimal? ISDEL { get; set; }

	/// <summary>
	/// 1启用2禁用
	/// </summary>
	public decimal? STATUS { get; set; }

	/// <summary>
	/// 父ID描述
	/// </summary>
	public string PARENTCODEDESC { get; set; }

	/// <summary>
	/// 创建人
	/// </summary>
	public Guid CREATOR { get; set; }

	/// <summary>
	/// 创建时间
	/// </summary>
	public DateTime CREATETIME { get; set; }

	/// <summary>
	/// 更新人
	/// </summary>
	public Guid MODIFIER { get; set; }

	/// <summary>
	/// 更新时间
	/// </summary>
	public DateTime MODIFYTIME { get; set; }
}
