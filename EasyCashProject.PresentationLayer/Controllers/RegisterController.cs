using EasyCashIdentityProject.BusinessLayer.FluentValidation.AppUserValidationRules;
using EasyCashIdentityProject.DtoLayer.DTOs.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using FluentValidation.Results;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EasyCashProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        string from = "tnecmi81@gmail.com";
        string subject = "Email Doğrulama Kodu";

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager=userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto model) 
        {
            if (ModelState.IsValid)
            {
                AppUserRegisterValidator validations = new();
                ValidationResult validate = validations.Validate(model);
                if (validate.IsValid)
                {
                    Random random = new();
                    string code = random.Next(100000,999999).ToString();
                    AppUser user = new()
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        UserName = model.UserName,
                        Email = model.Email,
                        ConfirmCode= code
                    };
                    IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        MimeMessage message = new();

                        MailboxAddress MailFrom = new("EasyCash Admin", from);
                        MailboxAddress MailTo = new("User", user.Email);
                        message.From.Add(MailFrom);
                        message.To.Add(MailTo);

                        BodyBuilder bodyBuilder = new();
                        bodyBuilder.TextBody = "Email Onay Kodunuz: "+code;

                        message.Body = bodyBuilder.ToMessageBody();
						message.Subject = subject;

						using SmtpClient client = new();
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate(from, "nbgakmmoozfptvfr");
                        client.Send(message);
                        client.Disconnect(true);
                        TempData["MailAddress"]=model.Email;
                        return RedirectToAction("Index", "MailConfirm");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                else
                {
                    foreach (var item in validate.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                    }                    
                }

            }   
            return View(model);
        }
    }
}
