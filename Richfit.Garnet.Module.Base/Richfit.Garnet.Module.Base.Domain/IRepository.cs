using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.Base.Infrastructure.Data;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Base.Domain;

/// <summary>
/// 仓储（Repository）接口定义
/// </summary>
/// <typeparam name="TEntity">仓储操作的数据实体类型；数据实体类型都继承于 <see cref="T:Richfit.Garnet.Module.Base.Domain.Entity" />。</typeparam>
/// <remarks>
/// 每个仓储只操作一种数据实体，数据实体都继承于 <see cref="T:Richfit.Garnet.Module.Base.Domain.Entity" />。
/// </remarks>
public interface IRepository<TEntity> : IDisposable, IRepositoryExtender, ISql, ISqlQueryConverter where TEntity : Entity
{
	/// <summary>
	/// 获取当前仓储的数据库上下文
	/// </summary>
	/// <value>当前仓储使用的数据库上下文对象</value>
	IDBContext DbContext { get; }

	/// <summary>
	/// 向当前仓储中添加数据实体
	/// </summary>
	/// <param name="entity">待添加的数据实体</param>
	/// <param name="schema">实体结构定义</param>
	/// <remarks>
	/// 本方法会影响数据实体的下列属性：
	/// <list type="bullet">
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Creator">Creator</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.CreateTime">CreateTime</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Modifier">Modifier</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.ModifyTime">ModifyTime</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.IsDel">IsDel</see></description></item>
	/// </list>
	/// </remarks>
	void Add(TEntity entity, EntitySchema schema = null);

	/// <summary>
	/// 向当前仓储中批量添加数据实体
	/// </summary>
	/// <param name="entities">待添加的数据实体列表</param>
	/// <param name="schema">实体结构定义</param>
	/// <remarks>
	/// 本方法会影响数据实体的下列属性：
	/// <list type="bullet">
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Creator">Creator</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.CreateTime">CreateTime</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Modifier">Modifier</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.ModifyTime">ModifyTime</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.IsDel">IsDel</see></description></item>
	/// </list>
	/// </remarks>
	void Add(IEnumerable<TEntity> entities, EntitySchema schema = null);

	/// <summary>
	/// 向当前仓储中添加数据实体并保存
	/// </summary>
	/// <param name="entity">待添加的数据实体</param>
	/// <param name="schema">实体结构定义</param>
	/// <remarks>
	/// 本方法会影响数据实体的下列属性：
	/// <list type="bullet">
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Creator">Creator</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.CreateTime">CreateTime</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Modifier">Modifier</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.ModifyTime">ModifyTime</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.IsDel">IsDel</see></description></item>
	/// </list>
	/// </remarks>
	void AddCommit(TEntity entity, EntitySchema schema = null);

	/// <summary>
	/// 向当前仓储中批量添加数据实体并保存
	/// </summary>
	/// <param name="entities">待添加的数据实体的列表</param>
	/// <param name="schema">实体结构定义</param>
	/// <remarks>
	/// 本方法会影响数据实体的下列属性：
	/// <list type="bullet">
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Creator">Creator</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.CreateTime">CreateTime</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Modifier">Modifier</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.ModifyTime">ModifyTime</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.IsDel">IsDel</see></description></item>
	/// </list>
	/// </remarks>
	void AddCommit(IEnumerable<TEntity> entities, EntitySchema schema = null);

	/// <summary>
	/// 向当前仓储中批量添加数据实体，为了提升效率，只限数据实体本身，如果有子实体忽略
	/// </summary>
	/// <param name="entities"></param>
	/// <param name="schema"></param>
	/// <remarks>
	/// 本方法会影响数据实体的下列属性：
	/// <list type="bullet">
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Creator">Creator</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.CreateTime">CreateTime</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Modifier">Modifier</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.ModifyTime">ModifyTime</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.IsDel">IsDel</see></description></item>
	/// </list>
	/// </remarks>
	void BulkAddCommit(IEnumerable<TEntity> entities, EntitySchema schema = null);

	/// <summary>
	/// 在当前仓储中修改数据实体
	/// </summary>
	/// <param name="entity">待修改的数据实体</param>
	/// <param name="modifiedChildren">实体中数据有变动的子表属性名称，为了提高子表处理效率，只将变动的子表名称传入；默认为空，表示处理所有子表属性。</param>
	/// <remarks>
	/// 本方法会影响数据实体的下列属性：
	/// <list type="bullet">
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Modifier">Modifier</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.ModifyTime">ModifyTime</see></description></item>
	/// </list>
	/// </remarks>
	void Update(TEntity entity, params string[] modifiedChildren);

