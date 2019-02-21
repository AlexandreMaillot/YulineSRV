using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using YulineServer;
using YulineServer.Class;

namespace YulineServer.Controllers
{
    public class CardMainDecksController : ApiController
    {
        private Yuline db = new Yuline();

        // GET: api/CardMainDecks
        public IQueryable<CardMainDeck> GetCardMainDeck()
        {
            return db.CardMainDeck;
        }

        // GET: api/CardMainDecks/5
        [ResponseType(typeof(CardMainDeck))]
        public async Task<IHttpActionResult> GetCardMainDeck(int id)
        {
            CardMainDeck cardMainDeck = await db.CardMainDeck.FindAsync(id);
            if (cardMainDeck == null)
            {
                return NotFound();
            }

            return Ok(cardMainDeck);
        }

        // PUT: api/CardMainDecks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCardMainDeck(int id, CardMainDeck cardMainDeck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cardMainDeck.IdMainDeck)
            {
                return BadRequest();
            }

            db.Entry(cardMainDeck).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardMainDeckExists(id))
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

        // POST: api/CardMainDecks
        [ResponseType(typeof(CardMainDeck))]
        public async Task<IHttpActionResult> PostCardMainDeck(CardMainDeck cardMainDeck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CardMainDeck.Add(cardMainDeck);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cardMainDeck.IdMainDeck }, cardMainDeck);
        }

        // DELETE: api/CardMainDecks/5
        [ResponseType(typeof(CardMainDeck))]
        public async Task<IHttpActionResult> DeleteCardMainDeck(int id)
        {
            CardMainDeck cardMainDeck = await db.CardMainDeck.FindAsync(id);
            if (cardMainDeck == null)
            {
                return NotFound();
            }

            db.CardMainDeck.Remove(cardMainDeck);
            await db.SaveChangesAsync();

            return Ok(cardMainDeck);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CardMainDeckExists(int id)
        {
            return db.CardMainDeck.Count(e => e.IdMainDeck == id) > 0;
        }
    }
}