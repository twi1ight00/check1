using System;
using System.IO;
using Aspose.Words;
using x28925c9b27b37a46;

namespace xa604c4d210ae0581;

internal class xbf47b732017d34a9
{
	internal static TabStopCollection x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, TabStopCollection x5ffa547f17ecad54, bool xaded964d2765d9b8, IWarningCallback x57fef5933b41d0c2)
	{
		x5ffa547f17ecad54.HasTolerances = xaded964d2765d9b8;
		int num = xe134235b3526fa75.ReadByte();
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = xe134235b3526fa75.ReadInt16();
		}
		int[] array2 = null;
		if (xaded964d2765d9b8)
		{
			array2 = new int[num];
			for (int j = 0; j < num; j++)
			{
				array2[j] = xe134235b3526fa75.ReadInt16();
			}
		}
		for (int k = 0; k < num; k++)
		{
			TabStop tabStop = new TabStop(array[k], TabAlignment.Clear, TabLeader.None);
			if (xaded964d2765d9b8)
			{
				tabStop.ToleranceTwips = array2[k];
			}
			x5ffa547f17ecad54.Add(tabStop);
		}
		int num2 = xe134235b3526fa75.ReadByte();
		int[] array3 = new int[num2];
		for (int l = 0; l < num2; l++)
		{
			array3[l] = xe134235b3526fa75.ReadInt16();
		}
		byte[] array4 = new byte[num2];
		Stream baseStream = xe134235b3526fa75.BaseStream;
		int val = (int)(baseStream.Length - baseStream.Position);
		baseStream.Read(array4, 0, Math.Min(num2, val));
		for (int m = 0; m < num2; m++)
		{
			if (m > 0 && array3[m] <= array3[m - 1])
			{
				x98b0e09ccece0a5a.x3dc950453374051a(x57fef5933b41d0c2, WarningSource.Doc, "Invalid tab stop position {0}, ignored.", array3[m]);
				break;
			}
			TabStop tabStop2 = new TabStop(array3[m], (TabAlignment)(array4[m] & 7), (TabLeader)((array4[m] & 0x38) >> 3));
			if (tabStop2.Alignment == (TabAlignment)5)
			{
				x98b0e09ccece0a5a.x3dc950453374051a(x57fef5933b41d0c2, WarningSource.Doc, "Invalid tab stop alignment type read, used defaults.");
				tabStop2.Alignment = TabAlignment.Left;
			}
			tabStop2.Undocumented40 = (array4[m] & 0x40) != 0;
			x5ffa547f17ecad54.Add(tabStop2);
		}
		return x5ffa547f17ecad54;
	}

	internal static void x6210059f049f0d48(TabStopCollection x5ffa547f17ecad54, x354e9ebad65eecc8 xbdfb620b7167944b)
	{
		if (x5ffa547f17ecad54.Count == 0)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < x5ffa547f17ecad54.Count; i++)
		{
			if (x5ffa547f17ecad54[i].IsClear)
			{
				num++;
			}
			else
			{
				num2++;
			}
		}
		bool hasTolerances = x5ffa547f17ecad54.HasTolerances;
		xbdfb620b7167944b.x3a52c4e37999b16e(hasTolerances ? x875aca5784596b73.x0d02b68a5ba692ca : x875aca5784596b73.xb11f973f5b4b3b79);
		int num3 = 1 + num * 2 + (hasTolerances ? (num * 2) : 0) + 1 + num2 * 2 + num2;
		xbdfb620b7167944b.Write((byte)num3);
		xbdfb620b7167944b.Write((byte)num);
		for (int j = 0; j < x5ffa547f17ecad54.Count; j++)
		{
			if (x5ffa547f17ecad54[j].IsClear)
			{
				xbdfb620b7167944b.Write((short)x5ffa547f17ecad54.GetPositionTwipsByIndex(j));
			}
		}
		if (hasTolerances)
		{
			for (int k = 0; k < x5ffa547f17ecad54.Count; k++)
			{
				TabStop tabStop = x5ffa547f17ecad54[k];
				if (tabStop.IsClear)
				{
					xbdfb620b7167944b.Write((short)tabStop.ToleranceTwips);
				}
			}
		}
		xbdfb620b7167944b.Write((byte)num2);
		for (int l = 0; l < x5ffa547f17ecad54.Count; l++)
		{
			if (!x5ffa547f17ecad54[l].IsClear)
			{
				xbdfb620b7167944b.Write((short)x5ffa547f17ecad54.GetPositionTwipsByIndex(l));
			}
		}
		for (int m = 0; m < x5ffa547f17ecad54.Count; m++)
		{
			TabStop tabStop2 = x5ffa547f17ecad54[m];
			if (!tabStop2.IsClear)
			{
				int num4 = 0;
				num4 |= (int)tabStop2.Alignment;
				num4 |= (int)tabStop2.Leader << 3;
				num4 |= (tabStop2.Undocumented40 ? 64 : 0);
				xbdfb620b7167944b.Write((byte)num4);
			}
		}
	}
}
