using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TheHinhPower.Data.Enum;
using TheHinhPower.Data.Interfaces;
using TheHinhPower.Infrastructure.SharedKernel;

namespace TheHinhPower.Data.Entities
{
    public class Product : DomainEntity<Guid>, ISwitchable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string description { get; set; }
        public Guid? CategoryProduct_id { get; set; }
        [ForeignKey("CategoryProduct_id")]
        public virtual CategoryProduct CategoryProduct { get; set; }
        public Status Status { get; set; }
    }
}
