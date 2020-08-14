using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheHinhPower.Infrastructure.SharedKernel
{
    public abstract class DomainEntity<T> : IDelete
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public T Id { get; set; }
        public Guid UserCreated { get; set; }
        public Guid UserModified { get; set; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public bool IsDeleted { get; set; }

        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }
    }
}
