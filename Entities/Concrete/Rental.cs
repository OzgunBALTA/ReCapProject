using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }

        [DefaultValue(null)]
        public DateTime RentalDate { get; set; }

        [DefaultValue(null)]
        public DateTime ReturnDate { get; set; }


        public Car Car { get; set; }
    }
}
