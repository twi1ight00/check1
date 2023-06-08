using System;
using System.Globalization;
using System.Text;
using Aspose.Cells;
using ns2;

namespace ns14;

internal class Class513 : ICustomParser
{
	private Class530 class530_0 = new Class530();

	private StringBuilder stringBuilder_0 = new StringBuilder(50);

	private StringBuilder stringBuilder_1 = new StringBuilder(10);

	private CultureInfo cultureInfo_0;

	private Class529 class529_0;

	private Interface4 interface4_0;

	private Class520 class520_0;

	private readonly int[] int_0 = new int[3];

	private readonly int[] int_1 = new int[3];

	private readonly int[] int_2 = new int[3];

	private int int_3 = -1;

	private int int_4 = -1;

	private int int_5 = -1;

	private int int_6 = -1;

	private int int_7 = -1;

	private int int_8 = -1;

	private int int_9 = -1;

	private int int_10;

	private int int_11;

	private int int_12;

	private int int_13;

	private char[] char_0;

	internal Class513(CultureInfo cultureInfo_1, Class529 class529_1, Class520 class520_1)
	{
		cultureInfo_0 = cultureInfo_1;
		class529_0 = class529_1;
		class520_0 = class520_1;
		interface4_0 = class520_1.method_1();
		if (interface4_0 == null)
		{
			interface4_0 = new Class528(cultureInfo_1, class529_1);
		}
	}

