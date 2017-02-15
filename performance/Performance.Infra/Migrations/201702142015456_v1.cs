namespace Performance.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProdutoId = c.Guid(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pedido_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id)
                .Index(t => t.Pedido_Id);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Numero = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        UsuarioId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "Pedido_Id", "dbo.Pedido");
            DropIndex("dbo.Item", new[] { "Pedido_Id" });
            DropTable("dbo.Pedido");
            DropTable("dbo.Item");
        }
    }
}
