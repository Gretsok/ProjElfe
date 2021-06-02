using System;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;

namespace Tween
{
    [System.Serializable]
    public abstract class ATween : MonoBehaviour
    {
        public enum EStopType
        {
            ResetToBeginning,
            StayOnPlace,
            Finish
        }

        #region Callbacks
        [SerializeField]
        private UnityEvent m_onStarted = null;
        [SerializeField]
        private UnityEvent m_onFinish = null;

        public Action<ATween> m_onTweenStarted = null;
        public Action<ATween> m_onTweenFinish = null;
        #endregion

        #region Infos
        private bool m_isPlaying = false;
        private bool m_isGoingForward = true;

        public bool IsPlaying => m_isPlaying;
        public bool IsGoingForward => m_isGoingForward;
        #endregion

        #region Basic Params
        protected Transform m_target = null;
        [SerializeField]
        private bool m_playOnAwake = false;
        [SerializeField]
        protected float m_tweenDuration = 1f;
        [SerializeField]
        protected ELoopType m_loopType = ELoopType.Once;
        [SerializeField]
        protected AnimationCurve m_tweenCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        public bool PlayOnAwake => m_playOnAwake;
        public float TweenDuration => m_tweenDuration;
        public ELoopType LoopType => m_loopType;
        #endregion

        private Coroutine m_tweenRoutine = null;

        private ATween[] m_attachedTweens = null;

        private void Awake()
        {
            m_attachedTweens = gameObject.GetComponents<ATween>();
            if(m_playOnAwake)
            {
                Play();
            }
        }

        protected virtual void Play(bool forward = true)
        {
            if (m_target == null)
            {
                m_target = transform;
            }
            if (m_tweenRoutine != null)
            {
                StopCoroutine(m_tweenRoutine);
            }
            m_isGoingForward = forward;
            if(m_isGoingForward)
            {
                SetStartingValues();
            }
            else
            {
                SetFinalValues();
            }
            
            m_isPlaying = true;
            m_tweenRoutine = StartCoroutine(TweenRoutine());
            m_onStarted?.Invoke();
            m_onTweenStarted?.Invoke(this);
        }

        public void StartTween(bool forward = true)
        {
            if(!m_isPlaying && Application.isPlaying)
            {
                Play(forward);
            }
        }

        public virtual void StartAllAttachedTweens()
        {
            for (int i = 0; i < m_attachedTweens.Length; ++i)
            {
                m_attachedTweens[i].StartTween();
            }
        }

        public virtual void Stop(EStopType a_stopType = EStopType.ResetToBeginning)
        {
            if (m_target == null)
            {
                m_target = transform;
            }
            
            if (m_tweenRoutine != null)
            {
                StopCoroutine(m_tweenRoutine);
            }
            m_tweenRoutine = null;
            m_isPlaying = false;

            switch (a_stopType)
            {
                case EStopType.ResetToBeginning:
                    ResetValues();
                    break;
                case EStopType.Finish:
                    if(m_isGoingForward)
                    {
                        SetFinalValues();
                    }
                    else
                    {
                        SetStartingValues();
                    }
                    break;
                case EStopType.StayOnPlace:
                default:
                    break;
            }
        }

        public virtual void StopAllAttachedTweens(EStopType a_stop = EStopType.ResetToBeginning)
        {
            if(m_attachedTweens == null)
            {
                return;
            }
            for(int i = 0; i < m_attachedTweens.Length; ++i)
            {
                m_attachedTweens[i].Stop(a_stop);
            }
        }


        private IEnumerator TweenRoutine()
        {
            float startingTime = Time.time;
            while (Time.time - startingTime < m_tweenDuration)
            {

                if (m_isGoingForward)
                {
                    ManageTween(Mathf.Clamp01(m_tweenCurve.Evaluate(Mathf.Clamp01((Time.time - startingTime) / m_tweenDuration))));
                }
                else
                {
                    ManageTween(1 - Mathf.Clamp01(m_tweenCurve.Evaluate(Mathf.Clamp01((Time.time - startingTime) / m_tweenDuration))));
                }
                yield return null;
            }
            Stop(EStopType.Finish);
            #region Finish Management
            bool hasFinished = false;
            bool nextIsForward = true;
            switch(m_loopType)
            {
                case ELoopType.Once:
                    hasFinished = true;
                    break;
                case ELoopType.Loop:
                    nextIsForward = m_isGoingForward;
                    break;
                case ELoopType.BackAndForth:
                    if(m_isGoingForward)
                    {
                        nextIsForward = false;
                    }
                    else
                    {
                        hasFinished = true;
                    }
                    break;
                case ELoopType.PingPong:
                    nextIsForward = !m_isGoingForward;
                    break;
            }
            if(hasFinished)
            {
                m_onFinish?.Invoke();
                m_onTweenFinish?.Invoke(this);
            }
            else
            {
                if(nextIsForward)
                {
                    Play(true);
                }
                else
                {
                    Play(false);
                }
            }
            #endregion
            yield return null;
        }

        protected virtual void SetStartingValues()
        {

        }

        protected virtual void SetFinalValues()
        {

        }

        public virtual void ResetValues()
        {
            m_isGoingForward = true;
            SetStartingValues();
        }

        protected virtual void ManageTween(float interpolationValue)
        {

        }

    }

    public enum ELoopType
    {
        Once,
        Loop,
        BackAndForth,
        PingPong
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(ATween), true)]
    public class ATweenEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if(GUILayout.Button("Start tween !"))
            {
                (target as ATween).StartTween();
            }

            if (GUILayout.Button("Play all attached tweens !"))
            {
                (target as ATween).StartAllAttachedTweens();
            }

            if (GUILayout.Button("Stop all attached tweens !"))
            {
                (target as ATween).StopAllAttachedTweens();
            }

            if(GUILayout.Button("Reset !"))
            {
                (target as ATween).ResetValues();
            }
        }
    }
#endif
}