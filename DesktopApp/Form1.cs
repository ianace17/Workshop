using DesktopApp.Repository;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;
using WorkShop.Library.IServices;
using WorkShop.Library.Model;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        private readonly IRegistrationCommand _registrationCommand;

        public Form1(IRegistrationCommand registrationCommand, IConfiguration configuration)
        {
            _registrationCommand = registrationCommand;
            InitializeComponent();

            //new AccountService(configuration).Query("1", "email@psei.ph");

            // MessageBox.Show("DOne");
        }

        internal readonly char[] chars =
              "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        public string GetUniqueKey(int size)
        {
            byte[] data = new byte[4 * size];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(() =>
            {
                for (int i = 40000; i < 200000; i++)
                {

                    //var i = 0;
                    var registration = new RegistrationModel();


                    registration.AccountDetails = new AccountModel();
                    registration.Addresses = new List<AddressModel>();
                    registration.Banks = new List<BankModel>();
                    registration.Users = new List<UserModel>();
                    registration.Type = 1;


                    registration.AccountDetails = new AccountModel()
                    {
                        AccountOwnership = "1",
                        AccountType = "1",
                        BusinessAddress = "Address",
                        BusinessNature = "IT",
                        CivilStatus = 'M',
                        ClientCode = GetUniqueKey(10) + "-" + GetUniqueKey(4),
                        Email = $"email{i}@psei.ph",
                        EmployerName = "Mark Joya",
                        Firstname = GetUniqueKey(10),
                        Lastname = GetUniqueKey(10),
                        Middlename = GetUniqueKey(10),
                        MobileNo = "00000",
                        Nationality = 'F',
                        SpouseName = "Ssddd",
                        Status = 1,
                        Occupation = "Dev",
                        TelNo = "asdasda",
                        Tin = "12121"
                    };




                    registration.Addresses.Add(new AddressModel
                    {
                        Barangay = "2",
                        City = "2",
                        HouseNo = "2332",
                        PostalCode = "1234",
                        Province = "123123",
                        Status = 1,
                        Streetname = $"St. dad{i}"
                    });

                    registration.Banks.Add(new BankModel
                    {
                        AccountNo = "677673992000",
                        Branch = $"Imus{i}",
                        Name = GetUniqueKey(10),
                        Status = 1
                    });



                    registration.Users.Add(new UserModel
                    {
                        Birthdate = DateTime.Now,
                        Email = $"email{i}@psei.ph",
                        Firstname = registration.AccountDetails.Firstname,
                        Middlename = registration.AccountDetails.Middlename,
                        Lastname = registration.AccountDetails.Lastname,
                        Gender = 'M',
                        Password = "sd1d1d1d1d",
                        Status = 1
                    });


                    var d = _registrationCommand.CreateIndividual(registration).Result;
                }
            }));
            t.Start();

        }
    
    }

}