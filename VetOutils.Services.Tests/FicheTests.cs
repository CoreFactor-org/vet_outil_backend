using System;

namespace VetOutils.Services.Tests;

public class FicheTests
{
    private Fiche _sut = new Fiche
    {
        FicheId = Guid.NewGuid(),
        BddId = 78,
        Titre = "Tetelle",
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

}
