using System;
using System.IO;

namespace ns33;

internal class Class730
{
	private ulong ulong_0;

	private ulong ulong_1 = 100uL;

	private bool bool_0;

	private string string_0 = string.Empty;

	private static object object_0 = new object();

	private static Class730 class730_0 = null;

	public ulong MaxLogCalls
	{
		set
		{
			lock (object_0)
			{
				ulong_1 = value;
			}
		}
	}

	public static Class730 Instance
	{
		get
		{
			lock (object_0)
			{
				if (class730_0 == null)
				{
					class730_0 = new Class730();
				}
				return class730_0;
			}
		}
	}

	public void method_0(string logFileLocation)
	{
		lock (object_0)
		{
			string_0 = logFileLocation;
			bool_0 = true;
		}
	}

	public void Write(string data)
	{
		try
		{
			lock (object_0)
			{
				if (bool_0 && string_0 != null && string_0.Length > 0 && ulong_0 < ulong_1)
				{
					using (StreamWriter streamWriter = File.AppendText(string_0))
					{
						ulong_0++;
						streamWriter.Write(data);
						return;
					}
				}
			}
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
		}
	}

	public void Close()
	{
		lock (object_0)
		{
			bool_0 = false;
		}
	}

	private Class730()
	{
	}
}
