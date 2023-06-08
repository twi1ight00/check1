using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Richfit.Garnet.Common.Dynamic;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Importing.Aspose.Properties;

namespace Richfit.Garnet.Module.Importing.Aspose.Excel;

/// <summary>
/// 导入模版项目对象
/// </summary>
public class AsposeExcelImportTemplateItem
{
	/// <summary>
	/// 项目名称
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// 项目标题
	/// </summary>
	public string Title { get; set; }

	/// <summary>
	/// 项目类型
	/// </summary>
	public Type Type { get; set; }

	/// <summary>
	/// 项目正则模式
	/// </summary>
	public Regex Pattern { get; set; }

	/// <summary>
	/// 错误提示信息
	/// </summary>
	public string ErrorMessage { get; set; }

	/// <summary>
	/// 项目是否是数据键
	/// </summary>
	public bool IsKey { get; set; }

	/// <summary>
	/// 项目自动值类型
	/// </summary>
	public AutoValueType AutoValue { get; set; }

	/// <summary>
	/// 项目值解析键
	/// </summary>
	public string ResolveKey { get; set; }

	/// <summary>
	/// 项目值解析位置
	/// </summary>
	public string ResolveRef { get; set; }

	/// <summary>
	/// 是否忽略该项目
	/// </summary>
	public bool Ignore { get; set; }

	/// <summary>
	/// 是否校验该项目
	/// </summary>
	public bool Validate { get; set; }

	/// <summary>
	/// 子项目集合
	/// </summary>
	public List<AsposeExcelImportTemplateItem> Items { get; set; }

	/// <summary>
	/// 是否是子表项目
	/// </summary>
	public bool IsSublist => Items.Count > 0;

	/// <summary>
	/// 数据列索引
	/// </summary>
	internal int TemplateColumn { get; set; }

	/// <summary>
	/// 是否匹配
	/// </summary>
	internal bool IsMatched { get; set; }

	/// <summary>
	/// 初始化默认模版项目对象
	/// </summary>
	public AsposeExcelImportTemplateItem()
	{
		Name = string.Empty;
		Title = string.Empty;
		Type = typeof(string);
		Pattern = null;
		ErrorMessage = string.Empty;
		IsKey = false;
		AutoValue = AutoValueType.Default;
		ResolveKey = string.Empty;
		ResolveRef = string.Empty;
		Ignore = false;
		Validate = true;
		Items = new List<AsposeExcelImportTemplateItem>();
		TemplateColumn = -1;
		IsMatched = false;
	}

	/// <summary>
	/// 复制构造
	/// </summary>
	/// <param name="item">待复制的对象</param>
	public AsposeExcelImportTemplateItem(AsposeExcelImportTemplateItem item)
	{
		item.GuardNotNull();
		Name = item.Name;
		Title = item.Title;
		Type = item.Type;
		Pattern = item.Pattern;
		ErrorMessage = item.ErrorMessage;
		IsKey = item.IsKey;
		AutoValue = item.AutoValue;
		ResolveKey = item.ResolveKey;
		ResolveRef = item.ResolveRef;
		Ignore = item.Ignore;
		Validate = item.Validate;
		Items = new List<AsposeExcelImportTemplateItem>();
		Items.AddRange(item.Items.Select((AsposeExcelImportTemplateItem x) => x.Copy()));
		TemplateColumn = item.TemplateColumn;
		IsMatched = item.IsMatched;
	}

	/// <summary>
	/// 使用指定的配置数据进行初始化
	/// </summary>
	/// <param name="xmlTemplateItem">Xml配置数据对象</param>
	public AsposeExcelImportTemplateItem(XElement xmlTemplateItem)
		: this()
	{
		Load(xmlTemplateItem);
	}

	/// <summary>
	/// 加载导入模版项目
	/// </summary>
	/// <param name="xmlTemplateItem">Xml数据对象</param>
	public void Load(XElement xmlTemplateItem)
	{
		LoadItem(this, xmlTemplateItem);
	}

