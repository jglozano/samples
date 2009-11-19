namespace Persistence {
    using System;
    using System.Collections.Generic;
    using Domain;

    public interface ICRUDRepository<TEntity> where TEntity : EntityBase, new() {
        void Create(TEntity entity);
        TEntity Retrieve(Guid entityId);

        IList<TEntity> RetrieveAll();

        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}