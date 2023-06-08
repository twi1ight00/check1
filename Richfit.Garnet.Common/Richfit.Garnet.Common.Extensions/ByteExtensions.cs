using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using Richfit.Garnet.Common.IO;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Utility;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Byte" /> 数组扩展方法类
///
/// 包括：
/// 1.Byte类型的扩展方法
/// 2.Byte类型数组或者泛型数组的扩展方法
/// </summary>
public static class ByteExtensions
{
	/// <summary>
	/// 使用Ascii编码对当前字节数据进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string AsciiDecode(this byte[] bytes)
	{
		return bytes.TextDecode(Encoding.ASCII);
	}

	/// <summary>
	/// 使用Ascii编码对当前字节数据进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的字节索引位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从开始转换位置 <paramref name="start" /> 起剩余的字节数量。</exception>
	public static string AsciiDecode(this byte[] bytes, int start, int count)
	{
		return bytes.TextDecode(start, count, Encoding.ASCII);
	}

	/// <summary>
	/// 使用Ascii编码对当前字节序列进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static string AsciiDecode(this IEnumerable<byte> bytes)
	{
		return bytes.TextDecode(Encoding.ASCII);
	}

	/// <summary>
	/// 将当前字节数组转换Base64编码的字符串
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="options">转换参数</param>
	/// <returns>字节数组的Base64编码字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <seealso cref="M:System.Convert.ToBase64String(System.Byte[])" />
	public static string Base64Encode(this byte[] bytes, Base64FormattingOptions options = Base64FormattingOptions.None)
	{
		bytes.GuardNotNull("bytes");
		return Convert.ToBase64String(bytes, options);
	}

