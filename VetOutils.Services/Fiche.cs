namespace VetOutils.Services;

public class Fiche
{
    public int Id { get; set; }
    public DateTimeOffset DateCreation { get; set; }
    public DateTimeOffset DateModification { get; set; }
    public string CheminPdf { get; set; }
    public string Titre { get; set; }
    public string Description { get; set; }
    public List<Etiquette> Etiquettes { get; set; }
    public FormatAffichageSngtvStandard Standard { get; set; }
    
}

public enum Etiquette
{
    Ovin,
    Brucellose,
    FCO,
}

public class FormatAffichageSngtvStandard
{
    
}