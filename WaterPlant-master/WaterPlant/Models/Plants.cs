using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WaterPlant.Models
{
    public class Plants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? LastWatered { get; set; }

        public string ImageUrl { get; set; }
    }
}