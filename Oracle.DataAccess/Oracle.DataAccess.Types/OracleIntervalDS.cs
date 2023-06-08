using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

[Serializable]
[XmlSchemaProvider("GetXsdType")]
public struct OracleIntervalDS : IComparable, INullable, IXmlSerializable
{
	internal const short MaxArrSize = 11;

	internal const byte IDSType = 10;

	internal const byte DAY = 2;

	internal const byte HOUR = 3;

	internal const byte MINUTE = 4;

	internal const byte SECOND = 5;

	internal const byte MILLISECOND = 6;

	internal const byte FSECOND = 7;

	internal const byte MaxStrLen = byte.MaxValue;

	public static readonly OracleIntervalDS MaxValue;

	public static readonly OracleIntervalDS MinValue;

	public static readonly OracleIntervalDS Null;

	public static readonly OracleIntervalDS Zero;

	private OpoIDSCtx m_opoIDSCtx;

	private bool m_bNotNull;

	private int m_dayPrec;

	private int m_fSecondPrec;

	public unsafe byte[] BinData
	{
		get
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::BinData: get\n");
			}
			int num = 0;
			if (m_bNotNull)
			{
				byte[] array = new byte[11];
				try
				{
					num = OpsIDS.ToBytes(m_opoIDSCtx.m_pValCtx, array);
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
					OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::BinData: get\n");
				}
				return array;
			}
			throw new OracleNullValueException();
		}
	}

	public bool IsNull => !m_bNotNull;

	public unsafe TimeSpan Value
	{
		get
		{
			if (m_bNotNull)
			{
				return TimeSpanConv.GetTimeSpan(m_opoIDSCtx.m_pValCtx, OracleDbType.IntervalDS);
			}
			throw new OracleNullValueException();
		}
	}

	public int Days
	{
		get
		{
			if (m_bNotNull)
			{
				return GetIDSData(2);
			}
			throw new OracleNullValueException();
		}
	}

	public int Hours
	{
		get
		{
			if (m_bNotNull)
			{
				return GetIDSData(3);
			}
			throw new OracleNullValueException();
		}
	}

	public int Minutes
	{
		get
		{
			if (m_bNotNull)
			{
				return GetIDSData(4);
			}
			throw new OracleNullValueException();
		}
	}

	public int Seconds
	{
		get
		{
			if (m_bNotNull)
			{
				return GetIDSData(5);
			}
			throw new OracleNullValueException();
		}
	}

	public double Milliseconds
	{
		get
		{
			if (m_bNotNull)
			{
				return GetIDSData(7) / 1000000;
			}
			throw new OracleNullValueException();
		}
	}

	public int Nanoseconds
	{
		get
		{
			if (m_bNotNull)
			{
				return GetIDSData(7);
			}
			throw new OracleNullValueException();
		}
	}

	public unsafe double TotalDays
	{
		get
		{
			if (m_bNotNull)
			{
				double result = 0.0;
				try
				{
					OpsIDS.ToDays(m_opoIDSCtx.m_pValCtx, &result);
					return result;
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
			throw new OracleNullValueException();
		}
	}

	static OracleIntervalDS()
	{
		MaxValue = new OracleIntervalDS(999999999, 23, 59, 59, 999999999);
		MinValue = new OracleIntervalDS(-999999999, -23, -59, -59, -999999999);
		Zero = new OracleIntervalDS(0, 0, 0, 0, 0);
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet)
	{
		return new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
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
			m_opoIDSCtx = new OpoIDSCtx(attribute);
			if (m_opoIDSCtx.m_error != 0)
			{
				throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoIDSCtx.m_error));
			}
			m_fSecondPrec = 9;
			m_dayPrec = 9;
			m_bNotNull = true;
		}
		else
		{
			m_bNotNull = false;
		}
	}

	unsafe void IXmlSerializable.WriteXml(XmlWriter writer)
	{
		if (m_bNotNull)
		{
			writer.WriteString(ITLMethods.ToString(m_opoIDSCtx.m_pValCtx, m_dayPrec, m_fSecondPrec));
		}
		else
		{
			writer.WriteAttributeString("xsi", "null", "http://www.w3.org/2001/XMLSchema-instance", "true");
		}
	}

	public OracleIntervalDS(int days, int hours, int minutes, int seconds, int nanoseconds)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::OracleIntervalDS(1)\n");
		}
		if (Interval.IsValidDS(days, hours, minutes, seconds, nanoseconds))
		{
			m_opoIDSCtx = new OpoIDSCtx(days, hours, minutes, seconds, nanoseconds);
			if (m_opoIDSCtx.m_error != 0)
			{
				throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoIDSCtx.m_error));
			}
			m_bNotNull = true;
			m_fSecondPrec = 9;
			m_dayPrec = 9;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::OracleIntervalDS(1)\n");
			}
			return;
		}
		throw new ArgumentOutOfRangeException();
	}

	public OracleIntervalDS(int days, int hours, int minutes, int seconds, double milliseconds)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::OracleIntervalDS(2)\n");
		}
		int num = (int)(milliseconds * 1000000.0);
		if (Interval.IsValidDS(days, hours, minutes, seconds, num))
		{
			m_opoIDSCtx = new OpoIDSCtx(days, hours, minutes, seconds, num);
			if (m_opoIDSCtx.m_error != 0)
			{
				throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoIDSCtx.m_error));
			}
			m_bNotNull = true;
			m_fSecondPrec = 9;
			m_dayPrec = 9;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::OracleIntervalDS(2)\n");
			}
			return;
		}
		throw new ArgumentOutOfRangeException();
	}

	public OracleIntervalDS(TimeSpan data)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::OracleIntervalDS(3)\n");
		}
		m_opoIDSCtx = new OpoIDSCtx(data);
		m_bNotNull = true;
		m_fSecondPrec = 9;
		m_dayPrec = 9;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::OracleIntervalDS(3)\n");
		}
	}

	public OracleIntervalDS(double totalDays)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::OracleIntervalDS(4)\n");
		}
		if (Interval.IsValidDSDays(totalDays))
		{
			m_opoIDSCtx = new OpoIDSCtx(totalDays);
			if (m_opoIDSCtx.m_error != 0)
			{
				throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoIDSCtx.m_error));
			}
			m_bNotNull = true;
			m_fSecondPrec = 9;
			m_dayPrec = 9;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::OracleIntervalDS(4)\n");
			}
			return;
		}
		throw new ArgumentOutOfRangeException();
	}

	public OracleIntervalDS(string intervalStr)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::OracleIntervalDS(5)\n");
		}
		if (intervalStr == null)
		{
			throw new ArgumentNullException();
		}
		m_opoIDSCtx = new OpoIDSCtx(intervalStr);
		if (m_opoIDSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoIDSCtx.m_error));
		}
		m_bNotNull = true;
		m_fSecondPrec = 9;
		m_dayPrec = 9;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::OracleIntervalDS(5)\n");
		}
	}

	internal unsafe OracleIntervalDS(IntPtr ociInterval)
	{
		int num = 0;
		OracleConnection internalConnection = OracleConnection.GetInternalConnection();
		OpoITLValCtx* pCtx = null;
		num = OpsIDS.AllocValCtxFromOCI(internalConnection.m_opoConCtx.opsConCtx, internalConnection.m_opoConCtx.opsErrCtx, ociInterval, out pCtx);
		if (num != 0)
		{
			throw new OracleException(num, string.Empty, string.Empty, string.Empty);
		}
		m_opoIDSCtx = new OpoIDSCtx(pCtx);
		m_bNotNull = true;
		m_fSecondPrec = 9;
		m_dayPrec = 9;
	}

	public OracleIntervalDS(byte[] binData)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::OracleIntervalDS(6)\n");
		}
		if (binData == null)
		{
			throw new ArgumentNullException();
		}
		m_opoIDSCtx = new OpoIDSCtx(binData);
		if (m_opoIDSCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoIDSCtx.m_error));
		}
		m_bNotNull = true;
		m_fSecondPrec = 9;
		m_dayPrec = 9;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::OracleIntervalDS(6)\n");
		}
	}

	public unsafe static bool Equals(OracleIntervalDS value1, OracleIntervalDS value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::Equals(1)\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Equals(1)\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Equals(1)\n");
			}
			return false;
		case CompareNullEnum.BothNotNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Equals(1)\n");
			}
			if (ITLMethods.Compare(value1.m_opoIDSCtx.m_pValCtx, value2.m_opoIDSCtx.m_pValCtx) == 0)
			{
				return true;
			}
			return false;
		}
	}

	public unsafe static bool GreaterThan(OracleIntervalDS value1, OracleIntervalDS value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::GreaterThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::GreaterThan()\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::GreaterThan()\n");
			}
			if (ITLMethods.Compare(value1.m_opoIDSCtx.m_pValCtx, value2.m_opoIDSCtx.m_pValCtx) > 0)
			{
				return true;
			}
			return false;
		}
	}

	public unsafe static bool GreaterThanOrEqual(OracleIntervalDS value1, OracleIntervalDS value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::GreaterThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::GreaterThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::GreaterThanOrEqual()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::GreaterThanOrEqual()\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::GreaterThanOrEqual()\n");
			}
			if (ITLMethods.Compare(value1.m_opoIDSCtx.m_pValCtx, value2.m_opoIDSCtx.m_pValCtx) >= 0)
			{
				return true;
			}
			return false;
		}
	}

	public unsafe static bool LessThan(OracleIntervalDS value1, OracleIntervalDS value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::LessThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::LessThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::LessThan()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::LessThan()\n");
			}
			return false;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::LessThan()\n");
			}
			if (ITLMethods.Compare(value1.m_opoIDSCtx.m_pValCtx, value2.m_opoIDSCtx.m_pValCtx) < 0)
			{
				return true;
			}
			return false;
		}
	}

	public unsafe static bool LessThanOrEqual(OracleIntervalDS value1, OracleIntervalDS value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::LessThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::LessThanOrEqual()\n");
			}
			return false;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::LessThanOrEqual()\n");
			}
			if (ITLMethods.Compare(value1.m_opoIDSCtx.m_pValCtx, value2.m_opoIDSCtx.m_pValCtx) <= 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool NotEquals(OracleIntervalDS value1, OracleIntervalDS value2)
	{
		return !Equals(value1, value2);
	}

	public static OracleIntervalDS Parse(string intervalStr)
	{
		return new OracleIntervalDS(intervalStr);
	}

	public unsafe static OracleIntervalDS SetPrecision(OracleIntervalDS value1, int dayPrecision, int fracSecPrecision)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::SetPrecision()\n");
		}
		if (!value1.m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		int num = 0;
		if (dayPrecision < 0 || dayPrecision > 9)
		{
			throw new ArgumentOutOfRangeException("dayPrecision");
		}
		if (fracSecPrecision < 0 || fracSecPrecision > 9)
		{
			throw new ArgumentOutOfRangeException("fracSecPrecision");
		}
		OpoITLValCtx* pValCtx = null;
		try
		{
			num = OpsIDS.AllocValCtxFromBytes(value1.BinData, out pValCtx, dayPrecision, fracSecPrecision);
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
					OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::SetPrecision()\n");
				}
				ITLMethods.FreeCtx(ref pValCtx);
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::SetPrecision()\n");
		}
		return new OracleIntervalDS(pValCtx, dayPrecision, fracSecPrecision);
	}

	public static bool operator ==(OracleIntervalDS value1, OracleIntervalDS value2)
	{
		return Equals(value1, value2);
	}

	public static bool operator >(OracleIntervalDS value1, OracleIntervalDS value2)
	{
		return GreaterThan(value1, value2);
	}

	public static bool operator >=(OracleIntervalDS value1, OracleIntervalDS value2)
	{
		return GreaterThanOrEqual(value1, value2);
	}

	public static bool operator <(OracleIntervalDS value1, OracleIntervalDS value2)
	{
		return LessThan(value1, value2);
	}

	public static bool operator <=(OracleIntervalDS value1, OracleIntervalDS value2)
	{
		return LessThanOrEqual(value1, value2);
	}

	public static bool operator !=(OracleIntervalDS value1, OracleIntervalDS value2)
	{
		return NotEquals(value1, value2);
	}

	public unsafe static OracleIntervalDS operator +(OracleIntervalDS value1, OracleIntervalDS value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::Operator +\n");
		}
		if (!value1.m_bNotNull || !value2.m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator +\n");
			}
			return Null;
		}
		int num = 0;
		OpoITLValCtx* intervalCtx = null;
		try
		{
			num = OpsITL.Add(value1.m_opoIDSCtx.m_pValCtx, value2.m_opoIDSCtx.m_pValCtx, out intervalCtx);
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
					OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator +()\n");
				}
				ITLMethods.FreeCtx(ref intervalCtx);
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator +()\n");
		}
		return new OracleIntervalDS(intervalCtx, 9, 9);
	}

	public unsafe static OracleIntervalDS operator -(OracleIntervalDS value1, OracleIntervalDS value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::Operator -\n");
		}
		if (!value1.m_bNotNull || !value2.m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator -\n");
			}
			return Null;
		}
		int num = 0;
		OpoITLValCtx* intervalCtx = null;
		try
		{
			num = OpsITL.Subtract(value1.m_opoIDSCtx.m_pValCtx, value2.m_opoIDSCtx.m_pValCtx, out intervalCtx);
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
					OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator -()\n");
				}
				ITLMethods.FreeCtx(ref intervalCtx);
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator -()\n");
		}
		return new OracleIntervalDS(intervalCtx, 9, 9);
	}

	public unsafe static OracleIntervalDS operator -(OracleIntervalDS value1)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::Operator Negate\n");
		}
		if (!value1.m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator Negate\n");
			}
			return Null;
		}
		int num = 0;
		OpoITLValCtx* pValCtx = null;
		try
		{
			num = OpsIDS.Negate(value1.m_opoIDSCtx.m_pValCtx, out pValCtx);
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
					OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator Negate\n");
				}
				ITLMethods.FreeCtx(ref pValCtx);
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator Negate\n");
		}
		return new OracleIntervalDS(pValCtx, 9, 9);
	}

	public unsafe static OracleIntervalDS operator *(OracleIntervalDS value1, int multiplier)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::Operator *\n");
		}
		if (!value1.m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator *\n");
			}
			return Null;
		}
		int num = 0;
		OpoITLValCtx* intervalCtx = null;
		try
		{
			num = OpsITL.Multiply(value1.m_opoIDSCtx.m_pValCtx, multiplier, out intervalCtx);
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
					OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator *\n");
				}
				ITLMethods.FreeCtx(ref intervalCtx);
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator *\n");
		}
		return new OracleIntervalDS(intervalCtx, 9, 9);
	}

	public unsafe static OracleIntervalDS operator /(OracleIntervalDS value1, int divisor)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::Operator /\n");
		}
		if (!value1.m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator /\n");
			}
			return Null;
		}
		if (divisor == 0)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator /\n");
			}
			throw new DivideByZeroException();
		}
		int num = 0;
		OpoITLValCtx* intervalCtx = null;
		try
		{
			num = OpsITL.Divide(value1.m_opoIDSCtx.m_pValCtx, divisor, out intervalCtx);
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
					OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator /\n");
				}
				ITLMethods.FreeCtx(ref intervalCtx);
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Operator /\n");
		}
		return new OracleIntervalDS(intervalCtx, 9, 9);
	}

	public static explicit operator OracleIntervalDS(string intervalStr)
	{
		return new OracleIntervalDS(intervalStr);
	}

	public unsafe static explicit operator TimeSpan(OracleIntervalDS value1)
	{
		if (value1.m_bNotNull)
		{
			decimal num = TimeSpanConv.ValCtxToTicks(value1.m_opoIDSCtx.m_pValCtx);
			if (num < -9223372036854775808m || num > 9223372036854775807m)
			{
				throw new OracleTypeException(ErrRes.TYP_GETDOTNETTYPE_FAIL);
			}
			return new TimeSpan((long)num);
		}
		throw new OracleNullValueException();
	}

	public static implicit operator OracleIntervalDS(TimeSpan value1)
	{
		return new OracleIntervalDS(value1);
	}

	internal unsafe IntPtr GetOCIInterval()
	{
		int num = 0;
		IntPtr pOCIInterval = IntPtr.Zero;
		OracleConnection internalConnection = OracleConnection.GetInternalConnection();
		num = OpsIDS.AllocOCIFromValCtx(internalConnection.m_opoConCtx.opsConCtx, internalConnection.m_opoConCtx.opsErrCtx, GetValCtx(), out pOCIInterval);
		if (num != 0)
		{
			throw new OracleException(num, string.Empty, string.Empty, string.Empty);
		}
		return pOCIInterval;
	}

	public unsafe int CompareTo(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::CompareTo()\n");
		}
		if (obj.GetType() != typeof(OracleIntervalDS))
		{
			throw new ArgumentException();
		}
		OracleIntervalDS oracleIntervalDS = (OracleIntervalDS)obj;
		switch (InternalTypes.CompareNull(!m_bNotNull, !oracleIntervalDS.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::CompareTo()\n");
			}
			return 0;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::CompareTo()\n");
			}
			return -1;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::CompareTo()\n");
			}
			return 1;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::CompareTo()\n");
			}
			return ITLMethods.Compare(m_opoIDSCtx.m_pValCtx, oracleIntervalDS.m_opoIDSCtx.m_pValCtx);
		}
	}

	public override bool Equals(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalDS::Equals(2)\n");
		}
		if (obj == null)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Equals()\n");
			}
			return false;
		}
		if (obj.GetType() != typeof(OracleIntervalDS))
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Equals()\n");
			}
			return false;
		}
		OracleIntervalDS value = (OracleIntervalDS)obj;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalDS::Equals()\n");
		}
		return Equals(this, value);
	}

	public override int GetHashCode()
	{
		if (m_bNotNull)
		{
			return m_opoIDSCtx.GetHashCode();
		}
		return 0;
	}

	public unsafe override string ToString()
	{
		if (m_bNotNull)
		{
			return ITLMethods.ToString(m_opoIDSCtx.m_pValCtx, m_dayPrec, m_fSecondPrec);
		}
		return "null";
	}

	internal OracleIntervalDS(OpoIDSCtx ctx)
	{
		m_opoIDSCtx = ctx;
		m_bNotNull = true;
		m_fSecondPrec = 9;
		m_dayPrec = 9;
	}

	internal unsafe OracleIntervalDS(OpoITLValCtx* ctx)
		: this(ctx, 9, 9)
	{
	}

	internal unsafe OracleIntervalDS(OpoITLValCtx* ctx, int dayPrec, int fSecondPrec)
	{
		m_opoIDSCtx = new OpoIDSCtx(ctx);
		m_bNotNull = true;
		m_fSecondPrec = fSecondPrec;
		m_dayPrec = dayPrec;
	}

	internal unsafe static OpoITLValCtx* AllocValCtxFromData(TimeSpan data)
	{
		int num = 0;
		OpoITLValCtx* ctx = null;
		try
		{
			num = OpsIDS.AllocValCtx(ref ctx);
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
		FillValCtxFromTimeSpan(ctx, data);
		return ctx;
	}

	internal unsafe static void FillValCtxFromTimeSpan(OpoITLValCtx* pValCtx, TimeSpan ts)
	{
		long num = ts.Ticks - ts.Days * 864000000000L - ts.Hours * 36000000000L - (long)ts.Minutes * 600000000L - (long)ts.Seconds * 10000000L;
		pValCtx->m_type = 10;
		pValCtx->m_ds.m_days = ts.Days;
		pValCtx->m_ds.m_hours = ts.Hours;
		pValCtx->m_ds.m_minutes = ts.Minutes;
		pValCtx->m_ds.m_seconds = ts.Seconds;
		pValCtx->m_ds.m_fSeconds = (int)(num * 100);
	}

	internal unsafe OpoITLValCtx* GetValCtx()
	{
		return m_opoIDSCtx.m_pValCtx;
	}

	internal unsafe IntPtr DupValCtx()
	{
		IntPtr pNewCtx = IntPtr.Zero;
		int num = 0;
		num = OpsIDS.DupValCtx(GetValCtx(), out pNewCtx);
		if (num != 0)
		{
			throw new OracleException(num, string.Empty, string.Empty, string.Empty);
		}
		return pNewCtx;
	}

	internal unsafe int GetIDSData(byte idsComponent)
	{
		int result = 0;
		switch (idsComponent)
		{
		case 2:
			result = m_opoIDSCtx.m_pValCtx->m_ds.m_days;
			break;
		case 3:
			result = m_opoIDSCtx.m_pValCtx->m_ds.m_hours;
			break;
		case 4:
			result = m_opoIDSCtx.m_pValCtx->m_ds.m_minutes;
			break;
		case 5:
			result = m_opoIDSCtx.m_pValCtx->m_ds.m_seconds;
			break;
		case 7:
			result = m_opoIDSCtx.m_pValCtx->m_ds.m_fSeconds;
			break;
		}
		return result;
	}
}
