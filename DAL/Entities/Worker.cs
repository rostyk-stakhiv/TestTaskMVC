using System;

namespace DAL.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Married { get; set; }
        public decimal Salary { get; set; }
        public string Phone { get; set; }
    }
}