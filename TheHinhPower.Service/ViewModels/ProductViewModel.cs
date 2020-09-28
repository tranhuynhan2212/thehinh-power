using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TheHinhPower.Data.Enum;
using TheHinhPower.Infrastructure.SharedKernel;

namespace TheHinhPower.Service.ViewModels
{
    public class ProductViewModel : BaseViewModel<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string description { get; set; }
        public Guid? CategoryProduct_id { get; set; }
        public virtual CategoryProductViewModel CategoryProduct { get; set; }
        public Status Status { get; set; }
    }
}
