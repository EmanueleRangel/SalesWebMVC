using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalesMVC.Models;
using WebSalesMVC.Models.Enums;

namespace WebSalesMVC.Data {
  public class SeedingService {
    private readonly WebSalesMVCContext context;

    public SeedingService(WebSalesMVCContext context) => this.context = context;

    public void Seed() {
      if (this.context.Department.Any() ||
        this.context.Seller.Any() ||
        this.context.SaleRecord.Any()) 
      {
          return;  
      }
      var d1 = new Department(1, "Computers");
      var d2 = new Department(2, "Electronics");
      var d3 = new Department(3, "Fashion");
      var d4 = new Department(4, "Books");

      var s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
      var s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
      var s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
      var s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
      var s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
      var s6 = new Seller(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

      var r1 = new SaleRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s1);
      var r2 = new SaleRecord(2, new DateTime(2018, 09, 4), 7000.0, SaleStatus.Billed, s5);
      var r3 = new SaleRecord(3, new DateTime(2018, 09, 13), 4000.0, SaleStatus.Canceled, s4);
      var r4 = new SaleRecord(4, new DateTime(2018, 09, 1), 8000.0, SaleStatus.Billed, s1);
      var r5 = new SaleRecord(5, new DateTime(2018, 09, 21), 3000.0, SaleStatus.Billed, s3);
      var r6 = new SaleRecord(6, new DateTime(2018, 09, 15), 2000.0, SaleStatus.Billed, s1);
      var r7 = new SaleRecord(7, new DateTime(2018, 09, 28), 13000.0, SaleStatus.Billed, s2);
      var r8 = new SaleRecord(8, new DateTime(2018, 09, 11), 4000.0, SaleStatus.Billed, s4);
      var r9 = new SaleRecord(9, new DateTime(2018, 09, 14), 11000.0, SaleStatus.Pending, s6);
      var r10 = new SaleRecord(10, new DateTime(2018, 09, 7), 9000.0, SaleStatus.Billed, s6);
      var r11 = new SaleRecord(11, new DateTime(2018, 09, 13), 6000.0, SaleStatus.Billed, s2);
      var r12 = new SaleRecord(12, new DateTime(2018, 09, 25), 7000.0, SaleStatus.Pending, s3);
      var r13 = new SaleRecord(13, new DateTime(2018, 09, 29), 10000.0, SaleStatus.Billed, s4);
      var r14 = new SaleRecord(14, new DateTime(2018, 09, 4), 3000.0, SaleStatus.Billed, s5);
      var r15 = new SaleRecord(15, new DateTime(2018, 09, 12), 4000.0, SaleStatus.Billed, s1);
      var r16 = new SaleRecord(16, new DateTime(2018, 10, 5), 2000.0, SaleStatus.Billed, s4);
      var r17 = new SaleRecord(17, new DateTime(2018, 10, 1), 12000.0, SaleStatus.Billed, s1);
      var r18 = new SaleRecord(18, new DateTime(2018, 10, 24), 6000.0, SaleStatus.Billed, s3);
      var r19 = new SaleRecord(19, new DateTime(2018, 10, 22), 8000.0, SaleStatus.Billed, s5);
      var r20 = new SaleRecord(20, new DateTime(2018, 10, 15), 8000.0, SaleStatus.Billed, s6);
      var r21 = new SaleRecord(21, new DateTime(2018, 10, 17), 9000.0, SaleStatus.Billed, s2);
      var r22 = new SaleRecord(22, new DateTime(2018, 10, 24), 4000.0, SaleStatus.Billed, s4);
      var r23 = new SaleRecord(23, new DateTime(2018, 10, 19), 11000.0, SaleStatus.Canceled, s2);
      var r24 = new SaleRecord(24, new DateTime(2018, 10, 12), 8000.0, SaleStatus.Billed, s5);
      var r25 = new SaleRecord(25, new DateTime(2018, 10, 31), 7000.0, SaleStatus.Billed, s3);
      var r26 = new SaleRecord(26, new DateTime(2018, 10, 6), 5000.0, SaleStatus.Billed, s4);
      var r27 = new SaleRecord(27, new DateTime(2018, 10, 13), 9000.0, SaleStatus.Pending, s1);
      var r28 = new SaleRecord(28, new DateTime(2018, 10, 7), 4000.0, SaleStatus.Billed, s3);
      var r29 = new SaleRecord(29, new DateTime(2018, 10, 23), 12000.0, SaleStatus.Billed, s5);
      var r30 = new SaleRecord(30, new DateTime(2018, 10, 12), 5000.0, SaleStatus.Billed, s2);

      this.context.Department.AddRange(d1, d2, d3, d4);

      this.context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

      this.context.SaleRecord.AddRange(
               r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
               r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
               r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
           );

      this.context.SaveChanges();
    }
  }
}
