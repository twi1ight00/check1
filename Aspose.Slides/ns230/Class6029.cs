using System;
using System.Collections;
using System.Text;
using ns225;
using ns226;
using ns227;
using ns229;

namespace ns230;

internal class Class6029 : Class6027, Interface257
{
	internal class Class6070 : Class6068
	{
		private Hashtable hashtable_0;

		public static Class6070 smethod_1(Class6110 header, Class6017 data)
		{
			return new Class6070(header, data);
		}

		protected Class6070(Class6110 header, Class6017 data)
			: base(header, data)
		{
		}

		protected Class6070(Class6110 header, Class6016 data)
			: base(header, data)
		{
		}

		private void Initialize(Class6016 data)
		{
			hashtable_0 = new Hashtable();
			if (data != null)
			{
				Class6029 @class = new Class6029(method_16(), data);
				Interface256 @interface = @class.imethod_0();
				while (@interface.imethod_0())
				{
					Class6103 nameEntry = (Class6103)@interface.imethod_1();
					Class6104 class2 = new Class6104(nameEntry);
					hashtable_0.Add(class2.method_0(), class2);
				}
			}
		}

		private Hashtable method_17()
		{
			if (hashtable_0 == null)
			{
				Initialize(method_6());
			}
			method_13();
			return hashtable_0;
		}

		public void method_18()
		{
			hashtable_0 = null;
			method_14(changed: false);
		}

		public int method_19()
		{
			return method_17().Count;
		}

		public void Clear()
		{
			method_17().Clear();
		}

		public bool method_20(int platformId, int encodingId, int languageId, int nameId)
		{
			Class6102 key = new Class6102(platformId, encodingId, languageId, nameId);
			return method_17().ContainsKey(key);
		}

		public Class6104 method_21(int platformId, int encodingId, int languageId, int nameId)
		{
			Class6102 @class = new Class6102(platformId, encodingId, languageId, nameId);
			Class6104 class2 = (Class6104)method_17()[@class];
			if (class2 == null)
			{
				class2 = new Class6104(@class);
				method_17().Add(@class, class2);
			}
			return class2;
		}

		public bool Remove(int platformId, int encodingId, int languageId, int nameId)
		{
			Class6102 key = new Class6102(platformId, encodingId, languageId, nameId);
			bool result = method_17().ContainsKey(key);
			method_17().Remove(key);
			return result;
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6029(method_16(), data);
		}

		protected override void vmethod_5()
		{
			hashtable_0 = null;
			method_14(changed: false);
		}

		internal override int vmethod_4()
		{
			if (hashtable_0 != null && hashtable_0.Count != 0)
			{
				int num = 6 + hashtable_0.Count * 12;
				{
					foreach (DictionaryEntry item in hashtable_0)
					{
						num += ((Class6104)item.Value).method_5().Length;
					}
					return num;
				}
			}
			return 0;
		}

		internal override bool vmethod_3()
		{
			if (hashtable_0 != null && hashtable_0.Count != 0)
			{
				return true;
			}
			return false;
		}

		internal override int vmethod_2(Class6017 newData)
		{
			int num = 6 + hashtable_0.Count * 12;
			newData.method_37(0, 0);
			newData.method_37(2, hashtable_0.Count);
			newData.method_37(4, num);
			int num2 = 6;
			int num3 = 0;
			foreach (DictionaryEntry item in hashtable_0)
			{
				newData.method_37(num2, ((Class6102)item.Key).method_0());
				newData.method_37(num2 + 2, ((Class6102)item.Key).method_1());
				newData.method_37(num2 + 4, ((Class6102)item.Key).method_2());
				newData.method_37(num2 + 6, ((Class6102)item.Key).method_3());
				newData.method_37(num2 + 8, ((Class6104)item.Value).method_5().Length);
				newData.method_37(num2 + 10, num3);
				num2 += 12;
				num3 += newData.method_35(num3 + num, ((Class6104)item.Value).method_5());
			}
			return num3 + num;
		}
	}

	public enum Enum767
	{
		const_0 = 0,
		const_1 = 2,
		const_2 = 4,
		const_3 = 6,
		const_4 = 0,
		const_5 = 2,
		const_6 = 12,
		const_7 = 0,
		const_8 = 2,
		const_9 = 4,
		const_10 = 6,
		const_11 = 8,
		const_12 = 10
	}

