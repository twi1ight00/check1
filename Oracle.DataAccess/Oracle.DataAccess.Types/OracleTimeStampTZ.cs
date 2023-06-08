using System;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

[XmlSchemaProvider("GetXsdType")]
public struct OracleTimeStampTZ : IComparable, INullable, IXmlSerializable
{
	internal const byte MaxArrSize = 13;

	public static readonly OracleTimeStampTZ MaxValue;

	public static readonly OracleTimeStampTZ MinValue;

	public static readonly OracleTimeStampTZ Null;

	private OpoTSCtx m_opoTSCtx;

	private bool m_bNotNull;

	private int m_fSecondPrec;

	private int m_year;

	private int m_month;

	private int m_day;

	private int m_hour;

	private int m_minute;

	private int m_second;

	private int m_fSecond;

	private string m_timeZone;

	public unsafe byte[] BinData
	{
		get
		{
			if (m_bNotNull)
			{
				byte[] array = new byte[13];
				int num = 0;
				int num2 = 0;
				try
				{
					num2 = OpsTSZ.ToBytes(m_opoTSCtx.m_pValCtx, array, &num);
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
				OpoTSValCtx opoTSValCtx = default(OpoTSValCtx);
				opoTSValCtx.m_year = (short)m_year;
				opoTSValCtx.m_month = (byte)m_month;
				opoTSValCtx.m_day = (byte)m_day;
				opoTSValCtx.m_hour = (byte)m_hour;
				opoTSValCtx.m_minute = (byte)m_minute;
				opoTSValCtx.m_second = (byte)m_second;
				opoTSValCtx.m_fSecond = m_fSecond;
				return DateTimeConv.GetDateTime(&opoTSValCtx, OracleDbType.TimeStamp, bCheck: false);
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
				return m_year;
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
				return m_month;
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
				return m_day;
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
				return m_hour;
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
				return m_minute;
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
				return m_second;
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
				return (double)m_fSecond / 1000000.0;
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
				return m_fSecond;
			}
			throw new OracleNullValueException();
		}
	}

	public string TimeZone
	{
		get
		{
			if (m_bNotNull)
			{
				if (m_timeZone == null)
				{
					m_timeZone = GetTimeZoneName();
				}
				return m_timeZone;
			}
			throw new OracleNullValueException();
		}
	}

	static OracleTimeStampTZ()
	{
		MaxValue = GetMaxValue(9999, 12, 31, 23, 59, 59, 999999999, 0, 0);
		MinValue = GetMinValue(-4712, 1, 1, 0, 0, 0, 0, 0, 0);
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet)
	{
		return new XmlQualifiedName("DateTime", "http://www.w3.org/2001/XMLSchema");
	}

	XmlSchema IXmlSerializable.GetSchema()
	{
		return null;
	}

	unsafe void IXmlSerializable.ReadXml(XmlReader reader)
	{
		string attribute = reader.GetAttribute("null", "http://www.w3.org/2001/XMLSchema-instance");
		if (attribute == null || !XmlConvert.ToBoolean(attribute))
		{
			attribute = reader.ReadElementString();
			m_opoTSCtx = new OpoTSCtx(attribute, TimeStampType.TSType_TSZ);
			if (m_opoTSCtx.m_error != 0)
			{
				throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
			}
			int num = 0;
			OpoTSValCtx opoTSValCtx = default(OpoTSValCtx);
			try
			{
				num = OpsTSZ.ConvertToTSL(m_opoTSCtx.m_pValCtx, &opoTSValCtx);
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
			m_year = opoTSValCtx.m_year;
			m_month = opoTSValCtx.m_month;
			m_day = opoTSValCtx.m_day;
			m_hour = opoTSValCtx.m_hour;
			m_minute = opoTSValCtx.m_minute;
			m_second = opoTSValCtx.m_second;
			m_fSecond = opoTSValCtx.m_fSecond;
			m_fSecondPrec = 9;
			m_timeZone = null;
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
			writer.WriteString(TimeStamp.ToTSString(m_opoTSCtx, m_fSecondPrec, TimeStampType.TSType_TSZ));
		}
		else
		{
			writer.WriteAttributeString("xsi", "null", "http://www.w3.org/2001/XMLSchema-instance", "true");
		}
	}

	public OracleTimeStampTZ(int year, int month, int day, int hour, int minute, int second, int nanosecond, string timeZone)
	{
		if (!TimeStamp.IsValidDateTime(year, month, day, hour, minute, second, nanosecond))
		{
			throw new ArgumentOutOfRangeException();
		}
		m_opoTSCtx = new OpoTSCtx(year, month, day, hour, minute, second, nanosecond, timeZone);
		if (m_opoTSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
		}
		m_year = year;
		m_day = day;
		m_month = month;
		m_hour = hour;
		m_minute = minute;
		m_second = second;
		m_fSecond = nanosecond;
		m_bNotNull = true;
		m_fSecondPrec = 9;
		m_timeZone = timeZone;
	}

	public OracleTimeStampTZ(int year, int month, int day, int hour, int minute, int second, int nanosecond)
		: this(year, month, day, hour, minute, second, nanosecond, null)
	{
	}

	public OracleTimeStampTZ(int year, int month, int day, int hour, int minute, int second, double millisecond, string timeZone)
	{
		if (!TimeStamp.IsValidDateTime(year, month, day, hour, minute, second, (int)(millisecond * 1000000.0)))
		{
			throw new ArgumentOutOfRangeException();
		}
		int fSecond = (int)(millisecond * 1000000.0);
		m_opoTSCtx = new OpoTSCtx(year, month, day, hour, minute, second, fSecond, timeZone);
		if (m_opoTSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
		}
		m_year = year;
		m_day = day;
		m_month = month;
		m_hour = hour;
		m_minute = minute;
		m_second = second;
		m_fSecond = (int)(millisecond * 1000000.0);
		m_bNotNull = true;
		m_fSecondPrec = 9;
		m_timeZone = timeZone;
	}

	public OracleTimeStampTZ(int year, int month, int day, int hour, int minute, int second, double millisecond)
		: this(year, month, day, hour, minute, second, millisecond, null)
	{
	}

	public OracleTimeStampTZ(int year, int month, int day, string timeZone)
		: this(year, month, day, 0, 0, 0, 0, timeZone)
	{
	}

	public OracleTimeStampTZ(int year, int month, int day)
		: this(year, month, day, 0, 0, 0, 0)
	{
	}

	internal unsafe OracleTimeStampTZ(IntPtr ociDateTime)
	{
		int num = 0;
		OpoTSValCtx* pValCtx = null;
		num = OpsTSZ.AllocValCtxFromOCI(ociDateTime, out pValCtx);
		if (num != 0)
		{
			throw new OracleException(num, string.Empty, string.Empty, string.Empty);
		}
		m_opoTSCtx = new OpoTSCtx(pValCtx);
		OpoTSValCtx opoTSValCtx = default(OpoTSValCtx);
		try
		{
			num = OpsTSZ.ConvertToTSL(m_opoTSCtx.m_pValCtx, &opoTSValCtx);
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
		m_year = opoTSValCtx.m_year;
		m_month = opoTSValCtx.m_month;
		m_day = opoTSValCtx.m_day;
		m_hour = opoTSValCtx.m_hour;
		m_minute = opoTSValCtx.m_minute;
		m_second = opoTSValCtx.m_second;
		m_fSecond = opoTSValCtx.m_fSecond;
		m_bNotNull = true;
		m_fSecondPrec = 9;
		m_timeZone = null;
	}

	public OracleTimeStampTZ(int year, int month, int day, int hour, int minute, int second, string timeZone)
		: this(year, month, day, hour, minute, second, 0, timeZone)
	{
	}

	public OracleTimeStampTZ(int year, int month, int day, int hour, int minute, int second)
		: this(year, month, day, hour, minute, second, 0)
	{
	}

	public unsafe OracleTimeStampTZ(DateTime data, string timeZone)
	{
		m_opoTSCtx = new OpoTSCtx(data, timeZone);
		if (m_opoTSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
		}
		OpoTSValCtx opoTSValCtx = default(OpoTSValCtx);
		TimeStamp.FillValCtxFromDateTime(&opoTSValCtx, data);
		m_year = opoTSValCtx.m_year;
		m_month = opoTSValCtx.m_month;
		m_day = opoTSValCtx.m_day;
		m_hour = opoTSValCtx.m_hour;
		m_minute = opoTSValCtx.m_minute;
		m_second = opoTSValCtx.m_second;
		m_fSecond = opoTSValCtx.m_fSecond;
		m_bNotNull = true;
		m_fSecondPrec = 9;
		m_timeZone = timeZone;
	}

	public OracleTimeStampTZ(DateTime data)
		: this(data, null)
	{
	}

	public unsafe OracleTimeStampTZ(byte[] binData)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::OracleTimeStampTZ(4)\n");
		}
		if (binData == null)
		{
			throw new ArgumentNullException();
		}
		m_opoTSCtx = new OpoTSCtx(binData, TimeStampType.TSType_TSZ);
		if (m_opoTSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
		}
		OpoTSValCtx opoTSValCtx = default(OpoTSValCtx);
		try
		{
			OpsTSZ.ConvertToTSL(m_opoTSCtx.m_pValCtx, &opoTSValCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		m_year = opoTSValCtx.m_year;
		m_month = opoTSValCtx.m_month;
		m_day = opoTSValCtx.m_day;
		m_hour = opoTSValCtx.m_hour;
		m_minute = opoTSValCtx.m_minute;
		m_second = opoTSValCtx.m_second;
		m_fSecond = opoTSValCtx.m_fSecond;
		m_bNotNull = true;
		m_fSecondPrec = 9;
		m_timeZone = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::OracleTimeStampTZ(4)\n");
		}
	}

	public unsafe OracleTimeStampTZ(string tsStr)
	{
		if (tsStr == null)
		{
			throw new ArgumentNullException();
		}
		m_opoTSCtx = new OpoTSCtx(tsStr, TimeStampType.TSType_TSZ);
		if (m_opoTSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
		}
		int num = 0;
		OpoTSValCtx opoTSValCtx = default(OpoTSValCtx);
		try
		{
			num = OpsTSZ.ConvertToTSL(m_opoTSCtx.m_pValCtx, &opoTSValCtx);
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
		m_year = opoTSValCtx.m_year;
		m_month = opoTSValCtx.m_month;
		m_day = opoTSValCtx.m_day;
		m_hour = opoTSValCtx.m_hour;
		m_minute = opoTSValCtx.m_minute;
		m_second = opoTSValCtx.m_second;
		m_fSecond = opoTSValCtx.m_fSecond;
		m_bNotNull = true;
		m_fSecondPrec = 9;
		m_timeZone = null;
	}

	internal unsafe static IntPtr AllocValCtx(object methodParam)
	{
		IntPtr pOCIDateTime = IntPtr.Zero;
		int num = 0;
		if (methodParam is char[])
		{
			OracleTimeStampTZ oracleTimeStampTZ = new OracleTimeStampTZ(new string((char[])methodParam));
			num = OpsTSZ.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, oracleTimeStampTZ.GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is byte[])
		{
			num = OpsTSZ.AllocValCtxFromBytes((byte[])methodParam, out var pValCtx, 9);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
			num = OpsTSZ.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, pValCtx, out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
			num = OpsTSZ.FreeValCtx(pValCtx);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is string)
		{
			OracleTimeStampTZ oracleTimeStampTZ2 = new OracleTimeStampTZ((string)methodParam);
			num = OpsTSZ.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, oracleTimeStampTZ2.GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is DateTime)
		{
			OracleTimeStampTZ oracleTimeStampTZ3 = new OracleTimeStampTZ((DateTime)methodParam);
			num = OpsTSZ.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, oracleTimeStampTZ3.GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is OracleString)
		{
			OracleTimeStampTZ oracleTimeStampTZ4 = new OracleTimeStampTZ(((OracleString)methodParam).Value);
			num = OpsTSZ.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, oracleTimeStampTZ4.GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is OracleDate oracleDate)
		{
			num = OpsTSZ.AllocValCtxForFromDate(oracleDate.GetValCtx(), out var pValCtx2);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
			num = OpsTSZ.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, pValCtx2, out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
			num = OpsTSZ.FreeValCtx(pValCtx2);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is OracleTimeStamp)
		{
			num = OpsTSZ.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, ((OracleTimeStamp)methodParam).ToOracleTimeStampTZ().GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is OracleTimeStampTZ)
		{
			num = OpsTSZ.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, ((OracleTimeStampTZ)methodParam).GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is OracleTimeStampLTZ)
		{
			num = OpsTSZ.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, ((OracleTimeStampLTZ)methodParam).ToOracleTimeStampTZ().GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		return pOCIDateTime;
	}

	public static bool Equals(OracleTimeStampTZ value1, OracleTimeStampTZ value2)
	{
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			return true;
		default:
			return false;
		case CompareNullEnum.BothNotNull:
			if (TimeStamp.Compare(value1.m_opoTSCtx, value2.m_opoTSCtx) == 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool GreaterThan(OracleTimeStampTZ value1, OracleTimeStampTZ value2)
	{
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			return false;
		case CompareNullEnum.FirstNullOnly:
			return false;
		case CompareNullEnum.SecondNullOnly:
			return true;
		default:
			if (TimeStamp.Compare(value1.m_opoTSCtx, value2.m_opoTSCtx) > 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool GreaterThanOrEqual(OracleTimeStampTZ value1, OracleTimeStampTZ value2)
	{
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			return true;
		case CompareNullEnum.FirstNullOnly:
			return false;
		case CompareNullEnum.SecondNullOnly:
			return true;
		default:
			if (TimeStamp.Compare(value1.m_opoTSCtx, value2.m_opoTSCtx) >= 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool LessThan(OracleTimeStampTZ value1, OracleTimeStampTZ value2)
	{
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			return false;
		case CompareNullEnum.FirstNullOnly:
			return true;
		case CompareNullEnum.SecondNullOnly:
			return false;
		default:
			if (TimeStamp.Compare(value1.m_opoTSCtx, value2.m_opoTSCtx) < 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool LessThanOrEqual(OracleTimeStampTZ value1, OracleTimeStampTZ value2)
	{
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			return true;
		case CompareNullEnum.FirstNullOnly:
			return true;
		case CompareNullEnum.SecondNullOnly:
			return false;
		default:
			if (TimeStamp.Compare(value1.m_opoTSCtx, value2.m_opoTSCtx) <= 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool NotEquals(OracleTimeStampTZ value1, OracleTimeStampTZ value2)
	{
		return !Equals(value1, value2);
	}

	public unsafe static OracleTimeStampTZ GetSysDate()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::GetSysDate()\n");
		}
		int num = 0;
		OpoTSValCtx* pValCtx = null;
		try
		{
			num = OpsTSZ.AllocValCtxForSysDate(out pValCtx);
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
					OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::GetSysDate()\n");
				}
				if (pValCtx != null)
				{
					try
					{
						OpsTSZ.FreeValCtx(pValCtx);
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
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::GetSysDate()\n");
		}
		return new OracleTimeStampTZ(pValCtx);
	}

	public static OracleTimeStampTZ Parse(string tsStr)
	{
		if (tsStr == null)
		{
			throw new ArgumentNullException();
		}
		return new OracleTimeStampTZ(tsStr);
	}

	public unsafe static OracleTimeStampTZ SetPrecision(OracleTimeStampTZ value1, int fracSecPrecision)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::SetPrecision()\n");
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
			num = OpsTSZ.AllocValCtxFromBytes(value1.BinData, out pValCtx, fracSecPrecision);
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
					OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::SetPrecision()\n");
				}
				if (pValCtx != null)
				{
					try
					{
						OpsTSZ.FreeValCtx(pValCtx);
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
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::SetPrecision()\n");
		}
		return new OracleTimeStampTZ(pValCtx, fracSecPrecision);
	}

	public static bool operator ==(OracleTimeStampTZ value1, OracleTimeStampTZ value2)
	{
		return Equals(value1, value2);
	}

	public static bool operator >(OracleTimeStampTZ value1, OracleTimeStampTZ value2)
	{
		return GreaterThan(value1, value2);
	}

	public static bool operator >=(OracleTimeStampTZ value1, OracleTimeStampTZ value2)
	{
		return GreaterThanOrEqual(value1, value2);
	}

	public static bool operator <(OracleTimeStampTZ value1, OracleTimeStampTZ value2)
	{
		return LessThan(value1, value2);
	}

	public static bool operator <=(OracleTimeStampTZ value1, OracleTimeStampTZ value2)
	{
		return LessThanOrEqual(value1, value2);
	}

	public static bool operator !=(OracleTimeStampTZ value1, OracleTimeStampTZ value2)
	{
		return NotEquals(value1, value2);
	}

	public unsafe static OracleTimeStampTZ operator +(OracleTimeStampTZ value1, OracleIntervalDS value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::operator +(1)\n");
		}
		if (value1.IsNull || value2.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::operator +(1)\n");
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
					OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::operator +(1)\n");
				}
				if (pCtx != null)
				{
					try
					{
						OpsTSZ.FreeValCtx(pCtx);
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
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::operator +(1)\n");
		}
		return new OracleTimeStampTZ(pCtx);
	}

	public unsafe static OracleTimeStampTZ operator +(OracleTimeStampTZ value1, OracleIntervalYM value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::operator +(2)\n");
		}
		if (value1.IsNull || value2.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::operator +(2)\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::operator +(2)\n");
		}
		return new OracleTimeStampTZ(ctx);
	}

	public unsafe static OracleTimeStampTZ operator +(OracleTimeStampTZ value1, TimeSpan value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::operator +(3)\n");
		}
		if (value1.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::operator +(3)\n");
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
			num = OpsTSA.AllocValCtxForAddInterval(value1.m_opoTSCtx.m_pValCtx, &opoITLValCtx, out pCtx);
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
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::operator +(3)\n");
		}
		return new OracleTimeStampTZ(ctx);
	}

	public unsafe static OracleTimeStampTZ operator -(OracleTimeStampTZ value1, OracleIntervalDS value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::operator -(1)\n");
		}
		if (value1.IsNull || value2.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::operator -(1)\n");
			}
			return Null;
		}
		int num = 0;
		OpoTSCtx opoTSCtx = new OpoTSCtx(TimeStampType.TSType_TSZ);
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
		opoTSCtx = new OpoTSCtx(pCtx);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::operator -(1)\n");
		}
		return new OracleTimeStampTZ(opoTSCtx);
	}

	public unsafe static OracleTimeStampTZ operator -(OracleTimeStampTZ value1, OracleIntervalYM value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::operator -(2)\n");
		}
		if (value1.IsNull || value2.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::operator -(2)\n");
			}
			return Null;
		}
		int num = 0;
		OpoTSCtx opoTSCtx = new OpoTSCtx(TimeStampType.TSType_TSZ);
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
		opoTSCtx = new OpoTSCtx(pCtx);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::operator -(2)\n");
		}
		return new OracleTimeStampTZ(opoTSCtx);
	}

	public unsafe static OracleTimeStampTZ operator -(OracleTimeStampTZ value1, TimeSpan value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::operator -(3)\n");
		}
		if (value1.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::operator -(3)\n");
			}
			return Null;
		}
		int num = 0;
		OpoTSCtx opoTSCtx = new OpoTSCtx(TimeStampType.TSType_TSZ);
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
		opoTSCtx = new OpoTSCtx(pCtx);
		if (num != 0)
		{
			throw new OracleTypeException(num);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::operator -()\n");
		}
		return new OracleTimeStampTZ(opoTSCtx);
	}

	public static explicit operator OracleTimeStampTZ(string tsStr)
	{
		return new OracleTimeStampTZ(tsStr);
	}

	public static explicit operator DateTime(OracleTimeStampTZ value1)
	{
		if (value1.m_bNotNull)
		{
			return value1.Value;
		}
		throw new OracleNullValueException();
	}

	public unsafe static implicit operator OracleTimeStampTZ(OracleDate value1)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::operator OracleTimeStampTZ(1)\n");
		}
		if (!value1.IsNull)
		{
			int num = 0;
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTSZ.AllocValCtxForFromDate(value1.GetValCtx(), out pValCtx);
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::operator OracleTimeStampTZ(1)\n");
			}
			return new OracleTimeStampTZ(ctx);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::operator OracleTimeStampTZ(1)\n");
		}
		return Null;
	}

	public static explicit operator OracleTimeStampTZ(OracleTimeStamp value1)
	{
		if (!value1.IsNull)
		{
			return OracleTimeStamp.ToTSZ(value1);
		}
		return Null;
	}

	public static explicit operator OracleTimeStampTZ(OracleTimeStampLTZ value1)
	{
		if (!value1.IsNull)
		{
			return OracleTimeStampLTZ.ToTSZ(value1);
		}
		return Null;
	}

	public static implicit operator OracleTimeStampTZ(DateTime value1)
	{
		return new OracleTimeStampTZ(value1, null);
	}

	public unsafe OracleTimeStampTZ AddYears(int years)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::AddYears()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::AddYears()\n");
			}
			return new OracleTimeStampTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStampTZ AddMonths(long months)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::AddMonths()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::AddMonths()\n");
			}
			return new OracleTimeStampTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStampTZ AddDays(double days)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::AddDays()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::AddDays()\n");
			}
			return new OracleTimeStampTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStampTZ AddHours(double hours)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::AddDays()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::AddDays()\n");
			}
			return new OracleTimeStampTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStampTZ AddMinutes(double minutes)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::AddMinutes()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::AddMinutes()\n");
			}
			return new OracleTimeStampTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStampTZ AddSeconds(double seconds)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::AddSeconds()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::AddSeconds()\n");
			}
			return new OracleTimeStampTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStampTZ AddMilliseconds(double milliseconds)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::AddMilliseconds()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::AddMilliseconds()\n");
			}
			return new OracleTimeStampTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStampTZ AddNanoseconds(long nanoseconds)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::AddNanoseconds()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::AddNanoseconds()\n");
			}
			return new OracleTimeStampTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public int CompareTo(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::CompareTo()\n");
		}
		if (obj.GetType() != typeof(OracleTimeStampTZ))
		{
			throw new ArgumentException();
		}
		OracleTimeStampTZ oracleTimeStampTZ = (OracleTimeStampTZ)obj;
		switch (InternalTypes.CompareNull(!m_bNotNull, !oracleTimeStampTZ.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::CompareTo()\n");
			}
			return 0;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::CompareTo()\n");
			}
			return -1;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::CompareTo()\n");
			}
			return 1;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::CompareTo()\n");
			}
			return TimeStamp.Compare(m_opoTSCtx, oracleTimeStampTZ.m_opoTSCtx);
		}
	}

	public override bool Equals(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::Equals()\n");
		}
		if (obj == null)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::Equals()\n");
			}
			return false;
		}
		if (obj.GetType() != typeof(OracleTimeStampTZ))
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::Equals()\n");
			}
			return false;
		}
		OracleTimeStampTZ value = (OracleTimeStampTZ)obj;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::Equals()\n");
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

	public unsafe OracleIntervalDS GetDaysBetween(OracleTimeStampTZ value1)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::GetDaysBetween()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::GetDaysBetween()\n");
			}
			return new OracleIntervalDS(ctx);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::GetDaysBetween()\n");
		}
		return OracleIntervalDS.Null;
	}

	public unsafe OracleIntervalYM GetYearsBetween(OracleTimeStampTZ value1)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::GetYearsBetween()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::GetYearsBetween()\n");
			}
			return new OracleIntervalYM(ctx);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::GetYearsBetween()\n");
		}
		return OracleIntervalYM.Null;
	}

	private unsafe string GetTimeZoneName()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::GetTimeZoneName()\n");
		}
		if (m_bNotNull)
		{
			int num = 0;
			OpoTSValCtx* pValCtx = m_opoTSCtx.m_pValCtx;
			string tzStr;
			try
			{
				num = OpsTSZ.GetTimeZoneName(pValCtx->m_tzHour, pValCtx->m_tzMinute, pValCtx->m_regid, out tzStr);
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
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::GetTimeZoneName()\n");
			}
			return tzStr;
		}
		throw new OracleNullValueException();
	}

	public unsafe TimeSpan GetTimeZoneOffset()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::GetTimeZoneOffset()\n");
		}
		if (m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::GetTimeZoneOffset()\n");
			}
			return new TimeSpan(m_opoTSCtx.m_pValCtx->m_tzHour, m_opoTSCtx.m_pValCtx->m_tzMinute, 0);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStampLTZ ToLocalTime()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::ToLocalTime()\n");
		}
		if (m_bNotNull)
		{
			int num = 0;
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTSA.AllocValCtxForToTSL(m_opoTSCtx.m_pValCtx, out pValCtx);
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::ToLocalTime()\n");
			}
			return new OracleTimeStampLTZ(ctx);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::ToLocalTime()\n");
		}
		return OracleTimeStampLTZ.Null;
	}

	public unsafe OracleDate ToOracleDate()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::ToOracleDate()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::ToOracleDate()\n");
			}
			return new OracleDate(ctx);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::ToOracleDate()\n");
		}
		return OracleDate.Null;
	}

	public OracleTimeStamp ToOracleTimeStamp()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::ToOracleTimeStamp()\n");
		}
		if (m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::ToOracleTimeStamp()\n");
			}
			return ToTS(this);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::ToOracleTimeStamp()\n");
		}
		return OracleTimeStamp.Null;
	}

	public OracleTimeStampLTZ ToOracleTimeStampLTZ()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::ToOracleTimeStampLTZ()\n");
		}
		if (m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::ToOracleTimeStampLTZ()\n");
			}
			return ToTSL(this);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::ToOracleTimeStampLTZ()\n");
		}
		return OracleTimeStampLTZ.Null;
	}

	public override string ToString()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::ToString()\n");
		}
		if (m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::ToString()\n");
			}
			return TimeStamp.ToTSString(m_opoTSCtx, m_fSecondPrec, TimeStampType.TSType_TSZ);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::ToString()\n");
		}
		return "null";
	}

	public OracleTimeStampTZ ToUniversalTime()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampTZ::ToUniversalTime()\n");
		}
		if (m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::ToUniversalTime()\n");
			}
			return TimeStamp.ToUniversalTime(m_opoTSCtx);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampTZ::ToUniversalTime()\n");
		}
		return Null;
	}

	internal unsafe OracleTimeStampTZ(OpoTSValCtx* pCtx)
		: this(pCtx, 9)
	{
	}

	internal unsafe OracleTimeStampTZ(OpoTSValCtx* pCtx, int fSecondPrec)
	{
		m_opoTSCtx = new OpoTSCtx(pCtx);
		int num = 0;
		OpoTSValCtx opoTSValCtx = default(OpoTSValCtx);
		try
		{
			num = OpsTSZ.ConvertToTSL(m_opoTSCtx.m_pValCtx, &opoTSValCtx);
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
		m_year = opoTSValCtx.m_year;
		m_month = opoTSValCtx.m_month;
		m_day = opoTSValCtx.m_day;
		m_hour = opoTSValCtx.m_hour;
		m_minute = opoTSValCtx.m_minute;
		m_second = opoTSValCtx.m_second;
		m_fSecond = opoTSValCtx.m_fSecond;
		m_bNotNull = true;
		m_fSecondPrec = fSecondPrec;
		m_timeZone = null;
	}

	internal unsafe OracleTimeStampTZ(OpoTSCtx ctx)
	{
		m_opoTSCtx = ctx;
		int num = 0;
		OpoTSValCtx opoTSValCtx = default(OpoTSValCtx);
		try
		{
			num = OpsTSZ.ConvertToTSL(m_opoTSCtx.m_pValCtx, &opoTSValCtx);
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
		m_year = opoTSValCtx.m_year;
		m_month = opoTSValCtx.m_month;
		m_day = opoTSValCtx.m_day;
		m_hour = opoTSValCtx.m_hour;
		m_minute = opoTSValCtx.m_minute;
		m_second = opoTSValCtx.m_second;
		m_fSecond = opoTSValCtx.m_fSecond;
		m_bNotNull = true;
		m_fSecondPrec = 9;
		m_timeZone = null;
	}

	internal unsafe static OracleTimeStampTZ GetMaxValue(int year, int month, int day, int hour, int minute, int second, int nanosecond, int tzHours, int tzMinutes)
	{
		OpoTSValCtx* pTSCtx = null;
		int num = 0;
		try
		{
			num = OpsTSZ.AllocMaxValue(year, month, day, hour, minute, second, nanosecond, tzHours, tzMinutes, out pTSCtx);
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
				if (pTSCtx != null)
				{
					try
					{
						OpsTSZ.FreeValCtx(pTSCtx);
					}
					catch (Exception ex2)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex2);
						}
					}
					pTSCtx = null;
				}
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		return new OracleTimeStampTZ(pTSCtx);
	}

	internal unsafe static OracleTimeStampTZ GetMinValue(int year, int month, int day, int hour, int minute, int second, int nanosecond, int tzHours, int tzMinutes)
	{
		OpoTSValCtx* pTSCtx = null;
		int num = 0;
		try
		{
			num = OpsTSZ.AllocMinValue(year, month, day, hour, minute, second, nanosecond, tzHours, tzMinutes, out pTSCtx);
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
				if (pTSCtx != null)
				{
					try
					{
						OpsTSZ.FreeValCtx(pTSCtx);
					}
					catch (Exception ex2)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex2);
						}
					}
					pTSCtx = null;
				}
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		return new OracleTimeStampTZ(pTSCtx);
	}

	internal unsafe static OracleTimeStamp ToTS(OracleTimeStampTZ value1)
	{
		if (value1.m_bNotNull)
		{
			int num = 0;
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTSA.AllocValCtxForToTS(value1.m_opoTSCtx.m_pValCtx, out pValCtx);
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
			return new OracleTimeStamp(ctx);
		}
		return OracleTimeStamp.Null;
	}

	internal unsafe static OracleTimeStampLTZ ToTSL(OracleTimeStampTZ value1)
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
		num = OpsTSA.DupValCtx(GetValCtx(), out pNewCtx, TimeStampType.TSType_TSZ);
		if (num != 0)
		{
			throw new OracleException(num, string.Empty, string.Empty, string.Empty);
		}
		return pNewCtx;
	}
}
