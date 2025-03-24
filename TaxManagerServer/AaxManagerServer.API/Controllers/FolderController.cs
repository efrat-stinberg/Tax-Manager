using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxManager.Core.Models;
using TaxManager.Core.Models.TaxManager.Core.Models;
using TaxManager.Core.Services;
using TaxManagerServer.API.Models;
using TaxManagerServer.Core.DTOs;

namespace TaxManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FolderController : ControllerBase
    {
        private readonly IFolderService _folderService;
        private readonly IMapper _mapper;

        public FolderController(IFolderService folderService, IMapper mapper)
        {
            _folderService = folderService;
            _mapper = mapper;
        }

        // GET: api/<FolderController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FolderDTO>>> Get()
        {
            var folders = await _folderService.GetAllAsync(); // Assuming this returns a list of Folder
            var foldersDto = _mapper.Map<IEnumerable<FolderDTO>>(folders); // Map to FolderDTO
            return Ok(foldersDto);
        }


        // GET api/<FolderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Folder>> Get(int id)
        {
            var folder = await _folderService.GetByIdAsync(id); // Use async method
            if (folder == null)
            {
                return NotFound();
            }
            var folderDto = _mapper.Map<UserDTO>(folder);
            return Ok(folderDto);
        }

        // POST api/<FolderController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FolderPostModel folder)
        {
            if (folder == null)
            {
                return BadRequest("Folder cannot be null.");
            }

            var folderToAdd = new Folder { FolderName = folder.FolderName };

            await _folderService.AddAsync(folderToAdd); // Use async method
            return CreatedAtAction(nameof(Get), new { id = folderToAdd.FolderId }, folder);
        }

        // PUT api/<FolderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] FolderPostModel folder)
        {
            if (folder == null)
            {
                return BadRequest("Invalid folder data.");
            }
            var existingFolder = await _folderService.GetByIdAsync(id); // Use async method
            if (existingFolder == null)
            {
                return NotFound();
            }

            var folderToUpdate = new Folder { FolderId = id, FolderName = folder.FolderName }; // Set FolderId for update
            await _folderService.UpdateAsync(folderToUpdate); // Use async method
            return NoContent();
        }

        // DELETE api/<FolderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingFolder = await _folderService.GetByIdAsync(id); // Use async method
            if (existingFolder == null)
            {
                return NotFound();
            }
            await _folderService.DeleteAsync(id); // Use async method
            return NoContent();
        }
    }
}
