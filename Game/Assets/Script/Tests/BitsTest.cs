using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class BitsTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void BitsTestSimplePasses()
    {
        SceneManager.LoadSceneAsync("Battle");
        Debug.Log(GameObject.FindObjectOfType<GameObject>().name);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator BitsTestWithEnumeratorPasses()
    {
        var Obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Obj.transform.position = Vector3.zero;
        Obj.transform.eulerAngles = new Vector3(10,20,30);
        Obj.name = "testingCube";
        Obj.tag ="Player";
        Obj.gameObject.SetActive(true);
        Obj.AddComponent<PlayerBits>();
        var Uobj = new GameObject();
        Uobj.AddComponent<TiltBits>();
        yield return null;
        List<Bits> tList = Obj.GetComponent<PlayerBits>().temporalBits;
        Assert.AreEqual(0,tList.Count);
        tList.Add(Uobj.GetComponent<TiltBits>());
        Assert.AreEqual(1, tList.Count);
        Debug.Log(Obj.transform.eulerAngles);
        Debug.Log(tList.Last<Bits>().name);
        Debug.Log(Obj.GetComponent<PlayerBits>().temporalBits.Last<Bits>().name);
        tList.Last<Bits>().Power();
        Debug.Log(Obj.transform.eulerAngles);
        Assert.AreNotEqual((0, 0, 40), Obj.transform.eulerAngles);
        yield return null;
    }
}
