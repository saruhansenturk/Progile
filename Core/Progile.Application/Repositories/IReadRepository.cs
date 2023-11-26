﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progile.Application.Paging;
using Progile.Domain.Entities.Common;

namespace Progile.Application.Repositories
{
    public interface IReadRepository<T>: IRepository<T> where T : BaseEntity
    {
        Pagination<T> GetAll(int skip, int take, bool tracking = true);
        Task<T?> GetByIdAsync(string id, bool tracking = true);
    }
}