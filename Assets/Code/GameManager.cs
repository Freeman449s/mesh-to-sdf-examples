using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour {
    [SerializeField] public long notificationInterval = 100;
    private long _notificationCount = 0;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        _notificationCount++;
        if (_notificationCount >= notificationInterval) {
            _notificationCount = 0;
            Debug.Log(
                $"Game Manager: {Time.frameCount} frames, avg frame time: {Time.realtimeSinceStartupAsDouble / Time.frameCount * 1000} ms");
        }
    }
}