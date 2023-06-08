using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Runtime.InteropServices;
using Oracle.DataAccess.Types;

namespace Oracle.DataAccess.Client;

[TypeConverter("Oracle.VsDevTools.OracleVSGOracleParameterTypeConverter, Oracle.VsDevTools, Version=4.112.3.0, Culture=neutral, PublicKeyToken=89b483f429c47342, processorArchitecture=X86")]
public sealed class OracleParameter : DbParameter, IDisposable, ICloneable
{
	private const int MaxOraDbType = 133;

	private const int MinOraDbType = 101;

	private const int DataThresholdSizeForCLOB = 4000;

	private const int DataThresholdSizeForBLOB = 4000;

	internal const byte MaxScale = 127;

	internal const sbyte MinScale = -84;

	internal const byte InvalidPrecision = 100;

	internal const byte InvalidScale = 129;

	internal const int InvalidSize = -1;

	internal unsafe OpoPrmValCtx* m_pOpoPrmValCtx;

	internal string m_paramName;

	private string m_sourceColumn;

	private DataRowVersion m_sourceVersion;

	private DbType m_dbType;

	internal OracleDbType m_oraDbType;

	internal bool m_bOracleDbTypeExSet;

	private int m_maxSize;

	private int[] m_maxArrayBindSize;

	private bool m_nullable;

	private object m_value;

	internal ParameterDirection m_direction;

	private OracleParameterStatus m_status;

	private OracleParameterStatus[] m_arrayBindStatus;

	internal PrmEnumType m_enumType;

	private int m_offset;

	private byte m_precision;

	private byte m_scale;

	internal object[] m_saveValue;

	private int m_curSize;

	private int[] m_curArrayBindSize;

	private int m_arrBindCount;

	private bool m_bArrayBind;

	private OracleCollectionType m_collType;

	internal bool m_disposed;

	internal bool m_modified;

	internal OracleParameterCollection m_collRef;

	private int m_bindElemCount;

	private IntPtr m_pDataBuffer;

	private bool m_bSetDbType;

	private bool m_redirected;

	private bool m_sourceColumnNullMapping;

	private string m_udtTypeName;

	private bool m_modifedAfterBind;

	private OracleUdtDescriptor m_udtDescriptor;

	internal string m_commandText = string.Empty;

	internal string m_paramPosOrName = string.Empty;

	internal bool m_bReturnDateTimeOffset;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[Category("Data")]
	[Description("")]
	public override DbType DbType
	{
		get
		{
			if (!m_bSetDbType)
			{
				m_dbType = (DbType)OraDb_DbTypeTable.dbTypeToOracleDbTypeMapping[(int)m_oraDbType];
				m_bSetDbType = true;
			}
			return m_dbType;
		}
		set
		{
			switch (value)
			{
			case DbType.Boolean:
			case DbType.Currency:
			case DbType.Guid:
			case DbType.SByte:
			case DbType.UInt16:
			case DbType.UInt32:
			case DbType.UInt64:
			case DbType.VarNumeric:
				throw new ArgumentException();
			default:
				throw new ArgumentOutOfRangeException();
			case DbType.AnsiString:
			case DbType.Binary:
			case DbType.Byte:
			case DbType.Date:
			case DbType.DateTime:
			case DbType.Decimal:
			case DbType.Double:
			case DbType.Int16:
			case DbType.Int32:
			case DbType.Int64:
			case DbType.Object:
			case DbType.Single:
			case DbType.String:
			case DbType.Time:
			case DbType.AnsiStringFixedLength:
			case DbType.StringFixedLength:
				m_dbType = value;
				m_oraDbType = (OracleDbType)OraDb_DbTypeTable.dbTypeToOracleDbTypeMapping[(int)value];
				m_bSetDbType = true;
				m_modified = true;
				m_enumType = PrmEnumType.DBTYPE;
				m_bOracleDbTypeExSet = false;
				break;
			}
		}
	}

	[DefaultValue(false)]
	public override bool SourceColumnNullMapping
	{
		get
		{
			return m_sourceColumnNullMapping;
		}
		set
		{
			m_sourceColumnNullMapping = value;
		}
	}

	[DefaultValue(ParameterDirection.Input)]
	[Category("Data")]
	[Description("")]
	public override ParameterDirection Direction
	{
		get
		{
			return m_direction;
		}
		set
		{
			if (value != ParameterDirection.Input && value != ParameterDirection.Output && value != ParameterDirection.InputOutput && value != ParameterDirection.ReturnValue)
			{
				throw new ArgumentOutOfRangeException();
			}
			m_direction = value;
			m_modified = true;
		}
	}

	[Description("")]
	[Category("Data")]
	[DefaultValue(false)]
	public override bool IsNullable
	{
		get
		{
			return m_nullable;
		}
		set
		{
			m_nullable = value;
			m_modified = true;
		}
	}

	[Browsable(false)]
	[DefaultValue(0)]
	public int Offset
	{
		get
		{
			return m_offset;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			m_offset = value;
			m_modified = true;
		}
	}

