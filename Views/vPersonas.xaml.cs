using System.Xml.Linq;

namespace jespinozaS5.Views;

public partial class vPersonas : ContentPage
{
	public vPersonas()
	{
		InitializeComponent();
	}

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        App.personaRepository.AddPersona(txtname.Text);
        lblMessage.Text = App.personaRepository.statusMessage;
    }

    private void btnList_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        listPersonas.ItemsSource = App.personaRepository.ListarPersonas();

    }

   
    private void btnDelete_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = "";

        // Verifica si el sender es del tipo adecuado
        if (sender is Button button)
        {
            // Obtiene el valor de CommandParameter
            var commandParameter = button.CommandParameter.ToString();
            App.personaRepository.BorraPersona(int.Parse(commandParameter));
            lblMessage.Text = App.personaRepository.statusMessage;

            listPersonas.ItemsSource = App.personaRepository.ListarPersonas();


        }

    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = "";

        if (sender is Button button)
        {
            // Obtiene el valor de CommandParameter
            var commandParameter = button.CommandParameter.ToString();
            var persona=App.personaRepository.BuscarPersonaPorId(int.Parse(commandParameter));
            txtname.Text = persona.Name;
            idUpdate.Text = commandParameter;


        }
    }

   
    private void btnUpdatePerson_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = "";

        App.personaRepository.ActualizarPersona(int.Parse(idUpdate.Text), txtname.Text);
        lblMessage.Text = App.personaRepository.statusMessage;
        txtname.Text = "";
        listPersonas.ItemsSource = App.personaRepository.ListarPersonas();


    }
}