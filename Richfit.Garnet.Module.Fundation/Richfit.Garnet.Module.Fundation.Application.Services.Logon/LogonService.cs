using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.LDAP;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Security.JScript;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.Fundation.Application.Services.Domain;
using Richfit.Garnet.Module.Fundation.Domain.Models;
using Richfit.Garnet.Module.Fundation.Domain.Specifications;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Logon;

/// <summary>
/// 登陆服务接口实现
/// </summary>
public class LogonService : ServiceBase, ILogonService
{
	private class HRInfo
	{
		public int workage;

		public int year;
	}

	/// <summary>
	/// 登陆注入服务
	/// </summary>
	public ILogonInject LogonInject { get; set; }

	public string GetDomainByLogonName(string LogonName)
	{
		if (LogonName != string.Empty)
		{
			QueryCondition userCondition = new QueryCondition();
			QueryItem userItem = QueryItem.GetQueryItem("LOGON_NAME", LogonName, "string", " = ");
			userCondition.Add(userItem);
			QueryResult<DomainDTO> res = SqlQueryResult<DomainDTO>("GetDomainByLogonName", userCondition);
			if (res.List.Count != 0)
			{
				return res.List[0].DOMAIN_ADDRESS;
			}
		}
		return string.Empty;
	}

	public LogonContext Login(LogonDTO loginDTO)
	{
		LogonContext context = null;
		string domainName = loginDTO.DOMAIN_NAME;
		string logonName = loginDTO.LOGON_NAME.Trim();
		string culture = loginDTO.CULTURE;
		string timeOffset = loginDTO.TIMEOFFSET;
		int isMobile = loginDTO.IS_MOBILE;
		string extend1 = loginDTO.DEVICEINFO;
		string encryptedKey = loginDTO.ENCRYPTEDKEY;
		byte[] encryptedKeyData = ConvertHexToBytes(encryptedKey);
		string rsaPrivateKey = (SystemCacheBus.Instance.Get(loginDTO.SECRETTOKEN.Trim()) ?? string.Empty).ToString();
		if (!string.IsNullOrWhiteSpace(rsaPrivateKey))
		{
			string decryptedKey;
			using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
			{
				rsa.FromXmlString(rsaPrivateKey);
				byte[] decryptedKeyData = rsa.Decrypt(encryptedKeyData, fOAEP: false);
				decryptedKey = Encoding.ASCII.GetString(decryptedKeyData);
			}
			string password = AesCtrJs.decrypt(loginDTO.PASSWORD, decryptedKey, 256).ToString();
			LogonContext logonContext = new LogonContext();
			logonContext.DomainName = domainName;
			logonContext.LogonName = logonName;
			logonContext.Password = password;
			logonContext.Culture = culture;
			logonContext.TimeOffset = timeOffset;
			logonContext.IP = SessionContext.IP;
			logonContext.IsMobile = isMobile;
			context = logonContext;
			if (LogonInject != null)
			{
				LogonInject.BeforeLogin(context);
			}
			if (context.Success)
			{
				UserDTO userInfo = null;
				if (ConfigurationManager.System.Settings.EnableDomain && logonName != "admin")
				{
					string encryptPassword = password.EncryptText().Base64Encode();
					string superpassword = ConfigurationManager.System.Settings.GetSetting<string>("superpassword") ?? string.Empty;
					if (!string.IsNullOrWhiteSpace(superpassword) && superpassword == encryptPassword)
					{
						domainName = null;
					}
					else
					{
						string LdapServer = ConfigurationManager.System.Settings.GetSetting<string>("LdapServer") ?? string.Empty;
						string[] LdapServerArray = LdapServer.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
						if (!string.IsNullOrWhiteSpace(LdapServerArray[0]))
						{
							domainName = LdapServerArray[0];
						}
					}
				}
				if (!string.IsNullOrWhiteSpace(domainName))
				{
					DomainDTO domain = DomainManager.GetDomainByAddress("cnpc.com.cn");
					if (domain != null && (context.IsAccountExists = LDAPHelper.UserExists(domainName, domain.DOMAIN_ACCOUNT, domain.DOMAIN_PWD.Base64Decode().DecryptText(), logonName)))
					{
						bool isAuthentication = LDAPHelper.AuthenticateUser(domainName, logonName, password);
						ServiceBase.log.Debug(string.Format("用户{0}域验证{1}通过", logonName, isAuthentication ? "已" : "没"));
						if (isAuthentication)
						{
							userInfo = GetUserInfo(logonName, password, LogonType.Domain, isMobile);
							if (isMobile == 1 && extend1 != null && extend1 != "")
							{
								if (userInfo.EXTEND1 != null && userInfo.EXTEND1 != "" && userInfo.EXTEND2 != null && userInfo.EXTEND2 != "")
								{
									if (userInfo.EXTEND1 != extend1 && userInfo.EXTEND2 != extend1)
									{
										context.Success = false;
										context.Code = "Public.E_0102";
										context.Messages = new string[1] { "登录设备信息不匹配,如果换手机端登录,请在原设备上解绑" };
										return context;
									}
								}
								else if ((userInfo.EXTEND1 != null && userInfo.EXTEND1 != "") || (userInfo.EXTEND2 != null && userInfo.EXTEND2 != ""))
								{
									if (userInfo.EXTEND1 != null && userInfo.EXTEND1 != "" && userInfo.EXTEND1 != extend1)
									{
										saveDeviceInfo(userInfo.USER_ID, extend1, userInfo);
									}
									if (userInfo.EXTEND2 != null && userInfo.EXTEND2 != "" && userInfo.EXTEND2 != extend1)
									{
										saveDeviceInfo(userInfo.USER_ID, extend1, userInfo);
									}
								}
								else
								{
									saveDeviceInfo(userInfo.USER_ID, extend1, userInfo);
								}
							}
							if (userInfo != null)
							{
								userInfo.USER_PASSWORD = password.EncryptText().Base64Encode();
							}
						}
						else
						{
							ServiceBase.log.Debug($"用户{logonName}在{domainName}域验中不存在");
						}
					}
				}
				else if (context.IsAccountExists = UserAccountIsExists(logonName))
				{
					string encryptPassword = password.EncryptText().Base64Encode();
					string superpassword = ConfigurationManager.System.Settings.GetSetting<string>("superpassword") ?? string.Empty;
					userInfo = ((!ConfigurationManager.System.Settings.IsOpenSuperpassword || string.IsNullOrWhiteSpace(superpassword) || !(superpassword == encryptPassword)) ? GetUserInfo(logonName, encryptPassword, LogonType.System, isMobile) : GetUserInfo(logonName, password, LogonType.Super, isMobile));
				}
				if (userInfo != null)
				{
					ServiceBase.log.Debug($"用户{userInfo.DISPLAY_NAME}{userInfo.LOGON_NAME}查找到数据库用户信息，禁用状态为{userInfo.IS_FORBIDDEN}");
					if (userInfo.IS_FORBIDDEN == 0m)
					{
						if (LogonInject != null)
						{
							context.UserInfo = userInfo;
							LogonInject.AfterLogin(context);
							if (context.Success)
							{
								UserSessionInfo userSessionInfo = ToSessionInfo(userInfo, culture, timeOffset, isMobile);
								context.Token = Singleton<SessionManager>.Instance.AddSession(userSessionInfo);
							}
						}
						else
						{
							UserSessionInfo userSessionInfo = ToSessionInfo(userInfo, culture, timeOffset, isMobile);
							context.Token = Singleton<SessionManager>.Instance.AddSession(userSessionInfo);
						}
					}
					else
					{
						context.IsForbidden = true;
						context.Token = Guid.Empty;
					}
				}
				else
				{
					ServiceBase.log.Debug($"登陆用户{logonName}没有查到数据库信息！");
				}
			}
		}
		else
		{
			LogonContext logonContext2 = new LogonContext();
			logonContext2.DomainName = "";
			logonContext2.LogonName = "";
			logonContext2.IP = "";
			context = logonContext2;
			context.Success = false;
			context.Code = "Public.E_0009";
		}
		return context;
	}

