
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class AddOrderModel
    {
        public DateTime OrderDate { get; set; }
        public ICollection<OrderedBookModel> Books { get; set; }
    }
}
