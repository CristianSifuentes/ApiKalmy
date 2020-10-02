﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Dto;
using Api.Data.Entities;
using Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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


        [HttpPost]
        public async Task<ActionResult<CarDto>> Post(CarDto dto)
        {
            try
            {
                var mappedEntity = _mapper.Map<Car>(dto);
                _eventRepository.Add(mappedEntity);

                if (await _eventRepository.Save())
                {
                    var location = _linkGenerator.GetPathByAction("Get", "Car", new { mappedEntity.Id });
                    return Created(location, _mapper.Map<CarDto>(mappedEntity));
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }


        [HttpPut("{carId}")]
        public async Task<ActionResult<CarDto>> Put(long carId, CarDto dto)
        {
            try
            {
                var oldcar = await _eventRepository.GetCar(carId);
                if (oldcar == null) return NotFound($"Could not find car with id {carId}");

                var newcar = _mapper.Map(dto, oldcar);
                _eventRepository.Update(newcar);
                if (await _eventRepository.Save())
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
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
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{Id}")]
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

        [HttpDelete("{carId}")]
        public async Task<IActionResult> Delete(int carId)
        {
            try
            {
                var oldcar = await _eventRepository.GetCar(carId);
                if (oldcar == null) return NotFound($"Could not find car with id {carId}");

                _eventRepository.Delete(oldcar);
                if (await _eventRepository.Save())
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchByDate(string parameter1, string parameter2 = "")
        {
            try
            {
                var results = await _eventRepository.SearchByDate();

                //dynamic jsonObjectx = new JObject();
                //jsonObjectx.Date = DateTime.Now;
                //jsonObjectx.Album = "Me Against the world";

                //dynamic jsonObject = new JObject();
                //jsonObject.Date = DateTime.Now;
                //jsonObject.Album = "Me Against the world";
                //jsonObject.Year = 1995;
                //jsonObject.Artist = "2Pac";
                //jsonObject.Oher = jsonObjectx;

                return Content(JsonConvert.SerializeObject(results), "application/json");

                //var mappedEntities = _mapper.Map<CarDto[]>(results);
                //return Ok(mappedEntities);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


    }
}