	public object ParseObject(string value)
	{
		stringBuilder_0.Length = 0;
		class530_0.Reset();
		if (value != null && !(value == ""))
		{
			char_0 = value.ToCharArray();
			if (char_0[0] == ' ')
			{
				return null;
			}
			int_11 = 0;
			int_12 = char_0.Length;
			int_13 = 0;
			int_10 = 0;
			int_3 = -1;
			int_4 = -1;
			int_5 = -1;
			int_6 = -1;
			int_7 = -1;
			int_8 = -1;
			int_9 = -1;
			int_13 = int_11;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int int_ = 0;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			byte b = 0;
			byte b2 = 0;
			while (true)
			{
				if (int_13 < int_12)
				{
					char c = char_0[int_13];
					if (c >= '0' && c <= '9')
					{
						if ((!flag3 || !flag4) && int_10 <= 2 && (int_10 <= 0 || int_13 - num3 <= ((flag || (int_3 > -1 && int_3 < int_10)) ? 1 : 3)) && (flag3 || int_4 != int_10))
						{
							num = num * 10 + (c - 48);
							if (flag)
							{
								if (int_10 > 0 && num > 60)
								{
									return null;
								}
							}
							else if (num > 9999)
							{
								return null;
							}
							int_13++;
							continue;
						}
						return null;
					}
					if (num3 < int_13)
					{
						if (!flag3)
						{
							b2 = 0;
							num2 = interface4_0.imethod_7(char_0, int_13);
							if (num2 > 0)
							{
								b2 = 1;
							}
							else
							{
								num2 = interface4_0.imethod_9(char_0, int_13);
								if (num2 > 0)
								{
									b2 = 2;
								}
								else
								{
									num2 = interface4_0.imethod_11(char_0, int_13);
									if (num2 > 0)
									{
										b2 = 3;
									}
									else
									{
										num2 = interface4_0.imethod_4(char_0, int_13);
										if (num2 > 0)
										{
											if (num > 100)
											{
												if (int_13 - num3 < 4)
												{
													return null;
												}
												b2 = 1;
											}
											else if (num > 31)
											{
												b2 = 1;
											}
											else if (num > 12)
											{
												if (int_3 > -1 && int_3 < int_10)
												{
													b2 = 3;
												}
											}
											else if (int_3 > -1 && int_3 < int_10 && int_5 > -1 && int_5 < int_10)
											{
												b2 = 2;
											}
										}
									}
								}
							}
							if (num2 > 0)
							{
								if (flag)
								{
									if (int_10 <= 1)
									{
										return null;
									}
									if (flag2)
									{
										method_23(int_, num3);
									}
									else
									{
										method_3(bool_0: true);
									}
									if (int_7 < 0)
									{
										return null;
									}
									method_1(int_2[int_10 - 1], num3, bool_0: false);
									flag = false;
									flag4 = true;
									int_10 = 0;
									int_ = num3;
									flag2 = false;
								}
								switch (b2)
								{
								case 1:
									if (int_3 < 0)
									{
										int_3 = int_10;
									}
									else if (int_3 != int_10)
									{
										return null;
									}
									goto default;
								case 2:
									if (int_4 < 0)
									{
										int_4 = int_10;
									}
									else if (int_4 != int_10)
									{
										return null;
									}
									goto default;
								case 3:
									if (int_5 < 0)
									{
										int_5 = int_10;
									}
									else if (int_5 != int_10)
									{
										return null;
									}
									goto default;
								default:
									int_0[int_10] = num;
									int_1[int_10] = num3;
									int_2[int_10] = int_13;
									int_10++;
									int_13 += num2;
									num3 = int_13;
									num = 0;
									break;
								}
								continue;
							}
						}
						if (!flag4)
						{
							b2 = 0;
							num2 = interface4_0.imethod_13(char_0, int_13);
							if (num2 > 0)
							{
								b2 = 4;
							}
							else
							{
								num2 = interface4_0.imethod_15(char_0, int_13);
								if (num2 > 0)
								{
									b2 = 5;
								}
								else
								{
									num2 = interface4_0.imethod_17(char_0, int_13);
									if (num2 > 0)
									{
										b2 = 6;
									}
									else
									{
										num2 = interface4_0.imethod_5(char_0, int_13);
									}
								}
							}
							if (num2 > 0)
							{
								if (int_13 - num3 <= 2 || char_0[num3] != '0')
								{
									if (!flag)
									{
										if (int_10 > 1)
										{
											if (flag3)
											{
												return null;
											}
											if (flag2)
											{
												method_22(int_, num3);
											}
											else
											{
												method_8();
											}
											if (int_4 < 0)
											{
												return null;
											}
											method_1(int_2[int_10 - 1], num3, bool_0: false);
											flag3 = true;
											int_10 = 0;
											int_ = num3;
											flag2 = false;
										}
										else if (int_10 > 0)
										{
											return null;
										}
										flag = true;
									}
									switch (b2)
									{
									case 4:
										if (int_6 < 0)
										{
											int_6 = int_10;
										}
										else if (int_6 != int_10)
										{
											return null;
										}
										goto default;
									case 5:
										if (int_7 < 0)
										{
											int_7 = int_10;
										}
										else if (int_7 != int_10)
										{
											return null;
										}
										goto default;
									case 6:
										if (int_8 < 0)
										{
											int_8 = int_10;
										}
										else if (int_8 != int_10)
										{
											return null;
										}
										goto default;
									default:
										int_0[int_10] = num;
										int_1[int_10] = num3;
										int_2[int_10] = int_13;
										int_10++;
										int_13 += num2;
										num3 = int_13;
										num = 0;
										break;
									}
									continue;
								}
								return null;
							}
						}
						if (int_10 > 2 || (flag3 && flag4))
						{
							return null;
						}
						int_0[int_10] = num;
						int_1[int_10] = num3;
						int_2[int_10] = int_13;
						int_10++;
					}
					if (c == ' ')
					{
						int num4 = int_13;
						int_13++;
						while (int_13 < int_12 && char_0[int_13] == ' ')
						{
							int_13++;
						}
						bool flag5 = false;
						switch (int_10)
						{
						case 0:
							method_1(num4, int_13, !flag);
							goto default;
						case 1:
							if (num4 > num3 && int_13 < int_12 && char_0[int_13] >= '0' && char_0[int_13] <= '9')
							{
								return null;
							}
							goto default;
						case 2:
							if (num4 > num3 && int_13 < int_12 && char_0[int_13] >= '0' && char_0[int_13] <= '9')
							{
								flag5 = true;
							}
							goto default;
						case 3:
							flag5 = true;
							goto default;
						default:
							if (flag5)
							{
								if (flag2)
								{
									if (!flag)
									{
										if (flag3)
										{
											if (flag4)
											{
												return null;
											}
											flag = true;
										}
										else
										{
											flag = !flag4 && int_4 < 0 && int_5 < 0 && int_3 < 0;
											method_22(int_, int_13);
											if (int_4 < 0)
											{
												if (!flag)
												{
													return null;
												}
											}
											else
											{
												flag3 = true;
												flag = false;
											}
										}
									}
									if (flag)
									{
										method_23(int_, int_13);
										if (int_7 < 0)
										{
											return null;
										}
										flag = false;
										flag4 = true;
									}
								}
								else if (flag)
								{
									method_3(bool_0: true);
									if (int_7 < 0)
									{
										return null;
									}
									flag = false;
									flag4 = true;
								}
								else
								{
									method_8();
									if (int_4 < 0)
									{
										return null;
									}
									flag3 = true;
								}
								method_1(int_2[int_10 - 1], int_13, bool_0: false);
								int_10 = 0;
								int_ = int_13;
								flag2 = false;
							}
							num3 = int_13;
							num = 0;
							break;
						}
						continue;
					}
					if (!flag3)
					{
						num2 = interface4_0.imethod_6(char_0, int_13);
						if (num2 > 0)
						{
							if (int_3 > -1)
							{
								return null;
							}
							if (flag)
							{
								int_3 = 0;
							}
							else
							{
								int_3 = int_10;
							}
						}
						else
						{
							num2 = interface4_0.imethod_8(char_0, int_13);
							if (num2 > 0)
							{
								if (int_4 > -1)
								{
									return null;
								}
								if (flag)
								{
									int_4 = 0;
								}
								else
								{
									int_4 = int_10;
								}
							}
							else
							{
								num2 = interface4_0.imethod_10(char_0, int_13);
								if (num2 > 0)
								{
									if (int_5 > -1)
									{
										return null;
									}
									if (flag)
									{
										int_5 = 0;
									}
									else
									{
										int_5 = int_10;
									}
								}
							}
						}
						if (num2 > 0)
						{
							if (flag)
							{
								if (int_10 <= 1)
								{
									return null;
								}
								if (flag2)
								{
									method_23(int_, int_13);
								}
								else
								{
									method_3(bool_0: true);
								}
								if (int_7 < 0)
								{
									return null;
								}
								method_1(int_2[int_10 - 1], int_13 + num2, bool_0: false);
								flag = false;
								flag4 = true;
								int_10 = 0;
								int_ = int_13;
								flag2 = false;
							}
							int_13 += num2;
							num3 = int_13;
							num = 0;
							continue;
						}
					}
					if (!flag4)
					{
						num2 = interface4_0.imethod_12(char_0, int_13);
						if (num2 > 0)
						{
							if (int_6 > -1)
							{
								return null;
							}
							if (!flag)
							{
								int_6 = 0;
							}
							else
							{
								int_6 = int_10;
							}
						}
						else
						{
							num2 = interface4_0.imethod_14(char_0, int_13);
							if (num2 > 0)
							{
								if (int_7 > -1)
								{
									return null;
								}
								if (!flag)
								{
									int_7 = 0;
								}
								else
								{
									int_7 = int_10;
								}
							}
							else
							{
								num2 = interface4_0.imethod_16(char_0, int_13);
								if (num2 > 0)
								{
									if (int_8 > -1)
									{
										return null;
									}
									if (flag)
									{
										int_8 = 0;
									}
									else
									{
										int_8 = int_10;
									}
								}
							}
						}
						if (num2 > 0)
						{
							if (!flag)
							{
								if (int_10 > 1)
								{
									if (flag2)
									{
										method_22(int_, int_13);
									}
									else
									{
										method_8();
									}
									if (int_4 < 0)
									{
										return null;
									}
									method_1(int_2[int_10 - 1], int_13 + num2, bool_0: false);
									flag3 = true;
									int_10 = 0;
									int_ = int_13;
									flag2 = false;
								}
								else
								{
									if (int_10 > 0)
									{
										return null;
									}
									method_1(int_13, int_13 + num2, bool_0: false);
								}
								flag = true;
							}
							int_13 += num2;
							num3 = int_13;
							num = 0;
							continue;
						}
					}
					if (b == 0)
					{
						stringBuilder_1.Length = 0;
						num2 = interface4_0.imethod_18(char_0, int_13, stringBuilder_1);
						if (num2 > 0)
						{
							b = 1;
						}
						else
						{
							num2 = interface4_0.imethod_19(char_0, int_13, stringBuilder_1);
							if (num2 > 0)
							{
								b = 2;
							}
						}
						if (num2 > 0)
						{
							if (int_10 > 1)
							{
								if (flag2)
								{
									if (!flag3 && !flag)
									{
										flag = !flag4 && int_4 < 0 && int_5 < 0 && int_3 < 0;
										method_22(int_, int_13);
										if (int_4 < 0)
										{
											if (!flag)
											{
												return null;
											}
										}
										else
										{
											flag3 = true;
											flag = false;
										}
									}
									if (flag)
									{
										method_23(int_, int_13);
										if (int_7 < 0)
										{
											return null;
										}
										flag = false;
										flag4 = true;
									}
								}
								else if (flag)
								{
									method_3(bool_0: true);
									if (int_7 < 0)
									{
										return null;
									}
									flag = false;
									flag4 = true;
								}
								else
								{
									method_8();
									if (int_4 < 0)
									{
										return null;
									}
									flag3 = true;
								}
								method_1(int_2[int_10 - 1], int_13, bool_0: false);
								int_10 = 0;
								int_ = int_13 + num2;
								flag2 = false;
							}
							else if (int_10 > 0)
							{
								return null;
							}
							stringBuilder_0.Append(stringBuilder_1);
							int_13 += num2;
							num3 = int_13;
							num = 0;
							continue;
						}
					}
					if (flag)
					{
						if (c != '.' && c != class529_0.method_2())
						{
							flag2 = true;
							int_13++;
							num3 = int_13;
							num = 0;
							continue;
						}
						if (int_10 >= 2 && int_13 != num3 && num <= 60)
						{
							if (flag2)
							{
								method_23(int_, int_13);
							}
							else
							{
								method_3(bool_0: false);
							}
							if (int_7 >= 0)
							{
								flag = false;
								flag4 = true;
								stringBuilder_0.Append('.');
								int_10 = 0;
								int_13++;
								num3 = int_13;
								num = 0;
								while (int_13 < Math.Min(int_12, num3 + 3))
								{
									c = char_0[int_13];
									if (c < '0' || c > '9')
									{
										break;
									}
									num = num * 10 + (c - 48);
									int_13++;
								}
								if (int_13 > num3)
								{
									switch (int_13 - num3)
									{
									case 1:
										num *= 100;
										stringBuilder_0.Append('0');
										break;
									case 2:
										num *= 10;
										stringBuilder_0.Append("00");
										break;
									case 3:
										stringBuilder_0.Append("000");
										break;
									}
									int_9 = num;
									num = 0;
									num3 = int_13;
								}
								int_ = int_13;
								flag2 = false;
								continue;
							}
							return null;
						}
						return null;
					}
					if (!flag3)
					{
						if (c != ',' && c != class529_0.method_3())
						{
							if (int_10 < 3 && (int_4 < 0 || int_4 == int_10))
							{
								num2 = interface4_0.imethod_20(char_0, int_13);
								if (num2 != 0)
								{
									int_0[int_10] = ((num2 >> 1) & 0x7FFFFFFF) >> 27;
									int_1[int_10] = int_13;
									num2 &= 0xFFFFFFF;
									int_13 += num2;
									int_2[int_10] = int_13;
									if (int_13 < int_12 && char_0[int_13] == ' ')
									{
										while (true)
										{
											int_13++;
											if (int_13 >= int_12)
											{
												break;
											}
											if (char_0[int_13] != ' ')
											{
												if (!method_21(char_0[int_13]))
												{
													int_13--;
												}
												break;
											}
										}
									}
									if (int_13 == int_12 || (int_13 < int_12 && method_21(char_0[int_13])))
									{
										int_4 = int_10;
										int_10++;
										if (int_13 < int_12 && char_0[int_13] != ' ')
										{
											int_13++;
										}
										num3 = int_13;
										num = 0;
										continue;
									}
									int_13 -= num2;
								}
								if (int_4 == int_10)
								{
									return null;
								}
							}
							if (flag2)
							{
								if (int_13 - ((int_10 > 0) ? int_2[int_10 - 1] : int_11) > 20)
								{
									return null;
								}
							}
							else
							{
								flag2 = true;
							}
							int_13++;
							num3 = int_13;
							num = 0;
							continue;
						}
						if (int_10 == 2)
						{
							if (int_4 < 0)
							{
								return null;
							}
							if (int_4 >= int_10 || int_2[int_4] - int_1[int_4] < 3)
							{
								return null;
							}
							int_5 = 1 - int_4;
						}
						else
						{
							if (int_10 != 1)
							{
								break;
							}
							if (int_4 < 0)
							{
								int_5 = 0;
								int_4 = 1;
							}
							else if (int_4 != 0)
							{
								return null;
							}
						}
						int_1[int_10] = int_13;
						for (int i = 0; i < int_10; i++)
						{
							for (int j = int_2[i]; j < int_1[i + 1]; j++)
							{
								if (char_0[j] != ' ')
								{
									return null;
								}
							}
						}
						if (int_5 <= -1 || int_5 >= int_10 || (int_0[int_5] >= 1 && int_0[int_5] <= 31))
						{
							int_13++;
							num3 = int_13;
							num = 0;
							continue;
						}
						return null;
					}
					return null;
				}
				if (int_10 > 0)
				{
					if (flag3 && flag4)
					{
						return null;
					}
					if (int_13 > num3)
					{
						int_0[int_10] = num;
						int_1[int_10] = num3;
						int_2[int_10] = int_13;
						int_10++;
					}
					if (int_10 < 2)
					{
						return null;
					}
					if (flag2)
					{
						if (!flag3 && !flag)
						{
							flag = !flag4 && int_4 < 0 && int_5 < 0 && int_3 < 0;
							method_22(int_, int_13);
							if (int_4 < 0)
							{
								if (!flag)
								{
									return null;
								}
							}
							else
							{
								flag3 = true;
								flag = false;
							}
						}
						if (flag)
						{
							method_23(int_, int_13);
							if (int_7 < 0)
							{
								return null;
							}
							flag = false;
							flag4 = true;
						}
					}
					else if (flag)
					{
						method_3(bool_0: true);
						if (int_7 < 0)
						{
							return null;
						}
						flag = false;
						flag4 = true;
					}
					else
					{
						if (flag3)
						{
							return null;
						}
						if (int_3 < 0)
						{
							for (int k = int_2[int_10 - 1]; k < int_13; k++)
							{
								if (char_0[k] == ',' || char_0[k] == class529_0.method_3())
								{
									return null;
								}
							}
						}
						method_8();
						if (int_4 < 0)
						{
							return null;
						}
						flag3 = true;
					}
					method_1(int_2[int_10 - 1], int_13, bool_0: false);
				}
				else if (int_13 > num3)
				{
					return null;
				}
				if (b > 0)
				{
					if (int_7 < 0 || int_6 < 0 || int_6 > 12)
					{
						return null;
					}
					if (b == 1)
					{
						if (int_6 == 12)
						{
							int_6 = 0;
						}
					}
					else if (int_6 < 12)
					{
						int_6 += 12;
					}
				}
				if (int_4 < 0)
				{
					if (int_7 < 0)
					{
						return null;
					}
					double num5 = 0.0;
					if (int_6 > -1)
					{
						num5 = int_6;
					}
					num5 += (double)int_7 / 60.0;
					if (int_8 > -1)
					{
						num5 += (double)int_8 / 3600.0;
					}
					if (int_9 > -1)
					{
						num5 += (double)int_9 / 3600000.0;
					}
					class530_0.method_0(CellValueType.IsDateTime, Class428.GetDateTimeFromDouble(num5 / 24.0, bool_0: false));
				}
				else if (int_6 > 23)
				{
					DateTime dateTime = new DateTime(int_3, int_4, (int_5 <= -1) ? 1 : int_5, 0, (int_7 > -1) ? int_7 : 0, (int_8 > -1) ? int_8 : 0, (int_9 > -1) ? int_9 : 0);
					class530_0.method_0(CellValueType.IsDateTime, dateTime.AddHours(int_6));
				}
				else
				{
					class530_0.method_0(CellValueType.IsDateTime, new DateTime(int_3, int_4, (int_5 <= -1) ? 1 : int_5, (int_6 > -1) ? int_6 : 0, (int_7 > -1) ? int_7 : 0, (int_8 > -1) ? int_8 : 0, (int_9 > -1) ? int_9 : 0));
				}
				class530_0.method_2(stringBuilder_0.ToString());
				return class530_0.Value;
			}
			return null;
		}
		return null;
	}

