using System;

namespace x583d72a986201ed7;

internal class xd0213f18a88e2027
{
	private readonly string[] xe5c119bbf35c0d0b;

	private readonly string xed4a7b1500064e12;

	internal string[] x3c24f47680ce5966 => xe5c119bbf35c0d0b;

	internal string xf9ad6fb78355fe13 => xed4a7b1500064e12;

	internal xd0213f18a88e2027(string[] numbers, string text)
	{
		if (numbers == null)
		{
			throw new ArgumentNullException("numbers");
		}
		xe5c119bbf35c0d0b = numbers;
		xed4a7b1500064e12 = text;
	}

	internal xd0213f18a88e2027(string number, string text)
	{
		xe5c119bbf35c0d0b = new string[1];
		xe5c119bbf35c0d0b[0] = number;
		xed4a7b1500064e12 = text;
	}
}
