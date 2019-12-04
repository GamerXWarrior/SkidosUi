using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo : MonoBehaviour {

    public Animation logo;
    public AudioClip whoosh;
    public AudioSource source;
    public GameObject logoView;
    public GameObject scrollView;

    // Start is called before the first frame update
    IEnumerator Start () {
        source.clip = whoosh;
        source.Play ();
        logo.Play ();
        yield return new WaitForSeconds (source.clip.length + 1);
        logoView.SetActive (false);
        scrollView.SetActive (true);
    }

    // Update is called once per frame
    void Update () {

    }
}