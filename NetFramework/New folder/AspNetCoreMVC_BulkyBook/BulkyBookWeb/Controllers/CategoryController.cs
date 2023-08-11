using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db; //make to work with database

    public CategoryController(ApplicationDbContext db) //ctor
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList = _db.Categories; //.ToList(); //retrieve categories
        return View(objCategoryList);
    }

    //Get
    public IActionResult Create()
    {
        return View();
    }

    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        //server side validation
        if (obj.Name == obj.DisplayOrder.ToString())
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name");

        //server side validation
        if (ModelState.IsValid)
        {
            _ = _db.Categories.Add(obj);
            _ = _db.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }

        return View(obj);
    }

    //Get
    public IActionResult Edit(int? id)
    {
        if (id is null or 0) return NotFound();

        var categoryFromDb = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

        return categoryFromDb == null ? NotFound() : View(categoryFromDb);
    }

    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        //server side validation
        if (obj.Name == obj.DisplayOrder.ToString())
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name");

        //server side validation
        if (ModelState.IsValid)
        {
            _ = _db.Categories.Update(obj);
            _ = _db.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }

        return View(obj);
    }

    //Delete
    //Get
    public IActionResult Delete(int? id)
    {
        if (id is null or 0) return NotFound();

        var categoryFromDb = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

        return categoryFromDb == null ? NotFound() : View(categoryFromDb);
    }

    //Post
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)

    {
        var obj = _db.Categories.Find(id);
        //server side validation
        if (obj == null) return NotFound();
        //server side validation

        _ = _db.Categories.Remove(obj);
        _ = _db.SaveChanges();
        TempData["success"] = "Category removed successfully";
        return RedirectToAction("Index");
    }
}