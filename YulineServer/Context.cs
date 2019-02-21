using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YulineServer.Class;

namespace YulineServer
{
    public class Yuline : DbContext
    {
        public Yuline() : base("YulineServer")
    {
    }
        public DbSet<Deck> Deck { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<CardExtraDeck> CardExtraDecks { get; set; }
        public DbSet<CardMainDeck> CardMainDeck { get; set; }
        public DbSet<CardSideDeck> CardSideDeck { get; set; }



    }
   
}