	public enum Enum768
	{
		const_0 = -1,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9,
		const_10,
		const_11,
		const_12,
		const_13,
		const_14,
		const_15,
		const_16,
		const_17,
		const_18,
		const_19,
		const_20,
		const_21,
		const_22,
		const_23
	}

	public enum Enum769
	{
		const_0 = -1,
		const_1
	}

	public enum Enum770
	{
		const_0 = -1,
		const_1 = 0,
		const_2 = 1,
		const_3 = 2,
		const_4 = 3,
		const_5 = 4,
		const_6 = 5,
		const_7 = 6,
		const_8 = 7,
		const_9 = 8,
		const_10 = 9,
		const_11 = 10,
		const_12 = 11,
		const_13 = 12,
		const_14 = 13,
		const_15 = 14,
		const_16 = 15,
		const_17 = 16,
		const_18 = 17,
		const_19 = 18,
		const_20 = 19,
		const_21 = 20,
		const_22 = 21,
		const_23 = 22,
		const_24 = 23,
		const_25 = 24,
		const_26 = 25,
		const_27 = 26,
		const_28 = 27,
		const_29 = 28,
		const_30 = 29,
		const_31 = 30,
		const_32 = 31,
		const_33 = 32,
		const_34 = 33,
		const_35 = 34,
		const_36 = 35,
		const_37 = 36,
		const_38 = 37,
		const_39 = 38,
		const_40 = 39,
		const_41 = 40,
		const_42 = 41,
		const_43 = 42,
		const_44 = 43,
		const_45 = 44,
		const_46 = 45,
		const_47 = 46,
		const_48 = 47,
		const_49 = 48,
		const_50 = 49,
		const_51 = 50,
		const_52 = 51,
		const_53 = 52,
		const_54 = 53,
		const_55 = 54,
		const_56 = 55,
		const_57 = 56,
		const_58 = 57,
		const_59 = 58,
		const_60 = 59,
		const_61 = 60,
		const_62 = 61,
		const_63 = 62,
		const_64 = 63,
		const_65 = 64,
		const_66 = 65,
		const_67 = 66,
		const_68 = 67,
		const_69 = 68,
		const_70 = 69,
		const_71 = 70,
		const_72 = 71,
		const_73 = 72,
		const_74 = 73,
		const_75 = 74,
		const_76 = 75,
		const_77 = 76,
		const_78 = 77,
		const_79 = 78,
		const_80 = 79,
		const_81 = 80,
		const_82 = 81,
		const_83 = 82,
		const_84 = 83,
		const_85 = 84,
		const_86 = 85,
		const_87 = 86,
		const_88 = 87,
		const_89 = 88,
		const_90 = 89,
		const_91 = 90,
		const_92 = 91,
		const_93 = 92,
		const_94 = 93,
		const_95 = 94,
		const_96 = 128,
		const_97 = 129,
		const_98 = 130,
		const_99 = 131,
		const_100 = 132,
		const_101 = 133,
		const_102 = 134,
		const_103 = 135,
		const_104 = 136,
		const_105 = 137,
		const_106 = 138,
		const_107 = 139,
		const_108 = 140,
		const_109 = 141,
		const_110 = 142,
		const_111 = 143,
		const_112 = 144,
		const_113 = 145,
		const_114 = 146,
		const_115 = 147,
		const_116 = 148,
		const_117 = 149,
		const_118 = 150
	}

