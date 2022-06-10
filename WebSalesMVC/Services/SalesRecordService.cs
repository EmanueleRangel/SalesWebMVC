using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalesMVC.Data;
using WebSalesMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace WebSalesMVC.Services {
  public class SalesRecordService {

    private readonly WebSalesMVCContext context;
    public SalesRecordService(WebSalesMVCContext context) => this.context = context;

    public async Task<List<SaleRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate) {
      var result = from obj in this.context.SaleRecord select obj;
      if (minDate.HasValue) {
        result = result.Where(x => x.Date >= minDate.Value);
      }
      if (maxDate.HasValue) {
        result = result.Where(x => x.Date <= maxDate.Value);
      }
      return await result
        .Include(x => x.Seller)
        .Include(x => x.Seller.Department)
        .OrderByDescending(x => x.Date)
        .ToListAsync();
    }
  }
}
