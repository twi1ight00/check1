#define DEBUG
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Richfit.Garnet.Common.IO;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Text;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// IO辅助类
/// </summary>
public static class IOHelper
{
	/// <summary>
	/// 向当前文件中追加文本
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="text">追加的文本</param>
	/// <param name="encoding">追加的文本的字符编码，默认为UTF-8</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="text" /> 为空。</exception>
	public static void Append(FileInfo file, string text, Encoding encoding = null)
	{
		WriteText(file, text, append: true, encoding);
	}

	/// <summary>
	/// 向当前文件中追加字节数据
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="bytes">追加的字节数据</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="bytes" /> 为空。</exception>
	public static void Append(FileInfo file, byte[] bytes)
	{
		WriteBytes(file, bytes, append: true);
	}

	/// <summary>
	/// 向当前文件中追加字节流
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="stream">追加的字节流</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="stream" /> 为空。</exception>
	public static void Append(FileInfo file, Stream stream)
	{
		WriteBytes(file, stream, append: true);
	}

	/// <summary>
	/// 组合基础路径和当前路径
	/// </summary>
	/// <param name="path">当前路径</param>
	/// <param name="basePaths">基础路径</param>
	/// <returns>基础路径拼接上主路径后的规范化路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径为空；或者基础路径 <paramref name="basePaths" /> 为空。</exception>
	public static string BuildPath(string path, params string[] basePaths)
	{
		Guard.AssertNotNull(path, "path");
		Guard.AssertNotNull(basePaths, "base paths");
		return NormalizePath(Path.Combine(CollectionHelper.Append(basePaths, path).ToArray()));
	}

