using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VSBlog_Backend.Model
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20)]
        [Index(IsUnique=true)]
        public string Email { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        
        [StringLength(20)]
        [Index(IsUnique=true)]
        public string Token { get; set; }     

        [StringLength(20)]
        public string Name { get; set; }
        
        [StringLength(20)]
        public string Phonenumber { get; set; }
        
        [StringLength(40)]
        public string Address { get; set; }

        public DateTime RegisterTime { get; set; }

        public DateTime? Birthday { get; set; }
        
        public bool? Gender { get; set; }

        public object GetPublicInfo()
        {
            return new
            {
                Id,
                Name,
                RegisterTime,
            };
        }
        
        public object GetPersonalInfo()
        {
            return new
            {
                Id,
                Email,
                Name,
                Phonenumber,
                Address,
                RegisterTime,
                Birthday,
                Gender
            };
        }

        public object GetInfoWithToken()
        {
            return new
            {
                Id,
                Email,
                Name,
                Phonenumber,
                Address,
                RegisterTime,
                Birthday,
                Gender,
                Token
            };
        }
        
        public string GenerateToken()
        {
            //todo regenToken
            return Token;
        }
    }
}