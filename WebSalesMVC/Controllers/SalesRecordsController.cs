using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalesMVC.Services;

namespace WebSalesMVC.Controllers {
  public class SalesRecordsController : Controller {

    private readonly SalesRecordService salesRecordService;

    public SalesRecordsController(SalesRecordService salesRecordService) => this.salesRecordService = salesRecordService;

    public IActionResult Index() {
      return View();
    }
    public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate) {
      if (!minDate.HasValue) minDate = new DateTime(DateTime.Now.Year, 1, 1);
      if (!maxDate.HasValue) maxDate = DateTime.Now;
      this.ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
      this.ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
      var result = await this.salesRecordService.FindByDateAsync(minDate, maxDate);
      return this.View(result);
    }
    public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate) {
      if (!minDate.HasValue) minDate = new DateTime(DateTime.Now.Year, 1, 1);
      if (!maxDate.HasValue) maxDate = DateTime.Now;
      this.ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
      this.ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
      var result = await this.salesRecordService.FindByDateGroupingAsync(minDate, maxDate);
      return this.View(result);
    }
  }
}
