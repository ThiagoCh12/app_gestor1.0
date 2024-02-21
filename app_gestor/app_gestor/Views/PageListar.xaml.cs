using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using app_gestor.Model;
using app_gestor.Service;

namespace app_gestor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListar : ContentPage
    {
        public PageListar()
        {
            InitializeComponent();
            AtualizarLista();
        }
        public void AtualizarLista()
        {
            String titulo = "";
            if (txtNome.Text != null) titulo = txtNome.Text;
            ServiceDBEmployee dbFuncionario = new ServiceDBEmployee(App.DbPath);
            if (swFavorito.IsToggled)
            {
                ListaFuncionario.ItemsSource = dbFuncionario.Localizar(titulo, true);
            }
            else
            {
                ListaFuncionario.ItemsSource = dbFuncionario.Localizar(titulo);
            }
        }

        private void ListaFuncionario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ModelEmployee funcionario = (ModelEmployee)ListaFuncionario.SelectedItem;
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageCadastrar(funcionario));
        }

        private void swFavorito_Toggled(object sender, ToggledEventArgs e)
        {
            AtualizarLista();
        }

        private void btLocalizar_Clicked(object sender, EventArgs e)
        {
            AtualizarLista();
        }
    }
}