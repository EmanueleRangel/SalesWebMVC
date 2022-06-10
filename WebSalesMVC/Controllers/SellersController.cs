using Microsoft.AspNetCore.Mvc;
using WebSalesMVC.Models;
using WebSalesMVC.Models.ViewModels;
using WebSalesMVC.Services;

namespace WebSalesMVC.Controllers {
  public class SellersController : Controller {

    private readonly SellerService sellerService;
    private readonly DepartmentService departmentService;

    public SellersController(SellerService sellerService, DepartmentService departmentService) {
      this.sellerService = sellerService;
      this.departmentService = departmentService;
    }

    public IActionResult Index() {
      var list = this.sellerService.FindAll();
      return this.View(list);
    }

    public IActionResult Create() {
      var departments = this.departmentService.FindAll();
      var viewModel = new SellerFormViewModel { Departments = departments };
      return this.View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller) {
      this.sellerService.Insert(seller);
      return this.RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int? id) {
      if (id == null) return this.NotFound();

      var obj = this.sellerService.FindById(id.Value);
      return obj == null ? this.NotFound() : (IActionResult)this.View(obj);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id) {
      this.sellerService.Remove(id);
      return this.RedirectToAction(nameof(Index));
    }
  }
}