	internal Class530 method_0()
	{
		return class530_0;
	}

	private void method_1(int int_14, int int_15, bool bool_0)
	{
		if (int_14 == int_15)
		{
			return;
		}
		bool flag;
		if (flag = stringBuilder_0.Length > 0 && stringBuilder_0[stringBuilder_0.Length - 1] == '"')
		{
			stringBuilder_0.Length -= 1;
		}
		while (int_14 < int_15)
		{
			switch (char_0[int_14])
			{
			default:
				if (!flag)
				{
					stringBuilder_0.Append('"');
					flag = true;
				}
				break;
			case '/':
				if (bool_0 && char_0[int_14] != class529_0.method_5())
				{
					if (!flag)
					{
						stringBuilder_0.Append('\\');
					}
				}
				else if (flag)
				{
					stringBuilder_0.Append('"');
					flag = false;
				}
				break;
			case ' ':
			case ',':
			case '-':
			case '.':
			case ':':
				if (flag)
				{
					stringBuilder_0.Append('"');
					flag = false;
				}
				break;
			}
			stringBuilder_0.Append(char_0[int_14]);
			int_14++;
		}
		if (flag)
		{
			stringBuilder_0.Append('"');
		}
	}

	private void method_2(int int_14, bool bool_0)
	{
		if (int_14 < int_10 - 1)
		{
			method_1(int_2[int_14], int_1[int_14 + 1], bool_0);
		}
	}

