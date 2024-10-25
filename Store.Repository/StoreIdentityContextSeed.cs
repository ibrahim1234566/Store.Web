using Microsoft.AspNetCore.Identity;
using Store.Data.Entity.IdentityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreIdentityContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any() )
            {
                var user = new AppUser()
                {
                    DisplayName="Ibrahim EZZAT",
                    Email="hemaazz123@gmail.com",
                    UserName= "IbrahimEZZAT",
                    address = new Address()
                    {
                        FirstName = "Ibrahim",
                        LastName= "EZZAT",
                        City ="Alex",
                        State="Miami",
                        Street="45",
                        PostalCode="21644"

                    }

                };
                await userManager.CreateAsync(user,"password123#");
                
            }
        }
    }
}
