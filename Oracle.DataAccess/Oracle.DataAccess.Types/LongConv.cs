using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

internal class LongConv
{
	private LongConv()
	{
	}

	public unsafe static long GetLong(OpoITLValCtx* pValCtx, OracleDbType oraType)
	{
		if (oraType != OracleDbType.IntervalYM)
		{
			throw new OracleTypeException(ErrRes.INT_ERR);
		}
		return (long)pValCtx->m_ym.m_years * 12L + pValCtx->m_ym.m_months;
	}
}
