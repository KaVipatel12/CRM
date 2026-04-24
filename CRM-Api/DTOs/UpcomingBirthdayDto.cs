using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Api.DTOs
{
    public class UpcomingBirthdayDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        [NotMapped]
        public int DaysUntil { get; set; }
        
        [NotMapped]
        public string Day { get; set; }
        
        [NotMapped]
        public string Month { get; set; }
    }
}
