using System.ComponentModel.DataAnnotations;
using WorkShop.Library.Model;

namespace WebAPI.AnnotationModel
{
    public class CorporateAnnotationModel
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string SecRegistrationNumber { get; set; }
        [Required]
        public string Tin { get; set; }
        [Required]
        public string OfficeAddress { get; set; }
        [Required]
        public string BusinessNature { get; set; }
        [Required]
        public string TelNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [RegularExpression(@"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}]+)*@((([\-\w]+\.)+[a-zA-Z]{2,20})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$")]
        public string Email { get; set; }
        [Required]
        public int YearsInOperation { get; set; }
        public string FaxNo { get; set; }

        public static implicit operator CorporateModel(CorporateAnnotationModel model)
        {
            var result = new CorporateModel();
            try
            {
                result.CompanyName = model.CompanyName;
                result.SecRegistrationNumber = model.SecRegistrationNumber;
                result.Tin = model.Tin;
                result.OfficeAddress = model.OfficeAddress;
                result.BusinessNature = model.BusinessNature;
                result.TelNo = model.TelNo;
                result.Email = model.Email;
                result.YearsInOperation = model.YearsInOperation;
                result.FaxNo = model.FaxNo;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
