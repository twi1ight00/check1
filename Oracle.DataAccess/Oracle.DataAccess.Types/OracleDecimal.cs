using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

[XmlSchemaProvider("GetXsdType")]
public struct OracleDecimal : IComparable, INullable, IXmlSerializable
{
	internal const int NUMSIZE = 22;

	internal const int LNXSUCC = 0;

	internal const int LNXIBIG = 1;

	internal const int LNXISMALL = 2;

	internal const int LNXIINVALIDNUM = 3;

	internal const int LNXFAIL = -1;

	internal const byte MinPrecision = 1;

	public static readonly byte MaxPrecision;

	public static readonly byte MaxScale;

	public static readonly OracleDecimal MaxValue;

	public static readonly int MinScale;

	public static readonly OracleDecimal MinValue;

	public static readonly OracleDecimal NegativeOne;

	public static readonly OracleDecimal Null;

	public static readonly OracleDecimal One;

	private static readonly decimal Pivalue;

	public static readonly OracleDecimal Pi;

	public static readonly OracleDecimal Zero;

	internal static readonly OracleDecimal PositiveInfinity;

	internal static readonly OracleDecimal NegativeInfinity;

	internal OpoDecCtx m_opoDecCtx;

	private bool m_bPositive;

	private int m_numberType;

	private bool m_bZero;

	private string m_format;

	private bool m_bNotNull;

	private bool m_bGetInfo;

	public byte[] BinData
	{
		get
		{
			byte[] array = new byte[22];
			Marshal.Copy(m_opoDecCtx.m_pValCtx, array, 0, 22);
			return array;
		}
	}

	public bool IsNull => !m_bNotNull;

