using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using JetBrains.Annotations;
using System.IO;

public class Phrase
{
    public string term;
    public float occurrences;
}

public class WordSpawner : MonoBehaviour
{
    public GameObject wordObject;
    public float size = 10.0f;

    private List<Phrase> words = new List<Phrase>();
    private List<Phrase> randomWord = new List<Phrase>();

    private float totalOcc = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        ProcessWords();
        WordSpawn();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void WordSpawn()
    {
        int maxWords = Mathf.Min(10, words.Count);

        for (int i = 0; i < maxWords; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-2.5f, 2.6f), 2, Random.Range(-2.5f, 2.6f));

            GameObject child = Instantiate(wordObject, randomSpawnPosition, Quaternion.identity);
            TextMesh phraseText = child.GetComponent<TextMesh>();

            Phrase phrase = words[i];
            phraseText.text = phrase.term;

            float scale = (phrase.occurrences / totalOcc) * 25.0f;
            child.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    private void ProcessWords()
    {
        totalOcc = 0.0f;

        string jsonFile = File.ReadAllText(Application.dataPath + "/Json/result_json.json");
        JsonData jsonData = JsonMapper.ToObject(jsonFile);

        foreach (string key in jsonData.Keys)
        {
            Phrase phrase = new Phrase();
            phrase.term = key;
            phrase.occurrences = float.Parse(jsonData[key].ToString());
            words.Add(phrase);
            totalOcc += phrase.occurrences;
        }
    }

}
