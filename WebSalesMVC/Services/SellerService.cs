using System.Collections.Generic;
using System.Linq;
using WebSalesMVC.Data;
using WebSalesMVC.Models;
using Microsoft.EntityFrameworkCore;
using WebSalesMVC.Services.Exceptions;

namespace WebSalesMVC.Services {
  public class SellerService {
    private readonly WebSalesMVCContext context;

    public SellerService(WebSalesMVCContext context) => this.context = context;

    public List<Seller> FindAll() => this.context.Seller.ToList();

    public void Insert(Seller obj) {
      this.context.Add(obj);
      this.context.SaveChanges();
    }

    public Seller FindById(int id) => this.context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);

    public void Remove(int id) {
      var obj = this.context.Seller.Find(id);
      this.context.Seller.Remove(obj);
      this.context.SaveChanges();
    }

    public void Update(Seller obj) {

      if (!this.context.Seller.Any(x => x.Id == obj.Id)) throw new NotFoundException("Id not found");
      try {
        this.context.Update(obj);
        this.context.SaveChanges();
      }
      catch (DbUpdateConcurrencyException e) {
        throw new DbConcurrencyException(e.Message);
      }
     
    }
  }
}
