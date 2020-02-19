﻿using System;
using System.Collections.Generic;
using System.Text;
using Cytel.Top.Model;

namespace Cytel.Top.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);
        void Remove(int id);
        void Update(T item);
        T FindByID(int id);
        IEnumerable<T> FindAll();
    }
}
