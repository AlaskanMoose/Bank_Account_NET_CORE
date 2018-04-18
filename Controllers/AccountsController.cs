using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankAccount.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System;


namespace BankAccount.Controllers{
    public class AccountsController : Controller{
        private BankAccountContext _context;
        public AccountsController(BankAccountContext context){
            _context = context;
        }

        [HttpGet]
        [Route("dash")]
        public IActionResult Dash(){
            if(!CheckLogin()){
                return RedirectToAction("Index", "Users");
            }
            var curr_user = _context.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("CurrUserId"));
            ViewBag.CurrentUser = curr_user;
            List<Account> AllAccounts = _context.Accounts.Where(account => account.UserId == curr_user.UserId).OrderByDescending(account => account.CreatedAt).ToList();
            ViewBag.Accounts = AllAccounts;
            return View("Dash");
        }
        [HttpPost]
        [Route("deposit")]
        public IActionResult Deposit(Account model){
          if(ModelState.IsValid){
            User RetrievedUser = _context.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("CurrUserId"));
            RetrievedUser.Balance += model.Amount;
            _context.SaveChanges();
            model.UserId = RetrievedUser.UserId;
            model.CreatedAt = DateTime.Now;
            _context.Add(model);
            _context.SaveChanges();
          }
          return RedirectToAction("Dash");
        }

        private bool CheckLogin(){
            return (HttpContext.Session.GetInt32("CurrUserId") != null);
        }
    }  
}