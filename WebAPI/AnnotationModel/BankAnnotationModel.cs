using System.ComponentModel.DataAnnotations;
using WorkShop.Library.Model;

namespace WebAPI.AnnotationModel
{
    public class BankAnnotationModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        public string AccountNo { get; set; }

        public static implicit operator BankModel(BankAnnotationModel model)
        {
            var result = new BankModel();
            try
            {
                result.Name = model.Name;
                result.Branch = model.Branch;
                result.AccountNo = model.AccountNo;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
