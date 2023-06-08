using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

[Serializable]
[XmlSchemaProvider("GetXsdType")]
public struct OracleIntervalYM : IComparable, INullable, IXmlSerializable
{
	internal const short MaxArrSize = 5;

	internal const byte IYMType = 7;

	internal const byte YEAR = 0;

	internal const byte MONTH = 1;

	public static readonly OracleIntervalYM MaxValue;

	public static readonly OracleIntervalYM MinValue;

	public static readonly OracleIntervalYM Zero;

	public static readonly OracleIntervalYM Null;

	private OpoIYMCtx m_opoIYMCtx;

	private bool m_bNotNull;

	private int m_yearPrec;

	public unsafe byte[] BinData
	{
		get
		{
			int num = 0;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::BinData: get\n");
			}
			if (m_bNotNull)
			{
				byte[] array = new byte[5];
				try
				{
					num = OpsIYM.ToBytes(m_opoIYMCtx.m_pValCtx, array);
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
					OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::BinData: get\n");
				}
				return array;
			}
			throw new OracleNullValueException();
		}
	}

	public bool IsNull => !m_bNotNull;

	public unsafe long Value
	{
		get
		{
			if (m_bNotNull)
			{
				return LongConv.GetLong(m_opoIYMCtx.m_pValCtx, OracleDbType.IntervalYM);
			}
			OracleNullValueException ex = new OracleNullValueException();
			throw ex;
		}
	}

	public int Years
	{
		get
		{
			if (m_bNotNull)
			{
				return GetIYMData(0);
			}
			throw new OracleNullValueException();
		}
	}

	public int Months
	{
		get
		{
			if (m_bNotNull)
			{
				return GetIYMData(1);
			}
			throw new OracleNullValueException();
		}
	}

	public unsafe double TotalYears
	{
		get
		{
			int num = 0;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::TotalYears: get\n");
			}
			if (m_bNotNull)
			{
				double result = 0.0;
				try
				{
					num = OpsIYM.ToYears(m_opoIYMCtx.m_pValCtx, &result);
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
					OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::TotalYears: get\n");
				}
				return result;
			}
			throw new OracleNullValueException();
		}
	}

	static OracleIntervalYM()
	{
		MaxValue = new OracleIntervalYM(999999999, 11);
		MinValue = new OracleIntervalYM(-999999999, -11);
		Zero = new OracleIntervalYM(0, 0);
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
			m_opoIYMCtx = new OpoIYMCtx(attribute);
			if (m_opoIYMCtx.m_error != 0)
			{
				throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoIYMCtx.m_error));
			}
			m_yearPrec = 9;
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
			writer.WriteString(ITLMethods.ToString(m_opoIYMCtx.m_pValCtx, m_yearPrec, 0));
		}
		else
		{
			writer.WriteAttributeString("xsi", "null", "http://www.w3.org/2001/XMLSchema-instance", "true");
		}
	}

	public OracleIntervalYM(int years, int months)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::OracleIntervalYM(1)\n");
		}
		if (Interval.IsValidYM(years, months))
		{
			m_opoIYMCtx = new OpoIYMCtx(years, months);
			if (m_opoIYMCtx.m_error != 0)
			{
				throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoIYMCtx.m_error));
			}
			m_bNotNull = true;
			m_yearPrec = 9;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::OracleIntervalYM(1)\n");
			}
			return;
		}
		throw new ArgumentOutOfRangeException();
	}

	public OracleIntervalYM(long totalMonths)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::OracleIntervalYM(2)\n");
		}
		if (Interval.IsValidYMMonths(totalMonths))
		{
			int years = (int)(totalMonths / 12);
			int months = (int)(totalMonths % 12);
			m_opoIYMCtx = new OpoIYMCtx(years, months);
			m_bNotNull = true;
			m_yearPrec = 9;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::OracleIntervalYM(2)\n");
			}
			return;
		}
		throw new ArgumentOutOfRangeException();
	}

	public OracleIntervalYM(double totalYears)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::OracleIntervalYM(3)\n");
		}
		if (Interval.IsValidYMYears(totalYears))
		{
			m_opoIYMCtx = new OpoIYMCtx(totalYears);
			if (m_opoIYMCtx.m_error != 0)
			{
				throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoIYMCtx.m_error));
			}
			m_bNotNull = true;
			m_yearPrec = 9;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::OracleIntervalYM(3)\n");
			}
			return;
		}
		throw new ArgumentOutOfRangeException();
	}

	public OracleIntervalYM(string intervalStr)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::OracleIntervalYM(4)\n");
		}
		if (intervalStr == null)
		{
			throw new ArgumentNullException();
		}
		m_opoIYMCtx = new OpoIYMCtx(intervalStr);
		if (m_opoIYMCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoIYMCtx.m_error));
		}
		m_bNotNull = true;
		m_yearPrec = 9;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::OracleIntervalYM(4)\n");
		}
	}

	public OracleIntervalYM(byte[] binData)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::OracleIntervalYM(5)\n");
		}
		if (binData == null)
		{
			throw new ArgumentNullException();
		}
		m_opoIYMCtx = new OpoIYMCtx(binData);
		if (m_opoIYMCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoIYMCtx.m_error));
		}
		m_bNotNull = true;
		m_yearPrec = 9;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::OracleIntervalYM()\n");
		}
	}

	internal unsafe OracleIntervalYM(IntPtr ociInterval)
	{
		int num = 0;
		OracleConnection internalConnection = OracleConnection.GetInternalConnection();
		OpoITLValCtx* pCtx = null;
		num = OpsIYM.AllocValCtxFromOCI(internalConnection.m_opoConCtx.opsConCtx, internalConnection.m_opoConCtx.opsErrCtx, ociInterval, out pCtx);
		if (num != 0)
		{
			throw new OracleException(num, string.Empty, string.Empty, string.Empty);
		}
		m_opoIYMCtx = new OpoIYMCtx(pCtx);
		m_bNotNull = true;
		m_yearPrec = 9;
	}

	public unsafe static bool Equals(OracleIntervalYM value1, OracleIntervalYM value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::Equals(1)\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Equals(1)\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Equals(1)\n");
			}
			return false;
		case CompareNullEnum.BothNotNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Equals(1)\n");
			}
			if (ITLMethods.Compare(value1.m_opoIYMCtx.m_pValCtx, value2.m_opoIYMCtx.m_pValCtx) == 0)
			{
				return true;
			}
			return false;
		}
	}

	public unsafe static bool GreaterThan(OracleIntervalYM value1, OracleIntervalYM value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::GreaterThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::GreaterThan()\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::GreaterThan()\n");
			}
			if (ITLMethods.Compare(value1.m_opoIYMCtx.m_pValCtx, value2.m_opoIYMCtx.m_pValCtx) > 0)
			{
				return true;
			}
			return false;
		}
	}

	public unsafe static bool GreaterThanOrEqual(OracleIntervalYM value1, OracleIntervalYM value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::GreaterThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::GreaterThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::GreaterThanOrEqual()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::GreaterThanOrEqual()\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::GreaterThanOrEqual()\n");
			}
			if (ITLMethods.Compare(value1.m_opoIYMCtx.m_pValCtx, value2.m_opoIYMCtx.m_pValCtx) >= 0)
			{
				return true;
			}
			return false;
		}
	}

	public unsafe static bool LessThan(OracleIntervalYM value1, OracleIntervalYM value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::LessThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::LessThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::LessThan()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::LessThan()\n");
			}
			return false;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::LessThan()\n");
			}
			if (ITLMethods.Compare(value1.m_opoIYMCtx.m_pValCtx, value2.m_opoIYMCtx.m_pValCtx) < 0)
			{
				return true;
			}
			return false;
		}
	}

	public unsafe static bool LessThanOrEqual(OracleIntervalYM value1, OracleIntervalYM value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::LessThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::LessThanOrEqual()\n");
			}
			return false;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::LessThanOrEqual()\n");
			}
			if (ITLMethods.Compare(value1.m_opoIYMCtx.m_pValCtx, value2.m_opoIYMCtx.m_pValCtx) <= 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool NotEquals(OracleIntervalYM value1, OracleIntervalYM value2)
	{
		return !Equals(value1, value2);
	}

	public static OracleIntervalYM Parse(string intervalStr)
	{
		return new OracleIntervalYM(intervalStr);
	}

	public unsafe static OracleIntervalYM SetPrecision(OracleIntervalYM value1, int yearPrecision)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::SetPrecision()\n");
		}
		if (!value1.m_bNotNull)
		{
			throw new OracleNullValueException();
		}
		int num = 0;
		if (yearPrecision < 0 || yearPrecision > 9)
		{
			throw new ArgumentOutOfRangeException("yearPrecision");
		}
		OpoITLValCtx* pValCtx = null;
		try
		{
			num = OpsIYM.AllocValCtxFromBytes(value1.BinData, out pValCtx, yearPrecision);
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
					OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::SetPrecision()\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::SetPrecision()\n");
		}
		return new OracleIntervalYM(pValCtx, yearPrecision);
	}

	public static bool operator ==(OracleIntervalYM value1, OracleIntervalYM value2)
	{
		return Equals(value1, value2);
	}

	public static bool operator >(OracleIntervalYM value1, OracleIntervalYM value2)
	{
		return GreaterThan(value1, value2);
	}

	public static bool operator >=(OracleIntervalYM value1, OracleIntervalYM value2)
	{
		return GreaterThanOrEqual(value1, value2);
	}

	public static bool operator <(OracleIntervalYM value1, OracleIntervalYM value2)
	{
		return LessThan(value1, value2);
	}

	public static bool operator <=(OracleIntervalYM value1, OracleIntervalYM value2)
	{
		return LessThanOrEqual(value1, value2);
	}

	public static bool operator !=(OracleIntervalYM value1, OracleIntervalYM value2)
	{
		return NotEquals(value1, value2);
	}

	public unsafe static OracleIntervalYM operator +(OracleIntervalYM value1, OracleIntervalYM value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::Operator +\n");
		}
		if (!value1.m_bNotNull || !value2.m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator +\n");
			}
			return Null;
		}
		int num = 0;
		OpoITLValCtx* intervalCtx = null;
		try
		{
			num = OpsITL.Add(value1.m_opoIYMCtx.m_pValCtx, value2.m_opoIYMCtx.m_pValCtx, out intervalCtx);
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
					OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator +\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator +\n");
		}
		return new OracleIntervalYM(intervalCtx, 9);
	}

	public unsafe static OracleIntervalYM operator -(OracleIntervalYM value1, OracleIntervalYM value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::Operator -\n");
		}
		if (!value1.m_bNotNull || !value2.m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator -\n");
			}
			return Null;
		}
		int num = 0;
		OpoITLValCtx* intervalCtx = null;
		try
		{
			num = OpsITL.Subtract(value1.m_opoIYMCtx.m_pValCtx, value2.m_opoIYMCtx.m_pValCtx, out intervalCtx);
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
					OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator -\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator -\n");
		}
		return new OracleIntervalYM(intervalCtx, 9);
	}

	public unsafe static OracleIntervalYM operator -(OracleIntervalYM value1)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::Operator Negate\n");
		}
		if (!value1.m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator Negate\n");
			}
			return Null;
		}
		int num = 0;
		OpoITLValCtx* pValCtx = null;
		try
		{
			num = OpsIYM.Negate(value1.m_opoIYMCtx.m_pValCtx, out pValCtx);
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
					OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator Negate\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator Negate\n");
		}
		return new OracleIntervalYM(pValCtx, 9);
	}

	public unsafe static OracleIntervalYM operator *(OracleIntervalYM value1, int multiplier)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::Operator *\n");
		}
		if (!value1.m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator *\n");
			}
			return Null;
		}
		int num = 0;
		OpoITLValCtx* intervalCtx = null;
		try
		{
			num = OpsITL.Multiply(value1.m_opoIYMCtx.m_pValCtx, multiplier, out intervalCtx);
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
					OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator *\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator *\n");
		}
		return new OracleIntervalYM(intervalCtx, 9);
	}

	public unsafe static OracleIntervalYM operator /(OracleIntervalYM value1, int divisor)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::Operator /\n");
		}
		if (!value1.m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator /\n");
			}
			return Null;
		}
		if (divisor == 0)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator /\n");
			}
			throw new DivideByZeroException();
		}
		int num = 0;
		OpoITLValCtx* intervalCtx = null;
		try
		{
			num = OpsITL.Divide(value1.m_opoIYMCtx.m_pValCtx, divisor, out intervalCtx);
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
					OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator /\n");
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
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Operator /\n");
		}
		return new OracleIntervalYM(intervalCtx, 9);
	}

	public static explicit operator OracleIntervalYM(string intervalStr)
	{
		return new OracleIntervalYM(intervalStr);
	}

	public unsafe static explicit operator long(OracleIntervalYM value1)
	{
		if (value1.m_bNotNull)
		{
			OpoITLValCtx* pValCtx = value1.m_opoIYMCtx.m_pValCtx;
			return (long)pValCtx->m_ym.m_years * 12L + pValCtx->m_ym.m_months;
		}
		throw new OracleNullValueException();
	}

	public static implicit operator OracleIntervalYM(long months)
	{
		return new OracleIntervalYM(months);
	}

	internal unsafe IntPtr GetOCIInterval()
	{
		int num = 0;
		IntPtr pOCIInterval = IntPtr.Zero;
		OracleConnection internalConnection = OracleConnection.GetInternalConnection();
		num = OpsIYM.AllocOCIFromValCtx(internalConnection.m_opoConCtx.opsConCtx, internalConnection.m_opoConCtx.opsErrCtx, GetValCtx(), out pOCIInterval);
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
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::CompareTo()\n");
		}
		if (obj.GetType() != typeof(OracleIntervalYM))
		{
			throw new ArgumentException();
		}
		OracleIntervalYM oracleIntervalYM = (OracleIntervalYM)obj;
		switch (InternalTypes.CompareNull(!m_bNotNull, !oracleIntervalYM.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::CompareTo()\n");
			}
			return 0;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::CompareTo()\n");
			}
			return -1;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::CompareTo()\n");
			}
			return 1;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::CompareTo()\n");
			}
			return ITLMethods.Compare(m_opoIYMCtx.m_pValCtx, oracleIntervalYM.m_opoIYMCtx.m_pValCtx);
		}
	}

	public override bool Equals(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleIntervalYM::Equals(2)\n");
		}
		if (obj == null)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Equals(2)\n");
			}
			return false;
		}
		if (obj.GetType() != typeof(OracleIntervalYM))
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Equals(2)\n");
			}
			return false;
		}
		OracleIntervalYM value = (OracleIntervalYM)obj;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleIntervalYM::Equals(2)\n");
		}
		return Equals(this, value);
	}

	public override int GetHashCode()
	{
		if (m_bNotNull)
		{
			return m_opoIYMCtx.GetHashCode();
		}
		return 0;
	}

	public unsafe override string ToString()
	{
		if (m_bNotNull)
		{
			return ITLMethods.ToString(m_opoIYMCtx.m_pValCtx, m_yearPrec, 0);
		}
		return "null";
	}

	internal OracleIntervalYM(OpoIYMCtx ctx)
	{
		m_opoIYMCtx = ctx;
		m_bNotNull = true;
		m_yearPrec = 9;
	}

	internal unsafe OracleIntervalYM(OpoITLValCtx* ctx)
		: this(ctx, 9)
	{
	}

	internal unsafe OracleIntervalYM(OpoITLValCtx* ctx, int yearPrec)
	{
		m_opoIYMCtx = new OpoIYMCtx(ctx);
		m_bNotNull = true;
		m_yearPrec = yearPrec;
	}

	internal unsafe static OpoITLValCtx* AllocValCtxFromData(long ymMonths)
	{
		int num = 0;
		if (!Interval.IsValidYMMonths(ymMonths))
		{
			throw new ArgumentException();
		}
		OpoITLValCtx* ctx = null;
		try
		{
			num = OpsIYM.AllocValCtx(ref ctx);
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
				ITLMethods.FreeCtx(ref ctx);
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		ctx->m_type = 7;
		ctx->m_ym.m_years = (int)(ymMonths / 12);
		ctx->m_ym.m_months = (int)(ymMonths % 12);
		return ctx;
	}

	internal unsafe OpoITLValCtx* GetValCtx()
	{
		return m_opoIYMCtx.m_pValCtx;
	}

	internal unsafe IntPtr DupValCtx()
	{
		IntPtr pNewCtx = IntPtr.Zero;
		int num = 0;
		num = OpsIYM.DupValCtx(GetValCtx(), out pNewCtx);
		if (num != 0)
		{
			throw new OracleException(num, string.Empty, string.Empty, string.Empty);
		}
		return pNewCtx;
	}

	internal unsafe int GetIYMData(byte iymComponent)
	{
		int result = 0;
		switch (iymComponent)
		{
		case 0:
			result = m_opoIYMCtx.m_pValCtx->m_ym.m_years;
			break;
		case 1:
			result = m_opoIYMCtx.m_pValCtx->m_ym.m_months;
			break;
		}
		return result;
	}
}
