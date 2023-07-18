using EasyCashIdentityProject.DtoLayer.DTOs.AppUserDtos;
using FluentValidation;

namespace EasyCashIdentityProject.BusinessLayer.FluentValidation.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            //Name Rules
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");



            //Surname Rules
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim Alanı Boş Geçilemez");



            //UserName Rules
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");



            //Email Rules
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen Geçerli Bir Email Adresi Giriniz")
                .NotEmpty().WithMessage("Mail Adresi Alanı Boş Olamaz");




            //Password Rules
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Alanı Boş Geçilemez");



            //Confirm Password Rules
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrar Alanı Boş Geçilemez")
                .Equal(y => y.Password).WithMessage("Şifreler Uyuşmuyor");

        }
    }
}
