using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YulineServer.Class
{

    [Table("Card ")]
    public class Card
    {
        [Key]
        string id; // - ID or Passocde of the card.
        [Required]
        string name;// Name of the card.
        [Required]
        string desc;// Card description/effect.
        
        int? atk;// The ATK value of the card.
        
        int? def;//The DEF value of the card.
        [Required]
        string type;// The type of card you are viewing (Normal Monster, Spell Card, Trap Card, etc)
        [Required]
        int level;// The Level/RANK of the card.
        [Required]
        string race;//The card race which is officially called type (Spellcaster, Warrior, Insect, etc)
        [Required]
        string attribute;// The attribute of the card.
        
        int? scale;//The Pendulum Scale Value (only Pendulum monsters will have a scale value, otherwise NULL).
        
        int? linkval;// The Link Value of the card if it's of type "Link Monster".
        
        int? linkmarkers;//The Link Markers of the card if it's of type "Link Monster".
        
        string archetype;// The Archetype that the card belongs to. We take feedback on Archetypes here.
        [Required]
        string setcode;//Every Card Set this card belongs to.
        
        string ban_tcg;// status of the card on the TCG Ban List.
        
        string ban_ocg;//The status of the card on the OCG Ban List.
        
        string ban_goat;//The status of the card on the GOAT Format Ban List.

        public Card(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Card()
        {
        }

        public Card(string id, string name, string desc, int atk, int def, string type, int level, string race, string attribute, int scale, int linkval, int linkmarkers, string archetype, string setcode, string banTcg, string banOcg, string banGoat)
        {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.atk = atk;
            this.def = def;
            this.type = type;
            this.level = level;
            this.race = race;
            this.attribute = attribute;
            this.scale = scale;
            this.linkval = linkval;
            this.linkmarkers = linkmarkers;
            this.archetype = archetype;
            this.setcode = setcode;
            this.ban_tcg = banTcg;
            this.ban_ocg = banOcg;
            this.ban_goat = banGoat;
        }



        public string Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Desc
        {
            get => desc;
            set => desc = value;
        }

        public int? Atk
        {
            get => atk;
            set => atk = value;
        }

        public int? Def
        {
            get => def;
            set => def = value;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }

        public int Level
        {
            get => level;
            set => level = value;
        }

        public string Race
        {
            get => race;
            set => race = value;
        }

        public string Attribute
        {
            get => attribute;
            set => attribute = value;
        }

        public int? Scale
        {
            get => scale;
            set => scale = value;
        }

        public int? Linkval
        {
            get => linkval;
            set => linkval = value;
        }

        public int? Linkmarkers
        {
            get => linkmarkers;
            set => linkmarkers = value;
        }

        public string Archetype
        {
            get => archetype;
            set => archetype = value;
        }

        public string Setcode
        {
            get => setcode;
            set => setcode = value;
        }

        public string BanTcg
        {
            get => ban_tcg;
            set => ban_tcg = value;
        }

        public string BanOcg
        {
            get => ban_ocg;
            set => ban_ocg = value;
        }

        public string BanGoat
        {
            get => ban_goat;
            set => ban_goat = value;
        }
    }
}