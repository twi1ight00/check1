using System;
using System.Collections.Generic;
using SolrNet.Utils;

namespace SolrNet.Commands;

/// <summary>
/// Sends documents to solr for extraction
/// </summary>
public class ExtractCommand : ISolrCommand
{
	private readonly ExtractParameters parameters;

	public ExtractCommand(ExtractParameters parameters)
	{
		this.parameters = parameters;
	}

	public string Execute(ISolrConnection connection)
	{
		IEnumerable<KeyValuePair<string, string>> queryParameters = ConvertToQueryParameters();
		return connection.PostStream("/update/extract", parameters.StreamType, parameters.Content, queryParameters);
	}

	private IEnumerable<KeyValuePair<string, string>> ConvertToQueryParameters()
	{
		List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
		list.Add(KV.Create("literal.id", parameters.Id));
		list.Add(KV.Create("resource.name", parameters.ResourceName));
		List<KeyValuePair<string, string>> param = list;
		if (parameters.Fields != null)
		{
			foreach (ExtractField f in parameters.Fields)
			{
				if (f.FieldName == "id")
				{
					throw new ArgumentException("ExtractField named 'id' is not permitted in ExtractParameters.Fields - use ExtractParameters.Id instead");
				}
				param.Add(KV.Create("literal." + f.FieldName, f.Value));
			}
		}
		if (parameters.StreamType != null)
		{
			param.Add(KV.Create("stream.type", parameters.StreamType));
		}
		if (parameters.AutoCommit)
		{
			param.Add(KV.Create("commit", "true"));
		}
		if (!string.IsNullOrEmpty(parameters.Prefix))
		{
			param.Add(KV.Create("uprefix", parameters.Prefix));
		}
		if (!string.IsNullOrEmpty(parameters.DefaultField))
		{
			param.Add(KV.Create("defaultField", parameters.DefaultField));
		}
		if (parameters.ExtractOnly)
		{
			param.Add(KV.Create("extractOnly", "true"));
			if (parameters.ExtractFormat == ExtractFormat.Text)
			{
				param.Add(KV.Create("extractFormat", "text"));
			}
		}
		if (!string.IsNullOrEmpty(parameters.Capture))
		{
			param.Add(KV.Create("capture", parameters.Capture));
		}
		if (parameters.CaptureAttributes)
		{
			param.Add(KV.Create("captureAttr", "true"));
		}
		if (!string.IsNullOrEmpty(parameters.XPath))
		{
			param.Add(KV.Create("xpath", parameters.XPath));
		}
		if (parameters.LowerNames)
		{
			param.Add(KV.Create("lowernames", "true"));
		}
		return param;
	}
}
