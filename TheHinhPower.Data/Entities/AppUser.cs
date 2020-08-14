using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TheHinhPower.Data.Enum;
using TheHinhPower.Data.Interfaces;

namespace TheHinhPower.Data.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>, IDateTracking, ISwitchable
    {
        public AppUser()
        {
        }
        public AppUser(Guid id, string fullName, string userName,
            string email, string phoneNumber, Status status, Guid humanId)
        {
            Id = id;
            FullName = fullName;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            Status = status;
            HumanId = humanId;
        }
        public string FullName { get; set; }
        public Guid HumanId { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; }
    }
}
