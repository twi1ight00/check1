using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using SolrNet.Impl;
using SolrNet.Impl.DocumentPropertyVisitors;
using SolrNet.Impl.FacetQuerySerializers;
using SolrNet.Impl.FieldParsers;
using SolrNet.Impl.FieldSerializers;
using SolrNet.Impl.QuerySerializers;
using SolrNet.Impl.ResponseParsers;
using SolrNet.Mapping;
using SolrNet.Mapping.Validation;
using SolrNet.Mapping.Validation.Rules;
using SolrNet.Schema;
using SolrNet.Utils;

namespace SolrNet;

/// <summary>
/// SolrNet initialization manager
/// </summary>
public static class Startup
{
	public static readonly Container Container;

	static Startup()
	{
		Container = new Container();
		InitContainer();
	}

	public static void InitContainer()
	{
		ServiceLocator.SetLocatorProvider(() => Container);
		Container.Clear();
		MemoizingMappingManager mapper = new MemoizingMappingManager(new AttributesMappingManager());
		Container.Register((Converter<IContainer, IReadOnlyMappingManager>)((IContainer c) => mapper));
		DefaultFieldParser fieldParser = new DefaultFieldParser();
		Container.Register((Converter<IContainer, ISolrFieldParser>)((IContainer c) => fieldParser));
		DefaultFieldSerializer fieldSerializer = new DefaultFieldSerializer();
		Container.Register((Converter<IContainer, ISolrFieldSerializer>)((IContainer c) => fieldSerializer));
		Container.Register((Converter<IContainer, ISolrQuerySerializer>)((IContainer c) => new DefaultQuerySerializer(c.GetInstance<ISolrFieldSerializer>())));
		Container.Register((Converter<IContainer, ISolrFacetQuerySerializer>)((IContainer c) => new DefaultFacetQuerySerializer(c.GetInstance<ISolrQuerySerializer>(), c.GetInstance<ISolrFieldSerializer>())));
		Container.Register((Converter<IContainer, ISolrDocumentPropertyVisitor>)((IContainer c) => new DefaultDocumentVisitor(c.GetInstance<IReadOnlyMappingManager>(), c.GetInstance<ISolrFieldParser>())));
		SolrSchemaParser solrSchemaParser = new SolrSchemaParser();
		Container.Register((Converter<IContainer, ISolrSchemaParser>)((IContainer c) => solrSchemaParser));
		SolrDIHStatusParser solrDIHStatusParser = new SolrDIHStatusParser();
		Container.Register((Converter<IContainer, ISolrDIHStatusParser>)((IContainer c) => solrDIHStatusParser));
		HeaderResponseParser<string> headerParser = new HeaderResponseParser<string>();
		Container.Register((Converter<IContainer, ISolrHeaderResponseParser>)((IContainer c) => headerParser));
		ExtractResponseParser extractResponseParser = new ExtractResponseParser(headerParser);
		Container.Register((Converter<IContainer, ISolrExtractResponseParser>)((IContainer c) => extractResponseParser));
		Container.Register(typeof(MappedPropertiesIsInSolrSchemaRule).FullName, (Converter<IContainer, IValidationRule>)((IContainer c) => new MappedPropertiesIsInSolrSchemaRule()));
		Container.Register(typeof(RequiredFieldsAreMappedRule).FullName, (Converter<IContainer, IValidationRule>)((IContainer c) => new RequiredFieldsAreMappedRule()));
		Container.Register(typeof(UniqueKeyMatchesMappingRule).FullName, (Converter<IContainer, IValidationRule>)((IContainer c) => new UniqueKeyMatchesMappingRule()));
		Container.Register(typeof(MultivaluedMappedToCollectionRule).FullName, (Converter<IContainer, IValidationRule>)((IContainer c) => new MultivaluedMappedToCollectionRule()));
		Container.Register((Converter<IContainer, IMappingValidator>)((IContainer c) => new MappingValidator(c.GetInstance<IReadOnlyMappingManager>(), c.GetAllInstances<IValidationRule>().ToArray())));
		Container.Register((Converter<IContainer, ISolrStatusResponseParser>)((IContainer c) => new SolrStatusResponseParser()));
	}

	/// <summary>
	/// Initializes SolrNet with the built-in container
	/// </summary>
	/// <typeparam name="T">Document type</typeparam>
	/// <param name="serverURL">Solr URL (i.e. "http://10.22.143.153:8983/solr")</param>
	public static void Init<T>(string serverURL, string userName, string password)
	{
		SolrConnection connection = new SolrConnection(serverURL, userName, password);
		Init<T>(connection);
	}

