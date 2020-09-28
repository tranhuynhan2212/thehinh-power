using System;
using System.Collections.Generic;
using System.Text;

namespace TheHinhPower.Infrastructure.SharedKernel
{
    public abstract class BaseViewModel<T>
    {
        public T Id { get; set; }
    }
}
