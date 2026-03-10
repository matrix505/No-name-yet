using MVCWEB.Models;
using System.Collections;
using System.Collections.Generic;

namespace MVCWEB.Services.Abstract
{
    public interface IItemService
    {
         Task<IEnumerable<ItemViewModel>> GetItems();
    }
}
