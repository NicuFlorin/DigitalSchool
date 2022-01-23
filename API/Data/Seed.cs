using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {

            var userData = await System.IO.File.ReadAllTextAsync("Data/SeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            if (users == null) return;
            var roles = new List<AppRole>
            {
                new AppRole{Name="Admin"},
                new AppRole{Name="Moderator"},
                new AppRole{Name="Teacher"},
                new AppRole{Name="Student"},
                new AppRole{Name="Parent"},
                new AppRole{Name="Member"}

            };
            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }




            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();

                await userManager.CreateAsync(user, "Parola_123");

                await userManager.AddToRoleAsync(user, "Member");
            }
            await userManager.AddToRoleAsync(users.ElementAt(0), "Admin");



        }
    }
}