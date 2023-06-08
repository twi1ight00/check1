using Richfit.Garnet.Common.Configuration;

namespace Richfit.Garnet.Module.Importing.Aspose;

/// <summary>
/// 基于Aspose组件的导入器基类
/// </summary>
public abstract class AsposeImporter : Importer
{
	/// <summary>
	/// 静态初始化
	/// </summary>
	static AsposeImporter()
	{
	}

	/// <summary>
	/// 指定名称进行初始化
	/// </summary>
	/// <param name="name">导出器名称</param>
	protected AsposeImporter(string name)
		: base(name)
	{
	}

	/// <summary>
	/// 使用指定的配置进行初始化
	/// </summary>
	/// <param name="view">配置视图</param>
	protected AsposeImporter(IConfigurationView view)
		: base(view)
	{
	}
}
