using System;

namespace Richfit.Garnet.Common.Collections;

/// <summary>
/// 值范围比较参数枚举
/// </summary>
[Flags]
public enum RangeComparison
{
	/// <summary>
	/// 未指定
	/// </summary>
	None = 0,
	/// <summary>
	/// 进行范围比较时包含最小值
	/// </summary>
	MinIncluded = 1,
	/// <summary>
	/// 进行范围比较时包含最大值
	/// </summary>
	MaxIncluded = 2,
	/// <summary>
	/// 进行范围比较是包含最大值和最小值
	/// </summary>
	BothIncluded = 3
}
