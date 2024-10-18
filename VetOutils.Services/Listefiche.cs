// GestionnaireFiches.cs
using System;
using System.Collections.Generic;

namespace VetOutils.Services;

public class Listefiche
{
    // Liste d'objets Fiche
    public List<Fiche> _listefiche;
    
    public void InitialisationListeFiche()
    {
        // Initialisation de la liste de fiches
        _listefiche = new List<Fiche>();
    }

    public void AjoutListeFiches()
    {
        Fiche fiche1 = new Fiche
        {
            Id = 1,
            Titre = "Fiche numéro 1",
            Description = "Description de la fiche 1",
            DateCreation = DateTime.Now,
            DateModification = DateTime.Now,
            Etiquettes = new List<Etiquette>()
            {
                Etiquette.FCO,
                Etiquette.Brucellose
            }
        };
        Fiche fiche2 = new Fiche
        {
            Id = 2,
            Titre = "Fiche numéro 2",
            Description = "Description de la fiche 2",
            DateCreation = DateTime.Now,
            DateModification = DateTime.Now,
            Etiquettes = new List<Etiquette>()
            {
                Etiquette.FCO,
                Etiquette.Brucellose
            }
        };
        Fiche fiche3 = new Fiche
        {
            Id = 3,
            Titre = "Fiche numéro 3",
            Description = "Description de la fiche 3",
            DateCreation = DateTime.Now,
            DateModification = DateTime.Now,
            Etiquettes = new List<Etiquette>()
            {
                Etiquette.FCO,
                Etiquette.Brucellose,
                Etiquette.Ovin
            }
        };
        Fiche fiche4 = new Fiche
        {
            Id = 4,
            Titre = "Fiche numéro 4",
            Description = "Description de la fiche 4",
            DateCreation = DateTime.Now,
            DateModification = DateTime.Now,
            Etiquettes = new List<Etiquette>()
            {
                Etiquette.FCO,
                Etiquette.Brucellose,
            }
        };
        _listefiche.Add(fiche1);
        _listefiche.Add(fiche2);
        _listefiche.Add(fiche3);
        _listefiche.Add(fiche4);
    }
}