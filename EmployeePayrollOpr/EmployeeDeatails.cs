using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollOpr
{
    public class EmployeeDeatails
    {
        public int EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public string Phonenumber { get; set; }

        public string Address { get; set; }

        public string Department { get; set; }

        public char Gender { get; set; }

        public double BasicPay { get; set; }

        public double Deduction { get; set; }

        public double TaxablePay { get; set; }

        public double Tax { get; set; }

        public string city { get; set; }

        public string Country { get; set; }

        public EmployeeDeatails(int employeeid,string employeename,string phonenumber,string address,string department,char gender,double basicpay,double deduction,double taxablepay,double tax,string City,string country)
        {
            this.EmployeeID = employeeid;
            this.EmployeeName = employeename;
            this.Phonenumber = phonenumber;
            this.Address = address;
            this.Department = department;
            this.Gender = gender;
            this.BasicPay = basicpay;
            this.Deduction = deduction;
            this.TaxablePay = taxablepay;
            this.Tax = tax;
            this.city = City;
            this.Country = country;
        }
             



    }
}
