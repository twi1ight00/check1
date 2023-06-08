using System;
using System.Data;

namespace Dapper;

public interface IWrappedDataReader : IDataReader, IDisposable, IDataRecord
{
	IDataReader Reader { get; }

	IDbCommand Command { get; }
}
