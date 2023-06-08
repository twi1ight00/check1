using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Security;
using Common.Logging;
using Quartz.Core;
using Quartz.Impl.AdoJobStore;
using Quartz.Impl.AdoJobStore.Common;
using Quartz.Impl.Matchers;
using Quartz.Simpl;
using Quartz.Spi;
using Quartz.Util;

namespace Quartz.Impl;

/// <summary>
/// An implementation of <see cref="T:Quartz.ISchedulerFactory" /> that
/// does all of it's work of creating a <see cref="T:Quartz.Core.QuartzScheduler" /> instance
/// based on the contents of a properties file.
/// </summary>
/// <remarks>
/// <para>
/// By default a properties are loaded from App.config's quartz section. 
/// If that fails, then the file is loaded "quartz.properties". If file does not exist,
/// default configration located (as a embedded resource) in Quartz.dll is loaded. If you
/// wish to use a file other than these defaults, you must define the system
/// property 'quartz.properties' to point to the file you want.
/// </para>
/// <para>
/// See the sample properties that are distributed with Quartz for
/// information about the various settings available within the file.
/// </para>
/// <para>
/// Alternativly, you can explicitly Initialize the factory by calling one of
/// the <see cref="M:Quartz.Impl.StdSchedulerFactory.Initialize" /> methods before calling <see cref="M:Quartz.Impl.StdSchedulerFactory.GetScheduler" />.
/// </para>
/// <para>
/// Instances of the specified <see cref="T:Quartz.Spi.IJobStore" />,
/// <see cref="T:Quartz.Spi.IThreadPool" />, classes will be created
/// by name, and then any additional properties specified for them in the config
/// file will be set on the instance by calling an equivalent 'set' method. For
/// example if the properties file contains the property 'quartz.jobStore.
/// myProp = 10' then after the JobStore class has been instantiated, the property
/// 'MyProp' will be set with the value. Type conversion to primitive CLR types
/// (int, long, float, double, boolean, enum and string) are performed before calling
/// the property's setter method.
/// </para>
/// </remarks>
/// <author>James House</author>
/// <author>Anthony Eden</author>
/// <author>Mohammad Rezaei</author>
/// <author>Marko Lahma (.NET)</author>
public class StdSchedulerFactory : ISchedulerFactory
{
	private const string ConfigurationKeyPrefix = "quartz.";

	public const string PropertiesFile = "quartz.config";

	public const string PropertySchedulerInstanceName = "quartz.scheduler.instanceName";

	public const string PropertySchedulerInstanceId = "quartz.scheduler.instanceId";

	public const string PropertySchedulerInstanceIdGeneratorPrefix = "quartz.scheduler.instanceIdGenerator";

	public const string PropertySchedulerInstanceIdGeneratorType = "quartz.scheduler.instanceIdGenerator.type";

	public const string PropertySchedulerThreadName = "quartz.scheduler.threadName";

	public const string PropertySchedulerBatchTimeWindow = "quartz.scheduler.batchTriggerAcquisitionFireAheadTimeWindow";

	public const string PropertySchedulerMaxBatchSize = "quartz.scheduler.batchTriggerAcquisitionMaxCount";

	public const string PropertySchedulerExporterPrefix = "quartz.scheduler.exporter";

	public const string PropertySchedulerExporterType = "quartz.scheduler.exporter.type";

	public const string PropertySchedulerProxy = "quartz.scheduler.proxy";

	public const string PropertySchedulerProxyType = "quartz.scheduler.proxy.type";

	public const string PropertySchedulerIdleWaitTime = "quartz.scheduler.idleWaitTime";

	public const string PropertySchedulerDbFailureRetryInterval = "quartz.scheduler.dbFailureRetryInterval";

	public const string PropertySchedulerMakeSchedulerThreadDaemon = "quartz.scheduler.makeSchedulerThreadDaemon";

	public const string PropertySchedulerTypeLoadHelperType = "quartz.scheduler.typeLoadHelper.type";

	public const string PropertySchedulerJobFactoryType = "quartz.scheduler.jobFactory.type";

	public const string PropertySchedulerJobFactoryPrefix = "quartz.scheduler.jobFactory";

	public const string PropertySchedulerInterruptJobsOnShutdown = "quartz.scheduler.interruptJobsOnShutdown";

	public const string PropertySchedulerInterruptJobsOnShutdownWithWait = "quartz.scheduler.interruptJobsOnShutdownWithWait";

	public const string PropertySchedulerContextPrefix = "quartz.context.key";

	public const string PropertyThreadPoolPrefix = "quartz.threadPool";

	public const string PropertyThreadPoolType = "quartz.threadPool.type";

	public const string PropertyJobStorePrefix = "quartz.jobStore";

	public const string PropertyJobStoreLockHandlerPrefix = "quartz.jobStore.lockHandler";

