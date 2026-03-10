using Dapper;
using Microsoft.Extensions.Logging;
using MVCWEB.Data;
using MVCWEB.Models;
using MVCWEB.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MVCWEB.Services
{
    public class ItemService : IItemService
    {
        private readonly ILogger _logger;
        private readonly DapperContext _dapperContext;
        
        public ItemService(
            ILogger<ItemService> logger,
            DapperContext dapper            
            )
        {
            _dapperContext = dapper;
            _logger = logger;  
        }
        public async Task<IEnumerable<ItemViewModel>> GetItems()
        {
            try
            {
                using var connection = _dapperContext.CreateConnection();
                string query = "SELECT Id, ItemName, Type FROM Items";
                var items = await connection.QueryAsync<Item>(query);

                var itemViewModel = items.Select(i => new ItemViewModel()
                {
                    Id = i.Id,
                    ItemName = i.ItemName,
                    Type = i.Type
                }
                );

                return itemViewModel;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return Enumerable.Empty<ItemViewModel>();
            }
          
        }
    }
}
