using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategotyMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CategotyMVC.Controllers
{
    
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            var displayData = _db.CategoryTable.ToList();
            return View(displayData);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryModel nec)
        {
            if (ModelState.IsValid)
            {
                _db.Add(nec);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nec);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getCategorydetails = await _db.CategoryTable.FindAsync(id);
            return View(getCategorydetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryModel nc)
        {
            if (ModelState.IsValid)
            {
                _db.Update(nc);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nc);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getCategorydetails = await _db.CategoryTable.FindAsync(id);
            return View(getCategorydetails);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var getempdetails = await _db.CategoryTable.FindAsync(id);
            _db.CategoryTable.Remove(getempdetails);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
