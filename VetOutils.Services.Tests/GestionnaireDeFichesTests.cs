namespace VetOutils.Services.Tests;

public class GestionnaireDeFichesTests
{
    private readonly GestionnaireDeFiches _sut = new GestionnaireDeFiches();

    [Fact]
    public void Ajout_une_nouvelle_Fiche()
    {
        //Arrange
        var fiche = new Fiche
        {
            Titre = "Ajout fiche",
            Description = "Description ajout",
            DateCreation = DateTime.Now,
            DateModification = DateTime.Now,
            Etiquettes = new List<Etiquette>()
            {
            Etiquette.FCO,
            Etiquette.Ovin
        }
        };

        //Act
        var id = _sut.AjoutFiche(fiche);

        //Assert
        Assert.NotEqual(0, id);
    }

    [Fact]
    public void Recuperation_Fiche_inexistante()
    {
        //Arrange
        int id = 5;

        //Act
        Fiche? fiche = _sut.RecuperationFiche(id);

        //Assert
        Assert.Null(fiche);
    }

    [Fact]
    public void Recuperation_Fiche_existante()
    {
        //Arrange
        var id = 2;

        //Act
        Fiche? fiche = _sut.RecuperationFiche(id);
        //Assert
        Assert.NotNull(fiche);
    }

    [Fact]
    public void Supprimer_Fiche_inexistante()
    {
        //Arrange
        int id = 5;

        //Act
        bool res = _sut.SuppressionFiche(id);

        //Assert
        Assert.False(res);
    }

    [Fact]
    public void Supprimer_Fiche_existante()
    {
        //Arrange
        var id = 1;

        //Act
        bool res = _sut.SuppressionFiche(id);

        //Assert
        Assert.True(res);
    }

    [Fact]
    public void Recherche_Fiche_inexistante()
    {
        //Arrange
        int id = 8;

        //Act
        Fiche? res = _sut.RechercheFicheParId(id);

        //Assert
        Assert.Null(res);
    }

    [Fact]
    public void Recherche_Fiche_inexistante_par_etiquette()
    {
        //Arrange

        //Act
        List<Fiche>? res = _sut.RechercheFiches(Etiquette.Absent);

        //Assert
        Assert.Null(res);
    }

    [Fact]
    public void Recherche_Fiche_inexistante_par_etiquettes()
    {
        //Arrange

        //Act
        List<Fiche>? res = _sut.RechercheFiches(Etiquette.FCO, Etiquette.Brucellose);

        //Assert
        Assert.NotNull(res);
    }

    [Fact]
    public void Recherche_Fiche_par_etiquettes_sans_succes()
    {
        //Arrange

        //Act
        bool res = _sut.RechercheFichesSucces(Etiquette.Absent);

        //Assert
        Assert.False(res);
    }

    [Fact]
    public void Recherche_Fiche_par_etiquettes_succes()
    {
        //Arrange

        //Act
        bool res = _sut.RechercheFichesSucces(Etiquette.Brucellose, Etiquette.FCO);

        //Assert
        Assert.True(res);
    }
}