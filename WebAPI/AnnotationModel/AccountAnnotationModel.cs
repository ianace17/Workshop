using System.ComponentModel.DataAnnotations;
using WorkShop.Library.Model;

namespace WebAPI.AnnotationModel
{
    public class AccountAnnotationModel
    {
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string TelNo { get; set; }
        [Required]
        public string MobileNo { get; set; }

        [Required]
        [StringLength(1)]
        public string Nationality { get; set; }
        public string SpouseName { get; set; }
        [Required]
        public string Tin { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [RegularExpression(@"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}]+)*@((([\-\w]+\.)+[a-zA-Z]{2,20})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$")]
        public string Email { get; set; }

        public string Occupation { get; set; }
        public string BusinessNature { get; set; }
        public string EmployerName { get; set; }
        public string BusinessAddress { get; set; }
        [Required]
        public string TCCode { get; set; }
        [Required]
        public string TraderID { get; set; }
        [Required]
        public string ClientCode { get; set; }

        public string PdtcSubAccount { get; set; }
        public string AccountOwnership { get; set; }
        [Required]
        public string AccountType { get; set; }
        [Required]
        public decimal BrokerCommission { get; set; }
        [Required]
        public decimal MinumumCommission { get; set; }
        [Required]
        [StringLength(1)]
        public string CivilStatus { get; set; }




        public static implicit operator AccountModel(AccountAnnotationModel model)
        {
            var result = new AccountModel();
            try
            {
                result.Lastname = model.Lastname;
                result.Firstname = model.Firstname;
                result.Middlename = model.Middlename;
                result.TelNo = model.TelNo;
                result.MobileNo = model.MobileNo;
                result.Nationality = Convert.ToChar(model.Nationality);
                result.SpouseName = model.SpouseName;
                result.Tin = model.Tin;
                result.Email = model.Email;
                result.Occupation = model.Occupation;
                result.BusinessNature = model.BusinessNature;
                result.EmployerName = model.EmployerName;
                result.BusinessAddress = model.BusinessAddress;
                result.TCCode = model.TCCode;
                result.TraderID = model.TraderID;
                result.ClientCode = model.ClientCode;
                result.PdtcSubAccount = model.PdtcSubAccount;
                result.AccountOwnership = model.AccountOwnership;
                result.AccountType = model.AccountType;
                result.BrokerCommission = model.BrokerCommission;
                result.MinumumCommission = model.MinumumCommission;
                result.CivilStatus = Convert.ToChar(model.CivilStatus);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

    }
}
