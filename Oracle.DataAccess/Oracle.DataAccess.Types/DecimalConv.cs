using System;
using System.Data;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

internal class DecimalConv
{
	private DecimalConv()
	{
	}

	internal unsafe static decimal GetDecimal(IntPtr numCtx)
	{
		byte* ptr = (byte*)(void*)numCtx;
		if ((ptr[1] & 0x80u) != 0)
		{
			int num = *ptr;
			int num2 = ptr[1] - 193;
			if (num == 1)
			{
				return 0m;
			}
			if (ptr[1] == byte.MaxValue && ptr[2] == 101)
			{
				throw new OverflowException();
			}
			if (num2 > 14 || (num2 == 14 && ptr[2] > 8) || num2 - (num - 2) < -14)
			{
				throw new OverflowException();
			}
			int num3 = (num - 1) * 2;
			if (num3 >= 32)
			{
				throw new OverflowException();
			}
			byte b = 0;
			if (num3 == 30)
			{
				if (ptr[2] - 1 < 10)
				{
					num3--;
				}
				if ((ptr[(int)(*ptr)] - 1) % 10 == 0)
				{
					num3--;
					b = (byte)((ptr[(int)(*ptr)] - 1) / 10);
				}
				if (num3 > 29)
				{
					throw new OverflowException();
				}
			}
			decimal num4 = 0m;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			int num10 = 1;
			int num11 = 1;
			int num12 = 1;
			int num13 = 1;
			int num14 = 0;
			int num15 = num;
			num14 = ((b <= 0) ? (2 * (num2 - (num - 2))) : (2 * (num2 - (num - 2)) + 1));
			if (num14 > 1)
			{
				num15 = num2 + 2;
			}
			int num16 = num15;
			int num17 = num15;
			if (num15 - 1 > 12)
			{
				if (b > 0)
				{
					num6 = b;
					num16--;
					num10 = 10;
				}
				while (num16 >= num17 - 3)
				{
					num5 = ((num16 <= num) ? ((ptr[num16] - 1) * num10) : 0);
					num10 *= 100;
					num6 += num5;
					num16--;
				}
			}
			if (num15 - 1 > 8)
			{
				num17 = num16;
				while (num16 >= num17 - 3)
				{
					num5 = ((num16 <= num) ? ((ptr[num16] - 1) * num11) : 0);
					num11 *= 100;
					num7 += num5;
					num16--;
				}
			}
			if (num15 - 1 > 4)
			{
				num17 = num16;
				while (num16 >= num17 - 3)
				{
					num5 = ((num16 <= num) ? ((ptr[num16] - 1) * num12) : 0);
					num12 *= 100;
					num8 += num5;
					num16--;
				}
			}
			while (num16 >= 2)
			{
				num5 = ((num16 <= num) ? ((ptr[num16] - 1) * num13) : 0);
				num13 *= 100;
				num9 += num5;
				num16--;
			}
			num4 = ((num15 - 1 > 12) ? ((decimal)((long)num9 * (long)num12 + num8) * (decimal)((long)num10 * (long)num11) + (decimal)((long)num7 * (long)num10 + num6)) : ((num15 - 1 > 8) ? ((decimal)((long)num9 * (long)num12 + num8) * (decimal)num11 + (decimal)num7) : ((num15 - 1 <= 4) ? ((decimal)num9) : ((decimal)((long)num9 * (long)num12 + num8)))));
			if (num14 < 0)
			{
				int[] bits = decimal.GetBits(num4);
				num4 = new decimal(bits[0], bits[1], bits[2], isNegative: false, (byte)(-num14));
			}
			else if (num14 == 1)
			{
				num4 *= 10m;
			}
			return num4;
		}
		int num18 = *ptr;
		int num19 = 62 - ptr[1];
		if (num18 == 1)
		{
			throw new OverflowException();
		}
		if (num19 > 14 || (num19 == 14 && ptr[2] < 94) || num19 - (num18 - 3) < -14)
		{
			throw new OverflowException();
		}
		int num20 = (num18 - 2) * 2;
		if (num20 >= 32)
		{
			throw new OverflowException();
		}
		byte b2 = 0;
		if (num20 == 30)
		{
			if (101 - ptr[2] < 10)
			{
				num20--;
			}
			if ((101 - ptr[*ptr - 1]) % 10 == 0)
			{
				num20--;
				b2 = (byte)((101 - ptr[*ptr - 1]) / 10);
			}
			if (num20 > 29)
			{
				throw new OverflowException();
			}
		}
		decimal num21 = 0m;
		int num22 = 0;
		int num23 = 0;
		int num24 = 0;
		int num25 = 0;
		int num26 = 0;
		int num27 = 1;
		int num28 = 1;
		int num29 = 1;
		int num30 = 1;
		int num31 = 0;
		int num32 = num18;
		num31 = ((b2 <= 0) ? (2 * (num19 - (num18 - 3))) : (2 * (num19 - (num18 - 3)) + 1));
		if (num31 > 1)
		{
			num32 = num19 + 3;
		}
		int num33 = num32 - 1;
		int num34 = num32 - 1;
		if (num32 - 2 > 12)
		{
			if (b2 > 0)
			{
				num23 = b2;
				num33--;
				num27 = 10;
			}
			while (num33 >= num34 - 3)
			{
				num22 = ((num33 < num18) ? ((101 - ptr[num33]) * num27) : 0);
				num27 *= 100;
				num23 += num22;
				num33--;
			}
		}
		if (num32 - 2 > 8)
		{
			num34 = num33;
			while (num33 >= num34 - 3)
			{
				num22 = ((num33 < num18) ? ((101 - ptr[num33]) * num28) : 0);
				num28 *= 100;
				num24 += num22;
				num33--;
			}
		}
		if (num32 - 2 > 4)
		{
			num34 = num33;
			while (num33 >= num34 - 3)
			{
				num22 = ((num33 < num18) ? ((101 - ptr[num33]) * num29) : 0);
				num29 *= 100;
				num25 += num22;
				num33--;
			}
		}
		while (num33 >= 2)
		{
			num22 = ((num33 < num18) ? ((101 - ptr[num33]) * num30) : 0);
			num30 *= 100;
			num26 += num22;
			num33--;
		}
		num21 = ((num32 - 2 > 12) ? ((decimal)((long)num26 * (long)num29 + num25) * (decimal)((long)num27 * (long)num28) + (decimal)((long)num24 * (long)num27 + num23)) : ((num32 - 2 > 8) ? ((decimal)((long)num26 * (long)num29 + num25) * (decimal)num28 + (decimal)num24) : ((num32 - 2 <= 4) ? ((decimal)num26) : ((decimal)((long)num26 * (long)num29 + num25)))));
		int[] bits2 = decimal.GetBits(num21);
		if (num31 < 0)
		{
			num21 = new decimal(bits2[0], bits2[1], bits2[2], isNegative: true, (byte)(-num31));
		}
		else
		{
			bits2[3] |= int.MinValue;
			num21 = new decimal(bits2);
			if (num31 == 1)
			{
				num21 *= 10m;
			}
		}
		return num21;
	}

