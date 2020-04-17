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
            SeedReceptionist(userManager, log);
            SeedWaiter(userManager, log);
        }

        public static void SeedReceptionist(UserManager<ApplicationUser> userManager, ILogger log)
        {
            const string receptionistEmail = "receptionist@Morgenmadsbuffet.dk";
            const string receptionistPassword = "Receptionist1!";

            if (userManager.FindByNameAsync(receptionistEmail).Result == null)
            {
                log.LogWarning("Seeding the receptionist account");
                var user = new ApplicationUser
                {
                    UserName = receptionistEmail,
                    Email = receptionistEmail,
                    Name = "Receptionist"
                };
                IdentityResult result = userManager.CreateAsync
                    (user, receptionistPassword).Result;
                if (result.Succeeded)
                {
                    var receptionistClaim = new Claim("Receptionist", "Yes");
                    userManager.AddClaimAsync(user, receptionistClaim);
                }
            }
        }

        public static void SeedWaiter(UserManager<ApplicationUser> userManager, ILogger log)
        {
            const string waiterEmail = "waiter@Morgenmadsbuffet.dk";
            const string waiterPassword = "Waiter1!";

            if (userManager.FindByNameAsync(waiterEmail).Result == null)
            {
                log.LogWarning("Seeding the waiter account");
                var user = new ApplicationUser
                {
                    UserName = waiterEmail,
                    Email = waiterEmail,
                    Name = "Waiter"
                };
                IdentityResult result = userManager.CreateAsync
                    (user, waiterPassword).Result;
                if (result.Succeeded)
                {
                    var waiterClaim = new Claim("Waiter", "Yes");
                    userManager.AddClaimAsync(user, waiterClaim);
                }
            }
        }


        //********No need for this account*************
        //public static void SeedKitchen(UserManager<ApplicationUser> userManager, ILogger log)
        //{
        //    const string kitchenEmail = "kitchen@Morgenmadsbuffet.dk";
        //    const string kitchenPassword = "kitchen1!";

        //    if (userManager.FindByNameAsync(kitchenEmail).Result == null)
        //    {
        //        log.LogWarning("Seeding the kitchen account");
        //        var user = new ApplicationUser
        //        {
        //            UserName = kitchenEmail,
        //            Email = kitchenEmail,
        //            Name = "Kitchen"
        //        };
        //        IdentityResult result = userManager.CreateAsync
        //            (user, kitchenPassword).Result;
        //    }
        //}


    }
}