	public enum Enum771
	{
		const_0 = -1,
		const_1 = 1078,
		const_2 = 1052,
		const_3 = 1156,
		const_4 = 1118,
		const_5 = 5121,
		const_6 = 15361,
		const_7 = 3073,
		const_8 = 2049,
		const_9 = 11265,
		const_10 = 13313,
		const_11 = 12289,
		const_12 = 4097,
		const_13 = 6145,
		const_14 = 8193,
		const_15 = 16385,
		const_16 = 1025,
		const_17 = 10241,
		const_18 = 7169,
		const_19 = 14337,
		const_20 = 9217,
		const_21 = 1067,
		const_22 = 1101,
		const_23 = 2092,
		const_24 = 1068,
		const_25 = 1133,
		const_26 = 1069,
		const_27 = 1059,
		const_28 = 2117,
		const_29 = 1093,
		const_30 = 8218,
		const_31 = 5146,
		const_32 = 1150,
		const_33 = 1026,
		const_34 = 1027,
		const_35 = 3076,
		const_36 = 5124,
		const_37 = 2052,
		const_38 = 4100,
		const_39 = 1028,
		const_40 = 1155,
		const_41 = 1050,
		const_42 = 4122,
		const_43 = 1029,
		const_44 = 1030,
		const_45 = 1164,
		const_46 = 1125,
		const_47 = 2067,
		const_48 = 1043,
		const_49 = 3081,
		const_50 = 10249,
		const_51 = 4105,
		const_52 = 9225,
		const_53 = 16393,
		const_54 = 6153,
		const_55 = 8201,
		const_56 = 17417,
		const_57 = 5129,
		const_58 = 13321,
		const_59 = 18441,
		const_60 = 7177,
		const_61 = 11273,
		const_62 = 2057,
		const_63 = 1033,
		const_64 = 12297,
		const_65 = 1061,
		const_66 = 1080,
		const_67 = 1124,
		const_68 = 1035,
		const_69 = 2060,
		const_70 = 3084,
		const_71 = 1036,
		const_72 = 5132,
		const_73 = 6156,
		const_74 = 4108,
		const_75 = 1122,
		const_76 = 1110,
		const_77 = 1079,
		const_78 = 3079,
		const_79 = 1031,
		const_80 = 5127,
		const_81 = 4103,
		const_82 = 2055,
		const_83 = 1032,
		const_84 = 1135,
		const_85 = 1095,
		const_86 = 1128,
		const_87 = 1037,
		const_88 = 1081,
		const_89 = 1038,
		const_90 = 1039,
		const_91 = 1136,
		const_92 = 1057,
		const_93 = 1117,
		const_94 = 2141,
		const_95 = 2108,
		const_96 = 1076,
		const_97 = 1077,
		const_98 = 1040,
		const_99 = 2064,
		const_100 = 1041,
		const_101 = 1099,
		const_102 = 1087,
		const_103 = 1107,
		const_104 = 1158,
		const_105 = 1159,
		const_106 = 1089,
		const_107 = 1111,
		const_108 = 1042,
		const_109 = 1088,
		const_110 = 1108,
		const_111 = 1062,
		const_112 = 1063,
		const_113 = 2094,
		const_114 = 1134,
		const_115 = 1071,
		const_116 = 2110,
		const_117 = 1086,
		const_118 = 1100,
		const_119 = 1082,
		const_120 = 1153,
		const_121 = 1146,
		const_122 = 1102,
		const_123 = 1148,
		const_124 = 1104,
		const_125 = 2128,
		const_126 = 1121,
		const_127 = 1044,
		const_128 = 2068,
		const_129 = 1154,
		const_130 = 1096,
		const_131 = 1123,
		const_132 = 1045,
		const_133 = 1046,
		const_134 = 2070,
		const_135 = 1094,
		const_136 = 1131,
		const_137 = 2155,
		const_138 = 3179,
		const_139 = 1048,
		const_140 = 1047,
		const_141 = 1049,
		const_142 = 9275,
		const_143 = 4155,
		const_144 = 5179,
		const_145 = 3131,
		const_146 = 1083,
		const_147 = 2107,
		const_148 = 8251,
		const_149 = 6203,
		const_150 = 7227,
		const_151 = 1103,
		const_152 = 7194,
		const_153 = 3098,
		const_154 = 6170,
		const_155 = 2074,
		const_156 = 1132,
		const_157 = 1074,
		const_158 = 1115,
		const_159 = 1051,
		const_160 = 1060,
		const_161 = 11274,
		const_162 = 16394,
		const_163 = 13322,
		const_164 = 9226,
		const_165 = 5130,
		const_166 = 7178,
		const_167 = 12298,
		const_168 = 17418,
		const_169 = 4106,
		const_170 = 18442,
		const_171 = 2058,
		const_172 = 19466,
		const_173 = 6154,
		const_174 = 15370,
		const_175 = 10250,
		const_176 = 20490,
		const_177 = 3082,
		const_178 = 1034,
		const_179 = 21514,
		const_180 = 14346,
		const_181 = 8202,
		const_182 = 2077,
		const_183 = 1053,
		const_184 = 1114,
		const_185 = 1064,
		const_186 = 2143,
		const_187 = 1097,
		const_188 = 1092,
		const_189 = 1098,
		const_190 = 1054,
		const_191 = 1105,
		const_192 = 1055,
		const_193 = 1090,
		const_194 = 1152,
		const_195 = 1058,
		const_196 = 1070,
		const_197 = 1056,
		const_198 = 2115,
		const_199 = 1091,
		const_200 = 1066,
		const_201 = 1106,
		const_202 = 1096,
		const_203 = 1157,
		const_204 = 1144,
		const_205 = 1130
	}

