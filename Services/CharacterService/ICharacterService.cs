using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto character);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);

    }
}