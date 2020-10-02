using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Dto;
using Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IKalmyRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public CarController(IKalmyRepository eventRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<CarDto[]>> Get()
        {
            try
            {
                var results = await _eventRepository.GetCars();

                var mappedEntities = _mapper.Map<CarDto[]>(results);
                return Ok(mappedEntities);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{CarId}")]
        public async Task<ActionResult<CarDto>> Get(int CarId)
        {
            try
            {
                var result = await _eventRepository.GetCar(CarId);

                if (result == null) return NotFound();

                var mappedEntity = _mapper.Map<CarDto>(result);
                return Ok(mappedEntity);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        
    }
}