	public bool IsInt
	{
		get
		{
			if (m_bNotNull)
			{
				if (!m_bGetInfo)
				{
					int isPositive = 0;
					int isZero = 0;
					m_opoDecCtx.m_error = 0;
					try
					{
						m_opoDecCtx.m_error = OpsDec.GetInfo(m_opoDecCtx.m_pValCtx, out m_numberType, out isPositive, out isZero, 0);
					}
					catch (Exception ex)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex);
						}
						throw;
					}
					if (m_opoDecCtx.m_error != 0)
					{
						throw new OracleTypeException(m_opoDecCtx.m_error);
					}
					if (isPositive == 1)
					{
						m_bPositive = true;
					}
					else
					{
						m_bPositive = false;
					}
					if (isZero == 1)
					{
						m_bZero = true;
					}
					else
					{
						m_bZero = false;
					}
					m_bGetInfo = true;
				}
				if (m_numberType == 1)
				{
					return true;
				}
				return false;
			}
			throw new OracleNullValueException();
		}
	}

	public bool IsPositive
	{
		get
		{
			if (m_bNotNull)
			{
				if (!m_bGetInfo)
				{
					int isPositive = 0;
					int isZero = 0;
					m_opoDecCtx.m_error = 0;
					try
					{
						m_opoDecCtx.m_error = OpsDec.GetInfo(m_opoDecCtx.m_pValCtx, out m_numberType, out isPositive, out isZero, 0);
					}
					catch (Exception ex)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex);
						}
						throw;
					}
					if (m_opoDecCtx.m_error != 0)
					{
						throw new OracleTypeException(m_opoDecCtx.m_error);
					}
					if (isPositive == 1)
					{
						m_bPositive = true;
					}
					else
					{
						m_bPositive = false;
					}
					if (isZero == 1)
					{
						m_bZero = true;
					}
					else
					{
						m_bZero = false;
					}
					m_bGetInfo = true;
				}
				return m_bPositive;
			}
			throw new OracleNullValueException();
		}
	}

	public bool IsZero
	{
		get
		{
			if (m_bNotNull)
			{
				if (!m_bGetInfo)
				{
					int isPositive = 0;
					int isZero = 0;
					m_opoDecCtx.m_error = 0;
					try
					{
						m_opoDecCtx.m_error = OpsDec.GetInfo(m_opoDecCtx.m_pValCtx, out m_numberType, out isPositive, out isZero, 0);
					}
					catch (Exception ex)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex);
						}
						throw;
					}
					if (m_opoDecCtx.m_error != 0)
					{
						throw new OracleTypeException(m_opoDecCtx.m_error);
					}
					if (isPositive == 1)
					{
						m_bPositive = true;
					}
					else
					{
						m_bPositive = false;
					}
					if (isZero == 1)
					{
						m_bZero = true;
					}
					else
					{
						m_bZero = false;
					}
					m_bGetInfo = true;
				}
				return m_bZero;
			}
			throw new OracleNullValueException();
		}
	}

	internal bool IsInfinity
	{
		get
		{
			if (m_bNotNull)
			{
				if (!m_bGetInfo)
				{
					int isPositive = 0;
					int isZero = 0;
					m_opoDecCtx.m_error = 0;
					try
					{
						m_opoDecCtx.m_error = OpsDec.GetInfo(m_opoDecCtx.m_pValCtx, out m_numberType, out isPositive, out isZero, 0);
					}
					catch (Exception ex)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex);
						}
						throw;
					}
					if (m_opoDecCtx.m_error != 0)
					{
						throw new OracleTypeException(m_opoDecCtx.m_error);
					}
					if (isPositive == 1)
					{
						m_bPositive = true;
					}
					else
					{
						m_bPositive = false;
					}
					if (isZero == 1)
					{
						m_bZero = true;
					}
					else
					{
						m_bZero = false;
					}
					m_bGetInfo = true;
				}
				if (m_numberType == 3 || m_numberType == 4)
				{
					return true;
				}
				return false;
			}
			throw new OracleNullValueException();
		}
	}

	internal bool IsPositiveInfinity
	{
		get
		{
			if (m_bNotNull)
			{
				if (!m_bGetInfo)
				{
					int isPositive = 0;
					int isZero = 0;
					m_opoDecCtx.m_error = 0;
					try
					{
						m_opoDecCtx.m_error = OpsDec.GetInfo(m_opoDecCtx.m_pValCtx, out m_numberType, out isPositive, out isZero, 0);
					}
					catch (Exception ex)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex);
						}
						throw;
					}
					if (m_opoDecCtx.m_error != 0)
					{
						throw new OracleTypeException(m_opoDecCtx.m_error);
					}
					if (isPositive == 1)
					{
						m_bPositive = true;
					}
					else
					{
						m_bPositive = false;
					}
					if (isZero == 1)
					{
						m_bZero = true;
					}
					else
					{
						m_bZero = false;
					}
					m_bGetInfo = true;
				}
				if (m_numberType == 3)
				{
					return true;
				}
				return false;
			}
			throw new OracleNullValueException();
		}
	}

	internal bool IsNegativeInfinity
	{
		get
		{
			if (m_bNotNull)
			{
				if (!m_bGetInfo)
				{
					int isPositive = 0;
					int isZero = 0;
					m_opoDecCtx.m_error = 0;
					try
					{
						m_opoDecCtx.m_error = OpsDec.GetInfo(m_opoDecCtx.m_pValCtx, out m_numberType, out isPositive, out isZero, 0);
					}
					catch (Exception ex)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex);
						}
						throw;
					}
					if (m_opoDecCtx.m_error != 0)
					{
						throw new OracleTypeException(m_opoDecCtx.m_error);
					}
					if (isPositive == 1)
					{
						m_bPositive = true;
					}
					else
					{
						m_bPositive = false;
					}
					if (isZero == 1)
					{
						m_bZero = true;
					}
					else
					{
						m_bZero = false;
					}
					m_bGetInfo = true;
				}
				if (m_numberType == 4)
				{
					return true;
				}
				return false;
			}
			throw new OracleNullValueException();
		}
	}

	public string Format
	{
		get
		{
			if (m_bNotNull)
			{
				return m_format;
			}
			throw new OracleNullValueException();
		}
		set
		{
			if (m_bNotNull)
			{
				m_format = value;
				return;
			}
			throw new OracleNullValueException();
		}
	}

	public decimal Value
	{
		get
		{
			if (this == Pi)
			{
				return Pivalue;
			}
			if (m_bNotNull)
			{
				return DecimalConv.GetDecimal(m_opoDecCtx.m_pValCtx);
			}
			throw new OracleNullValueException();
		}
	}

	static OracleDecimal()
	{
		MaxPrecision = 38;
		MaxScale = 127;
		MaxValue = GetMaxValue();
		MinScale = -84;
		MinValue = GetMinValue();
		NegativeOne = new OracleDecimal(-1);
		One = new OracleDecimal(1);
		Pivalue = 3.1415926535897932384626433832m;
		Pi = SetPi();
		Zero = new OracleDecimal(0);
		PositiveInfinity = GetPosInfinity();
		NegativeInfinity = GetNegInfinity();
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet)
	{
		return new XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema");
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
			m_format = null;
			m_opoDecCtx = new OpoDecCtx(attribute, m_format, out m_numberType, out m_bPositive, out m_bZero);
			m_bGetInfo = true;
			if (m_opoDecCtx.m_error != 0)
			{
				if (m_opoDecCtx.m_error == 22053)
				{
					throw new OverflowException(OracleTypeException.GetTypeMsg(m_opoDecCtx.m_error));
				}
				throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoDecCtx.m_error, "numStr"));
			}
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
			int num = 0;
			string numStr;
			try
			{
				num = OpsDec.ToString(m_opoDecCtx.m_pValCtx, m_format, out numStr);
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
			numStr = numStr.TrimEnd(null);
			numStr = numStr.TrimStart(null);
			int length = numStr.Length;
			string text = new string('#', length);
			if (text.Equals(numStr))
			{
				throw new OracleTypeException(22065);
			}
			writer.WriteString(numStr);
		}
		else
		{
			writer.WriteAttributeString("xsi", "null", "http://www.w3.org/2001/XMLSchema-instance", "true");
		}
	}

	internal OracleDecimal(IntPtr numCtx)
		: this(numCtx, getInfo: true)
	{
	}

	public OracleDecimal(byte[] bytes)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::OracleDecimal(1)\n");
		}
		if (bytes == null)
		{
			throw new ArgumentNullException();
		}
		if (bytes.Length != 22)
		{
			throw new ArgumentException();
		}
		IntPtr intPtr = Marshal.AllocCoTaskMem(22);
		Marshal.Copy(bytes, 0, intPtr, 22);
		m_opoDecCtx = new OpoDecCtx(intPtr, out m_numberType, out m_bPositive, out m_bZero);
		m_bGetInfo = true;
		if (m_opoDecCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoDecCtx.m_error, "bytes"));
		}
		m_bNotNull = true;
		m_format = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::OracleDecimal(1)\n");
		}
	}

	public OracleDecimal(int intX)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::OracleDecimal(2)\n");
		}
		m_opoDecCtx = new OpoDecCtx(intX, out m_numberType, out m_bPositive, out m_bZero);
		m_bGetInfo = true;
		if (m_opoDecCtx.m_error != 0)
		{
			if (m_opoDecCtx.m_error == 22053)
			{
				throw new OverflowException(OracleTypeException.GetTypeMsg(m_opoDecCtx.m_error));
			}
			throw new OracleTypeException(m_opoDecCtx.m_error, "intX");
		}
		m_bNotNull = true;
		m_format = null;
		m_numberType = 1;
		if (intX > 0)
		{
			m_bPositive = true;
		}
		else
		{
			m_bPositive = false;
		}
		if (intX == 0)
		{
			m_bZero = true;
		}
		else
		{
			m_bZero = false;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::OracleDecimal(2)\n");
		}
	}

	public OracleDecimal(long longX)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::OracleDecimal(3)\n");
		}
		m_opoDecCtx = new OpoDecCtx(longX, out m_numberType, out m_bPositive, out m_bZero);
		m_bGetInfo = true;
		if (m_opoDecCtx.m_error != 0)
		{
			if (m_opoDecCtx.m_error == 22053)
			{
				throw new OverflowException(OracleTypeException.GetTypeMsg(m_opoDecCtx.m_error));
			}
			throw new OracleTypeException(m_opoDecCtx.m_error, "longX");
		}
		m_bNotNull = true;
		m_format = null;
		m_numberType = 1;
		if (longX > 0)
		{
			m_bPositive = true;
		}
		else
		{
			m_bPositive = false;
		}
		if (longX == 0)
		{
			m_bZero = true;
		}
		else
		{
			m_bZero = false;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::OracleDecimal(3)\n");
		}
	}

	public OracleDecimal(float floatX)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::OracleDecimal(4)\n");
		}
		if (float.IsNaN(floatX))
		{
			m_opoDecCtx = null;
			m_bGetInfo = true;
			m_bNotNull = false;
			m_numberType = 0;
			m_bPositive = false;
			m_bZero = false;
			m_format = null;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::OracleDecimal(4)\n");
			}
			return;
		}
		if (float.IsPositiveInfinity(floatX))
		{
			IntPtr pNumCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForPosInf(out pNumCtx);
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
					OpoDecCtx.FreeCtx(ref pNumCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			m_opoDecCtx = new OpoDecCtx(pNumCtx);
			m_bGetInfo = true;
			m_bNotNull = true;
			m_numberType = 3;
			m_bPositive = true;
			m_bZero = false;
			m_format = null;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::OracleDecimal(4)\n");
			}
			return;
		}
		if (float.IsNegativeInfinity(floatX))
		{
			IntPtr pNumCtx2 = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForNegInf(out pNumCtx2);
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
				if (num != 0)
				{
					OpoDecCtx.FreeCtx(ref pNumCtx2);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			m_opoDecCtx = new OpoDecCtx(pNumCtx2);
			m_bGetInfo = true;
			m_bNotNull = true;
			m_numberType = 4;
			m_bPositive = false;
			m_bZero = false;
			m_format = null;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::OracleDecimal(4)\n");
			}
			return;
		}
		m_opoDecCtx = new OpoDecCtx(floatX, out m_numberType, out m_bPositive, out m_bZero);
		m_bGetInfo = true;
		if (m_opoDecCtx.m_error != 0)
		{
			if (m_opoDecCtx.m_error == 22053)
			{
				throw new OverflowException(OracleTypeException.GetTypeMsg(m_opoDecCtx.m_error));
			}
			throw new OracleTypeException(m_opoDecCtx.m_error, "doubleX");
		}
		m_bNotNull = true;
		m_format = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::OracleDecimal(4)\n");
		}
	}

	public OracleDecimal(double doubleX)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::OracleDecimal(4)\n");
		}
		if (double.IsNaN(doubleX))
		{
			m_opoDecCtx = null;
			m_bGetInfo = true;
			m_bNotNull = false;
			m_numberType = 0;
			m_bPositive = false;
			m_bZero = false;
			m_format = null;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::OracleDecimal(4)\n");
			}
			return;
		}
		if (double.IsPositiveInfinity(doubleX))
		{
			IntPtr pNumCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForPosInf(out pNumCtx);
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
					OpoDecCtx.FreeCtx(ref pNumCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			m_opoDecCtx = new OpoDecCtx(pNumCtx);
			m_bGetInfo = true;
			m_bNotNull = true;
			m_numberType = 3;
			m_bPositive = true;
			m_bZero = false;
			m_format = null;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::OracleDecimal(4)\n");
			}
			return;
		}
		if (double.IsNegativeInfinity(doubleX))
		{
			IntPtr pNumCtx2 = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForNegInf(out pNumCtx2);
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
				if (num != 0)
				{
					OpoDecCtx.FreeCtx(ref pNumCtx2);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			m_opoDecCtx = new OpoDecCtx(pNumCtx2);
			m_bGetInfo = true;
			m_bNotNull = true;
			m_numberType = 4;
			m_bPositive = false;
			m_bZero = false;
			m_format = null;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::OracleDecimal(4)\n");
			}
			return;
		}
		m_opoDecCtx = new OpoDecCtx(doubleX, out m_numberType, out m_bPositive, out m_bZero);
		m_bGetInfo = true;
		if (m_opoDecCtx.m_error != 0)
		{
			if (m_opoDecCtx.m_error == 22053)
			{
				throw new OverflowException(OracleTypeException.GetTypeMsg(m_opoDecCtx.m_error));
			}
			throw new OracleTypeException(m_opoDecCtx.m_error, "doubleX");
		}
		m_bNotNull = true;
		m_format = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::OracleDecimal(4)\n");
		}
	}

	public OracleDecimal(decimal decimalX)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::OracleDecimal(5)\n");
		}
		m_opoDecCtx = new OpoDecCtx(decimalX, out m_numberType, out m_bPositive, out m_bZero);
		m_bGetInfo = true;
		if (m_opoDecCtx.m_error != 0)
		{
			if (m_opoDecCtx.m_error == 22053)
			{
				throw new OverflowException(OracleTypeException.GetTypeMsg(m_opoDecCtx.m_error));
			}
			throw new OracleTypeException(m_opoDecCtx.m_error, "decimalX");
		}
		m_bNotNull = true;
		m_format = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::OracleDecimal(5)\n");
		}
	}

	public OracleDecimal(string numStr)
		: this(numStr, null)
	{
	}

	public OracleDecimal(string numStr, string format)
	{
		if (numStr == null)
		{
			throw new ArgumentNullException("numStr");
		}
		m_format = format;
		m_opoDecCtx = new OpoDecCtx(numStr, m_format, out m_numberType, out m_bPositive, out m_bZero);
		m_bGetInfo = true;
		if (m_opoDecCtx.m_error != 0)
		{
			if (m_opoDecCtx.m_error == 22053)
			{
				throw new OverflowException(OracleTypeException.GetTypeMsg(m_opoDecCtx.m_error));
			}
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoDecCtx.m_error, numStr));
		}
		m_bNotNull = true;
	}

	public static bool Equals(OracleDecimal value1, OracleDecimal value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Equals(1)\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Equals(1)\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Equals(1)\n");
			}
			return false;
		case CompareNullEnum.BothNotNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Equals(1)\n");
			}
			if (Compare(value1.m_opoDecCtx, value2.m_opoDecCtx) == 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool GreaterThan(OracleDecimal value1, OracleDecimal value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::GreaterThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::GreaterThan()\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::GreaterThan()\n");
			}
			if (Compare(value1.m_opoDecCtx, value2.m_opoDecCtx) > 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool GreaterThanOrEqual(OracleDecimal value1, OracleDecimal value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::GreaterThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::GreaterThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::GreaterThanOrEqual()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::GreaterThanOrEqual()\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::GreaterThanOrEqual()\n");
			}
			if (Compare(value1.m_opoDecCtx, value2.m_opoDecCtx) >= 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool LessThan(OracleDecimal value1, OracleDecimal value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::LessThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::LessThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::LessThan()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::LessThan()\n");
			}
			return false;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::LessThan()\n");
			}
			if (Compare(value1.m_opoDecCtx, value2.m_opoDecCtx) < 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool LessThanOrEqual(OracleDecimal value1, OracleDecimal value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::LessThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::LessThanOrEqual()\n");
			}
			return false;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::LessThanOrEqual()\n");
			}
			if (Compare(value1.m_opoDecCtx, value2.m_opoDecCtx) <= 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool NotEquals(OracleDecimal value1, OracleDecimal value2)
	{
		return !Equals(value1, value2);
	}

	public static OracleDecimal Max(OracleDecimal value1, OracleDecimal value2)
	{
		if (GreaterThanOrEqual(value1, value2))
		{
			return value1;
		}
		return value2;
	}

	public static OracleDecimal Min(OracleDecimal value1, OracleDecimal value2)
	{
		if (LessThanOrEqual(value1, value2))
		{
			return value1;
		}
		return value2;
	}

	public static OracleDecimal Abs(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Abs()\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForAbs(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num, "value1");
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Abs()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Abs()\n");
		}
		return Null;
	}

	public static OracleDecimal Add(OracleDecimal value1, OracleDecimal value2)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Add()\n");
		}
		if (value1.m_bNotNull && value2.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForAdd(value1.m_opoDecCtx.m_pValCtx, value2.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Add()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Add()\n");
		}
		return Null;
	}

	public static OracleDecimal AdjustScale(OracleDecimal value1, int digits, bool fRound)
	{
		if (fRound)
		{
			return Round(value1, digits);
		}
		return Truncate(value1, digits);
	}

	public static OracleDecimal Ceiling(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Ceiling()\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForCeiling(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Ceiling()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Ceiling()\n");
		}
		return Null;
	}

	public static OracleDecimal ConvertToPrecScale(OracleDecimal value1, int precision, int scale)
	{
		int result = 0;
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::ConvertToPrecScale()\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			if (scale > MaxScale || scale < MinScale)
			{
				throw new OracleTypeException(1728);
			}
			if (precision > MaxPrecision || precision < 1)
			{
				throw new OracleTypeException(1727);
			}
			try
			{
				num = OpsDec.AllocValCtxForConvertToPrecScale(value1.m_opoDecCtx.m_pValCtx, precision, scale, out numCtx, ref result);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (result > 0)
			{
				OpoDecCtx.FreeCtx(ref numCtx);
				throw new OracleTruncateException();
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::ConvertToPrecScale()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::ConvertToPrecScale()\n");
		}
		return Null;
	}

	public static OracleDecimal Divide(OracleDecimal value1, OracleDecimal value2)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Divide()\n");
		}
		if (value1.m_bNotNull && value2.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForDivide(value1.m_opoDecCtx.m_pValCtx, value2.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Divide()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Divide()\n");
		}
		return Null;
	}

	public static OracleDecimal Floor(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Floor()\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForFloor(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Floor()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Floor()\n");
		}
		return Null;
	}

	public static OracleDecimal Mod(OracleDecimal value1, OracleDecimal value2)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Mod()\n");
		}
		if (value1.m_bNotNull && value2.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForModulus(value1.m_opoDecCtx.m_pValCtx, value2.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Mod()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Mod()\n");
		}
		return Null;
	}

	public static OracleDecimal Multiply(OracleDecimal value1, OracleDecimal value2)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Multiply()\n");
		}
		if (value1.m_bNotNull && value2.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForMultiply(value1.m_opoDecCtx.m_pValCtx, value2.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Multiply()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Multiply()\n");
		}
		return Null;
	}

	public static OracleDecimal Negate(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Negate()\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForNegate(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Negate()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Negate()\n");
		}
		return Null;
	}

	public static OracleDecimal Parse(string numStr)
	{
		return new OracleDecimal(numStr);
	}

	public static OracleDecimal SetPrecision(OracleDecimal value1, int precision)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::SetPrecision()\n");
		}
		if (value1.m_bNotNull)
		{
			if (precision > MaxPrecision || precision < 1)
			{
				throw new OracleTypeException(1727);
			}
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForSetPrecWRound(value1.m_opoDecCtx.m_pValCtx, precision, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::SetPrecision()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::SetPrecision()\n");
		}
		return Null;
	}

	internal static OracleDecimal SetPrecisionNoRound(OracleDecimal value1, int precision)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::SetPrecisionNoRound()\n");
		}
		if (value1.m_bNotNull)
		{
			if (precision > MaxPrecision || precision < 1)
			{
				throw new OracleTypeException(1727);
			}
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForSetPrecNoRound(value1.m_opoDecCtx.m_pValCtx, precision, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::SetPrecisionNoRound()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::SetPrecisionNoRound()\n");
		}
		return Null;
	}

	public static OracleDecimal Round(OracleDecimal value1, int decplace)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Round()\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForRound(value1.m_opoDecCtx.m_pValCtx, decplace, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Round()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Round()\n");
		}
		return Null;
	}

	public static OracleDecimal Shift(OracleDecimal value1, int decplace)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Shift()\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForShift(value1.m_opoDecCtx.m_pValCtx, decplace, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Shift()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Shift()\n");
		}
		return Null;
	}

	public static int Sign(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Sign()\n");
		}
		if (value1.m_bNotNull)
		{
			int result = 0;
			try
			{
				num = OpsDec.Sign(value1.m_opoDecCtx.m_pValCtx, ref result);
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
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Sign()\n");
			}
			return result;
		}
		throw new OracleNullValueException();
	}

	public static OracleDecimal Sqrt(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Sqrt()\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			if (!value1.m_bGetInfo)
			{
				int isPositive = 0;
				int isZero = 0;
				try
				{
					value1.m_opoDecCtx.m_error = OpsDec.GetInfo(value1.m_opoDecCtx.m_pValCtx, out value1.m_numberType, out isPositive, out isZero, 0);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					throw;
				}
				if (value1.m_opoDecCtx.m_error != 0)
				{
					throw new OracleTypeException(value1.m_opoDecCtx.m_error);
				}
				if (isPositive == 1)
				{
					value1.m_bPositive = true;
				}
				else
				{
					value1.m_bPositive = false;
				}
				if (isZero == 1)
				{
					value1.m_bZero = true;
				}
				else
				{
					value1.m_bZero = false;
				}
				value1.m_bGetInfo = true;
			}
			if (!value1.m_bPositive && !value1.m_bZero)
			{
				throw new ArgumentOutOfRangeException("value1");
			}
			try
			{
				num = OpsDec.AllocValCtxForSqrt(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
				if (num != 0)
				{
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Sqrt()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Sqrt()\n");
		}
		return Null;
	}

	public static OracleDecimal Subtract(OracleDecimal value1, OracleDecimal value2)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Subtract()\n");
		}
		if (value1.m_bNotNull && value2.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForSubtract(value1.m_opoDecCtx.m_pValCtx, value2.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Subtract()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Subtract()\n");
		}
		return Null;
	}

	public static OracleDecimal Truncate(OracleDecimal value1, int position)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Truncate()\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForTruncate(value1.m_opoDecCtx.m_pValCtx, position, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Truncate()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Truncate()\n");
		}
		return Null;
	}

	public static OracleDecimal Exp(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Exp()\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForExp(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Exp()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Exp()\n");
		}
		return Null;
	}

	public static OracleDecimal Pow(OracleDecimal value1, int power)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Pow(1)\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForIntPower(value1.m_opoDecCtx.m_pValCtx, power, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Pow(1)\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Pow(1)\n");
		}
		return Null;
	}

	public static OracleDecimal Log(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Log(1)\n");
		}
		if (value1.m_bNotNull)
		{
			if (!value1.IsPositive && !value1.IsZero)
			{
				throw new ArgumentOutOfRangeException();
			}
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForLn(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Log(1)\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Log(1)\n");
		}
		return Null;
	}

	public static OracleDecimal Log(OracleDecimal value1, int logBase)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Log(2)\n");
		}
		if (value1.m_bNotNull)
		{
			if ((!value1.IsPositive && !value1.IsZero) || logBase <= 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (value1.IsZero && logBase == 0)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Log(2)\n");
				}
				return Null;
			}
			if (value1.IsPositive && logBase == 0)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Log(2)\n");
				}
				return new OracleDecimal(0);
			}
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForIntLog(value1.m_opoDecCtx.m_pValCtx, logBase, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Log(2)\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Log(2)\n");
		}
		return Null;
	}

	public static OracleDecimal Log(OracleDecimal value1, OracleDecimal logBase)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Log(3)\n");
		}
		if (value1.m_bNotNull && logBase.m_bNotNull)
		{
			if ((!value1.IsPositive && !value1.IsZero) || (!logBase.IsPositive && !logBase.IsZero))
			{
				throw new ArgumentOutOfRangeException();
			}
			if (value1.IsZero && logBase.IsZero)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Log(3)\n");
				}
				return Null;
			}
			if (value1.IsPositive && logBase.IsZero)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Log(3)\n");
				}
				return new OracleDecimal(0);
			}
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForLog(value1.m_opoDecCtx.m_pValCtx, logBase.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Log(3)\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Log(3)\n");
		}
		return Null;
	}

	public static OracleDecimal Pow(OracleDecimal value1, OracleDecimal power)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Pow(2)\n");
		}
		if (value1.m_bNotNull && power.m_bNotNull)
		{
			if (value1.IsZero && !power.IsPositive && !power.IsZero)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Pow(2)\n");
				}
				return PositiveInfinity;
			}
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForPower(value1.m_opoDecCtx.m_pValCtx, power.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Pow(2)\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Pow(2)\n");
		}
		return Null;
	}

	public static OracleDecimal Acos(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Acos()\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForACos(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num, "value1");
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Acos()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Acos()\n");
		}
		return Null;
	}

	public static OracleDecimal Asin(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Asin()\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForASin(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num, "value1");
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Asin()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Asin()\n");
		}
		return Null;
	}

	public static OracleDecimal Atan(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Atan()\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForATan(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num, "value1");
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Atan()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Atan()\n");
		}
		return Null;
	}

	public static OracleDecimal Atan2(OracleDecimal value1, OracleDecimal value2)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Atan2()\n");
		}
		if (value1.m_bNotNull && value2.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForATan2(value1.m_opoDecCtx.m_pValCtx, value2.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num, "value1/value2");
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Atan2()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Atan2()\n");
		}
		return Null;
	}

	public static OracleDecimal Cos(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Cos()\n");
		}
		if (value1.m_bNotNull)
		{
			if (value1.IsInfinity)
			{
				throw new ArgumentOutOfRangeException("value1");
			}
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForCos(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Cos()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Cos()\n");
		}
		return Null;
	}

	public static OracleDecimal Sin(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Sin()\n");
		}
		if (value1.m_bNotNull)
		{
			if (value1.IsInfinity)
			{
				throw new ArgumentOutOfRangeException("value1");
			}
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForSin(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Sin()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Sin()\n");
		}
		return Null;
	}

	public static OracleDecimal Tan(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Tan()\n");
		}
		if (value1.m_bNotNull)
		{
			if (value1.IsInfinity)
			{
				throw new ArgumentOutOfRangeException("value1");
			}
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForTan(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Tan()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Tan()\n");
		}
		return Null;
	}

	public static OracleDecimal Cosh(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Cosh()\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForCosh(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Cosh()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Cosh()\n");
		}
		return Null;
	}

	public static OracleDecimal Sinh(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Sinh()\n");
		}
		if (value1.m_bNotNull)
		{
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForSinh(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Sinh()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Sinh()\n");
		}
		return Null;
	}

	public static OracleDecimal Tanh(OracleDecimal value1)
	{
		int num = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Tanh()\n");
		}
		if (value1.m_bNotNull)
		{
			if (value1.IsPositiveInfinity)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Tanh()\n");
				}
				return new OracleDecimal(1);
			}
			if (value1.IsNegativeInfinity)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Tanh()\n");
				}
				return new OracleDecimal(-1);
			}
			IntPtr numCtx = IntPtr.Zero;
			try
			{
				num = OpsDec.AllocValCtxForTanh(value1.m_opoDecCtx.m_pValCtx, out numCtx);
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
					OpoDecCtx.FreeCtx(ref numCtx);
					if (num != ErrRes.INT_ERR)
					{
						throw new OracleTypeException(num);
					}
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Tanh()\n");
			}
			return new OracleDecimal(numCtx, getInfo: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Tanh()\n");
		}
		return Null;
	}

	public static bool operator ==(OracleDecimal value1, OracleDecimal value2)
	{
		return Equals(value1, value2);
	}

	public static bool operator >(OracleDecimal value1, OracleDecimal value2)
	{
		return GreaterThan(value1, value2);
	}

	public static bool operator >=(OracleDecimal value1, OracleDecimal value2)
	{
		return GreaterThanOrEqual(value1, value2);
	}

	public static bool operator <(OracleDecimal value1, OracleDecimal value2)
	{
		return LessThan(value1, value2);
	}

	public static bool operator <=(OracleDecimal value1, OracleDecimal value2)
	{
		return LessThanOrEqual(value1, value2);
	}

	public static bool operator !=(OracleDecimal value1, OracleDecimal value2)
	{
		return NotEquals(value1, value2);
	}

	public static OracleDecimal operator +(OracleDecimal value1, OracleDecimal value2)
	{
		return Add(value1, value2);
	}

	public static OracleDecimal operator -(OracleDecimal value1, OracleDecimal value2)
	{
		return Subtract(value1, value2);
	}

	public static OracleDecimal operator -(OracleDecimal value1)
	{
		return Negate(value1);
	}

	public static OracleDecimal operator *(OracleDecimal value1, OracleDecimal value2)
	{
		return Multiply(value1, value2);
	}

	public static OracleDecimal operator /(OracleDecimal value1, OracleDecimal value2)
	{
		return Divide(value1, value2);
	}

	public static OracleDecimal operator %(OracleDecimal value1, OracleDecimal value2)
	{
		return Mod(value1, value2);
	}

	public static explicit operator OracleDecimal(string numStr)
	{
		return new OracleDecimal(numStr);
	}

	public static explicit operator byte(OracleDecimal value1)
	{
		if (value1.m_bNotNull)
		{
			return (byte)(object)DecimalConv.GetNum(value1.m_opoDecCtx.m_pValCtx, DbType.Byte);
		}
		throw new OracleNullValueException();
	}

	public static explicit operator short(OracleDecimal value1)
	{
		if (value1.m_bNotNull)
		{
			return (short)(object)DecimalConv.GetNum(value1.m_opoDecCtx.m_pValCtx, DbType.Int16);
		}
		throw new OracleNullValueException();
	}

	public static explicit operator int(OracleDecimal value1)
	{
		if (value1.m_bNotNull)
		{
			return (int)(object)DecimalConv.GetNum(value1.m_opoDecCtx.m_pValCtx, DbType.Int32);
		}
		throw new OracleNullValueException();
	}

	public static explicit operator long(OracleDecimal value1)
	{
		if (value1.m_bNotNull)
		{
			return (long)(object)DecimalConv.GetNum(value1.m_opoDecCtx.m_pValCtx, DbType.Int64);
		}
		throw new OracleNullValueException();
	}

	public static explicit operator float(OracleDecimal value1)
	{
		if (value1.m_bNotNull)
		{
			return (float)(object)DecimalConv.GetNum(value1.m_opoDecCtx.m_pValCtx, DbType.Single);
		}
		throw new OracleNullValueException();
	}

	public static explicit operator double(OracleDecimal value1)
	{
		if (value1.m_bNotNull)
		{
			return (double)(object)DecimalConv.GetNum(value1.m_opoDecCtx.m_pValCtx, DbType.Double);
		}
		throw new OracleNullValueException();
	}

	public static explicit operator decimal(OracleDecimal value1)
	{
		if (value1.m_bNotNull)
		{
			return DecimalConv.GetDecimal(value1.m_opoDecCtx.m_pValCtx);
		}
		throw new OracleNullValueException();
	}

	public static explicit operator OracleDecimal(double value1)
	{
		return new OracleDecimal(value1);
	}

	public static implicit operator OracleDecimal(int value1)
	{
		return new OracleDecimal(value1);
	}

	public static implicit operator OracleDecimal(long value1)
	{
		return new OracleDecimal(value1);
	}

	public static implicit operator OracleDecimal(decimal value1)
	{
		return new OracleDecimal(value1);
	}

	public byte ToByte()
	{
		if (m_bNotNull)
		{
			return (byte)(object)DecimalConv.GetNum(m_opoDecCtx.m_pValCtx, DbType.Byte);
		}
		throw new OracleNullValueException();
	}

	public short ToInt16()
	{
		if (m_bNotNull)
		{
			return (short)(object)DecimalConv.GetNum(m_opoDecCtx.m_pValCtx, DbType.Int16);
		}
		throw new OracleNullValueException();
	}

	public int ToInt32()
	{
		if (m_bNotNull)
		{
			return (int)(object)DecimalConv.GetNum(m_opoDecCtx.m_pValCtx, DbType.Int32);
		}
		throw new OracleNullValueException();
	}

	public long ToInt64()
	{
		if (m_bNotNull)
		{
			return (long)(object)DecimalConv.GetNum(m_opoDecCtx.m_pValCtx, DbType.Int64);
		}
		throw new OracleNullValueException();
	}

	public float ToSingle()
	{
		if (m_bNotNull)
		{
			return (float)(object)DecimalConv.GetNum(m_opoDecCtx.m_pValCtx, DbType.Single);
		}
		throw new OracleNullValueException();
	}

	public double ToDouble()
	{
		if (m_bNotNull)
		{
			return (double)(object)DecimalConv.GetNum(m_opoDecCtx.m_pValCtx, DbType.Double);
		}
		throw new OracleNullValueException();
	}

	public int CompareTo(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::CompareTo()\n");
		}
		if (obj.GetType() != typeof(OracleDecimal))
		{
			throw new ArgumentException();
		}
		OracleDecimal oracleDecimal = (OracleDecimal)obj;
		switch (InternalTypes.CompareNull(!m_bNotNull, !oracleDecimal.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::CompareTo()\n");
			}
			return 0;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::CompareTo()\n");
			}
			return -1;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::CompareTo()\n");
			}
			return 1;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::CompareTo()\n");
			}
			return Compare(m_opoDecCtx, oracleDecimal.m_opoDecCtx);
		}
	}

	public override bool Equals(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::Equals(2)\n");
		}
		if (obj == null)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Equals(2)\n");
			}
			return false;
		}
		if (obj.GetType() != typeof(OracleDecimal))
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Equals(2)\n");
			}
			return false;
		}
		OracleDecimal value = (OracleDecimal)obj;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::Equals(2)\n");
		}
		return Equals(this, value);
	}

	public override int GetHashCode()
	{
		if (m_bNotNull)
		{
			return m_opoDecCtx.GetHashCode();
		}
		return 0;
	}

	public override string ToString()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDecimal::ToString()\n");
		}
		if (m_bNotNull)
		{
			int num = 0;
			string numStr;
			try
			{
				num = OpsDec.ToString(m_opoDecCtx.m_pValCtx, m_format, out numStr);
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
			numStr = numStr.TrimEnd(null);
			numStr = numStr.TrimStart(null);
			int length = numStr.Length;
			string text = new string('#', length);
			if (text.Equals(numStr))
			{
				throw new OracleTypeException(22065);
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDecimal::ToString()\n");
			}
			return numStr;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDecimal::ToString()\n");
		}
		return "null";
	}

	internal OracleDecimal(IntPtr numCtx, bool getInfo)
	{
		if (getInfo)
		{
			m_opoDecCtx = new OpoDecCtx(numCtx, out m_numberType, out m_bPositive, out m_bZero);
			m_bGetInfo = true;
			if (m_opoDecCtx.m_error != 0)
			{
				throw new OracleTypeException(m_opoDecCtx.m_error);
			}
		}
		else
		{
			m_opoDecCtx = new OpoDecCtx(numCtx);
			m_numberType = 0;
			m_bZero = false;
			m_bPositive = false;
			m_bGetInfo = false;
		}
		m_bNotNull = true;
		m_format = null;
	}

	internal static OracleDecimal SetPi()
	{
		int num = 0;
		IntPtr numCtx = IntPtr.Zero;
		try
		{
			num = OpsDec.AllocValCtxFromPi(out numCtx);
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
				OpoDecCtx.FreeCtx(ref numCtx);
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		return new OracleDecimal(numCtx, getInfo: false);
	}

	internal unsafe static int Compare(OpoDecCtx value1, OpoDecCtx value2)
	{
		int num = 0;
		int result = default(int);
		try
		{
			num = OpsDec.Compare(value1.m_pValCtx, value2.m_pValCtx, &result);
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
		return result;
	}

	internal static OracleDecimal GetMaxValue()
	{
		string numStr = "9.9999999999999999999999999999999999999E+125";
		IntPtr numCtx = IntPtr.Zero;
		int num = 0;
		try
		{
			num = OpsDec.AllocValCtxFromNoFmtStr(numStr, out numCtx);
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
				OpoDecCtx.FreeCtx(ref numCtx);
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		return new OracleDecimal(numCtx, getInfo: false);
	}

	internal static OracleDecimal GetMinValue()
	{
		string numStr = "-9.9999999999999999999999999999999999999E+125";
		IntPtr numCtx = IntPtr.Zero;
		int num = 0;
		try
		{
			num = OpsDec.AllocValCtxFromNoFmtStr(numStr, out numCtx);
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
				OpoDecCtx.FreeCtx(ref numCtx);
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		return new OracleDecimal(numCtx, getInfo: false);
	}

	internal static OracleDecimal GetPosInfinity()
	{
		IntPtr pNumCtx = IntPtr.Zero;
		int num = 0;
		try
		{
			num = OpsDec.AllocValCtxForPosInf(out pNumCtx);
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
				OpoDecCtx.FreeCtx(ref pNumCtx);
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		return new OracleDecimal(pNumCtx, getInfo: false);
	}

	internal static OracleDecimal GetNegInfinity()
	{
		IntPtr pNumCtx = IntPtr.Zero;
		int num = 0;
		try
		{
			num = OpsDec.AllocValCtxForNegInf(out pNumCtx);
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
				OpoDecCtx.FreeCtx(ref pNumCtx);
				if (num != ErrRes.INT_ERR)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		return new OracleDecimal(pNumCtx, getInfo: false);
	}

	internal unsafe static IntPtr AllocValCtx(object methodParam)
	{
		IntPtr numCtx = IntPtr.Zero;
		if (methodParam is char || methodParam is sbyte || methodParam is byte)
		{
			int num = Convert.ToInt32(methodParam);
			OpsDec.AllocValCtxFromInteger(&num, 4, ref numCtx);
		}
		else if (methodParam is byte[])
		{
			if (((byte[])methodParam).Length != 22)
			{
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), methodParam.ToString());
			}
			int num2 = 0;
			GCHandle gCHandle = GCHandle.Alloc((byte[])methodParam, GCHandleType.Pinned);
			try
			{
				num2 = OpsDec.AllocValCtxFromBytes(gCHandle.AddrOfPinnedObject(), out numCtx);
			}
			finally
			{
				if (gCHandle.IsAllocated)
				{
					gCHandle.Free();
				}
				if (num2 != 0)
				{
					throw new OracleTypeException(num2);
				}
			}
		}
		else if (methodParam is short || methodParam is int)
		{
			int num3 = Convert.ToInt32(methodParam);
			OpsDec.AllocValCtxFromInteger(&num3, 4, ref numCtx);
		}
		else if (methodParam is long num4)
		{
			OpsDec.AllocValCtxFromInteger(&num4, 8, ref numCtx);
		}
		else if (methodParam is float)
		{
			OpsDec.AllocValCtxForSetPrecNoRound(new OracleDecimal((double)(float)methodParam).m_opoDecCtx.m_pValCtx, 7, out numCtx);
		}
		else if (methodParam is double)
		{
			OpsDec.AllocValCtxFromBytes(new OracleDecimal((double)methodParam).m_opoDecCtx.m_pValCtx, out numCtx);
		}
		else if (methodParam is decimal)
		{
			OpsDec.AllocValCtxFromBytes(new OracleDecimal((decimal)methodParam).m_opoDecCtx.m_pValCtx, out numCtx);
		}
		else if (methodParam is string)
		{
			OpsDec.AllocValCtxFromBytes(new OracleDecimal((string)methodParam).m_opoDecCtx.m_pValCtx, out numCtx);
		}
		else if (methodParam is OracleDecimal)
		{
			OpsDec.AllocValCtxFromBytes(((OracleDecimal)methodParam).m_opoDecCtx.m_pValCtx, out numCtx);
		}
		else if (methodParam is OracleString)
		{
			OracleDecimal oracleDecimal = new OracleDecimal(((OracleString)methodParam).Value);
			OpsDec.AllocValCtxFromBytes(oracleDecimal.m_opoDecCtx.m_pValCtx, out numCtx);
		}
		else
		{
			OpsDec.AllocValCtxFromBytes(new OracleDecimal(Convert.ToDecimal(methodParam)).m_opoDecCtx.m_pValCtx, out numCtx);
		}
		return numCtx;
	}

	internal static int ConvertToInt(object methodParam)
	{
		int result = 0;
		if (!(methodParam is byte[]))
		{
			result = ((!(methodParam is OracleDecimal oracleDecimal)) ? ((!(methodParam is OracleString oracleString)) ? Convert.ToInt32(methodParam) : Convert.ToInt32(oracleString.Value)) : oracleDecimal.ToInt32());
		}
		else
		{
			if (((byte[])methodParam).Length != 22)
			{
				throw new InvalidCastException();
			}
			GCHandle gCHandle = GCHandle.Alloc((byte[])methodParam, GCHandleType.Pinned);
			try
			{
				result = (int)(object)DecimalConv.GetNum(gCHandle.AddrOfPinnedObject(), DbType.Int32);
			}
			finally
			{
				if (gCHandle.IsAllocated)
				{
					gCHandle.Free();
				}
			}
		}
		return result;
	}

	internal void KeepValCtx()
	{
		if (m_opoDecCtx != null)
		{
			m_opoDecCtx.m_DoNotFreeValCtx = true;
		}
	}
}
