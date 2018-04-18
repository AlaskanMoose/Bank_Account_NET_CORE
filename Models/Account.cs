using System;
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models{
  public class Account : BaseEntity{
    public int AccountId {get; set; }
    public int Amount {get; set; } 
    public DateTime CreatedAt{get; set; }
    public int UserId{get; set; }
    public User User {get; set; }
    public Account(){
      
    }
  }
}