using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using YulineServer;
using YulineServer.Class;

namespace YulineServer.Controllers
{
    public class DecksController : ApiController
    {
        private Yuline db = new Yuline();

        // GET: api/Decks
        public IQueryable<Deck> GetDeck()
        {
            return db.Deck;
        }

        // GET: api/Decks/5
        [ResponseType(typeof(Deck))]
        public IHttpActionResult GetDeck(int id)
        {
            Deck deck = db.Deck.Find(id);
            if (deck == null)
            {
                return NotFound();
            }

            return Ok(deck);
        }

        // PUT: api/Decks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeck(int id, Deck deck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deck.IdDeck)
            {
                return BadRequest();
            }

            db.Entry(deck).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeckExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Decks
        [ResponseType(typeof(Deck))]
        public IHttpActionResult PostDeck(Deck deck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Deck.Add(deck);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = deck.IdDeck }, deck);
        }

        // DELETE: api/Decks/5
        [ResponseType(typeof(Deck))]
        public IHttpActionResult DeleteDeck(int id)
        {
            Deck deck = db.Deck.Find(id);
            if (deck == null)
            {
                return NotFound();
            }

            db.Deck.Remove(deck);
            db.SaveChanges();

            return Ok(deck);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeckExists(int id)
        {
            return db.Deck.Count(e => e.IdDeck == id) > 0;
        }
    }
}