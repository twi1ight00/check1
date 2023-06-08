using System;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

[XmlSchemaProvider("GetXsdType")]
public struct OracleTimeStampLTZ : IComparable, INullable, IXmlSerializable
{
	internal const byte MaxArrSize = 11;

	public static readonly OracleTimeStampLTZ MaxValue;

	public static readonly OracleTimeStampLTZ MinValue;

	public static readonly OracleTimeStampLTZ Null;

	private OpoTSCtx m_opoTSCtx;

	private bool m_bNotNull;

	private int m_fSecondPrec;

	public unsafe byte[] BinData
	{
		get
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::BinData: get\n");
			}
			if (m_bNotNull)
			{
				byte[] array = new byte[11];
				int num = 0;
				int num2 = 0;
				try
				{
					num2 = OpsTSL.ToBytes(m_opoTSCtx.m_pValCtx, array, &num);
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
					OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::BinData: get\n");
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
				return DateTimeConv.GetDateTime(m_opoTSCtx.m_pValCtx, OracleDbType.TimeStampLTZ, bCheck: false);
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

	static OracleTimeStampLTZ()
	{
		MaxValue = new OracleTimeStampLTZ(9999, 12, 31, 23, 59, 59, 999999999);
		MinValue = new OracleTimeStampLTZ(-4712, 1, 1, 0, 0, 0, 0);
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
			m_opoTSCtx = new OpoTSCtx(attribute, TimeStampType.TSType_TSL);
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
			writer.WriteString(TimeStamp.ToTSString(m_opoTSCtx, m_fSecondPrec, TimeStampType.TSType_TSL));
		}
		else
		{
			writer.WriteAttributeString("xsi", "null", "http://www.w3.org/2001/XMLSchema-instance", "true");
		}
	}

	public OracleTimeStampLTZ(int year, int month, int day, int hour, int minute, int second, int nanosecond)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::OracleTimeStampLTZ(1)\n");
		}
		if (!TimeStamp.IsValidDateTime(year, month, day, hour, minute, second, nanosecond))
		{
			throw new ArgumentOutOfRangeException();
		}
		m_opoTSCtx = new OpoTSCtx(year, month, day, hour, minute, second, nanosecond, TimeStamp.LocalTZOffset.m_tzHours, TimeStamp.LocalTZOffset.m_tzMinutes, TimeStampType.TSType_TSL);
		if (m_opoTSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
		}
		m_bNotNull = true;
		m_fSecondPrec = 9;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::OracleTimeStampLTZ(1)\n");
		}
	}

	public OracleTimeStampLTZ(int year, int month, int day, int hour, int minute, int second, double millisecond)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::OracleTimeStampLTZ(2)\n");
		}
		if (!TimeStamp.IsValidDateTime(year, month, day, hour, minute, second, (int)(millisecond * 1000000.0)))
		{
			throw new ArgumentOutOfRangeException();
		}
		m_opoTSCtx = new OpoTSCtx(year, month, day, hour, minute, second, millisecond, TimeStamp.LocalTZOffset.m_tzHours, TimeStamp.LocalTZOffset.m_tzMinutes, TimeStampType.TSType_TSL);
		if (m_opoTSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
		}
		m_bNotNull = true;
		m_fSecondPrec = 9;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::OracleTimeStampLTZ(2)\n");
		}
	}

	internal unsafe OracleTimeStampLTZ(IntPtr ociDateTime)
	{
		int num = 0;
		OpoTSValCtx* pValCtx = null;
		num = OpsTSL.AllocValCtxFromOCI(ociDateTime, out pValCtx);
		if (num != 0)
		{
			throw new OracleException(num, string.Empty, string.Empty, string.Empty);
		}
		m_opoTSCtx = new OpoTSCtx(pValCtx);
		m_bNotNull = true;
		m_fSecondPrec = 9;
	}

	public OracleTimeStampLTZ(int year, int month, int day)
		: this(year, month, day, 0, 0, 0, 0)
	{
	}

	public OracleTimeStampLTZ(int year, int month, int day, int hour, int minute, int second)
		: this(year, month, day, hour, minute, second, 0)
	{
	}

	public OracleTimeStampLTZ(DateTime data)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::OracleTimeStampLTZ(3)\n");
		}
		m_opoTSCtx = new OpoTSCtx(data, TimeStamp.LocalTZOffset.m_tzHours, TimeStamp.LocalTZOffset.m_tzMinutes, TimeStampType.TSType_TSL);
		if (m_opoTSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
		}
		m_bNotNull = true;
		m_fSecondPrec = 9;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::OracleTimeStampLTZ(3)\n");
		}
	}

	public OracleTimeStampLTZ(byte[] binData)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::OracleTimeStampLTZ(4)\n");
		}
		if (binData == null)
		{
			throw new ArgumentNullException();
		}
		m_opoTSCtx = new OpoTSCtx(binData, TimeStampType.TSType_TSL);
		if (m_opoTSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
		}
		m_bNotNull = true;
		m_fSecondPrec = 9;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::OracleTimeStampLTZ(4)\n");
		}
	}

	public OracleTimeStampLTZ(string tsStr)
	{
		if (tsStr == null)
		{
			throw new ArgumentNullException();
		}
		m_opoTSCtx = new OpoTSCtx(tsStr, TimeStampType.TSType_TSL);
		if (m_opoTSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoTSCtx.m_error));
		}
		m_bNotNull = true;
		m_fSecondPrec = 9;
	}

	internal unsafe static IntPtr AllocValCtx(object methodParam)
	{
		IntPtr pOCIDateTime = IntPtr.Zero;
		int num = 0;
		if (methodParam is char[])
		{
			OracleTimeStampLTZ oracleTimeStampLTZ = new OracleTimeStampLTZ(new string((char[])methodParam));
			num = OpsTSL.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, oracleTimeStampLTZ.GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is byte[])
		{
			num = OpsTSL.AllocValCtxFromBytes((byte[])methodParam, out var pValCtx, 9);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
			num = OpsTSL.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, pValCtx, out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
			num = OpsTSL.FreeValCtx(pValCtx);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is string)
		{
			OracleTimeStampLTZ oracleTimeStampLTZ2 = new OracleTimeStampLTZ((string)methodParam);
			num = OpsTSL.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, oracleTimeStampLTZ2.GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is DateTime)
		{
			OracleTimeStampLTZ oracleTimeStampLTZ3 = new OracleTimeStampLTZ((DateTime)methodParam);
			num = OpsTSL.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, oracleTimeStampLTZ3.GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is OracleString)
		{
			OracleTimeStampLTZ oracleTimeStampLTZ4 = new OracleTimeStampLTZ(((OracleString)methodParam).Value);
			num = OpsTSL.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, oracleTimeStampLTZ4.GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is OracleDate oracleDate)
		{
			num = OpsTSL.AllocValCtxForFromDate(oracleDate.GetValCtx(), out var pValCtx2);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
			num = OpsTSL.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, pValCtx2, out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
			num = OpsTSL.FreeValCtx(pValCtx2);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is OracleTimeStamp)
		{
			num = OpsTSL.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, ((OracleTimeStamp)methodParam).ToOracleTimeStampLTZ().GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is OracleTimeStampTZ)
		{
			num = OpsTSL.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, ((OracleTimeStampTZ)methodParam).ToOracleTimeStampLTZ().GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		else if (methodParam is OracleTimeStampLTZ)
		{
			num = OpsTSL.AllocOCIFromValCtx(OracleConnection.GetInternalConnection().m_opoConCtx.opsConCtx, ((OracleTimeStampLTZ)methodParam).GetValCtx(), out pOCIDateTime);
			if (num != 0)
			{
				throw new OracleException(num, string.Empty, string.Empty, string.Empty);
			}
		}
		return pOCIDateTime;
	}

	public static bool Equals(OracleTimeStampLTZ value1, OracleTimeStampLTZ value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::Equals(1)\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::Equals(1)\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::Equals(1)\n");
			}
			return false;
		case CompareNullEnum.BothNotNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::Equals(1)\n");
			}
			if (TimeStamp.Compare(value1.m_opoTSCtx, value2.m_opoTSCtx) == 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool GreaterThan(OracleTimeStampLTZ value1, OracleTimeStampLTZ value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::GreaterThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::GreaterThan()\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::GreaterThan()\n");
			}
			if (TimeStamp.Compare(value1.m_opoTSCtx, value2.m_opoTSCtx) > 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool GreaterThanOrEqual(OracleTimeStampLTZ value1, OracleTimeStampLTZ value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::GreaterThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::GreaterThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::GreaterThanOrEqual()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::GreaterThanOrEqual()\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::GreaterThanOrEqual()\n");
			}
			if (TimeStamp.Compare(value1.m_opoTSCtx, value2.m_opoTSCtx) >= 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool LessThan(OracleTimeStampLTZ value1, OracleTimeStampLTZ value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::LessThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::LessThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::LessThan()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::LessThan()\n");
			}
			return false;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::LessThan()\n");
			}
			if (TimeStamp.Compare(value1.m_opoTSCtx, value2.m_opoTSCtx) < 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool LessThanOrEqual(OracleTimeStampLTZ value1, OracleTimeStampLTZ value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::LessThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::LessThanOrEqual()\n");
			}
			return false;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::LessThanOrEqual()\n");
			}
			if (TimeStamp.Compare(value1.m_opoTSCtx, value2.m_opoTSCtx) <= 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool NotEquals(OracleTimeStampLTZ value1, OracleTimeStampLTZ value2)
	{
		return !Equals(value1, value2);
	}

	public unsafe static OracleTimeStampLTZ GetSysDate()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::GetSysDate()\n");
		}
		int num = 0;
		OpoTSValCtx* pValCtx = null;
		try
		{
			num = OpsTSL.AllocValCtxForSysDate(out pValCtx);
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
					OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::GetSysDate()\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::GetSysDate()\n");
		}
		return new OracleTimeStampLTZ(pValCtx);
	}

	public static string GetLocalTimeZoneName()
	{
		return TimeStamp.LocalTZName;
	}

	public static TimeSpan GetLocalTimeZoneOffset()
	{
		return new TimeSpan(TimeStamp.LocalTZOffset.m_tzHours, TimeStamp.LocalTZOffset.m_tzMinutes, 0);
	}

	public static OracleTimeStampLTZ Parse(string tsStr)
	{
		if (tsStr == null)
		{
			throw new ArgumentNullException();
		}
		return new OracleTimeStampLTZ(tsStr);
	}

	public unsafe static OracleTimeStampLTZ SetPrecision(OracleTimeStampLTZ value1, int fracSecPrecision)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::SetPrecision()\n");
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
			num = OpsTSL.AllocValCtxFromBytes(value1.BinData, out pValCtx, fracSecPrecision);
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
					OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::SetPrecision()\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::SetPrecision()\n");
		}
		return new OracleTimeStampLTZ(pValCtx, fracSecPrecision);
	}

	public static bool operator ==(OracleTimeStampLTZ value1, OracleTimeStampLTZ value2)
	{
		return Equals(value1, value2);
	}

	public static bool operator >(OracleTimeStampLTZ value1, OracleTimeStampLTZ value2)
	{
		return GreaterThan(value1, value2);
	}

	public static bool operator >=(OracleTimeStampLTZ value1, OracleTimeStampLTZ value2)
	{
		return GreaterThanOrEqual(value1, value2);
	}

	public static bool operator <(OracleTimeStampLTZ value1, OracleTimeStampLTZ value2)
	{
		return LessThan(value1, value2);
	}

	public static bool operator <=(OracleTimeStampLTZ value1, OracleTimeStampLTZ value2)
	{
		return LessThanOrEqual(value1, value2);
	}

	public static bool operator !=(OracleTimeStampLTZ value1, OracleTimeStampLTZ value2)
	{
		return NotEquals(value1, value2);
	}

	public unsafe static OracleTimeStampLTZ operator +(OracleTimeStampLTZ value1, OracleIntervalDS value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::operator +(1)\n");
		}
		if (value1.IsNull || value2.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator +(1)\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator +(1)\n");
		}
		return new OracleTimeStampLTZ(ctx);
	}

	public unsafe static OracleTimeStampLTZ operator +(OracleTimeStampLTZ value1, OracleIntervalYM value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::operator +(2)\n");
		}
		if (value1.IsNull || value2.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator +()\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator +()\n");
		}
		return new OracleTimeStampLTZ(ctx);
	}

	public unsafe static OracleTimeStampLTZ operator +(OracleTimeStampLTZ value1, TimeSpan value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::operator +(3)\n");
		}
		if (value1.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator +(3)\n");
			}
			return Null;
		}
		int num = 0;
		OpoITLValCtx opoITLValCtx = default(OpoITLValCtx);
		GCHandle gCHandle = GCHandle.Alloc(opoITLValCtx, GCHandleType.Pinned);
		try
		{
			OracleIntervalDS.FillValCtxFromTimeSpan(&opoITLValCtx, value2);
			if ((num = OpsTSA.AllocValCtxForAddInterval(value1.m_opoTSCtx.m_pValCtx, &opoITLValCtx, out var pCtx)) != 0)
			{
				if (pCtx != null)
				{
					try
					{
						OpsTS.FreeValCtx(pCtx);
					}
					catch (Exception ex)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex);
						}
					}
					pCtx = null;
				}
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator +(3)\n");
				}
				throw new OracleTypeException(num);
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator +(3)\n");
			}
			return new OracleTimeStampLTZ(pCtx);
		}
		finally
		{
			if (gCHandle.IsAllocated)
			{
				gCHandle.Free();
			}
		}
	}

	public unsafe static OracleTimeStampLTZ operator -(OracleTimeStampLTZ value1, OracleIntervalDS value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::operator -(1)\n");
		}
		if (value1.IsNull || value2.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator -(1)\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator -(1)\n");
		}
		return new OracleTimeStampLTZ(ctx);
	}

	public unsafe static OracleTimeStampLTZ operator -(OracleTimeStampLTZ value1, OracleIntervalYM value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::operator -(2)\n");
		}
		if (value1.IsNull || value2.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator -(2)\n");
			}
			return Null;
		}
		int num = 0;
		OpoTSCtx opoTSCtx = new OpoTSCtx(TimeStampType.TSType_TSL);
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
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator -(2)\n");
		}
		return new OracleTimeStampLTZ(opoTSCtx);
	}

	public unsafe static OracleTimeStampLTZ operator -(OracleTimeStampLTZ value1, TimeSpan value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::operator -(3)\n");
		}
		if (value1.IsNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator -(3)\n");
			}
			return Null;
		}
		int num = 0;
		OpoTSCtx opoTSCtx = new OpoTSCtx(TimeStampType.TSType_TSL);
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
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator -(3)\n");
		}
		return new OracleTimeStampLTZ(opoTSCtx);
	}

	public static explicit operator OracleTimeStampLTZ(string tsStr)
	{
		return new OracleTimeStampLTZ(tsStr);
	}

	public unsafe static explicit operator DateTime(OracleTimeStampLTZ value1)
	{
		if (value1.m_bNotNull)
		{
			return DateTimeConv.GetDateTime(value1.m_opoTSCtx.m_pValCtx, OracleDbType.TimeStampLTZ, bCheck: false);
		}
		throw new OracleNullValueException();
	}

	public unsafe static implicit operator OracleTimeStampLTZ(OracleDate value1)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::operator OracleTimeStampLTZ(1)\n");
		}
		if (!value1.IsNull)
		{
			int num = 0;
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTSL.AllocValCtxForFromDate(value1.GetValCtx(), out pValCtx);
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator OracleTimeStampLTZ(1)\n");
			}
			return new OracleTimeStampLTZ(ctx);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator OracleTimeStampLTZ(1)\n");
		}
		return Null;
	}

	public static explicit operator OracleTimeStampLTZ(OracleTimeStamp value1)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::operator OracleTimeStampLTZ(2)\n");
		}
		if (!value1.IsNull)
		{
			return OracleTimeStamp.ToTSL(value1);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::operator OracleTimeStampLTZ(2)\n");
		}
		return Null;
	}

	public static explicit operator OracleTimeStampLTZ(OracleTimeStampTZ value1)
	{
		if (!value1.IsNull)
		{
			return OracleTimeStampTZ.ToTSL(value1);
		}
		return Null;
	}

	public static implicit operator OracleTimeStampLTZ(DateTime value1)
	{
		return new OracleTimeStampLTZ(value1);
	}

	public unsafe OracleTimeStampLTZ AddYears(int years)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::AddYears()\n");
		}
		int num = 0;
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::AddYears()\n");
			}
			return new OracleTimeStampLTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStampLTZ AddMonths(long months)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::AddMonths()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::AddMonths()\n");
			}
			return new OracleTimeStampLTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStampLTZ AddDays(double days)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::AddDays()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::AddDays()\n");
			}
			return new OracleTimeStampLTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStampLTZ AddHours(double hours)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::AddHours()\n");
		}
		int num = 0;
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::AddHours()\n");
			}
			return new OracleTimeStampLTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStampLTZ AddMinutes(double minutes)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::AddMinutes()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::AddMinutes()\n");
			}
			return new OracleTimeStampLTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStampLTZ AddSeconds(double seconds)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::AddSeconds()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::AddSeconds()\n");
			}
			return new OracleTimeStampLTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStampLTZ AddMilliseconds(double milliseconds)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::AddMilliseconds()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::AddMilliseconds()\n");
			}
			return new OracleTimeStampLTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public unsafe OracleTimeStampLTZ AddNanoseconds(long nanoseconds)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::AddNanoseconds()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::AddNanoseconds()\n");
			}
			return new OracleTimeStampLTZ(ctx);
		}
		throw new OracleNullValueException();
	}

	public int CompareTo(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::CompareTo()\n");
		}
		if (obj.GetType() != typeof(OracleTimeStampLTZ))
		{
			throw new ArgumentException();
		}
		OracleTimeStampLTZ oracleTimeStampLTZ = (OracleTimeStampLTZ)obj;
		switch (InternalTypes.CompareNull(!m_bNotNull, !oracleTimeStampLTZ.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::CompareTo()\n");
			}
			return 0;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::CompareTo()\n");
			}
			return -1;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::CompareTo()\n");
			}
			return 1;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::CompareTo()\n");
			}
			return TimeStamp.Compare(m_opoTSCtx, oracleTimeStampLTZ.m_opoTSCtx);
		}
	}

	public override bool Equals(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::Equals(2)\n");
		}
		if (obj == null)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::Equals(2)\n");
			}
			return false;
		}
		if (obj.GetType() != typeof(OracleTimeStampLTZ))
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::Equals(2)\n");
			}
			return false;
		}
		OracleTimeStampLTZ value = (OracleTimeStampLTZ)obj;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::Equals(2)\n");
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

	public unsafe OracleIntervalDS GetDaysBetween(OracleTimeStampLTZ value1)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::GetDaysBetween()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::GetDaysBetween()\n");
			}
			return new OracleIntervalDS(ctx);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::GetDaysBetween()\n");
		}
		return OracleIntervalDS.Null;
	}

	public unsafe OracleIntervalYM GetYearsBetween(OracleTimeStampLTZ value1)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::GetYearsBetween()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::GetYearsBetween()\n");
			}
			return new OracleIntervalYM(ctx);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::GetYearsBetween()\n");
		}
		return OracleIntervalYM.Null;
	}

	public unsafe OracleDate ToOracleDate()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::ToOracleDate()\n");
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
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::ToOracleDate()\n");
			}
			return new OracleDate(ctx);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::ToOracleDate()\n");
		}
		return OracleDate.Null;
	}

	public OracleTimeStamp ToOracleTimeStamp()
	{
		if (m_bNotNull)
		{
			return ToTS(this);
		}
		return OracleTimeStamp.Null;
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
			OraTrace.Trace(1u, " (ENTRY) OracleTimeStampLTZ::ToString()\n");
		}
		if (m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::ToString()\n");
			}
			return TimeStamp.ToTSString(m_opoTSCtx, m_fSecondPrec, TimeStampType.TSType_TSL);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleTimeStampLTZ::ToString()\n");
		}
		return "null";
	}

	public OracleTimeStampTZ ToUniversalTime()
	{
		if (m_bNotNull)
		{
			return TimeStamp.ToUniversalTime(m_opoTSCtx);
		}
		return OracleTimeStampTZ.Null;
	}

	internal unsafe OracleTimeStampLTZ(OpoTSValCtx* pCtx)
		: this(pCtx, 9)
	{
	}

	internal unsafe OracleTimeStampLTZ(OpoTSValCtx* pCtx, int fSecondPrec)
	{
		m_opoTSCtx = new OpoTSCtx(pCtx);
		m_bNotNull = true;
		m_fSecondPrec = fSecondPrec;
	}

	internal OracleTimeStampLTZ(OpoTSCtx ctx)
	{
		m_opoTSCtx = ctx;
		m_bNotNull = true;
		m_fSecondPrec = 9;
	}

	internal unsafe static OracleTimeStamp ToTS(OracleTimeStampLTZ value1)
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

	internal unsafe static OracleTimeStampTZ ToTSZ(OracleTimeStampLTZ value1)
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

	internal unsafe OpoTSValCtx* GetValCtx()
	{
		return m_opoTSCtx.m_pValCtx;
	}

	internal unsafe IntPtr DupValCtx()
	{
		IntPtr pNewCtx = IntPtr.Zero;
		int num = 0;
		num = OpsTSA.DupValCtx(GetValCtx(), out pNewCtx, TimeStampType.TSType_TSL);
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
