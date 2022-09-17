using CoursesAPI.Context;
using CoursesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursesAPI.Repository.QueryRepository
{
    public class CoursesQueryRepository : ICoursesQueryRepository
    {
        readonly CoursesDbContext courseDbContext;
        public CoursesQueryRepository(CoursesDbContext _courseDbContext)
        {
            courseDbContext = _courseDbContext;
        }
        public List<CoursesModel> GetAllCourses()
        {
                return courseDbContext.Courses.ToList();
        }

        public List<CoursesModel> GetCoursesForDuration(string technology, DateTime durationFromRange, DateTime durationToRange)
        {
            var courses = courseDbContext.Courses.Where(c => c.Technology == technology && c.CourseStartDate==durationFromRange && c.CourseEndDate==durationToRange).ToList();
            return courses;
        }

        public List<CoursesModel> GetCoursesInfo(string technology)
        {
            var courses = courseDbContext.Courses.Where(c => c.Technology == technology).ToList();
            return courses;
        }
    }
}
