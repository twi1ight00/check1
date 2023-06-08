using System;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// 日期组成结构枚举
/// </summary>
[Flags]
public enum DateTimeParts
{
	/// <summary>
	/// 未指定
	/// </summary>
	Unspecified = 0,
	/// <summary>
	/// 年份
	/// </summary>
	Year = 1,
	/// <summary>
	/// 月份
	/// </summary>
	Month = 2,
	/// <summary>
	/// 日期
	/// </summary>
	Day = 4,
	/// <summary>
	/// 小时
	/// </summary>
	Hour = 8,
	/// <summary>
	/// 分钟
	/// </summary>
	Minute = 0x16,
	/// <summary>
	/// 秒
	/// </summary>
	Second = 0x32,
	/// <summary>
	/// 毫秒
	/// </summary>
	Millisecond = 0x64,
	/// <summary>
	/// 年份和月份
	/// </summary>
	YM = 3,
	/// <summary>
	/// 月份和日期
	/// </summary>
	MD = 6,
	/// <summary>
	/// 年份、月份和日期
	/// </summary>
	YMD = 7,
	/// <summary>
	/// 年份、月份、日期、小时、分钟和秒
	/// </summary>
	YMDHMS = 0x3F,
	/// <summary>
	/// 年份、月份、日期、小时、分钟、秒和毫秒
	/// </summary>
	YMDHMSM = 0x7F,
	/// <summary>
	/// 小时和分钟
	/// </summary>
	HM = 0x1E,
	/// <summary>
	/// 小时、分钟和秒
	/// </summary>
	HMS = 0x3E,
	/// <summary>
	/// 小时、分钟、秒和毫秒
	/// </summary>
	HMSM = 0x7E,
	/// <summary>
	/// 分钟和秒
	/// </summary>
	MS = 0x36,
	/// <summary>
	/// 分钟、秒和毫秒
	/// </summary>
	MSM = 0x76
}
