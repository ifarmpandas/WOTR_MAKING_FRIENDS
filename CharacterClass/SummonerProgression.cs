﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.CharacterClass
{
    internal class SummonerProgression
    {
        private static class Strings
        {
            public const string SummonerProgression = "SummonerProgression";
        }
        public static BlueprintProgression Initialize()
        {
            SummonerProficiencies.Initialize();
            SummonerSecondSpellbook.Initialize();

            LevelEntryBuilder entries = LevelEntryBuilder.New()
                    .AddEntry(1, GetGUID.SummonerProficiencies, GetGUID.SummonerSecondSpellbookFeat, GetGUID.SummonerLifeLinkFeature, GetGUID.FakeEidolonFeature)
                    .AddEntry(2, GetGUID.SummonerBondedSensesFeature)
                    .AddEntry(4, GetGUID.SummonerShieldAllyFeature)
                    .AddEntry(6, GetGUID.SummonerMakersCallFeature)
                    .AddEntry(8, GetGUID.SummonerTranspositionFeature)
                    .AddEntry(12, GetGUID.SummonerShieldAllyGreaterFeature);

            return ProgressionConfigurator.New(Strings.SummonerProgression, GetGUID.SummonerProgression)
                .SetAllowNonContextActions(false)
                .SetHideInUI(false)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .SetRanks(1)
                .SetReapplyOnLevelUp(false)
                .SetIsClassFeature(false)
                .SetForAllOtherClasses(false)
                .SetLevelEntries(entries)
                .Configure();
        }
    }
}
