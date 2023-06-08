namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 配置变更事件委托
/// </summary>
/// <param name="sender">发生变更的配置源</param>
/// <param name="args">变更参数</param>
public delegate void ConfigurationSourceChangedEventHandler(object sender, ConfigurationSourceChangedEventArgs args);
