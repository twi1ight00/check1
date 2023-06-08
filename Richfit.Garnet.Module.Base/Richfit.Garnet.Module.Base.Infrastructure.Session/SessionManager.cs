using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Threading;
using Richfit.Garnet.Module.Base.Infrastructure.Logging;

namespace Richfit.Garnet.Module.Base.Infrastructure.Session;

/// <summary>
/// 会话管理器
/// </summary>
public class SessionManager : Singleton<SessionManager>
{
	/// <summary>
	/// 调用ThreadTimerCallback的间隔时间，默认10分钟，10min = 600s = 600000ms
	/// </summary>
	private const int CallBackPeriod = 3660000;

	/// <summary>
	/// SessionKey
	/// </summary>
	public const string SessionKey = "SessionKey-{0}";

	/// <summary>
	/// SessionAlwaysKey
	/// </summary>
	public const string SessionAlwaysKey = "SessionAlwaysKey-{0}";

	/// <summary>
	/// SessionListKey
	/// </summary>
	public const string SessionListKey = "SessionListKey-{0}";

	/// <summary>
	/// SessionCounterKey
	/// </summary>
	public const string SessionCounterKey = "SessionCounterKey";

	/// <summary>
	/// 当前会话Token
	/// </summary>
	private static ThreadLocal<Guid> currentSessionToken = new ThreadLocal<Guid>();

	/// <summary>
	/// Session添加删除时的日志记录
	/// </summary>
	private static ISessionLog sessionLoger = ServiceLocator.Instance.GetService<ISessionLog>();

	/// <summary>
	/// Session过期时间
	/// </summary>
	private TimeSpan sessionSlidingExpired;

	/// <summary>
	/// Session过期时间(移动)
	/// </summary>
	private TimeSpan sessionSlidingExpiredForMoblie;

	/// <summary>
	/// 定时器
	/// </summary>
	private Timer timer;

	/// <summary>
	/// 同步锁
	/// </summary>
	private ReadWriteLocker syncLocker = new ReadWriteLocker();

	/// <summary>
	/// Session数量
	/// </summary>
	public int SessionCount => SystemCacheBus.Instance.Get<int>("SessionCounterKey");

	/// <summary>
	/// 登陆在线用户列表
	/// </summary>
	public IList<UserSessionInfo> SessionList
	{
		get
		{
			IList<UserSessionInfo> sessionList = new List<UserSessionInfo>();
			IList<Guid> sessionIdList = GetAllSessionIds();
			if (sessionIdList != null && sessionIdList.Any())
			{
				sessionIdList.ForEach(delegate(Guid x)
				{
					if (SystemCacheBus.Instance.Get($"SessionKey-{x}") is UserSessionInfo userSessionInfo)
					{
						userSessionInfo.Token = x;
						sessionList.Add(userSessionInfo);
					}
				});
			}
			return sessionList;
		}
	}

	/// <summary>
	/// 初始化管理器
	/// </summary>
	private SessionManager()
	{
		sessionSlidingExpired = TimeSpan.FromMinutes(ConfigurationManager.System.Settings.SessionTimeout);
		sessionSlidingExpiredForMoblie = TimeSpan.FromMinutes(ConfigurationManager.System.Settings.SessionTimeoutForMoblie);
		timer = new Timer(CheckSessionTimeOutCallback, this, 3660000, 3660000);
	}

	/// <summary>
	/// 获取所有SessionId列表
	/// </summary>
	/// <returns></returns>
	private IList<Guid> GetAllSessionIds()
	{
		IList<Guid> listReturn = new List<Guid>();
		CacheManager.DoSystemCacheAction(syncLocker, LockerType.Read, delegate
		{
			for (int i = 0; i < CacheConfig.DistributedServerCount; i++)
			{
				IList<Guid> list = SystemCacheBus.Instance.Get<IList<Guid>>($"SessionListKey-{i}");
				if (!SystemCacheBus.Instance.IsDistributed && list != null && list.Any())
				{
					list = list.ToList();
				}
				if (list != null && list.Any())
				{
					listReturn.AddRange(list);
				}
			}
		});
		return listReturn;
	}

	/// <summary>
	/// 获取当前会话Token
	/// </summary>
	public Guid GetCurrentSessionToken()
	{
		return currentSessionToken.Value;
	}

	/// <summary>
	/// 设置当前会话的Token
	/// </summary>
	/// <param name="token"></param>
	public void SetCurrentSessionToken(Guid token)
	{
		currentSessionToken.Value = token;
	}

	/// <summary>
	/// 清除当前会话的Token
	/// </summary>
	public void ClearCurrentSessionToken()
	{
		currentSessionToken.Value = Guid.Empty;
	}

