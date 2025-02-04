﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using System;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static WOTR_MAKING_FRIENDS.Enums.EnumsEidolons;

namespace WOTR_MAKING_FRIENDS.Progressions.EidolonProgressions
{
    internal class EidolonBaseProgression
    {
        internal static class IClass
        {
            internal const string Progression = "EidolonBaseProgression";
            internal static LocalizedString Name = Helpers.ObtainString("EidolonBaseProgression.Name");
            internal static LocalizedString Description = Helpers.ObtainString("EidolonBaseProgression.Description");
            internal static string ExtraEvolutionPoolFeature = GetGUID.GUIDByName("ExtraEvolutionPoolFeature");
            internal static string AddEvolutionPoolResource = GetGUID.GUIDByName("AddEvolutionPointsFeature");
            internal static string EvolutionStatBonus = GetGUID.GUIDByName("EidolonStatBonus");
            internal static string AddMaxAttacksStepFeature = GetGUID.GUIDByName("AddMaxAttacksStepFeature");
        }
        public static void CreateEidolonBaseProgression()
        {
            LevelEntryBuilder entries = LevelEntryBuilder.New()
                                .AddEntry(1,
                                         GetGUID.GUIDByName("AddEvolutionPointsFeature"),
                                         GetGUID.GUIDByName("AddMaxAttacksFeature"),
                                         GetGUID.GUIDByName("EvolutionBaseAbilitiesFeature"),
                                         GetGUID.GUIDByName("EidolonSubtypeSelectionFeature"),
                                         GetGUID.GUIDByName("EidolonStartingEvolutionsFeature"),
                                         FeatureRefs.ImprovedUnarmedStrike.Reference.Get().AssetGuid
                                         )
                                .AddEntry(2, IClass.ExtraEvolutionPoolFeature, IClass.EvolutionStatBonus)
                                .AddEntry(3, FeatureRefs.Evasion.Cast<BlueprintFeatureBaseReference>().Reference, IClass.ExtraEvolutionPoolFeature)
                                .AddEntry(4, IClass.ExtraEvolutionPoolFeature, IClass.AddMaxAttacksStepFeature)
                                .AddEntry(5, IClass.ExtraEvolutionPoolFeature, IClass.EvolutionStatBonus)
                                .AddEntry(6, FeatureRefs.AnimalCompanionDevotion.Cast<BlueprintFeatureBaseReference>().Reference, IClass.ExtraEvolutionPoolFeature)
                                .AddEntry(7, IClass.ExtraEvolutionPoolFeature, IClass.EvolutionStatBonus)
                                .AddEntry(9, FeatureRefs.Multiattack.Cast<BlueprintFeatureBaseReference>().Reference, IClass.ExtraEvolutionPoolFeature, IClass.AddMaxAttacksStepFeature)
                                .AddEntry(10, IClass.ExtraEvolutionPoolFeature, IClass.EvolutionStatBonus)
                                .AddEntry(11, IClass.ExtraEvolutionPoolFeature)
                                .AddEntry(12, IClass.EvolutionStatBonus)
                                .AddEntry(13, IClass.ExtraEvolutionPoolFeature)
                                .AddEntry(14, FeatureRefs.ImprovedEvasion.Cast<BlueprintFeatureBaseReference>().Reference, IClass.ExtraEvolutionPoolFeature, IClass.AddMaxAttacksStepFeature)
                                .AddEntry(15, IClass.ExtraEvolutionPoolFeature, IClass.EvolutionStatBonus)
                                .AddEntry(17, IClass.ExtraEvolutionPoolFeature, IClass.EvolutionStatBonus)
                                .AddEntry(18, IClass.ExtraEvolutionPoolFeature)
                                .AddEntry(19, IClass.ExtraEvolutionPoolFeature, IClass.AddMaxAttacksStepFeature)
                                .AddEntry(20, IClass.EvolutionStatBonus, GetGUID.GUIDByName("GrandEidolonFeature"));

            var progression = ProgressionConfigurator.New(IClass.Progression, GetGUID.GUIDByName("EidolonBaseProgression"))
                                                     .SetLevelEntries(entries)
                                                     .SetIsClassFeature(true)
                                                     .SetRanks(1)
                                                     .SetClasses(GetGUID.GUIDByName("SummonerClass"));

            foreach (var eidolonBaseForm in Enum.GetValues(typeof(EnumsEidolonBaseForm)))
            {
                try
                {
                    var characterClassName = "Eidolon" + Enum.GetName(typeof(EnumsEidolonBaseForm), eidolonBaseForm) + "Class";
                    var characterClassGuid = GetGUID.GUIDByName(characterClassName);
                    progression.AddToClasses(BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClassGuid));
                }
                catch { }
            }

            progression.ConfigureWithLogging();

        }
    }
}
