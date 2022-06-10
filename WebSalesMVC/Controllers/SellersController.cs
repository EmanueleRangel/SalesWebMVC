using Microsoft.AspNetCore.Mvc;
using WebSalesMVC.Models;
using WebSalesMVC.Services;

namespace WebSalesMVC.Controllers {
  public class SellersController : Controller {

    private readonly SellerService sellerService;

    public SellersController(SellerService sellerService) => this.sellerService = sellerService;
    
    public IActionResult Index() {
      var list = this.sellerService.FindAll();
      return this.View(list);
    }

    public IActionResult Create() => this.View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller) {
      this.sellerService.Insert(seller);
      return this.RedirectToAction(nameof(Index));
    }
  }
}
