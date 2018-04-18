using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models{
  public class User : BaseEntity{
    [Key]
    public int UserId {get; set; }
    [Required]
    public string FirstName {get; set; }
    [Required]
    public string LastName {get; set; }
    [Required]
    [EmailAddress]
    public string Email {get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password {get; set; }
    [Compare("Password", ErrorMessage="Passwords must match")]
    [DataType(DataType.Password)]
    public string PasswordConfirmation {get; set; }
    public DateTime CreatedAt{get; set; }
    public int Balance {get; set; }
    public List<Account> Accounts {get; set;}
    public User(){
      Accounts = new List<Account>();
    }  
  }
}