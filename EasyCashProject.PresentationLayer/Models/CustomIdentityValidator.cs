using Microsoft.AspNetCore.Identity;

namespace EasyCashProject.PresentationLayer.Models
{
	public class CustomIdentityValidator : IdentityErrorDescriber
	{
		public override IdentityError DuplicateEmail(string email)
		{
			return new IdentityError
			{
				Code = "DuplicateEmail",
				Description = $"{email} Adresi Sistemde Zaten Kayıtlı"
			};
		}
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError
			{
				Code="PasswordRequiresDigit",
				Description=" Şifrenizde En Az 1 Rakam olmalı ([0,9])"
			};
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresUpper",
				Description ="Şifrenizde En Az 1 Büyük karakter olmalıdır ('A'-'Z')"
			};
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError
			{
				Code="PasswordRequiresLower",
				Description="Şifrenizde En Az 1 Küçük karakter olmalıdır  ('a'-'z')"
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError
			{
				Code ="PasswordRequiresNonAlphanumeric",
				Description="Şifrenizde En Az 1 alfanümerik karakter olmalıdır {!,',^,+,...}"
			};
		}
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError
			{
				Code = "PasswordTooShort",
				Description = $"Parolanız En Az {length} karakter olmalıdır"
			};
		}
		public override IdentityError PasswordMismatch()
		{
			return new IdentityError
			{
				Code = "PasswordMismatch",
				Description = "Şifreler Uyuşmuyor"
			};
		}
		public override IdentityError DuplicateUserName(string userName)
		{
			return new IdentityError
			{
				Code = "DuplicateUserName",
				Description = "Kullanıcı Adı Sistemde Kayıtlı"
			};
		}
	}
}
