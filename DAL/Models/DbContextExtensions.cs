﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DAL.Repository;

using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;


namespace DAL.Models
{
    public static class DbContextExtensions
    {
        /// <summary>
        /// Refresh non-detached entities
        /// </summary>
        /// <param name="dbContext">context of the entities</param>
        /// <param name="entityType">when specified only entities of that type are refreshed. when null all non-detached entities are modified</param>
        /// <returns></returns>
        public static DbContext RefreshEntites(this DbContext dbContext, Type entityType)
        {
            //https://christianarg.wordpress.com/2013/06/13/entityframework-refreshall-loaded-entities-from-database/
            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
            var refreshableObjects = objectContext.ObjectStateManager
                .GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified | EntityState.Unchanged)
                .Where(x => entityType == null || x.Entity.GetType() == entityType)
                .Where(entry => entry.EntityKey != null)
                .Select(e => e.Entity)
                .ToArray();

            objectContext.Refresh(RefreshMode.StoreWins, refreshableObjects);

            return dbContext;
        }

        public static DbContext RefreshAllEntites(this DbContext dbContext)
        {
            return RefreshEntites(dbContext: dbContext, entityType: null); //null entityType is a wild card
        }

        public static DbContext RefreshEntites<TEntity>(this DbContext dbContext, RefreshMode refreshMode)
        {
            return RefreshEntites(dbContext: dbContext, entityType: typeof(TEntity));
        }
    }
}
