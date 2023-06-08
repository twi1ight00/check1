namespace System.Data.Entity.ModelConfiguration.Utilities;

internal class DatabaseName
{
	private readonly string _name;

	private readonly string _schema;

	public string Name => _name;

	public string Schema => _schema;

	public DatabaseName(string name)
		: this(name, null)
	{
	}

	public DatabaseName(string name, string schema)
	{
		_name = name;
		_schema = schema;
	}

	public override string ToString()
	{
		string text = _name;
		if (_schema != null)
		{
			text = _schema + "." + text;
		}
		return text;
	}

	public bool Equals(DatabaseName other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (string.Equals(other._name, _name, StringComparison.Ordinal))
		{
			return string.Equals(other._schema, _schema, StringComparison.Ordinal);
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
		if (obj.GetType() != typeof(DatabaseName))
		{
			return false;
		}
		return Equals((DatabaseName)obj);
	}

	public override int GetHashCode()
	{
		return (_name.GetHashCode() * 397) ^ ((_schema != null) ? _schema.GetHashCode() : 0);
	}
}
