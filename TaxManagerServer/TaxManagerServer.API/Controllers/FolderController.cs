using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaxManager.Core.Models;
using TaxManager.Core.Models.TaxManager.Core.Models;
using TaxManager.Core.Services;

namespace TaxManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IFolderService _folderService;

        public FolderController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        // GET: api/<FolderController>
        [HttpGet]
        public ActionResult<IEnumerable<Folder>> Get()
        {
            var folders = _folderService.GetAll();
            return Ok(folders);
        }

        // GET api/<FolderController>/5
        [HttpGet("{id}")]
        public ActionResult<Folder> Get(int id)
        {
            var folder = _folderService.GetById(id);
            if (folder == null)
            {
                return NotFound();
            }
            return Ok(folder);
        }

        // POST api/<FolderController>
        [HttpPost]
        public ActionResult Post([FromBody] Folder folder)
        {
            if (folder == null)
            {
                return BadRequest("Folder cannot be null.");
            }
            _folderService.Add(folder);
            return CreatedAtAction(nameof(Get), new { id = folder.FolderId }, folder);
        }

        // PUT api/<FolderController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Folder folder)
        {
            if (folder == null || folder.FolderId != id)
            {
                return BadRequest("Invalid folder data.");
            }
            var existingFolder = _folderService.GetById(id);
            if (existingFolder == null)
            {
                return NotFound();
            }
            _folderService.Update(folder);
            return NoContent();
        }

        // DELETE api/<FolderController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingFolder = _folderService.GetById(id);
            if (existingFolder == null)
            {
                return NotFound();
            }
            _folderService.Delete(id);
            return NoContent();
        }
    }
}
