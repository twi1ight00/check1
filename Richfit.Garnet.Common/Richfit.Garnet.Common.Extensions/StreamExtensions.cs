using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using Richfit.Garnet.Common.IO;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Utility;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.IO.Stream" /> 扩展方法类
/// </summary>
public static class StreamExtensions
{
	/// <summary>
	/// 将当前流从当前位置开始复制到缓存数组
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <returns>复制的缓存数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取。</exception>
	public static byte[] CopyToArray(this Stream stream)
	{
		return stream.ReadBytes();
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
	public static byte[] CopyToArray(this Stream stream, long count)
	{
		return stream.ReadBytes(count);
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
	public static byte[] CopyToArray(this Stream stream, long start, long count)
	{
		return stream.ReadBytes(start, count);
	}

	/// <summary>
	/// 将当前字节流从当前位置开始复制到字节列表
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <returns>复制的字节列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取。</exception>
	public static List<byte> CopyToList(this Stream stream)
	{
		return new List<byte>(stream.ReadBytes());
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
	public static List<byte> CopyToList(this Stream stream, long count)
	{
		return new List<byte>(stream.ReadBytes(count));
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
	public static List<byte> CopyToList(this Stream stream, long start, long count)
	{
		return new List<byte>(stream.ReadBytes(start, count));
	}

	/// <summary>
	/// 将当前字节流中的当前位置开始复制字节到目标字节流中
	/// </summary>
	/// <param name="source">当前字节流</param>
	/// <param name="target">目标流</param>
	/// <returns>已经复制的字节数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者目标流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取；或者目标流不支持写入。</exception>
	public static long CopyToStream(this Stream source, Stream target)
	{
		source.GuardNotNull("source stream");
		target.GuardNotNull("target stream");
		source.Guard(source.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		target.Guard(source.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
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
	public static long CopyToStream(this Stream source, Stream target, long count)
	{
		source.GuardNotNull("source stream");
		target.GuardNotNull("target stream");
		source.Guard(source.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		target.Guard(source.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
		count.GuardGreaterThanOrEqualTo(0L, "count");
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
	public static long CopyToStream(this Stream source, Stream target, long targetStart, long count)
	{
		source.GuardNotNull("source stream");
		target.GuardNotNull("target stream");
		source.Guard(source.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		target.Guard(source.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
		targetStart.GuardIndexLowBound(0L, "target start");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		target.Skip(targetStart);
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
	public static long CopyToStream(this Stream source, long sourceStart, Stream target)
	{
		source.GuardNotNull("source stream");
		target.GuardNotNull("target stream");
		source.Guard(source.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		target.Guard(source.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
		sourceStart.GuardIndexLowBound(0L, "source start");
		source.Skip(sourceStart);
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
	public static long CopyToStream(this Stream source, long sourceStart, Stream target, long count)
	{
		source.GuardNotNull("source stream");
		target.GuardNotNull("target stream");
		source.Guard(source.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		target.Guard(source.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
		sourceStart.GuardIndexLowBound(0L, "source start");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		source.Skip(sourceStart);
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
	public static long CopyToStream(this Stream source, long sourceStart, Stream target, long targetStart, long count)
	{
		source.GuardNotNull("source stream");
		target.GuardNotNull("target stream");
		source.Guard(source.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		target.Guard(source.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
		sourceStart.GuardIndexLowBound(0L, "source start");
		targetStart.GuardIndexLowBound(0L, "target start");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		source.Skip(sourceStart);
		target.Skip(targetStart);
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
	public static MemoryStream CopyToMemory(this Stream stream)
	{
		stream.GuardNotNull("stream");
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
	public static MemoryStream CopyToMemory(this Stream stream, long count)
	{
		stream.GuardNotNull("stream");
		stream.Guard(stream.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		count.GuardGreaterThanOrEqualTo(0L, "count");
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
	public static MemoryStream CopyToMemory(this Stream stream, long start, long count)
	{
		stream.GuardNotNull("stream");
		stream.Guard(stream.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		start.GuardIndexLowBound(0L, "start");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		stream.Skip(start);
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
	public static T CreateCompressStream<T>(this Stream stream) where T : Stream
	{
		stream.GuardNotNull("stream");
		if (typeof(T).ReferenceEquals(typeof(DeflateStream)))
		{
			return new DeflateStream(stream, CompressionMode.Compress, leaveOpen: true) as T;
		}
		if (typeof(T).ReferenceEquals(typeof(GZipStream)))
		{
			return new GZipStream(stream, CompressionMode.Compress, leaveOpen: true) as T;
		}
		throw new NotSupportedException(Literals.MSG_CompressionTypeNotSupported_1.FormatValue(typeof(T).FullName));
	}

	/// <summary>
	/// 创建当前字节流的压缩流
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="type">压缩流类型</param>
	/// <returns>以当前字节流为基础的压缩流。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static Stream CreateCompressStream(this Stream stream, CompressionType type)
	{
		stream.GuardNotNull("stream");
		return type switch
		{
			CompressionType.Deflate => new DeflateStream(stream, CompressionMode.Compress, leaveOpen: true), 
			CompressionType.GZip => new GZipStream(stream, CompressionMode.Compress, leaveOpen: true), 
			_ => throw new NotSupportedException(Literals.MSG_CompressionTypeNotSupported_1.FormatValue(type.ToString())), 
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
	public static T CreateDecompressStream<T>(this Stream stream) where T : Stream
	{
		stream.GuardNotNull("stream");
		if (typeof(T).ReferenceEquals(typeof(DeflateStream)))
		{
			return new DeflateStream(stream, CompressionMode.Decompress, leaveOpen: true) as T;
		}
		if (typeof(T).ReferenceEquals(typeof(GZipStream)))
		{
			return new GZipStream(stream, CompressionMode.Decompress, leaveOpen: true) as T;
		}
		throw new NotSupportedException(Literals.MSG_CompressionTypeNotSupported_1.FormatValue(typeof(T).FullName));
	}

	/// <summary>
	/// 创建当前字节流的解压缩流
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="type">解压缩流类型</param>
	/// <returns>以当前字节流为基础建立的解压缩流，如果不支持指定的解压缩流类型则返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static Stream CreateDecompressStream(this Stream stream, CompressionType type)
	{
		stream.GuardNotNull("stream");
		return type switch
		{
			CompressionType.Deflate => stream.CreateDecompressStream<DeflateStream>(), 
			CompressionType.GZip => stream.CreateDecompressStream<GZipStream>(), 
			_ => throw new NotSupportedException(Literals.MSG_CompressionTypeNotSupported_1.FormatValue(type.ToString())), 
		};
	}

	/// <summary>
	/// 创建当前字节流的指定字符编码的文本读取流
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="encoding">文本字符编码，默认为UTF-8编码</param>
	/// <returns>基于当前字节流的文本读取流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	public static StreamReader CreateReader(this Stream stream, Encoding encoding = null)
	{
		stream.GuardNotNull("stream");
		return new StreamReader(stream, encoding.IfNull(Encoding.UTF8));
	}

	/// <summary>
	/// 创建当前字节流的指定字符编码的文本写入流
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="encoding">文本字符编码，默认为UTF-8编码</param>
	/// <returns>基于当前字节流的文本写入流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	public static StreamWriter CreateWriter(this Stream stream, Encoding encoding = null)
	{
		stream.GuardNotNull("stream");
		return new StreamWriter(stream, encoding.IfNull(Encoding.UTF8));
	}

	/// <summary>
	/// 计算当前字节流的哈希值
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="algorithm">计算哈希值的哈希算法，默认为SHA1</param>
	/// <returns>计算出的哈希值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	public static byte[] Hash(this Stream stream, HashAlgorithm algorithm = null)
	{
		stream.GuardNotNull("stream");
		byte[] hashedBytes;
		using (HashAlgorithm hasher = algorithm.IfNull(new SHA1CryptoServiceProvider()))
		{
			hashedBytes = hasher.ComputeHash(stream);
			hasher.Clear();
		}
		return hashedBytes;
	}

	/// <summary>
	/// 读取当前字节流中所有的字节（从字节流的起始位置不是当前位置，到流的结束之间所有的字节）
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <returns>当前流中的所有字节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	public static byte[] ReadAllBytes(this Stream stream)
	{
		return stream.ReadBytes();
	}

	/// <summary>
	/// 读取当前字节流中所有的字节（从字节流的起始位置不是当前位置，到流的结束之间所有的字节），并按 <paramref name="encoding" /> 解码为文本。
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="encoding">文本编码，默认为UTF-8</param>
	/// <returns>解码后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	public static string ReadAllText(this Stream stream, Encoding encoding = null)
	{
		return stream.ReadAllBytes().TextDecode(encoding);
	}

	/// <summary>
	/// 读取当前字节流从当前位置开始的字节
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <returns>读取的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持读取。</exception>
	public static byte[] ReadBytes(this Stream stream)
	{
		stream.GuardNotNull("stream");
		stream.Guard(stream.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
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
	public static byte[] ReadBytes(this Stream stream, long count)
	{
		stream.GuardNotNull("stream");
		stream.Guard(stream.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		count.GuardGreaterThanOrEqualTo(0L, "count");
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
	public static byte[] ReadBytes(this Stream stream, long start, long count)
	{
		stream.GuardNotNull("stream");
		stream.Guard(stream.CanRead, () => new NotSupportedException(Literals.MSG_StreamNotSupportRead));
		start.GuardIndexLowBound(0L, "start");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		byte[] bytes = null;
		stream.Skip(start);
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
	public static string ReadText(this Stream stream, Encoding encoding = null)
	{
		return stream.ReadBytes().TextDecode(encoding);
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
	public static string ReadText(this Stream stream, long count, Encoding encoding = null)
	{
		return stream.ReadBytes(count).TextDecode(encoding);
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
	public static string ReadText(this Stream stream, long start, long count, Encoding encoding = null)
	{
		return stream.ReadBytes(start, count).TextDecode(encoding);
	}

	/// <summary>
	/// 将当前字节流的当前位置定位到流的起始位置
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <returns>重新等位后的流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持搜索。</exception>
	public static Stream SeekToBegin(this Stream stream)
	{
		stream.GuardNotNull("stream");
		stream.Guard(stream.CanSeek, () => new NotSupportedException(Literals.MSG_StreamNotSupportSeek));
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
	public static Stream SeekToEnd(this Stream stream)
	{
		stream.GuardNotNull("stream");
		stream.Guard(stream.CanSeek, () => new NotSupportedException(Literals.MSG_StreamNotSupportSeek));
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
	public static void Skip(this Stream stream, long count)
	{
		stream.GuardNotNull("stream");
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
	/// 向当前字节流中写入字节数据
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="data">待写入的字节数组</param>
	/// <returns>写入后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者写入的字节数组 <paramref name="data" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持写入。</exception>
	public static Stream WriteBytes(this Stream stream, params byte[] data)
	{
		data.GuardNotNull("data");
		return stream.WriteBytes(0L, data, 0L, data.LongLength);
	}

	/// <summary>
	/// 向当前字节流中写入字节数据
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="data">写入的字节序列</param>
	/// <returns>写入后的字节流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者写入的字节数据 <paramref name="data" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前字节流不支持写入。</exception>
	public static Stream WriteBytes(this Stream stream, IEnumerable<byte> data)
	{
		return stream.WriteBytes(0L, data);
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
	public static Stream WriteBytes(this Stream stream, byte[] data, long start, long count)
	{
		return stream.WriteBytes(0L, data, start, count);
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
	public static Stream WriteBytes(this Stream stream, long position, params byte[] data)
	{
		data.GuardNotNull("data");
		return stream.WriteBytes(position, data, 0L, data.LongLength);
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
	public static Stream WriteBytes(this Stream stream, long position, IEnumerable<byte> data)
	{
		stream.GuardNotNull("stream");
		stream.Guard(stream.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
		position.GuardIndexLowBound(0L, "position");
		data.GuardNotNull("data");
		stream.Skip(position);
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
	public static Stream WriteBytes(this Stream stream, long position, byte[] data, long start, long count)
	{
		stream.GuardNotNull("stream");
		stream.Guard(stream.CanWrite, () => new NotSupportedException(Literals.MSG_StreamNotSupportWrite));
		position.GuardIndexLowBound(0L, "position");
		data.GuardNotNull("data");
		start.GuardIndexRange(0L, data.LongLength - 1, "start");
		count.GuardBetween(0L, data.LongLength - start, "count");
		stream.Skip(position);
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

	/// <summary>
	/// 将当前字节流中的数据保存到文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="file">保存的目标文件</param>
	/// <param name="overwrite">如果目标文件存在，是否覆盖目标文件。等于true，覆盖目标文件；等于false，追加到目标文件。</param>
	/// <returns>保存数据后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者保存的目标文件 <paramref name="file" /> 为空。</exception>
	public static FileInfo SaveFile(this Stream stream, string file, bool overwrite = true)
	{
		file.GuardNotNull("target file");
		return stream.SaveFile(file.ToFileInfo(), overwrite);
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
	public static FileInfo SaveFile(this Stream stream, long count, string file, bool overwrite = true)
	{
		file.GuardNotNull("target file");
		return stream.SaveFile(count, file.ToFileInfo(), overwrite);
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
	public static FileInfo SaveFile(this Stream stream, long start, long count, string file, bool overwrite = true)
	{
		file.GuardNotNull("target file");
		return stream.SaveFile(start, count, file.ToFileInfo(), overwrite);
	}

	/// <summary>
	/// 将当前字节流中的数据保存到文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="file">保存的目标文件</param>
	/// <param name="overwrite">如果目标文件存在，是否覆盖目标文件。等于true，覆盖目标文件；等于false，追加到目标文件。</param>
	/// <returns>保存数据后的目标文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者保存的目标文件 <paramref name="file" /> 为空。</exception>
	public static FileInfo SaveFile(this Stream stream, FileInfo file, bool overwrite = true)
	{
		stream.GuardNotNull("stream");
		file.GuardNotNull("target file");
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
	public static FileInfo SaveFile(this Stream stream, long count, FileInfo file, bool overwrite = true)
	{
		stream.GuardNotNull("stream");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		file.GuardNotNull("target file");
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
	public static FileInfo SaveFile(this Stream stream, long start, long count, FileInfo file, bool overwrite = true)
	{
		stream.GuardNotNull("stream");
		start.GuardIndexLowBound(0L, "start");
		stream.Skip(start);
		return stream.SaveFile(count, file, overwrite);
	}

	/// <summary>
	/// 将当前字节流中的数据保存到临时文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="tempPath">保存的临时文件的位置</param>
	/// <returns>保存后的临时文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="tempPath" /> 指定的路径不存在，且无法创建。</exception>
	public static FileInfo SaveTempFile(this Stream stream, string tempPath = null)
	{
		stream.GuardNotNull("stream");
		return stream.SaveFile(IOHelper.CreateTempFile(tempPath), overwrite: false);
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
	public static FileInfo SaveTempFile(this Stream stream, long count, string tempPath = null)
	{
		stream.GuardNotNull("stream");
		return stream.SaveFile(count, IOHelper.CreateTempFile(tempPath), overwrite: false);
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
	public static FileInfo SaveTempFile(this Stream stream, long start, long count, string tempPath = null)
	{
		stream.GuardNotNull("stream");
		return stream.SaveFile(start, count, IOHelper.CreateTempFile(tempPath), overwrite: false);
	}

	/// <summary>
	/// 将当前字节流中的数据保存到临时文件
	/// </summary>
	/// <param name="stream">当前字节流</param>
	/// <param name="tempPath">保存的临时文件的位置</param>
	/// <returns>保存后的临时文件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节流为空；或者临时文件保存位置 <paramref name="tempPath" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="tempPath" /> 指定的路径不存在，且无法创建。</exception>
	public static FileInfo SaveTempFile(this Stream stream, DirectoryInfo tempPath)
	{
		stream.GuardNotNull("stream");
		tempPath.GuardNotNull("temp file location");
		return stream.SaveFile(IOHelper.CreateTempFile(tempPath), overwrite: false);
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
	public static FileInfo SaveTempFile(this Stream stream, long count, DirectoryInfo tempPath)
	{
		stream.GuardNotNull("stream");
		tempPath.GuardNotNull("temp file location");
		return stream.SaveFile(count, IOHelper.CreateTempFile(tempPath), overwrite: false);
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
	public static FileInfo SaveTempFile(this Stream stream, long start, long count, DirectoryInfo tempPath)
	{
		stream.GuardNotNull("stream");
		tempPath.GuardNotNull("temp file location");
		return stream.SaveFile(start, count, IOHelper.CreateTempFile(tempPath), overwrite: false);
	}
}
