namespace Clase12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionCliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoClientes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Nombre = c.String(),
                        costoSubcripcion = c.Short(nullable: false),
                        duracionSubEnMeses = c.Byte(nullable: false),
                        porcDescuento = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Clientes", "EstaInscritoRevista", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clientes", "IdTipoCliente", c => c.Byte(nullable: false));
            AddColumn("dbo.Clientes", "tipoCliente_Id", c => c.Byte());
            AlterColumn("dbo.Clientes", "Nombre", c => c.String(nullable: false, maxLength: 250));
            CreateIndex("dbo.Clientes", "tipoCliente_Id");
            AddForeignKey("dbo.Clientes", "tipoCliente_Id", "dbo.TipoClientes", "Id");
            DropColumn("dbo.Clientes", "Salario");
            DropColumn("dbo.Clientes", "Activo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Activo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clientes", "Salario", c => c.Double(nullable: false));
            DropForeignKey("dbo.Clientes", "tipoCliente_Id", "dbo.TipoClientes");
            DropIndex("dbo.Clientes", new[] { "tipoCliente_Id" });
            AlterColumn("dbo.Clientes", "Nombre", c => c.String());
            DropColumn("dbo.Clientes", "tipoCliente_Id");
            DropColumn("dbo.Clientes", "IdTipoCliente");
            DropColumn("dbo.Clientes", "EstaInscritoRevista");
            DropTable("dbo.TipoClientes");
        }
    }
}