	/// <summary>
	/// 在当前仓储中修改数据实体
	/// </summary>
	/// <param name="entity">待修改的数据实体</param>
	/// <param name="modifiedChildren">实体中数据有变动的子表属性名称，为了提高子表处理效率，只将变动的子表名称传入；默认为空，表示处理所有子表属性。</param>
	/// <param name="schema">实体结构定义</param>
	/// <remarks>
	/// 本方法会影响数据实体的下列属性：
	/// <list type="bullet">
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Modifier">Modifier</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.ModifyTime">ModifyTime</see></description></item>
	/// </list>
	/// </remarks>
	void Update(TEntity entity, string[] modifiedChildren, EntitySchema schema = null);

	/// <summary>
	/// 在当前仓储中批量修改数据实体
	/// </summary>
	/// <param name="entities">待修改的数据实体列表</param>
	/// <param name="modifiedChildren">实体中数据有变动的子表属性名称，为了提高子表处理效率，只将变动的子表名称传入；默认为空，表示处理所有子表属性。</param>
	/// <remarks>
	/// 本方法会影响数据实体的下列属性：
	/// <list type="bullet">
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Modifier">Modifier</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.ModifyTime">ModifyTime</see></description></item>
	/// </list>
	/// </remarks>
	void Update(IEnumerable<TEntity> entities, params string[] modifiedChildren);

	/// <summary>
	/// 在当前仓储中批量修改数据实体
	/// </summary>
	/// <param name="entities">待修改的数据实体列表</param>
	/// <param name="modifiedChildren">实体中数据有变动的子表属性名称，为了提高子表处理效率，只将变动的子表名称传入；默认为空，表示处理所有子表属性。</param>
	/// <param name="schema">实体结构定义</param>
	/// <remarks>
	/// 本方法会影响数据实体的下列属性：
	/// <list type="bullet">
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Modifier">Modifier</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.ModifyTime">ModifyTime</see></description></item>
	/// </list>
	/// </remarks>
	void Update(IEnumerable<TEntity> entities, string[] modifiedChildren, EntitySchema schema = null);

	/// <summary>
	/// 在当前仓储中修改数据实体并保存
	/// </summary>
	/// <param name="entity">待修改的数据实体</param>
	/// <param name="modifiedChildren">实体中数据有变动的子表属性名称，为了提高子表处理效率，只将变动的子表名称传入；默认为空，表示处理所有子表属性。</param>
	/// <remarks>
	/// 本方法会影响数据实体的下列属性：
	/// <list type="bullet">
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Modifier">Modifier</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.ModifyTime">ModifyTime</see></description></item>
	/// </list>
	/// </remarks>
	void UpdateCommit(TEntity entity, params string[] modifiedChildren);

	/// <summary>
	/// 在当前仓储中修改数据实体并保存
	/// </summary>
	/// <param name="entity">待修改的数据实体</param>
	/// <param name="modifiedChildren">实体中数据有变动的子表属性名称，为了提高子表处理效率，只将变动的子表名称传入；默认为空，表示处理所有子表属性。</param>
	/// <param name="schema">实体结构定义</param>
	/// <remarks>
	/// 本方法会影响数据实体的下列属性：
	/// <list type="bullet">
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Modifier">Modifier</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.ModifyTime">ModifyTime</see></description></item>
	/// </list>
	/// </remarks>
	void UpdateCommit(TEntity entity, string[] modifiedChildren, EntitySchema schema = null);

	/// <summary>
	/// 在当前仓储中批量修改数据实体并保存
	/// </summary>
	/// <param name="entities">待修改的数据实体列表</param>
	/// <param name="modifiedChildren">实体中数据有变动的子表属性名称，为了提高子表处理效率，只将变动的子表名称传入；默认为空，表示处理所有子表属性。</param>
	/// <remarks>
	/// 本方法会影响数据实体的下列属性：
	/// <list type="bullet">
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Modifier">Modifier</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.ModifyTime">ModifyTime</see></description></item>
	/// </list>
	/// </remarks>
	void UpdateCommit(IEnumerable<TEntity> entities, params string[] modifiedChildren);

