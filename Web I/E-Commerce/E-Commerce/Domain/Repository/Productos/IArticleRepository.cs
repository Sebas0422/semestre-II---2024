﻿using E_Commerce.Domain.Productos;
using E_Commerce.Domain.Repository.Shared;

namespace E_Commerce.Domain.Repository.Productos
{
    public interface IArticleRepository : IRepository<Article, Guid>
    {
    }
}