﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public abstract class Node : MonoBehaviour
{
    public virtual bool Run()
    {
        throw new NotImplementedException();
    }
}

public class CompositeNode : Node
{
    public override bool Run()     
    {
        throw new NotImplementedException();
    }

    public void AddChild(Node node) 
    {
        childrens.Push(node);
    }

    public Stack<Node> GetChildrens()  
    {
        return childrens;
    }
    private Stack<Node> childrens = new Stack<Node>();  
}

public class Selector : CompositeNode
{
    public override bool Run()
    {
        foreach (var node in GetChildrens())
        {
            if (node.Run())
            {
                return true;
            }
        }
        return false;

    }
}

public class Sequence : CompositeNode
{
    public override bool Run()
    {
        foreach (var node in GetChildrens())
        {
            if (!node.Run())
            {
                return false;
            }
        }
        return true;
    }
}


