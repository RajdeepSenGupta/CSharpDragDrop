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
        public bool isUpdate = false;

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

        [HttpPost("api/home/update")]
        public IActionResult Update(UpdateAC updateAc)
        {
            isUpdate = true;
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

        //public void GetCountries()
        //{
        //    countriesList = new List<Country>();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        countriesList.Add(new Country
        //        {
        //            Id = i + 1,
        //            Name = "Country_" + (i + 1)
        //        });
        //    }
        //}

        //public void GetStates()
        //{
        //    Random rand = new Random();
        //    statesList = new List<State>();
        //    for (int i = 0; i < 20; i++)
        //    {
        //        statesList.Add(new State
        //        {
        //            Id = i + 1,
        //            Name = "State_" + (i + 1),
        //            CountryId = rand.Next(1, countriesList.Count)
        //        });
        //    }
        //}
    }
}
