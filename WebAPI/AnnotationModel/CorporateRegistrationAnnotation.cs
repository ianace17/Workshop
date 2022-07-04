using System.ComponentModel.DataAnnotations;
using WorkShop.Library.Model;

namespace WebAPI.AnnotationModel
{
    public class CorporateRegistrationAnnotation : RegistrationAnnotation
    {
        [Required]
        public CorporateAnnotationModel CorporateDetails { get; set; } = new();

        public static implicit operator CorporateRegistrationModel(CorporateRegistrationAnnotation model)
        {
            var result = new CorporateRegistrationModel();
            try
            {
                result.AccountDetails = model.AccountDetails;
                foreach (var item in model.Users)
                {
                    result.Users.Add(item);
                }
                foreach (var item in model.Addresses)
                {
                    result.Addresses.Add(item);
                }
                foreach (var item in model.Banks)
                {
                    result.Banks.Add(item);
                }
                result.CorporateDetails = model.CorporateDetails;
            }
            catch (Exception)
            {

                throw;
            }
            return result;  
        }
    }
}
