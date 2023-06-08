using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Richfit.Garnet.Module.UEditor;

/// <summary>
/// FileManager 的摘要说明
/// </summary>
public class ListFileManager : Handler
{
	private enum ResultState
	{
		Success,
		InvalidParam,
		AuthorizError,
		IOError,
		PathNotFound
	}

	private int Start;

	private int Size;

	private int Total;

	private ResultState State;

	private string PathToList;

	private string[] FileList;

	private string[] SearchExtensions;

	public ListFileManager(HttpContext context, string pathToList, string[] searchExtensions)
		: base(context)
	{
		SearchExtensions = searchExtensions.Select((string x) => x.ToLower()).ToArray();
		PathToList = pathToList;
	}

	public override void Process()
	{
		try
		{
			Start = ((!string.IsNullOrEmpty(base.Request["start"])) ? Convert.ToInt32(base.Request["start"]) : 0);
			Size = (string.IsNullOrEmpty(base.Request["size"]) ? Config.GetInt("imageManagerListSize") : Convert.ToInt32(base.Request["size"]));
		}
		catch (FormatException)
		{
			State = ResultState.InvalidParam;
			WriteResult();
			return;
		}
		List<string> buildingList = new List<string>();
		try
		{
			string localPath = base.Server.MapPath(PathToList);
			buildingList.AddRange(from x in Directory.GetFiles(localPath, "*", SearchOption.AllDirectories)
				where SearchExtensions.Contains(Path.GetExtension(x).ToLower())
				select PathToList + x.Substring(localPath.Length).Replace("\\", "/"));
			Total = buildingList.Count;
			FileList = buildingList.OrderBy((string x) => x).Skip(Start).Take(Size)
				.ToArray();
		}
		catch (UnauthorizedAccessException)
		{
			State = ResultState.AuthorizError;
		}
		catch (DirectoryNotFoundException)
		{
			State = ResultState.PathNotFound;
		}
		catch (IOException)
		{
			State = ResultState.IOError;
		}
		finally
		{
			WriteResult();
		}
	}

	private void WriteResult()
	{
		WriteJson(new
		{
			state = GetStateString(),
			list = ((FileList == null) ? null : FileList.Select((string x) => new
			{
				url = x
			})),
			start = Start,
			size = Size,
			total = Total
		});
	}

	private string GetStateString()
	{
		return State switch
		{
			ResultState.Success => "SUCCESS", 
			ResultState.InvalidParam => "参数不正确", 
			ResultState.PathNotFound => "路径不存在", 
			ResultState.AuthorizError => "文件系统权限不足", 
			ResultState.IOError => "文件系统读取错误", 
			_ => "未知错误", 
		};
	}
}
