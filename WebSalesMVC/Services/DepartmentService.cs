using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalesMVC.Data;
using WebSalesMVC.Models;

namespace WebSalesMVC.Services {
  public class DepartmentService {

    private readonly WebSalesMVCContext context;

    public DepartmentService(WebSalesMVCContext context) => this.context = context;

    public List<Department> FindAll() => this.context.Department.OrderBy(x => x.Name).ToList();
  }
}
