using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
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

    public async Task<IActionResult> Index() {
      var list = await this.sellerService.FindAllAsync();
      return this.View(list);
    }

    public async Task<IActionResult> Create() {
      var departments = await this.departmentService.FindAllAsync();
      var viewModel = new SellerFormViewModel { Departments = departments };
      return this.View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Seller seller) {

      if (!this.ModelState.IsValid) {
        var departments = await this.departmentService.FindAllAsync();
        var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
        return this.View(viewModel);
      }

      await this.sellerService.InsertAsync(seller);
      return this.RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id) {
      if (id == null) return this.RedirectToAction(nameof(Error), new { message = "Id not provided" });

      var obj = await this.sellerService.FindByIdAsync(id.Value);
      return obj == null ? this.RedirectToAction(nameof(Error), new { message = "Id not found" }) : (IActionResult)this.View(obj);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id) {
      await this.sellerService.RemoveAsync(id);
      return this.RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int? id) {
      if (id == null) return this.RedirectToAction(nameof(Error), new { message = "Id not provided" });

      var obj = await this.sellerService.FindByIdAsync(id.Value);
      return obj == null ? this.RedirectToAction(nameof(Error), new { message = "Id not found" }) : (IActionResult)this.View(obj);
    }

    public async Task<IActionResult> Edit(int? id) {
      if (id == null) return this.RedirectToAction(nameof(Error), new { message = "Id not provided" });

      var obj = await this.sellerService.FindByIdAsync(id.Value);
      if (obj == null) return this.RedirectToAction(nameof(Error), new { message = "Id not found" });

      var departments = await this.departmentService.FindAllAsync();
      var viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
      return this.View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Seller seller) {
      if (!this.ModelState.IsValid) {
        var departments = await this.departmentService.FindAllAsync();
        var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
        return this.View(viewModel);
      }

      if (id != seller.Id) return this.RedirectToAction(nameof(Error), new { message = "Id missmatch" });

      try {
        await this.sellerService.UpdateAsync(seller);
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
