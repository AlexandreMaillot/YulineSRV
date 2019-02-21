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
    public class CardSideDecksController : ApiController
    {
        private Yuline db = new Yuline();

        // GET: api/CardSideDecks
        public IQueryable<CardSideDeck> GetCardSideDeck()
        {
            return db.CardSideDeck;
        }

        // GET: api/CardSideDecks/5
        [ResponseType(typeof(CardSideDeck))]
        public async Task<IHttpActionResult> GetCardSideDeck(int id)
        {
            CardSideDeck cardSideDeck = await db.CardSideDeck.FindAsync(id);
            if (cardSideDeck == null)
            {
                return NotFound();
            }

            return Ok(cardSideDeck);
        }

        // PUT: api/CardSideDecks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCardSideDeck(int id, CardSideDeck cardSideDeck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cardSideDeck.IdSideDeck)
            {
                return BadRequest();
            }

            db.Entry(cardSideDeck).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardSideDeckExists(id))
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

        // POST: api/CardSideDecks
        [ResponseType(typeof(CardSideDeck))]
        public async Task<IHttpActionResult> PostCardSideDeck(CardSideDeck cardSideDeck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CardSideDeck.Add(cardSideDeck);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cardSideDeck.IdSideDeck }, cardSideDeck);
        }

        // DELETE: api/CardSideDecks/5
        [ResponseType(typeof(CardSideDeck))]
        public async Task<IHttpActionResult> DeleteCardSideDeck(int id)
        {
            CardSideDeck cardSideDeck = await db.CardSideDeck.FindAsync(id);
            if (cardSideDeck == null)
            {
                return NotFound();
            }

            db.CardSideDeck.Remove(cardSideDeck);
            await db.SaveChangesAsync();

            return Ok(cardSideDeck);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CardSideDeckExists(int id)
        {
            return db.CardSideDeck.Count(e => e.IdSideDeck == id) > 0;
        }
    }
}