	private void method_3(bool bool_0)
	{
		if (int_10 > 2)
		{
			if (int_6 < 0)
			{
				if (int_7 > -1 || int_8 > -1)
				{
					int_7 = -1;
					return;
				}
				int_6 = 0;
				int_7 = 1;
				int_8 = 2;
			}
			else if (int_7 < 0 || int_8 < 0)
			{
				int_7 = -1;
				return;
			}
		}
		else
		{
			if (int_10 <= 1)
			{
				int_7 = -1;
				return;
			}
			if (int_7 < 0)
			{
				if (int_6 >= 0)
				{
					int_7 = -1;
					return;
				}
				if (int_8 >= 0)
				{
					int_7 = -1;
					return;
				}
				if (bool_0)
				{
					int_6 = 0;
					int_7 = 1;
				}
				else
				{
					int_7 = 0;
					int_8 = 1;
				}
			}
			else if (int_6 < 0 && int_8 < 0)
			{
				int_7 = -1;
				return;
			}
		}
		method_4();
		if (int_7 < 0)
		{
			return;
		}
		int num = 0;
		int_7 = int_0[int_7];
		if (int_7 == 60)
		{
			num++;
		}
		if (int_6 > -1)
		{
			int_6 = int_0[int_6];
			if (int_6 == 60)
			{
				num++;
			}
		}
		if (int_8 > -1)
		{
			int_8 = int_0[int_8];
			if (int_8 == 60)
			{
				num++;
			}
		}
		if (num > 1)
		{
			int_7 = -1;
		}
	}

