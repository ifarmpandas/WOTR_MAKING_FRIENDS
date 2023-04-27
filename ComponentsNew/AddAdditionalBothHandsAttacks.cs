﻿using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("b70b2cb73f3f47e58aa0b376366331e9")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [ComponentName("BuffMechanics/Extra Attack")]
    public class AddAdditionalBothHandsAttacks : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAttacksCount>, IRulebookHandler<RuleCalculateAttacksCount>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public void OnEventAboutToTrigger(RuleCalculateAttacksCount evt)
        {
            if (evt.Initiator.Body.PrimaryHand.HasWeapon && !evt.Initiator.Body.PrimaryHand.Weapon.Blueprint.IsNatural)
            {
                for (var i = 2; i <= base.Fact.GetRank(); i++)
                {
                    evt.Result.PrimaryHand.PenalizedAttacks++;
                }
            }
            if (evt.Initiator.Body.SecondaryHand.HasWeapon && !evt.Initiator.Body.SecondaryHand.Weapon.Blueprint.IsNatural)
            {
                for (var i = 2; i <= base.Fact.GetRank(); i++)
                {
                    evt.Result.SecondaryHand.PenalizedAttacks++;
                }
            }
        }

        public void OnEventDidTrigger(RuleCalculateAttacksCount evt)
        {
        }
    }
}
