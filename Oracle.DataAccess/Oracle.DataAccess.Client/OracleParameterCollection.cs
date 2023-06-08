using System;
using System.Collections;
using System.Data;
using System.Data.Common;

namespace Oracle.DataAccess.Client;

public sealed class OracleParameterCollection : DbParameterCollection
{
	private ArrayList m_array;

	public new OracleParameter this[string name]
	{
		get
		{
			int num = -1;
			if ((num = FindParamByName(name)) != -1)
			{
				return this[num];
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			if (value.m_collRef == null)
			{
				int num = FindParamByName(name);
				if (num >= 0)
				{
					m_array[num] = value;
					value.m_collRef = this;
					return;
				}
				throw new ArgumentException("name");
			}
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRMCOL_ALREADY_ADDED));
		}
	}

	public override bool IsFixedSize => m_array.IsFixedSize;

	public override bool IsReadOnly => m_array.IsReadOnly;

	public new OracleParameter this[int index]
	{
		get
		{
			return m_array[index] as OracleParameter;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			if (value.m_collRef == null)
			{
				m_array[index] = value;
				value.m_collRef = this;
				return;
			}
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRMCOL_ALREADY_ADDED));
		}
	}

	public override int Count => m_array.Count;

	public override bool IsSynchronized => m_array.IsSynchronized;

	public override object SyncRoot => m_array.SyncRoot;

	static OracleParameterCollection()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	internal OracleParameterCollection()
	{
		m_array = new ArrayList();
	}

	private int FindParamByName(string name)
	{
		int count = m_array.Count;
		for (int i = 0; i < count; i++)
		{
			if (((OracleParameter)m_array[i]).ParameterName.Length >= 1 && ((OracleParameter)m_array[i]).ParameterName[0] == '"')
			{
				if (((OracleParameter)m_array[i]).ParameterName == name)
				{
					return i;
				}
			}
			else if (string.Compare(((OracleParameter)m_array[i]).ParameterName, name, ignoreCase: true) == 0)
			{
				return i;
			}
		}
		return -1;
	}

	public override bool Contains(string parameterName)
	{
		return FindParamByName(parameterName) != -1;
	}

	public override int IndexOf(string parameterName)
	{
		return FindParamByName(parameterName);
	}

	public override void RemoveAt(string parameterName)
	{
		int num = FindParamByName(parameterName);
		if (num >= 0)
		{
			((OracleParameter)m_array[num]).m_collRef = null;
			m_array.RemoveAt(num);
			return;
		}
		throw new ArgumentException();
	}

	public override int Add(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameterCollection::Add(1)\n");
		}
		if (obj == null)
		{
			throw new ArgumentNullException();
		}
		OracleParameter oracleParameter = (OracleParameter)obj;
		if (oracleParameter.m_collRef != null)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRMCOL_ALREADY_ADDED));
		}
		int result = m_array.Add(oracleParameter);
		oracleParameter.m_collRef = this;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameterCollection::Add(1)\n");
		}
		return result;
	}

	public OracleParameter Add(OracleParameter param)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameterCollection::Add(2)\n");
		}
		if (param == null)
		{
			throw new ArgumentNullException("param");
		}
		if (param.m_collRef != null)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRMCOL_ALREADY_ADDED));
		}
		m_array.Add(param);
		param.m_collRef = this;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameterCollection::Add(2)\n");
		}
		return param;
	}

	public OracleParameter Add(string name, object val)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameterCollection::Add(3)\n");
		}
		OracleParameter result = Add(new OracleParameter(name, val));
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameterCollection::Add(3)\n");
		}
		return result;
	}

	public OracleParameter Add(string name, OracleDbType dbType)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameterCollection::Add(4)\n");
		}
		OracleParameter result = Add(new OracleParameter(name, dbType));
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameterCollection::Add(4)\n");
		}
		return result;
	}

	public OracleParameter Add(string name, OracleDbType dbType, ParameterDirection direction)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameterCollection::Add(5)\n");
		}
		OracleParameter result = Add(new OracleParameter(name, dbType, direction));
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameterCollection::Add(5)\n");
		}
		return result;
	}

	public OracleParameter Add(string name, OracleDbType dbType, object val, ParameterDirection dir)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameterCollection::Add(6)\n");
		}
		OracleParameter result = Add(new OracleParameter(name, dbType, val, dir));
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameterCollection::Add(6)\n");
		}
		return result;
	}

	public OracleParameter Add(string name, OracleDbType dbType, int size, object val, ParameterDirection dir)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameterCollection::Add(7)\n");
		}
		OracleParameter result = Add(new OracleParameter(name, dbType, size, val, dir));
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameterCollection::Add(7)\n");
		}
		return result;
	}

	public OracleParameter Add(string name, OracleDbType dbType, int size)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameterCollection::Add(8)\n");
		}
		OracleParameter result = Add(new OracleParameter(name, dbType, size));
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameterCollection::Add(8)\n");
		}
		return result;
	}

	public OracleParameter Add(string name, OracleDbType dbType, int size, string srcColumn)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameterCollection::Add(9)\n");
		}
		OracleParameter result = Add(new OracleParameter(name, dbType, size, srcColumn));
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameterCollection::Add(9)\n");
		}
		return result;
	}

	public OracleParameter Add(string name, OracleDbType dbType, int size, ParameterDirection dir, bool isNullable, byte precision, byte scale, string srcColumn, DataRowVersion version, object val)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameterCollection::Add(10)\n");
		}
		OracleParameter result = Add(new OracleParameter(name, dbType, size, dir, isNullable, precision, scale, srcColumn, version, val));
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameterCollection::Add(10)\n");
		}
		return result;
	}

	public override void Clear()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleParameterCollection::Clear()\n");
		}
		for (int i = 0; i < m_array.Count; i++)
		{
			((OracleParameter)m_array[i]).m_collRef = null;
		}
		m_array.Clear();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleParameterCollection::Clear()\n");
		}
	}

	public override bool Contains(object item)
	{
		return m_array.Contains((OracleParameter)item);
	}

	public override int IndexOf(object obj)
	{
		return m_array.IndexOf((OracleParameter)obj);
	}

	public override void Insert(int index, object obj)
	{
		if (obj == null)
		{
			throw new ArgumentNullException();
		}
		OracleParameter oracleParameter = (OracleParameter)obj;
		if (oracleParameter.m_collRef != null)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRMCOL_ALREADY_ADDED));
		}
		m_array.Insert(index, oracleParameter);
		oracleParameter.m_collRef = this;
	}

	public override void Remove(object obj)
	{
		if (obj == null)
		{
			throw new ArgumentNullException("obj");
		}
		int num = m_array.IndexOf((OracleParameter)obj);
		if (num >= 0)
		{
			((OracleParameter)m_array[num]).m_collRef = null;
			m_array.RemoveAt(num);
			return;
		}
		throw new ArgumentException();
	}

	public override void RemoveAt(int index)
	{
		((OracleParameter)m_array[index]).m_collRef = null;
		m_array.RemoveAt(index);
	}

	public override void CopyTo(Array array, int index)
	{
		m_array.CopyTo(array, index);
	}

	public override IEnumerator GetEnumerator()
	{
		return m_array.GetEnumerator();
	}

	public override void AddRange(Array paramArray)
	{
		if (paramArray == null)
		{
			throw new ArgumentNullException();
		}
		foreach (OracleParameter item in paramArray)
		{
			_ = item;
		}
		foreach (OracleParameter item2 in paramArray)
		{
			m_array.Add(item2);
		}
	}

	protected override DbParameter GetParameter(int index)
	{
		return m_array[index] as DbParameter;
	}

	protected override DbParameter GetParameter(string parameterName)
	{
		int num = -1;
		if ((num = FindParamByName(parameterName)) != -1)
		{
			return this[num];
		}
		return null;
	}

	protected override void SetParameter(int index, DbParameter value)
	{
		m_array[index] = value as OracleParameter;
	}

	protected override void SetParameter(string parameterName, DbParameter value)
	{
		int num = FindParamByName(parameterName);
		if (num < 0 || num >= m_array.Count)
		{
			throw new ArgumentException("parameterName");
		}
		m_array[num] = value;
	}
}
