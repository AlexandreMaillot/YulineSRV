using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace YulineServer.Class
{
    [Table("Deck")]
    public class Deck
    {
        
        private int _idDeck;
        [Required]
        private string _name;
        [Required]
        private string _banList;
        [ForeignKey("Player")]
        public Player player;

        public int _mainDeck { get; set; }
        public int _sideDeck { get; set; }
        public int _extraDeck { get; set; }

        public Deck()
        {
        }

        public Deck(int idDeck, string name, string banList, int mainDeck, int sideDeck, int extraDeck)
        {
            _idDeck = idDeck;
            _name = name;
            _banList = banList;
            _mainDeck = mainDeck;
            _sideDeck = sideDeck;
            _extraDeck = extraDeck;
        }

        
        public Player Player
        {
            get => player;
            set => player = value;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDeck
        {
            get => _idDeck;
            set => _idDeck = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string BanList
        {
            get => _banList;
            set => _banList = value;
        }

       
    }
}