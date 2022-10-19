using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGMusicScript: MonoBehaviour {

private static BGMusicScript bgmInstance;

void Awake(){
    DontDestroyOnLoad(this);

    if (bgmInstance == null) {
        bgmInstance = this;
    } else {
        Destroy(gameObject); // Used Destroy instead of DestroyObject
    }
}
 }