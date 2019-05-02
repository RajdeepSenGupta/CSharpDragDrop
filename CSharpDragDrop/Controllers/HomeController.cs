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
            updateAc.Destination.Name = updateAc.Destination.Name?.Trim();

            if (updateAc.Source.Name.ToLowerInvariant().Contains("country") && updateAc.Destination.Id != -1)
            {
                return BadRequest("Country can not be moved");
            }
            else if (updateAc.Source.Name.ToLowerInvariant().Contains("state")
                && (updateAc.Destination.Name == null || updateAc.Destination.Name.ToLowerInvariant().Contains("state")))
            {
                return BadRequest("State can not be moved into other state");
            }
            else if (updateAc.Destination.Id == -1 && updateAc.Source.Name.ToLowerInvariant().Contains("country"))
            {
                _list.CountryList.Add(new Country()
                {
                    Id = _list.CountryList.Count + 1,
                    Name = "Country_" + (_list.CountryList.Count + 1)
                });
            }
            else if (updateAc.Destination.Id == -1 && updateAc.Source.Name.ToLowerInvariant().Contains("state"))
            {
                return BadRequest("State should be inside a country");
            }
            else
            {
                _list.StatesList.First(x => x.Id == updateAc.Source.Id).CountryId = updateAc.Destination.Id;
            }

            return Ok();
        }

        [HttpPost("api/delete")]
        public IActionResult DeleteElement(ObjectDef obj)
        {
            return Ok();
        }

        [HttpPost("api/select")]
        public IActionResult ItemClicked(ObjectDef obj)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetData()
        {
            List<TreeData> treeDataList = new List<TreeData>();

            treeDataList = _list.CountryList.Select(x => new TreeData()
            {
                id = x.Id,
                name = x.Name,
                parentId = null,
                hasChildren = x.States.Count > 0,
                children = x.States.Select(y => new TreeData()
                {
                    id = y.Id,
                    name = y.Name,
                    parentId = y.CountryId,
                }).ToList()
            }).ToList();

            return Ok(treeDataList);
        }
    }

    public class TreeData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public int? parentId { get; set; }
        public string imageCssClass { get; set; }
        public bool hasChildren { get; set; }
        public virtual List<TreeData> children { get; set; }
    }
}
