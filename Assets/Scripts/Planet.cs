using UnityEngine;

public class Planet {
    public int id;
    public string name;
    public string region;
    public string climate;
    public string gravity;
    public string moons;
    public string day;
    public string year;
    public string natives;
    public string government;
    public string capital;
    public string market;
    public string facilities;

    public Planet(int i, string nam, string r, string cl, string gr, string mo, string d, string y, string nat, string go, string ca, string ma, string f) {
        id = i;
        name = nam;
        region = r;
        climate = cl;
        gravity = gr;
        moons = mo;
        day = d;
        year = y;
        natives = nat;
        government = go;
        capital = ca;
        market = ma;
        facilities = f;
    }
}
