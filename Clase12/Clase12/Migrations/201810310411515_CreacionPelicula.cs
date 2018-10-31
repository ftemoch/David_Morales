namespace Clase12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionPelicula : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoPeliculas",
                c => new
                    {
                        id = c.Byte(nullable: false),
                        Nombre = c.String(),
                        costoDia = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Movies", "IdTipoPelicula", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "tipoPelicula_id", c => c.Byte());
            CreateIndex("dbo.Movies", "tipoPelicula_id");
            AlterColumn("dbo.Movies", "Nombre", c => c.String(nullable: false, maxLength: 250));
            AddForeignKey("dbo.Movies", "tipoPelicula_id", "dbo.TipoPeliculas", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "tipoPelicula_id", "dbo.TipoPeliculas");
            DropIndex("dbo.Movies", new[] { "tipoPelicula_id" });
            DropColumn("dbo.Movies", "tipoPelicula_id");
            AlterColumn("dbo.Movies", "Nombre", c => c.String());
            DropColumn("dbo.Movies", "IdTipoPelicula");
            DropTable("dbo.TipoPeliculas");
        }
    }
}
