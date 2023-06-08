using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Richfit.Garnet.Common.AOP.Handler;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Logging;
using Richfit.Garnet.Module.MessageCenter.Application.DTO;

namespace Richfit.Garnet.Module.MessageCenter.Application.Services;

public class SendMeassageToRuiXin : ServiceBase
{
	private static readonly ILogger logExp = LoggerManager.GetLogger("Exception");

	public void SendNoticeToRuiXin(string msgContent, string userLoginID)
	{
		StringBuilder strMes = new StringBuilder();
		strMes.Append("{\"body\":{\"appname\":\"qixin\",\"source\":\"rfoa\",\"msg_type\":\"message\",\"receiver_type\":\"alias\",\"title\":\"title1\",");
		strMes.AppendFormat("\"message\":\"{0}\",", msgContent);
		strMes.AppendFormat("\"count\":\"2\",");
		strMes.AppendFormat("\"username\":\"{0}\"", userLoginID);
		strMes.Append("}}");
		PostRequest(ConfigurationManager.System.Settings.GetSetting<string>("SerName"), ConfigurationManager.System.Settings.GetSetting<string>("PostSerUrl"), Encoding.GetEncoding("utf-8").GetBytes(strMes.ToString()));
	}

	public void SendPubNoToRuiXin(string msgTitle, string msgURL, string pubNoID, string pubNoKey)
	{
		StringBuilder strMes = new StringBuilder();
		DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
		long timeStamp = (long)(DateTime.Now - startTime).TotalSeconds;
		Dictionary<string, string> dic = new Dictionary<string, string>();
		dic.Add("time", timeStamp.ToString());
		dic.Add("md5", Md5(pubNoKey + "|" + timeStamp));
		dic.Add("channel_id", pubNoID);
		dic.Add("summary", msgTitle);
		dic.Add("article", $"<script>window.location.href='{msgURL}'</script>");
		dic.Add("title", msgTitle);
		PostResponse(ConfigurationManager.System.Settings.GetSetting<string>("PostPubNoSerUrl"), null, dic, Encoding.UTF8);
	}

	private string Md5(string str)
	{
		string pwd = "";
		MD5 md5 = MD5.Create();
		byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
		for (int i = 0; i < s.Length; i++)
		{
			pwd += s[i].ToString("x2");
		}
		return pwd;
	}

	public static string PostResponse(string url, UpLoadFile[] files, Dictionary<string, string> input, Encoding endoding)
	{
		string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "multipart/form-data; boundary=" + boundary;
		request.Method = "POST";
		request.KeepAlive = true;
		request.Expect = "";
		MemoryStream stream = new MemoryStream();
		byte[] line = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
		byte[] enterER = Encoding.ASCII.GetBytes("\r\n");
		if (files != null)
		{
			string fformat = "Content-Disposition:form-data; name=\"{0}\";filename=\"{1}\"\r\nContent-Type:{2}\r\n\r\n";
			foreach (UpLoadFile file in files)
			{
				stream.Write(line, 0, line.Length);
				string s = string.Format(fformat, file.Name, file.FileName, file.Content_Type);
				byte[] data = Encoding.UTF8.GetBytes(s);
				stream.Write(data, 0, data.Length);
				stream.Write(file.Data, 0, file.Data.Length);
				stream.Write(enterER, 0, enterER.Length);
			}
		}
		if (input != null)
		{
			string format = "--" + boundary + "\r\nContent-Disposition:form-data;name=\"{0}\"\r\n\r\n{1}\r\n";
			foreach (string key in input.Keys)
			{
				string s = string.Format(format, key, input[key]);
				byte[] data = Encoding.UTF8.GetBytes(s);
				stream.Write(data, 0, data.Length);
			}
		}
		byte[] foot_data = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");
		stream.Write(foot_data, 0, foot_data.Length);
		request.ContentLength = stream.Length;
		Stream requestStream = request.GetRequestStream();
		stream.Position = 0L;
		stream.CopyTo(requestStream);
		stream.Close();
		requestStream.Close();
		try
		{
			try
			{
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				try
				{
					using Stream responseStream = response.GetResponseStream();
					using MemoryStream mstream = new MemoryStream();
					responseStream.CopyTo(mstream);
					return endoding.GetString(mstream.ToArray());
				}
				catch (Exception ex3)
				{
					throw ex3;
				}
			}
			catch (WebException ex2)
			{
				throw ex2;
			}
		}
		catch (Exception ex3)
		{
			throw ex3;
		}
	}

	private string PostRequest(string headValue, string url, byte[] bData)
	{
		string strResult = string.Empty;
		HttpWebRequest hwRequest;
		try
		{
			hwRequest = (HttpWebRequest)WebRequest.Create(url);
			hwRequest.Timeout = 500000;
			hwRequest.Method = "POST";
			hwRequest.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
			hwRequest.ContentLength = bData.Length;
			hwRequest.Headers.Add("serviceName", headValue);
			Stream smWrite = hwRequest.GetRequestStream();
			smWrite.Write(bData, 0, bData.Length);
			smWrite.Close();
		}
		catch (Exception err2)
		{
			LogException(err2);
			return strResult;
		}
		try
		{
			HttpWebResponse hwResponse = (HttpWebResponse)hwRequest.GetResponse();
			StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.UTF8);
			strResult = srReader.ReadToEnd();
			srReader.Close();
			hwResponse.Close();
		}
		catch (Exception err2)
		{
			LogException(err2);
		}
		ILogger logPosMsg = LoggerManager.GetLogger("RxMobile");
		logPosMsg.Info("推送信息：" + strResult);
		return strResult;
	}

	private void LogException(Exception exception)
	{
		string exceptionMessage = GetExceptionMessage(exception);
		if (!string.IsNullOrEmpty(exceptionMessage))
		{
			SystemLogEntry logEntry = new SystemLogEntry();
			logEntry.Data = string.Format(exceptionMessage);
			logExp.Error(logEntry.ToJson());
		}
	}

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
			DbUpdateConcurrencyException ex = (DbUpdateConcurrencyException)(object)exception;
			sbErrors.AppendLine("DbUpdateConcurrencyException:" + ex.Entries.First().Entity.GetType().Name);
		}
		else if (exception.IsDbEntityValidationException())
		{
			DbEntityValidationException deve = (DbEntityValidationException)(object)exception;
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
		sbErrors.AppendLine("StackTrace:" + Environment.StackTrace);
		return sbErrors.ToString();
	}

	public CNPCTaskListDTO GetCNPCTaskList(string logon_name)
	{
		try
		{
			string url = string.Format(ConfigurationManager.System.Settings.GetSetting<string>("CnpcTaskApiUrl"), logon_name);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
			string responseStr = reader.ReadToEnd();
			reader.Close();
			response.Close();
			return (CNPCTaskListDTO)JsonConvert.DeserializeObject(responseStr, typeof(CNPCTaskListDTO));
		}
		catch (WebException we)
		{
			CNPCTaskListDTO cNPCTaskListDTO = new CNPCTaskListDTO();
			cNPCTaskListDTO.Result = "false";
			cNPCTaskListDTO.Desc = we.Message;
			cNPCTaskListDTO.TaskCount = "0";
			cNPCTaskListDTO.Ht_TaskCount = "0";
			cNPCTaskListDTO.Gw_TaskCount = "0";
			cNPCTaskListDTO.Bx_TaskCount = "0";
			return cNPCTaskListDTO;
		}
	}
}
