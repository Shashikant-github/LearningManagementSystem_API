using CoursesAPI.Models;
using System.Collections.Generic;

namespace CoursesAPI.Repository.CommandRepository
{
    public interface ICoursesCommandRepository
    {
        int AddCourse(CoursesModel airline);
        int DeleteCourse(string courseCode);
        //list<coursesmodel> getallairlines();
        //int deleteairline(coursesmodel airline);
        //coursesmodel getairlinebyname(string airlinename);
        //bool bulkaddairlines(list<coursesmodel> airlines);
        //bool updateairlinestatus(string airlinename, coursesmodel airline);
        //bool blockairline(string airlinename);
        //list<coursesmodel> getairlinesbysearch(string source, string destination);
    }
}
