namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 配置清理事件委托
/// </summary>
/// <param name="sender">已清理的对象</param>
/// <param name="args">清理参数</param>
public delegate void ConfigurationSourceDisposedEventHandler(object sender, ConfigurationSourceDisposedEventArgs args);
