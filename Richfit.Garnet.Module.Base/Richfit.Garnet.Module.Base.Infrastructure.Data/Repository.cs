using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Dynamic;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data;

/// <summary>
/// 仓储基类
/// </summary>
/// <typeparam name="TEntity">仓储操作的数据实体类型；数据实体类型都继承于 <see cref="T:Richfit.Garnet.Module.Base.Domain.Entity" />。</typeparam>
public abstract class Repository<TEntity> : IRepository<TEntity>, IDisposable, IRepositoryExtender, ISql, ISqlQueryConverter where TEntity : Entity
{
	/// <summary>
	/// 日志对象，可从继承类中调用
	/// </summary>
	protected static readonly ILogger logger = LoggerManager.GetLogger();

	/// <summary>
	/// 仓储使用的数据库上下文
	/// </summary>
	private IDBContext dbContext;

	/// <summary>
	/// 是否已清理标识
	/// </summary>
	private bool isDisosing = false;

	/// <inheritdoc />
	public virtual IDBContext DbContext => dbContext;

	/// <summary>
	/// 使用指定的数据库上下文初始化仓储
	/// </summary>
	/// <param name="dbContext">仓储使用的数据库上下文</param>
	public Repository(IDBContext dbContext)
	{
		this.dbContext = dbContext.GuardNotNull("Database Context");
	}

	/// <inheritdoc />
	public void Add(TEntity entity, EntitySchema schema = null)
	{
		DoAdd(entity, schema.IfNull(EntitySchema.Default));
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.Add(`0,Richfit.Garnet.Module.Base.Domain.EntitySchema)" />
	protected abstract void DoAdd(TEntity entity, EntitySchema schema);

	/// <inheritdoc />
	public void Add(IEnumerable<TEntity> entities, EntitySchema schema = null)
	{
		DoAdd(entities, schema.IfNull(EntitySchema.Default));
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.Add(System.Collections.Generic.IEnumerable{`0},Richfit.Garnet.Module.Base.Domain.EntitySchema)" />
	protected abstract void DoAdd(IEnumerable<TEntity> entities, EntitySchema schema);

