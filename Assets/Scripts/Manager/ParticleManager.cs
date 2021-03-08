using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : SingleBehaviour<ParticleManager>
{
    public List<ParticleData> allParticles;


    public void ShowParticle(string ID,Vector3 pos)
    {
       ParticleData findedparticle=allParticles.Find(x => x.ID == ID);
        GameObject createdparticle = Instantiate(findedparticle.particleprefab, pos, Quaternion.identity);
        Destroy(createdparticle, 2f);
    }

    [System.Serializable]
    public class ParticleData
    {
        public string ID;
        public GameObject particleprefab;

    }
}