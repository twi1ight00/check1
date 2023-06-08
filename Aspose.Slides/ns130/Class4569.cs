using System;

namespace ns130;

internal class Class4569
{
	public struct Struct174
	{
		public byte byte_0;

		public byte byte_1;

		public byte byte_2;

		public ushort ushort_0;

		public ushort ushort_1;

		public bool bool_0;

		public bool bool_1;
	}

	public static Struct174 smethod_0(int index)
	{
		Struct174 result;
		switch (index)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
			result = default(Struct174);
			result.byte_0 = 2;
			result.byte_2 = 8;
			result.ushort_1 = (ushort)(256 * (index / 2));
			result.bool_1 = index % 2 == 0;
			break;
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
			result = default(Struct174);
			result.byte_0 = 2;
			result.byte_1 = 8;
			result.ushort_0 = (ushort)((index - 10) / 2 * 256);
			result.bool_0 = index % 2 == 0;
			break;
		case 20:
		case 21:
		case 22:
		case 23:
		case 24:
		case 25:
		case 26:
		case 27:
		case 28:
		case 29:
		case 30:
		case 31:
		case 32:
		case 33:
		case 34:
		case 35:
		case 36:
		case 37:
		case 38:
		case 39:
		case 40:
		case 41:
		case 42:
		case 43:
		case 44:
		case 45:
		case 46:
		case 47:
		case 48:
		case 49:
		case 50:
		case 51:
		case 52:
		case 53:
		case 54:
		case 55:
		case 56:
		case 57:
		case 58:
		case 59:
		case 60:
		case 61:
		case 62:
		case 63:
		case 64:
		case 65:
		case 66:
		case 67:
		case 68:
		case 69:
		case 70:
		case 71:
		case 72:
		case 73:
		case 74:
		case 75:
		case 76:
		case 77:
		case 78:
		case 79:
		case 80:
		case 81:
		case 82:
		case 83:
		{
			ushort num2 = (ushort)((index - 20) / 16 * 16 + 1);
			result = default(Struct174);
			result.byte_0 = 2;
			result.byte_1 = 4;
			result.byte_2 = 4;
			result.ushort_0 = num2;
			result.ushort_1 = (ushort)((index - 20 - num2 + 1) / 4 * 16 + 1);
			result.bool_0 = index % 2 == 0;
			result.bool_1 = (index - 20) / 2 % 2 == 0;
			break;
		}
		case 84:
		case 85:
		case 86:
		case 87:
		case 88:
		case 89:
		case 90:
		case 91:
		case 92:
		case 93:
		case 94:
		case 95:
		case 96:
		case 97:
		case 98:
		case 99:
		case 100:
		case 101:
		case 102:
		case 103:
		case 104:
		case 105:
		case 106:
		case 107:
		case 108:
		case 109:
		case 110:
		case 111:
		case 112:
		case 113:
		case 114:
		case 115:
		case 116:
		case 117:
		case 118:
		case 119:
		{
			ushort num = (ushort)((index - 84) / 12 * 256 + 1);
			result = default(Struct174);
			result.byte_0 = 3;
			result.byte_1 = 8;
			result.byte_2 = 8;
			result.ushort_0 = num;
			result.ushort_1 = (ushort)((index - 84 - (num - 1) / 256 * 12) / 4 * 256 + 1);
			result.bool_0 = index % 2 == 0;
			result.bool_1 = (index - 84) / 2 % 2 == 0;
			break;
		}
		case 120:
		case 121:
		case 122:
		case 123:
			result = default(Struct174);
			result.byte_0 = 4;
			result.byte_1 = 12;
			result.byte_2 = 12;
			result.bool_0 = index % 2 == 0;
			result.bool_1 = (index - 120) / 2 % 2 == 0;
			break;
		case 124:
		case 125:
		case 126:
		case 127:
			result = default(Struct174);
			result.byte_0 = 5;
			result.byte_1 = 16;
			result.byte_2 = 16;
			result.bool_0 = index % 2 == 0;
			result.bool_1 = (index - 124) / 2 % 2 == 0;
			break;
		default:
			throw new IndexOutOfRangeException("Index must be in range beetween zero and 127");
		}
		return result;
	}
}
