using NightSword.Kernel.Entity.Abstract;
using NightSword.Kernel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Kernel.Entity.Concrete
{
    public class KernelEntity : IEntity<int>
    {
        //Loglama işlemleri
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIp { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedIp { get; set; }
        public string ModifiedBy { get; set; }

        public Status Status { get; set; }

    }
}
