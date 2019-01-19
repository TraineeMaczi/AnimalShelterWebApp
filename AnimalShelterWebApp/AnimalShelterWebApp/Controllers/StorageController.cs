
﻿using AnimalShelterWebApp.Models.InputModels.Storage;
using Model.Entities;
using Repository.Abstract;

using System.Threading.Tasks;

using System.Web;
using System.Web.Mvc;

namespace AnimalShelterWebApp.Controllers
{
    public class StorageController : Controller
    {

        private readonly IItemRepository _itemRepository;

        public StorageController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public ActionResult Index()
        {
            return View();
        }


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



    }
}