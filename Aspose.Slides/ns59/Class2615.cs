using ns223;

namespace ns59;

internal class Class2615
{
	private Class5985 class5985_0 = new Class5985();

	public Class2615(byte[] key)
	{
		class5985_0.method_4(key);
	}

	public byte[] method_0(byte[] encryptedData)
	{
		return Encrypt(encryptedData);
	}

	public byte[] Encrypt(byte[] data)
	{
		byte[] array = new byte[data.Length];
		class5985_0.method_1(data, array);
		return array;
	}
}
