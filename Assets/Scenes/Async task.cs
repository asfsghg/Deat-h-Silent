using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncLessonTask : MonoBehaviour
{
    void Start()
    {
        PrintCounterAsync(5);
        PrintCounter();
        Debug.Log(IsPositive(-4));
        StartCoroutine(PrintCounterCoroutine());
    }

    public void PrintCounter()
    {
        for (int i = 3; i > 0; i--)
        {
            Debug.Log(i);
        }
    }



    public IEnumerator PrintCounterCoroutine()
    {
        for (int i = 3; i > 0; i--)
        {
            yield return new WaitForSeconds(2f);
            Debug.Log(i);
        }
    }


    
    
    async Task<int> PrintCounterAsync(int i)
    {
        await Task.Delay(2000);
        Debug.Log(i);
        return i;
    }

    public bool IsPositive(int i)
    {
        Debug.Log("Calculating....");

        Debug.Log("Almost done...");

        return i > 0;
    }

    async Task<bool> IsPositiveAsync(bool i)
    {
        Debug.Log("Calculating....");
        Debug.Log("Almost done...");
        return i;
    }

}