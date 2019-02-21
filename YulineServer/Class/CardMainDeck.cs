using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YulineServer.Class
{
    public class CardMainDeck
    {
        private int idMainDeck;
        [Required]
        private Card cardMainDeck;
        [Required]
        private Deck deckMainDeck;

        public CardMainDeck(Card cardMainDeck, Deck deckMainDeck)
        {
            this.cardMainDeck = cardMainDeck;
            this.deckMainDeck = deckMainDeck;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMainDeck
        {
            get => idMainDeck;
            set => idMainDeck = value;
        }

        public Card CardMainDeck1
        {
            get => cardMainDeck;
            set => cardMainDeck = value;
        }

        public Deck DeckMainDeck
        {
            get => deckMainDeck;
            set => deckMainDeck = value;
        }
    }
}