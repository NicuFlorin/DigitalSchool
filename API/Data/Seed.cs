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
        public static async Task SeedUsers(ISchoolRepository schoolRepository, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (await schoolRepository.Exists())
            {
                return;
            }
            var schoolData = await System.IO.File.ReadAllTextAsync("Data/SeedData.json");
            var schools = JsonSerializer.Deserialize<List<School>>(schoolData);
            if (schools == null) return;
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
            foreach (var school in schools)
            {
                var schoolDto = new SchoolDto
                {
                    Name = school.Name != null ? school.Name : "Default"
                };
                int idSchool = await schoolRepository.AddSchool(schoolDto);
                if (school.Users != null)
                {
                    foreach (var user in school.Users)
                    {
                        user.UserName = user.UserName.ToLower();
                        user.SchoolId = idSchool;
                        await userManager.CreateAsync(user, "Parola_123");

                        await userManager.AddToRoleAsync(user, "Member");
                    }
                    await userManager.AddToRoleAsync(school.Users.ElementAt(0), "Admin");
                }
            }

        }
    }
}