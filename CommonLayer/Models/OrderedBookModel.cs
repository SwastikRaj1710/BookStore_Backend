using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class OrderedBookModel
    {
        public string BookId { get; set; }
        public string BookName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
