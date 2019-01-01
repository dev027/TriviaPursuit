using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tp.Data.DbContexts;
using Tp.Models.DbEntities;
using Tp.Utilities.Extensions.EnumExtensions;

namespace Tp.Data.DbEntities.Questions
{
    public class QuestionDb : BaseDb
    {
        #region Constructor

        private DataContext Context { get; }

        public QuestionDb(DataContext context)
        {
            Context = context;
        }

        #endregion Constructor

        #region Get

        #region Single

        public Question GetById(
            int questionId,
            Question.Include include = Question.Include.None,
            bool isTracked = false)
        {
            return IsTracked(isTracked,
                    ReadInclude(
                        Context.Questions, include))
                .FirstOrDefault(q => q.Id == questionId);
        }

        #endregion Single

        #region Multiple

        public IList<Question> GetAll(
            Question.Include include = Question.Include.None,
            Question.OrderBy orderBy = Question.OrderBy.None,
            bool isTracked = false)

        {
            return IsTracked(isTracked,
                    OrderBy(
                        ReadInclude(Context.Questions, include),
                        orderBy))
                .ToList();
        }

        #endregion

        #endregion Get

        #region Include / OrderBy

        private static IQueryable<Question> ReadInclude(IQueryable<Question> read, Question.Include include)
        {
            if (include.IsSet(Question.Include.Category))
            {
                read = read.Include(q => q.Category);
            }

            if (include.IsSet(Question.Include.Answers))
            {
                read.Include(q => q.Answers);
            }

            return read;
        }

        private static IQueryable<Question> OrderBy(IQueryable<Question> read, Question.OrderBy orderBy)
        {
            switch (orderBy)
            {
                case Question.OrderBy.None:
                    return read;

                case Question.OrderBy.Id:
                    return read.OrderBy(q => q.Id);

                case Question.OrderBy.IdDescending:
                    return read.OrderByDescending(q => q.Id);

                case Question.OrderBy.CategoryName:
                    return read.OrderBy(q => q.Category.Name);

                default:
                    throw new ArgumentOutOfRangeException(nameof(orderBy), orderBy, null);
            }
        }

        #endregion Include / OrderBy

        public void Add(Question question)
        {
            Context.Questions.Add(question);
            Context.SaveChanges();
        }

        public int GetCountByCategoryId(int categoryId)
        {
            return Context.Questions.Count(q => q.CategoryId == categoryId);
        }

        public IList<Question> GetByCategoryId(
            int categoryId,
            Question.Include include = Question.Include.None,
            Question.OrderBy orderBy = Question.OrderBy.None,
            bool isTracked = false)
        {
            return IsTracked(
                    isTracked,
                    OrderBy(
                        ReadInclude(Context.Questions, include),
                        orderBy))
                .Where(q => q.CategoryId == categoryId)
                .ToList();
        }
    }
}