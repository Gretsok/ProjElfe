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
}
