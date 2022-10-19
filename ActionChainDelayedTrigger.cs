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
    public class ActionChainDelayedTrigger : ActionChainTrigger
    {
        [SerializeField] float time = 1;

        //
        Coroutine coroutine = null;

        void Cancel()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }

        void Trigger(float seconds)
        {
            Cancel();
            coroutine = StartCoroutine(_WaitSeconds(seconds));
        }

        IEnumerator _WaitSeconds(float time)
        {
            yield return new WaitForSeconds(time);
            base.Trigger();
        }

        public override void Trigger()
        {
            Trigger(time);
        }
    }
}