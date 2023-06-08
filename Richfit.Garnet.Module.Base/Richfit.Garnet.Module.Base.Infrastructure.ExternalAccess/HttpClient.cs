using System;
using System.Net;
using System.Text;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;

namespace Richfit.Garnet.Module.Base.Infrastructure.ExternalAccess;

/// <summary>
/// Http请求客户端
/// </summary>
public class HttpClient
{
	/// <summary>
	/// 请求事件委托
	/// </summary>
	public delegate void RequestEventHandler();

	/// <summary>
	/// 响应事件委托
	/// </summary>
	/// <param name="responseResult"></param>
	public delegate void ResponseEventHandler(string responseResult);

	/// <summary>
	/// Web客户端
	/// </summary>
	private WebClient client;

	/// <summary>
	/// POST方式名称
	/// </summary>
	private static readonly string postMethod = "POST";

	/// <summary>
	/// 处理器名称
	/// </summary>
	private static readonly string uriDo = "";

	/// <summary>
	/// 访问服务器路径：'http://0.0.0.0:61333/'
	/// </summary>
	public string HttpPath { get; set; }

	/// <summary>
	/// 发送数据
	/// </summary>
	public string Data { get; set; }

	/// <summary>
	/// 请求地址
	/// </summary>
	private Uri DoUri => new Uri(HttpPath + uriDo);

	/// <summary>
	/// 读取完成事件
	/// </summary>
	public event OpenReadCompletedEventHandler onOpenReadCompletedEventHandler;

	/// <summary>
	/// 请求事件
	/// </summary>
	public event RequestEventHandler onRequestEventHandler;

	/// <summary>
	/// 响应事件
	/// </summary>
	public event ResponseEventHandler onResponseEventHandler;

	/// <summary>
	/// 初始化
	/// </summary>
	/// <param name="httpPath"></param>
	public HttpClient(string httpPath)
		: this()
	{
		HttpPath = httpPath;
	}

	/// <summary>
	/// 初始化
	/// </summary>
	public HttpClient()
	{
		client = new WebClient();
		client.Encoding = Encoding.UTF8;
		client.Headers["Content-Type"] = "application/x-www-form-urlencoded;charset=utf-8";
		WebClient webClient = client;
		UploadStringCompletedEventHandler value = delegate(object s, UploadStringCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				if (this.onResponseEventHandler != null)
				{
					this.onResponseEventHandler(e.Result);
				}
			}
			else if (this.onResponseEventHandler != null)
			{
				ResponseData responseData = new ResponseData
				{
					Code = "Public.E_0010",
					Message = "网络访问错误！"
				};
				this.onResponseEventHandler(responseData.ToJson());
			}
		};
		webClient.UploadStringCompleted += value;
		client.OpenReadCompleted += delegate(object s, OpenReadCompletedEventArgs e)
		{
			if (this.onOpenReadCompletedEventHandler != null)
			{
				this.onOpenReadCompletedEventHandler(s, e);
			}
		};
	}

	/// <summary>
	/// 上传完成事件处理器
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
	{
		if (e.Error == null)
		{
			if (this.onResponseEventHandler != null)
			{
				this.onResponseEventHandler(e.Result);
			}
		}
		else if (this.onResponseEventHandler != null)
		{
			ResponseData responseData = new ResponseData();
			responseData.Code = "Public.E_0010";
			responseData.Message = "网络访问错误！";
			ResponseData data = responseData;
			this.onResponseEventHandler(data.ToJson());
		}
	}

	/// <summary>
	/// 异步发送
	/// </summary>
	public void PostAsync()
	{
		if (this.onRequestEventHandler != null)
		{
			this.onRequestEventHandler();
		}
		client.UploadStringAsync(DoUri, postMethod, "RequestData=" + Data);
	}

	/// <summary>
	/// 异步发送
	/// </summary>
	/// <param name="data"></param>
	public void PostAsync(string data)
	{
		if (this.onRequestEventHandler != null)
		{
			this.onRequestEventHandler();
		}
		client.UploadStringAsync(DoUri, postMethod, "RequestData=" + data);
	}

	/// <summary>
	/// 同步发送
	/// </summary>
	public string Post()
	{
		if (this.onRequestEventHandler != null)
		{
			this.onRequestEventHandler();
		}
		return client.UploadString(DoUri, "RequestData=" + Data);
	}

	/// <summary>
	/// 同步发送
	/// </summary>
	/// <param name="data"></param>
	public string Post(string data)
	{
		if (this.onRequestEventHandler != null)
		{
			this.onRequestEventHandler();
		}
		return client.UploadString(DoUri, "RequestData=" + data);
	}
}
