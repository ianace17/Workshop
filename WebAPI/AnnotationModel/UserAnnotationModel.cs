using System.ComponentModel.DataAnnotations;
using WorkShop.Library.Model;

namespace WebAPI.AnnotationModel
{
    public class UserAnnotationModel
    {
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Firstname { get; set; }
        public string Middlename { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [RegularExpression(@"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}]+)*@((([\-\w]+\.)+[a-zA-Z]{2,20})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$")]
        public string Email { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        [StringLength(1)]
        public string Gender { get; set; }
        [Required]
        public string Password { get; set; }

        public static implicit operator UserModel(UserAnnotationModel model)
        {
            var result = new UserModel();
            try
            {
                result.Lastname = model.Lastname;
                result.Firstname = model.Firstname;
                result.Middlename = model.Middlename;
                result.Email = model.Email;
                result.Birthdate = model.Birthdate;
                result.Gender = Convert.ToChar(model.Gender);
                result.Password = model.Password;
                result.Status = 1;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
