namespace PayPoint.WebApi.DbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class T1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Culture = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Resources");
        }
    }
}
