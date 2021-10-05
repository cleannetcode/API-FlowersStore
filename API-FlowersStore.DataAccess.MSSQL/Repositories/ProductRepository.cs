﻿using API_FlowersStore.Core.CoreModels;
using API_FlowersStore.Core.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FlowersStore.DataAccess.MSSQL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly APIFlowersStoreDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(APIFlowersStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Add(Product newProduct)
        {
            if (newProduct is null)
            {
                throw new ArgumentNullException(nameof(newProduct));
            }

            var newProductEntity = _mapper.Map<Core.CoreModels.Product, Entities.Product>(newProduct);

            await _context.Products.AddAsync(newProductEntity);
            await _context.SaveChangesAsync();

            return newProductEntity.Name;
        }

        public async Task<bool> Delete(string productName, int userId)
        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentException(nameof(productName));
            }

            var propdict = await _context.Products
                .FirstOrDefaultAsync(f => f.Name == productName && f.UserId == userId);

            var result = _context.Products.Remove(propdict);

            if(result.State != EntityState.Deleted)
            {
                return false;
            }

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Product[]> Get(int userId)
        {
            var product = await _context.Products
                       .Where(x => x.UserId == userId)
                       .AsNoTracking()
                       .ToArrayAsync();

            return _mapper.Map<Entities.Product[], Core.CoreModels.Product[]>(product);
        }

        public async Task<Product> GetByName(string productName, int userId)
        {
            var product = await _context.Products
                      .Where(x => x.Name == productName && x.UserId == userId)
                      .AsNoTracking()
                      .FirstOrDefaultAsync();

            //if (product == null)
            //{
            //    throw new ArgumentNullException("Product not found.");
            //}

            return _mapper.Map<Entities.Product, Core.CoreModels.Product>(product);
        }

        public async Task<Product[]> GetByOrders(int[] ordersId)
        {
            var orders = _context.Orders.Where(f => ordersId.Contains(f.Id)).ToArray();

            var products = new List<Entities.Product>();

            foreach (var o in orders)
            {
                products.Add(_context.Products.FirstOrDefault(f => f.Id == o.ProductId));
            }

           // var products = _context.Products.Where(f => orders.Any(ff => ff.ProductId == f.Id)).ToList();

            return _mapper.Map<Entities.Product[], Core.CoreModels.Product[]>(products.ToArray());
        }

        public async Task<string> Update(Product product, int userId)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var productEnModel = _mapper.Map<Core.CoreModels.Product, Entities.Product>(product);

            await _context.SaveChangesAsync();

            var existedProduct = await _context.Products
              .FirstOrDefaultAsync(f => f.Name == productEnModel.Name && f.UserId == userId);

            if (existedProduct == null)
            {
                throw new ArgumentNullException(nameof(existedProduct));
            }

            _context.Entry(existedProduct).State = EntityState.Modified;

            existedProduct.Name = productEnModel.Name;
            existedProduct.Description = productEnModel.Description;
            existedProduct.Color = productEnModel.Color;
            existedProduct.Price = productEnModel.Price;
            existedProduct.Amount = productEnModel.Amount;

            await _context.SaveChangesAsync();

            return product.Name;
        }
    }
}
