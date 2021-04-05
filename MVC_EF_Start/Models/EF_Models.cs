using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Start.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string OrderMessage { get; set; }
        public double OrderTotal { get; set; }

        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }

    public class Orderdetail
    {
        public int OrderdetailID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
    public class Product
    {

        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Seller { get; set; }
        public int StoreID { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }

    public class Store
    {
        public int StoreID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}