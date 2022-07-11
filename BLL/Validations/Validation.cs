using DAL.Entities;
using System;
using System.Text.RegularExpressions;

namespace BLL.Validations
{
    public static class Validation
    {
        public static bool ValidateWorker(Worker item)
        {
            if (item.Name.Length < 3 || item.Name.Length > 50)
            {
                throw new TestTaskException("Name length must be between 3 and 50 symbols");
            }

            if (item.DateOfBirth< new DateTime(1900,1,1)  || item.DateOfBirth > DateTime.Today)
            {
                throw new TestTaskException("Person with such date of birth cannot exist");
            }

            if (item.Salary < 0)
            {
                throw new TestTaskException("Salary cannot be less than zero");
            }

            if (!Regex.IsMatch(item.Phone, @"^[+]?[3]?[8]?[0][0-9]{9}$"))
            {
                throw new TestTaskException("Phone format is invalid");
            }

            return true;
        }
    }
}
