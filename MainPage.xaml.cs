// Arquivo MainPage.xaml.cs
namespace MauiAppMeuCombustivel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            //Tratamento de exceções para capturar erros de conversão e exibir mensagens amigáveis ao usuário
            try
            {
                // Captura do preço dos combustíveis
                double etanol = Convert.ToDouble(txt_etanol.Text);
                double gasolina = Convert.ToDouble(txt_gasolina.Text);

                // Captura e formatação do nome do veículo
                string marca = string.IsNullOrWhiteSpace(txt_marca.Text) ? "Veículo" : txt_marca.Text.Trim();
                string modelo = string.IsNullOrWhiteSpace(txt_modelo.Text) ? "" : txt_modelo.Text.Trim();
                string veiculo = $"{marca} {modelo}".Trim();

                string resultadoCombustivel = "";

                // Regra dos 70%
                if (etanol <= (gasolina * 0.7))
                {
                    resultadoCombustivel = "O etanol está compensando ";
                }
                else
                {
                    resultadoCombustivel = "A gasolina está compensando ";
                }

                // Mensagem final integrando o resultado e a marca e modelo do veículo
                string msg = $"{resultadoCombustivel} para o seu veículo {veiculo}";

                // Exibição do alerta
                await DisplayAlertAsync("Resultado da Análise", msg, "OK");

            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Ops", "Verifique se os preços foram preenchidos corretamente.\n\n" + ex.Message, "Fechar");
            }

        } // Fecha método
    } // Fecha Class
} // Fecha namespace