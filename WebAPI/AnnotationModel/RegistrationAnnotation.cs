using System.ComponentModel.DataAnnotations;
using WorkShop.Library.Model;

namespace WebAPI.AnnotationModel
{
    public class RegistrationAnnotation
    {
        [Required]
        public AccountAnnotationModel AccountDetails { get; set; }
        [Required]
        public List<UserAnnotationModel> Users { get; set; }
        [Required]
        public List<AddressAnnotationModel> Addresses { get; set; }
        [Required]
        public List<BankAnnotationModel> Banks { get; set; }

        public static implicit operator RegistrationModel(RegistrationAnnotation model)
        {
            var result = new RegistrationModel();
            try
            {
                result.AccountDetails = model.AccountDetails;
                foreach(var item in model.Users)
                {
                    result.Users.Add(item);
                }
                foreach(var item in model.Addresses)
                {
                    result.Addresses.Add(item);
                }
                foreach (var item in model.Banks)
                {
                    result.Banks.Add(item);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
