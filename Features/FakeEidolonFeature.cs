﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features
{
    internal class FakeEidolonFeature
    {
        private static class InternalString
        {
            internal const string Feature = "FakeEidolonFeature";
            internal static LocalizedString Name = Helpers.ObtainString("FakeEidolonFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("FakeEidolonFeature.Description");
        }
        public static void CreateFakeEidolon()
        {
            CreateFakeEidolonFeature();
        }
        public static void CreateFakeEidolonFeature()
        {
            AddEidolon addEidolon = new AddEidolon()
            {
                m_Pet = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.EidolonAirElemental),
                ProgressionType = PetProgressionTypeExtensions.EidolonProgression,
                m_UseContextValueLevel = false,
                m_LevelRank = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.EidolonRankFeature),
                Type = PetTypeExtensions.Eidolon,
                m_ForceAutoLevelup = false
            };
            Kingmaker.Blueprints.Classes.BlueprintFeature fakeEidolon = FeatureConfigurator.New(InternalString.Feature, GetGUID.FakeEidolonFeature)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .AddFeatureOnApply(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.EidolonProgression))
                .AddFeatureOnApply(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.EidolonRankFeature))
                .SetIcon(AbilityRefs.ElementalBodyIAir.Reference.Get().m_Icon)
                .SetRanks(1)
                .SetReapplyOnLevelUp(true)
                .SetIsClassFeature(true)
                .Configure();

            fakeEidolon.AddComponents(new[] { addEidolon });

        }
    }
}
