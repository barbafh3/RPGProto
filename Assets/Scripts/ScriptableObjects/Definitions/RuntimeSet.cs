using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject
{

  public List<T> Items = new List<T>();

  public void Add(T t)
  {
    if (!Items.Contains(t)) Items.Add(t);
  }

  public void ForceAdd(T t)
  {
    Items.Add(t);
  }

  public void Remove(T t)
  {
    if (Items.Contains(t)) Items.Remove(t);
  }

  public void RemoveAt(int i)
  {
    if (Items[i] != null) Items.RemoveAt(i);
  }

  public virtual void SetNullAt(int i)
  {
    Items[i] = default(T);
  }

  public void AddAt(int i, T t)
  {
    if (Items[i] == null) Items[i] = t;
  }

  public void SwapAt(int i, T t)
  {
    Items[i] = t;
  }

}