	[Category("Data")]
	[Description("")]
	[Browsable(false)]
	[DbProviderSpecificTypeProperty(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public OracleDbType OracleDbTypeEx
	{
		get
		{
			return m_oraDbType;
		}
		set
		{
			OracleDbType = value;
			m_bOracleDbTypeExSet = true;
		}
	}

	[Category("Data")]
	[Description("")]
	public OracleDbType OracleDbType
	{
		get
		{
			return m_oraDbType;
		}
		set
		{
			if (m_oraDbType != value)
			{
				if (value < OracleDbType.BFile || value > OracleDbType.BinaryFloat)
				{
					throw new ArgumentOutOfRangeException();
				}
				m_oraDbType = value;
			}
			m_bSetDbType = false;
			m_enumType = PrmEnumType.ORADBTYPE;
			m_bOracleDbTypeExSet = false;
		}
	}

	internal PrmEnumType ParameterEnumType
	{
		get
		{
			return m_enumType;
		}
		set
		{
			if (m_enumType != value)
			{
				m_enumType = value;
			}
		}
	}

	[DefaultValue("")]
	public override string ParameterName
	{
		get
		{
			if (m_paramName != null)
			{
				return m_paramName;
			}
			return string.Empty;
		}
		set
		{
			m_paramName = value;
		}
	}

	[DefaultValue(0)]
	[Description("")]
	[Category("Data")]
	public new byte Precision
	{
		get
		{
			if (m_precision == 100)
			{
				return 0;
			}
			return m_precision;
		}
		set
		{
			m_precision = value;
			m_modified = true;
		}
	}

	[Description("")]
	[DefaultValue(0)]
	[Category("Data")]
	public new byte Scale
	{
		get
		{
			if (m_scale == 129)
			{
				return 0;
			}
			return m_scale;
		}
		set
		{
			m_scale = value;
			m_modified = true;
		}
	}

	[Description("")]
	[DefaultValue(0)]
	[Category("Data")]
	public override int Size
	{
		get
		{
			if (m_curSize != -1)
			{
				return m_curSize;
			}
			if (m_maxSize != -1)
			{
				return m_maxSize;
			}
			return 0;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (value != 0)
			{
				m_maxSize = value;
			}
			else
			{
				m_maxSize = -1;
			}
			m_curSize = -1;
		}
	}

	[Browsable(false)]
	[DefaultValue(null)]
	public int[] ArrayBindSize
	{
		get
		{
			if (m_curArrayBindSize != null && m_curArrayBindSize[0] != -1)
			{
				return m_curArrayBindSize;
			}
			if (m_maxArrayBindSize != null && m_maxArrayBindSize[0] != -1)
			{
				return m_maxArrayBindSize;
			}
			return null;
		}
		set
		{
			m_maxArrayBindSize = value;
			m_curArrayBindSize = null;
			m_modified = true;
		}
	}

	[DefaultValue("")]
	[Category("Data")]
	[Description("")]
	public override string SourceColumn
	{
		get
		{
			if (m_sourceColumn != null)
			{
				return m_sourceColumn;
			}
			return string.Empty;
		}
		set
		{
			m_sourceColumn = value;
		}
	}

	[Category("Data")]
	[Description("")]
	[DefaultValue(DataRowVersion.Current)]
	public override DataRowVersion SourceVersion
	{
		get
		{
			return m_sourceVersion;
		}
		set
		{
			if (value != DataRowVersion.Original && value != DataRowVersion.Current && value != DataRowVersion.Proposed && value != DataRowVersion.Default)
			{
				throw new ArgumentOutOfRangeException();
			}
			m_sourceVersion = value;
		}
	}

	[DefaultValue(OracleParameterStatus.Success)]
	[Browsable(false)]
	public OracleParameterStatus Status
	{
		get
		{
			return m_status;
		}
		set
		{
			if (value != 0 && value != OracleParameterStatus.NullInsert && value != OracleParameterStatus.NullFetched && value != OracleParameterStatus.Truncation)
			{
				throw new ArgumentOutOfRangeException();
			}
			m_status = value;
			m_modified = true;
		}
	}

	[Browsable(false)]
	[DefaultValue(null)]
	public OracleParameterStatus[] ArrayBindStatus
	{
		get
		{
			if (m_arrayBindStatus != null)
			{
				return m_arrayBindStatus;
			}
			return null;
		}
		set
		{
			m_arrayBindStatus = value;
			m_modified = true;
		}
	}

	[Browsable(false)]
	[DefaultValue(OracleCollectionType.None)]
	public OracleCollectionType CollectionType
	{
		get
		{
			return m_collType;
		}
		set
		{
			if (value != 0 && value != OracleCollectionType.PLSQLAssociativeArray)
			{
				throw new ArgumentOutOfRangeException();
			}
			m_collType = value;
		}
	}

	[Category("Data")]
	[Description("")]
	[DefaultValue(null)]
	public override object Value
	{
		get
		{
			return m_value;
		}
		set
		{
			if (value != null && value != DBNull.Value && m_enumType == PrmEnumType.NOTSET)
			{
				Type type = value.GetType();
				if (type == typeof(bool) || type == typeof(sbyte) || type == typeof(ushort) || type == typeof(uint) || type == typeof(ulong))
				{
					throw new ArgumentException();
				}
				object obj = OraDb_DbTypeTable.s_table[type];
				if (obj != null)
				{
					m_oraDbType = (OracleDbType)obj;
				}
				else
				{
					if (!(value is IOracleCustomType))
					{
						throw new ArgumentException();
					}
					m_oraDbType = OracleDbType.Object;
				}
				m_bSetDbType = false;
				m_enumType = PrmEnumType.VALUE;
			}
			m_value = value;
			m_modifedAfterBind = true;
		}
	}

	[DefaultValue("")]
	[Description("")]
	[Category("Data")]
	public string UdtTypeName
	{
		get
		{
			if (m_udtTypeName != null)
			{
				return m_udtTypeName;
			}
			return string.Empty;
		}
		set
		{
			if (m_udtTypeName != value)
			{
				m_udtTypeName = value;
			}
		}
	}

	static OracleParameter()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	private bool ShouldSerializeDbType()
	{
		return m_enumType == PrmEnumType.DBTYPE;
	}

	private bool ShouldSerializeOracleDbType()
	{
		return m_enumType != PrmEnumType.DBTYPE;
	}

	public OracleParameter()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameter::OracleParameter(1)\n");
		}
		m_enumType = PrmEnumType.NOTSET;
		m_direction = ParameterDirection.Input;
		m_oraDbType = OracleDbType.Varchar2;
		m_precision = 100;
		m_scale = 129;
		m_maxSize = -1;
		m_sourceVersion = DataRowVersion.Current;
		m_curSize = -1;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameter::OracleParameter(1)\n");
		}
	}

	public OracleParameter(string parameterName, OracleDbType oraType)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameter::OracleParameter(2)\n");
		}
		m_enumType = PrmEnumType.ORADBTYPE;
		m_direction = ParameterDirection.Input;
		if (oraType < OracleDbType.BFile || oraType > OracleDbType.BinaryFloat)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		m_oraDbType = oraType;
		m_paramName = parameterName;
		m_precision = 100;
		m_scale = 129;
		m_maxSize = -1;
		m_sourceVersion = DataRowVersion.Current;
		m_curSize = -1;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameter::OracleParameter(2)\n");
		}
	}

	public OracleParameter(string parameterName, object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameter::OracleParameter(3)\n");
		}
		if (obj != null && obj != DBNull.Value)
		{
			Type type = obj.GetType();
			if (type == typeof(bool) || type == typeof(sbyte) || type == typeof(ushort) || type == typeof(uint) || type == typeof(ulong))
			{
				throw new ArgumentException();
			}
			m_oraDbType = (OracleDbType)OraDb_DbTypeTable.s_table[type];
			m_enumType = PrmEnumType.VALUE;
			m_value = obj;
		}
		else
		{
			m_oraDbType = OracleDbType.Varchar2;
			m_enumType = PrmEnumType.NOTSET;
		}
		m_direction = ParameterDirection.Input;
		m_paramName = parameterName;
		m_precision = 100;
		m_scale = 129;
		m_maxSize = -1;
		m_sourceVersion = DataRowVersion.Current;
		m_curSize = -1;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameter::OracleParameter(3)\n");
		}
	}

	public OracleParameter(string parameterName, OracleDbType type, ParameterDirection direction)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameter::OracleParameter(4)\n");
		}
		if (direction != ParameterDirection.Input && direction != ParameterDirection.Output && direction != ParameterDirection.InputOutput && direction != ParameterDirection.ReturnValue)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		m_enumType = PrmEnumType.ORADBTYPE;
		m_direction = direction;
		if (type < OracleDbType.BFile || type > OracleDbType.BinaryFloat)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		m_oraDbType = type;
		m_paramName = parameterName;
		m_precision = 100;
		m_scale = 129;
		m_maxSize = -1;
		m_sourceVersion = DataRowVersion.Current;
		m_curSize = -1;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameter::OracleParameter(4)\n");
		}
	}

	public OracleParameter(string parameterName, OracleDbType type, int size, object obj, ParameterDirection direction)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameter::OracleParameter(5)\n");
		}
		if (size < 0)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		if (type < OracleDbType.BFile || type > OracleDbType.BinaryFloat)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		if (direction != ParameterDirection.Input && direction != ParameterDirection.Output && direction != ParameterDirection.InputOutput && direction != ParameterDirection.ReturnValue)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		m_enumType = PrmEnumType.ORADBTYPE;
		m_oraDbType = type;
		m_direction = direction;
		m_paramName = parameterName;
		m_value = obj;
		m_precision = 100;
		m_scale = 129;
		m_sourceVersion = DataRowVersion.Current;
		m_curSize = -1;
		if (size != 0)
		{
			m_maxSize = size;
		}
		else
		{
			m_maxSize = -1;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameter::OracleParameter(5)\n");
		}
	}

	public OracleParameter(string parameterName, OracleDbType type, object obj, ParameterDirection direction)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameter::OracleParameter(5)\n");
		}
		if (type < OracleDbType.BFile || type > OracleDbType.BinaryFloat)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		if (direction != ParameterDirection.Input && direction != ParameterDirection.Output && direction != ParameterDirection.InputOutput && direction != ParameterDirection.ReturnValue)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		m_enumType = PrmEnumType.ORADBTYPE;
		m_oraDbType = type;
		m_direction = direction;
		m_paramName = parameterName;
		m_value = obj;
		m_precision = 100;
		m_scale = 129;
		m_maxSize = -1;
		m_sourceVersion = DataRowVersion.Current;
		m_curSize = -1;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameter::OracleParameter(5)\n");
		}
	}

	public OracleParameter(string parameterName, OracleDbType type, int size)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameter::OracleParameter(6)\n");
		}
		if (size < 0)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		if (type < OracleDbType.BFile || type > OracleDbType.BinaryFloat)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		m_enumType = PrmEnumType.ORADBTYPE;
		m_oraDbType = type;
		m_direction = ParameterDirection.Input;
		m_paramName = parameterName;
		m_precision = 100;
		m_scale = 129;
		m_sourceVersion = DataRowVersion.Current;
		m_curSize = -1;
		if (size != 0)
		{
			m_maxSize = size;
		}
		else
		{
			m_maxSize = -1;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameter::OracleParameter(6)\n");
		}
	}

	public OracleParameter(string parameterName, OracleDbType type, int size, string srcColumn)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameter::OracleParameter(7)\n");
		}
		if (size < 0)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		if (type < OracleDbType.BFile || type > OracleDbType.BinaryFloat)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		m_enumType = PrmEnumType.ORADBTYPE;
		m_oraDbType = type;
		m_direction = ParameterDirection.Input;
		m_paramName = parameterName;
		m_precision = 100;
		m_scale = 129;
		m_sourceVersion = DataRowVersion.Current;
		m_curSize = -1;
		m_sourceColumn = srcColumn;
		if (size != 0)
		{
			m_maxSize = size;
		}
		else
		{
			m_maxSize = -1;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameter::OracleParameter(7)\n");
		}
	}

	internal OracleParameter(string parameterName, OracleDbType type, int size, string srcColumn, DataRowVersion version)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameter::OracleParameter(8)\n");
		}
		if (type < OracleDbType.BFile || type > OracleDbType.BinaryFloat)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		if (version != DataRowVersion.Original && version != DataRowVersion.Current && version != DataRowVersion.Proposed && version != DataRowVersion.Default)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		m_enumType = PrmEnumType.ORADBTYPE;
		m_oraDbType = type;
		m_direction = ParameterDirection.Input;
		m_paramName = parameterName;
		m_precision = 100;
		m_scale = 129;
		m_sourceVersion = DataRowVersion.Current;
		m_curSize = -1;
		m_sourceColumn = srcColumn;
		m_sourceVersion = version;
		if (size != 0)
		{
			m_maxSize = size;
		}
		else
		{
			m_maxSize = -1;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameter::OracleParameter(8)\n");
		}
	}

	internal OracleParameter(string parameterName, OracleDbType type, int size, string srcColumn, DataRowVersion version, object obj)
	{
		if (type < OracleDbType.BFile || type > OracleDbType.BinaryFloat)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		if (version != DataRowVersion.Original && version != DataRowVersion.Current && version != DataRowVersion.Proposed && version != DataRowVersion.Default)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		m_enumType = PrmEnumType.ORADBTYPE;
		m_oraDbType = type;
		m_direction = ParameterDirection.Input;
		m_paramName = parameterName;
		m_precision = 100;
		m_scale = 129;
		m_sourceVersion = DataRowVersion.Current;
		m_curSize = -1;
		m_sourceColumn = srcColumn;
		m_sourceVersion = version;
		m_value = obj;
		if (size != 0)
		{
			m_maxSize = size;
		}
		else
		{
			m_maxSize = -1;
		}
	}

	public OracleParameter(string parameterName, OracleDbType oraType, int size, ParameterDirection direction, bool isNullable, byte precision, byte scale, string srcColumn, DataRowVersion srcVersion, object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameter::OracleParameter(9)\n");
		}
		if (size < 0)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		if (direction != ParameterDirection.Input && direction != ParameterDirection.Output && direction != ParameterDirection.InputOutput && direction != ParameterDirection.ReturnValue)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		if (oraType < OracleDbType.BFile || oraType > OracleDbType.BinaryFloat)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		if (srcVersion != DataRowVersion.Original && srcVersion != DataRowVersion.Current && srcVersion != DataRowVersion.Proposed && srcVersion != DataRowVersion.Default)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		m_enumType = PrmEnumType.ORADBTYPE;
		m_oraDbType = oraType;
		m_direction = direction;
		m_paramName = parameterName;
		m_precision = precision;
		m_scale = scale;
		m_sourceVersion = DataRowVersion.Current;
		m_curSize = -1;
		m_sourceColumn = srcColumn;
		m_sourceVersion = srcVersion;
		m_value = obj;
		m_nullable = isNullable;
		if (size != 0)
		{
			m_maxSize = size;
		}
		else
		{
			m_maxSize = -1;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameter::OracleParameter(9)\n");
		}
	}

	internal OracleParameter(DbType type, ParameterDirection direction, bool isNullable, int offSet, OracleDbType oraDbType, string paramName, byte precision, byte scale, int size, string srcColumn, DataRowVersion srcVersion, OracleParameterStatus paramStatus, object obj, bool bSetDbType, PrmEnumType enumType, bool modified, string udtTypeName)
	{
		if (direction != ParameterDirection.Input && direction != ParameterDirection.Output && direction != ParameterDirection.InputOutput && direction != ParameterDirection.ReturnValue)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		if (oraDbType < OracleDbType.BFile || oraDbType > OracleDbType.BinaryFloat)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		if (srcVersion != DataRowVersion.Original && srcVersion != DataRowVersion.Current && srcVersion != DataRowVersion.Proposed && srcVersion != DataRowVersion.Default)
		{
			GC.SuppressFinalize(this);
			throw new ArgumentOutOfRangeException();
		}
		m_enumType = enumType;
		m_modified = modified;
		m_oraDbType = oraDbType;
		m_direction = direction;
		m_paramName = paramName;
		m_precision = precision;
		m_scale = scale;
		m_sourceVersion = DataRowVersion.Current;
		m_curSize = -1;
		m_sourceColumn = srcColumn;
		m_sourceVersion = srcVersion;
		m_value = obj;
		m_nullable = isNullable;
		m_offset = offSet;
		m_status = paramStatus;
		m_udtTypeName = udtTypeName;
		if (size != 0)
		{
			m_maxSize = size;
		}
		else
		{
			m_maxSize = -1;
		}
		if (bSetDbType)
		{
			m_dbType = type;
			m_bSetDbType = true;
		}
	}

	public object Clone()
	{
		OracleParameter oracleParameter = null;
		oracleParameter = ((m_value == null || !m_value.GetType().IsArray) ? new OracleParameter(m_dbType, m_direction, m_nullable, m_offset, m_oraDbType, m_paramName, m_precision, m_scale, m_maxSize, m_sourceColumn, m_sourceVersion, m_status, m_value, m_bSetDbType, m_enumType, m_modified, m_udtTypeName) : new OracleParameter(m_dbType, m_direction, m_nullable, m_offset, m_oraDbType, m_paramName, m_precision, m_scale, m_maxSize, m_sourceColumn, m_sourceVersion, m_status, ((Array)m_value).Clone(), m_bSetDbType, m_enumType, m_modified, m_udtTypeName));
		oracleParameter.m_collType = m_collType;
		oracleParameter.m_bOracleDbTypeExSet = m_bOracleDbTypeExSet;
		oracleParameter.m_bReturnDateTimeOffset = m_bReturnDateTimeOffset;
		return oracleParameter;
	}

	public override string ToString()
	{
		if (m_paramName != null)
		{
			return m_paramName;
		}
		return string.Empty;
	}

	public void Dispose()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameter::Dispose()\n");
		}
		if (m_pDataBuffer != IntPtr.Zero)
		{
			try
			{
				Marshal.FreeCoTaskMem(m_pDataBuffer);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
			}
			m_pDataBuffer = IntPtr.Zero;
		}
		if (!m_disposed)
		{
			m_modified = true;
			m_disposed = true;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameter::Dispose()\n");
		}
	}

	private void Dispose(bool disposing)
	{
		if (!m_disposed)
		{
			if (disposing)
			{
				m_modified = true;
			}
			m_disposed = true;
		}
	}

	public override void ResetDbType()
	{
		m_enumType = PrmEnumType.NOTSET;
		DbType = DbType.String;
		OracleDbType = OracleDbType.Varchar2;
	}

	public void ResetOracleDbType()
	{
		m_enumType = PrmEnumType.NOTSET;
		DbType = DbType.String;
		OracleDbType = OracleDbType.Varchar2;
	}

	internal unsafe int ResetCtx(int arraySize)
	{
		int num = 0;
		m_curSize = -1;
		if (m_bArrayBind)
		{
			if (m_collType == OracleCollectionType.PLSQLAssociativeArray)
			{
				if (m_direction == ParameterDirection.Input)
				{
					if (m_value != null && m_value != DBNull.Value && m_value is Array)
					{
						if (m_maxSize > 0 && ((Array)m_value).Length > m_maxSize)
						{
							m_pOpoPrmValCtx->curelep = (m_pOpoPrmValCtx->maxarr_len = (m_arrBindCount = (m_bindElemCount = m_maxSize)));
						}
						else
						{
							m_pOpoPrmValCtx->curelep = (m_pOpoPrmValCtx->maxarr_len = (m_arrBindCount = (m_bindElemCount = ((Array)m_value).Length)));
						}
					}
					else
					{
						if (m_arrayBindStatus == null)
						{
							throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "OracleParameter.Value"));
						}
						m_bindElemCount = 0;
						if (m_maxSize > 0 && m_arrayBindStatus.Length > m_maxSize)
						{
							m_pOpoPrmValCtx->curelep = (m_pOpoPrmValCtx->maxarr_len = (m_arrBindCount = m_maxSize));
						}
						else
						{
							m_pOpoPrmValCtx->curelep = (m_pOpoPrmValCtx->maxarr_len = (m_arrBindCount = m_arrayBindStatus.Length));
						}
					}
					if (m_arrBindCount == 0)
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "OracleParameter.Value"));
					}
				}
				else if (m_direction == ParameterDirection.InputOutput)
				{
					if (m_maxSize <= 0)
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "OracleParameter.Size"));
					}
					if (m_value != null && m_value != DBNull.Value && m_value is Array)
					{
						if (((Array)m_value).Length > m_maxSize)
						{
							m_pOpoPrmValCtx->curelep = (m_bindElemCount = m_maxSize);
						}
						else
						{
							m_pOpoPrmValCtx->curelep = (m_bindElemCount = ((Array)m_value).Length);
						}
					}
					else
					{
						if (m_arrayBindStatus == null)
						{
							throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "OracleParameter.Value"));
						}
						m_bindElemCount = 0;
						if (m_arrayBindStatus.Length > m_maxSize)
						{
							m_pOpoPrmValCtx->curelep = m_maxSize;
						}
						else
						{
							m_pOpoPrmValCtx->curelep = m_arrayBindStatus.Length;
						}
					}
					m_pOpoPrmValCtx->maxarr_len = (m_arrBindCount = m_maxSize);
				}
				else
				{
					if (m_maxSize <= 0)
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "OracleParameter.Size"));
					}
					m_bindElemCount = 0;
					m_pOpoPrmValCtx->curelep = 0;
					m_pOpoPrmValCtx->maxarr_len = (m_arrBindCount = m_maxSize);
				}
				arraySize = m_arrBindCount;
			}
			else
			{
				m_arrBindCount = (m_bindElemCount = arraySize);
			}
		}
		else
		{
			m_arrBindCount = (m_bindElemCount = 1);
		}
		if (arraySize > m_pOpoPrmValCtx->NumArrBindElems)
		{
			try
			{
				num = OpsPrm.ReAllocValCtx(m_pOpoPrmValCtx, arraySize);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			if (num != 0)
			{
				return num;
			}
		}
		if (m_bArrayBind)
		{
			if (m_direction != ParameterDirection.Input && (OracleDbType == OracleDbType.Char || OracleDbType == OracleDbType.Varchar2 || OracleDbType == OracleDbType.Raw || OracleDbType == OracleDbType.Long || OracleDbType == OracleDbType.NChar || OracleDbType == OracleDbType.NVarchar2 || OracleDbType == OracleDbType.LongRaw) && (m_maxArrayBindSize == null || (m_maxArrayBindSize != null && m_maxArrayBindSize.Length < arraySize)))
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "OracleParameter.ArrayBindSize"));
			}
			if (m_curArrayBindSize == null || m_curArrayBindSize.Length != arraySize)
			{
				m_curArrayBindSize = new int[arraySize];
				for (int i = 0; i < arraySize; i++)
				{
					m_curArrayBindSize[i] = -1;
				}
			}
			if (m_maxArrayBindSize == null)
			{
				m_maxArrayBindSize = new int[arraySize];
				for (int i = 0; i < arraySize; i++)
				{
					m_maxArrayBindSize[i] = -1;
				}
			}
			else if (m_maxArrayBindSize.Length < arraySize)
			{
				int[] array = new int[arraySize];
				int i;
				for (i = 0; i < m_maxArrayBindSize.Length; i++)
				{
					array[i] = m_maxArrayBindSize[i];
				}
				for (; i < arraySize; i++)
				{
					array[i] = -1;
				}
				m_maxArrayBindSize = array;
			}
			if (m_arrayBindStatus == null)
			{
				m_arrayBindStatus = new OracleParameterStatus[arraySize];
				for (int i = 0; i < arraySize; i++)
				{
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
				}
			}
			else if (m_arrayBindStatus.Length < arraySize)
			{
				OracleParameterStatus[] array2 = new OracleParameterStatus[arraySize];
				int i;
				for (i = 0; i < m_arrayBindStatus.Length; i++)
				{
					array2[i] = m_arrayBindStatus[i];
				}
				for (; i < arraySize; i++)
				{
					array2[i] = OracleParameterStatus.Success;
				}
				m_arrayBindStatus = array2;
			}
		}
		SetStatus(arraySize);
		return 0;
	}

	internal void SetSize(int size)
	{
		if (size != 0)
		{
			m_maxSize = size;
		}
		else
		{
			m_maxSize = -1;
		}
		m_curSize = -1;
	}

	private bool IsProviderSpecificNullValue(object value)
	{
		bool result = false;
		switch (m_oraDbType)
		{
		case OracleDbType.Char:
		case OracleDbType.Long:
		case OracleDbType.NChar:
		case OracleDbType.NVarchar2:
		case OracleDbType.Varchar2:
			if (value is OracleString && ((OracleString)value).IsNull)
			{
				result = true;
			}
			break;
		case OracleDbType.BFile:
		{
			OracleBFile oracleBFile = null;
			if (value is OracleBFile oracleBFile2 && oracleBFile2.IsNull)
			{
				result = true;
			}
			break;
		}
		case OracleDbType.Blob:
		{
			OracleBlob oracleBlob = null;
			if ((value is OracleBlob oracleBlob2 && oracleBlob2.IsNull) || (value is OracleBinary && ((OracleBinary)value).IsNull))
			{
				result = true;
			}
			break;
		}
		case OracleDbType.Byte:
			if ((value is OracleDecimal oracleDecimal && oracleDecimal.IsNull) || (value is OracleString && ((OracleString)value).IsNull))
			{
				result = true;
			}
			break;
		case OracleDbType.Clob:
		case OracleDbType.NClob:
		{
			OracleClob oracleClob3 = null;
			if ((value is OracleClob oracleClob4 && oracleClob4.IsNull) || (value is OracleString && ((OracleString)value).IsNull))
			{
				result = true;
			}
			break;
		}
		case OracleDbType.Date:
		case OracleDbType.TimeStamp:
		case OracleDbType.TimeStampLTZ:
		case OracleDbType.TimeStampTZ:
			if ((value is OracleDate oracleDate && oracleDate.IsNull) || (value is OracleString oracleString && oracleString.IsNull) || (value is OracleTimeStamp oracleTimeStamp && oracleTimeStamp.IsNull) || (value is OracleTimeStampTZ oracleTimeStampTZ && oracleTimeStampTZ.IsNull) || (value is OracleTimeStampLTZ && ((OracleTimeStampLTZ)value).IsNull))
			{
				result = true;
			}
			break;
		case OracleDbType.Decimal:
		case OracleDbType.Double:
		case OracleDbType.Int16:
		case OracleDbType.Int32:
		case OracleDbType.Int64:
		case OracleDbType.Single:
		case OracleDbType.BinaryDouble:
		case OracleDbType.BinaryFloat:
			if ((value is OracleDecimal oracleDecimal2 && oracleDecimal2.IsNull) || (value is OracleString && ((OracleString)value).IsNull))
			{
				result = true;
			}
			break;
		case OracleDbType.IntervalDS:
			if ((value is OracleIntervalDS oracleIntervalDS && oracleIntervalDS.IsNull) || (value is OracleString && ((OracleString)value).IsNull))
			{
				result = true;
			}
			break;
		case OracleDbType.IntervalYM:
			if ((value is OracleIntervalYM oracleIntervalYM && oracleIntervalYM.IsNull) || (value is OracleString && ((OracleString)value).IsNull))
			{
				result = true;
			}
			break;
		case OracleDbType.LongRaw:
		case OracleDbType.Raw:
			if (value is OracleBinary && ((OracleBinary)value).IsNull)
			{
				result = true;
			}
			break;
		case OracleDbType.RefCursor:
		{
			OracleRefCursor oracleRefCursor = null;
			if (value is OracleRefCursor oracleRefCursor2 && oracleRefCursor2.IsNull)
			{
				result = true;
			}
			break;
		}
		case OracleDbType.XmlType:
		{
			OracleXmlType oracleXmlType = null;
			OracleClob oracleClob = null;
			if ((value is OracleXmlType oracleXmlType2 && oracleXmlType2.IsNull) || (value is OracleClob oracleClob2 && oracleClob2.IsNull) || (value is OracleString && ((OracleString)value).IsNull))
			{
				result = true;
			}
			break;
		}
		case OracleDbType.Object:
			if (value is INullable && ((INullable)value).IsNull)
			{
				result = true;
			}
			break;
		case OracleDbType.Ref:
		{
			OracleRef oracleRef = null;
			if ((value is OracleRef oracleRef2 && oracleRef2.IsNull) || (value is OracleString && ((OracleString)value).IsNull))
			{
				result = true;
			}
			break;
		}
		}
		return result;
	}

	internal unsafe void SetStatus(int arraySize)
	{
		if (m_value == null)
		{
			m_value = DBNull.Value;
		}
		if (m_bArrayBind)
		{
			if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
			{
				if (m_value == DBNull.Value || IsProviderSpecificNullValue(m_value))
				{
					for (int i = 0; i < arraySize; i++)
					{
						m_pOpoPrmValCtx->pInd[i] = -1;
						m_pOpoPrmValCtx->pSrcInd[i] = -1;
					}
					return;
				}
				int length = ((Array)m_value).Length;
				for (int i = 0; i < arraySize; i++)
				{
					if (m_arrayBindStatus[i] == OracleParameterStatus.NullInsert)
					{
						m_pOpoPrmValCtx->pInd[i] = -1;
						m_pOpoPrmValCtx->pSrcInd[i] = -1;
					}
					else if (length > i && (((Array)m_value).GetValue(i) == null || ((Array)m_value).GetValue(i) == DBNull.Value || (((Array)m_value).GetValue(i) is INullable && ((INullable)((Array)m_value).GetValue(i)).IsNull)))
					{
						m_pOpoPrmValCtx->pInd[i] = -1;
						m_pOpoPrmValCtx->pSrcInd[i] = -1;
					}
					else
					{
						m_pOpoPrmValCtx->pInd[i] = 0;
						m_pOpoPrmValCtx->pSrcInd[i] = 0;
					}
				}
			}
			else
			{
				for (int i = 0; i < arraySize; i++)
				{
					m_pOpoPrmValCtx->pInd[i] = 0;
					m_pOpoPrmValCtx->pSrcInd[i] = 0;
				}
			}
		}
		else if (((m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput) && (m_value == DBNull.Value || IsProviderSpecificNullValue(m_value) || m_status == OracleParameterStatus.NullInsert)) || m_direction == ParameterDirection.Output)
		{
			*m_pOpoPrmValCtx->pInd = -1;
			*m_pOpoPrmValCtx->pSrcInd = -1;
		}
		else
		{
			*m_pOpoPrmValCtx->pInd = 0;
			*m_pOpoPrmValCtx->pSrcInd = 0;
		}
	}

	internal void PreBind(OracleConnection conn, IntPtr errCtx, int arraySize)
	{
		PreBind(conn, errCtx, arraySize, bIsFromEF: false, bIsSelectStmt: false);
	}

	internal unsafe void PreBind(OracleConnection conn, IntPtr errCtx, int arraySize, bool bIsFromEF, bool bIsSelectStmt)
	{
		m_bArrayBind = arraySize != 0 || m_collType == OracleCollectionType.PLSQLAssociativeArray;
		if (m_bArrayBind)
		{
			ResetCtx(arraySize);
		}
		else
		{
			m_curSize = -1;
			m_arrBindCount = (m_bindElemCount = 1);
			SetStatus(arraySize);
		}
		switch (m_oraDbType)
		{
		case OracleDbType.Char:
		case OracleDbType.Long:
		case OracleDbType.Varchar2:
			m_pOpoPrmValCtx->CharSetForm = 1;
			PreBind_Char();
			break;
		case OracleDbType.BFile:
			PreBind_BFile(conn);
			break;
		case OracleDbType.Blob:
			PreBind_Blob(conn, bIsFromEF);
			break;
		case OracleDbType.Byte:
			PreBind_Byte();
			break;
		case OracleDbType.Clob:
			m_pOpoPrmValCtx->CharSetForm = 1;
			PreBind_Clob(conn, bIsFromEF, bIsSelectStmt);
			break;
		case OracleDbType.Date:
			PreBind_Date();
			break;
		case OracleDbType.Decimal:
			PreBind_Decimal();
			break;
		case OracleDbType.Double:
		case OracleDbType.BinaryDouble:
			PreBind_Double(conn, m_oraDbType);
			break;
		case OracleDbType.Int16:
			PreBind_Int16();
			break;
		case OracleDbType.Int32:
			PreBind_Int32();
			break;
		case OracleDbType.Int64:
			PreBind_Int64();
			break;
		case OracleDbType.IntervalDS:
			PreBind_IntervalDS();
			break;
		case OracleDbType.IntervalYM:
			PreBind_IntervalYM();
			break;
		case OracleDbType.LongRaw:
		case OracleDbType.Raw:
			PreBind_Raw();
			break;
		case OracleDbType.NChar:
		case OracleDbType.NVarchar2:
			m_pOpoPrmValCtx->CharSetForm = 2;
			PreBind_Char();
			break;
		case OracleDbType.NClob:
			m_pOpoPrmValCtx->CharSetForm = 2;
			PreBind_Clob(conn, bIsFromEF, bIsSelectStmt);
			break;
		case OracleDbType.RefCursor:
			PreBind_RefCursor(conn);
			break;
		case OracleDbType.Single:
		case OracleDbType.BinaryFloat:
			PreBind_Single(conn, m_oraDbType);
			break;
		case OracleDbType.TimeStamp:
			PreBind_TimeStamp(conn, errCtx);
			break;
		case OracleDbType.TimeStampLTZ:
			PreBind_TimeStampLTZ(conn, errCtx);
			break;
		case OracleDbType.TimeStampTZ:
			PreBind_TimeStampTZ(conn, errCtx);
			break;
		case OracleDbType.XmlType:
			PreBind_XmlType(conn);
			break;
		case OracleDbType.Ref:
			ResetUDTInd();
			if (m_enumType != PrmEnumType.ORADBTYPE && m_modifedAfterBind)
			{
				PreBind_Object(conn);
			}
			else
			{
				PreBind_OracleRef(conn);
			}
			break;
		case OracleDbType.Object:
			ResetUDTInd();
			PreBind_Object(conn);
			break;
		case OracleDbType.Array:
			ResetUDTInd();
			if (m_enumType != PrmEnumType.ORADBTYPE && m_modifedAfterBind)
			{
				PreBind_Object(conn);
			}
			else
			{
				PreBind_Collection(conn);
			}
			break;
		}
		m_modifedAfterBind = false;
	}

	internal unsafe bool PostBind(OracleConnection conn, OpoSqlValCtx* pOpoSqlValCtx, int arraySize)
	{
		if (CollectionType == OracleCollectionType.PLSQLAssociativeArray)
		{
			m_arrBindCount = m_pOpoPrmValCtx->curelep;
			Size = m_arrBindCount;
		}
		switch (m_oraDbType)
		{
		case OracleDbType.BFile:
			PostBind_BFile(conn);
			break;
		case OracleDbType.Blob:
			PostBind_Blob(conn);
			break;
		case OracleDbType.Byte:
			PostBind_Byte();
			break;
		case OracleDbType.Char:
		case OracleDbType.Long:
		case OracleDbType.NChar:
		case OracleDbType.NVarchar2:
		case OracleDbType.Varchar2:
			PostBind_Char();
			break;
		case OracleDbType.Clob:
			PostBind_Clob(conn, isNClob: false);
			break;
		case OracleDbType.Date:
			PostBind_Date();
			break;
		case OracleDbType.Decimal:
			PostBind_Decimal();
			break;
		case OracleDbType.Double:
		case OracleDbType.BinaryDouble:
			PostBind_Double();
			break;
		case OracleDbType.Int16:
			PostBind_Int16();
			break;
		case OracleDbType.Int32:
			PostBind_Int32();
			break;
		case OracleDbType.Int64:
			PostBind_Int64();
			break;
		case OracleDbType.IntervalDS:
			PostBind_IntervalDS();
			break;
		case OracleDbType.IntervalYM:
			PostBind_IntervalYM();
			break;
		case OracleDbType.NClob:
			PostBind_Clob(conn, isNClob: true);
			break;
		case OracleDbType.LongRaw:
		case OracleDbType.Raw:
			PostBind_Raw();
			break;
		case OracleDbType.RefCursor:
			PostBind_RefCursor(conn, pOpoSqlValCtx, m_commandText, m_paramPosOrName);
			break;
		case OracleDbType.Single:
		case OracleDbType.BinaryFloat:
			PostBind_Single();
			break;
		case OracleDbType.TimeStamp:
			PostBind_TimeStamp();
			break;
		case OracleDbType.TimeStampLTZ:
			PostBind_TimeStampLTZ();
			break;
		case OracleDbType.TimeStampTZ:
			PostBind_TimeStampTZ();
			break;
		case OracleDbType.XmlType:
			PostBind_XmlType(conn);
			break;
		case OracleDbType.Ref:
			PostBind_OracleRef(conn);
			break;
		case OracleDbType.Object:
			PostBind_OracleObject(conn);
			break;
		case OracleDbType.Array:
			PostBind_Collection(conn);
			break;
		}
		return true;
	}

	internal unsafe void PreBindFree(OracleConnection conn, int arraySize)
	{
		if (m_oraDbType != OracleDbType.Blob && m_oraDbType != OracleDbType.Clob && m_oraDbType != OracleDbType.NClob && m_oraDbType != OracleDbType.Ref)
		{
			m_saveValue = null;
		}
		switch (m_oraDbType)
		{
		case OracleDbType.Blob:
		case OracleDbType.Clob:
		case OracleDbType.NClob:
			if (m_redirected)
			{
				m_redirected = false;
				if (m_pDataBuffer != IntPtr.Zero)
				{
					try
					{
						Marshal.FreeCoTaskMem(m_pDataBuffer);
					}
					catch (Exception ex3)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex3);
						}
					}
					m_pDataBuffer = IntPtr.Zero;
				}
			}
			else if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
			{
				for (int i = 0; i < m_arrBindCount; i++)
				{
					try
					{
						if (m_saveValue[i] is OracleBlob)
						{
							((OracleBlob)m_saveValue[i]).Dispose();
						}
						else if (m_saveValue[i] is OracleClob)
						{
							((OracleClob)m_saveValue[i]).Dispose();
						}
						m_saveValue[i] = null;
					}
					catch (Exception ex4)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex4);
						}
					}
				}
			}
			m_saveValue = null;
			break;
		case OracleDbType.Char:
		case OracleDbType.Long:
		case OracleDbType.LongRaw:
		case OracleDbType.NChar:
		case OracleDbType.NVarchar2:
		case OracleDbType.Raw:
		case OracleDbType.Varchar2:
			if (!(m_pDataBuffer != IntPtr.Zero))
			{
				break;
			}
			try
			{
				Marshal.FreeCoTaskMem(m_pDataBuffer);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
			}
			m_pDataBuffer = IntPtr.Zero;
			break;
		case OracleDbType.IntervalDS:
		{
			if (m_direction != ParameterDirection.Input || (!(m_value is TimeSpan) && !(m_value is TimeSpan[])))
			{
				break;
			}
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1 || !((IntPtr)(*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)) != IntPtr.Zero))
				{
					continue;
				}
				try
				{
					OpsIDS.FreeValCtx((OpoITLValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
				}
				catch (Exception ex6)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex6);
					}
				}
				*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4) = (int)IntPtr.Zero;
			}
			break;
		}
		case OracleDbType.IntervalYM:
		{
			if (m_direction != ParameterDirection.Input || (!(m_value is byte) && !(m_value is short) && !(m_value is int) && !(m_value is long) && !(m_value is byte[]) && !(m_value is short[]) && !(m_value is int[]) && !(m_value is long[])))
			{
				break;
			}
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1 || !((IntPtr)(*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)) != IntPtr.Zero))
				{
					continue;
				}
				try
				{
					OpsIYM.FreeValCtx((OpoITLValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
				}
				catch (Exception ex5)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex5);
					}
				}
				*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4) = (int)IntPtr.Zero;
			}
			break;
		}
		case OracleDbType.TimeStamp:
		case OracleDbType.TimeStampLTZ:
		case OracleDbType.TimeStampTZ:
		{
			if (m_direction != ParameterDirection.Input || (!(m_value is DateTime) && !(m_value is DateTime[]) && !(m_value is Array)))
			{
				break;
			}
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if ((m_value is Array && !(((Array)m_value).GetValue(i) is DateTime)) || m_pOpoPrmValCtx->pInd[i] == -1 || !((IntPtr)(*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)) != IntPtr.Zero))
				{
					continue;
				}
				try
				{
					OpsTS.FreeValCtx((OpoTSValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
				}
				catch (Exception ex7)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex7);
					}
				}
				*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4) = (int)IntPtr.Zero;
			}
			break;
		}
		case OracleDbType.XmlType:
		case OracleDbType.Array:
		case OracleDbType.Object:
		case OracleDbType.Ref:
			if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
			{
				for (int i = 0; i < m_arrBindCount; i++)
				{
					if (m_oraDbType == OracleDbType.Ref && m_pOpoPrmValCtx->pSrcInd[i] != -1 && !(m_value is OracleRef) && !IsElemType(typeof(OracleRef), m_value, i))
					{
						if (m_saveValue[i] != null)
						{
							((OracleRef)m_saveValue[i]).Dispose();
						}
						m_saveValue[i] = null;
					}
					if (m_pOpoPrmValCtx->pInd[i] == -1)
					{
						continue;
					}
					if ((m_oraDbType == OracleDbType.Object || m_oraDbType == OracleDbType.Array) && m_pOpoPrmValCtx->pOpoUdtValCtx != null)
					{
						try
						{
							OpsPrm.FreeUdtInObjects(conn.m_opoConCtx.opsConCtx, m_pOpoPrmValCtx);
						}
						catch (Exception ex)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex);
							}
						}
					}
					if ((IntPtr)(*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)) != IntPtr.Zero)
					{
						*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4) = (int)IntPtr.Zero;
					}
				}
			}
			m_saveValue = null;
			break;
		case OracleDbType.Byte:
		case OracleDbType.Date:
		case OracleDbType.Decimal:
		case OracleDbType.Double:
		case OracleDbType.Int16:
		case OracleDbType.Int32:
		case OracleDbType.Int64:
		case (OracleDbType)118:
		case OracleDbType.RefCursor:
		case OracleDbType.Single:
			break;
		}
	}

	private unsafe void SetPrmValCtx(OracleUdtDescriptor udtDesc)
	{
		m_udtDescriptor = udtDesc;
		m_pOpoPrmValCtx->pOpsDscCtx = udtDesc.m_opsDscCtx;
		m_pOpoPrmValCtx->bIsFinalType = udtDesc.m_pOpoDscValCtx->bIsFinalType;
	}

	internal unsafe void SetPrmValCtx(IntPtr ip, int index)
	{
		*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)index * (nint)4) = ip.ToInt32();
	}

	internal unsafe void SetPrmValCtx(void* vp, int index)
	{
		*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)index * (nint)4) = (int)vp;
	}

	internal unsafe void SetPrmValCtx(byte b, int index)
	{
		((byte*)m_pOpoPrmValCtx->pBltVal)[index] = b;
	}

	internal unsafe void SetPrmValCtx(int i, int index)
	{
		*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)index * (nint)4) = i;
	}

	internal unsafe void SetPrmValCtx(long i, int index)
	{
		*(long*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)index * (nint)22) = i;
	}

	internal unsafe void SetPrmValCtx(float s, int index)
	{
		*(float*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)index * (nint)4) = s;
	}

	internal unsafe void SetPrmValCtx(double d, int index)
	{
		*(double*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)index * (nint)8) = d;
	}

	internal unsafe void SetPrmValCtx(short i, int index)
	{
		*(short*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)index * (nint)2) = i;
	}

	internal unsafe void SetPrmValCtx(OraType oraType, int valueSize, int[] alenp)
	{
		m_pOpoPrmValCtx->BindType = (ushort)oraType;
		m_pOpoPrmValCtx->OraDbType = (int)m_oraDbType;
		m_pOpoPrmValCtx->Direction = (byte)m_direction;
		m_pOpoPrmValCtx->PrmEnumType = (byte)m_enumType;
		SetArrayOfLen(valueSize, alenp);
	}

	internal unsafe void SetPrmValCtx(OraType oraType, int valueSize, int[] alenp, OracleDbType oradbtype)
	{
		SetPrmValCtx(oraType, valueSize, alenp);
		m_pOpoPrmValCtx->OraDbType = (int)oradbtype;
	}

	private unsafe void SetArrayOfLen(int valueSize, int[] alenp)
	{
		int num;
		if (!m_bArrayBind)
		{
			num = m_maxSize;
		}
		else
		{
			num = m_maxArrayBindSize[0];
			int num2 = m_maxArrayBindSize.Length;
			for (int i = 0; i < num2; i++)
			{
				if (m_maxArrayBindSize[i] > num)
				{
					num = m_maxArrayBindSize[i];
				}
			}
		}
		if (num <= -1)
		{
			num = valueSize;
		}
		if (m_direction == ParameterDirection.Input)
		{
			m_pOpoPrmValCtx->Size = valueSize;
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (alenp != null)
				{
					m_pOpoPrmValCtx->alenp[i] = (ushort)alenp[i];
					m_pOpoPrmValCtx->objalenp[i] = alenp[i];
				}
				else
				{
					m_pOpoPrmValCtx->alenp[i] = (ushort)valueSize;
					m_pOpoPrmValCtx->objalenp[i] = valueSize;
				}
			}
			return;
		}
		if (m_direction == ParameterDirection.InputOutput)
		{
			m_pOpoPrmValCtx->Size = num;
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (alenp != null)
				{
					m_pOpoPrmValCtx->alenp[i] = (ushort)alenp[i];
					m_pOpoPrmValCtx->objalenp[i] = alenp[i];
				}
				else
				{
					m_pOpoPrmValCtx->alenp[i] = (ushort)valueSize;
					m_pOpoPrmValCtx->objalenp[i] = valueSize;
				}
			}
			return;
		}
		m_pOpoPrmValCtx->Size = num;
		for (int i = 0; i < m_arrBindCount; i++)
		{
			if (alenp != null)
			{
				m_pOpoPrmValCtx->alenp[i] = (ushort)alenp[i];
				m_pOpoPrmValCtx->objalenp[i] = alenp[i];
			}
			else if (!m_bArrayBind)
			{
				m_pOpoPrmValCtx->alenp[i] = (ushort)num;
				m_pOpoPrmValCtx->objalenp[i] = num;
			}
			else if (num == 0)
			{
				m_pOpoPrmValCtx->alenp[i] = (ushort)num;
				m_pOpoPrmValCtx->objalenp[i] = num;
			}
			else
			{
				m_pOpoPrmValCtx->alenp[i] = (ushort)m_maxArrayBindSize[i];
				m_pOpoPrmValCtx->objalenp[i] = m_maxArrayBindSize[i];
			}
		}
	}

	private unsafe void PreBind_BFile(OracleConnection conn)
	{
		OracleBFile oracleBFile = null;
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array.GetValue(i);
				}
				if (obj is OracleBFile oracleBFile2)
				{
					oracleBFile = oracleBFile2;
					if (oracleBFile.m_connection == conn || (oracleBFile.m_connection.m_contextConnection && conn.m_contextConnection))
					{
						if (oracleBFile.m_conSignature != conn.m_conSignature)
						{
							throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
						}
						SetPrmValCtx(oracleBFile.LobCtx, i);
						continue;
					}
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_DIFFERENT_CONNECTIONS));
				}
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
			}
		}
		SetPrmValCtx(OraType.ORA_OCIBFileLocator, -1, null);
	}

	private unsafe void PostBind_BFile(OracleConnection conn)
	{
		OracleBFile[] array = null;
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					m_value = new OracleBFile(conn, (IntPtr)(*(int*)m_pOpoPrmValCtx->pBltVal));
					m_status = OracleParameterStatus.Success;
					break;
				}
				m_curSize = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					m_value = OracleBFile.Null;
				}
				else
				{
					m_value = DBNull.Value;
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			array = new OracleBFile[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					array[i] = new OracleBFile(conn, (IntPtr)(*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
					continue;
				}
				m_curSize = 0;
				m_curArrayBindSize[i] = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					array[i] = OracleBFile.Null;
				}
				else
				{
					array[i] = null;
				}
				m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
			}
			m_value = array;
			break;
		}
		case ParameterDirection.InputOutput:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (*m_pOpoPrmValCtx->pSrcInd == -1)
					{
						m_value = new OracleBFile(conn, (IntPtr)(*(int*)m_pOpoPrmValCtx->pBltVal));
						m_status = OracleParameterStatus.Success;
					}
					break;
				}
				if (*m_pOpoPrmValCtx->pSrcInd != -1)
				{
					((OracleBFile)m_value).Dispose();
				}
				m_curSize = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					m_value = OracleBFile.Null;
				}
				else
				{
					m_value = DBNull.Value;
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			array = new OracleBFile[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_pOpoPrmValCtx->pSrcInd[i] == -1)
					{
						array[i] = new OracleBFile(conn, (IntPtr)(*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
					}
					else
					{
						array[i] = ((OracleBFile[])m_value)[i];
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
					continue;
				}
				if (m_pOpoPrmValCtx->pSrcInd[i] != -1)
				{
					((OracleBFile[])m_value)[i].Dispose();
				}
				m_curSize = 0;
				m_curArrayBindSize[i] = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					array[i] = OracleBFile.Null;
				}
				else
				{
					array[i] = null;
				}
				m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
			}
			m_value = array;
			break;
		}
		}
		if (m_enumType != PrmEnumType.DBTYPE || !m_bOracleDbTypeExSet || m_direction == ParameterDirection.Input)
		{
			return;
		}
		if (m_bArrayBind)
		{
			byte[][] array2 = new byte[m_arrBindCount][];
			for (int j = 0; j < m_arrBindCount; j++)
			{
				OracleBFile oracleBFile = array[j];
				if (oracleBFile == null || oracleBFile.IsNull)
				{
					array2[j] = null;
					continue;
				}
				array2[j] = oracleBFile.Value;
				oracleBFile.Dispose();
			}
			m_value = array2;
		}
		else if (m_value != DBNull.Value)
		{
			OracleBFile oracleBFile2 = (OracleBFile)m_value;
			if (oracleBFile2.IsNull)
			{
				m_value = DBNull.Value;
				return;
			}
			m_value = oracleBFile2.Value;
			oracleBFile2.Dispose();
		}
	}

	private unsafe void PreBind_Blob(OracleConnection conn, bool bIsFromEF)
	{
		byte[] array = null;
		object obj = null;
		if (conn.m_majorVersion >= 9 && m_direction == ParameterDirection.Input && !m_bArrayBind && !(m_value is OracleBlob))
		{
			int num = 0;
			num = ((*m_pOpoPrmValCtx->pInd != -1) ? GetBindingSize_Raw(0) : 0);
			if (num < 4000 && num > 0)
			{
				m_redirected = true;
				PreBind_Raw();
				return;
			}
		}
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			m_saveValue = new object[m_arrBindCount];
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array2))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array2.GetValue(i);
				}
				if (obj is OracleBlob oracleBlob)
				{
					if (oracleBlob.m_connection == conn || (oracleBlob.m_connection.m_contextConnection && conn.m_contextConnection))
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							if (oracleBlob.IsNull)
							{
								OraTrace.Trace(1u, " (LOB) OracleBlob passed by App(PreBind): OracleBlob.Null \n");
							}
							else
							{
								OraTrace.Trace(1u, " (LOB) OracleBlob passed by App(PreBind): " + oracleBlob.LobCtx + "\n");
							}
						}
						if (oracleBlob.m_conSignature != conn.m_conSignature)
						{
							throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
						}
						if (oracleBlob.m_isTemporaryLob)
						{
							oracleBlob.CreateTempLob();
						}
						SetPrmValCtx(oracleBlob.LobCtx, i);
						continue;
					}
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_DIFFERENT_CONNECTIONS));
				}
				array = GetPreBindBuffer_Raw(i);
				int bindingSize = GetBindingSize(array, i);
				if (OraTrace.m_TraceLevel != 0)
				{
					if (m_direction == ParameterDirection.Input)
					{
						OraTrace.Trace(1u, " (LOB) Creating OracleBlob object(PreBind-Input)\n");
					}
					else
					{
						OraTrace.Trace(1u, " (LOB) Creating OracleBlob object(PreBind-IO)\n");
					}
				}
				OracleBlob oracleBlob2 = new OracleBlob(conn);
				oracleBlob2.Write(array, m_offset, bindingSize, bIsFromEF);
				SetPrmValCtx(oracleBlob2.LobCtx, i);
				m_saveValue[i] = oracleBlob2;
			}
		}
		SetPrmValCtx(OraType.ORA_OCIBLobLocator, -1, null);
	}

	private unsafe void PostBind_Blob(OracleConnection conn)
	{
		OracleBlob[] array = null;
		if (m_redirected)
		{
			m_redirected = false;
			PostBind_Raw();
			return;
		}
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (LOB) Creating OracleBlob object:O/RV(PostBind)\n");
					}
					m_value = new OracleBlob(conn, (IntPtr)(*(int*)m_pOpoPrmValCtx->pBltVal), bCaching: false, bTempLob: false);
					m_status = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = OracleBlob.Null;
					}
					else
					{
						m_value = DBNull.Value;
					}
					m_status = OracleParameterStatus.NullFetched;
				}
				break;
			}
			array = new OracleBlob[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (LOB) Creating OracleBlob objects:O/RV(PostBind)\n");
					}
					array[i] = new OracleBlob(conn, (IntPtr)(*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)), bCaching: false, bTempLob: false);
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					m_curArrayBindSize[i] = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						array[i] = OracleBlob.Null;
					}
					else
					{
						array[i] = null;
					}
					m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
				}
			}
			m_value = array;
			break;
		}
		case ParameterDirection.InputOutput:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (*m_pOpoPrmValCtx->pSrcInd == -1)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(1u, " (LOB) Creating OracleBlob object:IO(PostBind)\n");
						}
						m_value = new OracleBlob(conn, (IntPtr)(*(int*)m_pOpoPrmValCtx->pBltVal), bCaching: false, bTempLob: false);
					}
					else if (!(m_value is OracleBlob))
					{
						m_value = m_saveValue[0];
						m_saveValue = null;
					}
					m_status = OracleParameterStatus.Success;
					break;
				}
				if (*m_pOpoPrmValCtx->pSrcInd != -1)
				{
					if (m_value is OracleBlob)
					{
						((OracleBlob)m_value).Dispose();
					}
					else
					{
						((OracleBlob)m_saveValue[0]).Dispose();
						m_saveValue = null;
					}
				}
				m_curSize = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					m_value = OracleBlob.Null;
				}
				else
				{
					m_value = DBNull.Value;
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			array = new OracleBlob[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_pOpoPrmValCtx->pSrcInd[i] == -1)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(1u, " (LOB) Creating OracleBlob objects:IO(PostBind)\n");
						}
						array[i] = new OracleBlob(conn, (IntPtr)(*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)), bCaching: false, bTempLob: false);
					}
					else if (!(m_value is OracleBlob[]))
					{
						array[i] = (OracleBlob)m_saveValue[i];
						m_saveValue[i] = null;
					}
					else
					{
						array[i] = ((OracleBlob[])m_value)[i];
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
					continue;
				}
				if (m_pOpoPrmValCtx->pSrcInd[i] != -1)
				{
					if (m_value is OracleBlob[])
					{
						((OracleBlob[])m_value)[i].Dispose();
					}
					else
					{
						if (((Array)m_value).GetValue(i) is OracleBlob)
						{
							((OracleBlob)((Array)m_value).GetValue(i)).Dispose();
							((Array)m_value).SetValue(null, i);
						}
						if (m_saveValue[i] is OracleBlob)
						{
							((OracleBlob)m_saveValue[i]).Dispose();
							m_saveValue[i] = null;
						}
					}
				}
				m_curSize = 0;
				m_curArrayBindSize[i] = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					array[i] = OracleBlob.Null;
				}
				else
				{
					array[i] = null;
				}
				m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
			}
			m_value = array;
			break;
		}
		case ParameterDirection.Input:
		{
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pSrcInd[i] != -1 && !(m_value is OracleBlob) && !IsElemType(typeof(OracleBlob), m_value, i))
				{
					((OracleBlob)m_saveValue[i]).Dispose();
				}
			}
			m_saveValue = null;
			break;
		}
		}
		if (m_enumType != PrmEnumType.DBTYPE || !m_bOracleDbTypeExSet || m_direction == ParameterDirection.Input)
		{
			return;
		}
		if (m_bArrayBind)
		{
			byte[][] array2 = new byte[m_arrBindCount][];
			for (int j = 0; j < m_arrBindCount; j++)
			{
				OracleBlob oracleBlob = array[j];
				if (oracleBlob == null || oracleBlob.IsNull)
				{
					array2[j] = null;
					continue;
				}
				array2[j] = oracleBlob.Value;
				oracleBlob.Dispose();
			}
			m_value = array2;
		}
		else if (m_value != DBNull.Value)
		{
			OracleBlob oracleBlob2 = (OracleBlob)m_value;
			if (oracleBlob2.IsNull)
			{
				m_value = DBNull.Value;
				return;
			}
			m_value = oracleBlob2.Value;
			oracleBlob2.Dispose();
		}
	}

	private unsafe void PreBind_Clob(OracleConnection conn, bool bIsFromEF, bool bIsSelectStmt)
	{
		char[] array = null;
		if (conn.m_majorVersion >= 9 && m_direction == ParameterDirection.Input && !m_bArrayBind && !(m_value is OracleClob))
		{
			int num = 0;
			num = ((*m_pOpoPrmValCtx->pInd != -1) ? GetBindingSize_Char(0) : 0);
			if (m_pOpoPrmValCtx->CharSetForm == 2)
			{
				int maxBytesPerNChar = OpsCon.GetMaxBytesPerNChar(conn.m_opoConCtx.opsConCtx);
				if (num < 4000 / maxBytesPerNChar && (num > 0 || (num == 0 && bIsFromEF && bIsSelectStmt)))
				{
					m_redirected = true;
					PreBind_Char();
					return;
				}
			}
			else if (num < 4000 && (num > 0 || (num == 0 && bIsFromEF && bIsSelectStmt)))
			{
				m_redirected = true;
				PreBind_Char();
				return;
			}
		}
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			m_saveValue = new object[m_arrBindCount];
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array2))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array2.GetValue(i);
				}
				if (obj is OracleClob oracleClob)
				{
					if (oracleClob.m_connection == conn || (oracleClob.m_connection.m_contextConnection && conn.m_contextConnection))
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							if (oracleClob.IsNull)
							{
								OraTrace.Trace(1u, " (LOB) Clob passed by App(PreBind): OracleClob.Null \n");
							}
							else
							{
								OraTrace.Trace(1u, " (LOB) Clob passed by App(PreBind): " + oracleClob.LobCtx + "\n");
							}
						}
						if (oracleClob.m_conSignature != conn.m_conSignature)
						{
							throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
						}
						if (oracleClob.m_isTemporaryLob)
						{
							oracleClob.CreateTempLob();
						}
						SetPrmValCtx(oracleClob.LobCtx, i);
						continue;
					}
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_DIFFERENT_CONNECTIONS));
				}
				array = GetPreBindBuffer_Char(i);
				int bindingSize = GetBindingSize(array, i);
				if (OraTrace.m_TraceLevel != 0)
				{
					if (m_direction == ParameterDirection.Input)
					{
						OraTrace.Trace(1u, " (LOB) Creating Clob object(PreBind-Input)\n");
					}
					else
					{
						OraTrace.Trace(1u, " (LOB) Creating Clob object(PreBind-IO)\n");
					}
				}
				OracleClob oracleClob2 = ((m_oraDbType != OracleDbType.NClob) ? new OracleClob(conn, bCaching: false, bNClob: false) : new OracleClob(conn, bCaching: false, bNClob: true));
				m_saveValue[i] = oracleClob2;
				oracleClob2.Write(array, m_offset, bindingSize, bIsFromEF);
				SetPrmValCtx(oracleClob2.LobCtx, i);
			}
		}
		SetPrmValCtx(OraType.ORA_OCICLobLocator, -1, null);
	}

	private unsafe void PostBind_Clob(OracleConnection conn, bool isNClob)
	{
		OracleClob[] array = null;
		if (m_redirected)
		{
			m_redirected = false;
			PostBind_Char();
			return;
		}
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					bool bNClob3 = m_oraDbType == OracleDbType.NClob;
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (LOB) Creating Clob object:O/RV(PostBind)\n");
					}
					m_value = new OracleClob(conn, (IntPtr)(*(int*)m_pOpoPrmValCtx->pBltVal), bCaching: false, bNClob3, bTempLob: false);
					m_status = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = OracleClob.Null;
					}
					else
					{
						m_value = DBNull.Value;
					}
					m_status = OracleParameterStatus.NullFetched;
				}
				break;
			}
			array = new OracleClob[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					bool bNClob4 = m_oraDbType == OracleDbType.NClob;
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (LOB) Creating Clob objects:O/RV(PostBind)\n");
					}
					array[i] = new OracleClob(conn, (IntPtr)(*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)), bCaching: false, bNClob4, bTempLob: false);
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					m_curArrayBindSize[i] = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						array[i] = OracleClob.Null;
					}
					else
					{
						array[i] = null;
					}
					m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
				}
			}
			m_value = array;
			break;
		}
		case ParameterDirection.InputOutput:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (*m_pOpoPrmValCtx->pSrcInd == -1)
					{
						bool bNClob = m_oraDbType == OracleDbType.NClob;
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(1u, " (LOB) Creating Clob object:IO(PostBind)\n");
						}
						m_value = new OracleClob(conn, (IntPtr)(*(int*)m_pOpoPrmValCtx->pBltVal), bCaching: false, bNClob, bTempLob: false);
					}
					else if (!(m_value is OracleClob))
					{
						m_value = m_saveValue[0];
						m_saveValue = null;
					}
					m_status = OracleParameterStatus.Success;
					break;
				}
				if (*m_pOpoPrmValCtx->pSrcInd != -1)
				{
					if (m_value is OracleClob)
					{
						((OracleClob)m_value).Dispose();
					}
					else
					{
						((OracleClob)m_saveValue[0]).Dispose();
						m_saveValue = null;
					}
				}
				m_curSize = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					m_value = OracleClob.Null;
				}
				else
				{
					m_value = DBNull.Value;
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			array = new OracleClob[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_pOpoPrmValCtx->pSrcInd[i] == -1)
					{
						bool bNClob2 = m_oraDbType == OracleDbType.NClob;
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(1u, " (LOB) Creating Clob objects:IO(PostBind)\n");
						}
						array[i] = new OracleClob(conn, (IntPtr)(*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)), bCaching: false, bNClob2, bTempLob: false);
					}
					else if (m_value is OracleClob[])
					{
						array[i] = ((OracleClob[])m_value)[i];
					}
					else
					{
						array[i] = (OracleClob)m_saveValue[i];
						m_saveValue[i] = null;
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
					continue;
				}
				if (m_pOpoPrmValCtx->pSrcInd[i] != -1)
				{
					if (m_value is OracleClob[])
					{
						((OracleClob[])m_value)[i].Dispose();
					}
					else
					{
						if (((Array)m_value).GetValue(i) is OracleClob)
						{
							((OracleClob)((Array)m_value).GetValue(i)).Dispose();
							((Array)m_value).SetValue(null, i);
						}
						if (m_saveValue[i] is OracleClob)
						{
							((OracleClob)m_saveValue[i]).Dispose();
							m_saveValue[i] = null;
						}
					}
				}
				m_curSize = 0;
				m_curArrayBindSize[i] = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					array[i] = OracleClob.Null;
				}
				else
				{
					array[i] = null;
				}
				m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
			}
			m_value = array;
			break;
		}
		case ParameterDirection.Input:
		{
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pSrcInd[i] != -1 && !(m_value is OracleClob) && !IsElemType(typeof(OracleClob), m_value, i))
				{
					((OracleClob)m_saveValue[i]).Dispose();
				}
			}
			m_saveValue = null;
			break;
		}
		}
		if (m_enumType != PrmEnumType.DBTYPE || !m_bOracleDbTypeExSet || m_direction == ParameterDirection.Input)
		{
			return;
		}
		if (m_bArrayBind)
		{
			string[] array2 = new string[m_arrBindCount];
			for (int j = 0; j < m_arrBindCount; j++)
			{
				OracleClob oracleClob = array[j];
				if (oracleClob == null || oracleClob.IsNull)
				{
					array2[j] = null;
					continue;
				}
				array2[j] = oracleClob.Value;
				oracleClob.Dispose();
			}
			m_value = array2;
		}
		else if (m_value != DBNull.Value)
		{
			OracleClob oracleClob2 = (OracleClob)m_value;
			if (oracleClob2.IsNull)
			{
				m_value = DBNull.Value;
				return;
			}
			m_value = oracleClob2.Value;
			oracleClob2.Dispose();
		}
	}

	private bool IsElemType(Type type, object value, int index)
	{
		Type type2 = null;
		bool result = false;
		if (value != null)
		{
			if (value is Array array && array.Length > 0 && array.GetValue(index) != null)
			{
				type2 = array.GetValue(index).GetType();
			}
			result = type2 == type;
		}
		return result;
	}

	private unsafe void PreBind_Char()
	{
		OraType oraType = OraType.ORA_CHARN;
		if (m_oraDbType == OracleDbType.Char || m_oraDbType == OracleDbType.NChar)
		{
			oraType = OraType.ORA_CHAR;
		}
		int num2;
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			int[] array;
			int num;
			if (m_bArrayBind)
			{
				array = new int[m_arrBindCount];
				num = 0;
				num2 = 0;
				for (int i = 0; i < m_bindElemCount; i++)
				{
					if (m_pOpoPrmValCtx->pInd[i] == -1)
					{
						array[i] = 0;
					}
					else
					{
						array[i] = GetBindingSize_Char(i);
					}
					if (num2 < array[i])
					{
						num2 = array[i];
					}
					if (m_direction == ParameterDirection.InputOutput && m_maxArrayBindSize != null && num2 < m_maxArrayBindSize[i])
					{
						num2 = m_maxArrayBindSize[i];
					}
				}
			}
			else
			{
				array = null;
				num2 = ((*m_pOpoPrmValCtx->pInd != -1) ? (num = GetBindingSize_Char(0)) : (num = 0));
				if (m_direction == ParameterDirection.InputOutput && num < m_maxSize)
				{
					num2 = m_maxSize;
				}
			}
			if (num2 > 0)
			{
				try
				{
					m_pDataBuffer = Marshal.AllocCoTaskMem(num2 * m_arrBindCount * 2);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					throw;
				}
				if (m_pDataBuffer != IntPtr.Zero)
				{
					for (int j = 0; j < m_bindElemCount; j++)
					{
						object value;
						int num3;
						if (!m_bArrayBind)
						{
							value = m_value;
							num3 = num;
						}
						else
						{
							if (!(m_value is Array array2))
							{
								throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
							}
							value = array2.GetValue(j);
							num3 = array[j];
						}
						if (num3 > 0)
						{
							if (value is string text)
							{
								Marshal.Copy(text.ToCharArray(), m_offset, (IntPtr)((byte*)(void*)m_pDataBuffer + (nint)(j * num2) * (nint)2), num3);
							}
							else if (value is char[] source)
							{
								Marshal.Copy(source, m_offset, (IntPtr)((byte*)(void*)m_pDataBuffer + (nint)(j * num2) * (nint)2), num3);
							}
							else if (value is OracleString oracleString)
							{
								Marshal.Copy(oracleString.Value.ToCharArray(), m_offset, (IntPtr)((byte*)(void*)m_pDataBuffer + (nint)(j * num2) * (nint)2), num3);
							}
							else if (value is char)
							{
								Marshal.Copy(new char[1] { (char)value }, 0, (IntPtr)((byte*)(void*)m_pDataBuffer + (nint)(j * num2) * (nint)2), num3);
							}
							else
							{
								string text2 = Convert.ToString(value);
								Marshal.Copy(text2.ToCharArray(), m_offset, (IntPtr)((byte*)(void*)m_pDataBuffer + (nint)(j * num2) * (nint)2), num3);
							}
						}
					}
					SetPrmValCtx(m_pDataBuffer, 0);
				}
			}
			if (m_bArrayBind)
			{
				SetPrmValCtx(oraType, num2, array);
			}
			else if (m_oraDbType == OracleDbType.Clob)
			{
				SetPrmValCtx(oraType, num, null, OracleDbType.Varchar2);
			}
			else if (m_oraDbType == OracleDbType.NClob)
			{
				SetPrmValCtx(oraType, num, null, OracleDbType.NVarchar2);
			}
			else
			{
				SetPrmValCtx(oraType, num, null);
			}
			return;
		}
		if (!m_bArrayBind)
		{
			num2 = ((m_maxSize != -1) ? m_maxSize : 0);
		}
		else if (m_maxArrayBindSize != null)
		{
			num2 = m_maxArrayBindSize[0];
			for (int k = 0; k < m_arrBindCount; k++)
			{
				if (m_maxArrayBindSize[k] > num2)
				{
					num2 = m_maxArrayBindSize[k];
				}
			}
			if (num2 == -1)
			{
				num2 = 0;
			}
		}
		else
		{
			num2 = 0;
		}
		if (num2 > 0)
		{
			try
			{
				m_pDataBuffer = Marshal.AllocCoTaskMem(num2 * m_arrBindCount * 2);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				throw;
			}
			if (m_pDataBuffer != IntPtr.Zero)
			{
				SetPrmValCtx(m_pDataBuffer, 0);
			}
		}
		if (!m_bArrayBind)
		{
			SetPrmValCtx(oraType, num2, null);
		}
		else
		{
			SetPrmValCtx(oraType, num2, m_maxArrayBindSize);
		}
	}

	private int GetBindingSize_Char(int idx)
	{
		int bufferLength = 0;
		bool flag = false;
		if (m_bArrayBind)
		{
			if (m_value is string[] array)
			{
				bufferLength = array[idx].Length;
			}
			else if (m_value is char[][] array2)
			{
				bufferLength = array2[idx].Length;
			}
			else if (m_value is char[])
			{
				bufferLength = 1;
			}
			else if (m_value is OracleString[] array3)
			{
				bufferLength = array3[idx].Length;
			}
			else
			{
				flag = true;
			}
		}
		if (!m_bArrayBind || flag)
		{
			object obj = (m_bArrayBind ? ((Array)m_value).GetValue(idx) : m_value);
			bufferLength = ((!(obj is string text)) ? ((!(obj is char[] array4)) ? ((obj is char) ? 1 : ((!(obj is OracleString oracleString)) ? Convert.ToString(obj).Length : oracleString.Length)) : array4.Length) : text.Length);
		}
		return GetBindingSize(bufferLength, idx);
	}

	private int GetBindingSize_Raw(int idx)
	{
		int bufferLength = 0;
		bool flag = false;
		if (m_bArrayBind)
		{
			if (m_value is byte[][] array)
			{
				bufferLength = array[idx].Length;
			}
			else if (m_value is OracleBinary[] array2)
			{
				bufferLength = array2[idx].Length;
			}
			else
			{
				flag = true;
			}
		}
		if (!m_bArrayBind || flag)
		{
			object obj = null;
			obj = (m_bArrayBind ? ((Array)m_value).GetValue(idx) : m_value);
			if (obj is byte[] array3)
			{
				bufferLength = array3.Length;
			}
			else if (obj is OracleBinary oracleBinary)
			{
				bufferLength = oracleBinary.Length;
			}
			else
			{
				if (!(obj is Guid))
				{
					throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
				}
				bufferLength = 16;
			}
		}
		return GetBindingSize(bufferLength, idx);
	}

	private int GetBindingSize(int bufferLength, int idx)
	{
		int num = ((!m_bArrayBind) ? ((m_maxSize != -1) ? m_maxSize : bufferLength) : ((m_maxArrayBindSize[idx] != -1) ? m_maxArrayBindSize[idx] : bufferLength));
		if (m_offset > bufferLength)
		{
			throw new ArgumentException("Invalid offset", ParameterName);
		}
		if (m_offset + num > bufferLength)
		{
			num = bufferLength - m_offset;
		}
		return num;
	}

	private int GetBindingSize(Array buffer, int idx)
	{
		int num = ((!m_bArrayBind) ? ((m_maxSize != -1) ? m_maxSize : buffer.Length) : ((m_maxArrayBindSize[idx] != -1) ? m_maxArrayBindSize[idx] : buffer.Length));
		if (m_offset > buffer.Length)
		{
			throw new ArgumentException("Invalid offset", ParameterName);
		}
		if (m_offset + num > buffer.Length)
		{
			num = buffer.Length - m_offset;
		}
		return num;
	}

	private char[] GetPreBindBuffer_Char(int idx)
	{
		char[] array = null;
		object obj = null;
		if (!m_bArrayBind)
		{
			obj = m_value;
		}
		else
		{
			if (!(m_value is Array array2))
			{
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
			}
			obj = array2.GetValue(idx);
		}
		if (obj is string text)
		{
			return text.ToCharArray();
		}
		if (obj is char[] result)
		{
			return result;
		}
		if (obj is char c)
		{
			return c.ToString().ToCharArray();
		}
		if (obj is OracleString oracleString)
		{
			return oracleString.Value.ToCharArray();
		}
		return Convert.ToString(obj).ToCharArray();
	}

	private string GetPreBindBuffer_Str(int idx)
	{
		object obj = null;
		if (!m_bArrayBind)
		{
			obj = m_value;
		}
		else
		{
			if (!(m_value is Array array))
			{
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
			}
			obj = array.GetValue(idx);
		}
		if (obj is string result)
		{
			return result;
		}
		if (obj is char[] value)
		{
			return new string(value);
		}
		if (obj is char)
		{
			return new string((char)obj, 1);
		}
		if (obj is OracleString oracleString)
		{
			return oracleString.Value;
		}
		return Convert.ToString(obj);
	}

	private byte[] GetPreBindBuffer_Raw(int idx)
	{
		byte[] array = null;
		object obj = null;
		if (!m_bArrayBind)
		{
			obj = m_value;
		}
		else
		{
			if (!(m_value is Array array2))
			{
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
			}
			obj = array2.GetValue(idx);
		}
		if (obj is byte[] result)
		{
			return result;
		}
		if (obj is OracleBinary)
		{
			return (byte[])(OracleBinary)obj;
		}
		throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
	}

	private unsafe void PostBind_Char()
	{
		try
		{
			switch (m_direction)
			{
			case ParameterDirection.Output:
			case ParameterDirection.InputOutput:
			case ParameterDirection.ReturnValue:
			{
				if (!m_bArrayBind)
				{
					if (*m_pOpoPrmValCtx->pInd != -1)
					{
						if (m_enumType == PrmEnumType.ORADBTYPE)
						{
							m_value = new OracleString(new string((char*)(void*)m_pDataBuffer, 0, (int)(*m_pOpoPrmValCtx->alenp) / 2));
						}
						else
						{
							m_value = new string((char*)(void*)m_pDataBuffer, 0, (int)(*m_pOpoPrmValCtx->alenp) / 2);
						}
						m_curSize = (int)(*m_pOpoPrmValCtx->alenp) / 2;
						m_status = OracleParameterStatus.Success;
					}
					else
					{
						m_curSize = 0;
						if (PrmEnumType.ORADBTYPE == m_enumType)
						{
							m_value = OracleString.Null;
						}
						else
						{
							m_value = DBNull.Value;
						}
						m_status = OracleParameterStatus.NullFetched;
					}
					break;
				}
				OracleString[] array = null;
				string[] array2 = null;
				if (m_enumType == PrmEnumType.ORADBTYPE)
				{
					array = new OracleString[m_arrBindCount];
				}
				else
				{
					array2 = new string[m_arrBindCount];
				}
				for (int i = 0; i < m_arrBindCount; i++)
				{
					int num = 0;
					num = ((m_pOpoPrmValCtx->alenp[i] <= m_maxArrayBindSize[i] * 2) ? m_pOpoPrmValCtx->alenp[i] : ((m_maxArrayBindSize[i] > -1) ? (m_maxArrayBindSize[i] * 2) : 0));
					if (m_pOpoPrmValCtx->pInd[i] != -1)
					{
						if (m_enumType == PrmEnumType.ORADBTYPE)
						{
							ref OracleString reference = ref array[i];
							reference = new OracleString(new string((char*)(void*)m_pDataBuffer, m_pOpoPrmValCtx->Size / 2 * i, num / 2));
						}
						else
						{
							array2[i] = new string((char*)(void*)m_pDataBuffer, m_pOpoPrmValCtx->Size / 2 * i, num / 2);
						}
						m_curArrayBindSize[i] = num / 2;
						m_arrayBindStatus[i] = OracleParameterStatus.Success;
						continue;
					}
					m_curSize = 0;
					m_curArrayBindSize[i] = 0;
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleString reference2 = ref array[i];
						reference2 = OracleString.Null;
					}
					else
					{
						array2[i] = null;
					}
					m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
				}
				if (m_enumType == PrmEnumType.ORADBTYPE)
				{
					m_value = array;
				}
				else
				{
					m_value = array2;
				}
				break;
			}
			case (ParameterDirection)4:
			case (ParameterDirection)5:
				break;
			}
		}
		finally
		{
			if (m_pDataBuffer != IntPtr.Zero)
			{
				try
				{
					Marshal.FreeCoTaskMem(m_pDataBuffer);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
				m_pDataBuffer = IntPtr.Zero;
			}
		}
	}

	private unsafe void PreBind_Decimal()
	{
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			object obj = null;
			OracleDecimal value = OracleDecimal.Null;
			OracleDecimal oracleDecimal = OracleDecimal.Null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array.GetValue(i);
				}
				if (obj is decimal)
				{
					if (m_precision != 100 || m_scale != 129)
					{
						value = new OracleDecimal((decimal)obj);
					}
					else
					{
						DecimalConv.GetBytes((decimal)obj, (IntPtr)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22));
					}
				}
				else if (obj is byte)
				{
					if (m_precision != 100 || m_scale != 129)
					{
						value = new OracleDecimal((byte)obj);
					}
					else
					{
						byte b = (byte)obj;
						try
						{
							OpsDec.GetValCtxFromInteger(&b, 1, (IntPtr)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22));
						}
						catch (Exception ex)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex);
							}
							throw;
						}
					}
				}
				else if (obj is short)
				{
					if (m_precision != 100 || m_scale != 129)
					{
						value = new OracleDecimal((short)obj);
					}
					else
					{
						short num = (short)obj;
						try
						{
							OpsDec.GetValCtxFromInteger(&num, 2, (IntPtr)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22));
						}
						catch (Exception ex2)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex2);
							}
							throw;
						}
					}
				}
				else if (obj is int)
				{
					if (m_precision != 100 || m_scale != 129)
					{
						value = new OracleDecimal((int)obj);
					}
					else
					{
						int num2 = (int)obj;
						try
						{
							OpsDec.GetValCtxFromInteger(&num2, 4, (IntPtr)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22));
						}
						catch (Exception ex3)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex3);
							}
							throw;
						}
					}
				}
				else if (obj is long)
				{
					if (m_precision != 100 || m_scale != 129)
					{
						value = new OracleDecimal((long)obj);
					}
					else
					{
						long num3 = (long)obj;
						try
						{
							OpsDec.GetValCtxFromInteger(&num3, 8, (IntPtr)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22));
						}
						catch (Exception ex4)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex4);
							}
							throw;
						}
					}
				}
				else if (obj is float)
				{
					OracleDecimal value2 = new OracleDecimal((double)(float)obj);
					if (m_precision != 100 || m_scale != 129)
					{
						value = OracleDecimal.SetPrecisionNoRound(value2, 7);
					}
					else
					{
						try
						{
							OpsDec.GetValCtxForSetPrecNoRound(value2.m_opoDecCtx.m_pValCtx, 7, (IntPtr)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22));
						}
						catch (Exception ex5)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex5);
							}
							throw;
						}
					}
				}
				else if (obj is double)
				{
					if (m_precision != 100 || m_scale != 129)
					{
						value = new OracleDecimal((double)obj);
					}
					else
					{
						byte* ptr = (byte*)(void*)new OracleDecimal((double)obj).m_opoDecCtx.m_pValCtx;
						byte* ptr2 = (byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22;
						for (int j = 0; j <= *ptr; j++)
						{
							ptr2[j] = ptr[j];
						}
					}
				}
				else if (obj is OracleDecimal)
				{
					if (m_precision != 100 || m_scale != 129)
					{
						value = (OracleDecimal)obj;
					}
					else
					{
						byte* ptr3 = (byte*)(void*)((OracleDecimal)obj).m_opoDecCtx.m_pValCtx;
						byte* ptr4 = (byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22;
						for (int k = 0; k <= *ptr3; k++)
						{
							ptr4[k] = ptr3[k];
						}
					}
				}
				else if (obj is OracleString)
				{
					if (m_precision != 100 || m_scale != 129)
					{
						value = new OracleDecimal(((OracleString)obj).Value);
					}
					else
					{
						byte* ptr5 = (byte*)(void*)new OracleDecimal(((OracleString)obj).Value).m_opoDecCtx.m_pValCtx;
						byte* ptr6 = (byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22;
						for (int l = 0; l <= *ptr5; l++)
						{
							ptr6[l] = ptr5[l];
						}
					}
				}
				else if (obj is string numStr)
				{
					if (m_precision != 100 || m_scale != 129)
					{
						value = new OracleDecimal(numStr);
					}
					else
					{
						byte* ptr7 = (byte*)(void*)new OracleDecimal(numStr).m_opoDecCtx.m_pValCtx;
						byte* ptr8 = (byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22;
						for (int m = 0; m <= *ptr7; m++)
						{
							ptr8[m] = ptr7[m];
						}
					}
				}
				else if (obj is byte[] array2)
				{
					if (m_precision != 100 || m_scale != 129)
					{
						value = new OracleDecimal(array2);
					}
					else
					{
						if (array2.Length != 22)
						{
							throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
						}
						int num4 = 0;
						GCHandle gCHandle = GCHandle.Alloc(array2, GCHandleType.Pinned);
						try
						{
							num4 = OpsDec.GetValCtxFromBytes(gCHandle.AddrOfPinnedObject(), (IntPtr)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22));
						}
						catch (Exception ex6)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex6);
							}
							throw;
						}
						finally
						{
							if (gCHandle.IsAllocated)
							{
								gCHandle.Free();
							}
							if (num4 != 0)
							{
								throw new OracleTypeException(num4);
							}
						}
					}
				}
				else if (obj is bool)
				{
					if (m_precision != 100 || m_scale != 129)
					{
						value = new OracleDecimal((short)(((bool)obj) ? 1 : 0));
					}
					else
					{
						short num5 = (short)(((bool)obj) ? 1 : 0);
						try
						{
							OpsDec.GetValCtxFromInteger(&num5, 2, (IntPtr)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22));
						}
						catch (Exception ex7)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex7);
							}
							throw;
						}
					}
				}
				else if (m_precision != 100 || m_scale != 129)
				{
					value = new OracleDecimal(Convert.ToDecimal(obj));
				}
				else
				{
					DecimalConv.GetBytes(Convert.ToDecimal(obj), (IntPtr)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22));
				}
				if (m_precision != 100 || m_scale != 129)
				{
					oracleDecimal.m_opoDecCtx = null;
					if (m_precision != 100 && m_scale != 129)
					{
						oracleDecimal = OracleDecimal.ConvertToPrecScale(value, m_precision, m_scale);
					}
					else if (m_precision != 100)
					{
						oracleDecimal = OracleDecimal.SetPrecision(value, m_precision);
					}
					else if (m_scale != 129)
					{
						oracleDecimal = OracleDecimal.AdjustScale(value, m_scale, fRound: true);
					}
					byte* ptr9 = (byte*)(void*)oracleDecimal.m_opoDecCtx.m_pValCtx;
					byte* ptr10 = (byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22;
					for (int n = 0; n <= *ptr9; n++)
					{
						ptr10[n] = ptr9[n];
					}
				}
			}
		}
		SetPrmValCtx(OraType.ORA_VARNUM, 22, null);
	}

	private unsafe void PostBind_Decimal()
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.InputOutput:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					IntPtr numCtx = IntPtr.Zero;
					if (m_enumType == PrmEnumType.ORADBTYPE || m_precision != 100 || m_scale != 129)
					{
						int num = 0;
						try
						{
							num = OpsDec.AllocValCtxFromBytes((IntPtr)m_pOpoPrmValCtx->pBltVal, out numCtx);
						}
						catch (Exception ex)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex);
							}
							num = ErrRes.INT_ERR;
							throw;
						}
						finally
						{
							if (num != 0)
							{
								if (numCtx != IntPtr.Zero)
								{
									try
									{
										OpsDec.FreeValCtx(numCtx);
									}
									catch (Exception ex2)
									{
										if (OraTrace.m_TraceLevel != 0)
										{
											OraTrace.TraceExceptionInfo(ex2);
										}
									}
									numCtx = IntPtr.Zero;
								}
								if (num != ErrRes.INT_ERR)
								{
									throw new OracleTypeException(num);
								}
							}
						}
					}
					if (m_precision != 100 || m_scale != 129)
					{
						OracleDecimal value = new OracleDecimal(numCtx, getInfo: false);
						OracleDecimal oracleDecimal = OracleDecimal.Null;
						if (m_precision != 100 && m_scale != 129)
						{
							oracleDecimal = OracleDecimal.ConvertToPrecScale(value, m_precision, m_scale);
						}
						else if (m_precision != 100)
						{
							oracleDecimal = OracleDecimal.SetPrecision(value, m_precision);
						}
						else if (m_scale != 129)
						{
							oracleDecimal = OracleDecimal.AdjustScale(value, m_scale, fRound: true);
						}
						if (m_enumType == PrmEnumType.ORADBTYPE)
						{
							m_value = oracleDecimal;
						}
						else
						{
							m_value = oracleDecimal.Value;
						}
					}
					else if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						m_value = new OracleDecimal(numCtx, getInfo: false);
					}
					else
					{
						m_value = DecimalConv.GetDecimal((IntPtr)m_pOpoPrmValCtx->pBltVal);
					}
					m_status = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = OracleDecimal.Null;
					}
					else
					{
						m_value = DBNull.Value;
					}
					m_status = OracleParameterStatus.NullFetched;
				}
				break;
			}
			OracleDecimal[] array = null;
			decimal[] array2 = null;
			IntPtr zero = IntPtr.Zero;
			if (m_enumType == PrmEnumType.ORADBTYPE)
			{
				array = new OracleDecimal[m_arrBindCount];
			}
			else
			{
				array2 = new decimal[m_arrBindCount];
			}
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					zero = IntPtr.Zero;
					if (m_enumType == PrmEnumType.ORADBTYPE || m_precision != 100 || m_scale != 129)
					{
						int num2 = 0;
						try
						{
							num2 = OpsDec.AllocValCtxFromBytes((IntPtr)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22), out zero);
						}
						catch (Exception ex3)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex3);
							}
							num2 = ErrRes.INT_ERR;
							throw;
						}
						finally
						{
							if (num2 != 0)
							{
								if (zero != IntPtr.Zero)
								{
									try
									{
										OpsDec.FreeValCtx(zero);
									}
									catch (Exception ex4)
									{
										if (OraTrace.m_TraceLevel != 0)
										{
											OraTrace.TraceExceptionInfo(ex4);
										}
									}
									zero = IntPtr.Zero;
								}
								if (num2 != ErrRes.INT_ERR)
								{
									throw new OracleTypeException(num2);
								}
							}
						}
					}
					if (m_precision != 100 || m_scale != 129)
					{
						OracleDecimal value2 = new OracleDecimal(zero, getInfo: false);
						OracleDecimal oracleDecimal2 = OracleDecimal.Null;
						if (m_precision != 100 && m_scale != 129)
						{
							oracleDecimal2 = OracleDecimal.ConvertToPrecScale(value2, m_precision, m_scale);
						}
						else if (m_precision != 100)
						{
							oracleDecimal2 = OracleDecimal.SetPrecision(value2, m_precision);
						}
						else if (m_scale != 129)
						{
							oracleDecimal2 = OracleDecimal.AdjustScale(value2, m_scale, fRound: true);
						}
						if (m_enumType == PrmEnumType.ORADBTYPE)
						{
							array[i] = oracleDecimal2;
						}
						else
						{
							ref decimal reference = ref array2[i];
							reference = oracleDecimal2.Value;
						}
					}
					else if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleDecimal reference2 = ref array[i];
						reference2 = new OracleDecimal(zero, getInfo: false);
					}
					else
					{
						ref decimal reference3 = ref array2[i];
						reference3 = DecimalConv.GetDecimal((IntPtr)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22));
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					m_curArrayBindSize[i] = 0;
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleDecimal reference4 = ref array[i];
						reference4 = OracleDecimal.Null;
					}
					else
					{
						m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
					}
				}
			}
			if (m_enumType == PrmEnumType.ORADBTYPE)
			{
				m_value = array;
			}
			else
			{
				m_value = array2;
			}
			break;
		}
		case (ParameterDirection)4:
		case (ParameterDirection)5:
			break;
		}
	}

	private unsafe void PreBind_Date()
	{
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			object obj = null;
			OpoDatValCtx opoDatValCtx = default(OpoDatValCtx);
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					SetPrmValCtx(0L, i);
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array.GetValue(i);
				}
				if (obj is OracleDate oracleDate)
				{
					OracleDate.ToBytes(oracleDate.GetValCtx(), (byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)8);
				}
				else if (obj is DateTime)
				{
					DateTimeConv.ToBytes((DateTime)obj, (byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)8);
				}
				else if (obj is OracleTimeStamp oracleTimeStamp)
				{
					OracleDate.ToBytes(oracleTimeStamp.GetValCtx(), (byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)8);
				}
				else if (obj is OracleTimeStampLTZ oracleTimeStampLTZ)
				{
					OracleDate.ToBytes(oracleTimeStampLTZ.GetValCtx(), (byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)8);
				}
				else if (obj is OracleTimeStampTZ oracleTimeStampTZ)
				{
					OracleDate.ToBytes(oracleTimeStampTZ.GetValCtx(), (byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)8);
				}
				else if (obj is string || obj is char[] || obj is OracleString || obj is char)
				{
					int num = 0;
					string preBindBuffer_Str = GetPreBindBuffer_Str(i);
					try
					{
						num = OpsDat.GetValCtxFromStr(preBindBuffer_Str, &opoDatValCtx);
					}
					catch (Exception ex)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex);
						}
						throw;
					}
					finally
					{
						if (num != 0)
						{
							throw new ArgumentException(OracleTypeException.GetTypeMsg(num, ParameterName));
						}
					}
					OracleDate.ToBytes(&opoDatValCtx, (byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)8);
				}
				else if (obj is byte[] array2)
				{
					int year = (array2[0] - 100) * 100 + array2[1] - 100;
					int month = array2[2];
					int day = array2[3];
					int hour = array2[4] - 1;
					int minute = array2[5] - 1;
					int second = array2[6] - 1;
					if (!TimeStamp.IsValidDateTime(year, month, day, hour, minute, second, 0))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					byte* ptr = (byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)8;
					for (int j = 0; j < 7; j++)
					{
						ptr[j] = array2[j];
					}
				}
				else
				{
					DateTimeConv.ToBytes(Convert.ToDateTime(obj), (byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)8);
				}
			}
		}
		SetPrmValCtx(OraType.ORA_DATE, 7, null);
	}

	private unsafe void PostBind_Date()
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.InputOutput:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						m_value = new OracleDate((OpoDatValCtx*)(*(ulong*)m_pOpoPrmValCtx->pBltVal));
					}
					else if (m_bOracleDbTypeExSet)
					{
						m_value = new OracleDate((OpoDatValCtx*)(*(ulong*)m_pOpoPrmValCtx->pBltVal)).Value;
					}
					else
					{
						m_value = DateTimeConv.GetDateTime((byte*)m_pOpoPrmValCtx->pBltVal);
					}
					m_status = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = OracleDate.Null;
					}
					else
					{
						m_value = DBNull.Value;
					}
					m_status = OracleParameterStatus.NullFetched;
				}
				break;
			}
			DateTime[] array = new DateTime[m_arrBindCount];
			OracleDate[] array2 = new OracleDate[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleDate reference = ref array2[i];
						reference = new OracleDate((OpoDatValCtx*)(*(ulong*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)8)));
					}
					else if (m_bOracleDbTypeExSet)
					{
						ref DateTime reference2 = ref array[i];
						reference2 = new OracleDate((OpoDatValCtx*)(*(ulong*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)8))).Value;
					}
					else
					{
						ref DateTime reference3 = ref array[i];
						reference3 = DateTimeConv.GetDateTime((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)8);
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					m_curArrayBindSize[i] = 0;
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleDate reference4 = ref array2[i];
						reference4 = OracleDate.Null;
					}
					m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
				}
			}
			if (m_enumType == PrmEnumType.ORADBTYPE)
			{
				m_value = array2;
			}
			else
			{
				m_value = array;
			}
			break;
		}
		}
		m_saveValue = null;
	}

	private unsafe void PreBind_Byte()
	{
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array.GetValue(i);
				}
				if (obj is byte)
				{
					SetPrmValCtx((byte)obj, i);
				}
				else if (obj is OracleDecimal)
				{
					SetPrmValCtx(((OracleDecimal)obj).ToByte(), i);
				}
				else if (obj is OracleString)
				{
					SetPrmValCtx(Convert.ToByte(((OracleString)obj).Value), i);
				}
				else if (obj is byte[] array2)
				{
					if (array2.Length != 22)
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					byte b = 0;
					GCHandle gCHandle = default(GCHandle);
					try
					{
						gCHandle = GCHandle.Alloc(obj, GCHandleType.Pinned);
						b = Convert.ToByte(DecimalConv.GetDecimal(gCHandle.AddrOfPinnedObject()));
					}
					finally
					{
						if (gCHandle.IsAllocated)
						{
							gCHandle.Free();
						}
					}
					SetPrmValCtx(b, i);
				}
				else
				{
					SetPrmValCtx(Convert.ToByte(obj), i);
				}
			}
		}
		SetPrmValCtx(OraType.ORA_SB1, 1, null);
	}

	private unsafe void PostBind_Byte()
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.InputOutput:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = new OracleDecimal(*(byte*)m_pOpoPrmValCtx->pBltVal);
					}
					else
					{
						m_value = *(byte*)m_pOpoPrmValCtx->pBltVal;
					}
					m_status = OracleParameterStatus.Success;
					break;
				}
				m_curSize = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					m_value = OracleDecimal.Null;
				}
				else
				{
					m_value = DBNull.Value;
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			OracleDecimal[] array = new OracleDecimal[m_arrBindCount];
			byte[] array2 = new byte[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						ref OracleDecimal reference = ref array[i];
						reference = new OracleDecimal(((byte*)m_pOpoPrmValCtx->pBltVal)[i]);
					}
					else
					{
						array2[i] = ((byte*)m_pOpoPrmValCtx->pBltVal)[i];
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
					continue;
				}
				m_curSize = 0;
				m_curArrayBindSize[i] = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					ref OracleDecimal reference2 = ref array[i];
					reference2 = OracleDecimal.Null;
				}
				else
				{
					array2[i] = 0;
				}
				m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
			}
			if (PrmEnumType.ORADBTYPE == m_enumType)
			{
				m_value = array;
			}
			else
			{
				m_value = array2;
			}
			break;
		}
		case (ParameterDirection)4:
		case (ParameterDirection)5:
			break;
		}
	}

	private unsafe void PreBind_Double(OracleConnection conn, OracleDbType OraDbType)
	{
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array.GetValue(i);
				}
				if (obj is double)
				{
					SetPrmValCtx((double)obj, i);
				}
				else if (obj is OracleDecimal)
				{
					SetPrmValCtx(((OracleDecimal)obj).ToDouble(), i);
				}
				else if (obj is OracleString)
				{
					SetPrmValCtx(Convert.ToDouble(((OracleString)obj).Value), i);
				}
				else if (obj is byte[] array2)
				{
					if (array2.Length != 22)
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					double d = 0.0;
					GCHandle gCHandle = default(GCHandle);
					try
					{
						gCHandle = GCHandle.Alloc(obj, GCHandleType.Pinned);
						d = (double)(object)DecimalConv.GetNum(gCHandle.AddrOfPinnedObject(), DbType.Double);
					}
					finally
					{
						if (gCHandle.IsAllocated)
						{
							gCHandle.Free();
						}
					}
					SetPrmValCtx(d, i);
				}
				else
				{
					SetPrmValCtx(Convert.ToDouble(obj), i);
				}
			}
		}
		if (OraDbType != OracleDbType.BinaryDouble)
		{
			SetPrmValCtx(OraType.ORA_FLOAT, 8, null);
			return;
		}
		if (conn.m_majorVersion < 10)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
		}
		SetPrmValCtx(OraType.ORA_BDOUBLE, 8, null);
	}

	private unsafe void PostBind_Double()
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.InputOutput:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = new OracleDecimal(*(double*)m_pOpoPrmValCtx->pBltVal);
					}
					else
					{
						m_value = *(double*)m_pOpoPrmValCtx->pBltVal;
					}
					m_status = OracleParameterStatus.Success;
					break;
				}
				m_curSize = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					m_value = OracleDecimal.Null;
				}
				else
				{
					m_value = DBNull.Value;
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			OracleDecimal[] array = new OracleDecimal[m_arrBindCount];
			double[] array2 = new double[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleDecimal reference = ref array[i];
						reference = new OracleDecimal(*(double*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)8));
					}
					else
					{
						array2[i] = *(double*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)8);
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
					continue;
				}
				m_curSize = 0;
				m_curArrayBindSize[i] = 0;
				if (m_enumType == PrmEnumType.ORADBTYPE)
				{
					ref OracleDecimal reference2 = ref array[i];
					reference2 = OracleDecimal.Null;
				}
				else
				{
					array2[i] = 0.0;
				}
				m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
			}
			if (m_enumType == PrmEnumType.ORADBTYPE)
			{
				m_value = array;
			}
			else
			{
				m_value = array2;
			}
			break;
		}
		case (ParameterDirection)4:
		case (ParameterDirection)5:
			break;
		}
	}

	private unsafe void PreBind_Int16()
	{
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array.GetValue(i);
				}
				if (obj is short)
				{
					SetPrmValCtx((short)obj, i);
				}
				else if (obj is OracleDecimal)
				{
					SetPrmValCtx(((OracleDecimal)obj).ToInt16(), i);
				}
				else if (obj is OracleString)
				{
					SetPrmValCtx(Convert.ToInt16(((OracleString)obj).Value), i);
				}
				else if (obj is byte[] array2)
				{
					if (array2.Length != 22)
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					short i2 = 0;
					GCHandle gCHandle = default(GCHandle);
					try
					{
						gCHandle = GCHandle.Alloc(obj, GCHandleType.Pinned);
						i2 = (short)(object)DecimalConv.GetNum(gCHandle.AddrOfPinnedObject(), DbType.Int16);
					}
					finally
					{
						if (gCHandle.IsAllocated)
						{
							gCHandle.Free();
						}
					}
					SetPrmValCtx(i2, i);
				}
				else
				{
					SetPrmValCtx(Convert.ToInt16(obj), i);
				}
			}
		}
		SetPrmValCtx(OraType.ORA_SB1, 2, null);
	}

	private unsafe void PostBind_Int16()
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.InputOutput:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = new OracleDecimal(*(short*)m_pOpoPrmValCtx->pBltVal);
					}
					else
					{
						m_value = *(short*)m_pOpoPrmValCtx->pBltVal;
					}
					m_status = OracleParameterStatus.Success;
					break;
				}
				m_curSize = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					m_value = OracleDecimal.Null;
				}
				else
				{
					m_value = DBNull.Value;
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			OracleDecimal[] array = new OracleDecimal[m_arrBindCount];
			short[] array2 = new short[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleDecimal reference = ref array[i];
						reference = new OracleDecimal(*(short*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)2));
					}
					else
					{
						array2[i] = *(short*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)2);
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
					continue;
				}
				m_curSize = 0;
				m_curArrayBindSize[i] = 0;
				if (m_enumType == PrmEnumType.ORADBTYPE)
				{
					ref OracleDecimal reference2 = ref array[i];
					reference2 = OracleDecimal.Null;
				}
				else
				{
					array2[i] = 0;
				}
				m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
			}
			if (m_enumType == PrmEnumType.ORADBTYPE)
			{
				m_value = array;
			}
			else
			{
				m_value = array2;
			}
			break;
		}
		case (ParameterDirection)4:
		case (ParameterDirection)5:
			break;
		}
	}

	private unsafe void PreBind_Int32()
	{
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array.GetValue(i);
				}
				if (obj is int)
				{
					SetPrmValCtx((int)obj, i);
				}
				else if (obj is OracleDecimal)
				{
					SetPrmValCtx(((OracleDecimal)obj).ToInt32(), i);
				}
				else if (obj is OracleString)
				{
					SetPrmValCtx(Convert.ToInt32(((OracleString)obj).Value), i);
				}
				else if (obj is byte[] array2)
				{
					if (array2.Length != 22)
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					int i2 = 0;
					GCHandle gCHandle = default(GCHandle);
					try
					{
						gCHandle = GCHandle.Alloc(obj, GCHandleType.Pinned);
						i2 = (int)(object)DecimalConv.GetNum(gCHandle.AddrOfPinnedObject(), DbType.Int32);
					}
					finally
					{
						if (gCHandle.IsAllocated)
						{
							gCHandle.Free();
						}
					}
					SetPrmValCtx(i2, i);
				}
				else
				{
					SetPrmValCtx(Convert.ToInt32(obj), i);
				}
			}
		}
		SetPrmValCtx(OraType.ORA_SB1, 4, null);
	}

	private unsafe void PostBind_Int32()
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.InputOutput:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = new OracleDecimal(*(int*)m_pOpoPrmValCtx->pBltVal);
					}
					else
					{
						m_value = *(int*)m_pOpoPrmValCtx->pBltVal;
					}
					m_status = OracleParameterStatus.Success;
					break;
				}
				m_curSize = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					m_value = OracleDecimal.Null;
				}
				else
				{
					m_value = DBNull.Value;
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			OracleDecimal[] array = new OracleDecimal[m_arrBindCount];
			int[] array2 = new int[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleDecimal reference = ref array[i];
						reference = new OracleDecimal(*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4));
					}
					else
					{
						array2[i] = *(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4);
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
					continue;
				}
				m_curSize = 0;
				m_curArrayBindSize[i] = 0;
				if (m_enumType == PrmEnumType.ORADBTYPE)
				{
					ref OracleDecimal reference2 = ref array[i];
					reference2 = OracleDecimal.Null;
				}
				else
				{
					array2[i] = 0;
				}
				m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
			}
			if (m_enumType == PrmEnumType.ORADBTYPE)
			{
				m_value = array;
			}
			else
			{
				m_value = array2;
			}
			break;
		}
		case (ParameterDirection)4:
		case (ParameterDirection)5:
			break;
		}
	}

	private unsafe void PreBind_Int64()
	{
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array.GetValue(i);
				}
				if (obj is long)
				{
					SetPrmValCtx((long)obj, i);
				}
				else if (obj is OracleDecimal)
				{
					SetPrmValCtx(((OracleDecimal)obj).ToInt64(), i);
				}
				else if (obj is OracleString)
				{
					SetPrmValCtx(Convert.ToInt64(((OracleString)obj).Value), i);
				}
				else if (obj is byte[] array2)
				{
					if (array2.Length != 22)
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					long i2 = 0L;
					GCHandle gCHandle = default(GCHandle);
					try
					{
						gCHandle = GCHandle.Alloc(obj, GCHandleType.Pinned);
						i2 = (long)(object)DecimalConv.GetNum(gCHandle.AddrOfPinnedObject(), DbType.Int64);
					}
					finally
					{
						if (gCHandle.IsAllocated)
						{
							gCHandle.Free();
						}
					}
					SetPrmValCtx(i2, i);
				}
				else
				{
					SetPrmValCtx(Convert.ToInt64(obj), i);
				}
			}
		}
		SetPrmValCtx(OraType.ORA_VARNUM, 22, null);
	}

	private unsafe void PostBind_Int64()
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.InputOutput:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = new OracleDecimal(*(long*)m_pOpoPrmValCtx->pBltVal);
					}
					else
					{
						m_value = *(long*)m_pOpoPrmValCtx->pBltVal;
					}
					m_status = OracleParameterStatus.Success;
					break;
				}
				m_curSize = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					m_value = OracleDecimal.Null;
				}
				else
				{
					m_value = DBNull.Value;
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			OracleDecimal[] array = new OracleDecimal[m_arrBindCount];
			long[] array2 = new long[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleDecimal reference = ref array[i];
						reference = new OracleDecimal(*(long*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22));
					}
					else
					{
						array2[i] = *(long*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22);
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
					continue;
				}
				m_curSize = 0;
				m_curArrayBindSize[i] = 0;
				if (m_enumType == PrmEnumType.ORADBTYPE)
				{
					ref OracleDecimal reference2 = ref array[i];
					reference2 = OracleDecimal.Null;
				}
				else
				{
					array2[i] = 0L;
				}
				m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
			}
			if (m_enumType == PrmEnumType.ORADBTYPE)
			{
				m_value = array;
			}
			else
			{
				m_value = array2;
			}
			break;
		}
		case (ParameterDirection)4:
		case (ParameterDirection)5:
			break;
		}
	}

	private unsafe void PreBind_Single(OracleConnection conn, OracleDbType OraDbType)
	{
		bool flag = false;
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			OracleDecimal oracleDecimal = default(OracleDecimal);
			oracleDecimal.m_opoDecCtx = null;
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array.GetValue(i);
				}
				if (obj is float)
				{
					oracleDecimal = new OracleDecimal((double)(float)obj);
				}
				else if (obj is OracleDecimal)
				{
					oracleDecimal = (OracleDecimal)obj;
					flag = true;
				}
				else if (obj is OracleString)
				{
					oracleDecimal = new OracleDecimal(((OracleString)obj).Value);
					flag = true;
				}
				else if (obj is byte[] array2)
				{
					if (array2.Length != 22)
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					oracleDecimal = new OracleDecimal(array2);
					flag = true;
				}
				else
				{
					oracleDecimal = new OracleDecimal((double)Convert.ToSingle(obj));
				}
				if (OraDbType != OracleDbType.BinaryFloat)
				{
					try
					{
						OpsDec.GetValCtxForSetPrecNoRound(oracleDecimal.m_opoDecCtx.m_pValCtx, 7, (IntPtr)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22));
					}
					catch (Exception ex)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex);
						}
						throw;
					}
				}
				else if (flag)
				{
					SetPrmValCtx(oracleDecimal.ToSingle(), i);
				}
				else
				{
					SetPrmValCtx(Convert.ToSingle(obj), i);
				}
			}
		}
		if (OraDbType != OracleDbType.BinaryFloat)
		{
			SetPrmValCtx(OraType.ORA_VARNUM, 22, null);
			return;
		}
		if (conn.m_majorVersion < 10)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
		}
		SetPrmValCtx(OraType.ORA_BFLOAT, 4, null);
	}

	private unsafe void PostBind_Single()
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.InputOutput:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = new OracleDecimal(*(float*)m_pOpoPrmValCtx->pBltVal);
					}
					else
					{
						m_value = *(float*)m_pOpoPrmValCtx->pBltVal;
					}
					m_status = OracleParameterStatus.Success;
					break;
				}
				m_curSize = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					m_value = OracleDecimal.Null;
				}
				else
				{
					m_value = DBNull.Value;
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			OracleDecimal[] array = new OracleDecimal[m_arrBindCount];
			float[] array2 = new float[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						if (m_oraDbType == OracleDbType.BinaryFloat)
						{
							ref OracleDecimal reference = ref array[i];
							reference = new OracleDecimal(*(float*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4));
						}
						else
						{
							ref OracleDecimal reference2 = ref array[i];
							reference2 = new OracleDecimal(*(float*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22));
						}
					}
					else if (m_bOracleDbTypeExSet)
					{
						if (m_oraDbType == OracleDbType.BinaryFloat)
						{
							array2[i] = *(float*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4);
						}
						else
						{
							array2[i] = *(float*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22);
						}
					}
					else
					{
						array2[i] = *(float*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)22);
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					m_curArrayBindSize[i] = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						ref OracleDecimal reference3 = ref array[i];
						reference3 = OracleDecimal.Null;
					}
					else
					{
						array2[i] = 0f;
					}
					m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
				}
			}
			if (PrmEnumType.ORADBTYPE == m_enumType)
			{
				m_value = array;
			}
			else
			{
				m_value = array2;
			}
			break;
		}
		case (ParameterDirection)4:
		case (ParameterDirection)5:
			break;
		}
	}

	private unsafe void PreBind_IntervalDS()
	{
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			m_saveValue = new object[m_arrBindCount];
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array.GetValue(i);
				}
				if (obj is OracleIntervalDS)
				{
					SetPrmValCtx(((OracleIntervalDS)obj).GetValCtx(), i);
					continue;
				}
				if (obj is TimeSpan)
				{
					if (m_direction == ParameterDirection.Input)
					{
						SetPrmValCtx(OracleIntervalDS.AllocValCtxFromData((TimeSpan)obj), i);
						continue;
					}
					OracleIntervalDS oracleIntervalDS = new OracleIntervalDS((TimeSpan)obj);
					SetPrmValCtx(oracleIntervalDS.GetValCtx(), i);
					m_saveValue[i] = oracleIntervalDS;
					continue;
				}
				if (obj is string || obj is char[] || obj is OracleString || obj is char)
				{
					OracleIntervalDS oracleIntervalDS = new OracleIntervalDS(GetPreBindBuffer_Str(i));
					SetPrmValCtx(oracleIntervalDS.GetValCtx(), i);
					m_saveValue[i] = oracleIntervalDS;
					continue;
				}
				if (obj is byte[] binData)
				{
					OracleIntervalDS oracleIntervalDS = new OracleIntervalDS(binData);
					SetPrmValCtx(oracleIntervalDS.GetValCtx(), i);
					m_saveValue[i] = oracleIntervalDS;
					continue;
				}
				if (obj is decimal)
				{
					TimeSpan data = TimeSpan.FromSeconds((double)(decimal)obj);
					if (m_direction == ParameterDirection.Input)
					{
						SetPrmValCtx(OracleIntervalDS.AllocValCtxFromData(data), i);
						continue;
					}
					OracleIntervalDS oracleIntervalDS = new OracleIntervalDS(data);
					SetPrmValCtx(oracleIntervalDS.GetValCtx(), i);
					m_saveValue[i] = oracleIntervalDS;
					continue;
				}
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
			}
		}
		SetPrmValCtx(OraType.ORA_INTERVAL_DS, 0, null);
	}

	private unsafe void PostBind_IntervalDS()
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.InputOutput:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						m_value = new OracleIntervalDS((OpoITLValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal));
					}
					else
					{
						m_value = TimeSpanConv.GetTimeSpan((OpoITLValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal), OracleDbType.IntervalDS);
						try
						{
							OpsIDS.FreeValCtx((OpoITLValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal));
						}
						catch (Exception ex2)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex2);
							}
						}
					}
					m_status = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = OracleIntervalDS.Null;
					}
					else
					{
						m_value = DBNull.Value;
					}
					m_status = OracleParameterStatus.NullFetched;
				}
				break;
			}
			OracleIntervalDS[] array = new OracleIntervalDS[m_arrBindCount];
			TimeSpan[] array2 = new TimeSpan[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleIntervalDS reference = ref array[i];
						reference = new OracleIntervalDS((OpoITLValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
					}
					else
					{
						ref TimeSpan reference2 = ref array2[i];
						reference2 = TimeSpanConv.GetTimeSpan((OpoITLValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)), OracleDbType.IntervalDS);
						try
						{
							OpsIDS.FreeValCtx((OpoITLValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
						}
						catch (Exception ex3)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex3);
							}
						}
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					m_curArrayBindSize[i] = 0;
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleIntervalDS reference3 = ref array[i];
						reference3 = OracleIntervalDS.Null;
					}
					m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
				}
			}
			if (m_enumType == PrmEnumType.ORADBTYPE)
			{
				m_value = array;
			}
			else
			{
				m_value = array2;
			}
			break;
		}
		case ParameterDirection.Input:
		{
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pSrcInd[i] == -1 || (!(m_value is TimeSpan) && !(m_value is TimeSpan[])))
				{
					continue;
				}
				try
				{
					OpsIDS.FreeValCtx((OpoITLValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
			}
			break;
		}
		}
		m_saveValue = null;
	}

	private unsafe void PreBind_IntervalYM()
	{
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			m_saveValue = new object[m_arrBindCount];
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array.GetValue(i);
				}
				if (obj is OracleIntervalYM)
				{
					SetPrmValCtx(((OracleIntervalYM)obj).GetValCtx(), i);
					continue;
				}
				if (obj is byte || obj is short || obj is int || obj is long)
				{
					if (m_direction == ParameterDirection.Input)
					{
						SetPrmValCtx(OracleIntervalYM.AllocValCtxFromData((long)obj), i);
						continue;
					}
					OracleIntervalYM oracleIntervalYM = new OracleIntervalYM((long)obj);
					SetPrmValCtx(oracleIntervalYM.GetValCtx(), i);
					m_saveValue[i] = oracleIntervalYM;
					continue;
				}
				if (obj is string || obj is char[] || obj is OracleString || obj is char)
				{
					OracleIntervalYM oracleIntervalYM = new OracleIntervalYM(GetPreBindBuffer_Str(i));
					SetPrmValCtx(oracleIntervalYM.GetValCtx(), i);
					m_saveValue[i] = oracleIntervalYM;
					continue;
				}
				if (obj is byte[] binData)
				{
					OracleIntervalYM oracleIntervalYM = new OracleIntervalYM(binData);
					SetPrmValCtx(oracleIntervalYM.GetValCtx(), i);
					m_saveValue[i] = oracleIntervalYM;
					continue;
				}
				if (obj is decimal)
				{
					long num = (long)(decimal)obj;
					if (m_direction == ParameterDirection.Input)
					{
						SetPrmValCtx(OracleIntervalYM.AllocValCtxFromData(num), i);
						continue;
					}
					OracleIntervalYM oracleIntervalYM = new OracleIntervalYM(num);
					SetPrmValCtx(oracleIntervalYM.GetValCtx(), i);
					m_saveValue[i] = oracleIntervalYM;
					continue;
				}
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
			}
		}
		SetPrmValCtx(OraType.ORA_INTERVAL_YM, 0, null);
	}

	private unsafe void PostBind_IntervalYM()
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.InputOutput:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						m_value = new OracleIntervalYM((OpoITLValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal));
					}
					else
					{
						m_value = LongConv.GetLong((OpoITLValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal), OracleDbType.IntervalYM);
						try
						{
							OpsIYM.FreeValCtx((OpoITLValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal));
						}
						catch (Exception ex2)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex2);
							}
						}
					}
					m_status = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = OracleIntervalYM.Null;
					}
					else
					{
						m_value = DBNull.Value;
					}
					m_status = OracleParameterStatus.NullFetched;
				}
				break;
			}
			OracleIntervalYM[] array = new OracleIntervalYM[m_arrBindCount];
			long[] array2 = new long[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleIntervalYM reference = ref array[i];
						reference = new OracleIntervalYM((OpoITLValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
					}
					else
					{
						array2[i] = LongConv.GetLong((OpoITLValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)), OracleDbType.IntervalYM);
						try
						{
							OpsIYM.FreeValCtx((OpoITLValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
						}
						catch (Exception ex3)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex3);
							}
						}
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					m_curArrayBindSize[i] = 0;
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleIntervalYM reference2 = ref array[i];
						reference2 = OracleIntervalYM.Null;
					}
					m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
				}
			}
			if (m_enumType == PrmEnumType.ORADBTYPE)
			{
				m_value = array;
			}
			else
			{
				m_value = array2;
			}
			break;
		}
		case ParameterDirection.Input:
		{
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pSrcInd[i] == -1 || (!(m_value is byte) && !(m_value is short) && !(m_value is int) && !(m_value is long) && (!m_bArrayBind || !(m_value is byte[])) && !(m_value is short[]) && !(m_value is int[]) && !(m_value is long[])))
				{
					continue;
				}
				try
				{
					OpsIYM.FreeValCtx((OpoITLValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
			}
			break;
		}
		}
		m_saveValue = null;
	}

	private unsafe void PreBind_Raw()
	{
		_ = IntPtr.Zero;
		int[] array = null;
		int num = 0;
		int num2 = 0;
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			object obj = null;
			int num3 = 0;
			if (m_bArrayBind)
			{
				array = new int[m_arrBindCount];
				for (int i = 0; i < m_bindElemCount; i++)
				{
					if (m_pOpoPrmValCtx->pInd[i] == -1)
					{
						array[i] = 0;
					}
					else
					{
						array[i] = GetBindingSize_Raw(i);
					}
					if (num2 < array[i])
					{
						num2 = array[i];
					}
					if (m_direction == ParameterDirection.InputOutput && m_maxArrayBindSize != null && num2 < m_maxArrayBindSize[i])
					{
						num2 = m_maxArrayBindSize[i];
					}
				}
			}
			else
			{
				num2 = ((*m_pOpoPrmValCtx->pInd != -1) ? (num = GetBindingSize_Raw(0)) : (num = 0));
				if (m_direction == ParameterDirection.InputOutput && num < m_maxSize)
				{
					num2 = m_maxSize;
				}
			}
			if (num2 > 0)
			{
				try
				{
					m_pDataBuffer = Marshal.AllocCoTaskMem(num2 * m_arrBindCount);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					throw;
				}
				if (m_pDataBuffer != IntPtr.Zero)
				{
					for (int j = 0; j < m_bindElemCount; j++)
					{
						if (!m_bArrayBind)
						{
							obj = m_value;
							num3 = num;
						}
						else
						{
							if (!(m_value is Array array2))
							{
								throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
							}
							obj = array2.GetValue(j);
							num3 = array[j];
						}
						if (num3 <= 0)
						{
							continue;
						}
						if (obj is byte[] source)
						{
							Marshal.Copy(source, m_offset, (IntPtr)((byte*)(void*)m_pDataBuffer + (nint)j * (nint)num2), num3);
							continue;
						}
						if (obj is OracleBinary)
						{
							Marshal.Copy((byte[])(OracleBinary)obj, m_offset, (IntPtr)((byte*)(void*)m_pDataBuffer + (nint)j * (nint)num2), num3);
							continue;
						}
						if (obj is Guid guid)
						{
							Marshal.Copy(guid.ToByteArray(), m_offset, (IntPtr)((byte*)(void*)m_pDataBuffer + (nint)j * (nint)num2), num3);
							continue;
						}
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					SetPrmValCtx(m_pDataBuffer, 0);
				}
			}
			if (m_bArrayBind)
			{
				SetPrmValCtx(OraType.ORA_RAW, num2, array);
			}
			else if (m_oraDbType == OracleDbType.Blob)
			{
				SetPrmValCtx(OraType.ORA_RAW, num, null, OracleDbType.Raw);
			}
			else
			{
				SetPrmValCtx(OraType.ORA_RAW, num, null);
			}
			return;
		}
		if (!m_bArrayBind)
		{
			num2 = ((m_maxSize != -1) ? m_maxSize : 0);
		}
		else if (m_maxArrayBindSize != null)
		{
			num2 = m_maxArrayBindSize[0];
			for (int k = 0; k < m_arrBindCount; k++)
			{
				if (m_maxArrayBindSize[k] > num2)
				{
					num2 = m_maxArrayBindSize[k];
				}
			}
			if (num2 == -1)
			{
				num2 = 0;
			}
		}
		else
		{
			num2 = 0;
		}
		try
		{
			m_pDataBuffer = Marshal.AllocCoTaskMem(num2 * m_arrBindCount);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			throw;
		}
		if (m_pDataBuffer != IntPtr.Zero)
		{
			SetPrmValCtx(m_pDataBuffer, 0);
		}
		if (!m_bArrayBind)
		{
			SetPrmValCtx(OraType.ORA_RAW, num2, null);
		}
		else
		{
			SetPrmValCtx(OraType.ORA_RAW, num2, m_maxArrayBindSize);
		}
	}

	private unsafe void PostBind_Raw()
	{
		try
		{
			switch (m_direction)
			{
			case ParameterDirection.Output:
			case ParameterDirection.InputOutput:
			case ParameterDirection.ReturnValue:
			{
				if (!m_bArrayBind)
				{
					if (*m_pOpoPrmValCtx->pInd != -1)
					{
						if (m_enumType == PrmEnumType.ORADBTYPE)
						{
							byte[] array = new byte[*m_pOpoPrmValCtx->alenp];
							Marshal.Copy(m_pDataBuffer, array, 0, *m_pOpoPrmValCtx->alenp);
							m_value = new OracleBinary(array, bCopy: false);
						}
						else
						{
							m_value = new byte[*m_pOpoPrmValCtx->alenp];
							Marshal.Copy(m_pDataBuffer, (byte[])m_value, 0, *m_pOpoPrmValCtx->alenp);
						}
						m_curSize = *m_pOpoPrmValCtx->alenp;
						m_status = OracleParameterStatus.Success;
					}
					else
					{
						m_curSize = 0;
						if (PrmEnumType.ORADBTYPE == m_enumType)
						{
							m_value = OracleBinary.Null;
						}
						else
						{
							m_value = DBNull.Value;
						}
						m_status = OracleParameterStatus.NullFetched;
					}
					break;
				}
				OracleBinary[] array2 = null;
				byte[][] array3 = null;
				if (m_enumType == PrmEnumType.ORADBTYPE)
				{
					array2 = new OracleBinary[m_arrBindCount];
				}
				else
				{
					array3 = new byte[m_arrBindCount][];
				}
				for (int i = 0; i < m_arrBindCount; i++)
				{
					int num = 0;
					num = ((m_pOpoPrmValCtx->alenp[i] <= m_maxArrayBindSize[i]) ? m_pOpoPrmValCtx->alenp[i] : ((m_maxArrayBindSize[i] > -1) ? m_maxArrayBindSize[i] : 0));
					if (m_pOpoPrmValCtx->pInd[i] != -1)
					{
						if (m_enumType == PrmEnumType.ORADBTYPE)
						{
							byte[] array4 = new byte[num];
							Marshal.Copy((IntPtr)((byte*)(void*)m_pDataBuffer + (nint)m_pOpoPrmValCtx->Size * (nint)i), array4, 0, num);
							ref OracleBinary reference = ref array2[i];
							reference = new OracleBinary(array4, bCopy: false);
						}
						else
						{
							array3[i] = new byte[num];
							Marshal.Copy((IntPtr)((byte*)(void*)m_pDataBuffer + (nint)m_pOpoPrmValCtx->Size * (nint)i), array3[i], 0, num);
						}
						m_curArrayBindSize[i] = num;
						m_arrayBindStatus[i] = OracleParameterStatus.Success;
					}
					else
					{
						m_curSize = 0;
						m_curArrayBindSize[i] = 0;
						if (m_enumType == PrmEnumType.ORADBTYPE)
						{
							ref OracleBinary reference2 = ref array2[i];
							reference2 = OracleBinary.Null;
						}
						else
						{
							array3[i] = null;
						}
						m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
					}
				}
				if (m_enumType == PrmEnumType.ORADBTYPE)
				{
					m_value = array2;
				}
				else
				{
					m_value = array3;
				}
				break;
			}
			case (ParameterDirection)4:
			case (ParameterDirection)5:
				break;
			}
		}
		finally
		{
			if (m_pDataBuffer != IntPtr.Zero)
			{
				try
				{
					Marshal.FreeCoTaskMem(m_pDataBuffer);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
				m_pDataBuffer = IntPtr.Zero;
			}
		}
	}

	private unsafe void PreBind_RefCursor(OracleConnection conn)
	{
		OracleRefCursor oracleRefCursor = null;
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = ((Array)m_value).GetValue(i);
				}
				if (obj is OracleRefCursor)
				{
					oracleRefCursor = (OracleRefCursor)obj;
					if (oracleRefCursor.m_connection == conn || (oracleRefCursor.m_connection.m_contextConnection && conn.m_contextConnection))
					{
						if (oracleRefCursor.m_conSignature != conn.m_conSignature)
						{
							throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
						}
						if (oracleRefCursor.SqlCtx != IntPtr.Zero)
						{
							SetPrmValCtx(oracleRefCursor.SqlCtx, i);
							continue;
						}
						m_pOpoPrmValCtx->pInd[i] = -1;
						m_pOpoPrmValCtx->pSrcInd[i] = -1;
						continue;
					}
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_DIFFERENT_CONNECTIONS));
				}
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
			}
		}
		SetPrmValCtx(OraType.ORA_RESULTSET, -1, null);
	}

	private unsafe void PostBind_RefCursor(OracleConnection conn, OpoSqlValCtx* pOpoSqlValCtx, string cmdText, string posOrName)
	{
		OracleRefCursor[] array = null;
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					OpoSqlValCtx* pOpoSqlValCtxDst = null;
					try
					{
						OpsSql.CopySqlValCtx(pOpoSqlValCtx, ref pOpoSqlValCtxDst);
					}
					catch (Exception ex3)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex3);
						}
						throw;
					}
					m_value = new OracleRefCursor(conn, (IntPtr)(*(int*)m_pOpoPrmValCtx->pBltVal), pOpoSqlValCtxDst, cmdText, posOrName);
					pOpoSqlValCtxDst = null;
					m_status = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = OracleRefCursor.Null;
					}
					else
					{
						m_value = DBNull.Value;
					}
					m_status = OracleParameterStatus.NullFetched;
				}
				break;
			}
			array = new OracleRefCursor[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					OpoSqlValCtx* pOpoSqlValCtxDst = null;
					try
					{
						OpsSql.CopySqlValCtx(pOpoSqlValCtx, ref pOpoSqlValCtxDst);
					}
					catch (Exception ex4)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex4);
						}
						throw;
					}
					array[i] = new OracleRefCursor(conn, (IntPtr)(*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)), pOpoSqlValCtxDst, cmdText, posOrName);
					pOpoSqlValCtxDst = null;
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					m_curArrayBindSize[i] = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						array[i] = OracleRefCursor.Null;
					}
					else
					{
						array[i] = null;
					}
					m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
				}
			}
			m_value = array;
			break;
		}
		case ParameterDirection.InputOutput:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (*m_pOpoPrmValCtx->pSrcInd == -1)
					{
						OpoSqlValCtx* pOpoSqlValCtxDst = null;
						try
						{
							OpsSql.CopySqlValCtx(pOpoSqlValCtx, ref pOpoSqlValCtxDst);
						}
						catch (Exception ex)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex);
							}
							throw;
						}
						m_value = new OracleRefCursor(conn, (IntPtr)(*(int*)m_pOpoPrmValCtx->pBltVal), pOpoSqlValCtxDst, cmdText, posOrName);
						pOpoSqlValCtxDst = null;
					}
					m_status = OracleParameterStatus.Success;
				}
				else
				{
					if (m_value != DBNull.Value)
					{
						((OracleRefCursor)m_value).Dispose();
					}
					m_curSize = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = OracleRefCursor.Null;
					}
					else
					{
						m_value = DBNull.Value;
					}
					m_status = OracleParameterStatus.NullFetched;
				}
				break;
			}
			array = new OracleRefCursor[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_pOpoPrmValCtx->pSrcInd[i] == -1)
					{
						OpoSqlValCtx* pOpoSqlValCtxDst = null;
						try
						{
							OpsSql.CopySqlValCtx(pOpoSqlValCtx, ref pOpoSqlValCtxDst);
						}
						catch (Exception ex2)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex2);
							}
							throw;
						}
						array[i] = new OracleRefCursor(conn, (IntPtr)(*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)), pOpoSqlValCtxDst, cmdText, posOrName);
						pOpoSqlValCtxDst = null;
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
				}
				else
				{
					if (((OracleRefCursor[])m_value)[i] != null)
					{
						((OracleRefCursor[])m_value)[i].Dispose();
					}
					m_curSize = 0;
					m_curArrayBindSize[i] = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						array[i] = OracleRefCursor.Null;
					}
					else
					{
						array[i] = null;
					}
					m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
				}
			}
			m_value = array;
			break;
		}
		}
		if (m_enumType != PrmEnumType.DBTYPE || !m_bOracleDbTypeExSet || m_direction == ParameterDirection.Input)
		{
			return;
		}
		if (m_bArrayBind)
		{
			OracleDataReader[] array2 = new OracleDataReader[m_arrBindCount];
			for (int j = 0; j < m_arrBindCount; j++)
			{
				OracleRefCursor oracleRefCursor = array[j];
				if (oracleRefCursor == null || oracleRefCursor.IsNull)
				{
					array2[j] = null;
					continue;
				}
				array2[j] = oracleRefCursor.GetDataReader(fillRequest: false);
				oracleRefCursor.Dispose();
			}
			m_value = array2;
		}
		else if (m_value != DBNull.Value)
		{
			OracleRefCursor oracleRefCursor2 = (OracleRefCursor)m_value;
			if (oracleRefCursor2.IsNull)
			{
				m_value = DBNull.Value;
				return;
			}
			m_value = oracleRefCursor2.GetDataReader(fillRequest: false);
			oracleRefCursor2.Dispose();
		}
	}

	private unsafe void PreBind_TimeStamp(OracleConnection conn, IntPtr errCtx)
	{
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			m_saveValue = new object[m_arrBindCount];
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array.GetValue(i);
				}
				if (obj is DateTime)
				{
					if (m_direction == ParameterDirection.Input)
					{
						SetPrmValCtx(DateTimeConv.AllocTSValCtx((DateTime)obj), i);
						continue;
					}
					OracleTimeStamp oracleTimeStamp = new OracleTimeStamp((DateTime)obj);
					SetPrmValCtx(oracleTimeStamp.GetValCtx(), i);
					m_saveValue[i] = oracleTimeStamp;
					continue;
				}
				if (obj is OracleTimeStamp)
				{
					SetPrmValCtx(((OracleTimeStamp)obj).GetValCtx(), i);
					continue;
				}
				if (obj is OracleTimeStampLTZ)
				{
					SetPrmValCtx(((OracleTimeStampLTZ)obj).GetValCtx(), i);
					continue;
				}
				if (obj is OracleTimeStampTZ)
				{
					SetPrmValCtx(((OracleTimeStampTZ)obj).GetValCtx(), i);
					continue;
				}
				if (obj is OracleDate)
				{
					SetPrmValCtx(((OracleDate)obj).GetValCtx(), i);
					continue;
				}
				if (obj is string || obj is char[] || obj is OracleString || obj is char)
				{
					OracleTimeStamp oracleTimeStamp = new OracleTimeStamp(GetPreBindBuffer_Str(i));
					SetPrmValCtx(oracleTimeStamp.GetValCtx(), i);
					m_saveValue[i] = oracleTimeStamp;
					continue;
				}
				if (obj is byte[] binData)
				{
					OracleTimeStamp oracleTimeStamp = new OracleTimeStamp(binData);
					SetPrmValCtx(oracleTimeStamp.GetValCtx(), i);
					m_saveValue[i] = oracleTimeStamp;
					continue;
				}
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
			}
		}
		SetPrmValCtx(OraType.ORA_TIMESTAMP, 0, null);
	}

	private unsafe void PostBind_TimeStamp()
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.InputOutput:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						m_value = new OracleTimeStamp((OpoTSValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal));
					}
					else
					{
						m_value = DateTimeConv.GetDateTime((OpoTSValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal), OracleDbType.TimeStamp, bCheck: true);
						try
						{
							OpsTS.FreeValCtx((OpoTSValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal));
						}
						catch (Exception ex2)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex2);
							}
						}
					}
					m_status = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = OracleTimeStamp.Null;
					}
					else
					{
						m_value = DBNull.Value;
					}
					m_status = OracleParameterStatus.NullFetched;
				}
				break;
			}
			OracleTimeStamp[] array = new OracleTimeStamp[m_arrBindCount];
			DateTime[] array2 = new DateTime[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleTimeStamp reference = ref array[i];
						reference = new OracleTimeStamp((OpoTSValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
					}
					else
					{
						ref DateTime reference2 = ref array2[i];
						reference2 = DateTimeConv.GetDateTime((OpoTSValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)), OracleDbType.TimeStamp, bCheck: true);
						try
						{
							OpsTS.FreeValCtx((OpoTSValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
						}
						catch (Exception ex3)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex3);
							}
						}
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					m_curArrayBindSize[i] = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						ref OracleTimeStamp reference3 = ref array[i];
						reference3 = OracleTimeStamp.Null;
					}
					m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
				}
			}
			if (PrmEnumType.ORADBTYPE == m_enumType)
			{
				m_value = array;
			}
			else
			{
				m_value = array2;
			}
			break;
		}
		case ParameterDirection.Input:
		{
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pSrcInd[i] == -1 || (!(m_value is DateTime) && !(m_value is DateTime[]) && (!(m_value is Array) || !(((Array)m_value).GetValue(i) is DateTime))))
				{
					continue;
				}
				try
				{
					OpsTS.FreeValCtx((OpoTSValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
			}
			break;
		}
		}
		m_saveValue = null;
	}

	private unsafe void PreBind_TimeStampLTZ(OracleConnection conn, IntPtr errCtx)
	{
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			m_saveValue = new object[m_arrBindCount];
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array.GetValue(i);
				}
				if (obj is DateTime)
				{
					if (m_direction == ParameterDirection.Input)
					{
						SetPrmValCtx(DateTimeConv.AllocTSLValCtx((DateTime)obj), i);
						continue;
					}
					OracleTimeStampLTZ oracleTimeStampLTZ = new OracleTimeStampLTZ((DateTime)obj);
					SetPrmValCtx(oracleTimeStampLTZ.GetValCtx(), i);
					m_saveValue[i] = oracleTimeStampLTZ;
					continue;
				}
				if (obj is OracleTimeStampLTZ)
				{
					SetPrmValCtx(((OracleTimeStampLTZ)obj).GetValCtx(), i);
					continue;
				}
				if (obj is OracleTimeStamp)
				{
					SetPrmValCtx(((OracleTimeStamp)obj).GetValCtx(), i);
					continue;
				}
				if (obj is OracleTimeStampTZ)
				{
					SetPrmValCtx(((OracleTimeStampTZ)obj).GetValCtx(), i);
					continue;
				}
				if (obj is OracleDate)
				{
					SetPrmValCtx(((OracleDate)obj).GetValCtx(), i);
					continue;
				}
				if (obj is string || obj is char[] || obj is OracleString || obj is char)
				{
					OracleTimeStampLTZ oracleTimeStampLTZ = new OracleTimeStampLTZ(GetPreBindBuffer_Str(i));
					SetPrmValCtx(oracleTimeStampLTZ.GetValCtx(), i);
					m_saveValue[i] = oracleTimeStampLTZ;
					continue;
				}
				if (obj is byte[] binData)
				{
					OracleTimeStampLTZ oracleTimeStampLTZ = new OracleTimeStampLTZ(binData);
					SetPrmValCtx(oracleTimeStampLTZ.GetValCtx(), i);
					m_saveValue[i] = oracleTimeStampLTZ;
					continue;
				}
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
			}
		}
		SetPrmValCtx(OraType.ORA_TIMESTAMP_LTZ, 0, null);
	}

	private unsafe void PostBind_TimeStampLTZ()
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.InputOutput:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						m_value = new OracleTimeStampLTZ((OpoTSValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal));
					}
					else
					{
						m_value = DateTimeConv.GetDateTime((OpoTSValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal), OracleDbType.TimeStampLTZ, bCheck: true);
						try
						{
							OpsTS.FreeValCtx((OpoTSValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal));
						}
						catch (Exception ex2)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex2);
							}
						}
					}
					m_status = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = OracleTimeStampLTZ.Null;
					}
					else
					{
						m_value = DBNull.Value;
					}
					m_status = OracleParameterStatus.NullFetched;
				}
				break;
			}
			OracleTimeStampLTZ[] array = new OracleTimeStampLTZ[m_arrBindCount];
			DateTime[] array2 = new DateTime[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleTimeStampLTZ reference = ref array[i];
						reference = new OracleTimeStampLTZ((OpoTSValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
					}
					else
					{
						ref DateTime reference2 = ref array2[i];
						reference2 = DateTimeConv.GetDateTime((OpoTSValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)), OracleDbType.TimeStampLTZ, bCheck: true);
						try
						{
							OpsTS.FreeValCtx((OpoTSValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
						}
						catch (Exception ex3)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex3);
							}
						}
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					m_curArrayBindSize[i] = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						ref OracleTimeStampLTZ reference3 = ref array[i];
						reference3 = OracleTimeStampLTZ.Null;
					}
					m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
				}
			}
			if (PrmEnumType.ORADBTYPE == m_enumType)
			{
				m_value = array;
			}
			else
			{
				m_value = array2;
			}
			break;
		}
		case ParameterDirection.Input:
		{
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pSrcInd[i] == -1 || (!(m_value is DateTime) && !(m_value is DateTime[]) && (!(m_value is Array) || !(((Array)m_value).GetValue(i) is DateTime))))
				{
					continue;
				}
				try
				{
					OpsTS.FreeValCtx((OpoTSValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
			}
			break;
		}
		}
		m_saveValue = null;
	}

	private unsafe void PreBind_TimeStampTZ(OracleConnection conn, IntPtr errCtx)
	{
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			m_saveValue = new object[m_arrBindCount];
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array.GetValue(i);
				}
				OracleTimeStampTZ oracleTimeStampTZ;
				if (obj is DateTime)
				{
					if (m_direction == ParameterDirection.Input)
					{
						SetPrmValCtx(DateTimeConv.AllocTSZValCtx((DateTime)obj), i);
						continue;
					}
					oracleTimeStampTZ = new OracleTimeStampTZ((DateTime)obj);
					SetPrmValCtx(oracleTimeStampTZ.GetValCtx(), i);
					m_saveValue[i] = oracleTimeStampTZ;
				}
				else if (obj is OracleTimeStampTZ)
				{
					SetPrmValCtx(((OracleTimeStampTZ)obj).GetValCtx(), i);
				}
				else if (obj is OracleTimeStamp)
				{
					SetPrmValCtx(((OracleTimeStamp)obj).GetValCtx(), i);
				}
				else if (obj is OracleTimeStampLTZ)
				{
					SetPrmValCtx(((OracleTimeStampLTZ)obj).GetValCtx(), i);
				}
				else if (obj is OracleDate)
				{
					SetPrmValCtx(((OracleDate)obj).GetValCtx(), i);
				}
				else if (obj is string || obj is char[] || obj is OracleString || obj is char)
				{
					oracleTimeStampTZ = new OracleTimeStampTZ(GetPreBindBuffer_Str(i));
					SetPrmValCtx(oracleTimeStampTZ.GetValCtx(), i);
					m_saveValue[i] = oracleTimeStampTZ;
				}
				else if (obj is byte[] binData)
				{
					oracleTimeStampTZ = new OracleTimeStampTZ(binData);
					SetPrmValCtx(oracleTimeStampTZ.GetValCtx(), i);
					m_saveValue[i] = oracleTimeStampTZ;
				}
				else
				{
					if (!(obj is DateTimeOffset))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					oracleTimeStampTZ = new OracleTimeStampTZ(((DateTimeOffset)obj).DateTime, ((DateTimeOffset)obj).Offset.ToString());
					SetPrmValCtx(oracleTimeStampTZ.GetValCtx(), i);
				}
			}
		}
		SetPrmValCtx(OraType.ORA_TIMESTAMP_TZ, 0, null);
	}

	private unsafe void PostBind_TimeStampTZ()
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.InputOutput:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						m_value = new OracleTimeStampTZ((OpoTSValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal));
					}
					else
					{
						if (m_bReturnDateTimeOffset)
						{
							m_value = DateTimeConv.GetDateTimeOffset((OpoTSValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal), OracleDbType.TimeStampTZ, bCheck: true);
						}
						else
						{
							m_value = DateTimeConv.GetDateTime((OpoTSValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal), OracleDbType.TimeStampTZ, bCheck: true);
						}
						try
						{
							OpsTS.FreeValCtx((OpoTSValCtx*)(int)(*(uint*)m_pOpoPrmValCtx->pBltVal));
						}
						catch (Exception ex2)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex2);
							}
						}
					}
					m_status = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						m_value = OracleTimeStampTZ.Null;
					}
					else
					{
						m_value = DBNull.Value;
					}
					m_status = OracleParameterStatus.NullFetched;
				}
				break;
			}
			DateTime[] array = new DateTime[m_arrBindCount];
			OracleTimeStampTZ[] array2 = new OracleTimeStampTZ[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_enumType == PrmEnumType.ORADBTYPE)
					{
						ref OracleTimeStampTZ reference = ref array2[i];
						reference = new OracleTimeStampTZ((OpoTSValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
					}
					else
					{
						ref DateTime reference2 = ref array[i];
						reference2 = DateTimeConv.GetDateTime((OpoTSValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)), OracleDbType.TimeStampTZ, bCheck: true);
						try
						{
							OpsTS.FreeValCtx((OpoTSValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
						}
						catch (Exception ex3)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex3);
							}
						}
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
				}
				else
				{
					m_curSize = 0;
					m_curArrayBindSize[i] = 0;
					if (PrmEnumType.ORADBTYPE == m_enumType)
					{
						ref OracleTimeStampTZ reference3 = ref array2[i];
						reference3 = OracleTimeStampTZ.Null;
					}
					m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
				}
			}
			if (PrmEnumType.ORADBTYPE == m_enumType)
			{
				m_value = array2;
			}
			else
			{
				m_value = array;
			}
			break;
		}
		case ParameterDirection.Input:
		{
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pSrcInd[i] == -1 || (!(m_value is DateTime) && !(m_value is DateTime[]) && (!(m_value is Array) || !(((Array)m_value).GetValue(i) is DateTime))))
				{
					continue;
				}
				try
				{
					OpsTS.FreeValCtx((OpoTSValCtx*)(int)(*(uint*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)));
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
			}
			break;
		}
		}
		m_saveValue = null;
	}

	private unsafe void PreBind_XmlType(OracleConnection conn)
	{
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			m_saveValue = new object[m_arrBindCount];
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = array.GetValue(i);
				}
				if (obj is OracleXmlType oracleXmlType)
				{
					if (oracleXmlType.m_connection != conn && (!oracleXmlType.m_connection.m_contextConnection || !conn.m_contextConnection))
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_DIFFERENT_CONNECTIONS));
					}
					if (oracleXmlType.m_conSignature != conn.m_conSignature)
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
					}
					SetPrmValCtx(oracleXmlType.OpsXmlTypeCtx, i);
				}
				else if (obj is OracleClob oracleClob)
				{
					if (oracleClob.m_connection != conn && (!oracleClob.m_connection.m_contextConnection || !conn.m_contextConnection))
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_DIFFERENT_CONNECTIONS));
					}
					if (oracleClob.m_conSignature != conn.m_conSignature)
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
					}
					OracleXmlType oracleXmlType2 = new OracleXmlType(oracleClob);
					SetPrmValCtx(oracleXmlType2.OpsXmlTypeCtx, i);
					m_saveValue[i] = oracleXmlType2;
				}
				else
				{
					OracleXmlType oracleXmlType2 = new OracleXmlType(conn, GetPreBindBuffer_Str(i));
					SetPrmValCtx(oracleXmlType2.OpsXmlTypeCtx, i);
					m_saveValue[i] = oracleXmlType2;
				}
			}
		}
		SetPrmValCtx(OraType.ORA_NDT, 0, null);
	}

	private unsafe void PostBind_XmlType(OracleConnection conn)
	{
		OracleXmlType[] array = null;
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					m_value = new OracleXmlType(conn, (IntPtr)(*(int*)m_pOpoPrmValCtx->pBltVal), flag: false);
					m_status = OracleParameterStatus.Success;
					break;
				}
				m_curSize = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					m_value = OracleXmlType.Null;
				}
				else
				{
					m_value = DBNull.Value;
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			array = new OracleXmlType[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					array[i] = new OracleXmlType(conn, (IntPtr)(*(int*)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)i * (nint)4)), flag: false);
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
					continue;
				}
				m_curSize = 0;
				m_curArrayBindSize[i] = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					array[i] = OracleXmlType.Null;
				}
				else
				{
					array[i] = null;
				}
				m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
			}
			m_value = array;
			break;
		}
		case ParameterDirection.InputOutput:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (*m_pOpoPrmValCtx->pSrcInd == -1)
					{
						m_value = new OracleXmlType(conn, (IntPtr)(*(int*)m_pOpoPrmValCtx->pBltVal), flag: false);
					}
					else if (!(m_value is OracleXmlType))
					{
						m_value = m_saveValue[0];
						m_saveValue[0] = null;
						m_saveValue = null;
					}
					m_status = OracleParameterStatus.Success;
					break;
				}
				if (*m_pOpoPrmValCtx->pSrcInd != -1)
				{
					if (m_value is OracleXmlType)
					{
						((OracleXmlType)m_value).Dispose();
						m_value = null;
					}
					else
					{
						if (m_value is OracleClob)
						{
							((OracleClob)m_value).Dispose();
						}
						((OracleXmlType)m_saveValue[0]).Dispose();
						m_saveValue[0] = null;
						m_saveValue = null;
					}
				}
				m_curSize = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					m_value = OracleXmlType.Null;
				}
				else
				{
					m_value = DBNull.Value;
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			array = new OracleXmlType[m_arrBindCount];
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_pOpoPrmValCtx->pSrcInd[i] == -1)
					{
						array[i] = new OracleXmlType(conn, (IntPtr)(*(int*)m_pOpoPrmValCtx->pBltVal + i), flag: false);
					}
					else if (m_value is OracleXmlType[])
					{
						array[i] = ((OracleXmlType[])m_value)[i];
					}
					else
					{
						array[i] = (OracleXmlType)m_saveValue[i];
						m_saveValue[i] = null;
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
					continue;
				}
				if (m_pOpoPrmValCtx->pSrcInd[i] != -1)
				{
					if (m_value is OracleXmlType[])
					{
						((OracleXmlType[])m_value)[i].Dispose();
					}
					else
					{
						if (m_value is OracleClob[])
						{
							((OracleClob[])m_value)[i].Dispose();
						}
						((OracleXmlType)m_saveValue[i]).Dispose();
						m_saveValue[i] = null;
					}
				}
				m_curSize = 0;
				m_curArrayBindSize[i] = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					array[i] = OracleXmlType.Null;
				}
				else
				{
					array[i] = null;
				}
				m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
			}
			m_saveValue = null;
			m_value = array;
			break;
		}
		case ParameterDirection.Input:
		{
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pSrcInd[i] != -1 && !(m_value is OracleXmlType) && !IsElemType(typeof(OracleXmlType), m_value, i))
				{
					((OracleXmlType)m_saveValue[i]).Dispose();
					m_saveValue[i] = null;
				}
				SetPrmValCtx(IntPtr.Zero, i);
			}
			m_saveValue = null;
			break;
		}
		}
		if (m_enumType != PrmEnumType.DBTYPE || !m_bOracleDbTypeExSet || m_direction == ParameterDirection.Input)
		{
			return;
		}
		if (m_bArrayBind)
		{
			string[] array2 = new string[m_arrBindCount];
			for (int j = 0; j < m_arrBindCount; j++)
			{
				OracleXmlType oracleXmlType = array[j];
				if (oracleXmlType == null || oracleXmlType.IsNull)
				{
					array2[j] = null;
					continue;
				}
				array2[j] = oracleXmlType.Value;
				oracleXmlType.Dispose();
			}
			m_value = array2;
		}
		else if (m_value != DBNull.Value)
		{
			OracleXmlType oracleXmlType2 = (OracleXmlType)m_value;
			if (oracleXmlType2.IsNull)
			{
				m_value = DBNull.Value;
				return;
			}
			m_value = oracleXmlType2.Value;
			oracleXmlType2.Dispose();
		}
	}

	internal void FreeDataBuffer()
	{
		if (!(m_pDataBuffer != IntPtr.Zero))
		{
			return;
		}
		try
		{
			Marshal.FreeCoTaskMem(m_pDataBuffer);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
		}
		m_pDataBuffer = IntPtr.Zero;
	}

	private unsafe OracleRef CreateOracleRef(OracleConnection conn, int index)
	{
		IntPtr pOCIRef = (IntPtr)(*(void**)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)index * (nint)sizeof(void*)));
		IntPtr pObjInd = (IntPtr)(*(void**)((byte*)(void*)m_pOpoPrmValCtx->ppTempInd + (nint)index * (nint)sizeof(void*)));
		OpoUdtCtx opoUdtCtx = new OpoUdtCtx(conn.m_opoConCtx.opsConCtx, IntPtr.Zero, pOCIRef, pObjInd);
		if (m_pOpoPrmValCtx->bIsFinalType == 0)
		{
			return new OracleRef(conn, opoUdtCtx);
		}
		return new OracleRef(m_udtDescriptor, opoUdtCtx);
	}

	private string GetPreBindStr(object bindValue)
	{
		string result = null;
		if (bindValue is string)
		{
			result = (string)bindValue;
		}
		else if (bindValue is char[])
		{
			result = new string((char[])bindValue);
		}
		else if (bindValue is OracleString oracleString)
		{
			result = ((!oracleString.IsNull) ? ((OracleString)bindValue).Value : string.Empty);
		}
		return result;
	}

	private void PreBind_Object(OracleConnection conn)
	{
		if (conn.m_contextConnection)
		{
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_UDT_NOTSUPPORTED_CTX_CONN));
		}
		if (m_enumType == PrmEnumType.ORADBTYPE)
		{
			PreBind_OracleObject(conn);
			return;
		}
		SetUdtDescriptor(conn);
		m_oraDbType = m_udtDescriptor.OracleDbType;
		if (m_oraDbType == OracleDbType.Array)
		{
			PreBind_Collection(conn);
		}
		else
		{
			PreBind_OracleObject(conn);
		}
	}

	private unsafe void SetUdtDescriptor(OracleConnection conn)
	{
		if (m_pOpoPrmValCtx->pOpsDscCtx == IntPtr.Zero)
		{
			if (m_udtTypeName == null || m_udtTypeName.Length <= 0)
			{
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
			}
			OracleUdtDescriptor oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor(conn, m_udtTypeName);
			oracleUdtDescriptor.GetMetaDataTable();
			if (oracleUdtDescriptor == null)
			{
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
			}
			SetPrmValCtx(oracleUdtDescriptor);
		}
	}

	private unsafe void SetUDTFromArray(OracleConnection conn, object array, int i)
	{
		int num = 0;
		if (m_udtDescriptor.m_customTypeFactory == null)
		{
			object factory = OracleUdt.GetFactory(m_udtDescriptor);
			m_udtDescriptor.DescribeCustomType(factory);
		}
		if ((IntPtr)m_pOpoPrmValCtx->pOpoUdtValCtx == IntPtr.Zero)
		{
			try
			{
				num = OpsUdt.AllocValCtx(out m_pOpoPrmValCtx->pOpoUdtValCtx, m_bindElemCount);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				num = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (num == 0)
				{
					m_pOpoPrmValCtx->NumOpoUdtValCtx = m_bindElemCount;
				}
				else if (num != ErrRes.INT_ERR)
				{
					OracleException.HandleError(num, conn, conn.m_opoConCtx.opsErrCtx, this);
				}
			}
		}
		else if (m_pOpoPrmValCtx->NumOpoUdtValCtx < m_bindElemCount)
		{
			try
			{
				num = OpsUdt.ReAllocValCtx(ref m_pOpoPrmValCtx->pOpoUdtValCtx, m_pOpoPrmValCtx->NumOpoUdtValCtx, m_bindElemCount);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				num = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (num == 0)
				{
					m_pOpoPrmValCtx->NumOpoUdtValCtx = m_bindElemCount;
				}
				else if (num != ErrRes.INT_ERR)
				{
					OracleException.HandleError(num, conn, conn.m_opoConCtx.opsErrCtx, this);
				}
			}
		}
		m_pOpoPrmValCtx->pOpoUdtValCtx[i].pOpsErrCtx = conn.m_opoConCtx.opsErrCtx;
		m_pOpoPrmValCtx->pOpoUdtValCtx[i].pTDO = m_udtDescriptor.m_opsDscCtx;
		m_pOpoPrmValCtx->pOpoUdtValCtx[i].pOpoDscValCtx = m_udtDescriptor.m_pOpoDscValCtx;
		OracleUdt.SetValue(conn, (IntPtr)(m_pOpoPrmValCtx->pOpoUdtValCtx + i), 0, array);
		try
		{
			num = OpsUdt.SetArrayData(conn.m_opoConCtx.opsConCtx, m_pOpoPrmValCtx->pOpoUdtValCtx + i);
		}
		catch (Exception ex3)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex3);
			}
			num = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (num == 0)
			{
				SetPrmValCtx(m_pOpoPrmValCtx->pOpoUdtValCtx[i].pUDT, i);
				*(void**)((byte*)(void*)m_pOpoPrmValCtx->ppTempInd + (nint)i * (nint)sizeof(void*)) = (void*)m_pOpoPrmValCtx->pOpoUdtValCtx[i].pNullStruct;
			}
			else if (num != ErrRes.INT_ERR)
			{
				OracleException.HandleError(num, conn, m_pOpoPrmValCtx->pOpoUdtValCtx[i].pOpsErrCtx, this);
			}
		}
	}

	private unsafe void SetUDTFromCustomObject(OracleConnection conn, IOracleCustomType customObj, int i)
	{
		int num = 0;
		OracleUdtDescriptor oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor2(conn, (OpoDscRefCtx)OracleUdt.GetUdtName(customObj.GetType().FullName, conn.DataSource));
		if (oracleUdtDescriptor == null)
		{
			throw new InvalidOperationException();
		}
		if (oracleUdtDescriptor.m_customTypeFactory == null)
		{
			object factory = OracleUdt.GetFactory(oracleUdtDescriptor);
			oracleUdtDescriptor.DescribeCustomType(factory);
		}
		if ((IntPtr)m_pOpoPrmValCtx->pOpoUdtValCtx == IntPtr.Zero)
		{
			try
			{
				num = OpsUdt.AllocValCtx(out m_pOpoPrmValCtx->pOpoUdtValCtx, m_bindElemCount);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				num = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (num == 0)
				{
					m_pOpoPrmValCtx->NumOpoUdtValCtx = m_bindElemCount;
				}
				else if (num != ErrRes.INT_ERR)
				{
					OracleException.HandleError(num, conn, conn.m_opoConCtx.opsErrCtx, this);
				}
			}
		}
		else if (m_pOpoPrmValCtx->NumOpoUdtValCtx < m_bindElemCount)
		{
			try
			{
				num = OpsUdt.ReAllocValCtx(ref m_pOpoPrmValCtx->pOpoUdtValCtx, m_pOpoPrmValCtx->NumOpoUdtValCtx, m_bindElemCount);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				num = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (num == 0)
				{
					m_pOpoPrmValCtx->NumOpoUdtValCtx = m_bindElemCount;
				}
				else if (num != ErrRes.INT_ERR)
				{
					OracleException.HandleError(num, conn, conn.m_opoConCtx.opsErrCtx, this);
				}
			}
		}
		if ((IntPtr)m_pOpoPrmValCtx->pOpoUdtValCtx[i].pOpoUdtValCtx == IntPtr.Zero)
		{
			try
			{
				num = OpsUdt.AllocValCtx(out m_pOpoPrmValCtx->pOpoUdtValCtx[i].pOpoUdtValCtx, oracleUdtDescriptor.AttributeCount);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
				num = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (num == 0)
				{
					m_pOpoPrmValCtx->pOpoUdtValCtx[i].NumOpoUdtValCtx = oracleUdtDescriptor.AttributeCount;
				}
				else if (num != ErrRes.INT_ERR)
				{
					OracleException.HandleError(num, conn, conn.m_opoConCtx.opsErrCtx, this);
				}
			}
		}
		else if (m_pOpoPrmValCtx->pOpoUdtValCtx[i].NumOpoUdtValCtx < oracleUdtDescriptor.AttributeCount)
		{
			try
			{
				num = OpsUdt.ReAllocValCtx(ref m_pOpoPrmValCtx->pOpoUdtValCtx[i].pOpoUdtValCtx, m_pOpoPrmValCtx->pOpoUdtValCtx[i].NumOpoUdtValCtx, oracleUdtDescriptor.AttributeCount);
			}
			catch (Exception ex4)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex4);
				}
				num = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (num == 0)
				{
					m_pOpoPrmValCtx->pOpoUdtValCtx[i].NumOpoUdtValCtx = oracleUdtDescriptor.AttributeCount;
				}
				else if (num != ErrRes.INT_ERR)
				{
					OracleException.HandleError(num, conn, conn.m_opoConCtx.opsErrCtx, this);
				}
			}
		}
		m_pOpoPrmValCtx->pOpoUdtValCtx[i].pOpsErrCtx = conn.m_opoConCtx.opsErrCtx;
		m_pOpoPrmValCtx->pOpoUdtValCtx[i].pTDO = oracleUdtDescriptor.m_opsDscCtx;
		m_pOpoPrmValCtx->pOpoUdtValCtx[i].pOpoDscValCtx = oracleUdtDescriptor.m_pOpoDscValCtx;
		for (int j = 0; j < oracleUdtDescriptor.AttributeCount; j++)
		{
			m_pOpoPrmValCtx->pOpoUdtValCtx[i].pOpoUdtValCtx[j].bIsNull = 1;
		}
		customObj.FromCustomObject(conn, (IntPtr)(m_pOpoPrmValCtx->pOpoUdtValCtx + i));
		try
		{
			if (oracleUdtDescriptor.m_pOpoDscValCtx->TypeCode == 122)
			{
				if (m_pOpoPrmValCtx->pOpoUdtValCtx[i].bIsNull == 1)
				{
					m_pOpoPrmValCtx->pInd[i] = -1;
					m_pOpoPrmValCtx->pSrcInd[i] = -1;
					return;
				}
				num = OpsUdt.SetArrayData(conn.m_opoConCtx.opsConCtx, m_pOpoPrmValCtx->pOpoUdtValCtx + i);
			}
			else
			{
				num = OpsUdt.SetData(conn.m_opoConCtx.opsConCtx, m_pOpoPrmValCtx->pOpoUdtValCtx + i);
			}
		}
		catch (Exception ex5)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex5);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, conn, conn.m_opoConCtx.opsErrCtx, this);
			}
		}
		GC.KeepAlive(oracleUdtDescriptor);
		SetPrmValCtx(m_pOpoPrmValCtx->pOpoUdtValCtx[i].pUDT, i);
		*(void**)((byte*)(void*)m_pOpoPrmValCtx->ppTempInd + (nint)i * (nint)sizeof(void*)) = (void*)m_pOpoPrmValCtx->pOpoUdtValCtx[i].pNullStruct;
	}

	private unsafe void PreBind_OracleObject(OracleConnection conn)
	{
		if (conn.m_contextConnection)
		{
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_UDT_NOTSUPPORTED_CTX_CONN));
		}
		SetUdtDescriptor(conn);
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = ((Array)m_value).GetValue(i);
				}
				if (obj is IOracleCustomType)
				{
					SetUDTFromCustomObject(conn, (IOracleCustomType)obj, i);
					continue;
				}
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
			}
		}
		SetPrmValCtx(OraType.ORA_NDT, 0, null);
	}

	private unsafe void PreBind_Collection(OracleConnection conn)
	{
		if (conn.m_contextConnection)
		{
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_UDT_NOTSUPPORTED_CTX_CONN));
		}
		SetUdtDescriptor(conn);
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			object obj = null;
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = ((Array)m_value).GetValue(i);
				}
				if (obj is IOracleCustomType)
				{
					SetUDTFromCustomObject(conn, (IOracleCustomType)obj, i);
					continue;
				}
				if (obj is Array)
				{
					SetUDTFromArray(conn, obj, i);
					continue;
				}
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
			}
		}
		SetPrmValCtx(OraType.ORA_NDT, 0, null);
	}

	private unsafe void PreBind_OracleRef(OracleConnection conn)
	{
		if (conn.m_contextConnection)
		{
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_UDT_NOTSUPPORTED_CTX_CONN));
		}
		SetUdtDescriptor(conn);
		if (m_direction == ParameterDirection.Input || m_direction == ParameterDirection.InputOutput)
		{
			object obj = null;
			m_saveValue = new object[m_arrBindCount];
			for (int i = 0; i < m_bindElemCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] == -1)
				{
					continue;
				}
				if (!m_bArrayBind)
				{
					obj = m_value;
				}
				else
				{
					if (!(m_value is Array))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					obj = ((Array)m_value).GetValue(i);
				}
				if (obj is OracleRef)
				{
					if (((OracleRef)obj).m_connection != conn)
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_DIFFERENT_CONNECTIONS));
					}
					if (((OracleRef)obj).m_conSignature != conn.m_conSignature)
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
					}
					SetPrmValCtx(((OracleRef)obj).UdtDescriptor);
					SetPrmValCtx(((OracleRef)obj).m_opoUdtCtx.m_pOCIRef, i);
				}
				else
				{
					string preBindStr;
					if (!((preBindStr = GetPreBindStr(obj)) != string.Empty))
					{
						throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), ParameterName);
					}
					m_saveValue[i] = new OracleRef(conn, preBindStr);
					SetPrmValCtx(((OracleRef)m_saveValue[i]).UdtDescriptor);
					SetPrmValCtx(((OracleRef)m_saveValue[i]).m_opoUdtCtx.m_pOCIRef, i);
				}
			}
		}
		SetPrmValCtx(OraType.ORA_OCIRef, 0, null);
	}

	private unsafe void PostBind_OracleRef(OracleConnection conn)
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					m_value = CreateOracleRef(conn, 0);
					m_status = OracleParameterStatus.Success;
					break;
				}
				m_curSize = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					m_value = OracleRef.Null;
				}
				else
				{
					m_value = DBNull.Value;
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			Array array2 = Array.CreateInstance(typeof(object), m_arrBindCount);
			object obj3 = null;
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					obj3 = CreateOracleRef(conn, i);
					array2.SetValue(obj3, i);
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
				}
				else
				{
					obj3 = ((PrmEnumType.ORADBTYPE != m_enumType) ? ((object)DBNull.Value) : ((object)OracleRef.Null));
					array2.SetValue(obj3, i);
					m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
				}
			}
			m_value = array2;
			break;
		}
		case ParameterDirection.InputOutput:
		{
			if (!m_bArrayBind)
			{
				if (*m_pOpoPrmValCtx->pInd != -1)
				{
					if (*m_pOpoPrmValCtx->pSrcInd == -1)
					{
						m_value = CreateOracleRef(conn, 0);
					}
					else if (!(m_value is OracleRef))
					{
						m_value = m_saveValue[0];
						m_saveValue[0] = null;
						m_saveValue = null;
					}
					m_status = OracleParameterStatus.Success;
					break;
				}
				if (*m_pOpoPrmValCtx->pSrcInd != -1)
				{
					if (m_value is OracleRef)
					{
						((OracleRef)m_value).Dispose();
						m_value = null;
					}
					else
					{
						((OracleRef)m_saveValue[0]).Dispose();
						m_saveValue[0] = null;
						m_saveValue = null;
					}
				}
				m_curSize = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					m_value = OracleRef.Null;
				}
				else
				{
					m_value = DBNull.Value;
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			Array array = Array.CreateInstance(typeof(object), m_arrBindCount);
			object obj = null;
			object obj2 = null;
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pInd[i] != -1)
				{
					if (m_pOpoPrmValCtx->pSrcInd[i] == -1)
					{
						obj = CreateOracleRef(conn, i);
						array.SetValue(obj, i);
					}
					else
					{
						obj2 = ((Array)m_value).GetValue(i);
						if (!(obj2 is OracleRef))
						{
							array.SetValue(m_saveValue[i], i);
							m_saveValue[i] = null;
						}
						else
						{
							array.SetValue(obj2, i);
						}
					}
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
					continue;
				}
				if (m_pOpoPrmValCtx->pSrcInd[i] != -1)
				{
					obj2 = ((Array)m_value).GetValue(i);
					if (obj2 is OracleRef)
					{
						((OracleRef)obj2).Dispose();
					}
					else
					{
						((OracleRef)m_saveValue[i]).Dispose();
						m_saveValue[i] = null;
					}
				}
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					array.SetValue(OracleRef.Null, i);
				}
				else
				{
					array.SetValue(DBNull.Value, i);
				}
			}
			m_value = array;
			m_saveValue = null;
			break;
		}
		case ParameterDirection.Input:
		{
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (m_pOpoPrmValCtx->pSrcInd[i] != -1 && !(m_value is OracleRef) && !IsElemType(typeof(OracleRef), m_value, i))
				{
					((OracleRef)m_saveValue[i]).Dispose();
					m_saveValue[i] = null;
				}
				SetPrmValCtx(IntPtr.Zero, i);
			}
			m_saveValue = null;
			break;
		}
		case (ParameterDirection)4:
		case (ParameterDirection)5:
			break;
		}
	}

	private unsafe object CreateCustomObject(OracleConnection conn, int index)
	{
		IntPtr intPtr = (IntPtr)(*(void**)((byte*)m_pOpoPrmValCtx->pTDOSubType + (nint)index * (nint)sizeof(void*)));
		IntPtr pNullStruct = (IntPtr)(*(void**)((byte*)(void*)m_pOpoPrmValCtx->ppTempInd + (nint)index * (nint)sizeof(void*)));
		OracleUdtDescriptor oracleUdtDescriptor = null;
		if (m_pOpoPrmValCtx->bIsFinalType == 0)
		{
			oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor(conn, intPtr, bRefresh: false, out var bExists);
			*(void**)((byte*)m_pOpoPrmValCtx->pTDOSubType + (nint)index * (nint)sizeof(void*)) = (void*)IntPtr.Zero;
			if (bExists)
			{
				try
				{
					OpsDsc.UnpinTDO(conn.m_opoConCtx.opsConCtx, intPtr);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
				}
			}
		}
		else
		{
			oracleUdtDescriptor = m_udtDescriptor;
		}
		if (oracleUdtDescriptor.m_customTypeFactory == null)
		{
			object factory = OracleUdt.GetFactory(oracleUdtDescriptor);
			oracleUdtDescriptor.DescribeCustomType(factory);
		}
		if (m_pOpoPrmValCtx->pOpoUdtValCtx == null)
		{
			OpsUdt.AllocValCtx(out m_pOpoPrmValCtx->pOpoUdtValCtx, m_bindElemCount);
			m_pOpoPrmValCtx->NumOpoUdtValCtx = m_bindElemCount;
		}
		m_pOpoPrmValCtx->pOpoUdtValCtx[index].pNullStruct = pNullStruct;
		m_pOpoPrmValCtx->pOpoUdtValCtx[index].pOpsErrCtx = conn.m_opoConCtx.opsErrCtx;
		m_pOpoPrmValCtx->pOpoUdtValCtx[index].pTDO = oracleUdtDescriptor.m_opsDscCtx;
		m_pOpoPrmValCtx->pOpoUdtValCtx[index].pOpoDscValCtx = oracleUdtDescriptor.m_pOpoDscValCtx;
		m_pOpoPrmValCtx->pOpoUdtValCtx[index].ppRefTDO = m_pOpoPrmValCtx->ppRefTDO;
		if (oracleUdtDescriptor.m_pOpoDscValCtx->TypeCode == 122)
		{
			m_pOpoPrmValCtx->pOpoUdtValCtx[index].pUDT = (IntPtr)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)index * (nint)sizeof(void*));
			OpsUdt.GetArr(conn.m_opoConCtx.opsConCtx, m_pOpoPrmValCtx->pOpoUdtValCtx + index);
		}
		else
		{
			m_pOpoPrmValCtx->pOpoUdtValCtx[index].pUDT = (IntPtr)(*(void**)((byte*)m_pOpoPrmValCtx->pBltVal + (nint)index * (nint)sizeof(void*)));
			OpsUdt.GetObj(conn.m_opoConCtx.opsConCtx, m_pOpoPrmValCtx->pOpoUdtValCtx + index);
		}
		object obj = null;
		if (oracleUdtDescriptor.m_pOpoDscValCtx->bIsArrayType == 0)
		{
			obj = ((IOracleCustomTypeFactory)oracleUdtDescriptor.m_customTypeFactory).CreateObject();
			((IOracleCustomType)obj).ToCustomObject(conn, (IntPtr)(m_pOpoPrmValCtx->pOpoUdtValCtx + index));
		}
		else
		{
			obj = OracleUdt.GetArrData(conn, (IntPtr)(m_pOpoPrmValCtx->pOpoUdtValCtx + index), out var _, out var _);
		}
		GC.KeepAlive(oracleUdtDescriptor);
		return obj;
	}

	private unsafe void PostBind_Collection(OracleConnection conn)
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.InputOutput:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*(*(short**)(void*)m_pOpoPrmValCtx->ppTempInd) != -1)
				{
					m_value = CreateCustomObject(conn, 0);
					m_status = OracleParameterStatus.Success;
					break;
				}
				m_curSize = 0;
				m_value = DBNull.Value;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					if (m_udtDescriptor.m_customTypeFactory == null)
					{
						object factory = OracleUdt.GetFactory(m_udtDescriptor);
						if (factory != null)
						{
							m_udtDescriptor.DescribeCustomType(factory);
						}
					}
					if (m_udtDescriptor.m_customTypeFactory is IOracleCustomTypeFactory)
					{
						IOracleCustomTypeFactory oracleCustomTypeFactory = (IOracleCustomTypeFactory)m_udtDescriptor.m_customTypeFactory;
						if (oracleCustomTypeFactory != null)
						{
							IOracleCustomType oracleCustomType = oracleCustomTypeFactory.CreateObject();
							Type type = oracleCustomType.GetType();
							PropertyInfo property = type.GetProperty("Null");
							m_value = property.GetValue(null, null);
						}
					}
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			Array array = Array.CreateInstance(typeof(object), m_arrBindCount);
			object obj = null;
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (*(*(short**)((byte*)(void*)m_pOpoPrmValCtx->ppTempInd + (nint)i * (nint)sizeof(void*))) != -1)
				{
					obj = CreateCustomObject(conn, i);
					array.SetValue(obj, i);
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
					continue;
				}
				m_curSize = 0;
				m_curArrayBindSize[i] = 0;
				array.SetValue(null, i);
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					if (m_udtDescriptor.m_customTypeFactory == null)
					{
						object factory2 = OracleUdt.GetFactory(m_udtDescriptor);
						if (factory2 != null)
						{
							m_udtDescriptor.DescribeCustomType(factory2);
						}
					}
					if (m_udtDescriptor.m_customTypeFactory is IOracleCustomTypeFactory)
					{
						IOracleCustomTypeFactory oracleCustomTypeFactory2 = (IOracleCustomTypeFactory)m_udtDescriptor.m_customTypeFactory;
						if (oracleCustomTypeFactory2 != null)
						{
							IOracleCustomType oracleCustomType2 = oracleCustomTypeFactory2.CreateObject();
							Type type2 = oracleCustomType2.GetType();
							PropertyInfo property2 = type2.GetProperty("Null");
							array.SetValue(property2.GetValue(null, null), i);
						}
					}
				}
				m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
			}
			m_value = array;
			break;
		}
		case ParameterDirection.Input:
		{
			for (int i = 0; i < m_arrBindCount; i++)
			{
				SetPrmValCtx(IntPtr.Zero, i);
			}
			break;
		}
		}
		if (m_pOpoPrmValCtx->pOpoUdtValCtx == null)
		{
			return;
		}
		int num = 0;
		try
		{
			num = OpsPrm.FreeUdtObjects(conn.m_opoConCtx.opsConCtx, m_pOpoPrmValCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (num != 0 && num != ErrRes.INT_ERR)
			{
				OracleException.HandleError(num, conn, conn.m_opoConCtx.opsErrCtx, this);
			}
		}
	}

	private unsafe void PostBind_OracleObject(OracleConnection conn)
	{
		switch (m_direction)
		{
		case ParameterDirection.Output:
		case ParameterDirection.InputOutput:
		case ParameterDirection.ReturnValue:
		{
			if (!m_bArrayBind)
			{
				if (*(*(short**)(void*)m_pOpoPrmValCtx->ppTempInd) != -1)
				{
					m_value = CreateCustomObject(conn, 0);
					m_status = OracleParameterStatus.Success;
					break;
				}
				m_curSize = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					if (m_udtDescriptor.m_customTypeFactory == null)
					{
						object factory = OracleUdt.GetFactory(m_udtDescriptor);
						if (factory != null)
						{
							m_udtDescriptor.DescribeCustomType(factory);
						}
					}
					IOracleCustomTypeFactory oracleCustomTypeFactory = (IOracleCustomTypeFactory)m_udtDescriptor.m_customTypeFactory;
					IOracleCustomType oracleCustomType = oracleCustomTypeFactory.CreateObject();
					Type type = oracleCustomType.GetType();
					PropertyInfo property = type.GetProperty("Null");
					m_value = property.GetValue(null, null);
				}
				else
				{
					m_value = DBNull.Value;
				}
				m_status = OracleParameterStatus.NullFetched;
				break;
			}
			Array array = Array.CreateInstance(typeof(object), m_arrBindCount);
			object obj = null;
			for (int i = 0; i < m_arrBindCount; i++)
			{
				if (*(*(short**)((byte*)(void*)m_pOpoPrmValCtx->ppTempInd + (nint)i * (nint)sizeof(void*))) != -1)
				{
					obj = CreateCustomObject(conn, i);
					array.SetValue(obj, i);
					m_arrayBindStatus[i] = OracleParameterStatus.Success;
					continue;
				}
				m_curSize = 0;
				m_curArrayBindSize[i] = 0;
				if (PrmEnumType.ORADBTYPE == m_enumType)
				{
					if (m_udtDescriptor.m_customTypeFactory == null)
					{
						object factory2 = OracleUdt.GetFactory(m_udtDescriptor);
						if (factory2 != null)
						{
							m_udtDescriptor.DescribeCustomType(factory2);
						}
					}
					IOracleCustomTypeFactory oracleCustomTypeFactory2 = (IOracleCustomTypeFactory)m_udtDescriptor.m_customTypeFactory;
					IOracleCustomType oracleCustomType2 = oracleCustomTypeFactory2.CreateObject();
					Type type2 = oracleCustomType2.GetType();
					PropertyInfo property2 = type2.GetProperty("Null");
					obj = property2.GetValue(null, null);
					array.SetValue(obj, i);
				}
				else
				{
					array.SetValue(null, i);
				}
				m_arrayBindStatus[i] = OracleParameterStatus.NullFetched;
			}
			m_value = array;
			break;
		}
		case ParameterDirection.Input:
		{
			for (int i = 0; i < m_arrBindCount; i++)
			{
				SetPrmValCtx(IntPtr.Zero, i);
			}
			break;
		}
		}
		if (m_pOpoPrmValCtx->pOpoUdtValCtx == null)
		{
			return;
		}
		int num = 0;
		try
		{
			num = OpsPrm.FreeUdtObjects(conn.m_opoConCtx.opsConCtx, m_pOpoPrmValCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			num = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (num != 0 && num != ErrRes.INT_ERR)
			{
				OracleException.HandleError(num, conn, conn.m_opoConCtx.opsErrCtx, this);
			}
		}
	}

	private unsafe void ResetUDTInd()
	{
		try
		{
			OpsPrm.ResetValCtx(m_pOpoPrmValCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
	}
}
