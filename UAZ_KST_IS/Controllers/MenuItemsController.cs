using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UAZ_KST_IS.Business.Services.Interfaces;
using UAZ_KST_IS.Data.Persistance;
using UAZ_KST_IS.Models.Domain.Entities;
using UAZ_KST_IS.Models.ViewModels.Menu;
using UAZ_KST_IS.Models.ViewModels.MenuItem;

namespace UAZ_KST_IS.Controllers
{
    public class MenuItemsController : Controller
    {
        private readonly IMenuCategoryService _menuCategoryService;
        private readonly IMenuItemService _menuItemService;

        public MenuItemsController(IMenuCategoryService menuCategoryService, IMenuItemService menuItemService)
        {
            _menuCategoryService = menuCategoryService;
            _menuItemService = menuItemService;
        }

        // GET: MenuItems
        public async Task<IActionResult> Index()
        {
            var items = await _menuItemService.GetAllAsync();
            return View(items);
        }

        [HttpGet("/MenuItems/MenuCategory/{menuCategoryId:guid}")]
        public async Task<IActionResult> MenuCategory(Guid menuCategoryId)
        {
            var items = await _menuItemService.GetByMenuCategoryIdAsync(menuCategoryId);
            return View(items);
        }

        // GET: MenuItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _menuItemService.GetByIdAsync(id.Value);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // GET: MenuItems/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _menuCategoryService.GetAllAsync();
            ViewData["MenuCategoryId"] = new SelectList(categories, "Id", "Title");
            return View();
        }

        // POST: MenuItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuItemCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _menuItemService.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            var categories = await _menuCategoryService.GetAllAsync();
            ViewData["MenuCategoryId"] = new SelectList(categories, "Id", "Title", model.MenuCategoryId);
            return View(model);
        }

        // GET: MenuItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _menuItemService.GetByIdAsync(id.Value);
            if (menuItem == null)
            {
                return NotFound();
            }
            var categories = await _menuCategoryService.GetAllAsync();
            ViewData["MenuCategoryId"] = new SelectList(categories, "Id", "Title", menuItem.MenuCategoryId);
            return View(menuItem);
        }

        // POST: MenuItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MenuItemEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _menuItemService.UpdateAsync(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await MenuItemExistsAsync(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var categories = await _menuCategoryService.GetAllAsync();
            ViewData["MenuCategoryId"] = new SelectList(categories, "Id", "Title", model.MenuCategoryId);
            return View(model);
        }

        // GET: MenuItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _menuItemService.GetByIdAsync(id.Value);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // POST: MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var menuItem = await _menuItemService.GetByIdAsync(id);
            if (menuItem != null)
            {
                await _menuItemService.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> MenuItemExistsAsync(Guid id)
        {
            var item = await _menuItemService.GetByIdAsync(id);
            return item != null;
        }
    }
}