	public Guid Login(string domainName, string logonName, string password, int isMobile)
	{
		UserDTO userInfo = null;
		if (!string.IsNullOrWhiteSpace(domainName))
		{
			bool isAuthentication = LDAPHelper.AuthenticateUser(domainName, logonName.Trim(), password);
			ServiceBase.log.Debug(string.Format("用户{0}域验证{1}通过", logonName.Trim(), isAuthentication ? "已" : "没"));
			if (isAuthentication)
			{
				userInfo = GetSimpleUserInfo(logonName.Trim(), password, LogonType.Domain);
				if (userInfo != null)
				{
					userInfo.USER_PASSWORD = password.EncryptText().Base64Encode();
				}
			}
			else
			{
				string encryptPassword = password.EncryptText().Base64Encode();
				userInfo = GetSimpleUserInfo(logonName.Trim(), encryptPassword, LogonType.System);
			}
		}
		else
		{
			string encryptPassword = password.EncryptText().Base64Encode();
			userInfo = GetSimpleUserInfo(logonName.Trim(), encryptPassword, LogonType.System);
		}
		if (userInfo != null)
		{
			ServiceBase.log.Debug($"用户{userInfo.DISPLAY_NAME}{userInfo.LOGON_NAME}查找到数据库用户信息");
			UserSessionInfo userSessionInfo = ToSessionInfo(userInfo, null, null, isMobile);
			return Singleton<SessionManager>.Instance.AddSession(userSessionInfo);
		}
		ServiceBase.log.Debug($"登陆用户{logonName.Trim()}没有查到数据库信息！");
		return Guid.Empty;
	}

