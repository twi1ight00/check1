using System;

namespace PageOffice.Utilities;

public class ExcelRect
{
	public int left;

	public int top;

	public int right;

	public int bottom;

	public ExcelRect(string RangeAddress)
	{
		string[] array = RangeAddress.Split(':');
		if (array.Length == 2)
		{
			_0002(array[0]);
			_0003(array[1]);
		}
	}

	private static int _0002(string _0002)
	{
		try
		{
			return Convert.ToInt32(_0002);
		}
		catch
		{
			return 0;
		}
	}

	private void _0002(string _0002)
	{
		int num = 0;
		if (_0002.Length >= 2 && _0002[0] >= 'A' && _0002[0] <= 'Z')
		{
			if (_0002[1] >= 'A' && _0002[1] <= 'Z')
			{
				left = (_0002[0] - 65 + 1) * 26 + _0002[1] - 65 + 1;
				num = 2;
			}
			else
			{
				left = _0002[0] - 65 + 1;
				num = 1;
			}
			string text = _0002.Substring(num, _0002.Length - num);
			if (text.Length > 0)
			{
				top = ExcelRect._0002(text);
			}
		}
	}

	private void _0003(string _0002)
	{
		int num = 0;
		if (_0002.Length >= 2 && _0002[0] >= 'A' && _0002[0] <= 'Z')
		{
			if (_0002[1] >= 'A' && _0002[1] <= 'Z')
			{
				right = (_0002[0] - 65 + 1) * 26 + _0002[1] - 65 + 1;
				num = 2;
			}
			else
			{
				right = _0002[0] - 65 + 1;
				num = 1;
			}
			string text = _0002.Substring(num, _0002.Length - num);
			if (text.Length > 0)
			{
				bottom = ExcelRect._0002(text);
			}
		}
	}

	public bool IsValid()
	{
		if (left == 0 || top == 0 || right == 0 || bottom == 0)
		{
			return false;
		}
		if (left <= 676 && right <= 676 && top <= 65536 && bottom <= 65536 && bottom >= top && right >= left)
		{
			return true;
		}
		return false;
	}

	public static bool CellAddressIsValid(string CellAddress)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (CellAddress.Length >= 2 && CellAddress[0] >= 'A' && CellAddress[0] <= 'Z')
		{
			if (CellAddress[1] >= 'A' && CellAddress[1] <= 'Z')
			{
				num = (CellAddress[0] - 65 + 1) * 26 + CellAddress[1] - 65 + 1;
				num3 = 2;
			}
			else
			{
				num = CellAddress[0] - 65 + 1;
				num3 = 1;
			}
			string text = CellAddress.Substring(num3, CellAddress.Length - num3);
			if (text.Length > 0)
			{
				num2 = _0002(text);
			}
		}
		if (num > 0 && num2 > 0 && num <= 676 && num2 <= 65536)
		{
			return true;
		}
		return false;
	}

	public static bool LooklikeCellAddress(string CellAddress)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (CellAddress.Length >= 2 && CellAddress[0] >= 'A' && CellAddress[0] <= 'Z')
		{
			if (CellAddress[1] >= 'A' && CellAddress[1] <= 'Z')
			{
				num = (CellAddress[0] - 65 + 1) * 26 + CellAddress[1] - 65 + 1;
				num3 = 2;
			}
			else
			{
				num = CellAddress[0] - 65 + 1;
				num3 = 1;
			}
			string text = CellAddress.Substring(num3, CellAddress.Length - num3);
			if (text.Length > 0)
			{
				num2 = _0002(text);
			}
		}
		if (num > 0 && num2 > 0)
		{
			return true;
		}
		return false;
	}

	public static bool LooklikeRangeAddress(string RangeAddress)
	{
		if (RangeAddress.IndexOf(_0005_2000._0002(1402767420)) > 0)
		{
			string[] array = RangeAddress.Split(':');
			if (array.Length == 2 && LooklikeCellAddress(array[0]) && LooklikeCellAddress(array[1]))
			{
				return true;
			}
		}
		return false;
	}

	public string GetRangeAddress()
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		empty = ((left <= 26) ? ((char)(65 + (left - 1) % 26)).ToString() : (((char)(65 + (left - 1) / 26 - 1)).ToString() + (char)(65 + (left - 1) % 26)));
		empty2 = ((right <= 26) ? ((char)(65 + (right - 1) % 26)).ToString() : (((char)(65 + (right - 1) / 26 - 1)).ToString() + (char)(65 + (right - 1) % 26)));
		return empty + top + _0005_2000._0002(1402767420) + empty2 + bottom;
	}
}
