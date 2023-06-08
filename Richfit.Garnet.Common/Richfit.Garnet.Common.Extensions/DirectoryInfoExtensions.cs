using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.IO.DirectoryInfo" /> 类型扩展方法类
/// </summary>
public static class DirectoryInfoExtensions
{
	/// <summary>
	/// 清空当前的目录，删除当前目录下的所有文件和子目录
	/// </summary>
	/// <param name="directory">当前的目录</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static void Clear(this DirectoryInfo directory)
	{
		directory.GuardNotNull("directory").GuardExistence();
		directory.Directories().ForEach(delegate(DirectoryInfo d)
		{
			d.Delete(recursive: true);
		});
		directory.Files().ForEach(delegate(FileInfo f)
		{
			f.Delete();
		});
	}

	/// <summary>
	/// 清空当前目录中的所有子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static void ClearDirectories(this DirectoryInfo directory)
	{
		directory.GuardNotNull("directory").GuardExistence();
		directory.Directories().ForEach(delegate(DirectoryInfo d)
		{
			d.Delete(recursive: true);
		});
	}

	/// <summary>
	/// 清空当前目录中的所有文件，包括各级子目录下的文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="recursive">是否清理当前目录的各级子目录中的文件，默认为false</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static void ClearFiles(this DirectoryInfo directory, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		directory.Files(recursive).ForEach(delegate(FileInfo f)
		{
			f.Delete();
		});
	}

	/// <summary>
	/// 复制当前目录到目标目录 <paramref name="targetPath" />，如果目标位置不存在创建该目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标目录路径</param>
	/// <param name="overwrite">目标目录或者文件如果存在是否覆盖，默认为false</param>
	/// <param name="levels">复制目录的层级，只复制层级等于指定值的目录和其中文件；默认为空，不限制层级数量。</param>
	/// <returns>复制后的目标目录对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="targetPath" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制目录层级 <paramref name="levels" /> 小于0。</exception>
	public static DirectoryInfo CopyTo(this DirectoryInfo directory, string targetPath, bool overwrite = false, int[] levels = null)
	{
		return directory.CopyTo(targetPath, "*", "*", overwrite, levels);
	}

	/// <summary>
	/// 复制当前目录到目标目录 <paramref name="targetPath" />，如果目标位置不存在创建该目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标目录路径</param>
	/// <param name="directorySearching">复制的目录的搜索模式</param>
	/// <param name="fileSearching">复制的文件的搜索模式</param>
	/// <param name="overwrite">目标目录或者文件如果存在是否覆盖，默认为false</param>
	/// <param name="levels">复制目录的层级，只复制层级等于指定值的目录和其中文件；默认为空，不限制层级数量。</param>
	/// <returns>复制后的目标目录对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="targetPath" /> 为空；或者匹配模式 <paramref name="directorySearching" /> 为空；或者匹配模式 <paramref name="fileSearching" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，<paramref name="targetPath" /> 指示的目标目录已经存在。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制目录层级 <paramref name="levels" /> 小于0。</exception>
	public static DirectoryInfo CopyTo(this DirectoryInfo directory, string targetPath, string directorySearching, string fileSearching, bool overwrite = false, int[] levels = null)
	{
		directory.GuardNotNull("directory").GuardExistence();
		targetPath.GuardNotNull("targetPath");
		directorySearching.GuardNotNull("directory searching");
		fileSearching.GuardNotNull("file searching");
		if (levels.IsNull())
		{
			return CopyTo(directory, targetPath, (DirectoryInfo d) => d.Directories(directorySearching), (DirectoryInfo f) => f.Files(fileSearching), overwrite);
		}
		levels.ForEach(delegate(int x)
		{
			x.GuardGreaterThanOrEqualTo(0, "level");
		});
		return CopyTo(directory, targetPath, (DirectoryInfo d) => d.Directories(directorySearching, levels), (DirectoryInfo f) => f.Files(fileSearching), overwrite, levels);
	}

	/// <summary>
	/// 复制当前目录到目标目录 <paramref name="targetPath" />，如果目标位置不存在创建该目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标目录</param>
	/// <param name="pattern">复制的目录或者文件的名称的匹配模式，匹配目录或者文件的全名（包括路径和名称）</param>
	/// <param name="overwrite">目标目录或者文件如果存在是否覆盖，默认为false</param>
	/// <param name="levels">复制目录的层级，只复制层级等于指定值的目录和其中文件；默认为空，不限制层级数量。</param>
	/// <returns>复制后的目标目录对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="targetPath" /> 为空；或者匹配模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制目录层级 <paramref name="levels" /> 小于0。</exception>
	public static DirectoryInfo CopyTo(this DirectoryInfo directory, string targetPath, Regex pattern, bool overwrite = false, int[] levels = null)
	{
		pattern.GuardNotNull("pattern");
		return directory.CopyTo(targetPath, (FileSystemInfo x) => pattern.IsMatch(x.FullName), overwrite, levels);
	}

	/// <summary>
	/// 复制当前目录到目标目录 <paramref name="targetPath" />，如果目标位置不存在创建该目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标目录路径</param>
	/// <param name="predicate">复制筛选条件；将复制的目录或者文件的对象传入该方法，根据返回值确定是否进行复制。</param>
	/// <param name="overwrite">目标目录或者文件如果存在是否覆盖，默认为false</param>
	/// <param name="levels">复制目录的层级，只复制层级等于指定值的目录和其中文件；默认为空，不限制层级数量。</param>
	/// <returns>复制后的目标目录对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="targetPath" /> 为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制目录层级 <paramref name="levels" /> 小于0。</exception>
	public static DirectoryInfo CopyTo(this DirectoryInfo directory, string targetPath, Func<FileSystemInfo, bool> predicate, bool overwrite = false, int[] levels = null)
	{
		directory.GuardNotNull("directory").GuardExistence();
		targetPath.GuardNotNull("targetPath");
		predicate.GuardNotNull("predicate");
		if (levels.IsNull())
		{
			return CopyTo(directory, targetPath, (DirectoryInfo d) => d.Directories(predicate), (DirectoryInfo f) => f.Files(predicate), overwrite);
		}
		levels.ForEach(delegate(int x)
		{
			x.GuardGreaterThanOrEqualTo(0, "level");
		});
		return CopyTo(directory, targetPath, (DirectoryInfo d) => d.Directories(predicate, levels), (DirectoryInfo f) => f.Files(predicate), overwrite, levels);
	}

	private static DirectoryInfo CopyTo(DirectoryInfo directory, string targetPath, Func<DirectoryInfo, IEnumerable<DirectoryInfo>> directoryEnumerator, Func<DirectoryInfo, IEnumerable<FileInfo>> fileEnumerator, bool overwrite)
	{
		DirectoryInfo target = new DirectoryInfo(targetPath);
		if (!target.Exists)
		{
			target.Create(directory.GetAccessControl(AccessControlSections.All));
		}
		foreach (FileInfo finfo in fileEnumerator(directory))
		{
			finfo.CopyTo(Path.Combine(target.FullName, finfo.Name), overwrite);
		}
		foreach (DirectoryInfo dinfo in directoryEnumerator(directory))
		{
			CopyTo(dinfo, Path.Combine(target.FullName, dinfo.Name), directoryEnumerator, fileEnumerator, overwrite);
		}
		return target;
	}

	private static DirectoryInfo CopyTo(DirectoryInfo directory, string targetPath, Func<DirectoryInfo, IEnumerable<DirectoryInfo>> directoryEnumerator, Func<DirectoryInfo, IEnumerable<FileInfo>> fileEnumerator, bool overwrite, int[] levels)
	{
		DirectoryInfo target = new DirectoryInfo(targetPath);
		foreach (DirectoryInfo dinfo in directoryEnumerator(directory))
		{
			targetPath = Path.Combine(target.FullName, dinfo.GetRelativePath(directory));
			if (!Directory.Exists(targetPath))
			{
				Directory.CreateDirectory(targetPath);
			}
			foreach (FileInfo finfo in fileEnumerator(directory))
			{
				finfo.CopyTo(Path.Combine(targetPath, finfo.Name), overwrite);
			}
		}
		return target;
	}

	/// <summary>
	/// 复制当前目录下的子目录到指定的目标位置，不复制目录中的文件；如果目标位置不存在则创建
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标位置路径</param>
	/// <param name="recursive">是否递归复制当前目录下所有的子目录</param>
	/// <returns>复制后的目标目录对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者复制的目标位置 <paramref name="targetPath" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	public static DirectoryInfo CopyDirectories(this DirectoryInfo directory, string targetPath, bool recursive = false)
	{
		return directory.CopyDirectories(targetPath, "*", recursive);
	}

	/// <summary>
	/// 复制当前目录下的子目录到指定的目标位置，不复制目录中的文件；如果目标位置不存在则创建
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标位置路径</param>
	/// <param name="levels">复制目录的层级，只复制层级等于指定值的目录和其中文件</param>
	/// <returns>复制后的目标目录对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者复制的目标位置 <paramref name="targetPath" /> 为空；或者 <paramref name="levels" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制目录层级 <paramref name="levels" /> 小于0。</exception>
	public static DirectoryInfo CopyDirectories(this DirectoryInfo directory, string targetPath, params int[] levels)
	{
		return directory.CopyDirectories(targetPath, "*", levels);
	}

	/// <summary>
	/// 复制当前目录下的子目录到指定的目标位置，不复制目录中的文件；如果目标位置不存在则创建
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标位置路径</param>
	/// <param name="searching">复制的目录的搜索模式</param>
	/// <param name="recursive">是否递归复制当前目录下所有的子目录</param>
	/// <returns>复制后的目标目录对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者复制的目标位置 <paramref name="targetPath" /> 为空；或者 <paramref name="searching" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	public static DirectoryInfo CopyDirectories(this DirectoryInfo directory, string targetPath, string searching, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		targetPath.GuardNotNull("targetPath");
		searching.GuardNotNull("searching");
		return CopyDirectories(directory, targetPath, (DirectoryInfo d) => d.Directories(searching, recursive));
	}

	/// <summary>
	/// 复制当前目录下的子目录到指定的目标位置，不复制目录中的文件；如果目标位置不存在则创建
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标位置路径</param>
	/// <param name="searching">复制的目录的搜索模式</param>
	/// <param name="levels">复制目录的层级，只复制层级等于指定值的目录和其中文件</param>
	/// <returns>复制后的目标目录对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者复制的目标位置 <paramref name="targetPath" /> 为空；或者 <paramref name="searching" /> 为空；或者 <paramref name="levels" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制目录层级 <paramref name="levels" /> 小于0。</exception>
	public static DirectoryInfo CopyDirectories(this DirectoryInfo directory, string targetPath, string searching, params int[] levels)
	{
		directory.GuardNotNull("directory").GuardExistence();
		targetPath.GuardNotNull("targetPath");
		searching.GuardNotNull("searching");
		levels.GuardNotNull("levels");
		levels.ForEach(delegate(int x)
		{
			x.GuardGreaterThanOrEqualTo(0, "level");
		});
		return CopyDirectories(directory, targetPath, (DirectoryInfo d) => d.Directories(searching, levels));
	}

	/// <summary>
	/// 复制当前目录下的子目录到指定的目标位置，不复制目录中的文件；如果目标位置不存在则创建
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标位置路径</param>
	/// <param name="pattern">复制的目录的名称匹配模式</param>
	/// <param name="recursive">是否递归复制当前目录下所有的子目录</param>
	/// <returns>复制后的目标目录对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者复制的目标位置 <paramref name="targetPath" /> 为空；或者 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	public static DirectoryInfo CopyDirectories(this DirectoryInfo directory, string targetPath, Regex pattern, bool recursive = false)
	{
		pattern.GuardNotNull("pattern");
		return directory.CopyDirectories(targetPath, (DirectoryInfo d) => pattern.IsMatch(d.FullName), recursive);
	}

	/// <summary>
	/// 复制当前目录下的子目录到指定的目标位置，不复制目录中的文件；如果目标位置不存在则创建
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标位置路径</param>
	/// <param name="pattern">复制的目录的名称匹配模式</param>
	/// <param name="levels">复制目录的层级，只复制层级等于指定值的目录和其中文件</param>
	/// <returns>复制后的目标目录对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者复制的目标位置 <paramref name="targetPath" /> 为空；或者 <paramref name="pattern" /> 为空；或者 <paramref name="levels" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制目录层级 <paramref name="levels" /> 小于0。</exception>
	public static DirectoryInfo CopyDirectories(this DirectoryInfo directory, string targetPath, Regex pattern, params int[] levels)
	{
		pattern.GuardNotNull("pattern");
		return directory.CopyDirectories(targetPath, (DirectoryInfo d) => pattern.IsMatch(d.FullName), levels);
	}

	/// <summary>
	/// 复制当前目录下的子目录到指定的目标位置，不复制目录中的文件；如果目标位置不存在则创建
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标位置路径</param>
	/// <param name="predicate">复制目录筛选条件</param>
	/// <param name="recursive">是否递归复制当前目录下所有的子目录</param>
	/// <returns>复制后的目标目录对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者复制的目标位置 <paramref name="targetPath" /> 为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	public static DirectoryInfo CopyDirectories(this DirectoryInfo directory, string targetPath, Func<DirectoryInfo, bool> predicate, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		targetPath.GuardNotNull("targetPath");
		predicate.GuardNotNull("predicate");
		return CopyDirectories(directory, targetPath, (DirectoryInfo d) => d.Directories(predicate, recursive));
	}

	/// <summary>
	/// 复制当前目录下的子目录到指定的目标位置，不复制目录中的文件；如果目标位置不存在则创建
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标位置路径</param>
	/// <param name="predicate">复制目录筛选条件</param>
	/// <param name="levels">复制目录的层级，只复制层级等于指定值的目录和其中文件</param>
	/// <returns>复制后的目标目录对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者复制的目标位置 <paramref name="targetPath" /> 为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="levels" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制目录层级 <paramref name="levels" /> 小于0。</exception>
	public static DirectoryInfo CopyDirectories(this DirectoryInfo directory, string targetPath, Func<DirectoryInfo, bool> predicate, params int[] levels)
	{
		directory.GuardNotNull("directory").GuardExistence();
		targetPath.GuardNotNull("targetPath");
		predicate.GuardNotNull("predicate");
		levels.GuardNotNull("levels");
		levels.ForEach(delegate(int x)
		{
			x.GuardGreaterThanOrEqualTo(0, "level");
		});
		return CopyDirectories(directory, targetPath, (DirectoryInfo d) => d.Directories(predicate, levels));
	}

	private static DirectoryInfo CopyDirectories(DirectoryInfo directory, string targetPath, Func<DirectoryInfo, IEnumerable<DirectoryInfo>> enumerator)
	{
		DirectoryInfo target = new DirectoryInfo(targetPath);
		if (!target.Exists)
		{
			target.Create(directory.GetAccessControl(AccessControlSections.All));
		}
		foreach (DirectoryInfo dinfo in enumerator(directory))
		{
			targetPath = Path.Combine(target.FullName, dinfo.GetRelativePath(directory));
			if (!Directory.Exists(targetPath))
			{
				Directory.CreateDirectory(targetPath);
			}
		}
		return target;
	}

	/// <summary>
	/// 复制当前目录下的文件到指定的目标位置，如果目标位置不存在则创建
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标位置路径</param>
	/// <param name="overwrite">如果目标位置存在同名文件，是否覆盖</param>
	/// <returns>复制后的目标位置对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者复制目标位置 <paramref name="targetPath" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，<paramref name="targetPath" /> 指示的目标目录中存在同名文件已经存在。</exception>
	public static DirectoryInfo CopyFiles(this DirectoryInfo directory, string targetPath, bool overwrite = false)
	{
		return directory.CopyFiles(targetPath, "*", overwrite);
	}

	/// <summary>
	/// 复制当前目录下的文件到指定的目标位置，如果目标位置不存在则创建
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标位置路径</param>
	/// <param name="searching">复制文件的搜索条件</param>
	/// <param name="overwrite">如果目标位置存在同名文件，是否覆盖</param>
	/// <returns>复制后的目标位置对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者复制目标位置 <paramref name="targetPath" /> 为空；或者筛选条件 <paramref name="searching" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，<paramref name="targetPath" /> 指示的目标目录中存在同名文件已经存在。</exception>
	public static DirectoryInfo CopyFiles(this DirectoryInfo directory, string targetPath, string searching, bool overwrite = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		targetPath.GuardNotNull("targetPath");
		searching.GuardNotNull("searching");
		return CopyFiles(directory, targetPath, (DirectoryInfo d) => d.Files(searching), overwrite);
	}

	/// <summary>
	/// 复制当前目录下的文件到指定的目标位置，如果目标位置不存在则创建
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标位置路径</param>
	/// <param name="pattern">复制文件名称的匹配模式，对文件的全名进行匹配（包括路径和文件名）</param>
	/// <param name="overwrite">如果目标位置存在同名文件，是否覆盖</param>
	/// <returns>复制后的目标位置对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者复制目标位置 <paramref name="targetPath" /> 为空；或者 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，<paramref name="targetPath" /> 指示的目标目录中存在同名文件已经存在。</exception>
	public static DirectoryInfo CopyFiles(this DirectoryInfo directory, string targetPath, Regex pattern, bool overwrite = false)
	{
		pattern.GuardNotNull("pattern");
		return directory.CopyFiles(targetPath, (FileInfo f) => pattern.IsMatch(f.FullName), overwrite);
	}

	/// <summary>
	/// 复制当前目录下的文件到指定的目标位置，如果目标位置不存在则创建
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="targetPath">复制的目标位置路径</param>
	/// <param name="predicate">复制文件的筛选条件</param>
	/// <param name="overwrite">如果目标位置存在同名文件，是否覆盖</param>
	/// <returns>复制后的目标位置对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者复制目标位置 <paramref name="targetPath" /> 为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentException">目标路径 <paramref name="targetPath" /> 无效。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，<paramref name="targetPath" /> 指示的目标目录中存在同名文件已经存在。</exception>
	public static DirectoryInfo CopyFiles(this DirectoryInfo directory, string targetPath, Func<FileInfo, bool> predicate, bool overwrite = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		targetPath.GuardNotNull("targetPath");
		predicate.GuardNotNull("predicate");
		return CopyFiles(directory, targetPath, (DirectoryInfo d) => d.Files(predicate), overwrite);
	}

	private static DirectoryInfo CopyFiles(DirectoryInfo directory, string targetPath, Func<DirectoryInfo, IEnumerable<FileInfo>> enumerator, bool overwrite = false)
	{
		DirectoryInfo target = new DirectoryInfo(targetPath);
		if (!target.Exists)
		{
			target.Create(directory.GetAccessControl(AccessControlSections.All));
		}
		foreach (FileInfo finfo in enumerator(directory))
		{
			finfo.CopyTo(Path.Combine(target.FullName, finfo.Name), overwrite);
		}
		return target;
	}

	/// <summary>
	/// 删除当前目录下目录级别等于指定值的全部目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="level">待删除的目录级别</param>
	/// <param name="force">是否删除含有子目录或者文件的非空目录</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">删除的目录级别 <paramref name="level" /> 小于0。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="force" /> 为false时，删除的目录不为空。</exception>
	public static void DeleteDirectories(this DirectoryInfo directory, int level, bool force = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		level.GuardGreaterThanOrEqualTo(0, "level");
		foreach (DirectoryInfo dinfo in directory.Directories(level))
		{
			if (dinfo.Exists)
			{
				dinfo.Delete(force);
			}
		}
	}

	/// <summary>
	/// 删除当前目录下的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="searching">目录搜索模式</param>
	/// <param name="recursive">是否在子目录中搜索待删除的目录</param>
	/// <param name="force">是否删除含有子目录或者文件的非空目录</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="searching" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="force" /> 为false时，删除的目录不为空。</exception>
	public static void DeleteDirectories(this DirectoryInfo directory, string searching, bool recursive = false, bool force = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		searching.GuardNotNull("searching");
		foreach (DirectoryInfo dinfo in directory.Directories(searching, recursive))
		{
			if (dinfo.Exists)
			{
				dinfo.Delete(force);
			}
		}
	}

	/// <summary>
	/// 删除当前目录下的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="pattern">目录全名匹配模式</param>
	/// <param name="recursive">是否在子目录中搜索待删除的目录</param>
	/// <param name="force">是否删除含有子目录或者文件的非空目录</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="force" /> 为false时，删除的目录不为空。</exception>
	public static void DeleteDirectories(this DirectoryInfo directory, Regex pattern, bool recursive = false, bool force = false)
	{
		pattern.GuardNotNull("pattern");
		directory.DeleteDirectories((DirectoryInfo d) => pattern.IsMatch(d.FullName), recursive, force);
	}

	/// <summary>
	/// 删除当前目录下的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="predicate">删除目录筛选条件</param>
	/// <param name="recursive">是否在子目录中搜索待删除的目录</param>
	/// <param name="force">是否删除含有子目录或者文件的非空目录</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="force" /> 为false时，删除的目录不为空。</exception>
	public static void DeleteDirectories(this DirectoryInfo directory, Func<DirectoryInfo, bool> predicate, bool recursive = false, bool force = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		predicate.GuardNotNull("predicate");
		DirectoryInfo[] directories = directory.GetDirectories(predicate, recursive);
		foreach (DirectoryInfo dinfo in directories)
		{
			if (dinfo.Exists)
			{
				dinfo.Delete(force);
			}
		}
	}

	/// <summary>
	/// 删除当前目录下的空目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="recursive">是否删除当前目录下所有空的子目录</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static void DeleteEmptyDirectories(this DirectoryInfo directory, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		directory.DeleteDirectories((DirectoryInfo d) => d.IsEmpty(), recursive);
	}

	/// <summary>
	/// 删除当前目录下目录级别等于指定值的目录下的文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="level">待删除文件的目录级别</param>
	/// <param name="recursive">是否删除子目录中的文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">删除的目录级别 <paramref name="level" /> 小于0。</exception>
	public static void DeleteFiles(this DirectoryInfo directory, int level, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		level.GuardGreaterThanOrEqualTo(0, "level");
		foreach (DirectoryInfo dinfo in directory.Directories(level))
		{
			dinfo.ClearFiles(recursive);
		}
	}

	/// <summary>
	/// 删除当前目录下的所有与指定模式匹配的文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="searching">可删除文件的通配符模式</param>
	/// <param name="recursive">是否删除子目录中的文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="searching" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static void DeleteFiles(this DirectoryInfo directory, string searching, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		searching.GuardNotNull("searching");
		foreach (FileInfo finfo in directory.Files(searching, recursive))
		{
			if (finfo.Exists)
			{
				finfo.Delete();
			}
		}
	}

	/// <summary>
	/// 删除当前目录下的文件全名与指定模式匹配的文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="pattern">文件名称匹配模式</param>
	/// <param name="recursive">是否删除子目录中的文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static void DeleteFiles(this DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		pattern.GuardNotNull("pattern");
		foreach (FileInfo finfo in directory.Files(pattern, recursive))
		{
			if (finfo.Exists)
			{
				finfo.Delete();
			}
		}
	}

	/// <summary>
	/// 删除当前目录下的符合筛选条件的文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="predicate">文件删除筛选条件</param>
	/// <param name="recursive">是否删除子目录中的文件</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static void DeleteFiles(this DirectoryInfo directory, Func<FileInfo, bool> predicate, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		predicate.GuardNotNull("predicate");
		foreach (FileInfo finfo in directory.Files(predicate, recursive))
		{
			if (finfo.Exists)
			{
				finfo.Delete();
			}
		}
	}

	/// <summary>
	/// 枚举当前目录中的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="recursive">是否递归枚举当前目录下的所有子目录，默认为false</param>
	/// <returns>当前目录的子目录序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <remarks><paramref name="recursive" /> 为false，只枚举当前目录下的一级子目录；为true，则枚举当前目录下的所有子目录（包括子目录的子目录）。</remarks>
	public static IEnumerable<DirectoryInfo> Directories(this DirectoryInfo directory, bool recursive = false)
	{
		return directory.Directories("*", recursive);
	}

	/// <summary>
	/// 枚举当前目录中的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="levels">枚举目录的层级，只枚举层级等于指定值的子目录</param>
	/// <returns>当前目录的子目录序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="levels" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">枚举层级 <paramref name="levels" /> 小于0。</exception>
	public static IEnumerable<DirectoryInfo> Directories(this DirectoryInfo directory, params int[] levels)
	{
		return directory.Directories("*", levels);
	}

	/// <summary>
	/// 枚举当前目录中的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="searching">子目录搜索模式</param>
	/// <param name="recursive">是否递归枚举当前目录下的所有子目录，默认为false</param>
	/// <returns>当前目录的子目录序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="searching" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <remarks><paramref name="recursive" /> 为false，只枚举当前目录下的一级子目录；为true，则枚举当前目录下的所有子目录（包括子目录的子目录）。</remarks>
	public static IEnumerable<DirectoryInfo> Directories(this DirectoryInfo directory, string searching, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		searching.GuardNotNull("searching");
		return directory.EnumerateDirectories(searching, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
	}

	/// <summary>
	/// 枚举当前目录中的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="searching">子目录搜索模式</param>
	/// <param name="levels">枚举目录的层级，只枚举层级等于指定值的子目录</param>
	/// <returns>当前目录的子目录序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="searching" /> 为空；或者 <paramref name="levels" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">枚举层级 <paramref name="levels" /> 小于0。</exception>
	public static IEnumerable<DirectoryInfo> Directories(this DirectoryInfo directory, string searching, params int[] levels)
	{
		directory.GuardNotNull("directory").GuardExistence();
		searching.GuardNotNull("searching");
		levels.GuardNotNull("levels");
		levels.ForEach(delegate(int x)
		{
			x.GuardGreaterThanOrEqualTo(0, "level");
		});
		if (levels.Length == 0)
		{
			return new DirectoryInfo[0];
		}
		int[] newLevels = levels.Copy().Sort();
		return from d in directory.EnumerateDirectories(searching, SearchOption.AllDirectories)
			where newLevels.BinarySearch(d.GetLevel(directory)) >= 0
			select d;
	}

	/// <summary>
	/// 枚举当前目录中的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="pattern">目录全名匹配模式，包括目录名称和路径</param>
	/// <param name="recursive">是否递归枚举当前目录下的所有子目录，默认为false</param>
	/// <returns>当前目录的子目录序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <remarks><paramref name="recursive" /> 为false，只枚举当前目录下的一级子目录；为true，则枚举当前目录下的所有子目录（包括子目录的子目录）。</remarks>
	public static IEnumerable<DirectoryInfo> Directories(this DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		pattern.GuardNotNull("pattern");
		return directory.Directories((DirectoryInfo d) => pattern.IsMatch(d.FullName), recursive);
	}

	/// <summary>
	/// 枚举当前目录中的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="pattern">目录全名匹配模式，包括目录名称和路径</param>
	/// <param name="levels">枚举目录的层级，只枚举层级等于指定值的子目录</param>
	/// <returns>当前目录的子目录序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="pattern" /> 为空；或者 <paramref name="levels" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">枚举层级 <paramref name="levels" /> 小于0。</exception>
	public static IEnumerable<DirectoryInfo> Directories(this DirectoryInfo directory, Regex pattern, params int[] levels)
	{
		pattern.GuardNotNull("pattern");
		return directory.Directories((DirectoryInfo d) => pattern.IsMatch(d.FullName), levels);
	}

	/// <summary>
	/// 枚举当前目录中的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="predicate">目录筛选条件</param>
	/// <param name="recursive">是否递归枚举当前目录下的所有子目录，默认为false</param>
	/// <returns>当前目录的子目录序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <remarks><paramref name="recursive" /> 为false，只枚举当前目录下的一级子目录；为true，则枚举当前目录下的所有子目录（包括子目录的子目录）。</remarks>
	public static IEnumerable<DirectoryInfo> Directories(this DirectoryInfo directory, Func<DirectoryInfo, bool> predicate, bool recursive = false)
	{
		predicate.GuardNotNull("predicate");
		return directory.Directories("*", recursive).Where(predicate);
	}

	/// <summary>
	/// 枚举当前目录中的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="predicate">目录筛选条件</param>
	/// <param name="levels">枚举目录的层级，只枚举层级等于指定值的子目录</param>
	/// <returns>当前目录的子目录序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="levels" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">枚举层级 <paramref name="levels" /> 小于0。</exception>
	public static IEnumerable<DirectoryInfo> Directories(this DirectoryInfo directory, Func<DirectoryInfo, bool> predicate, params int[] levels)
	{
		predicate.GuardNotNull("predicate");
		return directory.Directories("*", levels).Where(predicate);
	}

	/// <summary>
	/// 枚举当前目录中文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="recursive">是否递归枚举当前目录下和其子目录下的文件，默认为false</param>
	/// <returns>目录中的文件集合</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static IEnumerable<FileInfo> Files(this DirectoryInfo directory, bool recursive = false)
	{
		return directory.Files("*");
	}

	/// <summary>
	/// 枚举当前目录中文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="levels">枚举目录的层级，只枚举层级等于指定值的子目录中的文件</param>
	/// <returns>目录中的文件集合</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="levels" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">枚举层级 <paramref name="levels" /> 小于0。</exception>
	public static IEnumerable<FileInfo> Files(this DirectoryInfo directory, params int[] levels)
	{
		return directory.Files("*", levels);
	}

	/// <summary>
	/// 枚举当前目录中文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="searching">文件搜索模式</param>
	/// <param name="recursive">是否递归枚举当前目录下和其子目录下的文件，默认为false</param>
	/// <returns>当前目录下的文件的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="searching" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static IEnumerable<FileInfo> Files(this DirectoryInfo directory, string searching, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		searching.GuardNotNull("searching");
		return directory.EnumerateFiles(searching, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
	}

	/// <summary>
	/// 枚举当前目录中文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="searching">文件搜索模式</param>
	/// <param name="levels">枚举目录的层级，只枚举层级等于指定值的子目录中的文件</param>
	/// <returns>当前目录下的文件的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="searching" /> 为空；或者 <paramref name="levels" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">枚举层级 <paramref name="levels" /> 小于0。</exception>
	public static IEnumerable<FileInfo> Files(this DirectoryInfo directory, string searching, params int[] levels)
	{
		directory.GuardNotNull("directory").GuardExistence();
		searching.GuardNotNull("searching");
		levels.GuardNotNull("levels");
		levels.ForEach(delegate(int x)
		{
			x.GuardGreaterThanOrEqualTo(0, "level");
		});
		if (levels.Length == 0)
		{
			return new FileInfo[0];
		}
		int[] newLevels = levels.Copy().Sort();
		return from f in directory.EnumerateFiles(searching, SearchOption.AllDirectories)
			where newLevels.BinarySearch(f.Directory.GetLevel(directory)) >= 0
			select f;
	}

	/// <summary>
	/// 枚举当前目录中的文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="pattern">文件全名匹配模式，包括文件名称和路径</param>
	/// <param name="recursive">是否递归枚举当前目录下和其子目录下的文件，默认为false</param>
	/// <returns>当前目录下的文件的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static IEnumerable<FileInfo> Files(this DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		pattern.GuardNotNull("pattern");
		return directory.Files((FileInfo f) => pattern.IsMatch(f.FullName), recursive);
	}

	/// <summary>
	/// 枚举当前目录中的文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="pattern">文件全名匹配模式，包括文件名称和路径</param>
	/// <param name="levels">枚举目录的层级，只枚举层级等于指定值的子目录中的文件</param>
	/// <returns>当前目录下的文件的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="pattern" /> 为空；或者 <paramref name="levels" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">枚举层级 <paramref name="levels" /> 小于0。</exception>
	public static IEnumerable<FileInfo> Files(this DirectoryInfo directory, Regex pattern, params int[] levels)
	{
		pattern.GuardNotNull("pattern");
		return directory.Files((FileInfo f) => pattern.IsMatch(f.FullName), levels);
	}

	/// <summary>
	/// 枚举当前目录中的文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="predicate">文件筛选条件</param>
	/// <param name="recursive">是否递归枚举当前目录下和其子目录下的文件，默认为false</param>
	/// <returns>当前目录下的文件的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static IEnumerable<FileInfo> Files(this DirectoryInfo directory, Func<FileInfo, bool> predicate, bool recursive = false)
	{
		predicate.GuardNotNull("predicate");
		return directory.Files("*", recursive).Where(predicate);
	}

	/// <summary>
	/// 枚举当前目录中的文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="predicate">文件筛选条件</param>
	/// <param name="levels">枚举目录的层级，只枚举层级等于指定值的子目录中的文件</param>
	/// <returns>当前目录下的文件的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="levels" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">枚举层级 <paramref name="levels" /> 小于0。</exception>
	public static IEnumerable<FileInfo> Files(this DirectoryInfo directory, Func<FileInfo, bool> predicate, params int[] levels)
	{
		predicate.GuardNotNull("predicate");
		return directory.Files("*", levels).Where(predicate);
	}

	/// <summary>
	/// 获取当前目录中与指定搜索模式匹配的第一个子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="searching">目录搜索模式</param>
	/// <param name="recursive">是否在子目录中查找</param>
	/// <returns>返回符合条件的第一个子目录，否则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="searching" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static DirectoryInfo GetDirectory(this DirectoryInfo directory, string searching, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		searching.GuardNotNull("searching");
		HashSet<DirectoryInfo> cache = new HashSet<DirectoryInfo>();
		cache.Add(directory);
		while (cache.Count > 0)
		{
			DirectoryInfo[] roots = cache.ToArray();
			DirectoryInfo[] array = roots;
			foreach (DirectoryInfo root in array)
			{
				DirectoryInfo result = root.Directories(searching).FirstOrDefault();
				if (result.IsNotNull())
				{
					return result;
				}
				if (recursive)
				{
					cache.AddRange(root.Directories());
				}
				cache.Remove(root);
			}
		}
		return null;
	}

	/// <summary>
	/// 获取当前目录中目录全名与指定模式匹配的第一个子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="pattern">目录全名匹配模式</param>
	/// <param name="recursive">是否在子目录中查找</param>
	/// <returns>返回符合条件的第一个子目录，否则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static DirectoryInfo GetDirectory(this DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		pattern.GuardNotNull("pattern");
		return directory.GetDirectory((DirectoryInfo d) => pattern.IsMatch(d.FullName), recursive);
	}

	/// <summary>
	/// 获取当前目录中满足指定筛选条件的第一个子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="predicate">目录筛选条件</param>
	/// <param name="recursive">是否在子目录中查找</param>
	/// <returns>返回符合条件的第一个子目录，否则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static DirectoryInfo GetDirectory(this DirectoryInfo directory, Func<DirectoryInfo, bool> predicate, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		predicate.GuardNotNull("predicate");
		HashSet<DirectoryInfo> cache = new HashSet<DirectoryInfo>();
		cache.Add(directory);
		while (cache.Count > 0)
		{
			DirectoryInfo[] roots = cache.ToArray();
			DirectoryInfo[] array = roots;
			foreach (DirectoryInfo root in array)
			{
				foreach (DirectoryInfo dinfo in root.Directories())
				{
					if (predicate.IsNull() || predicate(dinfo))
					{
						return dinfo;
					}
					if (recursive)
					{
						cache.Add(dinfo);
					}
				}
				cache.Remove(root);
			}
		}
		return null;
	}

	/// <summary>
	/// 获取当前目录的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="recursive">是否获取全部子目录</param>
	/// <returns>当前目录的子目录的数组；如果当前目录没有子目录，返回空数组。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static DirectoryInfo[] GetDirectories(this DirectoryInfo directory, bool recursive)
	{
		directory.GuardNotNull("directory").GuardExistence();
		return directory.GetDirectories("*", recursive);
	}

	/// <summary>
	/// 获取当前目录中与指定搜索模式匹配的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="searching">目录搜索模式</param>
	/// <param name="recursive">是否搜索全部子目录</param>
	/// <returns>找到匹配的子目录的数组；如果没有符合条件的子目录，返回空数组。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="searching" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static DirectoryInfo[] GetDirectories(this DirectoryInfo directory, string searching, bool recursive)
	{
		directory.GuardNotNull("directory").GuardExistence();
		searching.GuardNotNull("searching");
		return directory.GetDirectories(searching, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
	}

	/// <summary>
	/// 获取当前目录中目录全名与指定模式匹配的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="pattern">目录全名匹配模式</param>
	/// <param name="recursive">是否搜索全部子目录</param>
	/// <returns>找到匹配的子目录的数组；如果没有符合条件的子目录，返回空数组。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static DirectoryInfo[] GetDirectories(this DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		pattern.GuardNotNull("pattern");
		return directory.Directories(pattern, recursive).ToArray();
	}

	/// <summary>
	/// 获取当前目录中满足指定筛选条件的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="predicate">子目录的筛选条件</param>
	/// <param name="recursive">是否搜索全部子目录</param>
	/// <returns>找到符合条件的子目录的数组；如果没有符合条件的子目录，返回空数组。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static DirectoryInfo[] GetDirectories(this DirectoryInfo directory, Func<DirectoryInfo, bool> predicate, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		predicate.GuardNotNull("predicate");
		return directory.Directories(predicate, recursive).ToArray();
	}

	/// <summary>
	/// 获得当前目录所在驱动器的信息
	/// </summary>
	/// <param name="directory">当前的目录</param>
	/// <returns>当前的目录所在的驱动器的信息</returns>
	public static DriveInfo GetDrive(this DirectoryInfo directory)
	{
		directory.GuardNotNull("directory");
		return new DriveInfo(directory.Root.FullName);
	}

	/// <summary>
	/// 获取当前目录中与指定搜索模式匹配的第一个文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="searching">文件搜索模式</param>
	/// <param name="recursive">是否在子目录中查找</param>
	/// <returns>返回符合条件的第一个文件，否则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="searching" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static FileInfo GetFile(this DirectoryInfo directory, string searching, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		searching.GuardNotNull("searching");
		HashSet<DirectoryInfo> cache = new HashSet<DirectoryInfo>();
		cache.Add(directory);
		while (cache.Count > 0)
		{
			DirectoryInfo[] roots = cache.ToArray();
			DirectoryInfo[] array = roots;
			foreach (DirectoryInfo root in array)
			{
				FileInfo result = root.Files(searching).FirstOrDefault();
				if (result.IsNotNull())
				{
					return result;
				}
				if (recursive)
				{
					cache.AddRange(root.Directories());
				}
				cache.Remove(root);
			}
		}
		return null;
	}

	/// <summary>
	/// 获取当前目录中文件全名与指定模式匹配的第一个文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="pattern">文件全名匹配模式</param>
	/// <param name="recursive">是否在子目录中查找</param>
	/// <returns>返回符合条件的第一个文件，否则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static FileInfo GetFile(this DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		pattern.GuardNotNull("pattern");
		return directory.GetFile((FileInfo f) => pattern.IsMatch(f.FullName), recursive);
	}

	/// <summary>
	/// 获取当前目录中满足指定筛选条件的第一个文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="predicate">文件筛选条件</param>
	/// <param name="recursive">是否在子目录中查找</param>
	/// <returns>返回符合条件的第一个文件，否则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static FileInfo GetFile(this DirectoryInfo directory, Func<FileInfo, bool> predicate, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		predicate.GuardNotNull("predicate");
		HashSet<DirectoryInfo> cache = new HashSet<DirectoryInfo>();
		cache.Add(directory);
		while (cache.Count > 0)
		{
			DirectoryInfo[] roots = cache.ToArray();
			DirectoryInfo[] array = roots;
			foreach (DirectoryInfo root in array)
			{
				FileInfo result = root.Files(predicate).FirstOrDefault();
				if (result.IsNotNull())
				{
					return result;
				}
				if (recursive)
				{
					cache.AddRange(root.Directories());
				}
				cache.Remove(root);
			}
		}
		return null;
	}

	/// <summary>
	/// 获取当前目录下的文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="recursive">是否在子目录中查找</param>
	/// <returns>当前目录下的文件的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static FileInfo[] GetFiles(this DirectoryInfo directory, bool recursive)
	{
		return directory.GetFiles("*", recursive);
	}

	/// <summary>
	/// 获取当前目录下与指定搜索模式匹配的文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="searching">文件搜索模式</param>
	/// <param name="recursive">是否搜索全部子目录中的文件</param>
	/// <returns>找到符合条件的文件的数组；如果没有符合条件的文件，返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="searching" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static FileInfo[] GetFiles(this DirectoryInfo directory, string searching, bool recursive)
	{
		directory.GuardNotNull("directory").GuardExistence();
		searching.GuardNotNull("searching");
		return directory.GetFiles(searching, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
	}

	/// <summary>
	/// 获取当前目录中文件全名与指定模式匹配的文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="pattern">文件全名匹配模式</param>
	/// <param name="recursive">是否搜索全部子目录中的文件</param>
	/// <returns>找到符合条件的文件的数组；如果没有符合条件的文件，返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static FileInfo[] GetFiles(this DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		pattern.GuardNotNull("pattern");
		return directory.GetFiles((FileInfo f) => pattern.IsMatch(f.FullName), recursive);
	}

	/// <summary>
	/// 获取当前目录中满足指定筛选条件的文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="predicate">文件的筛选条件</param>
	/// <param name="recursive">是否搜索全部子目录中的文件</param>
	/// <returns>找到符合条件的文件的数组；如果没有符合条件的文件，返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static FileInfo[] GetFiles(this DirectoryInfo directory, Func<FileInfo, bool> predicate, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		predicate.GuardNotNull("predicate");
		return directory.Files(predicate, recursive).ToArray();
	}

	/// <summary>
	/// 获取当前目录下的文件的数量
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="recursive">是否获取当前目录及所有子目录下文件的数量</param>
	/// <returns>文件的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	public static int GetFileCount(this DirectoryInfo directory, bool recursive = false)
	{
		directory.GuardNotNull("directory");
		return directory.Files(recursive).Count();
	}

	/// <summary>
	/// 计算当前目录下文件的大小（字节）
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="recursive">是否搜索全部子目录中的文件</param>
	/// <returns>符合条件的所有文件的大小</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	public static long GetFileSize(this DirectoryInfo directory, bool recursive = false)
	{
		return directory.GetFileSize("*", recursive);
	}

	/// <summary>
	/// 计算当前目录中与指定搜索模式匹配的文件的大小（字节）
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="searching">文件搜索模式</param>
	/// <param name="recursive">是否搜索全部子目录中的文件</param>
	/// <returns>符合条件的所有文件的大小</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="searching" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static long GetFileSize(this DirectoryInfo directory, string searching, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		searching.GuardNotNull("searching");
		return directory.Files(searching, recursive).Sum((FileInfo x) => x.Length);
	}

	/// <summary>
	/// 计算当前目录中文件全名与指定模式匹配的文件的大小（字节）
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="pattern">文件全名匹配模式</param>
	/// <param name="recursive">是否搜索全部子目录中的文件</param>
	/// <returns>符合条件的所有文件的大小</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static long GetFileSize(this DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		pattern.GuardNotNull("pattern");
		return directory.GetFileSize((FileInfo f) => pattern.IsMatch(f.FullName), recursive);
	}

	/// <summary>
	/// 计算当前目录下符合指定条件的文件的大小（字节）
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="predicate">文件筛选方法</param>
	/// <param name="recursive">是否搜索全部子目录中的文件</param>
	/// <returns>符合条件的所有文件的大小</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static long GetFileSize(this DirectoryInfo directory, Func<FileInfo, bool> predicate, bool recursive = false)
	{
		return directory.Files(predicate, recursive).Sum((FileInfo x) => x.Length);
	}

	/// <summary>
	/// 获取当前目录的层级
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="basePath">获取目录层级的基准目录；如果基准目录为空，则以当前目录的根目录作为基准目录。</param>
	/// <returns>当前目录相对于基准目录的层级；如果基准目录为空，则返回当前目录相对于其根目录的层级。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.ArgumentException">基准目录 <paramref name="basePath" /> 不在当前目录的目录结构中。</exception>
	public static int GetLevel(this DirectoryInfo directory, DirectoryInfo basePath = null)
	{
		directory.GuardNotNull("directory");
		return directory.GetRelativePath(basePath).Split(new char[1] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries).Length;
	}

	/// <summary>
	/// 获取当前目录的层级
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="basePath">获取目录层级的基准目录</param>
	/// <returns>当前目录相对于基准目录的层级；如果基准目录为空，则返回当前目录相对于其根目录的层级。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者基准目录 <paramref name="basePath" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">基准目录 <paramref name="basePath" /> 无效；或者不在当前目录的目录结构中。</exception>
	public static int GetLevel(this DirectoryInfo directory, string basePath)
	{
		directory.GuardNotNull("directory");
		basePath.GuardNotNull("base path");
		return directory.GetLevel(new DirectoryInfo(basePath));
	}

	/// <summary>
	/// 获取当前目录与指定的基准目录之间的相对路径
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="basePath">指定的基准目录；如果基准目录为空，则以当前目录的根目录作为基准目录。</param>
	/// <returns>当前目录与指定的基准目录之间的相对路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.ArgumentException">基准目录 <paramref name="basePath" /> 不在当前目录的目录结构中。</exception>
	public static string GetRelativePath(this DirectoryInfo directory, DirectoryInfo basePath = null)
	{
		directory.GuardNotNull("directory");
		if (basePath.IsNull())
		{
			basePath = directory.GetRoot();
		}
		else
		{
			basePath.Guard(directory.FullName.IndexOf(basePath.FullName) == 0, "base path");
		}
		return directory.FullName.TrimStart(basePath.FullName).Trim(Path.DirectorySeparatorChar);
	}

	/// <summary>
	/// 获取当前目录与指定的基准目录之间的相对路径
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="basePath">指定的基准目录路径</param>
	/// <returns>当前目录与指定的基准目录之间的相对路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者基准目录路径 <paramref name="basePath" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">基准目录 <paramref name="basePath" /> 无效，或者不在当前目录的目录结构中。</exception>
	public static string GetRelativePath(this DirectoryInfo directory, string basePath)
	{
		directory.GuardNotNull("directory");
		basePath.GuardNotNull("base path");
		return directory.GetRelativePath(new DirectoryInfo(basePath));
	}

	/// <summary>
	/// 获取当前目录的根目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <returns>当前目录的根目录</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <remarks>在当前目录的目录结构中进行回溯，没有父级目录的目录认为是根目录。</remarks>
	public static DirectoryInfo GetRoot(this DirectoryInfo directory)
	{
		directory.GuardNotNull("directory");
		while (directory.Parent.IsNotNull())
		{
			directory = directory.Parent;
		}
		return directory;
	}

	/// <summary>
	/// 检测当前目录是否存在，如果不存在则抛出 <see cref="T:System.IO.DirectoryNotFoundException" /> 异常。
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="message">错误消息</param>
	/// <returns>如果当前目录存在则返回当前目录</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static DirectoryInfo GuardExistence(this DirectoryInfo directory, string message = null)
	{
		directory.GuardNotNull("directory");
		directory.Guard(directory.Exists, () => new DirectoryNotFoundException(message.IfNull(Literals.MSG_DirectoryNotFound_1.FormatValue(directory.FullName))));
		return directory;
	}

	/// <summary>
	/// 检测当前目录是否存在，如果当前目录不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前目录存在则返回当前目录</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前目录不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static DirectoryInfo GuardExistence(this DirectoryInfo directory, Func<Exception> exceptionCreator)
	{
		directory.GuardNotNull("directory");
		directory.Guard(directory.Exists, exceptionCreator);
		return directory;
	}

	/// <summary>
	/// 检测当前目录是否存在，如果当前目录不存在则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前目录存在则返回当前目录</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前目录不存在则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static DirectoryInfo GuardExistence(this DirectoryInfo directory, Type exceptionType, params object[] args)
	{
		directory.GuardNotNull("directory");
		directory.Guard(directory.Exists, exceptionType, args);
		return directory;
	}

	/// <summary>
	/// 检测当前目录是否为空
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <returns>如果当前目录为空（不包括任何文件和子目录）则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static bool IsEmpty(this DirectoryInfo directory)
	{
		directory.GuardNotNull("directory").GuardExistence();
		return !directory.Files().Any() && !directory.Directories().Any();
	}

	/// <summary>
	/// 加载当前目录下的文件中的程序集
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="recursive">是否在子目录中查找文件</param>
	/// <returns>加载的程序集数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <remarks>搜索当前目录下扩展名为 "dll" 的文件。</remarks>
	public static Assembly[] LoadAssemblies(this DirectoryInfo directory, bool recursive = false)
	{
		return directory.LoadAssemblies("*.dll", (AssemblyName a) => true, recursive);
	}

	/// <summary>
	/// 加载当前目录下的满足指定筛选条件的文件中的程序集
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="assemblyPredicate">程序集筛选方法</param>
	/// <param name="recursive">是否在子目录中查找</param>
	/// <returns>加载的程序集数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者筛选方法 <paramref name="assemblyPredicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <remarks>搜索当前目录下扩展名为 "dll" 的文件。</remarks>
	public static Assembly[] LoadAssemblies(this DirectoryInfo directory, Func<AssemblyName, bool> assemblyPredicate, bool recursive = false)
	{
		return directory.LoadAssemblies("*.dll", assemblyPredicate, recursive);
	}

	/// <summary>
	/// 加载当前目录下的满足指定筛选条件的程序集
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="searching">程序集文件搜索模式</param>
	/// <param name="assemblyPredicate">程序集筛选方法；如果为空，则忽略程序集筛选。</param>
	/// <param name="recursive">是否在子目录中查找</param>
	/// <returns>加载的程序集数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="searching" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static Assembly[] LoadAssemblies(this DirectoryInfo directory, string searching, Func<AssemblyName, bool> assemblyPredicate, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		searching.GuardNotNull("searching");
		assemblyPredicate.GuardNotNull("assembly predicate");
		return LoadAssemblies(directory, (DirectoryInfo d) => d.Files(searching, recursive), assemblyPredicate);
	}

	/// <summary>
	/// 加载当前目录下文件全名与指定模式匹配的文件中的程序集
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="pattern">文件全名匹配模式</param>
	/// <param name="assemblyPredicate">程序集筛选方法；如果为空，则忽略程序集筛选。</param>
	/// <param name="recursive">是否在子目录中查找文件</param>
	/// <returns>加载的程序集数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者筛选方法 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static Assembly[] LoadAssemblies(this DirectoryInfo directory, Regex pattern, Func<AssemblyName, bool> assemblyPredicate, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		pattern.GuardNotNull("pattern");
		assemblyPredicate.GuardNotNull("assembly predicate");
		return directory.LoadAssemblies((FileInfo f) => pattern.IsMatch(f.FullName), assemblyPredicate, recursive);
	}

	/// <summary>
	/// 加载当前目录下的满足指定筛选条件的程序集
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="predicate">程序集文件筛选方法</param>
	/// <param name="assemblyPredicate">程序集筛选方法；如果为空，则忽略程序集筛选。</param>
	/// <param name="recursive">是否在子目录中查找文件</param>
	/// <returns>加载的程序集数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者筛选方法 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static Assembly[] LoadAssemblies(this DirectoryInfo directory, Func<FileInfo, bool> predicate, Func<AssemblyName, bool> assemblyPredicate, bool recursive = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		predicate.GuardNotNull("predicate");
		assemblyPredicate.GuardNotNull("assembly predicate");
		return LoadAssemblies(directory, (DirectoryInfo d) => d.Files(predicate, recursive), assemblyPredicate);
	}

	private static Assembly[] LoadAssemblies(DirectoryInfo directory, Func<DirectoryInfo, IEnumerable<FileInfo>> enumerator, Func<AssemblyName, bool> assemblyPredicate)
	{
		List<Assembly> assemblies = new List<Assembly>();
		foreach (FileInfo finfo in enumerator(directory))
		{
			try
			{
				AssemblyName name = AssemblyName.GetAssemblyName(finfo.FullName);
				if (assemblyPredicate.IsNull() || assemblyPredicate(name))
				{
					assemblies.Add(name.Load());
				}
			}
			catch (ArgumentNullException)
			{
			}
			catch (BadImageFormatException)
			{
			}
		}
		return assemblies.ToArray();
	}

	/// <summary>
	/// 设置当前目录下文件的属性
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="attributes">待设置的属性</param>
	/// <param name="recursive">是否在子目录中查找文件</param>
	/// <param name="append">是否追加到文件的现有属性，否则重写现有属性。</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static void SetFileAttributes(this DirectoryInfo directory, FileAttributes attributes, bool recursive = true, bool append = false)
	{
		directory.SetFileAttributes("*", attributes, recursive, append);
	}

	/// <summary>
	/// 设置当前目录下与指定搜索模式匹配的文件的属性
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="searching">文件搜索模式</param>
	/// <param name="attributes">设置的文件属性</param>
	/// <param name="recursive">是否在子目录中查找文件</param>
	/// <param name="append">是否追加到文件的现有属性，否则重写现有属性。</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者筛选方法 <paramref name="searching" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static void SetFileAttributes(this DirectoryInfo directory, string searching, FileAttributes attributes, bool recursive = true, bool append = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		searching.GuardNotNull("searching");
		SetFileAttributes(directory, (DirectoryInfo d) => d.Files(searching, recursive), attributes, append);
	}

	/// <summary>
	/// 设置当前目录下文件全名与指定模式匹配的文件的属性
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="pattern">文件全名匹配模式</param>
	/// <param name="attributes">设置的文件属性</param>
	/// <param name="recursive">是否在子目录中查找文件</param>
	/// <param name="append">是否追加到文件的现有属性，否则重写现有属性。</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者筛选方法 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static void SetFileAttributes(this DirectoryInfo directory, Regex pattern, FileAttributes attributes, bool recursive = true, bool append = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		pattern.GuardNotNull("pattern");
		SetFileAttributes(directory, (DirectoryInfo d) => d.Files(pattern, recursive), attributes, append);
	}

	/// <summary>
	/// 设置当前目录下符合指定筛选条件的文件的属性
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="predicate">文件筛选方法</param>
	/// <param name="attributes">设置的文件属性</param>
	/// <param name="recursive">是否在子目录中查找文件</param>
	/// <param name="append">是否追加到文件的现有属性，否则重写现有属性。</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者筛选方法 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static void SetFileAttributes(this DirectoryInfo directory, Func<FileInfo, bool> predicate, FileAttributes attributes, bool recursive = false, bool append = false)
	{
		directory.GuardNotNull("directory").GuardExistence();
		predicate.GuardNotNull("predicate");
		SetFileAttributes(directory, (DirectoryInfo d) => d.Files(predicate, recursive), attributes, append);
	}

	private static void SetFileAttributes(DirectoryInfo directory, Func<DirectoryInfo, IEnumerable<FileInfo>> enumerator, FileAttributes attributes, bool append)
	{
		foreach (FileInfo finfo in enumerator(directory))
		{
			if (finfo.Exists)
			{
				finfo.SetAttributes(attributes, append);
			}
		}
	}
}
