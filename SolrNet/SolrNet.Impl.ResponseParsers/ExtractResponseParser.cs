using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using SolrNet.Utils;

namespace SolrNet.Impl.ResponseParsers;

public class ExtractResponseParser : ISolrExtractResponseParser
{
	private readonly ISolrHeaderResponseParser headerResponseParser;

	public ExtractResponseParser(ISolrHeaderResponseParser headerResponseParser)
	{
		this.headerResponseParser = headerResponseParser;
	}

	public ExtractResponse Parse(XDocument response)
	{
		ResponseHeader responseHeader = headerResponseParser.Parse(response);
		XElement contentNode = response.Element("response").Element("str");
		ExtractResponse extractResponse2 = new ExtractResponse(responseHeader);
		extractResponse2.Content = contentNode?.Value;
		ExtractResponse extractResponse = extractResponse2;
		extractResponse.Metadata = ParseMetadata(response);
		return extractResponse;
	}

	/// Metadata looks like this:
	/// <response>
	///     <lst name="null_metadata">
	///         <arr name="stream_source_info">
	///             <null />
	///         </arr>
	///         <arr name="nbTab">
	///             <str>10</str>
	///         </arr>
	///         <arr name="date">
	///             <str>2009-06-24T15:25:00</str>
	///         </arr>
	///     </lst>
	/// </response>
	private List<ExtractField> ParseMetadata(XDocument response)
	{
		IEnumerable<XElement> metadataElements = response.Element("response").Elements("lst").Where(X.AttrEq("name", "null_metadata"))
			.SelectMany((XElement x) => x.Elements("att"));
		List<ExtractField> metadata = new List<ExtractField>(metadataElements.Count());
		foreach (XElement node in metadataElements)
		{
			XAttribute nameAttrib = node.Attribute("name");
			if (nameAttrib == null)
			{
				throw new NotSupportedException("Metadata node has no name attribute: " + node);
			}
			XElement stringValue = node.Element("str");
			string fieldValue;
			if (stringValue != null)
			{
				fieldValue = stringValue.Value;
			}
			else
			{
				if (node.Element("null") == null)
				{
					throw new NotSupportedException("No support for metadata element type: " + node);
				}
				fieldValue = null;
			}
			metadata.Add(new ExtractField(nameAttrib.Value, fieldValue));
		}
		return metadata;
	}
}
