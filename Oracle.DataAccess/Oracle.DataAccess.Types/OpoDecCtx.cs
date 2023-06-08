using System;
using System.Runtime.InteropServices;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

internal class OpoDecCtx : IDisposable
{
	internal IntPtr m_pValCtx;

	internal int m_error;

	internal bool m_DoNotFreeValCtx;

	internal OpoDecCtx(IntPtr numCtx)
	{
		m_pValCtx = numCtx;
	}

	internal OpoDecCtx(IntPtr numCtx, out int numberType, out bool bPositive, out bool bZero)
	{
		int isPositive = 0;
		int isZero = 0;
		numberType = 1;
		bPositive = false;
		bZero = false;
		try
		{
			m_error = OpsDec.GetInfo(numCtx, out numberType, out isPositive, out isZero, 1);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		if (m_error == 0)
		{
			m_pValCtx = numCtx;
			if (isPositive == 1)
			{
				bPositive = true;
			}
			else
			{
				bPositive = false;
			}
			bZero = false;
			if (isZero == 1)
			{
				bZero = true;
			}
			else
			{
				bZero = false;
			}
		}
	}

	internal OpoDecCtx(string numStr, string numFmt, out int numberType, out bool bPositive, out bool bZero)
	{
		int isPositive = 0;
		int isZero = 0;
		numberType = 1;
		bPositive = false;
		bZero = false;
		if (numStr == "~")
		{
			try
			{
				m_error = OpsDec.AllocValCtxForPosInf(out m_pValCtx);
				return;
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				m_error = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (m_error != 0)
				{
					FreeCtx(ref m_pValCtx);
				}
				else
				{
					numberType = 3;
					bPositive = true;
					bZero = false;
				}
			}
		}
		if (numStr == "-~")
		{
			try
			{
				m_error = OpsDec.AllocValCtxForNegInf(out m_pValCtx);
				return;
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				m_error = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (m_error != 0)
				{
					FreeCtx(ref m_pValCtx);
				}
				else
				{
					numberType = 4;
					bPositive = false;
					bZero = false;
				}
			}
		}
		try
		{
			m_error = OpsDec.AllocValCtxWInfoFromStr(numStr, numFmt, out m_pValCtx, out numberType, out isPositive, out isZero);
		}
		catch (Exception ex3)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex3);
			}
			m_error = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (m_error != 0)
			{
				FreeCtx(ref m_pValCtx);
			}
			else
			{
				if (isPositive == 1)
				{
					bPositive = true;
				}
				else
				{
					bPositive = false;
				}
				if (isZero == 1)
				{
					bZero = true;
				}
				else
				{
					bZero = false;
				}
			}
		}
	}

	internal unsafe OpoDecCtx(int intX, out int numberType, out bool bPositive, out bool bZero)
	{
		numberType = 1;
		bPositive = false;
		bZero = false;
		try
		{
			m_error = OpsDec.AllocValCtxFromInteger(&intX, 4, ref m_pValCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			m_error = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (m_error != 0)
			{
				FreeCtx(ref m_pValCtx);
			}
			else
			{
				numberType = 1;
				if (intX > 0)
				{
					bPositive = true;
				}
				else
				{
					bPositive = false;
				}
				if (intX == 0)
				{
					bZero = true;
				}
				else
				{
					bZero = false;
				}
			}
		}
	}

	internal unsafe OpoDecCtx(long longX, out int numberType, out bool bPositive, out bool bZero)
	{
		numberType = 1;
		bPositive = false;
		bZero = false;
		try
		{
			m_error = OpsDec.AllocValCtxFromInteger(&longX, 8, ref m_pValCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			m_error = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (m_error != 0)
			{
				FreeCtx(ref m_pValCtx);
			}
			else
			{
				numberType = 1;
				if (longX > 0)
				{
					bPositive = true;
				}
				else
				{
					bPositive = false;
				}
				if (longX == 0)
				{
					bZero = true;
				}
				else
				{
					bZero = false;
				}
			}
		}
	}

	internal unsafe OpoDecCtx(float floatX, out int numberType, out bool bPositive, out bool bZero)
	{
		int isPositive = 0;
		int isZero = 0;
		bPositive = false;
		bZero = false;
		numberType = 0;
		try
		{
			m_error = OpsDec.AllocValCtxWInfoFromReal(&floatX, 4, out m_pValCtx, out numberType, out isPositive, out isZero);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			m_error = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (m_error != 0)
			{
				FreeCtx(ref m_pValCtx);
			}
			else
			{
				if (isPositive == 1)
				{
					bPositive = true;
				}
				else
				{
					bPositive = false;
				}
				if (isZero == 1)
				{
					bZero = true;
				}
				else
				{
					bZero = false;
				}
			}
		}
	}

	internal unsafe OpoDecCtx(double doubleX, out int numberType, out bool bPositive, out bool bZero)
	{
		int isPositive = 0;
		int isZero = 0;
		bPositive = false;
		bZero = false;
		numberType = 0;
		try
		{
			m_error = OpsDec.AllocValCtxWInfoFromReal(&doubleX, 8, out m_pValCtx, out numberType, out isPositive, out isZero);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			m_error = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (m_error != 0)
			{
				FreeCtx(ref m_pValCtx);
			}
			else
			{
				if (isPositive == 1)
				{
					bPositive = true;
				}
				else
				{
					bPositive = false;
				}
				if (isZero == 1)
				{
					bZero = true;
				}
				else
				{
					bZero = false;
				}
			}
		}
	}

	internal OpoDecCtx(decimal decimalX, out int numberType, out bool bPositive, out bool bZero)
	{
		m_pValCtx = Marshal.AllocCoTaskMem(22);
		DecimalConv.GetBytes(decimalX, m_pValCtx);
		byte[] bytes = BitConverter.GetBytes(decimal.GetBits(decimalX)[3]);
		if (bytes[2] == 0)
		{
			numberType = 1;
		}
		else
		{
			numberType = 2;
		}
		if (decimalX > 0m)
		{
			bPositive = true;
		}
		else
		{
			bPositive = false;
		}
		if (decimalX == 0m)
		{
			bZero = true;
		}
		else
		{
			bZero = false;
		}
	}

	~OpoDecCtx()
	{
		Dispose();
	}

	public void Dispose()
	{
		if (!m_DoNotFreeValCtx)
		{
			FreeCtx(ref m_pValCtx);
		}
		try
		{
			GC.SuppressFinalize(this);
		}
		catch
		{
		}
	}

	internal static void FreeCtx(ref IntPtr numCtx)
	{
		if (!(numCtx != IntPtr.Zero))
		{
			return;
		}
		try
		{
			OpsDec.FreeValCtx(numCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
		}
		numCtx = IntPtr.Zero;
	}
}
