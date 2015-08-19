using Common;
using PayPoint.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PayPoint.WebApi.DbContext
{
    public class Configuration : DbMigrationsConfiguration<PayPointDbContext>
    {
        #region Public Methods

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Seeds the database
        /// </summary>
        /// <param name="context">the PayPoint database context</param>
        protected override void Seed(PayPointDbContext context)
        {
            SeedCulture(context);
            context.SaveChanges();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Seed the culture default entries
        /// </summary>
        /// <param name="context">the context</param>
        private static void SeedCulture(PayPointDbContext context)
        {
            // If the seeded resources don't exist, then create them
            if (!context.Resources.Any(resource => resource.Key == CultureConstants.UserNameKey))
            {
                context.Resources.AddOrUpdate(new Resource { Key = CultureConstants.UserNameKey, Value = CultureConstants.CHNValue, Culture = CultureConstants.CHNCulture });
            }

            if (!context.Resources.Any(resource => resource.Key == CultureConstants.UserNameKey))
            {
                context.Resources.AddOrUpdate(new Resource { Key = CultureConstants.UserNameKey, Value = CultureConstants.USValue, Culture = CultureConstants.USCulture });
            }
        }

        #endregion
    }
}