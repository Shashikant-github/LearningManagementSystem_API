using CoursesAPI.Context;
using CoursesAPI.Models;
using System;
using System.Linq;

namespace CoursesAPI.Repository.CommandRepository
{
    public class CoursesCommandRepository : ICoursesCommandRepository
    {

        readonly CoursesDbContext courseDbContext;
        public CoursesCommandRepository(CoursesDbContext _courseDbContext)
        {
            courseDbContext = _courseDbContext;
        }
        public int AddCourse(CoursesModel course)
        {
            #region None
            //var airlineContextList = airlineDbContext.Airlines.AsQueryable();
            //if (airlineContextList.Count() != 0)
            //{
            //    airline.AirlineId = airlineContextList.Max(a => a.AirlineId) + 1;
            //}
            //else
            //{
            //    airline.AirlineId = 101;
            //}
            #endregion
            course.CourseCode = Guid.NewGuid().ToString("N").Substring(1, 5).ToUpper();
            course.CourseName = course.CourseName.ToUpper();
            course.CourseLaunchURL = course.CourseLaunchURL.ToLower();
            course.IsActive = true;

            courseDbContext.Courses.Add(course);
            return courseDbContext.SaveChanges();
        }

        public int DeleteCourse(string courseCode)
        {
            var courseDelete = courseDbContext.Courses.FirstOrDefault(c => c.CourseCode == courseCode.ToUpper());
            if (courseDelete != null)
            {
                courseDbContext.Courses.Remove(courseDelete);
                return courseDbContext.SaveChanges();
            }
            else return 0;
        }

        //public int deleteairline(coursesmodel airline)
        //{
        //    var airlinedelete = airlinedbcontext.airlines.firstordefault(a => a.airlinecode.equals(airline.airlinecode));
        //    if (airlinedelete != null)
        //    {
        //        airlinedelete.delete = true;
        //        return airlinedbcontext.savechanges();
        //    }
        //    else return 0;
        //}

        //public list<coursesmodel> getallairlines()
        //{
        //    return airlinedbcontext.airlines.tolist();
        //}
        //public coursesmodel getairlinebyname(string airlinename) //getairlinebycode
        //{
        //    return airlinedbcontext.airlines.where(a => a.airlinecode == airlinename).firstordefault();
        //}

        //public bool bulkaddairlines(list<coursesmodel> airlines)
        //{
        //    iqueryable<coursesmodel> airlinecontextlist = airlinedbcontext.airlines.asqueryable();
        //    foreach (var item in airlines)
        //    {
        //        #region customprimarykey
        //        //if (airlinecontextlist.count() != 0)
        //        //{
        //        //    item.airlineid = airlinecontextlist.max(a => a.airlineid) + 1;
        //        //}
        //        //else
        //        //{
        //        //    item.airlineid = 101;
        //        //}
        //        #endregion
        //        airlinedbcontext.airlines.add(item);
        //        airlinedbcontext.savechanges();
        //    }
        //    return true;
        //}

        //public bool updateairlinestatus(string airlinename, coursesmodel _airline)
        //{
        //    var airline = airlinedbcontext.airlines.firstordefault(a => a.airlinecode.equals(airlinename.toupper()));

        //    #region update properties
        //    //airline.airlinename = _airline.airlinename;
        //    //airline.airlineid = _airline.airlineid;

        //    // airline.airlineticketprice = _airline.airlineticketprice;
        //    // airline.airlinecategory = _airline.airlinecategory;
        //    #endregion

        //    if (airline != null)
        //    {
        //        airline.status = _airline.status;
        //        airlinedbcontext.savechanges();

        //        return true;
        //    }

        //    else return false;

        //}

        //public bool blockairline(string airlinename)
        //{
        //    coursesmodel airline = airlinedbcontext.airlines.firstordefault(a => a.airlinecode.equals(airlinename));
        //    if (airline != null)
        //    {
        //        if (airline.status == "active")
        //        {
        //            airline.status = "inactive";
        //            airlinedbcontext.savechanges();
        //            return true;
        //        }
        //        else
        //        {
        //            airline.status = "active";
        //            airlinedbcontext.savechanges();
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public list<coursesmodel> getairlinesbysearch(string source, string destination)
        //{
        //       return airlinedbcontext.airlines.where(a => a.source == source.toupper() && a.destination==destination.toupper()).tolist();

        //}
    }
}
