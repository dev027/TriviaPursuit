﻿using System;
using Tp.Data.DbContexts;
using Tp.Data.DbEntities.Categories;
using Tp.Data.DbEntities.Questions;

namespace Tp.Data
{
    public class Data : IDisposable
    {
        private DataContext Context { get; set; }

        private void ReleaseUnmanagedResources()
        {
            Context?.Dispose();
            Context = null;
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~Data()
        {
            ReleaseUnmanagedResources();
        }

        public Data()
        {
            Context = new DataContext();
        }

        private QuestionDb _question;
        private CategoryDb _category;

        public QuestionDb Question => _question ?? (_question = new QuestionDb(Context));
        public CategoryDb Category => _category ?? (_category = new CategoryDb(Context));
    }
}