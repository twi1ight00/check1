using System;
using System.Collections;
using x13f1efc79617a47b;

namespace x6c95d9cf46ff5f25;

internal class x682712679dbc585a
{
	public static void x70fa1602ceccddee(object[] x337e217cb3ba0627, IDictionary x20a3e0f339796f78, IDictionary xa3247a6c559dde0e)
	{
		int num = x337e217cb3ba0627.Length / 2;
		for (int i = 0; i < num; i++)
		{
			x20a3e0f339796f78.Add(x337e217cb3ba0627[i * 2], x337e217cb3ba0627[i * 2 + 1]);
			xa3247a6c559dde0e?.Add(x337e217cb3ba0627[i * 2 + 1], x337e217cb3ba0627[i * 2]);
		}
	}

	public static object xce92de628aa023cf(IDictionary x12fedb3de1c57ea7, object x389f579bb09d94ed, object xc6e85c82d0d89508)
	{
		if (x389f579bb09d94ed != null)
		{
			object obj = x12fedb3de1c57ea7[x389f579bb09d94ed];
			if (obj != null)
			{
				return obj;
			}
		}
		if (xc6e85c82d0d89508 != null)
		{
			return xc6e85c82d0d89508;
		}
		throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ddmdoedeifkeffbfdfifffpfopfgodngheehdelhieciedjiodajndhjgonjkoekldmknoclhdklonamcohm", 1915698160)), x389f579bb09d94ed));
	}

	public static object xce92de628aa023cf(IDictionary x12fedb3de1c57ea7, object x389f579bb09d94ed)
	{
		return xce92de628aa023cf(x12fedb3de1c57ea7, x389f579bb09d94ed, null);
	}

	public static object xadb8a11581ae0f33(IDictionary x12fedb3de1c57ea7, object x389f579bb09d94ed)
	{
		if (x389f579bb09d94ed == null)
		{
			return null;
		}
		return x12fedb3de1c57ea7[x389f579bb09d94ed];
	}

	private x682712679dbc585a()
	{
	}
}