	public const string PropertyJobStoreLockHandlerType = "quartz.jobStore.lockHandler.type";

	public const string PropertyTablePrefix = "tablePrefix";

	public const string PropertySchedulerName = "schedName";

	public const string PropertyJobStoreType = "quartz.jobStore.type";

	public const string PropertyDataSourcePrefix = "quartz.dataSource";

	public const string PropertyDbProviderType = "connectionProvider.type";

	public const string PropertyDataSourceProvider = "provider";

	public const string PropertyDataSourceConnectionString = "connectionString";

	public const string PropertyDataSourceConnectionStringName = "connectionStringName";

	public const string PropertyPluginPrefix = "quartz.plugin";

	public const string PropertyPluginType = "type";

	public const string PropertyJobListenerPrefix = "quartz.jobListener";

	public const string PropertyTriggerListenerPrefix = "quartz.triggerListener";

	public const string PropertyListenerType = "type";

	public const string DefaultInstanceId = "NON_CLUSTERED";

	public const string PropertyCheckConfiguration = "quartz.checkConfiguration";

	public const string AutoGenerateInstanceId = "AUTO";

	public const string PropertyThreadExecutor = "quartz.threadExecutor";

	public const string PropertyThreadExecutorType = "quartz.threadExecutor.type";

	public const string PropertyObjectSerializer = "quartz.serializer";

	public const string SystemPropertyAsInstanceId = "SYS_PROP";

	private SchedulerException initException;

	private PropertiesParser cfg;

	private static readonly ILog log = LogManager.GetLogger(typeof(StdSchedulerFactory));

	private string SchedulerName => cfg.GetStringProperty("quartz.scheduler.instanceName", "QuartzScheduler");

	protected ILog Log => log;

	/// <summary> <para>
	/// Returns a handle to all known Schedulers (made by any
	/// StdSchedulerFactory instance.).
	/// </para>
	/// </summary>
	public virtual ICollection<IScheduler> AllSchedulers => SchedulerRepository.Instance.LookupAll();

	/// <summary>
	/// Returns a handle to the default Scheduler, creating it if it does not
	/// yet exist.
	/// </summary>
	/// <seealso cref="M:Quartz.Impl.StdSchedulerFactory.Initialize">
	/// </seealso>
	public static IScheduler GetDefaultScheduler()
	{
		StdSchedulerFactory fact = new StdSchedulerFactory();
		return fact.GetScheduler();
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.StdSchedulerFactory" /> class.
	/// </summary>
	public StdSchedulerFactory()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.StdSchedulerFactory" /> class.
	/// </summary>
	/// <param name="props">The props.</param>
	public StdSchedulerFactory(NameValueCollection props)
	{
		Initialize(props);
	}

	/// <summary>
	/// Initialize the <see cref="T:Quartz.ISchedulerFactory" />.
	/// </summary>
	/// <remarks>
	/// By default a properties file named "quartz.properties" is loaded from
	/// the 'current working directory'. If that fails, then the
	/// "quartz.properties" file located (as an embedded resource) in the Quartz.NET
	/// assembly is loaded. If you wish to use a file other than these defaults,
	/// you must define the system property 'quartz.properties' to point to
	/// the file you want.
	/// </remarks>
	public void Initialize()
	{
		if (cfg != null)
		{
			return;
		}
		if (initException != null)
		{
			throw initException;
		}
		NameValueCollection props = (NameValueCollection)ConfigurationManager.GetSection("quartz");
		string requestedFile = QuartzEnvironment.GetEnvironmentVariable("quartz.config");
		string propFileName = ((requestedFile != null && requestedFile.Trim().Length > 0) ? requestedFile : "~/quartz.config");
		try
		{
			propFileName = FileUtil.ResolveFile(propFileName);
		}
		catch (SecurityException)
		{
			log.WarnFormat("Unable to resolve file path '{0}' due to security exception, probably running under medium trust");
			propFileName = "quartz.config";
		}
		if (props == null && File.Exists(propFileName))
		{
			try
			{
				PropertiesParser pp2 = PropertiesParser.ReadFromFileResource(propFileName);
				props = pp2.UnderlyingProperties;
				Log.Info($"Quartz.NET properties loaded from configuration file '{propFileName}'");
			}
			catch (Exception ex2)
			{
				Log.Error("Could not load properties for Quartz from file {0}: {1}".FormatInvariant(propFileName, ex2.Message), ex2);
			}
		}
		if (props == null)
		{
			try
			{
				PropertiesParser pp = PropertiesParser.ReadFromEmbeddedAssemblyResource("Quartz.quartz.config");
				props = pp.UnderlyingProperties;
				Log.Info("Default Quartz.NET properties loaded from embedded resource file");
			}
			catch (Exception ex)
			{
				Log.Error("Could not load default properties for Quartz from Quartz assembly: {0}".FormatInvariant(ex.Message), ex);
			}
		}
		if (props == null)
		{
			throw new SchedulerConfigException("Could not find <quartz> configuration section from your application config or load default configuration from assembly.\r\nPlease add configuration to your application config file to correctly initialize Quartz.");
		}
		Initialize(OverrideWithSysProps(props));
	}

	/// <summary>
	/// Creates a new name value collection and overrides its values
	/// with system values (environment variables).
	/// </summary>
	/// <param name="props">The base properties to override.</param>
	/// <returns>A new NameValueCollection instance.</returns>
	private static NameValueCollection OverrideWithSysProps(NameValueCollection props)
	{
		NameValueCollection retValue = new NameValueCollection(props);
		IDictionary<string, string> vars = QuartzEnvironment.GetEnvironmentVariables();
		foreach (string key in vars.Keys)
		{
			retValue.Set(key, vars[key]);
		}
		return retValue;
	}

	/// <summary> 
	/// Initialize the <see cref="T:Quartz.ISchedulerFactory" /> with
	/// the contents of the given key value collection object.
	/// </summary>
	public virtual void Initialize(NameValueCollection props)
	{
		cfg = new PropertiesParser(props);
		ValidateConfiguration();
	}

	protected virtual void ValidateConfiguration()
	{
		if (!cfg.GetBooleanProperty("quartz.checkConfiguration", defaultValue: true))
		{
			return;
		}
		List<string> supportedKeys = new List<string>();
		List<FieldInfo> fields = new List<FieldInfo>(GetType().GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy));
		fields = fields.FindAll((FieldInfo field) => field.FieldType == typeof(string));
		foreach (FieldInfo field2 in fields)
		{
			string value = (string)field2.GetValue(null);
			if (value != null && value.StartsWith("quartz.") && value != "quartz.")
			{
				supportedKeys.Add(value);
			}
		}
		string[] allKeys = cfg.UnderlyingProperties.AllKeys;
		foreach (string configurationKey in allKeys)
		{
			if (!configurationKey.StartsWith("quartz."))
			{
				continue;
			}
			bool isMatch = false;
			foreach (string supportedKey in supportedKeys)
			{
				if (configurationKey.StartsWith(supportedKey, StringComparison.InvariantCulture))
				{
					isMatch = true;
					break;
				}
			}
			if (!isMatch)
			{
				throw new SchedulerConfigException("Unknown configuration property '" + configurationKey + "'");
			}
		}
	}