	public void LogOut()
	{
		Singleton<SessionManager>.Instance.RemoveSession();
	}

	/// <summary>
	/// 判断用户帐号是否存在
	/// </summary>
	/// <param name="logonName">用户登录名</param>
	/// <returns>是否存在标志</returns>
	public bool UserAccountIsExists(string logonName)
	{
		ISpecification<SYS_USER> specification = UserSpecifications.AccountExistsSpecification(logonName);
		IRepository<SYS_USER> userRepository = ServiceLocator.Instance.GetService<IRepository<SYS_USER>>();
		return userRepository.Exists(specification);
	}

	public VersionInfoDTO GetVersionInfo(string OS)
	{
		QueryCondition conditions = new QueryCondition();
		conditions.QueryItems.Add(new QueryItem
		{
			Key = "OS",
			Method = " = ",
			Value = OS,
			Type = "string"
		});
		QueryResult<VersionInfoDTO> result = SqlQueryResult<VersionInfoDTO>("GetVersionInfo", conditions);
		if (result.List.Count > 0)
		{
			return result.List[0];
		}
		return null;
	}

	public void UpdateHRInfo(Guid userID)
	{
		try
		{
			DateTime dt = DateTime.Now;
			SqlRepository repository = new SqlRepository(null);
			string sql = string.Concat("SELECT ORIGINAL_UNIT FROM HR_EMPLOYEE WHERE USER_ID =f_guidtoraw('", userID, "')");
			IList<int> List = repository.ExecuteQuery<int>(sql, new object[0]);
			if (List.Count <= 0 || List[0] != DateTime.Now.AddYears(-1).Year)
			{
				return;
			}
			ServiceBase.log.Info("开始更新员工工龄和应休天数！");
			int vacationDays = 0;
			sql = string.Concat("SELECT WORK_AGE FROM HR_EMPLOYEE WHERE USER_ID =f_guidtoraw('", userID, "')");
			List = repository.ExecuteQuery<int>(sql, new object[0]);
			if (List.Count > 0)
			{
				int workage = List[0];
				if (workage >= 1 && workage < 10)
				{
					vacationDays = 5;
				}
				else if (workage >= 10 && workage < 20)
				{
					vacationDays = 10;
				}
				else if (workage >= 20)
				{
					vacationDays = 15;
				}
				sql = string.Concat("UPDATE HR_EMPLOYEE SET VACATION_DAYS=", vacationDays, ",WORK_AGE=WORK_AGE+1,ORIGINAL_UNIT='", DateTime.Now.Year, "' WHERE USER_ID =f_guidtoraw('", userID, "')");
				repository.ExecuteCommand(sql);
				ServiceBase.log.Info("更新员工工龄和应休天数结束！");
			}
		}
		catch (Exception)
		{
			ServiceBase.log.Info("尝试连接数据库失败！");
		}
	}

