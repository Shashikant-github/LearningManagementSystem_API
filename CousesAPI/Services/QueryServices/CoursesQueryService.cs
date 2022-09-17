using CoursesAPI.Models;
using CoursesAPI.Repository.QueryRepository;
using System;
using System.Collections.Generic;

namespace CoursesAPI.Services.QueryServices
{
    public class CoursesQueryService : ICoursesQueryService
    {
        readonly ICoursesQueryRepository courseQueryRepository;
        public CoursesQueryService(ICoursesQueryRepository _courseQueryRepository)
        {
            courseQueryRepository = _courseQueryRepository;
        }
        public List<CoursesModel> GetAllCourses()
        {
            List<CoursesModel> courses = new List<CoursesModel>();
            courses = courseQueryRepository.GetAllCourses();

            return courses;
        }

        public List<CoursesModel> GetCoursesForDuration(string technology, DateTime durationFromRange, DateTime durationToRange)
        {
            List<CoursesModel> courses = courseQueryRepository.GetCoursesForDuration(technology, durationFromRange, durationToRange);
            return courses;
        }

        public List<CoursesModel> GetCoursesInfo(string technology)
        {
            List<CoursesModel> courses = courseQueryRepository.GetCoursesInfo(technology);
            return courses;
        }
    }
}
