using System;
using System.Collections.Generic;
using System.Text;
using TheHinhPower.Infrastructure.SharedKernel;

namespace TheHinhPower.Service.ViewModels
{
    public class CategoryProductViewModel : BaseViewModel<Guid>
    {
        public string Name { get; set; }
        public string Commission_f1 { get; set; }
        public string Commission_f2 { get; set; }
        public string Commission_f3 { get; set; }
        public string Personal { get; set; }
    }
}
