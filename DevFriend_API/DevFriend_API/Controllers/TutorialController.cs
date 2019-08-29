using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DevFriend_API.dtos.TutorialDtos;
using DevFriend_API.Entities;
using DevFriend_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFriend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialController : ControllerBase
    {
        private readonly ITutorialRepository _tutorialRepository;
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;

        public TutorialController(IMapper mapper, ITutorialRepository tutorialRepository, IUnitOfWork uow)
        {
            _mapper = mapper;
            _tutorialRepository = tutorialRepository;
            _uow = uow;
        }
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(UploadTutorialDto uploadTutorialDto)
        {
            try
            {
                var tutorial = _mapper.Map<Tutorial>(uploadTutorialDto);
                _tutorialRepository.Add(tutorial);
                if(await _uow.Commit())
                    return Ok();
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetAllTutorial()
        {
            try
            {
                var list = (await _tutorialRepository.GetAll());
                var listDto = _mapper.Map<IEnumerable<UploadTutorialDto>>(list);
                return Ok(listDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}