using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Linq;

namespace EmployeeFunctionApp
{
    public static class EmployeeFunction
    {
        [FunctionName("EmployeeFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            List<Employee> emplist = null;
            string EmployeeId = string.Empty;

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            EmployeeId = data?.employeeId;

            // create a list of Employee for demo.
                emplist = new List<Employee>();
                for (int i = 1; i < 5; i++)
                {
                    string empid = (i + 20).ToString();
                    emplist.Add(new Employee() { EmployeeId = empid, EmployeeName = $"Employee_"+i.ToString() });
                }

                // return all employees 
                if(emplist!=null)
                    return (ActionResult)new OkObjectResult(emplist);

            return new BadRequestObjectResult("Please pass a employee Id in the request body");
        }


        
    }
}
