using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BulkyBookWeb.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [DisplayName("Contact Number")] //We can use this for displaying other names, bcoz we can't use space between the Name words of an object.
    //[Range(1,100,ErrorMessage ="Custom message, like Contact No. must be of 10 letters OR value must be b/w 1 to 100")]
    public int ContactNumber { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now; //this will set the default date & time.

}

public class Category2
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Category3
{
    public int ContactNumber { get; set; }
}