using System;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.SystemManagement.Application.DTO;

/// <summary>
/// 用户和组织机构缓存类
/// </summary>
/// <remarks>
/// 用户和组织机构类,用来存放组织机构信息,用户信息，组织机构下级组织机构的数量，
/// 组织机构下用户的数量
/// </remarks>
[Serializable]
public class OrgDTO : DTOBase
{
	/// <summary>
	/// 组织机构ID
	/// </summary>
	public Guid ORG_ID { get; set; }

	/// <summary>
	/// 组织结构父ID
	/// </summary>
	public Guid? PARENT_ORG_ID { get; set; }

	/// <summary>
	/// 机构名称
	/// </summary>
	public string ORG_NAME { get; set; }

	/// <summary>
	/// 排序
	/// </summary>
	public decimal SORT { get; set; }

	/// <summary>
	/// 备注
	/// </summary>
	public string NOTE { get; set; }

	/// <summary>
	/// 是否删除0未删除1、为已删除
	/// </summary>
	public decimal ISDEL { get; set; }

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

	/// <summary>
	/// 节点类型，0表示机构；1表示人员
	/// </summary>
	public string TYPE { get; set; }

	/// <summary>
	/// 子节点数量
	/// </summary>
	public decimal CHILD_COUNT { get; set; }

	/// <summary>
	/// 父机构名称
	/// </summary>
	public string PARENT_ORG_NAME { get; set; }

	/// <summary>
	/// 用户与机构对应的唯一标识，1表示主，2表示次
	/// </summary>
	public decimal USER_IDENTITY_TYPE { get; set; }

	/// <summary>
	/// 节点层级路径
	/// </summary>
	public string PATH { get; set; }

	/// <summary>
	/// 机构子节点数量
	/// </summary>
	public decimal ORG_CHILD_COUNT { get; set; }

	/// <summary>
	/// 人员子节点数量
	/// </summary>
	public decimal USER_CHILD_COUNT { get; set; }

	/// <summary>
	/// 只在对象分布式缓存用到
	/// </summary>
	public CacheObjectStatus DTOStatus { get; set; }
}
