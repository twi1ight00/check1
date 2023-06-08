using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Fundation.Application.Services.BusinessMenu;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Action;

/// <summary>
/// Action管理类
/// </summary>
public class ActionManager
{
	/// <summary>
	/// 日志对象
	/// </summary>
	private static readonly ILogger log = LoggerManager.GetLogger();

	/// <summary>
	/// 根据ActionCode得到处理业务的Handler实例
	/// </summary>
	/// <param name="actionCode"></param>
	/// <returns></returns>
	public static IHandlerBase GetBusinessHandler(string actionCode)
	{
		log.Debug(actionCode + "查找对应的Handler开始");
		IHandlerBase handler = null;
		string handlerAssembly = string.Empty;
		ActionBusinessCacheLoader.SyncLocker.Read(delegate
		{
			handlerAssembly = LocalCacheBus.Instance.Get($"ActionHandlerCacheKey-{actionCode}") as string;
		});
		if (!string.IsNullOrWhiteSpace(handlerAssembly))
		{
			log.Debug(actionCode + "查找到" + handlerAssembly + "成功");
			try
			{
				handler = Type.GetType(handlerAssembly).CreateInstance<IHandlerBase>();
			}
			catch (Exception e)
			{
				StringBuilder sbError = new StringBuilder();
				while (e != null)
				{
					sbError.AppendLine(e.Message);
					e = e.InnerException;
				}
				log.Debug("创建" + handlerAssembly + "实例发生错误：" + sbError.ToString());
			}
		}
		else
		{
			log.Debug(actionCode + "没有找到Handler");
		}
		log.Debug(actionCode + "查找对应的Handler结束");
		return handler;
	}

	/// <summary>
	/// 判断某用户是否有执行某action的权限
	/// </summary>
	/// <param name="userId"></param>
	/// <param name="userOrgId"></param>
	/// <param name="actionCode"></param>
	/// <returns></returns>
	public static bool ActionCanDo(Guid userId, Guid userOrgId, string actionCode)
	{
		bool canDo = false;
		log.Debug("查找Action:" + actionCode + "对应的业务开始");
		log.Debug(string.Concat("userId:", userId, "userOrgId:", userOrgId, "查找对应的业务开始"));
		IList<Guid> userBusinessIdList = BusinessMenuManager.GetUserBusinessIds(userId, userOrgId);
		if (userBusinessIdList != null && userBusinessIdList.Any())
		{
			log.Debug(string.Concat("userId:", userId, "userOrgId:", userOrgId, "查找对应的业务成功"));
			Parallel.ForEach(userBusinessIdList, delegate(Guid businessId, ParallelLoopState s)
			{
				if (LocalCacheBus.Instance.Contains($"ActionBusinessCacheKey-{actionCode}-{businessId}"))
				{
					canDo = true;
					s.Stop();
				}
			});
		}
		else
		{
			log.Debug(string.Concat("userId:", userId, "userOrgId:", userOrgId, "没有查找对应的业务"));
		}
		log.Debug(string.Concat("userId:", userId, "userOrgId:", userOrgId, canDo ? "有" : "无", "执行Action:", actionCode, "的权限"));
		return canDo;
	}

	/// <summary>
	/// 判断Action是否需要权限验证
	/// </summary>
	/// <param name="actionCode"></param>
	/// <returns></returns>
	public static bool ActionNeedValidate(string actionCode)
	{
		bool need = true;
		log.Debug(actionCode + "判断是否权限验证开始");
		ActionBusinessCacheLoader.SyncLocker.Read(delegate
		{
			decimal num = LocalCacheBus.Instance.Get<decimal>($"ActionValidateTypeCacheKey-{actionCode}");
			need = num != 1m;
		});
		log.Debug(actionCode + (need ? "是" : "不") + "需要权限验证");
		log.Debug(actionCode + "判断是否权限验证结束");
		return need;
	}
}
