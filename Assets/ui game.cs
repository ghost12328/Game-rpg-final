using UnityEngine;
using UnityEngine.UI;

public class ConsoleToUIText : MonoBehaviour
{
    public Text uiText; // Reference to your UI Text component
    private string currentLog = ""; // Current log message to display
    private bool logPending = false; // Flag to track if new log is pending

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        // Set the new log message to display
        currentLog = logString;
        logPending = true; // Mark that a new log is ready to be shown
    }

    void Update()
    {
        // If there is a new log message, show it on the UI
        if (logPending)
        {
            uiText.text = currentLog;
            logPending = false; // After showing the message, reset the flag
        }
    }
}
