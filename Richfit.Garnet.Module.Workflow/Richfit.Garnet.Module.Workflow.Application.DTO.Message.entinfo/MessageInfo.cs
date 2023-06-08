using System;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Message.entinfo;

[Serializable]
public class MessageInfo
{
	/// <summary>
	/// 格式XXX-XXX-XXX-XXXXX
	///
	/// </summary>
	public string Sn { get; set; }

	/// <summary>
	/// md5(sn+password) 32位大写密文
	/// </summary>
	public string Pwd { get; set; }

	/// <summary>
	/// 手机号，群发使用英文,逗号分割开
	/// </summary>
	public string[] Mobile { get; set; }

	/// <summary>
	/// 短信内容，支持长短信，具体看接口文档
	/// </summary>
	public string Content { get; set; }

	/// <summary>
	/// 例如：123（默认置空）
	/// </summary>
	public string Ext { get; set; }

	/// <summary>
	/// 例如：2010-12-29 16:27:03（非定时置空）
	/// </summary>
	public DateTime? stime { get; set; }

	/// <summary>
	/// 最长18位，只能是数字或者 字母 或者数字+字母的组合，
	/// 不填写返回短信接口生成的rrid
	/// </summary>
	public string Rrid { get; set; }

	/// <summary>
	/// 发送时间
	/// </summary>
	public DateTime SendTime { get; set; }

	public MessageInfo()
	{
		SendTime = DateTime.Now;
		stime = null;
		Ext = "";
		Rrid = "";
	}
}
