using jespinozaS5.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net;

namespace jespinozaS5.Views;

public partial class vCrearAlmacen : ContentPage
{
    private const string URI = "http://localhost:7000/api/almacen";
    private readonly HttpClient _httpClient = new HttpClient();
    private string identidad;
    public vCrearAlmacen(string id)
	{
        
		InitializeComponent();

        if (!string.IsNullOrEmpty(id))
        {
            identidad=id;
            obtenerAlmacenId(id);
        }
    }


    public async void obtenerAlmacenId(string id)
    {
        var client = await _httpClient.GetStringAsync($"{URI}/{id}");
        var almacen = JsonConvert.DeserializeObject<Almacen>(client);
        txtNombre.Text = almacen.Nombre;
        txtDireccion.Text = almacen.Direccion;
        txtlatitud.Text = almacen.Latitud;
        txtlongitud.Text = almacen.Longitud;

        // listaAlmacen.ItemsSource = almacens;

    }
    private void btnCrear_Clicked(object sender, EventArgs e)
    {
		try
		{

            WebClient client = new WebClient();
            var parametros = new NameValueCollection();
            parametros.Add("Nombre", txtNombre.Text);
            parametros.Add("Direccion", txtDireccion.Text);
            parametros.Add("Latitud", txtlatitud.Text);
            parametros.Add("Longitud", txtlongitud.Text);
            if (string.IsNullOrEmpty(identidad))
            {
                client.UploadValues("http://localhost:7000/api/almacen/crear","POST", parametros);
                Navigation.PushAsync(new vAlmacen());
                DisplayAlert("Almacen", "Nuevo almacen agreado!", "Ok");
            }
            else
            {
                client.UploadValues($"http://localhost:7000/api/almacen/{identidad}", "PUT", parametros);
                Navigation.PushAsync(new vAlmacen());
                DisplayAlert("Almacen", $"almacen actualizado!{ identidad }", "Ok");
            }
           
        }
		catch (Exception ex)
		{

            DisplayAlert("Almacen", $"Error al agregar almacen: {ex.Message}", "Ok");

        }

    }
}