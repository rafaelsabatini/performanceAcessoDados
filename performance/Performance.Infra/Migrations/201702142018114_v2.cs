namespace Performance.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pedido", "Numero", c => c.String(maxLength: 8, fixedLength: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pedido", "Numero", c => c.String());
        }
    }
}
