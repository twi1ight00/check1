using System;
using System.Collections.Generic;
using Richfit.Garnet.Common.Email;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Components;

public class EmailService
{
	private IRepository<SYS_MAIL_LOG> repositoryEmail = null;

	public EmailService()
	{
		repositoryEmail = ServiceLocator.Instance.GetService<IRepository<SYS_MAIL_LOG>>();
	}

	/// <summary>
	/// 发送邮件
	/// </summary>
	/// <param name="objId">业务Id</param>
	/// <param name="extendId">扩展业务Id</param>
	/// <param name="serverIP"></param>
	/// <param name="mailToAddress"></param>
	/// <param name="mailFromAddress"></param>
	/// <param name="mailFromPWD"></param>
	/// <param name="mailSubject"></param>
	/// <param name="mailBody"></param>
	public void SendToEmail(Guid objId, Guid? extendId, string serverIP, string mailToAddress, string mailFromAddress, string mailFromPWD, string mailSubject, string mailBody)
	{
		try
		{
			SYS_MAIL_LOG sYS_MAIL_LOG = new SYS_MAIL_LOG();
			sYS_MAIL_LOG.OBJECT_ID = objId;
			sYS_MAIL_LOG.EXTEND_ID = extendId;
			sYS_MAIL_LOG.MAIL_BODY = mailBody;
			sYS_MAIL_LOG.MAIL_FROM_ADDRESS = mailFromAddress;
			sYS_MAIL_LOG.MAIL_FROM_PWD = mailFromPWD;
			sYS_MAIL_LOG.MAIL_TO_ADDRESS = mailToAddress;
			sYS_MAIL_LOG.MAIL_SUBJECT = mailSubject;
			sYS_MAIL_LOG.SERVER_IP = serverIP;
			SYS_MAIL_LOG log = sYS_MAIL_LOG;
			repositoryEmail.AddCommit(log);
			EmailManager.SendToEmail(serverIP, mailToAddress, mailFromAddress, mailFromPWD, mailSubject, mailBody);
		}
		catch (Exception)
		{
			throw;
		}
	}

	public bool IsSend(Guid guid)
	{
		int year = DateTime.Now.Year;
		int month = DateTime.Now.Month;
		IList<SYS_MAIL_LOG> query = repositoryEmail.FindAll((SYS_MAIL_LOG a) => a.OBJECT_ID == guid && a.CREATETIME.Year == year && a.CREATETIME.Month == month);
		return query != null && query.Count > 0;
	}
}
