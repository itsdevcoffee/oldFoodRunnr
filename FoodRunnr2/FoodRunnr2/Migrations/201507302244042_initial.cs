namespace FoodRunnr2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductDescription = c.String(),
                        ProductImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingCartProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ShoppingCartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCartId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ShoppingCartId);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCartProducts", "ShoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.ShoppingCartProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.ShoppingCartProducts", new[] { "ShoppingCartId" });
            DropIndex("dbo.ShoppingCartProducts", new[] { "ProductId" });
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.ShoppingCartProducts");
            DropTable("dbo.Products");
        }
    }
}
