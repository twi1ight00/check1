using System.Collections;
using System.Collections.Generic;

namespace System.Data.Entity.Edm;

/// <summary>
///     Enumerates all <see cref="T:System.Data.Entity.Edm.EdmStructuralMember" /> s declared or inherited by an <see cref="T:System.Data.Entity.Edm.EdmStructuralType" /> .
/// </summary>
internal sealed class EdmStructuralTypeMemberCollection : IEnumerable<EdmStructuralMember>, IEnumerable
{
	private readonly Func<IEnumerable<EdmStructuralMember>> getAllMembers;

	private readonly Func<IEnumerable<EdmStructuralMember>> getDeclaredMembers;

	internal EdmStructuralTypeMemberCollection(Func<IEnumerable<EdmStructuralMember>> allMembers, Func<IEnumerable<EdmStructuralMember>> declaredMembers)
	{
		getAllMembers = allMembers;
		getDeclaredMembers = declaredMembers;
	}

	internal EdmStructuralTypeMemberCollection(Func<IEnumerable<EdmStructuralMember>> declaredMembers)
		: this(declaredMembers, declaredMembers)
	{
	}

	public IEnumerator<EdmStructuralMember> GetEnumerator()
	{
		return getAllMembers().GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return getAllMembers().GetEnumerator();
	}
}
