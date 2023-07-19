using AppDomain.Entities;
using AppDomain.Repositories;
using Dapper;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using System.Data;

namespace Infrastructure.Persistance
{
    public class ProductRepository : IRepository <Product>
    {
        private IDbConnection _db;
        public ProductRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<List<Product>> GetListAsync()
        {
            return (await _db.QueryAsync<Product>("SELECT * FROM Products"))
                .AsList();
        }

        public async Task<Product> GetAsync(Guid id)
        {
            return await _db.QueryFirstAsync<Product>($"SELECT * FROM Products WHERE = '{id}'");
        }

        public async Task<Product> InsertAsync(Product product)
        {
            var query = $"INSERT INTO Products (Name,Quantity,Price,Stock) VALUES ('{product.Name}', '{product.Quantity}',{product.Price}, {product.Stock})";
            await _db.ExecuteAsync(query);
            return product;
        }

        public async Task<Product> UpdateAsync(Guid id, Product product)
        {
            await _db.ExecuteAsync($"UPDATE Products SET {nameof(Product.Name)} = '{product.Name}', {nameof(Product.Quantity)} = '{product.Quantity}', {nameof(Product.Price)} = {product.Price}, {nameof(Product.Stock)} = {product.Stock} WHERE Id = '{id}'");
            return product;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _db.ExecuteAsync($"DELETE FROM Products WHERE Id = '{id}'");
        }
    }
}
