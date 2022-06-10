using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalesMVC.Data;
using WebSalesMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace WebSalesMVC.Services {
  public class DepartmentService {

    private readonly WebSalesMVCContext context;

    public DepartmentService(WebSalesMVCContext context) => this.context = context;

    public async Task<List<Department>> FindAllAsync() => await this.context.Department.OrderBy(x => x.Name).ToListAsync();
  }
}
