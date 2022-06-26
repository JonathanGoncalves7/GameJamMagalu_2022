using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectType : MonoBehaviour
{
    private EnumObjectType type;
    public EnumObjectType Type { get => type; }
}

public enum EnumObjectType
{
    Car,
    Person
}
