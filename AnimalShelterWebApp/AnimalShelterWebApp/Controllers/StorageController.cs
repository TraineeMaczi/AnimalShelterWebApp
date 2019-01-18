<<<<<<< HEAD
﻿using AnimalShelterWebApp.Models.InputModels.Storage;
using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
>>>>>>> f432d7f93dd54f3cd3a15f28835ad2e2c02ee184
using System.Web;
using System.Web.Mvc;

namespace AnimalShelterWebApp.Controllers
{
    public class StorageController : Controller
    {
<<<<<<< HEAD
        private readonly IItemRepository _itemRepository;

        public StorageController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

=======
        
>>>>>>> f432d7f93dd54f3cd3a15f28835ad2e2c02ee184
        public ActionResult Index()
        {
            return View();
        }
<<<<<<< HEAD

        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("/Storage/AddItem")]
        public async Task<ActionResult> AddItem(ItemInputModel model)
        {
            if (model != null)
            {
                var item = new Item();
                item.Name = model.Name;
                item.Storage = model.Storage;

                await _itemRepository.SaveItemAsync(item);
            }
            return Redirect("/Storage");
        }


=======
        public String AddItems()
        {
            return "to do";
        }
        public String DeleteItem()
        {
            return "to do";
        }
       
>>>>>>> f432d7f93dd54f3cd3a15f28835ad2e2c02ee184
    }
}