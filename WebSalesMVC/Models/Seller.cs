using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebSalesMVC.Models {
  public class Seller {
    public int Id { get; set; }
    public string Name { get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BirthDate { get; set; }
    
    [Display(Name = "Base Salary")]
    [DisplayFormat(DataFormatString = "{0:F2}")]
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
