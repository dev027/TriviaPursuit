using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tp.Data.DbContexts;
using Tp.Models.DbEntities;
using Tp.Utilities.Extensions.EnumExtensions;

namespace Tp.Data.DbEntities.Categories
{
    public class CategoryDb : BaseDb
    {
        #region Constructor

        private DataContext Context { get; }

        public CategoryDb(DataContext context)
        {
            Context = context;
        }

        #endregion Constructor

        #region Get

        #region Single

        public Category GetById(
            int categoryId,
            Category.Include include = Category.Include.None,
            bool isTracked = false)
        {
            return IsTracked(isTracked,
                    ReadInclude(
                        Context.Categories, include))
                .FirstOrDefault(c => c.Id == categoryId);
        }

        #endregion Single

        #region Multiple

        public IList<Category> GetAll(
            Category.Include include = Category.Include.None,
            Category.OrderBy orderBy = Category.OrderBy.None,
            bool isTracked = false)

        {
            return IsTracked(isTracked,
                    OrderBy(
                        ReadInclude(Context.Categories, include),
                        orderBy))
                .ToList();
        }

        #endregion

        #endregion Get

        #region Include / OrderBy

        private static IQueryable<Category> ReadInclude(IQueryable<Category> read, Category.Include include)
        {
            if (include.IsSet(Category.Include.PlayerCategories))
            {
                read = read.Include(c => c.PlayerCategories);
            }

            if (include.IsSet(Category.Include.Questions))
            {
                read.Include(c => c.Questions);
            }

            return read;
        }

        private static IQueryable<Category> OrderBy(IQueryable<Category> read, Category.OrderBy orderBy)
        {
            switch (orderBy)
            {
                case Category.OrderBy.None:
                    return read;

                case Category.OrderBy.Id:
                    return read.OrderBy(c => c.Id);

                case Category.OrderBy.Name:
                    return read.OrderBy(c => c.Name);

                case Category.OrderBy.CheeseColour:
                    return read.OrderBy(c => c.CheeseColour);

                default:
                    throw new ArgumentOutOfRangeException(nameof(orderBy), orderBy, null);
            }
        }

        #endregion Include / OrderBy

        public bool Any()
        {
            return Context.Categories.Any();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="category"></param>
        /// <exception cref="DbUpdateException"></exception>
        /// <exception cref="DbUpdateConcurrencyException"></exception>
        public void Create(Category category)
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
        }
    }
}