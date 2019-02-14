
using System;
using System.Collections;
using UnityEditor.Experimental.UIElements;
using UnityEngine;

public class CustomCoroutine : MonoBehaviour
{
    private float _operatingTime;
    private float _elapsedTime;
    private float _delayTime;

    private void Awake()
    {
        _operatingTime = 0;
        _elapsedTime = 0;
        _delayTime = 0;
    }

    public void OnPulling()
    {
        _operatingTime = 0;
        _elapsedTime = 0;
        _delayTime = 0;
    }

    /* legacy
    /// <summary>
    /// 
    /// </summary>
    /// <param name="variable">변화를 줄 변수(ex. vector, int)</param>
    /// <param name="start">변수의 시작 값</param>
    /// <param name="end">변수의 끝 값</param>
    /// <param name="frame">코루틴이 몇번에 거쳐서 실행될 것인지</param>
    /// <param name="coroutineRunTime">코루틴이 처리되는 시간(Speed) > 0</param>
    /// <typeparam name="T"></typeparam>
    public static void RunCoroutine<T>(ref T variable, T start, T end, int frame, float coroutineRunTime) where T : IComparable 
    {
        if (coroutineRunTime <= 0) throw new UnityException("Coroutine Time Under 0 : " + coroutineRunTime.ToString());
        if (frame <= 0) throw new UnityException("Coroutine Frame Under 0 : " + frame.ToString());
        var delayOfEvent = coroutineRunTime/frame;

        MakeCoroutine(out variable, start, end, frame, delayOfEvent);
    }

    private static IEnumerator MakeCoroutine<T>(out T variable, T start, T end, int frame, float delayOfEvent) where T : IComparable 
    {
//        switch (variable.GetType())
//        {
//            default:
//                throw new UnityException("Undefined Type : " + variable.GetType());
//        }
        if (variable is int
            || variable is float
            || variable is double
            || variable is short
        )
        {
            var s = (int)(object) start;
            for (var i = 0; i < frame; i++)
            {
                variable = (T)(object)(s / frame);
            }

        }

        yield return null;
    }
    */
}