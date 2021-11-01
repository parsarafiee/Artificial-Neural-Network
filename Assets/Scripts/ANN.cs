using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANN
{
    public int numInputs;
    public int numOutPuts;
    public int numHiddenLeyers;
    public int numPerHiddenLeyer;

    public double alpha;

    List<Layer> layers = new List<Layer>();

    public ANN(int nI, int nO, int nH, int nPH, double a)
    {
        numInputs = nI;
        numOutPuts = nO;
        numHiddenLeyers = nH;
        numPerHiddenLeyer = nPH;
        alpha = a;

        if (numHiddenLeyers>0)
        {
            layers.Add(new Layer(numPerHiddenLeyer, numInputs));

            for (int i = 0; i < numHiddenLeyers-1; i++)
            {
                layers.Add(new Layer(numPerHiddenLeyer, numPerHiddenLeyer));
            }
            layers.Add(new Layer(numOutPuts, numPerHiddenLeyer));

        }
        else
        {
            layers.Add(new Layer(numOutPuts, numInputs));
        }
}


}
