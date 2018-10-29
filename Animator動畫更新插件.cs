using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
public class AnimatorManager{
    

    [MenuItem("AnimatorManager/UpdateAnimatorTransition")]
    static void UpdateAnimator()
    {
        OperationAnimatorSystem OperationAnimatorSystem = new OperationAnimatorSystem();
        OperationAnimatorSystem.InitializeClass();

        OperationAnimatorSystem.ReadAll_ClipNameAndAddParameterToAnimatorBorad();


        OperationAnimatorSystem.MakeAllStateToAnimatorTransitionAndCondition();
    }
    class OperationAnimatorSystem
    {
        AnimatorController GameSceneAnimatorController = new AnimatorController();
        AnimatorControllerParameter parameter = new AnimatorControllerParameter();
        
        AnimatorStateMachine AllAnimationState;
        //初始化
        public void InitializeClass()
        {
            LoadGameAnimatorControllerFromResourceFolderToEditParameter();

            //取得所有的動畫狀態
            this.AllAnimationState = GetAllAnimationState();

            ClearAllParameterOfAnimator();
            ClearAllAnimatorStatToDefalutTransition();
            ClearAllAnimatorDefalutToStateTransition();
        }
        public void MakeAllStateToAnimatorTransitionAndCondition()
        {
            int AnimatorStateIndex = 0;
            foreach (ChildAnimatorState AnimationState in this.AllAnimationState.states)
            {
                var AnimatorStateToDefalutTransition = AnimationState.state.AddTransition(this.AllAnimationState.defaultState, false);
                var AnimatorDefalutToStateTransition = this.AllAnimationState.defaultState.AddTransition(AnimationState.state, false);
               
                ChangeStateToStateDuration(AnimatorStateToDefalutTransition, 1.5f);
                SetStateToStateHasExitTimeBool(AnimatorStateToDefalutTransition, true);

                AnimatorDefalutToStateTransition.AddCondition(AnimatorConditionMode.If, 0,this.GameSceneAnimatorController.animationClips[AnimatorStateIndex].name);
                ChangeStateToStateDuration(AnimatorDefalutToStateTransition, 1.5f);

                AnimatorStateIndex++;
            }
        }
        public void ChangeStateToStateDuration(AnimatorStateTransition AnimatorStateTransition,float DurationTime)
        {
            AnimatorStateTransition.duration = DurationTime;
        }

        public void SetStateToStateHasExitTimeBool(AnimatorStateTransition AnimatorStateTransition, bool HasExitTimeCondition)
        {
            AnimatorStateTransition.hasExitTime = HasExitTimeCondition;
        }
        public void ClearAllAnimatorStatToDefalutTransition()
        {
            foreach (ChildAnimatorState AnimationState in this.AllAnimationState.states)
            {
                foreach (AnimatorStateTransition StateTransition in this.AllAnimationState.defaultState.transitions)
                {
                    AnimationState.state.RemoveTransition(StateTransition);
                }
            }
        }

        public void ClearAllAnimatorDefalutToStateTransition()
        {
            foreach (ChildAnimatorState AnimationState in this.AllAnimationState.states)
            {
                foreach (AnimatorStateTransition StateTransition in AnimationState.state.transitions)
                {
                    this.AllAnimationState.defaultState.RemoveTransition(StateTransition);
                }
            }
        }

      
        public void ClearAllParameterOfAnimator()
        {
            foreach (AnimatorControllerParameter AnimatorParameter in this.GameSceneAnimatorController.parameters)
            {
                this.GameSceneAnimatorController.RemoveParameter(AnimatorParameter);
            }
        }
        public AnimationClip[] GetAllAnimationClip()
        {
            return this.GameSceneAnimatorController.animationClips;
        }

        public void ReadAll_ClipNameAndAddParameterToAnimatorBorad()
        {
            foreach (AnimationClip Clip in this.GameSceneAnimatorController.animationClips)
            {
                AddParameterToAnimatorBoardSetNameAndType(Clip.name, AnimatorControllerParameterType.Trigger);
                AddParameterToAnimator();
            }
        }
        public AnimatorStateMachine GetAllAnimationState()
        {
            return this.GameSceneAnimatorController.layers[0].stateMachine;
        }

        public void AddParameterToAnimatorBoardSetNameAndType(string ParameterName, AnimatorControllerParameterType AnimatorType)
        {
            parameter.type = AnimatorType;
            parameter.name = ParameterName;
            this.parameter = parameter;
        }

        public void AddParameterToAnimator()
        {
            this.GameSceneAnimatorController.AddParameter(this.parameter);
        }
        public void LoadGameAnimatorControllerFromResourceFolderToEditParameter()
        {
            GameSceneAnimatorController = Resources.Load("Animator/教室人物動作控制圖") as AnimatorController;
            this.GameSceneAnimatorController = GameSceneAnimatorController;
        }
    }

    
}
