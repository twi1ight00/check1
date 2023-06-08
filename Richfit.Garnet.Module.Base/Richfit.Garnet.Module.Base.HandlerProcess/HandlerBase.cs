using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json.Linq;
using Richfit.Garnet.Common.AOP.Handler;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Common.Web.Extensions;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Logging;

namespace Richfit.Garnet.Module.Base.HandlerProcess;

/// <summary>
/// 请求处理基类
/// </summary>
public abstract class HandlerBase : IHandlerBase
{
	private static readonly ILogger logExp = LoggerManager.GetLogger("Exception");

	/// <summary>
	/// 日志对象，可从继承类中调用
	/// </summary>
	protected static readonly ILogger log = LoggerManager.GetLogger();

	/// <summary>
	/// 请求数据
	/// </summary>
	public RequestData RequestData { get; set; }

	/// <summary>
	/// 处理请求
	/// </summary>
	/// <param name="context"></param>
	public abstract void ProcessRequest(HttpContext context);

	/// <summary>
	/// 根据参数名称，获取url中的参数内容
	/// </summary>
	/// <param name="paramName">参数名</param>
	/// <returns>参数名对应的内容</returns>
	public string GetParameter(string paramName)
	{
		return HttpContext.Current.Request.QueryParam(paramName);
	}

	/// <summary>
	/// 把json字符串转成QueryCondition对象
	/// </summary>
	/// <param name="jsonText"></param>
	/// <returns></returns>
	public QueryCondition GetQueryCondition(string jsonText)
	{
		if (string.IsNullOrEmpty(jsonText))
		{
			return null;
		}
		QueryCondition queryCondition = QueryCondition.DeserializeFromJson(jsonText);
		if (queryCondition == null)
		{
			return null;
		}
		if (queryCondition.PagingSetting == null)
		{
			queryCondition.PagingSetting = PagingInfo.DeserializeFromJson(GetPagingInfo());
		}
		return queryCondition;
	}

	/// <summary>
	/// 获取查询条件，用于前端没有传回查询条件但是分页的情况
	/// </summary>
	/// <returns>返回QueryCondition对象，查询条件为空，分页不为空</returns>
	public QueryCondition GetQueryCondition()
	{
		QueryCondition queryCondition = new QueryCondition();
		if (queryCondition.PagingSetting == null)
		{
			queryCondition.PagingSetting = PagingInfo.DeserializeFromJson(GetPagingInfo());
		}
		return queryCondition;
	}

	/// <summary>
	/// Ext调用方式获取url 中的分页信息
	/// </summary>
	/// <returns></returns>
	private string GetPagingInfo()
	{
		string pageIndex = GetParameter("page");
		string pageCount = GetParameter("limit");
		string sortParameter = GetParameter("sort");
		if (string.IsNullOrWhiteSpace(sortParameter) || string.IsNullOrWhiteSpace(pageIndex) || string.IsNullOrWhiteSpace(pageCount))
		{
			return string.Empty;
		}
		pageIndex = ((pageIndex == string.Empty) ? "0" : (int.Parse(pageIndex) - 1).ToString());
		string sortBy = string.Empty;
		string sortOrder = string.Empty;
		JArray arrSort = JArray.Parse(sortParameter);
		foreach (JObject sort in arrSort)
		{
			sortBy = sortBy + (string)sort["property"] + ",";
			sortOrder = sortOrder + (string)sort["direction"] + ",";
		}
		sortBy = sortBy.Substring(0, sortBy.Length - 1);
		sortOrder = sortOrder.Substring(0, sortOrder.Length - 1);
		return "{\"pageindex\":" + pageIndex + ",\"pagecount\":" + pageCount + ",\"sortby\":\"" + sortBy + "\",\"sortorder\":\"" + sortOrder + "\"}";
	}

	/// <summary>
	/// Handler的ProcessRequest方法中通用的错误处理
	/// </summary>
	/// <param name="ex"></param>
	/// <returns></returns>
	public ResponseData HandleException(Exception ex)
	{
		ResponseData handlerResult = new ResponseData();
		handlerResult.Code = "Public.E_0001";
		LogException(ex);
		ExceptionClassification(ex, handlerResult);
		return handlerResult;
	}

