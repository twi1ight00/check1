using System;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

[XmlSchemaProvider("GetXsdType")]
public struct OracleTimeStamp : IComparable, INullable, IXmlSerializable
{
	internal const byte MaxArrSize = 11;

	public static readonly OracleTimeStamp MaxValue;

	public static readonly OracleTimeStamp MinValue;

	public static readonly OracleTimeStamp Null;

	private OpoTSCtx m_opoTSCtx;

	private bool m_bNotNull;

	private int m_fSecondPrec;

	public unsafe byte[] BinData
	{
		get
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::BinData: get\n");
			}
			if (m_bNotNull)
			{
				byte[] array = new byte[11];
				int num = 0;
				int num2 = 0;
				try
				{
					num2 = OpsTS.ToBytes(m_opoTSCtx.m_pValCtx, array, &num);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					throw;
				}
				if (num2 != 0)
				{
					throw new OracleTypeException(num2);
				}
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::BinData: get\n");
				}
				return array;
			}
			throw new OracleNullValueException();
		}
	}

	public bool IsNull => !m_bNotNull;

	public unsafe DateTime Value
	{
		get
		{
			if (m_bNotNull)
			{
				return DateTimeConv.GetDateTime(m_opoTSCtx.m_pValCtx, OracleDbType.TimeStamp, bCheck: false);
			}
			throw new OracleNullValueException();
		}
	}

	public int Year
	{
		get
		{
			if (m_bNotNull)
			{
				return GetTSData(0);
			}
			throw new OracleNullValueException();
		}
	}

	public int Month
	{
		get
		{
			if (m_bNotNull)
			{
				return GetTSData(1);
			}
			throw new OracleNullValueException();
		}
	}

	public int Day
	{
		get
		{
			if (m_bNotNull)
			{
				return GetTSData(2);
			}
			throw new OracleNullValueException();
		}
	}

	public int Hour
	{
		get
		{
			if (m_bNotNull)
			{
				return GetTSData(3);
			}
			throw new OracleNullValueException();
		}
	}

	public int Minute
	{
		get
		{
			if (m_bNotNull)
			{
				return GetTSData(4);
			}
			throw new OracleNullValueException();
		}
	}

	public int Second
	{
		get
		{
			if (m_bNotNull)
			{
				return GetTSData(5);
			}
			throw new OracleNullValueException();
		}
	}

	public double Millisecond
	{
		get
		{
			if (m_bNotNull)
			{
				return (double)GetTSData(7) / 1000000.0;
			}
			throw new OracleNullValueException();
		}
	}

	public int Nanosecond
	{
		get
		{
			if (m_bNotNull)
			{
				return GetTSData(7);
			}
			throw new OracleNullValueException();
		}
	}

	static OracleTimeStamp()
	{
		MaxValue = new OracleTimeStamp(9999, 12, 31, 23, 59, 59, 999999999);
		MinValue = new OracleTimeStamp(-4712, 1, 1, 0, 0, 0, 0);
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet)
	{
		return new XmlQualifiedName("dateTime", "http://www.w3.org/2001/XMLSchema");
	}

	XmlSchema IXmlSerializable.GetSchema()
	{
		return null;
	}

	void IXmlSerializable.ReadXml(XmlReader reader)
	{
		string attribute = reader.GetAttribute("null", "http://www.w3.org/2001/XMLSchema-instance");
		if (attribute == null || !XmlConvert.ToBoolean(attribute))
		{
			attribute = reader.ReadElementString();
			m_opoTSCtx = new OpoTSCtx(attribute, TimeStampType.TSType_TS);
			if (m_opoTSCtx.m_error != 0)
			{
				throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
			}
			m_fSecondPrec = 9;
			m_bNotNull = true;
		}
		else
		{
			m_bNotNull = false;
		}
	}

	void IXmlSerializable.WriteXml(XmlWriter writer)
	{
		if (m_bNotNull)
		{
			writer.WriteString(TimeStamp.ToTSString(m_opoTSCtx, m_fSecondPrec, TimeStampType.TSType_TS));
		}
		else
		{
			writer.WriteAttributeString("xsi", "null", "http://www.w3.org/2001/XMLSchema-instance", "true");
		}
	}

	public OracleTimeStamp(int year, int month, int day, int hour, int minute, int second, int nanosecond)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::OracleTimeStamp(1)\n");
		}
		if (!TimeStamp.IsValidDateTime(year, month, day, hour, minute, second, nanosecond))
		{
			throw new ArgumentOutOfRangeException();
		}
		m_opoTSCtx = new OpoTSCtx(year, month, day, hour, minute, second, nanosecond, 0, 0, TimeStampType.TSType_TS);
		if (m_opoTSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
		}
		m_bNotNull = true;
		m_fSecondPrec = 9;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::OracleTimeStamp(1)\n");
		}
	}

	public OracleTimeStamp(int year, int month, int day, int hour, int minute, int second, double millisecond)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::OracleTimeStamp(2)\n");
		}
		if (!TimeStamp.IsValidDateTime(year, month, day, hour, minute, second, (int)(millisecond * 1000000.0)))
		{
			throw new ArgumentOutOfRangeException();
		}
		m_opoTSCtx = new OpoTSCtx(year, month, day, hour, minute, second, millisecond, 0, 0, TimeStampType.TSType_TS);
		if (m_opoTSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
		}
		m_bNotNull = true;
		m_fSecondPrec = 9;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::OracleTimeStamp(2)\n");
		}
	}

	public OracleTimeStamp(int year, int month, int day)
		: this(year, month, day, 0, 0, 0, 0)
	{
	}

	public OracleTimeStamp(int year, int month, int day, int hour, int minute, int second)
		: this(year, month, day, hour, minute, second, 0)
	{
	}

	internal unsafe OracleTimeStamp(IntPtr ociDateTime)
	{
		int num = 0;
		OpoTSValCtx* pLdiDateTimeCtx = null;
		num = OpsTS.AllocValCtxFromOCI(ociDateTime, out pLdiDateTimeCtx);
		if (num != 0)
		{
			throw new OracleException(num, string.Empty, string.Empty, string.Empty);
		}
		m_opoTSCtx = new OpoTSCtx(pLdiDateTimeCtx);
		m_bNotNull = true;
		m_fSecondPrec = 9;
	}

	public OracleTimeStamp(DateTime data)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::OracleTimeStamp(3)\n");
		}
		m_opoTSCtx = new OpoTSCtx(data, 0, 0, TimeStampType.TSType_TS);
		if (m_opoTSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
		}
		m_bNotNull = true;
		m_fSecondPrec = 9;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::OracleTimeStamp(3)\n");
		}
	}

	public OracleTimeStamp(byte[] binData)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::OracleTimeStamp(4)\n");
		}
		if (binData == null)
		{
			throw new ArgumentNullException();
		}
		m_opoTSCtx = new OpoTSCtx(binData, TimeStampType.TSType_TS);
		if (m_opoTSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
		}
		m_bNotNull = true;
		m_fSecondPrec = 9;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::OracleTimeStamp(4)\n");
		}
	}

	public OracleTimeStamp(string tsStr)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::OracleTimeStamp(5)\n");
		}
		if (tsStr == null)
		{
			throw new ArgumentNullException("tsStr");
		}
		m_opoTSCtx = new OpoTSCtx(tsStr, TimeStampType.TSType_TS);
		if (m_opoTSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
		}
		m_bNotNull = true;
		m_fSecondPrec = 9;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::OracleTimeStamp(5)\n");
		}
	}

	internal unsafe static IntPtr AllocValCtx(object methodParam)
	{
		IntPtr pOCIDateTime = IntPtr.Zero;
		bool flag = false;
		int num = 0;
		OpoTSValCtx* pValCtx = null;
		if (methodParam is char[])
		{
			num = OpsTS.AllocValCtxFromStr(new string((char[])methodParam), out pValCtx);
		}
		else if (methodParam is byte[])
		{
			num = OpsTS.AllocValCtxFromBytes((byte[])methodParam, out pValCtx, 9);
		}
		else if (methodParam is string)
		{
			num = OpsTS.AllocValCtxFromStr((string)methodParam, out pValCtx);
		}
		else if (methodParam is DateTime)
		{
			OracleTimeStamp oracleTimeStamp = new OracleTimeStamp((DateTime)methodParam);
			num = OpsTS.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, oracleTimeStamp.GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
			flag = true;
		}
		else if (methodParam is OracleString oracleString)
		{
			num = OpsTS.AllocValCtxFromStr(oracleString.Value, out pValCtx);
		}
		else if (methodParam is OracleDate oracleDate)
		{
			num = OpsTS.AllocValCtxForFromDate(oracleDate.GetValCtx(), out pValCtx);
		}
		else if (methodParam is OracleTimeStamp)
		{
			num = OpsTS.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, ((OracleTimeStamp)methodParam).GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
			flag = true;
		}
		else if (methodParam is OracleTimeStampTZ)
		{
			num = OpsTS.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, ((OracleTimeStampTZ)methodParam).ToOracleTimeStamp().GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
			flag = true;
		}
		else if (methodParam is OracleTimeStampLTZ)
		{
			num = OpsTS.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, ((OracleTimeStampLTZ)methodParam).ToOracleTimeStamp().GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
			flag = true;
		}
		if (!flag)
		{
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
			num = OpsTS.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, pValCtx, out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
			num = OpsTS.FreeValCtx(pValCtx);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		return pOCIDateTime;
	}

	public static bool Equals(OracleTimeStamp value1, OracleTimeStamp value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::Equals(1)\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::Equals(1)\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::Equals(1)\n");
			}
			return false;
		case CompareNullEnum.BothNotNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::Equals(1)\n");
			}
			if (TimeStamp.Compare(value1.m_opoTSCtx, value2.m_opoTSCtx) == 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool GreaterThan(OracleTimeStamp value1, OracleTimeStamp value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::GreaterThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::GreaterThan()\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::GreaterThan()\n");
			}
			if (TimeStamp.Compare(value1.m_opoTSCtx, value2.m_opoTSCtx) > 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool GreaterThanOrEqual(OracleTimeStamp value1, OracleTimeStamp value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::GreaterThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::GreaterThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::GreaterThanOrEqual()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::GreaterThanOrEqual()\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::GreaterThanOrEqual()\n");
			}
			if (TimeStamp.Compare(value1.m_opoTSCtx, value2.m_opoTSCtx) >= 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool LessThan(OracleTimeStamp value1, OracleTimeStamp value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::LessThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::LessThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::LessThan()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::LessThan()\n");
			}
			return false;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::LessThan()\n");
			}
			if (TimeStamp.Compare(value1.m_opoTSCtx, value2.m_opoTSCtx) < 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool LessThanOrEqual(OracleTimeStamp value1, OracleTimeStamp value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::LessThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::LessThanOrEqual()\n");
			}
			return false;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::LessThanOrEqual()\n");
			}
			if (TimeStamp.Compare(value1.m_opoTSCtx, value2.m_opoTSCtx) <= 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool NotEquals(OracleTimeStamp value1, OracleTimeStamp value2)
	{
		return !Equals(value1, value2);
	}

	public unsafe static OracleTimeStamp GetSysDate()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::GetSysDate()\n");
		}
		int num = 0;
		OpoTSValCtx* pValCtx = null;
		try
		{
			num = OpsTS.AllocValCtxForSysDate(out pValCtx);
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
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::GetSysDate()\n");
				}
				if (pValCtx != null)
				{
					try
					{
						OpsTS.FreeValCtx(pValCtx);
					}
					catch (Exception ex2)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex2);
						}
					}
					pValCtx = null;
				}
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::GetSysDate()\n");
		}
		return new OracleTimeStamp(pValCtx);
	}

	public static OracleTimeStamp Parse(string tsStr)
	{
		if (tsStr == null)
		{
			throw new ArgumentNullException();
		}
		return new OracleTimeStamp(tsStr);
	}

	public unsafe static OracleTimeStamp SetPrecision(OracleTimeStamp value1, int fracSecPrecision)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::SetPrecision()\n");
		}
		if (!value1.m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		int num = 0;
		if (fracSecPrecision < 0 || fracSecPrecision > 9)
		{
			throw new ArgumentOutOfRangeException("fracSecPrecision");
		}
		OpoTSValCtx* pValCtx = null;
		try
		{
			num = OpsTS.AllocValCtxFromBytes(value1.BinData, out pValCtx, fracSecPrecision);
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
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::SetPrecision()\n");
				}
				if (pValCtx != null)
				{
					try
					{
						OpsTS.FreeValCtx(pValCtx);
					}
					catch (Exception ex2)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex2);
						}
					}
					pValCtx = null;
				}
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::SetPrecision()\n");
		}
		return new OracleTimeStamp(pValCtx, fracSecPrecision);
	}

	public static bool operator ==(OracleTimeStamp value1, OracleTimeStamp value2)
	{
		return Equals(value1, value2);
	}

	public static bool operator >(OracleTimeStamp value1, OracleTimeStamp value2)
	{
		return GreaterThan(value1, value2);
	}

	public static bool operator >=(OracleTimeStamp value1, OracleTimeStamp value2)
	{
		return GreaterThanOrEqual(value1, value2);
	}

	public static bool operator <(OracleTimeStamp value1, OracleTimeStamp value2)
	{
		return LessThan(value1, value2);
	}

	public static bool operator <=(OracleTimeStamp value1, OracleTimeStamp value2)
	{
		return LessThanOrEqual(value1, value2);
	}

	public static bool operator !=(OracleTimeStamp value1, OracleTimeStamp value2)
	{
		return NotEquals(value1, value2);
	}

	public unsafe static OracleTimeStamp operator +(OracleTimeStamp value1, OracleIntervalDS value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::operator +(1)\n");
		}
		if (value1.IsNull || value2.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator +(1)\n");
			}
			return Null;
		}
		int num = 0;
		OpoTSValCtx* pCtx = null;
		try
		{
			num = OpsTSA.AllocValCtxForAddInterval(value1.m_opoTSCtx.m_pValCtx, value2.GetValCtx(), out pCtx);
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
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator +(1)\n");
				}
				if (pCtx != null)
				{
					try
					{
						OpsTS.FreeValCtx(pCtx);
					}
					catch (Exception ex2)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex2);
						}
					}
					pCtx = null;
				}
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator +(1)\n");
		}
		return new OracleTimeStamp(pCtx);
	}

	public unsafe static OracleTimeStamp operator +(OracleTimeStamp value1, OracleIntervalYM value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::operator +(2)\n");
		}
		if (value1.IsNull || value2.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator +(2)\n");
			}
			return Null;
		}
		int num = 0;
		OpoTSValCtx* pCtx;
		try
		{
			num = OpsTSA.AllocValCtxForAddInterval(value1.m_opoTSCtx.m_pValCtx, value2.GetValCtx(), out pCtx);
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
			throw new OracleTypeException(num);
		}
		OpoTSCtx ctx = new OpoTSCtx(pCtx);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator +(2)\n");
		}
		return new OracleTimeStamp(ctx);
	}

	public unsafe static OracleTimeStamp operator +(OracleTimeStamp value1, TimeSpan value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::operator +(3)\n");
		}
		if (value1.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator +(3)\n");
			}
			return Null;
		}
		int num = 0;
		OpoITLValCtx opoITLValCtx = default(OpoITLValCtx);
		GCHandle gCHandle = GCHandle.Alloc(opoITLValCtx, GCHandleType.Pinned);
		OracleIntervalDS.FillValCtxFromTimeSpan(&opoITLValCtx, value2);
		OpoTSValCtx* pCtx;
		try
		{
			num = OpsTSA.AllocValCtxForAddInterval(value1.m_opoTSCtx.m_pValCtx, &opoITLValCtx, out pCtx);
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
			if (gCHandle.IsAllocated)
			{
				gCHandle.Free();
			}
		}
		OpoTSCtx ctx = new OpoTSCtx(pCtx);
		if (num != 0)
		{
			throw new OracleTypeException(num);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator +(3)\n");
		}
		return new OracleTimeStamp(ctx);
	}

	public unsafe static OracleTimeStamp operator -(OracleTimeStamp value1, OracleIntervalDS value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::operator -(1)\n");
		}
		if (value1.IsNull || value2.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator -(1)\n");
			}
			return Null;
		}
		int num = 0;
		OpoTSValCtx* pCtx;
		try
		{
			num = OpsTSA.AllocValCtxForSubInterval(value1.m_opoTSCtx.m_pValCtx, value2.GetValCtx(), out pCtx);
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
			throw new OracleTypeException(num);
		}
		OpoTSCtx ctx = new OpoTSCtx(pCtx);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator -(1)\n");
		}
		return new OracleTimeStamp(ctx);
	}

	public unsafe static OracleTimeStamp operator -(OracleTimeStamp value1, OracleIntervalYM value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::operator -(2)\n");
		}
		if (value1.IsNull || value2.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator -(2)\n");
			}
			return Null;
		}
		int num = 0;
		OpoTSValCtx* pCtx;
		try
		{
			num = OpsTSA.AllocValCtxForSubInterval(value1.m_opoTSCtx.m_pValCtx, value2.GetValCtx(), out pCtx);
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
			throw new OracleTypeException(num);
		}
		OpoTSCtx ctx = new OpoTSCtx(pCtx);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator -(2)\n");
		}
		return new OracleTimeStamp(ctx);
	}

	public unsafe static OracleTimeStamp operator -(OracleTimeStamp value1, TimeSpan value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::operator -(3)\n");
		}
		if (value1.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator -(3)\n");
			}
			return Null;
		}
		int num = 0;
		OpoITLValCtx opoITLValCtx = default(OpoITLValCtx);
		GCHandle gCHandle = GCHandle.Alloc(opoITLValCtx, GCHandleType.Pinned);
		OpoTSValCtx* pCtx;
		try
		{
			OracleIntervalDS.FillValCtxFromTimeSpan(&opoITLValCtx, value2);
			num = OpsTSA.AllocValCtxForSubInterval(value1.m_opoTSCtx.m_pValCtx, &opoITLValCtx, out pCtx);
		}
		finally
		{
			if (gCHandle.IsAllocated)
			{
				gCHandle.Free();
			}
		}
		OpoTSCtx ctx = new OpoTSCtx(pCtx);
		if (num != 0)
		{
			throw new OracleTypeException(num);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator -(3)\n");
		}
		return new OracleTimeStamp(ctx);
	}

	public static explicit operator OracleTimeStamp(string tsStr)
	{
		return new OracleTimeStamp(tsStr);
	}

	public unsafe static explicit operator DateTime(OracleTimeStamp value1)
	{
		if (value1.m_bNotNull)
		{
			return DateTimeConv.GetDateTime(value1.m_opoTSCtx.m_pValCtx, OracleDbType.TimeStamp, bCheck: false);
		}
		throw new OracleNullValueException();
	}

	public unsafe static implicit operator OracleTimeStamp(OracleDate value1)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::operator OracleTimeStamp(1)\n");
		}
		int num = 0;
		if (!value1.IsNull)
		{
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTS.AllocValCtxForFromDate(value1.GetValCtx(), out pValCtx);
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
				throw new OracleTypeException(num);
			}
			OpoTSCtx ctx = new OpoTSCtx(pValCtx);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator OracleTimeStamp(1)\n");
			}
			return new OracleTimeStamp(ctx);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator OracleTimeStamp(1)\n");
		}
		return Null;
	}

	public static explicit operator OracleTimeStamp(OracleTimeStampLTZ value1)
	{
		if (!value1.IsNull)
		{
			return OracleTimeStampLTZ.ToTS(value1);
		}
		return Null;
	}

	public static explicit operator OracleTimeStamp(OracleTimeStampTZ value1)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::operator OracleTimeStamp(2)\n");
		}
		if (!value1.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator OracleTimeStamp(2)\n");
			}
			return OracleTimeStampTZ.ToTS(value1);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::operator OracleTimeStamp(2)\n");
		}
		return Null;
	}

	public static implicit operator OracleTimeStamp(DateTime value1)
	{
		return new OracleTimeStamp(value1);
	}

	public unsafe OracleTimeStamp AddYears(int years)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::AddYears()\n");
		}
		if (years < -999999999 || years > 999999999)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (m_bNotNull)
		{
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTSA.AllocValCtxForAddYears(m_opoTSCtx.m_pValCtx, years, out pValCtx);
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
				throw new OracleTypeException(num);
			}
			OpoTSCtx ctx = new OpoTSCtx(pValCtx);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::AddYears()\n");
			}
			return new OracleTimeStamp(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStamp AddMonths(long months)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::AddMonths()\n");
		}
		if (months <= -12000000000L || months >= 12000000000L)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (m_bNotNull)
		{
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTSA.AllocValCtxForAddMonths(m_opoTSCtx.m_pValCtx, months, out pValCtx);
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
				throw new OracleTypeException(num);
			}
			OpoTSCtx ctx = new OpoTSCtx(pValCtx);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::AddMonths()\n");
			}
			return new OracleTimeStamp(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStamp AddDays(double days)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::AddDays()\n");
		}
		if (days <= -1000000000.0 || days >= 1000000000.0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (m_bNotNull)
		{
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTSA.AllocValCtxForAddDays(m_opoTSCtx.m_pValCtx, days, out pValCtx);
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
				throw new OracleTypeException(num);
			}
			OpoTSCtx ctx = new OpoTSCtx(pValCtx);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::AddDays()\n");
			}
			return new OracleTimeStamp(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStamp AddHours(double hours)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::AddHours()\n");
		}
		if (hours <= -24000000000.0 || hours >= 24000000000.0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (m_bNotNull)
		{
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTSA.AllocValCtxForAddHours(m_opoTSCtx.m_pValCtx, hours, out pValCtx);
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
				throw new OracleTypeException(num);
			}
			OpoTSCtx ctx = new OpoTSCtx(pValCtx);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::AddHours()\n");
			}
			return new OracleTimeStamp(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStamp AddMinutes(double minutes)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::AddMinutes()\n");
		}
		if (minutes <= -1440000000000.0 || minutes >= 1440000000000.0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (m_bNotNull)
		{
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTSA.AllocValCtxForAddMinutes(m_opoTSCtx.m_pValCtx, minutes, out pValCtx);
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
				throw new OracleTypeException(num);
			}
			OpoTSCtx ctx = new OpoTSCtx(pValCtx);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::AddMinutes()\n");
			}
			return new OracleTimeStamp(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStamp AddSeconds(double seconds)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::AddSeconds()\n");
		}
		if (seconds <= -86400000000000.0 || seconds >= 86400000000000.0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (m_bNotNull)
		{
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTSA.AllocValCtxForAddSeconds(m_opoTSCtx.m_pValCtx, seconds, out pValCtx);
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
				throw new OracleTypeException(num);
			}
			OpoTSCtx ctx = new OpoTSCtx(pValCtx);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::AddSeconds()\n");
			}
			return new OracleTimeStamp(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStamp AddMilliseconds(double milliseconds)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::AddMilliseconds()\n");
		}
		if (milliseconds <= -86400000000000000.0 || milliseconds >= 86400000000000000.0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (m_bNotNull)
		{
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTSA.AllocValCtxForAddMilliseconds(m_opoTSCtx.m_pValCtx, milliseconds, out pValCtx);
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
				throw new OracleTypeException(num);
			}
			OpoTSCtx ctx = new OpoTSCtx(pValCtx);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::AddMilliseconds()\n");
			}
			return new OracleTimeStamp(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStamp AddNanoseconds(long nanoseconds)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::AddNanoseconds()\n");
		}
		if (m_bNotNull)
		{
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTSA.AllocValCtxForAddNanoseconds(m_opoTSCtx.m_pValCtx, nanoseconds, out pValCtx);
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
				throw new OracleTypeException(num);
			}
			OpoTSCtx ctx = new OpoTSCtx(pValCtx);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::AddNanoseconds()\n");
			}
			return new OracleTimeStamp(ctx);
		}
		throw new OracleNullValueException();
	}

	public int CompareTo(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::CompareTo()\n");
		}
		if (obj.GetType() != typeof(OracleTimeStamp))
		{
			throw new ArgumentException();
		}
		OracleTimeStamp oracleTimeStamp = (OracleTimeStamp)obj;
		switch (InternalTypes.CompareNull(!m_bNotNull, !oracleTimeStamp.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::CompareTo()\n");
			}
			return 0;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::CompareTo()\n");
			}
			return -1;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::CompareTo()\n");
			}
			return 1;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::CompareTo()\n");
			}
			return TimeStamp.Compare(m_opoTSCtx, oracleTimeStamp.m_opoTSCtx);
		}
	}

	public override bool Equals(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::Equals(2)\n");
		}
		if (obj == null)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::Equals(2)\n");
			}
			return false;
		}
		if (obj.GetType() != typeof(OracleTimeStamp))
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::Equals(2)\n");
			}
			return false;
		}
		OracleTimeStamp value = (OracleTimeStamp)obj;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::Equals(2)\n");
		}
		return Equals(this, value);
	}

	public override int GetHashCode()
	{
		if (m_bNotNull)
		{
			return m_opoTSCtx.GetHashCode();
		}
		return 0;
	}

	public unsafe OracleIntervalDS GetDaysBetween(OracleTimeStamp value1)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::GetDaysBetween()\n");
		}
		if (m_bNotNull && value1.m_bNotNull)
		{
			int num = 0;
			OpoITLValCtx* pIDS;
			try
			{
				num = OpsTSA.AllocValCtxForSubTSToIDS(m_opoTSCtx.m_pValCtx, value1.m_opoTSCtx.m_pValCtx, out pIDS);
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
				throw new OracleTypeException(num);
			}
			OpoIDSCtx ctx = new OpoIDSCtx(pIDS);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::GetDaysBetween()\n");
			}
			return new OracleIntervalDS(ctx);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::GetDaysBetween()\n");
		}
		return OracleIntervalDS.Null;
	}

	public unsafe OracleIntervalYM GetYearsBetween(OracleTimeStamp value1)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::GetYearsBetween()\n");
		}
		if (m_bNotNull && value1.m_bNotNull)
		{
			int num = 0;
			OpoITLValCtx* pIDS;
			try
			{
				num = OpsTSA.AllocValCtxForSubTSToIYM(m_opoTSCtx.m_pValCtx, value1.m_opoTSCtx.m_pValCtx, out pIDS);
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
				throw new OracleTypeException(num);
			}
			OpoIYMCtx ctx = new OpoIYMCtx(pIDS);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::GetYearsBetween()\n");
			}
			return new OracleIntervalYM(ctx);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::GetYearsBetween()\n");
		}
		return OracleIntervalYM.Null;
	}

	public unsafe OracleDate ToOracleDate()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::ToOracleDate()\n");
		}
		if (m_bNotNull)
		{
			int num = 0;
			OpoDatValCtx* pDatCtx;
			try
			{
				num = OpsTSA.AllocValCtxForToDate(m_opoTSCtx.m_pValCtx, out pDatCtx);
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
				throw new OracleTypeException(num);
			}
			OpoDatCtx ctx = new OpoDatCtx(pDatCtx);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::ToOracleDate()\n");
			}
			return new OracleDate(ctx);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::ToOracleDate()\n");
		}
		return OracleDate.Null;
	}

	public OracleTimeStampLTZ ToOracleTimeStampLTZ()
	{
		if (m_bNotNull)
		{
			return ToTSL(this);
		}
		return OracleTimeStampLTZ.Null;
	}

	public OracleTimeStampTZ ToOracleTimeStampTZ()
	{
		if (m_bNotNull)
		{
			return ToTSZ(this);
		}
		return OracleTimeStampTZ.Null;
	}

	public override string ToString()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStamp::ToString()\n");
		}
		if (m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::ToString()\n");
			}
			return TimeStamp.ToTSString(m_opoTSCtx, m_fSecondPrec, TimeStampType.TSType_TS);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStamp::ToString()\n");
		}
		return "null";
	}

	internal unsafe OracleTimeStamp(OpoTSValCtx* pCtx)
		: this(pCtx, 9)
	{
	}

	internal unsafe OracleTimeStamp(OpoTSValCtx* pCtx, int fSecondPrec)
	{
		m_opoTSCtx = new OpoTSCtx(pCtx);
		m_bNotNull = true;
		m_fSecondPrec = fSecondPrec;
	}

	internal OracleTimeStamp(OpoTSCtx ctx)
	{
		m_opoTSCtx = ctx;
		m_bNotNull = true;
		m_fSecondPrec = 9;
	}

	internal unsafe static OracleTimeStampTZ ToTSZ(OracleTimeStamp value1)
	{
		if (value1.m_bNotNull)
		{
			int num = 0;
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTSA.AllocValCtxForToTSZ(value1.m_opoTSCtx.m_pValCtx, out pValCtx);
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
				throw new OracleTypeException(num);
			}
			OpoTSCtx ctx = new OpoTSCtx(pValCtx);
			return new OracleTimeStampTZ(ctx);
		}
		return OracleTimeStampTZ.Null;
	}

	internal unsafe static OracleTimeStampLTZ ToTSL(OracleTimeStamp value1)
	{
		if (value1.m_bNotNull)
		{
			int num = 0;
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTSA.AllocValCtxForToTSL(value1.m_opoTSCtx.m_pValCtx, out pValCtx);
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
				throw new OracleTypeException(num);
			}
			OpoTSCtx ctx = new OpoTSCtx(pValCtx);
			return new OracleTimeStampLTZ(ctx);
		}
		return OracleTimeStampLTZ.Null;
	}

	internal unsafe OpoTSValCtx* GetValCtx()
	{
		return m_opoTSCtx.m_pValCtx;
	}

	internal unsafe IntPtr DupValCtx()
	{
		IntPtr pNewCtx = IntPtr.Zero;
		int num = 0;
		num = OpsTSA.DupValCtx(GetValCtx(), out pNewCtx, TimeStampType.TSType_TS);
		if (num != 0)
		{
			throw new OracleException(num, string.Empty, string.Empty, string.Empty);
		}
		return pNewCtx;
	}

	internal unsafe int GetTSData(byte tsComponent)
	{
		return TimeStamp.GetTSData(m_opoTSCtx.m_pValCtx, tsComponent);
	}
}
