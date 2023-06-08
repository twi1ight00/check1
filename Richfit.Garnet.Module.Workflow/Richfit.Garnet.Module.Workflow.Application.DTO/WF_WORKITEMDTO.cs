using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

public class WF_WORKITEMDTO : DTOBase
{
	public Guid WORKITEM_ID { get; set; }

	public Guid ACTIVITY_ID { get; set; }

	public string ACTIVITY_NAME { get; set; }

	public decimal? ACTIVITY_TYPE { get; set; }

	public Guid? INSTANCE_ID { get; set; }

	public Guid? PARENT_WORKITEM_ID { get; set; }

	public Guid? CHILD_INSTANCE_ID { get; set; }

	public Guid? SENDER_USER_ID { get; set; }

	public string WORKITEM_NAME { get; set; }

	public string SENDER_USER_NAME { get; set; }

	public string SEND_TOKEN { get; set; }

	public DateTime? SEND_TIME { get; set; }

	public decimal? WORKITEM_RUN_STATE { get; set; }

	public decimal? HANDLE_RESULT { get; set; }

	public decimal? ITEM_TYPE { get; set; }

	public decimal? GENERATE_TYPE { get; set; }

	public decimal? STATUS { get; set; }

	public decimal? CLIENT_TYPE { get; set; }

	public decimal ISDEL { get; set; }

	public decimal ISMOBILE { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public List<WF_WORKITEM_HANDLERDTO> WF_WORKITEM_HANDLER { get; set; }

	/// <summary>
	/// 工作项接收用户ID
	/// </summary>
	public Guid USER_ID { get; set; }

	/// <summary>
	/// 工作项接收用户名称
	/// </summary>
	public string USER_NAME { get; set; }

	/// <summary>
	/// 路径
	/// </summary>
	public string FORM_PATH_URL { get; set; }

	/// <summary>
	/// 实例名称
	/// </summary>
	public string INSTANCE_NAME { get; set; }

	/// <summary>
	/// 模板ID
	/// </summary>
	public Guid? PACKAGE_ID { get; set; }

	/// <summary>
	/// 模板ID
	/// </summary>
	public string PACKAGE_NAME { get; set; }

	/// <summary>
	/// 模板ID
	/// </summary>
	public Guid? TEMPLATE_ID { get; set; }

	/// <summary>
	/// 发起人
	/// </summary>
	public string START_USER_NAME { get; set; }

	/// <summary>
	/// 发起时间
	/// </summary>
	public DateTime? START_TIME { get; set; }

	/// <summary>
	/// 单据类型
	/// </summary>
	public string TEMPLATE_NAME { get; set; }

	/// <summary>
	/// 模版编码
	/// </summary>
	public string TEMPLATE_CODE { get; set; }

	/// <summary>
	/// 单据类型
	/// </summary>
	public string IMGURL { get; set; }

	/// <summary>
	/// 申请部门ID
	/// </summary>
	public Guid? ORG_ID { get; set; }

	/// <summary>
	/// 申请部门名称
	/// </summary>
	public string ORG_NAME { get; set; }

	public decimal? RUN_STATE { get; set; }

	/// <summary>
	/// 在线公文
	/// </summary>
	public string FILE_NAME { get; set; }

	/// <summary>
	/// 在线公文
	/// </summary>
	public string SUBJECT { get; set; }

	public int? ATTCOUNT { get; set; }

	public decimal? SORT { get; set; }

	public string OLDURL { get; set; }

	public string OLDSYSTEM { get; set; }
}
