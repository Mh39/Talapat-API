using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;

namespace TalabatG02.Core.Specifications
{
    public class EmployeeSpecification:BaseSpecification<Employee>
    {
        public EmployeeSpecification() //Get
        {
            Includes.Add(E => E.Department);
        }
        public EmployeeSpecification(int id) : base(E => E.Id == id) //GetByID
        {
            Includes.Add(E => E.Department);
            

        }
    }
}
