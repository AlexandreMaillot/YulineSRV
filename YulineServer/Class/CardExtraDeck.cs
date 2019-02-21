using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YulineServer.Class
{
    public class CardExtraDeck
    {
        private int idExtraDeck;
        [Required]
        private Card cardExtraDeck;
        [Required]
        private Deck deckExtraDeck;

        public CardExtraDeck(Card cardExtraDeck, Deck deckExtraDeck)
        {
            this.cardExtraDeck = cardExtraDeck;
            this.deckExtraDeck = deckExtraDeck;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdExtraDeck
        {
            get => idExtraDeck;
            set => idExtraDeck = value;
        }

        public Card CardExtraDeck1
        {
            get => cardExtraDeck;
            set => cardExtraDeck = value;
        }

        public Deck DeckExtraDeck
        {
            get => deckExtraDeck;
            set => deckExtraDeck = value;
        }
    }
}