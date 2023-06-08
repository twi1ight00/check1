using System;

namespace Richfit.Garnet.Module.Base.Domain;

/// <summary>
/// 标识生成器
/// </summary>
public static class IdentityGenerator
{
	/// <summary>
	/// 生成新的Guid值
	/// </summary>
	/// <returns>生成的Guid值</returns>
	/// <remarks>本方法调用 <see cref="M:System.Guid.NewGuid" /> 生成新的Guid值。</remarks>
	/// <seealso cref="M:System.Guid.NewGuid" />
	public static Guid NewGuid()
	{
		return Guid.NewGuid();
	}

	/// <summary>
	/// 生成新的连续Guid值
	/// </summary>
	/// <returns>生成的Guid值</returns>
	/// <remarks>
	/// 本方法生成连续的Guid值。
	/// 一个Guid值由16个字节组成：
	/// 高位8个字节根据当前时间的刻度值生成（<see cref="P:System.DateTime.Ticks" />），这样保持了生成Guid值的连续性；
	/// 低位8个字节为新生成的Guid值的低位8个字节，保证了生成的Guid值在时间刻度最小值量级上的唯一性。
	/// 使用连续的Guid值可以减少数据库索引的规模，加快查询速度。
	/// This algorithm generates sequential GUIDs across system boundaries, ideal for databases 
	/// </remarks>
	public static Guid NewSequentialGuid()
	{
		byte[] secuentialGuid = new byte[16];
		byte[] uid = Guid.NewGuid().ToByteArray();
		secuentialGuid[0] = uid[0];
		secuentialGuid[1] = uid[1];
		secuentialGuid[2] = uid[2];
		secuentialGuid[3] = uid[3];
		secuentialGuid[4] = uid[4];
		secuentialGuid[5] = uid[5];
		secuentialGuid[6] = uid[6];
		secuentialGuid[7] = (byte)(0xC0u | (0xFu & uid[7]));
		byte[] binDate = BitConverter.GetBytes(DateTime.UtcNow.Ticks);
		secuentialGuid[9] = binDate[0];
		secuentialGuid[8] = binDate[1];
		secuentialGuid[15] = binDate[2];
		secuentialGuid[14] = binDate[3];
		secuentialGuid[13] = binDate[4];
		secuentialGuid[12] = binDate[5];
		secuentialGuid[11] = binDate[6];
		secuentialGuid[10] = binDate[7];
		return new Guid(secuentialGuid);
	}
}
