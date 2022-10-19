/*
********************************************************************
* ActionChain - NEEEU Spaces GmbH
*
* This files is part of the ActionChain package.
* 
* Written by Ingo Randolf, 2021 - 2022
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*********************************************************************
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NEEEU.ActionChain
{
    public class ActionChainIf : ActionChainBase, IActionChainTrigger
    {
        [SerializeField] ActionChainDecider decider;
        [SerializeField] ActionChainElse elseBranch;

        public void Trigger()
        {
            // figure out condition
            if (decider != null &&
                decider.Decide())
            {
                // continue with if-branch: all the children
                // just trigger next
                _TriggerNext();
            }
            else if (elseBranch)
            {
                elseBranch.TriggerNext();
            }
            else
            {
                TriggerParentNext();
            }
        }
    }
}