﻿using JetBrains.Annotations;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Serialization;
using UnityEngine;
using Kingmaker.Utility;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [AllowMultipleComponents]
    [ComponentName("Add secondary attacks")]
    [AllowedOn(typeof(BlueprintUnit), false)]
    [TypeId("21fd1f974a29beb40bcce671b17b7de4")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    public class AddSecondaryAttacksItemsByRank : UnitFactComponentDelegate<AddSecondaryAttacksData>
    {
        [NotNull]
        [FormerlySerializedAs("Weapon")]
        [SerializeField]
        public BlueprintItemWeaponReference m_Weapon;
        public int limbCount = 1;
        public BlueprintFeatureReference m_feature;

        public override void OnTurnOn()
        {
            for (var i = 1; i <= base.Owner.Progression.Features.GetRank(m_feature.Get()); i++)
            {
                for (var l = 1; l <= limbCount; l++)
                {
                    base.Data.Added.Add(base.Owner.Body.AddAdditionalLimbItem(m_Weapon, isSecondary: true));
                }
            }
            base.Owner.Body.FixAdditionalLimbs();
        }

        public override void OnTurnOff()
        {
            base.Data.Added.ForEach(base.Owner.Body.RemoveAdditionalLimb);
            base.Data.Added.Clear();
        }
    }
}
