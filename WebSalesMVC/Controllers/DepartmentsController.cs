using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalesMVC.Models;

namespace WebSalesMVC.Controllers {
  public class DepartmentsController : Controller {
    public IActionResult Index() {
      var list = new List<Department> {
        new Department { Id = 1, Name = "Eletronics" },
        new Department { Id = 2, Name = "Fashion" }
      };
      return this.View(list);
    }
  }
}