	/// <summary>  </summary>
	private IScheduler Instantiate()
	{
		if (cfg == null)
		{
			Initialize();
		}
		if (initException != null)
		{
			throw initException;
		}
		ISchedulerExporter exporter = null;
		QuartzScheduler qs = null;
		IDbConnectionManager dbMgr = null;
		Type instanceIdGeneratorType = null;
		bool autoId = false;
		TimeSpan idleWaitTime = TimeSpan.Zero;
		TimeSpan dbFailureRetry = TimeSpan.FromSeconds(15.0);
		SchedulerRepository schedRep = SchedulerRepository.Instance;
		string schedName = cfg.GetStringProperty("quartz.scheduler.instanceName", "QuartzScheduler");
		string threadName = cfg.GetStringProperty("quartz.scheduler.threadName", "{0}_QuartzSchedulerThread".FormatInvariant(schedName));
		string schedInstId = cfg.GetStringProperty("quartz.scheduler.instanceId", "NON_CLUSTERED");
		if (schedInstId.Equals("AUTO"))
		{
			autoId = true;
			instanceIdGeneratorType = LoadType(cfg.GetStringProperty("quartz.scheduler.instanceIdGenerator.type")) ?? typeof(SimpleInstanceIdGenerator);
		}
		else if (schedInstId.Equals("SYS_PROP"))
		{
			autoId = true;
			instanceIdGeneratorType = typeof(SystemPropertyInstanceIdGenerator);
		}
		Type typeLoadHelperType = LoadType(cfg.GetStringProperty("quartz.scheduler.typeLoadHelper.type"));
		Type jobFactoryType = LoadType(cfg.GetStringProperty("quartz.scheduler.jobFactory.type", null));
		idleWaitTime = cfg.GetTimeSpanProperty("quartz.scheduler.idleWaitTime", idleWaitTime);
		if (idleWaitTime > TimeSpan.Zero && idleWaitTime < TimeSpan.FromMilliseconds(1000.0))
		{
			throw new SchedulerException("quartz.scheduler.idleWaitTime of less than 1000ms is not legal.");
		}
		dbFailureRetry = cfg.GetTimeSpanProperty("quartz.scheduler.dbFailureRetryInterval", dbFailureRetry);
		if (dbFailureRetry < TimeSpan.Zero)
		{
			throw new SchedulerException("quartz.scheduler.dbFailureRetryInterval of less than 0 ms is not legal.");
		}
		bool makeSchedulerThreadDaemon = cfg.GetBooleanProperty("quartz.scheduler.makeSchedulerThreadDaemon");
		long batchTimeWindow = cfg.GetLongProperty("quartz.scheduler.batchTriggerAcquisitionFireAheadTimeWindow", 0L);
		int maxBatchSize = cfg.GetIntProperty("quartz.scheduler.batchTriggerAcquisitionMaxCount", 1);
		bool interruptJobsOnShutdown = cfg.GetBooleanProperty("quartz.scheduler.interruptJobsOnShutdown", defaultValue: false);
		bool interruptJobsOnShutdownWithWait = cfg.GetBooleanProperty("quartz.scheduler.interruptJobsOnShutdownWithWait", defaultValue: false);
		NameValueCollection schedCtxtProps = cfg.GetPropertyGroup("quartz.context.key", stripPrefix: true);
		bool proxyScheduler = cfg.GetBooleanProperty("quartz.scheduler.proxy", defaultValue: false);
		ITypeLoadHelper loadHelper;
		try
		{
			loadHelper = ObjectUtils.InstantiateType<ITypeLoadHelper>(typeLoadHelperType ?? typeof(SimpleTypeLoadHelper));
		}
		catch (Exception e25)
		{
			throw new SchedulerConfigException("Unable to instantiate type load helper: {0}".FormatInvariant(e25.Message), e25);
		}
		loadHelper.Initialize();
		if (proxyScheduler)
		{
			if (autoId)
			{
				schedInstId = "NON_CLUSTERED";
			}
			Type proxyType = loadHelper.LoadType(cfg.GetStringProperty("quartz.scheduler.proxy.type")) ?? typeof(RemotingSchedulerProxyFactory);
			IRemotableSchedulerProxyFactory factory;
			try
			{
				factory = ObjectUtils.InstantiateType<IRemotableSchedulerProxyFactory>(proxyType);
				ObjectUtils.SetObjectProperties(factory, cfg.GetPropertyGroup("quartz.scheduler.proxy", stripPrefix: true));
			}
			catch (Exception e24)
			{
				initException = new SchedulerException("Remotable proxy factory '{0}' could not be instantiated.".FormatInvariant(proxyType), e24);
				throw initException;
			}
			string uid = QuartzSchedulerResources.GetUniqueIdentifier(schedName, schedInstId);
			RemoteScheduler remoteScheduler = new RemoteScheduler(uid, factory);
			schedRep.Bind(remoteScheduler);
			return remoteScheduler;
		}
		IJobFactory jobFactory = null;
		NameValueCollection tProps;
		if (jobFactoryType != null)
		{
			try
			{
				jobFactory = ObjectUtils.InstantiateType<IJobFactory>(jobFactoryType);
			}
			catch (Exception e23)
			{
				throw new SchedulerConfigException("Unable to Instantiate JobFactory: {0}".FormatInvariant(e23.Message), e23);
			}
			tProps = cfg.GetPropertyGroup("quartz.scheduler.jobFactory", stripPrefix: true);
			try
			{
				ObjectUtils.SetObjectProperties(jobFactory, tProps);
			}
			catch (Exception e22)
			{
				initException = new SchedulerException("JobFactory of type '{0}' props could not be configured.".FormatInvariant(jobFactoryType), e22);
				throw initException;
			}
		}
		IInstanceIdGenerator instanceIdGenerator = null;
		if (instanceIdGeneratorType != null)
		{
			try
			{
				instanceIdGenerator = ObjectUtils.InstantiateType<IInstanceIdGenerator>(instanceIdGeneratorType);
			}
			catch (Exception e21)
			{
				throw new SchedulerConfigException("Unable to Instantiate InstanceIdGenerator: {0}".FormatInvariant(e21.Message), e21);
			}
			tProps = cfg.GetPropertyGroup("quartz.scheduler.instanceIdGenerator", stripPrefix: true);
			try
			{
				ObjectUtils.SetObjectProperties(instanceIdGenerator, tProps);
			}
			catch (Exception e20)
			{
				initException = new SchedulerException("InstanceIdGenerator of type '{0}' props could not be configured.".FormatInvariant(instanceIdGeneratorType), e20);
				throw initException;
			}
		}
		Type tpType = loadHelper.LoadType(cfg.GetStringProperty("quartz.threadPool.type")) ?? typeof(SimpleThreadPool);
		IThreadPool tp;
		try
		{
			tp = ObjectUtils.InstantiateType<IThreadPool>(tpType);
		}
		catch (Exception e19)
		{
			initException = new SchedulerException("ThreadPool type '{0}' could not be instantiated.".FormatInvariant(tpType), e19);
			throw initException;
		}
		tProps = cfg.GetPropertyGroup("quartz.threadPool", stripPrefix: true);
		try
		{
			ObjectUtils.SetObjectProperties(tp, tProps);
		}
		catch (Exception e18)
		{
			initException = new SchedulerException("ThreadPool type '{0}' props could not be configured.".FormatInvariant(tpType), e18);
			throw initException;
		}
		IList<string> dsNames = cfg.GetPropertyGroups("quartz.dataSource");
		foreach (string dataSourceName in dsNames)
		{
			string datasourceKey = "{0}.{1}".FormatInvariant("quartz.dataSource", dataSourceName);
			NameValueCollection propertyGroup = cfg.GetPropertyGroup(datasourceKey, stripPrefix: true);
			PropertiesParser pp2 = new PropertiesParser(propertyGroup);
			Type cpType = loadHelper.LoadType(pp2.GetStringProperty("connectionProvider.type", null));
			if (cpType != null)
			{
				IDbProvider cp;
				try
				{
					cp = ObjectUtils.InstantiateType<IDbProvider>(cpType);
				}
				catch (Exception e17)
				{
					initException = new SchedulerException("ConnectionProvider of type '{0}' could not be instantiated.".FormatInvariant(cpType), e17);
					throw initException;
				}
				try
				{
					pp2.UnderlyingProperties.Remove("connectionProvider.type");
					ObjectUtils.SetObjectProperties(cp, pp2.UnderlyingProperties);
					cp.Initialize();
				}
				catch (Exception e16)
				{
					initException = new SchedulerException("ConnectionProvider type '{0}' props could not be configured.".FormatInvariant(cpType), e16);
					throw initException;
				}
				dbMgr = DBConnectionManager.Instance;
				dbMgr.AddConnectionProvider(dataSourceName, cp);
				continue;
			}
			string dsProvider = pp2.GetStringProperty("provider", null);
			string dsConnectionString = pp2.GetStringProperty("connectionString", null);
			string dsConnectionStringName = pp2.GetStringProperty("connectionStringName", null);
			if (dsConnectionString == null && !string.IsNullOrEmpty(dsConnectionStringName))
			{
				ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[dsConnectionStringName];
				if (connectionStringSettings == null)
				{
					initException = new SchedulerException("Named connection string '{0}' not found for DataSource: {1}".FormatInvariant(dsConnectionStringName, dataSourceName));
					throw initException;
				}
				dsConnectionString = connectionStringSettings.ConnectionString;
			}
			if (dsProvider == null)
			{
				initException = new SchedulerException("Provider not specified for DataSource: {0}".FormatInvariant(dataSourceName));
				throw initException;
			}
			if (dsConnectionString == null)
			{
				initException = new SchedulerException("Connection string not specified for DataSource: {0}".FormatInvariant(dataSourceName));
				throw initException;
			}
			try
			{
				DbProvider dbp = new DbProvider(dsProvider, dsConnectionString);
				dbp.Initialize();
				dbMgr = DBConnectionManager.Instance;
				dbMgr.AddConnectionProvider(dataSourceName, dbp);
			}
			catch (Exception exception)
			{
				initException = new SchedulerException("Could not Initialize DataSource: {0}".FormatInvariant(dataSourceName), exception);
				throw initException;
			}
		}
		string objectSerializerType = cfg.GetStringProperty("quartz.serializer.type");
		IObjectSerializer objectSerializer;
		if (objectSerializerType != null)
		{
			tProps = cfg.GetPropertyGroup("quartz.serializer", stripPrefix: true);
			try
			{
				objectSerializer = ObjectUtils.InstantiateType<IObjectSerializer>(loadHelper.LoadType(objectSerializerType));
				log.Info("Using custom implementation for object serializer: " + objectSerializerType);
				ObjectUtils.SetObjectProperties(objectSerializer, tProps);
			}
			catch (Exception e15)
			{
				initException = new SchedulerException("Object serializer type '" + objectSerializerType + "' could not be instantiated.", e15);
				throw initException;
			}
		}
		else
		{
			log.Info("Using default implementation for object serializer");
			objectSerializer = new DefaultObjectSerializer();
		}
		Type jsType = loadHelper.LoadType(cfg.GetStringProperty("quartz.jobStore.type"));
		IJobStore js;
		try
		{
			js = ObjectUtils.InstantiateType<IJobStore>(jsType ?? typeof(RAMJobStore));
		}
		catch (Exception e14)
		{
			initException = new SchedulerException("JobStore of type '{0}' could not be instantiated.".FormatInvariant(jsType), e14);
			throw initException;
		}
		SchedulerDetailsSetter.SetDetails(js, schedName, schedInstId);
		tProps = cfg.GetPropertyGroup("quartz.jobStore", stripPrefix: true, new string[1] { "quartz.jobStore.lockHandler" });
		try
		{
			ObjectUtils.SetObjectProperties(js, tProps);
		}
		catch (Exception e13)
		{
			initException = new SchedulerException("JobStore type '{0}' props could not be configured.".FormatInvariant(jsType), e13);
			throw initException;
		}
		if (js is JobStoreSupport)
		{
			Type lockHandlerType = loadHelper.LoadType(cfg.GetStringProperty("quartz.jobStore.lockHandler.type"));
			if (lockHandlerType != null)
			{
				try
				{
					ConstructorInfo cWithDbProvider = lockHandlerType.GetConstructor(new Type[1] { typeof(DbProvider) });
					ISemaphore lockHandler;
					if (cWithDbProvider != null)
					{
						IDbProvider dbProvider = DBConnectionManager.Instance.GetDbProvider(((JobStoreSupport)js).DataSource);
						lockHandler = (ISemaphore)cWithDbProvider.Invoke(new object[1] { dbProvider });
					}
					else
					{
						lockHandler = ObjectUtils.InstantiateType<ISemaphore>(lockHandlerType);
					}
					tProps = cfg.GetPropertyGroup("quartz.jobStore.lockHandler", stripPrefix: true);
					if (lockHandler is ITablePrefixAware)
					{
						tProps["tablePrefix"] = ((JobStoreSupport)js).TablePrefix;
						tProps["schedName"] = schedName;
					}
					try
					{
						ObjectUtils.SetObjectProperties(lockHandler, tProps);
					}
					catch (Exception e12)
					{
						initException = new SchedulerException("JobStore LockHandler type '{0}' props could not be configured.".FormatInvariant(lockHandlerType), e12);
						throw initException;
					}
					((JobStoreSupport)js).LockHandler = lockHandler;
					Log.Info("Using custom data access locking (synchronization): " + lockHandlerType);
				}
				catch (Exception e11)
				{
					initException = new SchedulerException("JobStore LockHandler type '{0}' could not be instantiated.".FormatInvariant(lockHandlerType), e11);
					throw initException;
				}
			}
		}
		IList<string> pluginNames = cfg.GetPropertyGroups("quartz.plugin");
		ISchedulerPlugin[] plugins = new ISchedulerPlugin[pluginNames.Count];
		for (int l = 0; l < pluginNames.Count; l++)
		{
			NameValueCollection pp = cfg.GetPropertyGroup("{0}.{1}".FormatInvariant("quartz.plugin", pluginNames[l]), stripPrefix: true);
			string plugInType = pp["type"];
			if (plugInType == null)
			{
				initException = new SchedulerException("SchedulerPlugin type not specified for plugin '{0}'".FormatInvariant(pluginNames[l]));
				throw initException;
			}
			ISchedulerPlugin plugin;
			try
			{
				plugin = ObjectUtils.InstantiateType<ISchedulerPlugin>(LoadType(plugInType));
			}
			catch (Exception e2)
			{
				initException = new SchedulerException("SchedulerPlugin of type '{0}' could not be instantiated.".FormatInvariant(plugInType), e2);
				throw initException;
			}
			try
			{
				ObjectUtils.SetObjectProperties(plugin, pp);
			}
			catch (Exception e)
			{
				initException = new SchedulerException("JobStore SchedulerPlugin '{0}' props could not be configured.".FormatInvariant(plugInType), e);
				throw initException;
			}
			plugins[l] = plugin;
		}
		IList<string> jobListenerNames = cfg.GetPropertyGroups("quartz.jobListener");
		IJobListener[] jobListeners = new IJobListener[jobListenerNames.Count];
		for (int k = 0; k < jobListenerNames.Count; k++)
		{
			NameValueCollection lp = cfg.GetPropertyGroup("{0}.{1}".FormatInvariant("quartz.jobListener", jobListenerNames[k]), stripPrefix: true);
			string listenerType = lp["type"];
			if (listenerType == null)
			{
				initException = new SchedulerException("JobListener type not specified for listener '{0}'".FormatInvariant(jobListenerNames[k]));
				throw initException;
			}
			IJobListener listener;
			try
			{
				listener = ObjectUtils.InstantiateType<IJobListener>(loadHelper.LoadType(listenerType));
			}
			catch (Exception e4)
			{
				initException = new SchedulerException("JobListener of type '{0}' could not be instantiated.".FormatInvariant(listenerType), e4);
				throw initException;
			}
			try
			{
				PropertyInfo nameProperty = listener.GetType().GetProperty("Name", BindingFlags.Instance | BindingFlags.Public);
				if (nameProperty != null && nameProperty.CanWrite)
				{
					nameProperty.GetSetMethod().Invoke(listener, new object[1] { jobListenerNames[k] });
				}
				ObjectUtils.SetObjectProperties(listener, lp);
			}
			catch (Exception e3)
			{
				initException = new SchedulerException("JobListener '{0}' props could not be configured.".FormatInvariant(listenerType), e3);
				throw initException;
			}
			jobListeners[k] = listener;
		}
		IList<string> triggerListenerNames = cfg.GetPropertyGroups("quartz.triggerListener");
		ITriggerListener[] triggerListeners = new ITriggerListener[triggerListenerNames.Count];
		for (int j = 0; j < triggerListenerNames.Count; j++)
		{
			NameValueCollection lp2 = cfg.GetPropertyGroup("{0}.{1}".FormatInvariant("quartz.triggerListener", triggerListenerNames[j]), stripPrefix: true);
			string listenerType2 = lp2["type"];
			if (listenerType2 == null)
			{
				initException = new SchedulerException("TriggerListener type not specified for listener '{0}'".FormatInvariant(triggerListenerNames[j]));
				throw initException;
			}
			ITriggerListener listener2;
			try
			{
				listener2 = ObjectUtils.InstantiateType<ITriggerListener>(loadHelper.LoadType(listenerType2));
			}
			catch (Exception e6)
			{
				initException = new SchedulerException("TriggerListener of type '{0}' could not be instantiated.".FormatInvariant(listenerType2), e6);
				throw initException;
			}
			try
			{
				PropertyInfo nameProperty2 = listener2.GetType().GetProperty("Name", BindingFlags.Instance | BindingFlags.Public);
				if (nameProperty2 != null && nameProperty2.CanWrite)
				{
					nameProperty2.GetSetMethod().Invoke(listener2, new object[1] { triggerListenerNames[j] });
				}
				ObjectUtils.SetObjectProperties(listener2, lp2);
			}
			catch (Exception e5)
			{
				initException = new SchedulerException("TriggerListener '{0}' props could not be configured.".FormatInvariant(listenerType2), e5);
				throw initException;
			}
			triggerListeners[j] = listener2;
		}
		string exporterType = cfg.GetStringProperty("quartz.scheduler.exporter.type", null);
		if (exporterType != null)
		{
			try
			{
				exporter = ObjectUtils.InstantiateType<ISchedulerExporter>(loadHelper.LoadType(exporterType));
			}
			catch (Exception e10)
			{
				initException = new SchedulerException("Scheduler exporter of type '{0}' could not be instantiated.".FormatInvariant(exporterType), e10);
				throw initException;
			}
			tProps = cfg.GetPropertyGroup("quartz.scheduler.exporter", stripPrefix: true);
			try
			{
				ObjectUtils.SetObjectProperties(exporter, tProps);
			}
			catch (Exception e9)
			{
				initException = new SchedulerException("Scheduler exporter type '{0}' props could not be configured.".FormatInvariant(exporterType), e9);
				throw initException;
			}
		}
		bool tpInited = false;
		bool qsInited = false;
		string threadExecutorClass = cfg.GetStringProperty("quartz.threadExecutor.type");
		IThreadExecutor threadExecutor;
		if (threadExecutorClass != null)
		{
			tProps = cfg.GetPropertyGroup("quartz.threadExecutor", stripPrefix: true);
			try
			{
				threadExecutor = ObjectUtils.InstantiateType<IThreadExecutor>(loadHelper.LoadType(threadExecutorClass));
				log.Info("Using custom implementation for ThreadExecutor: " + threadExecutorClass);
				ObjectUtils.SetObjectProperties(threadExecutor, tProps);
			}
			catch (Exception e8)
			{
				initException = new SchedulerException("ThreadExecutor class '" + threadExecutorClass + "' could not be instantiated.", e8);
				throw initException;
			}
		}
		else
		{
			log.Info("Using default implementation for ThreadExecutor");
			threadExecutor = new DefaultThreadExecutor();
		}
		try
		{
			IJobRunShellFactory jrsf = new StdJobRunShellFactory();
			if (autoId)
			{
				try
				{
					schedInstId = "NON_CLUSTERED";
					if (js.Clustered)
					{
						schedInstId = instanceIdGenerator.GenerateInstanceId();
					}
				}
				catch (Exception e7)
				{
					Log.Error("Couldn't generate instance Id!", e7);
					throw new SystemException("Cannot run without an instance id.");
				}
			}
			if (js is JobStoreSupport)
			{
				JobStoreSupport jjs = (JobStoreSupport)js;
				jjs.DbRetryInterval = dbFailureRetry;
				jjs.ThreadExecutor = threadExecutor;
				jjs.ObjectSerializer = objectSerializer;
			}
			QuartzSchedulerResources rsrcs = new QuartzSchedulerResources();
			rsrcs.Name = schedName;
			rsrcs.ThreadName = threadName;
			rsrcs.InstanceId = schedInstId;
			rsrcs.JobRunShellFactory = jrsf;
			rsrcs.MakeSchedulerThreadDaemon = makeSchedulerThreadDaemon;
			rsrcs.BatchTimeWindow = TimeSpan.FromMilliseconds(batchTimeWindow);
			rsrcs.MaxBatchSize = maxBatchSize;
			rsrcs.InterruptJobsOnShutdown = interruptJobsOnShutdown;
			rsrcs.InterruptJobsOnShutdownWithWait = interruptJobsOnShutdownWithWait;
			rsrcs.SchedulerExporter = exporter;
			SchedulerDetailsSetter.SetDetails(tp, schedName, schedInstId);
			rsrcs.ThreadExecutor = threadExecutor;
			threadExecutor.Initialize();
			rsrcs.ThreadPool = tp;
			if (tp is SimpleThreadPool)
			{
				((SimpleThreadPool)tp).ThreadNamePrefix = schedName + "_Worker";
			}
			tp.Initialize();
			tpInited = true;
			rsrcs.JobStore = js;
			ISchedulerPlugin[] array = plugins;
			foreach (ISchedulerPlugin plugin2 in array)
			{
				rsrcs.AddSchedulerPlugin(plugin2);
			}
			qs = new QuartzScheduler(rsrcs, idleWaitTime, dbFailureRetry);
			qsInited = true;
			IScheduler sched = Instantiate(rsrcs, qs);
			if (jobFactory != null)
			{
				qs.JobFactory = jobFactory;
			}
			for (int i = 0; i < plugins.Length; i++)
			{
				plugins[i].Initialize(pluginNames[i], sched);
			}
			IJobListener[] array2 = jobListeners;
			foreach (IJobListener listener3 in array2)
			{
				qs.ListenerManager.AddJobListener(listener3, EverythingMatcher<JobKey>.AllJobs());
			}
			ITriggerListener[] array3 = triggerListeners;
			foreach (ITriggerListener listener4 in array3)
			{
				qs.ListenerManager.AddTriggerListener(listener4, EverythingMatcher<TriggerKey>.AllTriggers());
			}
			foreach (string key in schedCtxtProps)
			{
				string val = schedCtxtProps.Get(key);
				sched.Context.Put(key, val);
			}
			js.InstanceId = schedInstId;
			js.InstanceName = schedName;
			js.ThreadPoolSize = tp.PoolSize;
			js.Initialize(loadHelper, qs.SchedulerSignaler);
			jrsf.Initialize(sched);
			qs.Initialize();
			Log.Info("Quartz scheduler '{0}' initialized".FormatInvariant(sched.SchedulerName));
			Log.Info("Quartz scheduler version: {0}".FormatInvariant(qs.Version));
			qs.AddNoGCObject(schedRep);
			if (dbMgr != null)
			{
				qs.AddNoGCObject(dbMgr);
			}
			schedRep.Bind(sched);
			return sched;
		}
		catch (SchedulerException)
		{
			if (qsInited)
			{
				qs.Shutdown(waitForJobsToComplete: false);
			}
			else if (tpInited)
			{
				tp.Shutdown(waitForJobsToComplete: false);
			}
			throw;
		}
		catch
		{
			if (qsInited)
			{
				qs.Shutdown(waitForJobsToComplete: false);
			}
			else if (tpInited)
			{
				tp.Shutdown(waitForJobsToComplete: false);
			}
			throw;
		}
	}