	/// <summary>
	/// 在当前仓储中批量修改数据实体并保存
	/// </summary>
	/// <param name="entities">待修改的数据实体列表</param>
	/// <param name="modifiedChildren">实体中数据有变动的子表属性名称，为了提高子表处理效率，只将变动的子表名称传入；默认为空，表示处理所有子表属性。</param>
	/// <param name="schema">实体结构定义</param>
	/// <remarks>
	/// 本方法会影响数据实体的下列属性：
	/// <list type="bullet">
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.Modifier">Modifier</see></description></item>
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.ModifyTime">ModifyTime</see></description></item>
	/// </list>
	/// </remarks>
	void UpdateCommit(IEnumerable<TEntity> entities, string[] modifiedChildren, EntitySchema schema = null);

	/// <summary>
	/// 从当前仓储中移除数据实体
	/// </summary>
	/// <param name="entity">待移除的数据实体</param>
	void Remove(TEntity entity);

	/// <summary>
	/// 从当前仓储中批量移除数据实体
	/// </summary>
	/// <param name="entities">待移除的数据实体列表</param>
	void Remove(IEnumerable<TEntity> entities);

	/// <summary>
	/// 从当前仓储中移除数据；按照以某字符分割的ID字符串的方式批量删除数据
	/// </summary>
	/// <param name="ids">ID字符串</param>
	/// <param name="spliter">ID分隔符</param>
	void Remove(string ids, string spliter = ",");

	/// <summary>
	/// 从当前仓储中移除数据实体并保存
	/// </summary>
	/// <param name="entity">待移除的数据实体</param>
	void RemoveCommit(TEntity entity);

	/// <summary>
	/// 从当前仓储中批量移除数据实体并保存
	/// </summary>
	/// <param name="entities">待移除的数据实体列表</param>
	void RemoveCommit(IEnumerable<TEntity> entities);

	/// <summary>
	/// 从当前仓储中移除数据并保存；按照以某字符分割的ID字符串的方式批量删除数据
	/// </summary>
	/// <param name="ids">ID字符串</param>
	/// <param name="spliter">ID分隔符</param>
	void RemoveCommit(string ids, string spliter = ",");

	/// <summary>
	/// 从当前仓储中逻辑移除数据；按照以某字符分割的ID字符串的方式批量逻辑删除数据
	/// </summary>
	/// <param name="ids">ID字符串</param>
	/// <param name="schema">实体结构定义</param>
	/// <param name="spliter">ID分隔符</param>
	/// <remarks>
	/// 本方法会影响数据实体的下列属性：
	/// <list type="bullet">
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.IsDel">IsDel</see></description></item>
	/// </list>
	/// </remarks>
	void LogicRemove(string ids, string spliter = ",", EntitySchema schema = null);

	/// <summary>
	/// 从当前仓储中逻辑移除数据并保存；按照以某字符分割的ID字符串的方式批量逻辑删除数据
	/// </summary>
	/// <param name="ids">ID字符串</param>
	/// <param name="spliter">ID分隔符</param>
	/// <param name="schema">实体结构定义</param>
	/// <remarks>
	/// 本方法会影响数据实体的下列属性：
	/// <list type="bullet">
	/// <item><description><see cref="P:Richfit.Garnet.Module.Base.Domain.EntitySchema.IsDel">IsDel</see></description></item>
	/// </list>
	/// </remarks>
	void LogicRemoveCommit(string ids, string spliter = ",", EntitySchema schema = null);

	/// <summary>
	/// 根据主键值获取数据实体.
	/// </summary>
	/// <param name="key">数据实体的主键值</param>
	/// <returns>与指定主键值匹配的数据实体</returns>
	TEntity GetByKey(object key);

	/// <summary>
	/// 检测满足指定规格的数据实体是否存在.
	/// </summary>
	/// <param name="specification">数据实体的规格检测条件</param>
	/// <returns>如果匹配的数据实体存在返回true，否则返回false。</returns>
	bool Exists(ISpecification<TEntity> specification);

	/// <summary>
	/// 将数据实体的原始值替换后为当前值
	/// </summary>
	/// <param name="origin">数据对象的原始值</param>
	/// <param name="current">数据对象的当前值</param>
	void Merge(TEntity origin, TEntity current);

