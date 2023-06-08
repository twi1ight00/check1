using System;
using System.Data;
using System.IO;
using System.Text;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// DataSet配置源对象
/// </summary>
public class DataSetConfigurationSource : FileConfigurationSource, IDataSetConfiguration, IConfiguration, IDataSetConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 数据集原始配置数据
	/// </summary>
	private string rawXml;

	/// <summary>
	/// 获取或者设置原始配置数据
	/// </summary>
	public override object RawData
	{
		get
		{
			return rawXml;
		}
		set
		{
			Text = (rawXml = (value.IsNull() ? string.Empty : value.ToString()));
		}
	}

	/// <summary>
	/// 创建扩展设置配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public DataSetConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatcher watcher)
		: base(sourceGroup, sourceName, sourceFile, watcher)
	{
		base.Encoding = Encoding.UTF8;
	}

	/// <summary>
	/// 创建扩展设置配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public DataSetConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatchingTimer timer)
		: base(sourceGroup, sourceName, sourceFile, timer)
	{
		base.Encoding = Encoding.UTF8;
	}

	/// <summary>
	/// 析构
	/// </summary>
	~DataSetConfigurationSource()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 清理对象方法
	/// </summary>
	/// <param name="disposing"></param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			rawXml = null;
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// 加载扩展设置配置
	/// </summary>
	/// <returns>如果加载成功返回true，否则返回false</returns>
	protected override bool LoadConfiguration()
	{
		try
		{
			bool status = base.LoadConfiguration();
			rawXml = Text;
			return status;
		}
		catch
		{
			throw;
		}
	}

	/// <summary>
	/// 获取配置源中定义的数据集，如果无配置数据返回空的数据集
	/// </summary>
	/// <returns>加载的数据集</returns>
	public DataSet GetDataSet()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			DataSet dataSet = new DataSet();
			FillDataSet(dataSet, fillSchema: true, XmlReadMode.InferSchema);
			return dataSet;
		});
	}

	/// <summary>
	/// 按照指定的方式从配置源中加载数据集的数据
	/// </summary>
	/// <param name="mode">数据读取模式</param>
	/// <returns>加载的数据集</returns>
	public DataSet GetDataSet(XmlReadMode mode)
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			DataSet dataSet = new DataSet();
			FillDataSet(dataSet, fillSchema: false, mode);
			return dataSet;
		});
	}

	/// <summary>
	/// 获取配置源中定义的强类型数据集，如果无配置数据返回空的数据集
	/// </summary>
	/// <typeparam name="T">数据集类型</typeparam>
	/// <returns>加载的数据集</returns>
	public T GetDataSet<T>() where T : DataSet, new()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			T val = new T();
			FillDataSet(val, fillSchema: true, XmlReadMode.InferSchema);
			return val;
		});
	}

	/// <summary>
	/// 获取配置源中定义的强类型数据集，如果无配置数据返回空的数据集
	/// </summary>
	/// <typeparam name="T">数据集类型</typeparam>
	/// <param name="mode">数据读取模式</param>
	/// <returns>加载的数据集</returns>
	public T GetDataSet<T>(XmlReadMode mode) where T : DataSet, new()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			T val = new T();
			FillDataSet(val, fillSchema: false, mode);
			return val;
		});
	}

	/// <summary>
	/// 保存数据集到配置源中
	/// </summary>
	/// <param name="ds">待保存的数据集</param>
	public void SetDataSet(DataSet ds)
	{
		ds.GuardNotNull();
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			SaveDataSet(ds, XmlWriteMode.WriteSchema);
		});
	}

	/// <summary>
	/// 保存数据集到配置源中
	/// </summary>
	/// <param name="ds">待保存的数据集</param>
	/// <param name="mode">数据写入模式</param>
	public void SetDataSet(DataSet ds, XmlWriteMode mode)
	{
		ds.GuardNotNull();
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			SaveDataSet(ds, mode);
		});
	}

	/// <summary>
	/// 获取配置源中定义的第一个数据表，如果未定义数据表则返回null
	/// </summary>
	/// <returns>配置源中定义的数据表</returns>
	public DataTable GetDataTable()
	{
		DataSet ds = GetDataSet();
		return (ds.Tables.Count > 0) ? ds.Tables[0] : null;
	}

	/// <summary>
	/// 获取配置源中定义的指定名称的数据表，如果未找到匹配的数据表则返回null
	/// </summary>
	/// <param name="name">数据表名称</param>
	/// <returns>配置源中定义的数据表</returns>
	public DataTable GetDataTable(string name)
	{
		name.GuardNotNull();
		DataSet ds = GetDataSet();
		return ds.Tables.Contains(name) ? ds.Tables[name] : null;
	}

	/// <summary>
	/// 获取配置源中定义的第一个强类型数据表
	/// </summary>
	/// <typeparam name="T">数据表类型</typeparam>
	/// <returns>配置源中定义的数据表</returns>
	public T GetDataTable<T>() where T : DataTable, new()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			T val = new T();
			FillDataTable(val);
			return val;
		});
	}

	/// <summary>
	/// 保存数据表到配置源中
	/// </summary>
	/// <param name="dt">待保存的数据表</param>
	public void SetDataTable(DataTable dt)
	{
		dt.GuardNotNull();
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			SaveDataTable(dt, XmlWriteMode.WriteSchema, inherit: false);
		});
	}

	/// <summary>
	/// 保存数据表到配置源中
	/// </summary>
	/// <param name="dt">待保存的数据表</param>
	/// <param name="mode">数据写入模式</param>
	/// <param name="inherit">是否保存子代数据表</param>
	public void SetDataTable(DataTable dt, XmlWriteMode mode, bool inherit = false)
	{
		dt.GuardNotNull();
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			SaveDataTable(dt, mode, inherit);
		});
	}

	/// <summary>
	/// 填充数据集
	/// </summary>
	/// <param name="ds"></param>
	/// <param name="fillSchema"></param>
	/// <param name="mode"></param>
	private void FillDataSet(DataSet ds, bool fillSchema, XmlReadMode mode)
	{
		if (rawXml.IsNull())
		{
			return;
		}
		if (fillSchema)
		{
			using StringReader reader2 = new StringReader(rawXml);
			ds.ReadXmlSchema(reader2);
		}
		using StringReader reader2 = new StringReader(rawXml);
		ds.ReadXml(reader2, mode);
	}

	/// <summary>
	/// 保存数据集
	/// </summary>
	/// <param name="ds"></param>
	/// <param name="mode"></param>
	private void SaveDataSet(DataSet ds, XmlWriteMode mode)
	{
		using (StringWriter writer = new StringWriter())
		{
			ds.WriteXml(writer, mode);
			rawXml = writer.ToString();
		}
		Text = rawXml;
	}

	/// <summary>
	/// 填充数据表
	/// </summary>
	/// <param name="dt"></param>
	private void FillDataTable(DataTable dt)
	{
		if (rawXml.IsNull() || dt.Columns.Count == 0)
		{
			return;
		}
		using StringReader reader = new StringReader(rawXml);
		dt.ReadXml(reader);
	}

	/// <summary>
	/// 保存数据表
	/// </summary>
	/// <param name="dt"></param>
	/// <param name="mode"></param>
	/// <param name="inherit"></param>
	private void SaveDataTable(DataTable dt, XmlWriteMode mode, bool inherit)
	{
		using (StringWriter writer = new StringWriter())
		{
			dt.WriteXml(writer, mode, inherit);
			rawXml = writer.ToString();
		}
		Text = rawXml;
	}
}