	/// <inheritdoc />
	public void AddCommit(TEntity entity, EntitySchema schema = null)
	{
		DoAddCommit(entity, schema.IfNull(EntitySchema.Default));
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.AddCommit(`0,Richfit.Garnet.Module.Base.Domain.EntitySchema)" />
	protected abstract void DoAddCommit(TEntity entity, EntitySchema schema);

	/// <inheritdoc />
	public void AddCommit(IEnumerable<TEntity> entities, EntitySchema schema = null)
	{
		DoAddCommit(entities, schema.IfNull(EntitySchema.Default));
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.AddCommit(`0,Richfit.Garnet.Module.Base.Domain.EntitySchema)" />
	protected abstract void DoAddCommit(IEnumerable<TEntity> entities, EntitySchema schema);

	/// <inheritdoc />
	public void BulkAddCommit(IEnumerable<TEntity> entities, EntitySchema schema = null)
	{
		DoBulkAddCommit(entities, schema.IfNull(EntitySchema.Default));
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.BulkAddCommit(System.Collections.Generic.IEnumerable{`0},Richfit.Garnet.Module.Base.Domain.EntitySchema)" />
	protected abstract void DoBulkAddCommit(IEnumerable<TEntity> entities, EntitySchema schema = null);

	/// <inheritdoc />
	public void Update(TEntity entity, params string[] modifiedChildren)
	{
		DoUpdate(entity, modifiedChildren, EntitySchema.Default);
	}

	/// <inheritdoc />
	public void Update(TEntity entity, string[] modifiedChildren, EntitySchema schema = null)
	{
		DoUpdate(entity, modifiedChildren, schema.IfNull(EntitySchema.Default));
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.Update(`0,System.String[],Richfit.Garnet.Module.Base.Domain.EntitySchema)" />
	protected abstract void DoUpdate(TEntity entity, string[] modifiedChildren, EntitySchema schema);

	/// <inheritdoc />
	public void Update(IEnumerable<TEntity> entities, params string[] modifiedChildren)
	{
		DoUpdate(entities, modifiedChildren, EntitySchema.Default);
	}

	/// <inheritdoc />
	public void Update(IEnumerable<TEntity> entities, string[] modifiedChildren, EntitySchema schema = null)
	{
		DoUpdate(entities, modifiedChildren, schema.IfNull(EntitySchema.Default));
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.Update(`0,System.String[],Richfit.Garnet.Module.Base.Domain.EntitySchema)" />
	protected abstract void DoUpdate(IEnumerable<TEntity> entities, string[] modifiedChildren, EntitySchema schema);

	/// <inheritdoc />
	public void UpdateCommit(TEntity entity, params string[] modifiedChildren)
	{
		DoUpdateCommit(entity, modifiedChildren, EntitySchema.Default);
	}

	/// <inheritdoc />
	public void UpdateCommit(TEntity entity, string[] modifiedChildren, EntitySchema schema = null)
	{
		DoUpdateCommit(entity, modifiedChildren, schema.IfNull(EntitySchema.Default));
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.UpdateCommit(`0,System.String[],Richfit.Garnet.Module.Base.Domain.EntitySchema)" />
	protected abstract void DoUpdateCommit(TEntity entity, string[] modifiedChildren, EntitySchema schema);

	/// <inheritdoc />
	public void UpdateCommit(IEnumerable<TEntity> entities, params string[] modifiedChildren)
	{
		DoUpdateCommit(entities, modifiedChildren, EntitySchema.Default);
	}

	/// <inheritdoc />
	public void UpdateCommit(IEnumerable<TEntity> entities, string[] modifiedChildren, EntitySchema schema = null)
	{
		DoUpdateCommit(entities, modifiedChildren, schema.IfNull(EntitySchema.Default));
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.UpdateCommit(System.Collections.Generic.IEnumerable{`0},System.String[],Richfit.Garnet.Module.Base.Domain.EntitySchema)" />
	protected abstract void DoUpdateCommit(IEnumerable<TEntity> entities, string[] modifiedChildren, EntitySchema schema);

	/// <inheritdoc />
	public void Remove(TEntity entity)
	{
		DoRemove(entity);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.Remove(`0)" />
	protected abstract void DoRemove(TEntity entity);

	/// <inheritdoc />
	public void Remove(IEnumerable<TEntity> entities)
	{
		DoRemove(entities);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.Remove(System.Collections.Generic.IEnumerable{`0})" />
	protected abstract void DoRemove(IEnumerable<TEntity> entities);

	/// <inheritdoc />
	public void Remove(string ids, string spliter = ",")
	{
		DoRemove(ids, spliter);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.Remove(System.String,System.String)" />
	protected abstract void DoRemove(string ids, string spliter);

	/// <inheritdoc />
	public void RemoveCommit(TEntity entity)
	{
		DoRemoveCommit(entity);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.RemoveCommit(`0)" />
	protected abstract void DoRemoveCommit(TEntity entity);

	/// <inheritdoc />
	public void RemoveCommit(IEnumerable<TEntity> entities)
	{
		DoRemoveCommit(entities);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.RemoveCommit(System.Collections.Generic.IEnumerable{`0})" />
	protected abstract void DoRemoveCommit(IEnumerable<TEntity> entities);

	/// <inheritdoc />
	public void RemoveCommit(string ids, string spliter = ",")
	{
		DoRemoveCommit(ids, spliter);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.RemoveCommit(System.String,System.String)" />
	protected abstract void DoRemoveCommit(string ids, string spliter);

	/// <inheritdoc />
	public void LogicRemove(string ids, string spliter = ",", EntitySchema schema = null)
	{
		DoLogicRemove(ids, spliter, schema.IfNull(EntitySchema.Default));
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.LogicRemove(System.String,System.String,Richfit.Garnet.Module.Base.Domain.EntitySchema)" />
	protected abstract void DoLogicRemove(string ids, string spliter, EntitySchema schema);

	/// <inheritdoc />
	public void LogicRemoveCommit(string ids, string spliter = ",", EntitySchema schema = null)
	{
		DoLogicRemoveCommit(ids, spliter, schema.IfNull(EntitySchema.Default));
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.LogicRemoveCommit(System.String,System.String,Richfit.Garnet.Module.Base.Domain.EntitySchema)" />
	protected abstract void DoLogicRemoveCommit(string ids, string spliter, EntitySchema schema);

	/// <inheritdoc />
	public TEntity GetByKey(object key)
	{
		return DoGetByKey(key);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.GetByKey(System.Object)" />
	protected abstract TEntity DoGetByKey(object key);

	/// <inheritdoc />
	public bool Exists(ISpecification<TEntity> specification)
	{
		return DoExists(specification);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.Exists(Richfit.Garnet.Module.Base.Domain.Specifications.ISpecification{`0})" />
	protected abstract bool DoExists(ISpecification<TEntity> specification);

	/// <inheritdoc />
	public void Merge(TEntity origin, TEntity current)
	{
		DoMerge(origin, current);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.Merge(`0,`0)" />
	protected abstract void DoMerge(TEntity origin, TEntity current);

	/// <inhertdoc />
	public void Merge<TObject>(TObject sourceEntity, TObject currentEntity) where TObject : Entity
	{
		DoMerge(sourceEntity, currentEntity);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.Merge``1(``0,``0)" />
	protected abstract void DoMerge<TObject>(TObject sourceEntity, TObject currentEntity) where TObject : Entity;

	/// <inheritdoc />
	public ISpecification<TEntity> GetSpecification(IEnumerable<QueryItem> items)
	{
		return LinqQueryConverter<TEntity>.ConvertSpecification(items);
	}

	/// <inheritdoc />
	public ISpecification<TEntity> GetSpecification(QueryItem item)
	{
		return LinqQueryConverter<TEntity>.ConvertSpecification(item);
	}

	/// <inheritdoc />
	public TEntity Find(ISpecification<TEntity> specification)
	{
		return DoFind(specification);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.Find(Richfit.Garnet.Module.Base.Domain.Specifications.ISpecification{`0})" />
	protected abstract TEntity DoFind(ISpecification<TEntity> specification);

	/// <inheritdoc />
	public TEntity Find(ISpecification<TEntity> specification, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		return DoFind(specification, eagerLoadingProperties);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.Find(Richfit.Garnet.Module.Base.Domain.Specifications.ISpecification{`0},System.Linq.Expressions.Expression{System.Func{`0,System.Object}}[])" />
	protected abstract TEntity DoFind(ISpecification<TEntity> specification, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <inheritdoc />
	public TEntity Find(Expression<Func<TEntity, bool>> expression)
	{
		ISpecification<TEntity> specification = new ExpressionSpecification<TEntity>(expression);
		return Find(specification);
	}

	/// <inheritdoc />
	public TEntity Find(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		ISpecification<TEntity> specification = new ExpressionSpecification<TEntity>(expression);
		return Find(specification, eagerLoadingProperties);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll()
	{
		return DoFindAll(new AnySpecification<TEntity>(), string.Empty);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(int pageIndex, int pageSize)
	{
		return DoFindAll(new AnySpecification<TEntity>(), string.Empty, pageIndex, pageSize);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(string sortExpress, int pageIndex, int pageSize)
	{
		return DoFindAll(new AnySpecification<TEntity>(), sortExpress, pageIndex, pageSize);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(int pageIndex, int pageSize, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		return DoFindAll(new AnySpecification<TEntity>(), string.Empty, pageIndex, pageSize, eagerLoadingProperties);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(string sortExpress, int pageIndex, int pageSize, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		return DoFindAll(new AnySpecification<TEntity>(), sortExpress, pageIndex, pageSize, eagerLoadingProperties);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(ISpecification<TEntity> specification)
	{
		return DoFindAll(specification, string.Empty);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(ISpecification<TEntity> specification, int pageIndex, int pageSize)
	{
		return DoFindAll(specification, string.Empty, pageIndex, pageSize);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(ISpecification<TEntity> specification, string sortExpress, int pageIndex, int pageSize)
	{
		return DoFindAll(specification, sortExpress, pageIndex, pageSize);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(ISpecification<TEntity> specification, string sortExpress, int pageIndex, int pageSize, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		return DoFindAll(specification, sortExpress, pageIndex, pageSize, eagerLoadingProperties);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(ISpecification<TEntity> specification, int pageIndex, int pageSize, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		return DoFindAll(specification, string.Empty, pageIndex, pageSize, eagerLoadingProperties);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		return DoFindAll(new AnySpecification<TEntity>(), string.Empty, eagerLoadingProperties);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(ISpecification<TEntity> specification, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		return DoFindAll(specification, string.Empty, eagerLoadingProperties);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(ISpecification<TEntity> specification, string sortExpress, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		return DoFindAll(specification, sortExpress, eagerLoadingProperties);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(Expression<Func<TEntity, bool>> expression)
	{
		ISpecification<TEntity> specification = new ExpressionSpecification<TEntity>(expression);
		return FindAll(specification);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize)
	{
		ISpecification<TEntity> specification = new ExpressionSpecification<TEntity>(expression);
		return FindAll(specification, pageIndex, pageSize);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, string sortExpress, int pageIndex, int pageSize)
	{
		ISpecification<TEntity> specification = new ExpressionSpecification<TEntity>(expression);
		return FindAll(specification, sortExpress, pageIndex, pageSize);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		ISpecification<TEntity> specification = new ExpressionSpecification<TEntity>(expression);
		return FindAll(specification, eagerLoadingProperties);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		ISpecification<TEntity> specification = new ExpressionSpecification<TEntity>(expression);
		return FindAll(specification, pageIndex, pageSize, eagerLoadingProperties);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, string sortExpress, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		ISpecification<TEntity> specification = new ExpressionSpecification<TEntity>(expression);
		return FindAll(specification, sortExpress, eagerLoadingProperties);
	}

	/// <inheritdoc />
	public IList<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, string sortExpress, int pageIndex, int pageSize, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		ISpecification<TEntity> specification = new ExpressionSpecification<TEntity>(expression);
		return FindAll(specification, sortExpress, pageIndex, pageSize, eagerLoadingProperties);
	}

	/// <summary>
	/// 分页查询满足指定规格的对象(有排序参数)
	/// </summary>
	/// <param name="specification">匹配的规格对象</param>
	/// <param name="sortExpress">排序表达式，根据对象属性排序</param>
	/// <param name="pageIndex">页索引</param>
	/// <param name="pageSize">每页记录数量</param>
	/// <returns>某页的对象.</returns>
	/// <remarks>
	/// 排序表达式的样例： Category.CategoryName, UnitPrice desc
	/// </remarks>
	protected abstract IList<TEntity> DoFindAll(ISpecification<TEntity> specification, string sortExpress, int pageIndex, int pageSize);

	/// <summary>
	/// 分页查询满足指定规格的对象(有排序参数)，贪婪加载相关对象
	/// </summary>
	/// <param name="specification">匹配的规格对象</param>
	/// <param name="sortExpress">排序表达式，根据对象属性排序</param>
	/// <param name="eagerLoadingProperties">贪婪加载相关对象表达式数组</param>
	/// <returns>所有满足指定规格的对象</returns>
	/// <remarks>
	/// 排序表达式的样例： Category.CategoryName, UnitPrice desc
	/// </remarks>
	protected abstract IList<TEntity> DoFindAll(ISpecification<TEntity> specification, string sortExpress, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <summary>
	/// 分页查询满足指定规格的对象(有排序参数)，贪婪加载相关对象
	/// </summary>
	/// <param name="specification">匹配的规格对象</param>
	/// <param name="sortExpress">排序表达式，根据对象属性排序</param>
	/// <param name="pageIndex">每页记录数量</param>
	/// <param name="pageSize">每页记录数量</param>
	/// <param name="eagerLoadingProperties">贪婪加载相关对象表达式数组</param>
	/// <returns>满足指定规格的对象(单页)</returns>
	/// <remarks>
	/// 排序表达式的样例： Category.CategoryName, UnitPrice desc
	/// </remarks>
	protected abstract IList<TEntity> DoFindAll(ISpecification<TEntity> specification, string sortExpress, int pageIndex, int pageSize, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <inheritdoc />
	public int GetCount(ISpecification<TEntity> specification)
	{
		return DoGetCount(specification);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.GetCount(Richfit.Garnet.Module.Base.Domain.Specifications.ISpecification{`0})" />
	protected abstract int DoGetCount(ISpecification<TEntity> specification);

	/// <inheritdoc />
	public void AddChild<TChildEntity>(TChildEntity entity) where TChildEntity : Entity
	{
		DoAddChild(entity);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.AddChild``1(``0)" />
	protected abstract void DoAddChild<TChildEntity>(TChildEntity entity) where TChildEntity : Entity;

	/// <inheritdoc />
	public void AddChild<TChildEntity>(IEnumerable<TChildEntity> entities) where TChildEntity : Entity
	{
		DoAddChild(entities);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.AddChild``1(System.Collections.Generic.IEnumerable{``0})" />
	protected abstract void DoAddChild<TChildEntity>(IEnumerable<TChildEntity> entities) where TChildEntity : Entity;

	/// <inheritdoc />
	public void RemoveChild(Entity entity)
	{
		DoRemoveChild(entity);
	}

	/// <inheritdoc />
	public void RemoveChild<TChildEntity>(TChildEntity entity) where TChildEntity : Entity
	{
		DoRemoveChild(entity);
	}

	/// <inheritdoc />
	protected abstract void DoRemoveChild<TChildEntity>(TChildEntity entity) where TChildEntity : Entity;

	/// <inheritdoc />
	public void RemoveChild(IEnumerable<Entity> entities)
	{
		DoRemoveChild(entities);
	}

	/// <inheritdoc />
	public void RemoveChild<TChildEntity>(IEnumerable<TChildEntity> entities) where TChildEntity : Entity
	{
		DoRemoveChild(entities);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.RemoveChild``1(System.Collections.Generic.IEnumerable{``0})" />
	protected abstract void DoRemoveChild<TChildEntity>(IEnumerable<TChildEntity> entities) where TChildEntity : Entity;

	/// <inheritdoc />
	public void Reload<TObject>(TObject sourceEntity) where TObject : Entity
	{
		DoReload(sourceEntity);
	}

	/// <inheritdoc cref="M:Richfit.Garnet.Module.Base.Domain.IRepository`1.Reload``1(``0)" />
	protected abstract void DoReload<TObject>(TObject entity) where TObject : Entity;

	/// <inheritdoc />
	public virtual string GetSqlConfig(string sqlKey, Type type)
	{
		SqlStatement statement = ConfigurationManager.GetPackage(type).Sqls.GetSql(dbContext.GetDatabaseType(), sqlKey).GuardNotNull("Sql key not found.");
		return statement.Sql;
	}

	/// <inheritdoc />
	public virtual SqlStatement GetSqlStatement(string sqlKey, Type type)
	{
		return ConfigurationManager.GetPackage(type).Sqls.GetSql(dbContext.GetDatabaseType(), sqlKey).GuardNotNull("Sql key not found.");
	}

	/// <inheritdoc />
	public IList<IDataObject> DynamicSqlQuery(string sql, params object[] parameters)
	{
		return dbContext.DynamicSqlQuery(sql, parameters);
	}

	/// <inheritdoc />
	public IList<IDataObject>[] DynamicSqlQueryResults(string sql, params object[] parameters)
	{
		return dbContext.DynamicSqlQueryResults(sql, parameters);
	}

	/// <inheritdoc />
	public virtual int ExecuteCommand(string sql, params object[] parameters)
	{
		return dbContext.ExecuteCommand(sql, parameters);
	}

	/// <inheritdoc />
	public virtual IList<TObject> ExecuteQuery<TObject>(string sql, params object[] parameters)
	{
		return dbContext.ExecuteQuery<TObject>(sql, parameters);
	}

	/// <inheritdoc />
	public IList<TObject> ExecuteQuery<TObject>(string sql, object parameters)
	{
		return dbContext.ExecuteQuery<TObject>(sql, parameters);
	}

	/// <inheritdoc />
	public TObject ExecuteScalar<TObject>(string sql, params object[] parameters)
	{
		throw new NotImplementedException();
	}

	/// <inheritdoc />
	public virtual int GetCount(string sql, params object[] parameters)
	{
		return dbContext.GetCount(sql, parameters);
	}

	/// <inheritdoc />
	public virtual DbParameter CreateParameter(string parameterName, object value, ParameterDirection direction)
	{
		return dbContext.CreateParameter(parameterName, value, direction);
	}

	/// <inheritdoc />
	public string GetWhereSqlClause(IList<QueryItem> items, int parameterStartIndex = 0)
	{
		return dbContext.GetWhereSqlClause(items, parameterStartIndex);
	}

	/// <inheritdoc />
	public string GetWhereSqlClause(IList<QueryItem> items, int[] indexOrder, int parameterStartIndex = 0)
	{
		return dbContext.GetWhereSqlClause(items, indexOrder, parameterStartIndex);
	}

	/// <inheritdoc />
	public string GetWhereSqlClause(IList<QueryItem> items, int beginIndex, int length, int parameterStartIndex = 0)
	{
		return dbContext.GetWhereSqlClause(items, beginIndex, length, parameterStartIndex);
	}

	/// <inheritdoc />
	public string GetSql(string sql, QueryCondition condition, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		return dbContext.GetSql(sql, condition, formatParameters, parameterStartIndex);
	}

	/// <inheritdoc />
	public string GetSql(string sql, QueryCondition condition, int[] indexOrder, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		return dbContext.GetSql(sql, condition, indexOrder, formatParameters, parameterStartIndex);
	}

	/// <inheritdoc />
	public string GetSql(string sql, QueryCondition condition, int beginIndex, int length, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		return dbContext.GetSql(sql, condition, beginIndex, length, formatParameters, parameterStartIndex);
	}

	/// <inheritdoc />
	public string GetTotalCountSql(string sql, QueryCondition condition, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		return dbContext.GetTotalCountSql(sql, condition, formatParameters, parameterStartIndex);
	}

	/// <inheritdoc />
	public string GetTotalCountSql(string sql, QueryCondition condition, int[] indexOrder, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		return dbContext.GetTotalCountSql(sql, condition, indexOrder, formatParameters, parameterStartIndex);
	}

	/// <inheritdoc />
	public string GetTotalCountSql(string sql, QueryCondition condition, int beginIndex, int length, string[] formatParameters = null, int parameterStartIndex = 0)
	{
		return dbContext.GetTotalCountSql(sql, condition, beginIndex, length, formatParameters, parameterStartIndex);
	}

	/// <inheritdoc />
	public object[] GetWhereSqlParamValue(IList<QueryItem> items, int valueStartIndex = 0, int defaultParameterCount = 0)
	{
		return dbContext.GetWhereSqlParamValue(items, valueStartIndex, defaultParameterCount);
	}

	/// <inheritdoc />
	public object[] GetWhereSqlParamValue(IList<QueryItem> items, int[] indexOrder, int defaultParameterCount = 0)
	{
		return dbContext.GetWhereSqlParamValue(items, indexOrder, defaultParameterCount);
	}

	/// <inheritdoc />
	public object[] GetWhereSqlParamValue(IList<QueryItem> items, int beginIndex, int length, int defaultParameterCount)
	{
		return dbContext.GetWhereSqlParamValue(items, beginIndex, length, defaultParameterCount);
	}

	/// <summary>
	/// 清理仓储对象
	/// </summary>
	public void Dispose()
	{
		if (!isDisosing)
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
			isDisosing = true;
		}
	}

	/// <summary>
	/// 执行对象清理
	/// </summary>
	/// <param name="disposing">是否为显示调用清理</param>
	protected virtual void Dispose(bool disposing)
	{
		if (disposing && dbContext.IsNotNull())
		{
			dbContext.Dispose();
		}
	}
}
