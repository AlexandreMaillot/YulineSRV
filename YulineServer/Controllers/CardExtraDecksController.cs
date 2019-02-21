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
    public class CardExtraDecksController : ApiController
    {
        private Yuline db = new Yuline();

        // GET: api/CardExtraDecks
        public IQueryable<CardExtraDeck> GetCardExtraDecks()
        {
            return db.CardExtraDecks;
        }

        // GET: api/CardExtraDecks/5
        [ResponseType(typeof(CardExtraDeck))]
        public async Task<IHttpActionResult> GetCardExtraDeck(int id)
        {
            CardExtraDeck cardExtraDeck = await db.CardExtraDecks.FindAsync(id);
            if (cardExtraDeck == null)
            {
                return NotFound();
            }

            return Ok(cardExtraDeck);
        }

        // PUT: api/CardExtraDecks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCardExtraDeck(int id, CardExtraDeck cardExtraDeck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cardExtraDeck.IdExtraDeck)
            {
                return BadRequest();
            }

            db.Entry(cardExtraDeck).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExtraDeckExists(id))
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

        // POST: api/CardExtraDecks
        [ResponseType(typeof(CardExtraDeck))]
        public async Task<IHttpActionResult> PostCardExtraDeck(CardExtraDeck cardExtraDeck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CardExtraDecks.Add(cardExtraDeck);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cardExtraDeck.IdExtraDeck }, cardExtraDeck);
        }

        // DELETE: api/CardExtraDecks/5
        [ResponseType(typeof(CardExtraDeck))]
        public async Task<IHttpActionResult> DeleteCardExtraDeck(int id)
        {
            CardExtraDeck cardExtraDeck = await db.CardExtraDecks.FindAsync(id);
            if (cardExtraDeck == null)
            {
                return NotFound();
            }

            db.CardExtraDecks.Remove(cardExtraDeck);
            await db.SaveChangesAsync();

            return Ok(cardExtraDeck);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CardExtraDeckExists(int id)
        {
            return db.CardExtraDecks.Count(e => e.IdExtraDeck == id) > 0;
        }
    }
}