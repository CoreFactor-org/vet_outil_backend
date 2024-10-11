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
}