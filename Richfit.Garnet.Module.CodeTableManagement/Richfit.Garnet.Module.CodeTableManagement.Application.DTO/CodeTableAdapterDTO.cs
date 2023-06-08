using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Localizing.Application.DTO;

namespace Richfit.Garnet.Module.CodeTableManagement.Application.DTO;

/// <summary>
/// 码表 CodeTableAdapterDTO类,为新增编辑时保存的总体对象,包含码表基础信息与对应的多语言列表.
/// </summary>
public class CodeTableAdapterDTO : DTOBase
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
	/// 排序
	/// </summary>
	public decimal? SORT { get; set; }

	/// <summary>
	/// 父ID
	/// </summary>
	public Guid? PARENT_CODE_TABLE_ID { get; set; }

	/// <summary>
	/// 启用禁用标识,1启用,2禁用
	/// </summary>
	public decimal? STATUS { get; set; }

	/// <summary>
	/// 多语言列表
	/// </summary>
	public IList<SYS_LOCALIZINGDTO> CULTURELIST { get; set; }
}
