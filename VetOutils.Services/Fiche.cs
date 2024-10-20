namespace VetOutils.Services;

public class Fiche
{
    /// <summary>
    /// Le numéro unique qui identifie la fiche du point de vue métier
    /// </summary>
    public required Guid FicheGuid { get; init; }

    /// <summary>
    /// L'identifiant en base de données
    /// </summary>
    public int FicheId { get; init; }

    public required DateTimeOffset DateCreation { get; init; }
    public DateTimeOffset DateModification { get; init; }
    public string? CheminPdf { get; init; }
    public required string Titre { get; init; }
    public string? Description { get; init; }
    public HashSet<Etiquette> Etiquettes { get; init; } = [];
    public FormatAffichageSngtvStandard? Standard { get; init; }
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