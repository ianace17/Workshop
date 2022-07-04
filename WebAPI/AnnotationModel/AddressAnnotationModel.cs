using System.ComponentModel.DataAnnotations;
using WorkShop.Library.Model;

namespace WebAPI.AnnotationModel
{
    public class AddressAnnotationModel
    {
        [Required]
        public string HouseNo { get; set; }
        [Required]
        public string Streetname { get; set; }
        [Required]
        public string Barangay { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        [StringLength(4)]
        public string PostalCode { get; set; }

        public static implicit operator AddressModel(AddressAnnotationModel model)
        {
            var result = new AddressModel();
            try
            {
                result.HouseNo = model.HouseNo;
                result.Streetname = model.Streetname;
                result.Barangay = model.Barangay;
                result.City = model.City;
                result.Province = model.Province;
                result.PostalCode = model.PostalCode;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
