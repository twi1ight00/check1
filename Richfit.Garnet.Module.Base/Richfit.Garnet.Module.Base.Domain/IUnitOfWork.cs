using System;

namespace Richfit.Garnet.Module.Base.Domain;

/// <summary>
/// 工作单元模式(UnitOfWork Pattern)接口
/// </summary>
/// <remarks>
/// Contract for ‘UnitOfWork pattern’. For more
/// related info see http://martinfowler.com/eaaCatalog/unitOfWork.html or
/// http://msdn.microsoft.com/en-us/magazine/dd882510.aspx
/// In this solution, the Unit Of Work is implemented using the out-of-box 
/// Entity Framework Context (EF 4.1 DbContext) persistence engine. But in order to
/// comply the PI (Persistence Ignorant) principle in our Domain, we implement this interface/contract. 
/// This interface/contract should be complied by any UoW implementation to be used with this Domain.
/// </remarks>
public interface IUnitOfWork : IDisposable
{
	/// <summary>
	/// 提交当前工作单元的全部变更;如果出现数据并发冲突则抛出异常。
	/// </summary>
	/// <remarks>
	/// Commit all changes made in a container.
	/// If the entity have fixed properties and any optimistic concurrency problem exists,  
	/// then an exception is thrown
	/// </remarks>
	void Commit();

	/// <summary>
	/// 提交当前工作单元的全部变更；忽略数据的并发冲突。
	/// </summary>
	/// <remarks>
	/// Commit all changes made in a container.
	/// If the entity have fixed properties and any optimistic concurrency problem exists,
	/// then 'client changes' are refreshed - Client wins
	/// </remarks>
	void CommitAndRefreshChanges();

	/// <summary>
	/// 放弃当前工作单元的全部变更。
	/// </summary>
	/// <remarks>
	/// Rollback tracked changes. See references of UnitOfWork pattern
	/// </remarks>
	void RollbackChanges();
}