	/// <summary>
	/// 更改当前文件的扩展名
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="extension">文件新的扩展名，扩展名不包含扩展名分割句点。</param>
	/// <param name="overwrite">如果目标文件存在，是否覆盖目标文件</param>
	/// <returns>更名后的文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者指定的扩展名 <paramref name="extension" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，更名的目标文件已经存在。</exception>
	public static FileInfo ChangeExtension(FileInfo file, string extension, bool overwrite = false)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(extension, "extension");
		string targetName = GetFileNameWithoutExtension(file) + (TextHelper.IsNotNullAndEmpty(extension) ? ("." + extension) : string.Empty);
		FileInfo target = new FileInfo(Path.Combine(file.DirectoryName, targetName));
		MoveTo(file, target, overwrite);
		return target;
	}

	/// <summary>
	/// 更改当前文件的扩展名
	/// </summary>
	/// <param name="file">当前文件名称，可以包含路径</param>
	/// <param name="extension">修改的扩展名，可以包含或者不包含句点；如果为空或者空串则移除扩展名</param>
	/// <returns>处理后的文件名称</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件名称为空。</exception>
	public static string ChangeExtension(string file, string extension)
	{
		Guard.AssertNotNull(file, "file");
		return Path.ChangeExtension(file, extension);
	}

	/// <summary>
	/// 清空当前的目录，删除当前目录下的所有文件和子目录
	/// </summary>
	/// <param name="directory">当前的目录</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static void Clear(DirectoryInfo directory)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		CollectionHelper.ForEach(Directories(directory), delegate(DirectoryInfo d)
		{
			d.Delete(recursive: true);
		});
		CollectionHelper.ForEach(Files(directory), delegate(FileInfo f)
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
	public static void ClearDirectories(DirectoryInfo directory)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		CollectionHelper.ForEach(Directories(directory), delegate(DirectoryInfo d)
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
	public static void ClearFiles(DirectoryInfo directory, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		CollectionHelper.ForEach(Files(directory, recursive), delegate(FileInfo f)
		{
			f.Delete();
		});
	}

	/// <summary>
	/// 判断当前文件中是否包含Html标记
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="encoding">当前文件的字符编码，默认为UTF-8</param>
	/// <returns>如果文件中的内容包含Html标记返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static bool ContainsHtmlTags(FileInfo file, Encoding encoding = null)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		return RegexPatterns.HtmlTag.IsMatch(ReadAllText(file, encoding));
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
	public static DirectoryInfo CopyTo(DirectoryInfo directory, string targetPath, bool overwrite = false, int[] levels = null)
	{
		return CopyTo(directory, targetPath, "*", "*", overwrite, levels);
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
	public static DirectoryInfo CopyTo(DirectoryInfo directory, string targetPath, string directorySearching, string fileSearching, bool overwrite = false, int[] levels = null)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(targetPath, "targetPath");
		Guard.AssertNotNull(directorySearching, "directory searching");
		Guard.AssertNotNull(fileSearching, "file searching");
		if (ObjectHelper.IsNull(levels))
		{
			return CopyTo(directory, targetPath, (DirectoryInfo d) => Directories(d, directorySearching), (DirectoryInfo f) => Files(f, fileSearching), overwrite);
		}
		CollectionHelper.ForEach(levels, delegate(int x)
		{
			Guard.AssertGreaterThanOrEqualTo(x, 0, "level");
		});
		return CopyTo(directory, targetPath, (DirectoryInfo d) => Directories(d, directorySearching, levels), (DirectoryInfo f) => Files(f, fileSearching), overwrite, levels);
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
	public static DirectoryInfo CopyTo(DirectoryInfo directory, string targetPath, Regex pattern, bool overwrite = false, int[] levels = null)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return CopyTo(directory, targetPath, (FileSystemInfo x) => pattern.IsMatch(x.FullName), overwrite, levels);
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
	public static DirectoryInfo CopyTo(DirectoryInfo directory, string targetPath, Func<FileSystemInfo, bool> predicate, bool overwrite = false, int[] levels = null)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(targetPath, "targetPath");
		Guard.AssertNotNull(predicate, "predicate");
		if (ObjectHelper.IsNull(levels))
		{
			return CopyTo(directory, targetPath, (DirectoryInfo d) => Directories(d, predicate), (DirectoryInfo f) => Files(f, predicate), overwrite);
		}
		CollectionHelper.ForEach(levels, delegate(int x)
		{
			Guard.AssertGreaterThanOrEqualTo(x, 0, "level");
		});
		return CopyTo(directory, targetPath, (DirectoryInfo d) => Directories(d, predicate, levels), (DirectoryInfo f) => Files(f, predicate), overwrite, levels);
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
			targetPath = Path.Combine(target.FullName, GetRelativePath(dinfo, directory));
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
	/// 复制当前文件到指定位置
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="target">复制的目标文件</param>
	/// <param name="overwrite">如果目标文件存在是否覆盖</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者复制的目标文件 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，复制的目标文件已经存在。</exception>
	public static void CopyTo(FileInfo file, FileInfo target, bool overwrite = false)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(target, "target");
		if (!overwrite && target.Exists)
		{
			throw new IOException(string.Format(Literals.MSG_FileExistsException_1, target.FullName));
		}
		if (!target.Directory.Exists)
		{
			target.Directory.Create(file.Directory.GetAccessControl(AccessControlSections.All));
		}
		if (target.Exists)
		{
			target.Delete();
		}
		file.CopyTo(target.FullName, overwrite: true);
		file.Refresh();
		target.Refresh();
	}

	/// <summary>
	/// 复制当前文件到指定位置
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="targetFile">复制的目标文件路径</param>
	/// <param name="predicate">文件复制条件；如果返回true，则复制当前文件，否则不复制。</param>
	/// <returns>复制后的文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者复制的目标文件路径 <paramref name="targetFile" /> 为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static FileInfo CopyTo(FileInfo file, string targetFile, Func<FileInfo, FileInfo, bool> predicate)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNullAndEmpty(targetFile, "target file");
		Guard.AssertNotNull(predicate, "predicate");
		FileInfo target = new FileInfo(targetFile);
		if (predicate(file, target))
		{
			file.Refresh();
			target.Refresh();
			CopyTo(file, target, overwrite: true);
		}
		return target;
	}

	/// <summary>
	/// 复制当期文件到指定的目录中
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="directory">复制的目标路径</param>
	/// <param name="overwrite">如果复制的目标文件存在，是否覆盖目标文件</param>
	/// <returns>复制后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者复制的目标路径 <paramref name="directory" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，复制的目标文件已经存在。</exception>
	public static FileInfo CopyTo(FileInfo file, DirectoryInfo directory, bool overwrite = false)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(directory, "directory");
		FileInfo target = new FileInfo(Path.Combine(directory.FullName, file.Name));
		CopyTo(file, target, overwrite);
		return target;
	}

	/// <summary>
	/// 复制当期文件到指定的目录中
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="directory">复制的目标路径</param>
	/// <param name="predicate">文件复制筛选条件</param>
	/// <returns>复制后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者复制的目标路径 <paramref name="directory" /> 为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static FileInfo CopyTo(FileInfo file, DirectoryInfo directory, Func<FileInfo, FileInfo, bool> predicate)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertNotNull(predicate, "predicate");
		FileInfo target = new FileInfo(Path.Combine(directory.FullName, file.Name));
		if (predicate(file, target))
		{
			file.Refresh();
			target.Refresh();
			CopyTo(file, target, overwrite: true);
		}
		return target;
	}

	/// <summary>
	/// 复制当期文件到指定的目录中
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="directoryPath">复制的目标路径</param>
	/// <param name="filename">复制的目标名称，如果为空，则与源文件同名</param>
	/// <param name="overwrite">如果复制的目标文件存在，是否覆盖目标文件</param>
	/// <returns>复制后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者复制的目标路径 <paramref name="directoryPath" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，复制的目标文件已经存在。</exception>
	public static FileInfo CopyTo(FileInfo file, string directoryPath, string filename, bool overwrite = false)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNullAndEmpty(directoryPath, "directory path");
		FileInfo target = new FileInfo(Path.Combine(directoryPath, ObjectHelper.IfNull(filename, file.Name)));
		CopyTo(file, target, overwrite);
		return target;
	}

	/// <summary>
	/// 复制当期文件到指定的目录中
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="directoryPath">复制的目标路径</param>
	/// <param name="filename">复制的目标名称，如果为空，则与源文件同名</param>
	/// <param name="predicate">文件复制筛选条件</param>
	/// <returns>复制后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者复制的目标路径 <paramref name="directoryPath" /> 为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static FileInfo CopyTo(FileInfo file, string directoryPath, string filename, Func<FileInfo, FileInfo, bool> predicate)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNullAndEmpty(directoryPath, "directory path");
		Guard.AssertNotNull(predicate, "predicate");
		FileInfo target = new FileInfo(Path.Combine(directoryPath, ObjectHelper.IfNull(filename, file.Name)));
		if (predicate(file, target))
		{
			file.Refresh();
			target.Refresh();
			CopyTo(file, target, overwrite: true);
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
	public static DirectoryInfo CopyDirectories(DirectoryInfo directory, string targetPath, bool recursive = false)
	{
		return CopyDirectories(directory, targetPath, "*", recursive);
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
	public static DirectoryInfo CopyDirectories(DirectoryInfo directory, string targetPath, params int[] levels)
	{
		return CopyDirectories(directory, targetPath, "*", levels);
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
	public static DirectoryInfo CopyDirectories(DirectoryInfo directory, string targetPath, string searching, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(targetPath, "targetPath");
		Guard.AssertNotNull(searching, "searching");
		return CopyDirectories(directory, targetPath, (DirectoryInfo d) => Directories(d, searching, recursive));
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
	public static DirectoryInfo CopyDirectories(DirectoryInfo directory, string targetPath, string searching, params int[] levels)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(targetPath, "targetPath");
		Guard.AssertNotNull(searching, "searching");
		Guard.AssertNotNull(levels, "levels");
		CollectionHelper.ForEach(levels, delegate(int x)
		{
			Guard.AssertGreaterThanOrEqualTo(x, 0, "level");
		});
		return CopyDirectories(directory, targetPath, (DirectoryInfo d) => Directories(d, searching, levels));
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
	public static DirectoryInfo CopyDirectories(DirectoryInfo directory, string targetPath, Regex pattern, bool recursive = false)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return CopyDirectories(directory, targetPath, (DirectoryInfo d) => pattern.IsMatch(d.FullName), recursive);
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
	public static DirectoryInfo CopyDirectories(DirectoryInfo directory, string targetPath, Regex pattern, params int[] levels)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return CopyDirectories(directory, targetPath, (DirectoryInfo d) => pattern.IsMatch(d.FullName), levels);
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
	public static DirectoryInfo CopyDirectories(DirectoryInfo directory, string targetPath, Func<DirectoryInfo, bool> predicate, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(targetPath, "targetPath");
		Guard.AssertNotNull(predicate, "predicate");
		return CopyDirectories(directory, targetPath, (DirectoryInfo d) => Directories(d, predicate, recursive));
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
	public static DirectoryInfo CopyDirectories(DirectoryInfo directory, string targetPath, Func<DirectoryInfo, bool> predicate, params int[] levels)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(targetPath, "targetPath");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(levels, "levels");
		CollectionHelper.ForEach(levels, delegate(int x)
		{
			Guard.AssertGreaterThanOrEqualTo(x, 0, "level");
		});
		return CopyDirectories(directory, targetPath, (DirectoryInfo d) => Directories(d, predicate, levels));
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
			targetPath = Path.Combine(target.FullName, GetRelativePath(dinfo, directory));
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
	public static DirectoryInfo CopyFiles(DirectoryInfo directory, string targetPath, bool overwrite = false)
	{
		return CopyFiles(directory, targetPath, "*", overwrite);
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
	public static DirectoryInfo CopyFiles(DirectoryInfo directory, string targetPath, string searching, bool overwrite = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(targetPath, "targetPath");
		Guard.AssertNotNull(searching, "searching");
		return CopyFiles(directory, targetPath, (DirectoryInfo d) => Files(d, searching), overwrite);
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
	public static DirectoryInfo CopyFiles(DirectoryInfo directory, string targetPath, Regex pattern, bool overwrite = false)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return CopyFiles(directory, targetPath, (FileInfo f) => pattern.IsMatch(f.FullName), overwrite);
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
	public static DirectoryInfo CopyFiles(DirectoryInfo directory, string targetPath, Func<FileInfo, bool> predicate, bool overwrite = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(targetPath, "targetPath");
		Guard.AssertNotNull(predicate, "predicate");
		return CopyFiles(directory, targetPath, (DirectoryInfo d) => Files(d, predicate), overwrite);
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
	/// 在临时路径中创建临时文件
	/// </summary>
	/// <param name="tempPath">临时路径；如果为空则使用系统默认的临时路径</param>
	/// <returns>创建的临时文件的路径（文件全名）</returns>
	public static string CreateTempFile(string tempPath = null)
	{
		tempPath = ObjectHelper.IfNull(tempPath, Path.GetTempPath()).TrimEnd('\\', '/');
		try
		{
			if (!Directory.Exists(tempPath))
			{
				Directory.CreateDirectory(tempPath);
			}
		}
		catch (Exception ex)
		{
			throw new DirectoryNotFoundException(string.Format(Literals.MSG_DirectoryNotFound_1, tempPath), ex);
		}
		string file = null;
		while (ObjectHelper.IsNull(file) || File.Exists(file))
		{
			file = Path.Combine(tempPath, Path.GetRandomFileName());
		}
		return file;
	}

	/// <summary>
	/// 在临时路径中创建临时文件
	/// </summary>
	/// <param name="tempPath">临时路径</param>
	/// <returns>创建的临时文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">临时路径 <paramref name="tempPath" /> 为空。</exception>
	public static FileInfo CreateTempFile(DirectoryInfo tempPath)
	{
		return ToFileInfo(CreateTempFile(tempPath.FullName));
	}

	/// <summary>
	/// 创建当前文件的字符写入流；如果当前文件存在则清空当前文件，如果当前文件不存在则创建新文件。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="encoding">当前文件的字符编码</param>
	/// <returns>当前文件的字符写入流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static StreamWriter CreateWriter(FileInfo file, Encoding encoding = null)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		return new StreamWriter(file.Open(FileMode.Create, FileAccess.Write, FileShare.None), encoding);
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
	public static void DeleteDirectories(DirectoryInfo directory, int level, bool force = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertGreaterThanOrEqualTo(level, 0, "level");
		foreach (DirectoryInfo dinfo in Directories(directory, level))
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
	public static void DeleteDirectories(DirectoryInfo directory, string searching, bool recursive = false, bool force = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(searching, "searching");
		foreach (DirectoryInfo dinfo in Directories(directory, searching, recursive))
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
	public static void DeleteDirectories(DirectoryInfo directory, Regex pattern, bool recursive = false, bool force = false)
	{
		Guard.AssertNotNull(pattern, "pattern");
		DeleteDirectories(directory, (DirectoryInfo d) => pattern.IsMatch(d.FullName), recursive, force);
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
	public static void DeleteDirectories(DirectoryInfo directory, Func<DirectoryInfo, bool> predicate, bool recursive = false, bool force = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(predicate, "predicate");
		DirectoryInfo[] directories = GetDirectories(directory, predicate, recursive);
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
	public static void DeleteEmptyDirectories(DirectoryInfo directory, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		DeleteDirectories(directory, (DirectoryInfo d) => IsEmpty(d), recursive);
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
	public static void DeleteFiles(DirectoryInfo directory, int level, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertGreaterThanOrEqualTo(level, 0, "level");
		foreach (DirectoryInfo dinfo in Directories(directory, level))
		{
			ClearFiles(dinfo, recursive);
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
	public static void DeleteFiles(DirectoryInfo directory, string searching, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(searching, "searching");
		foreach (FileInfo finfo in Files(directory, searching, recursive))
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
	public static void DeleteFiles(DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(pattern, "pattern");
		foreach (FileInfo finfo in Files(directory, pattern, recursive))
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
	public static void DeleteFiles(DirectoryInfo directory, Func<FileInfo, bool> predicate, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(predicate, "predicate");
		foreach (FileInfo finfo in Files(directory, predicate, recursive))
		{
			if (finfo.Exists)
			{
				finfo.Delete();
			}
		}
	}

	/// <summary>
	/// 检测当前目录路径指示的目录是否存在
	/// </summary>
	/// <param name="directory">当前目录路径</param>
	/// <returns>如果目录存在返回true，否则返回false</returns>
	public static bool DirectoryExists(string directory)
	{
		Guard.AssertNotNull(directory, "directory");
		return Directory.Exists(directory);
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
	public static IEnumerable<DirectoryInfo> Directories(DirectoryInfo directory, bool recursive = false)
	{
		return Directories(directory, "*", recursive);
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
	public static IEnumerable<DirectoryInfo> Directories(DirectoryInfo directory, params int[] levels)
	{
		return Directories(directory, "*", levels);
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
	public static IEnumerable<DirectoryInfo> Directories(DirectoryInfo directory, string searching, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(searching, "searching");
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
	public static IEnumerable<DirectoryInfo> Directories(DirectoryInfo directory, string searching, params int[] levels)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(searching, "searching");
		Guard.AssertNotNull(levels, "levels");
		CollectionHelper.ForEach(levels, delegate(int x)
		{
			Guard.AssertGreaterThanOrEqualTo(x, 0, "level");
		});
		if (levels.Length == 0)
		{
			return new DirectoryInfo[0];
		}
		int[] newLevels = ArrayHelper.Sort(ArrayHelper.Copy(levels));
		return from d in directory.EnumerateDirectories(searching, SearchOption.AllDirectories)
			where ArrayHelper.BinarySearch(newLevels, GetLevel(d, directory)) >= 0
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
	public static IEnumerable<DirectoryInfo> Directories(DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return Directories(directory, (DirectoryInfo d) => pattern.IsMatch(d.FullName), recursive);
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
	public static IEnumerable<DirectoryInfo> Directories(DirectoryInfo directory, Regex pattern, params int[] levels)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return Directories(directory, (DirectoryInfo d) => pattern.IsMatch(d.FullName), levels);
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
	public static IEnumerable<DirectoryInfo> Directories(DirectoryInfo directory, Func<DirectoryInfo, bool> predicate, bool recursive = false)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return Directories(directory, "*", recursive).Where(predicate);
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
	public static IEnumerable<DirectoryInfo> Directories(DirectoryInfo directory, Func<DirectoryInfo, bool> predicate, params int[] levels)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return Directories(directory, "*", levels).Where(predicate);
	}

	/// <summary>
	/// 检测当前目录路径指示的目录是否存在
	/// </summary>
	/// <param name="directory">当前目录路径</param>
	/// <returns>如果目录存在返回true，否则返回false</returns>
	public static bool Exists(DirectoryInfo directory)
	{
		Guard.AssertNotNull(directory, "directory");
		directory.Refresh();
		return directory.Exists;
	}

	/// <summary>
	/// 检测当前文件路径指示的文件是否存在
	/// </summary>
	/// <param name="file">当前文件路径</param>
	/// <returns>如果指示的文件存在返回true，否则返回false</returns>
	public static bool Exists(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		file.Refresh();
		return file.Exists;
	}

	/// <summary>
	/// 枚举当前目录中文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="recursive">是否递归枚举当前目录下和其子目录下的文件，默认为false</param>
	/// <returns>目录中的文件集合</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static IEnumerable<FileInfo> Files(DirectoryInfo directory, bool recursive = false)
	{
		return Files(directory, "*");
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
	public static IEnumerable<FileInfo> Files(DirectoryInfo directory, params int[] levels)
	{
		return Files(directory, "*", levels);
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
	public static IEnumerable<FileInfo> Files(DirectoryInfo directory, string searching, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(searching, "searching");
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
	public static IEnumerable<FileInfo> Files(DirectoryInfo directory, string searching, params int[] levels)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(searching, "searching");
		Guard.AssertNotNull(levels, "levels");
		CollectionHelper.ForEach(levels, delegate(int x)
		{
			Guard.AssertGreaterThanOrEqualTo(x, 0, "level");
		});
		if (levels.Length == 0)
		{
			return new FileInfo[0];
		}
		int[] newLevels = ArrayHelper.Sort(ArrayHelper.Copy(levels));
		return from f in directory.EnumerateFiles(searching, SearchOption.AllDirectories)
			where ArrayHelper.BinarySearch(newLevels, GetLevel(f.Directory, directory)) >= 0
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
	public static IEnumerable<FileInfo> Files(DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return Files(directory, (FileInfo f) => pattern.IsMatch(f.FullName), recursive);
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
	public static IEnumerable<FileInfo> Files(DirectoryInfo directory, Regex pattern, params int[] levels)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return Files(directory, (FileInfo f) => pattern.IsMatch(f.FullName), levels);
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
	public static IEnumerable<FileInfo> Files(DirectoryInfo directory, Func<FileInfo, bool> predicate, bool recursive = false)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return Files(directory, "*", recursive).Where(predicate);
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
	public static IEnumerable<FileInfo> Files(DirectoryInfo directory, Func<FileInfo, bool> predicate, params int[] levels)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return Files(directory, "*", levels).Where(predicate);
	}

	/// <summary>
	/// 检测当前文件路径指示的文件是否存在
	/// </summary>
	/// <param name="file">当前文件路径</param>
	/// <returns>如果指示的文件存在返回true，否则返回false</returns>
	public static bool FileExists(string file)
	{
		Guard.AssertNotNull(file, "file");
		return File.Exists(file);
	}

	/// <summary>
	/// 获取当前路径字符串相对应的绝对路径
	/// 1. 当前路径不以盘符、'\'开头的认为是相对路径，使用AppDomain.BaseDirectory目录做为基础
	/// 2. 以'~'开头的认为是相对路径，首先尝试使用HttpServerUtility.MapPath进行转换
	/// 3. 以'&gt;'开头的认为是相对路径，使用Environment.CurrentDirectory做为基础进行转换
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串相对应的绝对路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetAbsolutePath(string path)
	{
		Guard.AssertNotNull(path, "path");
		if (IsRelativePath(path))
		{
			switch (path[0])
			{
			case '>':
				return BuildPath(path.TrimStart('>'), Environment.CurrentDirectory);
			case '~':
				if (HttpContext.Current != null && HttpContext.Current.Server != null)
				{
					return HttpContext.Current.Server.MapPath(path);
				}
				return BuildPath(path.TrimStart('~'), AppDomain.CurrentDomain.BaseDirectory);
			default:
				return BuildPath(path, AppDomain.CurrentDomain.BaseDirectory);
			}
		}
		return Path.GetFullPath(path);
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
	public static DirectoryInfo GetDirectory(DirectoryInfo directory, string searching, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(searching, "searching");
		HashSet<DirectoryInfo> cache = new HashSet<DirectoryInfo>();
		cache.Add(directory);
		while (cache.Count > 0)
		{
			DirectoryInfo[] roots = cache.ToArray();
			DirectoryInfo[] array = roots;
			foreach (DirectoryInfo root in array)
			{
				DirectoryInfo result = Directories(root, searching).FirstOrDefault();
				if (ObjectHelper.IsNotNull(result))
				{
					return result;
				}
				if (recursive)
				{
					CollectionHelper.AddRange(cache, Directories(root));
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
	public static DirectoryInfo GetDirectory(DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return GetDirectory(directory, (DirectoryInfo d) => pattern.IsMatch(d.FullName), recursive);
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
	public static DirectoryInfo GetDirectory(DirectoryInfo directory, Func<DirectoryInfo, bool> predicate, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(predicate, "predicate");
		HashSet<DirectoryInfo> cache = new HashSet<DirectoryInfo>();
		cache.Add(directory);
		while (cache.Count > 0)
		{
			DirectoryInfo[] roots = cache.ToArray();
			DirectoryInfo[] array = roots;
			foreach (DirectoryInfo root in array)
			{
				foreach (DirectoryInfo dinfo in Directories(root))
				{
					if (ObjectHelper.IsNull(predicate) || predicate(dinfo))
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
	/// 获取当前路径字符串中的目录的信息对象
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>返回当前路径字符串中的目录的信息对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	/// <remarks>本方法返回当前路径字符串中最后一个路径分隔符之前的目录信息对象。</remarks>
	public static DirectoryInfo GetDirectory(string path)
	{
		return new DirectoryInfo(GetDirectoryName(path));
	}

	/// <summary>
	/// 获取当前路径字符串中指定目标所在的路径字符串
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>返回当前路径字符串中的目录路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	/// <remarks>本方法返回当前路径字符串中最后一个路径分隔符之前的目录路径。</remarks>
	public static string GetDirectoryName(string path)
	{
		Guard.AssertNotNull(path, "path");
		return ObjectHelper.IfNull(Path.GetDirectoryName(path), string.Empty);
	}

	/// <summary>
	/// 获取当前目录的子目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="recursive">是否获取全部子目录</param>
	/// <returns>当前目录的子目录的数组；如果当前目录没有子目录，返回空数组。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static DirectoryInfo[] GetDirectories(DirectoryInfo directory, bool recursive)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		return GetDirectories(directory, "*", recursive);
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
	public static DirectoryInfo[] GetDirectories(DirectoryInfo directory, string searching, bool recursive)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(searching, "searching");
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
	public static DirectoryInfo[] GetDirectories(DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(pattern, "pattern");
		return Directories(directory, pattern, recursive).ToArray();
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
	public static DirectoryInfo[] GetDirectories(DirectoryInfo directory, Func<DirectoryInfo, bool> predicate, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(predicate, "predicate");
		return Directories(directory, predicate, recursive).ToArray();
	}

	/// <summary>
	/// 获得当前目录所在驱动器的信息
	/// </summary>
	/// <param name="directory">当前的目录</param>
	/// <returns>当前的目录所在的驱动器的信息</returns>
	public static DriveInfo GetDrive(DirectoryInfo directory)
	{
		Guard.AssertNotNull(directory, "directory");
		return new DriveInfo(directory.Root.FullName);
	}

	/// <summary>
	/// 获取当前文件所在的驱动器信息
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>文件所在的驱动器信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static DriveInfo GetDriver(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		return new DriveInfo(file.FullName);
	}

	/// <summary>
	/// 获取当前文件扩展名，不包括句点
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>文件的扩展名，不包括扩展名的分割句点</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static string GetExtension(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		return file.Extension.TrimStart('.');
	}

	/// <summary>
	/// 获取当前路径字符串中包含的扩展名，获取的扩展名不包含句点。
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串中包含的扩展名；如果没有扩展名返回空串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetExtension(string path)
	{
		Guard.AssertNotNull(path, "path");
		string extension = Path.GetExtension(path);
		return ObjectHelper.IfNull(extension, string.Empty).Trim('.');
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
	public static FileInfo GetFile(DirectoryInfo directory, string searching, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(searching, "searching");
		HashSet<DirectoryInfo> cache = new HashSet<DirectoryInfo>();
		cache.Add(directory);
		while (cache.Count > 0)
		{
			DirectoryInfo[] roots = cache.ToArray();
			DirectoryInfo[] array = roots;
			foreach (DirectoryInfo root in array)
			{
				FileInfo result = Files(root, searching).FirstOrDefault();
				if (ObjectHelper.IsNotNull(result))
				{
					return result;
				}
				if (recursive)
				{
					CollectionHelper.AddRange(cache, Directories(root));
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
	public static FileInfo GetFile(DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return GetFile(directory, (FileInfo f) => pattern.IsMatch(f.FullName), recursive);
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
	public static FileInfo GetFile(DirectoryInfo directory, Func<FileInfo, bool> predicate, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(predicate, "predicate");
		HashSet<DirectoryInfo> cache = new HashSet<DirectoryInfo>();
		cache.Add(directory);
		while (cache.Count > 0)
		{
			DirectoryInfo[] roots = cache.ToArray();
			DirectoryInfo[] array = roots;
			foreach (DirectoryInfo root in array)
			{
				FileInfo result = Files(root, predicate).FirstOrDefault();
				if (ObjectHelper.IsNotNull(result))
				{
					return result;
				}
				if (recursive)
				{
					CollectionHelper.AddRange(cache, Directories(root));
				}
				cache.Remove(root);
			}
		}
		return null;
	}

	/// <summary>
	/// 获取当前目录下的文件的数量
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="recursive">是否获取当前目录及所有子目录下文件的数量</param>
	/// <returns>文件的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	public static int GetFileCount(DirectoryInfo directory, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		return Files(directory, recursive).Count();
	}

	/// <summary>
	/// 获取当前文件的文件名，不包含文件路径
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>文件的名称，不包含文件路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static string GetFileName(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		return file.Name;
	}

	/// <summary>
	/// 获取当前路径字符串中的文件名称，包括扩展名
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串中包含的文件名</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetFileName(string path)
	{
		Guard.AssertNotNull(path, "path");
		return Path.GetFileName(path);
	}

	/// <summary>
	/// 获取当前文件不包含扩展名的文件名
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>文件的不包含扩展名的文件名</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static string GetFileNameWithoutExtension(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		return TextHelper.TrimEnd(file.Name, file.Extension);
	}

	/// <summary>
	/// 获取当期文件路径不包含扩展名的文件名部分
	/// </summary>
	/// <param name="file"></param>
	/// <returns></returns>
	public static string GetFileNameWithoutExtension(string file)
	{
		Guard.AssertNotNull(file, "file");
		return Path.GetFileNameWithoutExtension(file);
	}

	/// <summary>
	/// 获取当前目录下的文件
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="recursive">是否在子目录中查找</param>
	/// <returns>当前目录下的文件的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static FileInfo[] GetFiles(DirectoryInfo directory, bool recursive)
	{
		return GetFiles(directory, "*", recursive);
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
	public static FileInfo[] GetFiles(DirectoryInfo directory, string searching, bool recursive)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(searching, "searching");
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
	public static FileInfo[] GetFiles(DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return GetFiles(directory, (FileInfo f) => pattern.IsMatch(f.FullName), recursive);
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
	public static FileInfo[] GetFiles(DirectoryInfo directory, Func<FileInfo, bool> predicate, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(predicate, "predicate");
		return Files(directory, predicate, recursive).ToArray();
	}

	/// <summary>
	/// 计算当前目录下文件的大小（字节）
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="recursive">是否搜索全部子目录中的文件</param>
	/// <returns>符合条件的所有文件的大小</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	public static long GetFileSize(DirectoryInfo directory, bool recursive = false)
	{
		return GetFileSize(directory, "*", recursive);
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
	public static long GetFileSize(DirectoryInfo directory, string searching, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(searching, "searching");
		return Files(directory, searching, recursive).Sum((FileInfo x) => x.Length);
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
	public static long GetFileSize(DirectoryInfo directory, Regex pattern, bool recursive = false)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return GetFileSize(directory, (FileInfo f) => pattern.IsMatch(f.FullName), recursive);
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
	public static long GetFileSize(DirectoryInfo directory, Func<FileInfo, bool> predicate, bool recursive = false)
	{
		return Files(directory, predicate, recursive).Sum((FileInfo x) => x.Length);
	}

	/// <summary>
	/// 获取当前目录的全名
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <returns>当前目录的全名</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	public static string GetFullName(DirectoryInfo directory)
	{
		Guard.AssertNotNull(directory, "directory");
		return directory.FullName;
	}

	/// <summary>
	/// 获取当前文件全名（包括文件路径和文件名）
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件的全名</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static string GetFullName(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		return file.FullName;
	}

	/// <summary>
	/// 获取当前文件的路径
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>文件所在路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static string GetFullPath(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		return file.DirectoryName;
	}

	/// <summary>
	/// 获取当前路径字符串的完整路径（绝对路径）
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串的完整路径（绝对路径）</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetFullPath(string path)
	{
		Guard.AssertNotNull(path, "path");
		return Path.GetFullPath(path);
	}

	/// <summary>
	/// 获取当前目录的层级
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="basePath">获取目录层级的基准目录；如果基准目录为空，则以当前目录的根目录作为基准目录。</param>
	/// <returns>当前目录相对于基准目录的层级；如果基准目录为空，则返回当前目录相对于其根目录的层级。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.ArgumentException">基准目录 <paramref name="basePath" /> 不在当前目录的目录结构中。</exception>
	public static int GetLevel(DirectoryInfo directory, DirectoryInfo basePath = null)
	{
		Guard.AssertNotNull(directory, "directory");
		return GetRelativePath(directory, basePath).Split(new char[1] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries).Length;
	}

	/// <summary>
	/// 获取当前目录的层级
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="basePath">获取目录层级的基准目录</param>
	/// <returns>当前目录相对于基准目录的层级；如果基准目录为空，则返回当前目录相对于其根目录的层级。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者基准目录 <paramref name="basePath" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">基准目录 <paramref name="basePath" /> 无效；或者不在当前目录的目录结构中。</exception>
	public static int GetLevel(DirectoryInfo directory, string basePath)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertNotNull(basePath, "base path");
		return GetLevel(directory, new DirectoryInfo(basePath));
	}

	/// <summary>
	/// 获取当前路径字符串的最末级的路径名称
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串中最末级的路径名称</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetPathName(string path)
	{
		Guard.AssertNotNull(path, "path");
		return path.Split(new char[1] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries)[^1];
	}

	/// <summary>
	/// 获取当前目录的根路径
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <returns>当前目录的根路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	public static string GetPathRoot(DirectoryInfo directory)
	{
		Guard.AssertNotNull(directory, "directory");
		return Path.GetPathRoot(directory.FullName);
	}

	/// <summary>
	/// 获取当前文件所在路径的根路径
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件所在路径的根路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static string GetPathRoot(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		return Path.GetPathRoot(file.FullName);
	}

	/// <summary>
	/// 获取当前路径字符串的根路径
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串的根路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetPathRoot(string path)
	{
		Guard.AssertNotNull(path, "path");
		return (path.Length == 0) ? string.Empty : Path.GetPathRoot(path);
	}

	/// <summary>
	/// 获取当前路径字符串的卷标名称；只处理Windows和Mac系统的卷标包含冒号的路径，其他系统或者不包含卷标的路径，返回空串
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>指定路径中包含的卷标名称，如果路径不包含卷标返回空串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetPathVolumeName(string path)
	{
		Guard.AssertNotNull(path, "path");
		Match i = RegexPatterns.PathVolume.Match(path);
		if (!i.Success || i.Index > 0)
		{
			return string.Empty;
		}
		if (i.Groups.Count > 0)
		{
			return i.Groups[1].Value;
		}
		return string.Empty;
	}

	/// <summary>
	/// 获取当前目录与指定的基准目录之间的相对路径
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="basePath">指定的基准目录；如果基准目录为空，则以当前目录的根目录作为基准目录。</param>
	/// <returns>当前目录与指定的基准目录之间的相对路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.ArgumentException">基准目录 <paramref name="basePath" /> 不在当前目录的目录结构中。</exception>
	public static string GetRelativePath(DirectoryInfo directory, DirectoryInfo basePath = null)
	{
		Guard.AssertNotNull(directory, "directory");
		if (ObjectHelper.IsNull(basePath))
		{
			basePath = GetRoot(directory);
		}
		else
		{
			Guard.Assert(directory.FullName.IndexOf(basePath.FullName) == 0, "base path");
		}
		return TextHelper.TrimStart(directory.FullName, basePath.FullName).Trim(Path.DirectorySeparatorChar);
	}

	/// <summary>
	/// 获取当前目录与指定的基准目录之间的相对路径
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="basePath">指定的基准目录路径</param>
	/// <returns>当前目录与指定的基准目录之间的相对路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者基准目录路径 <paramref name="basePath" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">基准目录 <paramref name="basePath" /> 无效，或者不在当前目录的目录结构中。</exception>
	public static string GetRelativePath(DirectoryInfo directory, string basePath)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertNotNull(basePath, "base path");
		return GetRelativePath(directory, new DirectoryInfo(basePath));
	}

	/// <summary>
	/// 将当前路径字符串转换为基于给定的基础目录的相对路径
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <param name="basePath">基础路径字符串</param>
	/// <returns>相对于基础路径的相对路径；如果当前路径不是绝对路径则返回当前路径本身；或者如果当前路径不是基于给定的基础路径的，则返回当前路径本身。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空；或者基础路径字符串 <paramref name="basePath" /> 为空。</exception>
	public static string GetRelativePath(string path, string basePath)
	{
		Guard.AssertNotNull(path, "path");
		Guard.AssertNotNull(basePath, "base path");
		if (IsAbsolutePath(path))
		{
			return TextHelper.TrimStart(path, basePath);
		}
		return path;
	}

	/// <summary>
	/// 获取当前目录的根目录
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <returns>当前目录的根目录</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <remarks>在当前目录的目录结构中进行回溯，没有父级目录的目录认为是根目录。</remarks>
	public static DirectoryInfo GetRoot(DirectoryInfo directory)
	{
		Guard.AssertNotNull(directory, "directory");
		while (ObjectHelper.IsNotNull(directory.Parent))
		{
			directory = directory.Parent;
		}
		return directory;
	}

	/// <summary>
	/// 检测当前文件是否含有扩展名
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>如果文件含有扩展名返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static bool HasExtension(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		return Path.HasExtension(file.FullName);
	}

	/// <summary>
	/// 检测当前路径字符串是否包含扩展名
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>如果包含扩展名返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static bool HasExtension(string path)
	{
		Guard.AssertNotNull(path, "path");
		return Path.HasExtension(path);
	}

	/// <summary>
	/// 判断当前路径字符串是否表示绝对路径
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>如果当前路径字符串表示绝对路径返回true，相对路径返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static bool IsAbsolutePath(string path)
	{
		Guard.AssertNotNull(path, "path");
		return RegexPatterns.PathRoot.IsMatch(path);
	}

	/// <summary>
	/// 检测当前目录是否为空
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <returns>如果当前目录为空（不包括任何文件和子目录）则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static bool IsEmpty(DirectoryInfo directory)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		return !Files(directory).Any() && !Directories(directory).Any();
	}

	/// <summary>
	/// 检测当前路径字符串是否包含根路径
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>如果当前路径字符串包含根路径返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static bool IsPathRooted(string path)
	{
		Guard.AssertNotNull(path, "path");
		return Path.IsPathRooted(path);
	}

	/// <summary>
	/// 判断当前路径字符串是否表示相对路径
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>如果当前路径字符串表示相对路径返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static bool IsRelativePath(string path)
	{
		return !IsAbsolutePath(path);
	}

	/// <summary>
	/// 判断当前文本是否是Unicode字符串（只包含Unicode字符）
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>如果当前文本全部字符都是Unicode字符返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static bool IsUnicode(string text)
	{
		Guard.AssertNotNull(text, "text");
		return TextHelper.EqualOrdinal(TextHelper.AsciiDecode(TextHelper.AsciiEncode(text)), text);
	}

	/// <summary>
	/// 检测当前文件名字符串是否是有效的文件名
	/// </summary>
	/// <param name="fileName">当前文件名字符串</param>
	/// <returns>如果当前字符串时有效的文件名返回true；否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件名字符串为空。</exception>
	public static bool IsValidFileName(string fileName)
	{
		Guard.AssertNotNull(fileName, "file name");
		return fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;
	}

	/// <summary>
	/// 检测当前文件路径字符串（包括路径和文件名）是否有效
	/// </summary>
	/// <param name="filePath">当前文件路径字符串</param>
	/// <returns>如果当前文件路径字符串是否有效返回true；否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件路径字符串为空。</exception>
	public static bool IsValidFilePath(string filePath)
	{
		Guard.AssertNotNull(filePath, "file path");
		return filePath.IndexOfAny(Path.GetInvalidFileNameChars().Union(Path.GetInvalidPathChars()).ToArray()) < 0;
	}

	/// <summary>
	/// 检测当前路径字符串是否有效
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>如果当前路径字符串是否有效返回true；否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static bool IsValidPath(string path)
	{
		Guard.AssertNotNull(path, "path");
		return path.IndexOfAny(Path.GetInvalidPathChars()) < 0;
	}

	/// <summary>
	/// 移动当前文件到指定位置
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="target">移动的目标文件</param>
	/// <param name="overwrite">如果目标文件存在是否覆盖</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者移动的目标文件 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，移动的目标文件已经存在。</exception>
	public static void MoveTo(FileInfo file, FileInfo target, bool overwrite = false)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(target, "target");
		if (!overwrite && target.Exists)
		{
			throw new IOException(string.Format(Literals.MSG_FileExistsException_1, target.FullName));
		}
		if (!target.Directory.Exists)
		{
			target.Directory.Create(file.Directory.GetAccessControl(AccessControlSections.All));
		}
		if (target.Exists)
		{
			target.Delete();
		}
		file.MoveTo(target.FullName);
		file.Refresh();
		target.Refresh();
	}

	/// <summary>
	/// 移动当前文件到指定位置
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="targetFile">移动的目标文件路径</param>
	/// <param name="overwrite">如果目标文件存在是否覆盖</param>
	/// <returns>移动后的文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者移动的目标文件路径 <paramref name="targetFile" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，移动的目标文件已经存在。</exception>
	public static FileInfo MoveTo(FileInfo file, string targetFile, bool overwrite)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNullAndEmpty(targetFile, "target");
		FileInfo target = new FileInfo(targetFile);
		MoveTo(file, target, overwrite);
		return target;
	}

	/// <summary>
	/// 移动当前文件到指定位置
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="targetFile">移动的目标文件路径</param>
	/// <param name="predicate">文件移动条件；如果返回true，则移动当前文件，否则不移动。</param>
	/// <returns>移动后的文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者移动的目标文件路径 <paramref name="targetFile" /> 为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static FileInfo MoveTo(FileInfo file, string targetFile, Func<FileInfo, FileInfo, bool> predicate)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNullAndEmpty(targetFile, "target file");
		Guard.AssertNotNull(predicate, "predicate");
		FileInfo target = new FileInfo(targetFile);
		if (predicate(file, target))
		{
			file.Refresh();
			target.Refresh();
			MoveTo(file, target, overwrite: true);
		}
		return target;
	}

	/// <summary>
	/// 移动当期文件到指定的目录中
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="directory">移动的目标路径</param>
	/// <param name="overwrite">如果移动的目标文件存在，是否覆盖目标文件</param>
	/// <returns>移动后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者移动的目标路径 <paramref name="directory" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，移动的目标文件已经存在。</exception>
	public static FileInfo MoveTo(FileInfo file, DirectoryInfo directory, bool overwrite = false)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(directory, "directory");
		FileInfo target = new FileInfo(Path.Combine(directory.FullName, file.Name));
		MoveTo(file, target, overwrite);
		return target;
	}

	/// <summary>
	/// 移动当期文件到指定的目录中
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="directory">移动的目标路径</param>
	/// <param name="predicate">文件移动筛选条件</param>
	/// <returns>移动后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者移动的目标路径 <paramref name="directory" /> 为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static FileInfo MoveTo(FileInfo file, DirectoryInfo directory, Func<FileInfo, FileInfo, bool> predicate)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertNotNull(predicate, "predicate");
		FileInfo target = new FileInfo(Path.Combine(directory.FullName, file.Name));
		if (predicate(file, target))
		{
			file.Refresh();
			target.Refresh();
			MoveTo(file, target, overwrite: true);
		}
		return target;
	}

	/// <summary>
	/// 移动当期文件到指定的目录中
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="directoryPath">移动的目标路径</param>
	/// <param name="filename">移动的目标名称，如果为空，则与源文件同名</param>
	/// <param name="overwrite">如果移动的目标文件存在，是否覆盖目标文件</param>
	/// <returns>移动后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者移动的目标路径 <paramref name="directoryPath" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，移动的目标文件已经存在。</exception>
	public static FileInfo MoveTo(FileInfo file, string directoryPath, string filename, bool overwrite = false)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNullAndEmpty(directoryPath, "directory path");
		FileInfo target = new FileInfo(Path.Combine(directoryPath, ObjectHelper.IfNull(filename, file.Name)));
		MoveTo(file, target, overwrite);
		return target;
	}

	/// <summary>
	/// 移动当期文件到指定的目录中
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="directoryPath">移动的目标路径</param>
	/// <param name="filename">移动的目标名称，如果为空，则与源文件同名</param>
	/// <param name="predicate">文件移动筛选条件</param>
	/// <returns>移动后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者移动的目标路径 <paramref name="directoryPath" /> 为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static FileInfo MoveTo(FileInfo file, string directoryPath, string filename, Func<FileInfo, FileInfo, bool> predicate)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNullAndEmpty(directoryPath, "directory path");
		Guard.AssertNotNull(predicate, "predicate");
		FileInfo target = new FileInfo(Path.Combine(directoryPath, ObjectHelper.IfNull(filename, file.Name)));
		if (predicate(file, target))
		{
			file.Refresh();
			target.Refresh();
			MoveTo(file, target, overwrite: true);
		}
		return target;
	}

	/// <summary>
	/// 规范化当前文件名称，非法文件名字符使用默认字符替代
	/// </summary>
	/// <param name="fileName">当前文件名称</param>
	/// <param name="defaultChar">用以替换非法字符的默认字符</param>
	/// <returns>规范化的文件名称</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件名称为空。</exception>
	/// <remarks>本方法仅用于规范化文件名称，如果要规范化文件全名（文件路径和文件名称），应使用 <see cref="M:Richfit.Garnet.Common.Utility.IOHelper.NormalizeFilePath(System.String,System.Char)" /> 方法。</remarks>
	public static string NormalizeFileName(string fileName, char defaultChar = '_')
	{
		Guard.AssertNotNull(fileName, "filename");
		return RegexPatterns.InvalidFileNameChars.Replace(fileName, defaultChar.ToString());
	}

	/// <summary>
	/// 规范化当前文件路径（包含文件路径和文件名称），非法字符使用默认字符替代
	/// </summary>
	/// <param name="filePath">当前文件路径</param>
	/// <param name="defaultChar">用以替换非法字符的默认字符</param>
	/// <returns>规范化的文件路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件名称为空。</exception>
	public static string NormalizeFilePath(string filePath, char defaultChar = '_')
	{
		Guard.AssertNotNull(filePath, "filename");
		string fileName = Path.GetFileName(filePath);
		if (fileName.Length >= 0)
		{
			return NormalizePath(filePath.Substring(0, filePath.Length - fileName.Length), defaultChar) + NormalizeFileName(fileName, defaultChar);
		}
		return NormalizePath(filePath, defaultChar);
	}

	/// <summary>
	/// 规范化当前路径，非法路径字符使用默认字符替代
	/// </summary>
	/// <param name="path">当前路径</param>
	/// <param name="defaultChar">用以替换非法字符的默认字符</param>
	/// <returns>规范化的路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径为空。</exception>
	/// <remarks>本方法仅用于规范化路径，如果要处理包含文件名的路径，应使用 <see cref="M:Richfit.Garnet.Common.Utility.IOHelper.NormalizeFilePath(System.String,System.Char)" /> 方法。</remarks>
	public static string NormalizePath(string path, char defaultChar = '_')
	{
		Guard.AssertNotNull(path, "path");
		return RegexPatterns.InvalidPathChars.Replace(path, defaultChar.ToString());
	}

	/// <summary>
	/// 读取当前文件中全部字节数据
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>读取的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static byte[] ReadAllBytes(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		return File.ReadAllBytes(file.FullName);
	}

	/// <summary>
	/// 读取当前文件中指定范围内的字节数据
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="start">开始读取的字节位置</param>
	/// <returns>读取的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出文件中字节的索引范围。</exception>
	public static byte[] ReadBytes(FileInfo file, long start)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertIndexRange(start, 0L, file.Length - 1, "start");
		return ReadBytes(file, start, file.Length - start);
	}

	/// <summary>
	/// 读取当前文件中指定范围内的字节数据
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="start">开始读取的字节位置</param>
	/// <param name="count">读取的字节数量</param>
	/// <returns>读取的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出文件中字节的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 超出文件从 <paramref name="start" /> 指定位置开始可读取的字节数量。</exception>
	public static byte[] ReadBytes(FileInfo file, long start, long count)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertIndexRange(start, 0L, file.Length - 1, "start");
		Guard.AssertBetween(count, 0L, file.Length - start, "count");
		byte[] buff = new byte[count];
		int read = 0;
		using (FileStream fs = file.OpenRead())
		{
			fs.Position = start;
			read = fs.Read(buff, 0, buff.Length);
			fs.Close();
		}
		if (read < buff.Length)
		{
			byte[] newBuff = new byte[read];
			Array.Copy(buff, newBuff, read);
			return newBuff;
		}
		return buff;
	}

	/// <summary>
	/// 读取当前文件中的文本
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>从文件中读取的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static string ReadAllText(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		return File.ReadAllText(file.FullName);
	}

	/// <summary>
	/// 读取当前文件中的数据并解码为文本
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="encoding">文件文本的编码</param>
	/// <returns>从文件中读取的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="encoding" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static string ReadAllText(FileInfo file, Encoding encoding)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(encoding, "encoding");
		return File.ReadAllText(file.FullName, encoding);
	}

	/// <summary>
	/// 读取当前文件中的数据，并解码为文本
	/// </summary>
	/// <param name="file">当前文本</param>
	/// <param name="start">开始读取的字符索引</param>
	/// <param name="encoding">文件文本的编码，默认为UTF-8</param>
	/// <returns>从文件中读取的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 小于0。</exception>
	public static string ReadText(FileInfo file, int start, Encoding encoding = null)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertIndexLowBound(start, 0, "start");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		return ReadText(file, start, int.MaxValue, encoding);
	}

	/// <summary>
	/// 读取当前文件中的数据，并解码为文本
	/// </summary>
	/// <param name="file">当前文本</param>
	/// <param name="start">开始读取的字符索引</param>
	/// <param name="count">读取的字符数量</param>
	/// <param name="encoding">文件文本的编码，默认为UTF-8</param>
	/// <returns>从文件中读取的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	public static string ReadText(FileInfo file, int start, int count, Encoding encoding = null)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		StringBuilder buff = new StringBuilder();
		Decoder decoder = encoding.GetDecoder();
		byte[] bytes = new byte[512];
		char[] chars = new char[512];
		int read = 0;
		int decoded = 0;
		int totalDecoded = 0;
		int totalRead = 0;
		using (FileStream fs = file.OpenRead())
		{
			while ((read = fs.Read(bytes, 0, bytes.Length)) > 0)
			{
				decoded = decoder.GetChars(bytes, 0, read, chars, 0, flush: false);
				totalDecoded += decoded;
				if (totalDecoded > start)
				{
					totalRead = totalDecoded - start;
					if (totalRead < decoded)
					{
						TextHelper.AppendValue(buff, chars.Skip(decoded - totalRead).Take(totalRead));
					}
					else
					{
						TextHelper.AppendValue(buff, chars.Take(decoded));
					}
				}
				if (buff.Length >= count)
				{
					break;
				}
			}
			fs.Close();
		}
		return (buff.Length <= count) ? buff.ToString() : buff.ToString(0, count);
	}

	/// <summary>
	/// 重命名当前文件
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="newName">新文件名</param>
	/// <param name="overwrite">如果重命名的目标文件存在，是否覆盖目标文件</param>
	/// <returns>重命名后的新文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="newName" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="newName" /> 不是有效的文件名。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，重命名的目标文件已经存在。</exception>
	public static FileInfo Rename(FileInfo file, string newName, bool overwrite = false)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(newName, "new name");
		return Rename(file, (FileInfo f) => newName, overwrite);
	}

	/// <summary>
	/// 重命名当前文件，将文件名中指定的文本替换指定的内容
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="text">文件名中替换的部分</param>
	/// <param name="replacement">替换的文本</param>
	/// <param name="overwrite">如果重命名的目标文件存在，是否覆盖目标文件</param>
	/// <returns>重命名后的新文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，重命名的目标文件已经存在。</exception>
	public static FileInfo Rename(FileInfo file, string text, string replacement, bool overwrite = false)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(text, "text");
		replacement = ObjectHelper.IfNull(replacement, string.Empty);
		return Rename(file, (FileInfo f) => f.Name.Replace(text, replacement), overwrite);
	}

	/// <summary>
	/// 重命名当前文件，将文件名中与正则模式匹配的部分进行替换
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="pattern">替换用的正则匹配模式</param>
	/// <param name="replacement">替换的文本</param>
	/// <param name="overwrite">如果重命名的目标文件存在，是否覆盖目标文件</param>
	/// <returns>重命名后的新文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，重命名的目标文件已经存在。</exception>
	public static FileInfo Rename(FileInfo file, Regex pattern, string replacement, bool overwrite = false)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(pattern, "pattern");
		replacement = ObjectHelper.IfNull(replacement, string.Empty);
		return Rename(file, (FileInfo f) => pattern.Replace(f.Name, replacement), overwrite);
	}

	/// <summary>
	/// 重命名当前文件
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="renaming">重命名方法，返回新的文件名</param>
	/// <param name="overwrite">如果重命名后的文件已经存在，是否覆盖。</param>
	/// <returns>重命名后的新文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="renaming" /> 为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	/// <exception cref="T:System.IO.IOException">当 <paramref name="overwrite" /> 为false时，重命名的目标文件已经存在。</exception>
	/// <exception cref="T:System.ArgumentException">重命名方法 <paramref name="renaming" /> 返回的文件名无效。</exception>
	public static FileInfo Rename(FileInfo file, Func<FileInfo, string> renaming, bool overwrite = false)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		Guard.AssertNotNull(renaming, "renaming");
		string newName = Guard.Ensure(renaming(file), (string n) => IsValidFileName(n), "new name");
		FileInfo newFile = new FileInfo(Path.Combine(file.DirectoryName, newName));
		if (newFile.Exists)
		{
			if (!overwrite)
			{
				throw new IOException(string.Format(Literals.MSG_FileExistsException_1, newFile.FullName));
			}
			newFile.Delete();
		}
		file.MoveTo(newFile.FullName);
		newFile.Refresh();
		return newFile;
	}

	/// <summary>
	/// 将当前字节数据保存到文件
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="file">保存的目标文件对象</param>
	/// <param name="overwrite">如果目标文件存在，是否覆盖目标文件。等于true，覆盖目标文件；等于false，追加到目标文件。</param>
	/// <returns>保存后的文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空；或者 <paramref name="file" /> 为空。</exception>
	/// <remarks>如果目标文件不存在，则创建新的目标文件；否则按照 <paramref name="overwrite" /> 指定的方式处理。</remarks>
	public static FileInfo SaveFile(byte[] data, string file, bool overwrite = true)
	{
		return SaveFile(data, new FileInfo(file), overwrite);
	}

	/// <summary>
	/// 将当前字节数据保存到文件
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="start">开始保存的字节的索引位置</param>
	/// <param name="count">保存的字节数量</param>
	/// <param name="file">保存的目标文件对象</param>
	/// <param name="overwrite">如果目标文件存在，是否覆盖目标文件。等于true，覆盖目标文件；等于false，追加到目标文件。</param>
	/// <returns>保存后的文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空；或者 <paramref name="file" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	/// <remarks>如果目标文件不存在，则创建新的目标文件；否则按照 <paramref name="overwrite" /> 指定的方式处理。</remarks>
	public static FileInfo SaveFile(byte[] data, int start, int count, string file, bool overwrite = true)
	{
		return SaveFile(data, start, count, new FileInfo(file), overwrite);
	}

	/// <summary>
	/// 将当前字节数据保存到文件
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="file">保存的目标文件对象</param>
	/// <param name="overwrite">如果目标文件存在，是否覆盖目标文件。等于true，覆盖目标文件；等于false，追加到目标文件。</param>
	/// <returns>保存后的文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空；或者 <paramref name="file" /> 为空。</exception>
	/// <remarks>如果目标文件不存在，则创建新的目标文件；否则按照 <paramref name="overwrite" /> 指定的方式处理。</remarks>
	public static FileInfo SaveFile(byte[] data, FileInfo file, bool overwrite = true)
	{
		Guard.AssertNotNull(data, "data");
		return SaveFile(data, 0, data.Length, file, overwrite);
	}

	/// <summary>
	/// 将当前字节数据保存到文件
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="start">开始保存的字节的索引位置</param>
	/// <param name="count">保存的字节数量</param>
	/// <param name="file">保存的目标文件对象</param>
	/// <param name="overwrite">如果目标文件存在，是否覆盖目标文件。等于true，覆盖目标文件；等于false，追加到目标文件。</param>
	/// <returns>保存后的文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空；或者 <paramref name="file" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	/// <remarks>如果目标文件不存在，则创建新的目标文件；否则按照 <paramref name="overwrite" /> 指定的方式处理。</remarks>
	public static FileInfo SaveFile(byte[] data, int start, int count, FileInfo file, bool overwrite = true)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertIndexRange(start, 0, data.Length - 1, "start");
		Guard.AssertBetween(count, 0, data.Length - start, "count");
		Guard.AssertNotNull(file, "file");
		using (FileStream stream = file.Open(overwrite ? FileMode.Create : FileMode.Append, FileAccess.Write, FileShare.None))
		{
			stream.Write(data, start, count);
			stream.Close();
		}
		return file;
	}

	/// <summary>
	/// 将当前字节序列保存到文件
	/// </summary>
	/// <param name="data">当前字节序列</param>
	/// <param name="file">保存的目标文件对象</param>
	/// <param name="overwrite">如果目标文件存在，是否覆盖目标文件。等于true，覆盖目标文件；等于false，追加到目标文件。</param>
	/// <returns>保存后的文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空；或者 <paramref name="file" /> 为空。</exception>
	/// <remarks>如果目标文件不存在，则创建新的目标文件；否则按照 <paramref name="overwrite" /> 指定的方式处理。</remarks>
	public static FileInfo SaveFile(IEnumerable<byte> data, string file, bool overwrite = true)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(file, "file");
		return SaveFile(data, new FileInfo(file), overwrite);
	}

	/// <summary>
	/// 将当前字节序列保存到文件
	/// </summary>
	/// <param name="data">当前字节序列</param>
	/// <param name="file">保存的目标文件对象</param>
	/// <param name="overwrite">如果目标文件存在，是否覆盖目标文件。等于true，覆盖目标文件；等于false，追加到目标文件。</param>
	/// <returns>保存后的文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空；或者 <paramref name="file" /> 为空。</exception>
	/// <remarks>如果目标文件不存在，则创建新的目标文件；否则按照 <paramref name="overwrite" /> 指定的方式处理。</remarks>
	public static FileInfo SaveFile(IEnumerable<byte> data, FileInfo file, bool overwrite = true)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertNotNull(file, "file");
		using (FileStream stream = file.Open(overwrite ? FileMode.Create : FileMode.Append, FileAccess.Write, FileShare.None))
		{
			foreach (byte b in data)
			{
				stream.WriteByte(b);
			}
			stream.Close();
		}
		return file;
	}

	/// <summary>
	/// 将当前字节数组保存到临时文件
	/// </summary>
	/// <param name="data">当前字节数组</param>
	/// <param name="tempPath">临时文件存储目录</param>
	/// <returns>保存后的临时文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="tempPath" /> 指定的路径不存在，或者无法创建。</exception>
	/// <remarks>如果 <paramref name="tempPath" /> 为空，则使用系统临时文件目录。</remarks>
	public static FileInfo SaveTempFile(byte[] data, string tempPath = null)
	{
		Guard.AssertNotNull(data, "data");
		return SaveFile(data, CreateTempFile(tempPath), overwrite: false);
	}

	/// <summary>
	/// 将当前字节数组保存到临时文件
	/// </summary>
	/// <param name="data">当前字节数组</param>
	/// <param name="start">开始保存的字节的索引位置</param>
	/// <param name="count">保存的字节数量</param>
	/// <param name="tempPath">临时文件存储目录</param>
	/// <returns>保存后的临时文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="tempPath" /> 指定的路径不存在，或者无法创建。</exception>
	/// <remarks>如果 <paramref name="tempPath" /> 为空，则使用系统临时文件目录。</remarks>
	public static FileInfo SaveTempFile(byte[] data, int start, int count, string tempPath = null)
	{
		Guard.AssertNotNull(data, "data");
		return SaveFile(data, start, count, CreateTempFile(tempPath), overwrite: false);
	}

	/// <summary>
	/// 将当前字节数组保存到临时文件
	/// </summary>
	/// <param name="data">当前字节数组</param>
	/// <param name="tempPath">临时文件存储目录</param>
	/// <returns>保存后的临时文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空；或者 <paramref name="tempPath" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="tempPath" /> 指定的路径不存在，或者无法创建。</exception>
	/// <remarks>如果 <paramref name="tempPath" /> 为空，则使用系统临时文件目录。</remarks>
	public static FileInfo SaveTempFile(byte[] data, DirectoryInfo tempPath)
	{
		Guard.AssertNotNull(data, "data");
		return SaveFile(data, CreateTempFile(tempPath), overwrite: false);
	}

	/// <summary>
	/// 将当前字节数组保存到临时文件
	/// </summary>
	/// <param name="data">当前字节数组</param>
	/// <param name="start">开始保存的字节的索引位置</param>
	/// <param name="count">保存的字节数量</param>
	/// <param name="tempPath">临时文件存储目录</param>
	/// <returns>保存后的临时文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空；或者 <paramref name="tempPath" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="tempPath" /> 指定的路径不存在，或者无法创建。</exception>
	/// <remarks>如果 <paramref name="tempPath" /> 为空，则使用系统临时文件目录。</remarks>
	public static FileInfo SaveTempFile(byte[] data, int start, int count, DirectoryInfo tempPath)
	{
		Guard.AssertNotNull(data, "data");
		return SaveFile(data, start, count, CreateTempFile(tempPath), overwrite: false);
	}

	/// <summary>
	/// 将当前字节序列保存到临时文件
	/// </summary>
	/// <param name="data">当前字节序列</param>
	/// <param name="tempPath">临时文件存储目录</param>
	/// <returns>保存后的临时文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="tempPath" /> 指定的路径不存在，或者无法创建。</exception>
	/// <remarks>如果 <paramref name="tempPath" /> 为空，则使用系统临时文件目录。</remarks>
	public static FileInfo SaveTempFile(IEnumerable<byte> data, string tempPath = null)
	{
		Guard.AssertNotNull(data, "data");
		return SaveFile(data, CreateTempFile(tempPath), overwrite: false);
	}

	/// <summary>
	/// 将当前字节序列保存到临时文件
	/// </summary>
	/// <param name="data">当前字节序列</param>
	/// <param name="tempPath">临时文件存储目录</param>
	/// <returns>保存后的临时文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空；或者 <paramref name="tempPath" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="tempPath" /> 指定的路径不存在，或者无法创建。</exception>
	/// <remarks>如果 <paramref name="tempPath" /> 为空，则使用系统临时文件目录。</remarks>
	public static FileInfo SaveTempFile(IEnumerable<byte> data, DirectoryInfo tempPath)
	{
		Guard.AssertNotNull(data, "data");
		return SaveFile(data, CreateTempFile(tempPath), overwrite: false);
	}

	/// <summary>
	/// 设置当前文件的属性
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="attributes">需要设置的文件属性</param>
	/// <param name="append">是否追加到当前文件的属性</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void SetFileAttributes(FileInfo file, FileAttributes attributes, bool append = false)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		File.SetAttributes(file.FullName, append ? EnumHelper.SetFlag(attributes, file.Attributes) : attributes);
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
	public static void SetFileAttributes(DirectoryInfo directory, FileAttributes attributes, bool recursive = true, bool append = false)
	{
		SetFileAttributes(directory, "*", attributes, recursive, append);
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
	public static void SetFileAttributes(DirectoryInfo directory, string searching, FileAttributes attributes, bool recursive = true, bool append = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(searching, "searching");
		SetFileAttributes(directory, (DirectoryInfo d) => Files(d, searching, recursive), attributes, append);
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
	public static void SetFileAttributes(DirectoryInfo directory, Regex pattern, FileAttributes attributes, bool recursive = true, bool append = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(pattern, "pattern");
		SetFileAttributes(directory, (DirectoryInfo d) => Files(d, pattern, recursive), attributes, append);
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
	public static void SetFileAttributes(DirectoryInfo directory, Func<FileInfo, bool> predicate, FileAttributes attributes, bool recursive = false, bool append = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(predicate, "predicate");
		SetFileAttributes(directory, (DirectoryInfo d) => Files(d, predicate, recursive), attributes, append);
	}

	private static void SetFileAttributes(DirectoryInfo directory, Func<DirectoryInfo, IEnumerable<FileInfo>> enumerator, FileAttributes attributes, bool append)
	{
		foreach (FileInfo finfo in enumerator(directory))
		{
			if (finfo.Exists)
			{
				SetFileAttributes(finfo, attributes, append);
			}
		}
	}

	/// <summary>
	/// 将当前文件路径转换为所指示的文件对象，不检测文件是否实际存在是否存在
	/// </summary>
	/// <param name="file">当前文件路径</param>
	/// <returns>当前文件路径指示的文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录路径为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前目录路径无效。</exception>
	public static FileInfo ToFileInfo(string file)
	{
		Guard.AssertNotNull(file, "file");
		return new FileInfo(file);
	}

	/// <summary>
	/// 向当前文件中写入字节数据
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="bytes">写入的字节数组</param>
	/// <param name="append">是否追加到当前文件，默认为false</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者写入的字节数组 <paramref name="bytes" /> 为空。</exception>
	public static void WriteBytes(FileInfo file, byte[] bytes, bool append = false)
	{
		Guard.AssertNotNull(bytes, "bytes");
		WriteBytes(file, bytes, 0, bytes.Length, append);
	}

	/// <summary>
	/// 向当前文件中写入字节数组
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="bytes">写入的字节数组</param>
	/// <param name="start">字节数组中开始写入的位置</param>
	/// <param name="count">字节数组中写入的字节数量</param>
	/// <param name="append">是否追加到当前文件，默认为false</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；写入的字节数组 <paramref name="bytes" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">数组写入的起始位置 <paramref name="start" /> 小于0，或者大于当前字节数组的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">数组写入的字节数量 <paramref name="count" /> 小于0，或者大于当前字节数组从写入起始位置开始剩余的字节数量。</exception>
	public static void WriteBytes(FileInfo file, byte[] bytes, int start, int count, bool append = false)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertNotNull(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		Guard.AssertBetween(count, 0, bytes.Length - start, "count");
		using FileStream fs = file.Open(append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.None);
		WriteBytes(fs, bytes, start, count);
		fs.Close();
	}

	/// <summary>
	/// 将字节流写入到当前文件
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="stream">写入的字节流</param>
	/// <param name="append">是否追加到当前文件，默认为false</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="stream" /> 为空。</exception>
	public static void WriteBytes(FileInfo file, Stream stream, bool append = false)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertNotNull(stream, "stream");
		using FileStream fs = file.Open(append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.None);
		stream.CopyTo(fs);
		fs.Close();
	}

	/// <summary>
	/// 将文本数据写入当前文件，如果当前文件存在则覆盖
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="text">写入的文本数据</param>
	/// <param name="encoding">写入文本的字符编码，默认为UTF-8</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="text" /> 为空。</exception>
	public static void WriteText(FileInfo file, string text, Encoding encoding = null)
	{
		WriteBytes(file, ObjectHelper.IfNull(encoding, Encoding.UTF8).GetBytes(text));
	}

	/// <summary>
	/// 将文本数据写入当前文件
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="text">写入的文本数据</param>
	/// <param name="append">是否追加到当前文件</param>
	/// <param name="encoding">写入文本的字符编码，默认为UTF-8</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="text" /> 为空。</exception>
	public static void WriteText(FileInfo file, string text, bool append, Encoding encoding = null)
	{
		WriteBytes(file, ObjectHelper.IfNull(encoding, Encoding.UTF8).GetBytes(text), append);
	}

	/// <summary>
	/// 压缩当前字节数据
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="type">压缩算法类型，默认为 <see cref="F:Richfit.Garnet.Common.IO.CompressionType.Deflate" /></param>
	/// <returns>返回压缩后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static byte[] Compress(byte[] data, CompressionType type = CompressionType.Deflate)
	{
		Guard.AssertNotNull(data, "data");
		return Compress(data, 0, data.Length, type);
	}

	/// <summary>
	/// 压缩当前字节数据
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="start">开始处理的字节索引位置</param>
	/// <param name="count">处理的字节数量</param>
	/// <param name="type">压缩算法类型，默认为 <see cref="F:Richfit.Garnet.Common.IO.CompressionType.Deflate" /></param>
	/// <returns>返回压缩后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的字节数。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static byte[] Compress(byte[] data, int start, int count, CompressionType type = CompressionType.Deflate)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertIndexRange(start, 0, data.Length - 1, "start");
		Guard.AssertBetween(count, 0, data.Length - start, "count");
		using MemoryStream ms = new MemoryStream(1024);
		using Stream cs = CreateCompressStream(ms, type);
		cs.Write(data, start, count);
		cs.Close();
		ms.Close();
		return ms.ToArray();
	}

	/// <summary>
	/// 对当前字节数据进行压缩
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="type">压缩算法类型，默认为 <see cref="F:Richfit.Garnet.Common.IO.CompressionType.Deflate" /></param>
	/// <returns>返回压缩后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static byte[] Compress(IEnumerable<byte> data, CompressionType type = CompressionType.Deflate)
	{
		Guard.AssertNotNull(data, "data");
		using MemoryStream ms = new MemoryStream(1024);
		using Stream cs = CreateCompressStream(ms, type);
		foreach (byte b in data)
		{
			cs.WriteByte(b);
		}
		cs.Close();
		ms.Close();
		return ms.ToArray();
	}

	/// <summary>
	/// 将文本按指定文本编码进行编码并压缩为字节数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="encoding">文本编码格式，默认为UTF-8</param>
	/// <param name="type">压缩类型</param>
	/// <returns>编码压缩后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] Compress(string text, Encoding encoding = null, CompressionType type = CompressionType.Deflate)
	{
		Guard.AssertNotNull(text, "data");
		return Compress(TextHelper.TextEncode(text, encoding), type);
	}

	/// <summary>
	/// 将当前流从当前位置开始复制到缓存数组
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <returns>复制的缓存数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取。</exception>
	public static byte[] CopyToArray(Stream stream)
	{
		return ReadBytes(stream);
	}

	/// <summary>
	/// 将当前字节流从当前位置开始复制 <paramref name="count" /> 指定数量的字节到缓存数组
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="count">复制的字节数量</param>
	/// <returns>复制的缓存数组，数组元素的个数可能少于指定复制的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制的字节数量 <paramref name="count" /> 小于0。</exception>
	public static byte[] CopyToArray(Stream stream, long count)
	{
		return ReadBytes(stream, count);
	}

	/// <summary>
	/// 将当前字节流从 <paramref name="start" /> 指定的位置开始复制 <paramref name="count" /> 指定数量的字节到缓存数组
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="start">当期流开始复制的字节偏移量</param>
	/// <param name="count">复制的字节数量</param>
	/// <returns>复制的缓存数组，数组元素的个数可能少于指定复制的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">当前字节流开始复制的位置 <paramref name="start" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制的字节数量 <paramref name="count" /> 小于0。</exception>
	public static byte[] CopyToArray(Stream stream, long start, long count)
	{
		return ReadBytes(stream, start, count);
	}

	/// <summary>
	/// 将当前字节流从当前位置开始复制到字节列表
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <returns>复制的字节列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取。</exception>
	public static List<byte> CopyToList(Stream stream)
	{
		return new List<byte>(ReadBytes(stream));
	}

	/// <summary>
	/// 将当前字节流从当前位置开始复制 <paramref name="count" /> 指定数量的字节到字节列表
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="count">复制的字节数量</param>
	/// <returns>复制的字节列表，数组元素的个数可能少于指定复制的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制的字节数量 <paramref name="count" /> 小于0。</exception>
	public static List<byte> CopyToList(Stream stream, long count)
	{
		return new List<byte>(ReadBytes(stream, count));
	}

	/// <summary>
	/// 将当前字节流从 <paramref name="start" /> 指定的位置开始复制 <paramref name="count" /> 指定数量的字节到字节列表
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="start">当期流开始复制的字节偏移量</param>
	/// <param name="count">复制的字节数量</param>
	/// <returns>复制的字节列表，列表元素的个数可能少于指定复制的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">当前字节流开始复制的位置 <paramref name="start" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制的字节数量 <paramref name="count" /> 小于0。</exception>
	public static List<byte> CopyToList(Stream stream, long start, long count)
	{
		return new List<byte>(ReadBytes(stream, start, count));
	}

	/// <summary>
	/// 将当前字节流中的当前位置开始复制字节到目标字节流中
	/// </summary>
	/// <param name="source">当前字节流</param>
	/// <param name="target">目标流</param>
	/// <returns>已经复制的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者目标流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取；或者目标流不支持写入。</exception>
	public static long CopyToStream(Stream source, Stream target)
	{
		Guard.AssertNotNull(source, "source stream");
		Guard.AssertNotNull(target, "target stream");
		Guard.Assert(source.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		Guard.Assert(source.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
		return CopyStream(source, target, -1L);
	}

	/// <summary>
	/// 将当前字节流中的当前位置开始复制指定数量的字节到目标字节流中
	/// </summary>
	/// <param name="source">当前字节流</param>
	/// <param name="target">目标流</param>
	/// <param name="count">复制的字节数量</param>
	/// <returns>已经复制的字节数量；复制的字节数量可能少于 <paramref name="count" /> 指定的数量。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者目标流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取；或者目标流不支持写入。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制的字节数量 <paramref name="count" /> 小于0。</exception>
	public static long CopyToStream(Stream source, Stream target, long count)
	{
		Guard.AssertNotNull(source, "source stream");
		Guard.AssertNotNull(target, "target stream");
		Guard.Assert(source.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		Guard.Assert(source.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		return CopyStream(source, target, count);
	}

	/// <summary>
	/// 将当前字节流中的当前位置开始复制字节到目标字节流中
	/// </summary>
	/// <param name="source">当前字节流</param>
	/// <param name="target">目标流</param>
	/// <param name="targetStart">目标流中开始复制的位置</param>
	/// <param name="count">复制的字节数量</param>
	/// <returns>已经复制的字节数量；复制的字节数量可能少于 <paramref name="count" /> 指定的数量。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者目标流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取；或者目标流不支持写入。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">目标流开始复制的位置 <paramref name="targetStart" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制的字节数量 <paramref name="count" /> 小于0。</exception>
	public static long CopyToStream(Stream source, Stream target, long targetStart, long count)
	{
		Guard.AssertNotNull(source, "source stream");
		Guard.AssertNotNull(target, "target stream");
		Guard.Assert(source.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		Guard.Assert(source.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
		Guard.AssertIndexLowBound(targetStart, 0L, "target start");
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		Skip(target, targetStart);
		return CopyStream(source, target, count);
	}

	/// <summary>
	/// 将当前字节流中的指定位置开始复制字节到目标字节流中
	/// </summary>
	/// <param name="source">当前字节流</param>
	/// <param name="sourceStart">当前字节流中开始复制的位置</param>
	/// <param name="target">目标流</param>
	/// <returns>已经复制的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者目标流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取；或者目标流不支持写入。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">当前字节流开始复制的位置 <paramref name="sourceStart" /> 小于0。</exception>
	public static long CopyToStream(Stream source, long sourceStart, Stream target)
	{
		Guard.AssertNotNull(source, "source stream");
		Guard.AssertNotNull(target, "target stream");
		Guard.Assert(source.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		Guard.Assert(source.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
		Guard.AssertIndexLowBound(sourceStart, 0L, "source start");
		Skip(source, sourceStart);
		return CopyStream(source, target, -1L);
	}

	/// <summary>
	/// 将当前字节流中的指定位置开始复制指定数量的字节到目标字节流中
	/// </summary>
	/// <param name="source">当前字节流</param>
	/// <param name="sourceStart">当前字节流中开始复制的位置</param>
	/// <param name="target">复制的目标字节流</param>
	/// <param name="count">复制的字节数量</param>
	/// <returns>已经复制的字节数量；复制的字节数量可能少于 <paramref name="count" /> 指定的数量。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者目标流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取；或者目标流不支持写入。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">当前字节流开始复制的位置 <paramref name="sourceStart" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制的字节数量 <paramref name="count" /> 小于0。</exception>
	public static long CopyToStream(Stream source, long sourceStart, Stream target, long count)
	{
		Guard.AssertNotNull(source, "source stream");
		Guard.AssertNotNull(target, "target stream");
		Guard.Assert(source.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		Guard.Assert(source.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
		Guard.AssertIndexLowBound(sourceStart, 0L, "source start");
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		Skip(source, sourceStart);
		return CopyStream(source, target, count);
	}

	/// <summary>
	/// 将当前字节流中的指定位置开始复制指定数量的字节到目标字节流中
	/// </summary>
	/// <param name="source">当前字节流</param>
	/// <param name="sourceStart">当前字节流中开始复制的位置</param>
	/// <param name="target">复制的目标字节流</param>
	/// <param name="targetStart">目标流中开始复制的位置</param>
	/// <param name="count">复制的字节数量</param>
	/// <returns>已经复制的字节数量；复制的字节数量可能少于 <paramref name="count" /> 指定的数量。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者目标流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取；或者目标流不支持写入。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">当前字节流开始复制的位置 <paramref name="sourceStart" /> 小于0；目标流开始复制的位置 <paramref name="targetStart" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制的字节数量 <paramref name="count" /> 小于0。</exception>
	public static long CopyToStream(Stream source, long sourceStart, Stream target, long targetStart, long count)
	{
		Guard.AssertNotNull(source, "source stream");
		Guard.AssertNotNull(target, "target stream");
		Guard.Assert(source.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		Guard.Assert(source.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
		Guard.AssertIndexLowBound(sourceStart, 0L, "source start");
		Guard.AssertIndexLowBound(targetStart, 0L, "target start");
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		Skip(source, sourceStart);
		Skip(target, targetStart);
		return CopyStream(source, target, count);
	}

	private static long CopyStream(Stream source, Stream target, long count)
	{
		byte[] buff = new byte[4096];
		int readCount = 0;
		long copyCount = 0L;
		if (count < 0)
		{
			while ((readCount = source.Read(buff, 0, buff.Length)) > 0)
			{
				copyCount += readCount;
				target.Write(buff, 0, readCount);
			}
		}
		else
		{
			while ((readCount = source.Read(buff, 0, buff.Length)) > 0)
			{
				copyCount += readCount;
				if (copyCount < count)
				{
					target.Write(buff, 0, readCount);
					continue;
				}
				readCount -= (int)(copyCount - count);
				copyCount = count;
				if (readCount > 0)
				{
					target.Write(buff, 0, readCount);
				}
				break;
			}
		}
		return copyCount;
	}

	/// <summary>
	/// 将当前字节流从当前位置开始复制到内存流
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <returns>复制的内存流</returns>
	public static MemoryStream CopyToMemory(Stream stream)
	{
		Guard.AssertNotNull(stream, "stream");
		MemoryStream ms = new MemoryStream();
		stream.CopyTo(ms);
		return ms;
	}

	/// <summary>
	/// 将当前字节流从当前位置开始复制 <paramref name="count" /> 指定数量的字节到内存流
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="count">复制的字节数量</param>
	/// <returns>复制的内存流，复制的字节数可能少于指定复制的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取和搜索。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制的字节数量 <paramref name="count" /> 小于0。</exception>
	public static MemoryStream CopyToMemory(Stream stream, long count)
	{
		Guard.AssertNotNull(stream, "stream");
		Guard.Assert(stream.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		MemoryStream ms = new MemoryStream();
		CopyStream(stream, ms, count);
		return ms;
	}

	/// <summary>
	/// 将当前字节流中的指定位置开始复制指定数量的字节到内存流中
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="start">当期流开始复制的字节偏移量</param>
	/// <param name="count">复制的字节数量</param>
	/// <returns>复制的内存流，复制的字节数可能少于指定复制的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">当前字节流开始复制的位置 <paramref name="start" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">复制的字节数量 <paramref name="count" /> 小于0。</exception>
	public static MemoryStream CopyToMemory(Stream stream, long start, long count)
	{
		Guard.AssertNotNull(stream, "stream");
		Guard.Assert(stream.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		Guard.AssertIndexLowBound(start, 0L, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		Skip(stream, start);
		MemoryStream ms = new MemoryStream();
		CopyStream(stream, ms, count);
		return ms;
	}

	/// <summary>
	/// 创建当前字节流的压缩流
	/// </summary>
	/// <typeparam name="T">压缩流类型</typeparam>
	/// <param name="stream">当前字节流</param>
	/// <returns>以当前字节流为基础的压缩流。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static T CreateCompressStream<T>(Stream stream) where T : Stream
	{
		Guard.AssertNotNull(stream, "stream");
		if (typeof(T).Equals(typeof(DeflateStream)))
		{
			return new DeflateStream(stream, CompressionMode.Compress, leaveOpen: true) as T;
		}
		if (typeof(T).Equals(typeof(GZipStream)))
		{
			return new GZipStream(stream, CompressionMode.Compress, leaveOpen: true) as T;
		}
		throw new NotSupportedException(string.Format(Literals.MSG_CompressionTypeNotSupported_1, typeof(T).FullName));
	}

	/// <summary>
	/// 创建当前字节流的压缩流
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="type">压缩流类型</param>
	/// <returns>以当前字节流为基础的压缩流。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static Stream CreateCompressStream(Stream stream, CompressionType type)
	{
		Guard.AssertNotNull(stream, "stream");
		return type switch
		{
			CompressionType.Deflate => CreateCompressStream<DeflateStream>(stream), 
			CompressionType.GZip => CreateCompressStream<GZipStream>(stream), 
			_ => throw new NotSupportedException(string.Format(Literals.MSG_CompressionTypeNotSupported_1, type.ToString())), 
		};
	}

	/// <summary>
	/// 创建当前字节流的解压缩流
	/// </summary>
	/// <typeparam name="T">解压缩流类型</typeparam>
	/// <param name="stream">当前字节流</param>
	/// <returns>以当前字节流为基础建立的解压缩流。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static T CreateDecompressStream<T>(Stream stream) where T : Stream
	{
		Guard.AssertNotNull(stream, "stream");
		if (typeof(T).Equals(typeof(DeflateStream)))
		{
			return new DeflateStream(stream, CompressionMode.Decompress, leaveOpen: true) as T;
		}
		if (typeof(T).Equals(typeof(GZipStream)))
		{
			return new GZipStream(stream, CompressionMode.Decompress, leaveOpen: true) as T;
		}
		throw new NotSupportedException(string.Format(Literals.MSG_CompressionTypeNotSupported_1, typeof(T).FullName));
	}

	/// <summary>
	/// 创建当前字节流的解压缩流
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="type">解压缩流类型</param>
	/// <returns>以当前字节流为基础建立的解压缩流，如果不支持指定的解压缩流类型则返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static Stream CreateDecompressStream(Stream stream, CompressionType type)
	{
		Guard.AssertNotNull(stream, "stream");
		return type switch
		{
			CompressionType.Deflate => CreateDecompressStream<DeflateStream>(stream), 
			CompressionType.GZip => CreateDecompressStream<GZipStream>(stream), 
			_ => throw new NotSupportedException(string.Format(Literals.MSG_CompressionTypeNotSupported_1, type.ToString())), 
		};
	}

	/// <summary>
	/// 创建当前字节流的指定字符编码的文本读取流
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="encoding">文本字符编码，默认为UTF-8编码</param>
	/// <returns>基于当前字节流的文本读取流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	public static StreamReader CreateReader(Stream stream, Encoding encoding = null)
	{
		Guard.AssertNotNull(stream, "stream");
		return new StreamReader(stream, ObjectHelper.IfNull(encoding, Encoding.UTF8));
	}

	/// <summary>
	/// 根据当前字节数据创建流对象
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <returns>新的流对象，流内数据为当前字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <remarks>本方法创建新的流对象，当前的字节数据被复制到新的流内，流的当前位置为流的开头。本方法的调用者应负责关闭创建的流对象。</remarks>
	public static Stream CreateStream(byte[] data)
	{
		Guard.AssertNotNull(data, "data");
		return CreateStream(data, 0, data.Length);
	}

	/// <summary>
	/// 根据当前字节数据创建流对象
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="start">开始处理的字节索引位置</param>
	/// <param name="count">处理的字节数量</param>
	/// <returns>新的流对象，流内数据为当前字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的字节数。</exception>
	/// <remarks>本方法创建新的流对象，当前的字节数据被复制到新的流内，流的当前位置为流的开头。本方法的调用者应负责关闭创建的流对象。</remarks>
	public static Stream CreateStream(byte[] data, int start, int count)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertIndexRange(start, 0, data.Length - 1, "start");
		Guard.AssertBetween(count, 0, data.Length - start, "count");
		MemoryStream stream = new MemoryStream(count);
		stream.Write(data, start, count);
		stream.Position = 0L;
		return stream;
	}

	/// <summary>
	/// 根据当前字节序列创建流对象
	/// </summary>
	/// <param name="data">当前字节序列</param>
	/// <returns>新的流对象，流内数据为当前字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	/// <remarks>本方法创建新的流对象，当前的字节序列被复制到新的流内，流的当前位置为流的开头。本方法的调用者应负责关闭创建的流对象。</remarks>
	public static Stream CreateStream(IEnumerable<byte> data)
	{
		Guard.AssertNotNull(data, "data");
		MemoryStream stream = new MemoryStream(1024);
		foreach (byte b in data)
		{
			stream.WriteByte(b);
		}
		stream.Position = 0L;
		return stream;
	}

	/// <summary>
	/// 创建当前文件的可读写流；如果当前文件存在则清空当前文件，如果当前文件不存在则创建新文件。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件的可读写流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static Stream CreateStream(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		return file.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.None);
	}

	/// <summary>
	/// 创建当前字节流的指定字符编码的文本写入流
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="encoding">文本字符编码，默认为UTF-8编码</param>
	/// <returns>基于当前字节流的文本写入流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	public static StreamWriter CreateWriter(Stream stream, Encoding encoding = null)
	{
		Guard.AssertNotNull(stream, "stream");
		return new StreamWriter(stream, ObjectHelper.IfNull(encoding, Encoding.UTF8));
	}

	/// <summary>
	/// 对当前字节数据进行解压缩
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="type">压缩算法类型，默认为 <see cref="F:Richfit.Garnet.Common.IO.CompressionType.Deflate" /></param>
	/// <returns>返回解压缩的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static byte[] Decompress(byte[] data, CompressionType type = CompressionType.Deflate)
	{
		Guard.AssertNotNull(data, "data");
		return Decompress(data, 0, data.Length, type);
	}

	/// <summary>
	/// 对当前字节数据进行解压缩
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="start">开始处理的字节索引位置</param>
	/// <param name="count">处理的字节数量</param>
	/// <param name="type">压缩算法类型，默认为 <see cref="F:Richfit.Garnet.Common.IO.CompressionType.Deflate" /></param>
	/// <returns>返回解压缩的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的字节数。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static byte[] Decompress(byte[] data, int start, int count, CompressionType type = CompressionType.Deflate)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertIndexRange(start, 0, data.Length - 1, "start");
		Guard.AssertBetween(count, 0, data.Length - start, "count");
		using MemoryStream ms = new MemoryStream((int)((double)count * 1.5));
		using MemoryStream cs = new MemoryStream(count);
		cs.Write(data, start, count);
		cs.Position = 0L;
		using Stream ds = CreateDecompressStream(cs, type);
		ds.CopyTo(ms);
		ds.Close();
		cs.Close();
		ms.Close();
		return ms.ToArray();
	}

	/// <summary>
	/// 对当前字节数据进行解压缩
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="type">压缩算法类型，默认为 <see cref="F:Richfit.Garnet.Common.IO.CompressionType.Deflate" /></param>
	/// <returns>返回解压缩的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static byte[] Decompress(IEnumerable<byte> data, CompressionType type = CompressionType.Deflate)
	{
		Guard.AssertNotNull(data, "data");
		using MemoryStream ms = new MemoryStream(1024);
		using MemoryStream cs = new MemoryStream(1024);
		foreach (byte b in data)
		{
			cs.WriteByte(b);
		}
		cs.Position = 0L;
		using Stream ds = CreateDecompressStream(cs, type);
		ds.CopyTo(ms);
		ds.Close();
		cs.Close();
		ms.Close();
		return ms.ToArray();
	}

	/// <summary>
	/// 将当前字节数据解压缩，并按 <paramref name="encoding" /> 指定的编码把字节数据解码为文本
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="encoding">文本字符编码，默认为 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <param name="type">压缩算法类型，默认为 <see cref="F:Richfit.Garnet.Common.IO.CompressionType.Deflate" /></param>
	/// <returns>处理后生成的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static string DecompressText(byte[] data, Encoding encoding = null, CompressionType type = CompressionType.Deflate)
	{
		return TextHelper.TextDecode(Decompress(data, type), ObjectHelper.IfNull(encoding, Encoding.UTF8));
	}

	/// <summary>
	/// 将当前字节数据解压缩，并按 <paramref name="encoding" /> 指定的编码把字节数据解码为文本
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="encoding">文本字符编码，默认为 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <param name="type">压缩算法类型，默认为 <see cref="F:Richfit.Garnet.Common.IO.CompressionType.Deflate" /></param>
	/// <returns>处理后生成的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static string DecompressText(IEnumerable<byte> data, Encoding encoding = null, CompressionType type = CompressionType.Deflate)
	{
		return TextHelper.TextDecode(Decompress(data, type), ObjectHelper.IfNull(encoding, Encoding.UTF8));
	}

	/// <summary>
	/// 打开当前文件，并返回指定文本编码的字符读取流
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="encoding">文本字符编码，默认的编码为UTF-8</param>
	/// <returns>文件的字符流读取器</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当期文件不存在。</exception>
	public static StreamReader OpenReader(FileInfo file, Encoding encoding = null)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		return new StreamReader(file.Open(FileMode.Open, FileAccess.Read, FileShare.None), ObjectHelper.IfNull(encoding, Encoding.UTF8));
	}

	/// <summary>
	/// 打开当前文件的可读写字节流读取器，流的当前位置默认在文件头部；如果当前文件不存在则创建新文件。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>文件的可读写字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static Stream OpenStream(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		return file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
	}

	/// <summary>
	/// 打开当前文件，并返回指定文本编码的字符流写入流；如果当前文件不存在则创建新文件。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="append">是否追加到当前文件</param>
	/// <returns>当前文件的字符写入流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <remarks>在追加模式下，打开现有文件并追加，或者创建新文件；在非追加模式下，打开现有文件并从文件头部写入，或者创建新文件。</remarks>
	public static StreamWriter OpenWriter(FileInfo file, bool append = false)
	{
		Guard.AssertNotNull(file, "file");
		return new StreamWriter(file.Open(append ? FileMode.Append : FileMode.OpenOrCreate, FileAccess.Write, FileShare.None), Encoding.UTF8);
	}

	/// <summary>
	/// 打开当前文件，并返回指定文本编码的字符写入流；如果当前文件不存在则创建新文件。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="encoding">文本字符编码；如果为空，则默认为UTF-8编码。</param>
	/// <param name="append">是否追加到当前文件</param>
	/// <returns>当前文件的字符写入流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <remarks>在追加模式下，打开现有文件并追加，或者创建新文件；在非追加模式下，打开现有文件并从文件头部写入，或者创建新文件。</remarks>
	public static StreamWriter OpenWriter(FileInfo file, Encoding encoding, bool append = false)
	{
		Guard.AssertNotNull(file, "file");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		return new StreamWriter(file.Open(append ? FileMode.Append : FileMode.OpenOrCreate, FileAccess.Write, FileShare.None), encoding);
	}

	/// <summary>
	/// 读取当前字节流中所有的字节（从字节流的起始位置不是当前位置，到流的结束之间所有的字节）
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <returns>当前流中的所有字节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	public static byte[] ReadAllBytes(Stream stream)
	{
		return ReadBytes(stream);
	}

	/// <summary>
	/// 读取当前字节流中所有的字节（从字节流的起始位置不是当前位置，到流的结束之间所有的字节），并按 <paramref name="encoding" /> 解码为文本。
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="encoding">文本编码，默认为UTF-8</param>
	/// <returns>解码后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	public static string ReadAllText(Stream stream, Encoding encoding = null)
	{
		return TextHelper.TextDecode(ReadAllBytes(stream), encoding);
	}

	/// <summary>
	/// 读取当前字节流从当前位置开始的字节
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <returns>读取的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取。</exception>
	public static byte[] ReadBytes(Stream stream)
	{
		Guard.AssertNotNull(stream, "stream");
		Guard.Assert(stream.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		byte[] bytes = null;
		using (MemoryStream ms = new MemoryStream())
		{
			CopyStream(stream, ms, -1L);
			bytes = ms.ToArray();
			ms.Close();
		}
		return bytes;
	}

	/// <summary>
	/// 读取当前字节流从当前位置开始指定数量的字节
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="count">读取的字节数量</param>
	/// <returns>读取的字节数组，读取的字节数量可能少于指定的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">读取的字节数量 <paramref name="count" /> 小于0。</exception>
	public static byte[] ReadBytes(Stream stream, long count)
	{
		Guard.AssertNotNull(stream, "stream");
		Guard.Assert(stream.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		byte[] bytes = null;
		using (MemoryStream ms = new MemoryStream())
		{
			CopyStream(stream, ms, count);
			bytes = ms.ToArray();
			ms.Close();
		}
		return bytes;
	}

	/// <summary>
	/// 读取当前字节流从指定的位置开始指定数量的字节
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="start">当期流开始读取的字节偏移量</param>
	/// <param name="count">读取的字节数量</param>
	/// <returns>读取的字节数组，读取的字节数量可能少于指定的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">当前字节流开始读取的位置 <paramref name="start" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">读取的字节数量 <paramref name="count" /> 小于0。</exception>
	public static byte[] ReadBytes(Stream stream, long start, long count)
	{
		Guard.AssertNotNull(stream, "stream");
		Guard.Assert(stream.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		Guard.AssertIndexLowBound(start, 0L, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		byte[] bytes = null;
		Skip(stream, start);
		using (MemoryStream ms = new MemoryStream())
		{
			CopyStream(stream, ms, count);
			bytes = ms.ToArray();
			ms.Close();
		}
		return bytes;
	}

	/// <summary>
	/// 读取当前流从当前位置开始的字节，并按 <paramref name="encoding" /> 解码后的文本
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="encoding">文本编码，默认为UTF-8</param>
	/// <returns>解码后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取。</exception>
	public static string ReadText(Stream stream, Encoding encoding = null)
	{
		return TextHelper.TextDecode(ReadBytes(stream), encoding);
	}

	/// <summary>
	/// 读取当前字节流从当前位置开始 <paramref name="count" /> 指定数量的字节，并按 <paramref name="encoding" /> 解码后的文本
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="count">读取的字节数量</param>
	/// <param name="encoding">文本编码，默认为UTF-8</param>
	/// <returns>解码后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">读取的字节数量 <paramref name="count" /> 小于0。</exception>
	public static string ReadText(Stream stream, long count, Encoding encoding = null)
	{
		return TextHelper.TextDecode(ReadBytes(stream, count), encoding);
	}

	/// <summary>
	/// 读取当前字节流从 <paramref name="start" /> 指定的位置开始 <paramref name="count" /> 指定数量的字节，按 <paramref name="encoding" /> 解码的文本。
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="start">当期流开始读取的字节偏移量</param>
	/// <param name="count">读取的字节数量</param>
	/// <param name="encoding">文本编码，默认为UTF-8</param>
	/// <returns>解码后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取和搜索。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">当前字节流开始读取的位置 <paramref name="start" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">读取的字节数量 <paramref name="count" /> 小于0。</exception>
	public static string ReadText(Stream stream, long start, long count, Encoding encoding = null)
	{
		return TextHelper.TextDecode(ReadBytes(stream, start, count), encoding);
	}

	/// <summary>
	/// 将当前字节流中的数据保存到文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="file">保存的目标文件</param>
	/// <param name="overwrite">如果目标文件存在，是否覆盖目标文件。等于true，覆盖目标文件；等于false，追加到目标文件。</param>
	/// <returns>保存数据后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者保存的目标文件 <paramref name="file" /> 为空。</exception>
	public static FileInfo SaveFile(Stream stream, string file, bool overwrite = true)
	{
		Guard.AssertNotNull(file, "target file");
		return SaveFile(stream, ToFileInfo(file), overwrite);
	}

	/// <summary>
	/// 将当前字节流中的数据保存到文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="count">保存的字节数量</param>
	/// <param name="file">保存的目标文件</param>
	/// <param name="overwrite">如果目标文件存在，是否覆盖目标文件。等于true，覆盖目标文件；等于false，追加到目标文件。</param>
	/// <returns>保存数据后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者保存的目标文件 <paramref name="file" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">保存的字节数量 <paramref name="count" /> 小于0。</exception>
	public static FileInfo SaveFile(Stream stream, long count, string file, bool overwrite = true)
	{
		Guard.AssertNotNull(file, "target file");
		return SaveFile(stream, count, ToFileInfo(file), overwrite);
	}

	/// <summary>
	/// 将当前字节流中的数据保存到文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="start">当前字节流开始保存到文件的字节的索引</param>
	/// <param name="count">保存的字节数量</param>
	/// <param name="file">保存的目标文件</param>
	/// <param name="overwrite">如果目标文件存在，是否覆盖目标文件。等于true，覆盖目标文件；等于false，追加到目标文件。</param>
	/// <returns>保存数据后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者保存的目标文件 <paramref name="file" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始保存的字节的索引 <paramref name="start" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">保存的字节数量 <paramref name="count" /> 小于0。</exception>
	public static FileInfo SaveFile(Stream stream, long start, long count, string file, bool overwrite = true)
	{
		Guard.AssertNotNull(file, "target file");
		return SaveFile(stream, start, count, ToFileInfo(file), overwrite);
	}

	/// <summary>
	/// 将当前字节流中的数据保存到文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="file">保存的目标文件</param>
	/// <param name="overwrite">如果目标文件存在，是否覆盖目标文件。等于true，覆盖目标文件；等于false，追加到目标文件。</param>
	/// <returns>保存数据后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者保存的目标文件 <paramref name="file" /> 为空。</exception>
	public static FileInfo SaveFile(Stream stream, FileInfo file, bool overwrite = true)
	{
		Guard.AssertNotNull(stream, "stream");
		Guard.AssertNotNull(file, "target file");
		using (FileStream fs = file.Open(overwrite ? FileMode.Create : FileMode.Append, FileAccess.Write, FileShare.None))
		{
			stream.CopyTo(fs);
			fs.Close();
		}
		return file;
	}

	/// <summary>
	/// 将当前字节流中的数据保存到文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="count">保存的字节数量</param>
	/// <param name="file">保存的目标文件</param>
	/// <param name="overwrite">如果目标文件存在，是否覆盖目标文件。等于true，覆盖目标文件；等于false，追加到目标文件。</param>
	/// <returns>保存数据后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者保存的目标文件 <paramref name="file" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">保存的字节数量 <paramref name="count" /> 小于0。</exception>
	public static FileInfo SaveFile(Stream stream, long count, FileInfo file, bool overwrite = true)
	{
		Guard.AssertNotNull(stream, "stream");
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		Guard.AssertNotNull(file, "target file");
		long writeCount = 0L;
		long readByte = -1L;
		using (FileStream fs = file.Open(overwrite ? FileMode.Create : FileMode.Append, FileAccess.Write, FileShare.None))
		{
			while (writeCount++ < count && (readByte = stream.ReadByte()) >= 0)
			{
				fs.WriteByte((byte)readByte);
			}
			fs.Close();
		}
		return file;
	}

	/// <summary>
	/// 将当前字节流中的数据保存到文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="start">当前字节流开始保存到文件的字节的索引</param>
	/// <param name="count">保存的字节数量</param>
	/// <param name="file">保存的目标文件</param>
	/// <param name="overwrite">如果目标文件存在，是否覆盖目标文件。等于true，覆盖目标文件；等于false，追加到目标文件。</param>
	/// <returns>保存数据后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者保存的目标文件 <paramref name="file" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始保存的字节的索引 <paramref name="start" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">保存的字节数量 <paramref name="count" /> 小于0。</exception>
	public static FileInfo SaveFile(Stream stream, long start, long count, FileInfo file, bool overwrite = true)
	{
		Guard.AssertNotNull(stream, "stream");
		Guard.AssertIndexLowBound(start, 0L, "start");
		Skip(stream, start);
		return SaveFile(stream, count, file, overwrite);
	}

	/// <summary>
	/// 将当前字节流中的数据保存到临时文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="tempPath">保存的临时文件的位置</param>
	/// <returns>保存后的临时文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="tempPath" /> 指定的路径不存在，且无法创建。</exception>
	public static FileInfo SaveTempFile(Stream stream, string tempPath = null)
	{
		Guard.AssertNotNull(stream, "stream");
		return SaveFile(stream, CreateTempFile(tempPath), overwrite: false);
	}

	/// <summary>
	/// 将当前字节流中的数据保存到临时文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="count">保存的字节数量</param>
	/// <param name="tempPath">保存的临时文件的位置</param>
	/// <returns>保存后的临时文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">保存的字节数量 <paramref name="count" /> 小于0。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="tempPath" /> 指定的路径不存在，且无法创建。</exception>
	public static FileInfo SaveTempFile(Stream stream, long count, string tempPath = null)
	{
		Guard.AssertNotNull(stream, "stream");
		return SaveFile(stream, count, CreateTempFile(tempPath), overwrite: false);
	}

	/// <summary>
	/// 将当前字节流中的数据保存到临时文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="start">当前字节流开始保存到文件的字节的索引</param>
	/// <param name="count">保存的字节数量</param>
	/// <param name="tempPath">保存的临时文件的位置</param>
	/// <returns>保存后的临时文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始保存的字节的索引 <paramref name="start" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">保存的字节数量 <paramref name="count" /> 小于0。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="tempPath" /> 指定的路径不存在，且无法创建。</exception>
	public static FileInfo SaveTempFile(Stream stream, long start, long count, string tempPath = null)
	{
		Guard.AssertNotNull(stream, "stream");
		return SaveFile(stream, start, count, CreateTempFile(tempPath), overwrite: false);
	}

	/// <summary>
	/// 将当前字节流中的数据保存到临时文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="tempPath">保存的临时文件的位置</param>
	/// <returns>保存后的临时文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者临时文件保存位置 <paramref name="tempPath" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="tempPath" /> 指定的路径不存在，且无法创建。</exception>
	public static FileInfo SaveTempFile(Stream stream, DirectoryInfo tempPath)
	{
		Guard.AssertNotNull(stream, "stream");
		Guard.AssertNotNull(tempPath, "temp file location");
		return SaveFile(stream, CreateTempFile(tempPath), overwrite: false);
	}

	/// <summary>
	/// 将当前字节流中的数据保存到临时文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="count">保存的字节数量</param>
	/// <param name="tempPath">保存的临时文件的位置</param>
	/// <returns>保存后的临时文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者临时文件保存位置 <paramref name="tempPath" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">保存的字节数量 <paramref name="count" /> 小于0。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="tempPath" /> 指定的路径不存在，且无法创建。</exception>
	public static FileInfo SaveTempFile(Stream stream, long count, DirectoryInfo tempPath)
	{
		Guard.AssertNotNull(stream, "stream");
		Guard.AssertNotNull(tempPath, "temp file location");
		return SaveFile(stream, count, CreateTempFile(tempPath), overwrite: false);
	}

	/// <summary>
	/// 将当前字节流中的数据保存到临时文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="start">当前字节流开始保存到文件的字节的索引</param>
	/// <param name="count">保存的字节数量</param>
	/// <param name="tempPath">保存的临时文件的位置</param>
	/// <returns>保存后的临时文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者临时文件保存位置 <paramref name="tempPath" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始保存的字节的索引 <paramref name="start" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">保存的字节数量 <paramref name="count" /> 小于0。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="tempPath" /> 指定的路径不存在，且无法创建。</exception>
	public static FileInfo SaveTempFile(Stream stream, long start, long count, DirectoryInfo tempPath)
	{
		Guard.AssertNotNull(stream, "stream");
		Guard.AssertNotNull(tempPath, "temp file location");
		return SaveFile(stream, start, count, CreateTempFile(tempPath), overwrite: false);
	}

	/// <summary>
	/// 将当前字节流的当前位置定位到流的起始位置
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <returns>重新等位后的流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持搜索。</exception>
	public static Stream SeekToBegin(Stream stream)
	{
		Guard.AssertNotNull(stream, "stream");
		Guard.Assert(stream.CanSeek, () => new NotSupportedException(Literals.MSG_StreamNotSupportSeek));
		stream.Seek(0L, SeekOrigin.Begin);
		return stream;
	}

	/// <summary>
	/// 将当前字节流的当前位置定位到流的末尾
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <returns>重新等位后的流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持搜索。</exception>
	public static Stream SeekToEnd(Stream stream)
	{
		Guard.AssertNotNull(stream, "stream");
		Guard.Assert(stream.CanSeek, () => new NotSupportedException(Literals.MSG_StreamNotSupportSeek));
		stream.Seek(0L, SeekOrigin.End);
		return stream;
	}

	/// <summary>
	/// 将当前流的当前位置向前或者向后跳过指定数量的字节
	/// </summary>
	/// <param name="stream">当前流</param>
	/// <param name="count">跳过的字节数量；指定的数量小于0，则向前跳过；指定的数量大于0，则向后跳过。</param>
	/// <returns>移动后的流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前流为空。</exception>
	public static void Skip(Stream stream, long count)
	{
		Guard.AssertNotNull(stream, "stream");
		if (count > 0)
		{
			if (stream.CanSeek)
			{
				stream.Position += count;
				return;
			}
			while (count-- > 0)
			{
				stream.ReadByte();
			}
		}
		else if (count < 0)
		{
			if (!stream.CanSeek)
			{
				throw new NotSupportedException(Literals.MSG_StreamNotSupportSeek);
			}
			stream.Position += count;
		}
	}

	/// <summary>
	/// 把当前的字节数组转换为只读的流对象。
	/// </summary>
	/// <param name="data">当前的字节数组</param>
	/// <returns>创建的只读流对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <remarks>
	/// 创建的流对象以当前字节数据为基础，不可以改变容量，不可修改流内容。
	/// 本方法创建新的流对象，当前的字节数据被复制到新的流内，流的当前位置为流的开头。本方法的调用者应负责关闭创建的流对象。
	/// </remarks>
	public static Stream ToReadonlyStream(byte[] data)
	{
		Guard.AssertNotNull(data, "data");
		MemoryStream stream = new MemoryStream(data, writable: false);
		stream.Position = 0L;
		return stream;
	}

	/// <summary>
	/// 把当前的字节数组转换为只读的流对象
	/// </summary>
	/// <param name="data">当前的字节数组</param>
	/// <param name="start">开始处理的字节索引位置</param>
	/// <param name="count">处理的字节数量</param>
	/// <returns>创建的只读流对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的字节数。</exception>
	/// <remarks>
	/// 创建的流对象以当前字节数据为基础，不可以改变容量，不可修改流内容。
	/// 本方法创建新的流对象，当前的字节数据被复制到新的流内，流的当前位置为流的开头。本方法的调用者应负责关闭创建的流对象。
	/// </remarks>
	public static Stream ToReadonlyStream(byte[] data, int start, int count)
	{
		Guard.AssertNotNull(data, "data");
		Guard.AssertIndexRange(start, 0, data.Length - 1, "start");
		Guard.AssertBetween(count, 0, data.Length - start, "count");
		MemoryStream stream = new MemoryStream(data, start, count, writable: false);
		stream.Position = 0L;
		return stream;
	}

	/// <summary>
	/// 把当前的字节数组转换为只读的流对象
	/// </summary>
	/// <param name="data">当前字节序列</param>
	/// <returns>创建的只读流对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	/// <remarks>
	/// 创建的流对象以当前字节数据为基础，不可以改变容量，不可修改流内容。
	/// 本方法创建新的流对象，当前的字节数据被复制到新的流内，流的当前位置为流的开头。本方法的调用者应负责关闭创建的流对象。
	/// </remarks>
	public static Stream ToReadonlyStream(IEnumerable<byte> data)
	{
		Guard.AssertNotNull(data, "data");
		return ToReadonlyStream(data.ToArray());
	}

	/// <summary>
	/// 把当前的字节数组转换为流对象。
	/// </summary>
	/// <param name="bytes">当前的字节数组</param>
	/// <param name="writable">流对象是否可写，默认为true</param>
	/// <returns>创建的流对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <remarks>创建的流对象以当前字节数据为基础，不可以改变容量。</remarks>
	public static Stream ToStream(byte[] bytes, bool writable = true)
	{
		Guard.AssertNotNull(bytes, "bytes");
		MemoryStream stream = new MemoryStream(bytes, writable);
		stream.Position = 0L;
		return stream;
	}

	/// <summary>
	/// 把当前的字节数组转换为流对象
	/// </summary>
	/// <param name="bytes">当前的字节数组</param>
	/// <param name="start">开始处理的字节索引位置</param>
	/// <param name="count">处理的字节数量</param>
	/// <param name="writable">流对象是否可写，默认为true</param>
	/// <returns>创建的流对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的字节数。</exception>
	/// <remarks>
	/// 创建的流对象以当前字节数据为基础，不可以改变容量。
	/// 本方法创建新的流对象，当前的字节数据被复制到新的流内，流的当前位置为流的开头。本方法的调用者应负责关闭创建的流对象。
	/// </remarks>
	public static Stream ToStream(byte[] bytes, int start, int count, bool writable = true)
	{
		Guard.AssertNotNull(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		Guard.AssertBetween(count, 0, bytes.Length - start, "count");
		MemoryStream stream = new MemoryStream(bytes, start, count, writable);
		stream.Position = 0L;
		return stream;
	}

	/// <summary>
	/// 把当前的字节数组转换为流对象
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="writable">流对象是否可写，默认为true</param>
	/// <returns>创建的流对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	/// <remarks>
	/// 创建的流对象以当前字节数据为基础，不可以改变容量。
	/// 本方法创建新的流对象，当前的字节数据被复制到新的流内，流的当前位置为流的开头。本方法的调用者应负责关闭创建的流对象。
	/// </remarks>
	public static Stream ToStream(IEnumerable<byte> bytes, bool writable = true)
	{
		Guard.AssertNotNull(bytes, "bytes");
		return ToStream(bytes.ToArray(), writable);
	}

	/// <summary>
	/// 向当前字节流中写入字节数据
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="data">待写入的字节数组</param>
	/// <returns>写入后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者写入的字节数组 <paramref name="data" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持写入。</exception>
	public static Stream WriteBytes(Stream stream, params byte[] data)
	{
		Guard.AssertNotNull(data, "data");
		return WriteBytes(stream, 0L, data, 0L, data.LongLength);
	}

	/// <summary>
	/// 向当前字节流中写入字节数据
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="data">写入的字节序列</param>
	/// <returns>写入后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者写入的字节数据 <paramref name="data" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持写入。</exception>
	public static Stream WriteBytes(Stream stream, IEnumerable<byte> data)
	{
		return WriteBytes(stream, 0L, data);
	}

	/// <summary>
	/// 向当前字节流中写入字节数据
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="data">写入的字节数据</param>
	/// <param name="start">数组开始写入的字节位置</param>
	/// <param name="count">数组写入的字节的数量</param>
	/// <returns>写入后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者写入的字节数组为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持写入。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">数组写入的起始位置 <paramref name="start" /> 小于0，或者大于当前字节数组的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">数组写入的字节数量 <paramref name="count" /> 小于0，或者大于当前字节数组从写入起始位置 <paramref name="start" /> 开始剩余的字节数量。</exception>
	public static Stream WriteBytes(Stream stream, byte[] data, long start, long count)
	{
		return WriteBytes(stream, 0L, data, start, count);
	}

	/// <summary>
	/// 向当前字节流中写入字节数据
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="position">当前字节流写入位置</param>
	/// <param name="data">写入的字节数据</param>
	/// <returns>写入后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者写入的字节数据 <paramref name="data" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持写入。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">当前字节流写入位置 <paramref name="position" /> 小于0。</exception>
	public static Stream WriteBytes(Stream stream, long position, params byte[] data)
	{
		Guard.AssertNotNull(data, "data");
		return WriteBytes(stream, position, data, 0L, data.LongLength);
	}

	/// <summary>
	/// 向当前字节流中写入字节数据
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="position">当前字节流写入位置</param>
	/// <param name="data">写入的字节序列</param>
	/// <returns>写入后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者写入的字节数据 <paramref name="data" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持写入。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">当前字节流写入位置 <paramref name="position" /> 小于0。</exception>
	public static Stream WriteBytes(Stream stream, long position, IEnumerable<byte> data)
	{
		Guard.AssertNotNull(stream, "stream");
		Guard.Assert(stream.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
		Guard.AssertIndexLowBound(position, 0L, "position");
		Guard.AssertNotNull(data, "data");
		Skip(stream, position);
		foreach (byte b in data)
		{
			stream.WriteByte(b);
		}
		return stream;
	}

	/// <summary>
	/// 向当前字节流中写入字节数据
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="position">当前字节流写入位置</param>
	/// <param name="data">写入的字节数据</param>
	/// <param name="start">字节数据开始写入的位置</param>
	/// <param name="count">字节数据写入的字节数量</param>
	/// <returns>写入后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者写入的字节数据 <paramref name="data" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持写入。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">当前字节流写入位置 <paramref name="position" /> 小于0；或者字节数据开始写入的位置 <paramref name="start" /> 小于0，或者大于字节数据的最大字节索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">字节数据写入的字节数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始写入的字节数据剩余的字节数量。</exception>
	public static Stream WriteBytes(Stream stream, long position, byte[] data, long start, long count)
	{
		Guard.AssertNotNull(stream, "stream");
		Guard.Assert(stream.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
		Guard.AssertIndexLowBound(position, 0L, "position");
		Guard.AssertNotNull(data, "data");
		Guard.AssertIndexRange(start, 0L, data.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, data.LongLength - start, "count");
		Skip(stream, position);
		if (start <= int.MaxValue && count <= int.MaxValue)
		{
			stream.Write(data, (int)start, (int)count);
		}
		else
		{
			long end = start + count;
			for (long i = start; i < end; i++)
			{
				stream.WriteByte(data[i]);
			}
		}
		return stream;
	}
}
