using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalesMVC.Data;
using WebSalesMVC.Models;

namespace WebSalesMVC.Services {
  public class SellerService {
    private readonly WebSalesMVCContext context;

    public SellerService(WebSalesMVCContext context) => this.context = context;

    public List<Seller> FindAll() => this.context.Seller.ToList();
  }
}
