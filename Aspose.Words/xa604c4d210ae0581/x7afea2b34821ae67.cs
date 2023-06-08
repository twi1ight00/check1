using System;
using System.Collections;
using System.IO;
using Aspose.Words;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal class x7afea2b34821ae67
{
	private const string xe2bbaeb42aadfa27 = "Sign";

	internal static void x06b0e25aa6ad68a9(x8aeace2bf92692ab xf0c8411938a86cbf, BinaryReader xe134235b3526fa75, Document x6beba47238e0ade6)
	{
		if (xf0c8411938a86cbf.x955a03f821588c52.xd6d54512da92fc89.x04c290dc4d04369c == 0)
		{
			return;
		}
		xe134235b3526fa75.BaseStream.Position = xf0c8411938a86cbf.x955a03f821588c52.xd6d54512da92fc89.xe53f0e68147463d1;
		int num = xe134235b3526fa75.ReadUInt16();
		if (num != 65535)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kkgacmnamlebillbokccegjceladhkhdckodgkfegjmegkdfekkfojbgoiiggepgcjghginhndeioiliphcjjhjjbdakchhkkhoklgflkhmlpgdmegkmkgbnngingbpnjggobfnopfepdflpiecagejaneabdehboeobipeciemcgeddodkdodbekciencpeicgfoomf", 1419118163)));
		}
		int num2 = xe134235b3526fa75.ReadInt16();
		xe134235b3526fa75.ReadInt16();
		string[] array = new string[num2];
		for (int i = 0; i < num2; i++)
		{
			array[i] = x93b05c1ad709a695.x602d3c3fbfa56f51(xe134235b3526fa75, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
			xe134235b3526fa75.ReadInt32();
		}
		for (int j = 0; j < num2; j++)
		{
			if (array[j] != "Sign")
			{
				string value = x93b05c1ad709a695.x602d3c3fbfa56f51(xe134235b3526fa75, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
				x6beba47238e0ade6.Variables.Add(array[j], value);
			}
			else
			{
				int count = xe134235b3526fa75.ReadUInt16() * 2;
				x6beba47238e0ade6.xd7b817e9f42390ee = xe134235b3526fa75.ReadBytes(count);
			}
		}
	}

	internal static int x6210059f049f0d48(Document x6beba47238e0ade6, BinaryWriter xbdfb620b7167944b)
	{
		int num = (int)xbdfb620b7167944b.BaseStream.Position;
		string[] array = x7c375c76081b3d09(x6beba47238e0ade6);
		if (array.Length == 0)
		{
			return 0;
		}
		xbdfb620b7167944b.Write(ushort.MaxValue);
		xbdfb620b7167944b.Write((short)array.Length);
		xbdfb620b7167944b.Write((short)4);
		string[] array2 = array;
		foreach (string xbcea506a33cf in array2)
		{
			x93b05c1ad709a695.x4a3c44ae9b1cf5ab(xbcea506a33cf, int.MaxValue, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
			xbdfb620b7167944b.Write(0);
		}
		string[] array3 = array;
		foreach (string text in array3)
		{
			if (text != "Sign")
			{
				string xbcea506a33cf2 = x6beba47238e0ade6.Variables[text];
				x93b05c1ad709a695.x4a3c44ae9b1cf5ab(xbcea506a33cf2, int.MaxValue, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
			}
			else
			{
				xbdfb620b7167944b.Write((ushort)(x6beba47238e0ade6.xd7b817e9f42390ee.Length / 2));
				xbdfb620b7167944b.Write(x6beba47238e0ade6.xd7b817e9f42390ee);
			}
		}
		return (int)xbdfb620b7167944b.BaseStream.Position - num;
	}

	internal static string[] x7c375c76081b3d09(Document x6beba47238e0ade6)
	{
		int num = x6beba47238e0ade6.Variables.Count;
		if (x6beba47238e0ade6.xd7b817e9f42390ee != null)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		foreach (DictionaryEntry variable in x6beba47238e0ade6.Variables)
		{
			array[num2++] = (string)variable.Key;
		}
		if (x6beba47238e0ade6.xd7b817e9f42390ee != null)
		{
			array[^1] = "Sign";
		}
		Array.Sort(array, x86c17cfc92c052fd.xb9715d2f06b63cf0);
		return array;
	}
}
