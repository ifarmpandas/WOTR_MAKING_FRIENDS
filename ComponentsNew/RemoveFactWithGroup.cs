﻿using JetBrains.Annotations;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Owlcat.QA.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Serialization;
using UnityEngine;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using static Kingmaker.Blueprints.Area.FactHolder;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("63bedbf5fa6040788ccb3a8ca7dd7e11")]
    public class RemoveFactWithGroup : ContextAction
    {
        [ValidateNotNull]
        [SerializeReference]
        public UnitEvaluator Unit;

        public FeatureGroup featureGroup;

        public override string GetCaption()
        {
            return $"Remove Fact ({featureGroup} from {Unit})";
        }

        public override void RunAction()
        {
            Main.Log("Start");
            var features = new List<Feature>();

            foreach(var feature in base.Target.Unit.Progression.Features)
            {
                if (feature.Blueprint.HasGroup(featureGroup))
                {
                    Main.Log($"Feature Add {feature.Blueprint.name}");
                    features.Add(feature);
                }
            }

            foreach (var fact in features)
            {
                Main.Log($"Fact: {fact.Blueprint.name}");
                if (fact.Blueprint.HasGroup(featureGroup))
                {
                    while (Target.Unit.Progression.Features.HasFact(fact))
                    {
                        Main.Log("Removing Fact");
                        base.Target.Unit.Progression.Features.RemoveFact(fact);
                    }
                }
            }
        }
    }
}