	/// <summary>
	/// 获取错误信息
	/// </summary>
	/// <param name="exception"></param>
	/// <returns></returns>
	private string GetExceptionMessage(Exception exception)
	{
		StringBuilder sbErrors = new StringBuilder();
		if (exception.IsCustomCodeException())
		{
			CustomCodeException cce = exception as CustomCodeException;
			sbErrors.AppendLine("CustomCodeException:Code:" + cce.ErrorCode);
			sbErrors.AppendLine(GetExceptionMessage(cce.Exception));
		}
		else if (exception.IsValidationException())
		{
			ValidationException avee = exception as ValidationException;
			sbErrors.AppendLine("ValidationException:Code:" + avee.ValidateCode + "Messages:" + avee.ToString());
		}
		else if (exception.IsDbUpdateConcurrencyException())
		{
			DbUpdateConcurrencyException ex = (DbUpdateConcurrencyException)exception;
			sbErrors.AppendLine("DbUpdateConcurrencyException:" + ex.Entries.First().Entity.GetType().Name);
		}
		else if (exception.IsDbEntityValidationException())
		{
			DbEntityValidationException deve = (DbEntityValidationException)exception;
			foreach (DbEntityValidationResult eve in deve.EntityValidationErrors)
			{
				sbErrors.AppendFormat("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
				foreach (DbValidationError ve in eve.ValidationErrors)
				{
					sbErrors.AppendFormat("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
				}
			}
		}
		else if (exception.IsSqlExecuteException())
		{
			sbErrors.Append("SqlExecuteException:" + (exception as SqlExecuteException).ToString());
		}
		sbErrors.AppendLine("Exception occured: " + exception.Message);
		if (exception.InnerException != null)
		{
			log.Debug("HandlerBase-->获取错误信息日志开始，错误信息exception.InnerException.Message：" + exception.InnerException.Message);
		}
		else
		{
			log.Debug("HandlerBase-->获取错误信息日志开始，错误信息exception.Message：" + exception.Message);
		}
		sbErrors.AppendLine("StackTrace:" + Environment.StackTrace);
		log.Debug("HandlerBase-->获取错误信息日志结束");
		return sbErrors.ToString();
	}

	/// <summary>
	/// 记录错误日志
	/// </summary>
	/// <param name="exception"></param>
	private void LogException(Exception exception)
	{
		string exceptionMessage = GetExceptionMessage(exception);
		if (!string.IsNullOrEmpty(exceptionMessage))
		{
			SystemLogEntry logEntry = new SystemLogEntry();
			logEntry.Action = RequestData.ActionCode;
			logEntry.Data = $"RequestData:{RequestData.Data}-----Error:[{exceptionMessage}]";
			logExp.Error(logEntry.ToJson());
		}
	}

	/// <summary>
	/// 错误分类处理
	/// </summary>
	/// <param name="exception"></param>
	/// <param name="handlerResult"></param>
	private void ExceptionClassification(Exception exception, ResponseData handlerResult)
	{
		if (exception.IsCustomCodeException())
		{
			CustomCodeException cce = exception as CustomCodeException;
			handlerResult.Code = ((!string.IsNullOrWhiteSpace(cce.ErrorCode)) ? cce.ErrorCode : "Public.E_0001");
			ExceptionClassification(cce.Exception, handlerResult);
		}
		else if (exception.IsValidationException())
		{
			ValidationException validationException = exception as ValidationException;
			handlerResult.Code = (string.IsNullOrEmpty(validationException.ValidateCode) ? "Public.V_0001" : validationException.ValidateCode);
			handlerResult.Message = validationException.ToString();
		}
		else if (exception.IsDbUpdateConcurrencyException())
		{
			handlerResult.Code = "Public.E_0002";
		}
		else if (exception.IsDbEntityValidationException())
		{
			handlerResult.Code = "Public.V_0003";
		}
		else if (exception.IsDbUpdateConflictException())
		{
			handlerResult.Code = "Public.E_0013";
		}
		else
		{
			handlerResult.Message = exception.Message;
		}
	}
}