	private void method_4()
	{
		switch (int_6)
		{
		case 0:
			switch (int_7)
			{
			default:
				int_7 = -1;
				break;
			case 1:
				if (int_8 > -1 && int_8 != 2)
				{
					int_7 = -1;
					break;
				}
				method_5();
				method_6();
				method_7();
				break;
			case 2:
				if (int_8 != 1)
				{
					int_7 = -1;
					break;
				}
				method_5();
				method_7();
				method_6();
				break;
			}
			return;
		case 1:
			switch (int_7)
			{
			case 0:
				if (int_8 > -1 && int_8 != 2)
				{
					int_7 = -1;
					break;
				}
				method_6();
				method_5();
				method_7();
				break;
			default:
				int_7 = -1;
				break;
			case 2:
				if (int_8 != 0)
				{
					int_7 = -1;
					break;
				}
				method_7();
				method_5();
				method_6();
				break;
			}
			return;
		}
		switch (int_7)
		{
		default:
			int_7 = -1;
			break;
		case 0:
			if (int_8 != 1)
			{
				int_7 = -1;
				break;
			}
			method_6();
			method_7();
			method_5();
			break;
		case 1:
			if (int_8 != 0)
			{
				int_7 = -1;
				break;
			}
			method_7();
			method_6();
			method_5();
			break;
		}
	}

	private void method_5()
	{
		if (int_6 >= 0)
		{
			if (int_0[int_6] > 23)
			{
				stringBuilder_0.Append("[h]");
			}
			else if (int_0[int_6] < 10 && int_2[int_6] - int_1[int_6] > 1)
			{
				stringBuilder_0.Append("hh");
			}
			else
			{
				stringBuilder_0.Append('h');
			}
			method_2(int_6, bool_0: false);
		}
	}

	private void method_6()
	{
		if (int_2[int_7] - int_1[int_7] > 1 && (int_0[int_7] < 10 || (int_8 > -1 && int_0[int_8] < 10 && int_2[int_8] - int_1[int_8] > 1)))
		{
			stringBuilder_0.Append("mm");
		}
		else
		{
			stringBuilder_0.Append('m');
		}
		method_2(int_7, bool_0: false);
	}

	private void method_7()
	{
		if (int_8 >= 0)
		{
			if (int_2[int_8] - int_1[int_8] > 1 && (int_0[int_8] < 10 || (int_7 > -1 && int_0[int_7] < 10 && int_2[int_7] - int_1[int_7] > 1)))
			{
				stringBuilder_0.Append("ss");
			}
			else
			{
				stringBuilder_0.Append('s');
			}
			method_2(int_8, bool_0: false);
		}
	}

