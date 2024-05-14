using jespinozaS5.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace jespinozaS5.Views;


public partial class vAlmacen : ContentPage
{
    private const string URI = "http://localhost:7000/api/almacen";
    private readonly HttpClient _httpClient = new HttpClient();
    private ObservableCollection<Almacen> almacens;
    private string commandParameter=string.Empty;
    public vAlmacen()
	{
		InitializeComponent();
        obtenerAlmacenes();

    }

    public async void obtenerAlmacenes()
    {
        var client = await _httpClient.GetStringAsync($"{URI}/listar");
        var almacenes = JsonConvert.DeserializeObject<List<Almacen>>(client);
        almacens = new ObservableCollection<Almacen>(almacenes);
       listaAlmacen.ItemsSource = almacens;

    }

    private void btnCrear_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vCrearAlmacen(string.Empty));
    }

    private async void btnBorrar_Clicked(object sender, EventArgs e)
    {
        // Verifica si el sender es del tipo adecuado
        if (sender is Button button)
        {
            // Obtiene el valor de CommandParameter
             commandParameter = button.CommandParameter.ToString();
            var client = await _httpClient.DeleteAsync($"{URI}/{commandParameter}");

            obtenerAlmacenes();

        }

    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
         if (sender is Button button)
        {
            // Obtiene el valor de CommandParameter
            commandParameter = button.CommandParameter.ToString();
            Navigation.PushAsync(new vCrearAlmacen(commandParameter));


        }

    }
}