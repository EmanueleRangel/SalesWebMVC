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
  }
}
