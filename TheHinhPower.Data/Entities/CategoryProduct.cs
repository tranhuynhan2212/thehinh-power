using System;
using System.Collections.Generic;
using System.Text;
using TheHinhPower.Infrastructure.SharedKernel;

namespace TheHinhPower.Data.Entities
{
    public class CategoryProduct : DomainEntity<Guid>
    {
        public string Name { get; set; }
        public string Commission_f1 { get; set; }
        public string Commission_f2 { get; set; }
        public string Commission_f3 { get; set; }
        public string Personal { get; set; }
        public CategoryProduct()
        {

        }
        public CategoryProduct(string name, string commission_f1, string commission_f2, string commission_f3, string personal)
        {
            this.Name = name;
            this.Commission_f1 = commission_f1;
            this.Commission_f2 = commission_f2;
            this.Commission_f3 = commission_f3;
            this.Personal = personal;
        }
        
    }
}
