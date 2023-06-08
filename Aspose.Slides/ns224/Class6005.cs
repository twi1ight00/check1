using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ns224;

internal class Class6005 : IDisposable, IEnumerator, IEnumerator<Class6005.Class6006>
{
	public class Class6006
	{
		private bool bool_0;

		private StringBuilder stringBuilder_0 = new StringBuilder();

		public bool IsLower => bool_0;

		public string Text => stringBuilder_0.ToString();

		public Class6006(bool isLower)
		{
			bool_0 = isLower;
		}

		internal void Add(char c)
		{
			stringBuilder_0.Append(c);
		}
	}

	private string string_0;

	private int int_0;

	private int int_1;

	private Class6006 class6006_0;

	public Class6006 Current => class6006_0;

	object IEnumerator.Current => Current;

	public Class6005(string text)
	{
		int_0 = -1;
		string_0 = text;
		int_1 = text.Length;
	}

	public void Dispose()
	{
		string_0 = null;
	}

	public bool MoveNext()
	{
		if (int_0 == int_1 - 1)
		{
			return false;
		}
		int_0++;
		char c = string_0[int_0];
		class6006_0 = new Class6006(char.IsLower(c));
		class6006_0.Add(c);
		char nextChar;
		while (method_0(out nextChar))
		{
			bool flag = char.IsLower(nextChar);
			if ((!class6006_0.IsLower || !flag) && (class6006_0.IsLower || flag))
			{
				break;
			}
			int_0++;
			class6006_0.Add(nextChar);
		}
		return true;
	}

	private bool method_0(out char nextChar)
	{
		int num = int_0 + 1;
		if (num < int_1)
		{
			nextChar = string_0[num];
			return true;
		}
		nextChar = '\0';
		return false;
	}

	public void Reset()
	{
		int_0 = -1;
		class6006_0 = null;
	}
}
