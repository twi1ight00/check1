namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 配置清理前事件委托
/// </summary>
/// <param name="sender">待清理的对象</param>
/// <param name="args">清理参数</param>
public delegate void ConfigurationSourceDisposingEventHandler(object sender, ConfigurationSourceDisposingEventArgs args);
