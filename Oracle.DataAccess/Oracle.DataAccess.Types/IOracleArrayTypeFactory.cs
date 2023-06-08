using System;

namespace Oracle.DataAccess.Types;

public interface IOracleArrayTypeFactory
{
	Array CreateArray(int numElems);

	Array CreateStatusArray(int numElems);
}
