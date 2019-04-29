using CSharpDragDrop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpDragDrop.Controllers
{
    public class HomeController : Controller
    {
        public UpdateAC _list;
        
        public HomeController(UpdateAC list)
        {
            _list = list;
        }

        public IActionResult Index()
        {
            FormatData();

            return View(_list.CountryList);
        }

        public IActionResult DragDrop()
        {
            FormatData();

            return View(_list.CountryList);
        }

        private void FormatData()
        {
            foreach (Country country in _list.CountryList)
            {
                country.States = _list.StatesList.FindAll(x => x.CountryId == country.Id);
            }
        }

        [HttpPost("api/update")]
        public IActionResult Update(UpdateAC updateAc)
        {
            updateAc.Source.Name = updateAc.Source.Name.Trim();
            updateAc.Destination.Name = updateAc.Destination.Name.Trim();

            if (updateAc.Source.Name.ToLowerInvariant().Contains("country"))
            {
                return BadRequest("Country can not be moved");
            }
            else if (updateAc.Source.Name.ToLowerInvariant().Contains("state")
                && updateAc.Destination.Name.ToLowerInvariant().Contains("state"))
            {
                return BadRequest("State can not be moved into other state");
            }
            else
            {
                _list.StatesList.First(x => x.Id == updateAc.Source.Id).CountryId = updateAc.Destination.Id;
            }

            return Ok();
        }
    }
}
