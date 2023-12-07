using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using WeatherAp.Services;
using System.IO; 

namespace WeatherAp
{
    public partial class MainWindow : Window
    {
        Ville.Villes ville;
        private CityManager _cityManager;

        public MainWindow()
        {
            ville = new Ville.Villes();
            InitializeComponent();


            // Assurez-vous que CB_Villes est correctement initialisé
            CB_Villes.ItemsSource = ville.LsVille;

            // Gérez l'événement SelectionChanged pour obtenir la météo lorsque la sélection change
            CB_Villes.SelectionChanged += CB_Villes_SelectionChanged;

            // Appel initial de GetMeteo avec la valeur sélectionnée initialement (par exemple, "Annecy" par défaut)
            GetMeteo(CB_Villes.SelectedItem?.ToString() ?? "Annecy");
        }

        private void CB_Villes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obtenez la ville sélectionnée et appelez GetMeteo avec cette valeur
            string selectedVille = CB_Villes.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedVille))
            {
                GetMeteo(selectedVille);
            }
        }


        // Ajoutez la méthode GetMeteo ici
        private async void GetMeteo(string ville)
        {
            // Code pour obtenir la météo en fonction de la ville
            // (Remplacez cela par votre logique de météo réelle)
            Console.WriteLine($"Obtenir la météo pour {ville}");

            // Appel de la méthode GetWeather
            string weatherResult = await GetWeather(ville);

            // Faites quelque chose avec le résultat (par exemple, mettez à jour l'interface utilisateur)
            Console.WriteLine(weatherResult);
        }

        // Méthode pour obtenir la météo à partir de l'API
        public async Task<string> GetWeather(string ville)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://www.prevision-meteo.ch/services/json/{ville}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Root root = JsonConvert.DeserializeObject<Root>(content);


                    CurrentCondition currentCondition;

                    {
                        currentCondition = root.current_condition;

                        FcstDay fcstDay0 = root.fcst_day_0;
                        Temp_0.Text = $"{fcstDay0.day_long}: {root.current_condition.tmp}°C";
                        Previsions_0.Text = root.current_condition.condition;
                        TempMax_0.Text = $"Max: {fcstDay0.tmax}°C";
                        TempLow_0.Text = $"Min: {fcstDay0.tmin}°C";
                        Condition_0.Text = $"Humidité: {fcstDay0.tmin}%";

                        // Jour 1
                        FcstDay fcstDay1 = root.fcst_day_1;
                        Temp_1.Text = $"{fcstDay1.day_long}: {root.current_condition.tmp}°C";
                        Previsions_1.Text = root.current_condition.condition;
                        TempMax_1.Text = $"Max: {fcstDay1.tmax}°C";
                        TempLow_1.Text = $"Min: {fcstDay1.tmin}°C";
                        Condition_1.Text = $"Humidité: {fcstDay1.tmin}%";

                        // Jour 2
                        FcstDay fcstDay2 = root.fcst_day_2;
                        Temp_2.Text = $"{fcstDay2.day_long}: {root.current_condition.tmp}°C";
                        Previsions_2.Text = root.current_condition.condition;
                        TempMax_2.Text = $"Max: {fcstDay2.tmax}°C";
                        TempLow_2.Text = $"Min: {fcstDay2.tmin}°C";
                        Condition_2.Text = $"Humidité: {fcstDay2.tmin}%";

                        // Jour 3
                        FcstDay fcstDay3 = root.fcst_day_3;
                        Temp_3.Text = $"{fcstDay3.day_long}: {root.current_condition.tmp}°C";
                        Previsions_3.Text = root.current_condition.condition;
                        TempMax_3.Text = $"Max: {fcstDay3.tmax}°C";
                        TempLow_3.Text = $"Min: {fcstDay3.tmin}°C";
                        Condition_3.Text = $"Humidité: {fcstDay3.tmin}%";



                        return "";
                    }




                    // Vous pouvez traiter les données météorologiques ici
                    // et renvoyer les informations souhaitées sous forme de chaîne
                    return "Météo récupérée avec succès !";
                }
            }
            catch (Exception ex)
            {
                return $"Erreur lors de la récupération de la météo : {ex.Message}";
            }

            return "Erreur inattendue lors de la récupération de la météo.";
        }
    }
    public partial class MainWindow : Window
    {
        // ...

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string nouvelleVille = Search.Text.Trim();

            // Vérifiez si la ville n'est pas déjà dans la liste
            if (!ville.LsVille.Contains(nouvelleVille))
            {
                // Ajoutez la nouvelle ville à la liste
                ville.LsVille.Add(nouvelleVille);

                // Mettez à jour la source de données de la ComboBox
                CB_Villes.ItemsSource = null; // Supprime la source actuelle
                CB_Villes.ItemsSource = ville.LsVille; // Ajoute la nouvelle ville à la source
            }
            else
            {
                MessageBox.Show("La ville existe déjà dans la liste.", "Erreur d'ajout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {

            // Vérifiez si une ville est sélectionnée
            if (CB_Villes.SelectedItem != null)
            {
                // Mettez un point d'arrêt (breakpoint) sur la ligne suivante
                string villeASupprimer = CB_Villes.SelectedItem.ToString();

                // Vérifiez si la ville à supprimer existe dans la liste
                if (villeASupprimer != null && ville.LsVille.Contains(villeASupprimer))
                {
                    // Supprimez la ville de la liste
                    ville.LsVille.Remove(villeASupprimer);

                    // Mettez à jour la source de données de la ComboBox
                    CB_Villes.ItemsSource = null; // Supprime la source actuelle
                    CB_Villes.ItemsSource = ville.LsVille; // Ajoute la nouvelle ville à la source
                }
                else
                {
                    MessageBox.Show("La ville sélectionnée n'existe pas dans la liste.", "Erreur de suppression", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ville à supprimer.", "Erreur de suppression", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }



}



// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class _0H00
        {
            public string ICON { get; set; }
            public string CONDITION { get; set; }
            public string CONDITION_KEY { get; set; }
            public double TMP2m { get; set; }
            public double DPT2m { get; set; }
            public double WNDCHILL2m { get; set; }
            public object HUMIDEX { get; set; }
            public double RH2m { get; set; }
            public double PRMSL { get; set; }
            public double APCPsfc { get; set; }
            public double WNDSPD10m { get; set; }
            public double WNDGUST10m { get; set; }
            public double WNDDIR10m { get; set; }
            public string WNDDIRCARD10 { get; set; }
            public double ISSNOW { get; set; }
            public double HCDC { get; set; }
            public double MCDC { get; set; }
            public double LCDC { get; set; }
            public double HGT0C { get; set; }
            public double KINDEX { get; set; }
            public string CAPE180_0 { get; set; }
            public double CIN180_0 { get; set; }
        }

        public class _10H00
        {
    public string ICON { get; set; }
    public string CONDITION { get; set; }
    public string CONDITION_KEY { get; set; }
    public double TMP2m { get; set; }
    public double DPT2m { get; set; }
    public double WNDCHILL2m { get; set; }
    public object HUMIDEX { get; set; }
    public double RH2m { get; set; }
    public double PRMSL { get; set; }
    public double APCPsfc { get; set; }
    public double WNDSPD10m { get; set; }
    public double WNDGUST10m { get; set; }
    public double WNDDIR10m { get; set; }
    public string WNDDIRCARD10 { get; set; }
    public double ISSNOW { get; set; }
    public double HCDC { get; set; }
    public double MCDC { get; set; }
    public double LCDC { get; set; }
    public double HGT0C { get; set; }
    public double KINDEX { get; set; }
    public string CAPE180_0 { get; set; }
    public double CIN180_0 { get; set; }
}

        public class _11H00
        {
    public string ICON { get; set; }
    public string CONDITION { get; set; }
    public string CONDITION_KEY { get; set; }
    public double TMP2m { get; set; }
    public double DPT2m { get; set; }
    public double WNDCHILL2m { get; set; }
    public object HUMIDEX { get; set; }
    public double RH2m { get; set; }
    public double PRMSL { get; set; }
    public double APCPsfc { get; set; }
    public double WNDSPD10m { get; set; }
    public double WNDGUST10m { get; set; }
    public double WNDDIR10m { get; set; }
    public string WNDDIRCARD10 { get; set; }
    public double ISSNOW { get; set; }
    public double HCDC { get; set; }
    public double MCDC { get; set; }
    public double LCDC { get; set; }
    public double HGT0C { get; set; }
    public double KINDEX { get; set; }
    public string CAPE180_0 { get; set; }
    public double CIN180_0 { get; set; }
}

        public class _12H00
        {
    public string ICON { get; set; }
    public string CONDITION { get; set; }
    public string CONDITION_KEY { get; set; }
    public double TMP2m { get; set; }
    public double DPT2m { get; set; }
    public double WNDCHILL2m { get; set; }
    public object HUMIDEX { get; set; }
    public double RH2m { get; set; }
    public double PRMSL { get; set; }
    public double APCPsfc { get; set; }
    public double WNDSPD10m { get; set; }
    public double WNDGUST10m { get; set; }
    public double WNDDIR10m { get; set; }
    public string WNDDIRCARD10 { get; set; }
    public double ISSNOW { get; set; }
    public double HCDC { get; set; }
    public double MCDC { get; set; }
    public double LCDC { get; set; }
    public double HGT0C { get; set; }
    public double KINDEX { get; set; }
    public string CAPE180_0 { get; set; }
    public double CIN180_0 { get; set; }
}

public class _13H00
{
    public string ICON { get; set; }
    public string CONDITION { get; set; }
    public string CONDITION_KEY { get; set; }
    public double TMP2m { get; set; }
    public double DPT2m { get; set; }
    public double WNDCHILL2m { get; set; }
    public object HUMIDEX { get; set; }
    public double RH2m { get; set; }
    public double PRMSL { get; set; }
    public double APCPsfc { get; set; }
    public double WNDSPD10m { get; set; }
    public double WNDGUST10m { get; set; }
    public double WNDDIR10m { get; set; }
    public string WNDDIRCARD10 { get; set; }
    public double ISSNOW { get; set; }
    public double HCDC { get; set; }
    public double MCDC { get; set; }
    public double LCDC { get; set; }
    public double HGT0C { get; set; }
    public double KINDEX { get; set; }
    public string CAPE180_0 { get; set; }
    public double CIN180_0 { get; set; }

    public class _14H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _15H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _16H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _17H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _18H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _19H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _1H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _20H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _21H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _22H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _23H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _2H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _3H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _4H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _5H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _6H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _7H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _8H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class _9H00
    {
        public string ICON { get; set; }
        public string CONDITION { get; set; }
        public string CONDITION_KEY { get; set; }
        public double TMP2m { get; set; }
        public double DPT2m { get; set; }
        public double WNDCHILL2m { get; set; }
        public object HUMIDEX { get; set; }
        public double RH2m { get; set; }
        public double PRMSL { get; set; }
        public double APCPsfc { get; set; }
        public double WNDSPD10m { get; set; }
        public double WNDGUST10m { get; set; }
        public double WNDDIR10m { get; set; }
        public string WNDDIRCARD10 { get; set; }
        public double ISSNOW { get; set; }
        public double HCDC { get; set; }
        public double MCDC { get; set; }
        public double LCDC { get; set; }
        public double HGT0C { get; set; }
        public double KINDEX { get; set; }
        public string CAPE180_0 { get; set; }
        public double CIN180_0 { get; set; }
    }

    public class CityInfo
    {
        public string name { get; set; }
        public string country { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string elevation { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }

    public class CurrentCondition
    {
        public string date { get; set; }
        public string hour { get; set; }
        public int tmp { get; set; }
        public int wnd_spd { get; set; }
        public int wnd_gust { get; set; }
        public string wnd_dir { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public string condition { get; set; }
        public string condition_key { get; set; }
        public string icon { get; set; }
        public string icon_big { get; set; }
    }

    public class FcstDay0
    {
        public string date { get; set; }
        public string day_short { get; set; }
        public string day_long { get; set; }
        public int tmin { get; set; }
        public int tmax { get; set; }
        public string condition { get; set; }
        public string condition_key { get; set; }
        public string icon { get; set; }
        public string icon_big { get; set; }
        public HourlyData hourly_data { get; set; }
    }

    public class FcstDay1
    {
        public string date { get; set; }
        public string day_short { get; set; }
        public string day_long { get; set; }
        public int tmin { get; set; }
        public int tmax { get; set; }
        public string condition { get; set; }
        public string condition_key { get; set; }
        public string icon { get; set; }
        public string icon_big { get; set; }
        public HourlyData hourly_data { get; set; }
    }

    public class FcstDay2
    {
        public string date { get; set; }
        public string day_short { get; set; }
        public string day_long { get; set; }
        public int tmin { get; set; }
        public int tmax { get; set; }
        public string condition { get; set; }
        public string condition_key { get; set; }
        public string icon { get; set; }
        public string icon_big { get; set; }
        public HourlyData hourly_data { get; set; }
    }

    public class FcstDay3
    {
        public string date { get; set; }
        public string day_short { get; set; }
        public string day_long { get; set; }
        public int tmin { get; set; }
        public int tmax { get; set; }
        public string condition { get; set; }
        public string condition_key { get; set; }
        public string icon { get; set; }
        public string icon_big { get; set; }
        public HourlyData hourly_data { get; set; }
    }

    public class FcstDay4
    {
        public string date { get; set; }
        public string day_short { get; set; }
        public string day_long { get; set; }
        public int tmin { get; set; }
        public int tmax { get; set; }
        public string condition { get; set; }
        public string condition_key { get; set; }
        public string icon { get; set; }
        public string icon_big { get; set; }
        public HourlyData hourly_data { get; set; }
    }

    public class ForecastInfo
    {
        public object latitude { get; set; }
        public object longitude { get; set; }
        public string elevation { get; set; }
    }

    public class HourlyData
    {
        [JsonProperty("0H00")]
        public _0H00 _0H00 { get; set; }

        [JsonProperty("1H00")]
        public _1H00 _1H00 { get; set; }

        [JsonProperty("2H00")]
        public _2H00 _2H00 { get; set; }

        [JsonProperty("3H00")]
        public _3H00 _3H00 { get; set; }

        [JsonProperty("4H00")]
        public _4H00 _4H00 { get; set; }

        [JsonProperty("5H00")]
        public _5H00 _5H00 { get; set; }

        [JsonProperty("6H00")]
        public _6H00 _6H00 { get; set; }

        [JsonProperty("7H00")]
        public _7H00 _7H00 { get; set; }

        [JsonProperty("8H00")]
        public _8H00 _8H00 { get; set; }

        [JsonProperty("9H00")]
        public _9H00 _9H00 { get; set; }

        [JsonProperty("10H00")]
        public _10H00 _10H00 { get; set; }

        [JsonProperty("11H00")]
        public _11H00 _11H00 { get; set; }

        [JsonProperty("12H00")]
        public _12H00 _12H00 { get; set; }

        [JsonProperty("13H00")]
        public _13H00 _13H00 { get; set; }

        [JsonProperty("14H00")]
        public _14H00 _14H00 { get; set; }

        [JsonProperty("15H00")]
        public _15H00 _15H00 { get; set; }

        [JsonProperty("16H00")]
        public _16H00 _16H00 { get; set; }

        [JsonProperty("17H00")]
        public _17H00 _17H00 { get; set; }

        [JsonProperty("18H00")]
        public _18H00 _18H00 { get; set; }

        [JsonProperty("19H00")]
        public _19H00 _19H00 { get; set; }

        [JsonProperty("20H00")]
        public _20H00 _20H00 { get; set; }

        [JsonProperty("21H00")]
        public _21H00 _21H00 { get; set; }

        [JsonProperty("22H00")]
        public _22H00 _22H00 { get; set; }

        [JsonProperty("23H00")]
        public _23H00 _23H00 { get; set; }
    }

    public class Root
    {
        public CityInfo city_info { get; set; }
        public ForecastInfo forecast_info { get; set; }
        public CurrentCondition current_condition { get; set; }
        public FcstDay0 fcst_day_0 { get; set; }
        public FcstDay1 fcst_day_1 { get; set; }
        public FcstDay2 fcst_day_2 { get; set; }
        public FcstDay3 fcst_day_3 { get; set; }
        public FcstDay4 fcst_day_4 { get; set; }
    }
}
   

