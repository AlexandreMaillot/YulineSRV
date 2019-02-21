using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YulineServer.Class
{
    public class CardSideDeck
    {
        private int idSideDeck;
        [Required]
        private Card cardSideDeck;
        [Required]
        private Deck deckSideDeck;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSideDeck
        {
            get => idSideDeck;
            set => idSideDeck = value;
        }

        public CardSideDeck(Card cardSideDeck, Deck deckSideDeck)
        {
            this.cardSideDeck = cardSideDeck;
            this.deckSideDeck = deckSideDeck;
        }


        public Card CardSideDeck1
        {
            get => cardSideDeck;
            set => cardSideDeck = value;
        }

        public Deck DeckSideDeck
        {
            get => deckSideDeck;
            set => deckSideDeck = value;
        }
    }
}