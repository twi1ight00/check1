using Richfit.Garnet.Common.Configuration;

namespace Richfit.Garnet.Module.Exporting.Aspose;

/// <summary>
/// 基于Aspose组件的导出器基类
/// </summary>
public abstract class AsposeExporter : Exporter
{
	/// <summary>
	/// 静态初始化
	/// </summary>
	static AsposeExporter()
	{
	}

	/// <summary>
	/// 指定名称进行初始化
	/// </summary>
	/// <param name="name">导出器名称</param>
	protected AsposeExporter(string name)
		: base(name)
	{
	}

	/// <summary>
	/// 使用指定的配置进行初始化
	/// </summary>
	/// <param name="view">配置视图</param>
	protected AsposeExporter(IConfigurationView view)
		: base(view)
	{
	}
}
