﻿using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic;
using Kingmaker.Utility;
using Kingmaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Serialization;
using UnityEngine;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("2c6eaa7a71104deaa86bff2868ea2fc8")]
    public class ContextActionAddFeatureIfPrevious : ContextAction
    {
        [SerializeField]
        [FormerlySerializedAs("PermanentFeature")]
        public BlueprintFeatureReference[] m_PermanentFeatures;

        public override string GetCaption()
        {
            return "Add permanent feature.";
        }

        public override void RunAction()
        {
            if (base.Target.Unit == null)
            {
                PFLog.Default.Error(this, "Invalid target for effect '{0}'", GetType().Name);
                return;
            }

            FeatureCollection features = base.Target.Unit.Descriptor.Progression.Features;
            for (var i = m_PermanentFeatures.Length-1; i >= 0; i--)
            {
                if (i == 0)
                {
                    if (!features.HasFact(m_PermanentFeatures[i].Get()))
                    {
                        features.AddFeature(m_PermanentFeatures[i].Get());
                        return;
                    }
                }
                else
                {
                    if (features.HasFact(m_PermanentFeatures[i-1].Get()))
                    {
                        features.AddFeature(m_PermanentFeatures[i].Get());
                        return;
                    }
                }
            }
        }
    }
}
