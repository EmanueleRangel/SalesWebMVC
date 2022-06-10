using System;
using System.Collections.Generic;
using System.Linq;

namespace WebSalesMVC.Models {
  public class Seller {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public double BaseSalary { get; set; }
    public Department Department { get; set; }
    public int DepartmentId { get; set; }
    public ICollection<SaleRecord> Sales { get; set; } = new List<SaleRecord>();

    public Seller() { }

    public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department) {
      this.Id = id;
      this.Name = name;
      this.Email = email;
      this.BirthDate = birthDate;
      this.BaseSalary = baseSalary;
      this.Department = department;
    }

    public void AddSales(SaleRecord saleRecord) => this.Sales.Add(saleRecord);

    public void RemoveSales(SaleRecord saleRecord) => this.Sales.Remove(saleRecord);

    public double TotalSales(DateTime initial, DateTime final) => this.Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
  }
}
