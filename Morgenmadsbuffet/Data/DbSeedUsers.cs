using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Morgenmadsbuffet.Models;

namespace Morgenmadsbuffet.Data
{
    public class DbSeedUsers
    {
     
        public static void SeedData(ApplicationDbContext db, UserManager<ApplicationUser> userManager, ILogger log)
        {
            SeedUsers(userManager, log);
            //SeedReceptionist(userManager, log);
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager, ILogger log)
        {
            //Waiter information
            const string waiterEmail = "waiter@Morgenmadsbuffet.dk";
            const string waiterPassword = "Waiter1!";


            //Receptionist information
            const string receptionistEmail = "receptionist@Morgenmadsbuffet.dk";
            const string receptionistPassword = "Receptionist1!";

            if (userManager.FindByNameAsync(waiterEmail).Result == null)
            {
                log.LogWarning("Seeding the waiter account");
                var userWaiter = new ApplicationUser
                {
                    UserName = waiterEmail,
                    Email = waiterEmail,
                    Name = "Waiter",
                    EmailConfirmed = true
                };
                IdentityResult result = userManager.CreateAsync
                    (userWaiter, waiterPassword).Result;
                if (result.Succeeded)
                {
                    var waiterClaim = new Claim("Waiter", "Yes");
                    userManager.AddClaimAsync(userWaiter, waiterClaim).Wait();
                }

            }

            if (userManager.FindByNameAsync(receptionistEmail).Result == null)
            {
                log.LogWarning("Seeding the receptionist account");
                var userReceptionist = new ApplicationUser
                {
                    UserName = receptionistEmail,
                    Email = receptionistEmail,
                    Name = "Waiter",
                    EmailConfirmed = true
                };
                IdentityResult result = userManager.CreateAsync
                    (userReceptionist, receptionistPassword).Result;
                if (result.Succeeded)
                {
                    var receptionistClaim = new Claim("Receptionist", "Yes");
                    userManager.AddClaimAsync(userReceptionist, receptionistClaim).Wait();
                }

            }
        }

        //public static void SeedReceptionist(UserManager<ApplicationUser> userManager, ILogger log)
        //{
        //    const string receptionistEmail = "receptionist@Morgenmadsbuffet.dk";
        //    const string receptionistPassword = "Receptionist1!";

        //    if (userManager.FindByNameAsync(receptionistEmail).Result == null)
        //    {
        //        log.LogWarning("Seeding the receptionist account");
        //        var userRecptionist = new ApplicationUser
        //        {
        //            UserName = receptionistEmail,
        //            Email = receptionistEmail,
        //            Name = "Receptionist",
        //            EmailConfirmed = true

        //        };
        //        IdentityResult result = userManager.CreateAsync
        //            (userRecptionist, receptionistPassword).Result;
        //        if (result.Succeeded)
        //        {
        //            var receptionistClaim = new Claim("Receptionist", "Yes");
        //            userManager.AddClaimAsync(userRecptionist, receptionistClaim).Wait();
                    
        //        }
        //    }
        //}

        //public static void SeedWaiter(UserManager<ApplicationUser> userManager, ILogger log)
        //{
        //    const string waiterEmail = "waiter@Morgenmadsbuffet.dk";
        //    const string waiterPassword = "Waiter1!";

        //    if (userManager.FindByNameAsync(waiterEmail).Result == null)
        //    {
        //        log.LogWarning("Seeding the waiter account");
        //        var userWaiter = new ApplicationUser
        //        {
        //            UserName = waiterEmail,
        //            Email = waiterEmail,
        //            Name = "Waiter"
        //        };
        //        IdentityResult result = userManager.CreateAsync
        //        (userWaiter, waiterPassword).Result;
        //        if (result.Succeeded)
        //        {
        //            var waiterClaim = new Claim("Waiter", "Yes");
        //            userManager.AddClaimAsync(userWaiter, waiterClaim);
        //            userWaiter.EmailConfirmed = true;
        //        }
        //    }
        //}
    }
}
