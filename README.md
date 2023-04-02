# Description
The animals of the forest have been captured! Use the portal to explore dungeons to free them all and unlock the weapons along the way!
Saving animals grants you stats bonus which replaces the classic level mechanic.

# About
This project was made by three programmer students without artists.

# Technical content
RPG made with :
- Third person controller
- Three types of weapon (Swords, bows and grimoires)
- Inventory Management (Including items' reforging and selling)
- Stats enhancing
- Procedurally generated dungeons
- Dungeons unlocking
- Short ranged and close ranged AIs
- Save System
- UI System
- Audio System
- Localization System
- State machines
- Mouse&Keyboard and Gamepad handling (Gameplay + UI)

# Requirements
Unity Version : 2019.4.12f1

# Development GuideLines
## Encapsulation
-Il faut mettre les variables en private autant que possible. Si on en a besoin depuis l'inpector, on ajoute le tag [SerializeField] devant.
-Toutes les classes d'une même fonctionalité doivent être regroupées dans un même namespace. Le namespace doit être "ProjElf.NomFonctionalité".

## SOLID
-Chaque classe doit avoir une et une seule responsabilité.

## Commentaires et annotations
-Commenter chaque méthode en mettant /// .
-Ajouter des [Tooltip("")] aux attributs visibles dans l'inspector.


# Normes de nommages
Les dossiers des modules commence par M_ .
Les classes abstraites commence par A.
Les énumérations commence par E.
Les interfaces commence par I.



