using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalesMVC.Services;

namespace WebSalesMVC.Controllers {
  public class SellersController : Controller {

    private readonly SellerService sellerService;

    public SellersController(SellerService sellerService) => this.sellerService = sellerService;
    public IActionResult Index() {
      var list = this.sellerService.FindAll();
      return this.View(list);
    }
  }
}
