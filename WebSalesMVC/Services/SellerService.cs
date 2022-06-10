using System.Collections.Generic;
using System.Linq;
using WebSalesMVC.Data;
using WebSalesMVC.Models;
using Microsoft.EntityFrameworkCore;
using WebSalesMVC.Services.Exceptions;
using System.Threading.Tasks;

namespace WebSalesMVC.Services {
  public class SellerService {
    private readonly WebSalesMVCContext context;

    public SellerService(WebSalesMVCContext context) => this.context = context;

    public async Task<List<Seller>> FindAllAsync () => await this.context.Seller.ToListAsync();

    public async Task InsertAsync(Seller obj) {
      this.context.Add(obj);
      await this.context.SaveChangesAsync();
    }

    public async Task<Seller> FindByIdAsync(int id) => await this.context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);

    public async Task RemoveAsync(int id) {
      try {
        var obj = await this.context.Seller.FindAsync(id);
        this.context.Seller.Remove(obj);
        await this.context.SaveChangesAsync();
      } catch (DbUpdateException e) {
        throw new IntegrityException(e.Message);
      }

    }

    public async Task UpdateAsync(Seller obj) {

      var hasAny = await this.context.Seller.AnyAsync(x => x.Id == obj.Id);
      if (!hasAny) throw new NotFoundException("Id not found");
      try {
        this.context.Update(obj);
        await this.context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException e) {
        throw new DbConcurrencyException(e.Message);
      }
     
    }
  }
}
