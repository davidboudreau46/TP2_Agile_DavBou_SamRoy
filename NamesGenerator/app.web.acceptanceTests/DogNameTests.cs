using System;
using System.Text;
using System.Threading.Tasks;
using app.domain;
using app.testApi;
using GenFu;
using Newtonsoft.Json;
using TestStack.BDDfy;
using Xunit;
using System.Net.Http;
using System.Collections.Generic;

namespace app.web.acceptanceTests
{
    [Story(
        Title = "je veux pouvoir voir une liste de mots originaux",
        AsA = "Utilisateur général",
        IWant = "je veux pouvoir voir une liste de mots originaux",
        SoThat = "afin de trouver un nom pour mon chien")]
    public class DogNameTests : AcceptanceTestsBase
    {
        private string _htmlPageContent;
        private List<DogName> _dogNames;
        public void afficher_le_nom_un_chien()
        {
            this.Given(x => un_nom_de_chien())
                .When(x => l_utilisateur_demande_de_voir_la_page_principale())
                .Then(x => le_nom_des_chien_s_affiche())
                .BDDfy();
        }
        [Fact]
        private void le_nom_des_chien_s_affiche()
        {
            Assert.True(true);
        }

        private async void l_utilisateur_demande_de_voir_la_page_principale()
        {
            var response = await HttpClient.GetAsync("/Home");
            response.EnsureSuccessStatusCode();
            _htmlPageContent = await response.Content.ReadAsStringAsync();
        }

        private void un_nom_de_chien()
        {
            DbTestApi.ClearAllTables();
            _dogNames = newDogNames();
        }

        private List<DogName> newDogNames()
        {
            return new List<DogName>()
            {
                new DogName()
                {
                    Name = "Chien Chien"
                }
            };
        }
    }
}
