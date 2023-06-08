using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using Aspose.Cells;
using Richfit.Garnet.Common.Dynamic;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Importing.Aspose.Properties;

namespace Richfit.Garnet.Module.Importing.Aspose.Excel;

/// <summary>
/// 导入模版对象
/// </summary>
public class AsposeExcelImportTemplate : IImportTemplate
{
	/// <summary>
	/// 导入模版名称
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// 导入模版标题
	/// </summary>
	public string Title { get; set; }

	/// <summary>
	/// 导入区域起始行
	/// </summary>
	public int? StartRow { get; set; }

	/// <summary>
	/// 数据区域起始行
	/// </summary>
	public int? DataRow { get; set; }

	/// <summary>
	/// 导入区域终止行
	/// </summary>
	public int? EndRow { get; set; }

	/// <summary>
	/// 起始列
	/// </summary>
	public string StartColumn { get; set; }

	/// <summary>
	/// 终止列
	/// </summary>
	public string EndColumn { get; set; }

	/// <summary>
	/// 键项目
	/// </summary>
	public string KeyItem { get; set; }

	/// <summary>
	/// 导入模版映射类型
	/// </summary>
	public Type Type { get; set; }

	/// <summary>
	/// 导入模式
	/// </summary>
	public ImportMode Mode { get; set; }

	/// <summary>
	/// 导入模版项目列表
	/// </summary>
	public Dictionary<string, AsposeExcelImportTemplateItem> Items { get; set; }

	/// <summary>
	/// 导入的数据表
	/// </summary>
	internal Worksheet Sheet { get; set; }

	/// <summary>
	/// 起始索引
	/// </summary>
	internal int FirstRowIndex { get; set; }

	/// <summary>
	/// 起始数据行索引
	/// </summary>
	internal int FirstDataIndex { get; set; }

	/// <summary>
	/// 结束数据行索引
	/// </summary>
	internal int LastRowIndex { get; set; }

	/// <summary>
	/// 起始数据列索引
	/// </summary>
	internal int FirstColumnIndex { get; set; }

	/// <summary>
	/// 结束数据列索引
	/// </summary>
	internal int LastColumnIndex { get; set; }

	/// <summary>
	/// 数据列映射
	/// </summary>
	internal Dictionary<string, string> ColumnMap { get; private set; }

	/// <summary>
	/// 数据表解析上下文
	/// </summary>
	internal SheetResolveContext SheetResolveContext { get; private set; }

	/// <summary>
	/// 数据解析上下文
	/// </summary>
	internal ValueResolveContext ValueResolveContext { get; private set; }

	/// <summary>
	/// 数据校验上下文
	/// </summary>
	internal ValueValidateContext ValueValidateContext { get; private set; }

	/// <summary>
	/// 数据记录解析上下文
	/// </summary>
	internal RecordResolveContext RecordResolveContext { get; private set; }

	/// <summary>
	/// 数据记录校验上下文
	/// </summary>
	internal RecordValidateContext RecordValidateContext { get; private set; }

	/// <summary>
	/// 数据记录保存上下文
	/// </summary>
	internal RecordSaveContext RecordSaveContext { get; private set; }

	/// <summary>
	/// 初始化默认导入模版
	/// </summary>
	public AsposeExcelImportTemplate()
	{
		Name = string.Empty;
		Title = string.Empty;
		StartRow = null;
		DataRow = null;
		EndRow = null;
		StartColumn = string.Empty;
		EndColumn = string.Empty;
		KeyItem = string.Empty;
		Type = null;
		Mode = ImportMode.Table;
		Items = new Dictionary<string, AsposeExcelImportTemplateItem>();
		Sheet = null;
		FirstRowIndex = -1;
		FirstDataIndex = -1;
		LastRowIndex = -1;
		FirstColumnIndex = -1;
		LastColumnIndex = -1;
		ColumnMap = new Dictionary<string, string>();
		SheetResolveContext = new SheetResolveContext();
		ValueResolveContext = new ValueResolveContext();
		ValueValidateContext = new ValueValidateContext();
		RecordResolveContext = new RecordResolveContext();
		RecordValidateContext = new RecordValidateContext();
		RecordSaveContext = new RecordSaveContext();
	}

	/// <summary>
	/// 复制构造
	/// </summary>
	/// <param name="template"></param>
	public AsposeExcelImportTemplate(AsposeExcelImportTemplate template)
	{
		template.GuardNotNull();
		Name = template.Name;
		Title = template.Title;
		StartRow = template.StartRow;
		DataRow = template.DataRow;
		EndRow = template.EndRow;
		StartColumn = template.StartColumn;
		EndColumn = template.EndColumn;
		KeyItem = template.KeyItem;
		Type = template.Type;
		Mode = template.Mode;
		Items = new Dictionary<string, AsposeExcelImportTemplateItem>();
		Items.AddRange(template.Items, (KeyValuePair<string, AsposeExcelImportTemplateItem> kvp) => kvp.Key, (KeyValuePair<string, AsposeExcelImportTemplateItem> kvp) => kvp.Value.Copy());
		Sheet = template.Sheet;
		FirstRowIndex = template.FirstRowIndex;
		FirstDataIndex = template.FirstDataIndex;
		LastRowIndex = template.LastRowIndex;
		FirstColumnIndex = template.FirstColumnIndex;
		LastColumnIndex = template.LastColumnIndex;
		ColumnMap = new Dictionary<string, string>(template.ColumnMap);
		SheetResolveContext = new SheetResolveContext();
		ValueResolveContext = new ValueResolveContext();
		ValueValidateContext = new ValueValidateContext();
		RecordResolveContext = new RecordResolveContext();
		RecordValidateContext = new RecordValidateContext();
		RecordSaveContext = new RecordSaveContext();
	}

