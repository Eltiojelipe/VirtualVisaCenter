﻿using VirtualVisaCenter.API.Data;
using VirtualVisaCenter.Shared.Entities;
using VirtualVisaCenter.Shared.Enums;
using VirualVisaCenter.API.Helpers;

namespace VirualVisaCenter.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }



        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTypeVIsasAsync();
            await CheckRolesAsync();
            await CheckUserAsync("201907","Sebas", "Admin", "sebasdago.2019@gmail.com", "305232456", "Lo que sea", UserType.Admin);

        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }



        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);

            if (user == null)
            {

                user = new User
                {
                    Document = document,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phone,
                    UserName = email,
                    Address = address,
                    UserType = userType,
                };

                await _userHelper.AdduserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }
            return user;
        }

        private async Task CheckTypeVIsasAsync()
        {
            if (!_context.TypeVIsas.Any())
            {
                _context.TypeVIsas.Add(new TypeVIsa { Name = "Turismo" });
                _context.TypeVIsas.Add(new TypeVIsa { Name = "Negocios" });
                _context.TypeVIsas.Add(new TypeVIsa { Name = "Empleo" });
                _context.TypeVIsas.Add(new TypeVIsa { Name = "Estudios" });
                _context.TypeVIsas.Add(new TypeVIsa { Name = "Inmigracion" });
                _context.TypeVIsas.Add(new TypeVIsa { Name = "Comercio" });
                _context.TypeVIsas.Add(new TypeVIsa { Name = "Inversion" });
                _context.TypeVIsas.Add(new TypeVIsa { Name = "Intercambio" });
                _context.TypeVIsas.Add(new TypeVIsa { Name = "Adopcion" });
            }



            await _context.SaveChangesAsync();

        }

    }
}