	private void method_8()
	{
		if (int_10 < 2)
		{
			return;
		}
		if (int_3 < 0)
		{
			for (int i = 0; i < int_10; i++)
			{
				if (int_0[i] > 31)
				{
					int_3 = i;
					break;
				}
			}
		}
		if (int_5 < 0 && int_3 > -1)
		{
			for (int j = 0; j < int_10; j++)
			{
				if (j != int_3 && int_0[j] > 12)
				{
					int_5 = j;
					break;
				}
			}
		}
		switch (int_10)
		{
		case 2:
			switch (int_3)
			{
			default:
				switch (int_4)
				{
				default:
					switch (int_5)
					{
					default:
						int_4 = ((!method_9()) ? 1 : 0);
						int_5 = 1 - int_4;
						if (!method_14())
						{
							int_5 = int_4;
							int_4 = 1 - int_5;
							if (!method_14())
							{
								int_4 = -1;
								return;
							}
						}
						if (!method_15())
						{
							int_3 = int_5;
							int_5 = -1;
							if (!method_13())
							{
								int_4 = -1;
								return;
							}
							if (int_4 == 0)
							{
								method_17();
								method_16();
							}
							else
							{
								method_16();
								method_17();
							}
						}
						else if (int_4 == 0)
						{
							method_17();
							method_18();
						}
						else
						{
							method_18();
							method_17();
						}
						break;
					case 0:
						int_4 = 1;
						if (method_14() && method_15())
						{
							method_18();
							method_17();
							break;
						}
						int_4 = -1;
						return;
					case 1:
						int_4 = 0;
						if (method_14() && method_15())
						{
							method_17();
							method_18();
							break;
						}
						int_4 = -1;
						return;
					}
					break;
				case 0:
					if (!method_14())
					{
						int_4 = -1;
						return;
					}
					int_5 = 1;
					if (method_15())
					{
						method_17();
						method_18();
						break;
					}
					int_5 = -1;
					int_3 = 1;
					if (!method_13())
					{
						int_4 = -1;
						return;
					}
					method_17();
					method_16();
					break;
				case 1:
					if (!method_14())
					{
						int_4 = -1;
						return;
					}
					int_5 = 0;
					if (method_15())
					{
						method_18();
						method_17();
						break;
					}
					int_5 = -1;
					int_3 = 0;
					if (!method_13())
					{
						int_4 = -1;
						return;
					}
					method_16();
					method_17();
					break;
				}
				break;
			case 0:
				int_4 = 1;
				if (method_13() && method_14())
				{
					method_16();
					method_17();
					break;
				}
				int_4 = -1;
				return;
			case 1:
				int_4 = 0;
				if (method_13() && method_14())
				{
					method_17();
					method_16();
					break;
				}
				int_4 = -1;
				return;
			}
			break;
		case 3:
			switch (int_3)
			{
			default:
				switch (int_4)
				{
				default:
					switch (int_5)
					{
					default:
						method_19();
						if (int_4 < 0)
						{
							return;
						}
						break;
					case 0:
						if ((int_0[2] < 10 && int_2[2] - int_1[2] == 1) || class529_0.method_4() == Enum23.const_5)
						{
							int_4 = 2;
						}
						else
						{
							int_4 = 1;
						}
						int_3 = 3 - int_4;
						if (!method_13())
						{
							int_4 = -1;
							return;
						}
						if (!method_14())
						{
							int_3 = int_4;
							int_4 = 3 - int_3;
							if (!method_13() || !method_14())
							{
								int_4 = -1;
								return;
							}
						}
						method_18();
						if (int_4 == 1)
						{
							method_17();
							method_16();
						}
						else
						{
							method_16();
							method_17();
						}
						break;
					case 1:
						if ((int_0[2] < 10 && int_2[2] - int_1[2] == 1) || class529_0.method_4() == Enum23.const_3)
						{
							int_4 = 2;
						}
						else
						{
							int_4 = 1;
						}
						int_3 = 2 - int_4;
						if (!method_13())
						{
							int_4 = -1;
							return;
						}
						if (!method_14())
						{
							int_3 = int_4;
							int_4 = 2 - int_3;
							if (!method_13() || !method_14())
							{
								int_4 = -1;
								return;
							}
						}
						if (int_4 == 0)
						{
							method_17();
							method_18();
							method_16();
						}
						else
						{
							method_16();
							method_18();
							method_17();
						}
						break;
					case 2:
						if ((int_0[0] < 10 && int_2[1] - int_1[0] == 1) || class529_0.method_4() == Enum23.const_4)
						{
							int_4 = 0;
						}
						else
						{
							int_4 = 1;
						}
						int_3 = 1 - int_4;
						if (!method_13())
						{
							int_4 = -1;
							return;
						}
						if (!method_14())
						{
							int_3 = int_4;
							int_4 = 1 - int_3;
							if (!method_13() || !method_14())
							{
								int_4 = -1;
								return;
							}
						}
						if (int_4 == 0)
						{
							method_17();
							method_16();
						}
						else
						{
							method_16();
							method_17();
						}
						method_18();
						break;
					}
					break;
				case 0:
				{
					if (!method_14())
					{
						int_4 = -1;
						return;
					}
					bool flag3 = true;
					if (int_5 < 0)
					{
						if ((int_0[2] < 10 && int_2[2] - int_1[2] == 1) || class529_0.method_4() == Enum23.const_4)
						{
							int_5 = 2;
						}
						else
						{
							int_5 = 1;
						}
						int_3 = 3 - int_5;
						if (!method_13())
						{
							int_4 = -1;
							return;
						}
						if (method_15())
						{
							flag3 = false;
						}
						else
						{
							int_5 = int_3;
							int_3 = 3 - int_5;
						}
					}
					else
					{
						int_3 = 3 - int_5;
					}
					if (flag3 && (!method_13() || !method_15()))
					{
						int_4 = -1;
						return;
					}
					method_17();
					if (int_5 == 1)
					{
						method_18();
						method_16();
					}
					else
					{
						method_16();
						method_18();
					}
					break;
				}
				case 1:
				{
					if (!method_14())
					{
						int_4 = -1;
						return;
					}
					bool flag4 = true;
					if (int_5 < 0)
					{
						if (int_0[2] < 10 && int_2[2] - int_1[2] == 1)
						{
							int_5 = 2;
						}
						else
						{
							int_5 = ((!method_10() && int_2[1] - int_1[1] <= 2) ? 2 : 0);
						}
						int_3 = 2 - int_5;
						if (!method_13())
						{
							int_4 = -1;
							return;
						}
						if (method_15())
						{
							flag4 = false;
						}
						else
						{
							int_5 = int_3;
							int_3 = 2 - int_5;
						}
					}
					else
					{
						int_3 = 2 - int_5;
					}
					if (flag4 && (!method_13() || !method_15()))
					{
						int_4 = -1;
						return;
					}
					if (int_5 == 0)
					{
						method_18();
						method_17();
						method_16();
					}
					else
					{
						method_16();
						method_17();
						method_18();
					}
					break;
				}
				case 2:
				{
					if (!method_14())
					{
						int_4 = -1;
						return;
					}
					bool flag2 = true;
					if (int_5 < 0)
					{
						int_5 = ((!method_10()) ? 1 : 0);
						int_3 = 1 - int_5;
						if (!method_13())
						{
							int_4 = -1;
							return;
						}
						if (method_15())
						{
							flag2 = false;
						}
						else
						{
							int_5 = int_3;
							int_3 = 1 - int_5;
						}
					}
					else
					{
						int_3 = 1 - int_5;
					}
					if (flag2 && (!method_13() || !method_15()))
					{
						int_4 = -1;
						return;
					}
					if (int_5 == 0)
					{
						method_18();
						method_16();
					}
					else
					{
						method_16();
						method_18();
					}
					method_17();
					break;
				}
				}
				break;
			case 0:
			{
				if (!method_13())
				{
					int_4 = -1;
					return;
				}
				bool flag6 = true;
				if (int_4 < 0)
				{
					if (int_5 < 0)
					{
						int_4 = (method_9() ? 1 : 2);
						int_5 = 3 - int_4;
						if (!method_14())
						{
							int_5 = int_4;
							int_4 = 3 - int_5;
							if (!method_14())
							{
								int_4 = -1;
								return;
							}
						}
						if (!method_15())
						{
							int_4 = -1;
							return;
						}
						flag6 = false;
					}
					else
					{
						int_4 = 3 - int_5;
					}
				}
				else if (int_5 < 0)
				{
					int_5 = 3 - int_4;
				}
				if (flag6 && (!method_14() || !method_15()))
				{
					int_4 = -1;
					return;
				}
				method_16();
				if (int_4 == 1)
				{
					method_17();
					method_18();
				}
				else
				{
					method_18();
					method_17();
				}
				break;
			}
			case 1:
			{
				if (!method_13())
				{
					int_4 = -1;
					return;
				}
				bool flag5 = true;
				if (int_4 < 0)
				{
					if (int_5 < 0)
					{
						int_4 = ((!method_9()) ? 2 : 0);
						int_5 = 2 - int_4;
						if (!method_14())
						{
							int_5 = int_4;
							int_4 = 2 - int_5;
							if (!method_14())
							{
								int_4 = -1;
								return;
							}
						}
						if (!method_15())
						{
							int_4 = -1;
							return;
						}
						flag5 = false;
					}
					else
					{
						int_4 = 2 - int_5;
					}
				}
				else if (int_5 < 0)
				{
					int_5 = 2 - int_4;
				}
				if (flag5 && (!method_14() || !method_15()))
				{
					int_4 = -1;
					return;
				}
				if (int_4 == 0)
				{
					method_17();
					method_16();
					method_18();
				}
				else
				{
					method_18();
					method_16();
					method_17();
				}
				break;
			}
			case 2:
			{
				if (!method_13())
				{
					int_4 = -1;
					return;
				}
				bool flag = true;
				if (int_4 < 0)
				{
					if (int_5 < 0)
					{
						int_4 = ((!method_9()) ? 1 : 0);
						int_5 = 1 - int_4;
						if (!method_14())
						{
							int_5 = int_4;
							int_4 = 1 - int_5;
							if (!method_14())
							{
								int_4 = -1;
								return;
							}
						}
						if (!method_15())
						{
							int_4 = -1;
							return;
						}
						flag = false;
					}
					else
					{
						int_4 = 1 - int_5;
					}
				}
				else if (int_5 < 0)
				{
					int_5 = 1 - int_4;
				}
				if (flag && (!method_14() || !method_15()))
				{
					int_4 = -1;
					return;
				}
				if (int_4 == 0)
				{
					method_17();
					method_18();
				}
				else
				{
					method_18();
					method_17();
				}
				method_16();
				break;
			}
			}
			break;
		}
		if (int_4 >= 0)
		{
			int_4 = int_0[int_4];
			if (int_5 < 0)
			{
				int_5 = 1;
			}
			else
			{
				int_5 = int_0[int_5];
			}
			int_3 = method_12();
		}
	}

