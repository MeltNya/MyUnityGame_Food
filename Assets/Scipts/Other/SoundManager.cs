using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : BaseManager<SoundManager>
{
    GameObject soundObj = null;
    public AudioSource audioSource;
    AudioClip atkClip=ResMgr.GetInstance().Load<AudioClip>("music/PlayerAttack");
    AudioClip getClip=ResMgr.GetInstance().Load<AudioClip>("music/get") ;
    AudioClip hitClip = ResMgr.GetInstance().Load<AudioClip>("music/hit");
    AudioClip startClip = ResMgr.GetInstance().Load<AudioClip>("music/start");
    AudioClip clickClip= ResMgr.GetInstance().Load<AudioClip>("music/click");
    AudioClip bagClip = ResMgr.GetInstance().Load<AudioClip>("music/bag");
    AudioClip succClip = ResMgr.GetInstance().Load<AudioClip>("music/succ");
    // Start is called before the first frame update
    void Start()
    {
       // audioSource = GetComponent<AudioSource>();
      //  atkClip = 
       // getClip = ;
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    public void PlaySuccClip()
    {
        PlaySound(succClip);
    }
    public void PlayBagClip()
    {
        PlaySound(bagClip);
    }
    public void PlayClickClip()
    {
        PlaySound(clickClip);
    }
    public void PlayStartClip()
    {
        PlaySound(startClip);
    }
    public void PlayAtckClip()
    {
        PlaySound(atkClip);
    }
    public void PlayGetClip()
    {
        PlaySound(getClip);
    }
    public void PlayHitClip()
    {
        PlaySound(hitClip);
    }
    void PlaySound(AudioClip clip)
    {
        if (soundObj == null)
        {
            soundObj = new GameObject();
            soundObj.name = "SoundObject";
        }
        audioSource = soundObj.AddComponent<AudioSource>();
        audioSource.PlayOneShot(clip);
        
    }
}
