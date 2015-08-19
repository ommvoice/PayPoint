namespace PayPoint.WebApi.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using System.Configuration;
    using PayPoint.Domain;


    /// <summary>
    /// The DbContext for the PayPoint database
    /// </summary>
    public class PayPointDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PayPointDbContext"/> class.
        /// </summary>
        public PayPointDbContext()
            : base(ConfigurationManager.AppSettings["PayPointDB"])
        {         
        }

        /// <summary>
        /// Gets or sets the resource.
        /// </summary>
        public DbSet<Resource> Resources { get; set; }
    }

}