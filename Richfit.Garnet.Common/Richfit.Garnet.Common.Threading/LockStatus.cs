using System;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Threading;

/// <summary>
/// 锁定状态对象
/// </summary>
public class LockStatus : IEquatable<LockStatus>
{
	/// <summary>
	/// 锁定层级
	/// </summary>
	public int Level { get; set; }

	/// <summary>
	/// 当前锁定模式
	/// </summary>
	public LockMode Mode { get; set; }

	/// <summary>
	/// 锁定数据
	/// </summary>
	public object Data { get; set; }

	/// <summary>
	/// 初始化
	/// </summary>
	public LockStatus(int level, LockMode mode, object data)
	{
		Level = level;
		Mode = mode;
		Data = data;
	}

	/// <summary>
	/// 获取状态对象Hash值
	/// </summary>
	/// <returns></returns>
	public override int GetHashCode()
	{
		int hashCode = Level.GetHashCode() ^ Mode.GetHashCode();
		if (Data.IsNotNull())
		{
			hashCode ^= Data.GetHashCode();
		}
		return hashCode;
	}

	/// <summary>
	/// 比较指定对象与当前状态对象是否相等
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	public override bool Equals(object obj)
	{
		if (obj is LockStatus)
		{
			return Equals((LockStatus)obj);
		}
		return false;
	}

	/// <summary>
	/// 比较指定的状态对象与当前状态对象是否相等
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public bool Equals(LockStatus other)
	{
		return Level == other.Level && Mode == other.Mode;
	}
}
