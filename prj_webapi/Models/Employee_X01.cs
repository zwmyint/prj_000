using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace prj_webapi.Models
{
    public class Employee_X01{

        [Key]
        public int EmployeeID {get; set;}

        [Column(TypeName = "nvarchar(50)")]
        public string EmployeeName {get; set;}

        [Column(TypeName = "nvarchar(50)")]
        public string Occupation {get; set;}

        [Column(TypeName = "nvarchar(150)")]
        public string ImageName {get; set;}
        
        [NotMapped]
        public IFormFile ImageFile {get; set;}

        [NotMapped]
        public string ImageSrc {get; set;}

        //Pascal(EmployeeName) -> Camel
        //Camel(employeeName) -> Pascal
  
    }
    

    //
}

// controller without view and Generate a Controller with REST style API
/* dotnet aspnet-codegenerator controller -name Employee_X01Controller -m Employee_X01 -dc Employee_X01DbContext --relativeFolderPath Controllers --restWithNoViews --referenceScriptLibraries */