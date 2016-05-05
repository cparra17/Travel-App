using System;
using System.ComponentModel.DataAnnotations;

namespace Lab_5.ViewModels
{
    public class StopViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, MinimumLength = 5)]
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
    }
}