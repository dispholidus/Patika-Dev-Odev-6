using BookStoreApi.Models.Repositories;
using BookStoreApi.Models.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorModelValidator _authorModelValidator;
        public AuthorController(IAuthorRepository authorRepository, AuthorModelValidator authorModelValidator)
        {
            _authorRepository = authorRepository;
            _authorModelValidator = authorModelValidator;
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            IEnumerable<AuthorModel> authorModels = _authorRepository.GetAuthors();
            return Ok(authorModels);
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthorById(int authorId)
        {
            AuthorModel? authorModel = _authorRepository.GetAuthorById(authorId);
            try
            {
                if (authorModel != null)
                {
                    _authorModelValidator.ValidateAndThrow(authorModel);
                    return Ok(authorModel);
                }
                return NotFound("Verilen ID ile yazar bulunamadı!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorModel authorModel)
        {
            try
            {
                _authorModelValidator.ValidateAndThrow(authorModel);
                if (_authorRepository.AddAuthor(authorModel))
                {
                    return Ok();
                }
                return BadRequest("Verilen ID ile yazar bulunamadı!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{authorId}")]
        public IActionResult DeleteAuthor(int authorId)
        {
            if (_authorRepository.DeleteAuthorById(authorId))
            {
                return Ok();
            }
            return BadRequest("Verilen ID ile yazar bulunamadı veya yazarın sistemde kayıtlı kitabı var!");
        }
        [HttpPut("{authorId}")]
        public IActionResult UpdateAuthor(int authorId, [FromBody] AuthorModel authorModel)
        {
            try
            {
                _authorModelValidator.ValidateAndThrow(authorModel);
                if (_authorRepository.UpdateAuthorById(authorId, authorModel))
                {
                    return Ok();
                }
                return NotFound("Verilen ID ile yazar bulunamadı!");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
