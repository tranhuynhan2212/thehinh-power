using System;
using System.Collections.Generic;
using System.Text;
using TheHinhPower.Data.Enum;

namespace TheHinhPower.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { get; set; }
    }
}
