using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;
using UnityEngine.UI;

public class RunTimer : MonoBehaviour
{
    [SerializeField] TMP_Text runTimerText;
    [SerializeField] VerticalLayoutGroup splits;
    Stopwatch currentRun = new Stopwatch();
    Stopwatch timeSinceLastSplit = new Stopwatch();

    public void Split(string name = "")
    {
        var newSplit = Instantiate(runTimerText, splits.transform);
        newSplit.text = $"{name} - {newSplit.text}\n {timeSinceLastSplit.Elapsed}";
        timeSinceLastSplit.Restart();
    }

    void Update()
    {
        if (!currentRun.IsRunning && Input.anyKeyDown)
        {
            currentRun.Start();
            timeSinceLastSplit.Start();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space)) { Split("Level 1"); }

            runTimerText.text = currentRun.Elapsed.ToString("hh\\:mm\\:ss\\.ffff");
            //runTimerText.text = $"{currentRun.Elapsed.TotalHours}:{currentRun.Elapsed.TotalMinutes}:{currentRun.Elapsed.TotalSeconds}:{currentRun.Elapsed.TotalMilliseconds}";
        }

    }
}
