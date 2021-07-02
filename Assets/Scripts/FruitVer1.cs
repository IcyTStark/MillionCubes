using UnityEngine;
public class FruitVer1 : MonoBehaviour
{
    public static Material Apple;
    public static Material Avocado;
    public static Material Banana;
    public static Material Berry;
    public static Material Custdapple;
    public static Material Grape;
    public void Awake()
    {
        Apple = Resources.Load("FruitMat/Apple") as Material;
        Avocado = Resources.Load("FruitMat/Avacado") as Material;
        Banana = Resources.Load("FruitMat/Banana") as Material;
        Berry = Resources.Load("FruitMat/Berry") as Material;
        Custdapple = Resources.Load("FruitMat/CustardApple") as Material;
        Grape = Resources.Load("FruitMat/Grape") as Material;
    }
}
    

    

    

   

