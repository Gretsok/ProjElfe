using ProjElf.CombatController;
using ProjElf.ProceduraleGeneration;

public class ProjElfUtils
{
    public static string GetDifficultyLabel(EDunjeonDifficulty dunjeonDifficulty)
    {
        switch(dunjeonDifficulty)
        {
            case EDunjeonDifficulty.RescuerI:
                return "rescuer1";
            case EDunjeonDifficulty.RescuerII:
                return "rescuer2";
            case EDunjeonDifficulty.RescuerIII:
                return "rescuer3";
            case EDunjeonDifficulty.LifeSaverI:
                return "lifesaver1";
            case EDunjeonDifficulty.LifeSaverII:
                return "lifesaver2";
            case EDunjeonDifficulty.LifeSaverIII:
                return "lifesaver3";
            case EDunjeonDifficulty.AbsoluteMasterGuardian:
                return "absolutemasterguardian";
            default:
                return "";
        }
    }

    public static string GetDifficultyKey(EDunjeonDifficulty dunjeonDifficulty)
    {
        switch (dunjeonDifficulty)
        {
            case EDunjeonDifficulty.RescuerI:
                return "DIFFICULTY_RESCUER_I";
            case EDunjeonDifficulty.RescuerII:
                return "DIFFICULTY_RESCUER_II";
            case EDunjeonDifficulty.RescuerIII:
                return "DIFFICULTY_RESCUER_III";
            case EDunjeonDifficulty.LifeSaverI:
                return "DIFFICULTY_LIFESAVER_I";
            case EDunjeonDifficulty.LifeSaverII:
                return "DIFFICULTY_LIFESAVER_II";
            case EDunjeonDifficulty.LifeSaverIII:
                return "DIFFICULTY_LIFESAVER_III";
            case EDunjeonDifficulty.AbsoluteMasterGuardian:
                return "DIFFICULTY_ABSOLUTE_MASTER_GUARDIAN";
            default:
                return "";
        }
    }

    public static string GetPlayerStatKey(EPlayerStats l_playerStats)
    {
        switch(l_playerStats)
        {
            case EPlayerStats.AttackSpeed:
                return "STAT_FORCE";
            case EPlayerStats.LifePoints:
                return "STAT_LIFEPOINTS";
            case EPlayerStats.MovementSpeed:
                return "STAT_MOVEMENTSPEED";
            case EPlayerStats.MagicalArmor:
                return "STAT_MAGICAL_ARMOR";
            case EPlayerStats.PhysicalArmor:
                return "STAT_PHYSICAL_ARMOR";
            case EPlayerStats.MagicalDamageMultiplierIncrement:
                return "STAT_MAGICAL_DAMAGE_MULTIPLIER_INCREMENT";
            case EPlayerStats.PhysicalDamageMultiplierIncrement:
                return "STAT_PHYSICAL_DAMAGE_MULTIPLIER_INCREMENT";
            default:
                return "";
        }
    }

    public static bool IsStatAnInt(EPlayerStats l_playerStats)
    {
        switch(l_playerStats)
        {
            case EPlayerStats.AttackSpeed:
            case EPlayerStats.MovementSpeed:
            case EPlayerStats.MagicalDamageMultiplierIncrement:
            case EPlayerStats.PhysicalDamageMultiplierIncrement:
                return false;
            default:
                return true;
        }
    }

    public static string GetInSentenceSuffixForKeys()
    {
        return "_IN_SENTENCE";
    }

    public static string GetDunjeonTypeKey(EDunjeonType dunjeonType)
    {
        switch(dunjeonType)
        {
            case EDunjeonType.Castle:
                return "DUNJEON_TYPE_CASTLE";
            case EDunjeonType.Cave:
                return "DUNJEON_TYPE_CAVE";
            default:
                return "";
        }
    }

    public static string GetDamageTypeKey(EDamageType l_damageType)
    {
        switch(l_damageType)
        {
            case EDamageType.Magical:
                return "DAMAGE_TYPE_MAGICAL";
            case EDamageType.Physical:
                return "DAMAGE_TYPE_PHYSICAL";
            default:
                return "";
        }
    }

    public static string GetYesOrNoKey(bool isYes)
    {
        if(isYes)
        {
            return "GENERIC_YES";
        }
        else
        {
            return "GENERIC_NO";
        }
    }
}
