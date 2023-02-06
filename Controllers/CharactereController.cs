using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactereController : ControllerBase
    {
      
        private readonly ICharacterService _characterService;

        public CharactereController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get(){
            return Ok(await _characterService.GetCharacters());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int Id){
            return Ok(await _characterService.GetCharacterById(Id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto character){
            return Ok(await _characterService.AddCharacter(character));
        } 

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto character){
            var response = await _characterService.UpdateCharacter(character);
            if(response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
        } 
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter(int Id){
            var response = await _characterService.DeleteCharacter(Id);
            if(response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}