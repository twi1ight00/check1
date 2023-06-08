using System;
using System.Security.Cryptography;
using System.Text;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Workflow.Application.DTO.Message.entinfo;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Messagge.entinfo;

namespace Richfit.Garnet.Module.Workflow.Application.Services;

public class MessageService
{
	private IRepository<SYS_MESSAGE_LOG> repositoryMessage = null;

	private static readonly object syncRoot = new object();

	private static WebServiceSoapClient instance = null;

	/// <summary>
	/// 为了以后调用接口其他方法而预留的实例
	/// </summary>
	private static WebServiceSoapClient Instance
	{
		get
		{
			if (instance == null)
			{
				lock (syncRoot)
				{
					if (instance == null)
					{
						instance = new WebServiceSoapClient();
					}
				}
			}
			return instance;
		}
	}

	public MessageService()
	{
		repositoryMessage = ServiceLocator.Instance.GetService<IRepository<SYS_MESSAGE_LOG>>();
	}

	/// <summary>
	/// 发送短信消息
	/// </summary>
	/// <param name="func">短信内容</param>
	/// <returns>rrid</returns>
	public void SendToMessage(Func<MessageInfo> func, Guid objId, Guid? extendId, string serverIP, string Browser)
	{
		MessageInfo info = func();
		string resultRRID = "";
		string sTime = "";
		if (info.stime.HasValue)
		{
			sTime = info.stime.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss");
		}
		string phones = "";
		phones = GetMobile(info.Mobile);
		string pwdMd5 = GetMd5(info.Sn + info.Pwd);
		resultRRID = Instance.mt(info.Sn, pwdMd5, phones, info.Content, info.Ext, sTime, info.Rrid);
		for (int i = 0; i < info.Mobile.Length; i++)
		{
			SYS_MESSAGE_LOG sYS_MESSAGE_LOG = new SYS_MESSAGE_LOG();
			sYS_MESSAGE_LOG.IP = serverIP;
			sYS_MESSAGE_LOG.CREATE_TIME = DateTime.Now;
			sYS_MESSAGE_LOG.SENDTIME = info.SendTime;
			sYS_MESSAGE_LOG.BROWSER = Browser;
			sYS_MESSAGE_LOG.RRID = resultRRID;
			sYS_MESSAGE_LOG.SN = info.Sn;
			sYS_MESSAGE_LOG.PWD = info.Pwd;
			sYS_MESSAGE_LOG.STIME = info.stime;
			sYS_MESSAGE_LOG.CONTENT = info.Content;
			sYS_MESSAGE_LOG.EXT = info.Ext;
			sYS_MESSAGE_LOG.MOBILE = info.Mobile[0];
			sYS_MESSAGE_LOG.OBJECT_ID = objId.ToString();
			sYS_MESSAGE_LOG.EXTEND_ID = (extendId.HasValue ? extendId.ToString() : "");
			SYS_MESSAGE_LOG model = sYS_MESSAGE_LOG;
			repositoryMessage.AddCommit(model);
		}
	}

	/// <summary>
	/// 处理手机号数组
	/// </summary>
	/// <param name="phoneArray"></param>
	/// <returns></returns>
	private string GetMobile(string[] phoneArray)
	{
		StringBuilder mobileBuff = new StringBuilder();
		foreach (string item in phoneArray)
		{
			if (mobileBuff.Length != 0)
			{
				mobileBuff.Append(",");
			}
			mobileBuff.Append(item);
		}
		return mobileBuff.ToString();
	}

	/// <summary>
	/// Md5 大写加密
	/// </summary>
	/// <param name="content">加密内容</param>
	/// <returns>加密结果</returns>
	private string GetMd5(string content)
	{
		MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
		byte[] hashedDataBytes = md5Hasher.ComputeHash(Encoding.GetEncoding("gb2312").GetBytes(content));
		StringBuilder tmp = new StringBuilder();
		byte[] array = hashedDataBytes;
		foreach (byte i in array)
		{
			tmp.Append(i.ToString("x2"));
		}
		return tmp.ToString().ToUpper();
	}
}
