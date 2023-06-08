using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Security;
using Common.Logging;
using Quartz.Spi;

namespace Quartz.Simpl;

/// <summary>
/// Scheduler exporter that exports scheduler to remoting context.
/// </summary>
/// <author>Marko Lahma</author>
public class RemotingSchedulerExporter : ISchedulerExporter
{
	public const string ChannelTypeTcp = "tcp";

	public const string ChannelTypeHttp = "http";

	private const string DefaultBindName = "QuartzScheduler";

	private const string DefaultChannelName = "http";

	private readonly ILog log;

	private int port = -1;

	private string bindName = "QuartzScheduler";

	private string channelName = "http";

	private string channelType = "tcp";

	private TypeFilterLevel typeFilgerLevel = TypeFilterLevel.Full;

	private static readonly Dictionary<string, object> registeredChannels = new Dictionary<string, object>();

	protected virtual ILog Log => log;

	/// <summary>
	/// Gets or sets the port used for remoting.
	/// </summary>
	public virtual int Port
	{
		get
		{
			return port;
		}
		set
		{
			port = value;
		}
	}

	/// <summary>
	/// Gets or sets the name to use when exporting
	/// scheduler to remoting context.
	/// </summary>
	public virtual string BindName
	{
		get
		{
			return bindName;
		}
		set
		{
			bindName = value;
		}
	}

	/// <summary>
	/// Gets or sets the name to use when binding to 
	/// tcp channel.
	/// </summary>
	public virtual string ChannelName
	{
		get
		{
			return channelName;
		}
		set
		{
			channelName = value;
		}
	}

	/// <summary>
	/// Sets the channel type when registering remoting.
	///
	/// </summary>
	public virtual string ChannelType
	{
		get
		{
			return channelType;
		}
		set
		{
			channelType = value;
		}
	}

	/// <summary>
	/// Sets the <see cref="P:Quartz.Simpl.RemotingSchedulerExporter.TypeFilterLevel" /> used when
	/// exporting to remoting context. Defaults to
	/// <see cref="F:System.Runtime.Serialization.Formatters.TypeFilterLevel.Full" />.
	/// </summary>
	public virtual TypeFilterLevel TypeFilterLevel
	{
		get
		{
			return typeFilgerLevel;
		}
		set
		{
			typeFilgerLevel = value;
		}
	}

	public RemotingSchedulerExporter()
	{
		log = LogManager.GetLogger(GetType());
	}

	public virtual void Bind(IRemotableQuartzScheduler scheduler)
	{
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		if (!(scheduler is MarshalByRefObject))
		{
			throw new ArgumentException("Exported scheduler must be of type MarshallByRefObject", "scheduler");
		}
		RegisterRemotingChannelIfNeeded();
		try
		{
			RemotingServices.Marshal((MarshalByRefObject)scheduler, bindName);
			Log.Info(string.Format(CultureInfo.InvariantCulture, "Successfully marhalled remotable scheduler under name '{0}'", new object[1] { bindName }));
		}
		catch (RemotingException ex3)
		{
			Log.Error("RemotingException during Bind", ex3);
		}
		catch (SecurityException ex2)
		{
			Log.Error("SecurityException during Bind", ex2);
		}
		catch (Exception ex)
		{
			Log.Error("Exception during Bind", ex);
		}
	}

	/// <summary>
	/// Registers remoting channel if needed. This is determined
	/// by checking whether there is a positive value for port.
	/// </summary>
	protected virtual void RegisterRemotingChannelIfNeeded()
	{
		if (port > -1 && channelType != null)
		{
			IDictionary props = new Hashtable();
			props["port"] = port;
			props["name"] = channelName;
			BinaryServerFormatterSinkProvider formatprovider = new BinaryServerFormatterSinkProvider(props, null);
			formatprovider.TypeFilterLevel = typeFilgerLevel;
			string channelRegistrationKey = channelType + "_" + port;
			if (registeredChannels.ContainsKey(channelRegistrationKey))
			{
				Log.Warn($"Channel '{channelType}' already registered for port {port}, not registering again");
				return;
			}
			IChannel chan;
			if (channelType == "http")
			{
				chan = new HttpChannel(props, null, formatprovider);
			}
			else
			{
				if (!(channelType == "tcp"))
				{
					throw new ArgumentException("Unknown remoting channel type '" + channelType + "'");
				}
				chan = new TcpChannel(props, null, formatprovider);
			}
			Log.Info(string.Format(CultureInfo.InvariantCulture, "Registering remoting channel of type '{0}' to port ({1}) with name ({2})", new object[3]
			{
				chan.GetType(),
				port,
				chan.ChannelName
			}));
			ChannelServices.RegisterChannel(chan, ensureSecurity: false);
			registeredChannels.Add(channelRegistrationKey, new object());
			Log.Info("Remoting channel registered successfully");
		}
		else
		{
			log.Error("Cannot register remoting if port or channel type not specified");
		}
	}

	public virtual void UnBind(IRemotableQuartzScheduler scheduler)
	{
		if (scheduler == null)
		{
			throw new ArgumentNullException("scheduler");
		}
		if (!(scheduler is MarshalByRefObject))
		{
			throw new ArgumentException("Exported scheduler must be of type MarshallByRefObject", "scheduler");
		}
		try
		{
			RemotingServices.Disconnect((MarshalByRefObject)scheduler);
			Log.Info("Successfully disconnected remotable scheduler");
		}
		catch (ArgumentException ex3)
		{
			Log.Error("ArgumentException during Unbind", ex3);
		}
		catch (SecurityException ex2)
		{
			Log.Error("SecurityException during Unbind", ex2);
		}
		catch (Exception ex)
		{
			Log.Error("Exception during Unbind", ex);
		}
	}
}
