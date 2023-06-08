using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Text;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.IO.FileInfo" /> 类型扩展方法类
/// </summary>
public static class FileInfoExtensions
{
	/// <summary>
	/// 向当前文件中追加文本
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="text">追加的文本</param>
	/// <param name="encoding">追加的文本的字符编码，默认为UTF-8</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="text" /> 为空。</exception>
	public static void Append(this FileInfo file, string text, Encoding encoding = null)
	{
		file.Write(text, append: true, encoding);
	}

	/// <summary>
	/// 向当前文件中追加字节数据
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="bytes">追加的字节数据</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="bytes" /> 为空。</exception>
	public static void Append(this FileInfo file, byte[] bytes)
	{
		file.Write(bytes, append: true);
	}

	/// <summary>
	/// 向当前文件中追加字节流
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="stream">追加的字节流</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="stream" /> 为空。</exception>
	public static void Append(this FileInfo file, Stream stream)
	{
		file.Write(stream, append: true);
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
	public static FileInfo ChangeExtension(this FileInfo file, string extension, bool overwrite = false)
	{
		file.GuardNotNull("file").GuardExistence();
		extension.GuardNotNull("extension");
		string targetName = file.GetNameWithoutExtension() + (extension.IsNotNullAndEmpty() ? ("." + extension) : string.Empty);
		FileInfo target = new FileInfo(Path.Combine(file.DirectoryName, targetName));
		file.MoveTo(target, overwrite);
		return target;
	}

	/// <summary>
	/// 判断当前文件中是否包含Html标记
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="encoding">当前文件的字符编码，默认为UTF-8</param>
	/// <returns>如果文件中的内容包含Html标记返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static bool ContainsHtmlTags(this FileInfo file, Encoding encoding = null)
	{
		file.GuardNotNull("file").GuardExistence();
		return RegexPatterns.HtmlTag.IsMatch(file.ReadText(encoding));
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
	public static void CopyTo(this FileInfo file, FileInfo target, bool overwrite = false)
	{
		file.GuardNotNull("file").GuardExistence();
		target.GuardNotNull("target");
		if (!overwrite && target.Exists)
		{
			throw new IOException(Literals.MSG_FileExistsException_1.FormatValue(target.FullName));
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
	public static FileInfo CopyTo(this FileInfo file, string targetFile, Func<FileInfo, FileInfo, bool> predicate)
	{
		file.GuardNotNull("file").GuardExistence();
		targetFile.GuardNotNullAndEmpty("target file");
		predicate.GuardNotNull("predicate");
		FileInfo target = new FileInfo(targetFile);
		if (predicate(file, target))
		{
			file.Refresh();
			target.Refresh();
			file.CopyTo(target, overwrite: true);
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
	public static FileInfo CopyTo(this FileInfo file, DirectoryInfo directory, bool overwrite = false)
	{
		file.GuardNotNull("file").GuardExistence();
		directory.GuardNotNull("directory");
		FileInfo target = new FileInfo(Path.Combine(directory.FullName, file.Name));
		file.CopyTo(target, overwrite);
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
	public static FileInfo CopyTo(this FileInfo file, DirectoryInfo directory, Func<FileInfo, FileInfo, bool> predicate)
	{
		file.GuardNotNull("file").GuardExistence();
		directory.GuardNotNull("directory");
		predicate.GuardNotNull("predicate");
		FileInfo target = new FileInfo(Path.Combine(directory.FullName, file.Name));
		if (predicate(file, target))
		{
			file.Refresh();
			target.Refresh();
			file.CopyTo(target, overwrite: true);
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
	public static FileInfo CopyTo(this FileInfo file, string directoryPath, string filename, bool overwrite = false)
	{
		file.GuardNotNull("file").GuardExistence();
		directoryPath.GuardNotNullAndEmpty("directory path");
		FileInfo target = new FileInfo(Path.Combine(directoryPath, filename.IfNull(file.Name)));
		file.CopyTo(target, overwrite);
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
	public static FileInfo CopyTo(this FileInfo file, string directoryPath, string filename, Func<FileInfo, FileInfo, bool> predicate)
	{
		file.GuardNotNull("file").GuardExistence();
		directoryPath.GuardNotNullAndEmpty("directory path");
		predicate.GuardNotNull("predicate");
		FileInfo target = new FileInfo(Path.Combine(directoryPath, filename.IfNull(file.Name)));
		if (predicate(file, target))
		{
			file.Refresh();
			target.Refresh();
			file.CopyTo(target, overwrite: true);
		}
		return target;
	}

	/// <summary>
	/// 创建当前文件的可读写流；如果当前文件存在则清空当前文件，如果当前文件不存在则创建新文件。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件的可读写流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static Stream CreateStream(this FileInfo file)
	{
		file.GuardNotNull("file").GuardExistence();
		return file.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.None);
	}

	/// <summary>
	/// 创建当前文件的字符写入流；如果当前文件存在则清空当前文件，如果当前文件不存在则创建新文件。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="encoding">当前文件的字符编码</param>
	/// <returns>当前文件的字符写入流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static StreamWriter CreateWriter(this FileInfo file, Encoding encoding = null)
	{
		file.GuardNotNull("file").GuardExistence();
		encoding = encoding.IfNull(Encoding.UTF8);
		return new StreamWriter(file.Open(FileMode.Create, FileAccess.Write, FileShare.None), encoding);
	}

	/// <summary>
	/// 获取当前文件中程序集的完全名称
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件中程序集的完全名称</returns>
	public static string GetAssemblyFullName(this FileInfo file)
	{
		return file.GetAssemblyName().FullName;
	}

	/// <summary>
	/// 获取当前文件中程序集的名称
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件中程序集的名称</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static AssemblyName GetAssemblyName(this FileInfo file)
	{
		file.GuardNotNull("file").GuardExistence();
		return AssemblyName.GetAssemblyName(file.FullName);
	}

	/// <summary>
	/// 获取当前文件中的程序集的版本号
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件中的程序集的版本号</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static Version GetAssemblyVersion(this FileInfo file)
	{
		file.GuardNotNull("file").GuardExistence();
		return file.GetAssemblyName().Version;
	}

	/// <summary>
	/// 获取当前文件中的程序集的完整版本号
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件中的程序集的完整版本号</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static string GetAssemblyFullVersion(this FileInfo file)
	{
		file.GuardNotNull("file").GuardExistence();
		return file.GetAssemblyVersion().ToString(4);
	}

	/// <summary>
	/// 获取当前文件中的程序集的简短版本号
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件中的程序集的简短版本号</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static string GetAssemblyShortVersion(this FileInfo file)
	{
		file.GuardNotNull("file").GuardExistence();
		return file.GetAssemblyVersion().ToString(2);
	}

	/// <summary>
	/// 获取当前文件所在的驱动器信息
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>文件所在的驱动器信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static DriveInfo GetDriver(this FileInfo file)
	{
		file.GuardNotNull("file");
		return new DriveInfo(file.FullName);
	}

	/// <summary>
	/// 获取当前文件扩展名，不包括句点
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>文件的扩展名，不包括扩展名的分割句点</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static string GetExtension(this FileInfo file)
	{
		file.GuardNotNull("file");
		return file.Extension.TrimStart('.');
	}

	/// <summary>
	/// 获取当前文件的文件名，不包含文件路径
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>文件的名称，不包含文件路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static string GetName(this FileInfo file)
	{
		file.GuardNotNull("file");
		return file.Name;
	}

	/// <summary>
	/// 获取当前文件不包含扩展名的文件名
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>文件的不包含扩展名的文件名</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static string GetNameWithoutExtension(this FileInfo file)
	{
		file.GuardNotNull("file");
		return file.Name.TrimEnd(file.Extension);
	}

	/// <summary>
	/// 获取当前文件的路径
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>文件所在路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static string GetPath(this FileInfo file)
	{
		file.GuardNotNull("file");
		return file.DirectoryName;
	}

	/// <summary>
	/// 获取当前文件所在路径的根路径
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件所在路径的根路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static string GetPathRoot(this FileInfo file)
	{
		file.GuardNotNull("file");
		return Path.GetPathRoot(file.FullName);
	}

	/// <summary>
	/// 获取当前文件全名（包括文件路径和文件名）
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件的全名</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static string GetFullName(this FileInfo file)
	{
		file.GuardNotNull("file");
		return file.FullName;
	}

	/// <summary>
	/// 检测当前文件是否存在，如果不存在则抛出 <see cref="T:System.IO.FileNotFoundException" /> 异常。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="message">错误消息</param>
	/// <returns>如果当前文件存在则返回当前文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static FileInfo GuardExistence(this FileInfo file, string message = null)
	{
		file.GuardNotNull("file");
		file.Guard(file.Exists, () => new FileNotFoundException(message.IfNull(Literals.MSG_FileNotFoundException_1.FormatValue(file.FullName)), file.Name));
		return file;
	}

	/// <summary>
	/// 检测当前文件是否存在，如果不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前文件存在则返回当前文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前文件不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static FileInfo GuardExistence(this FileInfo file, Func<Exception> exceptionCreator)
	{
		file.GuardNotNull("file");
		file.Guard(file.Exists, exceptionCreator);
		return file;
	}

	/// <summary>
	/// 检测当前文件是否存在，如果不存在则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前文件存在则返回当前文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前文件不存在则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static FileInfo GuardExistence(this FileInfo file, Type exceptionType, params object[] args)
	{
		file.GuardNotNull("file");
		file.Guard(file.Exists, exceptionType, args);
		return file;
	}

	/// <summary>
	/// 计算当前文件的哈希值
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="algorithm">使用的哈希值算法，默认为SHA1</param>
	/// <returns>文件的哈希值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static byte[] Hash(this FileInfo file, HashAlgorithm algorithm = null)
	{
		file.GuardNotNull("file").GuardExistence();
		byte[] hashedBytes;
		using (FileStream fs = file.OpenRead())
		{
			hashedBytes = fs.Hash(algorithm);
			fs.Close();
		}
		return hashedBytes;
	}

	/// <summary>
	/// 检测当前文件是否含有扩展名
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>如果文件含有扩展名返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static bool HasExtension(this FileInfo file)
	{
		file.GuardNotNull("file");
		return Path.HasExtension(file.FullName);
	}

	/// <summary>
	/// 加载当前的文件中的程序集
	/// </summary>
	/// <param name="file">加载当前的文件中的程序集</param>
	/// <returns>从当前的文件中加载的程序集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static Assembly LoadAssembly(this FileInfo file)
	{
		file.GuardNotNull("assemblyFile").GuardExistence();
		return Assembly.LoadFrom(file.FullName);
	}

	/// <summary>
	/// 加载当前的文件中的程序集
	/// </summary>
	/// <param name="file">加载当前的文件中的程序集</param>
	/// <returns>从当前的文件中加载的程序集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static Assembly LoadAssemblyFile(this FileInfo file)
	{
		file.GuardNotNull("assemblyFile").GuardExistence();
		return Assembly.LoadFile(file.FullName);
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
	public static void MoveTo(this FileInfo file, FileInfo target, bool overwrite = false)
	{
		file.GuardNotNull("file").GuardExistence();
		target.GuardNotNull("target");
		if (!overwrite && target.Exists)
		{
			throw new IOException(Literals.MSG_FileExistsException_1.FormatValue(target.FullName));
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
	public static FileInfo MoveTo(this FileInfo file, string targetFile, bool overwrite)
	{
		file.GuardNotNull("file").GuardExistence();
		targetFile.GuardNotNullAndEmpty("target");
		FileInfo target = new FileInfo(targetFile);
		file.MoveTo(target, overwrite);
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
	public static FileInfo MoveTo(this FileInfo file, string targetFile, Func<FileInfo, FileInfo, bool> predicate)
	{
		file.GuardNotNull("file").GuardExistence();
		targetFile.GuardNotNullAndEmpty("target file");
		predicate.GuardNotNull("predicate");
		FileInfo target = new FileInfo(targetFile);
		if (predicate(file, target))
		{
			file.Refresh();
			target.Refresh();
			file.MoveTo(target, overwrite: true);
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
	public static FileInfo MoveTo(this FileInfo file, DirectoryInfo directory, bool overwrite = false)
	{
		file.GuardNotNull("file").GuardExistence();
		directory.GuardNotNull("directory");
		FileInfo target = new FileInfo(Path.Combine(directory.FullName, file.Name));
		file.MoveTo(target, overwrite);
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
	public static FileInfo MoveTo(this FileInfo file, DirectoryInfo directory, Func<FileInfo, FileInfo, bool> predicate)
	{
		file.GuardNotNull("file").GuardExistence();
		directory.GuardNotNull("directory");
		predicate.GuardNotNull("predicate");
		FileInfo target = new FileInfo(Path.Combine(directory.FullName, file.Name));
		if (predicate(file, target))
		{
			file.Refresh();
			target.Refresh();
			file.MoveTo(target, overwrite: true);
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
	public static FileInfo MoveTo(this FileInfo file, string directoryPath, string filename, bool overwrite = false)
	{
		file.GuardNotNull("file").GuardExistence();
		directoryPath.GuardNotNullAndEmpty("directory path");
		FileInfo target = new FileInfo(Path.Combine(directoryPath, filename.IfNull(file.Name)));
		file.MoveTo(target, overwrite);
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
	public static FileInfo MoveTo(this FileInfo file, string directoryPath, string filename, Func<FileInfo, FileInfo, bool> predicate)
	{
		file.GuardNotNull("file").GuardExistence();
		directoryPath.GuardNotNullAndEmpty("directory path");
		predicate.GuardNotNull("predicate");
		FileInfo target = new FileInfo(Path.Combine(directoryPath, filename.IfNull(file.Name)));
		if (predicate(file, target))
		{
			file.Refresh();
			target.Refresh();
			file.MoveTo(target, overwrite: true);
		}
		return target;
	}

	/// <summary>
	/// 打开当前文件，并返回指定文本编码的字符读取流
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="encoding">文本字符编码，默认的编码为UTF-8</param>
	/// <returns>文件的字符流读取器</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当期文件不存在。</exception>
	public static StreamReader OpenReader(this FileInfo file, Encoding encoding = null)
	{
		file.GuardNotNull("file").GuardExistence();
		return new StreamReader(file.Open(FileMode.Open, FileAccess.Read, FileShare.None), encoding.IfNull(Encoding.UTF8));
	}

	/// <summary>
	/// 打开当前文件的可读写字节流读取器，流的当前位置默认在文件头部；如果当前文件不存在则创建新文件。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>文件的可读写字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	public static Stream OpenStream(this FileInfo file)
	{
		file.GuardNotNull("file");
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
	public static StreamWriter OpenWriter(this FileInfo file, bool append = false)
	{
		file.GuardNotNull("file");
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
	public static StreamWriter OpenWriter(this FileInfo file, Encoding encoding, bool append = false)
	{
		file.GuardNotNull("file");
		encoding = encoding.IfNull(Encoding.UTF8);
		return new StreamWriter(file.Open(append ? FileMode.Append : FileMode.OpenOrCreate, FileAccess.Write, FileShare.None), encoding);
	}

	/// <summary>
	/// 读取当前文件中的文本
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>从文件中读取的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static string ReadText(this FileInfo file)
	{
		file.GuardNotNull("file").GuardExistence();
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
	public static string ReadText(this FileInfo file, Encoding encoding)
	{
		file.GuardNotNull("file").GuardExistence();
		encoding.GuardNotNull("encoding");
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
	public static string ReadText(this FileInfo file, int start, Encoding encoding = null)
	{
		file.GuardNotNull("file").GuardExistence();
		start.GuardIndexLowBound(0, "start");
		encoding = encoding.IfNull(Encoding.UTF8);
		return file.ReadText(start, int.MaxValue, encoding);
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
	public static string ReadText(this FileInfo file, int start, int count, Encoding encoding = null)
	{
		file.GuardNotNull("file").GuardExistence();
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		encoding = encoding.IfNull(Encoding.UTF8);
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
						buff.AppendValue(chars.Skip(decoded - totalRead).Take(totalRead));
					}
					else
					{
						buff.AppendValue(chars.Take(decoded));
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
	/// 读取当前文件中全部字节数据
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>读取的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static byte[] ReadBytes(this FileInfo file)
	{
		file.GuardNotNull("file").GuardExistence();
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
	public static byte[] ReadBytes(this FileInfo file, long start)
	{
		file.GuardNotNull("file").GuardExistence();
		start.GuardIndexRange(0L, file.Length - 1, "start");
		return file.ReadBytes(start, file.Length - start);
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
	public static byte[] ReadBytes(this FileInfo file, long start, long count)
	{
		file.GuardNotNull("file").GuardExistence();
		start.GuardIndexRange(0L, file.Length - 1, "start");
		count.GuardBetween(0L, file.Length - start, "count");
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
	public static FileInfo Rename(this FileInfo file, string newName, bool overwrite = false)
	{
		file.GuardNotNull("file").GuardExistence();
		newName.GuardNotNull("new name");
		return file.Rename((FileInfo f) => newName, overwrite);
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
	public static FileInfo Rename(this FileInfo file, string text, string replacement, bool overwrite = false)
	{
		file.GuardNotNull("file").GuardExistence();
		text.GuardNotNull("text");
		replacement = replacement.IfNull(string.Empty);
		return file.Rename((FileInfo f) => f.Name.Replace(text, replacement), overwrite);
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
	public static FileInfo Rename(this FileInfo file, Regex pattern, string replacement, bool overwrite = false)
	{
		file.GuardNotNull("file").GuardExistence();
		pattern.GuardNotNull("pattern");
		replacement = replacement.IfNull(string.Empty);
		return file.Rename((FileInfo f) => pattern.Replace(f.Name, replacement), overwrite);
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
	public static FileInfo Rename(this FileInfo file, Func<FileInfo, string> renaming, bool overwrite = false)
	{
		file.GuardNotNull("file").GuardExistence();
		renaming.GuardNotNull("renaming");
		string newName = renaming(file).Guard((string n) => n.IsValidFileName(), "new name");
		FileInfo newFile = new FileInfo(Path.Combine(file.DirectoryName, newName));
		if (newFile.Exists)
		{
			if (!overwrite)
			{
				throw new IOException(Literals.MSG_FileExistsException_1.FormatValue(newFile.FullName));
			}
			newFile.Delete();
		}
		file.MoveTo(newFile.FullName);
		newFile.Refresh();
		return newFile;
	}

	/// <summary>
	/// 设置当前文件的属性
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="attributes">需要设置的文件属性</param>
	/// <param name="append">是否追加到当前文件的属性</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static void SetAttributes(this FileInfo file, FileAttributes attributes, bool append = false)
	{
		file.GuardNotNull("file").GuardExistence();
		File.SetAttributes(file.FullName, append ? attributes.SetFlag(file.Attributes) : attributes);
	}

	/// <summary>
	/// 将文本数据写入当前文件，如果当前文件存在则覆盖
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="text">写入的文本数据</param>
	/// <param name="encoding">写入文本的字符编码，默认为UTF-8</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="text" /> 为空。</exception>
	public static void Write(this FileInfo file, string text, Encoding encoding = null)
	{
		file.Write(encoding.IfNull(Encoding.UTF8).GetBytes(text));
	}

	/// <summary>
	/// 将文本数据写入当前文件
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="text">写入的文本数据</param>
	/// <param name="append">是否追加到当前文件</param>
	/// <param name="encoding">写入文本的字符编码，默认为UTF-8</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="text" /> 为空。</exception>
	public static void Write(this FileInfo file, string text, bool append, Encoding encoding = null)
	{
		file.Write(encoding.IfNull(Encoding.UTF8).GetBytes(text), append);
	}

	/// <summary>
	/// 向当前文件中写入字节数据
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="bytes">写入的字节数组</param>
	/// <param name="append">是否追加到当前文件，默认为false</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者写入的字节数组 <paramref name="bytes" /> 为空。</exception>
	public static void Write(this FileInfo file, byte[] bytes, bool append = false)
	{
		bytes.GuardNotNull("bytes");
		file.Write(bytes, 0, bytes.Length, append);
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
	public static void Write(this FileInfo file, byte[] bytes, int start, int count, bool append = false)
	{
		file.GuardNotNull("file");
		bytes.GuardNotNull("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		count.GuardBetween(0, bytes.Length - start, "count");
		using FileStream fs = file.Open(append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.None);
		fs.WriteBytes(bytes, start, count);
		fs.Close();
	}

	/// <summary>
	/// 将字节流写入到当前文件
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="stream">写入的字节流</param>
	/// <param name="append">是否追加到当前文件，默认为false</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="stream" /> 为空。</exception>
	public static void Write(this FileInfo file, Stream stream, bool append = false)
	{
		file.GuardNotNull("file");
		stream.GuardNotNull("stream");
		using FileStream fs = file.Open(append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.None);
		stream.CopyTo(fs);
		fs.Close();
	}
}
