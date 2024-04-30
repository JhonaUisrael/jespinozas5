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
}