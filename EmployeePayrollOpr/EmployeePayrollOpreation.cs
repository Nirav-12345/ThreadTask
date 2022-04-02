using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollOpr
{
    public class EmployeePayrollOpreation
    {
        List<EmployeeDeatails> employeeDeatails = new List<EmployeeDeatails>();

        public void EmployeePalyRoll(List<EmployeeDeatails> listemployeedetails)
        {
            listemployeedetails.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added:" + employeeData.EmployeeName);
                this.EmployeePalyRoll(employeeData);
                Console.WriteLine("Employee added: " + employeeData.EmployeeName);
            });
            Console.WriteLine(this.employeeDeatails.ToString());
        }
        private void EmployeePalyRoll(EmployeeDeatails emp)
        {
            employeeDeatails.Add(emp);
        }
        public void addEmployeePayrollWiththread(List<EmployeeDeatails> listemployeedetails)
        {
            listemployeedetails.ForEach(employeeData =>
            {
                Task tread = new Task(() =>
                 {
                     Console.WriteLine("Employee being added:" + employeeData.EmployeeName);
                     this.EmployeePalyRoll(employeeData);
                     Console.WriteLine("Employee added: " + employeeData.EmployeeName);


                 });

                tread.Start();



            });
            Console.WriteLine(this.employeeDeatails.ToString());
        }
    }
}
