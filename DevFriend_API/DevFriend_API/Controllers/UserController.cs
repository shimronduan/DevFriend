using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DevFriend_API.dtos;
using DevFriend_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFriend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMapper _mapper;
        private IQuestionRepository _questionRepository;
        private IUnitOfWork _unitOfWork;
        private ITagRepository _tagRepository;
        private IUserRepository _userRepository;

        public UserController
            (IMapper mapper, IQuestionRepository questionRepository, IUnitOfWork unitOfWork, ITagRepository tagRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetAll();
            var usersDto = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(usersDto);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string id)
        {
            var uid =  new Guid(id);
            var user = await _userRepository.GetById(uid);
            var userDto = _mapper.Map<UserForDetailedDto>(user);
            return Ok(userDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserForUpdateDto userForUpdateDto)
        {
            if (id.ToString() != User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                return Unauthorized();
            }
            var userFromRepo = await _userRepository.GetById(id);
            _mapper.Map(userForUpdateDto, userFromRepo);

            if (await _unitOfWork.Commit())
            {
                return NoContent();
            }

            throw new Exception($"Updating user {id} failed on save");
        }
       
    }
}