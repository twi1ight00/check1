using System;
using System.Data;
using System.Text;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 数据集配置源对象
/// </summary>
[ConfigurationSourceMapping(typeof(DataSetConfigurationSource))]
public interface IDataSetConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置配置源文件的编码
	/// </summary>
	Encoding Encoding { get; set; }

	/// <summary>
	/// 获取或者设置配置源文本
	/// </summary>
	string Text { get; set; }

	/// <summary>
	/// 获取配置源中定义的数据集，如果无配置数据返回空的数据集
	/// </summary>
	/// <returns>加载的数据集</returns>
	DataSet GetDataSet();

	/// <summary>
	/// 按照指定的方式从配置源中加载数据集的数据
	/// </summary>
	/// <param name="mode">数据读取模式</param>
	/// <returns>加载的数据集</returns>
	DataSet GetDataSet(XmlReadMode mode);

	/// <summary>
	/// 获取配置源中定义的强类型数据集，如果无配置数据返回空的数据集
	/// </summary>
	/// <typeparam name="T">数据集类型</typeparam>
	/// <returns>加载的数据集</returns>
	T GetDataSet<T>() where T : DataSet, new();

	/// <summary>
	/// 按照指定的方式从配置源中加载数据集的数据
	/// </summary>
	/// <typeparam name="T">数据集类型</typeparam>
	/// <param name="mode">数据读取模式</param>
	/// <returns>加载的数据集</returns>
	T GetDataSet<T>(XmlReadMode mode) where T : DataSet, new();

	/// <summary>
	/// 保存数据集到配置源中
	/// </summary>
	/// <param name="ds">待保存的数据集</param>
	void SetDataSet(DataSet ds);

	/// <summary>
	/// 保存数据集到配置源中
	/// </summary>
	/// <param name="ds">待保存的数据集</param>
	/// <param name="mode">数据写入模式</param>
	void SetDataSet(DataSet ds, XmlWriteMode mode);

	/// <summary>
	/// 获取配置源中定义的第一个数据表，如果未定义数据表则返回null
	/// </summary>
	/// <returns>配置源中定义的数据表</returns>
	DataTable GetDataTable();

	/// <summary>
	/// 获取配置源中定义的指定名称的数据表，如果未找到匹配的数据表则返回null
	/// </summary>
	/// <param name="name">数据表名称</param>
	/// <returns>配置源中定义的数据表</returns>
	DataTable GetDataTable(string name);

	/// <summary>
	/// 获取配置源中定义的第一个强类型数据表
	/// </summary>
	/// <typeparam name="T">数据表类型</typeparam>
	/// <returns>配置源中定义的数据表</returns>
	T GetDataTable<T>() where T : DataTable, new();

	/// <summary>
	/// 保存数据表到配置源中
	/// </summary>
	/// <param name="dt"></param>
	void SetDataTable(DataTable dt);

	/// <summary>
	/// 保存数据表到配置源中
	/// </summary>
	/// <param name="dt">待保存的数据集</param>
	/// <param name="mode">数据写入模式</param>
	/// <param name="inherit">是否保存子代数据表</param>
	void SetDataTable(DataTable dt, XmlWriteMode mode, bool inherit = false);
}
