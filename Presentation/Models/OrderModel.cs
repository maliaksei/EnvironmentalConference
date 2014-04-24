using System;

namespace Presentation.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime ShippedDate { get; set; }

        public int ShipVia { get; set; }
        public double Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public OrderModel()
        {
            OrderID = 1;
            CustomerID = "ALEX";
            EmployeeID = 2;
            OrderDate = DateTime.Now;
            RequiredDate = DateTime.Now;
            ShippedDate = DateTime.Now;
            ShipVia = 1;
            Freight = 1.0;
            ShipName = string.Empty;
            ShipAddress = string.Empty;
            ShipCity = string.Empty;
            ShipRegion = string.Empty;
            ShipPostalCode = string.Empty;
            ShipCountry = string.Empty;
        }
    }
}