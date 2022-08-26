using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestTable {

    [Test]
    public void TestTableSimplePasses() {

        var db = new SampleDatabase();
        var tb = db.Textures;

        Assert.AreEqual(0, tb.Count);
        
        tb.Add(new TextureResource(db, tb, new IntKey(1)));
        Assert.AreEqual(1, tb.Count);
        var r1 = tb[new IntKey(1)];
        Assert.IsNotNull(r1);
        Assert.AreEqual(1, r1.Key.key);

        tb.Add(new TextureResource(db, tb, new IntKey(2)));
        Assert.AreEqual(2, tb.Count);
        var r2 = tb[new IntKey(2)];
        Assert.IsNotNull(r2);
        Assert.AreEqual(2, r2.Key.key);

        tb.Add(new TextureResource(db, tb, new IntKey(2)));
        Assert.AreEqual(2, tb.Count);
        var r3 = tb[new IntKey(2)];
        Assert.IsNotNull(r3);
        Assert.AreEqual(2, r3.Key.key);
        Assert.AreNotEqual(r2, r3);

        tb.Remove(new IntKey(2));
        Assert.AreEqual(1, tb.Count);
        Assert.IsFalse(tb.ContainsKey(new IntKey(2)));

        tb.Remove(new IntKey(2));
        Assert.AreEqual(1, tb.Count);
        Assert.IsFalse(tb.ContainsKey(new IntKey(2)));
        Assert.IsTrue(tb.ContainsKey(new IntKey(1)));

        tb.Remove(new IntKey(1));
        Assert.AreEqual(0, tb.Count);
        Assert.IsFalse(tb.ContainsKey(new IntKey(1)));
    }
}
