using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CoursesAPI.Models
{
    public class CoursesModel
    {
        #region Properties
        [JsonIgnore]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Technology { get; set; }
        public string CourseDuration{ get; set; }
        public string CourseDescription { get; set; }
        public bool IsActive { get; set; }
        public string CourseLaunchURL { get; set; }
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }
        #endregion

        //public AirlineModel()
        //{
        //    this.Delete = false;
        //}
        //public override string ToString()
        //{
        //    return string.Format($"{AirlineId}\t{AirlineName}\t{AirlineTicketPrice}");
        //}
    }
}
