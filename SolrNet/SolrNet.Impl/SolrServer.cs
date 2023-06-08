using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SolrNet.Commands.Parameters;
using SolrNet.Exceptions;
using SolrNet.Mapping.Validation;
using SolrNet.Schema;

namespace SolrNet.Impl;

/// <summary>
/// Main component to interact with Solr
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class SolrServer<T> : ISolrOperations<T>, ISolrReadOnlyOperations<T>, ISolrBasicReadOnlyOperations<T>
{
	private readonly ISolrBasicOperations<T> basicServer;

	private readonly IReadOnlyMappingManager mappingManager;

	private readonly IMappingValidator _schemaMappingValidator;

	public SolrServer(ISolrBasicOperations<T> basicServer, IReadOnlyMappingManager mappingManager, IMappingValidator _schemaMappingValidator)
	{
		this.basicServer = basicServer;
		this.mappingManager = mappingManager;
		this._schemaMappingValidator = _schemaMappingValidator;
	}

	/// <summary>
	/// Executes a query
	/// </summary>
	/// <param name="query"></param>
	/// <param name="options"></param>
	/// <returns></returns>
	public SolrQueryResults<T> Query(ISolrQuery query, QueryOptions options)
	{
		return basicServer.Query(query, options);
	}

	public ResponseHeader Ping()
	{
		return basicServer.Ping();
	}

	public SolrQueryResults<T> Query(string q)
	{
		return Query(new SolrQuery(q));
	}

	/// <summary>
	/// Executes a query
	/// </summary>
	/// <param name="q"></param>
	/// <param name="orders"></param>
	/// <returns></returns>
	public SolrQueryResults<T> Query(string q, ICollection<SortOrder> orders)
	{
		return Query(new SolrQuery(q), orders);
	}

	/// <summary>
	/// Executes a query
	/// </summary>
	/// <param name="q"></param>
	/// <param name="options"></param>
	/// <returns></returns>
	public SolrQueryResults<T> Query(string q, QueryOptions options)
	{
		return basicServer.Query(new SolrQuery(q), options);
	}

	/// <summary>
	/// Executes a query
	/// </summary>
	/// <param name="q"></param>
	/// <returns></returns>
	public SolrQueryResults<T> Query(ISolrQuery q)
	{
		return Query(q, new QueryOptions());
	}

	/// <summary>
	/// Executes a query
	/// </summary>
	/// <param name="query"></param>
	/// <param name="orders"></param>
	/// <returns></returns>
	public SolrQueryResults<T> Query(ISolrQuery query, ICollection<SortOrder> orders)
	{
		return Query(query, new QueryOptions
		{
			OrderBy = orders
		});
	}

	/// <summary>
	/// Executes a facet field query only
	/// </summary>
	/// <param name="facet"></param>
	/// <returns></returns>
	public ICollection<KeyValuePair<string, int>> FacetFieldQuery(SolrFacetFieldQuery facet)
	{
		SolrQueryResults<T> r = basicServer.Query(SolrQuery.All, new QueryOptions
		{
			Rows = 0,
			Facet = new FacetParameters
			{
				Queries = new SolrFacetFieldQuery[1] { facet }
			}
		});
		return r.FacetFields[facet.Field];
	}

	public ResponseHeader BuildSpellCheckDictionary()
	{
		SolrQueryResults<T> r = basicServer.Query(SolrQuery.All, new QueryOptions
		{
			Rows = 0,
			SpellCheck = new SpellCheckingParameters
			{
				Build = true
			}
		});
		return r.Header;
	}

	public ResponseHeader AddWithBoost(T doc, double boost)
	{
		return AddWithBoost(doc, boost, null);
	}

	public ResponseHeader AddWithBoost(T doc, double boost, AddParameters parameters)
	{
		return ((ISolrOperations<T>)this).AddRangeWithBoost((IEnumerable<KeyValuePair<T, double?>>)new KeyValuePair<T, double?>[1]
		{
			new KeyValuePair<T, double?>(doc, boost)
		}, parameters);
	}

	public ExtractResponse Extract(ExtractParameters parameters)
	{
		return basicServer.Extract(parameters);
	}

	[Obsolete("Use AddRange instead")]
	public ResponseHeader Add(IEnumerable<T> docs)
	{
		return Add(docs, null);
	}

	public ResponseHeader AddRange(IEnumerable<T> docs)
	{
		return AddRange(docs, null);
	}

	[Obsolete("Use AddRange instead")]
	public ResponseHeader Add(IEnumerable<T> docs, AddParameters parameters)
	{
		return basicServer.AddWithBoost(docs.Select((T d) => new KeyValuePair<T, double?>(d, null)), parameters);
	}

	public ResponseHeader AddRange(IEnumerable<T> docs, AddParameters parameters)
	{
		return basicServer.AddWithBoost(docs.Select((T d) => new KeyValuePair<T, double?>(d, null)), parameters);
	}

	[Obsolete("Use AddRangeWithBoost instead")]
	ResponseHeader ISolrOperations<T>.AddWithBoost(IEnumerable<KeyValuePair<T, double?>> docs)
	{
		return ((ISolrOperations<T>)this).AddWithBoost(docs, (AddParameters)null);
	}

	public ResponseHeader AddRangeWithBoost(IEnumerable<KeyValuePair<T, double?>> docs)
	{
		return ((ISolrOperations<T>)this).AddRangeWithBoost(docs, (AddParameters)null);
	}

	[Obsolete("Use AddRangeWithBoost instead")]
	ResponseHeader ISolrOperations<T>.AddWithBoost(IEnumerable<KeyValuePair<T, double?>> docs, AddParameters parameters)
	{
		return basicServer.AddWithBoost(docs, parameters);
	}

	public ResponseHeader AddRangeWithBoost(IEnumerable<KeyValuePair<T, double?>> docs, AddParameters parameters)
	{
		return basicServer.AddWithBoost(docs, parameters);
	}

	public ResponseHeader Delete(IEnumerable<string> ids)
	{
		return basicServer.Delete(ids, null, null);
	}

	public ResponseHeader Delete(IEnumerable<string> ids, DeleteParameters parameters)
	{
		return basicServer.Delete(ids, null, parameters);
	}

	public ResponseHeader Delete(T doc)
	{
		return Delete(doc, null);
	}

	public ResponseHeader Delete(T doc, DeleteParameters parameters)
	{
		object id = GetId(doc);
		return Delete(id.ToString(), parameters);
	}

	public ResponseHeader Delete(IEnumerable<T> docs)
	{
		return Delete(docs, null);
	}

	public ResponseHeader Delete(IEnumerable<T> docs, DeleteParameters parameters)
	{
		return basicServer.Delete(docs.Select(delegate(T d)
		{
			SolrFieldModel uniqueKey = mappingManager.GetUniqueKey(typeof(T));
			if (uniqueKey == null)
			{
				throw new SolrNetException($"This operation requires a unique key, but type '{typeof(T)}' has no declared unique key");
			}
			return Convert.ToString(uniqueKey.Property.GetValue(d, null));
		}), null, parameters);
	}

	private object GetId(T doc)
	{
		SolrFieldModel uniqueKey = mappingManager.GetUniqueKey(typeof(T));
		if (uniqueKey == null)
		{
			throw new SolrNetException($"This operation requires a unique key, but type '{typeof(T)}' has no declared unique key");
		}
		PropertyInfo prop = uniqueKey.Property;
		return prop.GetValue(doc, null);
	}

	ResponseHeader ISolrOperations<T>.Delete(ISolrQuery q)
	{
		return basicServer.Delete(null, q, null);
	}

	public ResponseHeader Delete(ISolrQuery q, DeleteParameters parameters)
	{
		return basicServer.Delete(null, q, parameters);
	}

	public ResponseHeader Delete(string id)
	{
		return basicServer.Delete(new string[1] { id }, null, null);
	}

	public ResponseHeader Delete(string id, DeleteParameters parameters)
	{
		return basicServer.Delete(new string[1] { id }, null, parameters);
	}

	ResponseHeader ISolrOperations<T>.Delete(IEnumerable<string> ids, ISolrQuery q)
	{
		return basicServer.Delete(ids, q, null);
	}

	ResponseHeader ISolrOperations<T>.Delete(IEnumerable<string> ids, ISolrQuery q, DeleteParameters parameters)
	{
		return basicServer.Delete(ids, q, parameters);
	}

	public ResponseHeader Commit()
	{
		return basicServer.Commit(null);
	}

	/// <summary>
	/// Rollbacks all add/deletes made to the index since the last commit.
	/// </summary>
	/// <returns></returns>
	public ResponseHeader Rollback()
	{
		return basicServer.Rollback();
	}

	/// <summary>
	/// Commits posts, 
	/// blocking until index changes are flushed to disk and
	/// blocking until a new searcher is opened and registered as the main query searcher, making the changes visible.
	/// </summary>
	public ResponseHeader Optimize()
	{
		return basicServer.Optimize(null);
	}

	public ResponseHeader Add(T doc)
	{
		return Add(doc, null);
	}

	public ResponseHeader Add(T doc, AddParameters parameters)
	{
		return AddRange(new T[1] { doc }, parameters);
	}

	public SolrSchema GetSchema()
	{
		return basicServer.GetSchema("schema.xml");
	}

	public SolrSchema GetSchema(string schemaFileName)
	{
		return basicServer.GetSchema(schemaFileName);
	}

	public IEnumerable<ValidationResult> EnumerateValidationResults()
	{
		SolrSchema schema = GetSchema();
		return _schemaMappingValidator.EnumerateValidationResults(typeof(T), schema);
	}

	/// <summary>
	/// Gets the DIH Status.
	/// </summary>
	/// <param name="options">command options</param>
	/// <returns>A XmlDocument containing the DIH Status XML.</returns>
	public SolrDIHStatus GetDIHStatus(KeyValuePair<string, string> options)
	{
		return basicServer.GetDIHStatus(options);
	}

	public SolrMoreLikeThisHandlerResults<T> MoreLikeThis(SolrMLTQuery query, MoreLikeThisHandlerQueryOptions options)
	{
		return basicServer.MoreLikeThis(query, options);
	}
}