	/// <summary>
	/// 用户登陆，添加seesion信息
	/// </summary>
	/// <param name="userInfo"></param>
	/// <returns></returns>
	public Guid AddSession(UserSessionInfo userInfo)
	{
		Guid guid = Guid.NewGuid();
		if (userInfo.IsMobile == 1)
		{
			SystemCacheBus.Instance.Set($"SessionKey-{guid}", userInfo, sessionSlidingExpiredForMoblie);
			SystemCacheBus.Instance.Set($"SessionAlwaysKey-{guid}", userInfo, sessionSlidingExpiredForMoblie);
		}
		else
		{
			SystemCacheBus.Instance.Set($"SessionKey-{guid}", userInfo, sessionSlidingExpired);
			SystemCacheBus.Instance.Set($"SessionAlwaysKey-{guid}", userInfo, sessionSlidingExpired);
		}
		CacheManager.DoSystemCacheAction(syncLocker, LockerType.Write, delegate
		{
			SystemCacheBus.Instance.Set($"SessionListKey-{CacheConfig.CurrentServerIndex}", delegate(IList<Guid> list)
			{
				if (list != null && list.Any())
				{
					list.Add(guid);
				}
				else
				{
					list = new List<Guid>();
					list.Add(guid);
				}
				return list;
			});
			SystemCacheBus.Instance.Set("SessionCounterKey", (int i) => ++i);
		});
		currentSessionToken.Value = guid;
		sessionLoger.SessionAddLog();
		return guid;
	}

	/// <summary>
	/// 用户注销登陆，删除session信息
	/// </summary>
	public void RemoveSession()
	{
		Guid token = GetCurrentSessionToken();
		sessionLoger.SessionRemoveLog(token);
		SystemCacheBus.Instance.Remove($"SessionKey-{token}");
		CacheManager.DoSystemCacheAction(syncLocker, LockerType.Write, delegate
		{
			bool isHit = false;
			SystemCacheBus.Instance.Set($"SessionListKey-{CacheConfig.CurrentServerIndex}", delegate(IList<Guid> list)
			{
				if (list != null && list.Any() && list.Contains(token))
				{
					isHit = true;
					list.Remove(token);
				}
				return list;
			});
			if (isHit)
			{
				SystemCacheBus.Instance.Set("SessionCounterKey", (int i) => --i);
			}
		});
	}

	/// <summary>
	/// 根据SessionId判断Session是否存在
	/// </summary>
	/// <param name="token"></param>
	/// <returns></returns>
	public bool IsExists(Guid token)
	{
		return SystemCacheBus.Instance.Contains($"SessionKey-{token}");
	}

	/// <summary>
	/// 根据Token，获得对应会话的用户信息
	/// </summary>
	/// <param name="token"></param>
	/// <returns></returns>
	public UserSessionInfo GetUserSessionInfo(Guid token)
	{
		object sessionInfo = SystemCacheBus.Instance.Get($"SessionAlwaysKey-{token}");
		return (sessionInfo != null) ? (sessionInfo as UserSessionInfo) : null;
	}

	/// <summary>
	/// 获取当前会话用户信息
	/// </summary>
	/// <returns></returns>
	public UserSessionInfo GetCurrentUserSessionInfo()
	{
		Guid token = GetCurrentSessionToken();
		return GetUserSessionInfo(token);
	}

	/// <summary>
	/// 调整当前会话的过期时间
	/// </summary>
	public void AdjustExpiredTime()
	{
		if (!SystemCacheBus.Instance.IsDistributed)
		{
			return;
		}
		Guid token = GetCurrentSessionToken();
		UserSessionInfo sessionInfo = SystemCacheBus.Instance.Get<UserSessionInfo>($"SessionKey-{token}");
		if (sessionInfo != null)
		{
			if (sessionInfo.IsMobile == 1)
			{
				SystemCacheBus.Instance.Set($"SessionKey-{token}", sessionInfo, sessionSlidingExpiredForMoblie);
			}
			else
			{
				SystemCacheBus.Instance.Set($"SessionKey-{token}", sessionInfo, sessionSlidingExpired);
			}
		}
	}

	/// <summary>
	/// 检测Session过期的回调函数
	/// </summary>
	/// <param name="state"></param>
	private void CheckSessionTimeOutCallback(object state)
	{
		IList<Guid> uselessSessionIdList = new List<Guid>();
		CacheManager.DoSystemCacheAction(syncLocker, LockerType.Write, delegate
		{
			SystemCacheBus.Instance.Set($"SessionListKey-{CacheConfig.CurrentServerIndex}", delegate(IList<Guid> list)
			{
				uselessSessionIdList.Clear();
				if (list != null && list.Any())
				{
					list.ForEach(delegate(Guid x)
					{
						if (!SystemCacheBus.Instance.Contains($"SessionKey-{x}"))
						{
							uselessSessionIdList.Add(x);
							SystemCacheBus.Instance.Remove($"SessionAlwaysKey-{x}");
						}
					});
					if (uselessSessionIdList.Any())
					{
						uselessSessionIdList.ForEach(delegate(Guid x)
						{
							list.Remove(x);
						});
					}
				}
				else
				{
					list = new List<Guid>();
				}
				return list;
			});
			if (uselessSessionIdList.Any())
			{
				SystemCacheBus.Instance.Set("SessionCounterKey", (int i) => i - uselessSessionIdList.Count);
			}
		});
		if (uselessSessionIdList.Any())
		{
			uselessSessionIdList.ForEach(delegate(Guid x)
			{
				sessionLoger.SessionRemoveLog(x);
			});
		}
	}
}
