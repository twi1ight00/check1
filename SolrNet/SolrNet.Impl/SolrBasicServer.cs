using System.Collections.Generic;
using System.Xml.Linq;
using SolrNet.Commands;
using SolrNet.Commands.Parameters;
using SolrNet.Schema;

namespace SolrNet.Impl;

/// <summary>
/// Implements the basic Solr operations
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class SolrBasicServer<T> : ISolrBasicOperations<T>, ISolrBasicReadOnlyOperations<T>
{
	private readonly ISolrConnection connection;

	private readonly ISolrQueryExecuter<T> queryExecuter;

	private readonly ISolrDocumentSerializer<T> documentSerializer;

	private readonly ISolrSchemaParser schemaParser;

	private readonly ISolrHeaderResponseParser headerParser;

	private readonly ISolrQuerySerializer querySerializer;

	private readonly ISolrDIHStatusParser dihStatusParser;

	private readonly ISolrExtractResponseParser extractResponseParser;

	public SolrBasicServer(ISolrConnection connection, ISolrQueryExecuter<T> queryExecuter, ISolrDocumentSerializer<T> documentSerializer, ISolrSchemaParser schemaParser, ISolrHeaderResponseParser headerParser, ISolrQuerySerializer querySerializer, ISolrDIHStatusParser dihStatusParser, ISolrExtractResponseParser extractResponseParser)
	{
		this.connection = connection;
		this.extractResponseParser = extractResponseParser;
		this.queryExecuter = queryExecuter;
		this.documentSerializer = documentSerializer;
		this.schemaParser = schemaParser;
		this.headerParser = headerParser;
		this.querySerializer = querySerializer;
		this.dihStatusParser = dihStatusParser;
	}

	public ResponseHeader Commit(CommitOptions options)
	{
		options = options ?? new CommitOptions();
		CommitCommand commitCommand = new CommitCommand();
		commitCommand.WaitFlush = options.WaitFlush;
		commitCommand.WaitSearcher = options.WaitSearcher;
		commitCommand.ExpungeDeletes = options.ExpungeDeletes;
		commitCommand.MaxSegments = options.MaxSegments;
		CommitCommand cmd = commitCommand;
		return SendAndParseHeader(cmd);
	}

	public ResponseHeader Optimize(CommitOptions options)
	{
		options = options ?? new CommitOptions();
		OptimizeCommand optimizeCommand = new OptimizeCommand();
		optimizeCommand.WaitFlush = options.WaitFlush;
		optimizeCommand.WaitSearcher = options.WaitSearcher;
		optimizeCommand.ExpungeDeletes = options.ExpungeDeletes;
		optimizeCommand.MaxSegments = options.MaxSegments;
		OptimizeCommand cmd = optimizeCommand;
		return SendAndParseHeader(cmd);
	}

	public ResponseHeader Rollback()
	{
		return SendAndParseHeader(new RollbackCommand());
	}

	public ResponseHeader AddWithBoost(IEnumerable<KeyValuePair<T, double?>> docs, AddParameters parameters)
	{
		AddCommand<T> cmd = new AddCommand<T>(docs, documentSerializer, parameters);
		return SendAndParseHeader(cmd);
	}

	public ExtractResponse Extract(ExtractParameters parameters)
	{
		ExtractCommand cmd = new ExtractCommand(parameters);
		return SendAndParseExtract(cmd);
	}

	public ResponseHeader Delete(IEnumerable<string> ids, ISolrQuery q, DeleteParameters parameters)
	{
		DeleteCommand delete = new DeleteCommand(new DeleteByIdAndOrQueryParam(ids, q, querySerializer), parameters);
		return SendAndParseHeader(delete);
	}

	public ResponseHeader Delete(IEnumerable<string> ids, ISolrQuery q)
	{
		DeleteCommand delete = new DeleteCommand(new DeleteByIdAndOrQueryParam(ids, q, querySerializer), null);
		return SendAndParseHeader(delete);
	}

	public SolrQueryResults<T> Query(ISolrQuery query, QueryOptions options)
	{
		return queryExecuter.Execute(query, options);
	}

	public string Send(ISolrCommand cmd)
	{
		return cmd.Execute(connection);
	}

	public ExtractResponse SendAndParseExtract(ISolrCommand cmd)
	{
		string r = Send(cmd);
		XDocument xml = XDocument.Parse(r);
		return extractResponseParser.Parse(xml);
	}

	public ResponseHeader SendAndParseHeader(ISolrCommand cmd)
	{
		string r = Send(cmd);
		XDocument xml = XDocument.Parse(r);
		return headerParser.Parse(xml);
	}

	public ResponseHeader Ping()
	{
		return SendAndParseHeader(new PingCommand());
	}

	public SolrSchema GetSchema(string schemaFileName)
	{
		string schemaXml = connection.Get("/admin/file", new KeyValuePair<string, string>[1]
		{
			new KeyValuePair<string, string>("file", schemaFileName)
		});
		XDocument schema = XDocument.Parse(schemaXml);
		return schemaParser.Parse(schema);
	}

	public SolrDIHStatus GetDIHStatus(KeyValuePair<string, string> options)
	{
		string response = connection.Get("/dataimport", null);
		XDocument dihstatus = XDocument.Parse(response);
		return dihStatusParser.Parse(dihstatus);
	}

	public SolrMoreLikeThisHandlerResults<T> MoreLikeThis(SolrMLTQuery query, MoreLikeThisHandlerQueryOptions options)
	{
		return queryExecuter.Execute(query, options);
	}
}
