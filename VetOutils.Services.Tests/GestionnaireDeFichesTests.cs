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
            FicheGuid = Guid.NewGuid(),
            DateCreation = DateTimeOffset.Now,
            Titre = "Titre_bidon",
        };

        //Act
        var id = _sut.AjouteFiche(fiche);

        //Assert
        Assert.NotEqual(Guid.Empty, id);
    }

    [Fact]
    public void Recuperation_Fiche_inexistante()
    {
        //Arrange
        var id = Guid.NewGuid();

        //Act
        var fiche = _sut.GetFiche(id);

        //Assert
        Assert.Null(fiche);
    }

    [Fact]
    public void Recuperation_Fiche_existante()
    {
        //Arrange
        var fiche = new Fiche
        {
            FicheGuid = Guid.NewGuid(),
            DateCreation = DateTimeOffset.Now,
            Titre = "Titre_bidon",
        };

        var id = _sut.AjouteFiche(fiche);

        //Act
        var ficheTrouvee = _sut.GetFiche(id);

        //Assert
        Assert.NotNull(ficheTrouvee);
    }

    [Fact]
    public void Supprimer_Fiche_inexistante()
    {
        //Arrange
        var id = new Guid("A26F4BD3-7E38-4484-885D-9FDA936DC1B7");

        //Act
        var res = _sut.SupprimeFiche(id);

        //Assert
        Assert.False(res);
    }

    [Fact]
    public void Supprimer_Fiche_existante()
    {
        //Arrange
        var fiche = new Fiche
        {
            FicheGuid = Guid.NewGuid(),
            DateCreation = DateTimeOffset.Now,
            Titre = "Titre_bidon",
        };
        var id = _sut.AjouteFiche(fiche);

        //Act
        var res = _sut.SupprimeFiche(id);

        //Assert
        Assert.True(res);
    }


    [Fact]
    public void Recherche_Fiche_inexistante()
    {
        //Arrange
        var id = Guid.NewGuid();

        //Act
        var res = _sut.GetFiche(id);

        //Assert
        Assert.Null(res);
    }

    [Fact]
    public void Recherche_Fiche_inexistante_par_etiquette()
    {
        //Arrange

        //Act
        var res = _sut.RechercheFichesParEtiquettes(Etiquette.FCO);

        //Assert
        Assert.Empty(res);
    }

    [Fact]
    public void Recherche_Fiche_inexistante_par_etiquettes()
    {
        //Arrange

        //Act
        var res = _sut.RechercheFichesParEtiquettes(Etiquette.FCO, Etiquette.Brucellose);

        //Assert
        Assert.Empty(res);
    }

    [Fact]
    public void Recherche_Fiche_par_etiquettes_sans_succes()
    {
        //Arrange
        var fiche = new Fiche()
        {
            Etiquettes = new HashSet<Etiquette>()
            {
                Etiquette.FCO
            },
            FicheGuid = Guid.NewGuid(),
            DateCreation = DateTimeOffset.Now,
            Titre = "Titre_bidon",
        };
        _sut.AjouteFiche(fiche);

        //Act
        var res = _sut.RechercheFichesParEtiquettes(Etiquette.FCO, Etiquette.Brucellose);

        //Assert
        Assert.Empty(res);
    }

    [Fact]
    public void Recherche_Fiche_par_etiquettes_succes()
    {
        //Arrange
        var fiche = new Fiche
        {
            FicheId = 67,
            Etiquettes = new HashSet<Etiquette>
            {
                Etiquette.FCO,
                Etiquette.Brucellose
            },
            FicheGuid = Guid.NewGuid(),
            DateCreation = DateTimeOffset.Now,
            Titre = "Titre_bidon",
        };
        _sut.AjouteFiche(fiche);

        //Act
        var res = _sut.RechercheFichesParEtiquettes(Etiquette.FCO, Etiquette.Brucellose);

        //Assert
        Assert.Single(res);
        Assert.Equal(67, res[0].FicheId);
    }

    [Fact]
    public void Recherche_Fiche_par_etiquettes_sans_etiquettes()
    {
        //Arrange
        var fiche = new Fiche
        {
            FicheId = 67,
            Etiquettes = new HashSet<Etiquette>()
            {
                Etiquette.FCO,
                Etiquette.Brucellose
            },
            FicheGuid = Guid.NewGuid(),
            DateCreation = DateTimeOffset.Now,
            Titre = "Titre_bidon",
        };
        _sut.AjouteFiche(fiche);

        //Act
        var res = _sut.RechercheFichesParEtiquettes();

        //Assert
        Assert.Single(res);
        Assert.Equal(67, res[0].FicheId);
    }
}