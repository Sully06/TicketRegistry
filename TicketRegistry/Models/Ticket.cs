// Name: Sully Cavanh
// School: DMACC
// Assignment: Ticket Validation System with Database
// I attest that this is original work. No unauthorized assistance was received. I understand the concepts of academic integrity and have adhered to them in this assignment.

using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PassengerName { get; set; } = string.Empty;

        [Required]
        public string Destination { get; set; } = string.Empty;

        public bool IsValid { get; set; } = true;
    }
}