	/// <summary>
	/// 查询登陆用户信息
	/// </summary>
	/// <param name="logonName">用户登录名</param>
	/// <param name="password">用户密码</param>
	/// <param name="type">用户类型</param>
	/// <returns>用户信息</returns>
	private UserDTO GetUserInfo(string logonName, string password, LogonType type, int isMobile)
	{
		ISpecification<SYS_USER> specification = UserSpecifications.LogonSpecification(logonName, password, type);
		IRepository<SYS_USER> userRepository = ServiceLocator.Instance.GetService<IRepository<SYS_USER>>();
		UserDTO userDTO = null;
		SYS_USER user = userRepository.Find(specification);
		if (user != null)
		{
			userDTO = user.AdaptAsDTO<UserDTO>();
			SYS_USER_ORG userOrg = user.SYS_USER_ORG.Where(delegate(SYS_USER_ORG x)
			{
				decimal? uSER_IDENTITY_TYPE = x.USER_IDENTITY_TYPE;
				return uSER_IDENTITY_TYPE.GetValueOrDefault() == 1m && uSER_IDENTITY_TYPE.HasValue;
			}).FirstOrDefault();
			if (userOrg != null)
			{
				userDTO.ORG_ID = userOrg.ORG_ID;
			}
			userDTO.IsMobile = isMobile;
		}
		return userDTO;
	}

	private void saveDeviceInfo(Guid USER_ID, string deviceinfo, UserDTO userinfo)
	{
		try
		{
			SqlRepository repository = new SqlRepository(null);
			string sql = "";
			if (userinfo.EXTEND1 == null || userinfo.EXTEND1 == "")
			{
				sql = string.Concat("UPDATE SYS_USER SET EXTEND1 ='", deviceinfo, "' WHERE USER_ID =f_guidtoraw('", USER_ID, "')");
			}
			else if (userinfo.EXTEND2 == null || userinfo.EXTEND2 == "")
			{
				sql = string.Concat("UPDATE SYS_USER SET EXTEND2 ='", deviceinfo, "' WHERE USER_ID =f_guidtoraw('", USER_ID, "')");
			}
			repository.ExecuteCommand(sql);
		}
		catch (Exception)
		{
			ServiceBase.log.Info("尝试连接数据库失败！");
		}
	}

	public bool unbind(Guid USER_ID, string DEVICEINFO)
	{
		try
		{
			if (DEVICEINFO == null || DEVICEINFO == "" || DEVICEINFO == string.Empty)
			{
				return false;
			}
			SqlRepository repository = new SqlRepository(null);
			string sql1 = string.Concat("SELECT * FROM SYS_USER WHERE ISDEL=0 AND USER_ID =f_guidtoraw('", USER_ID, "') AND ( EXTEND1='", DEVICEINFO, "' OR  EXTEND2='", DEVICEINFO, "')");
			IList<SYS_USER> List = repository.ExecuteQuery<SYS_USER>(sql1, new object[0]);
			string sql2 = "";
			if (List.Count == 0)
			{
				return false;
			}
			sql2 = ((!List[0].EXTEND1.Equals(DEVICEINFO)) ? string.Concat("UPDATE SYS_USER SET EXTEND2=null WHERE USER_ID = f_guidtoraw('", USER_ID, "')") : string.Concat("UPDATE SYS_USER SET EXTEND1=null WHERE USER_ID = f_guidtoraw('", USER_ID, "')"));
			repository.ExecuteCommand(sql2);
		}
		catch (Exception)
		{
			ServiceBase.log.Info("尝试连接数据库失败！");
			return false;
		}
		return true;
	}