	protected virtual IScheduler Instantiate(QuartzSchedulerResources rsrcs, QuartzScheduler qs)
	{
		return new StdScheduler(qs);
	}

	/// <summary>
	/// Needed while loadhelper is not constructed.
	/// </summary>
	/// <param name="typeName"></param>
	/// <returns></returns>
	protected virtual Type LoadType(string typeName)
	{
		if (string.IsNullOrEmpty(typeName))
		{
			return null;
		}
		return Type.GetType(typeName, throwOnError: true);
	}

	/// <summary>
	/// Returns a handle to the Scheduler produced by this factory.
	/// </summary>
	/// <remarks>
	/// If one of the <see cref="M:Quartz.Impl.StdSchedulerFactory.Initialize" /> methods has not be previously
	/// called, then the default (no-arg) <see cref="M:Quartz.Impl.StdSchedulerFactory.Initialize" /> method
	/// will be called by this method.
	/// </remarks>
	public virtual IScheduler GetScheduler()
	{
		if (cfg == null)
		{
			Initialize();
		}
		SchedulerRepository schedRep = SchedulerRepository.Instance;
		IScheduler sched = schedRep.Lookup(SchedulerName);
		if (sched != null)
		{
			if (!sched.IsShutdown)
			{
				return sched;
			}
			schedRep.Remove(SchedulerName);
		}
		return Instantiate();
	}

	/// <summary> <para>
	/// Returns a handle to the Scheduler with the given name, if it exists (if
	/// it has already been instantiated).
	/// </para>
	/// </summary>
	public virtual IScheduler GetScheduler(string schedName)
	{
		return SchedulerRepository.Instance.Lookup(schedName);
	}
}
