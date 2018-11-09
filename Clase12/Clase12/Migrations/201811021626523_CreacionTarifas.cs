namespace Clase12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionTarifas : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Genero");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genero", c => c.String());
        }
    }
}
