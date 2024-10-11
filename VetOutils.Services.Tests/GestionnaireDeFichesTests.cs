using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Logging;

namespace VetOutils.Services.Tests;

public class GestionnaireDeFichesTests
{
    private readonly GestionnaireDeFiches _sut = new GestionnaireDeFiches();

    [Fact]
    public void Ajout_une_nouvelle_Fiche()
    {
        //Arrange
        var fiche = new Fiche();

        //Act
        var id = _sut.AjoutFiche(fiche);

        //Assert
        Assert.NotEqual(0, id);
    }

    [Fact]
    public void Recuperation_Fiche_inexistante()
    {
        //Arrange
        int id = 67;

        //Act
        Fiche fiche = _sut.RecuperationFiche(id);

        //Assert
        Assert.Null(fiche);
    }

    [Fact]
    public void Recuperation_Fiche_existante()
    {
        //Arrange
        var fiche = new Fiche();
        var id = _sut.AjoutFiche(fiche);

        //Act
        Fiche ficheTrouvee = _sut.RecuperationFiche(id);

        //Assert
        Assert.NotNull(ficheTrouvee);
    }

    [Fact]
    public void Supprimer_Fiche_inexistante()
    {
        //Arrange
        int id = 78;

        //Act
        bool res = _sut.SuppressionFiche(id);

        //Assert
        Assert.False(res);
    }

    [Fact]
    public void Supprimer_Fiche_existante()
    {
        //Arrange
        var fiche = new Fiche();
        var id = _sut.AjoutFiche(fiche);

        //Act
        bool res = _sut.SuppressionFiche(id);

        //Assert
        Assert.True(res);
    }
    
    [Fact]
    public void Recherche_Fiche_inexistante()
    {
        //Arrange
        int id = 23;

        //Act
        Fiche res = _sut.RechercheFicheParId(id);

        //Assert
        Assert.Null(res);
    }
    
    [Fact]
    public void Recherche_Fiche_inexistante_par_etiquette()
    {
        //Arrange

        //Act
        List<Fiche> res = _sut.RechercheFiches(Etiquette.FCO);

        //Assert
        Assert.Empty(res);
    }
    
    [Fact]
    public void Recherche_Fiche_inexistante_par_etiquettes()
    {
        //Arrange

        //Act
        List<Fiche> res = _sut.RechercheFiches(Etiquette.FCO, Etiquette.Brucellose);

        //Assert
        Assert.Empty(res);
    }
    
    [Fact]
    public void Recherche_Fiche_par_etiquettes_sans_succes()
    {
        //Arrange
        var fiche = new Fiche()
        {
            Etiquettes = new List<Etiquette>()
            {
                Etiquette.FCO
            }  
        };
        _sut.AjoutFiche(fiche);
        
        //Act
        List<Fiche> res = _sut.RechercheFiches(Etiquette.FCO, Etiquette.Brucellose);

        //Assert
        Assert.Empty(res);
    }
    
    [Fact]
    public void Recherche_Fiche_par_etiquettes_succes()
    {
        //Arrange
        var fiche = new Fiche()
        {
            Id = 67,
            Etiquettes = new List<Etiquette>()
            {
                Etiquette.FCO,
                Etiquette.Brucellose
            }  
        };
        _sut.AjoutFiche(fiche);
        
        //Act
        List<Fiche> res = _sut.RechercheFiches(Etiquette.FCO, Etiquette.Brucellose);

        //Assert
        Assert.Single(res);
        Assert.Equal(67,res[0].Id);
    }
}