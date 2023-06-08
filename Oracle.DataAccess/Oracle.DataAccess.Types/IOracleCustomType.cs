using System;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

public interface IOracleCustomType
{
	void FromCustomObject(OracleConnection con, IntPtr pUdt);

	void ToCustomObject(OracleConnection con, IntPtr pUdt);
}