	/// <summary>
	/// 合并仓储中两个数据实体，将原对象的值修改为当前对象的值
	/// </summary>
	/// <typeparam name="TObject">数据实体类型</typeparam>
	/// <param name="sourceEntity">原对象</param>
	/// <param name="currentEntity">当前对象</param>
	void Merge<TObject>(TObject sourceEntity, TObject currentEntity) where TObject : Entity;

	/// <summary>
	/// 将多个查询条件转化为数据实体的规格对象，用于对数据实体的查询
	/// </summary>
	/// <param name="items">查询条件</param>
	/// <returns>查询条件相应的当前数据实体的规格</returns>
	ISpecification<TEntity> GetSpecification(IEnumerable<QueryItem> items);

	/// <summary>
	/// 将某个查询条件转化为数据实体的规格对象，用于对数据实体的查询
	/// </summary>
	/// <param name="item">查询条件</param>
	/// <returns>查询条件相应的当前数据实体的规格</returns>
	ISpecification<TEntity> GetSpecification(QueryItem item);

	/// <summary>
	/// 查找与指定的规格相匹配的数据实体
	/// </summary>
	/// <param name="specification">数据实体筛选规格</param>
	/// <returns>与规格匹配的数据实体</returns>
	TEntity Find(ISpecification<TEntity> specification);

	/// <summary>
	/// 根据LINQ表达式查找相匹配的数据实体
	/// </summary>
	/// <param name="expression">实体查询LINQ表达式</param>
	/// <returns>查询返回实体</returns>
	TEntity Find(Expression<Func<TEntity, bool>> expression);

	/// <summary>
	/// 查找与指定的规格相匹配的数据实体并加载相关对象
	/// </summary>
	/// <param name="specification">匹配的规格.</param>
	/// <param name="eagerLoadingProperties">加载的属性</param>
	/// <returns>单个对象</returns>
	TEntity Find(ISpecification<TEntity> specification, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <summary>
	/// 根据LINQ表达式查找相匹配的数据实体并加载相关对象
	/// </summary>
	/// <param name="expression">实体查询LINQ表达式</param>
	/// <param name="eagerLoadingProperties">加载的属性表达式</param>
	/// <returns>单个实体</returns>
	TEntity Find(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <summary>
	/// 查询所有数据实体。
	/// </summary>
	/// <returns>数据实体列表</returns>
	IList<TEntity> FindAll();

	/// <summary>
	/// 分页查询所有数据实体。
	/// </summary>
	/// <param name="pageIndex">页索引</param>
	/// <param name="pageSize">每页记录数量</param>
	/// <returns>指定页中包含的数据实体列表</returns>
	IList<TEntity> FindAll(int pageIndex, int pageSize);

	/// <summary>
	/// 按照指定的排序表达式分页查询所有数据实体。
	/// </summary>
	/// <param name="sortExpress">排序表达式，根据实体属性排序</param>
	/// <param name="pageIndex">页索引</param>
	/// <param name="pageSize">每页记录数量</param>
	/// <returns>指定页中包含的数据实体列表</returns>
	/// <remark>
	/// 排序表达式的样例： Category.CategoryName, UnitPrice desc
	/// </remark>
	IList<TEntity> FindAll(string sortExpress, int pageIndex, int pageSize);

	/// <summary>
	/// 查询与指定规格相匹配的所有数据实体
	/// </summary>
	/// <param name="specification">数据实体的筛选规格</param>
	/// <returns>与指定规格匹配的数据实体列表</returns>
	IList<TEntity> FindAll(ISpecification<TEntity> specification);

	/// <summary>
	/// LINQ查询相匹配的所有数据实体
	/// </summary>
	/// <param name="expression">实体查询LINQ表达式</param>
	/// <returns>实体集合</returns>
	IList<TEntity> FindAll(Expression<Func<TEntity, bool>> expression);

	/// <summary>
	/// 分页查询满足指定规格的数据实体
	/// </summary>
	/// <param name="specification">匹配的规格对象</param>
	/// <param name="pageIndex">页索引</param>
	/// <param name="pageSize">每页记录数量</param>
	/// <returns>指定页中包含的数据实体列表</returns>
	IList<TEntity> FindAll(ISpecification<TEntity> specification, int pageIndex, int pageSize);

	/// <summary>
	/// LINQ分页查询实体集合
	/// </summary>
	/// <param name="expression">实体查询LINQ表达式</param>
	/// <param name="pageIndex">页索引</param>
	/// <param name="pageSize">每页记录数量</param>
	/// <returns>实体集合</returns>
	IList<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize);

	/// <summary>
	/// 按照指定的排序表达式分页查询满足指定规格的数据实体
	/// </summary>
	/// <param name="specification">匹配的规格对象</param>
	/// <param name="sortExpress">排序表达式，根据对象属性排序</param>
	/// <param name="pageIndex">页索引</param>
	/// <param name="pageSize">每页记录数量</param>
	/// <returns>与指定规格匹配的数据实体列表</returns>
	/// <remarks>
	/// 排序表达式的样例： Category.CategoryName, UnitPrice desc
	/// </remarks>
	IList<TEntity> FindAll(ISpecification<TEntity> specification, string sortExpress, int pageIndex, int pageSize);

	/// <summary>
	/// 根据LINQ表达式按照指定的排序表达式分页查询数据实体
	/// </summary>
	/// <param name="expression">实体查询LINQ表达式</param>
	/// <param name="sortExpress">排序表达式，根据对象属性排序</param>
	/// <param name="pageIndex">页索引</param>
	/// <param name="pageSize">每页记录数量</param>
	/// <returns>实体集合</returns>
	/// <remarks>
	/// 排序表达式的样例： Category.CategoryName, UnitPrice desc
	/// </remarks>
	IList<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, string sortExpress, int pageIndex, int pageSize);

