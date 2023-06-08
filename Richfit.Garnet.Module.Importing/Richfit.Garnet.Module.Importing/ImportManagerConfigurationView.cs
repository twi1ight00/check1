using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Configuration.Views;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Importing.Properties;

namespace Richfit.Garnet.Module.Importing;

/// <summary>
/// 导入配置视图
/// </summary>
public class ImportManagerConfigurationView : ConfigurationView
{
	/// <summary>
	/// 导入器配置信息
	/// </summary>
	public class ImporterInfo
	{
		/// <summary>
		/// 导入器名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 导入器类型
		/// </summary>
		public Type Type { get; set; }

		/// <summary>
		/// 导入器配置
		/// </summary>
		public IViewsConfiguration Configuration { get; set; }
	}

	/// <summary>
	/// 导入器配置信息缓存
	/// </summary>
	private Dictionary<string, ImporterInfo> importerInfos = new Dictionary<string, ImporterInfo>(StringComparer.Ordinal);

	/// <summary>
	/// 初始化默认配置视图
	/// </summary>
	public ImportManagerConfigurationView()
	{
	}

	/// <summary>
	/// 初始化配置视图
	/// </summary>
	/// <param name="xml">视图数据</param>
	public ImportManagerConfigurationView(string xml)
		: base(xml)
	{
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
		Dictionary<string, ImporterInfo> newInfos = new Dictionary<string, ImporterInfo>(StringComparer.Ordinal);
		XElement importers = root.Element("importers");
		foreach (XElement importer in importers.Elements())
		{
			string item = importer.Name.ToString();
			Func<Exception> exceptionCreator = () => new ConfigurationErrorsException(Literals.M_E_ImportManager_Configuration_Unrecognizable.FormatValue(importer.Name.LocalName, "importers"));
			item.GuardEqualTo("importer", exceptionCreator);
			ImporterInfo info = new ImporterInfo();
			info.Name = importer.Attribute("name").GuardNotNull(typeof(ConfigurationErrorsException), Literals.M_E_ImportManager_Configuration_AttributeMissing.FormatValue("name", importer.Name.LocalName)).Value;
			info.Type = importer.Attribute("type").GuardNotNull(typeof(ConfigurationErrorsException), Literals.M_E_ImportManager_Configuration_AttributeMissing.FormatValue("type", importer.Name.LocalName)).Value.ResolveType();
			info.Configuration = base.Owner;
			if (newInfos.ContainsKey(info.Name))
			{
				throw new ConfigurationErrorsException(Literals.M_E_Importer_Configuration_Duplication.FormatValue(info.Name));
			}
			newInfos.Add(info.Name, info);
		}
		importerInfos = newInfos;
	}

	/// <summary>
	/// 获取全部导入器配置信息
	/// </summary>
	/// <returns>导入器配置信息数组</returns>
	public ImporterInfo[] GetInfos()
	{
		if (base.SyncRoot.IsNull())
		{
			return importerInfos.Values.ToArray();
		}
		return base.SyncRoot.Read(() => importerInfos.Values.ToArray());
	}

	/// <summary>
	/// 获取指定名称的导入器配置信息
	/// </summary>
	/// <param name="importerName">导入器名称</param>
	/// <returns>导入器配置信息</returns>
	public ImporterInfo GetInfo(string importerName)
	{
		importerName.GuardNotNull();
		if (base.SyncRoot.IsNull())
		{
			return importerInfos.ContainsKey(importerName) ? importerInfos[importerName] : null;
		}
		return base.SyncRoot.Read(() => importerInfos.ContainsKey(importerName) ? importerInfos[importerName] : null);
	}
}
