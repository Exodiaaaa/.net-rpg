using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.CharacterService
{
    public class CharactereService : ICharacterService
    {
        private static List<Character> characters = new List<Character>(){
            new Character(),
            new Character{Id=1, Name = "Ashe"}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharactereService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var newCharacter = _mapper.Map<Character>(character);
            newCharacter.Id = characters.Max(character => character.Id) + 1;
            characters.Add(newCharacter);
            serviceResponse.Data = characters.Select(c=>_mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto character)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();

            try{

            var characterToUpdate = characters.FirstOrDefault(c => c.Id == character.Id);
            if(characterToUpdate is null)
            {
                throw new Exception($"Character with Id {character.Id} Not Found");
            }

            characterToUpdate.Name = character.Name;
            characterToUpdate.HitPoint = character.HitPoint;
            characterToUpdate.Strenght = character.Strenght;
            characterToUpdate.Defense = character.Defense;
            characterToUpdate.Intelligence = character.Intelligence;
            characterToUpdate.Class = character.Class;

            serviceResponse.Data = _mapper.Map<GetCharacterDto>(characterToUpdate);
            }catch(Exception e){
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id){
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try{
                var characterToDelete = characters.FirstOrDefault(c => c.Id == id);
                if(characterToDelete is null){
                    throw new Exception($"Character with Id {id} Not Found");
                }

                characters.Remove(characterToDelete);
                serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();   
                
            }catch(Exception e){
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }
    }
}