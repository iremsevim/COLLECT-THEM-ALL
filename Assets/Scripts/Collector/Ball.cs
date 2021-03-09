using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Ball : MonoBehaviour
{
    private bool isTouched;

    private void OnCollisionEnter(Collision collision)
    {
        if (isTouched) return;
        if(collision.gameObject.GetComponent<Evalator>())
        {
            AudioManager.Instance.PlayAudio("ballhit");
            isTouched = true;
            collision.gameObject.GetComponent<Evalator>().TouchBall();
            ParticleManager.Instance.ShowParticle("explosion", transform.position);
            transform.DOMove(transform.position+Vector3.up * Random.Range(0.75f, 1.25f),0.5f).OnComplete(()=>
            {
               
                transform.GetComponent<Renderer>().material.color = GameData.Instance.generalData.groundColor;
                Destroy(gameObject, 0.5f);
            });


        }
        AudioManager.Instance.PlayAudio("ballhit");



    }
}
