﻿using UnityEngine;
using System.Collections;

namespace com.iuixi.FreeJeck
{
	public class JumpState : StateMachineBehaviour
	{
		// OnStateEnter is called before OnStateEnter is called on any state inside this state machine
		//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//
		//}

		// OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
		override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (stateInfo.normalizedTime >= 0.99f) {
				animator.SetBool ("InJump", false);
				animator.SetFloat ("JumpType", 0);
			}
		}

		// OnStateExit is called before OnStateExit is called on any state inside this state machine
		override public void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animator.SetBool ("InJump", false);
			animator.SetFloat ("JumpType", 0);
		}

		// OnStateMove is called before OnStateMove is called on any state inside this state machine
		//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//
		//}

		// OnStateIK is called before OnStateIK is called on any state inside this state machine
		//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//
		//}

		// OnStateMachineEnter is called when entering a statemachine via its Entry Node
		override public void OnStateMachineEnter (Animator animator, int stateMachinePathHash)
		{
			animator.SetBool ("InJump", true);
		}

		//	 OnStateMachineExit is called when exiting a statemachine via its Exit Node
		override public void OnStateMachineExit (Animator animator, int stateMachinePathHash)
		{
			animator.SetBool ("InJump", false);
			animator.SetFloat ("JumpType", 0);
		}
	}
}
