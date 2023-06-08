using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using SolrNet.Commands.Parameters;
using SolrNet.Utils;

namespace SolrNet.Commands;

/// <summary>
/// Deletes document(s), either by id or by query
/// </summary>
public class DeleteCommand : ISolrCommand
{
	private readonly DeleteByIdAndOrQueryParam deleteParam;

	private readonly DeleteParameters parameters;

	/// <summary>
	/// Deprecated in Solr 1.3
	/// </summary>
	public bool? FromPending { get; set; }

	/// <summary>
	/// Deprecated in Solr 1.3
	/// </summary>
	public bool? FromCommitted { get; set; }

	public DeleteCommand(DeleteByIdAndOrQueryParam deleteParam, DeleteParameters parameters)
	{
		this.deleteParam = deleteParam;
		this.parameters = parameters;
	}

	public string Execute(ISolrConnection connection)
	{
		XElement deleteNode = new XElement("delete");
		if (parameters != null && parameters.CommitWithin.HasValue)
		{
			XAttribute attr = new XAttribute("commitWithin", parameters.CommitWithin.Value.ToString(CultureInfo.InvariantCulture));
			deleteNode.Add(attr);
		}
		KeyValuePair<bool?, string>[] param = new KeyValuePair<bool?, string>[2]
		{
			KV.Create(FromPending, "fromPending"),
			KV.Create(FromCommitted, "fromCommitted")
		};
		KeyValuePair<bool?, string>[] array = param;
		for (int i = 0; i < array.Length; i++)
		{
			KeyValuePair<bool?, string> p = array[i];
			if (p.Key.HasValue)
			{
				XAttribute att = new XAttribute(p.Value, p.Key.Value.ToString().ToLower());
				deleteNode.Add(att);
			}
		}
		deleteNode.Add(deleteParam.ToXmlNode().ToArray());
		return connection.Post("/update", deleteNode.ToString(SaveOptions.DisableFormatting));
	}
}
