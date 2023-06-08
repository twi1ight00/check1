using System;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Module.Base.Infrastructure.Data;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Base.Infrastructure.TimeZone;

namespace Richfit.Garnet.Module.Base.Infrastructure.Logging;

/// <summary>
/// 业务操作日志条目，业务操作条目要写入数据库日志表
/// </summary>
[Serializable]
public class BusinessLogEntry
{
	/// <summary>
	/// Token
	/// </summary>
	public string Token { get; set; }

	/// <summary>
	/// 业务类型
	/// </summary>
	public string BusinessType { get; set; }

	/// <summary>
	/// 用户Id
	/// </summary>
	public string UserId { get; set; }

	/// <summary>
	/// 用户名
	/// </summary>
	public string UserName { get; set; }

	/// <summary>
	/// 组织机构ID
	/// </summary>
	public string OrgId { get; set; }

	/// <summary>
	/// IP地址
	/// </summary>
	public string IP { get; set; }

	/// <summary>
	/// 业务操作的时间
	/// </summary>
	public DateTime DoTime { get; set; }

	/// <summary>
	/// log数据
	/// </summary>
	public string Data { get; set; }

	/// <summary>
	/// 构造日志条目对象
	/// </summary>
	/// <param name="businessType">业务类型</param>
	public BusinessLogEntry(string businessType)
	{
		BusinessType = businessType;
		DoTime = TimeZoneHelper.Now;
		UserSessionInfo userInfo = SessionContext.UserInfo;
		if (userInfo != null)
		{
			UserId = userInfo.UserID.ToString();
			UserName = userInfo.UserName;
			OrgId = userInfo.BelongToOrgID.ToString();
			IP = SessionContext.IP;
			Token = Singleton<SessionManager>.Instance.GetCurrentSessionToken().ToString();
		}
		else
		{
			IP = "No IP";
			Token = "Expired";
		}
	}

	/// <summary>
	/// 构造日志条目对象
	/// </summary>
	/// <param name="businessType">业务类型</param>
	/// <param name="sessionId">会话ID</param>
	public BusinessLogEntry(string businessType, Guid sessionId)
	{
		BusinessType = businessType;
		DoTime = TimeZoneHelper.Now;
		IP = ((!string.IsNullOrEmpty(SessionContext.IP)) ? SessionContext.IP : "No IP");
		Token = sessionId.ToString();
		UserSessionInfo userInfo = Singleton<SessionManager>.Instance.GetUserSessionInfo(sessionId);
		if (userInfo != null)
		{
			UserId = userInfo.UserID.ToString();
			UserName = userInfo.UserName;
			OrgId = userInfo.BelongToOrgID.ToString();
		}
	}

	/// <summary>
	/// 生成将日志条目保存到数据库的SQL语句
	/// </summary>
	/// <param name="dbContext"></param>
	/// <returns></returns>
	public string ToInsertSql(IDBContext dbContext)
	{
		string id = Guid.NewGuid().ToString();
		string sql = "INSERT INTO SYS_LOG (LOG_ID, BUSINESS_TYPE, USER_ID, USER_NAME, ORG_ID, IP, DO_TIME, DATA,TOKEN) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}','{8}')";
		string userID = UserId;
		string orgID = OrgId;
		if (dbContext.GetDatabaseType() == DBType.Oracle)
		{
			sql = "INSERT INTO SYS_LOG (LOG_ID, BUSINESS_TYPE, USER_ID, USER_NAME, ORG_ID, IP, DO_TIME, DATA,TOKEN) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', timestamp'{6}', '{7}','{8}')";
			id = new Guid(id).ToOracleHex();
			if (userID.IsNotNull())
			{
				userID = new Guid(userID).ToOracleHex();
			}
			if (orgID.IsNotNull())
			{
				orgID = new Guid(orgID).ToOracleHex();
			}
		}
		return string.Format(sql, id, BusinessType, userID, UserName, orgID, IP, $"{DoTime:yyyy-MM-dd HH:mm:ss}", Data, Token);
	}
}
