namespace YulineServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Card",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Desc = c.String(),
                        Atk = c.Int(),
                        Def = c.Int(),
                        Type = c.String(),
                        Level = c.Int(nullable: false),
                        Race = c.String(),
                        Attribute = c.String(),
                        Scale = c.Int(),
                        Linkval = c.Int(),
                        Linkmarkers = c.Int(),
                        Archetype = c.String(),
                        Setcode = c.String(),
                        BanTcg = c.String(),
                        BanOcg = c.String(),
                        BanGoat = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CardExtraDecks",
                c => new
                    {
                        IdExtraDeck = c.Int(nullable: false, identity: true),
                        CardExtraDeck1_Id = c.String(maxLength: 128),
                        DeckExtraDeck_IdDeck = c.Int(),
                    })
                .PrimaryKey(t => t.IdExtraDeck)
                .ForeignKey("dbo.Card", t => t.CardExtraDeck1_Id)
                .ForeignKey("dbo.Deck", t => t.DeckExtraDeck_IdDeck)
                .Index(t => t.CardExtraDeck1_Id)
                .Index(t => t.DeckExtraDeck_IdDeck);
            
            CreateTable(
                "dbo.Deck",
                c => new
                    {
                        IdDeck = c.Int(nullable: false, identity: true),
                        _mainDeck = c.Int(nullable: false),
                        _sideDeck = c.Int(nullable: false),
                        _extraDeck = c.Int(nullable: false),
                        Name = c.String(),
                        BanList = c.String(),
                        Player_IdPlayer = c.Int(),
                    })
                .PrimaryKey(t => t.IdDeck)
                .ForeignKey("dbo.Player", t => t.Player_IdPlayer)
                .Index(t => t.Player_IdPlayer);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        IdPlayer = c.Int(nullable: false, identity: true),
                        Pseudo = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.IdPlayer);
            
            CreateTable(
                "dbo.CardMainDecks",
                c => new
                    {
                        IdMainDeck = c.Int(nullable: false, identity: true),
                        CardMainDeck1_Id = c.String(maxLength: 128),
                        DeckMainDeck_IdDeck = c.Int(),
                    })
                .PrimaryKey(t => t.IdMainDeck)
                .ForeignKey("dbo.Card", t => t.CardMainDeck1_Id)
                .ForeignKey("dbo.Deck", t => t.DeckMainDeck_IdDeck)
                .Index(t => t.CardMainDeck1_Id)
                .Index(t => t.DeckMainDeck_IdDeck);
            
            CreateTable(
                "dbo.CardSideDecks",
                c => new
                    {
                        IdSideDeck = c.Int(nullable: false, identity: true),
                        CardSideDeck1_Id = c.String(maxLength: 128),
                        DeckSideDeck_IdDeck = c.Int(),
                    })
                .PrimaryKey(t => t.IdSideDeck)
                .ForeignKey("dbo.Card", t => t.CardSideDeck1_Id)
                .ForeignKey("dbo.Deck", t => t.DeckSideDeck_IdDeck)
                .Index(t => t.CardSideDeck1_Id)
                .Index(t => t.DeckSideDeck_IdDeck);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CardSideDecks", "DeckSideDeck_IdDeck", "dbo.Deck");
            DropForeignKey("dbo.CardSideDecks", "CardSideDeck1_Id", "dbo.Card");
            DropForeignKey("dbo.CardMainDecks", "DeckMainDeck_IdDeck", "dbo.Deck");
            DropForeignKey("dbo.CardMainDecks", "CardMainDeck1_Id", "dbo.Card");
            DropForeignKey("dbo.CardExtraDecks", "DeckExtraDeck_IdDeck", "dbo.Deck");
            DropForeignKey("dbo.Deck", "Player_IdPlayer", "dbo.Player");
            DropForeignKey("dbo.CardExtraDecks", "CardExtraDeck1_Id", "dbo.Card");
            DropIndex("dbo.CardSideDecks", new[] { "DeckSideDeck_IdDeck" });
            DropIndex("dbo.CardSideDecks", new[] { "CardSideDeck1_Id" });
            DropIndex("dbo.CardMainDecks", new[] { "DeckMainDeck_IdDeck" });
            DropIndex("dbo.CardMainDecks", new[] { "CardMainDeck1_Id" });
            DropIndex("dbo.Deck", new[] { "Player_IdPlayer" });
            DropIndex("dbo.CardExtraDecks", new[] { "DeckExtraDeck_IdDeck" });
            DropIndex("dbo.CardExtraDecks", new[] { "CardExtraDeck1_Id" });
            DropTable("dbo.CardSideDecks");
            DropTable("dbo.CardMainDecks");
            DropTable("dbo.Player");
            DropTable("dbo.Deck");
            DropTable("dbo.CardExtraDecks");
            DropTable("dbo.Card");
        }
    }
}
