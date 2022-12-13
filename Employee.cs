using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeFunctionApp
{
   public class Employee
    {
            [JsonProperty(PropertyName = "employeeId")]
            public string EmployeeId { get; set; }
            public string EmployeeName { get; set; }
    }
}