	private bool method_9()
	{
		switch (class529_0.method_4())
		{
		default:
			return true;
		case Enum23.const_1:
		case Enum23.const_3:
		case Enum23.const_5:
			return false;
		}
	}

	private bool method_10()
	{
		switch (class529_0.method_4())
		{
		default:
			return true;
		case Enum23.const_0:
		case Enum23.const_3:
		case Enum23.const_4:
			return false;
		}
	}

	private int method_11()
	{
		int num = int_0[int_4];
		if (num == 2)
		{
			if (!DateTime.IsLeapYear(method_12()))
			{
				return 28;
			}
			return 29;
		}
		if (num >= 8)
		{
			return 31 - num % 2;
		}
		return 30 + num % 2;
	}

	private int method_12()
	{
		int num;
		if (int_3 < 0)
		{
			num = DateTime.Today.Year;
		}
		else
		{
			num = int_0[int_3];
			if (int_2[int_3] - int_1[int_3] < 3)
			{
				num += class520_0.method_0();
			}
		}
		return num;
	}

	private bool method_13()
	{
		if (int_0[int_3] >= 0 && int_0[int_3] <= 9999)
		{
			switch (int_2[int_3] - int_1[int_3])
			{
			default:
				return false;
			case 2:
			case 4:
				return true;
			}
		}
		return false;
	}

	private bool method_14()
	{
		if (int_0[int_4] > 0 && int_0[int_4] < 13)
		{
			if (int_2[int_4] - int_1[int_4] >= 3)
			{
				return char_0[int_1[int_4]] != '0';
			}
			return true;
		}
		return false;
	}

	private bool method_15()
	{
		if (int_0[int_5] > 0 && int_0[int_5] <= method_11())
		{
			return int_2[int_5] - int_1[int_5] < 3;
		}
		return false;
	}

