using System.Xml.Linq;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// Xml配置文件XDocument对象信息
/// </summary>
internal class XDocumentInfo
{
	/// <summary>
	/// Xml文档对象
	/// </summary>
	public XDocument Document { get; set; }

	/// <summary>
	/// 文件信息
	/// </summary>
	public string FullName { get; set; }

	/// <summary>
	/// 初始化
	/// </summary>
	/// <param name="document"></param>
	/// <param name="fileName"></param>
	public XDocumentInfo(XDocument document, string fileName)
	{
		Document = document;
		FullName = fileName;
	}
}
