using AnimalShelterWebApp.Models.InputModels.Storage;
using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
﻿using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using AnimalShelterWebApp.Models.OutputModels.Storage;

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

            string table = "";

            List<Item> listOfItems = _itemRepository.GetItemsInfos();

            if (listOfItems.Count() < 1) return View();
            else
            {
                foreach (var x in listOfItems)
                {
                    table +=
                    "<tr>" +
                        "<td>" +
                            x.Name +
                        "</td>" +
                        "<td>" +
                            x.Storage +
                        "</td>" +
                        "<td>" +
                            "<button type=\"submit\" class=\"btn bg-mainGreen text-center text-white m-0\" name=\"delete\" value=\"" + x.Id + "\">Delete</button>" +
                        "</td>" +
                    "</tr>";
                }
            }

            ViewData["table"] = table;

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetItems()
        {
            List<Item> items = await _itemRepository.GetItemsAsync();
            List<ItemOutputModel> outputModel = new List<ItemOutputModel>();

            foreach (Item item in items)
            {
                outputModel.Add(new ItemOutputModel()
                {
                    Name = item.Name,
                    Storage = item.Storage
                });
            }

            return Redirect("/Storage");
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

        [HttpPost]
        [AllowAnonymous]
        [Route("/Storage/AddItem")]
        public async Task<ActionResult> ItemDelete(string delete)
        {
           Item item = new Item{ Id = Int32.Parse(delete) };

            await _itemRepository.DeleteItemAsync(item);

            return Redirect("/Storage");
        }
    }
}