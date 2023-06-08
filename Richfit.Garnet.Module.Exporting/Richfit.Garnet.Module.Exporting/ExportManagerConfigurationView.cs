using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Configuration.Views;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Exporting.Properties;

namespace Richfit.Garnet.Module.Exporting;

/// <summary>
/// 导出配置视图
/// </summary>
public class ExportManagerConfigurationView : ConfigurationView
{
	/// <summary>
	/// 导出器配置信息
	/// </summary>
	public class ExporterInfo
	{
		/// <summary>
		/// 导出器名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 导出器类型
		/// </summary>
		public Type Type { get; set; }

		/// <summary>
		/// 导出器配置
		/// </summary>
		public IViewsConfiguration Configuration { get; set; }
	}

	/// <summary>
	/// 导出器配置信息缓存
	/// </summary>
	private Dictionary<string, ExporterInfo> exporterInfos = new Dictionary<string, ExporterInfo>(StringComparer.Ordinal);

	/// <summary>
	/// 初始化默认配置视图
	/// </summary>
	public ExportManagerConfigurationView()
	{
	}

	/// <summary>
	/// 初始化配置视图
	/// </summary>
	/// <param name="xml">视图数据</param>
	public ExportManagerConfigurationView(string xml)
	{
		Deserialize(xml);
	}

	/// <summary>
	/// 将视图序列化为Xml格式的配置数据
	/// </summary>
	/// <returns>Xml结构化对象</returns>
	protected override XElement SerializeView()
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// 将Xml格式的配置数据反序列化为视图对象
	/// </summary>
	/// <param name="root">Xml格式配置数据对象</param>
	protected override void DeserializeView(XElement root)
	{
		Dictionary<string, ExporterInfo> newInfos = new Dictionary<string, ExporterInfo>(StringComparer.Ordinal);
		XElement exporters = root.Element("exporters").GuardNotNull(typeof(ConfigurationErrorsException), Literals.MSG_E_InvalidManagerConfiguration);
		foreach (XElement exporter in exporters.Elements())
		{
			exporter.Name.ToString().GuardEqualTo("exporter", () => new ConfigurationErrorsException(Literals.MSG_E_InvalidManagerConfiguration));
			ExporterInfo info = new ExporterInfo();
			info.Name = exporter.Attribute("name").GuardNotNull(typeof(ConfigurationErrorsException), Literals.MSG_E_InvalidManagerConfiguration).Value;
			info.Type = exporter.Attribute("type").GuardNotNull(typeof(ConfigurationErrorsException), Literals.MSG_E_InvalidManagerConfiguration).Value.ResolveType();
			info.Configuration = base.Owner;
			if (newInfos.ContainsKey(info.Name))
			{
				throw new ConfigurationErrorsException(Literals.MSG_E_DuplicateExporterName);
			}
			newInfos.Add(info.Name, info);
		}
		exporterInfos = newInfos;
	}

	/// <summary>
	/// 获取全部导出器配置信息
	/// </summary>
	/// <returns>导出器配置信息数组</returns>
	public ExporterInfo[] GetInfos()
	{
		if (base.SyncRoot.IsNull())
		{
			return exporterInfos.Values.ToArray();
		}
		return base.SyncRoot.Read(() => exporterInfos.Values.ToArray());
	}

	/// <summary>
	/// 获取指定名称的导出器配置信息
	/// </summary>
	/// <param name="exporterName">导出器名称</param>
	/// <returns>导出器配置信息</returns>
	public ExporterInfo GetInfo(string exporterName)
	{
		exporterName.GuardNotNull();
		if (base.SyncRoot.IsNull())
		{
			return exporterInfos.ContainsKey(exporterName) ? exporterInfos[exporterName] : null;
		}
		return base.SyncRoot.Read(() => exporterInfos.ContainsKey(exporterName) ? exporterInfos[exporterName] : null);
	}
}