	/// <summary>
	/// 将当前字节数组转换Base64编码的字符串
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <param name="options">转换参数</param>
	/// <returns>字节数组的Base64编码字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的字节数。</exception>
	/// <seealso cref="M:System.Convert.ToBase64String(System.Byte[],System.Int32,System.Int32,System.Base64FormattingOptions)" />
	public static string Base64Encode(this byte[] bytes, int start, int count, Base64FormattingOptions options = Base64FormattingOptions.None)
	{
		bytes.GuardNotNull("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		count.GuardBetween(0, bytes.Length - start, "count");
		return Convert.ToBase64String(bytes, start, count, options);
	}

	/// <summary>
	/// 将当前字节序列转换Base64编码的字符串
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="options">转换参数</param>
	/// <returns>字节序列的Base64编码字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	/// <seealso cref="M:System.Convert.ToBase64String(System.Byte[])" />
	public static string Base64Encode(this IEnumerable<byte> bytes, Base64FormattingOptions options = Base64FormattingOptions.None)
	{
		bytes.GuardNotNull("bytes");
		return bytes.ToArray().Base64Encode();
	}

	/// <summary>
	/// 将当前字节数组反序列化为对象
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <remarks>当前字节数组应是由二进制序列化生成的。</remarks>
	/// <seealso cref="M:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(System.IO.Stream)" />
	public static object BinaryDeserialize(this byte[] bytes)
	{
		bytes.GuardNotNull("bytes");
		using MemoryStream stream = new MemoryStream(bytes);
		BinaryFormatter formatter = new BinaryFormatter();
		return formatter.Deserialize(stream);
	}

	/// <summary>
	/// 将当前字节数组反序列化为对象
	/// </summary>
	/// <typeparam name="T">反序列化的目标对象类型</typeparam>
	/// <param name="bytes">当前字节数组</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <remarks>当前字节数组应是由二进制序列化生成的。</remarks>
	/// <seealso cref="M:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(System.IO.Stream)" />
	public static T BinaryDeserialize<T>(this byte[] bytes)
	{
		return bytes.BinaryDeserialize().As<T>();
	}

	/// <summary>
	/// 将当前字节序列反序列化为对象
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	/// <remarks>当前字节数组应是由二进制序列化生成的。</remarks>
	/// <seealso cref="M:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(System.IO.Stream)" />
	public static object BinaryDeserialize(this IEnumerable<byte> bytes)
	{
		bytes.GuardNotNull("bytes");
		using MemoryStream stream = new MemoryStream(1024);
		foreach (byte b in bytes)
		{
			stream.WriteByte(b);
		}
		stream.Position = 0L;
		BinaryFormatter formatter = new BinaryFormatter();
		return formatter.Deserialize(stream);
	}

	/// <summary>
	/// 将当前字节序列反序列化为对象
	/// </summary>
	/// <typeparam name="T">反序列化的目标对象类型</typeparam>
	/// <param name="bytes">当前字节序列</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	/// <remarks>当前字节数组应是由二进制序列化生成的。</remarks>
	/// <seealso cref="M:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(System.IO.Stream)" />
	public static T BinaryDeserialize<T>(this IEnumerable<byte> bytes)
	{
		return bytes.BinaryDeserialize().As<T>();
	}

	/// <summary>
	/// 将当前字节数组按 <paramref name="encoding" /> 指定编码解码为字符数组
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="encoding">转换使用的字符编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>解码生成的字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static char[] CharDecode(this byte[] bytes, Encoding encoding = null)
	{
		bytes.GuardNotNull("bytes");
		return encoding.IfNull(Encoding.UTF8).GetChars(bytes);
	}

	/// <summary>
	/// 将当前字节数组按 <paramref name="encoding" /> 指定编码解码为字符数组
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的字节索引位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <param name="encoding">转换使用的字符编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>解码生成的字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	public static char[] CharDecode(this byte[] bytes, int start, int count, Encoding encoding = null)
	{
		bytes.GuardNotNull("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		count.GuardBetween(0, bytes.Length - start, "count");
		return encoding.IfNull(Encoding.UTF8).GetChars(bytes, start, count);
	}

	/// <summary>
	/// 将当前字节序列按 <paramref name="encoding" /> 指定编码解码为字符数组
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="encoding">转换使用的字符编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>解码生成的字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static char[] CharDecode(this IEnumerable<byte> bytes, Encoding encoding = null)
	{
		bytes.GuardNotNull("bytes");
		encoding = encoding.IfNull(Encoding.UTF8);
		Decoder decoder = encoding.GetDecoder();
		List<char> result = new List<char>();
		byte[] buff = new byte[1024];
		char[] chars = new char[1024];
		int index = 0;
		int charCount = 0;
		foreach (byte b in bytes)
		{
			buff[index++] = b;
			if (index >= buff.Length)
			{
				charCount = decoder.GetChars(buff, 0, buff.Length, chars, 0);
				result.AddRange(chars.Take(charCount));
				index = 0;
			}
		}
		if (index > 0)
		{
			charCount = decoder.GetChars(buff, 0, index, chars, 0, flush: true);
			result.AddRange(chars.Take(charCount));
		}
		return chars.ToArray();
	}

	/// <summary>
	/// 将当前字节数组从一种字符编码转换为另一种字符编码
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="from">字节数组使用的源编码,默认为ASCII</param>
	/// <param name="to">字节数组转换的目标编码,默认为UTF-8</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组空；或者源编码 <paramref name="from" /> 为空；或者目标编码 <paramref name="to" /> 为空。</exception>
	public static byte[] ChangeEncoding(this byte[] bytes, Encoding from, Encoding to)
	{
		bytes.GuardNotNull("bytes");
		from.GuardNotNull("from");
		to.GuardNotNull("to");
		return Encoding.Convert(from, to, bytes);
	}

	/// <summary>
	/// 压缩当前字节数据
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="type">压缩算法类型，默认为 <see cref="F:Richfit.Garnet.Common.IO.CompressionType.Deflate" /></param>
	/// <returns>返回压缩后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static byte[] Compress(this byte[] data, CompressionType type = CompressionType.Deflate)
	{
		data.GuardNotNull("data");
		return data.Compress(0, data.Length, type);
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
	public static byte[] Compress(this byte[] data, int start, int count, CompressionType type = CompressionType.Deflate)
	{
		data.GuardNotNull("data");
		start.GuardIndexRange(0, data.Length - 1, "start");
		count.GuardBetween(0, data.Length - start, "count");
		using MemoryStream ms = new MemoryStream(1024);
		using Stream cs = ms.CreateCompressStream(type);
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
	public static byte[] Compress(this IEnumerable<byte> data, CompressionType type = CompressionType.Deflate)
	{
		data.GuardNotNull("data");
		using MemoryStream ms = new MemoryStream(1024);
		using Stream cs = ms.CreateCompressStream(type);
		foreach (byte b in data)
		{
			cs.WriteByte(b);
		}
		cs.Close();
		ms.Close();
		return ms.ToArray();
	}

	/// <summary>
	/// 根据当前字节数据创建流对象
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <returns>新的流对象，流内数据为当前字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <remarks>本方法创建新的流对象，当前的字节数据被复制到新的流内，流的当前位置为流的开头。本方法的调用者应负责关闭创建的流对象。</remarks>
	public static Stream CreateStream(this byte[] data)
	{
		data.GuardNotNull("data");
		return data.CreateStream(0, data.Length);
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
	public static Stream CreateStream(this byte[] data, int start, int count)
	{
		data.GuardNotNull("data");
		start.GuardIndexRange(0, data.Length - 1, "start");
		count.GuardBetween(0, data.Length - start, "count");
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
	public static Stream CreateStream(this IEnumerable<byte> data)
	{
		data.GuardNotNull("data");
		MemoryStream stream = new MemoryStream(1024);
		foreach (byte b in data)
		{
			stream.WriteByte(b);
		}
		stream.Position = 0L;
		return stream;
	}

	/// <summary>
	/// 对当前字节数据进行解压缩
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="type">压缩算法类型，默认为 <see cref="F:Richfit.Garnet.Common.IO.CompressionType.Deflate" /></param>
	/// <returns>返回解压缩的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前指定的压缩流类型不受支持。</exception>
	public static byte[] Decompress(this byte[] data, CompressionType type = CompressionType.Deflate)
	{
		data.GuardNotNull("data");
		return data.Decompress(0, data.Length, type);
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
	public static byte[] Decompress(this byte[] data, int start, int count, CompressionType type = CompressionType.Deflate)
	{
		data.GuardNotNull("data");
		start.GuardIndexRange(0, data.Length - 1, "start");
		count.GuardBetween(0, data.Length - start, "count");
		using MemoryStream ms = new MemoryStream((int)((double)count * 1.5));
		using MemoryStream cs = new MemoryStream(count);
		cs.Write(data, start, count);
		cs.Position = 0L;
		using Stream ds = cs.CreateDecompressStream(type);
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
	public static byte[] Decompress(this IEnumerable<byte> data, CompressionType type = CompressionType.Deflate)
	{
		data.GuardNotNull("data");
		using MemoryStream ms = new MemoryStream(1024);
		using MemoryStream cs = new MemoryStream(1024);
		foreach (byte b in data)
		{
			cs.WriteByte(b);
		}
		cs.Position = 0L;
		using Stream ds = cs.CreateDecompressStream(type);
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
	public static string DecompressText(this byte[] data, Encoding encoding = null, CompressionType type = CompressionType.Deflate)
	{
		return data.Decompress(type).TextDecode(encoding.IfNull(Encoding.UTF8));
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
	public static string DecompressText(this IEnumerable<byte> data, Encoding encoding = null, CompressionType type = CompressionType.Deflate)
	{
		return data.Decompress(type).TextDecode(encoding.IfNull(Encoding.UTF8));
	}

	/// <summary>
	/// 将当前字节数组反序列化为 <see cref="T:System.DateTime" /> 类型
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>反序列化后生成的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static DateTime DeserializeDateTime(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNull("bytes");
		return DateTime.FromBinary(bytes.GetInt64(start));
	}

	/// <summary>
	/// 将当前字节数组反序列化为 <see cref="T:System.DateTimeOffset" /> 类型
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>反序列化后生成的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static DateTimeOffset DeserializeDateTimeOffset(this byte[] bytes, int start = 0)
	{
		DateTime dateTime = bytes.GetRawDateTime(start);
		TimeSpan timeSpan = bytes.GetRawTimeSpan(start);
		return new DateTimeOffset(dateTime, timeSpan);
	}

	/// <summary>
	/// 向当前数组中填充空值（\0）
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] FillNull(this byte[] array)
	{
		array.GuardNotNull("array");
		return array.Fill((byte)0);
	}

	/// <summary>
	/// 使用936代码页(GB2312)编码把当前字节数据解码为字符串
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string GB2312Decode(this byte[] data)
	{
		return data.TextDecode(Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 使用936代码页(GB2312)编码把当前字节数据解码为字符串
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="start">开始转换的字节索引位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	public static string GB2312Decode(this byte[] data, int start, int count)
	{
		return data.TextDecode(start, count, Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 使用936代码页(GB2312)编码把当前字节序列解码为字符串
	/// </summary>
	/// <param name="data">当前字节序列</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static string GB2312Decode(this IEnumerable<byte> data)
	{
		return data.TextDecode(Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Numerics.BigInteger" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	public static BigInteger GetBigInteger(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = bytes;
		if (start > 0)
		{
			buff = new byte[bytes.Length - start];
			Array.Copy(bytes, start, buff, 0, buff.Length);
		}
		return new BigInteger(buff);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Numerics.BigInteger" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列元素索引有效范围。</exception>
	public static BigInteger GetBigInteger(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return new BigInteger(bytes.Skip(start).ToArray());
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Boolean" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToBoolean(System.Byte[],System.Int32)" />
	public static bool GetBoolean(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = bytes;
		if (start > 0)
		{
			buff = new byte[1];
			Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		}
		return BitConverter.ToBoolean(buff, 0);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Boolean" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列元素索引有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToBoolean(System.Byte[],System.Int32)" />
	public static bool GetBoolean(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(1).ToArray()
			.GetBoolean();
	}

	/// <summary>
	/// 获取当前字节数组中指定位置的 <see cref="T:System.Byte" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">获取的字节的起始位置</param>
	/// <returns>获取的字节值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>本方法返回当前字节数组中指定索引位置的字节数据。</remarks>
	public static byte GetByte(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		return bytes[start];
	}

	/// <summary>
	/// 获取当前字节序列中指定位置的 <see cref="T:System.Byte" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">获取的字节的起始位置</param>
	/// <returns>获取的字节值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列元素索引有效范围。</exception>
	/// <remarks>本方法返回当前字节序列中指定索引位置的字节数据。</remarks>
	public static byte GetByte(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		IEnumerable<byte> sub = bytes.Skip(start);
		if (sub.Any())
		{
			return sub.First();
		}
		throw new IndexOutOfRangeException(Literals.MSG_IndexOutOfRange_1.FormatValue("start"));
	}

	/// <summary>
	/// 获取当前字节的字节数组
	/// </summary>
	/// <param name="b">当前字节</param>
	/// <returns>以当前字节作为元素的字节数组</returns>
	public static byte[] GetBytes(this byte b)
	{
		return new byte[1] { b };
	}

	/// <summary>
	/// 获取当前字节数组的指定部分的子数组
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">子数组的起始索引</param>
	/// <param name="count">子数组的元素数量</param>
	/// <returns>获取的子字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(this byte[] bytes, int start, int count)
	{
		bytes.GuardNotNull("values");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		count.GuardBetween(0, bytes.Length - start, "count");
		byte[] buff = new byte[count];
		Array.Copy(bytes, start, buff, 0, count);
		return buff;
	}

	/// <summary>
	/// 获取当前字节序列的指定部分的子数组
	/// </summary>
	/// <param name="bytes">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(this IEnumerable<byte> bytes)
	{
		bytes.GuardNotNull("bytes");
		return bytes.ToArray();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Char" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToChar(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Char" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	/// <seealso cref="M:System.BitConverter.ToChar(System.Byte[],System.Int32)" />
	public static char GetChar(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[2];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		return BitConverter.ToChar(buff, 0);
	}

	/// <summary>
	/// 将当前字节序列中指定位置开始的数个字节转换为 <see cref="T:System.Char" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToChar(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Char" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	/// <seealso cref="M:System.BitConverter.ToChar(System.Byte[],System.Int32)" />
	public static char GetChar(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(2).ToArray()
			.GetChar();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.DateTime" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法先调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 将字节数组还原为 <see cref="T:System.Int64" /> 型整数，再调用 <see cref="M:System.DateTime.#ctor(System.Int64)" /> 构造函数转换为 <see cref="T:System.DateTime" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static DateTime GetDateTime(this byte[] bytes, int start = 0)
	{
		return new DateTime(bytes.GetInt64(start));
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.DateTime" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法先调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 将字节数组还原为 <see cref="T:System.Int64" /> 型整数，再调用 <see cref="M:System.DateTime.#ctor(System.Int64)" /> 构造函数转换为 <see cref="T:System.DateTime" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static DateTime GetDateTime(this IEnumerable<byte> bytes, int start = 0)
	{
		return bytes.Skip(start).Take(8).ToArray()
			.GetDateTime();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.DateTimeOffset" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	public static DateTimeOffset GetDateTimeOffset(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		DateTime dateTime = bytes.GetDateTime(start);
		TimeSpan offset = TimeSpan.Zero;
		if (bytes.Length > start + 8)
		{
			offset = bytes.GetTimeSpan(start + 8);
		}
		return new DateTimeOffset(dateTime, offset);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.DateTimeOffset" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	public static DateTimeOffset GetDateTimeOffset(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(16).ToArray()
			.GetDateTimeOffset();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Decimal" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法先调用 <see cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" /> 将字节数组还原为4个 <see cref="T:System.Int32" /> 型整数，再调用 <see cref="M:System.Decimal.#ctor(System.Int32[])" /> 构造函数生成 <see cref="T:System.Decimal" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是4个 <see cref="T:System.Int32" /> 型数据占用字节数量（16）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static decimal GetDecimal(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		int[] bits = new int[4];
		for (int i = 0; i < bits.Length; i++)
		{
			bits[i] = ((bytes.Length > start + 4 * i) ? bytes.GetInt32(start + 4 * i) : 0);
		}
		return new decimal(bits);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Decimal" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法先调用 <see cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" /> 将字节数组还原为4个 <see cref="T:System.Int32" /> 型整数，再调用 <see cref="M:System.Decimal.#ctor(System.Int32[])" /> 构造函数生成 <see cref="T:System.Decimal" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是4个 <see cref="T:System.Int32" /> 型数据占用字节数量（16）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static decimal GetDecimal(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(16).ToArray()
			.GetDecimal();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Double" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToDouble(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Double" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static double GetDouble(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[8];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		return BitConverter.ToDouble(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Double" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToDouble(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Double" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static double GetDouble(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(8).ToArray()
			.GetDouble();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Single" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static float GetFloat(this byte[] bytes, int start = 0)
	{
		return bytes.GetSingle(start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.Single" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static float GetFloat(this IEnumerable<byte> bytes, int start = 0)
	{
		return bytes.GetSingle(start);
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Guid" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.Guid.#ctor(System.Byte[])" /> 构造函数创建 <see cref="T:System.Guid" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Guid" /> 型数据占用字节数量（16）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static Guid GetGuid(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[16];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		return new Guid(bytes);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Guid" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.Guid.#ctor(System.Byte[])" /> 构造函数创建 <see cref="T:System.Guid" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Guid" /> 型数据占用字节数量（16）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static Guid GetGuid(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(16).ToArray()
			.GetGuid();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Int16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt16(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int16" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static short GetInt16(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[2];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		return BitConverter.ToInt16(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Int16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt16(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.Int16" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static short GetInt16(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(2).ToArray()
			.GetInt16();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Int32" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int32" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static int GetInt32(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[4];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		return BitConverter.ToInt32(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Int32" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" /> 方法还原当前字节序列。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.Int32" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static int GetInt32(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(4).ToArray()
			.GetInt32();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Int64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static long GetInt64(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[8];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		return BitConverter.ToInt64(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Int64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static long GetInt64(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(8).ToArray()
			.GetInt64();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.IntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法根据 <see cref="P:System.IntPtr.Size" /> 的指示，分别调用 <see cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" /> 或者 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />，并将方法结果转换为 <see cref="T:System.IntPtr" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.IntPtr" /> 型数据占用字节数量（4或者8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static IntPtr GetIntPtr(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		return IntPtr.Size switch
		{
			4 => (IntPtr)bytes.GetInt32(start), 
			8 => (IntPtr)bytes.GetInt64(start), 
			_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
		};
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.IntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法根据 <see cref="P:System.IntPtr.Size" /> 的指示，分别调用 <see cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" /> 或者 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />，并将方法结果转换为 <see cref="T:System.IntPtr" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.IntPtr" /> 型数据占用字节数量（4或者8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static IntPtr GetIntPtr(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(IntPtr.Size).ToArray()
			.GetIntPtr();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Int64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static long GetLong(this byte[] bytes, int start = 0)
	{
		return bytes.GetInt64(start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Int64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static long GetLong(this IEnumerable<byte> bytes, int start = 0)
	{
		return bytes.GetInt64(start);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Numerics.BigInteger" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	public static BigInteger GetRawBigInteger(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = bytes;
		if (start > 0)
		{
			buff = new byte[bytes.Length - start];
			Array.Copy(bytes, start, buff, 0, buff.Length);
		}
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return new BigInteger(buff);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Boolean" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToBoolean(System.Byte[],System.Int32)" />
	public static bool GetRawBoolean(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[1];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToBoolean(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列转换为 <see cref="T:System.Boolean" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列元素索引有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToBoolean(System.Byte[],System.Int32)" />
	public static bool GetRawBoolean(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(1).ToArray()
			.GetRawBoolean();
	}

	/// <summary>
	/// 获取当前字节数组的指定部分的 Big-Endian 顺序的子字节数组
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">子数组的起始索引</param>
	/// <param name="count">子数组的元素数量</param>
	/// <returns>获取的子字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(this byte[] bytes, int start, int count)
	{
		bytes.GuardNotNull("bytes");
		byte[] buff = bytes.GetBytes(start, count);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
			return bytes;
		}
		return bytes;
	}

	/// <summary>
	/// 获取当前字节数组的指定部分的 Big-Endian 顺序的子字节数组
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <returns>获取子字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(this IEnumerable<byte> bytes)
	{
		bytes.GuardNotNull("bytes");
		if (BitConverter.IsLittleEndian)
		{
			return bytes.ToArray().Reverse();
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Char" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToChar(System.Byte[],System.Int32)" />
	public static char GetRawChar(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[2];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToChar(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列转换为 <see cref="T:System.Char" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列元素索引有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToChar(System.Byte[],System.Int32)" />
	public static char GetRawChar(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(2).ToArray()
			.GetRawChar();
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.DateTime" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.DateTime.FromBinary(System.Int64)" />
	public static DateTime GetRawDateTime(this byte[] bytes, int start = 0)
	{
		return new DateTime(bytes.GetRawInt64(start));
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.DateTime" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.DateTime.FromBinary(System.Int64)" />
	public static DateTime GetRawDateTime(this IEnumerable<byte> bytes, int start = 0)
	{
		return bytes.Skip(start).Take(8).ToArray()
			.GetRawDateTime();
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.DateTimeOffset" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.DateTime.FromBinary(System.Int64)" />
	/// <seealso cref="M:System.TimeSpan.FromTicks(System.Int64)" />
	public static DateTimeOffset GetRawDateTimeOffset(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		DateTime dateTime = bytes.GetRawDateTime(start);
		TimeSpan offset = TimeSpan.Zero;
		if (bytes.Length > start + 8)
		{
			offset = bytes.GetRawTimeSpan(start + 8);
		}
		return new DateTimeOffset(dateTime, offset);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.DateTimeOffset" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.DateTime.FromBinary(System.Int64)" />
	/// <seealso cref="M:System.TimeSpan.FromTicks(System.Int64)" />
	public static DateTimeOffset GetRawDateTimeOffset(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(16).ToArray()
			.GetRawDateTimeOffset();
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Decimal" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.Decimal.#ctor(System.Int32[])" />
	public static decimal GetRawDecimal(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		int[] bits = new int[4];
		for (int i = 0; i < bits.Length; i++)
		{
			bits[i] = ((bytes.Length > start + 4 * i) ? bytes.GetRawInt32(start + 4 * i) : 0);
		}
		return new decimal(bits);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Decimal" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.Decimal.#ctor(System.Int32[])" />
	public static decimal GetRawDecimal(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(16).ToArray()
			.GetRawDecimal();
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Double" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToDouble(System.Byte[],System.Int32)" />
	public static double GetRawDouble(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[8];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToDouble(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Double" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToDouble(System.Byte[],System.Int32)" />
	public static double GetRawDouble(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(8).ToArray()
			.GetRawDouble();
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" />
	public static float GetRawFloat(this byte[] bytes, int start = 0)
	{
		return bytes.GetRawSingle(start);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" />
	public static float GetRawFloat(this IEnumerable<byte> bytes, int start = 0)
	{
		return bytes.GetRawSingle(start);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Guid" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.Guid.#ctor(System.Byte[])" />
	public static Guid GetRawGuid(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[16];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return new Guid(buff);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Guid" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.Guid.#ctor(System.Byte[])" />
	public static Guid GetRawGuid(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(16).ToArray()
			.GetRawGuid();
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Int16" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt16(System.Byte[],System.Int32)" />
	public static short GetRawInt16(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[2];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToInt16(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Int16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt16(System.Byte[],System.Int32)" />
	public static short GetRawInt16(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(2).ToArray()
			.GetRawInt16();
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Int32" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" />
	public static int GetRawInt32(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[4];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToInt32(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Int32" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" />
	public static int RawToInt32(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(4).ToArray()
			.GetRawInt32();
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Int64" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	public static long GetRawInt64(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[8];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToInt64(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Int64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	public static long GetRawInt64(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(8).ToArray()
			.GetRawInt64();
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.IntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	public static IntPtr GetRawIntPtr(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		return IntPtr.Size switch
		{
			4 => (IntPtr)bytes.GetRawInt32(start), 
			8 => (IntPtr)bytes.GetRawInt64(start), 
			_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
		};
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.IntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	public static IntPtr GetRawIntPtr(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(IntPtr.Size).ToArray()
			.GetRawIntPtr();
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" />
	public static float GetRawSingle(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[4];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToSingle(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" />
	public static float GetRawSingle(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(4).ToArray()
			.GetRawSingle();
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.TimeSpan" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.TimeSpan.FromTicks(System.Int64)" />
	public static TimeSpan GetRawTimeSpan(this byte[] bytes, int start = 0)
	{
		return TimeSpan.FromTicks(bytes.GetRawInt64(start));
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.TimeSpan" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.TimeSpan.FromTicks(System.Int64)" />
	public static TimeSpan GetRawTimeSpan(this IEnumerable<byte> bytes, int start = 0)
	{
		return TimeSpan.FromTicks(bytes.GetRawInt64(start));
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.UInt16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToUInt16(System.Byte[],System.Int32)" />
	public static ushort GetRawUInt16(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[2];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToUInt16(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.UInt16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToUInt16(System.Byte[],System.Int32)" />
	public static ushort GetRawUInt16(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(2).ToArray()
			.GetRawUInt16();
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.UInt32" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" />
	public static uint GetRawUInt32(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[4];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToUInt32(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.UInt32" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" />
	public static uint GetRawUInt32(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(4).ToArray()
			.GetRawUInt32();
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.UInt64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" />
	public static ulong GetRawUInt64(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "index");
		byte[] buff = new byte[8];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToUInt64(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.UInt64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" /> 方法还原当前字节序列。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.UInt64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static ulong GetRawUInt64(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(8).ToArray()
			.GetRawUInt64();
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.UIntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" />
	public static UIntPtr GetRawUIntPtr(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "index");
		return UIntPtr.Size switch
		{
			4 => (UIntPtr)bytes.GetRawUInt32(start), 
			8 => (UIntPtr)bytes.GetRawUInt64(start), 
			_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
		};
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.UIntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" />
	public static UIntPtr GetRawUIntPtr(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(UIntPtr.Size).ToArray()
			.GetRawUIntPtr();
	}

	/// <summary>
	/// 从当前字节数组中获取 <see cref="T:System.SByte" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">获取的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>本方法返回当前字节数组中指定索引位置的字节数据。</remarks>
	public static sbyte GetSByte(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		return (sbyte)bytes[start];
	}

	/// <summary>
	/// 从当前字节序列中获取 <see cref="T:System.SByte" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">获取的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>本方法返回当前字节序列中指定索引位置的字节数据。</remarks>
	public static sbyte GetSByte(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		IEnumerable<byte> sub = bytes.Skip(start);
		if (sub.Any())
		{
			return (sbyte)sub.First();
		}
		throw new IndexOutOfRangeException(Literals.MSG_IndexOutOfRange_1.FormatValue("start"));
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Int16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt16(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int16" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static short GetShort(this byte[] bytes, int start = 0)
	{
		return bytes.GetInt16(start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Int16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt16(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.Int16" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static short GetShort(this IEnumerable<byte> bytes, int start = 0)
	{
		return bytes.GetInt16(start);
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Single" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static float GetSingle(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[4];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		return BitConverter.ToSingle(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.Single" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static float GetSingle(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(4).ToArray()
			.GetSingle();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.TimeSpan" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法先调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 将字节数组还原为 <see cref="T:System.Int64" /> 型整数，再调用 <see cref="M:System.TimeSpan.FromTicks(System.Int64)" /> 方法转换为 <see cref="T:System.TimeSpan" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static TimeSpan GetTimeSpan(this byte[] bytes, int start = 0)
	{
		return TimeSpan.FromTicks(bytes.GetInt64(start));
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.TimeSpan" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法先调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 将字节序列还原为 <see cref="T:System.Int64" /> 型整数，再调用 <see cref="M:System.TimeSpan.FromTicks(System.Int64)" /> 方法转换为 <see cref="T:System.TimeSpan" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static TimeSpan GetTimeSpan(this IEnumerable<byte> bytes, int start = 0)
	{
		return TimeSpan.FromTicks(bytes.GetInt64(start));
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.UInt16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToUInt16(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.UInt16" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static ushort GetUInt16(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[2];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		return BitConverter.ToUInt16(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.UInt16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToUInt16(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.Int16" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static ushort GetUInt16(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(2).ToArray()
			.GetUInt16();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.UInt32" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.UInt32" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static uint GetUInt32(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		byte[] buff = new byte[4];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		return BitConverter.ToUInt32(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.UInt32" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" /> 方法还原当前字节序列。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.UInt32" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static uint GetUInt32(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(4).ToArray()
			.GetUInt32();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.UInt64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.UInt64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static ulong GetUInt64(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "index");
		byte[] buff = new byte[4];
		Array.Copy(bytes, start, buff, 0, buff.Length.Min(bytes.Length - start));
		return BitConverter.ToUInt64(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.UInt64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" /> 方法还原当前字节序列。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.UInt64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static ulong GetUInt64(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(8).ToArray()
			.GetUInt64();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.UIntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法根据 <see cref="P:System.UIntPtr.Size" /> 的指示，分别调用 <see cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" /> 或者 <see cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" />，并将方法结果转换为 <see cref="T:System.UIntPtr" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.UIntPtr" /> 型数据占用字节数量（4或者8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static UIntPtr GetUIntPtr(this byte[] bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "index");
		return UIntPtr.Size switch
		{
			4 => (UIntPtr)bytes.GetUInt32(start), 
			8 => (UIntPtr)bytes.GetUInt64(start), 
			_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
		};
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.UIntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法根据 <see cref="P:System.UIntPtr.Size" /> 的指示，分别调用 <see cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" /> 或者 <see cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" />，并将方法结果转换为 <see cref="T:System.UIntPtr" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.UIntPtr" /> 型数据占用字节数量（4或者8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static UIntPtr GetUIntPtr(this IEnumerable<byte> bytes, int start = 0)
	{
		bytes.GuardNotNullAndEmpty("bytes");
		start.GuardIndexLowBound(0, "start");
		return bytes.Skip(start).Take(UIntPtr.Size).ToArray()
			.GetUIntPtr();
	}

	/// <summary>
	/// 计算当前字节数据的哈希值
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="algorithm">使用的哈希算法，默认为SHA1</param>
	/// <returns>根据当前字节数组计算出的哈希值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <remarks>如果方法调用者通过 <paramref name="algorithm" /> 参数指定了算法对象，本方法执行完成时，不会清理这个算法对象，调用者需要自行清理。</remarks>
	public static byte[] Hash(this byte[] data, HashAlgorithm algorithm = null)
	{
		data.GuardNotNull("data");
		return data.Hash(0, data.Length, algorithm);
	}

	/// <summary>
	/// 计算当前字节数据的哈希值
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="start">计算的字节起始索引</param>
	/// <param name="count">计算的字节数量</param>
	/// <param name="algorithm">使用的哈希算法，默认为SHA1</param>
	/// <returns>根据当前字节数组计算出的哈希值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前字节数据的索引范围</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的字节数量。</exception>
	/// <remarks>如果方法调用者通过 <paramref name="algorithm" /> 参数指定了算法对象，本方法执行完成时，不会清理这个算法对象，调用者需要自行清理。</remarks>
	public static byte[] Hash(this byte[] data, int start, int count, HashAlgorithm algorithm = null)
	{
		data.GuardNotNull("data");
		start.GuardIndexRange(0, data.Length - 1, "index");
		count.GuardBetween(0, data.Length - start, "count");
		byte[] hashedBytes;
		if (algorithm.IsNull())
		{
			using HashAlgorithm hasher = new SHA1Managed();
			hashedBytes = hasher.ComputeHash(data, start, count);
			hashedBytes.Clear();
		}
		else
		{
			hashedBytes = algorithm.ComputeHash(data, start, count);
		}
		return hashedBytes;
	}

	/// <summary>
	/// 计算当前字节数据的哈希值
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="algorithm">使用的哈希算法，默认为SHA1</param>
	/// <returns>根据当前字节数据计算出的哈希值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <remarks>如果方法调用者通过 <paramref name="algorithm" /> 参数指定了算法对象，本方法执行完成时，不会清理这个算法对象，调用者需要自行清理。</remarks>
	public static byte[] Hash(this IEnumerable<byte> data, HashAlgorithm algorithm = null)
	{
		data.GuardNotNull("data");
		return data.ToArray().Hash(algorithm);
	}

	/// <summary>
	/// 将当前字节编码为字节的十六进制字符串表示
	/// </summary>
	/// <param name="value">当前字节</param>
	/// <param name="upperCase">是否使用大写的字符形式，默认为false。</param>
	/// <returns>字节的字符串表达形式</returns>
	public static string HexEncode(this byte value, bool upperCase = false)
	{
		return value.ToString(upperCase ? "X2" : "x2");
	}

	/// <summary>
	/// 将当前字节数组编码为字节的十六进制字符串表示
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="upperCase">是否使用大写的字符形式，默认为false。</param>
	/// <returns>当前字节数组的字符串表达形式；如果当前数组不包含元素，则返回空字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string HexEncode(this byte[] bytes, bool upperCase = false)
	{
		bytes.GuardNotNull("bytes");
		return bytes.HexEncode(0, bytes.Length, upperCase);
	}

	/// <summary>
	/// 将当前字节数组编码为字节的十六进制字符串表示
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始编码的字节索引</param>
	/// <param name="count">编码的字节数量</param>
	/// <param name="upperCase">是否使用大写的字符形式，默认为false。</param>
	/// <returns>当前字节数组的字符串表达形式；如果当前数组不包含元素，则返回空字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前字节数据的索引范围</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的字节数量。</exception>
	public static string HexEncode(this byte[] bytes, int start, int count, bool upperCase = false)
	{
		bytes.GuardNotNull("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		count.GuardBetween(0, bytes.Length - start, "count");
		StringBuilder buff = new StringBuilder(count * 2);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			AppendByteHex(buff, bytes[i], upperCase);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 将当前字节序列编码为字节的十六进制字符串表示
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="upperCase">是否使用大写的字符形式，默认为false。</param>
	/// <returns>当前字节序列的字符串表达形式；如果当前序列不包含元素，则返回空字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static string HexEncode(this IEnumerable<byte> bytes, bool upperCase = false)
	{
		bytes.GuardNotNull("bytes");
		StringBuilder buff = new StringBuilder(1024);
		foreach (byte b in bytes)
		{
			AppendByteHex(buff, b, upperCase);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 将当前字节数组按 <paramref name="encoding" /> 指定编码解码为字符串
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="encoding">转换的字符串使用的编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>解码生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string TextDecode(this byte[] bytes, Encoding encoding = null)
	{
		bytes.GuardNotNull("bytes");
		return encoding.IfNull(Encoding.UTF8).GetString(bytes);
	}

	/// <summary>
	/// 将当前字节数组按 <paramref name="encoding" /> 指定编码解码为字符串
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的字节索引位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <param name="encoding">转换的字符串使用的编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>解码生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	public static string TextDecode(this byte[] bytes, int start, int count, Encoding encoding = null)
	{
		bytes.GuardNotNull("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		count.GuardBetween(0, bytes.Length - start, "count");
		return encoding.IfNull(Encoding.UTF8).GetString(bytes, start, count);
	}

	/// <summary>
	/// 将当前字节序列按 <paramref name="encoding" /> 指定编码解码为字符串
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="encoding">转换的字符串使用的编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>解码生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static string TextDecode(this IEnumerable<byte> bytes, Encoding encoding = null)
	{
		bytes.GuardNotNull("bytes");
		encoding = encoding.IfNull(Encoding.UTF8);
		Decoder decoder = encoding.GetDecoder();
		StringBuilder text = new StringBuilder();
		byte[] buff = new byte[1024];
		char[] chars = new char[1024];
		int index = 0;
		int charCount = 0;
		foreach (byte b in bytes)
		{
			buff[index++] = b;
			if (index >= buff.Length)
			{
				charCount = decoder.GetChars(buff, 0, buff.Length, chars, 0);
				text.Append(chars, 0, charCount);
				index = 0;
			}
		}
		if (index > 0)
		{
			charCount = decoder.GetChars(buff, 0, index, chars, 0, flush: true);
			text.Append(chars, 0, charCount);
		}
		return text.ToString();
	}

	/// <summary>
	/// 把当前字节值转换为位数组
	/// </summary>
	/// <param name="value">当前字节值</param>
	/// <returns>生成的位数组</returns>
	public static BitArray ToBitArray(this byte value)
	{
		return new BitArray(new byte[1] { value });
	}

	/// <summary>
	/// 把当前字节值数组转换为位数组
	/// </summary>
	/// <param name="values">当前字节值数组</param>
	/// <returns>生成的位数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节值数组为空。</exception>
	public static BitArray ToBitArray(this byte[] values)
	{
		values.GuardNotNull("values");
		return new BitArray(values);
	}

	/// <summary>
	/// 把当前字节值数组转换为位数组
	/// </summary>
	/// <param name="values">当前字节数组</param>
	/// <param name="start">开始转换的字节索引位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <returns>生成的位数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	public static BitArray ToBitArray(this byte[] values, int start, int count)
	{
		values.GuardNotNull("values");
		start.GuardIndexRange(0, values.Length - 1, "start");
		count.GuardBetween(0, values.Length - start, "count");
		byte[] bytes = new byte[count];
		Array.Copy(values, start, bytes, 0, count);
		return new BitArray(bytes);
	}

	/// <summary>
	/// 把当前字节值序列转换为位数组
	/// </summary>
	/// <param name="values">当前字节值序列</param>
	/// <returns>生成的位数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节值序列为空。</exception>
	public static BitArray ToBitArray(this IEnumerable<byte> values)
	{
		values.GuardNotNull("values");
		return values.ToArray().ToBitArray();
	}

	/// <summary>
	/// 将当前字节数组转换为字节的小写的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <returns>字节数组的小写十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(this byte[] bytes)
	{
		return bytes.ToHex(bytePrefix: false, upperCase: false);
	}

	/// <summary>
	/// 将当前字节数组转换为字节的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(this byte[] bytes, bool upperCase)
	{
		return bytes.ToHex(bytePrefix: false, upperCase);
	}

	/// <summary>
	/// 将当前字节数组转换为字节的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="bytePrefix">是否每个字节前都添加前缀</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(this byte[] bytes, bool bytePrefix, bool upperCase)
	{
		return bytes.ToHex(upperCase ? "0X" : "0x", bytePrefix, upperCase);
	}

	/// <summary>
	/// 将当前字节数组转换为字节的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="bytePrefix">是否每个字节前都添加前缀</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(this IEnumerable<byte> bytes, bool bytePrefix, bool upperCase)
	{
		return bytes.ToHex(upperCase ? "0X" : "0x", bytePrefix, upperCase);
	}

	/// <summary>
	/// 将当前字节数组转换为字节的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="prefix">十六进制字符串前缀</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(this byte[] bytes, string prefix)
	{
		return bytes.ToHex(prefix, bytePrefix: false, upperCase: false);
	}

	/// <summary>
	/// 将当前字节数组转换为字节的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="prefix">十六进制字符串前缀</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(this byte[] bytes, string prefix, bool upperCase)
	{
		return bytes.ToHex(prefix, bytePrefix: false, upperCase);
	}

	/// <summary>
	/// 将当前字节数组转换为字节的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="prefix">十六进制字符串前缀</param>
	/// <param name="bytePrefix">是否每个字节前都添加前缀</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(this byte[] bytes, string prefix, bool bytePrefix, bool upperCase)
	{
		bytes.GuardNotNull("bytes");
		prefix = prefix.IfNull(string.Empty);
		StringBuilder buff = new StringBuilder(bytes.Length * (bytePrefix ? (2 + prefix.Length) : 2) + ((!bytePrefix) ? prefix.Length : 0));
		for (int i = 0; i < bytes.Length; i++)
		{
			if (bytePrefix || i == 0)
			{
				buff.Append(prefix);
			}
			AppendByteHex(buff, bytes[i], upperCase);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 将当前字节数组转换为字节的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="prefix">十六进制字符串前缀</param>
	/// <param name="bytePrefix">是否每个字节前都添加前缀</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(this IEnumerable<byte> bytes, string prefix, bool bytePrefix, bool upperCase)
	{
		bytes.GuardNotNull("bytes");
		prefix = prefix.IfNull(string.Empty);
		StringBuilder buff = new StringBuilder(1024);
		bool firstByte = true;
		foreach (byte b in bytes)
		{
			if (firstByte || bytePrefix)
			{
				buff.Append(prefix);
				firstByte = false;
			}
			AppendByteHex(buff, b, upperCase);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 将当前字节数组中转换为字节的十六进制字符串表示
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="groupSize">字节分组的元素个数</param>
	/// <param name="groupFormat">字节分组格式化字符串</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空；或者字节分组格式化字符串 <paramref name="groupFormat" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">字节分组元素个数 <paramref name="groupSize" /> 小于0。</exception>
	public static string ToHex(this byte[] bytes, int groupSize, string groupFormat, bool upperCase = false)
	{
		bytes.GuardNotNull("bytes");
		return bytes.AsEnumerable<byte>().ToHex(groupSize, groupFormat, upperCase);
	}

	/// <summary>
	/// 将当前字节序列中转换为字节的十六进制字符串表示
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="groupSize">字节分组的元素个数</param>
	/// <param name="groupFormat">字节分组格式化字符串</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节序列的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空；或者字节分组格式化字符串 <paramref name="groupFormat" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">字节分组元素个数 <paramref name="groupSize" /> 小于0。</exception>
	public static string ToHex(this IEnumerable<byte> bytes, int groupSize, string groupFormat, bool upperCase = false)
	{
		bytes.GuardNotNull("bytes");
		groupSize.GuardGreaterThanOrEqualTo(0, "group size");
		groupFormat.GuardNotNull("group format");
		StringBuilder buff = new StringBuilder(1024);
		StringBuilder groupBuff = new StringBuilder(16);
		int groupCount = 0;
		foreach (byte b in bytes)
		{
			if (groupCount >= groupSize)
			{
				buff.Append(string.Format(groupFormat, groupBuff.ToString()));
				groupBuff.Clear();
				groupCount = 0;
			}
			AppendByteHex(buff, b, upperCase);
			groupCount++;
		}
		buff.Append(string.Format(groupFormat, groupBuff.ToString()));
		return buff.ToString();
	}

	private static StringBuilder AppendByteHex(StringBuilder buff, byte b, bool upperCase)
	{
		int c = (upperCase ? 65 : 97);
		int v = b >> 4;
		buff.Append((char)((v < 10) ? (48 + v) : (c - 10 + v)));
		v = b & 0xF;
		buff.Append((char)((v < 10) ? (48 + v) : (c - 10 + v)));
		return buff;
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
	public static Stream ToReadonlyStream(this byte[] data)
	{
		data.GuardNotNull("data");
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
	public static Stream ToReadonlyStream(this byte[] data, int start, int count)
	{
		data.GuardNotNull("data");
		start.GuardIndexRange(0, data.Length - 1, "start");
		count.GuardBetween(0, data.Length - start, "count");
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
	public static Stream ToReadonlyStream(this IEnumerable<byte> data)
	{
		data.GuardNotNull("data");
		return data.ToArray().ToReadonlyStream();
	}

	/// <summary>
	/// 把当前的字节数组转换为流对象。
	/// </summary>
	/// <param name="bytes">当前的字节数组</param>
	/// <param name="writable">流对象是否可写，默认为true</param>
	/// <returns>创建的流对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <remarks>创建的流对象以当前字节数据为基础，不可以改变容量。</remarks>
	public static Stream ToStream(this byte[] bytes, bool writable = true)
	{
		bytes.GuardNotNull("bytes");
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
	public static Stream ToStream(this byte[] bytes, int start, int count, bool writable = true)
	{
		bytes.GuardNotNull("bytes");
		start.GuardIndexRange(0, bytes.Length - 1, "start");
		count.GuardBetween(0, bytes.Length - start, "count");
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
	public static Stream ToStream(this IEnumerable<byte> bytes, bool writable = true)
	{
		bytes.GuardNotNull("bytes");
		return bytes.ToArray().ToStream(writable);
	}

	/// <summary>
	/// 使用Unicode编码对当前字节数据进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	public static string UnicodeDecode(this byte[] data)
	{
		return data.TextDecode(Encoding.Unicode);
	}

	/// <summary>
	/// 使用Unicode编码对当前字节数据进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="start">开始转换的字节索引位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	public static string UnicodeDecode(this byte[] data, int start, int count)
	{
		return data.TextDecode(start, count, Encoding.Unicode);
	}

	/// <summary>
	/// 使用Unicode编码对当前字节序列进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="data">当前字节序列</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static string UnicodeDecode(this IEnumerable<byte> data)
	{
		return data.TextDecode(Encoding.Unicode);
	}

	/// <summary>
	/// 使用UTF-8编码对当前字节数据进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	public static string Utf8Decode(this byte[] data)
	{
		return data.TextDecode(Encoding.UTF8);
	}

	/// <summary>
	/// 使用UTF-8编码对当前字节数据进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="start">开始转换的字节索引位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	public static string Utf8Decode(this byte[] data, int start, int count)
	{
		return data.TextDecode(start, count, Encoding.UTF8);
	}

	/// <summary>
	/// 使用UTF-8编码对当前字节序列进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="data">当前字节序列</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static string Utf8Decode(this IEnumerable<byte> data)
	{
		return data.TextDecode(Encoding.UTF8);
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
	public static FileInfo SaveFile(this byte[] data, string file, bool overwrite = true)
	{
		return data.SaveFile(new FileInfo(file), overwrite);
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
	public static FileInfo SaveFile(this byte[] data, int start, int count, string file, bool overwrite = true)
	{
		return data.SaveFile(start, count, new FileInfo(file), overwrite);
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
	public static FileInfo SaveFile(this byte[] data, FileInfo file, bool overwrite = true)
	{
		data.GuardNotNull("data");
		return data.SaveFile(0, data.Length, file, overwrite);
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
	public static FileInfo SaveFile(this byte[] data, int start, int count, FileInfo file, bool overwrite = true)
	{
		data.GuardNotNull("data");
		start.GuardIndexRange(0, data.Length - 1, "start");
		count.GuardBetween(0, data.Length - start, "count");
		file.GuardNotNull("file");
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
	public static FileInfo SaveFile(this IEnumerable<byte> data, string file, bool overwrite = true)
	{
		data.GuardNotNull("data");
		file.GuardNotNull("file");
		return data.SaveFile(new FileInfo(file), overwrite);
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
	public static FileInfo SaveFile(this IEnumerable<byte> data, FileInfo file, bool overwrite = true)
	{
		data.GuardNotNull("data");
		file.GuardNotNull("file");
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
	public static FileInfo SaveTempFile(this byte[] data, string tempPath = null)
	{
		data.GuardNotNull("data");
		return data.SaveFile(IOHelper.CreateTempFile(tempPath), overwrite: false);
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
	public static FileInfo SaveTempFile(this byte[] data, int start, int count, string tempPath = null)
	{
		data.GuardNotNull("data");
		return data.SaveFile(start, count, IOHelper.CreateTempFile(tempPath), overwrite: false);
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
	public static FileInfo SaveTempFile(this byte[] data, DirectoryInfo tempPath)
	{
		data.GuardNotNull("data");
		return data.SaveFile(IOHelper.CreateTempFile(tempPath), overwrite: false);
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
	public static FileInfo SaveTempFile(this byte[] data, int start, int count, DirectoryInfo tempPath)
	{
		data.GuardNotNull("data");
		return data.SaveFile(start, count, IOHelper.CreateTempFile(tempPath), overwrite: false);
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
	public static FileInfo SaveTempFile(this IEnumerable<byte> data, string tempPath = null)
	{
		data.GuardNotNull("data");
		return data.SaveFile(IOHelper.CreateTempFile(tempPath), overwrite: false);
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
	public static FileInfo SaveTempFile(this IEnumerable<byte> data, DirectoryInfo tempPath)
	{
		data.GuardNotNull("data");
		return data.SaveFile(IOHelper.CreateTempFile(tempPath), overwrite: false);
	}

	/// <summary>
	/// 将当前字节数组与指定的字节数组进行异或运算
	/// </summary>
	/// <param name="a">当前的字节数组</param>
	/// <param name="b">进行运算的数组</param>
	/// <returns>异或结果数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空；或者进行运算的数组 <paramref name="b" /> 为空。</exception>
	public static byte[] Xor(this byte[] a, byte[] b)
	{
		byte[] result = new byte[a.Length.Min(b.Length)];
		for (int i = 0; i < result.Length; i++)
		{
			result[i] = (byte)(a[i] ^ b[i]);
		}
		return result;
	}
}
