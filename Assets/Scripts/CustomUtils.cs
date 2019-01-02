using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomUtils
{
    public enum WeaponTypes
    {
        Shotgun,
        Rifle,
        Pistol
    };

	public static float NextGaussian()
    {
        float v1, v2, s;
        int iterations = 0;
        do {
            v1 = 2.0f * Random.Range(0f, 1f) - 1.0f;
            v2 = 2.0f * Random.Range(0f, 1f) - 1.0f;
            s = v1 * v1 + v2 * v2;
            iterations++;
        } while (s >= 1.0f || s == 0f && iterations < 500);

        s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);

        return v1 * s;
    }

    public static float NextGaussian(float mean, float standard_deviation)
    {
        return mean + NextGaussian() * standard_deviation;
    }

    public static float NextGaussian(float mean, float standard_deviation, float min, float max)
    {
        if (min == max) {
            Debug.Log("YO YOU HAVE BAD GAUSSIAN VALUES");
            return -1;
        }

        float x;
        int iterations = 0;
        do {
            x = NextGaussian(mean, standard_deviation);
            iterations++;
        } while (x < min || x > max && iterations < 500);
        return x;
    }
}
