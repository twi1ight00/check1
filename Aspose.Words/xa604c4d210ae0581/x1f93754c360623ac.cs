using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Settings;
using x28925c9b27b37a46;
using x79578da6a8a3ae37;
using xe5b37aee2c2a4d4e;

namespace xa604c4d210ae0581;

internal class x1f93754c360623ac
{
	private const int x44c626867f6a5144 = 500;

	private const int xb82b3aac2958c60c = 544;

	private const int xaa68cf4318342f52 = 594;

	private const int x2d5a5faabecc82f3 = 616;

	private const int xb79e849f60183b6b = 674;

	private const int xcdb4496fcc2fc553 = 101;

	private const int xd36f10d47a7d5858 = 51;

	internal static void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, x3fdb33c580a0bef3 x0634349d606a4d9a, Document x6beba47238e0ade6, IWarningCallback x57fef5933b41d0c2)
	{
		xdade2366eaa6f915 xdade2366eaa6f = x6beba47238e0ade6.xdade2366eaa6f915;
		int xe53f0e68147463d = x0634349d606a4d9a.xe53f0e68147463d1;
		int x04c290dc4d04369c = x0634349d606a4d9a.x04c290dc4d04369c;
		xe134235b3526fa75.BaseStream.Seek(xe53f0e68147463d, SeekOrigin.Begin);
		int num = xe134235b3526fa75.ReadUInt16();
		xdade2366eaa6f.x5ac0ad056c3fce83 = (num & 1) != 0;
		xdade2366eaa6f.xa7e6dbdb484bb52e = (num & 2) != 0;
		x6beba47238e0ade6.FootnoteOptions.Location = (FootnoteLocation)((num & 0x60) >> 5);
		num = xe134235b3526fa75.ReadUInt16();
		x6beba47238e0ade6.FootnoteOptions.RestartRule = (FootnoteNumberingRule)(num & 3);
		x6beba47238e0ade6.FootnoteOptions.StartNumber = (num & 0xFFFC) >> 2;
		num = xe134235b3526fa75.ReadUInt16();
		xdade2366eaa6f.xaca8557eea824bc0 = (num & 0x800) == 0;
		xdade2366eaa6f.xdf76d3eeb73027d7 = (num & 0x1000) != 0;
		xdade2366eaa6f.x25c2aa42b1eb10e5 = (num & 0x4000) != 0;
		xdade2366eaa6f.x98c0ec6ac7570a99 = (num & 0x8000) != 0;
		num = xe134235b3526fa75.ReadUInt16();
		xdade2366eaa6f.x35eed0f3116ef422 = (num & 4) != 0;
		xdade2366eaa6f.xd2884179402343a8 = (num & 8) != 0;
		if (((uint)num & 0x10u) != 0)
		{
			xdade2366eaa6f.xcadc354ab6a177f1.x491ce6cbe2c9a184 = ProtectionType.AllowOnlyComments;
		}
		xdade2366eaa6f.xd02fc99dc9c3221e = (num & 0x20) != 0;
		if (((uint)num & 0x200u) != 0)
		{
			xdade2366eaa6f.xcadc354ab6a177f1.x491ce6cbe2c9a184 = ProtectionType.AllowOnlyFormFields;
		}
		xdade2366eaa6f.xcadc354ab6a177f1.x3db5335cdcd5d88b = (num & 0x400) != 0;
		xdade2366eaa6f.x14fd633e1477f9de = (num & 0x800) != 0;
		xdade2366eaa6f.x10aeaa8cd2751f43 = (num & 0x1000) != 0;
		if (((uint)num & 0x4000u) != 0)
		{
			xdade2366eaa6f.xcadc354ab6a177f1.x491ce6cbe2c9a184 = ProtectionType.AllowOnlyRevisions;
		}
		xdade2366eaa6f.x26622336636caa4d = (num & 0x8000) != 0;
		num = xe134235b3526fa75.ReadUInt16();
		xdade2366eaa6f.xd72f9bc5cc53fc1c = xe134235b3526fa75.ReadUInt16();
		xe134235b3526fa75.ReadUInt16();
		xdade2366eaa6f.x91faf128d9e0425f = xe134235b3526fa75.ReadUInt16();
		xdade2366eaa6f.xfaa0f593a0704d95 = xe134235b3526fa75.ReadUInt16();
		xe134235b3526fa75.ReadUInt16();
		xe134235b3526fa75.ReadUInt32();
		xe134235b3526fa75.ReadUInt32();
		xe134235b3526fa75.ReadUInt32();
		xe134235b3526fa75.ReadInt16();
		xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt16();
		xe134235b3526fa75.ReadInt32();
		num = xe134235b3526fa75.ReadUInt16();
		x6beba47238e0ade6.EndnoteOptions.RestartRule = (FootnoteNumberingRule)(num & 3);
		x6beba47238e0ade6.EndnoteOptions.StartNumber = (num & 0xFFFC) >> 2;
		num = xe134235b3526fa75.ReadUInt16();
		x6beba47238e0ade6.EndnoteOptions.Location = (FootnoteLocation)(num & 3);
		xdade2366eaa6f.x15b47472ae0f4bf5 = (num & 0x400) != 0;
		xdade2366eaa6f.xc64ebc14fbb01a1c = (num & 0x800) != 0;
		xdade2366eaa6f.x75c79d4f5c4f8bd1 = (num & 0x1000) == 0;
		xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt16();
		xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		xdade2366eaa6f.xcadc354ab6a177f1.xf111d6890e7de382 = xe134235b3526fa75.ReadInt32();
		num = xe134235b3526fa75.ReadUInt16();
		x6beba47238e0ade6.ViewOptions.ViewType = (ViewType)(num & 7);
		x6beba47238e0ade6.ViewOptions.ZoomPercent = (num & 0xFF8) >> 3;
		x6beba47238e0ade6.ViewOptions.ZoomType = (ZoomType)((num & 0x3000) >> 12);
		xdade2366eaa6f.xe1c58df4343d599e = (num & 0x8000) != 0;
		x7366eccc4b770fb3(xdade2366eaa6f, x04c290dc4d04369c);
		CompatibilityOptions xe322902ca0e695f = xdade2366eaa6f.xe322902ca0e695f5;
		if (x04c290dc4d04369c >= 500)
		{
			num = xe134235b3526fa75.ReadInt32();
			xa58bc08dfb00dc6a(num, xe322902ca0e695f);
			xdade2366eaa6f.x5cdb67c2d32f8a3a = (x760e7af47aae1b61)xe134235b3526fa75.ReadUInt16();
			num = xe134235b3526fa75.ReadUInt16();
			xdade2366eaa6f.xa7c8accbf82b9f90 = (num & 1) != 0;
			xdade2366eaa6f.x2b3870f998fa2689 = (xd659df342ea4c461)((num & 6) >> 1);
			xdade2366eaa6f.x5478764877a094bc = (num & 0x18) != 0;
			xdade2366eaa6f.xb8230cce4c519a2a = (num & 0x20) != 0;
			int num2 = xe134235b3526fa75.ReadInt16();
			int val = xe134235b3526fa75.ReadInt16();
			int xbcea506a33cf = (num & 0x380) >> 7;
			xdade2366eaa6f.xb63452877389667b = x93b05c1ad709a695.x304e11a498f3b177(xbcea506a33cf);
			char[] value = x93b05c1ad709a695.xc391923d699d676a(xe134235b3526fa75, x5be1cad1d00af914: true, 101);
			char[] value2 = x93b05c1ad709a695.xc391923d699d676a(xe134235b3526fa75, x5be1cad1d00af914: true, 51);
			if (num2 > 101)
			{
				x98b0e09ccece0a5a.x3dc950453374051a(x57fef5933b41d0c2, "Too long following chars count, used defaults.");
			}
			if (num2 > 51)
			{
				x98b0e09ccece0a5a.x3dc950453374051a(x57fef5933b41d0c2, "Too long leading chars count, used defaults.");
			}
			xdade2366eaa6f.xfc71ac47a3606511 = new string(value, 0, Math.Min(num2, 101));
			xdade2366eaa6f.x466141be69711980 = new string(value2, 0, Math.Min(val, 51));
			xdade2366eaa6f.x88b1df8cde4d7483 = xe134235b3526fa75.ReadInt16();
			xdade2366eaa6f.xd4d02d35f9fd2c1a = xe134235b3526fa75.ReadInt16();
			xdade2366eaa6f.xf0c98b9a5846f66c = xe134235b3526fa75.ReadInt16();
			xdade2366eaa6f.xac305e755359cb11 = xe134235b3526fa75.ReadInt16();
			num = xe134235b3526fa75.ReadUInt16();
			xdade2366eaa6f.xc731b34015cd8a41 = num & 0x7F;
			xdade2366eaa6f.xe695bafc01728ebd = (num & 0x80) != 0;
			xdade2366eaa6f.x95a4a50d4ad3f396 = (num & 0x7F00) >> 8;
			xdade2366eaa6f.x5a27e3b345b6aa73 = (num & 0x8000) != 0;
			num = xe134235b3526fa75.ReadUInt16();
			xdade2366eaa6f.x084871122611bbee = (num & 0x1E) >> 1;
			if (((uint)num & 0x20u) != 0)
			{
				xdade2366eaa6f.x2ee91d7d1f22f253 = ((((uint)num & 0x40u) != 0) ? xf1ca9e6f44822582.xfed52103abb3a632 : xf1ca9e6f44822582.x7f11bcc2641beae7);
			}
			else
			{
				xdade2366eaa6f.x2ee91d7d1f22f253 = xf1ca9e6f44822582.x4d0b9d4447ba7566;
			}
			xdade2366eaa6f.xacad582ef7f5d121 = (num & 0x80) != 0;
			xdade2366eaa6f.xa935a347c7c02364 = (num & 0x100) != 0;
			xdade2366eaa6f.xcea5a6633f25e074 = (num & 0x200) != 0;
			xdade2366eaa6f.xb460e2e11d4e8429 = (num & 0x800) != 0;
			xdade2366eaa6f.x8af0b297a9d474ad = (num & 0x1000) == 0;
			xdade2366eaa6f.x636013cbf60f10b8 = (num & 0x2000) == 0;
			num = xe134235b3526fa75.ReadUInt16();
			xdade2366eaa6f.xb8e73c45a7311978 = (num & 1) != 0;
			xdade2366eaa6f.x96afc98efa43d588 = (num & 2) != 0;
			xe134235b3526fa75.ReadBytes(12);
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			x6beba47238e0ade6.xa0a845678e16cf58 = (xa0a845678e16cf58)xe134235b3526fa75.ReadInt32();
			num = xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadBytes(30);
			xe134235b3526fa75.ReadUInt32();
			xe134235b3526fa75.ReadUInt32();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadUInt32();
			x6beba47238e0ade6.FootnoteOptions.NumberStyle = (NumberStyle)xe134235b3526fa75.ReadInt16();
			x6beba47238e0ade6.EndnoteOptions.NumberStyle = (NumberStyle)xe134235b3526fa75.ReadInt16();
			xe134235b3526fa75.ReadUInt16();
			xe134235b3526fa75.ReadUInt16();
		}
		if (x04c290dc4d04369c >= 544)
		{
			xe134235b3526fa75.ReadUInt16();
			xdade2366eaa6f.x9e5cdc25f2c99156 = xe134235b3526fa75.ReadUInt16();
			num = xe134235b3526fa75.ReadInt32();
			xdade2366eaa6f.xb291c98fcefe576c = (num & 2) != 0;
			if (((uint)num & 0x10000000u) != 0)
			{
				xdade2366eaa6f.x033ad91511e4e3ff = (num & 0x200) == 0;
				xdade2366eaa6f.xc2d62826afc28ce5 = (num & 0x400) != 0;
				xdade2366eaa6f.xbd16abbd8b896a52 = (num & 0x800) != 0;
				xdade2366eaa6f.x86698283e3eda37c = (x6cb5c57047e5f82d)((num & 0xF000) >> 12);
				xdade2366eaa6f.x43d1e7077fb85de6 = (num & 0x10000) == 0;
				xdade2366eaa6f.x117cfa28c87eba97 = (num & 0x20000) == 0;
				xdade2366eaa6f.x1115d25f593044ad = (num & 0xFFC0000) >> 18;
			}
			num = xe134235b3526fa75.ReadInt32();
			xa58bc08dfb00dc6a(num, xe322902ca0e695f);
			num = xe134235b3526fa75.ReadInt32();
			xe322902ca0e695f.ShapeLayoutLikeWW8 = (num & 1) != 0;
			xe322902ca0e695f.FootnoteLayoutLikeWW8 = (num & 2) != 0;
			xe322902ca0e695f.DoNotUseHTMLParagraphAutoSpacing = (num & 4) != 0;
			xe322902ca0e695f.AdjustLineHeightInTable = (num & 8) == 0;
			xe322902ca0e695f.ForgetLastTabAlignment = (num & 0x10) != 0;
			xe322902ca0e695f.AutoSpaceLikeWord95 = (num & 0x20) != 0;
			xe322902ca0e695f.AlignTablesRowByRow = (num & 0x40) != 0;
			xe322902ca0e695f.LayoutRawTableWidth = (num & 0x80) != 0;
			xe322902ca0e695f.LayoutTableRowsApart = (num & 0x100) != 0;
			xe322902ca0e695f.UseWord97LineBreakRules = (num & 0x200) != 0;
			if (x04c290dc4d04369c >= 594)
			{
				xe322902ca0e695f.DoNotBreakWrappedTables = (num & 0x400) != 0;
				xe322902ca0e695f.DoNotSnapToGridInCell = (num & 0x800) != 0;
				xe322902ca0e695f.SelectFldWithFirstOrLastChar = (num & 0x1000) != 0;
				xe322902ca0e695f.ApplyBreakingRules = (num & 0x2000) != 0;
				xe322902ca0e695f.DoNotWrapTextWithPunct = (num & 0x4000) != 0;
				xe322902ca0e695f.DoNotUseEastAsianBreakRules = (num & 0x8000) != 0;
			}
			if (x04c290dc4d04369c >= 616)
			{
				xe322902ca0e695f.UseWord2002TableStyleRules = (num & 0x10000) != 0;
				xe322902ca0e695f.GrowAutofit = (num & 0x20000) != 0;
			}
			if (x04c290dc4d04369c >= 674)
			{
				xe322902ca0e695f.UseNormalStyleForList = (num & 0x40000) != 0;
				xe322902ca0e695f.DoNotUseIndentAsNumberingTabStop = (num & 0x80000) != 0;
				xe322902ca0e695f.UseAltKinsokuLineBreakRules = (num & 0x100000) != 0;
				xe322902ca0e695f.AllowSpaceOfSameStyleInTable = (num & 0x200000) != 0;
				xe322902ca0e695f.DoNotSuppressIndentation = (num & 0x400000) != 0;
				xe322902ca0e695f.DoNotAutofitConstrainedTables = (num & 0x800000) != 0;
				xe322902ca0e695f.AutofitToFirstFixedWidthCell = (num & 0x1000000) != 0;
				xe322902ca0e695f.UnderlineTabInNumList = (num & 0x2000000) != 0;
				xe322902ca0e695f.DisplayHangulFixedWidth = (num & 0x4000000) != 0;
				xe322902ca0e695f.SplitPgBreakAndParaMark = (num & 0x8000000) != 0;
				xe322902ca0e695f.DoNotVertAlignCellWithSp = (num & 0x10000000) != 0;
				xe322902ca0e695f.DoNotBreakConstrainedForcedTable = (num & 0x20000000) != 0;
				xe322902ca0e695f.DoNotVertAlignInTxbx = (num & 0x40000000) != 0;
				xe322902ca0e695f.UseAnsiKerningPairs = (num & 0x80000000u) != 0;
			}
			num = xe134235b3526fa75.ReadInt32();
			if (x04c290dc4d04369c >= 674)
			{
				xe322902ca0e695f.CachedColBalance = (num & 1) != 0;
			}
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			num = xe134235b3526fa75.ReadInt32();
			x6beba47238e0ade6.ViewOptions.DoNotDisplayPageBoundaries = (num & 0x20000) != 0;
			xdade2366eaa6f.x329a4e432765a448 = (num & 0x800000) != 0;
			if (((uint)num & 0x8000000u) != 0)
			{
				xdade2366eaa6f.x0171de9b8f68ad5c = (num & 0x10000000) != 0;
				xdade2366eaa6f.x3b978168870d58e9 = (num & 0x20000000) != 0;
				xdade2366eaa6f.x02b20ac01ba667b2 = (num & 0x40000000) == 0;
				xdade2366eaa6f.xf53b772003bc9d00 = (num & 0x80000000u) != 0;
			}
		}
		if (x04c290dc4d04369c >= 594)
		{
			xe134235b3526fa75.ReadInt32();
			num = xe134235b3526fa75.ReadUInt16();
			xdade2366eaa6f.x53c2568d1dfe1449 = (num & 1) != 0;
			xdade2366eaa6f.x434c293eda734492 = (num & 8) == 0;
			xdade2366eaa6f.x365333836dd8035a = (num & 0x10) != 0;
			xdade2366eaa6f.x6116d416354a4a7e = (num & 0x40) != 0;
			xdade2366eaa6f.xcb55fa1ad5b5e650 = (num & 0x80) != 0;
			xdade2366eaa6f.x73abf66e0a11af0c = (num & 0x800) != 0;
			xdade2366eaa6f.xf858f41dbb36ed12 = (num & 0x1000) != 0;
			xdade2366eaa6f.x445faafef4d65da6 = (num & 0x2000) != 0;
			xdade2366eaa6f.x4fa98f9c55cbae19 = (num & 0x4000) != 0;
			xdade2366eaa6f.x78187b055ec235b4 = (num & 0x8000) != 0;
			xdade2366eaa6f.x22840ca6171e1b22 = xe134235b3526fa75.ReadUInt16();
			xe134235b3526fa75.ReadUInt16();
			xdade2366eaa6f.xfc32bf4854f4898d = xe134235b3526fa75.ReadUInt16();
			xdade2366eaa6f.xf62aa4c5d803502a = xe134235b3526fa75.ReadUInt16();
			xdade2366eaa6f.x64d2067aa07ebd4f = xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			xdade2366eaa6f.xba77a088a86a2b66 = xe134235b3526fa75.ReadInt32();
		}
		if (x04c290dc4d04369c >= 616)
		{
			num = xe134235b3526fa75.ReadInt32();
			if (((uint)num & (true ? 1u : 0u)) != 0)
			{
				xdade2366eaa6f.xcadc354ab6a177f1.x491ce6cbe2c9a184 = ProtectionType.ReadOnly;
			}
			bool flag = (num & 2) != 0;
			xdade2366eaa6f.xcadc354ab6a177f1.x84a58b01dbef401d = (num & 4) != 0;
			xdade2366eaa6f.x1a8b9b3f9527c259 = (num & 8) != 0;
			xdade2366eaa6f.x2c67db9a06eaf625 = (num & 0x10) != 0;
			bool flag2 = (num & 0x20) != 0;
			xdade2366eaa6f.xcadc354ab6a177f1.x4eae8f1c9ec0d2ae = flag && flag2;
			xdade2366eaa6f.x2cc4b92e8cd6e124 = (num & 0x80) != 0;
			xdade2366eaa6f.x6980630e657b6aad = (num & 0x100) != 0;
			xdade2366eaa6f.x8749385938ab4a85 = (num & 0x800) != 0;
			xdade2366eaa6f.x7c692ff62009f114 = (num & 0x1000) != 0;
			num = xe134235b3526fa75.ReadUInt16();
			xdade2366eaa6f.xf50b9f8bbf8fb90c = (num & 1) != 0;
			xdade2366eaa6f.x809d83e59e8bfabb = (num & 2) != 0;
			xdade2366eaa6f.x21351dc18ee481b7 = (num & 4) != 0;
			x6beba47238e0ade6.ViewOptions.DisplayBackgroundShape = (num & 0x80) != 0;
			xe134235b3526fa75.ReadUInt16();
			xe134235b3526fa75.ReadUInt16();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadUInt16();
			xe134235b3526fa75.ReadUInt16();
			xe134235b3526fa75.ReadInt32();
		}
		if (x04c290dc4d04369c >= 674)
		{
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt32();
			x66236619bc6f7fad(xe134235b3526fa75, x6beba47238e0ade6);
		}
		_ = xe134235b3526fa75.BaseStream.Position;
	}

	private static void x66236619bc6f7fad(BinaryReader xe134235b3526fa75, Document x6beba47238e0ade6)
	{
		xdade2366eaa6f915 xdade2366eaa6f = x6beba47238e0ade6.xdade2366eaa6f915;
		int num = xe134235b3526fa75.ReadInt32();
		xdade2366eaa6f.x1c605672f036e9e1.x3b85abfed6d4424f = (x8cc5e7c82a5cfe7a)(num & 3);
		xdade2366eaa6f.x1c605672f036e9e1.xb56517bd05ef77f6 = (x64749a01847a82ed)((num & 0xC) >> 2);
		xdade2366eaa6f.x1c605672f036e9e1.x78266b0e9c142786 = (x2cdbcd6273a149f1)((num & 0x70) >> 4);
		xdade2366eaa6f.x1c605672f036e9e1.xaf8d6a43346515c6 = (num & 0x100) >> 8 != 0;
		int x8b277d8dd2e2d7af = (num & 0x200) >> 9;
		xdade2366eaa6f.x1c605672f036e9e1.x8b277d8dd2e2d7af = (xf47bac63068c8fd6)x8b277d8dd2e2d7af;
		int x07f824b6513692d = (num & 0x400) >> 10;
		xdade2366eaa6f.x1c605672f036e9e1.x07f824b6513692d8 = (xf47bac63068c8fd6)x07f824b6513692d;
		xdade2366eaa6f.x1c605672f036e9e1.x11227fd74d91663d = (num & 0x800) >> 11 != 0;
		xdade2366eaa6f.x1c605672f036e9e1.x92447f7677982e86 = (num & 0x1000) >> 12 != 0;
		int num2 = xe134235b3526fa75.ReadInt16();
		if (num2 < x6beba47238e0ade6.FontInfos.Count)
		{
			xdade2366eaa6f.x1c605672f036e9e1.xddffcb24e864cfcc = x6beba47238e0ade6.FontInfos[num2].Name;
		}
		xdade2366eaa6f.x1c605672f036e9e1.xc8a7b7ce5c5279ee = xe134235b3526fa75.ReadInt32();
		xdade2366eaa6f.x1c605672f036e9e1.x3fa6fa3075fd558f = xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		xdade2366eaa6f.x1c605672f036e9e1.x3810b9f8f9111f8a = xe134235b3526fa75.ReadInt32();
	}

	private static void xa58bc08dfb00dc6a(int xebf45bdcaa1fd1e1, CompatibilityOptions x87b12a2d3f48ccc8)
	{
		x87b12a2d3f48ccc8.NoTabHangInd = (xebf45bdcaa1fd1e1 & 1) != 0;
		x87b12a2d3f48ccc8.NoSpaceRaiseLower = (xebf45bdcaa1fd1e1 & 2) != 0;
		x87b12a2d3f48ccc8.SuppressSpBfAfterPgBrk = (xebf45bdcaa1fd1e1 & 4) != 0;
		x87b12a2d3f48ccc8.WrapTrailSpaces = (xebf45bdcaa1fd1e1 & 8) != 0;
		x87b12a2d3f48ccc8.PrintColBlack = (xebf45bdcaa1fd1e1 & 0x10) != 0;
		x87b12a2d3f48ccc8.NoColumnBalance = (xebf45bdcaa1fd1e1 & 0x20) != 0;
		x87b12a2d3f48ccc8.ConvMailMergeEsc = (xebf45bdcaa1fd1e1 & 0x40) != 0;
		x87b12a2d3f48ccc8.SuppressTopSpacing = (xebf45bdcaa1fd1e1 & 0x80) != 0;
		x87b12a2d3f48ccc8.UseSingleBorderforContiguousCells = (xebf45bdcaa1fd1e1 & 0x100) != 0;
		x87b12a2d3f48ccc8.TransparentMetafiles = (xebf45bdcaa1fd1e1 & 0x200) != 0;
		x87b12a2d3f48ccc8.ShowBreaksInFrames = (xebf45bdcaa1fd1e1 & 0x400) != 0;
		x87b12a2d3f48ccc8.SwapBordersFacingPgs = (xebf45bdcaa1fd1e1 & 0x800) != 0;
		x87b12a2d3f48ccc8.DoNotLeaveBackslashAlone = (xebf45bdcaa1fd1e1 & 0x1000) == 0;
		x87b12a2d3f48ccc8.DoNotExpandShiftReturn = (xebf45bdcaa1fd1e1 & 0x2000) == 0;
		x87b12a2d3f48ccc8.UlTrailSpace = (xebf45bdcaa1fd1e1 & 0x4000) == 0;
		x87b12a2d3f48ccc8.BalanceSingleByteDoubleByteWidth = (xebf45bdcaa1fd1e1 & 0x8000) == 0;
		x87b12a2d3f48ccc8.SuppressSpacingAtTopOfPage = (xebf45bdcaa1fd1e1 & 0x10000) != 0;
		x87b12a2d3f48ccc8.SpacingInWholePoints = (xebf45bdcaa1fd1e1 & 0x20000) != 0;
		x87b12a2d3f48ccc8.PrintBodyTextBeforeHeader = (xebf45bdcaa1fd1e1 & 0x40000) != 0;
		x87b12a2d3f48ccc8.NoLeading = (xebf45bdcaa1fd1e1 & 0x80000) != 0;
		x87b12a2d3f48ccc8.SpaceForUL = (xebf45bdcaa1fd1e1 & 0x100000) == 0;
		x87b12a2d3f48ccc8.MWSmallCaps = (xebf45bdcaa1fd1e1 & 0x200000) != 0;
		x87b12a2d3f48ccc8.SuppressTopSpacingWP = (xebf45bdcaa1fd1e1 & 0x400000) != 0;
		x87b12a2d3f48ccc8.TruncateFontHeightsLikeWP6 = (xebf45bdcaa1fd1e1 & 0x800000) != 0;
		x87b12a2d3f48ccc8.SubFontBySize = (xebf45bdcaa1fd1e1 & 0x1000000) != 0;
		x87b12a2d3f48ccc8.LineWrapLikeWord6 = (xebf45bdcaa1fd1e1 & 0x2000000) != 0;
		x87b12a2d3f48ccc8.DoNotSuppressParagraphBorders = (xebf45bdcaa1fd1e1 & 0x4000000) != 0;
		x87b12a2d3f48ccc8.NoExtraLineSpacing = (xebf45bdcaa1fd1e1 & 0x8000000) != 0;
		x87b12a2d3f48ccc8.SuppressBottomSpacing = (xebf45bdcaa1fd1e1 & 0x10000000) != 0;
		x87b12a2d3f48ccc8.WPSpaceWidth = (xebf45bdcaa1fd1e1 & 0x20000000) != 0;
		x87b12a2d3f48ccc8.WPJustification = (xebf45bdcaa1fd1e1 & 0x40000000) != 0;
		x87b12a2d3f48ccc8.UsePrinterMetrics = (xebf45bdcaa1fd1e1 & 0x80000000u) != 0;
	}

	internal static int x6210059f049f0d48(Document x6beba47238e0ade6, BinaryWriter xbdfb620b7167944b, IWarningCallback x57fef5933b41d0c2)
	{
		xdade2366eaa6f915 xdade2366eaa6f = x6beba47238e0ade6.xdade2366eaa6f915;
		int num = (int)xbdfb620b7167944b.BaseStream.Position;
		int num2 = 0;
		num2 |= (xdade2366eaa6f.x5ac0ad056c3fce83 ? 1 : 0);
		num2 |= (xdade2366eaa6f.xa7e6dbdb484bb52e ? 2 : 0);
		num2 |= ((xdade2366eaa6f.xe690cef2446c7d46.MainDocumentType != 0) ? 4 : 0);
		num2 |= (int)x6beba47238e0ade6.FootnoteOptions.Location << 5;
		xbdfb620b7167944b.Write((ushort)num2);
		num2 = 0;
		num2 |= (int)x6beba47238e0ade6.FootnoteOptions.RestartRule;
		num2 |= x6beba47238e0ade6.FootnoteOptions.StartNumber << 2;
		xbdfb620b7167944b.Write((ushort)num2);
		num2 = 0;
		num2 |= 0xF1;
		num2 |= ((!xdade2366eaa6f.xaca8557eea824bc0) ? 2048 : 0);
		num2 |= (xdade2366eaa6f.xdf76d3eeb73027d7 ? 4096 : 0);
		num2 |= (xdade2366eaa6f.x25c2aa42b1eb10e5 ? 16384 : 0);
		num2 |= (xdade2366eaa6f.x98c0ec6ac7570a99 ? 32768 : 0);
		xbdfb620b7167944b.Write((ushort)num2);
		num2 = 0;
		num2 |= 0x80;
		num2 |= (xdade2366eaa6f.x35eed0f3116ef422 ? 4 : 0);
		num2 |= (xdade2366eaa6f.xd2884179402343a8 ? 8 : 0);
		bool flag = xdade2366eaa6f.xcadc354ab6a177f1.x491ce6cbe2c9a184 == ProtectionType.AllowOnlyComments || xdade2366eaa6f.xcadc354ab6a177f1.x491ce6cbe2c9a184 == ProtectionType.ReadOnly;
		num2 |= (flag ? 16 : 0);
		num2 |= (xdade2366eaa6f.xd02fc99dc9c3221e ? 32 : 0);
		num2 |= ((xdade2366eaa6f.xcadc354ab6a177f1.x491ce6cbe2c9a184 == ProtectionType.AllowOnlyFormFields) ? 512 : 0);
		num2 |= (xdade2366eaa6f.xcadc354ab6a177f1.x3db5335cdcd5d88b ? 1024 : 0);
		num2 |= (xdade2366eaa6f.x14fd633e1477f9de ? 2048 : 0);
		num2 |= (xdade2366eaa6f.x10aeaa8cd2751f43 ? 4096 : 0);
		num2 |= ((xdade2366eaa6f.xcadc354ab6a177f1.x491ce6cbe2c9a184 == ProtectionType.AllowOnlyRevisions) ? 16384 : 0);
		num2 |= (xdade2366eaa6f.x26622336636caa4d ? 32768 : 0);
		xbdfb620b7167944b.Write((ushort)num2);
		CompatibilityOptions xe322902ca0e695f = xdade2366eaa6f.xe322902ca0e695f5;
		num2 = x0379299248a1d3ec(xe322902ca0e695f);
		xbdfb620b7167944b.Write((ushort)num2);
		xbdfb620b7167944b.Write((ushort)xdade2366eaa6f.xd72f9bc5cc53fc1c);
		xbdfb620b7167944b.Write((ushort)0);
		xbdfb620b7167944b.Write((ushort)xdade2366eaa6f.x91faf128d9e0425f);
		xbdfb620b7167944b.Write((ushort)xdade2366eaa6f.xfaa0f593a0704d95);
		xbdfb620b7167944b.Write((ushort)0);
		xed28c1e5772a17ea.xb7bb7be409813705(x6beba47238e0ade6.BuiltInDocumentProperties.CreatedTime, xbdfb620b7167944b);
		xed28c1e5772a17ea.xb7bb7be409813705(x6beba47238e0ade6.BuiltInDocumentProperties.LastSavedTime, xbdfb620b7167944b);
		xed28c1e5772a17ea.xb7bb7be409813705(x6beba47238e0ade6.BuiltInDocumentProperties.LastPrinted, xbdfb620b7167944b);
		xbdfb620b7167944b.Write((short)x6beba47238e0ade6.BuiltInDocumentProperties.RevisionNumber);
		xbdfb620b7167944b.Write(x6beba47238e0ade6.BuiltInDocumentProperties.TotalEditingTime);
		xbdfb620b7167944b.Write(x6beba47238e0ade6.BuiltInDocumentProperties.Words);
		xbdfb620b7167944b.Write(x6beba47238e0ade6.BuiltInDocumentProperties.Characters);
		xbdfb620b7167944b.Write((short)1);
		xbdfb620b7167944b.Write(x6beba47238e0ade6.BuiltInDocumentProperties.Paragraphs);
		num2 = 0;
		num2 |= (int)x6beba47238e0ade6.EndnoteOptions.RestartRule;
		num2 |= x6beba47238e0ade6.EndnoteOptions.StartNumber << 2;
		xbdfb620b7167944b.Write((ushort)num2);
		num2 = 0;
		num2 |= (int)x6beba47238e0ade6.EndnoteOptions.Location;
		num2 |= (xdade2366eaa6f.x15b47472ae0f4bf5 ? 1024 : 0);
		num2 |= (xdade2366eaa6f.xc64ebc14fbb01a1c ? 2048 : 0);
		num2 |= ((!xdade2366eaa6f.x75c79d4f5c4f8bd1) ? 4096 : 0);
		xbdfb620b7167944b.Write((ushort)num2);
		xbdfb620b7167944b.Write(1);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write((short)1);
		xbdfb620b7167944b.Write(1);
		xbdfb620b7167944b.Write(1);
		xbdfb620b7167944b.Write(xdade2366eaa6f.xcadc354ab6a177f1.xf111d6890e7de382);
		num2 = 0;
		num2 |= (int)x6beba47238e0ade6.ViewOptions.ViewType;
		num2 |= x6beba47238e0ade6.ViewOptions.ZoomPercent << 3;
		num2 |= (int)x6beba47238e0ade6.ViewOptions.ZoomType << 12;
		num2 |= (xdade2366eaa6f.xe1c58df4343d599e ? 32768 : 0);
		xbdfb620b7167944b.Write((ushort)num2);
		num2 = x0379299248a1d3ec(xe322902ca0e695f);
		xbdfb620b7167944b.Write((uint)num2);
		xbdfb620b7167944b.Write((ushort)xdade2366eaa6f.x5cdb67c2d32f8a3a);
		num2 = 0;
		num2 |= (xdade2366eaa6f.xa7c8accbf82b9f90 ? 1 : 0);
		num2 |= (int)xdade2366eaa6f.x2b3870f998fa2689 << 1;
		num2 |= (xdade2366eaa6f.x5478764877a094bc ? 8 : 0);
		num2 |= (xdade2366eaa6f.xb8230cce4c519a2a ? 32 : 0);
		int num3 = x93b05c1ad709a695.xe9e31472d474c9fc(xdade2366eaa6f.xb63452877389667b);
		num2 |= num3 << 7;
		xbdfb620b7167944b.Write((ushort)num2);
		char[] array = new char[101];
		int num4 = 0;
		if (xdade2366eaa6f.xfc71ac47a3606511 != null)
		{
			num4 = Math.Min(101, xdade2366eaa6f.xfc71ac47a3606511.Length);
			xdade2366eaa6f.xfc71ac47a3606511.CopyTo(0, array, 0, num4);
		}
		char[] array2 = new char[51];
		int num5 = 0;
		if (xdade2366eaa6f.x466141be69711980 != null)
		{
			num5 = Math.Min(51, xdade2366eaa6f.x466141be69711980.Length);
			xdade2366eaa6f.x466141be69711980.CopyTo(0, array2, 0, num5);
		}
		xbdfb620b7167944b.Write((short)num4);
		xbdfb620b7167944b.Write((short)num5);
		xbdfb620b7167944b.Write(array);
		xbdfb620b7167944b.Write(array2);
		xbdfb620b7167944b.Write((short)xdade2366eaa6f.x88b1df8cde4d7483);
		xbdfb620b7167944b.Write((short)xdade2366eaa6f.xd4d02d35f9fd2c1a);
		xbdfb620b7167944b.Write((short)xdade2366eaa6f.xf0c98b9a5846f66c);
		xbdfb620b7167944b.Write((short)xdade2366eaa6f.xac305e755359cb11);
		num2 = 0;
		num2 |= xdade2366eaa6f.xc731b34015cd8a41;
		num2 |= (xdade2366eaa6f.xe695bafc01728ebd ? 128 : 0);
		num2 |= xdade2366eaa6f.x95a4a50d4ad3f396 << 8;
		num2 |= (xdade2366eaa6f.x5a27e3b345b6aa73 ? 32768 : 0);
		xbdfb620b7167944b.Write((ushort)num2);
		num2 = 0;
		num2 |= xdade2366eaa6f.x084871122611bbee << 1;
		num2 |= ((xdade2366eaa6f.x2ee91d7d1f22f253 != 0) ? 32 : 0);
		num2 |= ((xdade2366eaa6f.x2ee91d7d1f22f253 == xf1ca9e6f44822582.xfed52103abb3a632) ? 64 : 0);
		num2 |= (xdade2366eaa6f.xacad582ef7f5d121 ? 128 : 0);
		num2 |= (xdade2366eaa6f.xa935a347c7c02364 ? 256 : 0);
		num2 |= (xdade2366eaa6f.xcea5a6633f25e074 ? 512 : 0);
		num2 |= 0x400;
		num2 |= (xdade2366eaa6f.xb460e2e11d4e8429 ? 2048 : 0);
		num2 |= ((!xdade2366eaa6f.x8af0b297a9d474ad) ? 4096 : 0);
		num2 |= ((!xdade2366eaa6f.x636013cbf60f10b8) ? 8192 : 0);
		xbdfb620b7167944b.Write((ushort)num2);
		num2 = 0;
		if (xdade2366eaa6f.x96afc98efa43d588)
		{
			x98b0e09ccece0a5a.xd28f53fd94b9c0e4(x57fef5933b41d0c2, WarningSource.Doc, "Word2003 versioning feature is not supported, AutoVersion option turned off");
		}
		xbdfb620b7167944b.Write((ushort)num2);
		xbdfb620b7167944b.Write((ushort)16);
		xbdfb620b7167944b.Write((ushort)25);
		xbdfb620b7167944b.Write(100);
		xbdfb620b7167944b.Write(25);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write((int)x6beba47238e0ade6.xa0a845678e16cf58);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(new byte[30]);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write((short)x6beba47238e0ade6.FootnoteOptions.NumberStyle);
		xbdfb620b7167944b.Write((short)x6beba47238e0ade6.EndnoteOptions.NumberStyle);
		xbdfb620b7167944b.Write((ushort)0);
		xbdfb620b7167944b.Write((ushort)0);
		xbdfb620b7167944b.Write((ushort)0);
		xbdfb620b7167944b.Write((ushort)xdade2366eaa6f.x9e5cdc25f2c99156);
		num2 = 0;
		num2 |= (xdade2366eaa6f.xb291c98fcefe576c ? 2 : 0);
		num2 |= ((!xdade2366eaa6f.x033ad91511e4e3ff) ? 512 : 0);
		num2 |= (xdade2366eaa6f.xc2d62826afc28ce5 ? 1024 : 0);
		num2 |= (xdade2366eaa6f.xbd16abbd8b896a52 ? 2048 : 0);
		num2 |= (int)xdade2366eaa6f.x86698283e3eda37c << 12;
		num2 |= ((!xdade2366eaa6f.x43d1e7077fb85de6) ? 65536 : 0);
		num2 |= ((!xdade2366eaa6f.x117cfa28c87eba97) ? 131072 : 0);
		num2 |= xdade2366eaa6f.x1115d25f593044ad << 18;
		num2 |= 0x10000000;
		xbdfb620b7167944b.Write(num2);
		num2 = x0379299248a1d3ec(xe322902ca0e695f);
		xbdfb620b7167944b.Write((uint)num2);
		num2 = 0;
		num2 |= (xe322902ca0e695f.ShapeLayoutLikeWW8 ? 1 : 0);
		num2 |= (xe322902ca0e695f.FootnoteLayoutLikeWW8 ? 2 : 0);
		num2 |= (xe322902ca0e695f.DoNotUseHTMLParagraphAutoSpacing ? 4 : 0);
		num2 |= ((!xe322902ca0e695f.AdjustLineHeightInTable) ? 8 : 0);
		num2 |= (xe322902ca0e695f.ForgetLastTabAlignment ? 16 : 0);
		num2 |= (xe322902ca0e695f.AutoSpaceLikeWord95 ? 32 : 0);
		num2 |= (xe322902ca0e695f.AlignTablesRowByRow ? 64 : 0);
		num2 |= (xe322902ca0e695f.LayoutRawTableWidth ? 128 : 0);
		num2 |= (xe322902ca0e695f.LayoutTableRowsApart ? 256 : 0);
		num2 |= (xe322902ca0e695f.UseWord97LineBreakRules ? 512 : 0);
		num2 |= (xe322902ca0e695f.DoNotBreakWrappedTables ? 1024 : 0);
		num2 |= (xe322902ca0e695f.DoNotSnapToGridInCell ? 2048 : 0);
		num2 |= (xe322902ca0e695f.SelectFldWithFirstOrLastChar ? 4096 : 0);
		num2 |= (xe322902ca0e695f.ApplyBreakingRules ? 8192 : 0);
		num2 |= (xe322902ca0e695f.DoNotWrapTextWithPunct ? 16384 : 0);
		num2 |= (xe322902ca0e695f.DoNotUseEastAsianBreakRules ? 32768 : 0);
		num2 |= (xe322902ca0e695f.UseWord2002TableStyleRules ? 65536 : 0);
		num2 |= (xe322902ca0e695f.GrowAutofit ? 131072 : 0);
		num2 |= (xe322902ca0e695f.UseNormalStyleForList ? 262144 : 0);
		num2 |= (xe322902ca0e695f.DoNotUseIndentAsNumberingTabStop ? 524288 : 0);
		num2 |= (xe322902ca0e695f.UseAltKinsokuLineBreakRules ? 1048576 : 0);
		num2 |= (xe322902ca0e695f.AllowSpaceOfSameStyleInTable ? 2097152 : 0);
		num2 |= (xe322902ca0e695f.DoNotSuppressIndentation ? 4194304 : 0);
		num2 |= (xe322902ca0e695f.DoNotAutofitConstrainedTables ? 8388608 : 0);
		num2 |= (xe322902ca0e695f.AutofitToFirstFixedWidthCell ? 16777216 : 0);
		num2 |= (xe322902ca0e695f.UnderlineTabInNumList ? 33554432 : 0);
		num2 |= (xe322902ca0e695f.DisplayHangulFixedWidth ? 67108864 : 0);
		num2 |= (xe322902ca0e695f.SplitPgBreakAndParaMark ? 134217728 : 0);
		num2 |= (xe322902ca0e695f.DoNotVertAlignCellWithSp ? 268435456 : 0);
		num2 |= (xe322902ca0e695f.DoNotBreakConstrainedForcedTable ? 536870912 : 0);
		num2 |= (xe322902ca0e695f.DoNotVertAlignInTxbx ? 1073741824 : 0);
		num2 |= (xe322902ca0e695f.UseAnsiKerningPairs ? int.MinValue : 0);
		xbdfb620b7167944b.Write((uint)num2);
		num2 = 0;
		num2 |= (xe322902ca0e695f.CachedColBalance ? 1 : 0);
		xbdfb620b7167944b.Write((uint)num2);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		num2 = 0;
		num2 |= (x6beba47238e0ade6.ViewOptions.DoNotDisplayPageBoundaries ? 131072 : 0);
		num2 |= (xdade2366eaa6f.x329a4e432765a448 ? 8388608 : 0);
		num2 |= 0x8000000;
		num2 |= (xdade2366eaa6f.x0171de9b8f68ad5c ? 268435456 : 0);
		num2 |= (xdade2366eaa6f.x3b978168870d58e9 ? 536870912 : 0);
		num2 |= ((!xdade2366eaa6f.x02b20ac01ba667b2) ? 1073741824 : 0);
		num2 |= (xdade2366eaa6f.xf53b772003bc9d00 ? int.MinValue : 0);
		xbdfb620b7167944b.Write((uint)num2);
		xbdfb620b7167944b.Write(0u);
		num2 = 0;
		num2 |= (xdade2366eaa6f.x53c2568d1dfe1449 ? 1 : 0);
		num2 |= ((!xdade2366eaa6f.x434c293eda734492) ? 8 : 0);
		num2 |= (xdade2366eaa6f.x365333836dd8035a ? 16 : 0);
		num2 |= (xdade2366eaa6f.x6116d416354a4a7e ? 64 : 0);
		num2 |= (xdade2366eaa6f.xcb55fa1ad5b5e650 ? 128 : 0);
		num2 |= (xdade2366eaa6f.x73abf66e0a11af0c ? 2048 : 0);
		num2 |= (xdade2366eaa6f.xf858f41dbb36ed12 ? 4096 : 0);
		num2 |= (xdade2366eaa6f.x445faafef4d65da6 ? 8192 : 0);
		num2 |= (xdade2366eaa6f.x4fa98f9c55cbae19 ? 16384 : 0);
		num2 |= (xdade2366eaa6f.x78187b055ec235b4 ? 32768 : 0);
		xbdfb620b7167944b.Write((ushort)num2);
		xbdfb620b7167944b.Write((ushort)xdade2366eaa6f.x22840ca6171e1b22);
		xbdfb620b7167944b.Write((ushort)0);
		xbdfb620b7167944b.Write((ushort)xdade2366eaa6f.xfc32bf4854f4898d);
		xbdfb620b7167944b.Write((ushort)xdade2366eaa6f.xf62aa4c5d803502a);
		xbdfb620b7167944b.Write((uint)xdade2366eaa6f.x64d2067aa07ebd4f);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write((uint)xdade2366eaa6f.xba77a088a86a2b66);
		num2 = 0;
		num2 |= ((xdade2366eaa6f.xcadc354ab6a177f1.x491ce6cbe2c9a184 == ProtectionType.ReadOnly) ? 1 : 0);
		num2 |= (xdade2366eaa6f.xcadc354ab6a177f1.x4eae8f1c9ec0d2ae ? 2 : 0);
		num2 |= (xdade2366eaa6f.xcadc354ab6a177f1.x84a58b01dbef401d ? 4 : 0);
		num2 |= (xdade2366eaa6f.x1a8b9b3f9527c259 ? 8 : 0);
		num2 |= (xdade2366eaa6f.x2c67db9a06eaf625 ? 16 : 0);
		num2 |= (xdade2366eaa6f.x2cc4b92e8cd6e124 ? 128 : 0);
		num2 |= (xdade2366eaa6f.x6980630e657b6aad ? 256 : 0);
		num2 |= (xdade2366eaa6f.x8749385938ab4a85 ? 2048 : 0);
		num2 |= (xdade2366eaa6f.x7c692ff62009f114 ? 4096 : 0);
		xbdfb620b7167944b.Write((uint)num2);
		num2 = 0;
		num2 |= (xdade2366eaa6f.xf50b9f8bbf8fb90c ? 1 : 0);
		num2 |= (xdade2366eaa6f.x809d83e59e8bfabb ? 2 : 0);
		num2 |= (xdade2366eaa6f.x21351dc18ee481b7 ? 4 : 0);
		num2 |= (xdade2366eaa6f.xcadc354ab6a177f1.x0cbff01514c02c1b ? 8 : 0);
		num2 = (xdade2366eaa6f.xcadc354ab6a177f1.x5410a63599038a04 switch
		{
			ProtectionType.AllowOnlyRevisions => num2, 
			ProtectionType.AllowOnlyComments => num2 | 0x10, 
			ProtectionType.AllowOnlyFormFields => num2 | 0x20, 
			ProtectionType.ReadOnly => num2 | 0x30, 
			ProtectionType.NoProtection => num2 | (xdade2366eaa6f.xcadc354ab6a177f1.x0cbff01514c02c1b ? 112 : 48), 
			_ => throw new InvalidOperationException("Unknown document protection type."), 
		}) | (x6beba47238e0ade6.ViewOptions.DisplayBackgroundShape ? 128 : 0);
		xbdfb620b7167944b.Write((ushort)num2);
		xbdfb620b7167944b.Write((ushort)0);
		xbdfb620b7167944b.Write((ushort)0);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write((ushort)0);
		xbdfb620b7167944b.Write((ushort)0);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xf1e8503d3452d34e(xbdfb620b7167944b, x6beba47238e0ade6);
		return (int)xbdfb620b7167944b.BaseStream.Position - num;
	}

	private static void xf1e8503d3452d34e(BinaryWriter xbdfb620b7167944b, Document x6beba47238e0ade6)
	{
		xdade2366eaa6f915 xdade2366eaa6f = x6beba47238e0ade6.xdade2366eaa6f915;
		int num = 0;
		num |= (int)xdade2366eaa6f.x1c605672f036e9e1.x3b85abfed6d4424f;
		int xb56517bd05ef77f = (int)xdade2366eaa6f.x1c605672f036e9e1.xb56517bd05ef77f6;
		num |= xb56517bd05ef77f << 2;
		int x78266b0e9c = (int)xdade2366eaa6f.x1c605672f036e9e1.x78266b0e9c142786;
		num |= x78266b0e9c << 4;
		num |= (xdade2366eaa6f.x1c605672f036e9e1.xaf8d6a43346515c6 ? 256 : 0);
		int x8b277d8dd2e2d7af = (int)xdade2366eaa6f.x1c605672f036e9e1.x8b277d8dd2e2d7af;
		num |= x8b277d8dd2e2d7af << 9;
		int x07f824b6513692d = (int)xdade2366eaa6f.x1c605672f036e9e1.x07f824b6513692d8;
		num |= x07f824b6513692d << 10;
		num |= (xdade2366eaa6f.x1c605672f036e9e1.x11227fd74d91663d ? 2048 : 0);
		num |= (xdade2366eaa6f.x1c605672f036e9e1.x92447f7677982e86 ? 4096 : 0);
		xbdfb620b7167944b.Write((uint)num);
		xbdfb620b7167944b.Write((ushort)x6beba47238e0ade6.FontInfos.x04327ff503798cdd(xdade2366eaa6f.x1c605672f036e9e1.xddffcb24e864cfcc));
		xbdfb620b7167944b.Write((uint)xdade2366eaa6f.x1c605672f036e9e1.xc8a7b7ce5c5279ee);
		xbdfb620b7167944b.Write((uint)xdade2366eaa6f.x1c605672f036e9e1.x3fa6fa3075fd558f);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write(0u);
		xbdfb620b7167944b.Write((uint)xdade2366eaa6f.x1c605672f036e9e1.x3810b9f8f9111f8a);
	}

	private static int x0379299248a1d3ec(CompatibilityOptions x87b12a2d3f48ccc8)
	{
		int num = 0;
		num |= (x87b12a2d3f48ccc8.NoTabHangInd ? 1 : 0);
		num |= (x87b12a2d3f48ccc8.NoSpaceRaiseLower ? 2 : 0);
		num |= (x87b12a2d3f48ccc8.SuppressSpBfAfterPgBrk ? 4 : 0);
		num |= (x87b12a2d3f48ccc8.WrapTrailSpaces ? 8 : 0);
		num |= (x87b12a2d3f48ccc8.PrintColBlack ? 16 : 0);
		num |= (x87b12a2d3f48ccc8.NoColumnBalance ? 32 : 0);
		num |= (x87b12a2d3f48ccc8.ConvMailMergeEsc ? 64 : 0);
		num |= (x87b12a2d3f48ccc8.SuppressTopSpacing ? 128 : 0);
		num |= (x87b12a2d3f48ccc8.UseSingleBorderforContiguousCells ? 256 : 0);
		num |= (x87b12a2d3f48ccc8.TransparentMetafiles ? 512 : 0);
		num |= (x87b12a2d3f48ccc8.ShowBreaksInFrames ? 1024 : 0);
		num |= (x87b12a2d3f48ccc8.SwapBordersFacingPgs ? 2048 : 0);
		num |= ((!x87b12a2d3f48ccc8.DoNotLeaveBackslashAlone) ? 4096 : 0);
		num |= ((!x87b12a2d3f48ccc8.DoNotExpandShiftReturn) ? 8192 : 0);
		num |= ((!x87b12a2d3f48ccc8.UlTrailSpace) ? 16384 : 0);
		num |= ((!x87b12a2d3f48ccc8.BalanceSingleByteDoubleByteWidth) ? 32768 : 0);
		num |= (x87b12a2d3f48ccc8.SuppressSpacingAtTopOfPage ? 65536 : 0);
		num |= (x87b12a2d3f48ccc8.SpacingInWholePoints ? 131072 : 0);
		num |= (x87b12a2d3f48ccc8.PrintBodyTextBeforeHeader ? 262144 : 0);
		num |= (x87b12a2d3f48ccc8.NoLeading ? 524288 : 0);
		num |= ((!x87b12a2d3f48ccc8.SpaceForUL) ? 1048576 : 0);
		num |= (x87b12a2d3f48ccc8.MWSmallCaps ? 2097152 : 0);
		num |= (x87b12a2d3f48ccc8.SuppressTopSpacingWP ? 4194304 : 0);
		num |= (x87b12a2d3f48ccc8.TruncateFontHeightsLikeWP6 ? 8388608 : 0);
		num |= (x87b12a2d3f48ccc8.SubFontBySize ? 16777216 : 0);
		num |= (x87b12a2d3f48ccc8.LineWrapLikeWord6 ? 33554432 : 0);
		num |= (x87b12a2d3f48ccc8.DoNotSuppressParagraphBorders ? 67108864 : 0);
		num |= (x87b12a2d3f48ccc8.NoExtraLineSpacing ? 134217728 : 0);
		num |= (x87b12a2d3f48ccc8.SuppressBottomSpacing ? 268435456 : 0);
		num |= (x87b12a2d3f48ccc8.WPSpaceWidth ? 536870912 : 0);
		num |= (x87b12a2d3f48ccc8.WPJustification ? 1073741824 : 0);
		return num | (x87b12a2d3f48ccc8.UsePrinterMetrics ? int.MinValue : 0);
	}

	private static void x7366eccc4b770fb3(xdade2366eaa6f915 x94aec03cf2ae750b, int x8e15aa2edd06439a)
	{
		if (x8e15aa2edd06439a >= 674)
		{
			x94aec03cf2ae750b.xe322902ca0e695f5 = CompatibilityOptions.xc947b7feabe5206d();
		}
		else if (x8e15aa2edd06439a >= 616)
		{
			x94aec03cf2ae750b.xe322902ca0e695f5 = CompatibilityOptions.x241adf6b8b1047e4();
		}
		else if (x8e15aa2edd06439a >= 594)
		{
			x94aec03cf2ae750b.xe322902ca0e695f5 = CompatibilityOptions.xbbd6fba96ae00fc2();
		}
		else if (x8e15aa2edd06439a >= 544)
		{
			x94aec03cf2ae750b.xe322902ca0e695f5 = CompatibilityOptions.xb76f161f953bf380();
		}
		else
		{
			x94aec03cf2ae750b.xe322902ca0e695f5 = CompatibilityOptions.x96ee55fa2e97929d();
		}
		x94aec03cf2ae750b.xe322902ca0e695f5.UICompat97To2003 = true;
	}

	private x1f93754c360623ac()
	{
	}
}
