using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.SystemManagement.Application.DTO;

[Serializable]
public class SYS_ORGDTO : DTOBase
{
	public Guid ORG_ID { get; set; }

	public Guid? PARENT_ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	/// <summary>
	/// 父ID描述
	/// </summary>
	public string PARENT_ORG_NAME { get; set; }

	/// <summary>
	/// 排序
	/// </summary>
	public decimal SORT { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	/// <summary>
	/// 扩展字段1
	/// </summary>
	public string EXTEND1 { get; set; }

	/// <summary>
	/// 扩展字段2
	/// </summary>
	public string EXTEND2 { get; set; }

	/// <summary>
	/// 扩展字段3
	/// </summary>
	public string EXTEND3 { get; set; }

	/// <summary>
	/// 扩展字段4
	/// </summary>
	public string EXTEND4 { get; set; }

	/// <summary>
	/// 扩展字段5
	/// </summary>
	public string EXTEND5 { get; set; }
}