	internal unsafe static ValueType GetNum(IntPtr numCtx, DbType dbType)
	{
		int num = 0;
		ValueType result = 0;
		switch (dbType)
		{
		case DbType.Byte:
		{
			byte b = 0;
			try
			{
				num = OpsDec.ToByte(numCtx, &b);
			}
			catch (Exception ex4)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex4);
				}
				throw;
			}
			result = b;
			break;
		}
		case DbType.Int16:
		{
			short num6 = 0;
			try
			{
				num = OpsDec.ToInteger(numCtx, &num6, 2);
			}
			catch (Exception ex6)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex6);
				}
				throw;
			}
			result = num6;
			break;
		}
		case DbType.Int32:
		{
			int num3 = 0;
			try
			{
				num = OpsDec.ToInteger(numCtx, &num3, 4);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				throw;
			}
			result = num3;
			break;
		}
		case DbType.Int64:
		{
			long num5 = 0L;
			try
			{
				num = OpsDec.ToInteger(numCtx, &num5, 8);
			}
			catch (Exception ex5)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex5);
				}
				throw;
			}
			result = num5;
			break;
		}
		case DbType.Single:
		{
			float num4 = 0f;
			try
			{
				num = OpsDec.ToReal(numCtx, &num4, 4);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
				throw;
			}
			result = num4;
			break;
		}
		case DbType.Double:
		{
			double num2 = 0.0;
			try
			{
				num = OpsDec.ToReal(numCtx, &num2, 8);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			result = num2;
			break;
		}
		case DbType.Decimal:
			result = GetDecimal(numCtx);
			num = 0;
			break;
		}
		switch (num)
		{
		case 0:
			return result;
		case 22053:
		case 22054:
			throw new OverflowException(OracleTypeException.GetTypeMsg(num));
		default:
			throw new OracleTypeException(num);
		}
	}

	public unsafe static void GetBytes(decimal dec, IntPtr numCtx)
	{
		byte* ptr = (byte*)(void*)numCtx;
		if (dec == 0m)
		{
			*ptr = 1;
			ptr[1] = 128;
			return;
		}
		int[] bits = decimal.GetBits(dec);
		int num = bits[3];
		bool flag = false;
		if ((num & 0x80000000u) == 2147483648u)
		{
			flag = true;
		}
		int num2 = (byte)((num & 0xFF0000) >> 16);
		decimal num3 = 10000000000000000m;
		int num4 = 100000000;
		decimal num5 = 0m;
		long num6 = 0L;
		long num7 = 0L;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		int num11 = 0;
		if (num2 == 0)
		{
			num6 = (long)(dec % num3);
			num7 = (long)(dec / num3);
			num8 = (int)(num6 % num4);
			num9 = (int)(num6 / num4);
			if (num7 != 0)
			{
				num10 = (int)(num7 % num4);
				num11 = (int)(num7 / num4);
			}
			if (flag)
			{
				if (num8 < 0)
				{
					num8 = -num8;
				}
				if (num9 < 0)
				{
					num9 = -num9;
				}
				if (num10 < 0)
				{
					num10 = -num10;
				}
				if (num11 < 0)
				{
					num11 = -num11;
				}
			}
		}
		else
		{
			num5 = new decimal(bits[0], bits[1], bits[2], flag, 0) / (decimal)Math.Pow(10.0, num2);
			bits = decimal.GetBits(num5);
			num = bits[3];
			num2 = (byte)((num & 0xFF0000) >> 16);
			num5 = new decimal(bits[0], bits[1], bits[2], isNegative: false, 0);
			if (num2 == 0)
			{
				num6 = (long)(num5 % num3);
				num7 = (long)(num5 / num3);
				num8 = (int)(num6 % num4);
				num9 = (int)(num6 / num4);
				if (num7 > 0)
				{
					num10 = (int)(num7 % num4);
					num11 = (int)(num7 / num4);
				}
			}
		}
		byte b = 100;
		byte b2 = 0;
		byte b3 = 0;
		byte b4 = 0;
		if (num2 == 0)
		{
			if (num8 > 0)
			{
				b4 = (byte)(num8 % (int)b);
				num8 /= (int)b;
				while (b4 == 0)
				{
					b4 = (byte)(num8 % (int)b);
					num8 /= (int)b;
					b2 = (byte)(b2 + 1);
				}
			}
			else if (num9 > 0)
			{
				b4 = (byte)(num9 % (int)b);
				num9 /= (int)b;
				b2 = 4;
				while (b4 == 0)
				{
					b4 = (byte)(num9 % (int)b);
					num9 /= (int)b;
					b2 = (byte)(b2 + 1);
				}
			}
			else if (num10 > 0)
			{
				b4 = (byte)(num10 % (int)b);
				num10 /= (int)b;
				b2 = 8;
				while (b4 == 0)
				{
					b4 = (byte)(num10 % (int)b);
					num10 /= (int)b;
					b2 = (byte)(b2 + 1);
				}
			}
			else
			{
				b4 = (byte)(num11 % (int)b);
				num11 /= (int)b;
				b2 = 12;
				while (b4 == 0)
				{
					b4 = (byte)(num11 % (int)b);
					num11 /= (int)b;
					b2 = (byte)(b2 + 1);
				}
			}
		}
		else if (num2 % 2 == 0)
		{
			num6 = (long)(num5 % num3);
			num7 = (long)(num5 / num3);
			num8 = (int)(num6 % num4);
			num9 = (int)(num6 / num4);
			if (num7 > 0)
			{
				num10 = (int)(num7 % num4);
				num11 = (int)(num7 / num4);
			}
			b4 = (byte)(num8 % (int)b);
			num8 /= (int)b;
			b3 = (byte)(num2 / 2);
		}
		else
		{
			decimal num12 = 1000000000000000m;
			long num13 = 10000000L;
			num6 = (long)(num5 % num12);
			num7 = (long)(num5 / num12);
			num8 = (int)(num6 % num13);
			num9 = (int)(num6 / num13);
			if (num7 > 0)
			{
				num10 = (int)(num7 % num4);
				num11 = (int)(num7 / num4);
			}
			b4 = (byte)(num8 % 10 * 10);
			num8 /= 10;
			b3 = (byte)(num2 / 2 + 1);
		}
		int num14 = 0;
		byte[] array = new byte[22];
		if (flag)
		{
			array[num14] = (byte)(101 - b4);
		}
		else
		{
			array[num14] = (byte)(b4 + 1);
		}
		num14++;
		while (num8 > 0)
		{
			b4 = (byte)(num8 % (int)b);
			num8 /= (int)b;
			if (flag)
			{
				array[num14] = (byte)(101 - b4);
			}
			else
			{
				array[num14] = (byte)(b4 + 1);
			}
			num14++;
			b2 = (byte)(b2 + 1);
		}
		if (num9 > 0)
		{
			while (b2 < 3)
			{
				if (flag)
				{
					array[num14] = 101;
				}
				else
				{
					array[num14] = 1;
				}
				num14++;
				b2 = (byte)(b2 + 1);
			}
		}
		while (num9 > 0)
		{
			b4 = (byte)(num9 % (int)b);
			num9 /= (int)b;
			if (flag)
			{
				array[num14] = (byte)(101 - b4);
			}
			else
			{
				array[num14] = (byte)(b4 + 1);
			}
			num14++;
			b2 = (byte)(b2 + 1);
		}
		if (num10 > 0)
		{
			while (b2 < 7)
			{
				if (flag)
				{
					array[num14] = 101;
				}
				else
				{
					array[num14] = 1;
				}
				num14++;
				b2 = (byte)(b2 + 1);
			}
		}
		while (num10 > 0)
		{
			b4 = (byte)(num10 % (int)b);
			num10 /= (int)b;
			if (flag)
			{
				array[num14] = (byte)(101 - b4);
			}
			else
			{
				array[num14] = (byte)(b4 + 1);
			}
			num14++;
			b2 = (byte)(b2 + 1);
		}
		if (num11 > 0)
		{
			while (b2 < 11)
			{
				if (flag)
				{
					array[num14] = 101;
				}
				else
				{
					array[num14] = 1;
				}
				num14++;
				b2 = (byte)(b2 + 1);
			}
		}
		while (num11 > 0)
		{
			b4 = (byte)(num11 % (int)b);
			num11 /= (int)b;
			if (flag)
			{
				array[num14] = (byte)(101 - b4);
			}
			else
			{
				array[num14] = (byte)(b4 + 1);
			}
			num14++;
			b2 = (byte)(b2 + 1);
		}
		b2 = ((!flag) ? ((byte)(b2 + 193 - b3)) : ((byte)(62 - b2 + b3)));
		if (flag)
		{
			*ptr = (byte)(num14 + 2);
		}
		else
		{
			*ptr = (byte)(num14 + 1);
		}
		ptr[1] = b2;
		int num15 = 0;
		num15 = 2;
		while (num14 > 0)
		{
			ptr[num15] = array[num14 - 1];
			num15++;
			num14--;
		}
		if (flag)
		{
			ptr[num15] = 102;
		}
	}
}