	/// <summary>
	/// Initializes SolrNet with the built-in container
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="connection"></param>
	public static void Init<T>(ISolrConnection connection)
	{
		string connectionKey = $"{typeof(SolrConnection)}.{typeof(T)}.{connection.GetType()}";
		Container.Register(connectionKey, (IContainer c) => connection);
		SolrDocumentActivator<T> activator = new SolrDocumentActivator<T>();
		Container.Register((Converter<IContainer, ISolrDocumentActivator<T>>)((IContainer c) => activator));
		Container.Register(ChooseDocumentResponseParser<T>);
		Container.Register((Converter<IContainer, ISolrAbstractResponseParser<T>>)((IContainer c) => new DefaultResponseParser<T>(c.GetInstance<ISolrDocumentResponseParser<T>>())));
		Container.Register((Converter<IContainer, ISolrMoreLikeThisHandlerQueryResultsParser<T>>)((IContainer c) => new SolrMoreLikeThisHandlerQueryResultsParser<T>(c.GetAllInstances<ISolrAbstractResponseParser<T>>().ToArray())));
		Container.Register((Converter<IContainer, ISolrQueryExecuter<T>>)((IContainer c) => new SolrQueryExecuter<T>(c.GetInstance<ISolrAbstractResponseParser<T>>(), connection, c.GetInstance<ISolrQuerySerializer>(), c.GetInstance<ISolrFacetQuerySerializer>(), c.GetInstance<ISolrMoreLikeThisHandlerQueryResultsParser<T>>())));
		Container.Register(ChooseDocumentSerializer<T>);
		Container.Register((Converter<IContainer, ISolrBasicOperations<T>>)((IContainer c) => new SolrBasicServer<T>(connection, c.GetInstance<ISolrQueryExecuter<T>>(), c.GetInstance<ISolrDocumentSerializer<T>>(), c.GetInstance<ISolrSchemaParser>(), c.GetInstance<ISolrHeaderResponseParser>(), c.GetInstance<ISolrQuerySerializer>(), c.GetInstance<ISolrDIHStatusParser>(), c.GetInstance<ISolrExtractResponseParser>())));
		Container.Register((Converter<IContainer, ISolrBasicReadOnlyOperations<T>>)((IContainer c) => new SolrBasicServer<T>(connection, c.GetInstance<ISolrQueryExecuter<T>>(), c.GetInstance<ISolrDocumentSerializer<T>>(), c.GetInstance<ISolrSchemaParser>(), c.GetInstance<ISolrHeaderResponseParser>(), c.GetInstance<ISolrQuerySerializer>(), c.GetInstance<ISolrDIHStatusParser>(), c.GetInstance<ISolrExtractResponseParser>())));
		Container.Register((Converter<IContainer, ISolrOperations<T>>)((IContainer c) => new SolrServer<T>(c.GetInstance<ISolrBasicOperations<T>>(), Container.GetInstance<IReadOnlyMappingManager>(), Container.GetInstance<IMappingValidator>())));
		Container.Register((Converter<IContainer, ISolrReadOnlyOperations<T>>)((IContainer c) => new SolrServer<T>(c.GetInstance<ISolrBasicOperations<T>>(), Container.GetInstance<IReadOnlyMappingManager>(), Container.GetInstance<IMappingValidator>())));
		string coreAdminKey = typeof(ISolrCoreAdmin).Name + connectionKey;
		Container.Register(coreAdminKey, (Converter<IContainer, ISolrCoreAdmin>)((IContainer c) => new SolrCoreAdmin(connection, c.GetInstance<ISolrHeaderResponseParser>(), c.GetInstance<ISolrStatusResponseParser>())));
	}

	private static ISolrDocumentSerializer<T> ChooseDocumentSerializer<T>(IServiceLocator c)
	{
		if (typeof(T) == typeof(Dictionary<string, object>))
		{
			return (ISolrDocumentSerializer<T>)new SolrDictionarySerializer(c.GetInstance<ISolrFieldSerializer>());
		}
		return new SolrDocumentSerializer<T>(c.GetInstance<IReadOnlyMappingManager>(), c.GetInstance<ISolrFieldSerializer>());
	}

	private static ISolrDocumentResponseParser<T> ChooseDocumentResponseParser<T>(IServiceLocator c)
	{
		if (typeof(T) == typeof(Dictionary<string, object>))
		{
			return (ISolrDocumentResponseParser<T>)new SolrDictionaryDocumentResponseParser(c.GetInstance<ISolrFieldParser>());
		}
		return new SolrDocumentResponseParser<T>(c.GetInstance<IReadOnlyMappingManager>(), c.GetInstance<ISolrDocumentPropertyVisitor>(), c.GetInstance<ISolrDocumentActivator<T>>());
	}
}
