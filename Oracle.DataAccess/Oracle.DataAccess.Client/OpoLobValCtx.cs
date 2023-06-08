namespace Oracle.DataAccess.Client;

internal struct OpoLobValCtx
{
	internal long inAmount;

	internal long outAmount;

	internal long src_offset;

	internal long dst_offset;

	internal long lobDataLength;

	internal long remainder;

	internal long totalAmount;

	internal long position;

	internal long count;

	internal long offset;

	internal int isFromEF;

	internal unsafe LobProperties* pLobProperties;
}