	private UserDTO GetSimpleUserInfo(string logonName, string password, LogonType type)
	{
		ISpecification<SYS_USER> specification = UserSpecifications.LogonSpecification(logonName, password, type);
		specification = specification.And(new ExpressionSpecification<SYS_USER>((SYS_USER x) => x.IS_FORBIDDEN == (decimal?)0m));
		IRepository<SYS_USER> userRepository = ServiceLocator.Instance.GetService<IRepository<SYS_USER>>();
		UserDTO userDTO = null;
		SYS_USER user = userRepository.Find(specification);
		if (user != null)
		{
			userDTO = user.AdaptAsDTO<UserDTO>();
			SYS_USER_ORG userOrg = user.SYS_USER_ORG.Where(delegate(SYS_USER_ORG x)
			{
				decimal? uSER_IDENTITY_TYPE = x.USER_IDENTITY_TYPE;
				return uSER_IDENTITY_TYPE.GetValueOrDefault() == 1m && uSER_IDENTITY_TYPE.HasValue;
			}).FirstOrDefault();
			if (userOrg != null)
			{
				userDTO.ORG_ID = userOrg.ORG_ID;
			}
		}
		return userDTO;
	}

	private UserSessionInfo ToSessionInfo(UserDTO userInfo, string culture, string timeOffset, int isMobile)
	{
		UserSessionInfo userSessionInfo = new UserSessionInfo();
		if (!string.IsNullOrEmpty(culture))
		{
			userSessionInfo.LanguageCulture = culture;
		}
		else
		{
			userSessionInfo.LanguageCulture = ConfigurationManager.System.Settings.DefaultCulture.Name;
		}
		userSessionInfo.LogonName = userInfo.LOGON_NAME;
		userSessionInfo.IsMobile = userInfo.IsMobile;
		userSessionInfo.LogonPassword = userInfo.USER_PASSWORD;
		userSessionInfo.UserID = userInfo.USER_ID;
		userSessionInfo.UserName = userInfo.DISPLAY_NAME;
		userSessionInfo.EXTEND1 = userInfo.EXTEND1;
		decimal? uSER_TYPE = userInfo.USER_TYPE;
		userSessionInfo.IsSuperUser = uSER_TYPE.GetValueOrDefault() == 2m && uSER_TYPE.HasValue;
		if (string.IsNullOrEmpty(timeOffset))
		{
			timeOffset = "0";
		}
		userSessionInfo.TimeOffset = int.Parse(timeOffset);
		userSessionInfo.BelongToOrgID = userInfo.ORG_ID;
		userSessionInfo.IP = SessionContext.IP;
		return userSessionInfo;
	}

	private byte[] ConvertHexToBytes(string hex)
	{
		if (string.IsNullOrEmpty(hex))
		{
			return new byte[0];
		}
		byte[] bytes = new byte[hex.Length / 2];
		for (int i = 0; i < hex.Length / 2; i++)
		{
			bytes[i] = (byte)((ParseHex(hex[i * 2]) << 4) + ParseHex(hex[i * 2 + 1]));
		}
		return bytes;
	}

	private int ParseHex(char c)
	{
		if ('A' <= c && c <= 'Z')
		{
			return c - 65 + 10;
		}
		if ('a' <= c && c <= 'z')
		{
			return c - 97 + 10;
		}
		if ('0' <= c && c <= '9')
		{
			return c - 48;
		}
		throw new InvalidOperationException();
	}
}
