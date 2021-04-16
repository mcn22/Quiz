using EditorialMvc.DataAccess.Data;
using EditorialMvc.Models;
using EditorialMvc.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditorialMvc
{
    public static class Setup
    {

        public static async Task<bool> InitAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Creacion de los roles en caso de que no existan para ejecutar la primera vez

            var RoleManager = roleManager;
            var UserManager = userManager;

            if (!await RoleManager.RoleExistsAsync(SD.Roles.Administrador))
            {   
                await RoleManager.CreateAsync(new IdentityRole(SD.Roles.Administrador));              
            }
            if (!await RoleManager.RoleExistsAsync(SD.Roles.Empleado))
            {
                await RoleManager.CreateAsync(new IdentityRole(SD.Roles.Empleado));
            }
            if (!await RoleManager.RoleExistsAsync(SD.Roles.Simple))
            {
                await RoleManager.CreateAsync(new IdentityRole(SD.Roles.Simple));
            }
            //fin Creacion de los roles
            //*****************************************************************************//
            //*****************************************************************************//
            //Creacion el primer usuario con rol de administrador para el primer usuario            
            var user =
                new Usuario
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    Nombre = "admin",
                    PhoneNumber = "12345",
                };
            if (!UserManager.Users.Select(u => u.Email == u.Email).FirstOrDefault())
            {
                await UserManager.CreateAsync(user, "Admin-2020");
                await UserManager.AddToRoleAsync(user, SD.Roles.Administrador);
            }
            return true;
        }
    }
}
