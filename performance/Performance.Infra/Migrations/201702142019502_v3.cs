namespace Performance.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "Valor", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Pedido", "Numero", c => c.String(maxLength: 8, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pedido", "Numero", c => c.String(maxLength: 8, fixedLength: true));
            AlterColumn("dbo.Item", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
