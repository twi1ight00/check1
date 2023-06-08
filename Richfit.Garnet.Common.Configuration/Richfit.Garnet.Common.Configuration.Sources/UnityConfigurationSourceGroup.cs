using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Practices.Unity.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 容器配置源集合
/// </summary>
public class UnityConfigurationSourceGroup : ConfigurationSourceGroup, IUnityGroupConfiguration, IConfiguration, IUnityGroupConfigurationSource, IGroupConfigurationSource, IRefreshableConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// Unity配置节
	/// </summary>
	private UnityConfigurationSection section;

	/// <summary>
	/// Unity配置节类型名称
	/// </summary>
	private readonly string unityConfigurationSectionType = typeof(UnityConfigurationSection).AssemblyQualifiedName;

	/// <summary>
	/// Unity配置节名称
	/// </summary>
	private readonly string unityConfigurationSectionName = "unity";

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
	public UnityConfigurationSourceGroup(IConfigurationSourceGroup group, bool recursive = false)
		: base(group, recursive)
	{
		LoadUnityConfigurationSection();
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
		return source is IUnityConfiguration;
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
	/// 获取Unity配置节
	/// </summary>
	/// <returns></returns>
	public UnityConfigurationSection GetConfiguration()
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
			LoadUnityConfigurationSection();
			base.GroupID = Guid.NewGuid();
		});
	}

	/// <summary>
	/// 加载Unity配置
	/// </summary>
	private void LoadUnityConfigurationSection()
	{
		Dictionary<IUnityConfigurationSource, XDocumentInfo> sourceMapping = new Dictionary<IUnityConfigurationSource, XDocumentInfo>();
		IConfigurationSource[] array = GetSources();
		for (int i = 0; i < array.Length; i++)
		{
			IUnityConfigurationSource source = (IUnityConfigurationSource)array[i];
			IFileConfigurationSource fileSource = (IFileConfigurationSource)source;
			XDocument xdoc = XDocument.Parse(fileSource.RawData.ToString());
			sourceMapping.Add(source, new XDocumentInfo(xdoc, fileSource.FullName));
		}
		XDocument document = MergeUnityConfiguration(sourceMapping);
		string tempFile = Path.GetTempFileName();
		document.Save(tempFile);
		ExeConfigurationFileMap exeConfigurationFileMap = new ExeConfigurationFileMap();
		exeConfigurationFileMap.ExeConfigFilename = tempFile;
		System.Configuration.Configuration unityConfiguration = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap, ConfigurationUserLevel.None);
		section = unityConfiguration.GetFirstSection<UnityConfigurationSection>();
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
	/// 合并Unity容器配置
	/// </summary>
	/// <param name="sourceMapping">配置源信息映射</param>
	/// <returns>合并后的Unity配置</returns>
	private XDocument MergeUnityConfiguration(Dictionary<IUnityConfigurationSource, XDocumentInfo> sourceMapping)
	{
		XElement mergedUnityNode = new XElement(unityConfigurationSectionName);
		foreach (XDocumentInfo doc in sourceMapping.Values)
		{
			XElement sourceUnityNode = null;
			XElement configurationNode = doc.Document.Element("configuration");
			if (!configurationNode.IsNull() && !(sourceUnityNode = GetUnitySectionNode(configurationNode)).IsNull())
			{
				MergeUnitySectionExtensionNode(mergedUnityNode, sourceUnityNode, doc);
				MergeUnityAliasNode(mergedUnityNode, sourceUnityNode, doc);
				MergeUnityAssemblyNode(mergedUnityNode, sourceUnityNode, doc);
				MergeUnityNamespaceNode(mergedUnityNode, sourceUnityNode, doc);
				MergeUnityContainerNode(mergedUnityNode, sourceUnityNode, doc);
			}
		}
		XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
		XElement rootNode = new XElement("configuration");
		xdoc.Add(rootNode);
		rootNode.Add(new XElement("configSections", new XElement("section", new XAttribute("name", unityConfigurationSectionName), new XAttribute("type", unityConfigurationSectionType))));
		rootNode.Add(mergedUnityNode);
		return xdoc;
	}

	/// <summary>
	/// 获取Unity配置节节点
	/// </summary>
	/// <param name="configurationNode">配置文件根节点</param>
	/// <returns>Unity配置节点</returns>
	private XElement GetUnitySectionNode(XElement configurationNode)
	{
		XElement configSectionNode = configurationNode.Element("configSections");
		if (configSectionNode.IsNull())
		{
			return null;
		}
		string sectionName = (from section in configSectionNode.Elements("section")
			where section.GetAttributeValue("type").ResolveType().ReferenceEquals(typeof(UnityConfigurationSection))
			select section.GetAttributeValue("name", string.Empty)).FirstOrDefault();
		if (string.IsNullOrWhiteSpace(sectionName))
		{
			return null;
		}
		string sectionFullName = $"{{http://schemas.microsoft.com/practices/2010/unity}}{sectionName}";
		return configurationNode.Element(sectionName) ?? configurationNode.Element(sectionFullName);
	}

	/// <summary>
	/// 合并namespace节点
	/// </summary>
	/// <param name="mergingUnityNode"></param>
	/// <param name="sourceUnityNode"></param>
	/// <param name="sourceInfo"></param>
	private void MergeUnityNamespaceNode(XElement mergingUnityNode, XElement sourceUnityNode, XDocumentInfo sourceInfo)
	{
		IEnumerable<XElement> list = from node in sourceUnityNode.Elements("namespace")
			where (from n in mergingUnityNode.Elements("namespace")
				where n.GetAttributeValue("name", string.Empty).EqualOrdinal(node.GetAttributeValue("name", string.Empty))
				select n).Count() == 0
			select node;
		if (list.Count() > 0)
		{
			mergingUnityNode.Add(new XComment(sourceInfo.FullName));
			mergingUnityNode.Add(list.Select((XElement node) => new XElement(node)).ToArray());
		}
	}

	/// <summary>
	/// 合并assembly节点
	/// </summary>
	/// <param name="mergingUnityNode"></param>
	/// <param name="sourceUnityNode"></param>
	/// <param name="sourceInfo"></param>
	private void MergeUnityAssemblyNode(XElement mergingUnityNode, XElement sourceUnityNode, XDocumentInfo sourceInfo)
	{
		IEnumerable<XElement> list = from node in sourceUnityNode.Elements("assembly")
			where (from n in mergingUnityNode.Elements("assembly")
				where n.GetAttributeValue("name", string.Empty).EqualOrdinal(node.GetAttributeValue("name", string.Empty))
				select n).Count() == 0
			select node;
		if (list.Count() > 0)
		{
			mergingUnityNode.Add(new XComment(sourceInfo.FullName));
			mergingUnityNode.Add(list.Select((XElement node) => new XElement(node)).ToArray());
		}
	}

	/// <summary>
	/// 合并sectionExtension节点
	/// </summary>
	/// <param name="mergingUnityNode"></param>
	/// <param name="sourceUnityNode"></param>
	/// <param name="sourceInfo"></param>
	private void MergeUnitySectionExtensionNode(XElement mergingUnityNode, XElement sourceUnityNode, XDocumentInfo sourceInfo)
	{
		IEnumerable<XElement> list = from node in sourceUnityNode.Elements("sectionExtension")
			where (from n in mergingUnityNode.Elements("sectionExtension")
				where n.GetAttributeValue("type").ResolveType().ReferenceEquals(node.GetAttributeValue("type").ResolveType()) && n.GetAttributeValue("prefix", string.Empty).EqualOrdinal(node.GetAttributeValue("prefix", string.Empty))
				select n).Count() == 0
			select node;
		if (list.Count() > 0)
		{
			mergingUnityNode.Add(new XComment(sourceInfo.FullName));
			mergingUnityNode.Add(list.Select((XElement node) => new XElement(node)).ToArray());
		}
	}

	/// <summary>
	/// 合并alias节点
	/// </summary>
	/// <param name="mergingUnityNode"></param>
	/// <param name="sourceUnityNode"></param>
	/// <param name="sourceInfo"></param>
	private void MergeUnityAliasNode(XElement mergingUnityNode, XElement sourceUnityNode, XDocumentInfo sourceInfo)
	{
		IEnumerable<XElement> list = from node in sourceUnityNode.Elements("alias")
			where (from n in mergingUnityNode.Elements("alias")
				where n.GetAttributeValue("alias", string.Empty).EqualOrdinal(node.GetAttributeValue("alias", string.Empty))
				select n).Count() == 0
			select node;
		if (list.Count() > 0)
		{
			mergingUnityNode.Add(new XComment(sourceInfo.FullName));
			mergingUnityNode.Add(list.Select((XElement node) => new XElement(node)).ToArray());
		}
	}

	/// <summary>
	/// 合并container节点
	/// </summary>
	/// <param name="mergingUnityNode"></param>
	/// <param name="sourceUnityNode"></param>
	/// <param name="sourceInfo"></param>
	private void MergeUnityContainerNode(XElement mergingUnityNode, XElement sourceUnityNode, XDocumentInfo sourceInfo)
	{
		sourceUnityNode.Elements("container").All(delegate(XElement sourceContainer)
		{
			IEnumerable<XElement> source = from node in mergingUnityNode.Elements("container")
				where node.GetAttributeValue("name", string.Empty).EqualOrdinal(sourceContainer.GetAttributeValue("name", string.Empty))
				select node;
			if (source.Count() == 0)
			{
				mergingUnityNode.Add(new XComment(sourceInfo.FullName));
				mergingUnityNode.Add(new XElement(sourceContainer));
			}
			else
			{
				source.All(delegate(XElement mergingContainer)
				{
					MergeUnityContainerExtensionNode(mergingContainer, sourceContainer, sourceInfo);
					MergeUnityContainerRegisterNode(mergingContainer, sourceContainer, sourceInfo);
					MergeUnityContainerInstanceNode(mergingContainer, sourceContainer, sourceInfo);
					MergeUnityContainerInterceptionNode(mergingContainer, sourceContainer, sourceInfo);
					return true;
				});
			}
			return true;
		});
	}

	/// <summary>
	/// 合并container\extension
	/// 需要首先对container节点进行合并
	/// </summary>
	/// <param name="mergingContainerNode"></param>
	/// <param name="sourceContainerNode"></param>
	/// <param name="sourceInfo"></param>
	private void MergeUnityContainerExtensionNode(XElement mergingContainerNode, XElement sourceContainerNode, XDocumentInfo sourceInfo)
	{
		IEnumerable<XElement> list = from node in sourceContainerNode.Elements("extension")
			where (from n in mergingContainerNode.Elements("extension")
				where n.GetAttributeValue("type", string.Empty).EqualOrdinal(node.GetAttributeValue("type", string.Empty))
				select n).Count() == 0
			select node;
		if (list.Count() > 0)
		{
			mergingContainerNode.Add(new XComment(sourceInfo.FullName));
			mergingContainerNode.Add(list.Select((XElement node) => new XElement(node)).ToArray());
		}
	}

	/// <summary>
	/// 合并container\register
	/// </summary>
	/// <param name="mergingContainerNode"></param>
	/// <param name="sourceContainerNode"></param>
	/// <param name="sourceInfo"></param>
	private void MergeUnityContainerRegisterNode(XElement mergingContainerNode, XElement sourceContainerNode, XDocumentInfo sourceInfo)
	{
		IEnumerable<XElement> list = from node in sourceContainerNode.Elements("register")
			where (from n in mergingContainerNode.Elements("register")
				where n.GetAttributeValue("type", string.Empty).EqualOrdinal(node.GetAttributeValue("type", string.Empty)) && n.GetAttributeValue("name", string.Empty).EqualOrdinal(node.GetAttributeValue("name", string.Empty)) && n.GetAttributeValue("mapTo", string.Empty).EqualOrdinal(node.GetAttributeValue("mapTo", string.Empty))
				select n).Count() == 0
			select node;
		if (list.Count() > 0)
		{
			mergingContainerNode.Add(new XComment(sourceInfo.FullName));
			mergingContainerNode.Add(list.Select((XElement node) => new XElement(node)).ToArray());
		}
	}

	/// <summary>
	/// 合并container/instance
	/// </summary>
	/// <param name="mergingContainerNode"></param>
	/// <param name="sourceContainerNode"></param>
	/// <param name="sourceInfo"></param>
	private void MergeUnityContainerInstanceNode(XElement mergingContainerNode, XElement sourceContainerNode, XDocumentInfo sourceInfo)
	{
		IEnumerable<XElement> list = from node in sourceContainerNode.Elements("instance")
			where (from n in mergingContainerNode.Elements("instance")
				where n.GetAttributeValue("type", string.Empty).EqualOrdinal(node.GetAttributeValue("type", string.Empty)) && n.GetAttributeValue("name", string.Empty).EqualOrdinal(node.GetAttributeValue("name", string.Empty))
				select n).Count() == 0
			select node;
		if (list.Count() > 0)
		{
			mergingContainerNode.Add(new XComment(sourceInfo.FullName));
			mergingContainerNode.Add(list.Select((XElement node) => new XElement(node)).ToArray());
		}
	}

	/// <summary>
	/// 合并container/interception
	/// </summary>
	/// <param name="mergingContainerNode"></param>
	/// <param name="sourceContainerNode"></param>
	/// <param name="sourceInfo"></param>
	private void MergeUnityContainerInterceptionNode(XElement mergingContainerNode, XElement sourceContainerNode, XDocumentInfo sourceInfo)
	{
		XElement sourceInterceptionNode = sourceContainerNode.Element("interception");
		XElement mergingInterceptionNode = mergingContainerNode.Element("interception");
		if (sourceInterceptionNode != null)
		{
			if (mergingInterceptionNode == null)
			{
				mergingContainerNode.Add(new XComment(sourceInfo.FullName));
				mergingContainerNode.Add(new XElement(sourceInterceptionNode));
			}
			else
			{
				MergeUnityContainerInterceptionPolicyNode(mergingInterceptionNode, sourceInterceptionNode, sourceInfo);
			}
		}
	}

	/// <summary>
	/// 合并container/interception/policy
	/// </summary>
	/// <param name="mergingInterceptionNode"></param>
	/// <param name="sourceInterceptionNode"></param>
	/// <param name="sourceInfo"></param>
	private void MergeUnityContainerInterceptionPolicyNode(XElement mergingInterceptionNode, XElement sourceInterceptionNode, XDocumentInfo sourceInfo)
	{
		IEnumerable<XElement> list = from node in sourceInterceptionNode.Elements("policy")
			where (from n in mergingInterceptionNode.Elements("policy")
				where n.GetAttributeValue("name", string.Empty).EqualOrdinal(node.GetAttributeValue("name", string.Empty))
				select n).Count() == 0
			select node;
		if (list.Count() > 0)
		{
			mergingInterceptionNode.Add(new XComment(sourceInfo.FullName));
			mergingInterceptionNode.Add(list.Select((XElement node) => new XElement(node)).ToArray());
		}
	}
}
