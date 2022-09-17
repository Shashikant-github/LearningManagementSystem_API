using CoursesAPI.Models;
using CoursesAPI.Repository.CommandRepository;
using CoursesAPI.Services.CommandServices;

namespace AirlineAPI.Services
{
    public class CoursesCommandService : ICoursesCommandService
    {

        readonly ICoursesCommandRepository courseComandRepository;
        public CoursesCommandService(ICoursesCommandRepository _courseCommandRepository)
        {
            courseComandRepository = _courseCommandRepository;
        }
        public bool AddCourse(CoursesModel course)
        {
            var courseAddStatus = courseComandRepository.AddCourse(course);
            return courseAddStatus == 1;
            //if (courseAddStatus == 1)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public bool DeleteCourse(string courseCode)
        {

            var courseDeleted= courseComandRepository.DeleteCourse(courseCode);

            return courseDeleted == 1;
        }

        //public bool BlockAirline(string airlineName)
        //{
        //    CoursesModel airline = airlineRepository.GetAirlineByName(airlineName);
        //    if (airline != null)
        //    {
        //        bool airlineStatus = airlineRepository.BlockAirline(airlineName);
        //        return airlineStatus;
        //    }
        //    else
        //    {
        //        //throw new AirlineNotFoundException($"{airlineName} Airline Not Found");
        //        return false;
        //    }
        //}

        //public bool BulkAddAirlines(List<CoursesModel> airlines)
        //{
        //    return airlineRepository.BulkAddAirlines(airlines);
        //}

        //public bool DeleteAirline(string airlineName)
        //{
        //    CoursesModel airline = airlineRepository.GetAirlineByName(airlineName);
        //    if (airline != null)
        //    {
        //        airlineRepository.DeleteAirline(airline);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public CoursesModel GetAirlineByName(string airlineName)
        //{
        //    var airlineExist = airlineRepository.GetAirlineByName(airlineName);
        //    if (airlineExist != null)
        //    {
        //        return airlineExist;
        //    }
        //    else
        //    {
        //        //throw new AirlineNotFoundException($"{airlineName} Airline Not Found");
        //        return null;
        //    }

        //}

        //public List<CoursesModel> getAirlinesBySearch(string source, string destination)
        //{
        //    List<CoursesModel> airline = new List<CoursesModel>();
        //    List<CoursesModel> airlineResult = new List<CoursesModel>();

        //    airline = airlineRepository.getAirlinesBysearch(source,destination);
        //    if (airline != null)
        //    {
        //        foreach (CoursesModel item in airline)
        //        {
        //            if (!item.Delete && item.Status == "ACTIVE")
        //            {
        //                airlineResult.Add(item);
        //            }
        //            //else
        //            //{
        //            //    airlineResult.Add(null);
        //            //}
        //        }
        //        return airlineResult;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public List<CoursesModel> GetAllAirlines()
        //{
        //    List<CoursesModel> airline = new List<CoursesModel>();
        //    List<CoursesModel> airlineResult = new List<CoursesModel>();
        //    airline = airlineRepository.GetAllAirlines();
        //    if (airline != null)
        //    {
        //        foreach (CoursesModel item in airline)
        //        {
        //            if (!item.Delete && item.Status == "ACTIVE")
        //            {
        //                airlineResult.Add(item);
        //            }
        //            //else
        //            //{
        //            //    airlineResult.Add(null);
        //            //}
        //        }
        //        return airlineResult;
        //    }
        //    else
        //    {
        //        //throw new AirlineNotFoundException($"No Airline Found");
        //        return null;
        //    }
        //}

        //public List<CoursesModel> GetAllAirlinesAdm()
        //{
        //    List<CoursesModel> airlineRes = new List<CoursesModel>();
        //    airlineRes= airlineRepository.GetAllAirlines();

        //    if (airlineRes != null)
        //    {
        //        return airlineRes;
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}

        //public bool UpdateAirlineStatus(string airlineName, CoursesModel airline)
        //{
        //    var airlineResult = airlineRepository.GetAirlineByName(airlineName);
        //    //return airlineRepository.UpdateAirlineStatus(airlineName, airline);
        //    if (airlineResult != null)
        //    {
        //        return airlineRepository.UpdateAirlineStatus(airlineName, airline);
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
