using System;
using System.Collections.Generic;
using Aspose.Cells;
using ns1;

namespace ns12;

internal class Class1252
{
	internal static object smethod_0(double double_0, double double_1, string string_0)
	{
		if (!string_0.Equals("i") && !string_0.Equals("j"))
		{
			return ErrorType.Value;
		}
		return new Class1251(double_0, double_1, string_0).ToString();
	}

	internal static double smethod_1(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_60 == null)
			{
				Class1742.dictionary_60 = new Dictionary<string, int>(8)
				{
					{ "m", 0 },
					{ "mi", 1 },
					{ "Nmi", 2 },
					{ "in", 3 },
					{ "ft", 4 },
					{ "yd", 5 },
					{ "ang", 6 },
					{ "Pica", 7 }
				};
			}
			if (Class1742.dictionary_60.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return 39.37007874015748;
				case 1:
					return 63360.0;
				case 2:
					return 72913.38583;
				case 3:
					return 1.0;
				case 4:
					return 12.0;
				case 5:
					return 36.0;
				case 6:
					return 3.93701E-09;
				case 7:
					return 0.013888889;
				}
			}
		}
		return 1.0;
	}

	internal static object smethod_2(double double_0, string string_0, string string_1)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_61 == null)
			{
				Class1742.dictionary_61 = new Dictionary<string, int>(11)
				{
					{ "m", 0 },
					{ "mi", 1 },
					{ "Nmi", 2 },
					{ "in", 3 },
					{ "ft", 4 },
					{ "yd", 5 },
					{ "ang", 6 },
					{ "Pica", 7 },
					{ "F", 8 },
					{ "C", 9 },
					{ "K", 10 }
				};
			}
			if (Class1742.dictionary_61.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				{
					string key2;
					if ((key2 = string_1) != null)
					{
						if (Class1742.dictionary_62 == null)
						{
							Class1742.dictionary_62 = new Dictionary<string, int>(8)
							{
								{ "m", 0 },
								{ "mi", 1 },
								{ "Nmi", 2 },
								{ "in", 3 },
								{ "ft", 4 },
								{ "yd", 5 },
								{ "ang", 6 },
								{ "Pica", 7 }
							};
						}
						if (Class1742.dictionary_62.TryGetValue(key2, out var value2))
						{
							switch (value2)
							{
							case 0:
							case 1:
							case 2:
							case 3:
							case 4:
							case 5:
							case 6:
							case 7:
								return double_0 * (smethod_1(string_0) / smethod_1(string_1));
							}
						}
					}
					return ErrorType.NA;
				}
				case 8:
				case 9:
				case 10:
					switch (string_1)
					{
					case "F":
					case "C":
					case "K":
						return smethod_4(smethod_3(double_0, string_0), string_1);
					default:
						return ErrorType.NA;
					}
				}
			}
		}
		return double_0;
	}

	internal static double smethod_3(double double_0, string string_0)
	{
		return string_0 switch
		{
			"K" => double_0 - 273.15, 
			"C" => double_0, 
			"F" => (double_0 - 32.0) * 5.0 / 9.0, 
			_ => double_0, 
		};
	}

	internal static double smethod_4(double double_0, string string_0)
	{
		return string_0 switch
		{
			"K" => double_0 + 273.15, 
			"C" => double_0, 
			"F" => double_0 * 9.0 / 5.0 + 32.0, 
			_ => double_0, 
		};
	}

	internal static object smethod_5(string[] string_0)
	{
		Class1251 @class = new Class1251();
		for (int i = 0; i < string_0.Length; i++)
		{
			Class1251 class1251_ = new Class1251(string_0[i]);
			@class = @class.Add(class1251_);
		}
		return @class.ToString();
	}

	internal static object smethod_6(string string_0, string string_1)
	{
		Class1251 @class = new Class1251(string_0);
		Class1251 class1251_ = new Class1251(string_1);
		Class1251 class2 = @class.method_5(class1251_);
		return class2.ToString();
	}

	internal static object smethod_7(string string_0)
	{
		Class1251 @class = new Class1251(string_0);
		return @class.method_0();
	}

	internal static object smethod_8(string string_0)
	{
		Class1251 @class = new Class1251(string_0);
		return @class.method_1();
	}

	internal static object smethod_9(string[] string_0)
	{
		Class1251 @class = new Class1251(string_0[0]);
		for (int i = 1; i < string_0.Length; i++)
		{
			Class1251 class1251_ = new Class1251(string_0[i]);
			@class = @class.method_6(class1251_);
		}
		return @class.ToString();
	}

	internal static object smethod_10(string string_0, string string_1)
	{
		Class1251 @class = new Class1251(string_0);
		Class1251 class1251_ = new Class1251(string_1);
		Class1251 class2 = @class.method_7(class1251_);
		return class2.ToString();
	}

	internal static object smethod_11(string string_0)
	{
		Class1251 @class = new Class1251(string_0);
		return @class.method_8();
	}

	internal static object smethod_12(string string_0)
	{
		Class1251 @class = new Class1251(string_0);
		return @class.method_9().ToString();
	}

	internal static object smethod_13(string string_0)
	{
		Class1251 @class = new Class1251(string_0);
		Class1251 class1251_ = new Class1251(Math.Log(Math.E, 2.0), 0.0);
		Class1251 class2 = @class.method_9().method_6(class1251_);
		return class2.ToString();
	}

	internal static object smethod_14(string string_0)
	{
		Class1251 @class = new Class1251(string_0);
		Class1251 class1251_ = new Class1251(Math.Log10(Math.E), 0.0);
		Class1251 class2 = @class.method_9().method_6(class1251_);
		return class2.ToString();
	}

	internal static object smethod_15(string string_0)
	{
		Class1251 @class = new Class1251(string_0);
		return @class.method_10().ToString();
	}

	internal static object smethod_16(string string_0)
	{
		Class1251 @class = new Class1251(string_0);
		return @class.method_11().ToString();
	}

	internal static object smethod_17(string string_0)
	{
		Class1251 @class = new Class1251(string_0);
		return @class.method_12().ToString();
	}

	internal static object smethod_18(string string_0, double double_0)
	{
		Class1251 @class = new Class1251(string_0);
		return @class.method_13(double_0).ToString();
	}

	internal static object smethod_19(string string_0)
	{
		Class1251 @class = new Class1251(string_0);
		return @class.method_14().ToString();
	}

	internal static object smethod_20(string string_0)
	{
		Class1251 @class = new Class1251(string_0);
		return @class.method_15();
	}

	internal static object smethod_21(string string_0)
	{
		Class1251 @class = new Class1251(string_0);
		return @class.method_16().ToString();
	}

	internal static object smethod_22(double double_0, double double_1)
	{
		if (double_0 == double_1)
		{
			return 1;
		}
		return 0;
	}

	internal static object smethod_23(double double_0)
	{
		return smethod_22(double_0, 0.0);
	}

	internal static object smethod_24(double double_0, double double_1)
	{
		if (double_0 >= double_1)
		{
			return 1;
		}
		return 0;
	}

	internal static object smethod_25(double double_0)
	{
		return smethod_24(double_0, 0.0);
	}

	internal static object smethod_26(long long_0)
	{
		if (long_0.ToString().Length > 10)
		{
			return ErrorType.Number;
		}
		return smethod_60(long_0.ToString(), 2, 10);
	}

	internal static object smethod_27(long long_0, int int_0)
	{
		if (long_0.ToString().Length <= 10 && int_0 >= 0)
		{
			return smethod_59(long_0.ToString(), 2, 8, int_0);
		}
		return ErrorType.Number;
	}

	internal static object smethod_28(long long_0)
	{
		if (long_0.ToString().Length > 10)
		{
			return ErrorType.Number;
		}
		return smethod_60(long_0.ToString(), 2, 8);
	}

	internal static object smethod_29(long long_0, int int_0)
	{
		if (long_0.ToString().Length <= 10 && int_0 >= 0)
		{
			return smethod_59(long_0.ToString(), 2, 16, int_0);
		}
		return ErrorType.Number;
	}

	internal static object smethod_30(long long_0)
	{
		if (long_0.ToString().Length > 10)
		{
			return ErrorType.Number;
		}
		return smethod_60(long_0.ToString(), 2, 16);
	}

	internal static object smethod_31(long long_0)
	{
		if (long_0 <= 511 && long_0 >= -512)
		{
			return smethod_60(long_0.ToString(), 10, 2);
		}
		return ErrorType.Number;
	}

	internal static object smethod_32(long long_0, int int_0)
	{
		if (long_0 <= 511 && long_0 >= -512 && int_0 >= 0)
		{
			return smethod_59(long_0.ToString(), 10, 2, int_0);
		}
		return ErrorType.Number;
	}

	internal static object smethod_33(long long_0)
	{
		if (long_0 <= 535870911 && long_0 >= -536870912)
		{
			return smethod_60(long_0.ToString(), 10, 8);
		}
		return ErrorType.Number;
	}

	internal static object smethod_34(long long_0, int int_0)
	{
		if (long_0 <= 535870911 && long_0 >= -536870912 && int_0 >= 0)
		{
			return smethod_59(long_0.ToString(), 10, 8, int_0);
		}
		return ErrorType.Number;
	}

	internal static object smethod_35(long long_0)
	{
		if (long_0 <= 549755813887L && long_0 >= -549755813888L)
		{
			return smethod_60(long_0.ToString(), 10, 16);
		}
		return ErrorType.Number;
	}

	internal static object smethod_36(long long_0, int int_0)
	{
		if (long_0 <= 549755813887L && long_0 >= -549755813888L && int_0 >= 0)
		{
			return smethod_59(long_0.ToString(), 10, 16, int_0);
		}
		return ErrorType.Number;
	}

	internal static object smethod_37(string string_0)
	{
		if (string_0.Length > 10)
		{
			return ErrorType.Number;
		}
		if (string_0.Length == 3 && string_0.ToUpper().CompareTo("1FF") > 0)
		{
			return ErrorType.Number;
		}
		if (string_0.Length > 3 && string_0.Length < 10)
		{
			return ErrorType.Number;
		}
		if (string_0.Length == 10 && string_0.ToUpper()[0] == 'F' && string_0.ToUpper().CompareTo("FFFFFFFE00") < 0)
		{
			return ErrorType.Number;
		}
		return smethod_60(string_0, 16, 2);
	}

	internal static object smethod_38(string string_0, int int_0)
	{
		if (string_0.Length <= 10 && int_0 >= 0)
		{
			if (string_0.Length == 3 && string_0.ToUpper().CompareTo("1FF") > 0)
			{
				return ErrorType.Number;
			}
			if (string_0.Length > 3 && string_0.Length < 10)
			{
				return ErrorType.Number;
			}
			if (string_0.Length == 10 && string_0.ToUpper()[0] == 'F' && string_0.ToUpper().CompareTo("FFFFFFFE00") < 0)
			{
				return ErrorType.Number;
			}
			return smethod_59(string_0, 16, 2, int_0);
		}
		return ErrorType.Number;
	}

	internal static object smethod_39(string string_0)
	{
		if (string_0.Length > 10)
		{
			return ErrorType.Number;
		}
		return smethod_60(string_0, 16, 10);
	}

	internal static object smethod_40(string string_0)
	{
		if (string_0.Length > 10)
		{
			return ErrorType.Number;
		}
		if (string_0.Length == 8 && string_0.ToUpper().CompareTo("1FFFFFFF") > 0)
		{
			return ErrorType.Number;
		}
		if (string_0.Length > 8 && string_0.Length < 10)
		{
			return ErrorType.Number;
		}
		if (string_0.Length == 10 && string_0.ToUpper()[0] == 'F' && string_0.ToUpper().CompareTo("FFE0000000") < 0)
		{
			return ErrorType.Number;
		}
		return smethod_60(string_0, 16, 8);
	}

	internal static object smethod_41(string string_0, int int_0)
	{
		if (string_0.Length <= 10 && int_0 >= 0)
		{
			if (string_0.Length == 8 && string_0.ToUpper().CompareTo("1FFFFFFF") > 0)
			{
				return ErrorType.Number;
			}
			if (string_0.Length > 8 && string_0.Length < 10)
			{
				return ErrorType.Number;
			}
			if (string_0.Length == 10 && string_0.ToUpper()[0] == 'F' && string_0.ToUpper().CompareTo("FFE0000000") < 0)
			{
				return ErrorType.Number;
			}
			return smethod_59(string_0, 16, 8, int_0);
		}
		return ErrorType.Number;
	}

	internal static object smethod_42(long long_0)
	{
		if (long_0.ToString().Length > 10)
		{
			return ErrorType.Number;
		}
		if (long_0.ToString().Length < 10 && long_0 > 777)
		{
			return ErrorType.Number;
		}
		if (long_0.ToString().Length == 10 && long_0 > 7777777000L)
		{
			return ErrorType.Number;
		}
		return smethod_60(long_0.ToString(), 8, 2);
	}

	internal static object smethod_43(long long_0, int int_0)
	{
		if (long_0.ToString().Length <= 10 && int_0 >= 0)
		{
			if (long_0.ToString().Length < 10 && long_0 > 777)
			{
				return ErrorType.Number;
			}
			if (long_0.ToString().Length == 10 && long_0 > 7777777000L)
			{
				return ErrorType.Number;
			}
			return smethod_59(long_0.ToString(), 8, 2, int_0);
		}
		return ErrorType.Number;
	}

	internal static object smethod_44(long long_0)
	{
		if (long_0.ToString().Length > 10)
		{
			return ErrorType.Number;
		}
		return smethod_60(long_0.ToString(), 8, 10);
	}

	internal static object smethod_45(long long_0)
	{
		if (long_0.ToString().Length > 10)
		{
			return ErrorType.Number;
		}
		return smethod_60(long_0.ToString(), 8, 16);
	}

	internal static object smethod_46(long long_0, int int_0)
	{
		if (long_0.ToString().Length > 10)
		{
			return ErrorType.Number;
		}
		return smethod_59(long_0.ToString(), 8, 16, int_0);
	}

	internal static object smethod_47(double double_0, double double_1)
	{
		if (!(double_0 < 0.0) && double_1 >= 0.0)
		{
			double num = smethod_50(double_1) - smethod_50(double_0);
			return num;
		}
		return ErrorType.Number;
	}

	internal static object smethod_48(double double_0)
	{
		if (double_0 < 0.0)
		{
			return ErrorType.Number;
		}
		double num = smethod_50(double_0);
		return num;
	}

	internal static object smethod_49(double double_0)
	{
		if (double_0 < 0.0)
		{
			return ErrorType.Number;
		}
		double num = 1.0 - smethod_50(double_0);
		return num;
	}

	internal static double smethod_50(double double_0)
	{
		double[] array = new double[65]
		{
			5.958930743E-11, -1.13739022964E-09, 1.466005199839E-08, -1.635035446196E-07, 1.6461004480962E-06, -1.492559551950604E-05, 0.00012055331122299264, -0.0008548326981129666, 0.005223977624823223, -0.026866170645077334,
			0.11283791670954882, -0.3761263890318375, 1.1283791670955126, 2.372510631E-11, -4.5493253732E-10, 5.90362766598E-09, -6.642090827576E-08, 6.7595634268133E-07, -6.21188515924E-06, 5.10388300970969E-05,
			-0.00037015410692956176, 0.00233307631218881, -0.012549884771821921, 0.05657061146827042, -0.21379664776456006, 0.8427007929497149, 9.49905026E-12, -1.8310229805E-10, 2.39463074E-09, -2.721444369609E-08,
			2.8045522331686E-07, -2.61830022482897E-06, 2.195455056768781E-05, -0.00016358986921372656, 0.0010705215356411031, -0.006082847181135901, 0.029869784652462584, -0.13055593046562267, 0.674933236039655, 3.82722073E-12,
			-7.421598602E-11, 9.793057408E-10, -1.126008898854E-08, 1.1775134830784E-07, -1.1199275838265E-06, 9.62023443095201E-06, -7.404402135070773E-05, 0.0005068999365414488, -0.003075530514392729, 0.016689778925531657,
			-0.08548534594781312, 0.5690907664239364, 1.55296588E-12, -3.032205868E-11, 4.0424830707E-10, -4.71135111493E-09, 5.011915876293E-08, -4.8722516178974E-07, 4.30683284629395E-06, -3.445026145385764E-05,
			0.00024879276133931664, -0.0016294094174807928, 0.009887863739323505, -0.05962426839442304, 0.49766113250947636
		};
		double[] array2 = new double[65]
		{
			-2.9734388465E-10, 2.69776334046E-09, -6.40788827665E-09, -1.6678201321E-08, -2.1854388148686E-07, 2.66246030457984E-06, 1.612722157047886E-05, -0.00025616361025506627, 0.00015380842432375364, 0.00815533022524928,
			-0.014022836638963193, -0.19746892495383023, 0.7151172032884284, -1.951073787E-11, -3.2302692214E-10, 5.22461866919E-09, 3.42940918551E-09, -3.5772874310272E-07, 1.9999935792654E-07, 2.687044575042908E-05,
			-0.00011843240273775776, -0.0008099172895603227, 0.006610629705022412, 0.009095309223548273, -0.20160072778491014, 0.5116969671872764, 3.147682272E-11, -4.8465972408E-10, 6.3675740242E-10, 3.377623323271E-08,
			-1.5451139637086E-07, -2.03340624738438E-06, 1.947204525295057E-05, 2.854147231653228E-05, -0.0010156506315220028, 0.0027118700352009566, 0.023280950354228107, -0.16725021123116876, 0.32490054966649434, 2.31936337E-11,
			-6.303206648E-11, -2.64888267434E-09, 2.050708040581E-08, 1.1371857327578E-07, -2.11211337219663E-06, 3.68797328322935E-06, 9.823686253424796E-05, -0.0006586024399045536, -0.0007528581489523087, 0.025854344242029606,
			-0.11637092784486193, 0.1826733677529661, -3.67789363E-12, 2.0876046746E-10, -1.93319027226E-09, -4.35953392472E-09, 1.8006992266137E-07, -7.8441223763969E-07, -6.75407647949153E-06, 8.428418334440096E-05,
			-0.00017604388937031816, -0.002397296114350716, 0.02064129023876023, -0.06905562880005864, 0.09084526782065479
		};
		double num = Math.Abs(double_0);
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = 0;
		if (num < 2.2)
		{
			num2 = num * num;
			num4 = (int)num2;
			num2 -= (double)num4;
			num4 *= 13;
			return ((((((((((((array[num4] * num2 + array[num4 + 1]) * num2 + array[num4 + 2]) * num2 + array[num4 + 3]) * num2 + array[num4 + 4]) * num2 + array[num4 + 5]) * num2 + array[num4 + 6]) * num2 + array[num4 + 7]) * num2 + array[num4 + 8]) * num2 + array[num4 + 9]) * num2 + array[num4 + 10]) * num2 + array[num4 + 11]) * num2 + array[num4 + 12]) * num;
		}
		if (num < 6.9)
		{
			num4 = (int)num;
			num2 = num - (double)num4;
			num4 = 13 * (num4 - 2);
			num3 = (((((((((((array2[num4] * num2 + array2[num4 + 1]) * num2 + array2[num4 + 2]) * num2 + array2[num4 + 3]) * num2 + array2[num4 + 4]) * num2 + array2[num4 + 5]) * num2 + array2[num4 + 6]) * num2 + array2[num4 + 7]) * num2 + array2[num4 + 8]) * num2 + array2[num4 + 9]) * num2 + array2[num4 + 10]) * num2 + array2[num4 + 11]) * num2 + array2[num4 + 12];
			num3 *= num3;
			num3 *= num3;
			num3 *= num3;
			return 1.0 - num3 * num3;
		}
		return 1.0;
	}

	internal static object smethod_51(double double_0, int int_0)
	{
		if (int_0 < 0)
		{
			return ErrorType.Number;
		}
		return smethod_52(double_0, int_0);
	}

	internal static double smethod_52(double double_0, int int_0)
	{
		int num = 0;
		int num2 = 0;
		double num3 = 0.0;
		double[] array = new double[6] { 57568490574.0, -13362590354.0, 651619640.7, -11214424.18, 77392.33017, -184.9052456 };
		double[] array2 = new double[6] { 57568490411.0, 1029532985.0, 9494680.718, 59272.64853, 267.8532712, 1.0 };
		double[] array3 = new double[6] { 72362614232.0, -7895059235.0, 242396853.1, -2972611.439, 15704.4826, -30.16036606 };
		double[] array4 = new double[6] { 144725228443.0, 2300535178.0, 18583304.74, 99447.43394, 376.9991397, 1.0 };
		double[] array5 = new double[5] { 1.0, -0.001098628627, 2.734510407E-05, -2.073370639E-06, 2.093887211E-07 };
		double[] array6 = new double[5] { -0.01562499995, 0.0001430488765, -6.911147651E-06, 7.621095161E-07, -9.34935152E-08 };
		double[] array7 = new double[5] { 1.0, 0.00183105, -3.516396496E-05, 2.457520174E-06, -2.40337019E-07 };
		double[] array8 = new double[5] { 0.04687499995, -0.0002002690873, 8.449199096E-06, -8.8228987E-07, 1.05787412E-07 };
		double num4 = Math.Abs(double_0);
		if (int_0 < 0)
		{
			int_0 = -int_0;
		}
		double num8;
		if (int_0 != 1)
		{
			if (num4 < 8.0)
			{
				double num5 = num4 * num4;
				num3 = array[5];
				double num6 = array2[5];
				for (num = 4; num >= 0; num--)
				{
					num3 = num3 * num5 + array[num];
					num6 = num6 * num5 + array2[num];
				}
				num3 /= num6;
			}
			else
			{
				double num7 = 8.0 / num4;
				double num5 = num7 * num7;
				num3 = array5[4];
				double num6 = array6[4];
				for (num = 3; num >= 0; num--)
				{
					num3 = num3 * num5 + array5[num];
					num6 = num6 * num5 + array6[num];
				}
				num8 = num4 - 0.785398164;
				num3 = num3 * Math.Cos(num8) - num7 * num6 * Math.Sin(num8);
				num3 *= Math.Sqrt(0.636619772 / num4);
			}
		}
		if (int_0 == 0)
		{
			return num3;
		}
		double num9 = num3;
		if (num4 < 8.0)
		{
			double num5 = num4 * num4;
			num3 = array3[5];
			double num6 = array4[5];
			for (num = 4; num >= 0; num--)
			{
				num3 = num3 * num5 + array3[num];
				num6 = num6 * num5 + array4[num];
			}
			num3 = double_0 * num3 / num6;
		}
		else
		{
			double num7 = 8.0 / num4;
			double num5 = num7 * num7;
			num3 = array7[4];
			double num6 = array8[4];
			for (num = 3; num >= 0; num--)
			{
				num3 = num3 * num5 + array7[num];
				num6 = num6 * num5 + array8[num];
			}
			num8 = num4 - 2.356194491;
			num3 = num3 * Math.Cos(num8) - num7 * num6 * Math.Sin(num8);
			num3 = num3 * double_0 * Math.Sqrt(0.636619772 / num4) / num4;
		}
		if (int_0 == 1)
		{
			return num3;
		}
		double num10 = num3;
		if (double_0 == 0.0)
		{
			return 0.0;
		}
		num8 = 2.0 / num4;
		if (num4 > 1.0 * (double)int_0)
		{
			if (double_0 < 0.0)
			{
				num10 = 0.0 - num10;
			}
			for (num = 1; num <= int_0 - 1; num++)
			{
				num3 = num8 * (double)num * num10 - num9;
				num9 = num10;
				num10 = num3;
			}
		}
		else
		{
			num2 = (int_0 + (int)Math.Sqrt(40.0 * (double)int_0)) / 2;
			num2 = 2 * num2;
			num3 = 0.0;
			double num6 = 0.0;
			num9 = 1.0;
			num10 = 0.0;
			for (num = num2 - 1; num >= 0; num--)
			{
				num4 = num8 * (double)(num + 1) * num9 - num10;
				num10 = num9;
				num9 = num4;
				if (Math.Abs(num9) > 10000000000.0)
				{
					num9 *= 1E-10;
					num10 *= 1E-10;
					num3 *= 1E-10;
					num6 *= 1E-10;
				}
				if ((num + 2) % 2 == 0)
				{
					num6 += num9;
				}
				if (num + 1 == int_0)
				{
					num3 = num10;
				}
			}
			num6 = 2.0 * num6 - num9;
			num3 /= num6;
		}
		if (double_0 < 0.0 && int_0 % 2 == 1)
		{
			num3 = 0.0 - num3;
		}
		return num3;
	}

	internal static object smethod_53(double double_0, int int_0)
	{
		if (int_0 < 0)
		{
			return ErrorType.Number;
		}
		return smethod_54(double_0, int_0);
	}

	internal static double smethod_54(double double_0, int int_0)
	{
		double num = 0.0;
		double[] array = new double[6] { -2957821389.0, 7062834065.0, -512359803.6, 10879881.29, -86327.92757, 228.4622733 };
		double[] array2 = new double[6] { 40076544269.0, 745249964.8, 7189466.438, 47447.2647, 226.1030244, 1.0 };
		double[] array3 = new double[6] { -4900604943000.0, 1275274390000.0, -51534381390.0, 734926455.1, -4237922.726, 8511.937935 };
		double[] array4 = new double[7] { 24995805700000.0, 424441966400.0, 3733650367.0, 22459040.02, 102042.605, 354.9632885, 1.0 };
		double[] array5 = new double[5] { 1.0, -0.001098628627, 2.734510407E-05, -2.073370639E-06, 2.093887211E-07 };
		double[] array6 = new double[5] { -0.01562499995, 0.0001430488765, -6.911147651E-06, 7.621095161E-07, -9.34935152E-08 };
		double[] array7 = new double[5] { 1.0, 0.00183105, -3.516396496E-05, 2.457520174E-06, -2.40337019E-07 };
		double[] array8 = new double[5] { 0.04687499995, -0.0002002690873, 8.449199096E-06, -8.8228987E-07, 1.05787412E-07 };
		if (int_0 < 0)
		{
			int_0 = -int_0;
		}
		if (double_0 < 0.0)
		{
			double_0 = 0.0 - double_0;
		}
		if (double_0 == 0.0)
		{
			return -1E+70;
		}
		double num6;
		if (int_0 != 1)
		{
			if (double_0 < 8.0)
			{
				double num2 = double_0 * double_0;
				num = array[5];
				double num3 = array2[5];
				for (int num4 = 4; num4 >= 0; num4--)
				{
					num = num * num2 + array[num4];
					num3 = num3 * num2 + array2[num4];
				}
				num = num / num3 + 0.636619772 * (double)smethod_51(double_0, 0) * Math.Log(double_0);
			}
			else
			{
				double num5 = 8.0 / double_0;
				double num2 = num5 * num5;
				num = array5[4];
				double num3 = array6[4];
				for (int num4 = 3; num4 >= 0; num4--)
				{
					num = num * num2 + array5[num4];
					num3 = num3 * num2 + array6[num4];
				}
				num6 = double_0 - 0.785398164;
				num = num * Math.Sin(num6) + num5 * num3 * Math.Cos(num6);
				num *= Math.Sqrt(0.636619772 / double_0);
			}
		}
		if (int_0 == 0)
		{
			return num;
		}
		double num7 = num;
		if (double_0 < 8.0)
		{
			double num2 = double_0 * double_0;
			num = array3[5];
			double num3 = array4[6];
			for (int num4 = 4; num4 >= 0; num4--)
			{
				num = num * num2 + array3[num4];
				num3 = num3 * num2 + array4[num4 + 1];
			}
			num3 = num3 * num2 + array4[0];
			num = double_0 * num / num3 + 0.636619772 * ((double)smethod_51(double_0, 1) * Math.Log(double_0) - 1.0 / double_0);
		}
		else
		{
			double num5 = 8.0 / double_0;
			double num2 = num5 * num5;
			num = array7[4];
			double num3 = array8[4];
			for (int num4 = 3; num4 >= 0; num4--)
			{
				num = num * num2 + array7[num4];
				num3 = num3 * num2 + array8[num4];
			}
			num6 = double_0 - 2.356194491;
			num = num * Math.Sin(num6) + num5 * num3 * Math.Cos(num6);
			num *= Math.Sqrt(0.636619772 / double_0);
		}
		if (int_0 == 1)
		{
			return num;
		}
		double num8 = num;
		num6 = 2.0 / double_0;
		for (int num4 = 1; num4 <= int_0 - 1; num4++)
		{
			num = num6 * (double)num4 * num8 - num7;
			num7 = num8;
			num8 = num;
		}
		return num;
	}

	internal static object smethod_55(double double_0, int int_0)
	{
		if (int_0 < 0)
		{
			return ErrorType.Number;
		}
		return smethod_56(double_0, int_0);
	}

	internal static double smethod_56(double double_0, int int_0)
	{
		double num = 0.0;
		double[] array = new double[7] { 1.0, 3.5156229, 3.0899424, 1.2067492, 0.2659732, 0.0360768, 0.0045813 };
		double[] array2 = new double[7] { 0.5, 0.87890594, 0.51498869, 0.15084934, 0.02658773, 0.00301532, 0.00032411 };
		double[] array3 = new double[9] { 0.39894228, 0.01328592, 0.00225319, -0.00157565, 0.00916281, -0.02057706, 0.02635537, -0.01647633, 0.00392377 };
		double[] array4 = new double[9] { 0.39894228, -0.03988024, -0.00362018, 0.00163801, -0.01031555, 0.02282967, -0.02895312, 0.01787654, -0.00420059 };
		if (int_0 < 0)
		{
			int_0 = -int_0;
		}
		double num2 = Math.Abs(double_0);
		double num3;
		if (int_0 != 1)
		{
			if (num2 < 3.75)
			{
				num3 = double_0 / 3.75 * (double_0 / 3.75);
				num = array[6];
				for (int num4 = 5; num4 >= 0; num4--)
				{
					num = num * num3 + array[num4];
				}
			}
			else
			{
				num3 = 3.75 / num2;
				num = array3[8];
				for (int num4 = 7; num4 >= 0; num4--)
				{
					num = num * num3 + array3[num4];
				}
				num = num * Math.Exp(num2) / Math.Sqrt(num2);
			}
		}
		if (int_0 == 0)
		{
			return num;
		}
		double num5 = num;
		if (num2 < 3.75)
		{
			num3 = double_0 / 3.75 * (double_0 / 3.75);
			num = array2[6];
			for (int num4 = 5; num4 >= 0; num4--)
			{
				num = num * num3 + array2[num4];
			}
			num *= num2;
		}
		else
		{
			num3 = 3.75 / num2;
			num = array4[8];
			for (int num4 = 7; num4 >= 0; num4--)
			{
				num = num * num3 + array4[num4];
			}
			num = num * Math.Exp(num2) / Math.Sqrt(num2);
		}
		if (double_0 < 0.0)
		{
			num = 0.0 - num;
		}
		if (int_0 == 1)
		{
			return num;
		}
		if (double_0 == 0.0)
		{
			return 0.0;
		}
		num3 = 2.0 / num2;
		num2 = 0.0;
		double num6 = 1.0;
		double num7 = 0.0;
		int num8 = int_0 + (int)Math.Sqrt(40.0 * (double)int_0);
		num8 = 2 * num8;
		for (int num4 = num8; num4 > 0; num4--)
		{
			num = num7 + (double)num4 * num3 * num6;
			num7 = num6;
			num6 = num;
			if (Math.Abs(num6) > 10000000000.0)
			{
				num2 *= 1E-10;
				num7 *= 1E-10;
				num6 *= 1E-10;
			}
			if (num4 == int_0)
			{
				num2 = num7;
			}
		}
		num = num2 * num5 / num6;
		if (double_0 < 0.0 && int_0 % 2 == 1)
		{
			num = 0.0 - num;
		}
		return num;
	}

	internal static object smethod_57(double double_0, int int_0)
	{
		if (int_0 < 0)
		{
			return ErrorType.Number;
		}
		return smethod_58(double_0, int_0);
	}

	internal static double smethod_58(double double_0, int int_0)
	{
		double num = 0.0;
		double[] array = new double[7] { -0.57721566, 0.4227842, 0.23069756, 0.0348859, 0.00262698, 0.0001075, 7.4E-06 };
		double[] array2 = new double[7] { 1.0, 0.15443144, -0.67278579, -0.18156897, -0.01919402, -0.00110404, -4.686E-05 };
		double[] array3 = new double[7] { 1.25331414, -0.07832358, 0.02189568, -0.01062446, 0.00587872, -0.0025154, 0.00053208 };
		double[] array4 = new double[7] { 1.25331414, 0.23498619, -0.0365562, 0.01504268, -0.00780353, 0.00325614, -0.00068245 };
		if (int_0 < 0)
		{
			int_0 = -int_0;
		}
		if (double_0 < 0.0)
		{
			double_0 = 0.0 - double_0;
		}
		if (double_0 == 0.0)
		{
			return 1E+70;
		}
		double num2;
		if (int_0 != 1)
		{
			if (double_0 <= 2.0)
			{
				num2 = double_0 * double_0 / 4.0;
				num = array[6];
				for (int num3 = 5; num3 >= 0; num3--)
				{
					num = num * num2 + array[num3];
				}
				num -= (double)smethod_55(double_0, 0) * Math.Log(double_0 / 2.0);
			}
			else
			{
				num2 = 2.0 / double_0;
				num = array3[6];
				for (int num3 = 5; num3 >= 0; num3--)
				{
					num = num * num2 + array3[num3];
				}
				num = num * Math.Exp(0.0 - double_0) / Math.Sqrt(double_0);
			}
		}
		if (int_0 == 0)
		{
			return num;
		}
		double num4 = num;
		if (double_0 <= 2.0)
		{
			num2 = double_0 * double_0 / 4.0;
			num = array2[6];
			for (int num3 = 5; num3 >= 0; num3--)
			{
				num = num * num2 + array2[num3];
			}
			num = num / double_0 + (double)smethod_55(double_0, 1) * Math.Log(double_0 / 2.0);
		}
		else
		{
			num2 = 2.0 / double_0;
			num = array4[6];
			for (int num3 = 5; num3 >= 0; num3--)
			{
				num = num * num2 + array4[num3];
			}
			num = num * Math.Exp(0.0 - double_0) / Math.Sqrt(double_0);
		}
		if (int_0 == 1)
		{
			return num;
		}
		double num5 = num;
		num2 = 2.0 / double_0;
		for (int num3 = 1; num3 < int_0; num3++)
		{
			num = num4 + (double)num3 * num2 * num5;
			num4 = num5;
			num5 = num;
		}
		return num;
	}

	internal static string smethod_59(string string_0, int int_0, int int_1, int int_2)
	{
		long num = 0L;
		string text = Convert.ToString(int_0 switch
		{
			2 => (string_0.Length != 10 || string_0[0] != '1') ? Convert.ToInt64(string_0, int_0) : (num - ((Convert.ToInt64(string_0.Substring(1, 9), int_0) ^ 0x1FF) + 1)), 
			8 => (string_0.Length != 10 || string_0[0] != '7') ? Convert.ToInt64(string_0, int_0) : (num - ((Convert.ToInt64(string_0.Substring(1, 9), int_0) ^ 0x7FFFFFF) + 1)), 
			16 => (string_0.Length != 10 || string_0.ToUpper()[0] != 'F') ? Convert.ToInt64(string_0, int_0) : (num - ((Convert.ToInt64(string_0.Substring(1, 9), int_0) ^ 0xFFFFFFFFFL) + 1)), 
			_ => Convert.ToInt64(string_0, int_0), 
		}, int_1).PadLeft(int_2, '0');
		if (text.Length > 10)
		{
			return text.Substring(text.Length - 10, 10).ToUpper();
		}
		return text.ToUpper();
	}

	internal static string smethod_60(string string_0, int int_0, int int_1)
	{
		long num = 0L;
		string text = Convert.ToString(int_0 switch
		{
			2 => (string_0.Length != 10 || string_0[0] != '1') ? Convert.ToInt64(string_0, int_0) : (num - ((Convert.ToInt64(string_0.Substring(1, 9), int_0) ^ 0x1FF) + 1)), 
			8 => (string_0.Length != 10 || string_0[0] != '7') ? Convert.ToInt64(string_0, int_0) : (num - ((Convert.ToInt64(string_0.Substring(1, 9), int_0) ^ 0x7FFFFFF) + 1)), 
			16 => (string_0.Length != 10 || string_0.ToUpper()[0] != 'F') ? Convert.ToInt64(string_0, int_0) : (num - ((Convert.ToInt64(string_0.Substring(1, 9), int_0) ^ 0xFFFFFFFFFL) + 1)), 
			_ => Convert.ToInt64(string_0, int_0), 
		}, int_1);
		if (text.Length > 10)
		{
			return text.Substring(text.Length - 10, 10).ToUpper();
		}
		return text.ToUpper();
	}
}
