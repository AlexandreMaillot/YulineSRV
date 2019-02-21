using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YulineServer.Class
{
    [Table("Player")]
    public class Player
    {

        private int _idPlayer;
        [Required]
        private string _pseudo;
        [Required]
        private string _email;
        [Required]
        private string _password;
        [InverseProperty("Deck")]
        public ICollection<Deck> _deckList;

        public Player()
        {
        }

        public Player(int idPlayer, string pseudo, string email, string password, ICollection<Deck> deckList)
        {
            _idPlayer = idPlayer;
            _pseudo = pseudo;
            _email = email;
            _password = password;
            _deckList = deckList;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPlayer
        {
            get => _idPlayer;
            set => _idPlayer = value;
        }

        public string Pseudo
        {
            get => _pseudo;
            set => _pseudo = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public ICollection<Deck> DeckList
        {
            get => _deckList;
            set => _deckList = value;
        }
    }
}