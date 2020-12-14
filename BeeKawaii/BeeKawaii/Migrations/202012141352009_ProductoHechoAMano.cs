namespace BeeKawaii.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductoHechoAMano : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductoHechoAManoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false, maxLength: 30),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Caracteristicas = c.String(nullable: false, maxLength: 90),
                        Material = c.String(nullable: false, maxLength: 30),
                        Tamaño = c.String(nullable: false, maxLength: 10),
                        TiempoRealización = c.String(nullable: false, maxLength: 30),
                        Costo = c.Single(nullable: false),
                        PrecioVenta = c.Double(nullable: false),
                        Imagen = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pupilentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Modelo = c.String(),
                        Color = c.String(),
                        Costo = c.Double(nullable: false),
                        TamañoPupila = c.Double(nullable: false),
                        TamañoDiametro = c.Double(nullable: false),
                        PrecioVenta = c.Double(nullable: false),
                        Imagen = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pupilentes");
            DropTable("dbo.ProductoHechoAManoes");
        }
    }
}
