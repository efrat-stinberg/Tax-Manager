using Microsoft.AspNetCore.Mvc;
using TaxManager.Core.Models;
using TaxManager.Core.Services;
using TaxManager.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaxManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService; ;
        }

        // GET: api/<DocumentController>
        [HttpGet]
        public IEnumerable<Document> Get()
        {
            return _documentService.GetAll();
        }

        // GET api/<DocumentController>/5
        [HttpGet("{id}")]
        public ActionResult<Document> Get(int id)
        {
            var document = _documentService.GetById(id);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        // POST api/<DocumentController>
        [HttpPost]
        public IActionResult Post([FromBody] Document document)
        {
            if (document == null)
            {
                return BadRequest("Document is null.");
            }

            _documentService.Add(document);
            return CreatedAtAction(nameof(Get), new { id = document.DocumentId }, document);
        }

        // PUT api/<DocumentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Document document)
        {
            if (document == null || document.DocumentId != id)
            {
                return BadRequest("Document is null or ID mismatch.");
            }

            var existingDocument = _documentService.GetById(id);
            if (existingDocument == null)
            {
                return NotFound();
            }

            _documentService.Update(document);
            return NoContent();
        }

        // DELETE api/<DocumentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingDocument = _documentService.GetById(id);
            if (existingDocument == null)
            {
                return NotFound();
            }

            _documentService.Delete(id);
            return NoContent();
        }

    }
}
