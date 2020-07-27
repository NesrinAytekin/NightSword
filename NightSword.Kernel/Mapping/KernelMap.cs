using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NightSword.Kernel.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Kernel.Mapping
{
    //Aşağıda diyoruzki KernelMap classı senin Tipin "T" olacak  yine "T" tipinde olan IEntityTypeConfiguration 'dan miras alacaksın  ve bu "T" tipide KernelEntity class'ı olacak

    //abstract olarak işaretledik çünkü ata sınıf ve override etmemiz gerekiyor.

    //KernelMap sınıfın IEntityTypeConfiguration ile extend etmek için Microsoft.EntityFrameworkCore'u yüklememiz gerektiğinden bu library' Nuget Packages'dan indirilir.
    public abstract class KernelMap<T>: IEntityTypeConfiguration<T> where T:KernelEntity
    {
        //Entity'lerim tarafından bu metodun override edileceğinden virtual olarak metodumuzu isaretlyoruz.EntityTypeBuilder için usuinglerimize Microsoft.EntityFrameworkCore.Metadata.Builders eklenir.Ve T tipinde bir builder nesnesi türetilir.

        //Klasik .Net'de bu map'leme işlemini yapıcı metod içerisnde yapıyorduk ancak Core'da bu durum değişti.

        //Bu class sayesinde miras alan class'ların ortak alanları aşağıdaki gibi maplenmiş bir halde olmuş oldu tekrar tekrar her entity'i maplerken ortak alanların map'lenmesine ihtiyaç kalmadı.
        public virtual void Configure(EntityTypeBuilder<T>builder) 
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status).IsRequired(true);

            builder.Property(x => x.CreateDate).IsRequired(false);
            builder.Property(x => x.CreatedComputerName).IsRequired(true);
            builder.Property(x => x.CreatedIp).IsRequired(true);
            builder.Property(x => x.CreatedBy).IsRequired(true);


            builder.Property(x => x.ModifiedIp).IsRequired(false);
            builder.Property(x => x.ModifiedDate).IsRequired(false);
            builder.Property(x => x.ModifiedComputerName).IsRequired(false);
            builder.Property(x => x.ModifiedBy).IsRequired(false);
        }
    }
}
