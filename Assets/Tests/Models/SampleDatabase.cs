using GenericDatabase.Collection;
using GenericDatabase.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct IntKey : IEquatable<IntKey>, IComparable<IntKey> {
    public readonly int key;

    public IntKey(int key) => this.key = key;

    #region IComparable
    public int CompareTo(IntKey other) => key.CompareTo(other.key);
    #endregion

    #region IEquatable
    public bool Equals(IntKey other) => key == other.key;
    #endregion

    #region object
    public override bool Equals(object obj) {
        if (!(obj is IntKey)) return false;
        return this.Equals((IntKey)obj);
    }
    public override int GetHashCode() => key;
    #endregion
}

public class TextureResource : BaseRow<SampleDatabase, TextureTable, TextureResource, IntKey> {
    public TextureResource(SampleDatabase db, TextureTable table, IntKey key) : base(db, table, key) {
    }
}

public class TextureTable : DictionaryTable<SampleDatabase, TextureTable, TextureResource, IntKey> {
    public TextureTable(SampleDatabase db) : base(db) {
    }
}

public class SampleDatabase : IDatabase, System.IDisposable {

    public SampleDatabase() {
        Textures = new TextureTable(this);
    }

    public TextureTable Textures { get; protected set; }

    public void Dispose() {
    }
}
