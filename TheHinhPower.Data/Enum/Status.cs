using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheHinhPower.Data.Enum
{
    public enum Status
    {
        [Display(Name = "Tắt")]
        InActive,
        [Display(Name = "Bật")]
        Active
    }
}
