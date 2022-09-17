using CoursesAPI.Models;

namespace CoursesAPI.Services.CommandServices
{
    public interface ICoursesCommandService
    {
        bool AddCourse(CoursesModel course);
        bool DeleteCourse(string courseCode);
        //List<CoursesModel> GetAllAirlines();
        //bool DeleteAirline(string airlineName);
        //bool BulkAddAirlines(List<CoursesModel> airlines);
        //CoursesModel GetAirlineByName(string airlineName);
        //bool UpdateAirlineStatus(string airlineName, CoursesModel airline);
        //List<CoursesModel> GetAllAirlinesAdm();
        //bool BlockAirline(string airlineName);
        //List<CoursesModel> getAirlinesBySearch(string source, string destination);
    }
}
