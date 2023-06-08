using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Richfit.Garnet.Common.Configuration.Designs;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// Unity容器拦截配置组
/// </summary>
public class InterceptionConfigurationSourceGroup : ConfigurationSourceGroup, IInterceptionGroupConfiguration, IConfiguration, IInterceptionGroupConfigurationSource, IGroupConfigurationSource, IRefreshableConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// Unity配置节
	/// </summary>
	private PolicyInterceptionSection section;

	/// <summary>
	/// 策略拦截配置节类型名称
	/// </summary>
	private readonly string policyInterceptionSectionType = typeof(PolicyInterceptionSection).AssemblyQualifiedName;

	/// <summary>
	/// 策略拦截配置节名称
	/// </summary>
	private readonly string policyInterceptionSectionName = "policyInterception";

	/// <summary>
	/// 获取Unity配置节
	/// </summary>
	public override object RawData
	{
		get
		{
			return base.SyncRoot.Read(delegate
			{
				this.GuardNotDisposed();
				return section.IsNull() ? null : section.CurrentConfiguration.FilePath.ToFileInfo().ReadText();
			});
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	/// <summary>
	/// 获取或者设置配置的原始文本
	/// </summary>
	public string Text => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return section.IsNull() ? null : section.SectionInformation.GetRawXml();
	});

	/// <summary>
	/// 使用配置源组初始化
	/// </summary>
	/// <param name="group">配置组</param>
	/// <param name="recursive">是否递归查找所有的子配置源</param>
	public InterceptionConfigurationSourceGroup(IConfigurationSourceGroup group, bool recursive = false)
		: base(group, recursive)
	{
		LoadPolicyInterceptionSection();
	}

	/// <summary>
	/// 验证配置源
	/// </summary>
	/// <param name="source"></param>
	/// <returns></returns>
	protected override bool ValidateSource(IConfigurationSource source)
	{
		if (!base.ValidateSource(source))
		{
			return false;
		}
		return source is IInterceptionConfiguration;
	}

	/// <summary>
	/// 执行清理
	/// </summary>
	/// <param name="disposing"></param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			DisposeSection();
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// 获取拦截配置节
	/// </summary>
	/// <returns>拦截配置节</returns>
	public PolicyInterceptionSection GetConfiguration()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return section;
		});
	}

	/// <summary>
	/// 配置源变更事件
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	protected override void DoSourceChanged(object sender, ConfigurationSourceChangedEventArgs args)
	{
		base.SyncRoot.Write(delegate
		{
			DisposeSection();
			LoadPolicyInterceptionSection();
			base.GroupID = Guid.NewGuid();
		});
	}

	/// <summary>
	/// 加载策略拦截配置
	/// </summary>
	private void LoadPolicyInterceptionSection()
	{
		Dictionary<IInterceptionConfigurationSource, XDocumentInfo> sourceMapping = new Dictionary<IInterceptionConfigurationSource, XDocumentInfo>();
		IConfigurationSource[] array = GetSources();
		for (int i = 0; i < array.Length; i++)
		{
			IInterceptionConfigurationSource source = (IInterceptionConfigurationSource)array[i];
			IFileConfigurationSource fileSource = (IFileConfigurationSource)source;
			XDocument xdoc = XDocument.Parse(fileSource.RawData.ToString());
			sourceMapping.Add(source, new XDocumentInfo(xdoc, fileSource.FullName));
		}
		XDocument document = MergePolicyInterceptionConfiguration(sourceMapping);
		string tempFile = Path.GetTempFileName();
		document.Save(tempFile);
		ExeConfigurationFileMap exeConfigurationFileMap = new ExeConfigurationFileMap();
		exeConfigurationFileMap.ExeConfigFilename = tempFile;
		System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap, ConfigurationUserLevel.None);
		section = configuration.GetFirstSection<PolicyInterceptionSection>();
	}

	/// <summary>
	/// 清理配置节
	/// </summary>
	private void DisposeSection()
	{
		if (section.IsNotNull())
		{
			File.Delete(section.CurrentConfiguration.FilePath);
			section = null;
		}
	}

	/// <summary>
	/// 合并策略拦截配置
	/// </summary>
	/// <param name="sourceMapping">配置源信息映射</param>
	/// <returns></returns>
	private XDocument MergePolicyInterceptionConfiguration(Dictionary<IInterceptionConfigurationSource, XDocumentInfo> sourceMapping)
	{
		XElement mergedNode = new XElement(policyInterceptionSectionName);
		foreach (XDocumentInfo doc in sourceMapping.Values)
		{
			XElement sourceNode = null;
			XElement configurationNode = doc.Document.Element("configuration");
			if (!configurationNode.IsNull() && !(sourceNode = GetPolicyInterceptionSectionNode(configurationNode)).IsNull())
			{
				MergePolicyInterceptionInterceptorNode(mergedNode, sourceNode, doc);
				MergePolicyInterceptionTargetNode(mergedNode, sourceNode, doc);
			}
		}
		XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
		XElement rootNode = new XElement("configuration");
		xdoc.Add(rootNode);
		rootNode.Add(new XElement("configSections", new XElement("section", new XAttribute("name", policyInterceptionSectionName), new XAttribute("type", policyInterceptionSectionType))));
		rootNode.Add(mergedNode);
		return xdoc;
	}

	/// <summary>
	/// 获取策略拦截配置节节点
	/// </summary>
	/// <param name="configurationNode"></param>
	/// <returns></returns>
	private XElement GetPolicyInterceptionSectionNode(XElement configurationNode)
	{
		XElement configSectionNode = configurationNode.Element("configSections");
		if (configSectionNode.IsNull())
		{
			return null;
		}
		string sectionName = (from section in configSectionNode.Elements("section")
			where section.GetAttributeValue("type").ResolveType().ReferenceEquals(typeof(PolicyInterceptionSection))
			select section.GetAttributeValue("name", string.Empty)).FirstOrDefault();
		if (string.IsNullOrWhiteSpace(sectionName))
		{
			return null;
		}
		return configurationNode.Element(sectionName);
	}

	/// <summary>
	/// 合并interceptor节点
	/// </summary>
	/// <param name="mergingNode"></param>
	/// <param name="sourceNode"></param>
	/// <param name="sourceInfo"></param>
	private void MergePolicyInterceptionInterceptorNode(XElement mergingNode, XElement sourceNode, XDocumentInfo sourceInfo)
	{
		XElement source = sourceNode.Element("interceptors");
		if (source.IsNull())
		{
			return;
		}
		XElement dest = null;
		if (mergingNode.Element("interceptors").IsNull())
		{
			mergingNode.Add(new XComment(sourceInfo.FullName));
			mergingNode.Add(new XElement("interceptors"));
		}
		dest = mergingNode.Element("interceptors");
		IEnumerable<XElement> list = from node in source.Elements("interceptor")
			where (from n in dest.Elements("interceptor")
				where n.GetAttributeValue("type", string.Empty) == node.GetAttributeValue("type", string.Empty)
				select n).Count() == 0
			select node;
		if (list.Count() > 0)
		{
			dest.Add(new XComment(sourceInfo.FullName));
			dest.Add(list.Select((XElement node) => new XElement(node)).ToArray());
		}
	}

	/// <summary>
	/// 合并target节点
	/// target节点是定义的最小单位,名称/类型/方法名均不同,则认为相同
	/// </summary>
	/// <param name="mergingNode"></param>
	/// <param name="sourceNode"></param>
	/// <param name="sourceInfo"></param>
	private void MergePolicyInterceptionTargetNode(XElement mergingNode, XElement sourceNode, XDocumentInfo sourceInfo)
	{
		XElement source = sourceNode.Element("targets");
		if (source.IsNull())
		{
			return;
		}
		XElement dest = null;
		if (mergingNode.Element("targets").IsNull())
		{
			mergingNode.Add(new XComment(sourceInfo.FullName));
			mergingNode.Add(new XElement("targets"));
		}
		dest = mergingNode.Element("targets");
		IEnumerable<XElement> list = from node in source.Elements("target")
			where (from n in dest.Elements("target")
				where n.GetAttributeValue("type", string.Empty) == node.GetAttributeValue("type", string.Empty) && n.GetAttributeValue("targetName", string.Empty) == node.GetAttributeValue("targetName", string.Empty) && n.GetAttributeValue("method", string.Empty) == node.GetAttributeValue("method", string.Empty)
				select n).Count() == 0
			select node;
		if (list.Count() > 0)
		{
			dest.Add(new XComment(sourceInfo.FullName));
			dest.Add(list.Select((XElement node) => new XElement(node)).ToArray());
		}
	}
}
