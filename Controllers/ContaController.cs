using CarteiraDigitalAPI.Dtos.Conta;
using CarteiraDigitalAPI.Services.ContaService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDigitalAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly IContaService _contaService;
        public CharacterController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetContaDto>>>> GetContas()
        {
            return Ok(await _contaService.GetAllContas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetContaDto>>> GetConta(int id)
        {
            return Ok(await _contaService.GetContaById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetContaDto>>>> AddConta(AddContaDto newConta)
        {
            return Ok(await _contaService.AddConta(newConta));
        }

        //[HttpPut]
        //public async Task<ActionResult<ServiceResponse<GetContaDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        //{
        //    var response = await _contaService.UpdateConta(updatedCharacter);
        //    if (response.Data == null)
        //    {
        //        return NotFound(response);
        //    }
        //    return Ok(response);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetContaDto>>>> Delete(int id)
        {
            var response = await _contaService.DeleteConta(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        //[HttpPost("Skill")]
        //public async Task<ActionResult<ServiceResponse<GetContaDto>>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        //{
        //    return Ok(await _contaService.AddConta(newCharacterSkill));
        //}
    }
}
