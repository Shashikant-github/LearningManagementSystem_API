using CoursesAPI.Models;
using CoursesAPI.Services.CommandServices;
using CoursesAPI.Services.QueryServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AirlineAPI.Controllers
{
    //[Authorize]
    [Route("/api/v1.0/lms/[controller]/")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        readonly ICoursesCommandService courseCommandService;
        readonly ICoursesQueryService courseQueryService;
        public CoursesController(ICoursesCommandService _courseCommandService, ICoursesQueryService _courseQueryService)
        {
            courseCommandService = _courseCommandService;
            courseQueryService = _courseQueryService;
    }
        //[Authorize]
        [HttpPost]
        [Route("AddCourse")]
        public ActionResult AddAirline([FromBody] CoursesModel course)
        {
            bool courseAddStatus = courseCommandService.AddCourse(course);
            return Created("Course Added", courseAddStatus);
        }
        
        [HttpGet]
        [Route("GetAllCourses")]
        public ActionResult GetAllCourses()
        {
            List<CoursesModel> courses = courseQueryService.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet]
        [Route("Info/{technology}")]
        public ActionResult GetCoursesInfo(string technology)
        {
            List<CoursesModel> courses = courseQueryService.GetCoursesInfo(technology);
            return Ok(courses);
        }

        [HttpGet]
        [Route("GetCourses/{technology}/{durationFromRange}/{durationToRange}")]
        public ActionResult GetCoursesForDuration(string technology, DateTime durationFromRange, DateTime durationToRange)
        {
            List<CoursesModel> courses = courseQueryService.GetCoursesForDuration(technology, durationFromRange, durationToRange);
            return Ok(courses);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
        [Route("DeleteCourse/{courseCode}")]
        public ActionResult DeleteAirline(string courseCode)
        {
            bool deleteCourseStatus = courseCommandService.DeleteCourse(courseCode);
            return Ok(deleteCourseStatus);
        }
    }
}
