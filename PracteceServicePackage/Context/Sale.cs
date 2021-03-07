using System;
using System.Collections.Generic;
using System.Text;

namespace PracteceServicePackage.Context
{
    public class Sale
    {
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public SaleStatus SaleStatus { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string CustomerId { get; set; }
        public int? SaleStatusId { get; set; }
        public int ProductId { get; set; }
        public DateTime BillingDate { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