	private void method_16()
	{
		if (int_2[int_3] - int_1[int_3] > 2)
		{
			stringBuilder_0.Append("yyyy");
		}
		else
		{
			stringBuilder_0.Append("yy");
		}
		method_2(int_3, bool_0: true);
	}

	private void method_17()
	{
		switch (int_2[int_4] - int_1[int_4])
		{
		default:
			stringBuilder_0.Append("mmmm");
			break;
		case 1:
			stringBuilder_0.Append('m');
			break;
		case 2:
			if (int_0[int_4] >= 10 && (int_5 <= -1 || int_0[int_5] >= 10 || int_2[int_5] - int_1[int_5] <= 1))
			{
				stringBuilder_0.Append('m');
			}
			else
			{
				stringBuilder_0.Append("mm");
			}
			break;
		case 3:
			stringBuilder_0.Append("mmm");
			break;
		}
		method_2(int_4, bool_0: true);
	}

	private void method_18()
	{
		int num = int_2[int_5] - int_1[int_5];
		if (num == 1)
		{
			stringBuilder_0.Append('d');
		}
		else if (int_0[int_5] >= 10 && (int_4 <= -1 || int_0[int_4] >= 10 || int_2[int_4] - int_1[int_4] != 2))
		{
			stringBuilder_0.Append('d');
		}
		else
		{
			stringBuilder_0.Append("dd");
		}
		method_2(int_5, bool_0: true);
	}

	private void method_19()
	{
		method_20(class529_0.method_4());
		if (int_4 > -1)
		{
			return;
		}
		switch (class529_0.method_4())
		{
		case Enum23.const_0:
			method_20(Enum23.const_2);
			if (int_4 <= -1)
			{
				method_20(Enum23.const_1);
				if (int_4 <= -1)
				{
					method_20(Enum23.const_3);
				}
			}
			break;
		case Enum23.const_1:
			method_20(Enum23.const_2);
			if (int_4 <= -1)
			{
				method_20(Enum23.const_0);
				if (int_4 <= -1)
				{
					method_20(Enum23.const_3);
				}
			}
			break;
		case Enum23.const_2:
			method_20(Enum23.const_1);
			if (int_4 <= -1)
			{
				method_20(Enum23.const_0);
				if (int_4 <= -1)
				{
					method_20(Enum23.const_3);
				}
			}
			break;
		case Enum23.const_3:
			method_20(Enum23.const_1);
			if (int_4 <= -1)
			{
				method_20(Enum23.const_0);
				if (int_4 <= -1)
				{
					method_20(Enum23.const_2);
				}
			}
			break;
		case Enum23.const_4:
			method_20(Enum23.const_5);
			if (int_4 > -1)
			{
				break;
			}
			method_20(Enum23.const_1);
			if (int_4 > -1)
			{
				break;
			}
			method_20(Enum23.const_2);
			if (int_4 <= -1)
			{
				method_20(Enum23.const_0);
				if (int_4 <= -1)
				{
					method_20(Enum23.const_3);
				}
			}
			break;
		case Enum23.const_5:
			method_20(Enum23.const_4);
			if (int_4 > -1)
			{
				break;
			}
			method_20(Enum23.const_1);
			if (int_4 > -1)
			{
				break;
			}
			method_20(Enum23.const_2);
			if (int_4 <= -1)
			{
				method_20(Enum23.const_0);
				if (int_4 <= -1)
				{
					method_20(Enum23.const_3);
				}
			}
			break;
		}
	}

	private void method_20(Enum23 enum23_0)
	{
		switch (enum23_0)
		{
		case Enum23.const_0:
			int_3 = 0;
			int_4 = 1;
			int_5 = 2;
			if (method_13() && method_14() && method_15())
			{
				method_16();
				method_17();
				method_18();
			}
			else
			{
				int_4 = -1;
			}
			break;
		case Enum23.const_1:
			int_5 = 0;
			int_4 = 1;
			int_3 = 2;
			if (method_13() && method_14() && method_15())
			{
				method_18();
				method_17();
				method_16();
			}
			else
			{
				int_4 = -1;
			}
			break;
		case Enum23.const_2:
			int_4 = 0;
			int_5 = 1;
			int_3 = 2;
			if (method_13() && method_14() && method_15())
			{
				method_17();
				method_18();
				method_16();
			}
			else
			{
				int_4 = -1;
			}
			break;
		case Enum23.const_3:
			int_3 = 0;
			int_5 = 1;
			int_4 = 2;
			if (method_13() && method_14() && method_15())
			{
				method_16();
				method_18();
				method_17();
			}
			else
			{
				int_4 = -1;
			}
			break;
		case Enum23.const_4:
			int_4 = 0;
			int_3 = 1;
			int_5 = 2;
			if (method_13() && method_14() && method_15())
			{
				method_17();
				method_16();
				method_18();
			}
			else
			{
				int_4 = -1;
			}
			break;
		case Enum23.const_5:
			int_5 = 0;
			int_3 = 1;
			int_4 = 2;
			if (method_13() && method_14() && method_15())
			{
				method_18();
				method_16();
				method_17();
			}
			else
			{
				int_4 = -1;
			}
			break;
		}
	}

	private bool method_21(char char_1)
	{
		switch (char_1)
		{
		default:
			if (char_1 == class529_0.method_3())
			{
				return true;
			}
			return false;
		case ' ':
		case ',':
		case '-':
		case '/':
			return true;
		}
	}

	private void method_22(int int_14, int int_15)
	{
		int_4 = -1;
	}

	private void method_23(int int_14, int int_15)
	{
		int_7 = -1;
	}

	public string GetFormat()
	{
		return class530_0.method_3();
	}
}
