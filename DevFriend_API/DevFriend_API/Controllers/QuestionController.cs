using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using DevFriend_API.dtos;
using DevFriend_API.Entities;
using DevFriend_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFriend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IMapper _mapper;
        private IQuestionRepository _questionRepository;
        private IUnitOfWork _unitOfWork;
        private ITagRepository _tagRepository;
        private IAnswerRepository _answerRepository;
        private IUserRepository _userRepository;
        public QuestionController
            (IMapper mapper, IQuestionRepository questionRepository, IUnitOfWork unitOfWork, ITagRepository tagRepository, 
            IAnswerRepository answerRepository, IUserRepository userRepository)
        {   
            _mapper = mapper;
            _questionRepository = questionRepository;
            _unitOfWork = unitOfWork;
            _tagRepository = tagRepository;
            _answerRepository = answerRepository;
            _userRepository = userRepository;

        }

        [HttpPost]
        public async Task<IActionResult> Question(AddQuestionDto addQuestionDto)
        {
            try
            {

                var question = _mapper.Map<Question>(addQuestionDto);
                question.Id = new Guid();
                question.CreatedDate = DateTime.Now;
                _questionRepository.Add(question);
                var status = await _unitOfWork.Commit();
                if (status)
                {
                    var questionToReturn = _mapper.Map<AddQuestionDto>(question);
                    return Ok(questionToReturn);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("tags")]
        public async Task<IActionResult> GetAllTag()
        {
            try
            {
                var list = await _tagRepository.GetAll();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("questions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            try
            {
                var list = (await _questionRepository.GetAll()).OrderByDescending(m => m.CreatedDate);
                var listDto = _mapper.Map<IEnumerable<QuestionListDto>>(list);
                return Ok(listDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("questions/{id}")]
        public async Task<IActionResult> GetQuestionById(string id)
        {
            try
            {
                var qid = new Guid(id);
                var question = await _questionRepository.GetById(qid);
                var questionDto = _mapper.Map<QuestionDetailDto>(question);
                return Ok(questionDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("questions/{id}/postanswer")]
        public async Task<IActionResult> Answer(string id, AnswerPostDto answerPostDto)
        {
            try
            {
                var answer = _mapper.Map<Answer>(answerPostDto);
                answer.UserId = new Guid(id);
                _answerRepository.Add(answer);
                if (await _unitOfWork.Commit())
                    return Ok();
                return BadRequest();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet("questions/{id}/answer")]
        public async Task<IActionResult> GetAnswerByQuestionId(string id)
        {
            try
            {
                var qid = new Guid(id);
                var ansList = await _answerRepository.GetAnswersByQuestionId(qid);

                var answerListDto = _mapper.Map<List<AnswerListDto>>(ansList);
                //answerListDto.ToList().ForEach(m => m.Username =
                //(await _userRepository.GetById(new Guid(m.UserId.ToString()))).Username
                //);
                //var a =await _userRepository.GetById(qid).;

                return Ok(answerListDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //[HttpPost("login")]
        //public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        //{
        //    var userFromRepo = await _authService.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);
        //    if (userFromRepo == null)
        //        return Unauthorized();

        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
        //        new Claim(ClaimTypes.Name,userFromRepo.Username)
        //    };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.Now.AddDays(1),
        //        SigningCredentials = creds
        //    };
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var token = tokenHandler.CreateToken(tokenDescriptor);

        //    var user = _mapper.Map<UserForListDto>(userFromRepo);

        //    return Ok(new
        //    {
        //        token = tokenHandler.WriteToken(token),
        //        user
        //    });
        //}
        [HttpPost("test")]
        public async Task<IActionResult> Test()
        {
            try
            {
                List<Tag> list = new List<Tag>();

                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Programming" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "OOP" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Java" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "C++" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "C#" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "RUBY" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Pascal" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = ".Net" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Networking" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "IOT" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Raspberry PI" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Python" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Arduino" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Networking" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "TCP/IP" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "MS-SQL" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Mongo DB" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Oracle Database" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "MySQL" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "PHP" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "CSS" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "JavaScript" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Angular" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "React" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Node.js" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "IOS" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Andriod" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Kotlin" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Swift" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Mobile development" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Web development" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Machine Learning" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Artificial Inteligence" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Cloud Computing" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Azure" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "AWS" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Firebase" });
                _tagRepository.Add(new Tag() { Id = new Guid(), Name = "Data-Structures and Algorithms" });
                var s = await _unitOfWork.Commit();
                if (s)
                    return Ok(new { duan = "its working" });
                return BadRequest();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}