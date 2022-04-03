using System;
using System.ComponentModel.DataAnnotations;

namespace budgetTracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; } = DateTime.MinValue;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] Picture { get; set; }
        public Budget Budget { get; set; }
    }
}