	internal interface Interface259
	{
		bool imethod_0(int platformId, int encodingId, int languageId, int nameId);
	}

	internal class Class6101 : Interface259
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		internal Class6101(int platformId, int encodingId, int languageId, int nameId)
		{
			int_0 = platformId;
			int_1 = encodingId;
			int_2 = languageId;
			int_3 = nameId;
		}

		public bool imethod_0(int platformId, int encodingId, int languageId, int nameId)
		{
			if (int_0 == platformId && int_1 == encodingId && int_2 == languageId && int_3 == nameId)
			{
				return true;
			}
			return false;
		}
	}

	internal class Class6102 : IComparable
	{
		protected int int_0;

		protected int int_1;

		protected int int_2;

		protected int int_3;

		internal Class6102(int platformId, int encodingId, int languageId, int nameId)
		{
			int_0 = platformId;
			int_1 = encodingId;
			int_2 = languageId;
			int_3 = nameId;
		}

		internal int method_0()
		{
			return int_0;
		}

		internal int method_1()
		{
			return int_1;
		}

		internal int method_2()
		{
			return int_2;
		}

		internal int method_3()
		{
			return int_3;
		}

		public string method_4()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("P=");
			stringBuilder.Append((Class6020.Enum751)int_0);
			stringBuilder.Append(", E=0x");
			stringBuilder.Append($"{int_1:x}");
			stringBuilder.Append(", L=0x");
			stringBuilder.Append($"{int_2:x}");
			stringBuilder.Append(", N=");
			stringBuilder.Append(int_3);
			return stringBuilder.ToString();
		}

		public int CompareTo(object obj)
		{
			Class6102 @class = obj as Class6102;
			if (int_0 != @class.int_0)
			{
				return int_0 - @class.int_0;
			}
			if (int_1 != @class.int_1)
			{
				return int_1 - @class.int_1;
			}
			if (int_2 != @class.int_2)
			{
				return int_2 - @class.int_2;
			}
			return int_3 - @class.int_3;
		}

		public bool Equals(Class6102 other)
		{
			if (object.ReferenceEquals(null, other))
			{
				return false;
			}
			if (object.ReferenceEquals(this, other))
			{
				return true;
			}
			if (other.int_0 == int_0 && other.int_1 == int_1 && other.int_2 == int_2)
			{
				return other.int_3 == int_3;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(null, obj))
			{
				return false;
			}
			if (object.ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj.GetType() != typeof(Class6102))
			{
				return false;
			}
			return Equals((Class6102)obj);
		}

		public override int GetHashCode()
		{
			return ((int_1 & 0x3F) << 26) | ((int_3 & 0x3F) << 16) | ((int_0 & 0xF) << 12) | (int_2 & 0xFF);
		}

		public static bool operator ==(Class6102 left, Class6102 right)
		{
			return object.Equals(left, right);
		}

		public static bool operator !=(Class6102 left, Class6102 right)
		{
			return !object.Equals(left, right);
		}
	}

	internal class Class6103
	{
		internal Class6102 class6102_0;

		protected int int_0;

		protected byte[] byte_0;

		protected Class6103()
		{
		}

		protected Class6103(Class6102 nameEntryId, byte[] nameBytes)
		{
			class6102_0 = nameEntryId;
			byte_0 = nameBytes;
		}

		internal Class6103(int platformId, int encodingId, int languageId, int nameId, byte[] nameBytes)
			: this(new Class6102(platformId, encodingId, languageId, nameId), nameBytes)
		{
		}

		internal Class6102 method_0()
		{
			return class6102_0;
		}

		public int method_1()
		{
			return class6102_0.method_0();
		}

		public int method_2()
		{
			return class6102_0.method_1();
		}

		public int method_3()
		{
			return class6102_0.method_2();
		}

		public int method_4()
		{
			return class6102_0.method_3();
		}

		public byte[] method_5()
		{
			return byte_0;
		}

		public string method_6()
		{
			return smethod_3(byte_0, method_1(), method_2());
		}

		public string method_7()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[");
			stringBuilder.Append(class6102_0);
			stringBuilder.Append(", \"");
			stringBuilder.Append(method_6());
			stringBuilder.Append("\"]");
			return stringBuilder.ToString();
		}

		public bool Equals(Class6103 other)
		{
			if (object.ReferenceEquals(null, other))
			{
				return false;
			}
			if (object.ReferenceEquals(this, other))
			{
				return true;
			}
			if (object.Equals(other.class6102_0, class6102_0) && other.int_0 == int_0)
			{
				return object.Equals(other.byte_0, byte_0);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(null, obj))
			{
				return false;
			}
			if (object.ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj.GetType() != typeof(Class6103))
			{
				return false;
			}
			return Equals((Class6103)obj);
		}

		public override int GetHashCode()
		{
			int num = class6102_0.GetHashCode();
			for (int i = 0; i < byte_0.Length; i += 4)
			{
				for (int j = 0; j < 4 && j + i < byte_0.Length; j++)
				{
					num |= byte_0[j] << j * 8;
				}
			}
			return num;
		}

		public static bool operator ==(Class6103 left, Class6103 right)
		{
			return object.Equals(left, right);
		}

		public static bool operator !=(Class6103 left, Class6103 right)
		{
			return !object.Equals(left, right);
		}
	}

	internal class Class6104 : Class6103
	{
		internal Class6104()
		{
		}

		internal Class6104(Class6102 nameEntryId, byte[] nameBytes)
			: base(nameEntryId, nameBytes)
		{
		}

		internal Class6104(Class6102 nameEntryId)
			: this(nameEntryId, null)
		{
		}

		internal Class6104(Class6103 nameEntry)
			: this(nameEntry.method_0(), nameEntry.method_5())
		{
		}

		public void method_8(string name)
		{
			if (name == null)
			{
				byte_0 = new byte[0];
			}
			else
			{
				byte_0 = smethod_2(name, class6102_0.method_0(), class6102_0.method_1());
			}
		}

		public void method_9(byte[] nameBytes)
		{
			byte_0 = new byte[nameBytes.Length];
			Array.Copy(nameBytes, byte_0, nameBytes.Length);
		}

		public void method_10(byte[] nameBytes, int offset, int length)
		{
			byte_0 = new byte[length];
			Array.Copy(nameBytes, offset, byte_0, 0, length);
		}
	}

	internal class Class6105 : Interface256
	{
		private int int_0;

		private Interface259 interface259_0;

		private Class6029 class6029_0;

		internal Class6105(Class6029 owner)
		{
			class6029_0 = owner;
		}

		internal Class6105(Interface259 filter, Class6029 owner)
		{
			interface259_0 = filter;
			class6029_0 = owner;
		}

		public bool imethod_0()
		{
			if (interface259_0 == null)
			{
				if (int_0 < class6029_0.method_13())
				{
					return true;
				}
				return false;
			}
			while (true)
			{
				if (int_0 < class6029_0.method_13())
				{
					if (interface259_0.imethod_0(class6029_0.method_15(int_0), class6029_0.method_16(int_0), class6029_0.method_17(int_0), class6029_0.method_18(int_0)))
					{
						break;
					}
					int_0++;
					continue;
				}
				return false;
			}
			return true;
		}

		public object imethod_1()
		{
			if (!imethod_0())
			{
				throw new InvalidOperationException();
			}
			return class6029_0.method_25(int_0++);
		}

		public void Remove()
		{
			throw new NotSupportedException("Cannot remove a CMap table from an existing font.");
		}
	}

	private Class6029(Class6110 header, Class6016 data)
		: base(header, data)
	{
	}

	public int method_12()
	{
		return class6016_0.method_16(0);
	}

	public int method_13()
	{
		return class6016_0.method_16(2);
	}

	private int method_14()
	{
		return class6016_0.method_16(4);
	}

	private static int smethod_0(int index)
	{
		return 6 + index * 12;
	}

	public int method_15(int index)
	{
		return class6016_0.method_16(smethod_0(index));
	}

	public int method_16(int index)
	{
		return class6016_0.method_16(2 + smethod_0(index));
	}

	public int method_17(int index)
	{
		return class6016_0.method_16(4 + smethod_0(index));
	}

	public int method_18(int index)
	{
		return class6016_0.method_16(6 + smethod_0(index));
	}

	private int method_19(int index)
	{
		return class6016_0.method_16(8 + smethod_0(index));
	}

	private int method_20(int index)
	{
		return class6016_0.method_16(10 + smethod_0(index)) + method_14();
	}

	public byte[] method_21(int index)
	{
		int num = method_19(index);
		byte[] array = new byte[num];
		class6016_0.method_14(method_20(index), array, 0, num);
		return array;
	}

	public byte[] method_22(int platformId, int encodingId, int languageId, int nameId)
	{
		Class6103 @class = method_26(platformId, encodingId, languageId, nameId);
		if (@class != null)
		{
			return @class.method_5();
		}
		return null;
	}

	public string method_23(int index)
	{
		return smethod_3(method_21(index), method_15(index), method_16(index));
	}

	public string method_24(int platformId, int encodingId, int languageId, int nameId)
	{
		Class6103 @class = method_26(platformId, encodingId, languageId, nameId);
		if (@class != null)
		{
			return @class.method_6();
		}
		return null;
	}

	public Class6103 method_25(int index)
	{
		return new Class6103(method_15(index), method_16(index), method_17(index), method_18(index), method_21(index));
	}

	public Class6103 method_26(int platformId, int encodingId, int languageId, int nameId)
	{
		Interface256 @interface = method_28(new Class6101(platformId, encodingId, languageId, nameId));
		if (@interface.imethod_0())
		{
			return (Class6103)@interface.imethod_1();
		}
		return null;
	}

	public ArrayList method_27()
	{
		ArrayList arrayList = new ArrayList(method_13());
		Interface256 @interface = imethod_0();
		while (@interface.imethod_0())
		{
			arrayList.Add(@interface.imethod_1());
		}
		return arrayList;
	}

	public Interface256 imethod_0()
	{
		return new Class6105(this);
	}

	public Interface256 method_28(Interface259 filter)
	{
		return new Class6105(filter, this);
	}

	private static string smethod_1(int platformId, int encodingId)
	{
		string result = null;
		switch ((Class6020.Enum751)platformId)
		{
		case Class6020.Enum751.const_1:
			result = "UTF-16BE";
			break;
		case Class6020.Enum751.const_2:
			switch ((Class6020.Enum754)encodingId)
			{
			case Class6020.Enum754.const_1:
				result = "MacRoman";
				break;
			case Class6020.Enum754.const_2:
				result = "Shift_JIS";
				break;
			case Class6020.Enum754.const_3:
				result = "Big5";
				break;
			case Class6020.Enum754.const_4:
				result = "EUC-KR";
				break;
			case Class6020.Enum754.const_5:
				result = "MacArabic";
				break;
			case Class6020.Enum754.const_6:
				result = "MacHebrew";
				break;
			case Class6020.Enum754.const_7:
				result = "MacGreek";
				break;
			case Class6020.Enum754.const_8:
				result = "MacCyrillic";
				break;
			case Class6020.Enum754.const_9:
				result = "MacSymbol";
				break;
			case Class6020.Enum754.const_22:
				result = "MacThai";
				break;
			case Class6020.Enum754.const_24:
				result = "MacCyrillic";
				break;
			case Class6020.Enum754.const_26:
				result = "EUC-CN";
				break;
			case Class6020.Enum754.const_28:
				result = "MacCyrillic";
				break;
			case Class6020.Enum754.const_30:
				result = "MacCyrillic";
				break;
			}
			break;
		case Class6020.Enum751.const_4:
			switch ((Class6020.Enum753)encodingId)
			{
			case Class6020.Enum753.const_1:
				result = "UTF-16BE";
				break;
			case Class6020.Enum753.const_2:
				result = "UTF-16BE";
				break;
			case Class6020.Enum753.const_3:
				result = "windows-933";
				break;
			case Class6020.Enum753.const_4:
				result = "windows-936";
				break;
			case Class6020.Enum753.const_5:
				result = "windows-950";
				break;
			case Class6020.Enum753.const_6:
				result = "windows-949";
				break;
			case Class6020.Enum753.const_7:
				result = "ms1361";
				break;
			case Class6020.Enum753.const_8:
				result = "UCS-4";
				break;
			}
			break;
		}
		return result;
	}

	private static byte[] smethod_2(string name, int platformId, int encodingId)
	{
		string text = smethod_1(platformId, encodingId);
		if (text == null)
		{
			return null;
		}
		Encoding encoding = Encoding.GetEncoding(text.ToLower());
		return encoding.GetBytes(name);
	}

	private static string smethod_3(byte[] nameBytes, int platformId, int encodingId)
	{
		string text = smethod_1(platformId, encodingId);
		Encoding encoding = Encoding.GetEncoding(text.ToLower());
		return encoding.GetString(nameBytes);
	}
}
