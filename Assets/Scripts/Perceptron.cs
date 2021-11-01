using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainingSet
{
    public float[] inputs;
    public float outputs;
}
public class Perceptron : MonoBehaviour
{
    public TrainingSet[] trainingset;

    float[] weights = { 0, 0 };
    float bias;
    float totalError = 0;
    

    void Start()
    {
        Train(8);

    }
    void Train(int epochs)
    {
        InitialData();
        for (int e = 0; e < epochs; e++)
        {
            totalError = 0;
            for (int i = 0; i < trainingset.Length; i++)
            {
                //UpdateWeights(t);
                Debug.Log("weights_1:" + weights[0] + " weights_2:" + weights[1] + " bias: " + bias);
            }
            Debug.Log("total Error = " + totalError);
        }
    }
    void InitialData()
    {
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] = Random.Range(-1.0f, 1.0f);
        }
        bias = Random.Range(-1.0f, 1.0f);
    }



    float DotProduct(float[] weights,float[] inputs)
    {
        if (weights.Length != inputs.Length)
            return -1;
        float dotAnswer = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            dotAnswer += weights[i] * inputs[i];
        }
        return dotAnswer+bias;
    }

    float CalcOutput(int i)
    {
        return DotProduct(weights, trainingset[i].inputs) > 0 ? 1 : 0;
    }
    void UpdateWeights(int t)
    {
        float newError = trainingset[t].outputs - CalcOutput(t);
        totalError += Mathf.Abs(newError);
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] = weights[i] + newError * trainingset[t].inputs[t];
        }
        bias += newError;

    }


    // Update is called once per frame
    void Update()
    {

    }
}
