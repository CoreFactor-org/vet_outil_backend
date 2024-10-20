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

    /// <summary>
    /// Le lien (url) vers la ressource et le format (Pdf/Word/...) de cette ressource
    /// </summary>
    public DetailLien? LienSource { get; set; }

    public required string Titre { get; init; }
    public string? Description { get; init; }
    public HashSet<Etiquette> Etiquettes { get; init; } = [];
    public FormatAffichageSngtvStandard? Standard { get; init; }
}

public class DetailLien
{
    public required string Url { get; init; }
    public required FormatSource Format { get; init; }
}

public enum FormatSource
{
    PDF,
    Word,
}

public enum Etiquette
{
    Ovin,
    Brucellose,
    FCO,
    FievreQ
}

public class FormatAffichageSngtvStandard
{
    
}