	/// <summary>
	/// 解析导入模版项目
	/// </summary>
	/// <param name="templateItem"></param>
	/// <param name="xmlTemplateItem"></param>
	/// <returns></returns>
	private AsposeExcelImportTemplateItem LoadItem(AsposeExcelImportTemplateItem templateItem, XElement xmlTemplateItem)
	{
		xmlTemplateItem.GuardNotNull();
		templateItem = templateItem.IfNull(new AsposeExcelImportTemplateItem());
		XAttribute attribute = xmlTemplateItem.Attribute("name");
		templateItem.Name = attribute.GuardNotNull(typeof(ConfigurationErrorsException), Literals.M_E_TemplateItem_PropertyMissing.FormatValue("", "name")).Value.Trim();
		IEnumerable<XElement> subItems = xmlTemplateItem.Elements("item");
		if (subItems.Any())
		{
			string templateItemName;
			string templateItemTitle;
			foreach (XElement subItem in subItems)
			{
				templateItemName = subItem.Attribute("name").GuardNotNull(typeof(ConfigurationErrorsException), Literals.M_E_TemplateItem_PropertyMissing.FormatValue("", "name")).Value.Trim();
				templateItemTitle = (subItem.Attribute("title").IsNull() ? templateItemName : subItem.Attribute("title").Value.Trim());
				AsposeExcelImportTemplateItem subTemplateItem = LoadItem(null, subItem);
				if (Items.Any((AsposeExcelImportTemplateItem x) => x.Name.EqualOrdinal(templateItemName) || x.Title.EqualOrdinal(templateItemTitle)))
				{
					throw new ConfigurationErrorsException(Literals.M_E_TemplateItem_Duplicate.FormatValue(templateItemName, templateItemTitle));
				}
				Items.Add(subTemplateItem);
			}
			Type = DataObject.CreateType(Items.Select((AsposeExcelImportTemplateItem x) => new DataPropertyInfo(x.Name, x.IsSublist ? typeof(List<IDataObject>) : x.Type)).ToArray());
		}
		else
		{
			attribute = xmlTemplateItem.Attribute("title");
			templateItem.Title = attribute.GuardNotNull(typeof(ConfigurationErrorsException), Literals.M_E_TemplateItem_PropertyMissing.FormatValue(xmlTemplateItem.Name.LocalName, "title")).Value.Trim();
			templateItem.Title = (templateItem.Title.IsNullOrEmpty() ? templateItem.Name : templateItem.Title);
			attribute = xmlTemplateItem.Attribute("type");
			templateItem.Type = (attribute.IsNull() ? typeof(string) : attribute.Value.ResolveType().GuardNotNull(typeof(ConfigurationErrorsException), Literals.M_E_TemplateItem_TypeError.FormatValue(templateItem.Name)));
			attribute = xmlTemplateItem.Attribute("pattern");
			templateItem.Pattern = ((attribute.IsNull() || attribute.Value.IsNullOrEmpty()) ? null : attribute.Value.ToRegex());
			attribute = xmlTemplateItem.Attribute("errorMessage");
			templateItem.ErrorMessage = ((attribute.IsNull() || attribute.Value.IsNullOrEmpty()) ? string.Empty : attribute.Value.Trim());
			attribute = xmlTemplateItem.Attribute("isKey");
			templateItem.IsKey = !attribute.IsNull() && attribute.Value.ParseBoolean();
			attribute = xmlTemplateItem.Attribute("autoValue");
			templateItem.AutoValue = (attribute.IsNull() ? AutoValueType.Default : attribute.Value.ParseEnum<AutoValueType>(ignoreCase: true));
			attribute = xmlTemplateItem.Attribute("resolveKey");
			templateItem.ResolveKey = (attribute.IsNull() ? string.Empty : attribute.Value.Trim());
			attribute = xmlTemplateItem.Attribute("resolveRef");
			templateItem.ResolveRef = (attribute.IsNull() ? string.Empty : attribute.Value.Trim());
			attribute = xmlTemplateItem.Attribute("ignore");
			templateItem.Ignore = !attribute.IsNull() && attribute.Value.ParseBoolean();
			attribute = xmlTemplateItem.Attribute("validate");
			templateItem.Validate = attribute.IsNull() || attribute.Value.ParseBoolean();
		}
		return templateItem;
	}

	/// <summary>
	/// 复制当前节点
	/// </summary>
	/// <returns></returns>
	public AsposeExcelImportTemplateItem Copy()
	{
		return new AsposeExcelImportTemplateItem(this);
	}
}
