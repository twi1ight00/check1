namespace Richfit.Garnet.Module.Base.Infrastructure.Cache;

/// <summary>
/// Cache加载接口定义，应用启动的时候需要载入Cache的业务需要实现此接口
/// </summary>
public interface ICacheLoader
{
	/// <summary>
	/// 加载缓存数据
	/// </summary>
	void Load();
}
