using Aspose;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal sealed class x77c5e3c2e7f86c35
{
	private const int x5f1f6c759ae65fab = 15;

	private const int x34fdcf86e8d004e7 = 19;

	private const int x9149f7dbf48c8dff = 30;

	private const int x4f96630056849dc0 = 256;

	private const int x53c45999b03c0bd2 = 29;

	internal const int xdb1f7cd17273ab16 = 7;

	private static readonly int xec7cd4898f2b4021;

	internal static readonly short[] xc1f389d7a96b2a3c;

	internal static readonly short[] xeccbfbd8e6cd2e4b;

	internal static x77c5e3c2e7f86c35 x7b9c36d1a44272f5;

	internal static x77c5e3c2e7f86c35 x95d3ca8e98979afd;

	internal static x77c5e3c2e7f86c35 x5ec6d82d604ee1fb;

	internal short[] x7b5ab713bb96aa2a;

	internal int[] xdca5400fbc290588;

	internal int x20cbf09449a75540;

	internal int x40021148582028be;

	internal int x95ef8119d9d70648;

	internal x77c5e3c2e7f86c35(short[] static_tree, int[] extra_bits, int extra_base, int elems, int max_length)
	{
		x7b5ab713bb96aa2a = static_tree;
		xdca5400fbc290588 = extra_bits;
		x20cbf09449a75540 = extra_base;
		x40021148582028be = elems;
		x95ef8119d9d70648 = max_length;
	}

	static x77c5e3c2e7f86c35()
	{
		xec7cd4898f2b4021 = 286;
		xc1f389d7a96b2a3c = new short[576]
		{
			12, 8, 140, 8, 76, 8, 204, 8, 44, 8,
			172, 8, 108, 8, 236, 8, 28, 8, 156, 8,
			92, 8, 220, 8, 60, 8, 188, 8, 124, 8,
			252, 8, 2, 8, 130, 8, 66, 8, 194, 8,
			34, 8, 162, 8, 98, 8, 226, 8, 18, 8,
			146, 8, 82, 8, 210, 8, 50, 8, 178, 8,
			114, 8, 242, 8, 10, 8, 138, 8, 74, 8,
			202, 8, 42, 8, 170, 8, 106, 8, 234, 8,
			26, 8, 154, 8, 90, 8, 218, 8, 58, 8,
			186, 8, 122, 8, 250, 8, 6, 8, 134, 8,
			70, 8, 198, 8, 38, 8, 166, 8, 102, 8,
			230, 8, 22, 8, 150, 8, 86, 8, 214, 8,
			54, 8, 182, 8, 118, 8, 246, 8, 14, 8,
			142, 8, 78, 8, 206, 8, 46, 8, 174, 8,
			110, 8, 238, 8, 30, 8, 158, 8, 94, 8,
			222, 8, 62, 8, 190, 8, 126, 8, 254, 8,
			1, 8, 129, 8, 65, 8, 193, 8, 33, 8,
			161, 8, 97, 8, 225, 8, 17, 8, 145, 8,
			81, 8, 209, 8, 49, 8, 177, 8, 113, 8,
			241, 8, 9, 8, 137, 8, 73, 8, 201, 8,
			41, 8, 169, 8, 105, 8, 233, 8, 25, 8,
			153, 8, 89, 8, 217, 8, 57, 8, 185, 8,
			121, 8, 249, 8, 5, 8, 133, 8, 69, 8,
			197, 8, 37, 8, 165, 8, 101, 8, 229, 8,
			21, 8, 149, 8, 85, 8, 213, 8, 53, 8,
			181, 8, 117, 8, 245, 8, 13, 8, 141, 8,
			77, 8, 205, 8, 45, 8, 173, 8, 109, 8,
			237, 8, 29, 8, 157, 8, 93, 8, 221, 8,
			61, 8, 189, 8, 125, 8, 253, 8, 19, 9,
			275, 9, 147, 9, 403, 9, 83, 9, 339, 9,
			211, 9, 467, 9, 51, 9, 307, 9, 179, 9,
			435, 9, 115, 9, 371, 9, 243, 9, 499, 9,
			11, 9, 267, 9, 139, 9, 395, 9, 75, 9,
			331, 9, 203, 9, 459, 9, 43, 9, 299, 9,
			171, 9, 427, 9, 107, 9, 363, 9, 235, 9,
			491, 9, 27, 9, 283, 9, 155, 9, 411, 9,
			91, 9, 347, 9, 219, 9, 475, 9, 59, 9,
			315, 9, 187, 9, 443, 9, 123, 9, 379, 9,
			251, 9, 507, 9, 7, 9, 263, 9, 135, 9,
			391, 9, 71, 9, 327, 9, 199, 9, 455, 9,
			39, 9, 295, 9, 167, 9, 423, 9, 103, 9,
			359, 9, 231, 9, 487, 9, 23, 9, 279, 9,
			151, 9, 407, 9, 87, 9, 343, 9, 215, 9,
			471, 9, 55, 9, 311, 9, 183, 9, 439, 9,
			119, 9, 375, 9, 247, 9, 503, 9, 15, 9,
			271, 9, 143, 9, 399, 9, 79, 9, 335, 9,
			207, 9, 463, 9, 47, 9, 303, 9, 175, 9,
			431, 9, 111, 9, 367, 9, 239, 9, 495, 9,
			31, 9, 287, 9, 159, 9, 415, 9, 95, 9,
			351, 9, 223, 9, 479, 9, 63, 9, 319, 9,
			191, 9, 447, 9, 127, 9, 383, 9, 255, 9,
			511, 9, 0, 7, 64, 7, 32, 7, 96, 7,
			16, 7, 80, 7, 48, 7, 112, 7, 8, 7,
			72, 7, 40, 7, 104, 7, 24, 7, 88, 7,
			56, 7, 120, 7, 4, 7, 68, 7, 36, 7,
			100, 7, 20, 7, 84, 7, 52, 7, 116, 7,
			3, 8, 131, 8, 67, 8, 195, 8, 35, 8,
			163, 8, 99, 8, 227, 8
		};
		xeccbfbd8e6cd2e4b = new short[60]
		{
			0, 5, 16, 5, 8, 5, 24, 5, 4, 5,
			20, 5, 12, 5, 28, 5, 2, 5, 18, 5,
			10, 5, 26, 5, 6, 5, 22, 5, 14, 5,
			30, 5, 1, 5, 17, 5, 9, 5, 25, 5,
			5, 5, 21, 5, 13, 5, 29, 5, 3, 5,
			19, 5, 11, 5, 27, 5, 7, 5, 23, 5
		};
		x7b9c36d1a44272f5 = new x77c5e3c2e7f86c35(xc1f389d7a96b2a3c, x3ea78caabca59bc5.x0cfc2eeecc7d6a9d, 257, xec7cd4898f2b4021, 15);
		x95d3ca8e98979afd = new x77c5e3c2e7f86c35(xeccbfbd8e6cd2e4b, x3ea78caabca59bc5.xc9e73f383680dd02, 0, 30, 15);
		x5ec6d82d604ee1fb = new x77c5e3c2e7f86c35(null, x3ea78caabca59bc5.xdc9a394be06f5774, 0, 19, 7);
	}
}