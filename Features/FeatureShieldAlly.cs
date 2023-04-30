﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features
{
    internal class FeatureShieldAlly
    {
        private static class InternalString
        {
            internal const string Feature = "SummonerShieldAllyFeature";
            internal const string AuraFeature = "SummonerShieldAllyAuraFeature";
            internal static LocalizedString Name = Helpers.ObtainString("SummonerShieldAllyFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerShieldAllyFeature.Description");
        }
        public static void CreateShieldAlly()
        {
            CreateShieldAllyFeature();
            CreateShieldAllyAuraFeature();
        }
        private static void CreateShieldAllyFeature()
        {
            FeatureConfigurator.New(InternalString.Feature, GetGUID.GUIDByName(InternalString.Feature))
                .CopyFrom(FeatureRefs.CavalierSpiritualShield.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddFeatureToPet(GetGUID.GUIDByName("SummonerShieldAllyAuraFeature"), PetTypeExtensions.Eidolon)
                .ConfigureWithLogging();

        }
        private static void CreateShieldAllyAuraFeature()
        {
            FeatureConfigurator.New(InternalString.AuraFeature, GetGUID.GUIDByName(InternalString.AuraFeature))
                .CopyFrom(FeatureRefs.CavalierSpiritualShield.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddAuraFeatureComponent(GetGUID.GUIDByName("SummonerShieldAllyAuraBuff"))
                .ConfigureWithLogging();
        }
    }
}
