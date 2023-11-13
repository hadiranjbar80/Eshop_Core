using Eshop_Core.App.Context;
using Eshop_Core.App.Models;
using Eshop_Core.App.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop_Core.App.Components
{
    public class ProductGroupsComponentes : ViewComponent
    {
        IGroupRepository _groupRepository;

        public ProductGroupsComponentes(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Componentes/ProductGroupsComponentes.cshtml",_groupRepository.GetGroupForShow());
        }
    }
}
