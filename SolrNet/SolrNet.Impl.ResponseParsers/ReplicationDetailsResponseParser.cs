using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SolrNet.Impl.ResponseParsers;

/// <summary>
/// Parses header (status, QTime, etc) and details from a response
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class ReplicationDetailsResponseParser<T> : ISolrAbstractResponseParser<T>, ISolrReplicationDetailsResponseParser
{
	/// <summary>
	/// Header parser
	/// </summary>
	/// <param name="xml">XML</param>
	/// <param name="results">results</param>
	public void Parse(XDocument xml, AbstractSolrQueryResults<T> results)
	{
		ReplicationDetailsResponse header = Parse(xml);
		if (header != null)
		{
			results.Header = header.responseHeader;
		}
	}

	/// <summary>
	/// Parses XML response to response class
	/// </summary>
	/// <param name="response">XML</param>
	/// <returns>ReplicationDetailsResponse class</returns>
	public ReplicationDetailsResponse Parse(XDocument response)
	{
		ResponseHeader responseHeader = new ResponseHeader();
		string indexSize = string.Empty;
		string indexPath = string.Empty;
		string isMaster = string.Empty;
		string isSlave = string.Empty;
		long indexVersion = -1L;
		long generation = -1L;
		string isReplicating = null;
		string totalPercent = null;
		string timeRemaining = null;
		XElement responseHeaderNode = response.XPathSelectElement("response/lst[@name='responseHeader']");
		if (responseHeaderNode != null)
		{
			responseHeader = ParseHeader(responseHeaderNode);
			XElement responseIndexSizeNode = response.XPathSelectElement("response/lst[@name='details']/str[@name='indexSize']");
			indexSize = ((responseIndexSizeNode == null) ? string.Empty : responseIndexSizeNode.Value);
			XElement responseIndexPathNode = response.XPathSelectElement("response/lst[@name='details']/str[@name='indexPath']");
			indexPath = ((responseIndexPathNode == null) ? string.Empty : responseIndexPathNode.Value);
			XElement responseIsMasterNode = response.XPathSelectElement("response/lst[@name='details']/str[@name='isMaster']");
			isMaster = ((responseIsMasterNode == null) ? string.Empty : responseIsMasterNode.Value);
			XElement responseIsSlaveNode = response.XPathSelectElement("response/lst[@name='details']/str[@name='isSlave']");
			isSlave = ((responseIsSlaveNode == null) ? string.Empty : responseIsSlaveNode.Value);
			XElement responseIndexVersionNode = response.XPathSelectElement("response/lst[@name='details']/long[@name='indexVersion']");
			if (responseIndexVersionNode != null)
			{
				indexVersion = long.Parse(responseIndexVersionNode.Value, CultureInfo.InvariantCulture.NumberFormat);
			}
			XElement responseGenerationNode = response.XPathSelectElement("response/lst[@name='details']/long[@name='generation']");
			if (responseGenerationNode != null)
			{
				generation = long.Parse(responseGenerationNode.Value, CultureInfo.InvariantCulture.NumberFormat);
			}
			XElement responseSlaveNode = response.XPathSelectElement("response/lst[@name='details']/lst[@name='slave']");
			if (responseSlaveNode != null)
			{
				isReplicating = responseSlaveNode.XPathSelectElement("str[@name='isReplicating']")?.Value;
				if (isReplicating != null && isReplicating.ToLower() == "true")
				{
					totalPercent = responseSlaveNode.XPathSelectElement("str[@name='totalPercent']")?.Value;
					timeRemaining = responseSlaveNode.XPathSelectElement("str[@name='timeRemaining']")?.Value;
				}
			}
			return new ReplicationDetailsResponse(responseHeader, indexSize, indexPath, isMaster, isSlave, indexVersion, generation, isReplicating, totalPercent, timeRemaining);
		}
		return null;
	}

	/// <summary>
	/// Parses response header
	/// </summary>
	/// <param name="node">XML</param>
	/// <returns>ResponseHeader</returns>
	public ResponseHeader ParseHeader(XElement node)
	{
		ResponseHeader r = new ResponseHeader();
		r.Status = int.Parse(node.XPathSelectElement("int[@name='status']").Value, CultureInfo.InvariantCulture.NumberFormat);
		r.QTime = int.Parse(node.XPathSelectElement("int[@name='QTime']").Value, CultureInfo.InvariantCulture.NumberFormat);
		r.Params = new Dictionary<string, string>();
		IEnumerable<XElement> paramNodes = node.XPathSelectElements("lst[@name='params']/str");
		foreach (XElement i in paramNodes)
		{
			r.Params[i.Attribute("name").Value] = i.Value;
		}
		return r;
	}
}
