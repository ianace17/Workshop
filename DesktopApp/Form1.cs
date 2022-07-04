using WorkShop.Library.IServices;
using WorkShop.Library.Model;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        private readonly IRegistrationCommand _registrationCommand;
        public Form1(IRegistrationCommand registrationCommand)
        {
            _registrationCommand = registrationCommand;
            var registration = new RegistrationModel();
            _registrationCommand.CreateIndividual(registration);
            InitializeComponent();
        }

    }
}