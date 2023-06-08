using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.CodeTableManagement.Application.DTO;

/// <summary>
/// 码表 CodeTableCultureDTO 类,为将多语信息实现行换列的中间转换类,类在内存中实现行列转换,转换后为CodeTableListDTO类。
/// </summary>
public class CodeTableCultureDTO : DTOBase
{
	public Guid CODE_TABLE_ID { get; set; }

	/// <summary>
	/// 父ID
	/// </summary>
	public Guid? PARENT_CODE_TABLE_ID { get; set; }

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
	/// Culture
	/// </summary>
	public string CULTURE { get; set; }

	/// <summary>
	/// StringKeyDesc
	/// </summary>
	public string STRING_KEY_DESC { get; set; }

	/// <summary>
	/// 是否删除
	/// </summary>
	public decimal? ISDEL { get; set; }
}
