namespace Richfit.Garnet.Common.Threading;

/// <summary>
/// 锁定模式
/// </summary>
public enum LockMode
{
	/// <summary>
	/// 无锁定
	/// </summary>
	None,
	/// <summary>
	/// 读锁定
	/// </summary>
	Read,
	/// <summary>
	/// 可升级读锁定
	/// </summary>
	UpgradableRead,
	/// <summary>
	/// 写锁定
	/// </summary>
	Write
}
