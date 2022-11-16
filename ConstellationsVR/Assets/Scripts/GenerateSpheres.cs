using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpheres : MonoBehaviour
{
    public List<AudioClip> sounds = new List<AudioClip>();//we might not even need this reference to them?
    public Object[] soundsAsObjects;//we have this because Resources.LoadAll only returns Objects
    public float maxX, minX, maxY, minY, maxZ, minZ;//bounds for where spheres go. we might also need to make them not be in the middle, where you stand, which is harder...
    public GameObject soundSpherePrefab;
    public string filePath;//where our folder full of sounds is
    public List<Material> sphereMats = new List<Material>();//colors spheres can be. random for now
    // Start is called before the first frame update
    void Start()
    {
      Debug.Log("The start function starts");
      //generate spheres
      //This process is a bit stupid because Resources.LoadAll returns Objects,
      //And Unity is very concerned that they might not be AudioClips
      soundsAsObjects = Resources.LoadAll(filePath, typeof(AudioClip));
      Debug.Log("We get through loading sounds as Objects");
      foreach(Object soundAsObject in soundsAsObjects){
        sounds.Add((AudioClip)soundAsObject);
      }
      foreach(AudioClip sound in sounds){
        Vector3 pos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        GameObject newSphere = Instantiate(soundSpherePrefab, pos, Quaternion.identity);
        newSphere.GetComponent<AudioSource>().clip = sound;
        newSphere.GetComponent<Renderer>().material = sphereMats[Random.Range(0, sphereMats.Count)];
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
