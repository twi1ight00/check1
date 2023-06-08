using System;

namespace Richfit.Garnet.Common.Collections;

/// <summary>
/// 比较方式枚举
/// </summary>
[Flags]
public enum ComparisonMode
{
	/// <summary>
	/// 不等于
	/// </summary>
	None = 0,
	/// <summary>
	/// 取反，不应单独使用
	/// </summary>
	Not = 0x80,
	/// <summary>
	/// 等于
	/// </summary>
	Equal = 1,
	/// <summary>
	/// 不等于
	/// </summary>
	NotEqual = 0x81,
	/// <summary>
	/// 大于
	/// </summary>
	GreaterThan = 2,
	/// <summary>
	/// 不大于
	/// </summary>
	NotGreaterThan = 0x82,
	/// <summary>
	/// 小于
	/// </summary>
	LessThan = 4,
	/// <summary>
	/// 不小于
	/// </summary>
	NotLessThan = 0x84,
	/// <summary>
	/// 大于等于
	/// </summary>
	GreaterThanOrEqual = 3,
	/// <summary>
	/// 不大于等于
	/// </summary>
	NotGreaterThanOrEqual = 0x83,
	/// <summary>
	/// 小于等于
	/// </summary>
	LessThanOrEqual = 5,
	/// <summary>
	/// 不小于等于
	/// </summary>
	NotLessThanOrEqual = 0x85
}
