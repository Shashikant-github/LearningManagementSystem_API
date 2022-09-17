using CoursesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesAPI.Services.QueryServices
{
    public interface ICoursesQueryService
    {
        List<CoursesModel> GetAllCourses();
        List<CoursesModel> GetCoursesInfo(string technology);
        List<CoursesModel> GetCoursesForDuration(string technology, DateTime durationFromRange, DateTime durationToRange);
    }
}
