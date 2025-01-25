using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskManagementv2.Pages.Admin
{
    public class loginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Credential.Username == "admin" && Credential.Password == "admin")
                {
                    Response.Redirect("/Admin/taasks");
                }
                else if (Credential.Username == "user" && Credential.Password == "user")
                {
                    Response.Redirect("/Employee/Employee");
                }
                else if(Credential.Username == "notuser" && Credential.Password == "notuser")
                {
                    Response.Redirect("/Employee/Employee1");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password");
                }
            }
        }
    }
    public class Credential
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
