using Eshop_Core.App.Context;
using Eshop_Core.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop_Core.App.Repositories
{
    public interface IGroupRepository
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<ShowGroupsViewModel> GetGroupForShow();
    }

    public class GroupRepository : IGroupRepository
    {
        private EshopContext _context;

        public GroupRepository(EshopContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }

        public IEnumerable<ShowGroupsViewModel> GetGroupForShow()
        {
            return _context.Categories
                .Select(c => new ShowGroupsViewModel()
                {
                    GroupId = c.Id,
                    Name = c.Name,
                    ProductCount = _context.CategoryToProducts.Count(g => g.CategoryId == c.Id)
                }).ToList();
        }
    }
}
