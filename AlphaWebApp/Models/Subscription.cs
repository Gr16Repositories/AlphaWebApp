﻿
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.X86;

namespace AlphaWebApp.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
        [Required]
        public bool PaymentComplete { get; set; } 
        public string UserId { get; set; }
        public int SubscriptionTypeId { get; set; }
        public  virtual User User { get; set; }
        public virtual SubscriptionType SubscriptionType { get; set; }
    }
}
