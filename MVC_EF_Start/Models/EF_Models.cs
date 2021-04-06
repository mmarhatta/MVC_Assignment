using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Start.Models
{
    public class Company
    {
        [Key]
        public string symbol { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public bool isEnabled { get; set; }
        public string type { get; set; }
        public string iexId { get; set; }
        public List<Quote> Quotes { get; set; }
    }

    public class Quote
    {
        public int QuoteId { get; set; }
        public string date { get; set; }
        public float open { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public float close { get; set; }
        public int volume { get; set; }
        public int unadjustedVolume { get; set; }
        public float change { get; set; }
        public float changePercent { get; set; }
        public float vwap { get; set; }
        public string label { get; set; }
        public float changeOverTime { get; set; }
        public string symbol { get; set; }
    }

    public class ChartRoot
    {
        public Quote[] chart { get; set; }
    }

    public class Order
    {
        public int ID { get; set; }
        public float Qty { get; set; }
        public List<Placed> ProductPlaced { get; set; }

    }

    public class Placed
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public DateTime PlacedDate { get; set; }

        public Product PlacedProduct { get; set; }
        public Order PlacedOrder { get; set; }
    }

    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public List<Placed> OrderPlaced { get; set; }
    }
}