	/// <summary>
	/// 查询所有数据实体并加载相关对象
	/// </summary>
	/// <param name="eagerLoadingProperties">贪婪加载相关对象表达式数组</param>
	/// <returns>加载的数据实体列表</returns>
	IList<TEntity> FindAll(params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <summary>
	/// 分页查询所有数据实体并加载相关对象
	/// </summary>
	/// <param name="pageIndex">页索引</param>
	/// <param name="pageSize">每页记录数量</param>
	/// <param name="eagerLoadingProperties">贪婪加载相关对象表达式数组</param>
	/// <returns>指定页中包含的数据实体列表</returns>
	IList<TEntity> FindAll(int pageIndex, int pageSize, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <summary>
	/// 按照指定的排序表达式分页查询满足指定规格的数据实体并加载相关对象
	/// </summary>
	/// <param name="sortExpress">排序表达式，根据对象属性排序</param>
	/// <param name="pageIndex">页索引</param>
	/// <param name="pageSize">每页记录数量</param>
	/// <param name="eagerLoadingProperties">贪婪加载相关对象表达式数组</param>
	/// <returns>指定页中包含的数据实体列表</returns>
	/// <remarks>
	/// 排序表达式的样例： Category.CategoryName, UnitPrice desc
	/// </remarks>
	IList<TEntity> FindAll(string sortExpress, int pageIndex, int pageSize, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <summary>
	/// 查询满足指定规格的数据实体并加载相关对象
	/// </summary>
	/// <param name="specification">匹配的规格对象</param>
	/// <param name="eagerLoadingProperties">贪婪加载相关对象表达式数组</param>
	/// <returns>所有满足指定规格的数据实体</returns>
	IList<TEntity> FindAll(ISpecification<TEntity> specification, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <summary>
	/// LINQ查询数据实体并加载相关对象
	/// </summary>
	/// <param name="expression">实体查询LINQ表达式</param>
	/// <param name="eagerLoadingProperties">贪婪加载相关对象表达式数组</param>
	/// <returns>实体集合</returns>
	IList<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <summary>
	/// 分页查询满足指定规格的对象并加载相关对象
	/// </summary>
	/// <param name="specification">匹配的规格对象</param>
	/// <param name="pageIndex">页索引</param>
	/// <param name="pageSize">每页记录数量</param>
	/// <param name="eagerLoadingProperties">贪婪加载相关对象表达式数组</param>
	/// <returns>指定页中包含的数据实体列表</returns>
	IList<TEntity> FindAll(ISpecification<TEntity> specification, int pageIndex, int pageSize, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <summary>
	/// LINQ分页查询对象并加载相关对象
	/// </summary>
	/// <param name="expression">实体查询LINQ表达式</param>
	/// <param name="pageIndex">页索引</param>
	/// <param name="pageSize">每页记录数量</param>
	/// <param name="eagerLoadingProperties">贪婪加载相关对象表达式数组</param>
	/// <returns>实体集合</returns>
	IList<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <summary>
	/// 按照指定的排序表达式分查询满足指定规格的对象并加载相关对象
	/// </summary>
	/// <param name="specification">匹配的规格对象</param>
	/// <param name="sortExpress">排序表达式，根据对象属性排序</param>
	/// <param name="eagerLoadingProperties">贪婪加载相关对象表达式数组</param>
	/// <returns>所有满足指定规格的实体列表</returns>
	/// <remarks>
	/// 排序表达式的样例： Category.CategoryName, UnitPrice desc
	/// </remarks>
	IList<TEntity> FindAll(ISpecification<TEntity> specification, string sortExpress, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <summary>
	/// LINQ按照指定的排序表达式查询对象并加载相关对象
	/// </summary>
	/// <param name="expression">实体查询LINQ表达式</param>
	/// <param name="sortExpress">排序表达式，根据对象属性排序</param>
	/// <param name="eagerLoadingProperties">贪婪加载相关对象表达式数组</param>
	/// <returns>实体集合</returns>
	/// <remarks>
	/// 排序表达式的样例： Category.CategoryName, UnitPrice desc
	/// </remarks>
	IList<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, string sortExpress, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <summary>
	/// 按照指定的排序表达式分页查询满足指定规格的对象并加载相关对象
	/// </summary>
	/// <param name="specification">匹配的规格对象</param>
	/// <param name="sortExpress">排序表达式，根据对象属性排序</param>
	/// <param name="pageIndex">每页记录数量</param>
	/// <param name="pageSize">每页记录数量</param>
	/// <param name="eagerLoadingProperties">贪婪加载相关对象表达式数组</param>
	/// <returns>指定页中包含的数据实体列表</returns>
	/// <remarks>
	/// 排序表达式的样例： Category.CategoryName, UnitPrice desc
	/// </remarks>
	IList<TEntity> FindAll(ISpecification<TEntity> specification, string sortExpress, int pageIndex, int pageSize, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <summary>
	/// LINQ按照指定的排序表达式分页查询对象并加载相关对象
	/// </summary>
	/// <param name="expression">实体查询LINQ表达式</param>
	/// <param name="sortExpress">排序表达式，根据对象属性排序</param>
	/// <param name="pageIndex">每页记录数量</param>
	/// <param name="pageSize">每页记录数量</param>
	/// <param name="eagerLoadingProperties">贪婪加载相关对象表达式数组</param>
	/// <returns>指定页中包含的数据实体列表</returns>
	/// <remarks>
	/// 排序表达式的样例： Category.CategoryName, UnitPrice desc
	/// </remarks>
	IList<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, string sortExpress, int pageIndex, int pageSize, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties);

	/// <summary>
	/// 在当前仓储中获取满足指定规格条件的数据实体的数量
	/// </summary>
	/// <param name="specification">数据实体的筛选规格</param>
	/// <returns></returns>
	int GetCount(ISpecification<TEntity> specification);

	/// <summary>
	/// 向当前仓储中添加数据实体，用于仓储直接增加子表的情况
	/// </summary>
	/// <typeparam name="TChildEntity">子表数据实体类型</typeparam>
	/// <param name="entity">待添加的子表数据实例</param>
	void AddChild<TChildEntity>(TChildEntity entity) where TChildEntity : Entity;

	/// <summary>
	/// 向当前仓储中添加数据实体，用于仓储直接增加子表的情况
	/// </summary>
	/// <typeparam name="TChildEntity">子表数据实体类型</typeparam>
	/// <param name="entities">待添加的子表数据实例列表</param>
	void AddChild<TChildEntity>(IEnumerable<TChildEntity> entities) where TChildEntity : Entity;

	/// <summary>
	/// 在当前仓储中移除指定的数据实体，用于从仓储中直接删除子表的情况
	/// </summary>
	/// <param name="entity">待移除的数据实体</param>
	void RemoveChild(Entity entity);

	/// <summary>
	/// 在当前仓储中移除指定的数据实体，用于从仓储中直接删除子表的情况
	/// </summary>
	/// <typeparam name="TChildEntity">子表数据实体类型</typeparam>
	/// <param name="entities">待移除的数据实体列表</param>
	void RemoveChild<TChildEntity>(IEnumerable<TChildEntity> entities) where TChildEntity : Entity;

	/// <summary>
	/// 重新加载数据实体
	/// </summary>
	/// <typeparam name="TObject">数据实体类型</typeparam>
	/// <param name="entity">待刷新的数据实体</param>
	void Reload<TObject>(TObject entity) where TObject : Entity;
}
