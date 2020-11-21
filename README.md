# ProjElfe
Un jeu où tout le monde s'appelle Francis. Ou peut-être que pas du tout en fait.

# Development GuideLines
## Encapsulation
-Il faut mettre les variables en private autant que possible. Si on en a besoin depuis l'inpector, on ajoute le tag [SerializeField] devant.
-Toutes les classes d'une même fonctionalité doivent être regroupées dans un même namespace. Le namespace doit être "ProjElf.NomFonctionalité".

## SOLID
-Chaque classe doit avoir une et une seule responsabilité.

## Commentaires et annotations
-Commenter chaque méthode en mettant /// .
-Ajouter des [Tooltip("")] aux attributs visibles dans l'inspector.