using System;
using ns60;

namespace ns63;

internal sealed class Class2940 : Interface40
{
	private uint uint_0;

	private uint uint_1;

	private Interface44 interface44_0;

	public uint PersitsId => uint_0;

	public uint Offset => uint_1;

	public Class2940(uint persitsId, uint offset)
	{
		uint_0 = persitsId;
		uint_1 = offset;
	}

	public void method_0(Interface44 record)
	{
		if (interface44_0 != null)
		{
			throw new Exception("m_referencedRecord is assigned already.");
		}
		interface44_0 = record;
	}

	public Interface44 method_1()
	{
		if (interface44_0 == null)
		{
			throw new Exception("m_referencedRecord is not assigned yet.");
		}
		return interface44_0;
	}
}
