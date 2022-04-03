using System;
using System.Buffers.Text;

namespace budgetTracker.Dtos
{
    public class UserRegisterDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        public string Picture { get; set; }
    }
}