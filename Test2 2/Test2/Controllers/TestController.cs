using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.Models;

namespace Test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly TestDbContext _context;

        public TestController(TestDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/getInspections")]
        public async Task<IActionResult> GetInspectionList(int IdInspection)
        {
            var checkInspection = await _context.Inspections.FirstOrDefaultAsync(i => i.IdInspection == IdInspection);
            if(checkInspection == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Inspection with given Id {IdInspection} not found");
            }

            var result = await _context.ServiseTypeDict_Inspections.Where(x => x.IdInspection == IdInspection)
                .Select(x => new
                {
                    CarName = x.Inspection.Car.Name,
                    YearOfProduction = x.Inspection.Car.ProductionYear,
                    MechanicName = x.Inspection.Mechanic.FirstName + " " + x.Inspection.Mechanic.LastName,
                    Services = x.ServiceTypeDict.ServiceType
                }).ToListAsync();

            return Ok(result);
        }

        [HttpPut]
        [Route("changeCar")]
        public async Task<IActionResult> ChangeCar(int IdCar, int IdServiceType)
        {
            var CheckCar = await _context.Cars.FirstOrDefaultAsync(x => x.IdCar == IdCar);
            if(CheckCar == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Car with given Id {IdCar} not found");
            }

            var checkAssigned = await _context.ServiseTypeDict_Inspections.FirstOrDefaultAsync(x => x.Inspection.IdCar == IdCar && x.IdServiceType == IdServiceType);
            if(checkAssigned != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Car with Id {IdCar} has already been assingned to the service type {IdServiceType}");
            }

            var CheckDate = await _context.Inspections.Where(x => x.IdCar == IdCar).Select(x => x.InspectionDate).FirstOrDefaultAsync();
            if(CheckDate < DateTime.Now)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"The Date Of Inspection Has Already Passed");
            }

            var result =await _context.ServiseTypeDict_Inspections.Where(x => x.IdServiceType == IdServiceType).FirstOrDefaultAsync();

            result.Inspection.IdCar = IdCar;

            await _context.SaveChangesAsync();

            return Ok($"Service with Id {IdServiceType} has been updated to Car {IdCar}");

        }
    }
}
