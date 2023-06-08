namespace Richfit.Garnet.Module.Workflow.Application.Enums;

public class STATUS
{
	/// <summary>
	/// 是否编辑表单
	/// </summary>
	public const string ENABLE_EDIT_ATTACHMENT = "0|2";

	public const string ENABLE_ATTACHMENT = "2|2";

	/// <summary>
	/// 是否瑞信可见
	/// </summary>
	public const string ENABLE_SHOW = "4|1";

	public const string IS_COUNTERSIGN = "5|1";

	/// <summary>
	/// 审批意见必填
	/// </summary>
	public const string MUST_SUGGESTION = "6|2";

	/// <summary>
	/// 是否需要签名
	/// </summary>
	public const string ENABLE_SIGNATURE = "8|2";

	/// <summary>
	/// 是否连续选人
	/// </summary>
	public const string START_SELECT_USER = "9|1";

	/// <summary>
	/// 是否终止流程
	/// </summary>
	public const string ENABLE_TERMINATE_FLOW = "10|1";

	/// <summary>
	/// 是否终止流程
	/// </summary>
	public const string ENABLE_SEND_MESSAGE = "11|1";

	/// <summary>
	/// 合并审批节点
	/// </summary>
	public const string IS_MERGR = "12|2";

	/// <summary>
	/// 是否转批
	/// </summary>
	public const string ENABLE_TRANSFER = "14|2";

	/// <summary>
	/// 是否传阅
	/// </summary>
	public const string ENABLE_CIRCULATED = "16|2";

	/// <summary>
	/// 是否归档
	/// </summary>
	public const string ENABLE_FILED = "18|2";

	/// <summary>
	/// 是否人工决策
	/// </summary>
	public const string IS_ARTIFICIAL_DECISION = "20|2";

	/// <summary>
	/// 选人方式
	/// </summary>
	public const string IS_AUTOMATIC = "22|2";

	/// <summary>
	/// 完成方式
	/// </summary>
	public const string FINISH_TYPE = "24|2";

	/// <summary>
	/// 在线公文打开方式
	/// </summary>
	public const string OPEN_MODE_TYPE = "26|4";

	/// <summary>
	/// 是否限制上传附件
	/// </summary>
	public const string IS_UPLOAD_AUTOMATIC = "30|1";
}
