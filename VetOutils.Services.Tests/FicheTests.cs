namespace VetOutils.Services.Tests;

public class FicheTests
{
    private readonly Fiche _sut = new Fiche
    {
        FicheId = Guid.NewGuid(),
        BddId = 78,
        Titre = "Impact de l'introduction du T-Rex sur la production laitière des brebis en zone Roquefort",
        Auteurs = ["Defachelles", "Gouache"],
        DateCreation = DateTimeOffset.Now.AddMonths(-267),
        DateModification = DateTimeOffset.Now.AddDays(-2),
        Standard = new FormatAffichageSngtvStandard(),
        Etiquettes = [Etiquette.Ovin, Etiquette.FCO, Etiquette.FievreQ],
        LienSource = new DetailLien
        {
            Url = "https://sngtv.org/file/api/ovin_27.pdf",
            Format = FormatSource.PDF,
        },
    };

    [Fact]
    public void Fiche_a_un_titre()
    {
        //Arrange

        //Act
        var res = _sut.Titre;

        //Assert
        Assert.Equal("Tetelle", res);
    }

    [Fact]
    public void Fiche_a_des_auteurs_correctement_ordonne()
    {
        //Arrange

        //Act
        var res = _sut.Auteurs;

        //Assert
        Assert.Equal(2, res.Count);
        Assert.Equal("Defachelles", res[0]);
        Assert.Equal("Gouache", res[1]);
    }

    [Fact]
    public void Fiche_nouvelle_a_aucun_auteur()
    {
        //Arrange
        var nouvelleFiche = new Fiche
        {
            FicheId = Guid.NewGuid(),
            DateCreation = DateTimeOffset.Now,
            Titre = "l'alimentation des t-Rex"
        };

        //Act
        var res = nouvelleFiche.Auteurs;

        //Assert
        Assert.Empty(res);
    }


}
