using jespinozaS5.Repository;
using jespinozaS5.Views;

namespace jespinozaS5
{
    public partial class App : Application
    {
        public static PersonaRepository personaRepository { get; set; }
        public App(PersonaRepository personaRepo)
        {
            InitializeComponent();

            MainPage = new vPersonas();
            personaRepository = personaRepo;
        }
    }
}