	/// <summary>
	/// 使用指定的配置数据进行初始化
	/// </summary>
	/// <param name="xmlTemplate">初始化Xml数据对象</param>
	public AsposeExcelImportTemplate(XElement xmlTemplate)
		: this()
	{
		Load(xmlTemplate);
	}

	/// <summary>
	/// 加载导入模版
	/// </summary>
	/// <param name="xmlTemplate">Xml数据对象</param>
	public void Load(XElement xmlTemplate)
	{
		xmlTemplate.GuardNotNull();
		XAttribute attribute = xmlTemplate.Attribute("name");
		Name = attribute.GuardNotNull(typeof(ConfigurationErrorsException), Literals.M_E_Template_PropertyMissing.FormatValue("", "name")).Value.Trim();
		attribute = xmlTemplate.Attribute("title");
		Title = (attribute.IsNull() ? string.Empty : attribute.Value.Trim());
		attribute = xmlTemplate.Attribute("startRow");
		StartRow = (attribute.IsNull() ? null : new int?(attribute.Value.ConvertToInt32().GuardGreaterThanOrEqualTo(1, () => new ConfigurationErrorsException(Literals.M_E_Template_PropertyError.FormatValue(Name, "startRow")))));
		attribute = xmlTemplate.Attribute("dataRow");
		DataRow = (attribute.IsNull() ? null : new int?(attribute.Value.ConvertToInt32().GuardGreaterThanOrEqualTo(1, () => new ConfigurationErrorsException(Literals.M_E_Template_PropertyError.FormatValue(Name, "dataRow")))));
		DataRow = ((!DataRow.IsNull() || !StartRow.IsNotNull()) ? DataRow : (StartRow + 1));
		attribute = xmlTemplate.Attribute("endRow");
		EndRow = (attribute.IsNull() ? null : new int?(attribute.Value.ConvertToInt32().GuardGreaterThanOrEqualTo(1, () => new ConfigurationErrorsException(Literals.M_E_Template_PropertyError.FormatValue(Name, "endRow")))));
		attribute = xmlTemplate.Attribute("startColumn");
		StartColumn = (attribute.IsNull() ? string.Empty : attribute.Value.Trim());
		attribute = xmlTemplate.Attribute("endColumn");
		EndColumn = (attribute.IsNull() ? string.Empty : attribute.Value.Trim());
		attribute = xmlTemplate.Attribute("keyItem");
		KeyItem = (attribute.IsNull() ? string.Empty : attribute.Value.Trim());
		attribute = xmlTemplate.Attribute("mode");
		Mode = ((!attribute.IsNull()) ? attribute.Value.Trim().ParseEnum<ImportMode>(ignoreCase: true) : ImportMode.Table);
		string templateItemName;
		string templateItemTitle;
		foreach (XElement item in xmlTemplate.Elements("item"))
		{
			templateItemName = item.Attribute("name").GuardNotNull(typeof(ConfigurationErrorsException), Literals.M_E_TemplateItem_PropertyMissing.FormatValue("", "name")).Value;
			templateItemTitle = (item.Attribute("title").IsNull() ? templateItemName : item.Attribute("title").Value);
			if (Items.Values.OfType<AsposeExcelImportTemplateItem>().Any((AsposeExcelImportTemplateItem x) => x.Name.EqualOrdinal(templateItemName) || x.Title.EqualOrdinal(templateItemTitle)))
			{
				throw new ConfigurationErrorsException(Literals.M_E_TemplateItem_Duplicate.FormatValue(templateItemName, templateItemTitle));
			}
			AsposeExcelImportTemplateItem templateItem = new AsposeExcelImportTemplateItem(item);
			Items.Add(templateItem.Name, templateItem);
		}
		if (!KeyItem.IsNullOrEmpty() && !Items.ContainsKey(KeyItem))
		{
			throw new ConfigurationErrorsException(Literals.M_E_Template_PropertyError.FormatValue(Name, "keyItem"));
		}
		Type = DataObject.CreateType((from x in Items.Values.OfType<AsposeExcelImportTemplateItem>()
			select new DataPropertyInfo(x.Name, x.IsSublist ? typeof(List<IDataObject>) : x.Type)).ToArray());
	}

	/// <summary>
	/// 复制当前对象
	/// </summary>
	/// <returns></returns>
	public AsposeExcelImportTemplate Copy()
	{
		return new AsposeExcelImportTemplate(this);
	}
}
