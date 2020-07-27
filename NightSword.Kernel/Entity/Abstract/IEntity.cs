using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Kernel.Entity.Abstract
{
    public interface IEntity<T> //Burada IEntity clasına T adında Tip Vermiş olduk
    {
        T Id { get; set; }
    }
}
