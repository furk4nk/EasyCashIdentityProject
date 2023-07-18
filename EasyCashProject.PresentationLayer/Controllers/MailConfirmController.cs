using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace EasyCashProject.PresentationLayer.Controllers
{
	public class MailConfirmController : Controller
	{
        private readonly UserManager<AppUser> _userManager;

        public MailConfirmController(UserManager<AppUser> userManager)
        {
            _userManager=userManager;
        }

        [HttpGet]
		public IActionResult Index()
		{
			var value= TempData["MailAddress"];
			ViewBag.address=value;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(MailConfirmViewModel model)
		{
			var user = await _userManager.FindByEmailAsync(model.mail);
			if (model.code == user.ConfirmCode)
			{
				user.EmailConfirmed=true;
				await _userManager.UpdateAsync(user);
				return RedirectToAction("Index", "Profile");
			}
			else
			{
				ModelState.AddModelError("code", "Girilen Kod Geçersiz");
			}
			return View();
		}
	}
}
