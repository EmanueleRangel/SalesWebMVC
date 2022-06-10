using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WebSalesMVC.Models;
using WebSalesMVC.Models.ViewModels;
using WebSalesMVC.Services;
using WebSalesMVC.Services.Exceptions;

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
      if (id == null) return this.RedirectToAction(nameof(Error), new { message = "Id not provided" });

      var obj = this.sellerService.FindById(id.Value);
      return obj == null ? this.RedirectToAction(nameof(Error), new { message = "Id not found" }) : (IActionResult)this.View(obj);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id) {
      this.sellerService.Remove(id);
      return this.RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int? id) {
      if (id == null) return this.RedirectToAction(nameof(Error), new { message = "Id not provided" });

      var obj = this.sellerService.FindById(id.Value);
      return obj == null ? this.RedirectToAction(nameof(Error), new { message = "Id not found" }) : (IActionResult)this.View(obj);
    }

    public IActionResult Edit(int? id) {
      if (id == null) return this.RedirectToAction(nameof(Error), new { message = "Id not provided" });

      var obj = this.sellerService.FindById(id.Value);
      if (obj == null) return this.RedirectToAction(nameof(Error), new { message = "Id not found" });

      var departments = this.departmentService.FindAll();
      var viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
      return this.View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Seller seller) {
      if (id != seller.Id) return this.RedirectToAction(nameof(Error), new { message = "Id missmatch" });

      try {
        this.sellerService.Update(seller);
        return this.RedirectToAction(nameof(Index));
      }
      catch (ApplicationException e) {
        return this.RedirectToAction(nameof(Error), new { message = e.Message });
      }
    }

    public IActionResult Error(string message) {
      var viewModel = new ErrorViewModel {
        Message = message,
        RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
      };
      return this.View(viewModel);
    }
  }
}
